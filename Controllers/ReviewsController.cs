using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ReviewsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            var eventDetails = await dbContext.Events.FindAsync(id);

            var eventModelReview = new ReviewViewModel();
            if (eventDetails != null)
            {
                eventModelReview.EventId = eventDetails.Id;
                eventModelReview.EventName = eventDetails.Name;
            }

            return View(eventModelReview);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewViewModel viewModel)
        {
            var idString = HttpContext.Session.GetString("UserId");

            if (!Guid.TryParse(idString, out Guid id))
            {
                // Handle the case where the session value is not a valid Guid
                // For example, redirect to an error page or display an error message
            }

            var reviewDetails = new Review
            {
                EventId = viewModel.EventId,
                UserId = id,
                Message = viewModel.Message,
                Rating = viewModel.Rating,
            };

            await dbContext.Reviews.AddAsync(reviewDetails);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Events");
        }

        [HttpGet]
        public async Task<IActionResult> List(Guid id)
        {
            var reviews = await dbContext.Reviews
                .Include(r => r.User)
                .Include(r => r.Event)
                .Where(r => r.EventId == id)
                .Select(r => new ReviewViewModel
                {
                    EventId = r.EventId,
                    UserName = r.User.Name,
                    EventName = r.Event.Name,
                    Rating = r.Rating,
                    Message = r.Message
                })
                .ToListAsync();
            return View(reviews);
        }
    }
}
