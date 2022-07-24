using System.Collections.Generic;
using ExoTravelFullStack.Models;

namespace ExoTravelFullStack.Repositories
{
    public interface IExoPlanetRepository
    {
        List<ExoPlanet> GetAllExoPlanets();
        List<ExoPlanet> GetAllExoPlanetsByLightYearAsc();
        List<ExoPlanet> GetAllExoPlanetsByLightYearDesc();
        List<ExoPlanet> GetAllExoPlanetsByRatingAsc();
        List<ExoPlanet> GetAllExoPlanetsByRatingDesc();
        void Add(ExoPlanet exoPlanet);
        ExoPlanet GetExoPlanetById(int id);
        void Update(ExoPlanet exoPlanet);
        void Delete(int id);
    }
}
