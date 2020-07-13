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
	/// <summary>Implements the static Relations variant for the entity: EventStaffAssignment. </summary>
	public partial class EventStaffAssignmentRelations
	{
		/// <summary>CTor</summary>
		public EventStaffAssignmentRelations()
		{
		}

		/// <summary>Gets all relations of the EventStaffAssignmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingScheduledByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingActualStaffOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingScheduledStaffOrgRoleUserId);
			toReturn.Add(this.PodDetailsEntityUsingPodId);
			toReturn.Add(this.StaffEventRoleEntityUsingStaffEventRoleId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EventStaffAssignmentEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventStaffAssignment.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, EventStaffAssignmentFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventStaffAssignmentEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventStaffAssignment.ScheduledByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingScheduledByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser__", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventStaffAssignmentFields.ScheduledByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventStaffAssignmentEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventStaffAssignment.ActualStaffOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingActualStaffOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventStaffAssignmentFields.ActualStaffOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventStaffAssignmentEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventStaffAssignment.ScheduledStaffOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingScheduledStaffOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventStaffAssignmentFields.ScheduledStaffOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventStaffAssignmentEntity and PodDetailsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventStaffAssignment.PodId - PodDetails.PodId
		/// </summary>
		public virtual IEntityRelation PodDetailsEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PodDetails", false);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, EventStaffAssignmentFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventStaffAssignmentEntity and StaffEventRoleEntity over the m:1 relation they have, using the relation between the fields:
		/// EventStaffAssignment.StaffEventRoleId - StaffEventRole.StaffEventRoleId
		/// </summary>
		public virtual IEntityRelation StaffEventRoleEntityUsingStaffEventRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "StaffEventRole", false);
				relation.AddEntityFieldPair(StaffEventRoleFields.StaffEventRoleId, EventStaffAssignmentFields.StaffEventRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventRoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", true);
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
