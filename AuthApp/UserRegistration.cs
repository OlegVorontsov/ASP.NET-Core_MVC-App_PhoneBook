using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_App_PhoneBook.AuthApp
{
    public class UserRegistration
    {
        [Required, MaxLength(20)]
        [Display(Name = "User name")]
        public string LoginProp { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords are different")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        public string PasswordConfirm { get; set; }
    }
}
