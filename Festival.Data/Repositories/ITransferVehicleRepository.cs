using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface ITransferVehicleRepository
    {
        List<TransferVehicle> GetAll();
        TransferVehicle GetByID(int ID);
        void Add(TransferVehicle transferVehicle);
        void Save();
        void Delete(int id);
    }
}
