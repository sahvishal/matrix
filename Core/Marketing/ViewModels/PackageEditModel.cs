using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class PackageEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        [DisplayName("Description for Upsell Section")]
        public string DescriptiononUpsellSection { get; set; }

        [DisplayName("Relative Order")]
        public long RelativeOrder { get; set; }

        [DisplayName("Package Type")]
        public long PackageTypeId { get; set; }
        [DisplayName("Default Selection for Event")]
        public bool IsSelectedByDefaultforEvent { get; set; }
        [DisplayName("Show in Public Website")]
        public bool ShowInPublicWebSite { get; set; }

        public IEnumerable<TestViewModel> AllTests { get; set; }
        public IEnumerable<PackageTestEditModel> SelectedTests { get; set; }

        public IEnumerable<OrderedPair<long, string>> AllRoles { get; set; }
        public IEnumerable<long> SelectedRoles { get; set; }

        public File ForOrderDisplayFile { get; set; }

        /// <summary>
        /// In minutes
        /// </summary>
        [DisplayName("Screening Time")]
        public int ScreeningTime { get; set; }

        [DisplayName("Package Info Url")]
        public string PackageInfoUrl { get; set; }

        [DisplayName("Health Assessment Template")]
        public long? HealthAssessmentTemplateId { get; set; }

        public long Gender { get; set; }
    }
}