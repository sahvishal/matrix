﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: InventoryItem. </summary>
	public partial class InventoryItemRelations
	{
		/// <summary>CTor</summary>
		public InventoryItemRelations()
		{
		}

		/// <summary>Gets all relations of the InventoryItemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.InventoryItemTestEntityUsingInventoryItemId);
			toReturn.Add(this.ItemEntityUsingInventoryItemId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between InventoryItemEntity and InventoryItemTestEntity over the 1:n relation they have, using the relation between the fields:
		/// InventoryItem.InventoryItemId - InventoryItemTest.InventoryItemId
		/// </summary>
		public virtual IEntityRelation InventoryItemTestEntityUsingInventoryItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InventoryItemTest" , true);
				relation.AddEntityFieldPair(InventoryItemFields.InventoryItemId, InventoryItemTestFields.InventoryItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InventoryItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InventoryItemTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between InventoryItemEntity and ItemEntity over the 1:n relation they have, using the relation between the fields:
		/// InventoryItem.InventoryItemId - Item.InventoryItemId
		/// </summary>
		public virtual IEntityRelation ItemEntityUsingInventoryItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Item" , true);
				relation.AddEntityFieldPair(InventoryItemFields.InventoryItemId, ItemFields.InventoryItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InventoryItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ItemEntity", false);
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
