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
            _connString = _config.GetConnectionString("LocalConnection");
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var sql = "SELECT * FROM dbo.Employee WHERE EmployeeId = @EmployeeId;";
            var employee = new Employee();
            
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                employee = conn.QueryFirstOrDefault<Employee>(sql, new { EmployeeId = employeeId });
            }
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var sql = "SELECT * FROM dbo.Employee;";
            var employees = new List<Employee>();
            
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                employees = conn.Query<Employee>(sql).ToList();
            }
            return employees;
        }
    }
}
