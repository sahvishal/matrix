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
	/// <summary>Implements the static Relations variant for the entity: EventSchedulingSlot. </summary>
	public partial class EventSchedulingSlotRelations
	{
		/// <summary>CTor</summary>
		public EventSchedulingSlotRelations()
		{
		}

		/// <summary>Gets all relations of the EventSchedulingSlotEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.EventSlotAppointmentEntityUsingSlotId);
			toReturn.Add(this.EventPodRoomEntityUsingEventPodRoomId);
			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.LookupEntityUsingStatus);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between EventSchedulingSlotEntity and EventSlotAppointmentEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventSchedulingSlot.SlotId - EventSlotAppointment.SlotId
		/// </summary>
		public virtual IEntityRelation EventSlotAppointmentEntityUsingSlotId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventSlotAppointment", true);

				relation.AddEntityFieldPair(EventSchedulingSlotFields.SlotId, EventSlotAppointmentFields.SlotId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSchedulingSlotEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSlotAppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventSchedulingSlotEntity and EventPodRoomEntity over the m:1 relation they have, using the relation between the fields:
		/// EventSchedulingSlot.EventPodRoomId - EventPodRoom.EventPodRoomId
		/// </summary>
		public virtual IEntityRelation EventPodRoomEntityUsingEventPodRoomId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventPodRoom", false);
				relation.AddEntityFieldPair(EventPodRoomFields.EventPodRoomId, EventSchedulingSlotFields.EventPodRoomId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodRoomEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSchedulingSlotEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventSchedulingSlotEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventSchedulingSlot.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, EventSchedulingSlotFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSchedulingSlotEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventSchedulingSlotEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventSchedulingSlot.Status - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventSchedulingSlotFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSchedulingSlotEntity", true);
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
