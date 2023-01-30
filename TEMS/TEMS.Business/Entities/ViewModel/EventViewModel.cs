namespace TEMS.Business.Entities.ViewModel
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public int VenueId { get; set; }
    }
}
