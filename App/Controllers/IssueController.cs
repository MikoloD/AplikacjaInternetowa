using App.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IssueController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Issue()
        {
            return View(new IssueModel());
        }
        [HttpPost]
        public IActionResult AddIssue(IssueModel issue)
        {
            issue.Date = DateTime.Now;
            _context.Issues.Add(issue);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
