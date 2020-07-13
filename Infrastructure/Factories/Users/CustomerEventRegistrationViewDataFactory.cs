using System.Linq;
using System.Collections.Generic;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Factories.Events;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Factories.Users
{
    public class CustomerEventRegistrationViewDataFactory : ICustomerEventRegistrationViewDataFactory
    {
         private readonly IEventCustomerViewDataFactory _eventCustomerViewDataFactory;

        public CustomerEventRegistrationViewDataFactory()
            : this(new EventCustomerViewDataFactory())
        { }

        public CustomerEventRegistrationViewDataFactory(IEventCustomerViewDataFactory eventCustomerViewDataFactory)
        {
            _eventCustomerViewDataFactory = eventCustomerViewDataFactory;
        }

        public List<CustomerEventRegistrationViewData> Create(CustomerOrderBasicInfoTypedView customerOrderBasicInfoTypedView)
        {
            var customerEventRegistrationViewData = new List<CustomerEventRegistrationViewData>();

            foreach (var orderBasicInfoTypedView in customerOrderBasicInfoTypedView)
            {
                var customerEventRegistrationViewDatum = new CustomerEventRegistrationViewData();

                _eventCustomerViewDataFactory.Create(customerEventRegistrationViewDatum, orderBasicInfoTypedView);

                //customerEventRegistrationViewDatum.AAATestEvaluationState =
                //    (TestResultStateNumber) orderBasicInfoTypedView.AaatestEvaluation;
                //customerEventRegistrationViewDatum.ASITestEvaluationState =
                //    (TestResultStateNumber) orderBasicInfoTypedView.AsitestEvaluation;
                //customerEventRegistrationViewDatum.CarotidTestEvaluationState =
                //    (TestResultStateNumber) orderBasicInfoTypedView.CarotidTestEvaluation;
                //customerEventRegistrationViewDatum.EKGTestEvaluationState =
                //    (TestResultStateNumber) orderBasicInfoTypedView.EkgtestEvaluation;
                //customerEventRegistrationViewDatum.FraminghamTestEvaluationState =
                //    (TestResultStateNumber) orderBasicInfoTypedView.FraminghamTestEvaluation;
                //customerEventRegistrationViewDatum.LipidTestEvaluationState =
                //    (TestResultStateNumber)orderBasicInfoTypedView.LipidTestEvaluation;
                //customerEventRegistrationViewDatum.LiverTestEvaluationState =
                //    (TestResultStateNumber)orderBasicInfoTypedView.LiverTestEvaluation;
                //customerEventRegistrationViewDatum.OsteoTestEvaluationState =
                //    (TestResultStateNumber)orderBasicInfoTypedView.OsteoTestEvaluation;
                //customerEventRegistrationViewDatum.PADTestEvaluationState =
                //    (TestResultStateNumber)orderBasicInfoTypedView.PadtestEvaluation;

                customerEventRegistrationViewDatum.FranchiseeName = orderBasicInfoTypedView.FranchiseeName;
                customerEventRegistrationViewDatum.HostOrganizationName = orderBasicInfoTypedView.OrganizationName;
                //customerEventRegistrationViewDatum.IsAAAPartial = orderBasicInfoTypedView.AaapartialState;
                //customerEventRegistrationViewDatum.IsASIPartial = orderBasicInfoTypedView.AsipartialState;
                //customerEventRegistrationViewDatum.IsCarotidPartial = orderBasicInfoTypedView.CarotidPartialState;
                //customerEventRegistrationViewDatum.IsEKGPartial = orderBasicInfoTypedView.EkgpartialState;
                //customerEventRegistrationViewDatum.IsFraminghamPartial = orderBasicInfoTypedView.FraminghamPartialState;
                //customerEventRegistrationViewDatum.IsLipidPartial = orderBasicInfoTypedView.LipidPartialState;
                //customerEventRegistrationViewDatum.IsLiverPartial = orderBasicInfoTypedView.LiverPartialState;
                //customerEventRegistrationViewDatum.IsOsteoPartial = orderBasicInfoTypedView.OsteoPartialState;
                //customerEventRegistrationViewDatum.IsPADPartial = orderBasicInfoTypedView.PadpartialState;
                

                customerEventRegistrationViewData.Add(customerEventRegistrationViewDatum);
            }
            return customerEventRegistrationViewData.OrderByDescending(cerv => cerv.EventSignupDate).ToList();
        }
    }
}