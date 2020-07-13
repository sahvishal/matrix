using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Infrastructure.Repositories.Host;
using Falcon.App.DependencyResolution;

namespace HealthYes.Web.App.Franchisee.Technician
{
    public partial class EndOfDayProcess : Page
    {
        public long EventId { get { return Convert.ToInt64(Request.QueryString["EventID"]); } }

        public long HostId
        {
            get
            {
                if (ViewState["HostId"] == null) ViewState["HostId"] = 0;
                return Convert.ToInt64(ViewState["HostId"]);
            }
            set { ViewState["HostId"] = value; }
        }

        private bool ScreenForHostRanking
        {
            get
            {
                if (ViewState["ForHostRanking"] == null) ViewState["ForHostRanking"] = false;
                return Convert.ToBoolean(ViewState["ForHostRanking"]);
            }
            set { ViewState["ForHostRanking"] = value; }
        }

        private bool MarkedLaterForHostRanking
        {
            get
            {
                if (ViewState["MarkedLaterForHostRanking"] == null) ViewState["MarkedLaterForHostRanking"] = false;
                return Convert.ToBoolean(ViewState["MarkedLaterForHostRanking"]);
            }
            set { ViewState["MarkedLaterForHostRanking"] = value; }
        }

        public string HostName
        {
            get
            {
                if (ViewState["HostName"] == null) ViewState["HostName"] = "";
                return Convert.ToString(ViewState["HostName"]);
            }
            set { ViewState["HostName"] = value; }
        }

        readonly string _physicalPath = IoC.Resolve<IMediaRepository>().GethHostImageMediaLocation().PhysicalPath;
        readonly string _virtualPath = IoC.Resolve<IMediaRepository>().GethHostImageMediaLocation().Url;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "End of Day Listing";
            if (!IsPostBack)
            {
                IHostRepository hostRepository = new HostRepository();
                var host = hostRepository.GetHostForEvent(EventId);

                HostId = host.Id;
                HostName = host.OrganizationName + ", " + host.Address.State;

                MarkedLaterForHostRanking = false;
                ScreenForHostRanking = false;
                if (Request.QueryString["HostRanking"] != null)
                {
                    this.Title = "Update Host Ranking";
                    _divSignoffCompleted.Style[HtmlTextWriterStyle.Display] = "none";
                    ScreenForHostRanking = true;
                    LinksEodDiv.Style[HtmlTextWriterStyle.Display] = "none";
                    OpenHostRankingInputBox();
                }
                //else if (Request.QueryString["EventID"] != null)
                //{
                //    FetchList(EventId);

                //    if (Request.QueryString["EventName"] == null)
                //    {
                //        MasterDAL masterDal = new MasterDAL();
                //        EEvent objEvent = masterDal.GetEvent(Request.QueryString["EventID"], "2").FirstOrDefault<EEvent>();
                //        spEventName.InnerHtml = HttpUtility.HtmlEncode(objEvent.Name);
                //    }
                //    else
                //        spEventName.InnerHtml = HttpUtility.HtmlEncode(Request.QueryString["EventName"]);
                //}
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventId"></param>
        private void FetchList(Int64 eventId)
        {
            bool _blnTechTeamConfigured = false;
            bool _blnSignoff = false;
            var ObjMasterDal = new MasterDAL();
            List<EEndOfDayInfo> lstEndOfDay = ObjMasterDal.GetEndofDayListing(eventId, out _blnTechTeamConfigured, out _blnSignoff);

            if (lstEndOfDay == null)
            {
                divCustomerList.InnerHtml = "No customers registered for this event.";
                divCustomerList.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }
            if (!_blnTechTeamConfigured)
            {
                _divTechTeam.Style.Add(HtmlTextWriterStyle.Display, "block");
            }

            var isHostRated = new HostFacilityRankingRepository().IsHostRatedByTechnician(HostId, EventId);

            // if customer info is missing
            if (lstEndOfDay.Count > 0 && (!string.IsNullOrEmpty(lstEndOfDay[0].FirstName)))
            {
                System.Text.StringBuilder sbList = new System.Text.StringBuilder();
                sbList.Append("");

                foreach (EEndOfDayInfo objEndOfDayinfo in lstEndOfDay)
                {
                    string CustomerHeading = "";
                    string strCustomerInfoPoints = "";

                    CustomerHeading = "<div class=\"left\" id=\"Customer1\"><div class=\"row\"> <span class=\"orngbold14_default\">" + objEndOfDayinfo.FirstName +
                                        (objEndOfDayinfo.MiddleName.Trim().Length > 1 ? " " + objEndOfDayinfo.MiddleName.Trim() + " " : " ") +
                                        objEndOfDayinfo.LastName + "&nbsp;(" + objEndOfDayinfo.CustomerID + ")&nbsp;</span> &nbsp; &nbsp; &nbsp; <span><b> [" + objEndOfDayinfo.AppointmentTime + "]</b></span> </div>";

                    if (!objEndOfDayinfo.DOB || !objEndOfDayinfo.Phone || !objEndOfDayinfo.Gender || !objEndOfDayinfo.Race ||
                        !objEndOfDayinfo.Height || !objEndOfDayinfo.Weight || !objEndOfDayinfo.PCP || (objEndOfDayinfo.FirstName.Trim().Length < 1)
                        || (objEndOfDayinfo.LastName.Trim().Length < 1) || !objEndOfDayinfo.City || !objEndOfDayinfo.State || !objEndOfDayinfo.Zip)
                    {
                        string strCustomerInfo = string.Empty;

                        // customer info
                        if (objEndOfDayinfo.FirstName.Trim().Length < 1) strCustomerInfo += "First Name, ";
                        if (objEndOfDayinfo.LastName.Trim().Length < 1) strCustomerInfo += "Last Name, ";

                        if (!objEndOfDayinfo.City) strCustomerInfo += "City, ";
                        if (!objEndOfDayinfo.State) strCustomerInfo += "State, ";
                        if (!objEndOfDayinfo.Zip) strCustomerInfo += "Zip, ";

                        if (!objEndOfDayinfo.DOB) strCustomerInfo += "Date of Birth, ";
                        if (!objEndOfDayinfo.Phone) strCustomerInfo += "Phone, ";
                        if (!objEndOfDayinfo.Height) strCustomerInfo += "Height, ";
                        if (!objEndOfDayinfo.Weight) strCustomerInfo += "Weight, ";
                        if (!objEndOfDayinfo.Gender) strCustomerInfo += "Gender, ";
                        if (!objEndOfDayinfo.Race) strCustomerInfo += "Race, ";

                        // add if customer info not empty
                        if (!string.IsNullOrEmpty(strCustomerInfo))
                        {
                            strCustomerInfo = strCustomerInfo.Trim();
                            if (strCustomerInfo.LastIndexOf(',') == strCustomerInfo.Length - 1)
                            {
                                strCustomerInfo = strCustomerInfo.Remove(strCustomerInfo.Length - 1, 1);
                            }

                            strCustomerInfo = "<li>Customer Info " + strCustomerInfo + "</li>";
                        }
                        strCustomerInfoPoints = strCustomerInfo;

                        // PCP Info
                        //if (!objEndOfDayinfo.PCP) strCustomerInfoPoints += "<li> PCP </li>";
                    }

                    if ((objEndOfDayinfo.HIPAAStatus == (short)RegulatoryState.Unknown))
                    {
                        strCustomerInfoPoints += "<li>HIPAA Form </li>";
                    }
                    // medical history
                    if (!objEndOfDayinfo.MedicalHistory)
                    {
                        strCustomerInfoPoints += "<li>Health Assessment</li>";
                    }
                    // event info
                    if (!objEndOfDayinfo.EndTime || !objEndOfDayinfo.StartTime || !objEndOfDayinfo.AAAInfo || !objEndOfDayinfo.StrokeInfo || !objEndOfDayinfo.PaymentInfo || (IoC.Resolve<ISettings>().IsAuthorizationRequired && !objEndOfDayinfo.IsAuthorized))
                    {
                        if (!objEndOfDayinfo.PaymentInfo) strCustomerInfoPoints += "<li> Payment </li>";
                        if (IoC.Resolve<ISettings>().IsAuthorizationRequired && !objEndOfDayinfo.IsAuthorized) strCustomerInfoPoints += "<li> Authorization </li>";
                        if (!objEndOfDayinfo.StartTime) strCustomerInfoPoints += "<li> Check-in time </li>";
                        if (!objEndOfDayinfo.EndTime) strCustomerInfoPoints += "<li> Check-out time </li>";
                        //if (!objEndOfDayinfo.AAAInfo) strCustomerInfoPoints += "<li> AAA Required data </li>";
                        //if (!objEndOfDayinfo.StrokeInfo) strCustomerInfoPoints += "<li> Stroke Required data </li>";
                    }
                    if (!string.IsNullOrEmpty(strCustomerInfoPoints))
                    {
                        strCustomerInfoPoints = "<div class=\"row\"><div class=\"leftprt_row\"><ul>" + strCustomerInfoPoints + "</ul>";
                        strCustomerInfoPoints = strCustomerInfoPoints + "</div></div></div>";
                        sbList.Append(CustomerHeading + strCustomerInfoPoints);
                    }

                    divCustomerList.InnerHtml = sbList.ToString();
                    divCustomerList.Style.Add(HtmlTextWriterStyle.Display, "block");
                    _divLoginInfo.Style.Add(HtmlTextWriterStyle.Display, "none");
                    _divSignoffInfo.Style.Add(HtmlTextWriterStyle.Display, "none");
                    _divSignoffCompleted.Style.Add(HtmlTextWriterStyle.Display, "none");

                }
                // if the signoff completed and customer register after signoff
                if (lstEndOfDay.Count > 0)
                {
                    if (lstEndOfDay[0].SignoffByUserId > 0 && (!string.IsNullOrEmpty(lstEndOfDay[0].SignoffBy)))
                    {
                        _lblSignoffBy.InnerHtml = lstEndOfDay[0].SignoffBy;
                        if (!string.IsNullOrEmpty(lstEndOfDay[0].SignoffDatetime))
                        {
                            _lblSignoffDatetime.InnerText = lstEndOfDay[0].SignoffDatetime;
                        }
                        _divSignoffInfo.Style.Add(HtmlTextWriterStyle.Display, "block");
                        _divLoginInfo.Style.Add(HtmlTextWriterStyle.Display, "none");
                        _divCustomerRegisterAfterSignoff.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }
                }
            }
            else if (!isHostRated && !MarkedLaterForHostRanking)
            {
                OpenHostRankingInputBox();
            }
            // when customer info completed but not signoff
            else if (lstEndOfDay != null && lstEndOfDay.Count == 1 && _blnSignoff == false)
            {
                _divLoginInfo.Style.Add(HtmlTextWriterStyle.Display, "block");
                this.form1.DefaultButton = "_ibtnSignoff";


                divCustomerList.Style.Add(HtmlTextWriterStyle.Display, "none");
                _divSignoffInfo.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            // when customer has signoff sucessfully.
            else if (_blnSignoff)
            {
                if (lstEndOfDay != null && lstEndOfDay.Count > 0 && lstEndOfDay[0].SignoffByUserId > 0)
                {
                    _lblSignoffBy.InnerHtml = lstEndOfDay[0].SignoffBy;
                    if (!string.IsNullOrEmpty(lstEndOfDay[0].SignoffDatetime))
                        _lblSignoffDatetime.InnerText = lstEndOfDay[0].SignoffDatetime;
                    _divSignoffInfo.Style.Add(HtmlTextWriterStyle.Display, "block");
                    _divLoginInfo.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divCustomerList.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
            }
        }

        //protected void lnkRefresh_Click(object sender, EventArgs e)
        //{
        //    if (Request.QueryString["EventID"] != null)
        //    {
        //        HostRankingDiv.Style[HtmlTextWriterStyle.Display] = "none";
        //        FetchList(EventId);
        //    }
        //}


        protected void _ibtnSignoff_Click(object sender, ImageClickEventArgs e)
        {

        }

        #region "Host Ranking Code"

        protected void UpdateHostRanking_Click(object sender, EventArgs e)
        {
            OpenHostRankingInputBox();
        }

        protected void DoItLaterLink_Click(object sender, EventArgs e)
        {

            if (ScreenForHostRanking)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "jsCloseWindow", " window.close(); ", true);
            }
            //else
            //{
            //    HostRankingDiv.Style[HtmlTextWriterStyle.Display] = "none";
            //    MarkedLaterForHostRanking = true;
            //    if (Request.QueryString["EventID"] != null)
            //    {
            //        FetchList(EventId);
            //    }
            //}
        }

        private void OpenHostRankingInputBox()
        {
            HostRankingDiv.Style[HtmlTextWriterStyle.Display] = "block";

            HostRankingDropDown.DataTextField = "Name";
            HostRankingDropDown.DataValueField = "PersistenceLayerId";

            HostRankingDropDown.DataSource = HostViabilityRanking.HostRankings;
            HostRankingDropDown.DataBind();

            HostRankingDropDown.Items.Insert(0, new ListItem("Select Rank", "0"));

            var isHostRated = new HostFacilityRankingRepository().IsHostRatedByTechnician(HostId, EventId);
            if (isHostRated)
            {
                var hostFacilityRanking = new HostFacilityRankingService().GetHostFacilityRankingByTechnician(HostId);
                if (hostFacilityRanking != null)
                {
                    if (hostFacilityRanking.Ranking != null)
                    {
                        var listItem = HostRankingDropDown.Items.FindByValue(hostFacilityRanking.Ranking.PersistenceLayerId.ToString());
                        if (listItem != null) listItem.Selected = true;
                    }

                    if (!string.IsNullOrEmpty(hostFacilityRanking.Notes))
                        CommentsForHostRankingInputBox.Text = hostFacilityRanking.Notes;
                }
            }

            _divLoginInfo.Style.Add(HtmlTextWriterStyle.Display, "none");
            divCustomerList.Style.Add(HtmlTextWriterStyle.Display, "none");
            _divCustomerRegisterAfterSignoff.Style.Add(HtmlTextWriterStyle.Display, "none");
            _divSignoffCompleted.Style.Add(HtmlTextWriterStyle.Display, "none");
            this.form1.DefaultButton = "SaveButton";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            IHostFacilityRankingService _hostFacilityRankingService = new HostFacilityRankingService();

            var isHostRated = new HostFacilityRankingRepository().IsHostRatedByTechnician(HostId, EventId);

            var hostFacilityViability = new HostFacilityViability();

            hostFacilityViability.HostId = HostId;
            hostFacilityViability.Notes = CommentsForHostRankingInputBox.Text;
            hostFacilityViability.Ranking = HostViabilityRanking.HostRankings.Find(ranking => ranking.PersistenceLayerId == Convert.ToInt32(HostRankingDropDown.SelectedItem.Value));
            hostFacilityViability.CreatedOn = DateTime.Now;

            var organizationRoleUser = IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                        IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                        IoC.Resolve<ISessionContext>().UserSession.UserId);

            hostFacilityViability.CreatedBy = organizationRoleUser;

            if (isHostRated == true)
            {
                var hostFacilityRankingByTechnician = _hostFacilityRankingService.GetHostFacilityRankingByTechnician(HostId);
                if (hostFacilityRankingByTechnician != null)
                    hostFacilityViability.Id = hostFacilityRankingByTechnician.Id;
            }

            _hostFacilityRankingService.SaveHostFacilityRanking(hostFacilityViability);
            SaveHostImages(organizationRoleUser);

            IHostFacilityRankingRepository hostFacilityRepository = new HostFacilityRankingRepository();
            hostFacilityRepository.SetIsHostRatedFlagOn(HostId, EventId);

            if (ScreenForHostRanking)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "jsCloseWindow", " window.close(); ", true);
            }
            //else
            //{
            //    FetchList(EventId);
            //    HostRankingDiv.Style[HtmlTextWriterStyle.Display] = "none";
            //}
        }

        private int UploadHostImage(FileUpload fileUploader, int counter, List<HostImage> hostImages)
        {
            if (fileUploader.FileName.Trim().Length < 1)
                return counter;

            var hostImage = new HostImage(0);
            string savePath_Physical = _physicalPath;
            string savePath_Virtual = _virtualPath;

            string fileExtension = new System.IO.FileInfo(fileUploader.FileName).Extension;
            string fileName = "HostImage_" + DateTime.Now.ToFileTimeUtc() + counter + fileExtension;

            fileUploader.SaveAs(savePath_Physical + "\\" + fileName);

            hostImage.Path = savePath_Virtual + "/" + fileName;
            hostImage.FileSize = (decimal)fileUploader.FileBytes.Length / 1024;
            hostImage.ImageType = HostImageType.HostInfrastructure;
            hostImage.Title = fileName;
            hostImage.Type = FileType.Image;

            hostImages.Add(hostImage);

            return counter + 1;
        }

        private void SaveHostImages(OrganizationRoleUser organizationRoleUser)
        {
            var hostImagesToSave = new List<HostImage>();

            int counter = 1;

            counter = UploadHostImage(HostImageUploader1, counter, hostImagesToSave);
            counter = UploadHostImage(HostImageUploader2, counter, hostImagesToSave);
            counter = UploadHostImage(HostImageUploader3, counter, hostImagesToSave);
            counter = UploadHostImage(HostImageUploader4, counter, hostImagesToSave);
            counter = UploadHostImage(HostImageUploader5, counter, hostImagesToSave);

            hostImagesToSave.ForEach(hostImage =>
            {
                hostImage.UploadedBy = organizationRoleUser;
                hostImage.UploadedOn = DateTime.Now;
            });

            IHostRepository hostRepository = new HostRepository();

            if (hostImagesToSave.Count > 0)
                hostRepository.SaveHostImages(HostId, hostImagesToSave);
        }



        #endregion

    }
}
