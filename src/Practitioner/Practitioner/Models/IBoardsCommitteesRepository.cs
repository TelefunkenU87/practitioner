using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public interface IBoardsCommitteesRepository
    {
        BoardsCommittees AddBoardsCommittees(BoardsCommittees addBoardsCommittees);
        int DeleteBoardsCommittees(int boardsCommitteesId);
        List<BoardsCommittees> GetBoardsCommitteesByEmployeeId(int employeeId);
        BoardsCommittees GetBoardsCommitteesById(int boardsCommitteesId);
        BoardsCommittees UpdateBoardCommittees(BoardsCommittees UpdatedBoardsCommittees);
    }
}
