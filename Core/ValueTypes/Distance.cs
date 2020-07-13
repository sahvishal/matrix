using System;

namespace Falcon.App.Core.ValueTypes
{
    public class Distance : Length
    {
        private const double KILOMETERS_IN_MILES = 1.6;

        public double Miles { get; set; }

        public double KiloMeters
        {
            get
            {
                return Math.Round(Miles * KILOMETERS_IN_MILES, 2);
            }
        }
        public Distance(double miles)
        {
            Miles = miles;
        }
    }
}
