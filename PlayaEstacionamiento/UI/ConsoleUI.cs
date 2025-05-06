using PlayaEstacionamiento.Models;
using PlayaEstacionamiento.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayaEstacionamiento.UI
{
    public class ConsoleUI
    {
        private readonly iParkingService _parkingService;
        private readonly IGarageService _garageService;
        private readonly iCustomerService _customerService;

        private bool _isRunnig = true;

        //inmersion de dependiencia

        public ConsoleUI(iParkingService parkingService, IGarageService garageService, iCustomerService customerService)
        {
            _parkingService = parkingService;
            _garageService = garageService;
            _customerService = customerService;

        }

        public void Run()
        {
            Console.WriteLine("*** Sistema de control de Playa de Estacionamiento ***");

            while (_isRunnig)
            {
                DisplayMenu();

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateParking();
                        break;
                    case "2":
                        ViewParking();
                        break;
                    case "3":
                        //CancelParking();
                        break;
                    case "4":
                        ViewGarage();
                        break;
                    case "5":
                        ManageCustomers();
                        break;
                    case "0":
                        _isRunnig = false;
                        Console.WriteLine("Final del Sistema de Control de Parqueo");
                        break;
                    default:
                        Console.WriteLine("Opción invalida..Ingrese nuevamente");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\n=== Menu Principal ===");
            Console.WriteLine("1. Crear Parqueo");
            Console.WriteLine("2. Ver Parqueo");
            Console.WriteLine("3. Cancelar Parqueo");
            Console.WriteLine("4. Ver Estacionamientos");
            Console.WriteLine("5. Gestionar Clientes");
            Console.WriteLine("0. Salir");
            Console.Write("Ingrese Opción: ");
        }

        private void CreateParking()
        {
            Console.Clear();
            Console.WriteLine("=== Crear Parqueo ===");

            // Get customer information
            Console.Write("Cliente: ");
            var name = Console.ReadLine();

            Console.Write("Dni: ");
            var phone = Console.ReadLine();

            Console.Write("Telefono: ");
            var dni = Console.ReadLine();

            var customer = _customerService.GetOrCreateCustomer(name, phone, dni);

            // Get Reserveation Details
            Console.Write("Ingrese Fecha y hora (MM/DD/YYYY HH:MM): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Formato de Fecha Invalido.");
                return;
            }


            Console.Write("Tipo: ");
            if (!int.TryParse(Console.ReadLine(), out int Size) || Size <= 0)
            {
                Console.WriteLine("Tipo invalido");
                return;
            }

            // Find available garages
            var availableGarage = _garageService.GetAvailableGarage(date, Size);

            if (availableGarage.Count == 0)
            {
                Console.WriteLine("No se tiene Estacionamientos disponibles");
                return;
            }

            // Display available tables
            Console.WriteLine("\nEstacionamientos Disponibles:");
            for (int i = 0; i < availableGarage.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableGarage[i]}");
            }

            // Select table
            Console.Write("\nSelect table (number): ");
            if (!int.TryParse(Console.ReadLine(), out int tableIndex) ||
                tableIndex < 1 || tableIndex > availableGarage.Count)
            {
                Console.WriteLine("Invalid table selection.");
                return;
            }

            var selectedGarage = availableGarage[tableIndex - 1];

            // Create Reservation
            var parking = new Parking()
            {
                CustomerId = customer.Id,
                GarageId = selectedGarage.Id,
                //Date = date,
                //Time = time,
                //Size = Size,
                //SpecialRequests = specialRequests,
                Status = Models.ParkingStatus.occuped,
            };

            var confirmation = _parkingService.CreateParking(parking);

            if (confirmation)
            {
                Console.WriteLine($"Parqueo Registrado correctamente! Registro ID: {parking.Id}");
            }
            else
            {
                Console.WriteLine("Creacion de Parqueo errado.");
            }
        }
        

        
        private void ViewParking()
        {
            Console.Clear();
            Console.WriteLine("=== View Reservations ===");
            Console.WriteLine("1. Ver por estacionamiento");
            Console.WriteLine("2. Ver por cliente");
            Console.Write("Enter option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    //ViewParkingByDate();
                    break;
                case "2":
                    ViewParkingByCustomer();
                    break;
                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        }
        
        private void ViewParkingByDate()
        {
            Console.Write("Enter date (MM/DD/YYYY): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            var parkings = _parkingService.GetParkingByDate(date);

            if (parkings.Count == 0)
            {
                Console.WriteLine("No reservations found for the selected date.");
                return;
            }

            Console.WriteLine($"\nReservations for {date.ToShortDateString()}:");
            foreach (var parking in parkings)
            {
                var customer = _customerService.GetCustomerById(parking.CustomerId);
                var garage = _garageService.GetGarageById(parking.GarageId);

                Console.WriteLine($"ID: {garage.Id}, Customer: {customer.Name}, " +
                                  $"Garage: {garage.Number}, " +
                                  $"Size: {garage.Size}, Status: {parking.Status}");
            }
        }

        private void ViewParkingByCustomer()
        {
            Console.Write("Ingrese DNI del cliente: ");
            var dni = Console.ReadLine();

            var customer = _customerService.GetCustomerByDni(dni);

            if (customer == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            var parkings = _customerService.GetCustomerParking(customer.Id);

            if (parkings.Count == 0)
            {
                Console.WriteLine("Parqueos no encontrados para el cliente");
                return;
            }

            Console.WriteLine($"\nParqueo para {customer.Name}:");
            foreach (var parking in parkings)
            {
                var garage = _garageService.GetGarageById(parking.GarageId);

                Console.WriteLine($"ID: {parking.Id}, Date: {parking.Date.ToShortDateString()}, " +
                                  $"Time: {parking.Time}, Garage: {garage.Number}, " +
                                  $"Party Size: {garage.Size}, Status: {parking.Status}");
            }
        }

        
        private void ViewGarage()
        {
            Console.Clear();
            Console.WriteLine("=== Garages ===");

            var garages = _garageService.GetAllGarage();

            foreach (var garage in garages)
            {
                Console.WriteLine(garage);
            }
        }
        
        private void ManageCustomers()
        {
            Console.Clear();
            Console.WriteLine("=== Gestion de Clientes ===");
            Console.WriteLine("1. Busqueda por DNI:");
            Console.WriteLine("2. Busqueda por Nombre:");
            Console.Write("Ingrese OPCION: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    SearchCustomer();
                    break;
                case "2":
                    //SearchCustomer();
                    break;
                default:
                    Console.WriteLine("Opcion Invalida.");
                    break;
            }
        }

        private void SearchCustomer()
        {
            Console.Write("Ingrese DNI del Cliente: ");
            var dni = Console.ReadLine();

            var customer = _customerService.GetCustomerByDni(dni);

            if (customer == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine($"\nCliente Detalles:");
            Console.WriteLine($"Nombre: {customer.Name}");
            Console.WriteLine($"Telefono: {customer.PhoneNumber}");
            Console.WriteLine($"Dni: {customer.Dni}");
            //Console.WriteLine($"VIP: {customer.IsVIP}");

            var parkings = _customerService.GetCustomerParking(customer.Id);

            if (parkings.Count > 0)
            {
                Console.WriteLine($"\nHistorial de Parqueo:");
                foreach (var parking in parkings)
                {
                    Console.WriteLine($"ID: {parking.Id}, Date: {parking.Date.ToShortDateString()}, " +
                                      $"Time: {parking.Time}, Status: {parking.Status}");
                }
            }
            else
            {
                Console.WriteLine("\nNo hay historial de parqueo.");
            }
        }

        


    }
}
