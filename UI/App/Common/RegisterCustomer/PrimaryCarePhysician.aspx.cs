using System;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.App.Core.Scheduling.Interfaces;

public partial class App_Common_RegisterCustomer_PrimaryCarePhysician : Page
{
    private string GuId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
        }
    }

    private RegistrationFlowModel RegistrationFlow
    {
        get
        {
            if (!string.IsNullOrEmpty(GuId))
            {
                return Session[GuId] as RegistrationFlowModel;
            }
            return null;
        }
    }

    private long CustomerId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
        }
    }

    private long EventId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "Add Primary Care Physician";
        var obj = (Franchisee_Technician_TechnicianMaster)this.Master;

        obj.SetBreadcrumb = "<a href=\"/App/Franchisee/Technician/HomePage.aspx\">Dashboard></a>";

        if (Request.QueryString["Customer"] != null && Request.QueryString["Customer"] == "Existing")
        {
            obj.settitle("Existing Customer");
            dvTitle.InnerText = "Add Primary Care Physician";
        }
        else
        {
            imgSymbol.Src = "../../Images/CCRep/page5symbol.gif";
            obj.settitle("Register New Customer");
            dvTitle.InnerText = "Add Primary Care Physician";
        }

        rbtnYes.Attributes["onClick"] = "return ShowdvPCP()";
        rbtnNo.Attributes["onClick"] = "return HidedvPCP()";
        if (rbtnYes.Checked)
        {
            divPcp.Visible = true;
            divPcp.Style["display"] = "block";
        }

        if (!IsPostBack)
        {
            FillPcpInfo();
        }
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        SavePcpDetails();

    }

    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["Customer"] != null && Request.QueryString["Customer"] == "Existing")
        {
            Response.RedirectUser("BillingInformationRegister.aspx?Customer=Existing" + "&guid=" + GuId);
        }
        else
        {
            Response.RedirectUser("BillingInformationRegister.aspx?guid=" + GuId);
        }
    }

    private bool SavePcpDetails()
    {
        if (rbtnYes.Checked == true)
        {
            try
            {
                var countryRepository = IoC.Resolve<ICountryRepository>();
                var countryId = countryRepository.GetAll().First().Id;

                var primaryCarePhysicianRepository = IoC.Resolve<IPrimaryCarePhysicianRepository>();
                PrimaryCarePhysician pcp = null;

                if (!chkPCPChange.Checked)
                    pcp = primaryCarePhysicianRepository.Get(CustomerId);
                var currentOrganizationRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

                var physicianMasterRepository = IoC.Resolve<IPhysicianMasterRepository>();

                var newPcp = false;

                if (Convert.ToInt64(PhysicianMasterIdHiddenField.Value) > 0)
                {
                    var physicianMaster = physicianMasterRepository.GetById(Convert.ToInt64(PhysicianMasterIdHiddenField.Value));

                    if (pcp == null)
                    {
                        pcp = new PrimaryCarePhysician
                        {
                            Name = new Name(physicianMaster.FirstName, physicianMaster.MiddleName, physicianMaster.LastName),
                            Primary = physicianMaster.PracticePhone,
                            Fax = physicianMaster.PracticeFax,
                            PrefixText = physicianMaster.PrefixText,
                            SuffixText = physicianMaster.SuffixText,
                            CredentialText = physicianMaster.CredentialText,
                            Npi = physicianMaster.Npi,
                            PhysicianMasterId = physicianMaster.Id,
                            CustomerId = CustomerId,
                            DataRecorderMetaData = new DataRecorderMetaData(currentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null)
                        };
                    }
                    else
                    {
                        pcp.Name = new Name(physicianMaster.FirstName, physicianMaster.MiddleName, physicianMaster.LastName);
                        pcp.Primary = physicianMaster.PracticePhone;
                        pcp.Fax = physicianMaster.PracticeFax;
                        pcp.PrefixText = physicianMaster.PrefixText;
                        pcp.SuffixText = physicianMaster.SuffixText;
                        pcp.CredentialText = physicianMaster.CredentialText;
                        pcp.Npi = physicianMaster.Npi;
                        pcp.PhysicianMasterId = physicianMaster.Id;
                        pcp.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentOrganizationRole.OrganizationRoleUserId);
                        pcp.DataRecorderMetaData.DateModified = DateTime.Now;
                    }

                    pcp = UpdatePcpAddressesFromMaster(physicianMaster, pcp);

                }
                else
                {
                    if (pcp == null)
                    {
                        newPcp = true;
                        pcp = new PrimaryCarePhysician
                        {
                            Name = new Name(UCPCPInfo1.FirstName, UCPCPInfo1.MiddleName, UCPCPInfo1.LastName),
                            Primary = string.IsNullOrEmpty(UCPCPInfo1.Phone) ? null : PhoneNumber.Create(UCPCPInfo1.Phone, PhoneNumberType.Home),
                            Secondary = string.IsNullOrEmpty(UCPCPInfo1.AlternatePhone) ? null : PhoneNumber.Create(UCPCPInfo1.AlternatePhone, PhoneNumberType.Office),
                            Fax = string.IsNullOrEmpty(UCPCPInfo1.Fax) ? null : PhoneNumber.Create(UCPCPInfo1.Fax, PhoneNumberType.Unknown),
                            Email = string.IsNullOrEmpty(UCPCPInfo1.Email) ? new Email(string.Empty, string.Empty) : new Email(UCPCPInfo1.Email),
                            SecondaryEmail = string.IsNullOrEmpty(UCPCPInfo1.AlternateEmail) ? new Email(string.Empty, string.Empty) : new Email(UCPCPInfo1.AlternateEmail),
                            Website = UCPCPInfo1.WebsiteUrl,
                            CustomerId = CustomerId,
                            DataRecorderMetaData = new DataRecorderMetaData(currentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null)
                        };
                    }
                    else
                    {
                        pcp.Name = new Name(UCPCPInfo1.FirstName, UCPCPInfo1.MiddleName, UCPCPInfo1.LastName);
                        pcp.Primary = string.IsNullOrEmpty(UCPCPInfo1.Phone) ? null : PhoneNumber.Create(UCPCPInfo1.Phone, PhoneNumberType.Home);
                        pcp.Secondary = string.IsNullOrEmpty(UCPCPInfo1.AlternatePhone) ? null : PhoneNumber.Create(UCPCPInfo1.AlternatePhone, PhoneNumberType.Office);
                        pcp.Fax = string.IsNullOrEmpty(UCPCPInfo1.Fax) ? null : PhoneNumber.Create(UCPCPInfo1.Fax, PhoneNumberType.Unknown);
                        pcp.Email = string.IsNullOrEmpty(UCPCPInfo1.Email) ? new Email(string.Empty, string.Empty) : new Email(UCPCPInfo1.Email);
                        pcp.SecondaryEmail = string.IsNullOrEmpty(UCPCPInfo1.AlternateEmail) ? new Email(string.Empty, string.Empty) : new Email(UCPCPInfo1.AlternateEmail);
                        pcp.Website = UCPCPInfo1.WebsiteUrl;
                        pcp.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentOrganizationRole.OrganizationRoleUserId);
                        pcp.DataRecorderMetaData.DateModified = DateTime.Now;
                    }

                    if (UCPCPInfo1.Address1.Trim().Length > 0 && UCPCPInfo1.State != "0" && UCPCPInfo1.City.Trim().Length > 0 && UCPCPInfo1.Zip.Trim().Length > 0)
                    {
                        long addressId = 0;
                        if (pcp.Address != null)
                            addressId = pcp.Address.Id;

                        pcp.Address = new Address(addressId)
                        {
                            StreetAddressLine1 = UCPCPInfo1.Address1,
                            StreetAddressLine2 = UCPCPInfo1.Address2,
                            City = UCPCPInfo1.City,
                            StateId = Convert.ToInt64(UCPCPInfo1.State),
                            ZipCode = new ZipCode(UCPCPInfo1.Zip),
                            CountryId = countryId
                        };

                    }
                    else
                        pcp.Address = null;

                    SetPcpMaillingAddress(pcp, countryId);
                }

                var isPcpAddressVerified = false;

                if (Convert.ToInt64(PhysicianMasterIdHiddenField.Value) > 0)
                {
                    isPcpAddressVerified = chkVerifiedPcpInfo.Checked;
                }
                else
                {
                    isPcpAddressVerified = UCPCPInfo1.IsPcpAddressVerified;
                }

                pcp.IsPcpAddressVerified = isPcpAddressVerified;
                pcp.PcpAddressVerifiedBy = currentOrganizationRole.OrganizationRoleUserId;
                pcp.PcpAddressVerifiedOn = DateTime.Now;

                pcp = primaryCarePhysicianRepository.Save(pcp);

                if (newPcp && pcp.PhysicianMasterId == null)
                {
                    var physicianMaster = new PhysicianMaster()
                    {
                        LastName = pcp.Name.LastName,
                        FirstName = pcp.Name.FirstName,
                        MiddleName = pcp.Name.MiddleName,
                        PracticePhone = pcp.Primary,
                        PracticeFax = pcp.Fax,
                        IsImported = false,
                        IsActive = true,
                        DateCreated = DateTime.Now,
                        Npi = ""
                    };

                    if (pcp.Address != null)
                    {
                        physicianMaster.PracticeAddress1 = pcp.Address.StreetAddressLine1;
                        physicianMaster.PracticeAddress2 = pcp.Address.StreetAddressLine2;
                        physicianMaster.PracticeCity = pcp.Address.City;
                        physicianMaster.PracticeState = pcp.Address.StateCode;
                        physicianMaster.PracticeZip = pcp.Address.ZipCode.Zip;
                    }


                    if (pcp.MailingAddress != null)
                    {
                        physicianMaster.MailingAddress1 = pcp.MailingAddress.StreetAddressLine1;
                        physicianMaster.MailingAddress2 = pcp.MailingAddress.StreetAddressLine2;
                        physicianMaster.MailingCity = pcp.MailingAddress.City;
                        physicianMaster.MailingState = pcp.MailingAddress.StateCode;
                        physicianMaster.MailingZip = pcp.MailingAddress.ZipCode.Zip;
                    }

                    if (pcp.Address != null && pcp.MailingAddress == null)
                    {
                        physicianMaster.MailingAddress1 = pcp.Address.StreetAddressLine1;
                        physicianMaster.MailingAddress2 = pcp.Address.StreetAddressLine2;
                        physicianMaster.MailingCity = pcp.Address.City;
                        physicianMaster.MailingState = pcp.Address.StateCode;
                        physicianMaster.MailingZip = pcp.Address.ZipCode.Zip;
                    }


                    physicianMaster = physicianMasterRepository.Save(physicianMaster);

                    pcp.PhysicianMasterId = physicianMaster.Id;
                    primaryCarePhysicianRepository.Save(pcp);
                }

                if (EventId > 0)
                {
                    var currentActivePcp = primaryCarePhysicianRepository.Get(CustomerId);
                    var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                    var eventCustomer = eventCustomerRepository.GetRegisteredEventForUser(CustomerId, EventId);

                    if (eventCustomer != null && currentActivePcp != null)
                    {
                        var eventCustomerPrimaryCarePhysicianRepository = IoC.Resolve<IEventCustomerPrimaryCarePhysicianRepository>();
                        var eventCustomerPrimarycarePhysician = new EventCustomerPrimaryCarePhysician
                        {
                            EventCustomerId = eventCustomer.Id,
                            PrimaryCarePhysicianId = currentActivePcp.Id,
                            IsPcpAddressVerified = isPcpAddressVerified,
                            PcpAddressVerifiedOn = DateTime.Now,
                            PcpAddressVerifiedBy = currentOrganizationRole.OrganizationRoleUserId
                        };
                        eventCustomerPrimaryCarePhysicianRepository.Save(eventCustomerPrimarycarePhysician);
                    }
                }

            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "jscodecityvalidate", "alert('" + ex.Message + "');", true);
                return false;
            }
        }


        if (Request.QueryString["Customer"] != null && Request.QueryString["Customer"] == "Existing")
        {
            Response.RedirectUser("../AddNotes.aspx?Customer=Existing" + "&guid=" + GuId);
        }
        else
        {
            Response.RedirectUser("../AddNotes.aspx?guid=" + GuId);
        }
        return true;
    }

    private void FillPcpInfo()
    {
        var primaryCarePhysicianRepository = IoC.Resolve<IPrimaryCarePhysicianRepository>();
        var pcp = primaryCarePhysicianRepository.Get(CustomerId);
        if (pcp != null)
        {
            spanpcpchange.Visible = true;
            var commonCode = new CommonCode();
            UCPCPInfo1.FirstName = pcp.Name.FirstName;
            UCPCPInfo1.MiddleName = pcp.Name.MiddleName;
            UCPCPInfo1.LastName = pcp.Name.LastName;
            UCPCPInfo1.Phone = !string.IsNullOrEmpty(commonCode.FormatPhoneNumber(pcp.Primary.ToString()))
                ? commonCode.FormatPhoneNumber(pcp.Primary.ToString())
                : string.Empty;
            UCPCPInfo1.AlternatePhone = !string.IsNullOrEmpty(commonCode.FormatPhoneNumber(pcp.Secondary.ToString()))
               ? commonCode.FormatPhoneNumber(pcp.Secondary.ToString())
               : string.Empty;
            UCPCPInfo1.Email = pcp.Email != null ? pcp.Email.ToString() : string.Empty;
            UCPCPInfo1.AlternateEmail = pcp.SecondaryEmail != null ? pcp.SecondaryEmail.ToString() : string.Empty;
            UCPCPInfo1.WebsiteUrl = pcp.Website;
            if (pcp.Address != null)
            {
                UCPCPInfo1.Address1 = pcp.Address.StreetAddressLine1;
                UCPCPInfo1.Address2 = pcp.Address.StreetAddressLine2;
                UCPCPInfo1.City = pcp.Address.City;
                UCPCPInfo1.State = pcp.Address.StateId.ToString();
                UCPCPInfo1.Zip = pcp.Address.ZipCode.Zip;
            }
            if (pcp.MailingAddress != null)
            {
                UCPCPInfo1.MaillingAddress1 = pcp.MailingAddress.StreetAddressLine1;
                UCPCPInfo1.MaillingAddress2 = pcp.MailingAddress.StreetAddressLine2;
                UCPCPInfo1.MaillingCity = pcp.MailingAddress.City;
                UCPCPInfo1.MaillingState = pcp.MailingAddress.StateId.ToString();
                UCPCPInfo1.MaillingZip = pcp.MailingAddress.ZipCode.Zip;
            }
            UCPCPInfo1.IsMaillingAddressSame = IsMailingAddressSame(pcp);
            if (pcp.Address != null && pcp.MailingAddress == null)
            {
                UCPCPInfo1.MaillingAddress1 = pcp.Address.StreetAddressLine1;
                UCPCPInfo1.MaillingAddress2 = pcp.Address.StreetAddressLine2;
                UCPCPInfo1.MaillingCity = pcp.Address.City;
                UCPCPInfo1.MaillingState = pcp.Address.StateId.ToString();
                UCPCPInfo1.MaillingZip = pcp.Address.ZipCode.Zip;
                UCPCPInfo1.IsMaillingAddressSame = true;
            }

            HasPcpHiddenField.Value = Boolean.TrueString;
        }
    }
    private void SetPcpMaillingAddress(PrimaryCarePhysician pcp, long countryId)
    {
        if (UCPCPInfo1.IsMaillingAddressSame || IsMailingAddressSame())
        {
            pcp.MailingAddress = null;
            return;
        }

        long mailingAddressId = 0;

        if (pcp.MailingAddress != null && (pcp.Address == null || pcp.MailingAddress.Id != pcp.Address.Id))
        {
            mailingAddressId = pcp.MailingAddress.Id;
        }

        pcp.MailingAddress = new Address(mailingAddressId)
        {
            StreetAddressLine1 = UCPCPInfo1.MaillingAddress1,
            StreetAddressLine2 = UCPCPInfo1.MaillingAddress2,
            City = UCPCPInfo1.MaillingCity,
            StateId = Convert.ToInt64(UCPCPInfo1.MaillingState),
            ZipCode = new ZipCode(UCPCPInfo1.MaillingZip),
            CountryId = countryId
        };
    }



    private Address SetPCPAddressFromPhysicianMaster(long addressId, string address1, string address2, string city, long stateId, long countryid, string zipcode)
    {
        return new Address(addressId)
        {
            StreetAddressLine1 = address1,
            StreetAddressLine2 = address2,
            City = city,
            StateId = stateId,
            ZipCode = new ZipCode(zipcode),
            CountryId = countryid
        };
    }

    private PrimaryCarePhysician UpdatePcpAddressesFromMaster(PhysicianMaster physicianMaster, PrimaryCarePhysician pcp)
    {
        var stateRepository = IoC.Resolve<IStateRepository>();

        if (physicianMaster.PracticeAddress1.Trim().Length > 0 && physicianMaster.PracticeState.Trim().Length > 0 && physicianMaster.PracticeCity.Trim().Length > 0 && physicianMaster.PracticeZip.Trim().Length > 0)
        {

            var state = stateRepository.GetStatebyCode(physicianMaster.PracticeState) ?? stateRepository.GetState(physicianMaster.PracticeState);
            long addressId = 0;
            if (pcp.Address != null)
                addressId = pcp.Address.Id;

            pcp.Address = SetPCPAddressFromPhysicianMaster(addressId, physicianMaster.PracticeAddress1, physicianMaster.PracticeAddress2, physicianMaster.PracticeCity, state.Id, state.CountryId, physicianMaster.PracticeZip);
        }
        else
            pcp.Address = null;

        if (!isPhysicianMasterMailinAddressSame(physicianMaster) && physicianMaster.MailingAddress1.Trim().Length > 0 && physicianMaster.MailingState.Trim().Length > 0 && physicianMaster.MailingCity.Trim().Length > 0 && physicianMaster.MailingZip.Trim().Length > 0)
        {
            var state = stateRepository.GetStatebyCode(physicianMaster.MailingState) ?? stateRepository.GetState(physicianMaster.MailingState);
            long addressId = 0;
            if (pcp.MailingAddress != null && (pcp.Address != null && pcp.MailingAddress.Id != pcp.Address.Id))
                addressId = pcp.MailingAddress.Id;

            pcp.MailingAddress = SetPCPAddressFromPhysicianMaster(addressId, physicianMaster.MailingAddress1, physicianMaster.MailingAddress2, physicianMaster.MailingCity, state.Id, state.CountryId, physicianMaster.MailingZip);
        }
        else
            pcp.MailingAddress = null;

        return pcp;
    }

    private bool isPhysicianMasterMailinAddressSame(PhysicianMaster physicianMaster)
    {
        if (physicianMaster.PracticeAddress1.Trim().Length <= 0 || physicianMaster.MailingAddress1.Trim().Length <= 0) return true;

        return physicianMaster.PracticeAddress1.Trim() == physicianMaster.MailingAddress1.Trim() && physicianMaster.PracticeState.Trim() == physicianMaster.MailingState.Trim() && physicianMaster.PracticeCity.Trim() == physicianMaster.MailingCity.Trim() && physicianMaster.PracticeZip.Trim() == physicianMaster.MailingZip.Trim();
    }

    private bool IsMailingAddressSame()
    {
        return UCPCPInfo1.MaillingAddress1 == UCPCPInfo1.Address1 && UCPCPInfo1.MaillingAddress2 == UCPCPInfo1.Address2 &&
               UCPCPInfo1.MaillingCity == UCPCPInfo1.City && UCPCPInfo1.MaillingStateName == UCPCPInfo1.StateName;
    }

    private bool IsMailingAddressSame(PrimaryCarePhysician pcp)
    {
        if (pcp.Address == null && pcp.MailingAddress == null) return true;
        if (pcp.Address != null && pcp.MailingAddress == null) return true;
        if (pcp.Address == null && pcp.MailingAddress != null) return true;

        return (pcp.MailingAddress.Id == pcp.Address.Id);
    }

}
