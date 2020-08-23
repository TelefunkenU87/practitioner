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
    public class ReloInterestController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IReloInterestRepository _reloInterestRepository;

        public ReloInterestController(IEmployeeRepository employeeRepository, IReloInterestRepository reloInterestRepository)
        {
            _employeeRepository = employeeRepository;
            _reloInterestRepository = reloInterestRepository;
        }

        public IActionResult ReloInterest(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            var reloInterests = _reloInterestRepository.GetReloInterestByEmployeeId(id);
            var categoryNav = new CategoryNavViewModel { EmployeeId = employee.EmployeeId, InterestActive = "active" };
            var interestTabNav = new InterestTabNavViewModel { EmployeeId = employee.EmployeeId, ReloInterestActive = "active" };

            return View(new ReloInterestViewModel
            {
                ReloInterests = reloInterests,
                Employee = employee,
                CategoryNav = categoryNav,
                InterestTabNav = interestTabNav,
                NewReloInterest = new ReloInterestDTO { ReloInterestId = 0, EmployeeId = employee.EmployeeId }
            });
        }

        public IActionResult ReloInterestEdit(int id)
        {
            var reloInterest = _reloInterestRepository.GetReloInterestById(id);
            return PartialView(reloInterest);
        }

        [HttpPost]
        public IActionResult ReloInterestEdit(ReloInterestDTO updatedReloInterest)
        {
            int Id = 0;
            if (updatedReloInterest.ReloInterestId > 0)
            {
                _reloInterestRepository.UpdateReloInterest(updatedReloInterest);
                Id = updatedReloInterest.EmployeeId;
            }
            else if (ModelState.IsValid)
            {
                _reloInterestRepository.AddReloInterest(updatedReloInterest);
                Id = updatedReloInterest.EmployeeId;
            }
            if (Id != 0)
            {
                return RedirectToAction("ReloInterest", new { id = Id });
            }
            else
            {
                return View(updatedReloInterest);
            }
        }

        public IActionResult ReloInterestDelete(int id, int employeeId)
        {
            int Id = employeeId;
            if (id > 0)
            {
                _reloInterestRepository.DeleteReloInterest(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("ReloInterest", new { id = Id });
        }
    }
}
