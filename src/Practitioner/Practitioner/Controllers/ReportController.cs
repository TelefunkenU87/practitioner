﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Practitioner.ViewModel;
using System.Text;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc.Rendering;
using PractitionerDTO;

namespace Practitioner.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportCriteriaRepository _reportCriteriaRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportController(IReportCriteriaRepository reportCriteriaRepository, IWebHostEnvironment webHostEnvironment)
        {
            _reportCriteriaRepository = reportCriteriaRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var reportCriteria = _reportCriteriaRepository.GetReportCriterias();
            var categoriesList = _reportCriteriaRepository.GetBaseReportCriteriaCategory();
            var categories = new List<SelectListItem>();
            categories.Add(new SelectListItem("Select Category", "Select Category"));
            foreach(var item in categoriesList)
            {
                categories.Add(new SelectListItem(item, item));
            }
            //var fieldsList = _reportCriteriaRepository.GetBaseReportCriteriaFields(categoriesList[0]);
            //var fields = new List<SelectListItem>();
            //foreach(var item in fieldsList)
            //{
            //    fields.Add(new SelectListItem(item.FriendlyField, item.Field));
            //}
            var fields = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Select Category", Value = "0"}
            };
            return View(new ReportCriteriaViewModel
            {
                ReportCriteria = new ReportCriteriaDTO(),
                BaseReportCriteriaId = 0,
                Category = categories,
                Fields = fields,
                StoredCriteria = reportCriteria
            });
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
                _reportCriteriaRepository.AddReportCriteria(Criteria.BaseReportCriteriaId, Criteria.ReportCriteria);
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
        public IActionResult PrintReport(ReportCriteriaViewModel Criteria)
        {
            switch (Criteria.Report)
            {
                case "RptInterestInRelo":
                    var report = _reportCriteriaRepository.GetRptInterestInRelo();
                    var url = Export(report);
                    ViewBag.DownloadUrl = url;
                    return View(Criteria.Report.ToString(), report);
                    break;
                default:
                    return NotFound();
                    break;
            }
            return RedirectToAction("Index");
        }

        public string Export(List<RptInterestInRelo> report)
        {
            string sWebRootFolder = _webHostEnvironment.WebRootPath;
            string sFileName = @"demo.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            }
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Interest in Relocation");
                //First add the headers
                worksheet.Cells[1, 1].Value = "Employee Id";
                worksheet.Cells[1, 2].Value = "Email";
                worksheet.Cells[1, 3].Value = "Name";
                worksheet.Cells[1, 4].Value = "Department";
                worksheet.Cells[1, 5].Value = "Location";
                worksheet.Cells[1, 6].Value = "Interest Level";
                worksheet.Cells[1, 7].Value = "Timing";
                worksheet.Cells[1, 8].Value = "Comments";
                //Add values
                for (int i = 0; i < report.Count(); i++)
                {
                    worksheet.Cells[$"A{i + 2}"].Value = report[i].EmployeeId;
                    worksheet.Cells[$"B{i + 2}"].Value = $"{report[i].Email}@company.org";
                    worksheet.Cells[$"C{i + 2}"].Value = $"{report[i].LastName}, {report[i].FirstName}";
                    worksheet.Cells[$"D{i + 2}"].Value = $"{report[i].Department}";
                    worksheet.Cells[$"E{i + 2}"].Value = $"{report[i].Location}";
                    worksheet.Cells[$"F{i + 2}"].Value = $"{report[i].InterestLevel}";
                    worksheet.Cells[$"G{i + 2}"].Value = $"{report[i].Timing}";
                    worksheet.Cells[$"H{i + 2}"].Value = $"{report[i].Comments}";
                }

                package.Save(); //Saves the workbook
            }
            return URL;
        }
    }
}
