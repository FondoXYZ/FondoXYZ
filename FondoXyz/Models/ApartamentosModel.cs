namespace FondosXYZ.Models{
    public class Apartamento{
        public int Id {get; set; }
        public string Name {get; set;}
        public string City {get; set; }
        public int NumberRooms {get; set; }
        public int NumberAccoodation {get; set; } // Numero de alojamiento
        public string CapacityMaximum {get; set; }
        public int SedeId {get; set; }
        public Sede Sede {get; set; }
    }
}