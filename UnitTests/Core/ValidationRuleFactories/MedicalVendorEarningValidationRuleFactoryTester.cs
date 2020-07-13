using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Impl;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Core.ValidationRuleFactories
{
    [TestFixture]
    public class MedicalVendorEarningValidationRuleFactoryTester
    {
        private readonly IValidator<MedicalVendorEarning> _validator = 
            new Validator<MedicalVendorEarning>(new MedicalVendorEarningValidationRuleFactory());
        private MedicalVendorEarning _medicalVendorEarning;

        private static MedicalVendorEarning GetValidMedicalVendorEarning()
        {
            return new MedicalVendorEarning
            {
                OrganizationRoleUserId = 1,
                MedicalVendorUserEventTestLockId = 1,
                MedicalVendorUserAmountEarned = 56.22m,
                DataRecorderMetaData = new DataRecorderMetaData(),
            };
        }

        [SetUp]
        public void SetUp()
        {
            _medicalVendorEarning = GetValidMedicalVendorEarning();
        }

        [TearDown]
        public void TearDown()
        {
            _medicalVendorEarning = null;
        }

        [Test]
        public void IsValidReturnsFalseWhenOrganizationRoleUserIdIsZero()
        {
            _medicalVendorEarning.OrganizationRoleUserId = 0;

            bool isValid = _validator.IsValid(_medicalVendorEarning);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenOrganizationRoleUserIdIsLessThanZero()
        {
            for (int i = -1; i >= -5; i--)
            {
                _medicalVendorEarning.OrganizationRoleUserId = i;
                bool isValid = _validator.IsValid(_medicalVendorEarning);
                Assert.IsFalse(isValid, string.Format("{0} returned true.", i));
            }
        }

        [Test]
        public void IsValidReturnsTrueWhenOrganizationRoleUserIdIsGreaterThanZero()
        {
            for (int i = 1; i <= 10; i++)
            {
                _medicalVendorEarning.OrganizationRoleUserId = i;
                Assert.IsTrue(_validator.IsValid(_medicalVendorEarning), string.Format("{0} returned false.", i));
            }
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorUserEventTestLockIdIsZero()
        {
            _medicalVendorEarning.MedicalVendorUserEventTestLockId = 0;

            bool isValid = _validator.IsValid(_medicalVendorEarning);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorUserEventTestLockIdIsLessThanZero()
        {
            for (int i = -1; i >= -5; i--)
            {
                _medicalVendorEarning.MedicalVendorUserEventTestLockId = i;
                Assert.IsFalse(_validator.IsValid(_medicalVendorEarning), string.Format("{0} returned true.", i));
            }
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorUserEventTestLockIdIsGreaterThanZero()
        {
            for (int i = 1; i <= 10; i++)
            {
                _medicalVendorEarning.MedicalVendorUserEventTestLockId = i;
                Assert.IsTrue(_validator.IsValid(_medicalVendorEarning), string.Format("{0} returned false.", i));
            }
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorUserAmountEarnedIsZero()
        {
            _medicalVendorEarning.MedicalVendorUserAmountEarned = 0m;

            bool isValid = _validator.IsValid(_medicalVendorEarning);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorUserAmountEarnedIsLessThanZero()
        {
            for (decimal i = -1m; i >= -5m; i--)
            {
                _medicalVendorEarning.MedicalVendorUserAmountEarned = i;
                Assert.IsFalse(_validator.IsValid(_medicalVendorEarning), string.Format("{0:c} returned true.", i));
            }
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorUserAmountEarnedIsLessThan100()
        {
            for (decimal i = .01m; i < 100.00m; i+= .01m)
            {
                _medicalVendorEarning.MedicalVendorUserAmountEarned = i;
                Assert.IsTrue(_validator.IsValid(_medicalVendorEarning), string.Format("{0:c} returned false.", i));
            }
        }

        [Test]
        public void IsValidReturnsTrueWhenMedicalVendorUserAmoutnEarnedIsEqualTo100()
        {
            _medicalVendorEarning.MedicalVendorUserAmountEarned = 100m;
            
            bool isValid = _validator.IsValid(_medicalVendorEarning);
            
            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenMedicalVendorUserAmountEarnedIsGreaterThan100()
        {
            for (decimal i = 100.01m; i <= 110m; i += 1m)
            {
                _medicalVendorEarning.MedicalVendorUserAmountEarned = i;
                Assert.IsFalse(_validator.IsValid(_medicalVendorEarning), string.Format("{0:c} returned true.", i));
            }
        }

        [Test]
        public void IsValidReturnsFalseWhenDataRecorderMetaDataIsNull()
        {
            _medicalVendorEarning.DataRecorderMetaData = null;
            Assert.IsFalse(_validator.IsValid(_medicalVendorEarning));
        }

        [Test]
        public void IsValidReturnsTrueWhenDataRecorderMetaDataIsNotNull()
        {
            _medicalVendorEarning.DataRecorderMetaData = new DataRecorderMetaData();
            Assert.IsTrue(_validator.IsValid(_medicalVendorEarning));
        }
    }
}