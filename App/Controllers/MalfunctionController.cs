using App.Data;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View(_context.Issues.ToList());
        }
    }
}
