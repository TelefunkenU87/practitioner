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
    public class GeneralInterestRepository : IGeneralInterestRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public GeneralInterestRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }

        public GeneralInterestDTO AddGeneralInterest(GeneralInterestDTO addGeneralInterest)
        {
            var procedure = "spAddGeneralInterest";
            var parameters = new
            {
                @EmployeeId = addGeneralInterest.EmployeeId,
                @Department = addGeneralInterest.Department,
                @Comments = addGeneralInterest.Comments
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                var executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addGeneralInterest;
        }

        public int DeleteGeneralInterest(int generalInterestId)
        {
            var procedure = "spDeleteGeneralInterest";
            var parameters = new { @GeneralInterestId = generalInterestId };
            int executedRows = 0;

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return executedRows;
        }

        public List<GeneralInterestDTO> GetGeneralInterestByEmployeeId(int employeeId)
        {
            var procedure = "spGetGeneralInterestByEmployeeId";
            var parameter = new { @EmployeeId = employeeId };
            var generalInterests = new List<GeneralInterestDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                generalInterests = conn.Query<GeneralInterestDTO>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
            }
            return generalInterests;
        }

        public GeneralInterestDTO GetGeneralInterestById(int generalInterestId)
        {
            var procedure = "spGetGeneralInterestById";
            var parameter = new { @GeneralInterestId = generalInterestId };
            var generalInterest = new GeneralInterestDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                generalInterest = conn.QueryFirstOrDefault<GeneralInterestDTO>(procedure, parameter, commandType: CommandType.StoredProcedure);
            }
            return generalInterest;
        }

        public GeneralInterestDTO UpdateGeneralInterest(GeneralInterestDTO updatedGeneralInterest)
        {
            var procedure = "spUpdateGeneralInterest";
            var parameters = new
            {
                @GeneralInterestId = updatedGeneralInterest.GeneralInterestId,
                @EmployeeId = updatedGeneralInterest.EmployeeId,
                @Department = updatedGeneralInterest.Department,
                @Comments = updatedGeneralInterest.Comments
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return updatedGeneralInterest;
        }
    }
}
