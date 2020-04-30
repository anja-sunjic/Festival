using Festival.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class StageRepository : IStageRepository
    {
        private readonly FestivalContext _context;

        public StageRepository(FestivalContext context)
        {
            _context = context;
        }

        public bool Add(Stage acc)
        {
            _context.Stage.Add(acc);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            Stage stage = _context.Stage.Find(id);
            _context.Remove(stage);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<Stage> GetAll()
        {
            return _context.Stage.Include(s=> s.Sponsor).ToList();
        }

        public Stage GetByID(int id)
        {
            return _context.Stage.Find(id);
        }
        public Sponsor GetSponsor(int id)
        {
            return _context.Sponsor.First(s => s.ID == _context.Stage.Find(id).SponsorID);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public List<Sponsor> GetAllSponsors()
        {
            return _context.Sponsor.ToList();
        }

    }
}
