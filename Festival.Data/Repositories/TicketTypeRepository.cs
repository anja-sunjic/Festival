using System;
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
            if (entity == null) throw new Exception($"Can't find ticket type with Id: {id}");

            context.TicketType.Remove(entity);
            Save();
        }

        public List<TicketType> GetAll()
        {
            return context.TicketType.ToList();
        }

        public TicketType GetByID(int id)
        {
            var ticketType = context.TicketType.Find(id);
            if (ticketType == null) throw new Exception($"Can't find ticket type with Id: {id}");

            return ticketType;
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
