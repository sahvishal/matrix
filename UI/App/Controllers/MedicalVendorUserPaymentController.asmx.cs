using System;
using System.Collections.Generic;
using System.Web.Services;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using IPaymentInstrumentRepository = Falcon.App.Core.Finance.IPaymentInstrumentRepository;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class MedicalVendorUserPaymentController : WebService
    {
        private readonly IMedicalVendorInvoiceStatisticRepository _medicalVendorInvoiceStatisticRepository;
        private readonly IPaymentInstrumentRepository _paymentInstrumentRepository;

        public MedicalVendorUserPaymentController()
            : this(new MedicalVendorInvoiceStatisticRepository(), new CombinedPaymentInstrumentRepository())
        {
            _medicalVendorInvoiceStatisticRepository = new MedicalVendorInvoiceStatisticRepository();
        }

        public MedicalVendorUserPaymentController(IMedicalVendorInvoiceStatisticRepository 
            medicalVendorInvoiceStatisticRepository, IPaymentInstrumentRepository paymentInstrumentRepository)
        {
            _medicalVendorInvoiceStatisticRepository = medicalVendorInvoiceStatisticRepository;
            _paymentInstrumentRepository = paymentInstrumentRepository;
        }

        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public OrderedPair<int, List<MedicalVendorInvoiceStatistic>> GetInvoiceStatisticsAndCount
            (long organizationRoleUserId, DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            int numberOfInvoiceStatisticsForMedicalVendorUser = _medicalVendorInvoiceStatisticRepository.
                GetNumberOfInvoiceStatisticsForMedicalVendorUser(organizationRoleUserId, startDate, endDate);
            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _medicalVendorInvoiceStatisticRepository.
                GetInvoiceStatisticsForMedicalVendorUser(organizationRoleUserId, startDate, endDate, pageNumber, pageSize);
            return new OrderedPair<int, List<MedicalVendorInvoiceStatistic>>(numberOfInvoiceStatisticsForMedicalVendorUser, 
                medicalVendorInvoiceStatistics);
        }

        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public OrderedPair<int, List<MedicalVendorInvoiceStatistic>> GetInvoiceStatisticsAndCountForVendor
            (long medicalVendorId, DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            int numberOfInvoiceStatisticsForMedicalVendorUser = _medicalVendorInvoiceStatisticRepository.
                GetNumberOfInvoiceStatisticsForMedicalVendor(medicalVendorId, startDate, endDate);
            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _medicalVendorInvoiceStatisticRepository.
                GetInvoiceStatisticsForMedicalVendor(medicalVendorId, startDate, endDate, pageNumber, pageSize);
            return new OrderedPair<int, List<MedicalVendorInvoiceStatistic>>(numberOfInvoiceStatisticsForMedicalVendorUser,
                medicalVendorInvoiceStatistics);
        }

        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public List<MedicalVendorInvoiceStatistic> GetInvoiceStatistics(PaymentStatus paymentStatus)
        {
            return _medicalVendorInvoiceStatisticRepository.GetInvoiceStatisticsByPaymentStatus(paymentStatus);
        }

        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public List<PaymentInstrument> GetPaymentInstruments(long medicalVendorInvoiceId)
        {
            return _paymentInstrumentRepository.GetPaymentInstrumentsForInvoice(medicalVendorInvoiceId);
        }
    }
}