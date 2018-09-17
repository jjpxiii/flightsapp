using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FlightsApp.Models;
using FlightsApp.Repositories;
using GeoCoordinatePortable;
using FlightsApp.ViewModels;
using MongoDB.Bson;

namespace FlightsApp.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightRepository _flightRepository;

        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        [HttpPost]
        public IActionResult Add(Flight flight)
        {
            if (ModelState.IsValid)
            {
                var latlngDeparture = new GeoCoordinate(flight.DepartureAirport.Latitude.Value, flight.DepartureAirport.Longitude.Value);
                var latlngArrival = new GeoCoordinate(flight.ArrivalAirport.Latitude.Value, flight.ArrivalAirport.Longitude.Value);
                flight.Distance = latlngDeparture.GetDistanceTo(latlngArrival) / 1000;
                flight.FuelConsumption = flight.Distance * flight.FuelPerKilometre + flight.FuelForTakoff;
                _flightRepository.AddFlight(flight);
                TempData["isNew"] = true;
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult List()
        {
            var viewModel = new FlightListViewModel { FlightsList = new List<FlightViewModel>() };
            foreach (var item in _flightRepository.GetAllFlights())
            {
                item.InternalId = item.Id.ToString();
                viewModel.FlightsList.Add(new FlightViewModel { Flight = item, IsEdit = true });
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Flight flight)
        {
            if (ModelState.IsValid)
            {
                var latlngDeparture = new GeoCoordinate(flight.DepartureAirport.Latitude.Value, flight.DepartureAirport.Longitude.Value);
                var latlngArrival = new GeoCoordinate(flight.ArrivalAirport.Latitude.Value, flight.ArrivalAirport.Longitude.Value);
                flight.Distance = latlngDeparture.GetDistanceTo(latlngArrival) / 1000;
                flight.FuelConsumption = flight.Distance * flight.FuelPerKilometre + flight.FuelForTakoff;

                flight.Id = ObjectId.Parse(flight.InternalId);
                _flightRepository.SaveFlight(flight);
                TempData["hasBeenEdited"] = true;
            }
            return RedirectToAction("List");
        }
    }
}
