using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLte3.Controllers
{
    public class TransportController : Controller
    {
        private readonly AdminLte3.Data.TodosContext _context;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public TransportController(AdminLte3.Data.TodosContext context)
        {
            //_mapper = mapper;
            _context = context;
        }

        public IActionResult Cars()
        {
            return View();
        }

        public IActionResult Drivers()
        {
            return View();
        }

        public IActionResult TrafficLicenses()
        {
            return View();
        }
        public IActionResult NewTrafficLicenses()
        {
            return View();
        }

        [Route("Transport/TrafficLicenses/Print")]
        public IActionResult Print()
        {
            return View();
        }
        public IActionResult RegisterDriver()
        {
            return View();
        }

        public IActionResult RegisterCar()
        {
            return View();
        }
        public IActionResult CreateTrafficLicense()
        {
            return View();
        }

        public IActionResult ProgressingTrafficLicenses()
        {
            return View();
        }
        public IActionResult TodosPage()
        {
            return View();
        }
    }
}
