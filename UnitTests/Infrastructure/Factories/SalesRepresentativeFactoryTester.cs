using System;
using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.Users;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class SalesRepresentativeFactoryTester
    {
        private readonly ISalesRepresentativeFactory _salesRepresentativeFactory = new SalesRepresentativeFactory();

        private static FranchiseeFranchiseeUserViewRow GetValidFranchiseeFranchiseeViewRow(long franchiseeFranchiseeUserId, 
            long franchiseeId)
        {
            var view = new FranchiseeFranchiseeUserViewTypedView();
            view.Rows.Add(franchiseeFranchiseeUserId, 0, franchiseeId);
            return (FranchiseeFranchiseeUserViewRow)view.Rows[0];
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSalesRepresentativeThrowsExceptionWhenGivenNullRow()
        {
            _salesRepresentativeFactory.CreateSalesRepresentative(null, new User());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSalesRepresentativeThrowsExceptionWhenGivenNullUser()
        {
            FranchiseeFranchiseeUserViewRow row = GetValidFranchiseeFranchiseeViewRow(0, 0);
            _salesRepresentativeFactory.CreateSalesRepresentative(row, null);
        }

        [Test]
        public void CreateSalesRepresentativeMapsFranchiseeFranchiseeUserIdToSalesRepId()
        {
            const long expectedSalesRepId = 24;
            FranchiseeFranchiseeUserViewRow row = GetValidFranchiseeFranchiseeViewRow(expectedSalesRepId, 0);

            SalesRepresentative salesRepresentative = _salesRepresentativeFactory.CreateSalesRepresentative(row, new User());

            Assert.AreEqual(expectedSalesRepId, salesRepresentative.SalesRepresentativeId);
        }

        [Test]
        public void CreateSalesRepresentativeMapsRowFranchiseeIdToFranchiseeId()
        {
            const long expectedFranchiseeId = 24;
            FranchiseeFranchiseeUserViewRow row = GetValidFranchiseeFranchiseeViewRow(0, expectedFranchiseeId);

            SalesRepresentative salesRepresentative = _salesRepresentativeFactory.CreateSalesRepresentative(row, new User());

            Assert.AreEqual(expectedFranchiseeId, salesRepresentative.FranchiseeId);
        }

        [Test]
        public void CreateSalesRepresentativeSetsFullNameToUserFullName()
        {
            const string firstName = "Bob";
            const string lastName = "Cindy";
            var expectedName = new Name(firstName, string.Empty, lastName);
            var user = new User { Name = expectedName };
            FranchiseeFranchiseeUserViewRow row = GetValidFranchiseeFranchiseeViewRow(0, 0);
            
            SalesRepresentative salesRepresentative = _salesRepresentativeFactory.CreateSalesRepresentative(row, user);

            Assert.AreEqual(expectedName, salesRepresentative.Name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSalesRepresentativesThrowsExceptionWhenGivenNullTypedView()
        {
            _salesRepresentativeFactory.CreateSalesRepresentatives(null, new List<User>());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSalesRepresentativesThrowsExceptionWhenGivenNullUserList()
        {
            _salesRepresentativeFactory.CreateSalesRepresentatives(new FranchiseeFranchiseeUserViewTypedView(), null);
        }

        [Test]
        [Ignore]      
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateSalesRepresentativesThrowsExceptionWhenNotGivenUserForAGivenViewRow()
        {
            var view = new FranchiseeFranchiseeUserViewTypedView();
            view.Rows.Add();
            _salesRepresentativeFactory.CreateSalesRepresentatives(view, new List<User>());
        }

        [Test]
        public void CreateSalesRepresentativesReturnsEmptyListWhenEmptyTypedViewGiven()
        {
            List<SalesRepresentative> salesRepresentatives = _salesRepresentativeFactory.CreateSalesRepresentatives
                (new FranchiseeFranchiseeUserViewTypedView(), new List<User>());

            Assert.IsNotNull(salesRepresentatives);
            Assert.IsEmpty(salesRepresentatives);
        }

        [Test]
        public void CreateSalesRepresentativesReturnsOneSalesRepWhenOneSalesRepRowGiven()
        {
            const long expectedUserId = 3;
            var view = new FranchiseeFranchiseeUserViewTypedView();
            view.Rows.Add(0, expectedUserId);
            var users = new List<User> {new User(expectedUserId)};

            List<SalesRepresentative> salesRepresentatives = _salesRepresentativeFactory.CreateSalesRepresentatives
                (view, users);

            Assert.IsTrue(salesRepresentatives.HasSingleItem());
        }

        [Test]
        public void CreateSalesRepresentativesReturnsThreeSalesRepsWhenThreeSalesRepRowsGiven()
        {
            const long expectedUserId = 3;
            var view = new FranchiseeFranchiseeUserViewTypedView();
            view.Rows.Add(0, expectedUserId);
            view.Rows.Add(0, expectedUserId);
            view.Rows.Add(0, expectedUserId);
            var users = new List<User> { new User(expectedUserId) };

            List<SalesRepresentative> salesRepresentatives = _salesRepresentativeFactory.CreateSalesRepresentatives
                (view, users);

            Assert.AreEqual(view.Rows.Count, salesRepresentatives.Count);
        }

        [Test]
        public void CreateSalesRepresentativeMapsGivenUserIdToSalesRepUserId()
        {
            const long expectedUserId = 3;
            
            SalesRepresentative salesRepresentative = _salesRepresentativeFactory.
                CreateSalesRepresentative(GetValidFranchiseeFranchiseeViewRow(1, 2), new User(expectedUserId));

            Assert.AreEqual(expectedUserId, salesRepresentative.Id);
        }
    }
}