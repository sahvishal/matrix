using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors.ViewData;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class MedicalVendorMedicalVendorUserAggregateFactory : IMedicalVendorMedicalVendorUserAggregateFactory
    {
        public List<MedicalVendorMedicalVendorUserAggregate> CreateMedicalVendorMedicalVendorUserAggregates
            (List<MedicalVendorMedicalVendorUser> medicalVendorMedicalVendorUsers, 
            MedicalVendorMvuserEarningAndPayRateTypedView medicalVendorMedicalVendorUserEarningAndPayRateView, 
            MedicalVendorMvuserPaymentTypedView medicalVendorMedicalVendorUserPaymentView)
        {
            if (medicalVendorMedicalVendorUsers == null)
            {
                throw new ArgumentNullException("medicalVendorMedicalVendorUsers");
            }
            if (medicalVendorMedicalVendorUserEarningAndPayRateView == null)
            {
                throw new ArgumentNullException("medicalVendorMedicalVendorUserEarningAndPayRateView");
            }
            if (medicalVendorMedicalVendorUserPaymentView == null)
            {
                throw new ArgumentNullException("medicalVendorMedicalVendorUserPaymentView");
            }
            var medicalVendorMedicalVendorUserAggregates = new List<MedicalVendorMedicalVendorUserAggregate>();
            foreach (var medicalVendorMedicalVendorUser in medicalVendorMedicalVendorUsers)
            {
                MedicalVendorMedicalVendorUserAggregate medicalVendorMedicalVendorUserAggregate = 
                    CreateMedicalVendorMedicalVendorUserAggregate(medicalVendorMedicalVendorUser, 
                    medicalVendorMedicalVendorUserEarningAndPayRateView, medicalVendorMedicalVendorUserPaymentView);
                medicalVendorMedicalVendorUserAggregates.Add(medicalVendorMedicalVendorUserAggregate);
            }
            return medicalVendorMedicalVendorUserAggregates;
        }

        public MedicalVendorMedicalVendorUserAggregate CreateMedicalVendorMedicalVendorUserAggregate
            (MedicalVendorMedicalVendorUser medicalVendorMedicalVendorUser, 
            MedicalVendorMvuserEarningAndPayRateTypedView medicalVendorMedicalVendorUserEarningAndPayRateView, 
            MedicalVendorMvuserPaymentTypedView medicalVendorMedicalVendorUserPaymentView)
        {
            if (medicalVendorMedicalVendorUser == null)
            {
                throw new ArgumentNullException("medicalVendorMedicalVendorUser");
            }
            if (medicalVendorMedicalVendorUserEarningAndPayRateView == null)
            {
                throw new ArgumentNullException("medicalVendorMedicalVendorUserEarningAndPayRateView");
            }
            if (medicalVendorMedicalVendorUserPaymentView == null)
            {
                throw new ArgumentNullException("medicalVendorMedicalVendorUserPaymentView");
            }
            int numberOfEvaluations = 0;
            decimal payRate = 0m;
            decimal totalEarnings = 0m;
            decimal totalPayments = 0m;
            if (medicalVendorMedicalVendorUserEarningAndPayRateView.Where(m =>
                    m.OrganizationRoleUserId == medicalVendorMedicalVendorUser.Id).Count() > 0)
            {
                MedicalVendorMvuserEarningAndPayRateRow medicalVendorMVUserEarningAndPayRateRow =
                    medicalVendorMedicalVendorUserEarningAndPayRateView.Where(m =>
                    m.OrganizationRoleUserId == medicalVendorMedicalVendorUser.Id).Single();
                    
                numberOfEvaluations = medicalVendorMVUserEarningAndPayRateRow.NumberOfEvaluations;
                payRate = medicalVendorMVUserEarningAndPayRateRow.OfferRate;
                totalEarnings = medicalVendorMVUserEarningAndPayRateRow.AmountEarned;
            }
            if (medicalVendorMedicalVendorUserPaymentView.Where(m =>
                    m.OrganizationRoleUserId == medicalVendorMedicalVendorUser.Id).Count() > 0)
            {
                MedicalVendorMvuserPaymentRow medicalVendorMVUserPaymentRow = medicalVendorMedicalVendorUserPaymentView.
                    Where(m => m.OrganizationRoleUserId== medicalVendorMedicalVendorUser.Id).Single();
                totalPayments = medicalVendorMVUserPaymentRow.AmountPaid;
            }
            return new MedicalVendorMedicalVendorUserAggregate
            {
                MedicalVendorMedicalVendorUser = medicalVendorMedicalVendorUser,
                NumberOfEvaluations = numberOfEvaluations,
                PayRate = payRate,
                TotalEarnings = totalEarnings,
                TotalPayments = totalPayments,
            };
        }
    }
}