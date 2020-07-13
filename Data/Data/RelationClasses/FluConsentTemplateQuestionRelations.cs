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
	/// <summary>Implements the static Relations variant for the entity: FluConsentTemplateQuestion. </summary>
	public partial class FluConsentTemplateQuestionRelations
	{
		/// <summary>CTor</summary>
		public FluConsentTemplateQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the FluConsentTemplateQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.FluConsentQuestionEntityUsingQuestionId);
			toReturn.Add(this.FluConsentTemplateEntityUsingTemplateId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between FluConsentTemplateQuestionEntity and FluConsentQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// FluConsentTemplateQuestion.QuestionId - FluConsentQuestion.Id
		/// </summary>
		public virtual IEntityRelation FluConsentQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FluConsentQuestion", false);
				relation.AddEntityFieldPair(FluConsentQuestionFields.Id, FluConsentTemplateQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentTemplateQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between FluConsentTemplateQuestionEntity and FluConsentTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// FluConsentTemplateQuestion.TemplateId - FluConsentTemplate.Id
		/// </summary>
		public virtual IEntityRelation FluConsentTemplateEntityUsingTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FluConsentTemplate", false);
				relation.AddEntityFieldPair(FluConsentTemplateFields.Id, FluConsentTemplateQuestionFields.TemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentTemplateQuestionEntity", true);
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
