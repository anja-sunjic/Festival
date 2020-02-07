namespace Festival.Data.Models
{
    public class Performer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Fee { get; set; }
        public string PromoText { get; set; }
        public Image Image { get; set; }
        public int? ImageID { get; set; }
        public Manager Manager { get; set; }
        public int? ManagerID { get; set; }
    }
}
