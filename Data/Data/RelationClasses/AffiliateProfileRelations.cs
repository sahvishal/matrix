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
	/// <summary>Implements the static Relations variant for the entity: AffiliateProfile. </summary>
	public partial class AffiliateProfileRelations
	{
		/// <summary>CTor</summary>
		public AffiliateProfileRelations()
		{
		}

		/// <summary>Gets all relations of the AffiliateProfileEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfaffiliateCampaignEntityUsingAffiliateId);
			toReturn.Add(this.AfcampaignSubAdvocateEntityUsingAffiliateId);
			toReturn.Add(this.AfcommisionEntityUsingAffiliateId);
			toReturn.Add(this.AflAffiliatePaymentMethodEntityUsingAffiliateId);
			toReturn.Add(this.AfpaymentEntityUsingAffiliateId);
			toReturn.Add(this.EventAffiliateDetailsEntityUsingAffiliateId);
			toReturn.Add(this.AfcampaignSubAdvocateEntityUsingCampaignSubAffiliateId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingAffiliateId);
			toReturn.Add(this.OrganizationEntityUsingOwnerOrganizationId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and AfaffiliateCampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// AffiliateProfile.AffiliateId - AfaffiliateCampaign.AffiliateId
		/// </summary>
		public virtual IEntityRelation AfaffiliateCampaignEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfaffiliateCampaign" , true);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfaffiliateCampaignFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and AfcampaignSubAdvocateEntity over the 1:n relation they have, using the relation between the fields:
		/// AffiliateProfile.AffiliateId - AfcampaignSubAdvocate.AffiliateId
		/// </summary>
		public virtual IEntityRelation AfcampaignSubAdvocateEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfcampaignSubAdvocate" , true);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfcampaignSubAdvocateFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignSubAdvocateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and AfcommisionEntity over the 1:n relation they have, using the relation between the fields:
		/// AffiliateProfile.AffiliateId - Afcommision.AffiliateId
		/// </summary>
		public virtual IEntityRelation AfcommisionEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afcommision" , true);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfcommisionFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcommisionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and AflAffiliatePaymentMethodEntity over the 1:n relation they have, using the relation between the fields:
		/// AffiliateProfile.AffiliateId - AflAffiliatePaymentMethod.AffiliateId
		/// </summary>
		public virtual IEntityRelation AflAffiliatePaymentMethodEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AflAffiliatePaymentMethod" , true);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AflAffiliatePaymentMethodFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AflAffiliatePaymentMethodEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and AfpaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// AffiliateProfile.AffiliateId - Afpayment.AffiliateId
		/// </summary>
		public virtual IEntityRelation AfpaymentEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afpayment" , true);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfpaymentFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfpaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and EventAffiliateDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// AffiliateProfile.AffiliateId - EventAffiliateDetails.AffiliateId
		/// </summary>
		public virtual IEntityRelation EventAffiliateDetailsEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAffiliateDetails" , true);
				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, EventAffiliateDetailsFields.AffiliateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAffiliateDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and AfcampaignSubAdvocateEntity over the 1:1 relation they have, using the relation between the fields:
		/// AffiliateProfile.AffiliateId - AfcampaignSubAdvocate.CampaignSubAffiliateId
		/// </summary>
		public virtual IEntityRelation AfcampaignSubAdvocateEntityUsingCampaignSubAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "AfcampaignSubAdvocate_", true);

				relation.AddEntityFieldPair(AffiliateProfileFields.AffiliateId, AfcampaignSubAdvocateFields.CampaignSubAffiliateId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignSubAdvocateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and OrganizationRoleUserEntity over the 1:1 relation they have, using the relation between the fields:
		/// AffiliateProfile.AffiliateId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "OrganizationRoleUser_", false);



				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AffiliateProfileFields.AffiliateId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// AffiliateProfile.OwnerOrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingOwnerOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, AffiliateProfileFields.OwnerOrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AffiliateProfileEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// AffiliateProfile.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AffiliateProfileFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", true);
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
