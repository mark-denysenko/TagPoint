using Domain.Country;
using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Country
{
    public class CountryRepository : EntityFrameworkCoreRelationalRepository<CountryEntity>, ICountryRepository
    {
        public CountryRepository(Context context) : base(context)
        {
        }
    }
}
