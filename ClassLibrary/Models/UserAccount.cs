using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public enum AccountType { attendee, admin}
    public class UserAccount
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountType Type { get; set; }
        public int? AccountTypeID { get; set; }
    }
}
