using EventManagementSystem.Data;
using EventManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AccountsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var _user = await dbContext.Users.AnyAsync(u => u.Email == user.Email);
            if (_user)
            {
                ViewBag.Error = "Email is already registered.";
                return View();
            }

            user.isAdmin = false;

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var _user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);

            if (_user == null)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }

            // Implement your authentication logic here, such as setting a cookie or session variable
            HttpContext.Session.SetString("UserId", _user.Id.ToString());

            return RedirectToAction("Index", "Home");
        }

    }
}
