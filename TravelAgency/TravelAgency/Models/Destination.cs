namespace TravelAgency.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
