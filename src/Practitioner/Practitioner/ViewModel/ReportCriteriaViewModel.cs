using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractitionerDTO;

namespace Practitioner.ViewModel
{
    public class ReportCriteriaViewModel
    {
        public ReportCriteriaDTO ReportCriteria { get; set; }
        public int BaseReportCriteriaId { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<SelectListItem> Fields { get; set; }
        //public List<SelectListItem> Fields { get; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "ReloInterest.Location", Text = "Interest in Relocation - Location" },
        //    new SelectListItem { Value = "ReloInterest.InterestLevel", Text = "Interest in Relocation - Interest Level" },
        //    new SelectListItem { Value = "ReloInterest.Timing", Text = "Interest in Relocation - Timing" }
        //};
        public List<SelectListItem> Operators { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "=", Text = "="},
            new SelectListItem { Value = "!=", Text = "!="}
        };
        public string Report { get; set; }
        public List<SelectListItem> Reports { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "RptInterestInRelo", Text = "Interest in Relocation" },
            new SelectListItem { Value = "RptInterestInRelo", Text = "Second Option - No Report"}
        };
        public List<ReportCriteriaDTO> StoredCriteria { get; set; }
    }
}
