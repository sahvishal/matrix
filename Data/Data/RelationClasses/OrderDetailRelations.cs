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
	/// <summary>Implements the static Relations variant for the entity: OrderDetail. </summary>
	public partial class OrderDetailRelations
	{
		/// <summary>CTor</summary>
		public OrderDetailRelations()
		{
		}

		/// <summary>Gets all relations of the OrderDetailEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventCustomerOrderDetailEntityUsingOrderDetailId);
			toReturn.Add(this.ShippingDetailOrderDetailEntityUsingOrderDetailId);
			toReturn.Add(this.SourceCodeOrderDetailEntityUsingOrderDetailId);
			toReturn.Add(this.TestOrderItemEntityUsingOrderItemId);

			toReturn.Add(this.LookupEntityUsingSourceId);
			toReturn.Add(this.OrderEntityUsingOrderId);
			toReturn.Add(this.OrderItemEntityUsingOrderItemId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OrderDetailEntity and EventCustomerOrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderDetail.OrderDetailId - EventCustomerOrderDetail.OrderDetailId
		/// </summary>
		public virtual IEntityRelation EventCustomerOrderDetailEntityUsingOrderDetailId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerOrderDetail" , true);
				relation.AddEntityFieldPair(OrderDetailFields.OrderDetailId, EventCustomerOrderDetailFields.OrderDetailId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerOrderDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderDetailEntity and ShippingDetailOrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderDetail.OrderDetailId - ShippingDetailOrderDetail.OrderDetailId
		/// </summary>
		public virtual IEntityRelation ShippingDetailOrderDetailEntityUsingOrderDetailId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingDetailOrderDetail" , true);
				relation.AddEntityFieldPair(OrderDetailFields.OrderDetailId, ShippingDetailOrderDetailFields.OrderDetailId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailOrderDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderDetailEntity and SourceCodeOrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderDetail.OrderDetailId - SourceCodeOrderDetail.OrderDetailId
		/// </summary>
		public virtual IEntityRelation SourceCodeOrderDetailEntityUsingOrderDetailId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SourceCodeOrderDetail" , true);
				relation.AddEntityFieldPair(OrderDetailFields.OrderDetailId, SourceCodeOrderDetailFields.OrderDetailId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SourceCodeOrderDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrderDetailEntity and TestOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// OrderDetail.OrderDetailId - TestOrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation TestOrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestOrderItem" , true);
				relation.AddEntityFieldPair(OrderDetailFields.OrderDetailId, TestOrderItemFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestOrderItemEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between OrderDetailEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// OrderDetail.SourceId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, OrderDetailFields.SourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrderDetailEntity and OrderEntity over the m:1 relation they have, using the relation between the fields:
		/// OrderDetail.OrderId - Order.OrderId
		/// </summary>
		public virtual IEntityRelation OrderEntityUsingOrderId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Order", false);
				relation.AddEntityFieldPair(OrderFields.OrderId, OrderDetailFields.OrderId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrderDetailEntity and OrderItemEntity over the m:1 relation they have, using the relation between the fields:
		/// OrderDetail.OrderItemId - OrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation OrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrderItem", false);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, OrderDetailFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", true);
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
