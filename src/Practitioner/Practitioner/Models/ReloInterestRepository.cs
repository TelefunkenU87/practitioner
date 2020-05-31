using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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
        public ReloInterest AddReloInterest(ReloInterest addReloInterest)
        {
            var procedure = "spAddReloInterest";
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

        public List<ReloInterest> GetReloInterestByEmployeeId(int employeeId)
        {
            var procedure = "spGetReloInterestByEmployeeId";
            var parameter = new { @EmployeeId = employeeId };
            var reloInterests = new List<ReloInterest>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                reloInterests = conn.Query<ReloInterest>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
            }
            return reloInterests;
        }

        public ReloInterest GetReloInterestById(int reloInterestId)
        {
            var procedure = "spGetReloInterestById";
            var parameter = new { @ReloInterestId = reloInterestId };
            var reloInterest = new ReloInterest();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                reloInterest = conn.QueryFirstOrDefault<ReloInterest>(procedure, parameter, commandType: CommandType.StoredProcedure);
            }
            return reloInterest;
        }

        public ReloInterest UpdateReloInterest(ReloInterest updatedReloInterest)
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
