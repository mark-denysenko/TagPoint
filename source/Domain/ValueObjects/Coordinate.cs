using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Coordinate : ValueObject
    {
        public double Altitude { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        protected override IEnumerable<object> GetEquals()
        {
            throw new NotImplementedException();
        }
    }
}
