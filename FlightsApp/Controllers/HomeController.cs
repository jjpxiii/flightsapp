using Microsoft.AspNetCore.Mvc;
using FlightsApp.Models;

namespace FlightsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData.Keep();
            var viewModel = new ViewModels.FlightViewModel();
            viewModel.Flight = new Flight();
            viewModel.Flight.ArrivalAirport = new Airport();
            viewModel.Flight.DepartureAirport = new Airport();
            return View(viewModel);
        }

        public IActionResult List()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
