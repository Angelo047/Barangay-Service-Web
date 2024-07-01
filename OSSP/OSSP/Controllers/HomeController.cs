using Grpc.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OSSP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;



namespace OSSP.Controllers
{
    public class HomeController : Controller
    {


        IConfiguration config;
        public HomeController(IConfiguration _config)
        {
            config = _config;
        }

        public IActionResult Index()
        {


            return View();

        }

        public IActionResult VerifyLogin(users u)
        {

            string email = u.email_address;
            string pass = u.password;
            ViewBag.loginMsg = "";
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE email_address = '" + email + "' AND password = '" + pass + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            if (reader.HasRows == false)
            {
                ViewBag.loginMsg = "error";
            }
            if (reader.HasRows)
            {

                reader.Read();
                int resNo = reader.GetInt32("resident_account");
                string fname = reader.GetString("first_name");
                string lname = reader.GetString("last_name");
                string accNo = Convert.ToString(resNo);


                if (reader.GetString("role") == "Resident" && reader.GetString("status") == "Unverified")
                {
                    HttpContext.Session.SetString("register", reader.GetString("email_address"));
                    HttpContext.Session.SetString("registerV", "email");
                    HttpContext.Session.SetInt32("codeNumber", users.rand.Next(1000, 9999));

                    MailMessage mm = new MailMessage();
                    mm.To.Add(u.email_address);
                    mm.Subject = "Verification Code";
                    mm.Body = "Your Verification code:" + HttpContext.Session.GetInt32("codeNumber");
                    mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
                    smtp.Send(mm);
                    return Redirect("~/Home/Verification");
                }
                else if (reader.GetString("role") == "Resident" && reader.GetString("status") == "Verified")
                {
                    HttpContext.Session.SetString("lname", fname);
                    HttpContext.Session.SetString("fname", lname);
                    HttpContext.Session.SetString("resident", accNo);
                    HttpContext.Session.SetString("residentV", "res");

                    return Redirect("~/Resident/Index");
                }
                else if (reader.GetString("role") == "Resident" && reader.GetString("status") == "Under Review")
                {
                    ViewBag.loginMsg = "Under Review";
                }
                else if (reader.GetString("role") == "Resident" && reader.GetString("status") == "Resubmit")
                {
                    ViewBag.loginMsg = "error";
                }
                else if (reader.GetString("role") == "Admin")
                {

                    HttpContext.Session.SetString("lname", fname);
                    HttpContext.Session.SetString("fname", lname);
                    string fullname = HttpContext.Session.GetString("fname") + " " + HttpContext.Session.GetString("lname");
                    HttpContext.Session.SetString("fullname", fullname);
                    HttpContext.Session.SetString("adminV", "Admin");
                    HttpContext.Session.SetString("admin", accNo);
                    return Redirect("~/Admin/Index");
                }

            }

            conn.Close();
            return View("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult pdfGen()
        {
            MemoryStream memory = new MemoryStream();
            PdfReader reader = new PdfReader(@"C:\Users\jep\source\repos\OSSP\OSSP\OSSP\wwwroot\PDF\pdf.pdf");
            PdfStamper stamper = new PdfStamper(reader, memory);

            AcroFields acroField = stamper.AcroFields;


            acroField.SetField("toWhom", "To Whom It May Concern:");
            acroField.SetField("body1", @"
            This is to certify that FERDINAND L. ILAGOR, 20 Years old, is a bona fide resident of Florentina Street, this Barangay. Since 2002 up to the present.");
            acroField.SetField("body2", @"
            This certification is being issued upon the request of the above-named person in compliance with the requirements of Quezon City University(QCU) and for whatever legal purposes it may serve.");
            acroField.SetField("date", "Given this 16th day of November, 2022.");
            acroField.SetField("capname", "REY ALDRIN S. TOLENTINO");
            acroField.SetField("position", "Barangay Captain");
            stamper.FormFlattening = true;
            stamper.Writer.CloseStream = false;
            stamper.Close();

            memory.Seek(0, SeekOrigin.Begin);

            return File(memory.ToArray(), "application/pdf");
        }
        public IActionResult Verification()
        {
            if (HttpContext.Session.GetString("registerV") != "email")
            {
                return Redirect("~/Home/");
            }
            return View();
        }
        public IActionResult Verify(int id)
        {
            if (HttpContext.Session.GetString("registerV") != "email") {
                return Redirect("~/Home/");
            }
            if (HttpContext.Session.GetInt32("codeNumber") == id)
            {
                return Json(new { data = "success" });
            }
            else
            {
                return Json(new { data = "error" });
            }

        }
        public IActionResult UpdateUnvAcc()
        {
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE [user]
            SET [status] = 'Under Review'
            WHERE email_address = '" + HttpContext.Session.GetString("register") + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            query = "SELECT * FROM [user] WHERE email_address = '" + HttpContext.Session.GetString("register") + "'";
            cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            reader.Read();
            var res = reader.GetInt32("resident_account");
            reader.Close();

            query = @"INSERT INTO notifications(resident_no, notif, request_type, notif_date, class, link, isRead, color) 
            VALUES(@res_no, @notif, @req_type, @notif_date, @class, @link, @isRead, @color)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@res_no", SqlDbType.Text).Value = res + "";
            cmd.Parameters.Add("@notif", SqlDbType.Text).Value = "New Account to Review";
            cmd.Parameters.Add("@req_type", SqlDbType.Text).Value = "Account";
            cmd.Parameters.Add("@notif_date", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@class", SqlDbType.Text).Value = "fa-user";
            cmd.Parameters.Add("@link", SqlDbType.Text).Value = "/Admin/accountApp";
            cmd.Parameters.Add("@isRead", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@color", SqlDbType.Text).Value = "bg-secondary";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            return Redirect("~/Home/");

        }
        public IActionResult Register()
        {
            return View(new users());

        }

        [HttpPost]
        public IActionResult Register(users u)
        {
            List<ValidationModel> Required = new List<ValidationModel>();
            if (u.id_card == null)
            {
                Required.Add(new ValidationModel() { ValidationId = "id_card", ValidationMsg = "Please enter valid ID." });
            }
            else if (u.id_card.ContentType != "image/png" && u.id_card.ContentType != "image/jpeg" && u.id_card.ContentType != "image/jpg")
            {
                Required.Add(new ValidationModel() { ValidationId = "id_card", ValidationMsg = "Only png, jpg, jpeg must be accepted." });
            }
            if (string.IsNullOrEmpty(u.last_name))
            {
                Required.Add(new ValidationModel() { ValidationId = "last_name", ValidationMsg = "Please enter your Last Name." });
            }
            if (u.birthday == null)
            {
                Required.Add(new ValidationModel() { ValidationId = "birthday", ValidationMsg = "Please enter your Birthday." });
            }
            if (string.IsNullOrEmpty(u.first_name))
            {
                Required.Add(new ValidationModel() { ValidationId = "first_name", ValidationMsg = "Please enter your First Name." });
            }

            if (string.IsNullOrEmpty(u.gender))
            {
                Required.Add(new ValidationModel() { ValidationId = "gender", ValidationMsg = "Please enter your Gender." });
            }
            if (string.IsNullOrEmpty(u.civil_status))
            {
                Required.Add(new ValidationModel() { ValidationId = "civil_status", ValidationMsg = "Please enter your Civil Status." });
            }
            if (string.IsNullOrEmpty(u.nationality))
            {
                Required.Add(new ValidationModel() { ValidationId = "nationality", ValidationMsg = "Please enter your Nationality." });
            }
            if (string.IsNullOrEmpty(u.email_address))
            {
                Required.Add(new ValidationModel() { ValidationId = "email_address", ValidationMsg = "Please enter your Email Address." });
            }
            if (string.IsNullOrEmpty(u.phone_number))
            {
                Required.Add(new ValidationModel() { ValidationId = "phone_number", ValidationMsg = "Please enter your Phone Number." });
            }
            if (string.IsNullOrEmpty(u.house_number))
            {
                Required.Add(new ValidationModel() { ValidationId = "house_number", ValidationMsg = "Please enter your House Number." });
            }
            if (string.IsNullOrEmpty(u.street))
            {
                Required.Add(new ValidationModel() { ValidationId = "street", ValidationMsg = "Please enter your Street." });
            }
            if (string.IsNullOrEmpty(u.password))
            {
                Required.Add(new ValidationModel() { ValidationId = "password", ValidationMsg = "Please enter your Password." });
            }
            if (string.IsNullOrEmpty(u.cPassword))
            {
                Required.Add(new ValidationModel() { ValidationId = "cPassword", ValidationMsg = "Please enter Confirm your Password." });
            }

            if (Required.Count > 0)
            {

                return Json(new { Data = Required });
            }




            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"SELECT * FROM [user] WHERE 
            email_address = '" + u.email_address + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            var reader2 = cmd.ExecuteReader();
            var msg = new ValidationModel();
            if (reader2.HasRows)
            {
                return Json(new { sample = "error" });
            }
            else
            {

                try
                {
                    HttpContext.Session.SetInt32("codeNumber", users.rand.Next(1000, 9999));

                    MailMessage mm = new MailMessage();
                    mm.To.Add(u.email_address);
                    mm.Subject = "Verification Code";
                    mm.Body = "Your Verification code:" + HttpContext.Session.GetInt32("codeNumber");
                    mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
                    smtp.Send(mm);
                }
                catch (Exception)
                {

                    return Json(new { sample = "no gmail" });
                }
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


                var lname = u.last_name;
                var fname = u.first_name;
                var mname = u.middle_name;
                var suffix = u.suffix;
                var bday = u.birthday;
                var gender = u.gender;
                var civS = u.civil_status;
                var email = u.email_address;
                var pn = u.phone_number;
                var hn = u.house_number;
                var st = u.street;
                var ntnl = u.nationality;
                var id = fileName;
                var role = "Resident";
                var password = u.password;
                var cpass = u.cPassword;
                var status = "Unverified";
                var mes = "";



                mes = "created";
                ViewBag.mes = mes;
                string commandText = @"INSERT INTO [user](last_name, first_name, middle_name, 
                suffix, birthday, gender, civil_status, email_address, phone_number, house_number, 
                street, nationality, id_card, role, password, status, 
                dateCreated) VALUES(@lname , @fname, @mname, @suffix, @bday, @gender, @civS, @email, 
                @pn, @hn, @st, @ntnl, @id, @role, @password, @status, @dateCreated); 
                SELECT 'Success' AS ValidationMsg FOR JSON PATH;
                ";


                using (SqlConnection connection = new SqlConnection(config.GetConnectionString("MyDB")))
                {


                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@lname", SqlDbType.Text).Value = lname + "";

                    command.Parameters.Add("@fname", SqlDbType.Text).Value = fname + "";

                    command.Parameters.Add("@mname", SqlDbType.Text).Value = mname + "";

                    command.Parameters.Add("@suffix", SqlDbType.Text).Value = suffix + "";

                    command.Parameters.Add("@bday", SqlDbType.Date).Value = (object)bday ?? DBNull.Value;

                    command.Parameters.Add("@gender", SqlDbType.Text).Value = gender + "";

                    command.Parameters.Add("@civS", SqlDbType.Text).Value = civS + "";

                    command.Parameters.Add("@email", SqlDbType.Text).Value = email + "";

                    command.Parameters.Add("@pn", SqlDbType.Text).Value = pn + "";

                    command.Parameters.Add("@hn", SqlDbType.Text).Value = hn + "";

                    command.Parameters.Add("@st", SqlDbType.Text).Value = st + "";

                    command.Parameters.Add("@ntnl", SqlDbType.Text).Value = ntnl + "";

                    command.Parameters.Add("@id", SqlDbType.Text).Value = id + "";

                    command.Parameters.Add("@role", SqlDbType.Text).Value = role + "";

                    command.Parameters.Add("@password", SqlDbType.Text).Value = password + "";

                    command.Parameters.Add("@status", SqlDbType.Text).Value = status + "";

                    command.Parameters.Add("@dateCreated", SqlDbType.DateTime).Value = DateTime.Now;




                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.

                    try
                    {




                        HttpContext.Session.SetString("register", u.email_address);
                        HttpContext.Session.SetString("registerV", "email");
                        connection.Open();
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            msg = JsonSerializer.Deserialize<List<ValidationModel>>(reader.GetValue(0).ToString()).FirstOrDefault();
                            reader.Close();
                        }
                        //Console.WriteLine("RowsAffected: {0}", rowsAffected);

                    }

                    catch (Exception ex)
                    {

                        throw;
                    }


                }


                return Json(new { Data = msg });
            }
            return Json(new { });
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ForgotPasswordVer(string id)
        {
            HttpContext.Session.SetString("email", id);
            HttpContext.Session.SetString("emailV", "email");
            users u = new users();
            ViewBag.forgotMsg = "";

            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT email_address FROM [user] WHERE email_address= '" + id + "' ", conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
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
                    mm.Subject = "Password Recovery Code";
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Message()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Message(users c)
        {
            ViewBag.forgotMsg = "";
            using (MailMessage mailMessage = new MailMessage())
            {
                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress("ilagor.vladimer@gmail.com"));
                mm.Subject = c.Subject;
                mm.Body = "Hi! <br/><br/> A new Message by user. Details is as follows : <br/><br/> Name : " + c.first_name + "<br/>Email : " + c.email_address + "<br/>Message : " + c.Body;
                mm.From = new MailAddress("ilagor.vladimer@gmail.com", "Barangay Gulod");
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("ilagor.vladimer@gmail.com", "nftyfgllffubpmtu");
                smtp.Send(mm);

                ViewBag.forgotMsg = "success";
            }
            return View();
        }

        public IActionResult ResetPassword()
        {
            if (HttpContext.Session.GetString("emailV") != "email")
            {
                return Redirect("~/Home/Index");
            }
            return View();
        }
        public IActionResult ResetPasswordVer(int id)
        {
            if (HttpContext.Session.GetString("emailV") != "email")
            {
                return Redirect("~/Home/Index");
            }

            if (id == HttpContext.Session.GetInt32("codeNumber"))
            {
                HttpContext.Session.SetString("passcode", "passcode");
                return Json(new { msg = "success" });
            }
            else
            {
                return Json(new { msg = "error" });
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
                mm.Subject = "Password Recovery Code";
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
        public IActionResult GetCode2()
        {
            if (HttpContext.Session.GetString("registerV") != "email")
            {
                return Redirect("~/Home/Index");
            }
            try
            {
                HttpContext.Session.SetInt32("codeNumber", users.rand.Next(1000, 9999));
                MailMessage mm = new MailMessage();
                mm.To.Add(HttpContext.Session.GetString("register"));
                mm.Subject = "Verification Code";
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
        public IActionResult RenewPassword()
        {
            if (HttpContext.Session.GetString("emailV") != "email")
            {
                return Redirect("~/Home/Index");
            }
            if (HttpContext.Session.GetString("passcode") != "passcode")
            {
                return Redirect("~/Home/Index");
            }
            return View();
        }
        public IActionResult RenewPasswordVer(string id)
        {
            if (HttpContext.Session.GetString("emailV") != "email")
            {
                return Redirect("~/Home/Index");
            }
            if (HttpContext.Session.GetString("passcode") != "passcode")
            {
                return Redirect("~/Home/Index");
            }
            SqlConnection conn = new SqlConnection(config.GetConnectionString("MyDB"));
            conn.Open();
            string query = @"UPDATE [user]
            SET[password] = '" + id + "' WHERE email_address = '" + HttpContext.Session.GetString("email") + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            HttpContext.Session.SetString("email", "");
            return Json(new { });
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
