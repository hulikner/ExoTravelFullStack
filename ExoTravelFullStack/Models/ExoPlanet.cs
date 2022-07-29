namespace ExoTravelFullStack.Models
{
    public class ExoPlanet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Mass { get; set; }
        public decimal Radius { get; set; }
        public decimal EqTemp { get; set; }
        public int Orbit { get; set; }
        public int LightYears { get; set; }
        public string Detail { get; set; }
        public int Rating { get; set; }
    }
}
