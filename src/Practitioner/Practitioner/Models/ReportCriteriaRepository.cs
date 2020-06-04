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
    public class ReportCriteriaRepository : IReportCriteriaRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public ReportCriteriaRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }

        public ReportCriteria AddReportCriteria(ReportCriteria addReportCriteria)
        {
            var procedure = "spAddReportCriteria";
            var parameters = new
            {
                @Field = addReportCriteria.Field,
                @Operator = addReportCriteria.Operator,
                @FriendlyWhere = addReportCriteria.FriendlyWhere
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                var executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addReportCriteria;
        }

        public int DeleteReportCriteria(int reportCriteriaId)
        {
            var procedure = "spDeleteReportCriteria";
            var parameters = new { @ReportCriteriaId = reportCriteriaId };
            int executedRows = 0;

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return executedRows;
        }

        public ReportCriteria GetReportCriteriaById(int reportCriteriaId)
        {
            var procedure = "spGetReportCriteriaById";
            var parameters = new { @ReportCriteriaId = reportCriteriaId };
            var reportCriteria = new ReportCriteria();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                reportCriteria = conn.QueryFirstOrDefault<ReportCriteria>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return reportCriteria;
        }

        public List<ReportCriteria> GetReportCriterias()
        {
            var procedure = "spGetReportCriterias";
            var reportCriterias = new List<ReportCriteria>();

            using(IDbConnection conn = new SqlConnection(_connString))
            {
                reportCriterias = conn.Query<ReportCriteria>(procedure).ToList();
            }
            return reportCriterias;
        }

        public List<RptInterestInRelo> GetRptInterestInRelo()
        {
            var report = "RptInterestInRelo";
            var rptInterestInRelo = new List<RptInterestInRelo>();

            using(IDbConnection conn = new SqlConnection(_connString))
            {
                rptInterestInRelo = conn.Query<RptInterestInRelo>(report, commandType: CommandType.StoredProcedure).ToList();
            }
            return rptInterestInRelo;
        }

        public ReportCriteria UpdateReportCriteria(ReportCriteria updatedReportCriteria)
        {
            var procedure = "spUpdateReportCriteria";
            var parameters = new
            {
                @ReportCriteriaId = updatedReportCriteria.ReportCriteriaId,
                @Field = updatedReportCriteria.Field,
                @Operator = updatedReportCriteria.Operator,
                @FriendlyWhere = updatedReportCriteria.FriendlyWhere
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return updatedReportCriteria;
        }
    }
}