///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
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
	/// <summary>Implements the static Relations variant for the entity: AfmarketingMaterial. </summary>
	public partial class AfmarketingMaterialRelations
	{
		/// <summary>CTor</summary>
		public AfmarketingMaterialRelations()
		{
		}

		/// <summary>Gets all relations of the AfmarketingMaterialEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfAdvertisingCommissionEntityUsingMarketingMaterialId);
			toReturn.Add(this.AfaffiliateCampaignMarketingMaterialEntityUsingMarketingMaterialId);
			toReturn.Add(this.ClickLogEntityUsingMarketingMaterialId);
			toReturn.Add(this.CustomCampaignContentEntityUsingMarketingMaterialId);
			toReturn.Add(this.MarketingPrintOrderItemEntityUsingMarketingMaterialId);
			toReturn.Add(this.WidgetEntityUsingMarketingMaterialId);

			toReturn.Add(this.AfmarketingMaterialTypeEntityUsingMarketingMaterialTypeId);
			toReturn.Add(this.EventsEntityUsingEventId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialEntity and AfAdvertisingCommissionEntity over the 1:n relation they have, using the relation between the fields:
		/// AfmarketingMaterial.MarketingMaterialId - AfAdvertisingCommission.MarketingMaterialId
		/// </summary>
		public virtual IEntityRelation AfAdvertisingCommissionEntityUsingMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfAdvertisingCommission" , true);
				relation.AddEntityFieldPair(AfmarketingMaterialFields.MarketingMaterialId, AfAdvertisingCommissionFields.MarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfAdvertisingCommissionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialEntity and AfaffiliateCampaignMarketingMaterialEntity over the 1:n relation they have, using the relation between the fields:
		/// AfmarketingMaterial.MarketingMaterialId - AfaffiliateCampaignMarketingMaterial.MarketingMaterialId
		/// </summary>
		public virtual IEntityRelation AfaffiliateCampaignMarketingMaterialEntityUsingMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfaffiliateCampaignMarketingMaterial" , true);
				relation.AddEntityFieldPair(AfmarketingMaterialFields.MarketingMaterialId, AfaffiliateCampaignMarketingMaterialFields.MarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignMarketingMaterialEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialEntity and ClickLogEntity over the 1:n relation they have, using the relation between the fields:
		/// AfmarketingMaterial.MarketingMaterialId - ClickLog.MarketingMaterialId
		/// </summary>
		public virtual IEntityRelation ClickLogEntityUsingMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClickLog" , true);
				relation.AddEntityFieldPair(AfmarketingMaterialFields.MarketingMaterialId, ClickLogFields.MarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialEntity and CustomCampaignContentEntity over the 1:n relation they have, using the relation between the fields:
		/// AfmarketingMaterial.MarketingMaterialId - CustomCampaignContent.MarketingMaterialId
		/// </summary>
		public virtual IEntityRelation CustomCampaignContentEntityUsingMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomCampaignContent" , true);
				relation.AddEntityFieldPair(AfmarketingMaterialFields.MarketingMaterialId, CustomCampaignContentFields.MarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomCampaignContentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialEntity and MarketingPrintOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// AfmarketingMaterial.MarketingMaterialId - MarketingPrintOrderItem.MarketingMaterialId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderItemEntityUsingMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrderItem" , true);
				relation.AddEntityFieldPair(AfmarketingMaterialFields.MarketingMaterialId, MarketingPrintOrderItemFields.MarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialEntity and WidgetEntity over the 1:n relation they have, using the relation between the fields:
		/// AfmarketingMaterial.MarketingMaterialId - Widget.MarketingMaterialId
		/// </summary>
		public virtual IEntityRelation WidgetEntityUsingMarketingMaterialId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Widget" , true);
				relation.AddEntityFieldPair(AfmarketingMaterialFields.MarketingMaterialId, WidgetFields.MarketingMaterialId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WidgetEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialEntity and AfmarketingMaterialTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// AfmarketingMaterial.MarketingMaterialTypeId - AfmarketingMaterialType.MarketingMaterialTypeId
		/// </summary>
		public virtual IEntityRelation AfmarketingMaterialTypeEntityUsingMarketingMaterialTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfmarketingMaterialType", false);
				relation.AddEntityFieldPair(AfmarketingMaterialTypeFields.MarketingMaterialTypeId, AfmarketingMaterialFields.MarketingMaterialTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AfmarketingMaterialEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// AfmarketingMaterial.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, AfmarketingMaterialFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfmarketingMaterialEntity", true);
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
