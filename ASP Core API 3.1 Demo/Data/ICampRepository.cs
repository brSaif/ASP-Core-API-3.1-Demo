using System;
using System.Threading.Tasks;
using ASP_Core_API_3._1_Demo.Data.Entities;

namespace ASP_Core_API_3._1_Demo.Data
{
    public interface ICampRepository
    {
        void Add<T>(T Entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Camp[]> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false);
        Task<Camp[]> GetAllCampsAsync(bool includeTalks = false);
        Task<Camp> GetCampAsync(string moniker, bool includeTalks = false);
        Task<Talk[]> GetTalksByMonikerAsync(string moniker, bool includeSpeakers = false);
        Task<Talk> GetTalkByMonikerAsync(string moniker, int talkId, bool includeSpeakers = false);
        Task<Speaker[]> GetSpeakersByMonikerAsync(string moniker);
        Task<Speaker[]> GetAllSpeakersAsync();
        Task<Speaker> GetSpeakerAsync(int speakerId);
    }
}