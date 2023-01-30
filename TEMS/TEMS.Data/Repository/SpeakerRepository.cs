using Microsoft.EntityFrameworkCore;
using TEMS.Business.Abstraction;
using TEMS.Business.Entities.Models;
using TEMS.Business.Entities.ViewModel;

namespace TEMS.Data.Repository
{
    public class SpeakerRepository : ISpeaker
    {
        private readonly TEMSContext _dbContext;
        public SpeakerRepository(TEMSContext speakerRepository)
        {
            _dbContext = speakerRepository;
        }

        public Task AddSpeaker(SpeakerViewModel Data)
        {
            var data = new Speakers()
            {
                Name = Data.Name,
                Description = Data.Description,
                Organisation = Data.Organisation,
                LinkedinUrl = Data.LinkedinUrl,
                TwitterHandle = Data.TwitterHandle
            };
            _dbContext.Speakers.AddAsync(data);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<SpeakerViewModel> GetSpeakerById(int id)
        {
            var result = await(from s in _dbContext.Speakers
                               where s.Id == id
                               select new SpeakerViewModel
                               {
                                   Id = s.Id,
                                   Name = s.Name,
                                   Description = s.Description,
                                   Organisation = s.Organisation,
                                   LinkedinUrl = s.LinkedinUrl,
                                   TwitterHandle = s.TwitterHandle
                               }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<SpeakerViewModel>> GetSpeakersOfSpecificEvent(int id)
        {
            var result = await(from e in _dbContext.Events
                               join t in _dbContext.TalksDetails
                               on e.Id equals t.EventId
                               join s in _dbContext.Speakers
                               on t.SpeakerId equals s.Id
                               where e.Id == id
                               select new SpeakerViewModel 
                               {
                                   Id = s.Id,
                                   Name = s.Name,
                                   Description = s.Description,
                                   Organisation = s.Organisation,
                                   LinkedinUrl = s.LinkedinUrl,
                                   TwitterHandle = s.TwitterHandle
                               }).Distinct().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<TalksDetailViewModel>> GetTalksBySpeakerForSpecificEvent(int EventId, int SpeakerId)
        {
            var result = await(from e in _dbContext.Events
                               join t in _dbContext.TalksDetails
                               on e.Id equals t.EventId
                               join s in _dbContext.Speakers
                               on t.SpeakerId equals s.Id
                               where e.Id == EventId && s.Id == SpeakerId
                               select new TalksDetailViewModel
                               {
                                   Id = t.Id,
                                   Title = t.Title,
                                   StartTime = t.StartTime,
                                   EndTime = t.EndTime,
                                   Duration = (t.EndTime - t.StartTime).TotalMinutes,
                                   Tags = t.Tags
                               }).ToListAsync();
            return result;
        }

    }
}
