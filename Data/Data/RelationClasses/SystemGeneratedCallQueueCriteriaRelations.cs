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
	/// <summary>Implements the static Relations variant for the entity: SystemGeneratedCallQueueCriteria. </summary>
	public partial class SystemGeneratedCallQueueCriteriaRelations
	{
		/// <summary>CTor</summary>
		public SystemGeneratedCallQueueCriteriaRelations()
		{
		}

		/// <summary>Gets all relations of the SystemGeneratedCallQueueCriteriaEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.SystemGeneratedCallQueueAssignmentEntityUsingCriteriaId);

			toReturn.Add(this.CallQueueEntityUsingCallQueueId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between SystemGeneratedCallQueueCriteriaEntity and SystemGeneratedCallQueueAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// SystemGeneratedCallQueueCriteria.Id - SystemGeneratedCallQueueAssignment.CriteriaId
		/// </summary>
		public virtual IEntityRelation SystemGeneratedCallQueueAssignmentEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SystemGeneratedCallQueueAssignment" , true);
				relation.AddEntityFieldPair(SystemGeneratedCallQueueCriteriaFields.Id, SystemGeneratedCallQueueAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueAssignmentEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between SystemGeneratedCallQueueCriteriaEntity and CallQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// SystemGeneratedCallQueueCriteria.CallQueueId - CallQueue.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallQueueEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallQueue", false);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, SystemGeneratedCallQueueCriteriaFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SystemGeneratedCallQueueCriteriaEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// SystemGeneratedCallQueueCriteria.AssignedToOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SystemGeneratedCallQueueCriteriaFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SystemGeneratedCallQueueCriteriaEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// SystemGeneratedCallQueueCriteria.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser__", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SystemGeneratedCallQueueCriteriaFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SystemGeneratedCallQueueCriteriaEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// SystemGeneratedCallQueueCriteria.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SystemGeneratedCallQueueCriteriaFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", true);
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
