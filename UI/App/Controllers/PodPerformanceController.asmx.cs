using System;
using System.Collections.Generic;
using System.Web.Services;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class PodPerformanceController : WebService, IPodPerformanceController
    {
        private readonly IMedicalVendorPaymentPodViewDataFactory _podViewDataFactory;
        private readonly IMedicalVendorInvoiceRepository _medicalVendorInvoiceRepository;

        public PodPerformanceController()
            : this(new MedicalVendorPaymentPodViewDataFactory(), new MedicalVendorInvoiceRepository())
        {}

        public PodPerformanceController(IMedicalVendorPaymentPodViewDataFactory podViewDataFactory,
            IMedicalVendorInvoiceRepository medicalVendorInvoiceRepository)
        {
            _podViewDataFactory = podViewDataFactory;
            _medicalVendorInvoiceRepository = medicalVendorInvoiceRepository;
        }

        [WebMethod (EnableSession = true)]
        public List<MedicalVendorPaymentPodViewData> GetPodViewDataForInvoice(long medicalVendorInvoiceId)
        {
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceRepository.
                GetMedicalVendorInvoice(medicalVendorInvoiceId).MedicalVendorInvoiceItems;
            return _podViewDataFactory.CreatePodViewData(medicalVendorInvoiceItems);
        }

        [WebMethod (EnableSession = true)]
        public List<MedicalVendorPaymentPodViewData> GetPodViewDataForDateRange(DateTime startDate, DateTime endDate)
        {
            List<PhysicianInvoice> medicalVendorInvoices = _medicalVendorInvoiceRepository.
                GetInvoicesForDateRange(startDate, endDate);
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>();
            foreach (var medicalVendorInvoice in medicalVendorInvoices)
            {
                medicalVendorInvoiceItems.AddRange(medicalVendorInvoice.MedicalVendorInvoiceItems);
            }
            return _podViewDataFactory.CreatePodViewData(medicalVendorInvoiceItems);
        }
    }
}
