using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.Models
{
    public class BoardsCommitteeRepository : IBoardsCommitteesRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public BoardsCommitteeRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }

        public BoardsCommitteesDTO AddBoardsCommittees(BoardsCommitteesDTO addBoardsCommittees)
        {
            var procedure = "spAddBoardsCommittees";
            var parameters = new
            {
                @EmployeeId = addBoardsCommittees.EmployeeId,
                @BoardCommittee = addBoardsCommittees.BoardCommittee,
                @Other = addBoardsCommittees.Other,
                @Role = addBoardsCommittees.Role,
                @Comments = addBoardsCommittees.Comments
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                var executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addBoardsCommittees;
        }

        public int DeleteBoardsCommittees(int boardsCommitteesId)
        {
            var procedure = "spDeleteBoardsCommittees";
            var parameters = new { @BoardsCommitteesId = boardsCommitteesId };
            int executedRows = 0;

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return executedRows;
        }

        public List<BoardsCommitteesDTO> GetBoardsCommitteesByEmployeeId(int employeeId)
        {
            var procedure = "spGetBoardsCommitteesByEmployeeId";
            var parameter = new { @EmployeeId = employeeId };
            var boardsCommittees = new List<BoardsCommitteesDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                boardsCommittees = conn.Query<BoardsCommitteesDTO>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
            }
            return boardsCommittees;
        }

        public BoardsCommitteesDTO GetBoardsCommitteesById(int boardsCommitteesId)
        {
            var procedure = "spGetBoardsCommitteesById";
            var parameter = new { @BoardsCommitteesId = boardsCommitteesId };
            var boardsCommittees = new BoardsCommitteesDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                boardsCommittees = conn.QueryFirstOrDefault<BoardsCommitteesDTO>(procedure, parameter, commandType: CommandType.StoredProcedure);
            }
            return boardsCommittees;
        }

        public BoardsCommitteesDTO UpdateBoardCommittees(BoardsCommitteesDTO UpdatedBoardsCommittees)
        {
            var procedure = "spUpdateBoardCommittees";
            var parameters = new
            {
                @BoardCommitteeId = UpdatedBoardsCommittees.BoardsCommitteesId,
                @EmployeeId = UpdatedBoardsCommittees.EmployeeId,
                @BoardCommittee = UpdatedBoardsCommittees.BoardCommittee,
                @Other = UpdatedBoardsCommittees.Other,
                @Role = UpdatedBoardsCommittees.Role,
                @Comments = UpdatedBoardsCommittees.Comments
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return UpdatedBoardsCommittees;
        }
    }
}
