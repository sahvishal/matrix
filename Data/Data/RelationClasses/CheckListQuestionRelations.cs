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
	/// <summary>Implements the static Relations variant for the entity: CheckListQuestion. </summary>
	public partial class CheckListQuestionRelations
	{
		/// <summary>CTor</summary>
		public CheckListQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the CheckListQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CheckListAnswerEntityUsingQuestionId);
			toReturn.Add(this.ChecklistGroupQuestionEntityUsingQuestionId);
			toReturn.Add(this.ChecklistGroupQuestionEntityUsingParentId);
			toReturn.Add(this.CheckListTemplateQuestionEntityUsingQuestionId);
			toReturn.Add(this.ExitInterviewSignatureEntityUsingQuestionId);

			toReturn.Add(this.LookupEntityUsingTypeId);
			toReturn.Add(this.LookupEntityUsingGender);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CheckListQuestionEntity and CheckListAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// CheckListQuestion.Id - CheckListAnswer.QuestionId
		/// </summary>
		public virtual IEntityRelation CheckListAnswerEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListAnswer" , true);
				relation.AddEntityFieldPair(CheckListQuestionFields.Id, CheckListAnswerFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CheckListQuestionEntity and ChecklistGroupQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// CheckListQuestion.Id - ChecklistGroupQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation ChecklistGroupQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChecklistGroupQuestion_" , true);
				relation.AddEntityFieldPair(CheckListQuestionFields.Id, ChecklistGroupQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChecklistGroupQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CheckListQuestionEntity and ChecklistGroupQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// CheckListQuestion.Id - ChecklistGroupQuestion.ParentId
		/// </summary>
		public virtual IEntityRelation ChecklistGroupQuestionEntityUsingParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChecklistGroupQuestion" , true);
				relation.AddEntityFieldPair(CheckListQuestionFields.Id, ChecklistGroupQuestionFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChecklistGroupQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CheckListQuestionEntity and CheckListTemplateQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// CheckListQuestion.Id - CheckListTemplateQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation CheckListTemplateQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListTemplateQuestion" , true);
				relation.AddEntityFieldPair(CheckListQuestionFields.Id, CheckListTemplateQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CheckListQuestionEntity and ExitInterviewSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// CheckListQuestion.Id - ExitInterviewSignature.QuestionId
		/// </summary>
		public virtual IEntityRelation ExitInterviewSignatureEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExitInterviewSignature" , true);
				relation.AddEntityFieldPair(CheckListQuestionFields.Id, ExitInterviewSignatureFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewSignatureEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CheckListQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CheckListQuestion.TypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CheckListQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CheckListQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CheckListQuestion.Gender - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CheckListQuestionFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", true);
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
