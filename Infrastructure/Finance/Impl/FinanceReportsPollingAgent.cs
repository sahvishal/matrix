using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using JetBrains.Annotations;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    [UsedImplicitly]
    public class FinanceReportsPollingAgent : BaseReportPollingAgent, IFinanceReportsPollingAgent
    {
        private IDatabase _db;
        private ConnectionMultiplexer _redis;
        private readonly ILogger _logger;



        private ConnectionMultiplexer ConnectionMultiplexer
        {
            get
            {
                if (_redis == null || !_redis.IsConnected)
                {
                    var config = ConfigurationOptions.Parse(Host);
                    config.ConnectTimeout = 5000;
                    _redis = ConnectionMultiplexer.Connect(config);
                }
                return _redis;
            }
        }

        public FinanceReportsPollingAgent(ILogManager logManager, ISettings settings)
            : base(settings)
        {
            _logger = logManager.GetLogger("Finance Reports");
        }

        private void ReportsPollingAgent(string channel, string queue)
        {
            _logger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", channel, queue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();

                sub.Unsubscribe(channel);

                _db = redis.GetDatabase(RedisDatabaseKey);
                _db.KeyDelete(queue);

                sub.Subscribe(channel, delegate
                {
                    string item = _db.ListRightPop(queue);
                    while (item != null)
                    {
                        var request = Newtonsoft.Json.JsonConvert.DeserializeObject<GenericReportRequest>(item);
                        try
                        {
                            ProcessReports(request);
                            _db.StringSet(request.Guid, "Completed");
                        }
                        catch (Exception)
                        {
                            _db.StringSet(request.Guid, "Failed");
                        }
                        item = _db.ListRightPop(queue);
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.Info("Process Report. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }

        }

        public void PollForFinanceReports()
        {
            PollForShippingRevenueDetailReport();
            PollForDeferredRevenueReport();
            PollForInsurancePaymentReport();
            PollForDetailOpenOrderReports();
            PollForUpsellReports();
            PollForCreditCardReconsileReports();
            PollForDailyRecapReports();
            PollForShippingRevenueSummaryReports();
            PollForCustomerOpenOrderReports();
            PollForCorporateInvoiceReports();
            PollForRefundRequestReports();
            PollForDailyRecapCustomerReports();
            PollForGiftCertificateReports();
            PollForPayPeriodBookedCustomersReports();
            PollForCallCenterBonusReports();
            PollForActualCustomerShowedReports();
        }



        private void PollForShippingRevenueDetailReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateShippingRevenueDetailReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateShippingRevenueDetailReportChannel, RequestSubcriberChannelNames.GenerateShippingRevenueDetailReportQueue);
        }

        private void PollForDeferredRevenueReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateDeferredRevenueReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateDeferredRevenueReportChannel, RequestSubcriberChannelNames.GenerateDeferredRevenueReportQueue);
        }

        private void PollForInsurancePaymentReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateInsurancePaymentReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateInsurancePaymentReportChannel, RequestSubcriberChannelNames.GenerateInsurancePaymentReportQueue);
        }

        private void PollForDetailOpenOrderReports()
        {

            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.DetailOpenOrderQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.DetailOpenOrderChannel, RequestSubcriberChannelNames.DetailOpenOrderQueue);
        }

        private void PollForUpsellReports()
        {

            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.UpsellQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.UpsellChannel, RequestSubcriberChannelNames.UpsellQueue);
        }

        private void PollForCreditCardReconsileReports()
        {

            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CreditCardReconsileQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CreditCardReconsileChannel, RequestSubcriberChannelNames.CreditCardReconsileQueue);
        }

        private void PollForDailyRecapReports()
        {

            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.DailyRecapQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.DailyRecapChannel, RequestSubcriberChannelNames.DailyRecapQueue);
        }

        private void PollForShippingRevenueSummaryReports()
        {

            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.ShippingRevenueSummaryQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.ShippingRevenueSummaryChannel, RequestSubcriberChannelNames.ShippingRevenueSummaryQueue);
        }

        private void PollForCustomerOpenOrderReports()
        {

            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CustomerOpenOrderQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CustomerOpenOrderChannel, RequestSubcriberChannelNames.CustomerOpenOrderQueue);
        }

        private void PollForCorporateInvoiceReports()
        {

            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CorporateInvoiceQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CorporateInvoiceChannel, RequestSubcriberChannelNames.CorporateInvoiceQueue);
        }

        private void PollForRefundRequestReports()
        {


            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.RefundRequestQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.RefundRequestChannel, RequestSubcriberChannelNames.RefundRequestQueue);
        }

        private void PollForDailyRecapCustomerReports()
        {


            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.DailyRecapCustomerQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.DailyRecapCustomerChannel, RequestSubcriberChannelNames.DailyRecapCustomerQueue);
        }

        private void PollForGiftCertificateReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GiftCertificateQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GiftCertificateChannel, RequestSubcriberChannelNames.GiftCertificateQueue);
        }

        private void PollForPayPeriodBookedCustomersReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.PayPeriodAppointmentBookedQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.PayPeriodAppointmentBookedChannel, RequestSubcriberChannelNames.PayPeriodAppointmentBookedQueue);
        }

        private void PollForCallCenterBonusReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CallCenterBonusQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CallCenterBonusChannel, RequestSubcriberChannelNames.CallCenterBonusQueue);
        }

        private void PollForActualCustomerShowedReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.ActualCustomerShowedQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.ActualCustomerShowedChannel, RequestSubcriberChannelNames.ActualCustomerShowedQueue);
        }
    }
}
