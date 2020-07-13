﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: PreQualificationQuestionRule. </summary>
	public partial class PreQualificationQuestionRuleRelations
	{
		/// <summary>CTor</summary>
		public PreQualificationQuestionRuleRelations()
		{
		}

		/// <summary>Gets all relations of the PreQualificationQuestionRuleEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.PreQualificationQuestionEntityUsingDependentQuestionId);
			toReturn.Add(this.PreQualificationQuestionEntityUsingQuestionId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionRuleEntity and PreQualificationQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationQuestionRule.DependentQuestionId - PreQualificationQuestion.Id
		/// </summary>
		public virtual IEntityRelation PreQualificationQuestionEntityUsingDependentQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PreQualificationQuestion_", false);
				relation.AddEntityFieldPair(PreQualificationQuestionFields.Id, PreQualificationQuestionRuleFields.DependentQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionRuleEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationQuestionRuleEntity and PreQualificationQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationQuestionRule.QuestionId - PreQualificationQuestion.Id
		/// </summary>
		public virtual IEntityRelation PreQualificationQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PreQualificationQuestion", false);
				relation.AddEntityFieldPair(PreQualificationQuestionFields.Id, PreQualificationQuestionRuleFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionRuleEntity", true);
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
