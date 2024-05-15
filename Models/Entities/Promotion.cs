namespace EventManagementSystem.Models.Entities
{
    public class Promotion
    {
        public Guid Id { get; set; }

        public string? Code { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public DateTime Date { get; set; }
    }
}
