using Festival.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class TransferServiceRepository : ITransferServiceRepository
    {
        private readonly FestivalContext _context;

        public TransferServiceRepository(FestivalContext context)
        {
            _context = context;
        }

        public void Add(TransferService transferService)
        {
            _context.TransferService.Add(transferService);
            Save();

        }

        public void Delete(int iD)
        {
            TransferService service = _context.TransferService.Find(iD);
            _context.Remove(service);
            Save();

        }

        public List<TransferService> GetAll()
        {
            return _context.TransferService.ToList();
        }


        public List<TransferVehicle> GetAllVehicles()
        {
            return _context.TransferVehicle.ToList();
        }

        public TransferService GetByID(int id)
        {
            return _context.TransferService.Find(id);
        }

        public TransferVehicle GetVehicleByID(int vehicleId)
        {
            return _context.TransferVehicle.Find(vehicleId);
        }

        public string GetVehicleNameByVehicleID(int? transferVehicleID)
        {
            return _context.TransferVehicle.Where(a => a.ID == transferVehicleID).FirstOrDefault().Name;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
