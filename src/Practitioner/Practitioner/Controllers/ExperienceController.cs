using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Models;
using Practitioner.ViewModel;

namespace Practitioner.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountServedRepository _accountServedRepository;
        private readonly IPracticeManagementRepository _practiceManagementRepository;
        public ExperienceController(IEmployeeRepository employeeRepository, IAccountServedRepository accountServedRepository,
                                    IPracticeManagementRepository practiceManagementRepository)
        {
            _employeeRepository = employeeRepository;
            _accountServedRepository = accountServedRepository;
            _practiceManagementRepository = practiceManagementRepository;
        }

        public IActionResult AccountServed(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            var accountsServed = _accountServedRepository.GetAccountServedByEmployeeId(id);
            var categoryNav = new CategoryNavViewModel{ EmployeeId = employee.EmployeeId, ExperienceActive = "active"};
            var experienceTabNav = new ExperienceTabNavViewModel { EmployeeId = employee.EmployeeId, AccountsServedActive = "active" };

            return View(new AccountServedViewModel
            {
                Employee = employee,
                AccountsServed = accountsServed,
                CategoryNav = categoryNav,
                ExperienceTabNav = experienceTabNav,
                NewAccountServed = new AccountServed { AccountServedId = 0, EmployeeId = employee.EmployeeId}
            });
        }

        public IActionResult AccountServedEdit(int id)
        {
            var accountServed = _accountServedRepository.GetAccountServedById(id);
            //return View(accountServed);
            return PartialView(accountServed);
        }

        [HttpPost]
        public IActionResult AccountServedEdit(AccountServed updatedAccountServed)
        {
            int Id = 0;
            if (updatedAccountServed.AccountServedId > 0)
            {
                _accountServedRepository.UpdateAccountServed(updatedAccountServed);
                Id = updatedAccountServed.EmployeeId;
            }
            else if (ModelState.IsValid)
            {
                _accountServedRepository.AddAccountServed(updatedAccountServed);
                Id = updatedAccountServed.EmployeeId;
            }
            if (Id != 0)
            {
                return RedirectToAction("AccountServed", new { id = Id });
            }
            else
            {
                return View(updatedAccountServed);
            }
        }

        public IActionResult AccountServedDelete(int id, int employeeId)
        {
            int Id = employeeId;
            if (id > 0)
            {
                _accountServedRepository.DeleteAccountServed(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("AccountServed", new { id = Id });
        }

        public IActionResult PracticeManagement(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            var practiceManagements = _practiceManagementRepository.GetPracticeManagementByEmployeeId(id);
            var categoryNav = new CategoryNavViewModel { EmployeeId = employee.EmployeeId, ExperienceActive = "active" };
            var experienceTabNav = new ExperienceTabNavViewModel { EmployeeId = employee.EmployeeId, PracticeManagementActive = "active" };

            return View(new PracticeManagementViewModel
            {
                PracticeManagements = practiceManagements,
                Employee = employee,
                CategoryNav = categoryNav,
                ExperienceTabNav = experienceTabNav,
                NewPracticeManagement = new PracticeManagement { PracticeManagementId = 0, EmployeeId = employee.EmployeeId }
            });
        }

        public IActionResult PracticeManagementEdit(int id)
        {
            var practiceManagement = _practiceManagementRepository.GetPracticeManagementById(id);
            return PartialView(practiceManagement);
        }

        [HttpPost]
        public IActionResult PracticeManagementEdit(PracticeManagement updatedPracticeManagement)
        {
            int Id = 0;
            if (updatedPracticeManagement.PracticeManagementId > 0)
            {
                _practiceManagementRepository.UpdatePracticeManagement(updatedPracticeManagement);
                Id = updatedPracticeManagement.EmployeeId;
            }
            else if (ModelState.IsValid)
            {
                _practiceManagementRepository.AddPracticeManagement(updatedPracticeManagement);
                Id = updatedPracticeManagement.EmployeeId;
            }
            if (Id != 0)
            {
                return RedirectToAction("PracticeManagement", new { id = Id });
            }
            else
            {
                return View(updatedPracticeManagement);
            }
        }

        public IActionResult PracticeManagementDelete(int id, int employeeId)
        {
            int Id = employeeId;
            if (id > 0)
            {
                _practiceManagementRepository.DeletePracticeManagement(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("PracticeManagement", new { id = Id });
        }
    }
}