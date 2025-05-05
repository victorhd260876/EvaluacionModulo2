using PlayaEstacionamiento.Models;

namespace PlayaEstacionamiento.Respositories
{
    //interfas generica q funciona con cualquier clase
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByPhoneNumber(string phoneNumber);
        Customer GetByEmail(string email);

    }
}

