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
	/// <summary>Implements the static Relations variant for the entity: MarketingPrintOrderItem. </summary>
	public partial class MarketingPrintOrderItemRelations
	{
		/// <summary>CTor</summary>
		public MarketingPrintOrderItemRelations()
		{
		}

		/// <summary>Gets all relations of the MarketingPrintOrderItemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.MarketingPrintOrderProspectListMappingEntityUsingMarketingPrintOrderItemId);
			toReturn.Add(this.PrintOrderItemTrackingEntityUsingPrintOrderItemId);

			toReturn.Add(this.AfmarketingMaterialEntityUsingMarketingMaterialId);
			toReturn.Add(this.CouponsEntityUsingSourceCodeId);
			toReturn.Add(this.LookupEntityUsingStatus);
			toReturn.Add(this.MarketingOrderShippingInfoEntityUsingMarketingOrderShippingInfoId);
			toReturn.Add(this.MarketingPrintOrderEntityUsingMarketingPrintOrderId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderItemEntity and MarketingPrintOrderProspectListMappingEntity over the 1:n relation they have, using the relation between the fields:
		/// MarketingPrintOrderItem.MarketingPrintOrderItemId - MarketingPrintOrderProspectListMapping.MarketingPrintOrderItemId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderProspectListMappingEntityUsingMarketingPrintOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrderProspectListMapping" , true);
				relation.AddEntityFieldPair(MarketingPrintOrderItemFields.MarketingPrintOrderItemId, MarketingPrintOrderProspectListMappingFields.MarketingPrintOrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderProspectListMappingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderItemEntity and PrintOrderItemTrackingEntity over the 1:n relation they have, using the relation between the fields:
		/// MarketingPrintOrderItem.MarketingPrintOrderItemId - PrintOrderItemTracking.PrintOrderItemId
		/// </summary>
		public virtual IEntityRelation PrintOrderItemTrackingEntityUsingPrintOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PrintOrderItemTracking" , true);
				relation.AddEntityFieldPair(MarketingPrintOrderItemFields.MarketingPrintOrderItemId, PrintOrderItemTrackingFields.PrintOrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemTrackingEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderItemEntity and AfmarketingMaterialEntity over the m:1 relation they have, using the relation between the fields:
		/// MarketingPrintOrderItem.MarketingMaterialId - AfmarketingMaterial.MarketingMaterialId
		/// </summary>
		public virtual IEntityRelation AfmarketingMaterialEntityUsingMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfmarketingMaterial", false);
				relation.AddEntityFieldPair(AfmarketingMaterialFields.MarketingMaterialId, MarketingPrintOrderItemFields.MarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderItemEntity and CouponsEntity over the m:1 relation they have, using the relation between the fields:
		/// MarketingPrintOrderItem.SourceCodeId - Coupons.CouponId
		/// </summary>
		public virtual IEntityRelation CouponsEntityUsingSourceCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Coupons", false);
				relation.AddEntityFieldPair(CouponsFields.CouponId, MarketingPrintOrderItemFields.SourceCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderItemEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// MarketingPrintOrderItem.Status - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, MarketingPrintOrderItemFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderItemEntity and MarketingOrderShippingInfoEntity over the m:1 relation they have, using the relation between the fields:
		/// MarketingPrintOrderItem.MarketingOrderShippingInfoId - MarketingOrderShippingInfo.MarketingOrderShippingInfoId
		/// </summary>
		public virtual IEntityRelation MarketingOrderShippingInfoEntityUsingMarketingOrderShippingInfoId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MarketingOrderShippingInfo", false);
				relation.AddEntityFieldPair(MarketingOrderShippingInfoFields.MarketingOrderShippingInfoId, MarketingPrintOrderItemFields.MarketingOrderShippingInfoId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingOrderShippingInfoEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MarketingPrintOrderItemEntity and MarketingPrintOrderEntity over the m:1 relation they have, using the relation between the fields:
		/// MarketingPrintOrderItem.MarketingPrintOrderId - MarketingPrintOrder.MarketingPrintOrderId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderEntityUsingMarketingPrintOrderId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MarketingPrintOrder", false);
				relation.AddEntityFieldPair(MarketingPrintOrderFields.MarketingPrintOrderId, MarketingPrintOrderItemFields.MarketingPrintOrderId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", true);
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
