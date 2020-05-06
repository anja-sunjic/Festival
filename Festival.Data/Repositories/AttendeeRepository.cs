using Festival.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Festival.Data.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly FestivalContext _context;
        public AttendeeRepository(FestivalContext context)
        {
            _context = context;
        }
        public bool Add(Attendee a)
        {
            _context.Attendee.Add(a);
            if (_context.SaveChanges() > 0)
                return true;
            return false;

        }

        public bool AddUserAccount(UserAccount userAccount)
        {
            _context.UserAccount.Add(userAccount);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<Attendee> GetAttendees()
        {
            return _context.Attendee.ToList();
        }
    }
}
