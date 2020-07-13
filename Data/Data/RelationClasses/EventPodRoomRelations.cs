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
	/// <summary>Implements the static Relations variant for the entity: EventPodRoom. </summary>
	public partial class EventPodRoomRelations
	{
		/// <summary>CTor</summary>
		public EventPodRoomRelations()
		{
		}

		/// <summary>Gets all relations of the EventPodRoomEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventPodRoomTestEntityUsingEventPodRoomId);
			toReturn.Add(this.EventSchedulingSlotEntityUsingEventPodRoomId);

			toReturn.Add(this.EventPodEntityUsingEventPodId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EventPodRoomEntity and EventPodRoomTestEntity over the 1:n relation they have, using the relation between the fields:
		/// EventPodRoom.EventPodRoomId - EventPodRoomTest.EventPodRoomId
		/// </summary>
		public virtual IEntityRelation EventPodRoomTestEntityUsingEventPodRoomId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPodRoomTest" , true);
				relation.AddEntityFieldPair(EventPodRoomFields.EventPodRoomId, EventPodRoomTestFields.EventPodRoomId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodRoomEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodRoomTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventPodRoomEntity and EventSchedulingSlotEntity over the 1:n relation they have, using the relation between the fields:
		/// EventPodRoom.EventPodRoomId - EventSchedulingSlot.EventPodRoomId
		/// </summary>
		public virtual IEntityRelation EventSchedulingSlotEntityUsingEventPodRoomId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventSchedulingSlot" , true);
				relation.AddEntityFieldPair(EventPodRoomFields.EventPodRoomId, EventSchedulingSlotFields.EventPodRoomId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodRoomEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSchedulingSlotEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between EventPodRoomEntity and EventPodEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPodRoom.EventPodId - EventPod.EventPodId
		/// </summary>
		public virtual IEntityRelation EventPodEntityUsingEventPodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventPod", false);
				relation.AddEntityFieldPair(EventPodFields.EventPodId, EventPodRoomFields.EventPodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodRoomEntity", true);
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
