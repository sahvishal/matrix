using System.Web.Services;
using System.ComponentModel;
using System.Web.Script.Services;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;

namespace Falcon.App.UI.App.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class ProductController : WebService
    {

        [WebMethod (EnableSession = true)]
        public ElectronicProduct GetProductDetail(long productId)
        {
            IElectronicProductRepository electronicProductRepository = new ElectronicProductRepository();

            var cdProduct = electronicProductRepository.GetById(productId);
            return cdProduct;
        }
    }
}
