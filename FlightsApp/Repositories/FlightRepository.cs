using FlightsApp.Contexts;
using FlightsApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightsApp.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightContext _context = null;

        public FlightRepository(IOptions<DbSettings> settings)
        {
            _context = new FlightContext(settings);
        }

        public List<Flight> GetAllFlights()
        {
            try
            {
                return _context.Flights.Find(_ => true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddFlight(Flight flight)
        {
            try
            {
                _context.Flights.InsertOne(flight);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveFlight(Flight flight)
        {
            try
            {
                var filter = Builders<Flight>.Filter.Eq(s => s.Id, flight.Id);
                _context.Flights.ReplaceOne(filter, flight);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
