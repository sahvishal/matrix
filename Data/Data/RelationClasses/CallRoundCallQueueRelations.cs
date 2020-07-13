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
	/// <summary>Implements the static Relations variant for the entity: CallRoundCallQueue. </summary>
	public partial class CallRoundCallQueueRelations
	{
		/// <summary>CTor</summary>
		public CallRoundCallQueueRelations()
		{
		}

		/// <summary>Gets all relations of the CallRoundCallQueueEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallRoundCallQueueCriteriaAssignmentEntityUsingCallRoundCallQueueId);

			toReturn.Add(this.AccountEntityUsingHealthPlanId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.LookupEntityUsingStatus);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CallRoundCallQueueEntity and CallRoundCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// CallRoundCallQueue.Id - CallRoundCallQueueCriteriaAssignment.CallRoundCallQueueId
		/// </summary>
		public virtual IEntityRelation CallRoundCallQueueCriteriaAssignmentEntityUsingCallRoundCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallRoundCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(CallRoundCallQueueFields.Id, CallRoundCallQueueCriteriaAssignmentFields.CallRoundCallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CallRoundCallQueueEntity and AccountEntity over the m:1 relation they have, using the relation between the fields:
		/// CallRoundCallQueue.HealthPlanId - Account.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Account", false);
				relation.AddEntityFieldPair(AccountFields.AccountId, CallRoundCallQueueFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallRoundCallQueueEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// CallRoundCallQueue.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CallRoundCallQueueFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallRoundCallQueueEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CallRoundCallQueue.Status - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallRoundCallQueueFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallRoundCallQueueEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallRoundCallQueue.ModifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallRoundCallQueueFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueEntity", true);
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
