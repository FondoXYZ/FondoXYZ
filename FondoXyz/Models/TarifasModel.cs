using System.Text.Json.Serialization;
using FondosXYZ.Models;

namespace FondosXYZ {
    public class Tarifa{
        public int Id {get; set; }
        [JsonIgnore]
        public int Apartamento {get; set; }
        public Apartamento apartamento {get; set;}
        public DateOnly StartDate {get; set;}
        public DateOnly EndDate {get; set;}
        public float PriceNight {get; set; }
    }
}