using App.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;
using System.Text.RegularExpressions;

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
            foreach (var item in issue.Images)
            {
                if (item.Img != null)
                {               
                var base64Data = Regex.Match(item.Img, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                item.Image = Convert.FromBase64String(base64Data);
                }
            }
            issue.Date = DateTime.Now;
            issue.State = State.Reported;
            _context.Issues.Add(issue);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
