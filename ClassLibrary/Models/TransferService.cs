using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public class TransferService
    {
        public int ID { get; set; }
        public DateTime Date{ get; set; }
        public int NumberOfAvailableSeats { get; set; }
        public TransferVehicle TransferVehicle { get; set; }
        public int? TransferVehicleID { get; set; }
    }
}
