using System;
using System.ComponentModel.DataAnnotations;

namespace Festival.Data.Models
{
    public class Performance
    {
        public int ID { get; set; }
        public DateTime Start { get; set; }
        public Stage Stage { get; set; }
        public int? StageID { get; set; }
        public Performer Performer { get; set; }
        public int? PerformerID { get; set; }
    }
}
