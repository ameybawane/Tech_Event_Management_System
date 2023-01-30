using System.ComponentModel.DataAnnotations.Schema;

namespace TEMS.Business.Entities.ViewModel
{
    public class TalksDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Tags { get; set; }

        [NotMapped]
        public double Duration { get; set; }
    }
}
