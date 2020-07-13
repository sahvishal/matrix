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
	/// <summary>Implements the static Relations variant for the entity: StaffEventRole. </summary>
	public partial class StaffEventRoleRelations
	{
		/// <summary>CTor</summary>
		public StaffEventRoleRelations()
		{
		}

		/// <summary>Gets all relations of the StaffEventRoleEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventStaffAssignmentEntityUsingStaffEventRoleId);
			toReturn.Add(this.PodDefaultTeamEntityUsingEventRoleId);
			toReturn.Add(this.StaffEventRoleTestEntityUsingStaffEventRoleId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between StaffEventRoleEntity and EventStaffAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// StaffEventRole.StaffEventRoleId - EventStaffAssignment.StaffEventRoleId
		/// </summary>
		public virtual IEntityRelation EventStaffAssignmentEntityUsingStaffEventRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventStaffAssignment" , true);
				relation.AddEntityFieldPair(StaffEventRoleFields.StaffEventRoleId, EventStaffAssignmentFields.StaffEventRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventRoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between StaffEventRoleEntity and PodDefaultTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// StaffEventRole.StaffEventRoleId - PodDefaultTeam.EventRoleId
		/// </summary>
		public virtual IEntityRelation PodDefaultTeamEntityUsingEventRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodDefaultTeam" , true);
				relation.AddEntityFieldPair(StaffEventRoleFields.StaffEventRoleId, PodDefaultTeamFields.EventRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventRoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDefaultTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between StaffEventRoleEntity and StaffEventRoleTestEntity over the 1:n relation they have, using the relation between the fields:
		/// StaffEventRole.StaffEventRoleId - StaffEventRoleTest.StaffEventRoleId
		/// </summary>
		public virtual IEntityRelation StaffEventRoleTestEntityUsingStaffEventRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StaffEventRoleTest" , true);
				relation.AddEntityFieldPair(StaffEventRoleFields.StaffEventRoleId, StaffEventRoleTestFields.StaffEventRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventRoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventRoleTestEntity", false);
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
