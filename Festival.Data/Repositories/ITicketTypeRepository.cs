using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface ITicketTypeRepository
    {
        List<TicketType> GetAll();
        int GetNumberOfTicketsBought(int iD);
        void Add(TicketType ticketType);
        void Save();
        void Delete(int id);
        TicketType GetByID(int id);
    }
}
