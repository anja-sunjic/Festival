using Festival.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Festival.Data.Repositories
{
    public class PerformerRepository : IPerformerRepository
    {
        private readonly FestivalContext _context;
        public PerformerRepository(FestivalContext context)
        {
            _context = context;
        }
        public List<Performer> GetAll()
        {
            return _context.Performer.Include(p => p.Manager).ToList();
   
        }
        public bool Add(Performer performer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Performer GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public List<Sponsor> GetAllSponsors()
        {
            throw new NotImplementedException();
        }
    }
}
