using Festival.Data.Models;
using System;
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
        List<TransferService> GetByDate(DateTime date);
        TransferVehicle GetVehicleByID(int vehicleId);
    }
}
