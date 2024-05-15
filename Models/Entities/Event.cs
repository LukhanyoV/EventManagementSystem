namespace EventManagementSystem.Models.Entities
{
    public class Event
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<EventList> EventLists { get; set; }
    }
}
