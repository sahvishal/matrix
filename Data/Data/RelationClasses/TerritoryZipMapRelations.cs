///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Tuesday, August 18, 2009 4:45:43 PM
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
	/// <summary>Implements the static Relations variant for the entity: TerritoryZipMap. </summary>
	public partial class TerritoryZipMapRelations
	{
		/// <summary>CTor</summary>
		public TerritoryZipMapRelations()
		{
		}

		/// <summary>Gets all relations of the TerritoryZipMapEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.TerritoryEntityUsingTerritoryId);
			toReturn.Add(this.ZipEntityUsingZipId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between TerritoryZipMapEntity and TerritoryEntity over the m:1 relation they have, using the relation between the fields:
		/// TerritoryZipMap.TerritoryId - Territory.TerritoryId
		/// </summary>
		public virtual IEntityRelation TerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Territory", false);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, TerritoryZipMapFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryZipMapEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TerritoryZipMapEntity and ZipEntity over the m:1 relation they have, using the relation between the fields:
		/// TerritoryZipMap.ZipId - Zip.ZipId
		/// </summary>
		public virtual IEntityRelation ZipEntityUsingZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Zip", false);
				relation.AddEntityFieldPair(ZipFields.ZipId, TerritoryZipMapFields.ZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryZipMapEntity", true);
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
