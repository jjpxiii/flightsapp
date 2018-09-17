using System.ComponentModel.DataAnnotations;

namespace FlightsApp.Models
{
    public class Airport
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double? Latitude { get; set; }

        [Required]
        public double? Longitude { get; set; }
    }
}
