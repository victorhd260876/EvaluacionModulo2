using PlayaEstacionamiento.Models;
using System;
using System.Collections.Generic;

namespace PlayaEstacionamiento.Respositories
{
	public interface IGarageRepository : IRepository<Garage>
	{
		List<Garage> GetAvailableGarage(DateTime date, int Ubication);

	}
}