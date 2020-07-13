///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:38
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
	/// <summary>Implements the static Relations variant for the entity: PodDetails. </summary>
	public partial class PodDetailsRelations
	{
		/// <summary>CTor</summary>
		public PodDetailsRelations()
		{
		}

		/// <summary>Gets all relations of the PodDetailsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventNoteEntityUsingPodId);
			toReturn.Add(this.EventPodEntityUsingPodId);
			toReturn.Add(this.EventStaffAssignmentEntityUsingPodId);
			toReturn.Add(this.PhysicianPodEntityUsingPodId);
			toReturn.Add(this.PodDefaultTeamEntityUsingPodId);
			toReturn.Add(this.PodInventoryItemEntityUsingPodId);
			toReturn.Add(this.PodPackageEntityUsingPodId);
			toReturn.Add(this.PodRoomEntityUsingPodId);
			toReturn.Add(this.PodTerritoryEntityUsingPodId);
			toReturn.Add(this.PodTestEntityUsingPodId);
			toReturn.Add(this.SalesRepPodAssigmentsEntityUsingPodId);

			toReturn.Add(this.OrganizationEntityUsingOrganizationId);
			toReturn.Add(this.VanDetailsEntityUsingVanId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and EventNoteEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - EventNote.PodId
		/// </summary>
		public virtual IEntityRelation EventNoteEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventNote" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, EventNoteFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventNoteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and EventPodEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - EventPod.PodId
		/// </summary>
		public virtual IEntityRelation EventPodEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPod" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, EventPodFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and EventStaffAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - EventStaffAssignment.PodId
		/// </summary>
		public virtual IEntityRelation EventStaffAssignmentEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventStaffAssignment" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, EventStaffAssignmentFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and PhysicianPodEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - PhysicianPod.PodId
		/// </summary>
		public virtual IEntityRelation PhysicianPodEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianPod" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, PhysicianPodFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianPodEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and PodDefaultTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - PodDefaultTeam.PodId
		/// </summary>
		public virtual IEntityRelation PodDefaultTeamEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodDefaultTeam" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, PodDefaultTeamFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDefaultTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and PodInventoryItemEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - PodInventoryItem.PodId
		/// </summary>
		public virtual IEntityRelation PodInventoryItemEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodInventoryItem" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, PodInventoryItemFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodInventoryItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and PodPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - PodPackage.PodId
		/// </summary>
		public virtual IEntityRelation PodPackageEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodPackage" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, PodPackageFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodPackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and PodRoomEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - PodRoom.PodId
		/// </summary>
		public virtual IEntityRelation PodRoomEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodRoom" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, PodRoomFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodRoomEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and PodTerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - PodTerritory.PodId
		/// </summary>
		public virtual IEntityRelation PodTerritoryEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodTerritory" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, PodTerritoryFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodTerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and PodTestEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - PodTest.PodId
		/// </summary>
		public virtual IEntityRelation PodTestEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodTest" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, PodTestFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and SalesRepPodAssigmentsEntity over the 1:n relation they have, using the relation between the fields:
		/// PodDetails.PodId - SalesRepPodAssigments.PodId
		/// </summary>
		public virtual IEntityRelation SalesRepPodAssigmentsEntityUsingPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SalesRepPodAssigments" , true);
				relation.AddEntityFieldPair(PodDetailsFields.PodId, SalesRepPodAssigmentsFields.PodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SalesRepPodAssigmentsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// PodDetails.OrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, PodDetailsFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PodDetailsEntity and VanDetailsEntity over the m:1 relation they have, using the relation between the fields:
		/// PodDetails.VanId - VanDetails.VanId
		/// </summary>
		public virtual IEntityRelation VanDetailsEntityUsingVanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "VanDetails", false);
				relation.AddEntityFieldPair(VanDetailsFields.VanId, PodDetailsFields.VanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("VanDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDetailsEntity", true);
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
