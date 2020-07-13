///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:04 AM
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
	/// <summary>Implements the static Relations variant for the entity: PadtestIncidentalFindings. </summary>
	public partial class PadtestIncidentalFindingsRelations
	{
		/// <summary>CTor</summary>
		public PadtestIncidentalFindingsRelations()
		{
		}

		/// <summary>Gets all relations of the PadtestIncidentalFindingsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.IncidentalFindingsEntityUsingIncidentalFindingsId);
			toReturn.Add(this.PadtestResultsEntityUsingPadtestId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PadtestIncidentalFindingsEntity and IncidentalFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// PadtestIncidentalFindings.IncidentalFindingsId - IncidentalFindings.IncidentalFindingsId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingsEntityUsingIncidentalFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IncidentalFindings", false);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, PadtestIncidentalFindingsFields.IncidentalFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestIncidentalFindingsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PadtestIncidentalFindingsEntity and PadtestResultsEntity over the m:1 relation they have, using the relation between the fields:
		/// PadtestIncidentalFindings.PadtestId - PadtestResults.PadtestId
		/// </summary>
		public virtual IEntityRelation PadtestResultsEntityUsingPadtestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PadtestResults", false);
				relation.AddEntityFieldPair(PadtestResultsFields.PadtestId, PadtestIncidentalFindingsFields.PadtestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestResultsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PadtestIncidentalFindingsEntity", true);
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
