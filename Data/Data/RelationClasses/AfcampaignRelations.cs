///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
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
	/// <summary>Implements the static Relations variant for the entity: Afcampaign. </summary>
	public partial class AfcampaignRelations
	{
		/// <summary>CTor</summary>
		public AfcampaignRelations()
		{
		}

		/// <summary>Gets all relations of the AfcampaignEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfAdvertisingCommissionEntityUsingCampaignId);
			toReturn.Add(this.AfaffiliateCampaignEntityUsingCampaignId);
			toReturn.Add(this.AfaffiliateCampaignMarketingMaterialEntityUsingCampaignId);
			toReturn.Add(this.AfcampaignSubAdvocateEntityUsingCampaignId);
			toReturn.Add(this.AfimpressionEntityUsingCampaignId);
			toReturn.Add(this.AfimpressionLogEntityUsingAffiliateCampaignMarketingMaterialId);
			toReturn.Add(this.CampaignTagMappingEntityUsingCampaignId);
			toReturn.Add(this.ClickLogEntityUsingCampaignId);
			toReturn.Add(this.CustomCampaignContentEntityUsingCampaignId);
			toReturn.Add(this.EventCampaignDetailsEntityUsingCampaignId);

			toReturn.Add(this.AfadvertiserEntityUsingAdvertiserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingRoleId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingShellId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and AfAdvertisingCommissionEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - AfAdvertisingCommission.CampaignId
		/// </summary>
		public virtual IEntityRelation AfAdvertisingCommissionEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfAdvertisingCommission" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, AfAdvertisingCommissionFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfAdvertisingCommissionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and AfaffiliateCampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - AfaffiliateCampaign.CampaignId
		/// </summary>
		public virtual IEntityRelation AfaffiliateCampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfaffiliateCampaign" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, AfaffiliateCampaignFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and AfaffiliateCampaignMarketingMaterialEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - AfaffiliateCampaignMarketingMaterial.CampaignId
		/// </summary>
		public virtual IEntityRelation AfaffiliateCampaignMarketingMaterialEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfaffiliateCampaignMarketingMaterial" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, AfaffiliateCampaignMarketingMaterialFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignMarketingMaterialEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and AfcampaignSubAdvocateEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - AfcampaignSubAdvocate.CampaignId
		/// </summary>
		public virtual IEntityRelation AfcampaignSubAdvocateEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfcampaignSubAdvocate" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, AfcampaignSubAdvocateFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignSubAdvocateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and AfimpressionEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - Afimpression.CampaignId
		/// </summary>
		public virtual IEntityRelation AfimpressionEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afimpression" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, AfimpressionFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfimpressionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and AfimpressionLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - AfimpressionLog.AffiliateCampaignMarketingMaterialId
		/// </summary>
		public virtual IEntityRelation AfimpressionLogEntityUsingAffiliateCampaignMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfimpressionLog" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, AfimpressionLogFields.AffiliateCampaignMarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfimpressionLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and CampaignTagMappingEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - CampaignTagMapping.CampaignId
		/// </summary>
		public virtual IEntityRelation CampaignTagMappingEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CampaignTagMapping" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, CampaignTagMappingFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignTagMappingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and ClickLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - ClickLog.CampaignId
		/// </summary>
		public virtual IEntityRelation ClickLogEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClickLog" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, ClickLogFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and CustomCampaignContentEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - CustomCampaignContent.CampaignId
		/// </summary>
		public virtual IEntityRelation CustomCampaignContentEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomCampaignContent" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, CustomCampaignContentFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomCampaignContentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and EventCampaignDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcampaign.CampaignId - EventCampaignDetails.CampaignId
		/// </summary>
		public virtual IEntityRelation EventCampaignDetailsEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCampaignDetails" , true);
				relation.AddEntityFieldPair(AfcampaignFields.CampaignId, EventCampaignDetailsFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCampaignDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and AfadvertiserEntity over the m:1 relation they have, using the relation between the fields:
		/// Afcampaign.AdvertiserId - Afadvertiser.AdvertiserId
		/// </summary>
		public virtual IEntityRelation AfadvertiserEntityUsingAdvertiserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Afadvertiser", false);
				relation.AddEntityFieldPair(AfadvertiserFields.AdvertiserId, AfcampaignFields.AdvertiserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfadvertiserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Afcampaign.RoleId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AfcampaignFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AfcampaignEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Afcampaign.ShellId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingShellId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AfcampaignFields.ShellId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", true);
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
