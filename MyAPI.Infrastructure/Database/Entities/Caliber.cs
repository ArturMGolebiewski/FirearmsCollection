namespace MyAPI.Infrastructure.Database.Entities
{
    public sealed class Caliber
    {
        public Guid Id { get; set; }
        public string CaliberName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
