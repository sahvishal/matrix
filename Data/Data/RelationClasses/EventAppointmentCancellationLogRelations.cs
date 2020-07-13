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
	/// <summary>Implements the static Relations variant for the entity: EventAppointmentCancellationLog. </summary>
	public partial class EventAppointmentCancellationLogRelations
	{
		/// <summary>CTor</summary>
		public EventAppointmentCancellationLogRelations()
		{
		}

		/// <summary>Gets all relations of the EventAppointmentCancellationLogEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerRegistrationNotesEntityUsingNoteId);
			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.LookupEntityUsingReasonId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.RefundRequestEntityUsingRefundRequestId);
			toReturn.Add(this.RescheduleCancelDispositionEntityUsingSubReasonId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EventAppointmentCancellationLogEntity and CustomerRegistrationNotesEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAppointmentCancellationLog.NoteId - CustomerRegistrationNotes.CustomerRegistrationNotesId
		/// </summary>
		public virtual IEntityRelation CustomerRegistrationNotesEntityUsingNoteId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerRegistrationNotes", false);
				relation.AddEntityFieldPair(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, EventAppointmentCancellationLogFields.NoteId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerRegistrationNotesEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAppointmentCancellationLogEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAppointmentCancellationLog.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventAppointmentCancellationLogFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAppointmentCancellationLogEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAppointmentCancellationLog.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, EventAppointmentCancellationLogFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAppointmentCancellationLogEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAppointmentCancellationLog.ReasonId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventAppointmentCancellationLogFields.ReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAppointmentCancellationLogEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAppointmentCancellationLog.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventAppointmentCancellationLogFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAppointmentCancellationLogEntity and RefundRequestEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAppointmentCancellationLog.RefundRequestId - RefundRequest.RefundRequestId
		/// </summary>
		public virtual IEntityRelation RefundRequestEntityUsingRefundRequestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "RefundRequest", false);
				relation.AddEntityFieldPair(RefundRequestFields.RefundRequestId, EventAppointmentCancellationLogFields.RefundRequestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAppointmentCancellationLogEntity and RescheduleCancelDispositionEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAppointmentCancellationLog.SubReasonId - RescheduleCancelDisposition.Id
		/// </summary>
		public virtual IEntityRelation RescheduleCancelDispositionEntityUsingSubReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "RescheduleCancelDisposition", false);
				relation.AddEntityFieldPair(RescheduleCancelDispositionFields.Id, EventAppointmentCancellationLogFields.SubReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RescheduleCancelDispositionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", true);
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
