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
	/// <summary>Implements the static Relations variant for the entity: Organization. </summary>
	public partial class OrganizationRelations
	{
		/// <summary>CTor</summary>
		public OrganizationRelations()
		{
		}

		/// <summary>Gets all relations of the OrganizationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountCallCenterOrganizationEntityUsingOrganizationId);
			toReturn.Add(this.AccountTestHcpcsCodeEntityUsingAccountId);
			toReturn.Add(this.AfcampaignTemplateEntityUsingOwnerFranchiseeId);
			toReturn.Add(this.AffiliateProfileEntityUsingOwnerOrganizationId);
			toReturn.Add(this.BlockedDaysFranchiseeEntityUsingOrganizationId);
			toReturn.Add(this.ContactFranchiseeAccessEntityUsingOrganizationId);
			toReturn.Add(this.EventAccountTestHcpcsCodeEntityUsingAccountId);
			toReturn.Add(this.FranchiseeTerritoryEntityUsingOrganizationId);
			toReturn.Add(this.MarketingPrintOrderEntityUsingPrintVendorOrganizationId);
			toReturn.Add(this.MarketingPrintOrderEntityUsingFranchiseeOrganizationId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingOrganizationId);
			toReturn.Add(this.PodDetailsEntityUsingOrganizationId);
			toReturn.Add(this.ProspectListDetailsEntityUsingOrganizationId);
			toReturn.Add(this.ScheduleTemplateFranchiseeAccessEntityUsingOrganizationId);
			toReturn.Add(this.AccountEntityUsingAccountId);
			toReturn.Add(this.HospitalFacilityEntityUsingHospitalFacilityId);
			toReturn.Add(this.MedicalVendorProfileEntityUsingOrganizationId);
			toReturn.Add(this.AddressEntityUsingBusinessAddressId);
			toReturn.Add(this.FileEntityUsingTeamImageId);
			toReturn.Add(this.FileEntityUsingLogoImageId);
			toReturn.Add(this.OrganizationTypeEntityUsingOrganizationTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and AccountCallCenterOrganizationEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - AccountCallCenterOrganization.OrganizationId
		/// </summary>
		public virtual IEntityRelation AccountCallCenterOrganizationEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCallCenterOrganization" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, AccountCallCenterOrganizationFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCallCenterOrganizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and AccountTestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - AccountTestHcpcsCode.AccountId
		/// </summary>
		public virtual IEntityRelation AccountTestHcpcsCodeEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountTestHcpcsCode" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, AccountTestHcpcsCodeFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountTestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and AfcampaignTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - AfcampaignTemplate.OwnerFranchiseeId
		/// </summary>
		public virtual IEntityRelation AfcampaignTemplateEntityUsingOwnerFranchiseeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfcampaignTemplate" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, AfcampaignTemplateFields.OwnerFranchiseeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and AffiliateProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - AffiliateProfile.OwnerOrganizationId
		/// </summary>
		public virtual IEntityRelation AffiliateProfileEntityUsingOwnerOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AffiliateProfile" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, AffiliateProfileFields.OwnerOrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and BlockedDaysFranchiseeEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - BlockedDaysFranchisee.OrganizationId
		/// </summary>
		public virtual IEntityRelation BlockedDaysFranchiseeEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BlockedDaysFranchisee" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, BlockedDaysFranchiseeFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BlockedDaysFranchiseeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and ContactFranchiseeAccessEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - ContactFranchiseeAccess.OrganizationId
		/// </summary>
		public virtual IEntityRelation ContactFranchiseeAccessEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ContactFranchiseeAccess" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, ContactFranchiseeAccessFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactFranchiseeAccessEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and EventAccountTestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - EventAccountTestHcpcsCode.AccountId
		/// </summary>
		public virtual IEntityRelation EventAccountTestHcpcsCodeEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAccountTestHcpcsCode" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, EventAccountTestHcpcsCodeFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and FranchiseeTerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - FranchiseeTerritory.OrganizationId
		/// </summary>
		public virtual IEntityRelation FranchiseeTerritoryEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FranchiseeTerritory" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, FranchiseeTerritoryFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FranchiseeTerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and MarketingPrintOrderEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - MarketingPrintOrder.PrintVendorOrganizationId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderEntityUsingPrintVendorOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrder_" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, MarketingPrintOrderFields.PrintVendorOrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and MarketingPrintOrderEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - MarketingPrintOrder.FranchiseeOrganizationId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderEntityUsingFranchiseeOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrder" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, MarketingPrintOrderFields.FranchiseeOrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and OrganizationRoleUserEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - OrganizationRoleUser.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrganizationRoleUser" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, OrganizationRoleUserFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and PodDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - PodDetails.OrganizationId
		/// </summary>
		public virtual IEntityRelation PodDetailsEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodDetails" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, PodDetailsFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and ProspectListDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - ProspectListDetails.OrganizationId
		/// </summary>
		public virtual IEntityRelation ProspectListDetailsEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectListDetails" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, ProspectListDetailsFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectListDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and ScheduleTemplateFranchiseeAccessEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - ScheduleTemplateFranchiseeAccess.OrganizationId
		/// </summary>
		public virtual IEntityRelation ScheduleTemplateFranchiseeAccessEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ScheduleTemplateFranchiseeAccess" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, ScheduleTemplateFranchiseeAccessFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScheduleTemplateFranchiseeAccessEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and AccountEntity over the 1:1 relation they have, using the relation between the fields:
		/// Organization.OrganizationId - Account.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "Account", true);

				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, AccountFields.AccountId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and HospitalFacilityEntity over the 1:1 relation they have, using the relation between the fields:
		/// Organization.OrganizationId - HospitalFacility.HospitalFacilityId
		/// </summary>
		public virtual IEntityRelation HospitalFacilityEntityUsingHospitalFacilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "HospitalFacility", true);

				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, HospitalFacilityFields.HospitalFacilityId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalFacilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and MedicalVendorProfileEntity over the 1:1 relation they have, using the relation between the fields:
		/// Organization.OrganizationId - MedicalVendorProfile.OrganizationId
		/// </summary>
		public virtual IEntityRelation MedicalVendorProfileEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "MedicalVendorProfile", true);

				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, MedicalVendorProfileFields.OrganizationId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalVendorProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// Organization.BusinessAddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingBusinessAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, OrganizationFields.BusinessAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Organization.TeamImageId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingTeamImageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, OrganizationFields.TeamImageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Organization.LogoImageId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingLogoImageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, OrganizationFields.LogoImageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and OrganizationTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Organization.OrganizationTypeId - OrganizationType.OrganizationTypeId
		/// </summary>
		public virtual IEntityRelation OrganizationTypeEntityUsingOrganizationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationType", false);
				relation.AddEntityFieldPair(OrganizationTypeFields.OrganizationTypeId, OrganizationFields.OrganizationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
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
