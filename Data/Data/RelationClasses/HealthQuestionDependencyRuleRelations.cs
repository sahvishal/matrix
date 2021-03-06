﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: HealthQuestionDependencyRule. </summary>
	public partial class HealthQuestionDependencyRuleRelations
	{
		/// <summary>CTor</summary>
		public HealthQuestionDependencyRuleRelations()
		{
		}

		/// <summary>Gets all relations of the HealthQuestionDependencyRuleEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerHealthQuestionsEntityUsingQuestionId);
			toReturn.Add(this.CustomerHealthQuestionsEntityUsingDependantQuestionId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HealthQuestionDependencyRuleEntity and CustomerHealthQuestionsEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthQuestionDependencyRule.QuestionId - CustomerHealthQuestions.CustomerHealthQuestionId
		/// </summary>
		public virtual IEntityRelation CustomerHealthQuestionsEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerHealthQuestions_", false);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, HealthQuestionDependencyRuleFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthQuestionDependencyRuleEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthQuestionDependencyRuleEntity and CustomerHealthQuestionsEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthQuestionDependencyRule.DependantQuestionId - CustomerHealthQuestions.CustomerHealthQuestionId
		/// </summary>
		public virtual IEntityRelation CustomerHealthQuestionsEntityUsingDependantQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerHealthQuestions", false);
				relation.AddEntityFieldPair(CustomerHealthQuestionsFields.CustomerHealthQuestionId, HealthQuestionDependencyRuleFields.DependantQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthQuestionDependencyRuleEntity", true);
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
