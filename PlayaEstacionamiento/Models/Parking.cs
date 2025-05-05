

namespace PlayaEstacionamiento.Models
{
    public class Parking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ParkingId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public ParkingStatus Status { get; set; }
        public override string ToString()
        {
            return $"Parking: #{Id}, CustomerId: {CustomerId}, ParkingId: {ParkingId}, " +
                $"Date: {Date.ToShortDateString()}, Time: {Time}, Status: {Status}";
        }
    }

    
}
