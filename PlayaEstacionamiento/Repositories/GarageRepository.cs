using PlayaEstacionamiento.Models;
using PlayaEstacionamiento.Repositories;

namespace PlayaEstacionamiento.Repositories
{
    public class GarageRepository : IGarageRepository
    {
        private List<Garage> _garage = new List<Garage>();
        private int _nextId = 1;

        public GarageRepository() 
        {
            _garage.Add(new Garage { Id = _nextId++, Number = 1, Size = 1, IsAvailable = true, Ubication = "s1" });
            _garage.Add(new Garage { Id = _nextId++, Number = 2, Size = 1, IsAvailable = true, Ubication = "s1" });
            _garage.Add(new Garage { Id = _nextId++, Number = 3, Size = 1, IsAvailable = true, Ubication = "s1" });
            _garage.Add(new Garage { Id = _nextId++, Number = 4, Size = 1, IsAvailable = true, Ubication = "s1" });
            _garage.Add(new Garage { Id = _nextId++, Number = 5, Size = 1, IsAvailable = true, Ubication = "s1" });
            _garage.Add(new Garage { Id = _nextId++, Number = 6, Size = 1, IsAvailable = true, Ubication = "s2" });
            _garage.Add(new Garage { Id = _nextId++, Number = 7, Size = 1, IsAvailable = true, Ubication = "s2" });
            _garage.Add(new Garage { Id = _nextId++, Number = 8, Size = 1, IsAvailable = true, Ubication = "s3" });
            _garage.Add(new Garage { Id = _nextId++, Number = 9, Size = 1, IsAvailable = true, Ubication = "s3" });
            _garage.Add(new Garage { Id = _nextId++, Number = 10, Size = 1, IsAvailable = true, Ubication = "s3" });
        }

        public List<Garage> GetAll()
        {
            return _garage;
        }

        public Garage GetById(int id)
        {
            return _garage.FirstOrDefault(t=>t.Id==id);
        }
        public void Add(Garage entity)
        {
            entity.Id = _nextId++;
            _garage.Add(entity);
        }

        public void Update(Garage entity)
        {
            var index = _garage.FindIndex(t=>t.Id==entity.Id);
            if (index != -1)
            {
                _garage[index] = entity;
            }
        }
        public void Delete(Garage entity)
        {
            _garage.Remove(entity);
        }
        public List<Garage> GetAvailableGarage(DateTime date, int ubication)
        {
            return _garage.Where(t=>t.IsAvailable && t.Size >= ubication).ToList();
        }
    }
}
