///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: SurveyQuestion. </summary>
	public partial class SurveyQuestionRelations
	{
		/// <summary>CTor</summary>
		public SurveyQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the SurveyQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.SurveyAnswerEntityUsingQuestionId);
			toReturn.Add(this.SurveyQuestionEntityUsingParentId);
			toReturn.Add(this.SurveyTemplateQuestionEntityUsingQuestionId);

			toReturn.Add(this.LookupEntityUsingTypeId);
			toReturn.Add(this.LookupEntityUsingGender);
			toReturn.Add(this.SurveyQuestionEntityUsingIdParentId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between SurveyQuestionEntity and SurveyAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// SurveyQuestion.Id - SurveyAnswer.QuestionId
		/// </summary>
		public virtual IEntityRelation SurveyAnswerEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyAnswer" , true);
				relation.AddEntityFieldPair(SurveyQuestionFields.Id, SurveyAnswerFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SurveyQuestionEntity and SurveyQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// SurveyQuestion.Id - SurveyQuestion.ParentId
		/// </summary>
		public virtual IEntityRelation SurveyQuestionEntityUsingParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyQuestion_" , true);
				relation.AddEntityFieldPair(SurveyQuestionFields.Id, SurveyQuestionFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SurveyQuestionEntity and SurveyTemplateQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// SurveyQuestion.Id - SurveyTemplateQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation SurveyTemplateQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyTemplateQuestion" , true);
				relation.AddEntityFieldPair(SurveyQuestionFields.Id, SurveyTemplateQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateQuestionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between SurveyQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// SurveyQuestion.TypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, SurveyQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SurveyQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// SurveyQuestion.Gender - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, SurveyQuestionFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SurveyQuestionEntity and SurveyQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// SurveyQuestion.ParentId - SurveyQuestion.Id
		/// </summary>
		public virtual IEntityRelation SurveyQuestionEntityUsingIdParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SurveyQuestion", false);
				relation.AddEntityFieldPair(SurveyQuestionFields.Id, SurveyQuestionFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", true);
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
