using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface ITicketVoucherRepository
    {
        List<TicketVoucher> GetAll();
        void Add(TicketVoucher ticketVoucher);
        void Save();
        TicketVoucher GetByID(int iD);
    }
}
