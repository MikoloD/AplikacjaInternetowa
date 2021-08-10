using MapApp.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapApp.Controllers
{
    public class IssueController : Controller
    {
        [HttpGet]
        public IActionResult AddIssue()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddIssue(Issue issue)
        {
            return View();
        }
    }
}
