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
            if (performer == null) throw new Exception($"Can't find performer with Id: {id}");

            _context.Remove(performer);

            Save();
        }

        public Performer GetByID(int id)
        {
            var performer = _context.Performer.Include(a => a.Manager).FirstOrDefault(b => b.ID == id);
            if (performer == null) throw new Exception($"Can't find performer with Id: {id}");

            return performer;
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
            var manager = _context.Manager.Find(managerId);
            if (manager == null) throw new Exception($"Can't find manager with Id: {managerId}");

            return manager;
        }

        public List<Manager> GetAllManagers()
        {
            return _context.Manager.ToList();
        }
    }
}

