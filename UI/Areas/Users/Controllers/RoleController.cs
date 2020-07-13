using System.Collections.Generic;
using System.Web.Mvc;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;


namespace Falcon.App.UI.Areas.Users.Controllers
{
    [RoleBasedAuthorize]
    public class RoleController : Controller
    {
        private readonly IOrganizationRepository _organizationRepository;

        public RoleController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }


        public ActionResult Switch(long roleId, long organizationId)
        {
            IoC.Resolve<ISessionContext>().UserSession =
                IoC.Resolve<IUserLoginService>().SwitchOrganizationRole(IoC.Resolve<ISessionContext>().UserSession,
                                                                                  roleId, organizationId);

            // return Redirect("/Users/Dashboard/" + IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias);
            return RedirectToAction(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias, "Dashboard", new { Area = "Users" });
        }


        public ActionResult GetAllowedRolesForOrganization(long id)
        {

            try
            {
                var organizationType = _organizationRepository.GetOrganizationbyId(id).OrganizationType;
                return Json(_organizationRepository.GetRolesByOrganizationType(organizationType), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new List<RoleDropdownListModel>
                            {
                                new RoleDropdownListModel
                                    {Name = "-- Select Organization First --", RoleId = -1}
                            }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
