using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practitioner.ViewModel;
using PractitionerDAL.Interfaces;
using PractitionerDTO;

namespace Practitioner.Controllers
{
    public class CareerInterestController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICareerInterestRepository _careerInterestRepository;

        public CareerInterestController(IEmployeeRepository employeeRepository, ICareerInterestRepository careerInterestRepository)
        {
            _employeeRepository = employeeRepository;
            _careerInterestRepository = careerInterestRepository;
        }

        public IActionResult CareerInterest(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            var careerInterests = _careerInterestRepository.GetCareerInterestByEmployeeId(id);
            var categoryNav = new CategoryNavViewModel { EmployeeId = employee.EmployeeId, InterestActive = "active" };
            var interestTabNav = new InterestTabNavViewModel { EmployeeId = employee.EmployeeId, CareerInterestActive = "active" };

            return View(new CareerInterestViewModel
            {
                CareerInterests = careerInterests,
                Employee = employee,
                CategoryNav = categoryNav,
                InterestTabNav = interestTabNav,
                NewCareerInterest = new CareerInterestDTO { CareerInterestId = 0, EmployeeId = employee.EmployeeId }
            });
        }

        public IActionResult CareerInterestEdit(int id)
        {
            var careerInterest = _careerInterestRepository.GetCareerInterestById(id);
            return PartialView(careerInterest);
        }

        [HttpPost]
        public IActionResult CareerInterestEdit(CareerInterestDTO updatedCareerInterest)
        {
            int Id = 0;
            if (updatedCareerInterest.CareerInterestId > 0)
            {
                _careerInterestRepository.UpdateCareerInterest(updatedCareerInterest);
                Id = updatedCareerInterest.EmployeeId;
            }
            else if (ModelState.IsValid)
            {
                _careerInterestRepository.AddCareerInterest(updatedCareerInterest);
                Id = updatedCareerInterest.EmployeeId;
            }
            if (Id != 0)
            {
                return RedirectToAction("CareerInterest", new { id = Id });
            }
            else
            {
                return View(updatedCareerInterest);
            }
        }

        public IActionResult CareerInterestDelete(int id, int employeeId)
        {
            int Id = employeeId;
            if (id > 0)
            {
                _careerInterestRepository.DeleteCareerInterest(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("CareerInterest", new { id = Id });
        }
    }
}
