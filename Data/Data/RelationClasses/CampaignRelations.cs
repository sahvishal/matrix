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
	/// <summary>Implements the static Relations variant for the entity: Campaign. </summary>
	public partial class CampaignRelations
	{
		/// <summary>CTor</summary>
		public CampaignRelations()
		{
		}

		/// <summary>Gets all relations of the CampaignEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallQueueCustomerEntityUsingCampaignId);
			toReturn.Add(this.CallsEntityUsingCampaignId);
			toReturn.Add(this.CampaignActivityEntityUsingCampaignId);
			toReturn.Add(this.CampaignAssignmentEntityUsingCampaignId);
			toReturn.Add(this.DirectMailEntityUsingCampaignId);
			toReturn.Add(this.EventCustomersEntityUsingCampaignId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingCampaignId);

			toReturn.Add(this.AccountEntityUsingAccountId);
			toReturn.Add(this.LookupEntityUsingTypeId);
			toReturn.Add(this.LookupEntityUsingModeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedby);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedby);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// Campaign.Id - CallQueueCustomer.CampaignId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(CampaignFields.Id, CallQueueCustomerFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and CallsEntity over the 1:n relation they have, using the relation between the fields:
		/// Campaign.Id - Calls.CampaignId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Calls" , true);
				relation.AddEntityFieldPair(CampaignFields.Id, CallsFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and CampaignActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// Campaign.Id - CampaignActivity.CampaignId
		/// </summary>
		public virtual IEntityRelation CampaignActivityEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CampaignActivity" , true);
				relation.AddEntityFieldPair(CampaignFields.Id, CampaignActivityFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and CampaignAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Campaign.Id - CampaignAssignment.CampaignId
		/// </summary>
		public virtual IEntityRelation CampaignAssignmentEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CampaignAssignment" , true);
				relation.AddEntityFieldPair(CampaignFields.Id, CampaignAssignmentFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and DirectMailEntity over the 1:n relation they have, using the relation between the fields:
		/// Campaign.Id - DirectMail.CampaignId
		/// </summary>
		public virtual IEntityRelation DirectMailEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DirectMail" , true);
				relation.AddEntityFieldPair(CampaignFields.Id, DirectMailFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// Campaign.Id - EventCustomers.CampaignId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers" , true);
				relation.AddEntityFieldPair(CampaignFields.Id, EventCustomersFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and HealthPlanCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// Campaign.Id - HealthPlanCallQueueCriteria.CampaignId
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCallQueueCriteria" , true);
				relation.AddEntityFieldPair(CampaignFields.Id, HealthPlanCallQueueCriteriaFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and AccountEntity over the m:1 relation they have, using the relation between the fields:
		/// Campaign.AccountId - Account.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Account", false);
				relation.AddEntityFieldPair(AccountFields.AccountId, CampaignFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Campaign.TypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CampaignFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Campaign.ModeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingModeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CampaignFields.ModeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Campaign.Modifiedby - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedby
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignFields.Modifiedby);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CampaignEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Campaign.Createdby - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedby
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignFields.Createdby);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", true);
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
