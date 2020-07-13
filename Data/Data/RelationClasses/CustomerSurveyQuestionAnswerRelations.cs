﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:38
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
	/// <summary>Implements the static Relations variant for the entity: CustomerSurveyQuestionAnswer. </summary>
	public partial class CustomerSurveyQuestionAnswerRelations
	{
		/// <summary>CTor</summary>
		public CustomerSurveyQuestionAnswerRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerSurveyQuestionAnswerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerSurveyEntityUsingCustomerSurveyQuestionAnswerId);

			toReturn.Add(this.CustomerSurveyQuestionEntityUsingCustomerSurveyQuestionId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerSurveyQuestionAnswerEntity and CustomerSurveyEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerSurveyQuestionAnswer.CustomerSurveyQuestionAnswerId - CustomerSurvey.CustomerSurveyQuestionAnswerId
		/// </summary>
		public virtual IEntityRelation CustomerSurveyEntityUsingCustomerSurveyQuestionAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerSurvey" , true);
				relation.AddEntityFieldPair(CustomerSurveyQuestionAnswerFields.CustomerSurveyQuestionAnswerId, CustomerSurveyFields.CustomerSurveyQuestionAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerSurveyQuestionAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerSurveyEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CustomerSurveyQuestionAnswerEntity and CustomerSurveyQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerSurveyQuestionAnswer.CustomerSurveyQuestionId - CustomerSurveyQuestion.CustomerSurveyQuestionId
		/// </summary>
		public virtual IEntityRelation CustomerSurveyQuestionEntityUsingCustomerSurveyQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerSurveyQuestion", false);
				relation.AddEntityFieldPair(CustomerSurveyQuestionFields.CustomerSurveyQuestionId, CustomerSurveyQuestionAnswerFields.CustomerSurveyQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerSurveyQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerSurveyQuestionAnswerEntity", true);
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
