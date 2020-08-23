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
    public class AccountServedRepository : IAccountServedRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public AccountServedRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }

        public AccountServedDTO AddAccountServed(AccountServedDTO addAccountServed)
        {
            var procedure = "spAddAccountServed";
            var parameters = new {
                @EmployeeId = addAccountServed.EmployeeId,
                @Account = addAccountServed.Account,
                @ClientService = addAccountServed.ClientService,
                @Industry = addAccountServed.Industry,
                @Sector = addAccountServed.Sector,
                @StartDate = addAccountServed.StartDate,
                @EndDate = addAccountServed.EndDate
            };

            using(IDbConnection conn = new SqlConnection(_connString))
            {
                var executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addAccountServed;
        }

        public int DeleteAccountServed(int accountServedId)
        {
            var procedure = "spDeleteAccountServed";
            var parameters = new { @AccountServedId = accountServedId };
            int executedRows = 0;

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return executedRows;
        }

        public List<AccountServedDTO> GetAccountServedByEmployeeId(int employeeId)
        {
            var procedure = "spGetAccountServedByEmployeeId";
            var parameter = new { @EmployeeId = employeeId };
            var accountServed = new List<AccountServedDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                accountServed = conn.Query<AccountServedDTO>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
            }
            return accountServed;
        }

        public AccountServedDTO GetAccountServedById(int accountServedId)
        {
            var procedure = "spGetAccountServedById";
            var parameter = new { @AccountServedId = accountServedId };
            var accountServed = new AccountServedDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                accountServed = conn.QueryFirstOrDefault<AccountServedDTO>(procedure, parameter, commandType: CommandType.StoredProcedure);
            }
            return accountServed;
        }

        public AccountServedDTO UpdateAccountServed(AccountServedDTO updatedAccountServed)
        {
            var procedure = "spUpdateAccountServed";
            var parameters = new {
                @AccountServedId = updatedAccountServed.AccountServedId,
                @EmployeeId = updatedAccountServed.EmployeeId,
                @Account = updatedAccountServed.Account,
                @ClientService = updatedAccountServed.ClientService,
                @Industry = updatedAccountServed.Industry,
                @Sector = updatedAccountServed.Sector,
                @StartDate = updatedAccountServed.StartDate,
                @EndDate = updatedAccountServed.EndDate
            };

            using(IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return updatedAccountServed;
        }
    }
}
