namespace TravelAgency.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>(); 
    }
}
// Defining relationship between the Customer and their booking