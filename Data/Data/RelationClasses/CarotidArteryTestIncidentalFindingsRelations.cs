﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:09 AM
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
	/// <summary>Implements the static Relations variant for the entity: CarotidArteryTestIncidentalFindings. </summary>
	public partial class CarotidArteryTestIncidentalFindingsRelations
	{
		/// <summary>CTor</summary>
		public CarotidArteryTestIncidentalFindingsRelations()
		{
		}

		/// <summary>Gets all relations of the CarotidArteryTestIncidentalFindingsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CarotidArteryTestResultsEntityUsingCarotidArteryTestId);
			toReturn.Add(this.IncidentalFindingsEntityUsingIncidentalFindingsId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestIncidentalFindingsEntity and CarotidArteryTestResultsEntity over the m:1 relation they have, using the relation between the fields:
		/// CarotidArteryTestIncidentalFindings.CarotidArteryTestId - CarotidArteryTestResults.CarotidArteryTestId
		/// </summary>
		public virtual IEntityRelation CarotidArteryTestResultsEntityUsingCarotidArteryTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CarotidArteryTestResults", false);
				relation.AddEntityFieldPair(CarotidArteryTestResultsFields.CarotidArteryTestId, CarotidArteryTestIncidentalFindingsFields.CarotidArteryTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestIncidentalFindingsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestIncidentalFindingsEntity and IncidentalFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// CarotidArteryTestIncidentalFindings.IncidentalFindingsId - IncidentalFindings.IncidentalFindingsId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingsEntityUsingIncidentalFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IncidentalFindings", false);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, CarotidArteryTestIncidentalFindingsFields.IncidentalFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestIncidentalFindingsEntity", true);
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
