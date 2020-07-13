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
	/// <summary>Implements the static Relations variant for the entity: ShippingDetailOrderDetail. </summary>
	public partial class ShippingDetailOrderDetailRelations
	{
		/// <summary>CTor</summary>
		public ShippingDetailOrderDetailRelations()
		{
		}

		/// <summary>Gets all relations of the ShippingDetailOrderDetailEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.OrderDetailEntityUsingOrderDetailId);
			toReturn.Add(this.ShippingDetailEntityUsingShippingDetailId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ShippingDetailOrderDetailEntity and OrderDetailEntity over the m:1 relation they have, using the relation between the fields:
		/// ShippingDetailOrderDetail.OrderDetailId - OrderDetail.OrderDetailId
		/// </summary>
		public virtual IEntityRelation OrderDetailEntityUsingOrderDetailId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrderDetail", false);
				relation.AddEntityFieldPair(OrderDetailFields.OrderDetailId, ShippingDetailOrderDetailFields.OrderDetailId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailOrderDetailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ShippingDetailOrderDetailEntity and ShippingDetailEntity over the m:1 relation they have, using the relation between the fields:
		/// ShippingDetailOrderDetail.ShippingDetailId - ShippingDetail.ShippingDetailId
		/// </summary>
		public virtual IEntityRelation ShippingDetailEntityUsingShippingDetailId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShippingDetail", false);
				relation.AddEntityFieldPair(ShippingDetailFields.ShippingDetailId, ShippingDetailOrderDetailFields.ShippingDetailId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailOrderDetailEntity", true);
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
