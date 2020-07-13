///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:18 AM
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
	/// <summary>Implements the static Relations variant for the entity: OsteoporosisTestIncidentalFindings. </summary>
	public partial class OsteoporosisTestIncidentalFindingsRelations
	{
		/// <summary>CTor</summary>
		public OsteoporosisTestIncidentalFindingsRelations()
		{
		}

		/// <summary>Gets all relations of the OsteoporosisTestIncidentalFindingsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.IncidentalFindingsEntityUsingIncidentalFindingsId);
			toReturn.Add(this.OsteoporosisTestResultsEntityUsingOsteoporosisTestId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between OsteoporosisTestIncidentalFindingsEntity and IncidentalFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// OsteoporosisTestIncidentalFindings.IncidentalFindingsId - IncidentalFindings.IncidentalFindingsId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingsEntityUsingIncidentalFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IncidentalFindings", false);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, OsteoporosisTestIncidentalFindingsFields.IncidentalFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestIncidentalFindingsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OsteoporosisTestIncidentalFindingsEntity and OsteoporosisTestResultsEntity over the m:1 relation they have, using the relation between the fields:
		/// OsteoporosisTestIncidentalFindings.OsteoporosisTestId - OsteoporosisTestResults.OsteoporosisTestId
		/// </summary>
		public virtual IEntityRelation OsteoporosisTestResultsEntityUsingOsteoporosisTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OsteoporosisTestResults", false);
				relation.AddEntityFieldPair(OsteoporosisTestResultsFields.OsteoporosisTestId, OsteoporosisTestIncidentalFindingsFields.OsteoporosisTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestResultsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestIncidentalFindingsEntity", true);
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
