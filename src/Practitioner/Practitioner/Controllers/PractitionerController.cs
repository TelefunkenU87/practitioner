using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using System.Linq.Dynamic;
using Practitioner.Models;

namespace Practitioner.Controllers
{
    public class PractitionerController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public PractitionerController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}