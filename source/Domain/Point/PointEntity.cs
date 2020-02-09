using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Point
{
    public class PointEntity
    {
        public long Id { get; set; }

        public Coordinate Coordinate { get; set; }
    }
}
