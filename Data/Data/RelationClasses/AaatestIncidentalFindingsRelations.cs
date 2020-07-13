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
	/// <summary>Implements the static Relations variant for the entity: AaatestIncidentalFindings. </summary>
	public partial class AaatestIncidentalFindingsRelations
	{
		/// <summary>CTor</summary>
		public AaatestIncidentalFindingsRelations()
		{
		}

		/// <summary>Gets all relations of the AaatestIncidentalFindingsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AaaiflocationWiseDataEntityUsingAaatestIncidentalFindingsId);

			toReturn.Add(this.AaatestResultsEntityUsingAaatestId);
			toReturn.Add(this.IncidentalFindingsEntityUsingIncidentalFindingsId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AaatestIncidentalFindingsEntity and AaaiflocationWiseDataEntity over the 1:n relation they have, using the relation between the fields:
		/// AaatestIncidentalFindings.AaatestIncidentalFindingsId - AaaiflocationWiseData.AaatestIncidentalFindingsId
		/// </summary>
		public virtual IEntityRelation AaaiflocationWiseDataEntityUsingAaatestIncidentalFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AaaiflocationWiseData" , true);
				relation.AddEntityFieldPair(AaatestIncidentalFindingsFields.AaatestIncidentalFindingsId, AaaiflocationWiseDataFields.AaatestIncidentalFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestIncidentalFindingsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaaiflocationWiseDataEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AaatestIncidentalFindingsEntity and AaatestResultsEntity over the m:1 relation they have, using the relation between the fields:
		/// AaatestIncidentalFindings.AaatestId - AaatestResults.AaatestId
		/// </summary>
		public virtual IEntityRelation AaatestResultsEntityUsingAaatestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AaatestResults", false);
				relation.AddEntityFieldPair(AaatestResultsFields.AaatestId, AaatestIncidentalFindingsFields.AaatestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestResultsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestIncidentalFindingsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AaatestIncidentalFindingsEntity and IncidentalFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// AaatestIncidentalFindings.IncidentalFindingsId - IncidentalFindings.IncidentalFindingsId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingsEntityUsingIncidentalFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IncidentalFindings", false);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, AaatestIncidentalFindingsFields.IncidentalFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestIncidentalFindingsEntity", true);
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
