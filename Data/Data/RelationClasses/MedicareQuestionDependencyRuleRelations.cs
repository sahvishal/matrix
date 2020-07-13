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
	/// <summary>Implements the static Relations variant for the entity: MedicareQuestionDependencyRule. </summary>
	public partial class MedicareQuestionDependencyRuleRelations
	{
		/// <summary>CTor</summary>
		public MedicareQuestionDependencyRuleRelations()
		{
		}

		/// <summary>Gets all relations of the MedicareQuestionDependencyRuleEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.MedicareQuestionEntityUsingDependentQuestionId);
			toReturn.Add(this.MedicareQuestionEntityUsingQuestionId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionDependencyRuleEntity and MedicareQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicareQuestionDependencyRule.DependentQuestionId - MedicareQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionEntityUsingDependentQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MedicareQuestion_", false);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareQuestionDependencyRuleFields.DependentQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionDependencyRuleEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionDependencyRuleEntity and MedicareQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicareQuestionDependencyRule.QuestionId - MedicareQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MedicareQuestion", false);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareQuestionDependencyRuleFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionDependencyRuleEntity", true);
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
