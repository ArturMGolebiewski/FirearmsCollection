namespace MyAPI.Domain.Caliber.Entities
{
    public sealed class Caliber
    {
        public Guid Id { get; }
        public string CaliberName { get; set; } = string.Empty;

        public Caliber()
        {
            Id = Guid.NewGuid();
        }
    }
}
