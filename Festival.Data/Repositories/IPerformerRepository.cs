using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface IPerformerRepository
    {
        List<Performer> GetAll();
        bool Add(Performer performer);
        void Delete(int id);
        Performer GetByID(int id);
        void Save();
        string FindManager(int managerId);
        void AddManager(Manager manager);
        Manager FindManagerById(int managerId);
        List<Manager> GetAllManagers();
    }
}
