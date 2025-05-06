using PlayaEstacionamiento.Models;

namespace PlayaEstacionamiento.Repositories
{
    //interfas generica q funciona con cualquier clase
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByPhoneNumber(string phoneNumber);
        Customer GetByDni(string dni);

    }
}

