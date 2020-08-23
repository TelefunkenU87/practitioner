using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.Models
{
    public interface IReportCriteriaRepository
    {
        ReportCriteriaDTO AddReportCriteria(int BaseReportCriteriaId, ReportCriteriaDTO addReportCriteria);
        int DeleteReportCriteria(int reportCriteriaId);
        ReportCriteriaDTO GetReportCriteriaById(int reportCriteriaId);
        List<ReportCriteriaDTO> GetReportCriterias();
        ReportCriteriaDTO UpdateReportCriteria(ReportCriteriaDTO updatedReportCriteria);
        List<RptInterestInRelo> GetRptInterestInRelo();
        List<string> GetBaseReportCriteriaCategory();
        List<BaseReportCriteriaFields> GetBaseReportCriteriaFields(string category);
        List<string> GetBaseReportCriteriaFieldValues(int Id);
    }
}
