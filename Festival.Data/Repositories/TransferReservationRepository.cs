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

        public List<TransferReservation> GetAll()
        {
            return context.TransferReservation.Include(x => x.Attendee).Include(x => x.TransferService).ToList();
        }
    }
}
