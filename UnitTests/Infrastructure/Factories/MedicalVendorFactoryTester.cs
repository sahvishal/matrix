using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Factories;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class MedicalVendorFactoryTester
    {
        //private MockRepository _mocks;
        //private IAddressFactory _addressFactory;
        private IMedicalVendorFactory _medicalVendorFactory;

        [SetUp]
        public void Setup()
        {
            DependencyRegistrar.RegisterDependencies();
            
        }

        [TearDown]
        public void TearDown()
        {
            //_mocks = null;
            _medicalVendorFactory = null;
        }

        private static AddressViewTypedView GetValidAddressView()
        {
            var addressView = new AddressViewTypedView();
            addressView.Rows.Add();
            return addressView;
        }

        private static AddressViewRow GetValidAddressViewRow()
        {
            return (AddressViewRow)GetValidAddressView().Rows[0];
        }

        [Test]
        public void CreateMedicalVendor_ReturnsAvaildDomainObject()
        {

            _medicalVendorFactory = IoC.Resolve<IMedicalVendorFactory>();
            var medicalVendorProfile = new MedicalVendorProfileEntity
            {
                ContractId = 2,
                TypeId = 1,
                IsHospitalPartner = false,
                Organization = new OrganizationEntity{Name = "Medical Vendor One",}
            };

            var actualMedicalVendor = _medicalVendorFactory.CreateMedicalVendor(medicalVendorProfile);

            Assert.AreEqual("Medical Vendor One", actualMedicalVendor.Name);
        }

       

      
    }
}