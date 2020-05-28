using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
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

        public Employee GetEmployeeById(int employeeId)
        {
            var procedure = "spGetEmployeeById";
            var parameters = new { @EmployeeId = employeeId};
            var employee = new Employee();
            
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                employee = conn.QueryFirstOrDefault<Employee>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var procedure = "spGetEmployees";
            var employees = new List<Employee>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                employees = conn.Query<Employee>(procedure).ToList();
            }
            return employees;
        }
    }
}
