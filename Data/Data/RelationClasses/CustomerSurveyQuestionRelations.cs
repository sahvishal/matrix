///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: CustomerSurveyQuestion. </summary>
	public partial class CustomerSurveyQuestionRelations
	{
		/// <summary>CTor</summary>
		public CustomerSurveyQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerSurveyQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerSurveyQuestionAnswerEntityUsingCustomerSurveyQuestionId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerSurveyQuestionEntity and CustomerSurveyQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerSurveyQuestion.CustomerSurveyQuestionId - CustomerSurveyQuestionAnswer.CustomerSurveyQuestionId
		/// </summary>
		public virtual IEntityRelation CustomerSurveyQuestionAnswerEntityUsingCustomerSurveyQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerSurveyQuestionAnswer" , true);
				relation.AddEntityFieldPair(CustomerSurveyQuestionFields.CustomerSurveyQuestionId, CustomerSurveyQuestionAnswerFields.CustomerSurveyQuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerSurveyQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerSurveyQuestionAnswerEntity", false);
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
