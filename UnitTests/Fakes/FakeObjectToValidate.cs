using System;
using System.Collections.Generic;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeObjectToValidate
    {
        public List<string> ListOfStrings { get; set; }
        public FakeEnum FakeEnum { get; set; }
        public DateTime? NullableDateTime { get; set; }
        public Guid Guid { get; set; }
        public int Integer { get; set; }
        public long Long { get; set; }
        public decimal Decimal { get; set; }

        public FakeObjectToValidate()
        {
            ListOfStrings = new List<string>();
        }
    }
}