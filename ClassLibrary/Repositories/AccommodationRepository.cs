using Festival.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly FestivalContext _context;

        public AccommodationRepository(FestivalContext context)
        {
            _context = context;
        }

        public bool Add(Accommodation acc)
        {
            _context.Accommodation.Add(acc);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            Accommodation accommodation = _context.Accommodation.Find(id);
            _context.Remove(accommodation);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<Accommodation> GetAll()
        {
            return _context.Accommodation.ToList();
        }

        public Accommodation GetByID(int id)
        {
            return _context.Accommodation.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
