using Domain.Country;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Country
{
    internal static class ContextCountrySeed
    {
        public static void SeedCountries(this ModelBuilder builder)
        {
            builder.Entity<CountryEntity>(x =>
            {
                x.HasData(new
                {
                    Id = 1,
                    Country = "Україна",
                    CountryCode = "UA"
                });
            });
        }
    }
}
