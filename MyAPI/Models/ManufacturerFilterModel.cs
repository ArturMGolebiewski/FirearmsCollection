using MyAPI.Application.Queries;

namespace MyAPI.Models
{
    public sealed class ManufacturerFilterModel
    {
        public string PropertyName { get; set; } = string.Empty;    
        public string PropertyValue { get; set; } = string.Empty;

        public FilterManufacturersQuery ToQuery()
        {
            var query = new FilterManufacturersQuery
            {
                PropertyName = PropertyName,
                PropertyValue = PropertyValue,
            };

            return query;
        }
    }
}