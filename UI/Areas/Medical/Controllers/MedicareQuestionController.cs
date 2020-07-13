using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class MedicareQuestionController : Controller
    {
        private readonly ICustomerMedicareQuestionService _customerMedicareQuestionService;

        public MedicareQuestionController(ICustomerMedicareQuestionService customerMedicareQuestionService)
        {
            _customerMedicareQuestionService = customerMedicareQuestionService;
        }

        public ActionResult Index(long eventCustomerId)
        {
            if (Request != null && !string.IsNullOrWhiteSpace(Request.ServerVariables["http_referer"]))
            {
                ViewData["http_referer"] = Request.ServerVariables["http_referer"];
            }
            return View(_customerMedicareQuestionService.GetEditModel(eventCustomerId));
        }

        public ActionResult Update(long eventCustomerId)
        {
            return PartialView(_customerMedicareQuestionService.GetEditModel(eventCustomerId));
        }

        [HttpPost]
        public ActionResult SaveCustomerAnswer(CustomerMedicareQuestionAnswerEditModel model)
        {
            var list = model.Question.Select(m => new CustomerMedicareAnswer
            {
                Answer = Server.UrlDecode(m.Answer),
                ControlType = m.ControlType,
                Id = m.Id
            }).ToList();

            model.Question = list;
            _customerMedicareQuestionService.SaveCustomerMedicareAnswer(model);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
