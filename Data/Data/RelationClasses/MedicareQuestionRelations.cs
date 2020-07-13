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
	/// <summary>Implements the static Relations variant for the entity: MedicareQuestion. </summary>
	public partial class MedicareQuestionRelations
	{
		/// <summary>CTor</summary>
		public MedicareQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the MedicareQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerMedicareQuestionAnswerEntityUsingQuestionId);
			toReturn.Add(this.MedicareGroupDependencyRuleEntityUsingQuestionId);
			toReturn.Add(this.MedicareQuestionEntityUsingParentQuestionId);
			toReturn.Add(this.MedicareQuestionDependencyRuleEntityUsingDependentQuestionId);
			toReturn.Add(this.MedicareQuestionDependencyRuleEntityUsingQuestionId);
			toReturn.Add(this.MedicareQuestionsRemarksEntityUsingCombinedQuestionId);
			toReturn.Add(this.MedicareQuestionsRemarksEntityUsingDependentQuestionId);
			toReturn.Add(this.MedicareQuestionsRemarksEntityUsingQuestionId);

			toReturn.Add(this.LookupEntityUsingControlType);
			toReturn.Add(this.MedicareQuestionEntityUsingQuestionIdParentQuestionId);
			toReturn.Add(this.MedicareQuestionGroupEntityUsingGroupId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and CustomerMedicareQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestion.QuestionId - CustomerMedicareQuestionAnswer.QuestionId
		/// </summary>
		public virtual IEntityRelation CustomerMedicareQuestionAnswerEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerMedicareQuestionAnswer" , true);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, CustomerMedicareQuestionAnswerFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerMedicareQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and MedicareGroupDependencyRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestion.QuestionId - MedicareGroupDependencyRule.QuestionId
		/// </summary>
		public virtual IEntityRelation MedicareGroupDependencyRuleEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareGroupDependencyRule" , true);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareGroupDependencyRuleFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareGroupDependencyRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and MedicareQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestion.QuestionId - MedicareQuestion.ParentQuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionEntityUsingParentQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareQuestion_" , true);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareQuestionFields.ParentQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and MedicareQuestionDependencyRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestion.QuestionId - MedicareQuestionDependencyRule.DependentQuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionDependencyRuleEntityUsingDependentQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareQuestionDependencyRule_" , true);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareQuestionDependencyRuleFields.DependentQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionDependencyRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and MedicareQuestionDependencyRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestion.QuestionId - MedicareQuestionDependencyRule.QuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionDependencyRuleEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareQuestionDependencyRule" , true);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareQuestionDependencyRuleFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionDependencyRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and MedicareQuestionsRemarksEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestion.QuestionId - MedicareQuestionsRemarks.CombinedQuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionsRemarksEntityUsingCombinedQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareQuestionsRemarks__" , true);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareQuestionsRemarksFields.CombinedQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionsRemarksEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and MedicareQuestionsRemarksEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestion.QuestionId - MedicareQuestionsRemarks.DependentQuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionsRemarksEntityUsingDependentQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareQuestionsRemarks_" , true);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareQuestionsRemarksFields.DependentQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionsRemarksEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and MedicareQuestionsRemarksEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestion.QuestionId - MedicareQuestionsRemarks.QuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionsRemarksEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareQuestionsRemarks" , true);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareQuestionsRemarksFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionsRemarksEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicareQuestion.ControlType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingControlType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, MedicareQuestionFields.ControlType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and MedicareQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicareQuestion.ParentQuestionId - MedicareQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionEntityUsingQuestionIdParentQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MedicareQuestion", false);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareQuestionFields.ParentQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionEntity and MedicareQuestionGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicareQuestion.GroupId - MedicareQuestionGroup.GroupId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionGroupEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MedicareQuestionGroup", false);
				relation.AddEntityFieldPair(MedicareQuestionGroupFields.GroupId, MedicareQuestionFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", true);
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
