using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Should be replaced by special spatial data
    /// Microsoft.EntityFrameworkCore.SqlServer (PostgreSQL | InMemory)
    /// </summary>
    public class Coordinate : ValueObject
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        protected override IEnumerable<object> GetEquals()
        {
            throw new NotImplementedException();
        }
    }
}
