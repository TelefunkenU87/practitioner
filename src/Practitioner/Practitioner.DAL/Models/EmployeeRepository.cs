using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;
using PractitionerDAL.Interfaces;

namespace PractitionerDAL.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public EmployeeRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }

        public EmployeeDTO GetEmployeeById(int employeeId)
        {
            var procedure = "spGetEmployeeById";
            var parameters = new { @EmployeeId = employeeId};
            var employee = new EmployeeDTO();
            
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                employee = conn.QueryFirstOrDefault<EmployeeDTO>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return employee;
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var procedure = "spGetEmployees";
            var employees = new List<EmployeeDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                employees = conn.Query<EmployeeDTO>(procedure).ToList();
            }
            return employees;
        }
    }
}
