using System.ComponentModel;

namespace FestivalWebApplication.ViewModels.TransferVehicle
{
    public class ListTransferVehicleVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Registration number")]
        public string RegistrationNumber { get; set; }
        public string Driver { get; set; }
        public int Capacity { get; set; }
    }
}
