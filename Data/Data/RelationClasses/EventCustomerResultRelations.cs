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
	/// <summary>Implements the static Relations variant for the entity: EventCustomerResult. </summary>
	public partial class EventCustomerResultRelations
	{
		/// <summary>CTor</summary>
		public EventCustomerResultRelations()
		{
		}

		/// <summary>Gets all relations of the EventCustomerResultEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CdcontentGeneratorTrackingEntityUsingEventCustomerResultId);
			toReturn.Add(this.CriticalCustomerCommunicationRecordEntityUsingEventCustomerResultId);
			toReturn.Add(this.CustomerEventScreeningTestsEntityUsingEventCustomerResultId);
			toReturn.Add(this.CustomerResultScreeningCommunicationEntityUsingEventCustomerResultId);
			toReturn.Add(this.EventCustomerPdfgenerationErrorLogEntityUsingEventCustomerResultId);
			toReturn.Add(this.KynLabValuesEntityUsingEventCustomerResultId);
			toReturn.Add(this.MolinaAttestationEntityUsingEventCustomerResultId);
			toReturn.Add(this.PriorityInQueueEntityUsingEventCustomerResultId);
			toReturn.Add(this.WellMedAttestationEntityUsingEventCustomerResultId);
			toReturn.Add(this.EventCustomerResultBloodLabEntityUsingEventCustomerResultId);
			toReturn.Add(this.EventCustomerResultBloodLabParserEntityUsingEventCustomerResultId);
			toReturn.Add(this.EventCustomerResultTraleEntityUsingEventCustomerResultId);
			toReturn.Add(this.EventCustomersEntityUsingEventCustomerResultId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.LookupEntityUsingResultSummary);
			toReturn.Add(this.OrganizationRoleUserEntityUsingSignedOffBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingRegeneratedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingVerifiedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingInvoiceDateUpdatedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingChatPdfReviewedByOverreadPhysicianId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCodedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingChatPdfReviewedByPhysicianId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and CdcontentGeneratorTrackingEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - CdcontentGeneratorTracking.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation CdcontentGeneratorTrackingEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CdcontentGeneratorTracking" , true);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, CdcontentGeneratorTrackingFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CdcontentGeneratorTrackingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and CriticalCustomerCommunicationRecordEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - CriticalCustomerCommunicationRecord.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation CriticalCustomerCommunicationRecordEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CriticalCustomerCommunicationRecord" , true);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, CriticalCustomerCommunicationRecordFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CriticalCustomerCommunicationRecordEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and CustomerEventScreeningTestsEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - CustomerEventScreeningTests.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation CustomerEventScreeningTestsEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventScreeningTests" , true);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, CustomerEventScreeningTestsFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and CustomerResultScreeningCommunicationEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - CustomerResultScreeningCommunication.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation CustomerResultScreeningCommunicationEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerResultScreeningCommunication" , true);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, CustomerResultScreeningCommunicationFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerResultScreeningCommunicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and EventCustomerPdfgenerationErrorLogEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - EventCustomerPdfgenerationErrorLog.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerPdfgenerationErrorLogEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerPdfgenerationErrorLog" , true);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, EventCustomerPdfgenerationErrorLogFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerPdfgenerationErrorLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and KynLabValuesEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - KynLabValues.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation KynLabValuesEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "KynLabValues" , true);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, KynLabValuesFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and MolinaAttestationEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - MolinaAttestation.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation MolinaAttestationEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MolinaAttestation" , true);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, MolinaAttestationFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MolinaAttestationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and PriorityInQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - PriorityInQueue.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation PriorityInQueueEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PriorityInQueue" , true);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, PriorityInQueueFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PriorityInQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and WellMedAttestationEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - WellMedAttestation.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation WellMedAttestationEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "WellMedAttestation" , true);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, WellMedAttestationFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WellMedAttestationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and EventCustomerResultBloodLabEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - EventCustomerResultBloodLab.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultBloodLabEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomerResultBloodLab", true);

				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, EventCustomerResultBloodLabFields.EventCustomerResultId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultBloodLabEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and EventCustomerResultBloodLabParserEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - EventCustomerResultBloodLabParser.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultBloodLabParserEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomerResultBloodLabParser", true);

				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, EventCustomerResultBloodLabParserFields.EventCustomerResultId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultBloodLabParserEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and EventCustomerResultTraleEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - EventCustomerResultTrale.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultTraleEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomerResultTrale", true);

				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, EventCustomerResultTraleFields.EventCustomerResultId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultTraleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and EventCustomersEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.EventCustomerResultId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomers", false);



				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerResultFields.EventCustomerResultId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, EventCustomerResultFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, EventCustomerResultFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.ResultSummary - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingResultSummary
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventCustomerResultFields.ResultSummary);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.SignedOffBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingSignedOffBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser___", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.SignedOffBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.RegeneratedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingRegeneratedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser__", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.RegeneratedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.VerifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingVerifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser____", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.VerifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.InvoiceDateUpdatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingInvoiceDateUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser______", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.InvoiceDateUpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.ChatPdfReviewedByOverreadPhysicianId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingChatPdfReviewedByOverreadPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser________", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.ChatPdfReviewedByOverreadPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.CodedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCodedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_____", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.CodedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResult.ChatPdfReviewedByPhysicianId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingChatPdfReviewedByPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_______", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.ChatPdfReviewedByPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", true);
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
