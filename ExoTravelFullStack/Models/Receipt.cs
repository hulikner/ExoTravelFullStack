namespace ExoTravelFullStack.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int ExoPlanetId { get; set; }
        public int DepartureDate { get; set; }
        public int ReturnDate { get; set; }
        public int LogId { get; set; }
        public int Paid { get; set; }
        public string Mode { get; set; }
        public UserProfile UserProfile { get; set; }
        public UserType UserType { get; set; }
        public ExoPlanet ExoPlanet { get; set; }
        public Log Log { get; set; }
    }
}
