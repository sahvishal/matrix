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
	/// <summary>Implements the static Relations variant for the entity: Coupons. </summary>
	public partial class CouponsRelations
	{
		/// <summary>CTor</summary>
		public CouponsRelations()
		{
		}

		/// <summary>Gets all relations of the CouponsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CouponSignUpModeEntityUsingCouponId);
			toReturn.Add(this.EventCouponsEntityUsingCouponId);
			toReturn.Add(this.MarketingPrintOrderItemEntityUsingSourceCodeId);
			toReturn.Add(this.PackageSourceCodeDiscountEntityUsingSourceCodeId);
			toReturn.Add(this.ProductSourceCodeDiscountEntityUsingSourceCodeId);
			toReturn.Add(this.ShippingOptionSourceCodeDiscountEntityUsingSourceCodeId);
			toReturn.Add(this.SourceCodeOrderDetailEntityUsingSourceCodeId);
			toReturn.Add(this.TestSourceCodeDiscountEntityUsingSourceCodeId);

			toReturn.Add(this.CouponTypeEntityUsingCouponTypeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and CouponSignUpModeEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupons.CouponId - CouponSignUpMode.CouponId
		/// </summary>
		public virtual IEntityRelation CouponSignUpModeEntityUsingCouponId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CouponSignUpMode" , true);
				relation.AddEntityFieldPair(CouponsFields.CouponId, CouponSignUpModeFields.CouponId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponSignUpModeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and EventCouponsEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupons.CouponId - EventCoupons.CouponId
		/// </summary>
		public virtual IEntityRelation EventCouponsEntityUsingCouponId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCoupons" , true);
				relation.AddEntityFieldPair(CouponsFields.CouponId, EventCouponsFields.CouponId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCouponsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and MarketingPrintOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupons.CouponId - MarketingPrintOrderItem.SourceCodeId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderItemEntityUsingSourceCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrderItem" , true);
				relation.AddEntityFieldPair(CouponsFields.CouponId, MarketingPrintOrderItemFields.SourceCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and PackageSourceCodeDiscountEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupons.CouponId - PackageSourceCodeDiscount.SourceCodeId
		/// </summary>
		public virtual IEntityRelation PackageSourceCodeDiscountEntityUsingSourceCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PackageSourceCodeDiscount" , true);
				relation.AddEntityFieldPair(CouponsFields.CouponId, PackageSourceCodeDiscountFields.SourceCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageSourceCodeDiscountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and ProductSourceCodeDiscountEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupons.CouponId - ProductSourceCodeDiscount.SourceCodeId
		/// </summary>
		public virtual IEntityRelation ProductSourceCodeDiscountEntityUsingSourceCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProductSourceCodeDiscount" , true);
				relation.AddEntityFieldPair(CouponsFields.CouponId, ProductSourceCodeDiscountFields.SourceCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductSourceCodeDiscountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and ShippingOptionSourceCodeDiscountEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupons.CouponId - ShippingOptionSourceCodeDiscount.SourceCodeId
		/// </summary>
		public virtual IEntityRelation ShippingOptionSourceCodeDiscountEntityUsingSourceCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingOptionSourceCodeDiscount" , true);
				relation.AddEntityFieldPair(CouponsFields.CouponId, ShippingOptionSourceCodeDiscountFields.SourceCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionSourceCodeDiscountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and SourceCodeOrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupons.CouponId - SourceCodeOrderDetail.SourceCodeId
		/// </summary>
		public virtual IEntityRelation SourceCodeOrderDetailEntityUsingSourceCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SourceCodeOrderDetail" , true);
				relation.AddEntityFieldPair(CouponsFields.CouponId, SourceCodeOrderDetailFields.SourceCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SourceCodeOrderDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and TestSourceCodeDiscountEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupons.CouponId - TestSourceCodeDiscount.SourceCodeId
		/// </summary>
		public virtual IEntityRelation TestSourceCodeDiscountEntityUsingSourceCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestSourceCodeDiscount" , true);
				relation.AddEntityFieldPair(CouponsFields.CouponId, TestSourceCodeDiscountFields.SourceCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestSourceCodeDiscountEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and CouponTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Coupons.CouponTypeId - CouponType.CouponTypeId
		/// </summary>
		public virtual IEntityRelation CouponTypeEntityUsingCouponTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CouponType", false);
				relation.AddEntityFieldPair(CouponTypeFields.CouponTypeId, CouponsFields.CouponTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Coupons.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CouponsFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CouponsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Coupons.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CouponsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", true);
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
