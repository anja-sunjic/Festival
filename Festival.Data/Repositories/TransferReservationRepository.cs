using Festival.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class TransferReservationRepository : ITransferReservationRepository
    {
        private readonly FestivalContext context;

        public TransferReservationRepository(FestivalContext context)
        {
            this.context = context;
        }

        public void Add(TransferReservation reservation)
        {
            context.TransferReservation.Add(reservation);
            Save();
        }

        public List<TransferReservation> GetAll()
        {
            return context.TransferReservation.Include(x => x.Attendee).Include(x => x.TransferService).ToList();
        }

        public List<Attendee> GetAllAttendees()
        {
            return context.Attendee.ToList();
        }

        public List<TransferService> GetAllServices()
        {
            return context.TransferService.Include(x => x.TransferVehicle).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
