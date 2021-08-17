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
            var querry = _context.Issues
                .Where(x => x.Malfunction.State != State.Finished);
            ViewBag.Issues = querry;
            ViewBag.Malfunctions = _context.Malfunctions
                .Where(x => x.State != State.Finished);
            return View();
        }
        [HttpPost]
        public IActionResult AddMalfunction(MalfunctionModel malfunction,IssueModel issue)
        {
            return View(nameof(Index));
        }
    }
}
