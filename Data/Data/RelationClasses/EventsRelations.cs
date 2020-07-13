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
	/// <summary>Implements the static Relations variant for the entity: Events. </summary>
	public partial class EventsRelations
	{
		/// <summary>CTor</summary>
		public EventsRelations()
		{
		}

		/// <summary>Gets all relations of the EventsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfmarketingMaterialEntityUsingEventId);
			toReturn.Add(this.CallDetailsEntityUsingEventId);
			toReturn.Add(this.CallQueueCustomerEntityUsingEventId);
			toReturn.Add(this.CustomerClinicalQuestionAnswerEntityUsingEventId);
			toReturn.Add(this.CustomerEventTestFindingEntityUsingEventId);
			toReturn.Add(this.CustomerOrderHistoryEntityUsingEventId);
			toReturn.Add(this.CustomerRegistrationNotesEntityUsingEventId);
			toReturn.Add(this.CustomEventNotificationEntityUsingEventId);
			toReturn.Add(this.DependentDisqualifiedTestEntityUsingEventId);
			toReturn.Add(this.DisqualifiedTestEntityUsingEventId);
			toReturn.Add(this.EventAccountTestHcpcsCodeEntityUsingEventId);
			toReturn.Add(this.EventAffiliateDetailsEntityUsingEventId);
			toReturn.Add(this.EventAppointmentCancellationLogEntityUsingEventId);
			toReturn.Add(this.EventAppointmentChangeLogEntityUsingOldEventId);
			toReturn.Add(this.EventAppointmentChangeLogEntityUsingNewEventId);
			toReturn.Add(this.EventCallDetailsEntityUsingEventId);
			toReturn.Add(this.EventChecklistTemplateEntityUsingEventId);
			toReturn.Add(this.EventCouponsEntityUsingEventId);
			toReturn.Add(this.EventCustomerQuestionAnswerEntityUsingEventId);
			toReturn.Add(this.EventCustomerResultEntityUsingEventId);
			toReturn.Add(this.EventCustomersEntityUsingEventId);
			toReturn.Add(this.EventFluConsentTemplateEntityUsingEventId);
			toReturn.Add(this.EventHospitalFacilityEntityUsingEventId);
			toReturn.Add(this.EventHospitalPartnerEntityUsingEventId);
			toReturn.Add(this.EventHostPromotionsEntityUsingEventId);
			toReturn.Add(this.EventMarketingOffersEntityUsingEventId);
			toReturn.Add(this.EventMeetingDetailsEntityUsingEventId);
			toReturn.Add(this.EventNotesLogEntityUsingEventId);
			toReturn.Add(this.EventNotificationEntityUsingEventId);
			toReturn.Add(this.EventPackageDetailsEntityUsingEventId);
			toReturn.Add(this.EventPhysicianTestEntityUsingEventId);
			toReturn.Add(this.EventPodEntityUsingEventId);
			toReturn.Add(this.EventProductExclusionEntityUsingEventId);
			toReturn.Add(this.EventProductTypeEntityUsingEventId);
			toReturn.Add(this.EventPublicationEntityUsingEventId);
			toReturn.Add(this.EventScheduleTemplateEntityUsingEventId);
			toReturn.Add(this.EventSchedulingSlotEntityUsingEventId);
			toReturn.Add(this.EventStaffAssignmentEntityUsingEventId);
			toReturn.Add(this.EventSurveyTemplateEntityUsingEventId);
			toReturn.Add(this.EventTaskDetailsEntityUsingEventId);
			toReturn.Add(this.EventTestEntityUsingEventId);
			toReturn.Add(this.EventZipEntityUsingEventId);
			toReturn.Add(this.HealthPlanFillEventCallQueueEntityUsingEventId);
			toReturn.Add(this.HospitalPartnerCustomerEntityUsingEventId);
			toReturn.Add(this.HospitalPartnerEventNotesEntityUsingEventId);
			toReturn.Add(this.HostEventDetailsEntityUsingEventId);
			toReturn.Add(this.HostPaymentEntityUsingEventId);
			toReturn.Add(this.MarketingPrintOrderEventMappingEntityUsingEventId);
			toReturn.Add(this.PhysicianEventAssignmentEntityUsingEventId);
			toReturn.Add(this.PhysicianInvoiceItemEntityUsingEventId);
			toReturn.Add(this.PreQualificationResultEntityUsingEventId);
			toReturn.Add(this.ResultArchiveUploadEntityUsingEventId);
			toReturn.Add(this.SeminarsEntityUsingEventId);
			toReturn.Add(this.EventAccountEntityUsingEventId);
			toReturn.Add(this.CommunicationModeEntityUsingCommunicationModeId);
			toReturn.Add(this.EventTypeEntityUsingEventTypeId);
			toReturn.Add(this.HafTemplateEntityUsingHafTemplateId);
			toReturn.Add(this.LookupEntityUsingGenerateKynXml);
			toReturn.Add(this.LookupEntityUsingGenerateHealthAssesmentFormStatus);
			toReturn.Add(this.LookupEntityUsingGenerateMyBioCheckAssessment);
			toReturn.Add(this.LookupEntityUsingGenerateHkynXml);
			toReturn.Add(this.LookupEntityUsingEventCancellationReasonId);
			toReturn.Add(this.NotesDetailsEntityUsingEmrNotesId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUpdatedByAdmin);
			toReturn.Add(this.OrganizationRoleUserEntityUsingEventActivityOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingSignOffOrgRoleUserId);
			toReturn.Add(this.ScheduleMethodEntityUsingScheduleMethodId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and AfmarketingMaterialEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - AfmarketingMaterial.EventId
		/// </summary>
		public virtual IEntityRelation AfmarketingMaterialEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfmarketingMaterial" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, AfmarketingMaterialFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and CallDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - CallDetails.EventId
		/// </summary>
		public virtual IEntityRelation CallDetailsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallDetails" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, CallDetailsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - CallQueueCustomer.EventId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, CallQueueCustomerFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and CustomerClinicalQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - CustomerClinicalQuestionAnswer.EventId
		/// </summary>
		public virtual IEntityRelation CustomerClinicalQuestionAnswerEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerClinicalQuestionAnswer" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, CustomerClinicalQuestionAnswerFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerClinicalQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and CustomerEventTestFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - CustomerEventTestFinding.EventId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestFindingEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestFinding" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, CustomerEventTestFindingFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestFindingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and CustomerOrderHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - CustomerOrderHistory.EventId
		/// </summary>
		public virtual IEntityRelation CustomerOrderHistoryEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerOrderHistory" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, CustomerOrderHistoryFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerOrderHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and CustomerRegistrationNotesEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - CustomerRegistrationNotes.EventId
		/// </summary>
		public virtual IEntityRelation CustomerRegistrationNotesEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerRegistrationNotes" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, CustomerRegistrationNotesFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerRegistrationNotesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and CustomEventNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - CustomEventNotification.EventId
		/// </summary>
		public virtual IEntityRelation CustomEventNotificationEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomEventNotification" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, CustomEventNotificationFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomEventNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and DependentDisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - DependentDisqualifiedTest.EventId
		/// </summary>
		public virtual IEntityRelation DependentDisqualifiedTestEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DependentDisqualifiedTest" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, DependentDisqualifiedTestFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DependentDisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and DisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - DisqualifiedTest.EventId
		/// </summary>
		public virtual IEntityRelation DisqualifiedTestEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DisqualifiedTest" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, DisqualifiedTestFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventAccountTestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventAccountTestHcpcsCode.EventId
		/// </summary>
		public virtual IEntityRelation EventAccountTestHcpcsCodeEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAccountTestHcpcsCode" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventAccountTestHcpcsCodeFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventAffiliateDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventAffiliateDetails.EventId
		/// </summary>
		public virtual IEntityRelation EventAffiliateDetailsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAffiliateDetails" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventAffiliateDetailsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAffiliateDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventAppointmentCancellationLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventAppointmentCancellationLog.EventId
		/// </summary>
		public virtual IEntityRelation EventAppointmentCancellationLogEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentCancellationLog" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventAppointmentCancellationLogFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventAppointmentChangeLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventAppointmentChangeLog.OldEventId
		/// </summary>
		public virtual IEntityRelation EventAppointmentChangeLogEntityUsingOldEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentChangeLog_" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventAppointmentChangeLogFields.OldEventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentChangeLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventAppointmentChangeLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventAppointmentChangeLog.NewEventId
		/// </summary>
		public virtual IEntityRelation EventAppointmentChangeLogEntityUsingNewEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentChangeLog" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventAppointmentChangeLogFields.NewEventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentChangeLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventCallDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventCallDetails.EventId
		/// </summary>
		public virtual IEntityRelation EventCallDetailsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCallDetails" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventCallDetailsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCallDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventChecklistTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventChecklistTemplate.EventId
		/// </summary>
		public virtual IEntityRelation EventChecklistTemplateEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventChecklistTemplate" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventChecklistTemplateFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventChecklistTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventCouponsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventCoupons.EventId
		/// </summary>
		public virtual IEntityRelation EventCouponsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCoupons" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventCouponsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCouponsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventCustomerQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventCustomerQuestionAnswer.EventId
		/// </summary>
		public virtual IEntityRelation EventCustomerQuestionAnswerEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerQuestionAnswer" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventCustomerQuestionAnswerFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventCustomerResult.EventId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventCustomerResultFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventCustomers.EventId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventCustomersFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventFluConsentTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventFluConsentTemplate.EventId
		/// </summary>
		public virtual IEntityRelation EventFluConsentTemplateEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventFluConsentTemplate" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventFluConsentTemplateFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventFluConsentTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventHospitalFacilityEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventHospitalFacility.EventId
		/// </summary>
		public virtual IEntityRelation EventHospitalFacilityEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventHospitalFacility" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventHospitalFacilityFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventHospitalFacilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventHospitalPartnerEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventHospitalPartner.EventId
		/// </summary>
		public virtual IEntityRelation EventHospitalPartnerEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventHospitalPartner" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventHospitalPartnerFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventHospitalPartnerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventHostPromotionsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventHostPromotions.EventId
		/// </summary>
		public virtual IEntityRelation EventHostPromotionsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventHostPromotions" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventHostPromotionsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventHostPromotionsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventMarketingOffersEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventMarketingOffers.EventId
		/// </summary>
		public virtual IEntityRelation EventMarketingOffersEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventMarketingOffers" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventMarketingOffersFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventMarketingOffersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventMeetingDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventMeetingDetails.EventId
		/// </summary>
		public virtual IEntityRelation EventMeetingDetailsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventMeetingDetails" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventMeetingDetailsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventMeetingDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventNotesLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventNotesLog.EventId
		/// </summary>
		public virtual IEntityRelation EventNotesLogEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventNotesLog" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventNotesLogFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventNotesLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventNotification.EventId
		/// </summary>
		public virtual IEntityRelation EventNotificationEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventNotification" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventNotificationFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventPackageDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventPackageDetails.EventId
		/// </summary>
		public virtual IEntityRelation EventPackageDetailsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPackageDetails" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventPackageDetailsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventPhysicianTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventPhysicianTest.EventId
		/// </summary>
		public virtual IEntityRelation EventPhysicianTestEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPhysicianTest" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventPhysicianTestFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPhysicianTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventPodEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventPod.EventId
		/// </summary>
		public virtual IEntityRelation EventPodEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPod" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventPodFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPodEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventProductExclusionEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventProductExclusion.EventId
		/// </summary>
		public virtual IEntityRelation EventProductExclusionEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventProductExclusion" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventProductExclusionFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventProductExclusionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventProductTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventProductType.EventId
		/// </summary>
		public virtual IEntityRelation EventProductTypeEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventProductType" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventProductTypeFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventProductTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventPublicationEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventPublication.EventId
		/// </summary>
		public virtual IEntityRelation EventPublicationEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPublication" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventPublicationFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPublicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventScheduleTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventScheduleTemplate.EventId
		/// </summary>
		public virtual IEntityRelation EventScheduleTemplateEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventScheduleTemplate" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventScheduleTemplateFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventScheduleTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventSchedulingSlotEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventSchedulingSlot.EventId
		/// </summary>
		public virtual IEntityRelation EventSchedulingSlotEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventSchedulingSlot" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventSchedulingSlotFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSchedulingSlotEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventStaffAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventStaffAssignment.EventId
		/// </summary>
		public virtual IEntityRelation EventStaffAssignmentEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventStaffAssignment" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventStaffAssignmentFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventSurveyTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventSurveyTemplate.EventId
		/// </summary>
		public virtual IEntityRelation EventSurveyTemplateEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventSurveyTemplate" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventSurveyTemplateFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSurveyTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventTaskDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventTaskDetails.EventId
		/// </summary>
		public virtual IEntityRelation EventTaskDetailsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTaskDetails" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventTaskDetailsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTaskDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventTest.EventId
		/// </summary>
		public virtual IEntityRelation EventTestEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTest" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventTestFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventZipEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - EventZip.EventId
		/// </summary>
		public virtual IEntityRelation EventZipEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventZip" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, EventZipFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventZipEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and HealthPlanFillEventCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - HealthPlanFillEventCallQueue.EventId
		/// </summary>
		public virtual IEntityRelation HealthPlanFillEventCallQueueEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanFillEventCallQueue" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, HealthPlanFillEventCallQueueFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanFillEventCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and HospitalPartnerCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - HospitalPartnerCustomer.EventId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerCustomerEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerCustomer" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, HospitalPartnerCustomerFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and HospitalPartnerEventNotesEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - HospitalPartnerEventNotes.EventId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerEventNotesEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerEventNotes" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, HospitalPartnerEventNotesFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEventNotesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and HostEventDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - HostEventDetails.EventId
		/// </summary>
		public virtual IEntityRelation HostEventDetailsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostEventDetails" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, HostEventDetailsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostEventDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and HostPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - HostPayment.EventId
		/// </summary>
		public virtual IEntityRelation HostPaymentEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPayment" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, HostPaymentFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and MarketingPrintOrderEventMappingEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - MarketingPrintOrderEventMapping.EventId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderEventMappingEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrderEventMapping" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, MarketingPrintOrderEventMappingFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEventMappingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and PhysicianEventAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - PhysicianEventAssignment.EventId
		/// </summary>
		public virtual IEntityRelation PhysicianEventAssignmentEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianEventAssignment" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, PhysicianEventAssignmentFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEventAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and PhysicianInvoiceItemEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - PhysicianInvoiceItem.EventId
		/// </summary>
		public virtual IEntityRelation PhysicianInvoiceItemEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianInvoiceItem" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, PhysicianInvoiceItemFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - PreQualificationResult.EventId
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, PreQualificationResultFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and ResultArchiveUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - ResultArchiveUpload.EventId
		/// </summary>
		public virtual IEntityRelation ResultArchiveUploadEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ResultArchiveUpload" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, ResultArchiveUploadFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultArchiveUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and SeminarsEntity over the 1:n relation they have, using the relation between the fields:
		/// Events.EventId - Seminars.EventId
		/// </summary>
		public virtual IEntityRelation SeminarsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Seminars" , true);
				relation.AddEntityFieldPair(EventsFields.EventId, SeminarsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SeminarsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventAccountEntity over the 1:1 relation they have, using the relation between the fields:
		/// Events.EventId - EventAccount.EventId
		/// </summary>
		public virtual IEntityRelation EventAccountEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventAccount", true);

				relation.AddEntityFieldPair(EventsFields.EventId, EventAccountFields.EventId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventsEntity and CommunicationModeEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.CommunicationModeId - CommunicationMode.CommunicationModeId
		/// </summary>
		public virtual IEntityRelation CommunicationModeEntityUsingCommunicationModeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CommunicationMode", false);
				relation.AddEntityFieldPair(CommunicationModeFields.CommunicationModeId, EventsFields.CommunicationModeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CommunicationModeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and EventTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.EventTypeId - EventType.EventTypeId
		/// </summary>
		public virtual IEntityRelation EventTypeEntityUsingEventTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventType", false);
				relation.AddEntityFieldPair(EventTypeFields.EventTypeId, EventsFields.EventTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and HafTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.HafTemplateId - HafTemplate.HaftemplateId
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HafTemplate", false);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, EventsFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.GenerateKynXml - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGenerateKynXml
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.GenerateKynXml);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.GenerateHealthAssesmentFormStatus - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGenerateHealthAssesmentFormStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup____", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.GenerateHealthAssesmentFormStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.GenerateMyBioCheckAssessment - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGenerateMyBioCheckAssessment
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup___", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.GenerateMyBioCheckAssessment);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.GenerateHkynXml - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGenerateHkynXml
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup__", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.GenerateHkynXml);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.EventCancellationReasonId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingEventCancellationReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.EventCancellationReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and NotesDetailsEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.EmrNotesId - NotesDetails.NoteId
		/// </summary>
		public virtual IEntityRelation NotesDetailsEntityUsingEmrNotesId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotesDetails", false);
				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, EventsFields.EmrNotesId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.UpdatedByAdmin - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUpdatedByAdmin
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser____", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.UpdatedByAdmin);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.EventActivityOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingEventActivityOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser__", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.EventActivityOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.AssignedToOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.SignOffOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingSignOffOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser___", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.SignOffOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventsEntity and ScheduleMethodEntity over the m:1 relation they have, using the relation between the fields:
		/// Events.ScheduleMethodId - ScheduleMethod.ScheduleMethodId
		/// </summary>
		public virtual IEntityRelation ScheduleMethodEntityUsingScheduleMethodId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ScheduleMethod", false);
				relation.AddEntityFieldPair(ScheduleMethodFields.ScheduleMethodId, EventsFields.ScheduleMethodId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScheduleMethodEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", true);
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
