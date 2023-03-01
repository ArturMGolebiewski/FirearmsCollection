namespace MyAPI.Domain.Firearm.Entities
{
    public sealed class Firearm
    {
        public Guid Id { get; }
        public Guid ManufacturerId { get; set; }
        public Guid FirearmTypeId { get; set; }
        public Guid CaliberId { get; set; } 
        public string FirearmModelName { get; set; } = string.Empty;

        public Firearm()
        {
            Id = Guid.NewGuid();
        }
    }
}
