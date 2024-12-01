namespace TravelAgency.Models
{
    public class Booking
    {
        public int ID {  get; set; }
        public int customerID { get; set; }
        public Customer Customer { get; set; }
        public int destinationID { get; set; }
        public Destination Destination { get; set; }
        public DateTime bookingTime { get; set; }
        
    }
}
