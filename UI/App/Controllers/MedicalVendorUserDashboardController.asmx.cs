using System.Web.Services;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class MedicalVendorUserDashboardController : WebService
    {
        private readonly IMedicalVendorInvoiceRepository _medicalVendorInvoiceRepository;
        private readonly IMedicalVendorEarningRepository _medicalVendorEarningRepository;

        public MedicalVendorUserDashboardController()
            : this (new MedicalVendorInvoiceRepository(), new MedicalVendorEarningRepository())
        {}

        public MedicalVendorUserDashboardController(IMedicalVendorInvoiceRepository medicalVendorInvoiceRepository,
            IMedicalVendorEarningRepository medicalVendorEarningRepository)
        {
            _medicalVendorInvoiceRepository = medicalVendorInvoiceRepository;
            _medicalVendorEarningRepository = medicalVendorEarningRepository;
        }

        [WebMethod (EnableSession = true)]
        public int GetNumberOfEarnings(long organizationRoleUserId, PaymentStatus paymentStatus)
        {
            var paymentStatusToSend = paymentStatus == PaymentStatus.Paid ? PaymentStatus.Unpaid : PaymentStatus.Paid;
            var payPeriods = _medicalVendorInvoiceRepository.GetMedicalVendorInvoicePayPeriods(organizationRoleUserId, paymentStatusToSend);
            return _medicalVendorEarningRepository.GetEarningsNotInDateRanges(organizationRoleUserId, payPeriods);
        }
    }
}
