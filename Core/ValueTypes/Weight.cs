using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.ValueTypes
{
    public class Weight
    {
        public const double Grams_into_Pounds = 453.592;
        public double Grams;
        [IgnoreAudit]
        public double Kilograms { get { return Grams / 1000; } }
        [IgnoreAudit]
        public double TotalOunces { get { return Math.Round(TotalPounds * 16, 4); } }
        [IgnoreAudit]
        public double TotalPounds { get { return Math.Round(Grams / Grams_into_Pounds, 4); } }

        private double _pounds;
        public double Pounds { get { return _pounds > 0 ? _pounds : (long)TotalPounds; } set { _pounds = value; } }
        public double Ounces { get { return TotalOunces % 16; } }
        [IgnoreAudit]
        public string MetricWeight { get { return Kilograms + " Kg"; } }
        [IgnoreAudit]
        public string EnglishWeight { get { return Pounds + " lb, " + Ounces + " oz"; } }

        public Weight() { }

        public Weight(double pounds)
        {
            _pounds = pounds;
            Grams = pounds * Grams_into_Pounds;
        }
    }
}