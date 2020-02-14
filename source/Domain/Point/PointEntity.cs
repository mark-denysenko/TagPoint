using Domain.ValueObjects;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Point
{
    public class PointEntity
    {
        public long Id { get; set; }

        public Coordinate Coordinate { get; set; }

        public UserEntity User { get; set; }
    }
}
