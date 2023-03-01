namespace MyAPI.Infrastructure.Database.Entities
{
    public sealed class Firearm
    {
        public Guid Id { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid FirearmTypeId { get; set; }
        public Guid CaliberId { get; set; }
        public string FirearmModelName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public FirearmType FirearmType { get; set; }
        public Caliber Caliber { get; set; }

    }
}
