using Database.Country;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Database;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Geolocation
{
    public class GeolocationApplicationService : IGeolocationApplicationService
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryRepository _countryRepository;

        public GeolocationApplicationService(
            //IUnitOfWork unitOfWork,
            ICountryRepository userRepository)
        {
            //_unitOfWork = unitOfWork;
            _countryRepository = userRepository;
        }

        public async Task<IDataResult<IEnumerable<CountryModel>>> GetCountriesAsync()
        {
            var countries = await _countryRepository.ListAsync();
            return DataResult<IEnumerable<CountryModel>>.Success(countries
                .OrderBy(c => c.Country)
                .Select(c => new CountryModel
                {
                    Id = c.Id,
                    Country = c.Country,
                    CountryCode = c.CountryCode
                }));
        }
    }
}
