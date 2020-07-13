using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PatientInputFileViewModel
    {
        [DisplayName("patient_cid")]
        public string PatientCid { get; set; }

        [DisplayName("ord_date")]
        [Format("MM/dd/yyyy")]
        public DateTime OrdDate { get; set; }

        [DisplayName("program_name")]
        public string ProgramName { get; set; }

        [DisplayName("location_name")]
        public string LocationName { get; set; }

        [DisplayName("location_suff")]
        public string LocationSuf { get; set; }

        [DisplayName("first_name")]
        public string FirstName { get; set; }

        [DisplayName("mi")]
        public string MiddleName { get; set; }

        [DisplayName("last_name")]
        public string LastName { get; set; }

        [Hidden]
        public Address Address { get; set; }

        [DisplayName("addr1")]
        public string Address1
        {
            get
            {
                if (Address != null) return Address.StreetAddressLine1;
                return string.Empty;
            }
        }

        [DisplayName("addr2")]
        public string Address2
        {
            get
            {
                if (Address != null) return Address.StreetAddressLine2;
                return string.Empty;
            }
        }

        [DisplayName("city")]
        public string City
        {
            get
            {
                if (Address != null) return Address.City;
                return string.Empty;
            }
        }

        [DisplayName("st")]
        public string State
        {
            get
            {
                if (Address != null) return Address.StateCode;
                return string.Empty;
            }
        }

        [DisplayName("zip")]
        public string Zip
        {
            get
            {
                if (Address != null) return Address.ZipCode.Zip;
                return string.Empty;
            }
        }

        [DisplayName("phone_h")]

        public string PhoneHome { get; set; }

        [DisplayName("phone_w")]
        public string PhoneWork { get; set; }

        [DisplayName("phone_c")]
        public string PhoneCell { get; set; }

        [DisplayName("primary_phone")]
        public string PrimaryPhone { get; set; }

        [DisplayName("phone_f")]
        public string PhoneFax { get; set; }

        [DisplayName("email_h")]
        public string EmailHome { get; set; }

        [DisplayName("email_w")]
        public string EmailWork { get; set; }

        [DisplayName("sex")]
        public string Gender { get; set; }

        [DisplayName("patient_id")]
        public string PatientId { get; set; }

        [DisplayName("dob")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("lang_spoken")]
        public string LanguageSpoken { get; set; }


        [DisplayName("lang_written")]
        public string LanguageWritten { get; set; }


        [DisplayName("date_called")]
        public string DateCalled { get; set; }

        [DisplayName("how_heard")]
        public string HowHeard { get; set; }

        [DisplayName("optinout")]
        public string OptInOut { get; set; }

        [DisplayName("opt_reason")]
        public string OptReason { get; set; }

        [DisplayName("box_code")]
        public string BoxCode { get; set; }

        [DisplayName("cass_code")]
        public string CassCode { get; set; }

        [DisplayName("kit_lot")]
        public string KitLot { get; set; }

        [DisplayName("fullfill_date")]
        public string FullfillDate { get; set; }

        [DisplayName("test_model")]
        public string TestModel { get; set; }

        [DisplayName("order_code")]
        public string OrderCode { get; set; }

        [DisplayName("status")]
        public string Status { get; set; }

        [DisplayName("date_approved")]
        public string DateApproved { get; set; }

        [DisplayName("dr_first")]
        public string DoctorFirst { get; set; }

        [DisplayName("dr_last")]
        public string DoctorLast { get; set; }

        [DisplayName("dr_lic_st")]
        public string DoctorLicensedSt { get; set; }

        [DisplayName("dr_upin")]
        public string DoctorUpin { get; set; }

        [DisplayName("dr_npi")]
        public string DoctorNpi { get; set; }

        [DisplayName("dr_license")]
        public string DoctorLicense { get; set; }

        [DisplayName("dr_lic_Exp")]
        public string DoctorLicenseExp { get; set; }

        [DisplayName("icd9_code")]
        public string Icd9Code { get; set; }

        [DisplayName("hcc_code")]
        public string HccCode { get; set; }

        [DisplayName("pcp_name")]
        public string PcpName { get; set; }

        [Hidden]
        public Address PcpAddress { get; set; }

        [DisplayName("pcp_addr1")]
        public string PcpAddress1
        {
            get
            {
                if (PcpAddress != null) return PcpAddress.StreetAddressLine1;
                return string.Empty;
            }
        }

        [DisplayName("pcp_addr2")]
        public string PcpAddress2
        {
            get
            {
                if (PcpAddress != null) return PcpAddress.StreetAddressLine2;
                return string.Empty;
            }

        }

        [DisplayName("pcp_addr3")]
        public string PcpAddress3 { get; set; }

        [DisplayName("pcp_city")]
        public string PcpCity
        {
            get
            {
                if (PcpAddress != null) return PcpAddress.City;
                return string.Empty;
            }
        }

        [DisplayName("pcp_st")]
        public string PcpState
        {
            get
            {
                if (PcpAddress != null) return PcpAddress.StateCode;
                return string.Empty;
            }
        }

        [DisplayName("pcp_zip")]
        public string PcpZip
        {
            get
            {
                if (PcpAddress != null) return PcpAddress.ZipCode.Zip;
                return string.Empty;
            }
        }

        [DisplayName("pcp_phone")]
        public string PcpPhone { get; set; }

        [DisplayName("pcp_fax")]
        public string PcpFax { get; set; }

        [DisplayName("custom1")]
        public string Custom1 { get; set; }

        [DisplayName("custom2")]
        public string Custom2 { get; set; }

        [DisplayName("custom3")]
        public string Custom3 { get; set; }

        [DisplayName("custom4")]
        public string Custom4 { get; set; }

        [DisplayName("custom5")]
        public string Custom5 { get; set; }


    }
}