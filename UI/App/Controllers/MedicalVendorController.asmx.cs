using System.Collections.Generic;
using System.Web.Services;
using Falcon.App.Core.Domain.MedicalVendors.ViewData;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Domain.MedicalVendors;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class MedicalVendorController : WebService
    {
        private readonly IMedicalVendorMedicalVendorUserAggregateRepository _medicalVendorMedicalVendorUserAggregateRepository;

        public MedicalVendorController()
            : this(new MedicalVendorMedicalVendorUserAggregateRepository())
        {}

        public MedicalVendorController(IMedicalVendorMedicalVendorUserAggregateRepository medicalVendorMedicalVendorUserAggregateRepository)
        {
            _medicalVendorMedicalVendorUserAggregateRepository = medicalVendorMedicalVendorUserAggregateRepository;
        }

        [WebMethod (EnableSession = true)]
        public List<MedicalVendorMedicalVendorUserAggregate> GetMedicalVendorMedicalVendorUsers(long medicalVendorId)
        {
            return _medicalVendorMedicalVendorUserAggregateRepository.GetMedicalVendorMedicalVendorUserAggregates(medicalVendorId);
        }
    }
}
