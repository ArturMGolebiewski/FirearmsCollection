using MyAPI.Application.Queries;
using MyAPI.Domain.Manufacturer.Entities;

namespace MyAPI.Infrastructure
{
    public interface IFilter
    {
        ICollection<Manufacturer> FilterManufacturers(ICollection<Manufacturer> collection, FilterManufacturersQuery request);
    }
}