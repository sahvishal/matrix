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
	/// <summary>Implements the static Relations variant for the entity: RefundOrderItem. </summary>
	public partial class RefundOrderItemRelations
	{
		/// <summary>CTor</summary>
		public RefundOrderItemRelations()
		{
		}

		/// <summary>Gets all relations of the RefundOrderItemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.OrderItemEntityUsingOrderItemId);
			toReturn.Add(this.RefundEntityUsingRefundId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between RefundOrderItemEntity and OrderItemEntity over the m:1 relation they have, using the relation between the fields:
		/// RefundOrderItem.OrderItemId - OrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation OrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrderItem", false);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, RefundOrderItemFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundOrderItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RefundOrderItemEntity and RefundEntity over the m:1 relation they have, using the relation between the fields:
		/// RefundOrderItem.RefundId - Refund.RefundId
		/// </summary>
		public virtual IEntityRelation RefundEntityUsingRefundId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Refund", false);
				relation.AddEntityFieldPair(RefundFields.RefundId, RefundOrderItemFields.RefundId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundOrderItemEntity", true);
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
