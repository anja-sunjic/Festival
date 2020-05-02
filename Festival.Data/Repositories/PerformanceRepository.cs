using System.Collections.Generic;
using System.Linq;
using Festival.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Festival.Data.Repositories
{
    public class PerformanceRepository : IPerformanceRepository
    {
        private readonly FestivalContext _context;

        public PerformanceRepository(FestivalContext context)
        {
            _context = context;
        }
        public List<Performance> GetAll()
        {
            return _context.Performance
                .Include(a => a.Performer)
                .Include(a => a.Stage)
                .ToList();
        }

        public void Add(Performance performance)
        {
            _context.Performance.Add(performance);
            Save();
        }

        public void Delete(int id)
        {
            var performance = _context.Performance.Find(id);
            _context.Remove(performance);
            Save();
        }

        public Performance GetById(int id)
        {
            return GetAll().FirstOrDefault(a => a.ID == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Stage> GetAllStages()
        {
            return _context.Stage.ToList();
        }

        public List<Performer> GetAllPerformers()
        {
            return _context.Performer.ToList();
        }
    }
}