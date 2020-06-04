using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Models;

namespace Practitioner.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendCriteria([FromBody] CriteriaRequestModel criteria)
        {
            return RedirectToAction("Index");
        }
    }
}
