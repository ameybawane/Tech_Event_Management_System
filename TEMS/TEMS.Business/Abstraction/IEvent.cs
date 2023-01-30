using TEMS.Business.Entities.ViewModel;

namespace TEMS.Business.Abstraction
{
    public interface IEvent
    {
        Task<EventViewModel> GetEventById(int id);
        Task<IEnumerable<EventViewModel>> GetAllEventsByMonthYear(int month, int year);
        Task<IEnumerable<EventViewModel>> GetAllCompletedEvents();
        Task AddEvent(EventViewModel Data);
        Task UpdateEvent(int id, EventViewModel entity);
    }
}
