using PlayaEstacionamiento.Models;
using PlayaEstacionamiento.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayaEstacionamiento.Services
{
    public class ParkingService : iParkingService
    {
        private readonly IParkingRepository _parkingRepository;

        public ParkingService(IParkingRepository parkingRepository)
        {
            this._parkingRepository = parkingRepository;
        }


        public bool CreateParking(Parking parking)
        {
            try
            {
                // Setear el status
                parking.Status = ParkingStatus.free;

                // Agregamos la reserva
                _parkingRepository.Add(parking);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool UpdateParking(Parking parking)
        {
            try
            {
                _parkingRepository.Update(parking);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool CancelParking(Parking parking)
        {
            var existingParking = _parkingRepository.GetById(parking.Id);
            if (existingParking == null)
                return false;

            existingParking.Status = ParkingStatus.canceled;
            _parkingRepository.Update(existingParking);

            return true;
        }


        public List<Parking> GetParkingByDate(DateTime date)
        {
            return _parkingRepository.GetParkingByDate(date);
        }

        public Parking GetParkingById(int id)
        {
            return _parkingRepository.GetById(id);
        }

    }
}
