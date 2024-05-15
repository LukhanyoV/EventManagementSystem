using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models.Entities
{
    public class EventList
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Guid EventId { get; set; }

        [ForeignKey("UserId")]
        public Event Event { get; set; }

        public int Amount { get; set; }
    }
}
