using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models.Entities
{
    public class Review
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Guid EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        public int Rating { get; set; }

        public string? Message { get; set; }
    }
}
