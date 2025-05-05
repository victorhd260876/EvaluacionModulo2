using PlayaEstacionamiento.Models;
using PlayaEstacionamiento.Respositories;
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
        
        public Customer GetOrCreateCustomer(string name, string email, string phone)
        {
            var customer = _customerRepository.GetByEmail(email);

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = name,
                    Email = email,
                    PhoneNumber = phone
                };
                _customerRepository.Add(customer);
            }
            return customer;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.GetByEmail(email);
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
