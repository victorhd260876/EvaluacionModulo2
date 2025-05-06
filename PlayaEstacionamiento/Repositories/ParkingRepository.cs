using PlayaEstacionamiento.Models;
using PlayaEstacionamiento.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlayaEstacionamiento.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private List<Parking> _parking = new List<Parking>();
        private int _nextId = 1;

        public List<Parking> GetAll()
        {
            return _parking;
        }

        public Parking GetById(int id)
        {
            return _parking.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Parking entity)
        {
            entity.Id = _nextId++;
            _parking.Add(entity);
        }
        public void Update(Parking entity)
        {
            var index = _parking.FindIndex(t => t.Id == entity.Id);
            if (index != -1)
            {
                _parking[index] = entity;
            }
        }

        public void Delete(Parking entity)
        {
            _parking.Remove(entity);
        }

 
 
        public List<Parking> GetParkingByDate(DateTime date)
        {
            return _parking.Where(t => t.Date==date).ToList();
        }

        public List<Parking> GetParkingByCustomer(int customerId)
        {
            return _parking.Where(t => t.CustomerId == customerId).ToList();
        }

    }
}
