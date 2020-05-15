using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface ITransferReservationRepository
    {
        List<TransferReservation> GetAll();
    }
}
