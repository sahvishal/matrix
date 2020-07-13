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
	/// <summary>Implements the static Relations variant for the entity: EventSlotAppointment. </summary>
	public partial class EventSlotAppointmentRelations
	{
		/// <summary>CTor</summary>
		public EventSlotAppointmentRelations()
		{
		}

		/// <summary>Gets all relations of the EventSlotAppointmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.EventSchedulingSlotEntityUsingSlotId);
			toReturn.Add(this.EventAppointmentEntityUsingAppointmentId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between EventSlotAppointmentEntity and EventSchedulingSlotEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventSlotAppointment.SlotId - EventSchedulingSlot.SlotId
		/// </summary>
		public virtual IEntityRelation EventSchedulingSlotEntityUsingSlotId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventSchedulingSlot", false);



				relation.AddEntityFieldPair(EventSchedulingSlotFields.SlotId, EventSlotAppointmentFields.SlotId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSchedulingSlotEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSlotAppointmentEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventSlotAppointmentEntity and EventAppointmentEntity over the m:1 relation they have, using the relation between the fields:
		/// EventSlotAppointment.AppointmentId - EventAppointment.AppointmentId
		/// </summary>
		public virtual IEntityRelation EventAppointmentEntityUsingAppointmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventAppointment", false);
				relation.AddEntityFieldPair(EventAppointmentFields.AppointmentId, EventSlotAppointmentFields.AppointmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSlotAppointmentEntity", true);
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
