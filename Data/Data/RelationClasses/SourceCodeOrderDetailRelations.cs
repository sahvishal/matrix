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
	/// <summary>Implements the static Relations variant for the entity: SourceCodeOrderDetail. </summary>
	public partial class SourceCodeOrderDetailRelations
	{
		/// <summary>CTor</summary>
		public SourceCodeOrderDetailRelations()
		{
		}

		/// <summary>Gets all relations of the SourceCodeOrderDetailEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CouponsEntityUsingSourceCodeId);
			toReturn.Add(this.OrderDetailEntityUsingOrderDetailId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between SourceCodeOrderDetailEntity and CouponsEntity over the m:1 relation they have, using the relation between the fields:
		/// SourceCodeOrderDetail.SourceCodeId - Coupons.CouponId
		/// </summary>
		public virtual IEntityRelation CouponsEntityUsingSourceCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Coupons", false);
				relation.AddEntityFieldPair(CouponsFields.CouponId, SourceCodeOrderDetailFields.SourceCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SourceCodeOrderDetailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SourceCodeOrderDetailEntity and OrderDetailEntity over the m:1 relation they have, using the relation between the fields:
		/// SourceCodeOrderDetail.OrderDetailId - OrderDetail.OrderDetailId
		/// </summary>
		public virtual IEntityRelation OrderDetailEntityUsingOrderDetailId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrderDetail", false);
				relation.AddEntityFieldPair(OrderDetailFields.OrderDetailId, SourceCodeOrderDetailFields.OrderDetailId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SourceCodeOrderDetailEntity", true);
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
