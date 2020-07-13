///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:40
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
	/// <summary>Implements the static Relations variant for the entity: CampaignActivity. </summary>
	public partial class CampaignActivityRelations
	{
		/// <summary>CTor</summary>
		public CampaignActivityRelations()
		{
		}

		/// <summary>Gets all relations of the CampaignActivityEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CampaignActivityAssignmentEntityUsingCampaignActivityId);
			toReturn.Add(this.HealthPlanCriteriaDirectMailEntityUsingCampaignActivityId);

			toReturn.Add(this.CampaignEntityUsingCampaignId);
			toReturn.Add(this.DirectMailTypeEntityUsingDirectMailTypeId);
			toReturn.Add(this.LookupEntityUsingTypeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedby);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedby);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CampaignActivityEntity and CampaignActivityAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// CampaignActivity.Id - CampaignActivityAssignment.CampaignActivityId
		/// </summary>
		public virtual IEntityRelation CampaignActivityAssignmentEntityUsingCampaignActivityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CampaignActivityAssignment" , true);
				relation.AddEntityFieldPair(CampaignActivityFields.Id, CampaignActivityAssignmentFields.CampaignActivityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CampaignActivityEntity and HealthPlanCriteriaDirectMailEntity over the 1:n relation they have, using the relation between the fields:
		/// CampaignActivity.Id - HealthPlanCriteriaDirectMail.CampaignActivityId
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaDirectMailEntityUsingCampaignActivityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaDirectMail" , true);
				relation.AddEntityFieldPair(CampaignActivityFields.Id, HealthPlanCriteriaDirectMailFields.CampaignActivityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaDirectMailEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CampaignActivityEntity and CampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// CampaignActivity.CampaignId - Campaign.Id
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Campaign", false);
				relation.AddEntityFieldPair(CampaignFields.Id, CampaignActivityFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CampaignActivityEntity and DirectMailTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// CampaignActivity.DirectMailTypeId - DirectMailType.Id
		/// </summary>
		public virtual IEntityRelation DirectMailTypeEntityUsingDirectMailTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DirectMailType", false);
				relation.AddEntityFieldPair(DirectMailTypeFields.Id, CampaignActivityFields.DirectMailTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CampaignActivityEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CampaignActivity.TypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CampaignActivityFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CampaignActivityEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CampaignActivity.Modifiedby - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedby
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignActivityFields.Modifiedby);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CampaignActivityEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CampaignActivity.Createdby - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedby
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignActivityFields.Createdby);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", true);
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
