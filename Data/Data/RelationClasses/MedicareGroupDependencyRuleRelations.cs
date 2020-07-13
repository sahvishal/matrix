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
	/// <summary>Implements the static Relations variant for the entity: MedicareGroupDependencyRule. </summary>
	public partial class MedicareGroupDependencyRuleRelations
	{
		/// <summary>CTor</summary>
		public MedicareGroupDependencyRuleRelations()
		{
		}

		/// <summary>Gets all relations of the MedicareGroupDependencyRuleEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.MedicareQuestionEntityUsingQuestionId);
			toReturn.Add(this.MedicareQuestionGroupEntityUsingDependentGroupId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between MedicareGroupDependencyRuleEntity and MedicareQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicareGroupDependencyRule.QuestionId - MedicareQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MedicareQuestion", false);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, MedicareGroupDependencyRuleFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareGroupDependencyRuleEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicareGroupDependencyRuleEntity and MedicareQuestionGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicareGroupDependencyRule.DependentGroupId - MedicareQuestionGroup.GroupId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionGroupEntityUsingDependentGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MedicareQuestionGroup", false);
				relation.AddEntityFieldPair(MedicareQuestionGroupFields.GroupId, MedicareGroupDependencyRuleFields.DependentGroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareGroupDependencyRuleEntity", true);
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
