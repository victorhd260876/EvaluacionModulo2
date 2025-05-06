using PlayaEstacionamiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayaEstacionamiento.Services
{
    public interface iCustomerService
    {
        Customer GetOrCreateCustomer(string name, string dni, string phone);
        Customer GetCustomerById(int id);
        List<Customer> GetCustomers();
        Customer GetCustomerByDni(string dni);
        List<Parking> GetCustomerParking(int customerId);
    }
}
