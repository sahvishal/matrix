﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: AsitestFindings. </summary>
	public partial class AsitestFindingsRelations
	{
		/// <summary>CTor</summary>
		public AsitestFindingsRelations()
		{
		}

		/// <summary>Gets all relations of the AsitestFindingsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OsteoporosisTestResultsEntityUsingOsteoporosisTestFindingsId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AsitestFindingsEntity and OsteoporosisTestResultsEntity over the 1:n relation they have, using the relation between the fields:
		/// AsitestFindings.AsitestFindingsId - OsteoporosisTestResults.OsteoporosisTestFindingsId
		/// </summary>
		public virtual IEntityRelation OsteoporosisTestResultsEntityUsingOsteoporosisTestFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OsteoporosisTestResults" , true);
				relation.AddEntityFieldPair(AsitestFindingsFields.AsitestFindingsId, OsteoporosisTestResultsFields.OsteoporosisTestFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestFindingsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OsteoporosisTestResultsEntity", false);
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