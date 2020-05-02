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
            return _context.Performer.Include(a=>a.Manager).ToList();
        }

        public bool Add(Performer performer)
        {
            _context.Performer.Add(performer);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public void Delete(int id)
        {
            var performer = _context.Performer.Find(id);
            _context.Remove(performer);

            Save();
        }

        public Performer GetByID(int id)
        {
            return _context.Performer.Include(a=>a.Manager).FirstOrDefault(b=>b.ID==id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public string FindManager(int managerId)
        {
            return _context.Manager.FirstOrDefault(m => m.ID == managerId)?.Name;
        }

        public void AddManager(Manager manager)
        {
            _context.Manager.Add(manager);
            Save();
        }

        public Manager FindManagerById(int managerId)
        {
            return  _context.Manager.Find(managerId);
        }

        public List<Manager> GetAllManagers()
        {
            return _context.Manager.ToList();
        }
    }
}

