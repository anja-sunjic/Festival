using Festival.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly FestivalContext context;

        public TicketTypeRepository(FestivalContext context)
        {
            this.context = context;
        }

        public void Add(TicketType ticketType)
        {
            context.TicketType.Add(ticketType);
            Save();
        }

        public void Delete(int id)
        {
            var entity = context.TicketType.Find(id);
            context.TicketType.Remove(entity);
            Save();
        }

        public List<TicketType> GetAll()
        {
            return context.TicketType.ToList();
        }

        public TicketType GetByID(int id)
        {
            return context.TicketType.Find(id);
        }

        public int GetNumberOfTicketsBought(int iD)
        {
            return context.Ticket.Where(x => x.TicketTypeID == iD).Count();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
