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
	/// <summary>Implements the static Relations variant for the entity: EventAppointment. </summary>
	public partial class EventAppointmentRelations
	{
		/// <summary>CTor</summary>
		public EventAppointmentRelations()
		{
		}

		/// <summary>Gets all relations of the EventAppointmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventCustomersEntityUsingAppointmentId);
			toReturn.Add(this.EventSlotAppointmentEntityUsingAppointmentId);

			toReturn.Add(this.OrganizationRoleUserEntityUsingScheduledByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EventAppointmentEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// EventAppointment.AppointmentId - EventCustomers.AppointmentId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingAppointmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers" , true);
				relation.AddEntityFieldPair(EventAppointmentFields.AppointmentId, EventCustomersFields.AppointmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventAppointmentEntity and EventSlotAppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// EventAppointment.AppointmentId - EventSlotAppointment.AppointmentId
		/// </summary>
		public virtual IEntityRelation EventSlotAppointmentEntityUsingAppointmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventSlotAppointment" , true);
				relation.AddEntityFieldPair(EventAppointmentFields.AppointmentId, EventSlotAppointmentFields.AppointmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSlotAppointmentEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between EventAppointmentEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAppointment.ScheduledByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingScheduledByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventAppointmentFields.ScheduledByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentEntity", true);
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
