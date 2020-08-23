using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.ViewModel
{
    public class BoardsCommitteesViewModel
    {
        public List<BoardsCommitteesDTO> BoardsCommittees { get; set; }
        public EmployeeDTO Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
        public ExperienceTabNavViewModel ExperienceTabNav { get; set; }
        public BoardsCommitteesDTO NewBoardsCommittees { get; set; }
    }
}
