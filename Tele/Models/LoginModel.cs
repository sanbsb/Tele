using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tele.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Provide current password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserId { get; set; }
        public string EmailId { get; set; }
    }
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Provide current password")]
        [DataType(DataType.Password)]
        [Display(Name = "Old password")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Provide new password")]
        [StringLength(100, ErrorMessage = "The password must be at least 8 characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "New password")]
        public string ConfirmPassword { get; set; }
        public Guid userId { get; set; }
    }
    public class ResetPasswordModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email")]
        public string Email { get; set; }
    }
}
