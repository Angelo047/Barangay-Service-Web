using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSSP.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Net.Mail;

namespace OSSP.Controllers
{
    public class AdminController : Controller
    {
        IConfiguration config;
        public AdminController(IConfiguration _config)
        {
            config = _config;
        }
        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT COUNT(*) ver FROM [user] WHERE status = 'Verified' AND role = 'Resident'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                ViewBag.user = reader.GetInt32("ver");
                reader.Close();
            }

            query = @"SELECT COUNT(*) ver FROM brgy_documents
            WHERE status = 'Claimed'
            AND docu_type = 'Barangay Indigency'
            AND MONTH(date_apply) = MONTH(CURRENT_TIMESTAMP) 
            AND YEAR(date_apply) = YEAR(CURRENT_TIMESTAMP);";
            cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                ViewBag.ind = reader.GetInt32("ver");
                reader.Close();
            }

            query = @"SELECT COUNT(*) ver FROM brgy_documents
            WHERE status = 'Claimed'
            AND docu_type = 'Barangay Clearance'
            AND MONTH(date_apply) = MONTH(CURRENT_TIMESTAMP) 
            AND YEAR(date_apply) = YEAR(CURRENT_TIMESTAMP);";
            cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                ViewBag.clear = reader.GetInt32("ver");
                reader.Close();
            }

            query = @"SELECT COUNT(*) ver FROM brgy_id
            WHERE status = 'Claimed'
            AND MONTH(date_apply) = MONTH(CURRENT_TIMESTAMP) 
            AND YEAR(date_apply) = YEAR(CURRENT_TIMESTAMP);";
            cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                ViewBag.id = reader.GetInt32("ver");
                reader.Close();
            }


            reader.Close();
            conn.Close();
            return View();

        }
        public IActionResult Notif()
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT TOP 3 n.*, u.first_name fname, u.last_name lname 
            FROM notifications n, [user] u WHERE n.resident_no = u.resident_account
            ORDER BY notif_date DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userlist.Add(new users()
                    {
                        notif_date = reader.GetDateTime("notif_date").ToString("MMM dd, yyyy | hh: mm tt"),
                        resident_accountBD = reader.GetString("fname") + " "+ reader.GetString("lname"),
                        notif = reader.GetString("notif"),
                        req_type = reader.GetString("request_type"),
                        link = reader.GetString("link"),
                        isclass = reader.GetString("class"),
                        color = reader.GetString("color"),
                    });
                }
            }
            reader.Close();
            query = @"SELECT COUNT(isRead) isRead FROM notifications WHERE isRead = '0'";
            cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();
            reader.Read();
            var count = reader.GetInt32("isRead");
            reader.Close();
            conn.Close();
            return Json(new { Data = userlist, notifCount = count });
        }

        public IActionResult isReadNotif()
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE notifications
            SET isRead = '1'
            WHERE isRead = '0'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            return Json(new { });
        }
        public IActionResult Notifications()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT n.*, u.first_name fname, u.last_name lname 
            FROM notifications n, [user] u WHERE n.resident_no = u.resident_account
            ORDER BY notif_date DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userlist.Add(new users()
                    {
                        notif_date = reader.GetDateTime("notif_date").ToString("MMM dd, yyyy | hh: mm"),
                        resident_accountBD = reader.GetString("fname") + " " + reader.GetString("lname"),
                        notif = reader.GetString("notif"),
                        req_type = reader.GetString("request_type"),
                        link = reader.GetString("link"),
                        isclass = reader.GetString("class"),
                        color = reader.GetString("color"),
                    });
                }
            }
            reader.Close();
            query = @"SELECT COUNT(isRead) isRead FROM notifications WHERE isRead = '0'";
            cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();
            reader.Read();
            var count = reader.GetInt32("isRead");
            reader.Close();
            conn.Close();
            return View(userlist);
        }
        public IActionResult accountApp()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE status = 'Under Review'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("dateCreated").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_account = reader.GetInt32("resident_account"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        email_address = reader.GetString("email_address"),

                    });
                }
            }

            conn.Close();
            return View(userlist);
        }
        public IActionResult account(int resNo)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            users model = new users();
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE resident_account = '" + resNo + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();

            model.resident_account = reader.GetInt32("resident_account");
            model.last_name = reader.GetString("last_name");
            model.first_name = reader.GetString("first_name");
            model.middle_name = reader.GetString("middle_name");
            model.suffix = reader.GetString("suffix");
            model.birthday = reader.GetDateTime("birthday");
            model.gender = reader.GetString("gender");
            model.civil_status = reader.GetString("civil_status");
            model.nationality = reader.GetString("nationality");
            model.email_address = reader.GetString("email_address");
            model.phone_number = reader.GetString("phone_number");
            model.house_number = reader.GetString("house_number");
            model.street = reader.GetString("street");
            model.id_cardDesc = reader.GetString("id_card");




            conn.Close();


            return View(model);
        }

        public IActionResult accountRes()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }

            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE status = 'Resubmit' AND role = 'Resident'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("dateCreated").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_account = reader.GetInt32("resident_account"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        email_address = reader.GetString("email_address"),

                    });
                }
            }

            conn.Close();
            return View(userlist);
        }
        public IActionResult accountView(int resNo)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }

            users model = new users();
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE resident_account = '" + resNo + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();
            ViewBag.redirect = "accountRes";
            if (reader.GetString("status") == "Verified")
            {
                ViewBag.redirect = "accountVer";
            }
            else if (reader.GetString("status") == "Resubmit")
            {
                ViewBag.redirect = "accountRes";
            }
            model.resident_account = reader.GetInt32("resident_account");
            model.last_name = reader.GetString("last_name");
            model.first_name = reader.GetString("first_name");
            model.middle_name = reader.GetString("middle_name");
            model.suffix = reader.GetString("suffix");
            model.birthday = reader.GetDateTime("birthday");
            model.gender = reader.GetString("gender");
            model.civil_status = reader.GetString("civil_status");
            model.nationality = reader.GetString("nationality");
            model.email_address = reader.GetString("email_address");
            model.phone_number = reader.GetString("phone_number");
            model.house_number = reader.GetString("house_number");
            model.street = reader.GetString("street");
            model.id_cardDesc = reader.GetString("id_card");




            conn.Close();


            return View(model);
        }
        public IActionResult accountVer()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            ViewBag.redirect = "accountVer";
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE status = 'Verified' AND role = 'Resident'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("dateCreated").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_account = reader.GetInt32("resident_account"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        email_address = reader.GetString("email_address"),

                    });
                }
            }

            conn.Close();
            return View(userlist);
        }

        public IActionResult clearance(int reqNo)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            users model = new users();
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] as u, brgy_documents as bd
            where u.resident_account = bd.resident_no AND bd.request_no = '" + reqNo + "' AND docu_type = 'Barangay Clearance'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();
            model.print_status = reader.GetString("print_status");
            model.request_no = reader.GetInt32("request_no");
            model.resident_account = reader.GetInt32("resident_account");
            model.last_name = reader.GetString("last_name");
            model.first_name = reader.GetString("first_name");
            model.middle_name = reader.GetString("middle_name");
            model.suffix = reader.GetString("suffix");
            model.birthday = reader.GetDateTime("birthday");
            model.gender = reader.GetString("gender");
            model.civil_status = reader.GetString("civil_status");
            model.nationality = reader.GetString("nationality");
            model.email_address = reader.GetString("email_address");
            model.phone_number = reader.GetString("phone_number");
            model.house_number = reader.GetString("house_number");
            model.street = reader.GetString("street");
            model.id_cardDesc = reader.GetString("idcard");
            model.pictureDesc = reader.GetString("id_pic");
            model.purpose = reader.GetString("purpose");
            conn.Close();
            return View(model);
        }

        public IActionResult clearanceApp()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [brgy_documents] WHERE status = 'Under Review' AND docu_type = 'Barangay Clearance';";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("request_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        purpose = reader.GetString("purpose"),
                        print_status = reader.GetString("print_status"),


                    });


                }
            }

            conn.Close();
            return View(userlist);
        }
        public IActionResult clearanceRel()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [brgy_documents] WHERE status = 'Released' AND docu_type = 'Barangay Clearance'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("request_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        purpose = reader.GetString("purpose"),

                    });


                }
            }

            conn.Close();
            return View(userlist);
        }
        public IActionResult clearanceClaimed()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [brgy_documents] WHERE
            status = 'Claimed' AND docu_type = 'Barangay Clearance'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        dateClaimedString = reader.GetDateTime("date_claimed").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("request_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        purpose = reader.GetString("purpose"),

                    });


                }
            }

            conn.Close();
            return View(userlist);
        }
        public IActionResult clearanceRes()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [brgy_documents] WHERE status = 'Resubmit' AND docu_type = 'Barangay Clearance'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("request_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        purpose = reader.GetString("purpose"),

                    });


                }
            }

            conn.Close();
            return View(userlist);
        }
        public IActionResult clearanceView(int reqNo)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            users model = new users();
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] as u, brgy_documents as bd
            where u.resident_account = bd.resident_no AND bd.request_no = '" + reqNo + "' AND docu_type = 'Barangay Clearance'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            reader.Read();
            model.print_status = reader.GetString("print_status");
            model.purpose = reader.GetString("purpose");
            model.request_no = reader.GetInt32("request_no");
            model.resident_account = reader.GetInt32("resident_account");
            model.last_name = reader.GetString("last_name");
            model.first_name = reader.GetString("first_name");
            model.middle_name = reader.GetString("middle_name");
            model.suffix = reader.GetString("suffix");
            model.birthday = reader.GetDateTime("birthday");
            model.gender = reader.GetString("gender");
            model.civil_status = reader.GetString("civil_status");
            model.nationality = reader.GetString("nationality");
            model.email_address = reader.GetString("email_address");
            model.phone_number = reader.GetString("phone_number");
            model.house_number = reader.GetString("house_number");
            model.street = reader.GetString("street");
            model.id_cardDesc = reader.GetString("idcard");
            model.pictureDesc = reader.GetString("id_pic");
            conn.Close();
            return View(model);
        }
        public static string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }
        public IActionResult PrintUpdate(int id)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE brgy_documents
            SET [print_status] = 'Printed'
            WHERE request_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            return Json(new { });
        }
        public IActionResult PrintIDUpdate(int id)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE brgy_id
            SET [print_status] = 'Done'
            WHERE id_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            return Json(new { });
        }
        public IActionResult IDPrint(int id)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            //string query = @"UPDATE brgy_documents
            //SET [print_status] = 'Printed'
            //WHERE request_no = '" + id + "'";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.CommandType = CommandType.Text;
            //cmd.ExecuteNonQuery();

            string query2 = @"SELECT A.*, B.* FROM [user] A, brgy_id
            B WHERE A.resident_account = B.resident_no
            AND B.id_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();
            string FullName = reader.GetString("first_name") + " " + reader.GetString("last_name");

            var myAge = DateTime.Now.Date.Subtract(reader.GetDateTime("birthday")).Days;
            myAge /= 365;
            var Year = reader.GetDateTime("birthday").ToString("yyyy");
            MemoryStream memory = new MemoryStream();
            PdfReader reader2 = new PdfReader(@"C:\Users\jep\source\repos\OSSP\OSSP\OSSP\wwwroot\PDF\id.pdf");
            PdfStamper stamper = new PdfStamper(reader2, memory);
            Stream inputImageStream = new FileStream(@"C:\Users\jep\source\repos\OSSP\OSSP\OSSP\wwwroot\Files\" + reader.GetString("twoxtwo_pic") + "", FileMode.Open, FileAccess.Read, FileShare.Read);
            AcroFields acroField = stamper.AcroFields;
            var pdfContentByte = stamper.GetOverContent(1);
            Image image = Image.GetInstance(inputImageStream);
            image.SetAbsolutePosition(182, 204);
            image.ScaleAbsoluteHeight(76.5f);
            image.ScaleAbsoluteWidth(83f);


            pdfContentByte.AddImage(image);

            acroField.SetField("date", DateTime.Now.ToString("MMM. dd, yyyy"));
            acroField.SetField("name", FullName);
            acroField.SetField("address", reader.GetString("house_number") + " " + reader.GetString("street") + " Street");
            acroField.SetField("dno", Convert.ToString(reader.GetInt32("id_no")));
            acroField.SetField("expiration", "Valid until " + DateTime.Now.AddMonths(6).ToString("MMM. dd, yyyy"));
            acroField.SetField("emername", reader.GetString("emer_name"));
            acroField.SetField("telno", reader.GetString("emerphone_no"));
            acroField.SetField("emeraddress", reader.GetString("emerhouse_no") + " " + reader.GetString("emerstreet") + " Street");

            stamper.FormFlattening = true;
            stamper.Writer.CloseStream = false;
            stamper.Close();

            memory.Seek(0, SeekOrigin.Begin);

            return File(memory.ToArray(), "application/pdf");
        }
        public IActionResult ClearancePrint(int id)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            //string query = @"UPDATE brgy_documents
            //SET [print_status] = 'Printed'
            //WHERE request_no = '" + id + "'";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.CommandType = CommandType.Text;
            //cmd.ExecuteNonQuery();

            string query2 = @"SELECT A.*, B.* FROM [user] A, brgy_documents
            B WHERE A.resident_account = B.resident_no
            AND B.request_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();
            string FullName = reader.GetString("first_name") + " " + reader.GetString("last_name");
            string purpose = reader.GetString("purpose");
            var myAge = DateTime.Now.Date.Subtract(reader.GetDateTime("birthday")).Days;
            myAge /= 365;
            var Year = reader.GetDateTime("birthday").ToString("yyyy");
            MemoryStream memory = new MemoryStream();
            PdfReader reader2 = new PdfReader(@"C:\Users\jep\source\repos\OSSP\OSSP\OSSP\wwwroot\PDF\pdfClearance.pdf");
            PdfStamper stamper = new PdfStamper(reader2, memory);
            Stream inputImageStream = new FileStream(@"C:\Users\jep\source\repos\OSSP\OSSP\OSSP\wwwroot\Files\" + reader.GetString("id_pic") + "", FileMode.Open, FileAccess.Read, FileShare.Read);
            AcroFields acroField = stamper.AcroFields;
            var pdfContentByte = stamper.GetOverContent(1);
            Image image = Image.GetInstance(inputImageStream);
            image.SetAbsolutePosition(196, 584);
            image.ScaleAbsoluteHeight(94f);
            image.ScaleAbsoluteWidth(98f);


            pdfContentByte.AddImage(image);

            acroField.SetField("toWhom", "To Whom It May Concern:");
            acroField.SetField("date", DateTime.Now.ToString("MMMM dd, yyyy"));
            acroField.SetField("name", FullName);
            acroField.SetField("street", reader.GetString("house_number") + " " + reader.GetString("street") + " Street");
            acroField.SetField("purpose", reader.GetString("purpose"));
            acroField.SetField("capname", "REY ALDRIN S. TOLENTINO");
            acroField.SetField("position", "Barangay Captain");
            stamper.FormFlattening = true;
            stamper.Writer.CloseStream = false;
            stamper.Close();

            memory.Seek(0, SeekOrigin.Begin);

            return File(memory.ToArray(), "application/pdf");
        }
        public IActionResult IndigencyPrint(int id)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            //string query = @"UPDATE brgy_documents
            //SET [print_status] = 'Printed'
            //WHERE request_no = '" + id + "'";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.CommandType = CommandType.Text;
            //cmd.ExecuteNonQuery();

            string query2 = @"SELECT A.*, B.* FROM [user] A, brgy_documents
            B WHERE A.resident_account = B.resident_no
            AND B.request_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();
            string FullName = reader.GetString("first_name") + " " + reader.GetString("last_name");
            string purpose = reader.GetString("purpose");
            var myAge = DateTime.Now.Date.Subtract(reader.GetDateTime("birthday")).Days;
            myAge /= 365;
            var Year = reader.GetDateTime("birthday").ToString("yyyy");
            MemoryStream memory = new MemoryStream();
            PdfReader reader2 = new PdfReader(@"C:\Users\jep\source\repos\OSSP\OSSP\OSSP\wwwroot\PDF\pdf.pdf");
            PdfStamper stamper = new PdfStamper(reader2, memory);

            AcroFields acroField = stamper.AcroFields;


            acroField.SetField("toWhom", "To Whom It May Concern:");
            acroField.SetField("body1", @"
            This is to certify that " + FullName + ", " + myAge + " Years old, is a bona fide resident of " + reader.GetString("house_number") + " " + reader.GetString("street") + " Street, this Barangay. Since " + reader.GetString("YearRes") + " up to the present.");
            acroField.SetField("body2", @"
            This certification is being issued upon the request of the above-named person in compliance with the requirements of " + purpose + " and for whatever legal purposes it may serve.");
            acroField.SetField("date", "Given this " + AddOrdinal(Convert.ToInt32(DateTime.Now.ToString("dd"))) + " day of " + DateTime.Now.ToString("MMMM, yyyy") + ".");
            acroField.SetField("capname", "REY ALDRIN S. TOLENTINO");
            acroField.SetField("position", "Barangay Captain");
            stamper.FormFlattening = true;
            stamper.Writer.CloseStream = false;
            stamper.Close();

            memory.Seek(0, SeekOrigin.Begin);

            return File(memory.ToArray(), "application/pdf");
        }

        //public IActionResult IndigencyPrint(int id)
        //{
        //    Document docu = new Document();
        //    Font fontstyle;
        //    PdfPCell pdfC;
        //    MemoryStream memoStream = new MemoryStream();

        //    byte[] me() {
        //        docu = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
        //        docu.SetMargins(20f, 20f, 20f, 20f);
        //        fontstyle = FontFactory.GetFont("Times New Roman", 20f, 1);
        //        PdfWriter.GetInstance(docu, memoStream);
        //        docu.Open();
        //        pdfC = new PdfPCell(new Phrase("C E R T I F I C A T I O N", fontstyle));
        //        docu.Close();
        //        return memoStream.ToArray();
        //    }
        //    return View();

        //}

        public IActionResult indigency(int reqNo)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            users model = new users();
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] as u, brgy_documents as bd
            where u.resident_account = bd.resident_no AND bd.request_no = '" + reqNo + "' AND docu_type = 'Barangay Indigency'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();
            model.print_status = reader.GetString("print_status");
            model.request_no = reader.GetInt32("request_no");
            model.resident_account = reader.GetInt32("resident_account");
            model.last_name = reader.GetString("last_name");
            model.first_name = reader.GetString("first_name");
            model.middle_name = reader.GetString("middle_name");
            model.suffix = reader.GetString("suffix");
            model.birthday = reader.GetDateTime("birthday");
            model.gender = reader.GetString("gender");
            model.civil_status = reader.GetString("civil_status");
            model.nationality = reader.GetString("nationality");
            model.email_address = reader.GetString("email_address");
            model.phone_number = reader.GetString("phone_number");
            model.house_number = reader.GetString("house_number");
            model.street = reader.GetString("street");
            model.id_cardDesc = reader.GetString("idcard");
            model.purpose = reader.GetString("purpose");
            conn.Close();
            return View(model);
        }


        public IActionResult indigencyApp()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }

            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [brgy_documents] WHERE status = 'Under Review' AND docu_type = 'Barangay Indigency'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("request_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        purpose = reader.GetString("purpose"),
                        print_status = reader.GetString("print_status"),

                    });


                }
            }

            conn.Close();
            return View(userlist);

        }
        public IActionResult indigencyRel()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [brgy_documents] WHERE status = 'Released' AND docu_type = 'Barangay Indigency'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("request_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        purpose = reader.GetString("purpose"),

                    });


                }
            }

            conn.Close();
            return View(userlist);

        }
        public IActionResult indigencyRes()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [brgy_documents] WHERE status = 'Resubmit' AND docu_type = 'Barangay Indigency'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("request_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        purpose = reader.GetString("purpose"),

                    });


                }
            }

            conn.Close();
            return View(userlist);

        }
        public IActionResult indigencyClaimed()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [brgy_documents] WHERE
            status = 'Claimed' AND docu_type = 'Barangay Indigency'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("request_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        purpose = reader.GetString("purpose"),
                        dateClaimedString = reader.GetDateTime("date_claimed").ToString("MMM. dd, yyyy | hh:mm tt"),

                    });


                }
            }

            conn.Close();
            return View(userlist);
        }
        public IActionResult indigencyView(int reqNo)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            users model = new users();
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] as u, brgy_documents as bd
            where u.resident_account = bd.resident_no AND bd.request_no = '" + reqNo + "' AND docu_type = 'Barangay Indigency'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            reader.Read();
            model.print_status = reader.GetString("print_status");
            model.request_no = reader.GetInt32("request_no");
            model.resident_account = reader.GetInt32("resident_account");
            model.last_name = reader.GetString("last_name");
            model.first_name = reader.GetString("first_name");
            model.middle_name = reader.GetString("middle_name");
            model.suffix = reader.GetString("suffix");
            model.birthday = reader.GetDateTime("birthday");
            model.gender = reader.GetString("gender");
            model.civil_status = reader.GetString("civil_status");
            model.nationality = reader.GetString("nationality");
            model.email_address = reader.GetString("email_address");
            model.phone_number = reader.GetString("phone_number");
            model.house_number = reader.GetString("house_number");
            model.street = reader.GetString("street");
            model.id_cardDesc = reader.GetString("idcard");
            model.purpose = reader.GetString("purpose");
            conn.Close();
            return View(model);
        }

        public IActionResult UpdateID(int id, string msg)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE brgy_id
            SET [status] = 'Released', message = '" + msg + "' WHERE id_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            string adminName = HttpContext.Session.GetString("fullname");
            string query2 = @"INSERT INTO Audit_Trail(record, date)VALUES('ID Number:" + id + " marked as Released by " + adminName + "', '" + DateTime.Now + "')";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string query3 = "SELECT * FROM brgy_id WHERE id_no = '" + id + "'";
            cmd = new SqlCommand(query3, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            reader.Read();
            string resiNo = reader.GetString("resident_no");
            reader.Close();

            string query4 = "SELECT * FROM [user] WHERE resident_account = '" + resiNo + "'";
            cmd = new SqlCommand(query4, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();

            reader.Read();
            MailMessage mm = new MailMessage();
            mm.To.Add(reader.GetString("email_address"));
            mm.Subject = "Document Released";
            mm.Body = "Good day " + reader.GetString("first_name") + "! Your ID request has has been released. You may now claim it in our barangay\n\n" + msg + "\n\nHave a nice Day!";
            mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
            smtp.Send(mm);
            reader.Close();
            conn.Close();
            return Json(new { });
        }
        public IActionResult UpdateIDC(int id)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE brgy_id
            SET [status] = 'Claimed', date_claimed = '" + DateTime.Now + "' WHERE id_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            string adminName = HttpContext.Session.GetString("fullname");
            string query2 = @"INSERT INTO Audit_Trail(record, date)VALUES('ID Number:" + id + " marked as Claimed by " + adminName + "', '" + DateTime.Now + "')";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            return Json(new { });
        }
        public IActionResult ResubmitID(int id, string msg)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE brgy_id
            SET [status] = 'Resubmit', message = '" + msg + "' WHERE id_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            string adminName = HttpContext.Session.GetString("fullname");
            string query2 = @"INSERT INTO Audit_Trail(record, date)VALUES('ID Number:" + id + " marked as Resubmit by " + adminName + "', '" + DateTime.Now + "')";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            string query3 = "SELECT * FROM brgy_id WHERE id_no = '" + id + "'";
            cmd = new SqlCommand(query3, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            reader.Read();
            string resiNo = reader.GetString("resident_no");
            reader.Close();

            string query4 = "SELECT * FROM [user] WHERE resident_account = '" + resiNo + "'";
            cmd = new SqlCommand(query4, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();

            reader.Read();
            MailMessage mm = new MailMessage();
            mm.To.Add(reader.GetString("email_address"));
            mm.Subject = "Document Released";
            mm.Body = "Good day " + reader.GetString("first_name") + "! We're sorry to say that your ID request has to resubmit due to this reason:\n\n" + msg + "\n\nHave a nice Day!";
            mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
            smtp.Send(mm);
            reader.Close();
            conn.Close();
            return Json(new { });
        }
        public IActionResult id(int reqNo)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            users model = new users();
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] as u, brgy_id as bd
            where u.resident_account = bd.resident_no AND bd.id_no = '" + reqNo + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            reader.Read();

            model.request_no = reader.GetInt32("id_no");
            model.resident_account = reader.GetInt32("resident_account");
            model.last_name = reader.GetString("last_name");
            model.first_name = reader.GetString("first_name");
            model.middle_name = reader.GetString("middle_name");
            model.suffix = reader.GetString("suffix");
            model.birthday = reader.GetDateTime("birthday");
            model.gender = reader.GetString("gender");
            model.civil_status = reader.GetString("civil_status");
            model.nationality = reader.GetString("nationality");
            model.email_address = reader.GetString("email_address");
            model.phone_number = reader.GetString("phone_number");
            model.house_number = reader.GetString("house_number");
            model.street = reader.GetString("street");
            model.id_cardDesc = reader.GetString("idcard");
            model.emername = reader.GetString("emer_name");
            model.emerhn = reader.GetString("emerhouse_no");
            model.emerst = reader.GetString("emerstreet");
            model.emerpn = reader.GetString("emerphone_no");
            model.pictureDesc = reader.GetString("twoxtwo_pic");
            conn.Close();
            return View(model);
        }
        public IActionResult idView(int reqNo)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            users model = new users();
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] as u, brgy_id as bd
            where u.resident_account = bd.resident_no AND bd.id_no = '" + reqNo + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            reader.Read();

            model.request_no = reader.GetInt32("id_no");
            model.resident_account = reader.GetInt32("resident_account");
            model.last_name = reader.GetString("last_name");
            model.first_name = reader.GetString("first_name");
            model.middle_name = reader.GetString("middle_name");
            model.suffix = reader.GetString("suffix");
            model.birthday = reader.GetDateTime("birthday");
            model.gender = reader.GetString("gender");
            model.civil_status = reader.GetString("civil_status");
            model.nationality = reader.GetString("nationality");
            model.email_address = reader.GetString("email_address");
            model.phone_number = reader.GetString("phone_number");
            model.house_number = reader.GetString("house_number");
            model.street = reader.GetString("street");
            model.id_cardDesc = reader.GetString("idcard");
            model.emername = reader.GetString("emer_name");
            model.emerhn = reader.GetString("emerhouse_no");
            model.emerst = reader.GetString("emerstreet");
            model.emerpn = reader.GetString("emerphone_no");
            model.pictureDesc = reader.GetString("twoxtwo_pic");
            conn.Close();
            return View(model);
        }
        public IActionResult idApp()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT A.status stat, A.*, B.* FROM brgy_id A
            LEFT JOIN [user] B ON A.resident_no = B.resident_account
            WHERE A.status = 'Under Review'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("id_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        print_status = reader.GetString("print_status"),

                    });


                }
            }

            conn.Close();
            return View(userlist);

        }
        public IActionResult idRel()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT A.status stat, A.*, B.* FROM brgy_id A
            LEFT JOIN [user] B ON A.resident_no = B.resident_account
            WHERE A.status = 'Released'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("id_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        print_status = reader.GetString("print_status"),

                    });


                }
            }

            conn.Close();
            return View(userlist);
        }
        public IActionResult idRes()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT A.status stat, A.*, B.* FROM brgy_id A
            LEFT JOIN [user] B ON A.resident_no = B.resident_account
            WHERE A.status = 'Resubmit'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("id_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        print_status = reader.GetString("print_status"),

                    });


                }
            }

            conn.Close();
            return View(userlist);
        }
        public IActionResult idClaimed()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT A.status stat, A.*, B.* FROM brgy_id A
            LEFT JOIN [user] B ON A.resident_no = B.resident_account
            WHERE A.status = 'Claimed'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();


            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {



                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date_apply").ToString("MMM. dd, yyyy | hh:mm tt"),
                        resident_accountBD = reader.GetString("resident_no"),
                        request_no = reader.GetInt32("id_no"),
                        last_name = reader.GetString("last_name"),
                        first_name = reader.GetString("first_name"),
                        print_status = reader.GetString("print_status"),
                        dateClaimedString = reader.GetDateTime("date_claimed").ToString("MMM. dd, yyyy | hh:mm tt"),

                    });


                }
            }

            conn.Close();
            return View(userlist);
        }


        public IActionResult UpdateAcc(int id)
        {

            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE [user]
            SET [status] = 'Verified'
            WHERE resident_account = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string adminName = HttpContext.Session.GetString("fullname");
            string query2 = @"INSERT INTO Audit_Trail(record, date)VALUES('Resident Number:" + id + " marked as Verified by " + adminName + "', '" + DateTime.Now + "')";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();


            string query4 = "SELECT * FROM [user] WHERE resident_account = '" + id + "'";
            cmd = new SqlCommand(query4, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                MailMessage mm = new MailMessage();
                mm.To.Add(reader.GetString("email_address"));
                mm.Subject = "Account Verified";
                mm.Body = "Good day " + reader.GetString("first_name") + "! Your account has been verified. You may now request the documents you need in this barangay. Have a nice Day!";
                mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
                smtp.Send(mm);
            }
            conn.Close();


            return Json(new { });
        }

        public IActionResult UpdateIndC(int id)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE [brgy_documents]
            SET [status] = 'Claimed', date_claimed = CURRENT_TIMESTAMP
            WHERE request_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            string adminName = HttpContext.Session.GetString("fullname");
            string query2 = @"INSERT INTO Audit_Trail(record, date)VALUES('Request Number:" + id + " marked as Claimed by " + adminName + "', '" + DateTime.Now + "')";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            ViewBag.sucs = "success";
            return Json(new { Data = "Success"});
        }

        public IActionResult ResubmitAcc(int id, string msg)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE [user]
            SET [status] = 'Resubmit'
            WHERE resident_account = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string adminName = HttpContext.Session.GetString("fullname");
            string query2 = @"INSERT INTO Audit_Trail(record, date)VALUES('Resident Number:" + id + " marked as Resubmit by " + adminName + "', '" + DateTime.Now + "')";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string query3 = @"UPDATE [user]
            SET message = '" + msg + "' WHERE resident_account = '" + id + "'";
            cmd = new SqlCommand(query3, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string query4 = "SELECT * FROM [user] WHERE resident_account = '" + id + "'";
            cmd = new SqlCommand(query4, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                MailMessage mm = new MailMessage();
                mm.To.Add(reader.GetString("email_address"));
                mm.Subject = "Account Disapproved";
                mm.Body = "Good day " + reader.GetString("first_name") + "! We're sorry to say that your account need to resubmit due to this reason:\n\n" + msg + "\n\nHave a nice Day!";
                mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
                smtp.Send(mm);
            }
            conn.Close();



            return Json(new { });
        }
        public IActionResult UpdateInd(int id, string msg)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE brgy_documents
            SET [status] = 'Released', message = '" + msg + " " + "' WHERE request_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            string adminName = HttpContext.Session.GetString("fullname");
            string query2 = @"INSERT INTO Audit_Trail(record, date)VALUES('Request Number:" + id + " Released by " + adminName + "', '" + DateTime.Now + "')";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();


            string query3 = "SELECT * FROM brgy_documents WHERE request_no = '" + id + "'";
            cmd = new SqlCommand(query3, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            reader.Read();
            string resiNo = reader.GetString("resident_no");
            string bd = reader.GetString("docu_type");
            reader.Close();

            string query4 = "SELECT * FROM [user] WHERE resident_account = '" + resiNo + "'";
            cmd = new SqlCommand(query4, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();

            reader.Read();
            MailMessage mm = new MailMessage();
            mm.To.Add(reader.GetString("email_address"));
            mm.Subject = "Document Released";
            mm.Body = "Good day " + reader.GetString("first_name") + "! Your " + bd + " has been released. You may now claim it here in our Barangay.\n\n " + msg + "\n\nThank You and Have a nice Day!";
            mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
            smtp.Send(mm);
            reader.Close();
            conn.Close();
            return Json(new { });
        }
        public IActionResult ResubmitInd(int id, string msg)
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE brgy_documents
            SET [status] = 'Resubmit', message = '" + msg + " " + "' WHERE request_no = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            string adminName = HttpContext.Session.GetString("fullname");
            string query2 = @"INSERT INTO Audit_Trail(record, date)VALUES('Request Number:" + id + " marked as Resubmit by " + adminName + "', '" + DateTime.Now + "')";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string query3 = "SELECT * FROM brgy_documents WHERE request_no = '" + id + "'";
            cmd = new SqlCommand(query3, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            reader.Read();
            string resiNo = reader.GetString("resident_no");
            string bd = reader.GetString("docu_type");
            reader.Close();

            string query4 = "SELECT * FROM [user] WHERE resident_account = '" + resiNo + "'";
            cmd = new SqlCommand(query4, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();

            reader.Read();
            MailMessage mm = new MailMessage();
            mm.To.Add(reader.GetString("email_address"));
            mm.Subject = "Document Disapproved";
            mm.Body = "Good day " + reader.GetString("first_name") + "! We're sorry to say that your " + bd + " request has to resubmit due to this reason:\n\n" + msg + "\n\nHave a nice Day!";
            mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
            smtp.Send(mm);
            reader.Close();
            conn.Close();
            return Json(new { });
        }

        public IActionResult AuditTrail()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.GetString("name");
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM Audit_Trail";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            List<users> userlist = new List<users>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userlist.Add(new users()
                    {
                        dateString = reader.GetDateTime("date").ToString("MMM. dd, yyyy | hh:mm tt"),
                        record_no = reader.GetInt32("record_no"),
                        record = reader.GetString("record"),


                    });
                }
            }

            conn.Close();
            return View(userlist);

        }

        public IActionResult PrintDoc()
        {

            Document doc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            MemoryStream stream = new MemoryStream();

            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, stream);
            pdfWriter.CloseStream = false;

            doc.Open();
            doc.SetMargins(10f, 10f, 10f, 10f);
            PdfPTable table = new PdfPTable(2);
            table.SetWidths(new int[] { 2, 2 });
            PdfPCell cell = new PdfPCell();
            Phrase ph = new Phrase();
            Chunk ck = new Chunk("C E R T I F I C A T I O N", FontFactory.GetFont("Times-Roman", 20, Font.BOLD | Font.UNDERLINE));

            cell.Colspan = 2;
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_MIDDLE;
            cell.VerticalAlignment = Element.ALIGN_CENTER;


            cell.AddElement(ck);


            table.AddCell(cell);
            doc.Add(table);

            doc.Add(new Paragraph("Hello Worldddd", FontFactory.GetFont("Times-Roman", 20, Font.BOLD | Font.UNDERLINE)));
            doc.Add(new Paragraph("Hello Worldddd", FontFactory.GetFont("Times-Roman", 20, Font.BOLD | Font.UNDERLINE)));

            doc.Close();

            stream.Flush(); //Always catches me out
            stream.Position = 0; //Not sure if this is required

            return new FileContentResult(stream.ToArray(), "application/pdf");
        }

        public IActionResult Profile(int id)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }

            users model = new users();
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE resident_account = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();
            ViewBag.redirect = "accountRes";

            model.resident_account = reader.GetInt32("resident_account");
            model.last_name = reader.GetString("last_name");
            model.first_name = reader.GetString("first_name");
            model.middle_name = reader.GetString("middle_name");
            model.suffix = reader.GetString("suffix");
            model.birthday = reader.GetDateTime("birthday");
            model.gender = reader.GetString("gender");
            model.civil_status = reader.GetString("civil_status");
            model.nationality = reader.GetString("nationality");
            model.email_address = reader.GetString("email_address");
            model.phone_number = reader.GetString("phone_number");
            model.house_number = reader.GetString("house_number");
            model.street = reader.GetString("street");
            model.id_cardDesc = reader.GetString("id_card");

            conn.Close();

            return View(model);
        }


        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(users model)
        {
            string current = model.password;
            string NewPass = model.NewPassword;
            string ConPass = model.ConfirmPassword;
            ViewBag.changeMsg = "";

            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }


            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            string query = "SELECT * FROM [user] WHERE resident_account = '" + HttpContext.Session.GetString("admin") + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();
            var email = reader.GetString("email_address");
            reader.Close();
            SqlDataAdapter da = new SqlDataAdapter("select * from [user] where password='" + current + "' and email_address = '" + email + "' ", conn);
            users modal = new users();
            DataTable dt = new DataTable();

            da.Fill(dt);


            if (dt.Rows.Count == 0)
            {
                ViewBag.changeMsg = "error";
            }
            else if (NewPass != ConPass)
            {
                ViewBag.changeMsg = "errors";
            }
            else
            {
                da = new SqlDataAdapter(@"UPDATE [user] SET password ='" + NewPass + "' where email_address = '" + email + "' ", conn);
                da.Fill(dt);
                ViewBag.changeMsg = "success";
            }
            conn.Close();
            return View();

        }
        public IActionResult ChangeEmail()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Index");
            }
            return View();
        }
        public IActionResult ResetEmail()
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Index");
            }
            return View();
        }
        public IActionResult ResetEmailVer(int id)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Index");
            }

            if (id == HttpContext.Session.GetInt32("codeNumber"))
            {

                SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
                string query = "SELECT email_address FROM [user] WHERE resident_account = '" + HttpContext.Session.GetString("admin") + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    var email = reader.GetString("email_address");
                    reader.Close();
                    query = "UPDATE [user] SET email_address = '" + HttpContext.Session.GetString("email") + "' WHERE email_address = '" + email + "'";
                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return Json(new { msg = "success" });
                }

            }
            else
            {
                return Json(new { msg = "error" });
            }
            return View("ResetEmail");
        }
        public IActionResult ChangeEmailCode(string id)
        {
            if (HttpContext.Session.GetString("adminV") != "Admin")
            {
                return Redirect("~/Home/Login");
            }
            HttpContext.Session.SetString("email", id);
            HttpContext.Session.SetString("emailV", "email");
            users u = new users();
            ViewBag.forgotMsg = "";

            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT email_address FROM [user] WHERE email_address= '" + id + "' ", conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return Json(new { msg = "error" });
            }
            else
            {


                conn.Close();

                try
                {
                    HttpContext.Session.SetInt32("codeNumber", users.rand.Next(1000, 9999));
                    MailMessage mm = new MailMessage();
                    mm.To.Add(id);
                    mm.Subject = "Email Verification Code";
                    mm.Body = "Your Code is: " + HttpContext.Session.GetInt32("codeNumber");
                    mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
                    smtp.Send(mm);

                    return Json(new { msg = "success" });
                }
                catch (Exception)
                {

                    return Json(new { msg = "error" });
                }


            }


        }
        public IActionResult GetCode()
        {
            if (HttpContext.Session.GetString("emailV") != "email")
            {
                return Redirect("~/Home/Index");
            }
            try
            {
                HttpContext.Session.SetInt32("codeNumber", users.rand.Next(1000, 9999));
                MailMessage mm = new MailMessage();
                mm.To.Add(HttpContext.Session.GetString("email"));
                mm.Subject = "Email Verification Code";
                mm.Body = "Your Code is: " + HttpContext.Session.GetInt32("codeNumber");
                mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
                smtp.Send(mm);

                return Json(new { msg = "success" });
            }
            catch (Exception)
            {

                return Json(new { msg = "error" });
            }

        }
    }
}
