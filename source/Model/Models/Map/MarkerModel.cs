using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Map
{
    public class MarkerModel
    {
        public long? Id { get; set; }
        public double Altitude { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
