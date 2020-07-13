///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:03 AM
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
	/// <summary>Implements the static Relations variant for the entity: CarotidArteryTestResults. </summary>
	public partial class CarotidArteryTestResultsRelations
	{
		/// <summary>CTor</summary>
		public CarotidArteryTestResultsRelations()
		{
		}

		/// <summary>Gets all relations of the CarotidArteryTestResultsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AaatestRecommendationEntityUsingAaatestId);
			toReturn.Add(this.CarotidArteryTestImagesEntityUsingCarotidArteryTestId);
			toReturn.Add(this.CarotidArteryTestIncidentalFindingsEntityUsingCarotidArteryTestId);

			toReturn.Add(this.CarotidArteryTestFindingsEntityUsingRcarotidArteryTestFindingsId);
			toReturn.Add(this.CarotidArteryTestFindingsEntityUsingLcarotidArteryTestFindingsId);
			toReturn.Add(this.CustomerEventTestsEntityUsingCustomerEventTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestResultsEntity and AaatestRecommendationEntity over the 1:n relation they have, using the relation between the fields:
		/// CarotidArteryTestResults.CarotidArteryTestId - AaatestRecommendation.AaatestId
		/// </summary>
		public virtual IEntityRelation AaatestRecommendationEntityUsingAaatestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AaatestRecommendation" , true);
				relation.AddEntityFieldPair(CarotidArteryTestResultsFields.CarotidArteryTestId, AaatestRecommendationFields.AaatestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestRecommendationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestResultsEntity and CarotidArteryTestImagesEntity over the 1:n relation they have, using the relation between the fields:
		/// CarotidArteryTestResults.CarotidArteryTestId - CarotidArteryTestImages.CarotidArteryTestId
		/// </summary>
		public virtual IEntityRelation CarotidArteryTestImagesEntityUsingCarotidArteryTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CarotidArteryTestImages" , true);
				relation.AddEntityFieldPair(CarotidArteryTestResultsFields.CarotidArteryTestId, CarotidArteryTestImagesFields.CarotidArteryTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestImagesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestResultsEntity and CarotidArteryTestIncidentalFindingsEntity over the 1:n relation they have, using the relation between the fields:
		/// CarotidArteryTestResults.CarotidArteryTestId - CarotidArteryTestIncidentalFindings.CarotidArteryTestId
		/// </summary>
		public virtual IEntityRelation CarotidArteryTestIncidentalFindingsEntityUsingCarotidArteryTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CarotidArteryTestIncidentalFindings" , true);
				relation.AddEntityFieldPair(CarotidArteryTestResultsFields.CarotidArteryTestId, CarotidArteryTestIncidentalFindingsFields.CarotidArteryTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestIncidentalFindingsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestResultsEntity and CarotidArteryTestFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// CarotidArteryTestResults.RcarotidArteryTestFindingsId - CarotidArteryTestFindings.CarotidArteryTestFindingsId
		/// </summary>
		public virtual IEntityRelation CarotidArteryTestFindingsEntityUsingRcarotidArteryTestFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CarotidArteryTestFindings_", false);
				relation.AddEntityFieldPair(CarotidArteryTestFindingsFields.CarotidArteryTestFindingsId, CarotidArteryTestResultsFields.RcarotidArteryTestFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestResultsEntity and CarotidArteryTestFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// CarotidArteryTestResults.LcarotidArteryTestFindingsId - CarotidArteryTestFindings.CarotidArteryTestFindingsId
		/// </summary>
		public virtual IEntityRelation CarotidArteryTestFindingsEntityUsingLcarotidArteryTestFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CarotidArteryTestFindings", false);
				relation.AddEntityFieldPair(CarotidArteryTestFindingsFields.CarotidArteryTestFindingsId, CarotidArteryTestResultsFields.LcarotidArteryTestFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestResultsEntity and CustomerEventTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// CarotidArteryTestResults.CustomerEventTestId - CustomerEventTests.CustomerEventTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestsEntityUsingCustomerEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventTests", false);
				relation.AddEntityFieldPair(CustomerEventTestsFields.CustomerEventTestId, CarotidArteryTestResultsFields.CustomerEventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", true);
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
