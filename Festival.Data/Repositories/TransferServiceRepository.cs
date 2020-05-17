using System;
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

        public void Delete(int Id)
        {
            TransferService service = _context.TransferService.Find(Id);
            if(service == null) throw new Exception($"Can't find transfer service with Id: {Id}");

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

        public TransferService GetByID(int Id)
        {
            var transferService = _context.TransferService.Find(Id);
            if (transferService == null) throw new Exception($"Can't find transfer service with Id: {Id}");

            return transferService;
        }

        public TransferVehicle GetVehicleByID(int vehicleId)
        {
            var vehicle = _context.TransferVehicle.Find(vehicleId);
            if (vehicle == null) throw new Exception($"Cant find vehicle with Id: {vehicleId}");

            return vehicle;
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
