using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialRatingMVC.Data;
using SocialRatingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialRatingMVC.Controllers
{
    public class ReactionsController : Controller
    {
        private readonly SocialDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        public ReactionsController(SocialDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var reactions = _context.Reactions.Where(c => c.ToUserId == userId).ToList();
            ViewData["reactions"] = reactions;
            return View();
        }
    }
}
