

namespace PlayaEstacionamiento.Models
{
    public class Garage // tabla
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Size {  get; set; }
        public bool IsAvailable {  get; set; }
        public string Ubication {  get; set; }

        public override string ToString()
        {
            return $"Estacionamiento #{Number}: Tipo: {Size}, Ubicacion: {Ubication}, " +
                $"Disponibilidad: {IsAvailable}";
        }


    }
}
