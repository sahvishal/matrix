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
	/// <summary>Implements the static Relations variant for the entity: ShippingOption. </summary>
	public partial class ShippingOptionRelations
	{
		/// <summary>CTor</summary>
		public ShippingOptionRelations()
		{
		}

		/// <summary>Gets all relations of the ShippingOptionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.HospitalPartnerShippingOptionEntityUsingShippingOptionId);
			toReturn.Add(this.ProductShippingOptionEntityUsingShippingOptionId);
			toReturn.Add(this.ShippingDetailEntityUsingShippingOptionId);
			toReturn.Add(this.ShippingOptionOrderItemEntityUsingShippingOptionId);
			toReturn.Add(this.ShippingOptionSourceCodeDiscountEntityUsingShippingOptionId);

			toReturn.Add(this.CarrierEntityUsingCarrierId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ShippingOptionEntity and HospitalPartnerShippingOptionEntity over the 1:n relation they have, using the relation between the fields:
		/// ShippingOption.ShippingOptionId - HospitalPartnerShippingOption.ShippingOptionId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerShippingOptionEntityUsingShippingOptionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerShippingOption" , true);
				relation.AddEntityFieldPair(ShippingOptionFields.ShippingOptionId, HospitalPartnerShippingOptionFields.ShippingOptionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerShippingOptionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShippingOptionEntity and ProductShippingOptionEntity over the 1:n relation they have, using the relation between the fields:
		/// ShippingOption.ShippingOptionId - ProductShippingOption.ShippingOptionId
		/// </summary>
		public virtual IEntityRelation ProductShippingOptionEntityUsingShippingOptionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProductShippingOption" , true);
				relation.AddEntityFieldPair(ShippingOptionFields.ShippingOptionId, ProductShippingOptionFields.ShippingOptionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductShippingOptionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShippingOptionEntity and ShippingDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// ShippingOption.ShippingOptionId - ShippingDetail.ShippingOptionId
		/// </summary>
		public virtual IEntityRelation ShippingDetailEntityUsingShippingOptionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingDetail" , true);
				relation.AddEntityFieldPair(ShippingOptionFields.ShippingOptionId, ShippingDetailFields.ShippingOptionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShippingOptionEntity and ShippingOptionOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// ShippingOption.ShippingOptionId - ShippingOptionOrderItem.ShippingOptionId
		/// </summary>
		public virtual IEntityRelation ShippingOptionOrderItemEntityUsingShippingOptionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingOptionOrderItem" , true);
				relation.AddEntityFieldPair(ShippingOptionFields.ShippingOptionId, ShippingOptionOrderItemFields.ShippingOptionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShippingOptionEntity and ShippingOptionSourceCodeDiscountEntity over the 1:n relation they have, using the relation between the fields:
		/// ShippingOption.ShippingOptionId - ShippingOptionSourceCodeDiscount.ShippingOptionId
		/// </summary>
		public virtual IEntityRelation ShippingOptionSourceCodeDiscountEntityUsingShippingOptionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingOptionSourceCodeDiscount" , true);
				relation.AddEntityFieldPair(ShippingOptionFields.ShippingOptionId, ShippingOptionSourceCodeDiscountFields.ShippingOptionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionSourceCodeDiscountEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ShippingOptionEntity and CarrierEntity over the m:1 relation they have, using the relation between the fields:
		/// ShippingOption.CarrierId - Carrier.CarrierId
		/// </summary>
		public virtual IEntityRelation CarrierEntityUsingCarrierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Carrier", false);
				relation.AddEntityFieldPair(CarrierFields.CarrierId, ShippingOptionFields.CarrierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarrierEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionEntity", true);
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
