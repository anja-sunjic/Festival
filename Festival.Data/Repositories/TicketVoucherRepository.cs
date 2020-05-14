using Festival.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class TicketVoucherRepository : ITicketVoucherRepository
    {
        private readonly FestivalContext context;

        public TicketVoucherRepository(FestivalContext context)
        {
            this.context = context;
        }

        public void Add(TicketVoucher ticketVoucher)
        {
            context.TicketVoucher.Add(ticketVoucher);
            Save();
        }

        public void Delete(int iD)
        {
            var voucher = context.TicketVoucher.Find(iD);
            context.TicketVoucher.Remove(voucher);
            Save();
        }

        public List<TicketVoucher> GetAll()
        {
            return context.TicketVoucher.ToList();
        }

        public TicketVoucher GetByID(int iD)
        {
            return context.TicketVoucher.Find(iD);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
