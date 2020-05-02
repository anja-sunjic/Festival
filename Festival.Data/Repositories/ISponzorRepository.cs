using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface ISponzorRepository
    {
        List<Sponsor> GetAll();
        void Add(Sponsor sponsor);
        void Save();
        Sponsor GetByID(int id);
        void Delete(int id);
    }
}
