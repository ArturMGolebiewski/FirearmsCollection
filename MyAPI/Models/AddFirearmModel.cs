namespace MyAPI.Models
{
    public sealed class AddFirearmModel
    {
        public Guid ManufacturerId { get; set; }
        public Guid FirearmTypeId { get; set; }
        public Guid CaliberId { get; set; }
        public string FirearmModelName { get; set; } = string.Empty;
    }
}
