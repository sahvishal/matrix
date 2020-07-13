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
	/// <summary>Implements the static Relations variant for the entity: Item. </summary>
	public partial class ItemRelations
	{
		/// <summary>CTor</summary>
		public ItemRelations()
		{
		}

		/// <summary>Gets all relations of the ItemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.PodInventoryItemEntityUsingItemId);

			toReturn.Add(this.InventoryItemEntityUsingInventoryItemId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ItemEntity and PodInventoryItemEntity over the 1:n relation they have, using the relation between the fields:
		/// Item.ItemId - PodInventoryItem.ItemId
		/// </summary>
		public virtual IEntityRelation PodInventoryItemEntityUsingItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodInventoryItem" , true);
				relation.AddEntityFieldPair(ItemFields.ItemId, PodInventoryItemFields.ItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodInventoryItemEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ItemEntity and InventoryItemEntity over the m:1 relation they have, using the relation between the fields:
		/// Item.InventoryItemId - InventoryItem.InventoryItemId
		/// </summary>
		public virtual IEntityRelation InventoryItemEntityUsingInventoryItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "InventoryItem", false);
				relation.AddEntityFieldPair(InventoryItemFields.InventoryItemId, ItemFields.InventoryItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InventoryItemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ItemEntity", true);
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
