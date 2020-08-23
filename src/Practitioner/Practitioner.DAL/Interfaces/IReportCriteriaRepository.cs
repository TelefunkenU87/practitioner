using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace PractitionerDAL.Interfaces
{
    public interface IReportCriteriaRepository
    {
        ReportCriteriaDTO AddReportCriteria(int BaseReportCriteriaId, ReportCriteriaDTO addReportCriteria);
        int DeleteReportCriteria(int reportCriteriaId);
        ReportCriteriaDTO GetReportCriteriaById(int reportCriteriaId);
        List<ReportCriteriaDTO> GetReportCriterias();
        ReportCriteriaDTO UpdateReportCriteria(ReportCriteriaDTO updatedReportCriteria);
        List<RptInterestInReloDTO> GetRptInterestInRelo();
        List<string> GetBaseReportCriteriaCategory();
        List<BaseReportCriteriaFieldsDTO> GetBaseReportCriteriaFields(string category);
        List<string> GetBaseReportCriteriaFieldValues(int Id);
    }
}
