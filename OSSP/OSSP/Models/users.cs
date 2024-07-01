using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OSSP.Models
{
    public class users
    {
        public int resident_account { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string suffix { get; set; }
        public string gender { get; set; }
        public string civil_status { get; set; }
        public DateTime? birthday { get; set; }
        public string email_address { get; set; }
        public string phone_number { get; set; }
        public string house_number { get; set; }
        public string street { get; set; }
        public string nationality { get; set; }
        public string passwords { get; set; }
        public string role { get; set; }
        public IFormFile id_card { get; set; }
        public DateTime? date { get; set; }
        public string cPassword { get; set; }
        public string yearres { get; set; }
        public string dateString { get; set; }
        public string dateClaimedString { get; set; }

        public string redi { get; set; }

        public IFormFile picture { get; set; }
        public string emername { get; set; }
        public string emerhn { get; set; }
        public string emerst { get; set; }
        public string emerpn { get; set; }
        public string resident_accountBD { get; set; }
        public string resident_accountBDNotif { get; set; }
        public int request_no { get; set; }
        public string docu_type { get; set; }
        public string purpose { get; set; }
        public string others { get; set; }
        public string status { get; set; }
        public string print_status { get; set; }
        public string link { get; set; }
        public string isclass { get; set; }
        public string color { get; set; }


        public string stat { get; set; }

        [NotMapped] public int notifCount { get; set; }
    [NotMapped] public string pictureDesc { get; set; }
        [NotMapped] public string id_cardDesc { get; set; }
        [NotMapped] public string birthdayDesc => birthday == null ? "" : birthday.Value.ToString("MM-dd-yyyy");
        [NotMapped] public string dateDesc => date == null ? "" : date.Value.ToString("MM-dd-yyyy");

        public int record_no { get; set; }
        public string admin_name { get; set; }
        public string record { get; set; }

        public static Random rand = new Random();

        public string notif { get; set; }
        public string req_type { get; set; }
        public string notif_date { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please Enter Your New Password")]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "The password must be atleast 8 characters long", MinimumLength = 8)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "The password must be atleast 8 characters long", MinimumLength = 8)]
        public string ConfirmPassword { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool EmailSent { get; set; }
    }

    public class ValidationModel {
        public string ValidationMsg { get; set; }
        public string ValidationId { get; set; }
    }
}
