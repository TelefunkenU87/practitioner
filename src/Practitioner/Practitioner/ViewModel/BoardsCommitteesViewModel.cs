using Practitioner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.ViewModel
{
    public class BoardsCommitteesViewModel
    {
        public List<BoardsCommittees> BoardsCommittees { get; set; }
        public Employee Employee { get; set; }
        public CategoryNavViewModel CategoryNav { get; set; }
        public ExperienceTabNavViewModel ExperienceTabNav { get; set; }
        public BoardsCommittees NewBoardsCommittees { get; set; }
    }
}
