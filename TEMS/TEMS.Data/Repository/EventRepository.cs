using Microsoft.EntityFrameworkCore;
using TEMS.Business.Abstraction;
using TEMS.Business.Entities.Models;
using TEMS.Business.Entities.ViewModel;

namespace TEMS.Data.Repository
{
    public class EventRepository : IEvent
    {
        private readonly TEMSContext _dbContext;
        public EventRepository(TEMSContext eventRepository)
        {
            _dbContext = eventRepository;
        }

        public Task AddEvent(EventViewModel Data)
        {
            var data = new Events()
            {
                Name = Data.Name,
                StartDate = Data.StartDate,
                EndDate = Data.EndDate,
                IsCompleted = Data.IsCompleted,
                VenueId = Data.VenueId
            };
            _dbContext.Events.AddAsync(data);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventViewModel>> GetAllCompletedEvents()
        {
            return await (from e in _dbContext.Events
                          where e.IsCompleted == true
                          select new EventViewModel
                          {
                              Id = e.Id,
                              Name = e.Name,
                              StartDate = e.StartDate,
                              EndDate = e.EndDate,
                              IsCompleted = e.IsCompleted,
                              VenueId = e.VenueId
                          }).ToListAsync();
        }

        public async Task<IEnumerable<EventViewModel>> GetAllEventsByMonthYear(int month, int year)
        {
            var result = await (from e in _dbContext.Events
                                where e.StartDate.Month == month && e.StartDate.Year == year
                                select new EventViewModel
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    StartDate = e.StartDate,
                                    EndDate = e.EndDate,
                                    IsCompleted = e.IsCompleted,
                                    VenueId = e.VenueId
                                }).ToListAsync();
            return result;
        }

        public async Task<EventViewModel> GetEventById(int id)
        {
            var result = await (from e in _dbContext.Events
                                where e.Id == id
                                select new EventViewModel
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    StartDate = e.StartDate,
                                    EndDate = e.EndDate,
                                    IsCompleted = e.IsCompleted,
                                    VenueId = e.VenueId
                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateEvent(int id, EventViewModel updateEvent)
        {
            var eventData = await _dbContext.Events.FindAsync(id);
            if (eventData != null)
            {
                eventData.Id = updateEvent.Id;
                eventData.Name = updateEvent.Name;
                eventData.StartDate = updateEvent.StartDate;
                eventData.EndDate = updateEvent.EndDate;
                eventData.IsCompleted = updateEvent.IsCompleted;
                eventData.VenueId = updateEvent.VenueId;
                _dbContext.Events.Update(eventData);
                await _dbContext.SaveChangesAsync();
            };
        }
    }
}
