///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:41
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
	/// <summary>Implements the static Relations variant for the entity: LanguageBarrierCallQueue. </summary>
	public partial class LanguageBarrierCallQueueRelations
	{
		/// <summary>CTor</summary>
		public LanguageBarrierCallQueueRelations()
		{
		}

		/// <summary>Gets all relations of the LanguageBarrierCallQueueEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.LanguageBarrierCallQueueCriteriaAssignmentEntityUsingLanguageBarrierCallQueueId);

			toReturn.Add(this.AccountEntityUsingHealthPlanId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.LookupEntityUsingStatus);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between LanguageBarrierCallQueueEntity and LanguageBarrierCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// LanguageBarrierCallQueue.Id - LanguageBarrierCallQueueCriteriaAssignment.LanguageBarrierCallQueueId
		/// </summary>
		public virtual IEntityRelation LanguageBarrierCallQueueCriteriaAssignmentEntityUsingLanguageBarrierCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "LanguageBarrierCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(LanguageBarrierCallQueueFields.Id, LanguageBarrierCallQueueCriteriaAssignmentFields.LanguageBarrierCallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between LanguageBarrierCallQueueEntity and AccountEntity over the m:1 relation they have, using the relation between the fields:
		/// LanguageBarrierCallQueue.HealthPlanId - Account.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Account", false);
				relation.AddEntityFieldPair(AccountFields.AccountId, LanguageBarrierCallQueueFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between LanguageBarrierCallQueueEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// LanguageBarrierCallQueue.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, LanguageBarrierCallQueueFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between LanguageBarrierCallQueueEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// LanguageBarrierCallQueue.Status - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, LanguageBarrierCallQueueFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between LanguageBarrierCallQueueEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// LanguageBarrierCallQueue.ModifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, LanguageBarrierCallQueueFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueEntity", true);
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
