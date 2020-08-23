using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Models;
using Practitioner.ViewModel;
using PractitionerDTO;

namespace Practitioner.Controllers
{
    public class GeneralInterestController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGeneralInterestRepository _generalInterestRepository;

        public GeneralInterestController(IEmployeeRepository employeeRepository, IGeneralInterestRepository generalInterestRepository)
        {
            _employeeRepository = employeeRepository;
            _generalInterestRepository = generalInterestRepository;
        }

        public IActionResult GeneralInterest(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            var generalInterests = _generalInterestRepository.GetGeneralInterestByEmployeeId(id);
            var categoryNav = new CategoryNavViewModel { EmployeeId = employee.EmployeeId, InterestActive = "active" };
            var interestTabNav = new InterestTabNavViewModel { EmployeeId = employee.EmployeeId, GeneralInterestActive = "active" };

            return View(new GeneralInterestViewModel
            {
                GeneralInterests = generalInterests,
                Employee = employee,
                CategoryNav = categoryNav,
                InterestTabNav = interestTabNav,
                NewGeneralInterest = new GeneralInterestDTO { GeneralInterestId = 0, EmployeeId = employee.EmployeeId }
            });
        }

        public IActionResult GeneralInterestEdit(int id)
        {
            var generalInterest = _generalInterestRepository.GetGeneralInterestById(id);
            return PartialView(generalInterest);
        }

        [HttpPost]
        public IActionResult GeneralInterestEdit(GeneralInterestDTO updatedGeneralInterest)
        {
            int Id = 0;
            if (updatedGeneralInterest.GeneralInterestId > 0)
            {
                _generalInterestRepository.UpdateGeneralInterest(updatedGeneralInterest);
                Id = updatedGeneralInterest.EmployeeId;
            }
            else if (ModelState.IsValid)
            {
                _generalInterestRepository.AddGeneralInterest(updatedGeneralInterest);
                Id = updatedGeneralInterest.EmployeeId;
            }
            if (Id != 0)
            {
                return RedirectToAction("GeneralInterest", new { id = Id });
            }
            else
            {
                return View(updatedGeneralInterest);
            }
        }

        public IActionResult GeneralInterestDelete(int id, int employeeId)
        {
            int Id = employeeId;
            if (id > 0)
            {
                _generalInterestRepository.DeleteGeneralInterest(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("GeneralInterest", new { id = Id });
        }
    }
}
