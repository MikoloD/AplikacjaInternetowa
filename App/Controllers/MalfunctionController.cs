using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class MalfunctionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MalfunctionController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<IssueModel> model = _context.Issues
                .Include(x=>x.Images)
                .Where(x => x.State == State.Reported)
                .ToList();
            var querry = _context.Malfunctions
                .Include(x => x.Issues)
                .ThenInclude(x=>x.Images)
                .ToList();
            foreach (var malfunction in querry)
            {
                var issue = malfunction.Issues
                    .First();
                issue.Description = malfunction.MalfunctionDescription;
                model.Add(issue);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddMalfunction(int id)
        {
            var Issue = _context.Issues
                .Include(x => x.Malfunction)
                .First(x => x.IssueId == id);
            return View(Issue);
        }
        [HttpPost]
        public IActionResult AddMalfunction(MalfunctionModel malfunction)
        {
            return View();
        }
    }
}
