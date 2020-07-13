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
	/// <summary>Implements the static Relations variant for the entity: CallQueue. </summary>
	public partial class CallQueueRelations
	{
		/// <summary>CTor</summary>
		public CallQueueRelations()
		{
		}

		/// <summary>Gets all relations of the CallQueueEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountCallQueueSettingEntityUsingCallQueueId);
			toReturn.Add(this.CallQueueAssignmentEntityUsingCallQueueId);
			toReturn.Add(this.CallQueueCriteriaEntityUsingCallQueueId);
			toReturn.Add(this.CallQueueCustomerEntityUsingCallQueueId);
			toReturn.Add(this.CallsEntityUsingCallQueueId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingCallQueueId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueId);
			toReturn.Add(this.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueId);
			toReturn.Add(this.SystemGeneratedCallQueueCriteriaEntityUsingCallQueueId);

			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.ScriptsEntityUsingScriptId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and AccountCallQueueSettingEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueue.CallQueueId - AccountCallQueueSetting.CallQueueId
		/// </summary>
		public virtual IEntityRelation AccountCallQueueSettingEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCallQueueSetting" , true);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, AccountCallQueueSettingFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCallQueueSettingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and CallQueueAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueue.CallQueueId - CallQueueAssignment.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallQueueAssignmentEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueAssignment" , true);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, CallQueueAssignmentFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and CallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueue.CallQueueId - CallQueueCriteria.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallQueueCriteriaEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCriteria" , true);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, CallQueueCriteriaFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueue.CallQueueId - CallQueueCustomer.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, CallQueueCustomerFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and CallsEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueue.CallQueueId - Calls.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Calls" , true);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, CallsFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and HealthPlanCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueue.CallQueueId - HealthPlanCallQueueCriteria.CallQueueId
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCallQueueCriteria" , true);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, HealthPlanCallQueueCriteriaFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and HealthPlanCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueue.CallQueueId - HealthPlanCallQueueCriteriaAssignment.CallQueueId
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, HealthPlanCallQueueCriteriaAssignmentFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and SystemGeneratedCallQueueAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueue.CallQueueId - SystemGeneratedCallQueueAssignment.CallQueueId
		/// </summary>
		public virtual IEntityRelation SystemGeneratedCallQueueAssignmentEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SystemGeneratedCallQueueAssignment" , true);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, SystemGeneratedCallQueueAssignmentFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and SystemGeneratedCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueue.CallQueueId - SystemGeneratedCallQueueCriteria.CallQueueId
		/// </summary>
		public virtual IEntityRelation SystemGeneratedCallQueueCriteriaEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SystemGenertedCallQueueCriteria" , true);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, SystemGeneratedCallQueueCriteriaFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueue.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueue.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueEntity and ScriptsEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueue.ScriptId - Scripts.ScriptId
		/// </summary>
		public virtual IEntityRelation ScriptsEntityUsingScriptId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Scripts", false);
				relation.AddEntityFieldPair(ScriptsFields.ScriptId, CallQueueFields.ScriptId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScriptsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", true);
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
