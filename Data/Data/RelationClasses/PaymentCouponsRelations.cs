///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:13 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: PaymentCoupons. </summary>
	public partial class PaymentCouponsRelations
	{
		/// <summary>CTor</summary>
		public PaymentCouponsRelations()
		{
		}

		/// <summary>Gets all relations of the PaymentCouponsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CouponsEntityUsingCouponId);
			toReturn.Add(this.PaymentDetailsEntityUsingPaymentDetailsId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PaymentCouponsEntity and CouponsEntity over the m:1 relation they have, using the relation between the fields:
		/// PaymentCoupons.CouponId - Coupons.CouponId
		/// </summary>
		public virtual IEntityRelation CouponsEntityUsingCouponId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Coupons", false);
				relation.AddEntityFieldPair(CouponsFields.CouponId, PaymentCouponsFields.CouponId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentCouponsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PaymentCouponsEntity and PaymentDetailsEntity over the m:1 relation they have, using the relation between the fields:
		/// PaymentCoupons.PaymentDetailsId - PaymentDetails.PaymentId
		/// </summary>
		public virtual IEntityRelation PaymentDetailsEntityUsingPaymentDetailsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PaymentDetails", false);
				relation.AddEntityFieldPair(PaymentDetailsFields.PaymentId, PaymentCouponsFields.PaymentDetailsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentCouponsEntity", true);
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
