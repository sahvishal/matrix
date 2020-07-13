using Falcon.App.Core;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeTypeSafeEnum : TypeSafeEnum
    {
        public FakeTypeSafeEnum(string name) : base(name)
        {}
    }
}