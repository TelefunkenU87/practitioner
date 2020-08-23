using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Practitioner.Models;
using PractitionerDAL.Interfaces;
using PractitionerDTO;

namespace Practitioner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportDataController : ControllerBase
    {
        private readonly IReportCriteriaRepository _reportCriteriaRepository;

        public ReportDataController(IReportCriteriaRepository reportCriteriaRepository)
        {
            _reportCriteriaRepository = reportCriteriaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var repoCategory = _reportCriteriaRepository.GetBaseReportCriteriaCategory();
            //return JsonResult(repoCategory);
            return Ok(repoCategory);
        }

        [HttpGet("{category}")]
        public IActionResult Get(string category)
        {
            if (!string.IsNullOrWhiteSpace(category))
            {
                var repoFields = _reportCriteriaRepository.GetBaseReportCriteriaFields(category);
                var returnFields = new List<SelectListItem>();
                foreach (var item in repoFields)
                {
                    returnFields.Add(new SelectListItem(item.FriendlyField, $"{item.BaseReportCriteriaId}"));
                }
                return Ok(returnFields);
            }
            return null;
        }

        [HttpGet("search")]
        public IActionResult GetFieldValues(int Id)
        {
            if (Id != 0)
            {
                var repoFieldValues = _reportCriteriaRepository.GetBaseReportCriteriaFieldValues(Id);
                var returnFieldValues = new List<SelectListItem>();
                foreach (var item in repoFieldValues)
                {
                    returnFieldValues.Add(new SelectListItem(item, item));
                }
                return Ok(returnFieldValues);
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpGet]
        //public ActionResult GetFields()//string category)
        //{
        //    if (!string.IsNullOrWhiteSpace(category))
        //    {
        //        var repoFields = _reportCriteriaRepository.GetBaseReportCriteriaFields(category);
        //        var returnFields = new List<SelectListItem>();
        //        foreach (var item in repoFields)
        //        {
        //            returnFields.Add(new SelectListItem(item.FriendlyField, item.Field));
        //        }
        //        return JsonResult(returnFields);
        //    }
        //    return null;
        //    return Ok();
        //}
    }
}
