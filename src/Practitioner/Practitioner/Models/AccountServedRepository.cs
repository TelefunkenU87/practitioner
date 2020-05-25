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
    public class AccountServedRepository : IAccountServedRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public AccountServedRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("LocalConnection");
        }

        public AccountServed AddAccountServed(AccountServed addAccountServed)
        {
            var sql = "INSERT INTO dbo.AccountServed " +
                      "VALUES(" +
                      "@EmployeeId, " +
                      "@Account, " +
                      "@ClientService, " +
                      "@Industry, " +
                      "@Sector, " +
                      "@StartDate, " +
                      "@EndDate);";

            using(IDbConnection conn = new SqlConnection(_connString))
            {
                var executedRows = conn.Execute(sql, new
                {
                    EmployeeId = addAccountServed.EmployeeId,
                    Account = addAccountServed.Account,
                    ClientService = addAccountServed.ClientService,
                    Industry = addAccountServed.Industry,
                    Sector = addAccountServed.Sector,
                    StartDate = addAccountServed.StartDate,
                    EndDate = addAccountServed.EndDate
                });
            }
            return addAccountServed;
        }

        public List<AccountServed> GetAccountServedByEmployeeId(int employeeId)
        {
            var sql = "SELECT * FROM dbo.AccountServed WHERE EmployeeId = @EmployeeId;";
            var accountServed = new List<AccountServed>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                accountServed = conn.Query<AccountServed>(sql, new { EmployeeId = employeeId }).ToList();
            }
            return accountServed;
        }

        public AccountServed GetAccountServedById(int accountServedId)
        {
            var sql = "SELECT * FROM dbo.AccountServed WHERE AccountServedId = @AccountServedId;";
            var accountServed = new AccountServed();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                accountServed = conn.QueryFirstOrDefault<AccountServed>(sql, new { AccountServedId = accountServedId });
            }
            return accountServed;
        }

        public AccountServed UpdateAccountServed(AccountServed updatedAccountServed)
        {
            var sql = "UPDATE dbo.AccountServed " +
                      "SET EmployeeId = @EmployeeId, " +
                      "Account = @Account, " +
                      "ClientService = @ClientService, " +
                      "Industry = @Industry, " +
                      "Sector = @Sector, " +
                      "StartDate = @StartDate, " +
                      "EndDate = @EndDate " +
                      "WHERE AccountServedId = @AccountServedId";

            using(IDbConnection conn = new SqlConnection(_connString))
            {
                var executedRows = conn.Execute(sql, new
                {
                    EmployeeId = updatedAccountServed.EmployeeId,
                    Account = updatedAccountServed.Account,
                    ClientService = updatedAccountServed.ClientService,
                    Industry = updatedAccountServed.Industry,
                    Sector = updatedAccountServed.Sector,
                    StartDate = updatedAccountServed.StartDate,
                    EndDate = updatedAccountServed.EndDate,
                    AccountServedId = updatedAccountServed.AccountServedId
                });
            }

            return updatedAccountServed;
        }
    }
}
