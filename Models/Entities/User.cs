namespace EventManagementSystem.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool isAdmin { get; set; } = false;

        public ICollection<Review> Reviews { get; set; }
        public ICollection<EventList> EventLists { get; set; }
    }
}
