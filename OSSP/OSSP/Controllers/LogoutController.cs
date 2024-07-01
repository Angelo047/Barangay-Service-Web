using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSSP.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult resLogout()
        {

           
            HttpContext.Session.Remove("resident");
            HttpContext.Session.Remove("residentV");

            return Redirect("~/Home/Login");
            
        }
        public IActionResult adminLogout()
        {


            HttpContext.Session.Remove("admin");
            HttpContext.Session.Remove("adminV");

            return Redirect("~/Home/Login");

        }
    }
}
