using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tele.Models
{
    public class User
    {
        [Required(ErrorMessage = "Required")]
        [Remote("IsUserNameAvailable", "User", ErrorMessage = "User Already Taken")]
        public string UserName { get; set; }
        public string UserNameForUpdate { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(10,ErrorMessage ="Phone No. should not be less than 10 digit")]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = "Required")]
        public string NewPassword { get; set; }
        [Remote("IsPasswordAvailable", "User", ErrorMessage = "Password Already Taken")]
        public string Password { get; set; }
        //public string CheckPassword { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public List<User> userList { get; set; }

    }
}