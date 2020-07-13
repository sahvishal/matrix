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
	/// <summary>Implements the static Relations variant for the entity: CustomerHealthQuestions. </summary>
	public partial class CustomerHealthQuestionsRelations
	{
		/// <summary>CTor</summary>
		public CustomerHealthQuestionsRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerHealthQuestionsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId);
			toReturn.Add(this.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId);
			toReturn.Add(this.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId);
			toReturn.Add(this.CustomerHealthInfoEntityUsingCustomerHealthQuestionId);
			toReturn.Add(this.CustomerHealthInfoArchiveEntityUsingCustomerHealthQuestionId);
			toReturn.Add(this.CustomerHealthQuestionsEntityUsingParentQuestionId);
			toReturn.Add(this.HafTemplateQuestionEntityUsingQuestionId);
			toReturn.Add(this.HealthQuestionDependencyRuleEntityUsingQuestionId);
			toReturn.Add(this.HealthQuestionDependencyRuleEntityUsingDependantQuestionId);
			toReturn.Add(this.MedicalHistoryReadingAssosciationEntityUsingMedicalHistoryQuestionId);

			toReturn.Add(this.CustomerHealthQuestionGroupEntityUsingCustomerHealthQuestionGroupId);
			toReturn.Add(this.CustomerHealthQuestionsEntityUsingCustomerHealthQuestionIdParentQuestionId);
			toReturn.Add(this.LookupEntityUsingControlType);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and ClinicalTestQualificationCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - ClinicalTestQualificationCriteria.DisqualifierQuestionId
		/// </summary>
		public virtual IEntityRelation ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClinicalTestQualificationCriteria_" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, ClinicalTestQualificationCriteriaFields.DisqualifierQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClinicalTestQualificationCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and ClinicalTestQualificationCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - ClinicalTestQualificationCriteria.MedicationQuestionId
		/// </summary>
		public virtual IEntityRelation ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClinicalTestQualificationCriteria" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, ClinicalTestQualificationCriteriaFields.MedicationQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClinicalTestQualificationCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and CustomerClinicalQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - CustomerClinicalQuestionAnswer.ClinicalHealthQuestionId
		/// </summary>
		public virtual IEntityRelation CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerClinicalQuestionAnswer" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, CustomerClinicalQuestionAnswerFields.ClinicalHealthQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerClinicalQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and CustomerHealthInfoEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - CustomerHealthInfo.CustomerHealthQuestionId
		/// </summary>
		public virtual IEntityRelation CustomerHealthInfoEntityUsingCustomerHealthQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthInfo" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, CustomerHealthInfoFields.CustomerHealthQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthInfoEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and CustomerHealthInfoArchiveEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - CustomerHealthInfoArchive.CustomerHealthQuestionId
		/// </summary>
		public virtual IEntityRelation CustomerHealthInfoArchiveEntityUsingCustomerHealthQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthInfoArchive" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, CustomerHealthInfoArchiveFields.CustomerHealthQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthInfoArchiveEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and CustomerHealthQuestionsEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - CustomerHealthQuestions.ParentQuestionId
		/// </summary>
		public virtual IEntityRelation CustomerHealthQuestionsEntityUsingParentQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthQuestions_" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, CustomerHealthQuestionsFields.ParentQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and HafTemplateQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - HafTemplateQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation HafTemplateQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HafTemplateQuestion" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, HafTemplateQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and HealthQuestionDependencyRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - HealthQuestionDependencyRule.QuestionId
		/// </summary>
		public virtual IEntityRelation HealthQuestionDependencyRuleEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthQuestionDependencyRule_" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, HealthQuestionDependencyRuleFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthQuestionDependencyRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and HealthQuestionDependencyRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - HealthQuestionDependencyRule.DependantQuestionId
		/// </summary>
		public virtual IEntityRelation HealthQuestionDependencyRuleEntityUsingDependantQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthQuestionDependencyRule" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, HealthQuestionDependencyRuleFields.DependantQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthQuestionDependencyRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and MedicalHistoryReadingAssosciationEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionId - MedicalHistoryReadingAssosciation.MedicalHistoryQuestionId
		/// </summary>
		public virtual IEntityRelation MedicalHistoryReadingAssosciationEntityUsingMedicalHistoryQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicalHistoryReadingAssosciation" , true);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, MedicalHistoryReadingAssosciationFields.MedicalHistoryQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalHistoryReadingAssosciationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and CustomerHealthQuestionGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.CustomerHealthQuestionGroupId - CustomerHealthQuestionGroup.CustomerHealthQuestionGroupId
		/// </summary>
		public virtual IEntityRelation CustomerHealthQuestionGroupEntityUsingCustomerHealthQuestionGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerHealthQuestionGroup", false);
				relation.AddEntityFieldPair(CustomerHealthQuestionGroupFields.CustomerHealthQuestionGroupId, CustomerHealthQuestionsFields.CustomerHealthQuestionGroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and CustomerHealthQuestionsEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.ParentQuestionId - CustomerHealthQuestions.CustomerHealthQuestionId
		/// </summary>
		public virtual IEntityRelation CustomerHealthQuestionsEntityUsingCustomerHealthQuestionIdParentQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerHealthQuestions", false);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, CustomerHealthQuestionsFields.ParentQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerHealthQuestionsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerHealthQuestions.ControlType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingControlType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerHealthQuestionsFields.ControlType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", true);
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
