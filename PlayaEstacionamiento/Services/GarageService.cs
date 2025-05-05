using PlayaEstacionamiento.Models;
using PlayaEstacionamiento.Repositories;
using PlayaEstacionamiento.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayaEstacionamiento.Services
{
    public class GarageService : iGarageService
    {
        private readonly IGarageRepository _garageRepository;

        public GarageService(IGarageRepository garageRepository)
        {
            this._garageRepository = garageRepository;
        }
        
        public List<Garage> GetAvailableGarage(DateTime date, int Size)
        {
            return _garageRepository.GetAvailableGarage(date, Size);
        }

        public Garage GetGarageById(int id)
        {
            return _garageRepository.GetById(id);
        }
        public List<Garage> GetAllGarage()
        {
            return _garageRepository.GetAll();
        }

   
    }
}
