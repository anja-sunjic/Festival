namespace Festival.Data.Models
{
    public class Sponsor
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public Image Image { get; set; }
        public int? ImageID { get; set; }
        public string ContactPersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
