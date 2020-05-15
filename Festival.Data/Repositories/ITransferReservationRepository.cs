using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface ITransferReservationRepository
    {
        List<TransferReservation> GetAll();
        List<Attendee> GetAllAttendees();
        List<TransferService> GetAllServices();
        void Add(TransferReservation reservation);
        void Save();
        TransferReservation GetByID(int iD);
        void Delete(int ID);
    }
}
