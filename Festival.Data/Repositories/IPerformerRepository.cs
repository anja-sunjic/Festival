using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface IPerformerRepository
    {
        List<Performer> GetAll();
        bool Add(Performer performer);
        bool Delete(int id);
        Performer GetByID(int id);
        void Save();
        List<Sponsor> GetAllSponsors();
        
    }
}
