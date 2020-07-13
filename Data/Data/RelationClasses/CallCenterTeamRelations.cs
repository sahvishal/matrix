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
	/// <summary>Implements the static Relations variant for the entity: CallCenterTeam. </summary>
	public partial class CallCenterTeamRelations
	{
		/// <summary>CTor</summary>
		public CallCenterTeamRelations()
		{
		}

		/// <summary>Gets all relations of the CallCenterTeamEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallCenterAgentTeamEntityUsingTeamId);
			toReturn.Add(this.CallCenterAgentTeamLogEntityUsingTeamId);
			toReturn.Add(this.HealthPlanCriteriaTeamAssignmentEntityUsingTeamId);

			toReturn.Add(this.LookupEntityUsingTypeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CallCenterTeamEntity and CallCenterAgentTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// CallCenterTeam.Id - CallCenterAgentTeam.TeamId
		/// </summary>
		public virtual IEntityRelation CallCenterAgentTeamEntityUsingTeamId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterAgentTeam" , true);
				relation.AddEntityFieldPair(CallCenterTeamFields.Id, CallCenterAgentTeamFields.TeamId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterTeamEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterAgentTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallCenterTeamEntity and CallCenterAgentTeamLogEntity over the 1:n relation they have, using the relation between the fields:
		/// CallCenterTeam.Id - CallCenterAgentTeamLog.TeamId
		/// </summary>
		public virtual IEntityRelation CallCenterAgentTeamLogEntityUsingTeamId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterAgentTeamLog" , true);
				relation.AddEntityFieldPair(CallCenterTeamFields.Id, CallCenterAgentTeamLogFields.TeamId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterTeamEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterAgentTeamLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallCenterTeamEntity and HealthPlanCriteriaTeamAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// CallCenterTeam.Id - HealthPlanCriteriaTeamAssignment.TeamId
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaTeamAssignmentEntityUsingTeamId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaTeamAssignment" , true);
				relation.AddEntityFieldPair(CallCenterTeamFields.Id, HealthPlanCriteriaTeamAssignmentFields.TeamId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterTeamEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaTeamAssignmentEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CallCenterTeamEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CallCenterTeam.TypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallCenterTeamFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterTeamEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallCenterTeamEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallCenterTeam.ModifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallCenterTeamFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterTeamEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallCenterTeamEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallCenterTeam.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallCenterTeamFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterTeamEntity", true);
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
