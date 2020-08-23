using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.Models
{
    public class ReloInterestRepository : IReloInterestRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public ReloInterestRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }
        public ReloInterestDTO AddReloInterest(ReloInterestDTO addReloInterest)
        {
            var procedure = "spaddReloInterest";
            var parameters = new
            {
                @EmployeeId = addReloInterest.EmployeeId,
                @Location = addReloInterest.Location,
                @InterestLevel = addReloInterest.InterestLevel,
                @Timing = addReloInterest.Timing,
                @Comments = addReloInterest.Comments
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                var executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addReloInterest;
        }

        public int DeleteReloInterest(int reloInterestId)
        {
            var procedure = "spDeleteReloInterest";
            var parameters = new { @ReloInterestId = reloInterestId };
            int executedRows = 0;

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return executedRows;
        }

        public List<ReloInterestDTO> GetReloInterestByEmployeeId(int employeeId)
        {
            var procedure = "spGetReloInterestByEmployeeId";
            var parameter = new { @EmployeeId = employeeId };
            var reloInterestsDTO = new List<ReloInterestDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                reloInterestsDTO = conn.Query<ReloInterestDTO>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
            }
            return reloInterestsDTO;
        }

        public ReloInterestDTO GetReloInterestById(int reloInterestId)
        {
            var procedure = "spGetReloInterestById";
            var parameter = new { @ReloInterestId = reloInterestId };
            var reloInterestDTO = new ReloInterestDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                reloInterestDTO = conn.QueryFirstOrDefault<ReloInterestDTO>(procedure, parameter, commandType: CommandType.StoredProcedure);
            }
            return reloInterestDTO;
        }

        public ReloInterestDTO UpdateReloInterest(ReloInterestDTO updatedReloInterest)
        {
            var procedure = "spUpdateReloInterest";
            var parameters = new
            {
                @ReloInterestId = updatedReloInterest.ReloInterestId,
                @EmployeeId = updatedReloInterest.EmployeeId,
                @Location = updatedReloInterest.Location,
                @InterestLevel = updatedReloInterest.InterestLevel,
                @Timing = updatedReloInterest.Timing,
                @Comments = updatedReloInterest.Comments
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return updatedReloInterest;
        }
    }
}
