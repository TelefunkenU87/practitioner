using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Models;
using Practitioner.ViewModel;

namespace Practitioner.Controllers
{
    public class BoardsCommitteesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IBoardsCommitteesRepository _boardsCommitteesRepository;

        public BoardsCommitteesController(IEmployeeRepository employeeRepository, IBoardsCommitteesRepository boardsCommitteesRepository)
        {
            _employeeRepository = employeeRepository;
            _boardsCommitteesRepository = boardsCommitteesRepository;
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
    }
}
