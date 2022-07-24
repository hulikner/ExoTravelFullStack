using System.Collections.Generic;
using ExoTravelFullStack.Models;

namespace ExoTravelFullStack.Repositories
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviews();
        List<Review> GetAllReviewsByExoPlanet(int id);
        void Add(Review review);
        Review GetReviewById(int id);
        void Update(Review review);
        void Delete(int id);
    }
}
