using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Geo;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Extensions;
using NUnit.Framework;
using Falcon.App.Infrastructure.Factories;
using System;

namespace Falcon.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class AddressFactoryTester
    {
        private readonly IAddressFactory _addressFactory = new AddressFactory();

        private static AddressViewRow GetValidAddressViewRow(string streetAddress1, string city,
            string country)
        {
            var addressView = new AddressViewTypedView();
            addressView.Rows.Add(1, streetAddress1, 3, 4, city, 6, 7,"PA" ,8, country);
            return (AddressViewRow)addressView.Rows[0];
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorThrowsExceptionWhenGivenNullRow()
        {
            _addressFactory.CreateAddress(null);
        }

        [Test]
        public void CreateMedicalVendorMapsAddressPropertiesCorrectly()
        {
            AddressViewRow addressViewRow = GetValidAddressViewRow("StreetAddress1", "City", "Country");

            Address address = _addressFactory.CreateAddress(addressViewRow);

            Assert.AreEqual(addressViewRow.Address1, address.StreetAddressLine1);
            Assert.AreEqual(addressViewRow.City, address.City);
            Assert.AreEqual(addressViewRow.Country, address.Country);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAddressesThrowsExceptionWhenGivenNullTypedView()
        {
            _addressFactory.CreateAddresses(null);
        }

        [Test]
        public void CreateAddressesReturnsEmptyListWhenGivenEmptyAddressCollection()
        {
            List<Address> addresses = _addressFactory.CreateAddresses(new AddressViewTypedView());

            Assert.IsNotNull(addresses);
            Assert.IsEmpty(addresses);
        }

        [Test]
        public void CreateAddressesReturnsSingleAddressWhenOneAddressIsInGivenCollection()
        {
            var addressViewTypedView = new AddressViewTypedView();
            addressViewTypedView.Rows.Add();

            List<Address> addresses = _addressFactory.CreateAddresses(addressViewTypedView);

            Assert.IsTrue(addresses.HasSingleItem());
        }

        [Test]
        public void CreateAddressesReturnsThreeAddressWhenThreeAddressRowsGiven()
        {
            var addressViewTypedView = new AddressViewTypedView();
            addressViewTypedView.Rows.Add();
            addressViewTypedView.Rows.Add();
            addressViewTypedView.Rows.Add();

            List<Address> addresses = _addressFactory.CreateAddresses(addressViewTypedView);

            Assert.AreEqual(addressViewTypedView.Rows.Count, addresses.Count);
        }
    }
}