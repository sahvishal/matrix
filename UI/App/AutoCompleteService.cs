using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Web.Services;
using Falcon.App.Core.Application;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Marketing.Repositories;
using Falcon.DataAccess.CallCenter;
using Falcon.DataAccess.Franchisee;
using Falcon.DataAccess.MarketingPartner;
using Falcon.DataAccess.Other;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Other;
using Falcon.DataAccess.Master;

using AjaxControlToolkit;
using System.Data;
using Falcon.Entity.Franchisee;
using Falcon.App.Core;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
/// <summary>
/// Summary description for AutoCompleteService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoCompleteService : System.Web.Services.WebService
{

    public AutoCompleteService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetCityByPrefixText(string prefixText)
    {
        var repository = IoC.Resolve<ICityRepository>();
        return repository.GetbyPrefixTest(prefixText).Select(m => m.Name).Distinct().ToList();

        //var masterDal = new MasterDAL();
        //return masterDal.GetCity(prefixText, 5).Select<ECity, string>(city => city.Name).ToList<string>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prefixText">The search string(city name)</param>
    /// <param name="contextKey">The context key is the state Id</param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public List<string> GetCityByContextKeyAndPrefixText(string prefixText, string contextKey)
    {
        var masterDal = new Falcon.DataAccess.Master.MasterDAL();

        // TODO: Using '0' is a hook here will have to be removed once we modify autoCompleteExtender.
        return ((!string.IsNullOrEmpty(contextKey) && contextKey != "0") ? masterDal.GetCitybyState(contextKey, prefixText, 4).Select<ECity, string>(city => city.Name).ToList<string>() : masterDal.GetUniqueCity(prefixText, 6).Select<ECity, string>(city => city.Name).ToList<string>());
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetCityByContextKeyNameAndPrefixText(string prefixText, string contextKey)
    {
        var masterDal = new MasterDAL();

        return (!string.IsNullOrEmpty(contextKey) ? masterDal.GetCityOnStateName(contextKey, prefixText).Tables[0].Rows.Cast<DataRow>().Select(dataRow => dataRow["Name"].ToString()).ToList<string>() : masterDal.GetCity(prefixText, 2).Select(dataRow => dataRow.Name).ToList());
    }

    [WebMethod(EnableSession = true)]
    public List<ECity> GetCitiesByPrefixText(string prefixText)
    {
        var masterDal = new MasterDAL();
        return masterDal.GetCity(prefixText, 5);
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetStateByPrefixText(string prefixText)
    {
        var masterDal = new MasterDAL();
        return masterDal.GetState(prefixText, 2).Select<EState, string>(state => state.Name).ToList<string>();
    }


    // TODO :To be removed once AutoCompleteExtender is viped of from the application..
    [WebMethod(EnableSession = true)]
    public string[] GetSimilarCity(string prefixText, int count)
    {

        var items = new List<string>();

        var masterDal = new Falcon.DataAccess.Master.MasterDAL();
        var cities = masterDal.GetCity(prefixText, 5);

        try
        {
            if (cities != null)
                foreach (ECity city in cities)
                    items.Add(city.Name);
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items.ToArray();
    }


    [WebMethod(EnableSession = true)]
    public string[] GetMatchingCityByStateName(string prefixText, int count, string contextKey)
    {

        List<string> items = new List<string>();

        var objDAL = new MasterDAL();

        try
        {
            if (!string.IsNullOrEmpty(contextKey))
            {
                foreach (DataRow dr in objDAL.GetCityOnStateName(contextKey, prefixText).Tables[0].Rows)
                    items.Add(dr["Name"].ToString());
            }
            else
            {
                foreach (ECity dr in objDAL.GetCity(prefixText, 2))
                    items.Add(dr.Name);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetMatchingState(string prefixText, int count)
    {

        List<string> items = new List<string>();

        MasterDAL masterDAL = new MasterDAL();
        var statearr = masterDAL.GetState(prefixText, 2);

        try
        {
            foreach (var state in statearr)
                items.Add(state.Name);
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public List<ECity> GetCityByStateAndPrefixText(string prefixText, string stateName)
    {
        var cities = new List<ECity>();

        var masterDal = new Falcon.DataAccess.Master.MasterDAL();

        try
        {
            cities = !string.IsNullOrEmpty(stateName) ? masterDal.GetCitybyState(stateName, prefixText, 4) : masterDal.GetUniqueCity(prefixText, 6);
        }
        catch { }

        return cities;
    }

    [WebMethod(EnableSession = true)]
    public string[] GetMatchingCity(string prefixText, int count, string contextKey)
    {

        List<string> items = new List<string>();

        //HealthYes.Web.UI.CityService.CityService service = new HealthYes.Web.UI.CityService.CityService();

        var masterDal = new Falcon.DataAccess.Master.MasterDAL();

        try
        {
            //ECity[] cityarr = new ECity[0];
            if (!string.IsNullOrEmpty(contextKey))
            {
                //cityarr = service.GetCitybyNameandState(Convert.ToInt32(contextKey), true, prefixText);
                var cities = masterDal.GetCitybyState(contextKey, prefixText, 4);
                foreach (ECity city in cities)
                    items.Add(city.Name);

            }
            else
            {
                //cityarr = service.GetUniqueCity(prefixText);
                var cities = masterDal.GetUniqueCity(prefixText, 6);
                foreach (ECity city in cities)
                    items.Add(city.Name);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items.ToArray();
    }



    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] GetEvents(string knownCategoryValues, string category)
    {
        var masterDal = new MasterDAL();

        List<EEvent> arrevent = masterDal.SearchEventDetails(0, "", "", "", "", "", "", 4);

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        foreach (EEvent objevent in arrevent)
        {
            values.Add(new CascadingDropDownNameValue(objevent.Name, objevent.EventID.ToString()));
        }
        return values.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetFranchiseeEmployeeByPrefixTextAndContextKey(string prefixText, string contextKey)
    {

        List<string> items = new List<string>();
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();
        List<Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser> objFFUser = franchiseeDAL.GetFranchiseeEmployeeByName(prefixText, Convert.ToInt32(contextKey), 3);

        try
        {
            string struser = string.Empty;
            string strshell = string.Empty;
            string strrole = string.Empty;

            foreach (Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser objUser in objFFUser)
            {
                struser = objUser.FranchiseeUser.User.FirstName + " " + objUser.FranchiseeUser.User.LastName + "[" + objUser.FranchiseeUser.User.UserID + "]";
                strrole = objUser.RoleType + "[" + objUser.RoleID + "]";
                strshell = objUser.Franchisee.Name + "[" + objUser.Franchisee.FranchiseeID + "]";
                items.Add(struser + " as " + strrole + " in " + strshell);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items;
    }


    // Refactored to GetFranchiseeEmployeeByPrefixTextAndContextKey
    [WebMethod(EnableSession = true)]
    public string[] GetFranchiseeEmployee(string prefixText, int count, string contextKey)
    {

        List<string> items = new List<string>();
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();
        List<Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser> objFFUser = franchiseeDAL.GetFranchiseeEmployeeByName(prefixText, Convert.ToInt32(contextKey), 3);

        try
        {
            string struser = string.Empty;
            string strshell = string.Empty;
            string strrole = string.Empty;

            foreach (Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser objUser in objFFUser)
            {
                struser = objUser.FranchiseeUser.User.FirstName + " " + objUser.FranchiseeUser.User.LastName + "[" + objUser.FranchiseeUser.User.UserID + "]";
                strrole = objUser.RoleType + "[" + objUser.RoleID + "]";
                strshell = objUser.Franchisee.Name + "[" + objUser.Franchisee.FranchiseeID + "]";
                items.Add(struser + " as " + strrole + " in " + strshell);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetEmployeeForFranchisorByPrefixTextAndContextKey(string prefixText, string contextKey)
    {
        List<string> items = new List<string>();
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();

        List<Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser> objFFUser = franchiseeDAL.GetEmployeeForFranchisor(prefixText, Convert.ToInt32(contextKey), 4);
        try
        {
            string struser = string.Empty;
            string strshell = string.Empty;
            string strrole = string.Empty;

            foreach (Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser objUser in objFFUser)
            {
                struser = objUser.FranchiseeUser.User.FirstName + " " + objUser.FranchiseeUser.User.LastName + "[" + objUser.FranchiseeUser.User.UserID + "]";
                strrole = objUser.RoleType + "[" + objUser.RoleID + "]";
                strshell = objUser.Franchisee.Name + "[" + objUser.Franchisee.FranchiseeID + "]";



                items.Add(struser + " as " + strrole + " in " + strshell);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items;
    }

    // Refactored to GetEmployeeForFranchisorByPrefixTextAndContextKey
    [WebMethod(EnableSession = true)]
    public string[] GetEmployeeForFranchisor(string prefixText, int count, string contextKey)
    {
        //GetEmployeeForFranchisor
        List<string> items = new List<string>();
        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService objService = new HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService();
        // remove services references
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();

        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.EFranchiseeFranchiseeUser[] objFFUser = objService.GetEmployeeForFranchisor(prefixText, Convert.ToInt32(contextKey), true);
        List<Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser> objFFUser = franchiseeDAL.GetEmployeeForFranchisor(prefixText, Convert.ToInt32(contextKey), 4);
        try
        {
            string struser = string.Empty;
            string strshell = string.Empty;
            string strrole = string.Empty;

            foreach (Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser objUser in objFFUser)
            {
                struser = objUser.FranchiseeUser.User.FirstName + " " + objUser.FranchiseeUser.User.LastName + "[" + objUser.FranchiseeUser.User.UserID + "]";
                strrole = objUser.RoleType + "[" + objUser.RoleID + "]";
                strshell = objUser.Franchisee.Name + "[" + objUser.Franchisee.FranchiseeID + "]";



                items.Add(struser + " as " + strrole + " in " + strshell);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items.ToArray();
    }

    // Refactored from GetSalesRepForFranchisor
    [WebMethod(EnableSession = true)]
    public List<string> GetSalesRepForFranchisorByPrefixText(string prefixText)
    {
        FranchiseeDAL franchiseeDal = new FranchiseeDAL();

        return franchiseeDal.GetEmployeeForFranchisor(prefixText, 0, 5)
            .Select<EFranchiseeFranchiseeUser, string>(franchiseeUser =>
                {
                    string user = franchiseeUser.FranchiseeUser.User.FirstName + " " + franchiseeUser.FranchiseeUser.User.LastName + "[" + franchiseeUser.FranchiseeFranchiseeUserID.ToString() + "]";
                    string role = franchiseeUser.RoleType;
                    string shell = franchiseeUser.Franchisee.Name + "[" + franchiseeUser.Franchisee.FranchiseeID + "]";

                    return user + " as " + role + " in " + shell;
                }).ToList<string>();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetSalesRepForFranchisee(string prefixText, int count, string contextKey)
    {
        List<string> items = new List<string>();
        long intFranchiseeID = 0;
        if (contextKey != null && contextKey != "")
        {
            intFranchiseeID = Convert.ToInt64(contextKey);
        }

        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService objService = new HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService();
        // remove services references
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();

        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.EUser[] objEUser = objService.GetSalesRepForFranchisee(prefixText, intFranchiseeID, true, 0, true);
        List<Falcon.Entity.Other.EUser> objEUser = franchiseeDAL.GetSalesRepForFranchisee(prefixText, intFranchiseeID, 0);

        try
        {
            string struser = string.Empty;
            IOrganizationRoleUserRepository orgRoleUserRepository = new OrganizationRoleUserRepository();

            foreach (Falcon.Entity.Other.EUser objUser in objEUser)
            {
                var orgRoleUser = orgRoleUserRepository.GetOrganizationRoleUser(objUser.UserID, Falcon.App.Core.Enum.Roles.SalesRep, intFranchiseeID);
                struser = objUser.FirstName + " [" + orgRoleUser.Id.ToString() + "]";
                items.Add(struser);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }
        return items.ToArray();

    }

    [WebMethod(EnableSession = true)]
    public string[] GetSalesRepForFranchisee_nonSSL(string prefixText, int count, string contextKey)
    {
        List<string> items = new List<string>();
        int intFranchiseeID = 0;
        if (contextKey != null && contextKey != "")
        {
            intFranchiseeID = Convert.ToInt32(contextKey);
        }

        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService objService = new HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService();
        // remove services references
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();

        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.EUser[] objEUser = objService.GetSalesRepForFranchisee(prefixText, intFranchiseeID, true, 0, true);
        List<Falcon.Entity.Other.EUser> objEUser = franchiseeDAL.GetSalesRepForFranchisee(prefixText, intFranchiseeID, 0);

        try
        {
            string struser = string.Empty;


            foreach (Falcon.Entity.Other.EUser objUser in objEUser)
            {
                struser = objUser.FirstName + " [" + objUser.UserID.ToString() + "]";
                items.Add(struser);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }
        return items.ToArray();

    }

    [WebMethod(EnableSession = true)]
    public List<string> GetFranchiseeEventsByPrefixText(string prefixText, string contextKey)
    {
        var masterDal = new MasterDAL();
        return masterDal.GetFranchiseeEvent(1, Convert.ToInt32(contextKey), prefixText).Select<EEvent, string>(eventData => eventData.Name + "[" + "ID:" + eventData.EventID.ToString() + "]").ToList<string>();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetFranchiseeEvents(string prefixText, int count, string contextKey)
    {
        //GetEmployeeForFranchisor
        List<string> items = new List<string>();
        var masterDal = new MasterDAL();
        List<EEvent> objEvent = masterDal.GetFranchiseeEvent(1, Convert.ToInt32(contextKey), prefixText);

        try
        {
            string eventname;
            string eventid = string.Empty;


            foreach (EEvent eevent in objEvent)
            {
                eventname = eevent.Name + "[" + "ID:" + eevent.EventID.ToString() + "]";
                items.Add(eventname);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items.ToArray();
    }

    // Refactored from GetAllFutureEvents
    [WebMethod(EnableSession = true)]
    public List<string> GetForthComingEventsByPrefixTextAndContextKey(string prefixText, string contextKey)
    {
        var masterDal = new MasterDAL();
        return masterDal.GetFranchiseeEvent(3, Convert.ToInt32(contextKey), prefixText).Select<EEvent, string>(eEvent => eEvent.Name + "[" + "ID:" + eEvent.EventID.ToString() + "]").ToList<string>();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetAllFutureEvents_nonSSL(string prefixText, int count, string contextKey)
    {
        //GetEmployeeForFranchisor
        List<string> items = new List<string>();
        var masterDal = new MasterDAL();
        List<EEvent> objEvent = masterDal.GetFranchiseeEvent(3, Convert.ToInt32(contextKey), prefixText);

        try
        {
            string eventname;
            string eventid = string.Empty;


            foreach (EEvent eevent in objEvent)
            {
                eventname = eevent.Name + "[" + "ID:" + eevent.EventID.ToString() + "]";
                items.Add(eventname);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetAllHeldEventsByPrefixText(string prefixText)
    {
        var masterDal = new MasterDAL();
        return masterDal.GetFranchiseeEvent(2, 0, prefixText).Select<EEvent, string>(eventData => eventData.Name + "[" + "ID:" + eventData.EventID.ToString() + "]").ToList<string>();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetAllHeldEventsforFranchisor(string prefixText, int count)
    {
        //GetEmployeeForFranchisor
        List<string> items = new List<string>();
        var masterDal = new MasterDAL();
        List<EEvent> objEvent = masterDal.GetFranchiseeEvent(2, 0, prefixText);

        try
        {
            foreach (EEvent eevent in objEvent)
            {
                string eventname = eevent.Name + "[" + "ID:" + eevent.EventID.ToString() + "]";
                items.Add(eventname);
            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }

        return items.ToArray();
    }

    // Refactored from GetAlreadyHeldEvents
    [WebMethod(EnableSession = true)]
    public List<string> GetCompletedEvents(string prefixText, string contextKey)
    {
        var masterDal = new MasterDAL();
        return masterDal.GetFranchiseeEvent(1, Convert.ToInt32(contextKey), prefixText).Select<EEvent, string>(eEvent => eEvent.Name + "[" + "ID:" + eEvent.EventID.ToString() + "]").ToList<string>();
    }

    [WebMethod(EnableSession = true)]
    public string IsNoShow(string yesorno)
    {
        var masterDal = new MasterDAL();

        if (yesorno.Substring(0, 1) == "y")
        {
            masterDal.SetNoShow(Convert.ToInt32(yesorno.Substring(1)), true);
            return yesorno.Substring(0, 1);
        }
        masterDal.SetNoShow(Convert.ToInt32(yesorno.Substring(1)), false);
        return yesorno.Substring(0, 1);
    }

    [WebMethod(EnableSession = true)]
    public string CheckInCheckOut(string appointmentid, string checkintime, string checkouttime)
    {
        var masterDal = new MasterDAL();

        string authorizationTime;

        var returnresult = masterDal.SetCheckInCheckOutTime(appointmentid, checkintime, checkouttime, out authorizationTime);

        return returnresult + ", " + (authorizationTime.Length < 1 ? "" : Convert.ToDateTime(authorizationTime).ToString("MM/dd/yyyy @ hh:mm tt"));
    }

    [WebMethod(EnableSession = true)]
    public void SetHIPAAStatus(long eventcustomerid, short status)
    {
        var masterDal = new MasterDAL();

        //short HIPAAStatus = 0;

        //if(status == HealthYes.Web.Core.Enum.HIPAAStatus.Signed.ToString())
        //    HIPAAStatus = (short)HealthYes.Web.Core.Enum.HIPAAStatus.Signed;
        //else if (status == HealthYes.Web.Core.Enum.HIPAAStatus.Not_Signed.ToString().Replace("_", " "))
        //    HIPAAStatus = (short)HealthYes.Web.Core.Enum.HIPAAStatus.Not_Signed;
        //else if (status == HealthYes.Web.Core.Enum.HIPAAStatus.Unknown.ToString())
        //    HIPAAStatus = (short)HealthYes.Web.Core.Enum.HIPAAStatus.Unknown;

        masterDal.SetHIPAAStatus(eventcustomerid, status);
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetCouponsByPrefixText(string prefixText)
    {
        var sourceCodeRepository = IoC.Resolve<ISourceCodeRepository>();
        return sourceCodeRepository.SearchSourceCodeByName(prefixText).Select(coupon => coupon.CouponCode + "[" + "ID:" + coupon.Id.ToString() + "]").ToList();
    }

    [WebMethod(EnableSession = true)]
    public List<ComboBoxPair> GetCouponsListByPrefixText(string prefixText)
    {
        var sourceCodeRepository = IoC.Resolve<ISourceCodeRepository>();
        return sourceCodeRepository.SearchSourceCodeByName(prefixText).Select(coupon => new ComboBoxPair { value = coupon.Id.ToString(), text = coupon.CouponCode }).ToList();
    }

    //Refactored to GetCouponsByPrefixText
    // TODO: Remove.
    [WebMethod(EnableSession = true)]
    public string[] GetMatchingCoupons(string prefixText, int count)
    {
        return GetCouponsByPrefixText(prefixText).ToArray();

    }
    [WebMethod(EnableSession = true)]
    public string[] GetMatchingCoupons_nonSSL(string prefixText, int count)
    {
        return GetCouponsByPrefixText(prefixText).ToArray();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetMatchingFranchisee(string prefixText, int count)
    {
        List<string> items = new List<string>();

        var marketParternerDal = new MarketingPartnerDAL();
        EFranchisee[] objFranchisee = marketParternerDal.SearchFranchisee(prefixText).ToArray();
        foreach (EFranchisee eFranchisee in objFranchisee)
        {
            items.Add(eFranchisee.Name + "[" + "ID:" + eFranchisee.FranchiseeID + "]");
        }
        return items.ToArray();

    }
    [WebMethod(EnableSession = true)]
    public string[] GetMatchingFranchisee_nonSSL(string prefixText, int count)
    {
        return GetMatchingFranchisee(prefixText, count);
    }

    [WebMethod(EnableSession = true)]
    public string GetAffiliateUserCategory(Int64 affiliateUserId)
    {
        var marketParternerDal = new MarketingPartnerDAL();

        string strCategory = marketParternerDal.GetAffiliateUserCategory(affiliateUserId);
        return strCategory;
    }

    // Refactored from GetMatchingMarketingSource
    [WebMethod(EnableSession = true)]
    public List<ComboBoxPair> GetMarketingSourceByPrefixText(string prefixText)
    {
        var otherDal = new OtherDAL();
        return otherDal.GetMarketingSource(string.Empty, 3).Where(eMarketingSource => eMarketingSource.Label.ToLower().Contains(prefixText.ToLower())).Select(marketingSource => new ComboBoxPair() { text = marketingSource.Label, value = marketingSource.MarketingSourceID.ToString() }).ToList();
    }

    [WebMethod(EnableSession = true)]
    public bool CheckUserNameAvailability(string userName, string userId)
    {
        //var repository = IoC.Resolve<IUserRepository<Customer>>();
        //long checkUserId = 0;
        //long.TryParse(userId.Trim(), out checkUserId);
        //if (checkUserId == 0)
        //    return !repository.UserNameExists(userName);
        //else
        //    return !repository.UserNameExists(checkUserId, userName);

        var otherDal = new OtherDAL();
        return otherDal.CheckUniqueUserName(userName, Convert.ToInt64(userId));
    }
    [WebMethod(EnableSession = true)]
    public bool CheckUserNameAvailability_nonSSL(string userName, string userId)
    {
        //var repository = IoC.Resolve<IUserRepository<Customer>>();
        //long checkUserId = 0;
        //long.TryParse(userId.Trim(), out checkUserId);
        //if (checkUserId == 0)
        //    return !repository.UserNameExists(userName);
        //else
        //    return !repository.UserNameExists(checkUserId, userName);

        var otherDal = new OtherDAL();
        return otherDal.CheckUniqueUserName(userName, Convert.ToInt64(userId));
    }

    [WebMethod(EnableSession = true)]
    public Int64 SaveProspectCustomerData(string prospectCustomerId, string fieldName, string value)
    {
        OtherDAL otherDal = new OtherDAL();
        long savedProspectCustomerId = otherDal.SaveProspectCustomerData(Convert.ToInt32(prospectCustomerId), fieldName, value);

        // If this is a new prospect customer, track this conversion.
        if (prospectCustomerId.Equals("0"))
        {
            long clickId = 0;

            HttpCookie clickIdCookie = Context.Request.Cookies["advertiserClick"];
            if (clickIdCookie != null)
            {
                long.TryParse(clickIdCookie.Value, out clickId);
            }

            // if there's a click ID, save which click caused the conversion to a prospective customer, and their prospect ID
            if (clickId > 0)
            {
                IClickConversionRepository ccr = new ClickConversionRepository();
                ccr.SaveProspectConversion(clickId, savedProspectCustomerId);
            }
        }

        return savedProspectCustomerId;
    }

    // Refactor from GetProspectListByName
    [WebMethod(EnableSession = true)]
    public List<string> GetProspectsByPrefixText(string prefixText)
    {
        FranchisorDAL franchisorDal = new FranchisorDAL();
        return franchisorDal.GetUserHost(prefixText, 0, 0, 0, 2).Select<EProspect, string>(eProspect => "HOST: " + eProspect.OrganizationName + " [ID:" + eProspect.ProspectID + "]").ToList<string>();
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetHostByPrefixText(string prefixText)
    {
        var hostRepository = IoC.Resolve<IHostRepository>();
        var prospects = hostRepository.SearchHostByName(prefixText);
        return prospects.Select(prospect => prospect.OrganizationName + " [ID:" + prospect.Id + "]").ToList();
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetProspectByPrefixText(string prefixText)
    {
        var hostRepository = IoC.Resolve<IHostRepository>();
        var prospects = hostRepository.SearchProspectByName(prefixText);
        return prospects.Select(prospect => prospect.OrganizationName + " [ID:" + prospect.Id + "]").ToList();
    }

    [WebMethod(EnableSession = true)]
    public Boolean VerifySourceCode(string sourceCode)
    {
        var callcenterDal = new CallCenterDAL();
        return callcenterDal.VerifySourceCode(sourceCode);
    }

    [WebMethod(EnableSession = true)]
    public Boolean AcceptOrder(string OrderID, string UserID, string RoleID)
    {
        OtherDAL otherDal = new OtherDAL();
        return otherDal.AcceptOrder(OrderID, UserID, RoleID);
    }
    [WebMethod(EnableSession = true)]
    public bool CheckUserNameAvailabilityForAdvocate(string userName, string userId)
    {
        OtherDAL otherDal = new OtherDAL();
        return otherDal.CheckUniqueUserName(userName, Convert.ToInt64(userId));
    }
    [WebMethod(EnableSession = true)]
    public bool CheckUserNameAvailabilityForAdvocate_nonSSL(string userName, string userId)
    {
        OtherDAL otherDal = new OtherDAL();
        return otherDal.CheckUniqueUserName(userName, Convert.ToInt64(userId));
    }

    // Refactored from GetMatchingFranchiseeUser
    [WebMethod(EnableSession = true)]
    public List<string> GetFranchiseeByPrefixTextAndContextKey(string prefixText, string contextKey)
    {
        FranchiseeDAL franchiseeDal = new FranchiseeDAL();
        return franchiseeDal.GetSimilarFranchiseeFranchiseeUser(prefixText, 0, Convert.ToInt32(contextKey)).Select<EFranchiseeFranchiseeUser, string>(eUser => eUser.FranchiseeUser.User.FirstName + " [ID:" + eUser.FranchiseeFranchiseeUserID + "]").ToList<string>();
    }


    [WebMethod(EnableSession = true)]
    public string[] GetMatchingFranchiseeUserList(string prefixText, int count, string contextKey)
    {
        List<string> items = new List<string>();

        FranchiseeDAL franchiseeDal = new FranchiseeDAL();

        Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser[] objFfu = franchiseeDal.GetMatchingFranchiseeUserList(prefixText, 1, Convert.ToInt32(contextKey)).ToArray();

        foreach (Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser objEffu in objFfu)
        {
            items.Add(objEffu.FranchiseeUser.User.FirstName + " [ID:" + objEffu.FranchiseeFranchiseeUserID + "]");
        }
        return items.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetMatchingFranchiseeUserListSalesRep(string prefixText, int count, string contextKey)
    {
        List<string> items = new List<string>();
        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService objFFUService = new HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService();
        // remove service references
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();

        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.EFranchiseeFranchiseeUser[] objFFU = objFFUService.GetMatchingFranchiseeUserListSalesRep(prefixText, Convert.ToInt32(contextKey), true);
        List<Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser> objFFU = franchiseeDAL.GetMatchingFranchiseeUserList(prefixText, 0, Convert.ToInt32(contextKey));



        foreach (Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser objEFFU in objFFU)
        {
            items.Add(objEFFU.FranchiseeUser.User.FirstName + " [ID:" + objEFFU.FranchiseeFranchiseeUserID + "]");
        }
        return items.ToArray();
    }

    // Refactored from GetMatchingZipCode
    [WebMethod(EnableSession = true)]
    public List<string> GetZipCodeByPrefixText(string prefixText)
    {
        var otherDal = new OtherDAL();
        return otherDal.GetSimilarZipCode(prefixText, 0).Select<EZip, string>(eZip => eZip.ZipCode).ToList<string>();
    }

    [WebMethod(EnableSession = true)]
    public Int64 UpdateAdvocateSalesManagerTeam(Int64 intAdvocateSalesManagerId, Int64 intSalesrepId, Boolean bolStatus)
    {
        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService objFFUserService = new HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService();
        // remove service references
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();

        Int64 retrurnvalue = new Int64();
        //objFFUserService.UpdateAdvocateSalesManagerTeam(intAdvocateSalesManagerId, true, intSalesrepId, true, bolStatus, true, out  retrurnvalue, out temp);
        franchiseeDAL.UpdateAdvocateSalesManagerTeam(intAdvocateSalesManagerId, intSalesrepId, bolStatus);
        return retrurnvalue;
    }

    [WebMethod(EnableSession = true)]
    public Int64 UpdateAdvocateSalesManagerTeam_nonSSL(Int64 intAdvocateSalesManagerId, Int64 intSalesrepId, Boolean bolStatus)
    {
        //HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService objFFUserService = new HealthYes.Web.UI.FranchiseeFranchiseeUserService.FranchiseeFranchiseeUserService();
        // remove service references
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();

        Int64 retrurnvalue = new Int64();
        //objFFUserService.UpdateAdvocateSalesManagerTeam(intAdvocateSalesManagerId, true, intSalesrepId, true, bolStatus, true, out  retrurnvalue, out temp);
        franchiseeDAL.UpdateAdvocateSalesManagerTeam(intAdvocateSalesManagerId, intSalesrepId, bolStatus);
        return retrurnvalue;
    }

    [WebMethod(EnableSession = true)]
    public Int64 ChangeAffiliateApprovedStatus(Int32 AffiliateId, Int16 activate)
    {
        bool status = activate == 0 ? false : true;
        var marketingPartnerDal = new MarketingPartnerDAL();
        marketingPartnerDal.ChangeAffiliateApprovedStatus(status, AffiliateId);
        return 1;
    }

    [WebMethod(EnableSession = true)]
    public string DeleteFranchiseeTerritory(string territoryid)
    {
        bool result;
        FranchisorDAL objFranchisorDal = new FranchisorDAL();
        //mode - 0 for delete territory
        result = objFranchisorDal.DeleteTerritory(territoryid, 0);
        return result.ToString();
    }

    [WebMethod(EnableSession = true)]
    public bool SaveProspectNotes(string notes, string prospectid)
    {
        bool result;
        FranchisorDAL objFranchisorDal = new FranchisorDAL();
        result = objFranchisorDal.SaveProspectNotes(notes, Convert.ToInt32(prospectid));
        return result;
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetFranchiseeByPrefixText(string prefixText)
    {
        var marketingPartnerDal = new MarketingPartnerDAL();
        return marketingPartnerDal.SearchFranchisee(prefixText).Select<EFranchisee, string>(eFranchisee => eFranchisee.Name + "[" + "ID:" + eFranchisee.FranchiseeID.ToString() + "]").ToList<string>();
    }

    // Refactored to GetFranchiseeByPrefixText
    // TODO: Remove.
    [WebMethod(EnableSession = true)]
    public string[] GetSimilarFranchisee(string prefixText, int count)
    {
        List<string> items = new List<string>();
        var marketingPartnerDal = new MarketingPartnerDAL();
        Falcon.Entity.Franchisee.EFranchisee[] objFranchisee = marketingPartnerDal.SearchFranchisee(prefixText).ToArray();//service.SearchFranchisee(prefixText);
        foreach (Falcon.Entity.Franchisee.EFranchisee eFranchisee in objFranchisee)
        {
            items.Add(eFranchisee.Name + "[" + "ID:" + eFranchisee.FranchiseeID.ToString() + "]");
        }
        return items.ToArray();

    }


    [WebMethod(EnableSession = true)]
    public string[] GetAllZipCodesByStateID(string stateid)
    {
        OtherDAL otherDal = new OtherDAL();
        EZip[] objZip = otherDal.GetSimilarZipCode(stateid, 1).ToArray();
        List<string> items = new List<string>(objZip.Length);
        foreach (EZip objEZip in objZip)
        {
            items.Add(objEZip.ZipCode);
        }
        return items.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetSimilarZipCodeByDistance(string zipcode, string distance)
    {
        OtherDAL otherDal = new OtherDAL();
        EZip[] objZip = otherDal.GetSimilarZipCodeByDistance(zipcode, distance, 2).ToArray();
        List<string> items = new List<string>(objZip.Length);
        foreach (EZip objEZip in objZip)
        {
            items.Add(objEZip.ZipCode);
        }
        return items.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetAllZipCodesByTerritory(string territoryid)
    {
        FranchisorDAL objFranchisorDal = new FranchisorDAL();
        string[] items = objFranchisorDal.GetAllZipCodesByTerritory(territoryid);
        return items;
    }

    [WebMethod(EnableSession = true)]
    public string[] GetUnAssignedCodesByTerritory(string territoryid)
    {
        //HealthYes.Web.UI.FranchisorService.FranchisorService objFranchiorService = new HealthYes.Web.UI.FranchisorService.FranchisorService();
        //string[] items = objFranchiorService.GetUnAssignedCodesByTerritory(territoryid);
        FranchisorDAL objFranchisorDal = new FranchisorDAL();
        string[] items = objFranchisorDal.GetUnAssignedCodesByTerritory(territoryid);
        return items;
    }

    [WebMethod(EnableSession = true)]
    public bool ForceChangePassword(string userid)
    {
        var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
        userLoginRepository.ForceUserToChangePassword(Convert.ToInt32(userid));
        return true;
    }

    [WebMethod(EnableSession = true)]
    public bool ForceSecurityQuesChange(string userid)
    {
        var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
        userLoginRepository.ForceUserToChangeQuestion(Convert.ToInt32(userid));

        return true;
    }

    [WebMethod(EnableSession = true)]
    public bool UnlockUser(string userid)
    {
        var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
        userLoginRepository.ReleaseUserLoginLock(Convert.ToInt32(userid));
        return true;
    }

    [WebMethod(EnableSession = true)]
    public bool ReGenrateCustomerReportPDF(long eventId, long customerId)
    {
        var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
        var orgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

        var returnResult = eventCustomerResultRepository.SetRecordforRegeneratingResultPacket(eventId, customerId, orgRoleUserId);
        return returnResult;
    }


    // Refactored from GetMatchingMarketingOffers
    [WebMethod(EnableSession = true)]
    public List<string> GetMatchingMarketingOffers(string prefixText)
    {
        MasterDAL masterDal = new MasterDAL();
        int icount = 0;
        return masterDal.GetMarketingOfferPaged(prefixText, 2, 1, 50, out icount).Select<EMarketingOffer, string>(marketingOffer => marketingOffer.MarketingOffer + " [" + marketingOffer.MarketingOfferID + "]").ToList<string>();
    }

    [WebMethod(EnableSession = true)]
    public string[] GetMatchingMarketingOffers_nonSSL(string prefixText, int count)
    {
        List<string> items = new List<string>();
        //HealthYes.Web.UI.CouponService.CouponService objCService = new HealthYes.Web.UI.CouponService.CouponService();
        // remove services references
        Falcon.DataAccess.Master.MasterDAL objDAL = new Falcon.DataAccess.Master.MasterDAL();

        int icount = 0;
        //HealthYes.Web.UI.CouponService.EMarketingOffer[] objMarketingOffers = objCService.GetMarketingOfferByName(prefixText, 1, true, 50, true, out icount, out bolIcountSpecefied);
        List<Falcon.Entity.Other.EMarketingOffer> objMarketingOffers = objDAL.GetMarketingOfferPaged(prefixText, 2, 1, 50, out icount);
        try
        {
            string strOffer = string.Empty;


            foreach (Falcon.Entity.Other.EMarketingOffer objMarketingOffer in objMarketingOffers)
            {

                strOffer = objMarketingOffer.MarketingOffer + " [" + objMarketingOffer.MarketingOfferID + "]";
                items.Add(strOffer);

            }
        }
        catch (Exception ex)
        {
            items.Add(ex.Message);
        }
        return items.ToArray();

    }

    // Refactored from GetUsers
    [WebMethod(EnableSession = true)]
    public List<string> GetUsersByPrefixText(string prefixText)
    {
        var franchisorDal = new FranchisorDAL();
        return franchisorDal.GetUsers(prefixText, 1).Select<EUser, string>(eUser => eUser.FirstName + " [" + eUser.UserID.ToString() + "]").ToList<string>();
    }

    [WebMethod(EnableSession = true)]
    public List<EPaymentDetail> GetCustomerEventPaymentDetail(long eventCustomerId)
    {
        var masterDal = new MasterDAL();
        List<EPaymentDetail> arrpaymentdet = masterDal.GetPaymentDetailsforEventCustomerList(eventCustomerId);
        return arrpaymentdet;
    }
    //TODo: RollBack the function written in repostory as the entity is not updated.
    [WebMethod(EnableSession = true)]
    public String GetCcRepInstruction(long eventId)
    {
        var masterDal = new MasterDAL();
        var strCcRepInstruction = masterDal.getCCRepInstructionForEvent(eventId);
        return strCcRepInstruction;
    }
    [WebMethod(EnableSession = true)]
    public EProspect GetProspectByID(Int64 HostId)
    {
        FranchisorDAL objDAL = new FranchisorDAL();
        var listProspect = objDAL.GetHostDetails(HostId.ToString(), 1);

        return listProspect[0];
    }


    [WebMethod(EnableSession = true)]
    public List<string> GetEventHostbyprefixText(string prefixText)
    {
        var repository = IoC.Resolve<IHostRepository>();
        return repository.GetScreenedEventHostNames(prefixText).ToList();
    }

    [WebMethod(EnableSession = true)]
    public IEnumerable<string> FetchMarketingSourceByTerritory(string prefixText, string contextKey)
    {
        var marketingSources = IoC.Resolve<IMarketingSourceService>().FetchMarketingSourceByZip(contextKey);
        if (marketingSources.Where(ms => ms.ToLower().Contains(prefixText.ToLower())).Count() > 0)
            return marketingSources.Where(ms => ms.ToLower().Contains(prefixText.ToLower())).ToArray();
        return marketingSources;
    }


}

