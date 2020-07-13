///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:42
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
	/// <summary>Implements the static Relations variant for the entity: PreAssessmentCustomerCallQueueCallAttempt. </summary>
	public partial class PreAssessmentCustomerCallQueueCallAttemptRelations
	{
		/// <summary>CTor</summary>
		public PreAssessmentCustomerCallQueueCallAttemptRelations()
		{
		}

		/// <summary>Gets all relations of the PreAssessmentCustomerCallQueueCallAttemptEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CallsEntityUsingCallId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.TagEntityUsingNotInterestedReasonId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PreAssessmentCustomerCallQueueCallAttemptEntity and CallsEntity over the m:1 relation they have, using the relation between the fields:
		/// PreAssessmentCustomerCallQueueCallAttempt.CallId - Calls.CallId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Calls", false);
				relation.AddEntityFieldPair(CallsFields.CallId, PreAssessmentCustomerCallQueueCallAttemptFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreAssessmentCustomerCallQueueCallAttemptEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreAssessmentCustomerCallQueueCallAttemptEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// PreAssessmentCustomerCallQueueCallAttempt.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, PreAssessmentCustomerCallQueueCallAttemptFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreAssessmentCustomerCallQueueCallAttemptEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreAssessmentCustomerCallQueueCallAttemptEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// PreAssessmentCustomerCallQueueCallAttempt.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreAssessmentCustomerCallQueueCallAttemptFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreAssessmentCustomerCallQueueCallAttemptEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreAssessmentCustomerCallQueueCallAttemptEntity and TagEntity over the m:1 relation they have, using the relation between the fields:
		/// PreAssessmentCustomerCallQueueCallAttempt.NotInterestedReasonId - Tag.TagId
		/// </summary>
		public virtual IEntityRelation TagEntityUsingNotInterestedReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Tag", false);
				relation.AddEntityFieldPair(TagFields.TagId, PreAssessmentCustomerCallQueueCallAttemptFields.NotInterestedReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TagEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreAssessmentCustomerCallQueueCallAttemptEntity", true);
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
