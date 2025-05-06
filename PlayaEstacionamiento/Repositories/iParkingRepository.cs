using PlayaEstacionamiento.Models;
using System;
using System.Collections.Generic;

namespace PlayaEstacionamiento.Repositories
{
    public interface IParkingRepository : IRepository<Parking>
    {
        List<Parking> GetParkingByDate(DateTime date);
        List<Parking> GetParkingByCustomer(int CustomerId);

    }
}