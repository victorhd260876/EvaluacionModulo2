using PlayaEstacionamiento.Models;
using PlayaEstacionamiento.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayaEstacionamiento.Services
{
    public class CustomerService : iCustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IParkingRepository _parkingRepository;
        
        public CustomerService(ICustomerRepository customerRepository, IParkingRepository parkingRepository)
        {
            this._customerRepository = customerRepository;
            this._parkingRepository = parkingRepository;
        }
        
        public Customer GetOrCreateCustomer(string name, string dni, string phone)
        {
            var customer = _customerRepository.GetByDni(dni);

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = name,
                    Dni = dni,
                    PhoneNumber = phone
                };
                _customerRepository.Add(customer);
            }
            return customer;
        }

        public Customer GetCustomerByDni(string dni)
        {
            return _customerRepository.GetByDni(dni);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public List<Parking> GetCustomerParking(int customerId)
        {
            return _parkingRepository.GetParkingByCustomer(customerId);
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetAll();
        }

     }
}
