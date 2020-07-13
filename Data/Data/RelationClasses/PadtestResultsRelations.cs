///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:13 AM
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
	/// <summary>Implements the static Relations variant for the entity: PadtestResults. </summary>
	public partial class PadtestResultsRelations
	{
		/// <summary>CTor</summary>
		public PadtestResultsRelations()
		{
		}

		/// <summary>Gets all relations of the PadtestResultsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OsteoporosisTestRecommendationEntityUsingOsteoporosisTestId);
			toReturn.Add(this.PadtestIncidentalFindingsEntityUsingPadtestId);

			toReturn.Add(this.CustomerEventTestsEntityUsingCustomerEventTestId);
			toReturn.Add(this.PadtestFindingsEntityUsingPadtestFindingsId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PadtestResultsEntity and OsteoporosisTestRecommendationEntity over the 1:n relation they have, using the relation between the fields:
		/// PadtestResults.PadtestId - OsteoporosisTestRecommendation.OsteoporosisTestId
		/// </summary>
		public virtual IEntityRelation OsteoporosisTestRecommendationEntityUsingOsteoporosisTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OsteoporosisTestRecommendation" , true);
				relation.AddEntityFieldPair(PadtestResultsFields.PadtestId, OsteoporosisTestRecommendationFields.OsteoporosisTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestRecommendationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PadtestResultsEntity and PadtestIncidentalFindingsEntity over the 1:n relation they have, using the relation between the fields:
		/// PadtestResults.PadtestId - PadtestIncidentalFindings.PadtestId
		/// </summary>
		public virtual IEntityRelation PadtestIncidentalFindingsEntityUsingPadtestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PadtestIncidentalFindings" , true);
				relation.AddEntityFieldPair(PadtestResultsFields.PadtestId, PadtestIncidentalFindingsFields.PadtestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestIncidentalFindingsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between PadtestResultsEntity and CustomerEventTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// PadtestResults.CustomerEventTestId - CustomerEventTests.CustomerEventTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestsEntityUsingCustomerEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventTests", false);
				relation.AddEntityFieldPair(CustomerEventTestsFields.CustomerEventTestId, PadtestResultsFields.CustomerEventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestResultsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PadtestResultsEntity and PadtestFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// PadtestResults.PadtestFindingsId - PadtestFindings.PadtestFindingsId
		/// </summary>
		public virtual IEntityRelation PadtestFindingsEntityUsingPadtestFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PadtestFindings", false);
				relation.AddEntityFieldPair(PadtestFindingsFields.PadtestFindingsId, PadtestResultsFields.PadtestFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestResultsEntity", true);
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
