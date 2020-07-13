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
	/// <summary>Implements the static Relations variant for the entity: AsiunableScreenReason. </summary>
	public partial class AsiunableScreenReasonRelations
	{
		/// <summary>CTor</summary>
		public AsiunableScreenReasonRelations()
		{
		}

		/// <summary>Gets all relations of the AsiunableScreenReasonEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AsitestResultsEntityUsingAsitestId);
			toReturn.Add(this.UnableScreenReasonEntityUsingUnableScreenReasonId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AsiunableScreenReasonEntity and AsitestResultsEntity over the m:1 relation they have, using the relation between the fields:
		/// AsiunableScreenReason.AsitestId - AsitestResults.AsitestId
		/// </summary>
		public virtual IEntityRelation AsitestResultsEntityUsingAsitestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AsitestResults", false);
				relation.AddEntityFieldPair(AsitestResultsFields.AsitestId, AsiunableScreenReasonFields.AsitestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsitestResultsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsiunableScreenReasonEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AsiunableScreenReasonEntity and UnableScreenReasonEntity over the m:1 relation they have, using the relation between the fields:
		/// AsiunableScreenReason.UnableScreenReasonId - UnableScreenReason.UnableScreenReasonId
		/// </summary>
		public virtual IEntityRelation UnableScreenReasonEntityUsingUnableScreenReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "UnableScreenReason", false);
				relation.AddEntityFieldPair(UnableScreenReasonFields.UnableScreenReasonId, AsiunableScreenReasonFields.UnableScreenReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UnableScreenReasonEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsiunableScreenReasonEntity", true);
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