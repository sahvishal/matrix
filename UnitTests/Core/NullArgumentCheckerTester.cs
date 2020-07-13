using System;
using Falcon.App.Core;
using NUnit.Framework;

namespace Falcon.UnitTests.Core
{
    [TestFixture]
    public class NullArgumentCheckerTester
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckIfNullThrowsExceptionWhenGivenObjectIsNull()
        {
            NullArgumentChecker.CheckIfNull(null, "Object");
        }

        [Test]
        public void CheckIfNullTakesNoActionWhenGivenNonNullObject()
        {
            NullArgumentChecker.CheckIfNull(string.Empty, "String");
        }
    }
}