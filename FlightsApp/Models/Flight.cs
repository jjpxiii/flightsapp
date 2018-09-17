using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;

namespace FlightsApp.Models
{
    public class Flight
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        public string InternalId { get; set; }

        [Required]
        public Airport DepartureAirport { get; set; }

        [Required]
        public Airport ArrivalAirport { get; set; }

        public double? Distance { get; set; }
        public double? FuelConsumption { get; set; }

        [Required]
        public double? FuelPerKilometre { get; set; }

        [Required]
        public double? FuelForTakoff { get; set; }
    }
}
