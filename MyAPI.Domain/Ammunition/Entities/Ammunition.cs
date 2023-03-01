namespace MyAPI.Domain.Ammunition.Entities
{
    public sealed class Ammunition
    {
        public Guid Id { get; }
        public Guid CaliberId { get; set; }
        public Guid FirearmTypeId { get; set; }
        public int Count { get; set; }
    }
}
