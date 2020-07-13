using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class PayPeriodFactory : IPayPeriodFactory
    {
        public PayPeriod CreateDomain(PayPeriod domain, PayPeriodEditModel model, long orgRoleId)
        {
            domain = domain ?? new PayPeriod();
            model.FromDate = model.FromDate.HasValue ? model.FromDate.Value : DateTime.Today;
            domain.IsPublished = model.IsPublished;
            domain.Name = model.FromDate.Value.ToShortDateString() + "_" + model.NumberOfWeek + " Weeks";
            domain.IsActive = true;

            domain.StartDate = model.FromDate.Value;

            domain.NumberOfWeeks = model.NumberOfWeek;
            domain.CreatedBy = domain.Id < 1 ? orgRoleId : domain.CreatedBy;
            domain.CreatedOn = domain.Id < 1 ? DateTime.Now : domain.CreatedOn;
            domain.ModifiedBy = domain.Id < 1 ? null : (long?)orgRoleId;
            domain.ModifiedOn = domain.Id < 1 ? null : (DateTime?)DateTime.Now;

            return domain;
        }

        public PayPeriodEditModel CreateModel(PayPeriod domain)
        {
            var model = new PayPeriodEditModel
            {
                PayPeriodId = domain.Id,
                Name = domain.Name,
                FromDate = domain.StartDate,
                NumberOfWeek = domain.NumberOfWeeks,
                IsActive = domain.IsActive,
                IsPublished = domain.IsPublished,

            };

            /*var numberOfDays = (domain.EndDate - domain.StartDate).TotalDays;

            model.NumberOfWeek = (int)(numberOfDays / 7);*/

            return model;
        }


        public IEnumerable<PayPeriodCriteria> CreateCriteriaDomain(IEnumerable<PayPeriodCriteriaEditModel> criterias, long payPeriodId)
        {
            var list = new List<PayPeriodCriteria>();

            foreach (var model in criterias)
            {
                list.Add(CreateCriteriaDomain(model, payPeriodId));
            }

            return list;
        }

        public PayPeriodCriteria CreateCriteriaDomain(PayPeriodCriteriaEditModel model, long payPeriodId)
        {
            return new PayPeriodCriteria
            {
                PayPeriodId = payPeriodId,
                MinCustomer = model.MinCustomer.HasValue ? model.MinCustomer.Value : 0,
                MaxCustomer = model.MaxCustomer,
                TypeId = model.TypeId,
                Ammount = model.Amount.HasValue ? model.Amount.Value : 0
            };
        }

        public PayPeriodCriteriaEditModel CreateCriteriaModel(PayPeriodCriteria domain)
        {
            return new PayPeriodCriteriaEditModel
            {
                PayPeriodId = domain.PayPeriodId,
                MinCustomer = domain.MinCustomer,
                MaxCustomer = domain.MaxCustomer,
                TypeId = domain.TypeId,
                Amount = domain.Ammount
            };
        }

        public IEnumerable<PayPeriodViewModel> CreateViewModel(IEnumerable<PayPeriod> payPeriod, IEnumerable<PayPeriodCriteria> payPeriodCriterias, IEnumerable<OrderedPair<long, string>> userOrderedPairs)
        {
            var list = new List<PayPeriodViewModel>();
            foreach (var period in payPeriod)
            {
                var createdBy = userOrderedPairs.First(x => x.FirstValue == period.CreatedBy);
                var modifiedBy = userOrderedPairs.FirstOrDefault(x => x.FirstValue == period.ModifiedBy);
                var criterias = payPeriodCriterias.Where(x => x.PayPeriodId == period.Id);

                var payPeriodView = new PayPeriodViewModel
                {
                    PayPerioidId = period.Id,
                    CreatedOn = period.CreatedOn,
                    ModifiedOn = period.ModifiedOn,
                    StartDate = period.StartDate,
                    NumberOfWeek = period.NumberOfWeeks,
                    IsPublished = period.IsPublished,
                    Createdby = createdBy.SecondValue,
                    Modifiedby = modifiedBy != null ? modifiedBy.SecondValue : string.Empty,
                    Name = period.Name,
                    Criteria = CreateViewModel(criterias)
                };

                list.Add(payPeriodView);
            }

            return list;
        }

        private IEnumerable<PayPeriodCriteriaViewModel> CreateViewModel(IEnumerable<PayPeriodCriteria> payPeriodCriterias)
        {
            return payPeriodCriterias.Select(x =>
                new PayPeriodCriteriaViewModel
                {
                    TypeId = x.TypeId,
                    MaxCustomer = x.MaxCustomer,
                    MinCustomer = x.MinCustomer,
                    Ammount = x.Ammount
                });
        }
    }
}