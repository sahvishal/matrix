using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IFinanceReportingService
    {
        ListModelBase<CustomerUpsellModel, CustomerUpsellListModelFilter> GetCustomerUpsellModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<CreditCardReconcileModel, CreditCardReconcileModelFilter> GetCreditCardReconcileList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        CustomerOrderListModel GetAllOrdersForCustomer(long customerId);
        ListModelBase<DeferredRevenueViewModel, DeferredRevenueListModelFilter> GetDeferredRevenue(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<ShippingRevenueSummaryViewModel, ShippingRevenueListModelFilter> GetShippingRevenueSummary(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<ShippingRevenueDetailViewModel, ShippingRevenueListModelFilter> GetShippingRevenueDetail(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<CustomerOpenOrderViewModel, CustomerOpenOrderListModelFilter> GetCustomerOpenOrder(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<CorporateAccountInvoiceLineItemViewModel, CorporateAccountInvoiceListModelFilter> GetCorporateAccountInvoiceList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<InsurancePaymentViewModel, InsurancePaymentListModelFilter> GetInsurancePayment(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<GiftCertificateReportViewModel, GiftCertificateReportFilter> GetGiftCertificateReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}