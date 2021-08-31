using App.Data;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace App.Controllers
{
    public class MalfunctionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public int IssueId { get; set; }
        public MalfunctionController(ApplicationDbContext context,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public bool UrlProtection()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return true;
            }
            return false;
        }

        public void MalfunctionService(MalfunctionModel malfunction, int id)
        {
            var Malfunctions = _context.Malfunctions
                .Include(x => x.Issues)
                .First(x => x.MalfunctionId == malfunction.MalfunctionId);
            var Issue = _context.Issues
                .First(x => x.IssueId == id);
            Issue.State = State.InProgress;
            Malfunctions.Issues.Add(Issue);

            _context.SaveChanges();
        }
        [HttpGet]

        public IActionResult Index()
        {
            if (UrlProtection())
            {
                List<IssueModel> model = _context.Issues
                    .Include(x => x.Images)
                    .Where(x => x.State == State.Reported)
                    .ToList();
                var querry = _context.Malfunctions
                    .Include(x => x.Issues)
                    .ThenInclude(x => x.Images)
                    .Where(x => x.Issues.First().State == State.InProgress)
                    .ToList();
                foreach (var malfunction in querry)
                {
                    var issue = malfunction.Issues.First();
                    issue.Description = malfunction.MalfunctionDescription;
                    model.Add(issue);
                }
                return View(model);
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }
        [HttpGet]
        public IActionResult AddMalfunction(int id)
        {
            if (UrlProtection())
            {
                ViewBag.Id = id;
                var issue = _context.Issues
                    .First(x => x.IssueId == id);
                ViewBag.Issue = issue;
                ViewBag.Malfunctions = _context.Malfunctions
                    .Include(x => x.Issues)
                    .Where(x => x.Issues.First().State == State.InProgress)
                    .ToList();
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }      
        }
        [HttpPost]
        public IActionResult AddMalfunction(MalfunctionModel malfunction, int id)
        {
            if (UrlProtection())
            {
                _context.Add(malfunction);
                _context.SaveChanges();
                MalfunctionService(malfunction, id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
            
        }
        [HttpPost]
        public IActionResult AddIssueToMalfunction(MalfunctionModel malfunction, int id)
        {
            if (UrlProtection())
            {
                UrlProtection();
                MalfunctionService(malfunction, id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }           
        }
        [HttpGet]
        public IActionResult ChangeMalfunctionState(int id)
        {
            if (UrlProtection())
            {
                var issue = _context.Issues.First(x => x.IssueId == id);
                if (issue.MalfunctionId == null)
                {
                    issue.State = State.Finished;
                }
                else
                {
                    var malfunctionId = _context.Malfunctions
                        .Include(x => x.Issues)
                        .First(x => x.Issues.First(x => x.IssueId == id) == issue).MalfunctionId;
                    var Issues = _context.Issues.Where(x => x.MalfunctionId == malfunctionId);
                    foreach (var item in Issues)
                    {
                        item.State = State.Finished;
                        _context.Issues.Update(item);
                    }
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
            
        }
    }
}
