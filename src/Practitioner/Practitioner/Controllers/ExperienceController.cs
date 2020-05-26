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
        public ExperienceController(IEmployeeRepository employeeRepository, IAccountServedRepository accountServedRepository)
        {
            _employeeRepository = employeeRepository;
            _accountServedRepository = accountServedRepository;
        }

        public IActionResult AccountServed(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            var accountsServed = _accountServedRepository.GetAccountServedByEmployeeId(id);
            var categoryNav = new CategoryNavViewModel{ EmployeeId = employee.EmployeeId, ExperienceActive = "active"};

            return View(new AccountServedViewModel
            {
                Employee = employee,
                AccountsServed = accountsServed,
                CategoryNav = categoryNav,
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
    }
}