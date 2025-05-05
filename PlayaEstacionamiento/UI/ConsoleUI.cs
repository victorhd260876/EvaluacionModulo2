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
        private readonly iGarageService _garageService;
        private readonly iCustomerService _customerService;

        private bool _isRunnig = true;

        //inmersion de dependiencia

        public ConsoleUI(iParkingService parkingService, iGarageService garageService, iCustomerService customerService)
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
                        CreateReservation();
                        break;
                    case "2":
                        ViewReservations();
                        break;
                    case "3":
                        CancelReservation();
                        break;
                    case "4":
                        ViewTables();
                        break;
                    case "5":
                        ManageCustomers();
                        break;
                    case "0":
                        _isRunnig = false;
                        Console.WriteLine("Thank you for using the Restaurant Reservation System!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
