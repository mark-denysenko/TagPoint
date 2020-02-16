using Domain.Country;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Database.Country
{
    internal static class ContextCountrySeed
    {
        public static void SeedCountries(this ModelBuilder builder)
        {
            builder.Entity<CountryEntity>(x =>
            {
                x.HasData(GetCountryList());
            });
        }

        private static IEnumerable<CountryEntity> GetCountryList()
        {
            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            int id = 1;
            var countriesList = new List<CountryEntity>(200);
            foreach(var culture in cultureInfos)
            {
                RegionInfo regionInfo = new RegionInfo(culture.LCID);
                if (countriesList.All(country => country.Country != regionInfo.DisplayName))
                {
                    countriesList.Add(new CountryEntity
                    {
                        Id = id++,
                        Country = regionInfo.DisplayName
                    });
                }
            }

            return countriesList;
        }
    }
}
