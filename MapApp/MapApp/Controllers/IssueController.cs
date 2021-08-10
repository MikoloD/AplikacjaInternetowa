using MapApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapApp.Controllers
{
    public class IssueController : Controller
    {
        private readonly Context _context;
        public IssueController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Issue()
        {
            _context.Database.EnsureCreated();
            _context.Zgloszenia.Add(new Issue { Description = "costam" });
            _context.SaveChanges();
            return View();
        }
    }
}
