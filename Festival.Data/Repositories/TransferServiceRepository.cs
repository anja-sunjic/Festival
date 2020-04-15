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

        public List<TransferService> GetAllServicesForVehicle(int id)
        {
            return _context.TransferService.Where(a => a.TransferVehicle.ID == id).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
