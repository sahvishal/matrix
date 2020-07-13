using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class StaffEventRoleEditModel: ViewModelBase
    {
        
        public StaffEventRoleEditModel(ITestRepository testRepository)
        {
            Tests = testRepository.GetAll();
            AllowedTestIds = new long[] {};
        }

        public StaffEventRoleEditModel()
        {

        }

        [UIHint("Hidden")]
        public long Id { get; set; }

        [UIHint("ExtendedTextBox")]
        public string Name { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Bindable(false)]
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public IEnumerable<Test> Tests { get; set; }
        public IEnumerable<long> AllowedTestIds { get; set; }


    }
}