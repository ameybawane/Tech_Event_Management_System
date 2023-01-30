using TEMS.Business.Abstraction;
using TEMS.Business.Entities.Models;
using TEMS.Business.Entities.ViewModel;

namespace TEMS.Data.Repository
{
    public class TalksDetailRepository : ITalksDetail
    {
        private readonly TEMSContext _dbContext;
        public TalksDetailRepository(TEMSContext talksDetailRepository)
        {
            _dbContext = talksDetailRepository;
        }

        public Task AddTalksDetail(AddTalksDetail Data)
        {
            var data = new TalksDetails()
            {
                EventId = Data.EventId,
                Title = Data.Title,
                SpeakerId = Data.SpeakerId,
                StartTime = Data.StartTime,
                EndTime = Data.EndTime,
                Tags = Data.Tags
            };
            _dbContext.TalksDetails.AddAsync(data);
            return _dbContext.SaveChangesAsync();
        }
    }
}
