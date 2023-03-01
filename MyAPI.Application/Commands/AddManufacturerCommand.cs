using FluentResults;
using MediatR;

namespace MyAPI.Application.Commands
{
    public sealed class AddManufacturerCommand : IRequest<Result>
    {
        public string ManufacturerName { get; }
        public string CountryOfOrigin { get; }
        public int YearOfFounding { get; }

        public AddManufacturerCommand(string manufacturerName, string countryOfOrigin, int yearOfFounding)
        {
            ManufacturerName = manufacturerName;
            CountryOfOrigin = countryOfOrigin;
            YearOfFounding = yearOfFounding;
        }
    }
}
