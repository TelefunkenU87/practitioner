using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public interface IReportCriteriaRepository
    {
        ReportCriteria AddReportCriteria(int BaseReportCriteriaId, ReportCriteria addReportCriteria);
        int DeleteReportCriteria(int reportCriteriaId);
        ReportCriteria GetReportCriteriaById(int reportCriteriaId);
        List<ReportCriteria> GetReportCriterias();
        ReportCriteria UpdateReportCriteria(ReportCriteria updatedReportCriteria);
        List<RptInterestInRelo> GetRptInterestInRelo();
        List<string> GetBaseReportCriteriaCategory();
        List<BaseReportCriteriaFields> GetBaseReportCriteriaFields(string category);
    }
}
