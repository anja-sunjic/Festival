using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public class Attendee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserAccount Account { get; set; }
        public int? UserAccountID { get; set; }
    }   
}
