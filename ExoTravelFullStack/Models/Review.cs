namespace ExoTravelFullStack.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int ExoPlanetId { get; set; }
        public int CreateDate { get; set; }
        public int EditDate { get; set; }
        public int Star { get; set; }
        public string Message { get; set; }
        public UserProfile UserProfile { get; set; }
        public ExoPlanet ExoPlanet { get; set; }
    }
}
