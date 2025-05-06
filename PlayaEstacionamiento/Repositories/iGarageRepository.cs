using PlayaEstacionamiento.Models;


namespace PlayaEstacionamiento.Repositories
{
	public interface IGarageRepository : IRepository<Garage>
	{
		List<Garage> GetAvailableGarage(DateTime date, int Ubication);

	}
}