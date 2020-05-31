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
        private readonly IBoardsCommitteesRepository _boardsCommitteesRepository;
        private readonly ICareerInterestRepository _careerInterestRepository;
        private readonly IGeneralInterestRepository _generalInterestRepository;
        private readonly IReloInterestRepository _reloInterestRepository;
        public ExperienceController(IEmployeeRepository employeeRepository, IAccountServedRepository accountServedRepository,
                                    IPracticeManagementRepository practiceManagementRepository,
                                    IBoardsCommitteesRepository boardsCommitteesRepository,
                                    ICareerInterestRepository careerInterestRepository,
                                    IGeneralInterestRepository generalInterestRepository,
                                    IReloInterestRepository reloInterestRepository)
        {
            _employeeRepository = employeeRepository;
            _accountServedRepository = accountServedRepository;
            _practiceManagementRepository = practiceManagementRepository;
            _boardsCommitteesRepository = boardsCommitteesRepository;
            _careerInterestRepository = careerInterestRepository;
            _generalInterestRepository = generalInterestRepository;
            _reloInterestRepository = reloInterestRepository;
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

        public IActionResult BoardsCommittees(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            var boardsCommittees = _boardsCommitteesRepository.GetBoardsCommitteesByEmployeeId(id);
            var categoryNav = new CategoryNavViewModel { EmployeeId = employee.EmployeeId, ExperienceActive = "active" };
            var experienceTabNav = new ExperienceTabNavViewModel { EmployeeId = employee.EmployeeId, BoardCommitteeActive = "active" };

            return View(new BoardsCommitteesViewModel
            {
                BoardsCommittees = boardsCommittees,
                Employee = employee,
                CategoryNav = categoryNav,
                ExperienceTabNav = experienceTabNav,
                NewBoardsCommittees = new BoardsCommittees { BoardsCommitteesId = 0, EmployeeId = employee.EmployeeId }
            });
        }

        public IActionResult BoardsCommitteesEdit(int id)
        {
            var boardsCommittees = _boardsCommitteesRepository.GetBoardsCommitteesById(id);
            return PartialView(boardsCommittees);
        }

        [HttpPost]
        public IActionResult BoardsCommitteesEdit(BoardsCommittees updatedBoardsCommittees)
        {
            int Id = 0;
            if (updatedBoardsCommittees.BoardsCommitteesId > 0)
            {
                _boardsCommitteesRepository.UpdateBoardCommittees(updatedBoardsCommittees);
                Id = updatedBoardsCommittees.EmployeeId;
            }
            else if (ModelState.IsValid)
            {
                _boardsCommitteesRepository.AddBoardsCommittees(updatedBoardsCommittees);
                Id = updatedBoardsCommittees.EmployeeId;
            }
            if (Id != 0)
            {
                return RedirectToAction("BoardsCommittees", new { id = Id });
            }
            else
            {
                return View(updatedBoardsCommittees);
            }
        }

        public IActionResult BoardsCommitteesDelete(int id, int employeeId)
        {
            int Id = employeeId;
            if (id > 0)
            {
                _boardsCommitteesRepository.DeleteBoardsCommittees(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("BoardsCommittees", new { id = Id });
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
                NewCareerInterest = new CareerInterest { CareerInterestId = 0, EmployeeId = employee.EmployeeId }
            });
        }

        public IActionResult CareerInterestEdit(int id)
        {
            var careerInterest = _careerInterestRepository.GetCareerInterestById(id);
            return PartialView(careerInterest);
        }

        [HttpPost]
        public IActionResult CareerInterestEdit(CareerInterest updatedCareerInterest)
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
                NewGeneralInterest = new GeneralInterest { GeneralInterestId = 0, EmployeeId = employee.EmployeeId }
            });
        }

        public IActionResult GeneralInterestEdit(int id)
        {
            var generalInterest = _generalInterestRepository.GetGeneralInterestById(id);
            return PartialView(generalInterest);
        }

        [HttpPost]
        public IActionResult GeneralInterestEdit(GeneralInterest updatedGeneralInterest)
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
                NewReloInterest = new ReloInterest { ReloInterestId = 0, EmployeeId = employee.EmployeeId }
            });
        }

        public IActionResult ReloInterestEdit(int id)
        {
            var reloInterest = _reloInterestRepository.GetReloInterestById(id);
            return PartialView(reloInterest);
        }

        [HttpPost]
        public IActionResult ReloInterestEdit(ReloInterest updatedReloInterest)
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