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
                .Where(x => x.State == State.Reported)
                .OrderByDescending(x=>x.Date);
            ViewBag.Issues = querry;
            ViewBag.Malfunctions = _context.Malfunctions
                .Include(x => x.Issues);
            return View();
        }
        [HttpGet]
        public IActionResult AddMalfunction(IssueModel issue)
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMalfunction(MalfunctionModel malfunction,IssueModel issue)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Photos(int id)
        {
            int check = _context.Issues
                .Where(x => x.IssueId == id)
                .Select(x => x.Images)
                .ToList()
                .Count();
            if (check > 0)
            {
                IssueModel issuePhotos = _context.Issues
                .Include(x => x.Images)
                .First(x => x.IssueId == id);

                foreach (var item in issuePhotos.Images)
                {
                    //item.MultimediumId;

                    //TODO blob to image
                }
            }
            return View();
        }
    }
}
