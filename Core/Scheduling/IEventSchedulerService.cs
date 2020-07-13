using System.Collections.Generic;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventSchedulerService
    {
        OnlineSchedulingProcessAndCartViewModel GetOnlineCart(string guid);
        OnlineSchedulingProcessAndCartViewModel GetOnlineCart(TempCart tempCart);

        SourceCodeApplyEditModel ApplySourceCode(SourceCodeApplyEditModel model);
        SourceCodeApplyEditModel GetSourceCodeApplied(TempCart tempCart, SourceCodeApplyEditModel sourceCodeModel = null);

        EventCustomerOrderSummaryModel GetEventCustomerOrderSummaryModel(string cartGuid);
        EventCustomerOrderSummaryModel GetEventCustomerOrderSummaryModel(TempCart tempCart, SourceCodeApplyEditModel sourceCodeModel = null);
        EventCustomerOrderSummaryModel GetEventCustomerOrderSummaryModel(TempCart tempCart, OrderPlaceEditModel orderPlaceEditModel, SourceCodeApplyEditModel sourceCodeModel);

        void CreateOrder(TempCart tempCart, PaymentEditModel paymentEditModel = null);

        SourceCodeApplyEditModel ApplySourceCode(long packageId, IEnumerable<long> addOnTestIds, decimal orderTotal,
                                                 string sourceCode, long eventId, long customerId, SignUpMode signUpMode,
                                                 decimal shippingAmount = 0, decimal productAmount = 0);

        OrderedPair<bool, string> DoesEventCustomerAlreadyExists(long customerId, long eventId);

        AppointmentSelectionEditModel GetAppointmentmentSelectionEditModel(TempCart tempcart);
        PackageSelectionInfoEditModel GetPackageSelectionInfoEditModel(TempCart tempCart, PreQualificationResult preQualificationResult);
        void ProcessPayment(PaymentEditModel paymentEditModel, long eventCustomerId, long customerId, bool isAmexFullPayment);
    }
}