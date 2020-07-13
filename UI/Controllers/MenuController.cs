using System;
using System.Web.Mvc;

namespace Falcon.App.UI.Controllers
{
    public class MenuController : Controller
    {
        public MenuController()
        {
            //Todo: Need to keep it in some centeralized place.
            //if (System.Web.HttpContext.Current.Request.Url.PathAndQuery.ToLower().IndexOf("resultarchive/upload") < 0)
            //{
            //    System.Web.HttpContext.Current.Response.AppendHeader("Refresh", Convert.ToString(((System.Web.HttpContext.Current.Session.Timeout * 60) - 5), System.Globalization.CultureInfo.CurrentCulture) + "; Url=" + "/APP/Logoff.aspx?st=st");
            //}
        }

        [ChildActionOnly]
        public ActionResult FranchisorAdmin()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult SalesRep()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult FranchiseeAdmin()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MedicalVendorUser()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CallCenterManager()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CallCenterRep()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Customer()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Technician()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult TechnicianTeamLead()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult OperationManager()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult HospitalPartnerCoordinator()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult CorporateAccountCoordinator()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult HospitalFacilityCoordinator()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult NursePractitioner()
        {
            return View();
        }
    }
}
