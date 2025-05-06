

namespace PlayaEstacionamiento.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dni { get; set; }
        public String PhoneNumber { get; set; }
        public bool IsVIP { get; set; }

        public List<Parking> ParkingHistory { get; set; }=new List<Parking> { };

        public override string ToString()
        {
            return $"Customer: {Name}, Dni: {Dni} ,Phone: {PhoneNumber}, VIP: {IsVIP}";
        }

    }
}
