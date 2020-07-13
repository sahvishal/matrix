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
	/// <summary>Implements the static Relations variant for the entity: FluConsentQuestion. </summary>
	public partial class FluConsentQuestionRelations
	{
		/// <summary>CTor</summary>
		public FluConsentQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the FluConsentQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.FluConsentAnswerEntityUsingQuestionId);
			toReturn.Add(this.FluConsentQuestionEntityUsingParentId);
			toReturn.Add(this.FluConsentTemplateQuestionEntityUsingQuestionId);

			toReturn.Add(this.FluConsentQuestionEntityUsingIdParentId);
			toReturn.Add(this.LookupEntityUsingTypeId);
			toReturn.Add(this.LookupEntityUsingGender);
			toReturn.Add(this.LookupEntityUsingFluConsentQuestionType);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between FluConsentQuestionEntity and FluConsentAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// FluConsentQuestion.Id - FluConsentAnswer.QuestionId
		/// </summary>
		public virtual IEntityRelation FluConsentAnswerEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentAnswer" , true);
				relation.AddEntityFieldPair(FluConsentQuestionFields.Id, FluConsentAnswerFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FluConsentQuestionEntity and FluConsentQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// FluConsentQuestion.Id - FluConsentQuestion.ParentId
		/// </summary>
		public virtual IEntityRelation FluConsentQuestionEntityUsingParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentQuestion_" , true);
				relation.AddEntityFieldPair(FluConsentQuestionFields.Id, FluConsentQuestionFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FluConsentQuestionEntity and FluConsentTemplateQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// FluConsentQuestion.Id - FluConsentTemplateQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation FluConsentTemplateQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentTemplateQuestion" , true);
				relation.AddEntityFieldPair(FluConsentQuestionFields.Id, FluConsentTemplateQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentTemplateQuestionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between FluConsentQuestionEntity and FluConsentQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// FluConsentQuestion.ParentId - FluConsentQuestion.Id
		/// </summary>
		public virtual IEntityRelation FluConsentQuestionEntityUsingIdParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FluConsentQuestion", false);
				relation.AddEntityFieldPair(FluConsentQuestionFields.Id, FluConsentQuestionFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between FluConsentQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// FluConsentQuestion.TypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, FluConsentQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between FluConsentQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// FluConsentQuestion.Gender - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, FluConsentQuestionFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between FluConsentQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// FluConsentQuestion.FluConsentQuestionType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingFluConsentQuestionType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup__", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, FluConsentQuestionFields.FluConsentQuestionType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", true);
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
