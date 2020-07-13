using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class PodEditModel : ViewModelBase
    {
        public PodEditModel(ITerritoryRepository territoryRepository, ITestRepository testRepository)
        {
            Territories = territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.Pod);
            Tests = testRepository.GetAll();

            Rooms = new List<PodRoomEditModel> { new PodRoomEditModel() };
        }

        public PodEditModel() { }

        [UIHint("Hidden")]
        public long Id { get; set; }

        [UIHint("ExtendedTextBox")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [UIHint("ExtendedTextBox")]
        [DisplayName("Processing Capacity")]
        public int ProcessingCapacity { get; set; }

        [UIHint("ExtendedTextBox")]
        [DisplayName("Vehicle")]
        public long VanId { get; set; }

        public IEnumerable<OrderedPair<long, string>> Territories { get; set; }
        public IEnumerable<long> AssignedTerritories { get; set; }
        public IEnumerable<PodStaffEditModel> DefaultStaffAssigned { get; set; }

        public DataRecorderMetaData DataRecoderMetaData { get; set; }

        [DisplayName("Assigned To")]
        public long AssignedToFranchiseeid { get; set; }

        public IList<PodRoomEditModel> Rooms { get; set; }
        public IEnumerable<Test> Tests { get; set; }

        [DisplayName("Enable Kyn Integration")]
        public bool EnableKynIntegration { get; set; }

        [DisplayName("Bloodwork Requisition  Form Attached")]
        public bool IsBloodworkFormAttached { get; set; }
    }
}