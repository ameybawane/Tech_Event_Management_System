using TEMS.Business.Entities.ViewModel;

namespace TEMS.Business.Abstraction
{
    public interface IVenue
    {
        Task AddVenue(VenueViewModel Data);
        public Task<VenueViewModel> GetVenueOfSpecificEvent (int id);
    }
}
