///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:08 AM
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
	/// <summary>Implements the static Relations variant for the entity: AsitestResults. </summary>
	public partial class AsitestResultsRelations
	{
		/// <summary>CTor</summary>
		public AsitestResultsRelations()
		{
		}

		/// <summary>Gets all relations of the AsitestResultsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ASIRawDataReadingEntityUsingAsitestId);
			toReturn.Add(this.AsitestIncidentalFindingsEntityUsingAsitestId);
			toReturn.Add(this.AsiunableScreenReasonEntityUsingAsitestId);
			toReturn.Add(this.CarotidArteryTestRecommendationEntityUsingCarotidArteryTestId);

			toReturn.Add(this.AaatestFindingsEntityUsingAsitestFindingsId);
			toReturn.Add(this.CustomerEventTestsEntityUsingCustomerEventTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AsitestResultsEntity and ASIRawDataReadingEntity over the 1:n relation they have, using the relation between the fields:
		/// AsitestResults.AsitestId - ASIRawDataReading.AsitestId
		/// </summary>
		public virtual IEntityRelation ASIRawDataReadingEntityUsingAsitestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AsirawDataReading" , true);
				relation.AddEntityFieldPair(AsitestResultsFields.AsitestId, ASIRawDataReadingFields.AsitestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ASIRawDataReadingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AsitestResultsEntity and AsitestIncidentalFindingsEntity over the 1:n relation they have, using the relation between the fields:
		/// AsitestResults.AsitestId - AsitestIncidentalFindings.AsitestId
		/// </summary>
		public virtual IEntityRelation AsitestIncidentalFindingsEntityUsingAsitestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AsitestIncidentalFindings" , true);
				relation.AddEntityFieldPair(AsitestResultsFields.AsitestId, AsitestIncidentalFindingsFields.AsitestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestIncidentalFindingsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AsitestResultsEntity and AsiunableScreenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// AsitestResults.AsitestId - AsiunableScreenReason.AsitestId
		/// </summary>
		public virtual IEntityRelation AsiunableScreenReasonEntityUsingAsitestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AsiunableScreenReason" , true);
				relation.AddEntityFieldPair(AsitestResultsFields.AsitestId, AsiunableScreenReasonFields.AsitestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsiunableScreenReasonEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AsitestResultsEntity and CarotidArteryTestRecommendationEntity over the 1:n relation they have, using the relation between the fields:
		/// AsitestResults.AsitestId - CarotidArteryTestRecommendation.CarotidArteryTestId
		/// </summary>
		public virtual IEntityRelation CarotidArteryTestRecommendationEntityUsingCarotidArteryTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CarotidArteryTestRecommendation" , true);
				relation.AddEntityFieldPair(AsitestResultsFields.AsitestId, CarotidArteryTestRecommendationFields.CarotidArteryTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestResultsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestRecommendationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AsitestResultsEntity and AaatestFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// AsitestResults.AsitestFindingsId - AaatestFindings.AaatestFindingsId
		/// </summary>
		public virtual IEntityRelation AaatestFindingsEntityUsingAsitestFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AaatestFindings", false);
				relation.AddEntityFieldPair(AaatestFindingsFields.AaatestFindingsId, AsitestResultsFields.AsitestFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestResultsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AsitestResultsEntity and CustomerEventTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// AsitestResults.CustomerEventTestId - CustomerEventTests.CustomerEventTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestsEntityUsingCustomerEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventTests", false);
				relation.AddEntityFieldPair(CustomerEventTestsFields.CustomerEventTestId, AsitestResultsFields.CustomerEventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestResultsEntity", true);
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
