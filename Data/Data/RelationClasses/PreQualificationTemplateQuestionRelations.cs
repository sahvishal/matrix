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
	/// <summary>Implements the static Relations variant for the entity: PreQualificationTemplateQuestion. </summary>
	public partial class PreQualificationTemplateQuestionRelations
	{
		/// <summary>CTor</summary>
		public PreQualificationTemplateQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the PreQualificationTemplateQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.PreQualificationQuestionEntityUsingQuestionId);
			toReturn.Add(this.PreQualificationTestTemplateEntityUsingTemplateId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PreQualificationTemplateQuestionEntity and PreQualificationQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationTemplateQuestion.QuestionId - PreQualificationQuestion.Id
		/// </summary>
		public virtual IEntityRelation PreQualificationQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PreQualificationQuestion", false);
				relation.AddEntityFieldPair(PreQualificationQuestionFields.Id, PreQualificationTemplateQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTemplateQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationTemplateQuestionEntity and PreQualificationTestTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationTemplateQuestion.TemplateId - PreQualificationTestTemplate.Id
		/// </summary>
		public virtual IEntityRelation PreQualificationTestTemplateEntityUsingTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PreQualificationTestTemplate", false);
				relation.AddEntityFieldPair(PreQualificationTestTemplateFields.Id, PreQualificationTemplateQuestionFields.TemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTemplateQuestionEntity", true);
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
