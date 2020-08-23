using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ReportCriteriaRepository : IReportCriteriaRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public ReportCriteriaRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }

        public ReportCriteriaDTO AddReportCriteria(int BaseReportCriteriaId, ReportCriteriaDTO addReportCriteria)
        {
            var procedure = "spAddReportCriteria";
            var parameters = new
            {
                //@Field = addReportCriteria.Field,
                @Id = BaseReportCriteriaId,
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

        public List<string> GetBaseReportCriteriaCategory()
        {
            var procedure = "SELECT DISTINCT Category FROM dbo.BaseReportCriteria;";
            var categories = new List<string>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                categories = conn.Query<string>(procedure, commandType: CommandType.Text).ToList();
            }
            return categories;
        }

        public List<BaseReportCriteriaFields> GetBaseReportCriteriaFields(string category)
        {
            var procedure = $"SELECT BaseReportCriteria.BaseReportCriteriaId, BaseReportCriteria.FriendlyField FROM dbo.BaseReportCriteria WHERE BaseReportCriteria.Category = '{category}'";
            var parameters = "";
            var baseReportCriteriaFields = new List<BaseReportCriteriaFields>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                baseReportCriteriaFields = conn.Query<BaseReportCriteriaFields>(procedure, commandType: CommandType.Text).ToList();
            }
            return baseReportCriteriaFields;
        }

        public List<string> GetBaseReportCriteriaFieldValues(int Id)
        {
            var procedure = "spGetReportCriteriaFieldValues";
            var parameters = new
            {
                @BaseReportCriteriaId = Id
            };
            var results = new List<String>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                results = conn.Query<String>(procedure, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return results;
        }

        public ReportCriteriaDTO GetReportCriteriaById(int reportCriteriaId)
        {
            var procedure = "spGetReportCriteriaById";
            var parameters = new { @ReportCriteriaId = reportCriteriaId };
            var reportCriteria = new ReportCriteriaDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                reportCriteria = conn.QueryFirstOrDefault<ReportCriteriaDTO>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return reportCriteria;
        }

        public List<ReportCriteriaDTO> GetReportCriterias()
        {
            var procedure = "spGetReportCriterias";
            var reportCriterias = new List<ReportCriteriaDTO>();

            using(IDbConnection conn = new SqlConnection(_connString))
            {
                reportCriterias = conn.Query<ReportCriteriaDTO>(procedure).ToList();
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

        public ReportCriteriaDTO UpdateReportCriteria(ReportCriteriaDTO updatedReportCriteria)
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
