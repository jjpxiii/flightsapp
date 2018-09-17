using FlightsApp.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace FlightsApp.Contexts
{
    public class FlightContext
    {
        private readonly IMongoDatabase _database = null;

        public FlightContext(IOptions<DbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Flight> Flights
        {
            get
            {
                return _database.GetCollection<Flight>("flights");
            }
        }
    }
}
