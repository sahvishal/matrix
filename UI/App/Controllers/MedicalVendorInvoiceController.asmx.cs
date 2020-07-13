using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Falcon.App.Core;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class MedicalVendorInvoiceController : WebService, IMedicalVendorInvoiceController
    {
        private readonly IMedicalVendorInvoiceRepository _medicalVendorInvoiceRepository;
        private readonly IMedicalVendorInvoiceStatisticRepository _medicalVendorInvoiceStatisticRepository;

        public MedicalVendorInvoiceController()
            : this (new MedicalVendorInvoiceRepository(), new MedicalVendorInvoiceStatisticRepository())
        {}

        public MedicalVendorInvoiceController(IMedicalVendorInvoiceRepository medicalVendorInvoiceRepository,
            IMedicalVendorInvoiceStatisticRepository medicalVendorInvoiceStatisticRepository)
        {
            _medicalVendorInvoiceRepository = medicalVendorInvoiceRepository;
            _medicalVendorInvoiceStatisticRepository = medicalVendorInvoiceStatisticRepository;
        }

        [WebMethod (EnableSession = true)]
        public PhysicianInvoice GetMedicalVendorInvoice(long medicalVendorInvoiceId)
        {
            return _medicalVendorInvoiceRepository.GetMedicalVendorInvoice(medicalVendorInvoiceId);
        }

        [WebMethod (EnableSession = true)]
        public MedicalVendorInvoiceStatistic GetMedicalVendorInvoiceStatistic(long medicalVendorInvoiceId)
        {
            return _medicalVendorInvoiceStatisticRepository.GetInvoiceStatistic(medicalVendorInvoiceId);
        }

        [WebMethod (EnableSession = true)]
        public List<ComboBoxPair> GetAllComboBoxInvoiceStatistics()
        {
            List<MedicalVendorInvoiceStatistic> medicalVendorInvoiceStatistics = _medicalVendorInvoiceStatisticRepository.
                GetAllInvoiceStatistics();
            return medicalVendorInvoiceStatistics.Select
                (m => new ComboBoxPair { value = m.Id.ToString(), text = m.ToString() }).ToList();
        }
    }
}
