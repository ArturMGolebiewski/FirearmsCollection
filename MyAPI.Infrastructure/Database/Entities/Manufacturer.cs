namespace MyAPI.Infrastructure.Database.Entities
{
    public sealed class Manufacturer
    {
        public Guid Id { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;
        public string CountryOfOrigin { get; set; } = string.Empty;
        public int YearOfFounding { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Firearm> Firearms { get; set; }
    }
}
