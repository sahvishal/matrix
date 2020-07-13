///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
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
	/// <summary>Implements the static Relations variant for the entity: Calls. </summary>
	public partial class CallsRelations
	{
		/// <summary>CTor</summary>
		public CallsRelations()
		{
		}

		/// <summary>Gets all relations of the CallsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallCenterNotesEntityUsingCallId);
			toReturn.Add(this.CallQueueCustomerCallEntityUsingCallId);
			toReturn.Add(this.CustomerAccountGlocomNumberEntityUsingCallId);
			toReturn.Add(this.CustomerCallQueueCallAttemptEntityUsingCallId);
			toReturn.Add(this.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCallId);
			toReturn.Add(this.PreQualificationResultEntityUsingCallId);
			toReturn.Add(this.ProspectCustomerCallEntityUsingCallId);
			toReturn.Add(this.CallDetailsEntityUsingCallDetailsId);
			toReturn.Add(this.AccountEntityUsingHealthPlanId);
			toReturn.Add(this.CallQueueEntityUsingCallQueueId);
			toReturn.Add(this.CampaignEntityUsingCampaignId);
			toReturn.Add(this.LookupEntityUsingProductTypeId);
			toReturn.Add(this.LookupEntityUsingNotInterestedReasonId);
			toReturn.Add(this.LookupEntityUsingDialerType);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CallsEntity and CallCenterNotesEntity over the 1:n relation they have, using the relation between the fields:
		/// Calls.CallId - CallCenterNotes.CallId
		/// </summary>
		public virtual IEntityRelation CallCenterNotesEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterNotes" , true);
				relation.AddEntityFieldPair(CallsFields.CallId, CallCenterNotesFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterNotesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallsEntity and CallQueueCustomerCallEntity over the 1:n relation they have, using the relation between the fields:
		/// Calls.CallId - CallQueueCustomerCall.CallId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerCallEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomerCall" , true);
				relation.AddEntityFieldPair(CallsFields.CallId, CallQueueCustomerCallFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallsEntity and CustomerAccountGlocomNumberEntity over the 1:n relation they have, using the relation between the fields:
		/// Calls.CallId - CustomerAccountGlocomNumber.CallId
		/// </summary>
		public virtual IEntityRelation CustomerAccountGlocomNumberEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerAccountGlocomNumber" , true);
				relation.AddEntityFieldPair(CallsFields.CallId, CustomerAccountGlocomNumberFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerAccountGlocomNumberEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallsEntity and CustomerCallQueueCallAttemptEntity over the 1:n relation they have, using the relation between the fields:
		/// Calls.CallId - CustomerCallQueueCallAttempt.CallId
		/// </summary>
		public virtual IEntityRelation CustomerCallQueueCallAttemptEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerCallQueueCallAttempt" , true);
				relation.AddEntityFieldPair(CallsFields.CallId, CustomerCallQueueCallAttemptFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCallQueueCallAttemptEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallsEntity and PreAssessmentCustomerCallQueueCallAttemptEntity over the 1:n relation they have, using the relation between the fields:
		/// Calls.CallId - PreAssessmentCustomerCallQueueCallAttempt.CallId
		/// </summary>
		public virtual IEntityRelation PreAssessmentCustomerCallQueueCallAttemptEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreAssessmentCustomerCallQueueCallAttempt" , true);
				relation.AddEntityFieldPair(CallsFields.CallId, PreAssessmentCustomerCallQueueCallAttemptFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreAssessmentCustomerCallQueueCallAttemptEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallsEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Calls.CallId - PreQualificationResult.CallId
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult" , true);
				relation.AddEntityFieldPair(CallsFields.CallId, PreQualificationResultFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallsEntity and ProspectCustomerCallEntity over the 1:n relation they have, using the relation between the fields:
		/// Calls.CallId - ProspectCustomerCall.CallId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerCallEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectCustomerCall" , true);
				relation.AddEntityFieldPair(CallsFields.CallId, ProspectCustomerCallFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallsEntity and CallDetailsEntity over the 1:1 relation they have, using the relation between the fields:
		/// Calls.CallId - CallDetails.CallDetailsId
		/// </summary>
		public virtual IEntityRelation CallDetailsEntityUsingCallDetailsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CallDetails", true);

				relation.AddEntityFieldPair(CallsFields.CallId, CallDetailsFields.CallDetailsId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallsEntity and AccountEntity over the m:1 relation they have, using the relation between the fields:
		/// Calls.HealthPlanId - Account.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Account", false);
				relation.AddEntityFieldPair(AccountFields.AccountId, CallsFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallsEntity and CallQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// Calls.CallQueueId - CallQueue.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallQueueEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallQueue", false);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, CallsFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallsEntity and CampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// Calls.CampaignId - Campaign.Id
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Campaign", false);
				relation.AddEntityFieldPair(CampaignFields.Id, CallsFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Calls.ProductTypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingProductTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup__", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallsFields.ProductTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Calls.NotInterestedReasonId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingNotInterestedReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallsFields.NotInterestedReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Calls.DialerType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingDialerType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallsFields.DialerType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Calls.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", true);
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
