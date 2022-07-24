using ExoTravelFullStack.Models;

namespace ExoTravelFullStack.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);

    }
}