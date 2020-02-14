using Domain.Country;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Country
{
    public interface ICountryRepository : IRelationalRepository<CountryEntity>
    {
    }
}
