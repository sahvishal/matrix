using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class PayPeriodService : IPayPeriodService
    {
        private readonly IPayPeriodRepository _payPeriodRepository;
        private readonly IPayPeriodCriteriaRepository _payPeriodCriteriaRepository;
        private readonly IPayPeriodFactory _payPeriodFactory;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public PayPeriodService(IPayPeriodRepository payPeriodRepository, IPayPeriodCriteriaRepository payPeriodCriteriaRepository, IPayPeriodFactory payPeriodFactory, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _payPeriodRepository = payPeriodRepository;
            _payPeriodCriteriaRepository = payPeriodCriteriaRepository;
            _payPeriodFactory = payPeriodFactory;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }

        public PayPeriodListModel Get(PayPeriodFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var payPeriod = _payPeriodRepository.GetByFilter(filter, pageNumber, pageSize, out totalRecords);
            var payPeriodCritirieas = _payPeriodCriteriaRepository.GetByPayPeriodId(payPeriod.Select(x => x.Id).ToArray());
            var list = new List<long>();
            list.AddRange(payPeriod.Select(x => x.CreatedBy));
            list.AddRange(payPeriod.Where(x => x.ModifiedBy.HasValue).Select(x => x.ModifiedBy.Value));
            var userNamePair = _organizationRoleUserRepository.GetNameIdPairofUsers(list.ToArray());

            var listModel = new PayPeriodListModel();

            var collection = _payPeriodFactory.CreateViewModel(payPeriod, payPeriodCritirieas, userNamePair);

            collection = SetActivePayPeriod(collection);

            listModel.Collection = collection;
            listModel.Filter = filter;

            return listModel;
        }

        private IEnumerable<PayPeriodViewModel> SetActivePayPeriod(IEnumerable<PayPeriodViewModel> collection)
        {
            if (collection.IsNullOrEmpty()) return collection;

            var previousPublished = collection.Where(x => x.StartDate <= DateTime.Today && x.IsPublished).OrderByDescending(x => x.StartDate).FirstOrDefault();
            if (previousPublished != null)
            {
                foreach (var payPeriodViewModel in collection)
                {
                    if (payPeriodViewModel.StartDate == previousPublished.StartDate && payPeriodViewModel.IsPublished)
                        payPeriodViewModel.IsActive = true;
                }
            }

            return collection;
        }

        public PayPeriodEditModel GetEditModel(long payPeriodId)
        {
            if (payPeriodId < 1) return new PayPeriodEditModel();

            var payPeriod = _payPeriodRepository.GetById(payPeriodId);
            var payPeriodCriteria = _payPeriodCriteriaRepository.GetByPayPeriodId(payPeriodId);
            var editModel = _payPeriodFactory.CreateModel(payPeriod);

            if (!payPeriodCriteria.IsNullOrEmpty())
            {
                var list = new List<PayPeriodCriteriaEditModel>();
                var index = 0;
                foreach (var criteria in payPeriodCriteria)
                {
                    var criteriaEditModel = _payPeriodFactory.CreateCriteriaModel(criteria);
                    criteriaEditModel.Index = index++;
                    list.Add(criteriaEditModel);
                }

                editModel.Criteria = list;
            }

            return editModel;
        }

        public void Save(PayPeriodEditModel model, long orgRoleId)
        {
            if (model == null) return;

            PayPeriod payPeriodDomain = null;

            if (model.PayPeriodId > 0)
                payPeriodDomain = _payPeriodRepository.GetById(model.PayPeriodId);

            payPeriodDomain = _payPeriodFactory.CreateDomain(payPeriodDomain, model, orgRoleId);

            payPeriodDomain = _payPeriodRepository.Save(payPeriodDomain);

            var criteriaDomain = _payPeriodFactory.CreateCriteriaDomain(model.Criteria, payPeriodDomain.Id);

            _payPeriodCriteriaRepository.Save(criteriaDomain, payPeriodDomain.Id);

        }

        public bool Delete(long payPeriodId)
        {
            return _payPeriodRepository.DeletePayPeriod(payPeriodId);
        }
    }
}
