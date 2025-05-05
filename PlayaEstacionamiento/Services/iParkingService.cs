using PlayaEstacionamiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayaEstacionamiento.Services
{
    public interface iParkingService
    {
        bool CreateParking(Parking parking);
        bool UpdateParking(Parking parking);
        bool CancelParking(Parking parking);
        List<Parking> GetParkingByDate(DateTime date);
        Parking GetParkingById(int id);
    }
}
