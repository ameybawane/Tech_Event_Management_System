namespace TEMS.Business.Entities.ViewModel
{
    public class AddTalksDetail
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Title { get; set; }
        public int SpeakerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Tags { get; set; }
    }
}
