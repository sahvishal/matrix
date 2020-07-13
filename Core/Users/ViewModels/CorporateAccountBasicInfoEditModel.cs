using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CorporateAccountBasicInfoEditModel : ViewModelBase
    {
        public OrganizationEditModel OrganizationEditModel { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Contract Notes")]
        public string ContractNotes { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }

        [DisplayName("Corp Code")]
        public string CorpCode { get; set; }

        public bool IsNew { get; set; }

        public long? ConvertedHostId { get; set; }

        public bool CreateHost { get; set; }
        public string OpenDefaultTab { get; set; }

        public CorporateAccountBasicInfoEditModel()
        {
            OrganizationEditModel = new OrganizationEditModel { BillingAddress = new AddressEditModel(), BusinessAddress = new AddressEditModel() };
            CorpCode = string.Empty;
        }
    }
}