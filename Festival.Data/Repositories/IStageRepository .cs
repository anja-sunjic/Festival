using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface IStageRepository
    {
        List<Stage> GetAll();
        bool Add(Stage acc);
        bool Delete(int id);
        Stage GetByID(int id);
        void Save();
        List<Sponsor> GetAllSponsors();
        Sponsor GetSponsor(int id);

    }
}
