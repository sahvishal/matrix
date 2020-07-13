using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.ValueTypes
{
    public class Length
    {
        public const double CENTIMETERS_IN_AN_INCH = 2.54;

        public double Centimeters;

        public Length() { }

        public Length(double feet, double inches)
        {
            _totalInches = inches + (feet * 12);
            Centimeters = _totalInches * CENTIMETERS_IN_AN_INCH;
        }

        public Length(double inches)
        {
            Centimeters = inches * CENTIMETERS_IN_AN_INCH;
        }

        public Length LengthFromCentimeters(double centimeters)
        {
            return new Length { Centimeters = centimeters };
        }
        [IgnoreAudit]
        public double Meters { get { return Math.Round(Centimeters / 100, 4); } }

        private double _totalInches;
        [IgnoreAudit]
        public double TotalInches
        {
            get
            {
                if (_totalInches < 1) return Centimeters / CENTIMETERS_IN_AN_INCH;
                return _totalInches;
            }
            set { _totalInches = value; }
        }
        [IgnoreAudit]
        public double TotalFeet { get { return Math.Round(TotalInches / 12, 4); } }
        public double Feet { get { return (long)TotalFeet; } }
        public double Inches { get { return (long)Math.Round(TotalInches % 12); } }
    }
}