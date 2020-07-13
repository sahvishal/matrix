using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Service;
using IPaymentInstrumentRepository = Falcon.App.Core.Finance.IPaymentInstrumentRepository;

namespace Falcon.App.UI.App.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]    
    [System.Web.Script.Services.ScriptService]
    public class MedicalVendorPaymentWebService : WebService, IMedicalVendorPaymentWebService
    {
        private readonly IMedicalVendorInvoiceRepository _medicalVendorInvoiceRepository;

        public MedicalVendorPaymentWebService()
            : this(new MedicalVendorInvoiceRepository())
        {}

        public MedicalVendorPaymentWebService(IMedicalVendorInvoiceRepository medicalVendorInvoiceRepository)
        {
            _medicalVendorInvoiceRepository = medicalVendorInvoiceRepository;
        }

        [WebMethod (EnableSession = true)]
        public bool HasInvoicesPendingForApproval(long medicalVendorMedicalVendorUserId)
        {
            return _medicalVendorInvoiceRepository.HasInvoicePendingApproval(medicalVendorMedicalVendorUserId);
        }
        
        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public string GenerateAndPersistInvoicesForMedicalVendor
            (long medicalVendorId, DateTime payPeriodStartDate, DateTime payPeriodEndDate)
        {
            IMedicalVendorPaymentService medicalVendorPaymentService = new MedicalVendorPaymentService();
            try
            {
                List<PhysicianInvoice> invoices = medicalVendorPaymentService.
                    GenerateInvoicesForMedicalVendor(medicalVendorId, payPeriodStartDate, payPeriodEndDate);
                _medicalVendorInvoiceRepository.SaveMedicalVendorInvoices(invoices);
                return string.Format("Successfully saved {0} invoice(s).", invoices.Count);
            }
            catch (Exception exception)
            {
                //if (exception.Message != null) throw new AuthenticationException(exception.Message);
                return "Error: " + exception.Message;
            }
        }

        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public PhysicianInvoice GetInvoice(long invoiceId)
        {
            try
            {
                PhysicianInvoice medicalVendorInvoice =
                    _medicalVendorInvoiceRepository.GetMedicalVendorInvoice(invoiceId);

                medicalVendorInvoice.MedicalVendorInvoiceItems = medicalVendorInvoice.
                    MedicalVendorInvoiceItems.OrderBy(mvii => mvii.ReviewDate).ThenBy(mvii => mvii.EventName).ToList();
                return medicalVendorInvoice;                
            }
            catch (Exception)
            {
                //TODO:log the exception in log4net
                return null;
            }
        }
        
        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public PhysicianInvoice GetOldestUnapprovedInvoiceForMedicalVendorUser(long medicalVendorMedicalVenderUserId)
        {
            try
            {
                PhysicianInvoice medicalVendorInvoice = _medicalVendorInvoiceRepository.
                    GetOldestUnapprovedInvoiceForMedicalVendorUser(medicalVendorMedicalVenderUserId);

                medicalVendorInvoice.MedicalVendorInvoiceItems = medicalVendorInvoice.
                    MedicalVendorInvoiceItems.OrderBy(mvii => mvii.ReviewDate).ThenBy(mvii => mvii.EventName).ToList();

                return medicalVendorInvoice;                
            }
            catch (Exception)
            {
                //TODO:log the exception in log4net
                return null;
            }
        }
        
        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public bool ChangeInvoiceApprovalStatus(long invoiceId, int approvalStatus)
        {
            _medicalVendorInvoiceRepository.ChangeMedicalVendorInvoiceApprovalStatus(invoiceId,(ApprovalStatus)approvalStatus);

            return true;                       
        }
        
        // TODO: TEST
        [WebMethod (EnableSession = true)]
        public List<PaymentInstrument> GetPaymentInstruments(long medicalVendorInvoiceId)
        {
            try
            {
                IPaymentInstrumentRepository paymentInstrumentRepository = new CombinedPaymentInstrumentRepository();
                return paymentInstrumentRepository.GetPaymentInstrumentsForInvoice(medicalVendorInvoiceId);
            }
            catch (Exception)
            {
                //TODO: Log exception in log4net.
                return null;
            }
        }
    }
}
