///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:41
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
	/// <summary>Implements the static Relations variant for the entity: ChecklistGroupQuestion. </summary>
	public partial class ChecklistGroupQuestionRelations
	{
		/// <summary>CTor</summary>
		public ChecklistGroupQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the ChecklistGroupQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CheckListTemplateQuestionEntityUsingGroupQuestionId);

			toReturn.Add(this.CheckListGroupEntityUsingGroupId);
			toReturn.Add(this.CheckListQuestionEntityUsingQuestionId);
			toReturn.Add(this.CheckListQuestionEntityUsingParentId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ChecklistGroupQuestionEntity and CheckListTemplateQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// ChecklistGroupQuestion.Id - CheckListTemplateQuestion.GroupQuestionId
		/// </summary>
		public virtual IEntityRelation CheckListTemplateQuestionEntityUsingGroupQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListTemplateQuestion" , true);
				relation.AddEntityFieldPair(ChecklistGroupQuestionFields.Id, CheckListTemplateQuestionFields.GroupQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChecklistGroupQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateQuestionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ChecklistGroupQuestionEntity and CheckListGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// ChecklistGroupQuestion.GroupId - CheckListGroup.Id
		/// </summary>
		public virtual IEntityRelation CheckListGroupEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CheckListGroup", false);
				relation.AddEntityFieldPair(CheckListGroupFields.Id, ChecklistGroupQuestionFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChecklistGroupQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ChecklistGroupQuestionEntity and CheckListQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// ChecklistGroupQuestion.QuestionId - CheckListQuestion.Id
		/// </summary>
		public virtual IEntityRelation CheckListQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CheckListQuestion_", false);
				relation.AddEntityFieldPair(CheckListQuestionFields.Id, ChecklistGroupQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChecklistGroupQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ChecklistGroupQuestionEntity and CheckListQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// ChecklistGroupQuestion.ParentId - CheckListQuestion.Id
		/// </summary>
		public virtual IEntityRelation CheckListQuestionEntityUsingParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CheckListQuestion", false);
				relation.AddEntityFieldPair(CheckListQuestionFields.Id, ChecklistGroupQuestionFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChecklistGroupQuestionEntity", true);
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
