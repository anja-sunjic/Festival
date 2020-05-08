using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival.Web.Areas.Guest.ViewModels.Attendee
{
    public class NewAttendeeVM
    {
        [Required(ErrorMessage = "First name is required, please insert it.")]
        public string FirstName { get; set; } 

        [Required(ErrorMessage = "Last name is required, please insert it.")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required, please insert it.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Phone number is required, please insert it.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Username is required, please insert the amount.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Promo text for the performer is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
