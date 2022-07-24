using System.Collections.Generic;
using ExoTravelFullStack.Models;

namespace ExoTravelFullStack.Repositories
{
    public interface ILogRepository
    {
        List<Log> GetAllLogs();
        List<Log> GetLogsByUserProfileId(int id);
        void Add(Log log);
        Log GetLogById(int id);
        void Update(Log log);
        void Delete(int id);
    }
}
