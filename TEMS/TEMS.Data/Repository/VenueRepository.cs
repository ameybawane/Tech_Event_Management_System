using Microsoft.EntityFrameworkCore;
using TEMS.Business.Abstraction;
using TEMS.Business.Entities.Models;
using TEMS.Business.Entities.ViewModel;

namespace TEMS.Data.Repository
{
    public class VenueRepository : IVenue
    {
        private readonly TEMSContext _dbContext;
        public VenueRepository(TEMSContext venueRepository)
        {
            _dbContext = venueRepository;
        }

        public Task AddVenue(VenueViewModel Data)
        {
            var data = new Venues()
            {
                Name = Data.Name,
                City = Data.City,
                Address = Data.Address,
                Website = Data.Website,
                ContactNo = Data.ContactNo
            };
            _dbContext.Venues.AddAsync(data);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<VenueViewModel> GetVenueOfSpecificEvent(int id)
        {
            var result = await (from e in _dbContext.Events
                                join v in _dbContext.Venues
                                on e.VenueId equals v.Id
                                where e.Id == id
                                select new VenueViewModel
                                {
                                    Id = v.Id,
                                    Name = v.Name,
                                    Address = v.Address,
                                    City = v.City,
                                    Website = v.Website,
                                    ContactNo = v.ContactNo
                                }).FirstOrDefaultAsync();
            return result;
        }
    }
}
