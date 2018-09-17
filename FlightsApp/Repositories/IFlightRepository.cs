using FlightsApp.Models;
using System.Collections.Generic;

namespace FlightsApp.Repositories
{
    public interface IFlightRepository
    {
        List<Flight> GetAllFlights();
        void AddFlight(Flight flight);
        void SaveFlight(Flight flight);
    }
}
