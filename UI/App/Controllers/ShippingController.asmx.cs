using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Script.Services;
using System.Web.Services;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class ShippingController : WebService
    {
        [WebMethod (EnableSession = true)]
        public IEnumerable<ShippingDetailViewModel> GetShippingDetailsForOrder(long orderDetailId)
        {
           var shippingDetailService= IoC.Resolve<IShippingDetailService>();
            
            //return _shippingDetailRepository.GetShippingDetailsForOrder(orderDetailId);
            return shippingDetailService.GetShippingDetailsForPopup(orderDetailId);
        }
    }
}
