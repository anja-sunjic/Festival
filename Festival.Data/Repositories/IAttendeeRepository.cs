using Festival.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festival.Data.Repositories
{
    public interface IAttendeeRepository
    {
        List<Attendee> GetAttendees();
        bool Add(Attendee a);
        bool AddUserAccount(UserAccount userAccount);
    }
}
