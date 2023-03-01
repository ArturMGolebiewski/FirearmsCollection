namespace MyAPI.Models
{
    public class AddManufacturerModel
    {
        public string ManufacturerName { get; set; } = string.Empty;
        public string CountryOfOrigin { get; set; } = string.Empty;
        public int YearOfFounding{ get; set; }
    }
}
