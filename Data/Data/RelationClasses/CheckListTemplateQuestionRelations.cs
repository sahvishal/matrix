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
	/// <summary>Implements the static Relations variant for the entity: CheckListTemplateQuestion. </summary>
	public partial class CheckListTemplateQuestionRelations
	{
		/// <summary>CTor</summary>
		public CheckListTemplateQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the CheckListTemplateQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ChecklistGroupQuestionEntityUsingGroupQuestionId);
			toReturn.Add(this.CheckListQuestionEntityUsingQuestionId);
			toReturn.Add(this.CheckListTemplateEntityUsingTemplateId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CheckListTemplateQuestionEntity and ChecklistGroupQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// CheckListTemplateQuestion.GroupQuestionId - ChecklistGroupQuestion.Id
		/// </summary>
		public virtual IEntityRelation ChecklistGroupQuestionEntityUsingGroupQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ChecklistGroupQuestion", false);
				relation.AddEntityFieldPair(ChecklistGroupQuestionFields.Id, CheckListTemplateQuestionFields.GroupQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChecklistGroupQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CheckListTemplateQuestionEntity and CheckListQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// CheckListTemplateQuestion.QuestionId - CheckListQuestion.Id
		/// </summary>
		public virtual IEntityRelation CheckListQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CheckListQuestion", false);
				relation.AddEntityFieldPair(CheckListQuestionFields.Id, CheckListTemplateQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CheckListTemplateQuestionEntity and CheckListTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// CheckListTemplateQuestion.TemplateId - CheckListTemplate.Id
		/// </summary>
		public virtual IEntityRelation CheckListTemplateEntityUsingTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CheckListTemplate", false);
				relation.AddEntityFieldPair(CheckListTemplateFields.Id, CheckListTemplateQuestionFields.TemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateQuestionEntity", true);
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
