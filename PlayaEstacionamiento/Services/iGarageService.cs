using PlayaEstacionamiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayaEstacionamiento.Services
{
    public interface iGarageService
    {
        List<Garage> GetAvailableGarage(DateTime date, int Size);
        Garage GetGarageById(int id);
        List<Garage> GetAllGarage();
    }
}
