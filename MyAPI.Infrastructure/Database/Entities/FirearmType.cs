namespace MyAPI.Infrastructure.Database.Entities
{
    public sealed class FirearmType
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
