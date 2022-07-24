using System.Collections.Generic;
using ExoTravelFullStack.Models;

namespace ExoTravelFullStack.Repositories
{
    public interface IHubDriveRepository
    {
        List<HubDrive> GetAllHubDrives();

        void Add(HubDrive hubDrive);
        HubDrive GetHubDriveById(int id);

        void Delete(int id);
    }
}