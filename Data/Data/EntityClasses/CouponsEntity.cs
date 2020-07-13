///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:44
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
	/// Entity class which represents the entity 'Coupons'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CouponsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CouponSignUpModeEntity> _couponSignUpMode;
		private EntityCollection<EventCouponsEntity> _eventCoupons;
		private EntityCollection<MarketingPrintOrderItemEntity> _marketingPrintOrderItem;
		private EntityCollection<PackageSourceCodeDiscountEntity> _packageSourceCodeDiscount;
		private EntityCollection<ProductSourceCodeDiscountEntity> _productSourceCodeDiscount;
		private EntityCollection<ShippingOptionSourceCodeDiscountEntity> _shippingOptionSourceCodeDiscount;
		private EntityCollection<SourceCodeOrderDetailEntity> _sourceCodeOrderDetail;
		private EntityCollection<TestSourceCodeDiscountEntity> _testSourceCodeDiscount;
		private EntityCollection<AfmarketingMaterialEntity> _afmarketingMaterialCollectionViaMarketingPrintOrderItem;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventCoupons;
		private EntityCollection<LookupEntity> _lookupCollectionViaMarketingPrintOrderItem;
		private EntityCollection<MarketingOrderShippingInfoEntity> _marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem;
		private EntityCollection<MarketingPrintOrderEntity> _marketingPrintOrderCollectionViaMarketingPrintOrderItem;
		private EntityCollection<OrderDetailEntity> _orderDetailCollectionViaSourceCodeOrderDetail;
		private EntityCollection<PackageEntity> _packageCollectionViaPackageSourceCodeDiscount;
		private EntityCollection<ProductEntity> _productCollectionViaProductSourceCodeDiscount;
		private EntityCollection<ShippingOptionEntity> _shippingOptionCollectionViaShippingOptionSourceCodeDiscount;
		private EntityCollection<TestEntity> _testCollectionViaTestSourceCodeDiscount;
		private CouponTypeEntity _couponType;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CouponType</summary>
			public static readonly string CouponType = "CouponType";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CouponSignUpMode</summary>
			public static readonly string CouponSignUpMode = "CouponSignUpMode";
			/// <summary>Member name EventCoupons</summary>
			public static readonly string EventCoupons = "EventCoupons";
			/// <summary>Member name MarketingPrintOrderItem</summary>
			public static readonly string MarketingPrintOrderItem = "MarketingPrintOrderItem";
			/// <summary>Member name PackageSourceCodeDiscount</summary>
			public static readonly string PackageSourceCodeDiscount = "PackageSourceCodeDiscount";
			/// <summary>Member name ProductSourceCodeDiscount</summary>
			public static readonly string ProductSourceCodeDiscount = "ProductSourceCodeDiscount";
			/// <summary>Member name ShippingOptionSourceCodeDiscount</summary>
			public static readonly string ShippingOptionSourceCodeDiscount = "ShippingOptionSourceCodeDiscount";
			/// <summary>Member name SourceCodeOrderDetail</summary>
			public static readonly string SourceCodeOrderDetail = "SourceCodeOrderDetail";
			/// <summary>Member name TestSourceCodeDiscount</summary>
			public static readonly string TestSourceCodeDiscount = "TestSourceCodeDiscount";
			/// <summary>Member name AfmarketingMaterialCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string AfmarketingMaterialCollectionViaMarketingPrintOrderItem = "AfmarketingMaterialCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name EventsCollectionViaEventCoupons</summary>
			public static readonly string EventsCollectionViaEventCoupons = "EventsCollectionViaEventCoupons";
			/// <summary>Member name LookupCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string LookupCollectionViaMarketingPrintOrderItem = "LookupCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name MarketingPrintOrderCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string MarketingPrintOrderCollectionViaMarketingPrintOrderItem = "MarketingPrintOrderCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name OrderDetailCollectionViaSourceCodeOrderDetail</summary>
			public static readonly string OrderDetailCollectionViaSourceCodeOrderDetail = "OrderDetailCollectionViaSourceCodeOrderDetail";
			/// <summary>Member name PackageCollectionViaPackageSourceCodeDiscount</summary>
			public static readonly string PackageCollectionViaPackageSourceCodeDiscount = "PackageCollectionViaPackageSourceCodeDiscount";
			/// <summary>Member name ProductCollectionViaProductSourceCodeDiscount</summary>
			public static readonly string ProductCollectionViaProductSourceCodeDiscount = "ProductCollectionViaProductSourceCodeDiscount";
			/// <summary>Member name ShippingOptionCollectionViaShippingOptionSourceCodeDiscount</summary>
			public static readonly string ShippingOptionCollectionViaShippingOptionSourceCodeDiscount = "ShippingOptionCollectionViaShippingOptionSourceCodeDiscount";
			/// <summary>Member name TestCollectionViaTestSourceCodeDiscount</summary>
			public static readonly string TestCollectionViaTestSourceCodeDiscount = "TestCollectionViaTestSourceCodeDiscount";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CouponsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CouponsEntity():base("CouponsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CouponsEntity(IEntityFields2 fields):base("CouponsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CouponsEntity</param>
		public CouponsEntity(IValidator validator):base("CouponsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="couponId">PK value for Coupons which data should be fetched into this Coupons object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CouponsEntity(System.Int64 couponId):base("CouponsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CouponId = couponId;
		}

		/// <summary> CTor</summary>
		/// <param name="couponId">PK value for Coupons which data should be fetched into this Coupons object</param>
		/// <param name="validator">The custom validator object for this CouponsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CouponsEntity(System.Int64 couponId, IValidator validator):base("CouponsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CouponId = couponId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CouponsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_couponSignUpMode = (EntityCollection<CouponSignUpModeEntity>)info.GetValue("_couponSignUpMode", typeof(EntityCollection<CouponSignUpModeEntity>));
				_eventCoupons = (EntityCollection<EventCouponsEntity>)info.GetValue("_eventCoupons", typeof(EntityCollection<EventCouponsEntity>));
				_marketingPrintOrderItem = (EntityCollection<MarketingPrintOrderItemEntity>)info.GetValue("_marketingPrintOrderItem", typeof(EntityCollection<MarketingPrintOrderItemEntity>));
				_packageSourceCodeDiscount = (EntityCollection<PackageSourceCodeDiscountEntity>)info.GetValue("_packageSourceCodeDiscount", typeof(EntityCollection<PackageSourceCodeDiscountEntity>));
				_productSourceCodeDiscount = (EntityCollection<ProductSourceCodeDiscountEntity>)info.GetValue("_productSourceCodeDiscount", typeof(EntityCollection<ProductSourceCodeDiscountEntity>));
				_shippingOptionSourceCodeDiscount = (EntityCollection<ShippingOptionSourceCodeDiscountEntity>)info.GetValue("_shippingOptionSourceCodeDiscount", typeof(EntityCollection<ShippingOptionSourceCodeDiscountEntity>));
				_sourceCodeOrderDetail = (EntityCollection<SourceCodeOrderDetailEntity>)info.GetValue("_sourceCodeOrderDetail", typeof(EntityCollection<SourceCodeOrderDetailEntity>));
				_testSourceCodeDiscount = (EntityCollection<TestSourceCodeDiscountEntity>)info.GetValue("_testSourceCodeDiscount", typeof(EntityCollection<TestSourceCodeDiscountEntity>));
				_afmarketingMaterialCollectionViaMarketingPrintOrderItem = (EntityCollection<AfmarketingMaterialEntity>)info.GetValue("_afmarketingMaterialCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<AfmarketingMaterialEntity>));
				_eventsCollectionViaEventCoupons = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventCoupons", typeof(EntityCollection<EventsEntity>));
				_lookupCollectionViaMarketingPrintOrderItem = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<LookupEntity>));
				_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingOrderShippingInfoEntity>)info.GetValue("_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<MarketingOrderShippingInfoEntity>));
				_marketingPrintOrderCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingPrintOrderEntity>)info.GetValue("_marketingPrintOrderCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<MarketingPrintOrderEntity>));
				_orderDetailCollectionViaSourceCodeOrderDetail = (EntityCollection<OrderDetailEntity>)info.GetValue("_orderDetailCollectionViaSourceCodeOrderDetail", typeof(EntityCollection<OrderDetailEntity>));
				_packageCollectionViaPackageSourceCodeDiscount = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaPackageSourceCodeDiscount", typeof(EntityCollection<PackageEntity>));
				_productCollectionViaProductSourceCodeDiscount = (EntityCollection<ProductEntity>)info.GetValue("_productCollectionViaProductSourceCodeDiscount", typeof(EntityCollection<ProductEntity>));
				_shippingOptionCollectionViaShippingOptionSourceCodeDiscount = (EntityCollection<ShippingOptionEntity>)info.GetValue("_shippingOptionCollectionViaShippingOptionSourceCodeDiscount", typeof(EntityCollection<ShippingOptionEntity>));
				_testCollectionViaTestSourceCodeDiscount = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaTestSourceCodeDiscount", typeof(EntityCollection<TestEntity>));
				_couponType = (CouponTypeEntity)info.GetValue("_couponType", typeof(CouponTypeEntity));
				if(_couponType!=null)
				{
					_couponType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CouponsFieldIndex)fieldIndex)
			{
				case CouponsFieldIndex.CouponTypeId:
					DesetupSyncCouponType(true, false);
					break;
				case CouponsFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CouponsFieldIndex.ModifiedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
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
				case "CouponType":
					this.CouponType = (CouponTypeEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CouponSignUpMode":
					this.CouponSignUpMode.Add((CouponSignUpModeEntity)entity);
					break;
				case "EventCoupons":
					this.EventCoupons.Add((EventCouponsEntity)entity);
					break;
				case "MarketingPrintOrderItem":
					this.MarketingPrintOrderItem.Add((MarketingPrintOrderItemEntity)entity);
					break;
				case "PackageSourceCodeDiscount":
					this.PackageSourceCodeDiscount.Add((PackageSourceCodeDiscountEntity)entity);
					break;
				case "ProductSourceCodeDiscount":
					this.ProductSourceCodeDiscount.Add((ProductSourceCodeDiscountEntity)entity);
					break;
				case "ShippingOptionSourceCodeDiscount":
					this.ShippingOptionSourceCodeDiscount.Add((ShippingOptionSourceCodeDiscountEntity)entity);
					break;
				case "SourceCodeOrderDetail":
					this.SourceCodeOrderDetail.Add((SourceCodeOrderDetailEntity)entity);
					break;
				case "TestSourceCodeDiscount":
					this.TestSourceCodeDiscount.Add((TestSourceCodeDiscountEntity)entity);
					break;
				case "AfmarketingMaterialCollectionViaMarketingPrintOrderItem":
					this.AfmarketingMaterialCollectionViaMarketingPrintOrderItem.IsReadOnly = false;
					this.AfmarketingMaterialCollectionViaMarketingPrintOrderItem.Add((AfmarketingMaterialEntity)entity);
					this.AfmarketingMaterialCollectionViaMarketingPrintOrderItem.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventCoupons":
					this.EventsCollectionViaEventCoupons.IsReadOnly = false;
					this.EventsCollectionViaEventCoupons.Add((EventsEntity)entity);
					this.EventsCollectionViaEventCoupons.IsReadOnly = true;
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
				case "OrderDetailCollectionViaSourceCodeOrderDetail":
					this.OrderDetailCollectionViaSourceCodeOrderDetail.IsReadOnly = false;
					this.OrderDetailCollectionViaSourceCodeOrderDetail.Add((OrderDetailEntity)entity);
					this.OrderDetailCollectionViaSourceCodeOrderDetail.IsReadOnly = true;
					break;
				case "PackageCollectionViaPackageSourceCodeDiscount":
					this.PackageCollectionViaPackageSourceCodeDiscount.IsReadOnly = false;
					this.PackageCollectionViaPackageSourceCodeDiscount.Add((PackageEntity)entity);
					this.PackageCollectionViaPackageSourceCodeDiscount.IsReadOnly = true;
					break;
				case "ProductCollectionViaProductSourceCodeDiscount":
					this.ProductCollectionViaProductSourceCodeDiscount.IsReadOnly = false;
					this.ProductCollectionViaProductSourceCodeDiscount.Add((ProductEntity)entity);
					this.ProductCollectionViaProductSourceCodeDiscount.IsReadOnly = true;
					break;
				case "ShippingOptionCollectionViaShippingOptionSourceCodeDiscount":
					this.ShippingOptionCollectionViaShippingOptionSourceCodeDiscount.IsReadOnly = false;
					this.ShippingOptionCollectionViaShippingOptionSourceCodeDiscount.Add((ShippingOptionEntity)entity);
					this.ShippingOptionCollectionViaShippingOptionSourceCodeDiscount.IsReadOnly = true;
					break;
				case "TestCollectionViaTestSourceCodeDiscount":
					this.TestCollectionViaTestSourceCodeDiscount.IsReadOnly = false;
					this.TestCollectionViaTestSourceCodeDiscount.Add((TestEntity)entity);
					this.TestCollectionViaTestSourceCodeDiscount.IsReadOnly = true;
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
			return CouponsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CouponType":
					toReturn.Add(CouponsEntity.Relations.CouponTypeEntityUsingCouponTypeId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(CouponsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CouponsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "CouponSignUpMode":
					toReturn.Add(CouponsEntity.Relations.CouponSignUpModeEntityUsingCouponId);
					break;
				case "EventCoupons":
					toReturn.Add(CouponsEntity.Relations.EventCouponsEntityUsingCouponId);
					break;
				case "MarketingPrintOrderItem":
					toReturn.Add(CouponsEntity.Relations.MarketingPrintOrderItemEntityUsingSourceCodeId);
					break;
				case "PackageSourceCodeDiscount":
					toReturn.Add(CouponsEntity.Relations.PackageSourceCodeDiscountEntityUsingSourceCodeId);
					break;
				case "ProductSourceCodeDiscount":
					toReturn.Add(CouponsEntity.Relations.ProductSourceCodeDiscountEntityUsingSourceCodeId);
					break;
				case "ShippingOptionSourceCodeDiscount":
					toReturn.Add(CouponsEntity.Relations.ShippingOptionSourceCodeDiscountEntityUsingSourceCodeId);
					break;
				case "SourceCodeOrderDetail":
					toReturn.Add(CouponsEntity.Relations.SourceCodeOrderDetailEntityUsingSourceCodeId);
					break;
				case "TestSourceCodeDiscount":
					toReturn.Add(CouponsEntity.Relations.TestSourceCodeDiscountEntityUsingSourceCodeId);
					break;
				case "AfmarketingMaterialCollectionViaMarketingPrintOrderItem":
					toReturn.Add(CouponsEntity.Relations.MarketingPrintOrderItemEntityUsingSourceCodeId, "CouponsEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventCoupons":
					toReturn.Add(CouponsEntity.Relations.EventCouponsEntityUsingCouponId, "CouponsEntity__", "EventCoupons_", JoinHint.None);
					toReturn.Add(EventCouponsEntity.Relations.EventsEntityUsingEventId, "EventCoupons_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaMarketingPrintOrderItem":
					toReturn.Add(CouponsEntity.Relations.MarketingPrintOrderItemEntityUsingSourceCodeId, "CouponsEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.LookupEntityUsingStatus, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem":
					toReturn.Add(CouponsEntity.Relations.MarketingPrintOrderItemEntityUsingSourceCodeId, "CouponsEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.MarketingOrderShippingInfoEntityUsingMarketingOrderShippingInfoId, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "MarketingPrintOrderCollectionViaMarketingPrintOrderItem":
					toReturn.Add(CouponsEntity.Relations.MarketingPrintOrderItemEntityUsingSourceCodeId, "CouponsEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.MarketingPrintOrderEntityUsingMarketingPrintOrderId, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "OrderDetailCollectionViaSourceCodeOrderDetail":
					toReturn.Add(CouponsEntity.Relations.SourceCodeOrderDetailEntityUsingSourceCodeId, "CouponsEntity__", "SourceCodeOrderDetail_", JoinHint.None);
					toReturn.Add(SourceCodeOrderDetailEntity.Relations.OrderDetailEntityUsingOrderDetailId, "SourceCodeOrderDetail_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaPackageSourceCodeDiscount":
					toReturn.Add(CouponsEntity.Relations.PackageSourceCodeDiscountEntityUsingSourceCodeId, "CouponsEntity__", "PackageSourceCodeDiscount_", JoinHint.None);
					toReturn.Add(PackageSourceCodeDiscountEntity.Relations.PackageEntityUsingPackageId, "PackageSourceCodeDiscount_", string.Empty, JoinHint.None);
					break;
				case "ProductCollectionViaProductSourceCodeDiscount":
					toReturn.Add(CouponsEntity.Relations.ProductSourceCodeDiscountEntityUsingSourceCodeId, "CouponsEntity__", "ProductSourceCodeDiscount_", JoinHint.None);
					toReturn.Add(ProductSourceCodeDiscountEntity.Relations.ProductEntityUsingProductId, "ProductSourceCodeDiscount_", string.Empty, JoinHint.None);
					break;
				case "ShippingOptionCollectionViaShippingOptionSourceCodeDiscount":
					toReturn.Add(CouponsEntity.Relations.ShippingOptionSourceCodeDiscountEntityUsingSourceCodeId, "CouponsEntity__", "ShippingOptionSourceCodeDiscount_", JoinHint.None);
					toReturn.Add(ShippingOptionSourceCodeDiscountEntity.Relations.ShippingOptionEntityUsingShippingOptionId, "ShippingOptionSourceCodeDiscount_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaTestSourceCodeDiscount":
					toReturn.Add(CouponsEntity.Relations.TestSourceCodeDiscountEntityUsingSourceCodeId, "CouponsEntity__", "TestSourceCodeDiscount_", JoinHint.None);
					toReturn.Add(TestSourceCodeDiscountEntity.Relations.TestEntityUsingTestId, "TestSourceCodeDiscount_", string.Empty, JoinHint.None);
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
				case "CouponType":
					SetupSyncCouponType(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CouponSignUpMode":
					this.CouponSignUpMode.Add((CouponSignUpModeEntity)relatedEntity);
					break;
				case "EventCoupons":
					this.EventCoupons.Add((EventCouponsEntity)relatedEntity);
					break;
				case "MarketingPrintOrderItem":
					this.MarketingPrintOrderItem.Add((MarketingPrintOrderItemEntity)relatedEntity);
					break;
				case "PackageSourceCodeDiscount":
					this.PackageSourceCodeDiscount.Add((PackageSourceCodeDiscountEntity)relatedEntity);
					break;
				case "ProductSourceCodeDiscount":
					this.ProductSourceCodeDiscount.Add((ProductSourceCodeDiscountEntity)relatedEntity);
					break;
				case "ShippingOptionSourceCodeDiscount":
					this.ShippingOptionSourceCodeDiscount.Add((ShippingOptionSourceCodeDiscountEntity)relatedEntity);
					break;
				case "SourceCodeOrderDetail":
					this.SourceCodeOrderDetail.Add((SourceCodeOrderDetailEntity)relatedEntity);
					break;
				case "TestSourceCodeDiscount":
					this.TestSourceCodeDiscount.Add((TestSourceCodeDiscountEntity)relatedEntity);
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
				case "CouponType":
					DesetupSyncCouponType(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CouponSignUpMode":
					base.PerformRelatedEntityRemoval(this.CouponSignUpMode, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCoupons":
					base.PerformRelatedEntityRemoval(this.EventCoupons, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MarketingPrintOrderItem":
					base.PerformRelatedEntityRemoval(this.MarketingPrintOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PackageSourceCodeDiscount":
					base.PerformRelatedEntityRemoval(this.PackageSourceCodeDiscount, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProductSourceCodeDiscount":
					base.PerformRelatedEntityRemoval(this.ProductSourceCodeDiscount, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ShippingOptionSourceCodeDiscount":
					base.PerformRelatedEntityRemoval(this.ShippingOptionSourceCodeDiscount, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SourceCodeOrderDetail":
					base.PerformRelatedEntityRemoval(this.SourceCodeOrderDetail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestSourceCodeDiscount":
					base.PerformRelatedEntityRemoval(this.TestSourceCodeDiscount, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_couponType!=null)
			{
				toReturn.Add(_couponType);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CouponSignUpMode);
			toReturn.Add(this.EventCoupons);
			toReturn.Add(this.MarketingPrintOrderItem);
			toReturn.Add(this.PackageSourceCodeDiscount);
			toReturn.Add(this.ProductSourceCodeDiscount);
			toReturn.Add(this.ShippingOptionSourceCodeDiscount);
			toReturn.Add(this.SourceCodeOrderDetail);
			toReturn.Add(this.TestSourceCodeDiscount);

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
				info.AddValue("_couponSignUpMode", ((_couponSignUpMode!=null) && (_couponSignUpMode.Count>0) && !this.MarkedForDeletion)?_couponSignUpMode:null);
				info.AddValue("_eventCoupons", ((_eventCoupons!=null) && (_eventCoupons.Count>0) && !this.MarkedForDeletion)?_eventCoupons:null);
				info.AddValue("_marketingPrintOrderItem", ((_marketingPrintOrderItem!=null) && (_marketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrderItem:null);
				info.AddValue("_packageSourceCodeDiscount", ((_packageSourceCodeDiscount!=null) && (_packageSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_packageSourceCodeDiscount:null);
				info.AddValue("_productSourceCodeDiscount", ((_productSourceCodeDiscount!=null) && (_productSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_productSourceCodeDiscount:null);
				info.AddValue("_shippingOptionSourceCodeDiscount", ((_shippingOptionSourceCodeDiscount!=null) && (_shippingOptionSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_shippingOptionSourceCodeDiscount:null);
				info.AddValue("_sourceCodeOrderDetail", ((_sourceCodeOrderDetail!=null) && (_sourceCodeOrderDetail.Count>0) && !this.MarkedForDeletion)?_sourceCodeOrderDetail:null);
				info.AddValue("_testSourceCodeDiscount", ((_testSourceCodeDiscount!=null) && (_testSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_testSourceCodeDiscount:null);
				info.AddValue("_afmarketingMaterialCollectionViaMarketingPrintOrderItem", ((_afmarketingMaterialCollectionViaMarketingPrintOrderItem!=null) && (_afmarketingMaterialCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_afmarketingMaterialCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_eventsCollectionViaEventCoupons", ((_eventsCollectionViaEventCoupons!=null) && (_eventsCollectionViaEventCoupons.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventCoupons:null);
				info.AddValue("_lookupCollectionViaMarketingPrintOrderItem", ((_lookupCollectionViaMarketingPrintOrderItem!=null) && (_lookupCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", ((_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem!=null) && (_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_marketingPrintOrderCollectionViaMarketingPrintOrderItem", ((_marketingPrintOrderCollectionViaMarketingPrintOrderItem!=null) && (_marketingPrintOrderCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrderCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_orderDetailCollectionViaSourceCodeOrderDetail", ((_orderDetailCollectionViaSourceCodeOrderDetail!=null) && (_orderDetailCollectionViaSourceCodeOrderDetail.Count>0) && !this.MarkedForDeletion)?_orderDetailCollectionViaSourceCodeOrderDetail:null);
				info.AddValue("_packageCollectionViaPackageSourceCodeDiscount", ((_packageCollectionViaPackageSourceCodeDiscount!=null) && (_packageCollectionViaPackageSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaPackageSourceCodeDiscount:null);
				info.AddValue("_productCollectionViaProductSourceCodeDiscount", ((_productCollectionViaProductSourceCodeDiscount!=null) && (_productCollectionViaProductSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_productCollectionViaProductSourceCodeDiscount:null);
				info.AddValue("_shippingOptionCollectionViaShippingOptionSourceCodeDiscount", ((_shippingOptionCollectionViaShippingOptionSourceCodeDiscount!=null) && (_shippingOptionCollectionViaShippingOptionSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_shippingOptionCollectionViaShippingOptionSourceCodeDiscount:null);
				info.AddValue("_testCollectionViaTestSourceCodeDiscount", ((_testCollectionViaTestSourceCodeDiscount!=null) && (_testCollectionViaTestSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_testCollectionViaTestSourceCodeDiscount:null);
				info.AddValue("_couponType", (!this.MarkedForDeletion?_couponType:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CouponsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CouponsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CouponsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CouponSignUpMode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponSignUpMode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponSignUpModeFields.CouponId, null, ComparisonOperator.Equal, this.CouponId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCoupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCoupons()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderItemFields.SourceCodeId, null, ComparisonOperator.Equal, this.CouponId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PackageSourceCodeDiscount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageSourceCodeDiscountFields.SourceCodeId, null, ComparisonOperator.Equal, this.CouponId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProductSourceCodeDiscount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProductSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductSourceCodeDiscountFields.SourceCodeId, null, ComparisonOperator.Equal, this.CouponId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingOptionSourceCodeDiscount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingOptionSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionSourceCodeDiscountFields.SourceCodeId, null, ComparisonOperator.Equal, this.CouponId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SourceCodeOrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSourceCodeOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SourceCodeOrderDetailFields.SourceCodeId, null, ComparisonOperator.Equal, this.CouponId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestSourceCodeDiscount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestSourceCodeDiscountFields.SourceCodeId, null, ComparisonOperator.Equal, this.CouponId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfmarketingMaterial' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfmarketingMaterialCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfmarketingMaterialCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventCoupons()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventCoupons"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingOrderShippingInfo' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrder' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrderCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MarketingPrintOrderCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderDetailCollectionViaSourceCodeOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderDetailCollectionViaSourceCodeOrderDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaPackageSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaPackageSourceCodeDiscount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Product' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProductCollectionViaProductSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProductCollectionViaProductSourceCodeDiscount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingOptionCollectionViaShippingOptionSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ShippingOptionCollectionViaShippingOptionSourceCodeDiscount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaTestSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaTestSourceCodeDiscount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.CouponId, "CouponsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CouponType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponTypeFields.CouponTypeId, null, ComparisonOperator.Equal, this.CouponTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CouponsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._couponSignUpMode);
			collectionsQueue.Enqueue(this._eventCoupons);
			collectionsQueue.Enqueue(this._marketingPrintOrderItem);
			collectionsQueue.Enqueue(this._packageSourceCodeDiscount);
			collectionsQueue.Enqueue(this._productSourceCodeDiscount);
			collectionsQueue.Enqueue(this._shippingOptionSourceCodeDiscount);
			collectionsQueue.Enqueue(this._sourceCodeOrderDetail);
			collectionsQueue.Enqueue(this._testSourceCodeDiscount);
			collectionsQueue.Enqueue(this._afmarketingMaterialCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventCoupons);
			collectionsQueue.Enqueue(this._lookupCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._marketingPrintOrderCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._orderDetailCollectionViaSourceCodeOrderDetail);
			collectionsQueue.Enqueue(this._packageCollectionViaPackageSourceCodeDiscount);
			collectionsQueue.Enqueue(this._productCollectionViaProductSourceCodeDiscount);
			collectionsQueue.Enqueue(this._shippingOptionCollectionViaShippingOptionSourceCodeDiscount);
			collectionsQueue.Enqueue(this._testCollectionViaTestSourceCodeDiscount);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._couponSignUpMode = (EntityCollection<CouponSignUpModeEntity>) collectionsQueue.Dequeue();
			this._eventCoupons = (EntityCollection<EventCouponsEntity>) collectionsQueue.Dequeue();
			this._marketingPrintOrderItem = (EntityCollection<MarketingPrintOrderItemEntity>) collectionsQueue.Dequeue();
			this._packageSourceCodeDiscount = (EntityCollection<PackageSourceCodeDiscountEntity>) collectionsQueue.Dequeue();
			this._productSourceCodeDiscount = (EntityCollection<ProductSourceCodeDiscountEntity>) collectionsQueue.Dequeue();
			this._shippingOptionSourceCodeDiscount = (EntityCollection<ShippingOptionSourceCodeDiscountEntity>) collectionsQueue.Dequeue();
			this._sourceCodeOrderDetail = (EntityCollection<SourceCodeOrderDetailEntity>) collectionsQueue.Dequeue();
			this._testSourceCodeDiscount = (EntityCollection<TestSourceCodeDiscountEntity>) collectionsQueue.Dequeue();
			this._afmarketingMaterialCollectionViaMarketingPrintOrderItem = (EntityCollection<AfmarketingMaterialEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventCoupons = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaMarketingPrintOrderItem = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingOrderShippingInfoEntity>) collectionsQueue.Dequeue();
			this._marketingPrintOrderCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingPrintOrderEntity>) collectionsQueue.Dequeue();
			this._orderDetailCollectionViaSourceCodeOrderDetail = (EntityCollection<OrderDetailEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaPackageSourceCodeDiscount = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._productCollectionViaProductSourceCodeDiscount = (EntityCollection<ProductEntity>) collectionsQueue.Dequeue();
			this._shippingOptionCollectionViaShippingOptionSourceCodeDiscount = (EntityCollection<ShippingOptionEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaTestSourceCodeDiscount = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._couponSignUpMode != null)
			{
				return true;
			}
			if (this._eventCoupons != null)
			{
				return true;
			}
			if (this._marketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._packageSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._productSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._shippingOptionSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._sourceCodeOrderDetail != null)
			{
				return true;
			}
			if (this._testSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._afmarketingMaterialCollectionViaMarketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventCoupons != null)
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
			if (this._orderDetailCollectionViaSourceCodeOrderDetail != null)
			{
				return true;
			}
			if (this._packageCollectionViaPackageSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._productCollectionViaProductSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._shippingOptionCollectionViaShippingOptionSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._testCollectionViaTestSourceCodeDiscount != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouponSignUpModeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponSignUpModeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCouponsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageSourceCodeDiscountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProductSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductSourceCodeDiscountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingOptionSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionSourceCodeDiscountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SourceCodeOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SourceCodeOrderDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestSourceCodeDiscountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingOrderShippingInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingOrderShippingInfoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CouponType", _couponType);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CouponSignUpMode", _couponSignUpMode);
			toReturn.Add("EventCoupons", _eventCoupons);
			toReturn.Add("MarketingPrintOrderItem", _marketingPrintOrderItem);
			toReturn.Add("PackageSourceCodeDiscount", _packageSourceCodeDiscount);
			toReturn.Add("ProductSourceCodeDiscount", _productSourceCodeDiscount);
			toReturn.Add("ShippingOptionSourceCodeDiscount", _shippingOptionSourceCodeDiscount);
			toReturn.Add("SourceCodeOrderDetail", _sourceCodeOrderDetail);
			toReturn.Add("TestSourceCodeDiscount", _testSourceCodeDiscount);
			toReturn.Add("AfmarketingMaterialCollectionViaMarketingPrintOrderItem", _afmarketingMaterialCollectionViaMarketingPrintOrderItem);
			toReturn.Add("EventsCollectionViaEventCoupons", _eventsCollectionViaEventCoupons);
			toReturn.Add("LookupCollectionViaMarketingPrintOrderItem", _lookupCollectionViaMarketingPrintOrderItem);
			toReturn.Add("MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", _marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem);
			toReturn.Add("MarketingPrintOrderCollectionViaMarketingPrintOrderItem", _marketingPrintOrderCollectionViaMarketingPrintOrderItem);
			toReturn.Add("OrderDetailCollectionViaSourceCodeOrderDetail", _orderDetailCollectionViaSourceCodeOrderDetail);
			toReturn.Add("PackageCollectionViaPackageSourceCodeDiscount", _packageCollectionViaPackageSourceCodeDiscount);
			toReturn.Add("ProductCollectionViaProductSourceCodeDiscount", _productCollectionViaProductSourceCodeDiscount);
			toReturn.Add("ShippingOptionCollectionViaShippingOptionSourceCodeDiscount", _shippingOptionCollectionViaShippingOptionSourceCodeDiscount);
			toReturn.Add("TestCollectionViaTestSourceCodeDiscount", _testCollectionViaTestSourceCodeDiscount);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_couponSignUpMode!=null)
			{
				_couponSignUpMode.ActiveContext = base.ActiveContext;
			}
			if(_eventCoupons!=null)
			{
				_eventCoupons.ActiveContext = base.ActiveContext;
			}
			if(_marketingPrintOrderItem!=null)
			{
				_marketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_packageSourceCodeDiscount!=null)
			{
				_packageSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_productSourceCodeDiscount!=null)
			{
				_productSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_shippingOptionSourceCodeDiscount!=null)
			{
				_shippingOptionSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_sourceCodeOrderDetail!=null)
			{
				_sourceCodeOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_testSourceCodeDiscount!=null)
			{
				_testSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterialCollectionViaMarketingPrintOrderItem!=null)
			{
				_afmarketingMaterialCollectionViaMarketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventCoupons!=null)
			{
				_eventsCollectionViaEventCoupons.ActiveContext = base.ActiveContext;
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
			if(_orderDetailCollectionViaSourceCodeOrderDetail!=null)
			{
				_orderDetailCollectionViaSourceCodeOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaPackageSourceCodeDiscount!=null)
			{
				_packageCollectionViaPackageSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_productCollectionViaProductSourceCodeDiscount!=null)
			{
				_productCollectionViaProductSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_shippingOptionCollectionViaShippingOptionSourceCodeDiscount!=null)
			{
				_shippingOptionCollectionViaShippingOptionSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaTestSourceCodeDiscount!=null)
			{
				_testCollectionViaTestSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_couponType!=null)
			{
				_couponType.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_couponSignUpMode = null;
			_eventCoupons = null;
			_marketingPrintOrderItem = null;
			_packageSourceCodeDiscount = null;
			_productSourceCodeDiscount = null;
			_shippingOptionSourceCodeDiscount = null;
			_sourceCodeOrderDetail = null;
			_testSourceCodeDiscount = null;
			_afmarketingMaterialCollectionViaMarketingPrintOrderItem = null;
			_eventsCollectionViaEventCoupons = null;
			_lookupCollectionViaMarketingPrintOrderItem = null;
			_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = null;
			_marketingPrintOrderCollectionViaMarketingPrintOrderItem = null;
			_orderDetailCollectionViaSourceCodeOrderDetail = null;
			_packageCollectionViaPackageSourceCodeDiscount = null;
			_productCollectionViaProductSourceCodeDiscount = null;
			_shippingOptionCollectionViaShippingOptionSourceCodeDiscount = null;
			_testCollectionViaTestSourceCodeDiscount = null;
			_couponType = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser = null;

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

			_fieldsCustomProperties.Add("CouponId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CouponTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPercentage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CouponValue", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CouponDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MinimumPurchaseAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ValidityStartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ValidityEndDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaximumNumberTimesUsed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CouponCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerRange", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _couponType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCouponType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _couponType, new PropertyChangedEventHandler( OnCouponTypePropertyChanged ), "CouponType", CouponsEntity.Relations.CouponTypeEntityUsingCouponTypeId, true, signalRelatedEntity, "Coupons", resetFKFields, new int[] { (int)CouponsFieldIndex.CouponTypeId } );		
			_couponType = null;
		}

		/// <summary> setups the sync logic for member _couponType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCouponType(IEntity2 relatedEntity)
		{
			if(_couponType!=relatedEntity)
			{
				DesetupSyncCouponType(true, true);
				_couponType = (CouponTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _couponType, new PropertyChangedEventHandler( OnCouponTypePropertyChanged ), "CouponType", CouponsEntity.Relations.CouponTypeEntityUsingCouponTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCouponTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CouponsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "Coupons_", resetFKFields, new int[] { (int)CouponsFieldIndex.ModifiedByOrgRoleUserId } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CouponsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CouponsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "Coupons", resetFKFields, new int[] { (int)CouponsFieldIndex.CreatedByOrgRoleUserId } );		
			_organizationRoleUser = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser(true, true);
				_organizationRoleUser = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CouponsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CouponsEntity</param>
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
		public  static CouponsRelations Relations
		{
			get	{ return new CouponsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CouponSignUpMode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponSignUpMode
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CouponSignUpModeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponSignUpModeEntityFactory))),
					(IEntityRelation)GetRelationsForField("CouponSignUpMode")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.CouponSignUpModeEntity, 0, null, null, null, null, "CouponSignUpMode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCoupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCoupons
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCouponsEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCoupons")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.EventCouponsEntity, 0, null, null, null, null, "EventCoupons", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("MarketingPrintOrderItem")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, 0, null, null, null, null, "MarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PackageSourceCodeDiscount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageSourceCodeDiscount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PackageSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageSourceCodeDiscountEntityFactory))),
					(IEntityRelation)GetRelationsForField("PackageSourceCodeDiscount")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.PackageSourceCodeDiscountEntity, 0, null, null, null, null, "PackageSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProductSourceCodeDiscount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProductSourceCodeDiscount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProductSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductSourceCodeDiscountEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProductSourceCodeDiscount")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.ProductSourceCodeDiscountEntity, 0, null, null, null, null, "ProductSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingOptionSourceCodeDiscount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingOptionSourceCodeDiscount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ShippingOptionSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionSourceCodeDiscountEntityFactory))),
					(IEntityRelation)GetRelationsForField("ShippingOptionSourceCodeDiscount")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.ShippingOptionSourceCodeDiscountEntity, 0, null, null, null, null, "ShippingOptionSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SourceCodeOrderDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSourceCodeOrderDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SourceCodeOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SourceCodeOrderDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("SourceCodeOrderDetail")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.SourceCodeOrderDetailEntity, 0, null, null, null, null, "SourceCodeOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestSourceCodeDiscount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestSourceCodeDiscount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestSourceCodeDiscountEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestSourceCodeDiscount")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.TestSourceCodeDiscountEntity, 0, null, null, null, null, "TestSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfmarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfmarketingMaterialCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.MarketingPrintOrderItemEntityUsingSourceCodeId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, 0, null, null, GetRelationsForField("AfmarketingMaterialCollectionViaMarketingPrintOrderItem"), null, "AfmarketingMaterialCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventCoupons
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.EventCouponsEntityUsingCouponId;
				intermediateRelation.SetAliases(string.Empty, "EventCoupons_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventCoupons"), null, "EventsCollectionViaEventCoupons", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.MarketingPrintOrderItemEntityUsingSourceCodeId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaMarketingPrintOrderItem"), null, "LookupCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingOrderShippingInfo' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.MarketingPrintOrderItemEntityUsingSourceCodeId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<MarketingOrderShippingInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingOrderShippingInfoEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.MarketingOrderShippingInfoEntity, 0, null, null, GetRelationsForField("MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem"), null, "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrder' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrderCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.MarketingPrintOrderItemEntityUsingSourceCodeId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, 0, null, null, GetRelationsForField("MarketingPrintOrderCollectionViaMarketingPrintOrderItem"), null, "MarketingPrintOrderCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderDetailCollectionViaSourceCodeOrderDetail
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.SourceCodeOrderDetailEntityUsingSourceCodeId;
				intermediateRelation.SetAliases(string.Empty, "SourceCodeOrderDetail_");
				return new PrefetchPathElement2(new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.OrderDetailEntity, 0, null, null, GetRelationsForField("OrderDetailCollectionViaSourceCodeOrderDetail"), null, "OrderDetailCollectionViaSourceCodeOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaPackageSourceCodeDiscount
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.PackageSourceCodeDiscountEntityUsingSourceCodeId;
				intermediateRelation.SetAliases(string.Empty, "PackageSourceCodeDiscount_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaPackageSourceCodeDiscount"), null, "PackageCollectionViaPackageSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Product' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProductCollectionViaProductSourceCodeDiscount
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.ProductSourceCodeDiscountEntityUsingSourceCodeId;
				intermediateRelation.SetAliases(string.Empty, "ProductSourceCodeDiscount_");
				return new PrefetchPathElement2(new EntityCollection<ProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.ProductEntity, 0, null, null, GetRelationsForField("ProductCollectionViaProductSourceCodeDiscount"), null, "ProductCollectionViaProductSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingOptionCollectionViaShippingOptionSourceCodeDiscount
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.ShippingOptionSourceCodeDiscountEntityUsingSourceCodeId;
				intermediateRelation.SetAliases(string.Empty, "ShippingOptionSourceCodeDiscount_");
				return new PrefetchPathElement2(new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.ShippingOptionEntity, 0, null, null, GetRelationsForField("ShippingOptionCollectionViaShippingOptionSourceCodeDiscount"), null, "ShippingOptionCollectionViaShippingOptionSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaTestSourceCodeDiscount
		{
			get
			{
				IEntityRelation intermediateRelation = CouponsEntity.Relations.TestSourceCodeDiscountEntityUsingSourceCodeId;
				intermediateRelation.SetAliases(string.Empty, "TestSourceCodeDiscount_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaTestSourceCodeDiscount"), null, "TestCollectionViaTestSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CouponType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CouponTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("CouponType")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.CouponTypeEntity, 0, null, null, null, null, "CouponType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CouponsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CouponsEntity.CustomProperties;}
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
			get { return CouponsEntity.FieldsCustomProperties;}
		}

		/// <summary> The CouponId property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."CouponID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CouponId
		{
			get { return (System.Int64)GetValue((int)CouponsFieldIndex.CouponId, true); }
			set	{ SetValue((int)CouponsFieldIndex.CouponId, value); }
		}

		/// <summary> The CouponTypeId property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."CouponTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CouponTypeId
		{
			get { return (System.Int64)GetValue((int)CouponsFieldIndex.CouponTypeId, true); }
			set	{ SetValue((int)CouponsFieldIndex.CouponTypeId, value); }
		}

		/// <summary> The IsPercentage property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."IsPercentage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPercentage
		{
			get { return (System.Boolean)GetValue((int)CouponsFieldIndex.IsPercentage, true); }
			set	{ SetValue((int)CouponsFieldIndex.IsPercentage, value); }
		}

		/// <summary> The CouponValue property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."CouponValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal CouponValue
		{
			get { return (System.Decimal)GetValue((int)CouponsFieldIndex.CouponValue, true); }
			set	{ SetValue((int)CouponsFieldIndex.CouponValue, value); }
		}

		/// <summary> The CouponDescription property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."CouponDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CouponDescription
		{
			get { return (System.String)GetValue((int)CouponsFieldIndex.CouponDescription, true); }
			set	{ SetValue((int)CouponsFieldIndex.CouponDescription, value); }
		}

		/// <summary> The MinimumPurchaseAmount property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."MinimumPurchaseAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MinimumPurchaseAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)CouponsFieldIndex.MinimumPurchaseAmount, false); }
			set	{ SetValue((int)CouponsFieldIndex.MinimumPurchaseAmount, value); }
		}

		/// <summary> The ValidityStartDate property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."ValidityStartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ValidityStartDate
		{
			get { return (System.DateTime)GetValue((int)CouponsFieldIndex.ValidityStartDate, true); }
			set	{ SetValue((int)CouponsFieldIndex.ValidityStartDate, value); }
		}

		/// <summary> The ValidityEndDate property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."ValidityEndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ValidityEndDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CouponsFieldIndex.ValidityEndDate, false); }
			set	{ SetValue((int)CouponsFieldIndex.ValidityEndDate, value); }
		}

		/// <summary> The DateCreated property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CouponsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CouponsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CouponsFieldIndex.DateModified, false); }
			set	{ SetValue((int)CouponsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CouponsFieldIndex.IsActive, true); }
			set	{ SetValue((int)CouponsFieldIndex.IsActive, value); }
		}

		/// <summary> The MaximumNumberTimesUsed property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."MaximumNumberTimesUsed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 MaximumNumberTimesUsed
		{
			get { return (System.Int32)GetValue((int)CouponsFieldIndex.MaximumNumberTimesUsed, true); }
			set	{ SetValue((int)CouponsFieldIndex.MaximumNumberTimesUsed, value); }
		}

		/// <summary> The CouponCode property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."CouponCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CouponCode
		{
			get { return (System.String)GetValue((int)CouponsFieldIndex.CouponCode, true); }
			set	{ SetValue((int)CouponsFieldIndex.CouponCode, value); }
		}

		/// <summary> The CustomerRange property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."CustomerRange"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> CustomerRange
		{
			get { return (Nullable<System.Byte>)GetValue((int)CouponsFieldIndex.CustomerRange, false); }
			set	{ SetValue((int)CouponsFieldIndex.CustomerRange, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)CouponsFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)CouponsFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity Coupons<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCoupons"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CouponsFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)CouponsFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouponSignUpModeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouponSignUpModeEntity))]
		public virtual EntityCollection<CouponSignUpModeEntity> CouponSignUpMode
		{
			get
			{
				if(_couponSignUpMode==null)
				{
					_couponSignUpMode = new EntityCollection<CouponSignUpModeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponSignUpModeEntityFactory)));
					_couponSignUpMode.SetContainingEntityInfo(this, "Coupons");
				}
				return _couponSignUpMode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCouponsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCouponsEntity))]
		public virtual EntityCollection<EventCouponsEntity> EventCoupons
		{
			get
			{
				if(_eventCoupons==null)
				{
					_eventCoupons = new EntityCollection<EventCouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCouponsEntityFactory)));
					_eventCoupons.SetContainingEntityInfo(this, "Coupons");
				}
				return _eventCoupons;
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
					_marketingPrintOrderItem.SetContainingEntityInfo(this, "Coupons");
				}
				return _marketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageSourceCodeDiscountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageSourceCodeDiscountEntity))]
		public virtual EntityCollection<PackageSourceCodeDiscountEntity> PackageSourceCodeDiscount
		{
			get
			{
				if(_packageSourceCodeDiscount==null)
				{
					_packageSourceCodeDiscount = new EntityCollection<PackageSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageSourceCodeDiscountEntityFactory)));
					_packageSourceCodeDiscount.SetContainingEntityInfo(this, "Coupons");
				}
				return _packageSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProductSourceCodeDiscountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProductSourceCodeDiscountEntity))]
		public virtual EntityCollection<ProductSourceCodeDiscountEntity> ProductSourceCodeDiscount
		{
			get
			{
				if(_productSourceCodeDiscount==null)
				{
					_productSourceCodeDiscount = new EntityCollection<ProductSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductSourceCodeDiscountEntityFactory)));
					_productSourceCodeDiscount.SetContainingEntityInfo(this, "Coupons");
				}
				return _productSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingOptionSourceCodeDiscountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingOptionSourceCodeDiscountEntity))]
		public virtual EntityCollection<ShippingOptionSourceCodeDiscountEntity> ShippingOptionSourceCodeDiscount
		{
			get
			{
				if(_shippingOptionSourceCodeDiscount==null)
				{
					_shippingOptionSourceCodeDiscount = new EntityCollection<ShippingOptionSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionSourceCodeDiscountEntityFactory)));
					_shippingOptionSourceCodeDiscount.SetContainingEntityInfo(this, "Coupons");
				}
				return _shippingOptionSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SourceCodeOrderDetailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SourceCodeOrderDetailEntity))]
		public virtual EntityCollection<SourceCodeOrderDetailEntity> SourceCodeOrderDetail
		{
			get
			{
				if(_sourceCodeOrderDetail==null)
				{
					_sourceCodeOrderDetail = new EntityCollection<SourceCodeOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SourceCodeOrderDetailEntityFactory)));
					_sourceCodeOrderDetail.SetContainingEntityInfo(this, "Coupons");
				}
				return _sourceCodeOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestSourceCodeDiscountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestSourceCodeDiscountEntity))]
		public virtual EntityCollection<TestSourceCodeDiscountEntity> TestSourceCodeDiscount
		{
			get
			{
				if(_testSourceCodeDiscount==null)
				{
					_testSourceCodeDiscount = new EntityCollection<TestSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestSourceCodeDiscountEntityFactory)));
					_testSourceCodeDiscount.SetContainingEntityInfo(this, "Coupons");
				}
				return _testSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfmarketingMaterialEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfmarketingMaterialEntity))]
		public virtual EntityCollection<AfmarketingMaterialEntity> AfmarketingMaterialCollectionViaMarketingPrintOrderItem
		{
			get
			{
				if(_afmarketingMaterialCollectionViaMarketingPrintOrderItem==null)
				{
					_afmarketingMaterialCollectionViaMarketingPrintOrderItem = new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory)));
					_afmarketingMaterialCollectionViaMarketingPrintOrderItem.IsReadOnly=true;
				}
				return _afmarketingMaterialCollectionViaMarketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventCoupons
		{
			get
			{
				if(_eventsCollectionViaEventCoupons==null)
				{
					_eventsCollectionViaEventCoupons = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventCoupons.IsReadOnly=true;
				}
				return _eventsCollectionViaEventCoupons;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderDetailEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderDetailEntity))]
		public virtual EntityCollection<OrderDetailEntity> OrderDetailCollectionViaSourceCodeOrderDetail
		{
			get
			{
				if(_orderDetailCollectionViaSourceCodeOrderDetail==null)
				{
					_orderDetailCollectionViaSourceCodeOrderDetail = new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory)));
					_orderDetailCollectionViaSourceCodeOrderDetail.IsReadOnly=true;
				}
				return _orderDetailCollectionViaSourceCodeOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaPackageSourceCodeDiscount
		{
			get
			{
				if(_packageCollectionViaPackageSourceCodeDiscount==null)
				{
					_packageCollectionViaPackageSourceCodeDiscount = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaPackageSourceCodeDiscount.IsReadOnly=true;
				}
				return _packageCollectionViaPackageSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProductEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProductEntity))]
		public virtual EntityCollection<ProductEntity> ProductCollectionViaProductSourceCodeDiscount
		{
			get
			{
				if(_productCollectionViaProductSourceCodeDiscount==null)
				{
					_productCollectionViaProductSourceCodeDiscount = new EntityCollection<ProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory)));
					_productCollectionViaProductSourceCodeDiscount.IsReadOnly=true;
				}
				return _productCollectionViaProductSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingOptionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingOptionEntity))]
		public virtual EntityCollection<ShippingOptionEntity> ShippingOptionCollectionViaShippingOptionSourceCodeDiscount
		{
			get
			{
				if(_shippingOptionCollectionViaShippingOptionSourceCodeDiscount==null)
				{
					_shippingOptionCollectionViaShippingOptionSourceCodeDiscount = new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory)));
					_shippingOptionCollectionViaShippingOptionSourceCodeDiscount.IsReadOnly=true;
				}
				return _shippingOptionCollectionViaShippingOptionSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaTestSourceCodeDiscount
		{
			get
			{
				if(_testCollectionViaTestSourceCodeDiscount==null)
				{
					_testCollectionViaTestSourceCodeDiscount = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaTestSourceCodeDiscount.IsReadOnly=true;
				}
				return _testCollectionViaTestSourceCodeDiscount;
			}
		}

		/// <summary> Gets / sets related entity of type 'CouponTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CouponTypeEntity CouponType
		{
			get
			{
				return _couponType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCouponType(value);
				}
				else
				{
					if(value==null)
					{
						if(_couponType != null)
						{
							_couponType.UnsetRelatedEntity(this, "Coupons");
						}
					}
					else
					{
						if(_couponType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Coupons");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "Coupons_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Coupons_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser
		{
			get
			{
				return _organizationRoleUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser != null)
						{
							_organizationRoleUser.UnsetRelatedEntity(this, "Coupons");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Coupons");
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
			get { return (int)Falcon.Data.EntityType.CouponsEntity; }
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
