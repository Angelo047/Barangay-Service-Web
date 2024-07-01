using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using OSSP.Models;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using System.IO;
using System.Net.Mail;

namespace OSSP.Controllers
{
    public class ResidentController : Controller
    {
        IConfiguration config;
        public ResidentController(IConfiguration _config)
        {
            config = _config;
        }

        public IActionResult Index(users u)
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE resident_account = '" + HttpContext.Session.GetString("resident") + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();


            ViewBag.fname = reader.GetString("first_name");
            ViewBag.lname = reader.GetString("last_name");


            conn.Close();
            return View();

        }

        public IActionResult upload(users u)
        {


            var me = DateTime.Now.Millisecond;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(u.id_card.FileName);
            string fileName = me + u.id_card.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                u.id_card.CopyTo(stream);
            }

            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"INSERT INTO brgy_documents(resident_no, last_name, first_name, docu_type, 
            purpose, status, idcard, date_apply, print_status, YearRes) VALUES(@resNo, @lname, @fname, @docu_type, @purpose,
            @status, @id, @dateApply, @pt, @yr)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@resNo", SqlDbType.Text).Value = HttpContext.Session.GetString("resident") + "";
            cmd.Parameters.Add("@lname", SqlDbType.Text).Value = u.last_name + "";
            cmd.Parameters.Add("@fname", SqlDbType.Text).Value = u.first_name + "";
            cmd.Parameters.Add("@docu_type", SqlDbType.Text).Value = u.docu_type + "";
            if (u.purpose != "OTHERS")
                cmd.Parameters.Add("@purpose", SqlDbType.Text).Value = u.purpose + "";
            else
                cmd.Parameters.Add("@purpose", SqlDbType.Text).Value = u.others + "";
            cmd.Parameters.Add("@status", SqlDbType.Text).Value = "Under Review";
            cmd.Parameters.Add("@id", SqlDbType.Text).Value = fileName;
            cmd.Parameters.Add("@dateApply", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@pt", SqlDbType.Text).Value = " ";
            cmd.Parameters.Add("@yr", SqlDbType.Text).Value = u.yearres;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            query = @"INSERT INTO notifications(resident_no, notif, request_type, notif_date, class, link, isRead, color) 
            VALUES(@res_no, @notif, @req_type, @notif_date, @class, @link, @isRead, @color)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@res_no", SqlDbType.Text).Value = HttpContext.Session.GetString("resident") + "";
            cmd.Parameters.Add("@notif", SqlDbType.Text).Value = "New " + u.docu_type + " Request";
            cmd.Parameters.Add("@req_type", SqlDbType.Text).Value = u.docu_type + "";
            cmd.Parameters.Add("@notif_date", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@class", SqlDbType.Text).Value = "fa-certificate";
            cmd.Parameters.Add("@link", SqlDbType.Text).Value = "/Admin/indigencyApp";
            cmd.Parameters.Add("@isRead", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@color", SqlDbType.Text).Value = "bg-success";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            return Json(new { });
        }
        public IActionResult upload2(users u)
        {


            var me = DateTime.Now.Millisecond;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(u.id_card.FileName);
            string fileName = me + u.id_card.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                u.id_card.CopyTo(stream);
            }

            FileInfo fileInfo2 = new FileInfo(u.picture.FileName);
            string fileName2 = me + u.picture.FileName;

            string fileNameWithPath2 = Path.Combine(path, fileName2);

            using (var stream = new FileStream(fileNameWithPath2, FileMode.Create))
            {
                u.picture.CopyTo(stream);
            }

            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"INSERT INTO brgy_id(resident_no, emer_name, emerhouse_no, 
            emerstreet, emerphone_no, twoxtwo_pic, idcard, date_apply, status, print_status)
            VALUES(@resNo, @ename, @ehn, @est, @epn, @txtp, @id, @da, @status, @ps)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@resNo", SqlDbType.Text).Value = HttpContext.Session.GetString("resident") + "";
            cmd.Parameters.Add("@ename", SqlDbType.Text).Value = u.emername + "";
            cmd.Parameters.Add("@ehn", SqlDbType.Text).Value = u.emerhn + "";
            cmd.Parameters.Add("@est", SqlDbType.Text).Value = u.emerst + "";
            cmd.Parameters.Add("@epn", SqlDbType.Text).Value = u.emerpn + "";
            cmd.Parameters.Add("@txtp", SqlDbType.Text).Value = fileName2;
            cmd.Parameters.Add("@id", SqlDbType.Text).Value = fileName;
            cmd.Parameters.Add("@da", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@status", SqlDbType.Text).Value = "Under Review";
            cmd.Parameters.Add("@ps", SqlDbType.Text).Value = " ";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            query = @"INSERT INTO notifications(resident_no, notif, request_type, notif_date, class, link, isRead, color) 
            VALUES(@res_no, @notif, @req_type, @notif_date, @class, @link, @isRead, @color)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@res_no", SqlDbType.Text).Value = HttpContext.Session.GetString("resident") + "";
            cmd.Parameters.Add("@notif", SqlDbType.Text).Value = "New ID Request";
            cmd.Parameters.Add("@req_type", SqlDbType.Text).Value = "Barangay ID";
            cmd.Parameters.Add("@notif_date", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@class", SqlDbType.Text).Value = "fa-id-card";
            cmd.Parameters.Add("@link", SqlDbType.Text).Value = "/Admin/idApp";
            cmd.Parameters.Add("@isRead", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@color", SqlDbType.Text).Value = "bg-info";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();

            return Json(new { });
        }
        public IActionResult upload3(users u)
        {


            var me = DateTime.Now.Millisecond;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(u.id_card.FileName);
            string fileName = me + u.id_card.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                u.id_card.CopyTo(stream);
            }

            FileInfo fileInfo2 = new FileInfo(u.picture.FileName);
            string fileName2 = me + u.picture.FileName;

            string fileNameWithPath2 = Path.Combine(path, fileName2);

            using (var stream = new FileStream(fileNameWithPath2, FileMode.Create))
            {
                u.picture.CopyTo(stream);
            }

            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"INSERT INTO brgy_documents(resident_no, last_name, first_name, docu_type, 
            purpose, status, idcard, date_apply, print_status, id_pic) VALUES(@resNo, @lname, @fname, @docu_type, @purpose,
            @status, @id, @dateApply, @pt, @idpic)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@resNo", SqlDbType.Text).Value = HttpContext.Session.GetString("resident") + "";
            cmd.Parameters.Add("@lname", SqlDbType.Text).Value = u.last_name + "";
            cmd.Parameters.Add("@fname", SqlDbType.Text).Value = u.first_name + "";
            cmd.Parameters.Add("@docu_type", SqlDbType.Text).Value = u.docu_type + "";
            if (u.purpose != "OTHERS")
                cmd.Parameters.Add("@purpose", SqlDbType.Text).Value = u.purpose + "";
            else
                cmd.Parameters.Add("@purpose", SqlDbType.Text).Value = u.others + "";
            cmd.Parameters.Add("@status", SqlDbType.Text).Value = "Under Review";
            cmd.Parameters.Add("@id", SqlDbType.Text).Value = fileName;
            cmd.Parameters.Add("@dateApply", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@pt", SqlDbType.Text).Value = " ";
            cmd.Parameters.Add("@idpic", SqlDbType.Text).Value = fileName2;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            query = @"INSERT INTO notifications(resident_no, notif, request_type, notif_date, class, link, isRead, color) 
            VALUES(@res_no, @notif, @req_type, @notif_date, @class, @link, @isRead, @color)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@res_no", SqlDbType.Text).Value = HttpContext.Session.GetString("resident") + "";
            cmd.Parameters.Add("@notif", SqlDbType.Text).Value = "New " + u.docu_type + " Request";
            cmd.Parameters.Add("@req_type", SqlDbType.Text).Value = u.docu_type + "";
            cmd.Parameters.Add("@notif_date", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@class", SqlDbType.Text).Value = "fa-folder";
            cmd.Parameters.Add("@link", SqlDbType.Text).Value = "/Admin/clearanceApp";
            cmd.Parameters.Add("@isRead", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@color", SqlDbType.Text).Value = "bg-danger";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();

            return Json(new { });
        }
        public IActionResult indigency(users u)
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }



            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE resident_account = '" + HttpContext.Session.GetString("resident") + "'";
            users model = new users();
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

        public IActionResult clearance()
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }

            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE resident_account = '" + HttpContext.Session.GetString("resident") + "'";
            users model = new users();
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
        public IActionResult id()
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE resident_account = '" + HttpContext.Session.GetString("resident") + "'";
            users model = new users();
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
        public IActionResult indprogress()
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT B.status stat, B.*, A.* FROM [user] A, brgy_documents B 
            WHERE A.resident_account = '" + HttpContext.Session.GetString("resident") + "' AND B.resident_no = '" + HttpContext.Session.GetString("resident") + "' AND B.docu_type = 'Barangay Indigency' AND B.status = 'Under Review'";
            users model = new users();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            var stats = true;
            if (reader.HasRows)
            {
                stats = false;
                ViewBag.stat = "Under Review";
            }
            reader.Close();
            string query2 = @"SELECT B.status stat, B.*, A.* FROM [user] A, brgy_documents B 
            WHERE A.resident_account = '" + HttpContext.Session.GetString("resident") + "' AND B.resident_no = '" + HttpContext.Session.GetString("resident") + "' AND B.docu_type = 'Barangay Indigency' AND B.status = 'Released'";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                stats = false;
                ViewBag.stat = "Released";
            }
            if (stats)
            {
                return Redirect("~/Resident/indigency");
            }



            return View();
        }
        public IActionResult idprogress()
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT B.status stat, B.*, A.* FROM [user] A, brgy_id B 
            WHERE A.resident_account = '" + HttpContext.Session.GetString("resident") + "' AND B.resident_no = '" + HttpContext.Session.GetString("resident") + "' AND B.status = 'Under Review'";
            users model = new users();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            var stats = true;
            if (reader.HasRows)
            {
                stats = false;
                ViewBag.stat = "Under Review";
            }
            reader.Close();
            string query2 = @"SELECT B.status stat, B.*, A.* FROM [user] A, brgy_id B 
            WHERE A.resident_account = '" + HttpContext.Session.GetString("resident") + "' AND B.resident_no = '" + HttpContext.Session.GetString("resident") + "' AND B.status = 'Released'";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                stats = false;
                ViewBag.stat = "Released";
            }
            if (stats)
            {
                return Redirect("~/Resident/id");
            }



            return View();
        }
        public IActionResult clearanceprogress()
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT B.status stat, B.*, A.* FROM [user] A, brgy_documents B 
            WHERE A.resident_account = '" + HttpContext.Session.GetString("resident") + "' AND B.resident_no = '" + HttpContext.Session.GetString("resident") + "' AND B.docu_type = 'Barangay Clearance' AND B.status = 'Under Review'";
            users model = new users();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            var stats = true;
            if (reader.HasRows)
            {
                stats = false;
                ViewBag.stat = "Under Review";
            }
            reader.Close();
            string query2 = @"SELECT B.status stat, B.*, A.* FROM [user] A, brgy_documents B 
            WHERE A.resident_account = '" + HttpContext.Session.GetString("resident") + "' AND B.resident_no = '" + HttpContext.Session.GetString("resident") + "' AND B.docu_type = 'Barangay Clearance' AND B.status = 'Released'";
            cmd = new SqlCommand(query2, conn);
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                stats = false;
                ViewBag.stat = "Released";
            }
            if (stats)
            {
                return Redirect("~/Resident/clearance");
            }



            return View();
        }
        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetString("residentV") != "res")
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

            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }


            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            string query = "SELECT * FROM [user] WHERE resident_account = '" + HttpContext.Session.GetString("resident") + "'";
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

        public IActionResult Profile(int id)
        {
            if (HttpContext.Session.GetString("residentV") != "res")
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
        public IActionResult ChangeEmail()
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }
            return View();
        }
        public IActionResult ResetEmail()
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Login");
            }
            return View();
        }
        public IActionResult ResetEmailVer(int id)
        {
            if (HttpContext.Session.GetString("residentV") != "res")
            {
                return Redirect("~/Home/Index");
            }

            if (id == HttpContext.Session.GetInt32("codeNumber"))
            {

                SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
                string query = "SELECT email_address FROM [user] WHERE resident_account = '" + HttpContext.Session.GetString("resident") + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    var email = reader.GetString("email_address");
                    reader.Close();
                    query = "UPDATE [user] SET email_address = '" + HttpContext.Session.GetString("email") + "' WHERE email_address = '"+email+"'";
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
            if (HttpContext.Session.GetString("residentV") != "res")
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
