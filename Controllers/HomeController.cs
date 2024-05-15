using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var idString = HttpContext.Session.GetString("UserId");

            if (!Guid.TryParse(idString, out Guid id))
            {
                // Handle the case where the session value is not a valid Guid
                // For example, redirect to an error page or display an error message
            }

            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                // Handle the case where the user with the specified ID is not found
                // For example, redirect to an error page or display an error message
            }

            return View(user);

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
