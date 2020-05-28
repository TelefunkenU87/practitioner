﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public class PracticeManagementRepository : IPracticeManagementRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public PracticeManagementRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }

        public PracticeManagement AddPracticeManagement(PracticeManagement addPracticeManagement)
        {
            var procedure = "spAddPracticeManagement";
            var parameters = new
            {
                @EmployeeId = addPracticeManagement.EmployeeId,
                @Role = addPracticeManagement.Role,
                @Other = addPracticeManagement.Other,
                @Office = addPracticeManagement.Office,
                @Industry = addPracticeManagement.Industry,
                @Sector = addPracticeManagement.Sector,
                @StartDate = addPracticeManagement.StartDate,
                @EndDate = addPracticeManagement.EndDate,
                @Comments = addPracticeManagement.Comments
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                var executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addPracticeManagement;
        }

        public int DeletePracticeManagement(int practiceManagementId)
        {
            var procedure = "spDeletePracticeManagement";
            var parameters = new { @PracticeManagementId = practiceManagementId };
            int executedRows = 0;

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return executedRows;
        }

        public List<PracticeManagement> GetPracticeManagementByEmployeeId(int employeeId)
        {
            var procedure = "spGetPracticeManagementByEmployeeId";
            var parameter = new { @EmployeeId = employeeId };
            var practiceManagements = new List<PracticeManagement>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                practiceManagements = conn.Query<PracticeManagement>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
            }
            return practiceManagements;
        }

        public PracticeManagement GetPracticeManagementById(int practiceManagementId)
        {
            var procedure = "spGetPracticeManagementById";
            var parameter = new { @PracticeManagementId = practiceManagementId };
            var practiceManagement = new PracticeManagement();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                practiceManagement = conn.QueryFirstOrDefault<PracticeManagement>(procedure, parameter, commandType: CommandType.StoredProcedure);
            }
            return practiceManagement;
        }

        public PracticeManagement UpdatePracticeManagement(PracticeManagement updatedPracticeManagement)
        {
            var procedure = "spUpdatePracticeManagement";
            var parameters = new
            {
                @PracticeManagementId = updatedPracticeManagement.PracticeManagementId,
                @EmployeeId = updatedPracticeManagement.EmployeeId,
                @Role = updatedPracticeManagement.Role,
                @Other = updatedPracticeManagement.Other,
                @Office = updatedPracticeManagement.Office,
                @Industry = updatedPracticeManagement.Industry,
                @Sector = updatedPracticeManagement.Sector,
                @StartDate = updatedPracticeManagement.StartDate,
                @EndDate = updatedPracticeManagement.EndDate,
                @Comments = updatedPracticeManagement.Comments
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return updatedPracticeManagement;
        }
    }
}
