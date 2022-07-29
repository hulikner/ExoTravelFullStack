using System.Collections.Generic;
using ExoTravelFullStack.Models;

namespace ExoTravelFullStack.Repositories
{
    public interface IExoPlanetRepository
    {
        List<ExoPlanet> GetAllExoPlanets();
        List<ExoPlanet> GetByLightYearAsc();
        List<ExoPlanet> GetByLightYearDesc();
        List<ExoPlanet> GetByRatingAsc();
        List<ExoPlanet> GetByRatingDesc();
        void Add(ExoPlanet exoPlanet);
        ExoPlanet GetExoPlanetById(int id);
        void Update(ExoPlanet exoPlanet);
        void Delete(int id);
    }
}
