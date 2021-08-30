using App.Models;
using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var Malfunctions = _context.Malfunctions
                .Include(x => x.Issues)
                .Where(x=>x.Issues.First().State == State.InProgress)
                .ToList();
            foreach(var item in Malfunctions)
            {
                //if (item.MalfunctionDescription.Length > 50)
                //    item.MalfunctionDescription = item.MalfunctionDescription.Substring(0, 50);
            }
            return View(Malfunctions);
        }
        public IActionResult Information()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
