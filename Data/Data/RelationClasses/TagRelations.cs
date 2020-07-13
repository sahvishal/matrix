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
	/// <summary>Implements the static Relations variant for the entity: Tag. </summary>
	public partial class TagRelations
	{
		/// <summary>CTor</summary>
		public TagRelations()
		{
		}

		/// <summary>Gets all relations of the TagEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId);
			toReturn.Add(this.PreAssessmentCustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId);

			toReturn.Add(this.LookupEntityUsingSource);
			toReturn.Add(this.LookupEntityUsingCallStatus);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TagEntity and CustomerCallQueueCallAttemptEntity over the 1:n relation they have, using the relation between the fields:
		/// Tag.TagId - CustomerCallQueueCallAttempt.NotInterestedReasonId
		/// </summary>
		public virtual IEntityRelation CustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerCallQueueCallAttempt" , true);
				relation.AddEntityFieldPair(TagFields.TagId, CustomerCallQueueCallAttemptFields.NotInterestedReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TagEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCallQueueCallAttemptEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TagEntity and PreAssessmentCustomerCallQueueCallAttemptEntity over the 1:n relation they have, using the relation between the fields:
		/// Tag.TagId - PreAssessmentCustomerCallQueueCallAttempt.NotInterestedReasonId
		/// </summary>
		public virtual IEntityRelation PreAssessmentCustomerCallQueueCallAttemptEntityUsingNotInterestedReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreAssessmentCustomerCallQueueCallAttempt" , true);
				relation.AddEntityFieldPair(TagFields.TagId, PreAssessmentCustomerCallQueueCallAttemptFields.NotInterestedReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TagEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreAssessmentCustomerCallQueueCallAttemptEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TagEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Tag.Source - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, TagFields.Source);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TagEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TagEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Tag.CallStatus - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingCallStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, TagFields.CallStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TagEntity", true);
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
