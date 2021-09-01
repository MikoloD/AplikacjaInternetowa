using App.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(ApplicationDbContext context,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public bool UrlProtection()
        {
            if (User.IsInRole("Admin"))
            {
                return true;
            }
            return false;
        }
        public IActionResult Index()
        {
            if (UrlProtection())
            {
                var users = _context.Users.ToList();
                ViewBag.Users = users;
                ViewBag.NewPassword = "";
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(string Id, string newPassword)
        {
            IdentityUser User =  await _userManager.FindByIdAsync(Id);
            string hashedNewPassword = _userManager.PasswordHasher.HashPassword(User, newPassword);
            User.PasswordHash = hashedNewPassword;
            _context.Update(User);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
