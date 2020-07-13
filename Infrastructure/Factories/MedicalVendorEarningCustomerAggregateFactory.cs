using System;
using System.Collections.Generic;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class MedicalVendorEarningCustomerAggregateFactory : IMedicalVendorEarningCustomerAggregateFactory
    {
        public List<MedicalVendorEarningCustomerAggregate> CreateMedicalVendorEarningAggregates(MedicalVendorEarningCustomerTypedView 
            medicalVendorEarningCustomerTypedView)
        {
            if (medicalVendorEarningCustomerTypedView == null)
            {
                throw new ArgumentNullException("medicalVendorEarningCustomerTypedView");
            }
            var medicalVendorEarningCustomerAggregates = new List<MedicalVendorEarningCustomerAggregate>();
            foreach (var medicalVendorEarningCustomerRow in medicalVendorEarningCustomerTypedView)
            {
                medicalVendorEarningCustomerAggregates.Add(CreateMedicalVendorEarningAggregate(medicalVendorEarningCustomerRow));
            }
            return medicalVendorEarningCustomerAggregates;
        }

        public MedicalVendorEarningCustomerAggregate CreateMedicalVendorEarningAggregate(MedicalVendorEarningCustomerRow 
            medicalVendorEarningCustomerRow)
        {
            if (medicalVendorEarningCustomerRow == null)
            {
                throw new ArgumentNullException("medicalVendorEarningCustomerRow");
            }

            IEventCustomerPackageTestDetailService packageTestDetailService = new EventCustomerPackageTestDetailService();

            return new MedicalVendorEarningCustomerAggregate
            {
                AmountEarned = medicalVendorEarningCustomerRow.MvamountEarned,
                CustomerId = medicalVendorEarningCustomerRow.CustomerId,
                CustomerName = new Name(medicalVendorEarningCustomerRow.CustomerFirstName,
                    medicalVendorEarningCustomerRow.CustomerMiddleName, medicalVendorEarningCustomerRow.CustomerLastName),
                EvaluationDate = medicalVendorEarningCustomerRow.EvaluationDate,
                MedicalVendorId = medicalVendorEarningCustomerRow.OrganizationId,
                OrganizationRoleUserId = medicalVendorEarningCustomerRow.OrganizationRoleUserId,
                PackageName = packageTestDetailService.GetOrderPurchasedString(medicalVendorEarningCustomerRow.EventId, medicalVendorEarningCustomerRow.CustomerId), 
                PhysicianName = new Name(medicalVendorEarningCustomerRow.PhysicianFirstName,
                    medicalVendorEarningCustomerRow.PhysicianMiddleName, medicalVendorEarningCustomerRow.PhysicianLastName),
            };
        }
    }
}