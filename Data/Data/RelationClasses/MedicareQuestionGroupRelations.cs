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
	/// <summary>Implements the static Relations variant for the entity: MedicareQuestionGroup. </summary>
	public partial class MedicareQuestionGroupRelations
	{
		/// <summary>CTor</summary>
		public MedicareQuestionGroupRelations()
		{
		}

		/// <summary>Gets all relations of the MedicareQuestionGroupEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.MedicareGroupDependencyRuleEntityUsingDependentGroupId);
			toReturn.Add(this.MedicareQuestionEntityUsingGroupId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionGroupEntity and MedicareGroupDependencyRuleEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestionGroup.GroupId - MedicareGroupDependencyRule.DependentGroupId
		/// </summary>
		public virtual IEntityRelation MedicareGroupDependencyRuleEntityUsingDependentGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareGroupDependencyRule" , true);
				relation.AddEntityFieldPair(MedicareQuestionGroupFields.GroupId, MedicareGroupDependencyRuleFields.DependentGroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionGroupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareGroupDependencyRuleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MedicareQuestionGroupEntity and MedicareQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicareQuestionGroup.GroupId - MedicareQuestion.GroupId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareQuestion" , true);
				relation.AddEntityFieldPair(MedicareQuestionGroupFields.GroupId, MedicareQuestionFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionGroupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", false);
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
