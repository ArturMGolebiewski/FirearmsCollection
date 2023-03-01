namespace MyAPI.Models
{
    public sealed class AddCaliberModel
    {
        public Guid Id { get; set; }
        public string CaliberName { get; set; } = string.Empty;
    }
}
