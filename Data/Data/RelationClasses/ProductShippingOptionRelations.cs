///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
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
	/// <summary>Implements the static Relations variant for the entity: ProductShippingOption. </summary>
	public partial class ProductShippingOptionRelations
	{
		/// <summary>CTor</summary>
		public ProductShippingOptionRelations()
		{
		}

		/// <summary>Gets all relations of the ProductShippingOptionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ProductEntityUsingProductId);
			toReturn.Add(this.ShippingOptionEntityUsingShippingOptionId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ProductShippingOptionEntity and ProductEntity over the m:1 relation they have, using the relation between the fields:
		/// ProductShippingOption.ProductId - Product.ProductId
		/// </summary>
		public virtual IEntityRelation ProductEntityUsingProductId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Product", false);
				relation.AddEntityFieldPair(ProductFields.ProductId, ProductShippingOptionFields.ProductId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductShippingOptionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProductShippingOptionEntity and ShippingOptionEntity over the m:1 relation they have, using the relation between the fields:
		/// ProductShippingOption.ShippingOptionId - ShippingOption.ShippingOptionId
		/// </summary>
		public virtual IEntityRelation ShippingOptionEntityUsingShippingOptionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShippingOption", false);
				relation.AddEntityFieldPair(ShippingOptionFields.ShippingOptionId, ProductShippingOptionFields.ShippingOptionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductShippingOptionEntity", true);
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
