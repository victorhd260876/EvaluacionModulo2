using PlayaEstacionamiento.Models;

namespace PlayaEstacionamiento.Services
{
    public interface IGarageService
    {
        List<Garage> GetAvailableGarage(DateTime date, int size); //DateTime date, int Size
        Garage GetGarageById(int id);
        List<Garage> GetAllGarage();
    }
}
