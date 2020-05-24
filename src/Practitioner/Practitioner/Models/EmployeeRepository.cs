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
        public IEnumerable<Employee> GetEmployees()
        {
            var _employees = new List<Employee>();
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                _employees = conn.Query<Employee>("SELECT * from dbo.Employee;").ToList();
            }
            return _employees;
        }
    }
}
