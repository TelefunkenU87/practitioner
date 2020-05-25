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
        private readonly IConfiguration config;
        private readonly string _connString;
        public EmployeeRepository(IConfiguration config)
        {
            this.config = config;
            _connString = config.GetConnectionString("LocalConnection");
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var sql = "SELECT * FROM dbo.Employee WHERE EmployeeId = @EmployeeId;";
            var _employee = new Employee();
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                _employee = conn.QueryFirstOrDefault<Employee>(sql, new { EmployeeId = employeeId });
            }
            return _employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var sql = "SELECT * FROM dbo.Employee;";
            var _employees = new List<Employee>();
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                _employees = conn.Query<Employee>(sql).ToList();
            }
            return _employees;
        }
    }
}
