///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:38
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
	/// <summary>Implements the static Relations variant for the entity: Product. </summary>
	public partial class ProductRelations
	{
		/// <summary>CTor</summary>
		public ProductRelations()
		{
		}

		/// <summary>Gets all relations of the ProductEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventProductExclusionEntityUsingProductId);
			toReturn.Add(this.ProductOrderItemEntityUsingProductId);
			toReturn.Add(this.ProductShippingOptionEntityUsingProductId);
			toReturn.Add(this.ProductSourceCodeDiscountEntityUsingProductId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ProductEntity and EventProductExclusionEntity over the 1:n relation they have, using the relation between the fields:
		/// Product.ProductId - EventProductExclusion.ProductId
		/// </summary>
		public virtual IEntityRelation EventProductExclusionEntityUsingProductId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventProductExclusion" , true);
				relation.AddEntityFieldPair(ProductFields.ProductId, EventProductExclusionFields.ProductId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventProductExclusionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProductEntity and ProductOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// Product.ProductId - ProductOrderItem.ProductId
		/// </summary>
		public virtual IEntityRelation ProductOrderItemEntityUsingProductId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProductOrderItem" , true);
				relation.AddEntityFieldPair(ProductFields.ProductId, ProductOrderItemFields.ProductId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProductEntity and ProductShippingOptionEntity over the 1:n relation they have, using the relation between the fields:
		/// Product.ProductId - ProductShippingOption.ProductId
		/// </summary>
		public virtual IEntityRelation ProductShippingOptionEntityUsingProductId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProductShippingOption" , true);
				relation.AddEntityFieldPair(ProductFields.ProductId, ProductShippingOptionFields.ProductId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductShippingOptionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProductEntity and ProductSourceCodeDiscountEntity over the 1:n relation they have, using the relation between the fields:
		/// Product.ProductId - ProductSourceCodeDiscount.ProductId
		/// </summary>
		public virtual IEntityRelation ProductSourceCodeDiscountEntityUsingProductId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProductSourceCodeDiscount" , true);
				relation.AddEntityFieldPair(ProductFields.ProductId, ProductSourceCodeDiscountFields.ProductId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductSourceCodeDiscountEntity", false);
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
