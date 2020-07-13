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
	/// <summary>Implements the static Relations variant for the entity: PreQualificationQuestion. </summary>
	public partial class PreQualificationQuestionRelations
	{
		/// <summary>CTor</summary>
		public PreQualificationQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the PreQualificationQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.DisqualifiedTestEntityUsingQuestionId);
			toReturn.Add(this.EventCustomerQuestionAnswerEntityUsingQuestionId);
			toReturn.Add(this.PreQualificationQuestionRuleEntityUsingDependentQuestionId);
			toReturn.Add(this.PreQualificationQuestionRuleEntityUsingQuestionId);
			toReturn.Add(this.PreQualificationTemplateQuestionEntityUsingQuestionId);

			toReturn.Add(this.LookupEntityUsingTypeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionEntity and DisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// PreQualificationQuestion.Id - DisqualifiedTest.QuestionId
		/// </summary>
		public virtual IEntityRelation DisqualifiedTestEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DisqualifiedTest" , true);
				relation.AddEntityFieldPair(PreQualificationQuestionFields.Id, DisqualifiedTestFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionEntity and EventCustomerQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// PreQualificationQuestion.Id - EventCustomerQuestionAnswer.QuestionId
		/// </summary>
		public virtual IEntityRelation EventCustomerQuestionAnswerEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerQuestionAnswer" , true);
				relation.AddEntityFieldPair(PreQualificationQuestionFields.Id, EventCustomerQuestionAnswerFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionEntity and PreQualificationQuestionRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// PreQualificationQuestion.Id - PreQualificationQuestionRule.DependentQuestionId
		/// </summary>
		public virtual IEntityRelation PreQualificationQuestionRuleEntityUsingDependentQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationQuestionRule_" , true);
				relation.AddEntityFieldPair(PreQualificationQuestionFields.Id, PreQualificationQuestionRuleFields.DependentQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionEntity and PreQualificationQuestionRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// PreQualificationQuestion.Id - PreQualificationQuestionRule.QuestionId
		/// </summary>
		public virtual IEntityRelation PreQualificationQuestionRuleEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationQuestionRule" , true);
				relation.AddEntityFieldPair(PreQualificationQuestionFields.Id, PreQualificationQuestionRuleFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionEntity and PreQualificationTemplateQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// PreQualificationQuestion.Id - PreQualificationTemplateQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation PreQualificationTemplateQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationTemplateQuestion" , true);
				relation.AddEntityFieldPair(PreQualificationQuestionFields.Id, PreQualificationTemplateQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTemplateQuestionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationQuestion.TypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationQuestion.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreQualificationQuestionFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationQuestion.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, PreQualificationQuestionFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", true);
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
