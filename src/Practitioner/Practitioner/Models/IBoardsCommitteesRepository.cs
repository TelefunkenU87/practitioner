using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.Models
{
    public interface IBoardsCommitteesRepository
    {
        BoardsCommitteesDTO AddBoardsCommittees(BoardsCommitteesDTO addBoardsCommittees);
        int DeleteBoardsCommittees(int boardsCommitteesId);
        List<BoardsCommitteesDTO> GetBoardsCommitteesByEmployeeId(int employeeId);
        BoardsCommitteesDTO GetBoardsCommitteesById(int boardsCommitteesId);
        BoardsCommitteesDTO UpdateBoardCommittees(BoardsCommitteesDTO UpdatedBoardsCommittees);
    }
}
