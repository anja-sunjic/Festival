using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface ITransferServiceRepository
    {
        TransferService GetByID(int id);
        List<TransferService> GetAll();
        void Delete(int iD);
        void Add(TransferService transferService);
        void Save();
        string GetVehicleNameByVehicleID(int? transferVehicleID);
        List<TransferVehicle> GetAllVehicles();
        TransferVehicle GetVehicleByID(int vehicleId);
    }
}
