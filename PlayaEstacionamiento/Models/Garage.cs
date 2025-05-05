

namespace PlayaEstacionamiento.Models
{
    public class Garage // tabla
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Size {  get; set; }
        public bool IsAvailable {  get; set; }
        public int Ubication {  get; set; }

        public override string ToString()
        {
            return $"Garage: #{Number}, Tamaño: {Size}, Ubication: {Ubication}, Available:{IsAvailable}";
        }


    }
}
