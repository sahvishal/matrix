using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class PackageModel
    {
        public long EventPackageId { get; set; }
        public long PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<TestModel> TestItems { get; set; }
    }
}