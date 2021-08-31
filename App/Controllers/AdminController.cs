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
        }
        public bool UrlProtection()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return true;
            }
            return false;
        }
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            ViewBag.Users = users;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string Id, string newPassword)
        {
            Task<IdentityUser> User = _userManager.FindByIdAsync(Id);
            string hashedNewPassword = _userManager.PasswordHasher.HashPassword(await User,newPassword);

            _context.Users.Update(await User);
            return View();
        }
    }
}
