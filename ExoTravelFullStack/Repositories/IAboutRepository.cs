using System.Collections.Generic;
using ExoTravelFullStack.Models;

namespace ExoTravelFullStack.Repositories
{
    public interface IAboutRepository
    {
        List<About> GetAllAbouts();

        void Add(About about);
        About GetAboutById(int id);

        void Delete(int id);
    }
}