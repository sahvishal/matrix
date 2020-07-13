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
	/// <summary>Implements the static Relations variant for the entity: OrderItem. </summary>
	public partial class OrderItemRelations
	{
		/// <summary>CTor</summary>
		public OrderItemRelations()
		{
		}

		/// <summary>Gets all relations of the OrderItemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventPackageOrderItemEntityUsingOrderItemId);
			toReturn.Add(this.EventTestOrderItemEntityUsingOrderItemId);
			toReturn.Add(this.GiftCertificateOrderItemEntityUsingOrderItemId);
			toReturn.Add(this.OrderDetailEntityUsingOrderItemId);
			toReturn.Add(this.ProductOrderItemEntityUsingOrderItemId);
			toReturn.Add(this.ProspectActivityEntityUsingProspectId);
			toReturn.Add(this.RefundOrderItemEntityUsingOrderItemId);
			toReturn.Add(this.ShippingOptionOrderItemEntityUsingOrderItemId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OrderItemEntity and EventPackageOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderItem.OrderItemId - EventPackageOrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation EventPackageOrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPackageOrderItem" , true);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, EventPackageOrderItemFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderItemEntity and EventTestOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderItem.OrderItemId - EventTestOrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation EventTestOrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTestOrderItem" , true);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, EventTestOrderItemFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderItemEntity and GiftCertificateOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderItem.OrderItemId - GiftCertificateOrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation GiftCertificateOrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GiftCertificateOrderItem" , true);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, GiftCertificateOrderItemFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderItemEntity and OrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderItem.OrderItemId - OrderDetail.OrderItemId
		/// </summary>
		public virtual IEntityRelation OrderDetailEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrderDetail" , true);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, OrderDetailFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderItemEntity and ProductOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderItem.OrderItemId - ProductOrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation ProductOrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProductOrderItem" , true);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, ProductOrderItemFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderItemEntity and ProspectActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderItem.OrderItemId - ProspectActivity.ProspectId
		/// </summary>
		public virtual IEntityRelation ProspectActivityEntityUsingProspectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectActivity" , true);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, ProspectActivityFields.ProspectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectActivityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderItemEntity and RefundOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderItem.OrderItemId - RefundOrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation RefundOrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RefundOrderItem" , true);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, RefundOrderItemFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderItemEntity and ShippingOptionOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderItem.OrderItemId - ShippingOptionOrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation ShippingOptionOrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingOptionOrderItem" , true);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, ShippingOptionOrderItemFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionOrderItemEntity", false);
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
