///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using Falcon.Data;
using Falcon.Data.FactoryClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: AfmarketingMaterialType. </summary>
	public partial class AfmarketingMaterialTypeRelations
	{
		/// <summary>CTor</summary>
		public AfmarketingMaterialTypeRelations()
		{
		}

		/// <summary>Gets all relations of the AfmarketingMaterialTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfmarketingMaterialEntityUsingMarketingMaterialTypeId);

			toReturn.Add(this.AfmarketingMaterialGroupEntityUsingGroupId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialTypeEntity and AfmarketingMaterialEntity over the 1:n relation they have, using the relation between the fields:
		/// AfmarketingMaterialType.MarketingMaterialTypeId - AfmarketingMaterial.MarketingMaterialTypeId
		/// </summary>
		public virtual IEntityRelation AfmarketingMaterialEntityUsingMarketingMaterialTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfmarketingMaterial" , true);
				relation.AddEntityFieldPair(AfmarketingMaterialTypeFields.MarketingMaterialTypeId, AfmarketingMaterialFields.MarketingMaterialTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialTypeEntity and AfmarketingMaterialGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// AfmarketingMaterialType.GroupId - AfmarketingMaterialGroup.MarketingMaterialGroupId
		/// </summary>
		public virtual IEntityRelation AfmarketingMaterialGroupEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfmarketingMaterialGroup", false);
				relation.AddEntityFieldPair(AfmarketingMaterialGroupFields.MarketingMaterialGroupId, AfmarketingMaterialTypeFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialTypeEntity", true);
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
