using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface ITransferServiceRepository
    {
        List<TransferService> GetAllServicesForVehicle(int id);
        void Delete(int iD);
        List<TransferService> GetAll();
        void Add(TransferService transferService);
        void Save();
    }
}
