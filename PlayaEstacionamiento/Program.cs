namespace PlayaEstacionamiento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Sistema de Control de Playa de Estacionamiento-------");
            //inicializacion
            var parkingService = new ParkingService(new ParkingRepository());
            var garageService = new GarageService(new GarageService());
            var customerService = new CustomerService(new CustomerService());

            //inicializando UI
            var ui = new ConsoleUI(parkingService, garageService, customerService);

            //inicializando aplicación
            ui.Run();
            Console.WriteLine("prueba de impresion");


        }
    }
}
