using DotNetCore.Objects;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Geolocation
{
    public interface IGeolocationApplicationService
    {
        Task<IDataResult<IEnumerable<CountryModel>>> GetCountriesAsync();
    }
}
