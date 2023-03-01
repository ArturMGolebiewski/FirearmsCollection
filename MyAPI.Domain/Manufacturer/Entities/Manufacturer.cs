namespace MyAPI.Domain.Manufacturer.Entities
{
    public sealed class Manufacturer
    {
        public Guid Id { get; }    
        public string ManufacturerName { get; set; } = string.Empty;
        public string CountryOfOrigin { get; set; } = string.Empty;
        public int YearOfFounding { get; set; }

        public Manufacturer()
        {
            Id = Guid.NewGuid();
        }
    }
}
