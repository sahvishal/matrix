﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:07 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: AaatestRecommendation. </summary>
	public partial class AaatestRecommendationRelations
	{
		/// <summary>CTor</summary>
		public AaatestRecommendationRelations()
		{
		}

		/// <summary>Gets all relations of the AaatestRecommendationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CarotidArteryTestResultsEntityUsingAaatestId);
			toReturn.Add(this.CustomerEventTestsEntityUsingCustomerEventTestId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AaatestRecommendationEntity and CarotidArteryTestResultsEntity over the m:1 relation they have, using the relation between the fields:
		/// AaatestRecommendation.AaatestId - CarotidArteryTestResults.CarotidArteryTestId
		/// </summary>
		public virtual IEntityRelation CarotidArteryTestResultsEntityUsingAaatestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CarotidArteryTestResults", false);
				relation.AddEntityFieldPair(CarotidArteryTestResultsFields.CarotidArteryTestId, AaatestRecommendationFields.AaatestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestRecommendationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AaatestRecommendationEntity and CustomerEventTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// AaatestRecommendation.CustomerEventTestId - CustomerEventTests.CustomerEventTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestsEntityUsingCustomerEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventTests", false);
				relation.AddEntityFieldPair(CustomerEventTestsFields.CustomerEventTestId, AaatestRecommendationFields.CustomerEventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestRecommendationEntity", true);
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
