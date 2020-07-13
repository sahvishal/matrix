using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class HospitalFacilityEditModel : ViewModelBase
    {
        public OrganizationEditModel OrganizationEditModel { get; set; }

        [DisplayName("Contract")]
        public long ContractId { get; set; }

        public File ResultLetterFile { get; set; }

        [DisplayName("Canned Message")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string CannedMessage { get; set; }

        public long HospitalPartnerId { get; set; }

        public HospitalFacilityEditModel()
        {
            OrganizationEditModel=new OrganizationEditModel();
        }
    }
}
