

namespace PlayaEstacionamiento.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public String PhoneNumber { get; set; }
        public bool isVIP { get; set; }

        public List<Parking> ParkingHistory { get; set; }=new List<Parking> { };

        public override string ToString()
        {
            return $"Customer: {Name}, Email: {Email} ,Phone: {PhoneNumber}, VIP: {IsVIP}";
        }

    }
}
