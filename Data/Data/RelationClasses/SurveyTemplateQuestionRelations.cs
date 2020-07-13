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
	/// <summary>Implements the static Relations variant for the entity: SurveyTemplateQuestion. </summary>
	public partial class SurveyTemplateQuestionRelations
	{
		/// <summary>CTor</summary>
		public SurveyTemplateQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the SurveyTemplateQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.SurveyQuestionEntityUsingQuestionId);
			toReturn.Add(this.SurveyTemplateEntityUsingTemplateId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between SurveyTemplateQuestionEntity and SurveyQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// SurveyTemplateQuestion.QuestionId - SurveyQuestion.Id
		/// </summary>
		public virtual IEntityRelation SurveyQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SurveyQuestion", false);
				relation.AddEntityFieldPair(SurveyQuestionFields.Id, SurveyTemplateQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SurveyTemplateQuestionEntity and SurveyTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// SurveyTemplateQuestion.TemplateId - SurveyTemplate.Id
		/// </summary>
		public virtual IEntityRelation SurveyTemplateEntityUsingTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SurveyTemplate", false);
				relation.AddEntityFieldPair(SurveyTemplateFields.Id, SurveyTemplateQuestionFields.TemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateQuestionEntity", true);
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
