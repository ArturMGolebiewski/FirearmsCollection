namespace MyAPI.Infrastructure.Database.Entities
{
    public sealed class Ammunition
    {
        public Guid Id { get; set; }
        public Guid CaliberId { get; set; }
        public Guid FirearmTypeId { get; set; }
        public int Count { get; set; } = 0;
        public DateTime CreatedAt { get; set; }

        public Caliber Caliber { get; set; }
        public FirearmType FirearmType { get; set; }
    }
}
