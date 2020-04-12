using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface IAccommodationRepository
    {
        List<Accommodation> GetAll();
        bool Add(Accommodation acc);
        bool Delete(int id);
        Accommodation GetByID(int id);
        void Save();
    }
}
