using EventManagementSystem.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class ReviewViewModel
    {
        public Guid EventId { get; set; }

        public string UserName { get; set; }

        public string EventName { get; set; }

        public int Rating { get; set; }

        public string? Message { get; set; }
    }
}
