using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Practitioner.ViewModel;
using System.Text;
using Microsoft.AspNetCore.Razor.Language;

namespace Practitioner.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportCriteriaRepository _reportCriteriaRepository;
        public ReportController(IReportCriteriaRepository reportCriteriaRepository)
        {
            _reportCriteriaRepository = reportCriteriaRepository;
        }
        public IActionResult Index()
        {
            var reportCriteria = _reportCriteriaRepository.GetReportCriterias();
            return View(new ReportCriteriaViewModel
            {
                ReportCriteria = new ReportCriteria(),
                StoredCriteria = reportCriteria
            });
            //var reportCriteria = new ReportCriteria();
            //return View(reportCriteria);
        }
        public IActionResult DeleteCriteria(int id)
        {
            if (id > 0)
            {
                _reportCriteriaRepository.DeleteReportCriteria(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SendCriteria(ReportCriteriaViewModel Criteria)
        {
            int Id = 0;
            if (Criteria.ReportCriteria.ReportCriteriaId > 0)
            {
                _reportCriteriaRepository.UpdateReportCriteria(Criteria.ReportCriteria);
                Id = Criteria.ReportCriteria.ReportCriteriaId;
            }
            else if (ModelState.IsValid)
            {
                _reportCriteriaRepository.AddReportCriteria(Criteria.ReportCriteria);
                Id = Criteria.ReportCriteria.ReportCriteriaId;
            }
            //if (Id != 0)
            //{
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View(updatedAccountServed);
            //}
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PrintCriteria(ReportCriteriaViewModel Criteria)
        {
            switch (Criteria.Report)
            {
                case "RptInterestInRelo":
                    var report = _reportCriteriaRepository.GetRptInterestInRelo();
                    break;
                default:
                    return NotFound();
                    break;
            }
            return RedirectToAction("Index");
        }
    }
}
