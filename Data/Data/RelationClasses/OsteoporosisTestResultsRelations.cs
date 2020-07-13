///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:16 AM
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
	/// <summary>Implements the static Relations variant for the entity: OsteoporosisTestResults. </summary>
	public partial class OsteoporosisTestResultsRelations
	{
		/// <summary>CTor</summary>
		public OsteoporosisTestResultsRelations()
		{
		}

		/// <summary>Gets all relations of the OsteoporosisTestResultsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AsitestRecommendationEntityUsingAsitestId);
			toReturn.Add(this.OsteoporosisTestIncidentalFindingsEntityUsingOsteoporosisTestId);

			toReturn.Add(this.AsitestFindingsEntityUsingOsteoporosisTestFindingsId);
			toReturn.Add(this.CustomerEventTestsEntityUsingCustomerEventTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OsteoporosisTestResultsEntity and AsitestRecommendationEntity over the 1:n relation they have, using the relation between the fields:
		/// OsteoporosisTestResults.OsteoporosisTestId - AsitestRecommendation.AsitestId
		/// </summary>
		public virtual IEntityRelation AsitestRecommendationEntityUsingAsitestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AsitestRecommendation" , true);
				relation.AddEntityFieldPair(OsteoporosisTestResultsFields.OsteoporosisTestId, AsitestRecommendationFields.AsitestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestRecommendationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OsteoporosisTestResultsEntity and OsteoporosisTestIncidentalFindingsEntity over the 1:n relation they have, using the relation between the fields:
		/// OsteoporosisTestResults.OsteoporosisTestId - OsteoporosisTestIncidentalFindings.OsteoporosisTestId
		/// </summary>
		public virtual IEntityRelation OsteoporosisTestIncidentalFindingsEntityUsingOsteoporosisTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OsteoporosisTestIncidentalFindings" , true);
				relation.AddEntityFieldPair(OsteoporosisTestResultsFields.OsteoporosisTestId, OsteoporosisTestIncidentalFindingsFields.OsteoporosisTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestIncidentalFindingsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between OsteoporosisTestResultsEntity and AsitestFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// OsteoporosisTestResults.OsteoporosisTestFindingsId - AsitestFindings.AsitestFindingsId
		/// </summary>
		public virtual IEntityRelation AsitestFindingsEntityUsingOsteoporosisTestFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AsitestFindings", false);
				relation.AddEntityFieldPair(AsitestFindingsFields.AsitestFindingsId, OsteoporosisTestResultsFields.OsteoporosisTestFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestResultsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OsteoporosisTestResultsEntity and CustomerEventTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// OsteoporosisTestResults.CustomerEventTestId - CustomerEventTests.CustomerEventTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestsEntityUsingCustomerEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventTests", false);
				relation.AddEntityFieldPair(CustomerEventTestsFields.CustomerEventTestId, OsteoporosisTestResultsFields.CustomerEventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestResultsEntity", true);
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
