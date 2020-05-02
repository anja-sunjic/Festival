using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface IPerformanceRepository
    {
        List<Performance> GetAll();
        void Add(Performance performer);
        void Delete(int id);
        Performance GetById(int id);
        void Save();
        List<Stage> GetAllStages();
        List<Performer> GetAllPerformers();
    }
}
