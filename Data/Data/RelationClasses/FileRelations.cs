///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using Falcon.Data;
using Falcon.Data.FactoryClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: File. </summary>
	public partial class FileRelations
	{
		/// <summary>CTor</summary>
		public FileRelations()
		{
		}

		/// <summary>Gets all relations of the FileEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountEntityUsingConfirmationScriptFileId);
			toReturn.Add(this.AccountEntityUsingCallCenterScriptFileId);
			toReturn.Add(this.AccountEntityUsingMemberLetterFileId);
			toReturn.Add(this.AccountEntityUsingInboundCallScriptFileId);
			toReturn.Add(this.AccountEntityUsingFluffLetterFileId);
			toReturn.Add(this.AccountEntityUsingParticipantLetterId);
			toReturn.Add(this.AccountEntityUsingCheckListFileId);
			toReturn.Add(this.AccountEntityUsingSurveyPdfFileId);
			toReturn.Add(this.AccountEntityUsingPcpLetterPdfFileId);
			toReturn.Add(this.CallUploadEntityUsingLogFileId);
			toReturn.Add(this.CallUploadEntityUsingFileId);
			toReturn.Add(this.ChaperoneSignatureEntityUsingStaffSignatureFileId);
			toReturn.Add(this.ChaperoneSignatureEntityUsingSignatureFileId);
			toReturn.Add(this.CorporateUploadEntityUsingLogFileId);
			toReturn.Add(this.CorporateUploadEntityUsingFileId);
			toReturn.Add(this.CorporateUploadEntityUsingAdjustOrderLogFileId);
			toReturn.Add(this.CustomerActivityTypeUploadEntityUsingLogFileId);
			toReturn.Add(this.CustomerActivityTypeUploadEntityUsingFileId);
			toReturn.Add(this.CustomerPhoneNumberUpdateUploadEntityUsingLogFileId);
			toReturn.Add(this.CustomerPhoneNumberUpdateUploadEntityUsingFileId);
			toReturn.Add(this.EligibilityUploadEntityUsingLogFileId);
			toReturn.Add(this.EligibilityUploadEntityUsingFileId);
			toReturn.Add(this.EventCustomerGiftCardEntityUsingTechnicianSignatureFileId);
			toReturn.Add(this.EventCustomerGiftCardEntityUsingPatientSignatureFileId);
			toReturn.Add(this.ExitInterviewSignatureEntityUsingSignatureFileId);
			toReturn.Add(this.ExportableReportsQueueEntityUsingFileId);
			toReturn.Add(this.FluConsentSignatureEntityUsingClinicalProviderSignatureFileId);
			toReturn.Add(this.FluConsentSignatureEntityUsingSignatureFileId);
			toReturn.Add(this.HealthPlanCriteriaAssignmentUploadEntityUsingFileId);
			toReturn.Add(this.HostImageEntityUsingImageId);
			toReturn.Add(this.MedicalVendorProfileEntityUsingDoctorLetterFileId);
			toReturn.Add(this.MedicalVendorProfileEntityUsingResultLetterCoBrandingFileId);
			toReturn.Add(this.MedicationUploadEntityUsingLogFileId);
			toReturn.Add(this.MedicationUploadEntityUsingFileId);
			toReturn.Add(this.MergeCustomerUploadEntityUsingLogFileId);
			toReturn.Add(this.MergeCustomerUploadEntityUsingFileId);
			toReturn.Add(this.OrganizationEntityUsingTeamImageId);
			toReturn.Add(this.OrganizationEntityUsingLogoImageId);
			toReturn.Add(this.OutboundUploadEntityUsingLogFileId);
			toReturn.Add(this.OutboundUploadEntityUsingFileId);
			toReturn.Add(this.PackageEntityUsingForOrderDisplayFileId);
			toReturn.Add(this.ParticipationConsentSignatureEntityUsingSignatureFileId);
			toReturn.Add(this.ParticipationConsentSignatureEntityUsingInsuranceSignatureFileId);
			toReturn.Add(this.PhysicianProfileEntityUsingDigitalSignatureFileId);
			toReturn.Add(this.PhysicianProfileEntityUsingResumeFileId);
			toReturn.Add(this.PhysicianRecordRequestSignatureEntityUsingSignatureFileId);
			toReturn.Add(this.RapsUploadEntityUsingLogFileId);
			toReturn.Add(this.RapsUploadEntityUsingFileId);
			toReturn.Add(this.ResultArchiveUploadEntityUsingFileId);
			toReturn.Add(this.StaffEventScheduleUploadEntityUsingLogFileId);
			toReturn.Add(this.StaffEventScheduleUploadEntityUsingFileId);
			toReturn.Add(this.SuspectConditionUploadEntityUsingLogFileId);
			toReturn.Add(this.SuspectConditionUploadEntityUsingFileId);
			toReturn.Add(this.TestimonialEntityUsingFileId);
			toReturn.Add(this.TestMediaEntityUsingFileId);
			toReturn.Add(this.WellMedAttestationEntityUsingProviderSignatureFileId);

			toReturn.Add(this.LookupEntityUsingType);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between FileEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Account.ConfirmationScriptFileId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingConfirmationScriptFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account______" , true);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.ConfirmationScriptFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Account.CallCenterScriptFileId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingCallCenterScriptFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account_____" , true);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.CallCenterScriptFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Account.MemberLetterFileId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingMemberLetterFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account________" , true);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.MemberLetterFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Account.InboundCallScriptFileId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingInboundCallScriptFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account_______" , true);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.InboundCallScriptFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Account.FluffLetterFileId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingFluffLetterFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account____" , true);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.FluffLetterFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Account.ParticipantLetterId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingParticipantLetterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.ParticipantLetterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Account.CheckListFileId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingCheckListFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account" , true);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.CheckListFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Account.SurveyPdfFileId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingSurveyPdfFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account___" , true);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.SurveyPdfFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Account.PcpLetterPdfFileId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingPcpLetterPdfFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account__" , true);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.PcpLetterPdfFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and CallUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - CallUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation CallUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, CallUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and CallUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - CallUpload.FileId
		/// </summary>
		public virtual IEntityRelation CallUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, CallUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and ChaperoneSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - ChaperoneSignature.StaffSignatureFileId
		/// </summary>
		public virtual IEntityRelation ChaperoneSignatureEntityUsingStaffSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaperoneSignature_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, ChaperoneSignatureFields.StaffSignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaperoneSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and ChaperoneSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - ChaperoneSignature.SignatureFileId
		/// </summary>
		public virtual IEntityRelation ChaperoneSignatureEntityUsingSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaperoneSignature" , true);
				relation.AddEntityFieldPair(FileFields.FileId, ChaperoneSignatureFields.SignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaperoneSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and CorporateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - CorporateUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation CorporateUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CorporateUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, CorporateUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and CorporateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - CorporateUpload.FileId
		/// </summary>
		public virtual IEntityRelation CorporateUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CorporateUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, CorporateUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and CorporateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - CorporateUpload.AdjustOrderLogFileId
		/// </summary>
		public virtual IEntityRelation CorporateUploadEntityUsingAdjustOrderLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CorporateUpload__" , true);
				relation.AddEntityFieldPair(FileFields.FileId, CorporateUploadFields.AdjustOrderLogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and CustomerActivityTypeUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - CustomerActivityTypeUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation CustomerActivityTypeUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerActivityTypeUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, CustomerActivityTypeUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerActivityTypeUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and CustomerActivityTypeUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - CustomerActivityTypeUpload.FileId
		/// </summary>
		public virtual IEntityRelation CustomerActivityTypeUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerActivityTypeUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, CustomerActivityTypeUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerActivityTypeUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and CustomerPhoneNumberUpdateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - CustomerPhoneNumberUpdateUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation CustomerPhoneNumberUpdateUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPhoneNumberUpdateUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, CustomerPhoneNumberUpdateUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPhoneNumberUpdateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and CustomerPhoneNumberUpdateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - CustomerPhoneNumberUpdateUpload.FileId
		/// </summary>
		public virtual IEntityRelation CustomerPhoneNumberUpdateUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPhoneNumberUpdateUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, CustomerPhoneNumberUpdateUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPhoneNumberUpdateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and EligibilityUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - EligibilityUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation EligibilityUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EligibilityUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, EligibilityUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and EligibilityUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - EligibilityUpload.FileId
		/// </summary>
		public virtual IEntityRelation EligibilityUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EligibilityUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, EligibilityUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and EventCustomerGiftCardEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - EventCustomerGiftCard.TechnicianSignatureFileId
		/// </summary>
		public virtual IEntityRelation EventCustomerGiftCardEntityUsingTechnicianSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerGiftCard_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, EventCustomerGiftCardFields.TechnicianSignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerGiftCardEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and EventCustomerGiftCardEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - EventCustomerGiftCard.PatientSignatureFileId
		/// </summary>
		public virtual IEntityRelation EventCustomerGiftCardEntityUsingPatientSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerGiftCard" , true);
				relation.AddEntityFieldPair(FileFields.FileId, EventCustomerGiftCardFields.PatientSignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerGiftCardEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and ExitInterviewSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - ExitInterviewSignature.SignatureFileId
		/// </summary>
		public virtual IEntityRelation ExitInterviewSignatureEntityUsingSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExitInterviewSignature" , true);
				relation.AddEntityFieldPair(FileFields.FileId, ExitInterviewSignatureFields.SignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and ExportableReportsQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - ExportableReportsQueue.FileId
		/// </summary>
		public virtual IEntityRelation ExportableReportsQueueEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExportableReportsQueue" , true);
				relation.AddEntityFieldPair(FileFields.FileId, ExportableReportsQueueFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExportableReportsQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and FluConsentSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - FluConsentSignature.ClinicalProviderSignatureFileId
		/// </summary>
		public virtual IEntityRelation FluConsentSignatureEntityUsingClinicalProviderSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentSignature_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, FluConsentSignatureFields.ClinicalProviderSignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and FluConsentSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - FluConsentSignature.SignatureFileId
		/// </summary>
		public virtual IEntityRelation FluConsentSignatureEntityUsingSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentSignature" , true);
				relation.AddEntityFieldPair(FileFields.FileId, FluConsentSignatureFields.SignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and HealthPlanCriteriaAssignmentUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - HealthPlanCriteriaAssignmentUpload.FileId
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaAssignmentUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaAssignmentUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, HealthPlanCriteriaAssignmentUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and HostImageEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - HostImage.ImageId
		/// </summary>
		public virtual IEntityRelation HostImageEntityUsingImageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostImage" , true);
				relation.AddEntityFieldPair(FileFields.FileId, HostImageFields.ImageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostImageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and MedicalVendorProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - MedicalVendorProfile.DoctorLetterFileId
		/// </summary>
		public virtual IEntityRelation MedicalVendorProfileEntityUsingDoctorLetterFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicalVendorProfile_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, MedicalVendorProfileFields.DoctorLetterFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and MedicalVendorProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - MedicalVendorProfile.ResultLetterCoBrandingFileId
		/// </summary>
		public virtual IEntityRelation MedicalVendorProfileEntityUsingResultLetterCoBrandingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicalVendorProfile" , true);
				relation.AddEntityFieldPair(FileFields.FileId, MedicalVendorProfileFields.ResultLetterCoBrandingFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and MedicationUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - MedicationUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation MedicationUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicationUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, MedicationUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and MedicationUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - MedicationUpload.FileId
		/// </summary>
		public virtual IEntityRelation MedicationUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicationUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, MedicationUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and MergeCustomerUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - MergeCustomerUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation MergeCustomerUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MergeCustomerUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, MergeCustomerUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MergeCustomerUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and MergeCustomerUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - MergeCustomerUpload.FileId
		/// </summary>
		public virtual IEntityRelation MergeCustomerUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MergeCustomerUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, MergeCustomerUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MergeCustomerUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and OrganizationEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Organization.TeamImageId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingTeamImageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Organization_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, OrganizationFields.TeamImageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and OrganizationEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Organization.LogoImageId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingLogoImageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Organization" , true);
				relation.AddEntityFieldPair(FileFields.FileId, OrganizationFields.LogoImageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and OutboundUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - OutboundUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation OutboundUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OutboundUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, OutboundUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OutboundUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and OutboundUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - OutboundUpload.FileId
		/// </summary>
		public virtual IEntityRelation OutboundUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OutboundUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, OutboundUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OutboundUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and PackageEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Package.ForOrderDisplayFileId
		/// </summary>
		public virtual IEntityRelation PackageEntityUsingForOrderDisplayFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Package" , true);
				relation.AddEntityFieldPair(FileFields.FileId, PackageFields.ForOrderDisplayFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and ParticipationConsentSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - ParticipationConsentSignature.SignatureFileId
		/// </summary>
		public virtual IEntityRelation ParticipationConsentSignatureEntityUsingSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ParticipationConsentSignature_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, ParticipationConsentSignatureFields.SignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ParticipationConsentSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and ParticipationConsentSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - ParticipationConsentSignature.InsuranceSignatureFileId
		/// </summary>
		public virtual IEntityRelation ParticipationConsentSignatureEntityUsingInsuranceSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ParticipationConsentSignature" , true);
				relation.AddEntityFieldPair(FileFields.FileId, ParticipationConsentSignatureFields.InsuranceSignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ParticipationConsentSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and PhysicianProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - PhysicianProfile.DigitalSignatureFileId
		/// </summary>
		public virtual IEntityRelation PhysicianProfileEntityUsingDigitalSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianProfile_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, PhysicianProfileFields.DigitalSignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and PhysicianProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - PhysicianProfile.ResumeFileId
		/// </summary>
		public virtual IEntityRelation PhysicianProfileEntityUsingResumeFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianProfile" , true);
				relation.AddEntityFieldPair(FileFields.FileId, PhysicianProfileFields.ResumeFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and PhysicianRecordRequestSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - PhysicianRecordRequestSignature.SignatureFileId
		/// </summary>
		public virtual IEntityRelation PhysicianRecordRequestSignatureEntityUsingSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianRecordRequestSignature" , true);
				relation.AddEntityFieldPair(FileFields.FileId, PhysicianRecordRequestSignatureFields.SignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianRecordRequestSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and RapsUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - RapsUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation RapsUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RapsUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, RapsUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and RapsUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - RapsUpload.FileId
		/// </summary>
		public virtual IEntityRelation RapsUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RapsUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, RapsUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and ResultArchiveUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - ResultArchiveUpload.FileId
		/// </summary>
		public virtual IEntityRelation ResultArchiveUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ResultArchiveUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, ResultArchiveUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultArchiveUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and StaffEventScheduleUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - StaffEventScheduleUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation StaffEventScheduleUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StaffEventScheduleUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, StaffEventScheduleUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and StaffEventScheduleUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - StaffEventScheduleUpload.FileId
		/// </summary>
		public virtual IEntityRelation StaffEventScheduleUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StaffEventScheduleUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, StaffEventScheduleUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and SuspectConditionUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - SuspectConditionUpload.LogFileId
		/// </summary>
		public virtual IEntityRelation SuspectConditionUploadEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SuspectConditionUpload_" , true);
				relation.AddEntityFieldPair(FileFields.FileId, SuspectConditionUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and SuspectConditionUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - SuspectConditionUpload.FileId
		/// </summary>
		public virtual IEntityRelation SuspectConditionUploadEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SuspectConditionUpload" , true);
				relation.AddEntityFieldPair(FileFields.FileId, SuspectConditionUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and TestimonialEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - Testimonial.FileId
		/// </summary>
		public virtual IEntityRelation TestimonialEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Testimonial" , true);
				relation.AddEntityFieldPair(FileFields.FileId, TestimonialFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestimonialEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and TestMediaEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - TestMedia.FileId
		/// </summary>
		public virtual IEntityRelation TestMediaEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestMedia" , true);
				relation.AddEntityFieldPair(FileFields.FileId, TestMediaFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestMediaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FileEntity and WellMedAttestationEntity over the 1:n relation they have, using the relation between the fields:
		/// File.FileId - WellMedAttestation.ProviderSignatureFileId
		/// </summary>
		public virtual IEntityRelation WellMedAttestationEntityUsingProviderSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "WellMedAttestation" , true);
				relation.AddEntityFieldPair(FileFields.FileId, WellMedAttestationFields.ProviderSignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WellMedAttestationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between FileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// File.Type - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, FileFields.Type);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between FileEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// File.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, FileFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", true);
				return relation;
			}
		}

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
