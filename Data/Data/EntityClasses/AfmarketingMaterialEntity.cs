///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:43
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using Falcon.Data;
using Falcon.Data.HelperClasses;
using Falcon.Data.FactoryClasses;
using Falcon.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'AfmarketingMaterial'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AfmarketingMaterialEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AfAdvertisingCommissionEntity> _afAdvertisingCommission;
		private EntityCollection<AfaffiliateCampaignMarketingMaterialEntity> _afaffiliateCampaignMarketingMaterial;
		private EntityCollection<ClickLogEntity> _clickLog;
		private EntityCollection<CustomCampaignContentEntity> _customCampaignContent;
		private EntityCollection<MarketingPrintOrderItemEntity> _marketingPrintOrderItem;
		private EntityCollection<WidgetEntity> _widget;
		private EntityCollection<AfcampaignEntity> _afcampaignCollectionViaClickLog;
		private EntityCollection<AfcampaignEntity> _afcampaignCollectionViaCustomCampaignContent;
		private EntityCollection<AfcampaignEntity> _afcampaignCollectionViaAfAdvertisingCommission;
		private EntityCollection<AfcampaignEntity> _afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial;
		private EntityCollection<CouponsEntity> _couponsCollectionViaMarketingPrintOrderItem;
		private EntityCollection<LookupEntity> _lookupCollectionViaMarketingPrintOrderItem;
		private EntityCollection<MarketingOrderShippingInfoEntity> _marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem;
		private EntityCollection<MarketingPrintOrderEntity> _marketingPrintOrderCollectionViaMarketingPrintOrderItem;
		private AfmarketingMaterialTypeEntity _afmarketingMaterialType;
		private EventsEntity _events;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AfmarketingMaterialType</summary>
			public static readonly string AfmarketingMaterialType = "AfmarketingMaterialType";
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name AfAdvertisingCommission</summary>
			public static readonly string AfAdvertisingCommission = "AfAdvertisingCommission";
			/// <summary>Member name AfaffiliateCampaignMarketingMaterial</summary>
			public static readonly string AfaffiliateCampaignMarketingMaterial = "AfaffiliateCampaignMarketingMaterial";
			/// <summary>Member name ClickLog</summary>
			public static readonly string ClickLog = "ClickLog";
			/// <summary>Member name CustomCampaignContent</summary>
			public static readonly string CustomCampaignContent = "CustomCampaignContent";
			/// <summary>Member name MarketingPrintOrderItem</summary>
			public static readonly string MarketingPrintOrderItem = "MarketingPrintOrderItem";
			/// <summary>Member name Widget</summary>
			public static readonly string Widget = "Widget";
			/// <summary>Member name AfcampaignCollectionViaClickLog</summary>
			public static readonly string AfcampaignCollectionViaClickLog = "AfcampaignCollectionViaClickLog";
			/// <summary>Member name AfcampaignCollectionViaCustomCampaignContent</summary>
			public static readonly string AfcampaignCollectionViaCustomCampaignContent = "AfcampaignCollectionViaCustomCampaignContent";
			/// <summary>Member name AfcampaignCollectionViaAfAdvertisingCommission</summary>
			public static readonly string AfcampaignCollectionViaAfAdvertisingCommission = "AfcampaignCollectionViaAfAdvertisingCommission";
			/// <summary>Member name AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial</summary>
			public static readonly string AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial = "AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial";
			/// <summary>Member name CouponsCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string CouponsCollectionViaMarketingPrintOrderItem = "CouponsCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name LookupCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string LookupCollectionViaMarketingPrintOrderItem = "LookupCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name MarketingPrintOrderCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string MarketingPrintOrderCollectionViaMarketingPrintOrderItem = "MarketingPrintOrderCollectionViaMarketingPrintOrderItem";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AfmarketingMaterialEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AfmarketingMaterialEntity():base("AfmarketingMaterialEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AfmarketingMaterialEntity(IEntityFields2 fields):base("AfmarketingMaterialEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AfmarketingMaterialEntity</param>
		public AfmarketingMaterialEntity(IValidator validator):base("AfmarketingMaterialEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="marketingMaterialId">PK value for AfmarketingMaterial which data should be fetched into this AfmarketingMaterial object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfmarketingMaterialEntity(System.Int64 marketingMaterialId):base("AfmarketingMaterialEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MarketingMaterialId = marketingMaterialId;
		}

		/// <summary> CTor</summary>
		/// <param name="marketingMaterialId">PK value for AfmarketingMaterial which data should be fetched into this AfmarketingMaterial object</param>
		/// <param name="validator">The custom validator object for this AfmarketingMaterialEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfmarketingMaterialEntity(System.Int64 marketingMaterialId, IValidator validator):base("AfmarketingMaterialEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MarketingMaterialId = marketingMaterialId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AfmarketingMaterialEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_afAdvertisingCommission = (EntityCollection<AfAdvertisingCommissionEntity>)info.GetValue("_afAdvertisingCommission", typeof(EntityCollection<AfAdvertisingCommissionEntity>));
				_afaffiliateCampaignMarketingMaterial = (EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>)info.GetValue("_afaffiliateCampaignMarketingMaterial", typeof(EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>));
				_clickLog = (EntityCollection<ClickLogEntity>)info.GetValue("_clickLog", typeof(EntityCollection<ClickLogEntity>));
				_customCampaignContent = (EntityCollection<CustomCampaignContentEntity>)info.GetValue("_customCampaignContent", typeof(EntityCollection<CustomCampaignContentEntity>));
				_marketingPrintOrderItem = (EntityCollection<MarketingPrintOrderItemEntity>)info.GetValue("_marketingPrintOrderItem", typeof(EntityCollection<MarketingPrintOrderItemEntity>));
				_widget = (EntityCollection<WidgetEntity>)info.GetValue("_widget", typeof(EntityCollection<WidgetEntity>));
				_afcampaignCollectionViaClickLog = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaignCollectionViaClickLog", typeof(EntityCollection<AfcampaignEntity>));
				_afcampaignCollectionViaCustomCampaignContent = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaignCollectionViaCustomCampaignContent", typeof(EntityCollection<AfcampaignEntity>));
				_afcampaignCollectionViaAfAdvertisingCommission = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaignCollectionViaAfAdvertisingCommission", typeof(EntityCollection<AfcampaignEntity>));
				_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial", typeof(EntityCollection<AfcampaignEntity>));
				_couponsCollectionViaMarketingPrintOrderItem = (EntityCollection<CouponsEntity>)info.GetValue("_couponsCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<CouponsEntity>));
				_lookupCollectionViaMarketingPrintOrderItem = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<LookupEntity>));
				_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingOrderShippingInfoEntity>)info.GetValue("_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<MarketingOrderShippingInfoEntity>));
				_marketingPrintOrderCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingPrintOrderEntity>)info.GetValue("_marketingPrintOrderCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<MarketingPrintOrderEntity>));
				_afmarketingMaterialType = (AfmarketingMaterialTypeEntity)info.GetValue("_afmarketingMaterialType", typeof(AfmarketingMaterialTypeEntity));
				if(_afmarketingMaterialType!=null)
				{
					_afmarketingMaterialType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((AfmarketingMaterialFieldIndex)fieldIndex)
			{
				case AfmarketingMaterialFieldIndex.MarketingMaterialTypeId:
					DesetupSyncAfmarketingMaterialType(true, false);
					break;
				case AfmarketingMaterialFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
				
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
		{
			switch(propertyName)
			{
				case "AfmarketingMaterialType":
					this.AfmarketingMaterialType = (AfmarketingMaterialTypeEntity)entity;
					break;
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "AfAdvertisingCommission":
					this.AfAdvertisingCommission.Add((AfAdvertisingCommissionEntity)entity);
					break;
				case "AfaffiliateCampaignMarketingMaterial":
					this.AfaffiliateCampaignMarketingMaterial.Add((AfaffiliateCampaignMarketingMaterialEntity)entity);
					break;
				case "ClickLog":
					this.ClickLog.Add((ClickLogEntity)entity);
					break;
				case "CustomCampaignContent":
					this.CustomCampaignContent.Add((CustomCampaignContentEntity)entity);
					break;
				case "MarketingPrintOrderItem":
					this.MarketingPrintOrderItem.Add((MarketingPrintOrderItemEntity)entity);
					break;
				case "Widget":
					this.Widget.Add((WidgetEntity)entity);
					break;
				case "AfcampaignCollectionViaClickLog":
					this.AfcampaignCollectionViaClickLog.IsReadOnly = false;
					this.AfcampaignCollectionViaClickLog.Add((AfcampaignEntity)entity);
					this.AfcampaignCollectionViaClickLog.IsReadOnly = true;
					break;
				case "AfcampaignCollectionViaCustomCampaignContent":
					this.AfcampaignCollectionViaCustomCampaignContent.IsReadOnly = false;
					this.AfcampaignCollectionViaCustomCampaignContent.Add((AfcampaignEntity)entity);
					this.AfcampaignCollectionViaCustomCampaignContent.IsReadOnly = true;
					break;
				case "AfcampaignCollectionViaAfAdvertisingCommission":
					this.AfcampaignCollectionViaAfAdvertisingCommission.IsReadOnly = false;
					this.AfcampaignCollectionViaAfAdvertisingCommission.Add((AfcampaignEntity)entity);
					this.AfcampaignCollectionViaAfAdvertisingCommission.IsReadOnly = true;
					break;
				case "AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial":
					this.AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial.IsReadOnly = false;
					this.AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial.Add((AfcampaignEntity)entity);
					this.AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial.IsReadOnly = true;
					break;
				case "CouponsCollectionViaMarketingPrintOrderItem":
					this.CouponsCollectionViaMarketingPrintOrderItem.IsReadOnly = false;
					this.CouponsCollectionViaMarketingPrintOrderItem.Add((CouponsEntity)entity);
					this.CouponsCollectionViaMarketingPrintOrderItem.IsReadOnly = true;
					break;
				case "LookupCollectionViaMarketingPrintOrderItem":
					this.LookupCollectionViaMarketingPrintOrderItem.IsReadOnly = false;
					this.LookupCollectionViaMarketingPrintOrderItem.Add((LookupEntity)entity);
					this.LookupCollectionViaMarketingPrintOrderItem.IsReadOnly = true;
					break;
				case "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem":
					this.MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.IsReadOnly = false;
					this.MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.Add((MarketingOrderShippingInfoEntity)entity);
					this.MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.IsReadOnly = true;
					break;
				case "MarketingPrintOrderCollectionViaMarketingPrintOrderItem":
					this.MarketingPrintOrderCollectionViaMarketingPrintOrderItem.IsReadOnly = false;
					this.MarketingPrintOrderCollectionViaMarketingPrintOrderItem.Add((MarketingPrintOrderEntity)entity);
					this.MarketingPrintOrderCollectionViaMarketingPrintOrderItem.IsReadOnly = true;
					break;

				default:
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return AfmarketingMaterialEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AfmarketingMaterialType":
					toReturn.Add(AfmarketingMaterialEntity.Relations.AfmarketingMaterialTypeEntityUsingMarketingMaterialTypeId);
					break;
				case "Events":
					toReturn.Add(AfmarketingMaterialEntity.Relations.EventsEntityUsingEventId);
					break;
				case "AfAdvertisingCommission":
					toReturn.Add(AfmarketingMaterialEntity.Relations.AfAdvertisingCommissionEntityUsingMarketingMaterialId);
					break;
				case "AfaffiliateCampaignMarketingMaterial":
					toReturn.Add(AfmarketingMaterialEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingMarketingMaterialId);
					break;
				case "ClickLog":
					toReturn.Add(AfmarketingMaterialEntity.Relations.ClickLogEntityUsingMarketingMaterialId);
					break;
				case "CustomCampaignContent":
					toReturn.Add(AfmarketingMaterialEntity.Relations.CustomCampaignContentEntityUsingMarketingMaterialId);
					break;
				case "MarketingPrintOrderItem":
					toReturn.Add(AfmarketingMaterialEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingMaterialId);
					break;
				case "Widget":
					toReturn.Add(AfmarketingMaterialEntity.Relations.WidgetEntityUsingMarketingMaterialId);
					break;
				case "AfcampaignCollectionViaClickLog":
					toReturn.Add(AfmarketingMaterialEntity.Relations.ClickLogEntityUsingMarketingMaterialId, "AfmarketingMaterialEntity__", "ClickLog_", JoinHint.None);
					toReturn.Add(ClickLogEntity.Relations.AfcampaignEntityUsingCampaignId, "ClickLog_", string.Empty, JoinHint.None);
					break;
				case "AfcampaignCollectionViaCustomCampaignContent":
					toReturn.Add(AfmarketingMaterialEntity.Relations.CustomCampaignContentEntityUsingMarketingMaterialId, "AfmarketingMaterialEntity__", "CustomCampaignContent_", JoinHint.None);
					toReturn.Add(CustomCampaignContentEntity.Relations.AfcampaignEntityUsingCampaignId, "CustomCampaignContent_", string.Empty, JoinHint.None);
					break;
				case "AfcampaignCollectionViaAfAdvertisingCommission":
					toReturn.Add(AfmarketingMaterialEntity.Relations.AfAdvertisingCommissionEntityUsingMarketingMaterialId, "AfmarketingMaterialEntity__", "AfAdvertisingCommission_", JoinHint.None);
					toReturn.Add(AfAdvertisingCommissionEntity.Relations.AfcampaignEntityUsingCampaignId, "AfAdvertisingCommission_", string.Empty, JoinHint.None);
					break;
				case "AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial":
					toReturn.Add(AfmarketingMaterialEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingMarketingMaterialId, "AfmarketingMaterialEntity__", "AfaffiliateCampaignMarketingMaterial_", JoinHint.None);
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.AfcampaignEntityUsingCampaignId, "AfaffiliateCampaignMarketingMaterial_", string.Empty, JoinHint.None);
					break;
				case "CouponsCollectionViaMarketingPrintOrderItem":
					toReturn.Add(AfmarketingMaterialEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingMaterialId, "AfmarketingMaterialEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.CouponsEntityUsingSourceCodeId, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaMarketingPrintOrderItem":
					toReturn.Add(AfmarketingMaterialEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingMaterialId, "AfmarketingMaterialEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.LookupEntityUsingStatus, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem":
					toReturn.Add(AfmarketingMaterialEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingMaterialId, "AfmarketingMaterialEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.MarketingOrderShippingInfoEntityUsingMarketingOrderShippingInfoId, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "MarketingPrintOrderCollectionViaMarketingPrintOrderItem":
					toReturn.Add(AfmarketingMaterialEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingMaterialId, "AfmarketingMaterialEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.MarketingPrintOrderEntityUsingMarketingPrintOrderId, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;

				default:

					break;				
			}
			return toReturn;
		}
#if !CF
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it
		/// will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckOneWayRelations(string propertyName)
		{
			// use template trick to calculate the # of single-sided / oneway relations
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));



				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "AfmarketingMaterialType":
					SetupSyncAfmarketingMaterialType(relatedEntity);
					break;
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "AfAdvertisingCommission":
					this.AfAdvertisingCommission.Add((AfAdvertisingCommissionEntity)relatedEntity);
					break;
				case "AfaffiliateCampaignMarketingMaterial":
					this.AfaffiliateCampaignMarketingMaterial.Add((AfaffiliateCampaignMarketingMaterialEntity)relatedEntity);
					break;
				case "ClickLog":
					this.ClickLog.Add((ClickLogEntity)relatedEntity);
					break;
				case "CustomCampaignContent":
					this.CustomCampaignContent.Add((CustomCampaignContentEntity)relatedEntity);
					break;
				case "MarketingPrintOrderItem":
					this.MarketingPrintOrderItem.Add((MarketingPrintOrderItemEntity)relatedEntity);
					break;
				case "Widget":
					this.Widget.Add((WidgetEntity)relatedEntity);
					break;

				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "AfmarketingMaterialType":
					DesetupSyncAfmarketingMaterialType(false, true);
					break;
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "AfAdvertisingCommission":
					base.PerformRelatedEntityRemoval(this.AfAdvertisingCommission, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AfaffiliateCampaignMarketingMaterial":
					base.PerformRelatedEntityRemoval(this.AfaffiliateCampaignMarketingMaterial, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ClickLog":
					base.PerformRelatedEntityRemoval(this.ClickLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomCampaignContent":
					base.PerformRelatedEntityRemoval(this.CustomCampaignContent, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MarketingPrintOrderItem":
					base.PerformRelatedEntityRemoval(this.MarketingPrintOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Widget":
					base.PerformRelatedEntityRemoval(this.Widget, relatedEntity, signalRelatedEntityManyToOne);
					break;

				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_afmarketingMaterialType!=null)
			{
				toReturn.Add(_afmarketingMaterialType);
			}
			if(_events!=null)
			{
				toReturn.Add(_events);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AfAdvertisingCommission);
			toReturn.Add(this.AfaffiliateCampaignMarketingMaterial);
			toReturn.Add(this.ClickLog);
			toReturn.Add(this.CustomCampaignContent);
			toReturn.Add(this.MarketingPrintOrderItem);
			toReturn.Add(this.Widget);

			return toReturn;
		}
		


		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_afAdvertisingCommission", ((_afAdvertisingCommission!=null) && (_afAdvertisingCommission.Count>0) && !this.MarkedForDeletion)?_afAdvertisingCommission:null);
				info.AddValue("_afaffiliateCampaignMarketingMaterial", ((_afaffiliateCampaignMarketingMaterial!=null) && (_afaffiliateCampaignMarketingMaterial.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaignMarketingMaterial:null);
				info.AddValue("_clickLog", ((_clickLog!=null) && (_clickLog.Count>0) && !this.MarkedForDeletion)?_clickLog:null);
				info.AddValue("_customCampaignContent", ((_customCampaignContent!=null) && (_customCampaignContent.Count>0) && !this.MarkedForDeletion)?_customCampaignContent:null);
				info.AddValue("_marketingPrintOrderItem", ((_marketingPrintOrderItem!=null) && (_marketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrderItem:null);
				info.AddValue("_widget", ((_widget!=null) && (_widget.Count>0) && !this.MarkedForDeletion)?_widget:null);
				info.AddValue("_afcampaignCollectionViaClickLog", ((_afcampaignCollectionViaClickLog!=null) && (_afcampaignCollectionViaClickLog.Count>0) && !this.MarkedForDeletion)?_afcampaignCollectionViaClickLog:null);
				info.AddValue("_afcampaignCollectionViaCustomCampaignContent", ((_afcampaignCollectionViaCustomCampaignContent!=null) && (_afcampaignCollectionViaCustomCampaignContent.Count>0) && !this.MarkedForDeletion)?_afcampaignCollectionViaCustomCampaignContent:null);
				info.AddValue("_afcampaignCollectionViaAfAdvertisingCommission", ((_afcampaignCollectionViaAfAdvertisingCommission!=null) && (_afcampaignCollectionViaAfAdvertisingCommission.Count>0) && !this.MarkedForDeletion)?_afcampaignCollectionViaAfAdvertisingCommission:null);
				info.AddValue("_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial", ((_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial!=null) && (_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial.Count>0) && !this.MarkedForDeletion)?_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial:null);
				info.AddValue("_couponsCollectionViaMarketingPrintOrderItem", ((_couponsCollectionViaMarketingPrintOrderItem!=null) && (_couponsCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_couponsCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_lookupCollectionViaMarketingPrintOrderItem", ((_lookupCollectionViaMarketingPrintOrderItem!=null) && (_lookupCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", ((_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem!=null) && (_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_marketingPrintOrderCollectionViaMarketingPrintOrderItem", ((_marketingPrintOrderCollectionViaMarketingPrintOrderItem!=null) && (_marketingPrintOrderCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrderCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_afmarketingMaterialType", (!this.MarkedForDeletion?_afmarketingMaterialType:null));
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AfmarketingMaterialFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AfmarketingMaterialFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AfmarketingMaterialRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfAdvertisingCommission' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfAdvertisingCommission()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfAdvertisingCommissionFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaignMarketingMaterial' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignMarketingMaterial()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignMarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClickLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClickLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClickLogFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomCampaignContent' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomCampaignContent()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomCampaignContentFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderItemFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Widget' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoWidget()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(WidgetFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCollectionViaClickLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfcampaignCollectionViaClickLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId, "AfmarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCollectionViaCustomCampaignContent()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfcampaignCollectionViaCustomCampaignContent"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId, "AfmarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCollectionViaAfAdvertisingCommission()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfcampaignCollectionViaAfAdvertisingCommission"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId, "AfmarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId, "AfmarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponsCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CouponsCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId, "AfmarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId, "AfmarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingOrderShippingInfo' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId, "AfmarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrder' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrderCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MarketingPrintOrderCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId, "AfmarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AfmarketingMaterialType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfmarketingMaterialType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialTypeFields.MarketingMaterialTypeId, null, ComparisonOperator.Equal, this.MarketingMaterialTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Events' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.EventId, null, ComparisonOperator.Equal, this.EventId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AfmarketingMaterialEntity);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._afAdvertisingCommission);
			collectionsQueue.Enqueue(this._afaffiliateCampaignMarketingMaterial);
			collectionsQueue.Enqueue(this._clickLog);
			collectionsQueue.Enqueue(this._customCampaignContent);
			collectionsQueue.Enqueue(this._marketingPrintOrderItem);
			collectionsQueue.Enqueue(this._widget);
			collectionsQueue.Enqueue(this._afcampaignCollectionViaClickLog);
			collectionsQueue.Enqueue(this._afcampaignCollectionViaCustomCampaignContent);
			collectionsQueue.Enqueue(this._afcampaignCollectionViaAfAdvertisingCommission);
			collectionsQueue.Enqueue(this._afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial);
			collectionsQueue.Enqueue(this._couponsCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._lookupCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._marketingPrintOrderCollectionViaMarketingPrintOrderItem);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._afAdvertisingCommission = (EntityCollection<AfAdvertisingCommissionEntity>) collectionsQueue.Dequeue();
			this._afaffiliateCampaignMarketingMaterial = (EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>) collectionsQueue.Dequeue();
			this._clickLog = (EntityCollection<ClickLogEntity>) collectionsQueue.Dequeue();
			this._customCampaignContent = (EntityCollection<CustomCampaignContentEntity>) collectionsQueue.Dequeue();
			this._marketingPrintOrderItem = (EntityCollection<MarketingPrintOrderItemEntity>) collectionsQueue.Dequeue();
			this._widget = (EntityCollection<WidgetEntity>) collectionsQueue.Dequeue();
			this._afcampaignCollectionViaClickLog = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
			this._afcampaignCollectionViaCustomCampaignContent = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
			this._afcampaignCollectionViaAfAdvertisingCommission = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
			this._afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
			this._couponsCollectionViaMarketingPrintOrderItem = (EntityCollection<CouponsEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaMarketingPrintOrderItem = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingOrderShippingInfoEntity>) collectionsQueue.Dequeue();
			this._marketingPrintOrderCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingPrintOrderEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._afAdvertisingCommission != null)
			{
				return true;
			}
			if (this._afaffiliateCampaignMarketingMaterial != null)
			{
				return true;
			}
			if (this._clickLog != null)
			{
				return true;
			}
			if (this._customCampaignContent != null)
			{
				return true;
			}
			if (this._marketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._widget != null)
			{
				return true;
			}
			if (this._afcampaignCollectionViaClickLog != null)
			{
				return true;
			}
			if (this._afcampaignCollectionViaCustomCampaignContent != null)
			{
				return true;
			}
			if (this._afcampaignCollectionViaAfAdvertisingCommission != null)
			{
				return true;
			}
			if (this._afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial != null)
			{
				return true;
			}
			if (this._couponsCollectionViaMarketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._lookupCollectionViaMarketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._marketingPrintOrderCollectionViaMarketingPrintOrderItem != null)
			{
				return true;
			}
			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfAdvertisingCommissionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfAdvertisingCommissionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomCampaignContentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomCampaignContentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<WidgetEntity>(EntityFactoryCache2.GetEntityFactory(typeof(WidgetEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingOrderShippingInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingOrderShippingInfoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AfmarketingMaterialType", _afmarketingMaterialType);
			toReturn.Add("Events", _events);
			toReturn.Add("AfAdvertisingCommission", _afAdvertisingCommission);
			toReturn.Add("AfaffiliateCampaignMarketingMaterial", _afaffiliateCampaignMarketingMaterial);
			toReturn.Add("ClickLog", _clickLog);
			toReturn.Add("CustomCampaignContent", _customCampaignContent);
			toReturn.Add("MarketingPrintOrderItem", _marketingPrintOrderItem);
			toReturn.Add("Widget", _widget);
			toReturn.Add("AfcampaignCollectionViaClickLog", _afcampaignCollectionViaClickLog);
			toReturn.Add("AfcampaignCollectionViaCustomCampaignContent", _afcampaignCollectionViaCustomCampaignContent);
			toReturn.Add("AfcampaignCollectionViaAfAdvertisingCommission", _afcampaignCollectionViaAfAdvertisingCommission);
			toReturn.Add("AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial", _afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial);
			toReturn.Add("CouponsCollectionViaMarketingPrintOrderItem", _couponsCollectionViaMarketingPrintOrderItem);
			toReturn.Add("LookupCollectionViaMarketingPrintOrderItem", _lookupCollectionViaMarketingPrintOrderItem);
			toReturn.Add("MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", _marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem);
			toReturn.Add("MarketingPrintOrderCollectionViaMarketingPrintOrderItem", _marketingPrintOrderCollectionViaMarketingPrintOrderItem);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_afAdvertisingCommission!=null)
			{
				_afAdvertisingCommission.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaignMarketingMaterial!=null)
			{
				_afaffiliateCampaignMarketingMaterial.ActiveContext = base.ActiveContext;
			}
			if(_clickLog!=null)
			{
				_clickLog.ActiveContext = base.ActiveContext;
			}
			if(_customCampaignContent!=null)
			{
				_customCampaignContent.ActiveContext = base.ActiveContext;
			}
			if(_marketingPrintOrderItem!=null)
			{
				_marketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_widget!=null)
			{
				_widget.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignCollectionViaClickLog!=null)
			{
				_afcampaignCollectionViaClickLog.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignCollectionViaCustomCampaignContent!=null)
			{
				_afcampaignCollectionViaCustomCampaignContent.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignCollectionViaAfAdvertisingCommission!=null)
			{
				_afcampaignCollectionViaAfAdvertisingCommission.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial!=null)
			{
				_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial.ActiveContext = base.ActiveContext;
			}
			if(_couponsCollectionViaMarketingPrintOrderItem!=null)
			{
				_couponsCollectionViaMarketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaMarketingPrintOrderItem!=null)
			{
				_lookupCollectionViaMarketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem!=null)
			{
				_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_marketingPrintOrderCollectionViaMarketingPrintOrderItem!=null)
			{
				_marketingPrintOrderCollectionViaMarketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterialType!=null)
			{
				_afmarketingMaterialType.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_afAdvertisingCommission = null;
			_afaffiliateCampaignMarketingMaterial = null;
			_clickLog = null;
			_customCampaignContent = null;
			_marketingPrintOrderItem = null;
			_widget = null;
			_afcampaignCollectionViaClickLog = null;
			_afcampaignCollectionViaCustomCampaignContent = null;
			_afcampaignCollectionViaAfAdvertisingCommission = null;
			_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial = null;
			_couponsCollectionViaMarketingPrintOrderItem = null;
			_lookupCollectionViaMarketingPrintOrderItem = null;
			_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = null;
			_marketingPrintOrderCollectionViaMarketingPrintOrderItem = null;
			_afmarketingMaterialType = null;
			_events = null;

			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingMaterialId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Title", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsEventSpecific", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingMaterialTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ImagePath", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Text", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Htmltext", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CommonSizeName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Height", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Width", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsInternal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HeadingText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LeadingInUrl", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DisplayUrl", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsInbound", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Isdefault", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingOfferId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ThumbnailImagePath", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afmarketingMaterialType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfmarketingMaterialType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afmarketingMaterialType, new PropertyChangedEventHandler( OnAfmarketingMaterialTypePropertyChanged ), "AfmarketingMaterialType", AfmarketingMaterialEntity.Relations.AfmarketingMaterialTypeEntityUsingMarketingMaterialTypeId, true, signalRelatedEntity, "AfmarketingMaterial", resetFKFields, new int[] { (int)AfmarketingMaterialFieldIndex.MarketingMaterialTypeId } );		
			_afmarketingMaterialType = null;
		}

		/// <summary> setups the sync logic for member _afmarketingMaterialType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfmarketingMaterialType(IEntity2 relatedEntity)
		{
			if(_afmarketingMaterialType!=relatedEntity)
			{
				DesetupSyncAfmarketingMaterialType(true, true);
				_afmarketingMaterialType = (AfmarketingMaterialTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afmarketingMaterialType, new PropertyChangedEventHandler( OnAfmarketingMaterialTypePropertyChanged ), "AfmarketingMaterialType", AfmarketingMaterialEntity.Relations.AfmarketingMaterialTypeEntityUsingMarketingMaterialTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfmarketingMaterialTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", AfmarketingMaterialEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "AfmarketingMaterial", resetFKFields, new int[] { (int)AfmarketingMaterialFieldIndex.EventId } );		
			_events = null;
		}

		/// <summary> setups the sync logic for member _events</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEvents(IEntity2 relatedEntity)
		{
			if(_events!=relatedEntity)
			{
				DesetupSyncEvents(true, true);
				_events = (EventsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", AfmarketingMaterialEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AfmarketingMaterialEntity</param>
		/// <param name="fields">Fields of this entity</param>
		protected virtual void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			base.Fields = fields;
			base.IsNew=true;
			base.Validator = validator;
			InitClassMembers();

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static AfmarketingMaterialRelations Relations
		{
			get	{ return new AfmarketingMaterialRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfAdvertisingCommission' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfAdvertisingCommission
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfAdvertisingCommissionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfAdvertisingCommissionEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfAdvertisingCommission")[0], (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.AfAdvertisingCommissionEntity, 0, null, null, null, null, "AfAdvertisingCommission", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaignMarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignMarketingMaterial
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfaffiliateCampaignMarketingMaterial")[0], (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, 0, null, null, null, null, "AfaffiliateCampaignMarketingMaterial", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClickLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClickLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("ClickLog")[0], (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.ClickLogEntity, 0, null, null, null, null, "ClickLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomCampaignContent' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomCampaignContent
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomCampaignContentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomCampaignContentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomCampaignContent")[0], (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.CustomCampaignContentEntity, 0, null, null, null, null, "CustomCampaignContent", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingPrintOrderItem")[0], (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, 0, null, null, null, null, "MarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Widget' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathWidget
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<WidgetEntity>(EntityFactoryCache2.GetEntityFactory(typeof(WidgetEntityFactory))),
					(IEntityRelation)GetRelationsForField("Widget")[0], (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.WidgetEntity, 0, null, null, null, null, "Widget", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCollectionViaClickLog
		{
			get
			{
				IEntityRelation intermediateRelation = AfmarketingMaterialEntity.Relations.ClickLogEntityUsingMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "ClickLog_");
				return new PrefetchPathElement2(new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, GetRelationsForField("AfcampaignCollectionViaClickLog"), null, "AfcampaignCollectionViaClickLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCollectionViaCustomCampaignContent
		{
			get
			{
				IEntityRelation intermediateRelation = AfmarketingMaterialEntity.Relations.CustomCampaignContentEntityUsingMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "CustomCampaignContent_");
				return new PrefetchPathElement2(new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, GetRelationsForField("AfcampaignCollectionViaCustomCampaignContent"), null, "AfcampaignCollectionViaCustomCampaignContent", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCollectionViaAfAdvertisingCommission
		{
			get
			{
				IEntityRelation intermediateRelation = AfmarketingMaterialEntity.Relations.AfAdvertisingCommissionEntityUsingMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "AfAdvertisingCommission_");
				return new PrefetchPathElement2(new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, GetRelationsForField("AfcampaignCollectionViaAfAdvertisingCommission"), null, "AfcampaignCollectionViaAfAdvertisingCommission", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial
		{
			get
			{
				IEntityRelation intermediateRelation = AfmarketingMaterialEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "AfaffiliateCampaignMarketingMaterial_");
				return new PrefetchPathElement2(new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, GetRelationsForField("AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial"), null, "AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponsCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = AfmarketingMaterialEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.CouponsEntity, 0, null, null, GetRelationsForField("CouponsCollectionViaMarketingPrintOrderItem"), null, "CouponsCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = AfmarketingMaterialEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaMarketingPrintOrderItem"), null, "LookupCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingOrderShippingInfo' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = AfmarketingMaterialEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<MarketingOrderShippingInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingOrderShippingInfoEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.MarketingOrderShippingInfoEntity, 0, null, null, GetRelationsForField("MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem"), null, "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrder' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrderCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = AfmarketingMaterialEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, 0, null, null, GetRelationsForField("MarketingPrintOrderCollectionViaMarketingPrintOrderItem"), null, "MarketingPrintOrderCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfmarketingMaterialType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfmarketingMaterialType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfmarketingMaterialType")[0], (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialTypeEntity, 0, null, null, null, null, "AfmarketingMaterialType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AfmarketingMaterialEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return AfmarketingMaterialEntity.FieldsCustomProperties;}
		}

		/// <summary> The MarketingMaterialId property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."MarketingMaterialId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MarketingMaterialId
		{
			get { return (System.Int64)GetValue((int)AfmarketingMaterialFieldIndex.MarketingMaterialId, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.MarketingMaterialId, value); }
		}

		/// <summary> The Title property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."Title"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Title
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.Title, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.Title, value); }
		}

		/// <summary> The Description property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.Description, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.Description, value); }
		}

		/// <summary> The IsEventSpecific property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."IsEventSpecific"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsEventSpecific
		{
			get { return (System.Boolean)GetValue((int)AfmarketingMaterialFieldIndex.IsEventSpecific, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.IsEventSpecific, value); }
		}

		/// <summary> The MarketingMaterialTypeId property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."MarketingMaterialTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MarketingMaterialTypeId
		{
			get { return (System.Int64)GetValue((int)AfmarketingMaterialFieldIndex.MarketingMaterialTypeId, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.MarketingMaterialTypeId, value); }
		}

		/// <summary> The ImagePath property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."ImagePath"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ImagePath
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.ImagePath, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.ImagePath, value); }
		}

		/// <summary> The Text property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."Text"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Text
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.Text, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.Text, value); }
		}

		/// <summary> The Htmltext property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."HTMLText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Htmltext
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.Htmltext, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.Htmltext, value); }
		}

		/// <summary> The CommonSizeName property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."CommonSizeName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CommonSizeName
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.CommonSizeName, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.CommonSizeName, value); }
		}

		/// <summary> The Height property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."Height"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Height
		{
			get { return (Nullable<System.Int32>)GetValue((int)AfmarketingMaterialFieldIndex.Height, false); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.Height, value); }
		}

		/// <summary> The Width property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."Width"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Width
		{
			get { return (Nullable<System.Int32>)GetValue((int)AfmarketingMaterialFieldIndex.Width, false); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.Width, value); }
		}

		/// <summary> The CreatedDate property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfmarketingMaterialFieldIndex.CreatedDate, false); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.CreatedDate, value); }
		}

		/// <summary> The LastModifiedDate property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."LastModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastModifiedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfmarketingMaterialFieldIndex.LastModifiedDate, false); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.LastModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AfmarketingMaterialFieldIndex.IsActive, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.IsActive, value); }
		}

		/// <summary> The IsInternal property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."IsInternal"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsInternal
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AfmarketingMaterialFieldIndex.IsInternal, false); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.IsInternal, value); }
		}

		/// <summary> The EventId property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EventId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AfmarketingMaterialFieldIndex.EventId, false); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.EventId, value); }
		}

		/// <summary> The HeadingText property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."HeadingText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String HeadingText
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.HeadingText, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.HeadingText, value); }
		}

		/// <summary> The LeadingInUrl property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."LeadingInURL"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LeadingInUrl
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.LeadingInUrl, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.LeadingInUrl, value); }
		}

		/// <summary> The DisplayUrl property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."DisplayURL"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DisplayUrl
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.DisplayUrl, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.DisplayUrl, value); }
		}

		/// <summary> The IsInbound property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."IsInbound"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsInbound
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AfmarketingMaterialFieldIndex.IsInbound, false); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.IsInbound, value); }
		}

		/// <summary> The Isdefault property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."Isdefault"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> Isdefault
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AfmarketingMaterialFieldIndex.Isdefault, false); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.Isdefault, value); }
		}

		/// <summary> The MarketingOfferId property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."MarketingOfferID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MarketingOfferId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AfmarketingMaterialFieldIndex.MarketingOfferId, false); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.MarketingOfferId, value); }
		}

		/// <summary> The ThumbnailImagePath property of the Entity AfmarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFMarketingMaterial"."ThumbnailImagePath"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 3000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ThumbnailImagePath
		{
			get { return (System.String)GetValue((int)AfmarketingMaterialFieldIndex.ThumbnailImagePath, true); }
			set	{ SetValue((int)AfmarketingMaterialFieldIndex.ThumbnailImagePath, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfAdvertisingCommissionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfAdvertisingCommissionEntity))]
		public virtual EntityCollection<AfAdvertisingCommissionEntity> AfAdvertisingCommission
		{
			get
			{
				if(_afAdvertisingCommission==null)
				{
					_afAdvertisingCommission = new EntityCollection<AfAdvertisingCommissionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfAdvertisingCommissionEntityFactory)));
					_afAdvertisingCommission.SetContainingEntityInfo(this, "AfmarketingMaterial");
				}
				return _afAdvertisingCommission;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfaffiliateCampaignMarketingMaterialEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfaffiliateCampaignMarketingMaterialEntity))]
		public virtual EntityCollection<AfaffiliateCampaignMarketingMaterialEntity> AfaffiliateCampaignMarketingMaterial
		{
			get
			{
				if(_afaffiliateCampaignMarketingMaterial==null)
				{
					_afaffiliateCampaignMarketingMaterial = new EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory)));
					_afaffiliateCampaignMarketingMaterial.SetContainingEntityInfo(this, "AfmarketingMaterial");
				}
				return _afaffiliateCampaignMarketingMaterial;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClickLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClickLogEntity))]
		public virtual EntityCollection<ClickLogEntity> ClickLog
		{
			get
			{
				if(_clickLog==null)
				{
					_clickLog = new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory)));
					_clickLog.SetContainingEntityInfo(this, "AfmarketingMaterial");
				}
				return _clickLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomCampaignContentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomCampaignContentEntity))]
		public virtual EntityCollection<CustomCampaignContentEntity> CustomCampaignContent
		{
			get
			{
				if(_customCampaignContent==null)
				{
					_customCampaignContent = new EntityCollection<CustomCampaignContentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomCampaignContentEntityFactory)));
					_customCampaignContent.SetContainingEntityInfo(this, "AfmarketingMaterial");
				}
				return _customCampaignContent;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingPrintOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingPrintOrderItemEntity))]
		public virtual EntityCollection<MarketingPrintOrderItemEntity> MarketingPrintOrderItem
		{
			get
			{
				if(_marketingPrintOrderItem==null)
				{
					_marketingPrintOrderItem = new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory)));
					_marketingPrintOrderItem.SetContainingEntityInfo(this, "AfmarketingMaterial");
				}
				return _marketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'WidgetEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(WidgetEntity))]
		public virtual EntityCollection<WidgetEntity> Widget
		{
			get
			{
				if(_widget==null)
				{
					_widget = new EntityCollection<WidgetEntity>(EntityFactoryCache2.GetEntityFactory(typeof(WidgetEntityFactory)));
					_widget.SetContainingEntityInfo(this, "AfmarketingMaterial");
				}
				return _widget;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> AfcampaignCollectionViaClickLog
		{
			get
			{
				if(_afcampaignCollectionViaClickLog==null)
				{
					_afcampaignCollectionViaClickLog = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaignCollectionViaClickLog.IsReadOnly=true;
				}
				return _afcampaignCollectionViaClickLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> AfcampaignCollectionViaCustomCampaignContent
		{
			get
			{
				if(_afcampaignCollectionViaCustomCampaignContent==null)
				{
					_afcampaignCollectionViaCustomCampaignContent = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaignCollectionViaCustomCampaignContent.IsReadOnly=true;
				}
				return _afcampaignCollectionViaCustomCampaignContent;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> AfcampaignCollectionViaAfAdvertisingCommission
		{
			get
			{
				if(_afcampaignCollectionViaAfAdvertisingCommission==null)
				{
					_afcampaignCollectionViaAfAdvertisingCommission = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaignCollectionViaAfAdvertisingCommission.IsReadOnly=true;
				}
				return _afcampaignCollectionViaAfAdvertisingCommission;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> AfcampaignCollectionViaAfaffiliateCampaignMarketingMaterial
		{
			get
			{
				if(_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial==null)
				{
					_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial.IsReadOnly=true;
				}
				return _afcampaignCollectionViaAfaffiliateCampaignMarketingMaterial;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouponsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouponsEntity))]
		public virtual EntityCollection<CouponsEntity> CouponsCollectionViaMarketingPrintOrderItem
		{
			get
			{
				if(_couponsCollectionViaMarketingPrintOrderItem==null)
				{
					_couponsCollectionViaMarketingPrintOrderItem = new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory)));
					_couponsCollectionViaMarketingPrintOrderItem.IsReadOnly=true;
				}
				return _couponsCollectionViaMarketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaMarketingPrintOrderItem
		{
			get
			{
				if(_lookupCollectionViaMarketingPrintOrderItem==null)
				{
					_lookupCollectionViaMarketingPrintOrderItem = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaMarketingPrintOrderItem.IsReadOnly=true;
				}
				return _lookupCollectionViaMarketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingOrderShippingInfoEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingOrderShippingInfoEntity))]
		public virtual EntityCollection<MarketingOrderShippingInfoEntity> MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem
		{
			get
			{
				if(_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem==null)
				{
					_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = new EntityCollection<MarketingOrderShippingInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingOrderShippingInfoEntityFactory)));
					_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.IsReadOnly=true;
				}
				return _marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingPrintOrderEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingPrintOrderEntity))]
		public virtual EntityCollection<MarketingPrintOrderEntity> MarketingPrintOrderCollectionViaMarketingPrintOrderItem
		{
			get
			{
				if(_marketingPrintOrderCollectionViaMarketingPrintOrderItem==null)
				{
					_marketingPrintOrderCollectionViaMarketingPrintOrderItem = new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory)));
					_marketingPrintOrderCollectionViaMarketingPrintOrderItem.IsReadOnly=true;
				}
				return _marketingPrintOrderCollectionViaMarketingPrintOrderItem;
			}
		}

		/// <summary> Gets / sets related entity of type 'AfmarketingMaterialTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfmarketingMaterialTypeEntity AfmarketingMaterialType
		{
			get
			{
				return _afmarketingMaterialType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfmarketingMaterialType(value);
				}
				else
				{
					if(value==null)
					{
						if(_afmarketingMaterialType != null)
						{
							_afmarketingMaterialType.UnsetRelatedEntity(this, "AfmarketingMaterial");
						}
					}
					else
					{
						if(_afmarketingMaterialType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AfmarketingMaterial");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventsEntity Events
		{
			get
			{
				return _events;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEvents(value);
				}
				else
				{
					if(value==null)
					{
						if(_events != null)
						{
							_events.UnsetRelatedEntity(this, "AfmarketingMaterial");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AfmarketingMaterial");
						}
					}
				}
			}
		}

	
		
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the Falcon.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)Falcon.Data.EntityType.AfmarketingMaterialEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
