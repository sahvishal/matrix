using System.Collections.Generic;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class PackageViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PackageType { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<string> SelectedTests { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
    }
}