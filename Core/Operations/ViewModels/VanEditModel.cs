using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;  //Yasir should not do this....., need to fix this.
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    
    public class VanEditModel : ViewModelBase
    {

        [HiddenInput(DisplayValue = false)] 
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        [DisplayName("Registration State")]  
        [UIHint("State")]
        public long StateId { get; set; }
        

        public string Make { get; set; }

        [DisplayName("VIN Number")]
        public string VehicleIdentificationNumber { get; set; }

        [DisplayName("Vehicle Registration Number")]
        public string RegistrationNumber { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
    }
    
}
