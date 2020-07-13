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
	/// <summary>Implements the static Relations variant for the entity: NotesDetails. </summary>
	public partial class NotesDetailsRelations
	{
		/// <summary>CTor</summary>
		public NotesDetailsRelations()
		{
		}

		/// <summary>Gets all relations of the NotesDetailsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallQueueCustomerEntityUsingNotesId);
			toReturn.Add(this.CustomerProfileEntityUsingDoNotContactReasonNotesId);
			toReturn.Add(this.EventsEntityUsingEmrNotesId);
			toReturn.Add(this.PriorityInQueueEntityUsingNoteId);
			toReturn.Add(this.CriticalCustomerCommunicationRecordEntityUsingNoteId);
			toReturn.Add(this.HospitalPartnerEventNotesEntityUsingNotesId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between NotesDetailsEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// NotesDetails.NoteId - CallQueueCustomer.NotesId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingNotesId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, CallQueueCustomerFields.NotesId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotesDetailsEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// NotesDetails.NoteId - CustomerProfile.DoNotContactReasonNotesId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingDoNotContactReasonNotesId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile" , true);
				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, CustomerProfileFields.DoNotContactReasonNotesId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotesDetailsEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// NotesDetails.NoteId - Events.EmrNotesId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEmrNotesId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events" , true);
				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, EventsFields.EmrNotesId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotesDetailsEntity and PriorityInQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// NotesDetails.NoteId - PriorityInQueue.NoteId
		/// </summary>
		public virtual IEntityRelation PriorityInQueueEntityUsingNoteId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PriorityInQueue" , true);
				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, PriorityInQueueFields.NoteId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PriorityInQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotesDetailsEntity and CriticalCustomerCommunicationRecordEntity over the 1:1 relation they have, using the relation between the fields:
		/// NotesDetails.NoteId - CriticalCustomerCommunicationRecord.NoteId
		/// </summary>
		public virtual IEntityRelation CriticalCustomerCommunicationRecordEntityUsingNoteId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CriticalCustomerCommunicationRecord", true);

				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, CriticalCustomerCommunicationRecordFields.NoteId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CriticalCustomerCommunicationRecordEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotesDetailsEntity and HospitalPartnerEventNotesEntity over the 1:1 relation they have, using the relation between the fields:
		/// NotesDetails.NoteId - HospitalPartnerEventNotes.NotesId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerEventNotesEntityUsingNotesId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "HospitalPartnerEventNotes", true);

				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, HospitalPartnerEventNotesFields.NotesId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEventNotesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NotesDetailsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// NotesDetails.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, NotesDetailsFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between NotesDetailsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// NotesDetails.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, NotesDetailsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", true);
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
