using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdminLte3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Document()
        {
            return View();
        }
        public IActionResult EditDocument()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult AddUser()
        {
            return View();
        }
        public IActionResult EmpList()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Department()
        {
            return View();
        }

        public IActionResult Department2()
        {
            return View();
        }

        public IActionResult DepartmentDetails()
        {
            return View();
        }

        public IActionResult Position()
        {
            return View();
        }

        public IActionResult ShowPetition()
        {
            return View();
        }

        public IActionResult Petition()
        {
            return View();
        }

        public IActionResult ChartJs()
        {
            return View();
        }
        
    }
}