using TEMS.Business.Entities.ViewModel;

namespace TEMS.Business.Abstraction
{
    public interface ISpeaker
    {
        Task<SpeakerViewModel> GetSpeakerById(int id);
        Task AddSpeaker(SpeakerViewModel Data);
        public Task<IEnumerable<SpeakerViewModel>> GetSpeakersOfSpecificEvent(int id);
        public Task<IEnumerable<TalksDetailViewModel>> GetTalksBySpeakerForSpecificEvent(int EventId, int SpeakerId);
        
    }
}
