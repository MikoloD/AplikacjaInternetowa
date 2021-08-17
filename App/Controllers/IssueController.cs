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
        private ApplicationDbContext _context { get; set; }
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
            _context.Issues.Add(issue);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
