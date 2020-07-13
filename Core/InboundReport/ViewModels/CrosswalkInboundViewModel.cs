using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class CrosswalkInboundViewModel : ViewModelBase
    {
        [DisplayName("Tenant_Id")]
        public string TenantId { get; set; }

        [DisplayName("Client_Id")]
        public string ClientId { get; set; }

        [DisplayName("Campaign_Id")]
        public string CampaignId { get; set; }

        [DisplayName("Individual_ID_Number")]
        public string IndividualIDNumber { get; set; }

        [DisplayName("Contract_Number")]
        public string ContractNumber { get; set; }

        [DisplayName("Contract_Person_Number")]
        public string ContractPersonNumber { get; set; }

        [DisplayName("Consumer_Id")]
        public string ConsumerId { get; set; }

        [DisplayName("Extract_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ExtractDate { get; set; }

        [DisplayName("Document_ID")]
        public string DocumentID { get; set; }

        [DisplayName("Relationship_Code")]
        public string RelationshipCode { get; set; }

        [DisplayName("Last_Name")]
        public string LastName { get; set; }

        [DisplayName("First_Name")]
        public string FirstName { get; set; }

        [DisplayName("Birth_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Client_Provider_ID")]
        public string ClientProviderID { get; set; }

        [DisplayName("File_Name")]
        public string FileName { get; set; }

        [DisplayName("Project_Type_Name")]
        public string ProjectTypeName { get; set; }

        [DisplayName("NPI")]
        public string Npi { get; set; }

        [DisplayName("Service_Start_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ServiceStartDate { get; set; }

        [DisplayName("Service_End_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ServiceEndDate { get; set; }

        [Hidden]
        public long EventId { get; set; }
        [Hidden]
        public long CustomerId { get; set; }
    }
}
