///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:41
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
	/// <summary>Implements the static Relations variant for the entity: CallQueueCustomer. </summary>
	public partial class CallQueueCustomerRelations
	{
		/// <summary>CTor</summary>
		public CallQueueCustomerRelations()
		{
		}

		/// <summary>Gets all relations of the CallQueueCustomerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallQueueCustomerCallEntityUsingCallQueueCustomerId);
			toReturn.Add(this.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueCustomerId);
			toReturn.Add(this.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueCustomerId);
			toReturn.Add(this.CallQueueCustomerLockEntityUsingCallQueueCustomerId);
			toReturn.Add(this.AccountEntityUsingHealthPlanId);
			toReturn.Add(this.ActivityTypeEntityUsingActivityId);
			toReturn.Add(this.CallQueueEntityUsingCallQueueId);
			toReturn.Add(this.CallQueueCriteriaEntityUsingCallQueueCriteriaId);
			toReturn.Add(this.CampaignEntityUsingCampaignId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.LanguageEntityUsingLanguageId);
			toReturn.Add(this.LookupEntityUsingDoNotContactUpdateSource);
			toReturn.Add(this.NotesDetailsEntityUsingNotesId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.ProspectCustomerEntityUsingProspectCustomerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and CallQueueCustomerCallEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueueCustomer.CallQueueCustomerId - CallQueueCustomerCall.CallQueueCustomerId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerCallEntityUsingCallQueueCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomerCall" , true);
				relation.AddEntityFieldPair(CallQueueCustomerFields.CallQueueCustomerId, CallQueueCustomerCallFields.CallQueueCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and CustomerCallQueueCallAttemptEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueueCustomer.CallQueueCustomerId - CustomerCallQueueCallAttempt.CallQueueCustomerId
		/// </summary>
		public virtual IEntityRelation CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerCallQueueCallAttempt" , true);
				relation.AddEntityFieldPair(CallQueueCustomerFields.CallQueueCustomerId, CustomerCallQueueCallAttemptFields.CallQueueCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCallQueueCallAttemptEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and HealthPlanCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueueCustomer.CallQueueCustomerId - HealthPlanCallQueueCriteriaAssignment.CallQueueCustomerId
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(CallQueueCustomerFields.CallQueueCustomerId, HealthPlanCallQueueCriteriaAssignmentFields.CallQueueCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and SystemGeneratedCallQueueAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueueCustomer.CallQueueCustomerId - SystemGeneratedCallQueueAssignment.CallQueueCustomerId
		/// </summary>
		public virtual IEntityRelation SystemGeneratedCallQueueAssignmentEntityUsingCallQueueCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SystemGeneratedCallQueueAssignment" , true);
				relation.AddEntityFieldPair(CallQueueCustomerFields.CallQueueCustomerId, SystemGeneratedCallQueueAssignmentFields.CallQueueCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and CallQueueCustomerLockEntity over the 1:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.CallQueueCustomerId - CallQueueCustomerLock.CallQueueCustomerId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerLockEntityUsingCallQueueCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CallQueueCustomerLock", true);

				relation.AddEntityFieldPair(CallQueueCustomerFields.CallQueueCustomerId, CallQueueCustomerLockFields.CallQueueCustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerLockEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and AccountEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.HealthPlanId - Account.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Account", false);
				relation.AddEntityFieldPair(AccountFields.AccountId, CallQueueCustomerFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and ActivityTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.ActivityId - ActivityType.Id
		/// </summary>
		public virtual IEntityRelation ActivityTypeEntityUsingActivityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ActivityType", false);
				relation.AddEntityFieldPair(ActivityTypeFields.Id, CallQueueCustomerFields.ActivityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActivityTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and CallQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.CallQueueId - CallQueue.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallQueueEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallQueue", false);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, CallQueueCustomerFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and CallQueueCriteriaEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.CallQueueCriteriaId - CallQueueCriteria.CallQueueCriteriaId
		/// </summary>
		public virtual IEntityRelation CallQueueCriteriaEntityUsingCallQueueCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallQueueCriteria", false);
				relation.AddEntityFieldPair(CallQueueCriteriaFields.CallQueueCriteriaId, CallQueueCustomerFields.CallQueueCriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCriteriaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and CampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.CampaignId - Campaign.Id
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Campaign", false);
				relation.AddEntityFieldPair(CampaignFields.Id, CallQueueCustomerFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CallQueueCustomerFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, CallQueueCustomerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, CallQueueCustomerFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and LanguageEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.LanguageId - Language.Id
		/// </summary>
		public virtual IEntityRelation LanguageEntityUsingLanguageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Language", false);
				relation.AddEntityFieldPair(LanguageFields.Id, CallQueueCustomerFields.LanguageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.DoNotContactUpdateSource - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingDoNotContactUpdateSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallQueueCustomerFields.DoNotContactUpdateSource);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and NotesDetailsEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.NotesId - NotesDetails.NoteId
		/// </summary>
		public virtual IEntityRelation NotesDetailsEntityUsingNotesId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotesDetails", false);
				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, CallQueueCustomerFields.NotesId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.AssignedToOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueCustomerFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser__", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueCustomerFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueCustomerFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerEntity and ProspectCustomerEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomer.ProspectCustomerId - ProspectCustomer.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ProspectCustomer", false);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, CallQueueCustomerFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", true);
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
