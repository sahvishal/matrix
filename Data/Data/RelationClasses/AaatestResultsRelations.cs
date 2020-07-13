///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: AaatestResults. </summary>
	public partial class AaatestResultsRelations
	{
		/// <summary>CTor</summary>
		public AaatestResultsRelations()
		{
		}

		/// <summary>Gets all relations of the AaatestResultsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AaatestIncidentalFindingsEntityUsingAaatestId);
			toReturn.Add(this.AaaunableScreenReasonEntityUsingAaatestId);
			toReturn.Add(this.PadtestRecommendationEntityUsingPadtestId);

			toReturn.Add(this.CustomerEventTestsEntityUsingCustomerEventTestId);
			toReturn.Add(this.OsteoporosisTestFindingsEntityUsingAaatestFindingsId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AaatestResultsEntity and AaatestIncidentalFindingsEntity over the 1:n relation they have, using the relation between the fields:
		/// AaatestResults.AaatestId - AaatestIncidentalFindings.AaatestId
		/// </summary>
		public virtual IEntityRelation AaatestIncidentalFindingsEntityUsingAaatestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AaatestIncidentalFindings" , true);
				relation.AddEntityFieldPair(AaatestResultsFields.AaatestId, AaatestIncidentalFindingsFields.AaatestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestIncidentalFindingsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AaatestResultsEntity and AaaunableScreenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// AaatestResults.AaatestId - AaaunableScreenReason.AaatestId
		/// </summary>
		public virtual IEntityRelation AaaunableScreenReasonEntityUsingAaatestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AaaunableScreenReason" , true);
				relation.AddEntityFieldPair(AaatestResultsFields.AaatestId, AaaunableScreenReasonFields.AaatestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaaunableScreenReasonEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AaatestResultsEntity and PadtestRecommendationEntity over the 1:n relation they have, using the relation between the fields:
		/// AaatestResults.AaatestId - PadtestRecommendation.PadtestId
		/// </summary>
		public virtual IEntityRelation PadtestRecommendationEntityUsingPadtestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PadtestRecommendation" , true);
				relation.AddEntityFieldPair(AaatestResultsFields.AaatestId, PadtestRecommendationFields.PadtestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestRecommendationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AaatestResultsEntity and CustomerEventTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// AaatestResults.CustomerEventTestId - CustomerEventTests.CustomerEventTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestsEntityUsingCustomerEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventTests", false);
				relation.AddEntityFieldPair(CustomerEventTestsFields.CustomerEventTestId, AaatestResultsFields.CustomerEventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestResultsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AaatestResultsEntity and OsteoporosisTestFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// AaatestResults.AaatestFindingsId - OsteoporosisTestFindings.OsteoporosisTestFindingsId
		/// </summary>
		public virtual IEntityRelation OsteoporosisTestFindingsEntityUsingAaatestFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OsteoporosisTestFindings", false);
				relation.AddEntityFieldPair(OsteoporosisTestFindingsFields.OsteoporosisTestFindingsId, AaatestResultsFields.AaatestFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestResultsEntity", true);
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
