using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class MedicalVendorUserEarningController : WebService
    {
        private readonly IMedicalVendorEarningCustomerAggregateRepository _medicalVendorEarningCustomerAggregateRepository;
        private readonly IMedicalVendorInvoiceRepository _medicalVendorInvoiceRepository;

        public MedicalVendorUserEarningController()
            : this(new MedicalVendorEarningCustomerAggregateRepository(), new MedicalVendorInvoiceRepository())
        {}

        public MedicalVendorUserEarningController(IMedicalVendorEarningCustomerAggregateRepository medicalVendorEarningRepository, 
            IMedicalVendorInvoiceRepository medicalVendorInvoiceRepository)
        {
            _medicalVendorEarningCustomerAggregateRepository = medicalVendorEarningRepository;
            _medicalVendorInvoiceRepository = medicalVendorInvoiceRepository;
        }

        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public List<MedicalVendorEarningCustomerAggregate> GetUnsettledEarningCustomerAggregates
            (long organizationRoleUserId)
        {
            List<OrderedPair<DateTime, DateTime>> dateRanges = _medicalVendorInvoiceRepository.
                GetMedicalVendorInvoicePayPeriods(organizationRoleUserId, PaymentStatus.Paid);
            return _medicalVendorEarningCustomerAggregateRepository.GetEarningCustomerAggregatesNotInDateRanges
                (organizationRoleUserId, dateRanges).OrderByDescending(a => a.EvaluationDate).ToList();
        }

        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public OrderedPair<int, List<MedicalVendorEarningCustomerAggregate>> GetEarningCustomerAggregatesAndAggregateCount
            (long organizationRoleUserId, DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            DateTime adjustedEndDate = endDate.AddDays(1).AddSeconds(-1);
            List<MedicalVendorEarningCustomerAggregate> medicalVendorEarningCustomerAggregates = 
                _medicalVendorEarningCustomerAggregateRepository.
                GetEarningCustomerAggregates(organizationRoleUserId, startDate, adjustedEndDate, pageNumber, pageSize);
            int numberOfAggregatesForUser = _medicalVendorEarningCustomerAggregateRepository.GetNumberofEarningCustomerAggregates
                (organizationRoleUserId, startDate, adjustedEndDate);

            return new OrderedPair<int, List<MedicalVendorEarningCustomerAggregate>>
                (numberOfAggregatesForUser, medicalVendorEarningCustomerAggregates);
        }

        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public OrderedPair<int, List<MedicalVendorEarningCustomerAggregate>> GetEarningCustomerAggregatesAndAggregateCountForVendor
            (long medicalVendorId, DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            DateTime adjustedEndDate = endDate.AddDays(1).AddSeconds(-1);
            List<MedicalVendorEarningCustomerAggregate> medicalVendorEarningCustomerAggregates = _medicalVendorEarningCustomerAggregateRepository.
                GetEarningCustomerAggregatesForVendor(medicalVendorId, startDate, adjustedEndDate, pageNumber, pageSize);
            int numberOfAggregatesForUser = _medicalVendorEarningCustomerAggregateRepository.GetNumberOfEarningCustomerAggregatesForVendor
                (medicalVendorId, startDate, adjustedEndDate);

            return new OrderedPair<int, List<MedicalVendorEarningCustomerAggregate>>
                (numberOfAggregatesForUser, medicalVendorEarningCustomerAggregates);
        }
    }
}
