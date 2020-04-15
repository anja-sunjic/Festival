using Festival.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class TransferVehicleRepository : ITransferVehicleRepository
    {
        private readonly FestivalContext _context;

        public TransferVehicleRepository(FestivalContext context)
        {
            _context = context;
        }

        public void Add(TransferVehicle transferVehicle)
        {
            _context.TransferVehicle.Add(transferVehicle);
            Save();
        }

        public void Delete(int id)
        {
            TransferVehicle vehicle = _context.TransferVehicle.Find(id);
            _context.Remove(vehicle);
            Save();
        }

        public List<TransferVehicle> GetAll()
        {
            return _context.TransferVehicle.ToList();
        }

        public TransferVehicle GetByID(int ID)
        {
            return _context.TransferVehicle.Find(ID);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
