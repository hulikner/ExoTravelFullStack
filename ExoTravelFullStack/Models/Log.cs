namespace ExoTravelFullStack.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int ExoPlanetId { get; set; }
        public int DepartureDate { get; set; }
        public int ReturnDate { get; set; }
        public int ReviewId { get; set; }
        public string Mode { get; set; }
        public ExoPlanet ExoPlanet { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
