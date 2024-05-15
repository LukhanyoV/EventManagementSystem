using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EventsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel viewModel)
        {
            var eventDetails = new Event {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                Date = viewModel.Date
            };

            await dbContext.Events.AddAsync(eventDetails);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var events = await dbContext.Events.ToListAsync();
            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var eventDetails = await dbContext.Events.FindAsync(id);

            return View(eventDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Event viewModel)
        {
            var eventDetails = await dbContext.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (eventDetails is not null)
            {
                dbContext.Events.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Events");
        }
    }
}
