///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:46
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
	/// Entity class which represents the entity 'OrderItem'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OrderItemEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventPackageOrderItemEntity> _eventPackageOrderItem;
		private EntityCollection<EventTestOrderItemEntity> _eventTestOrderItem;
		private EntityCollection<GiftCertificateOrderItemEntity> _giftCertificateOrderItem;
		private EntityCollection<OrderDetailEntity> _orderDetail;
		private EntityCollection<ProductOrderItemEntity> _productOrderItem;
		private EntityCollection<ProspectActivityEntity> _prospectActivity;
		private EntityCollection<RefundOrderItemEntity> _refundOrderItem;
		private EntityCollection<ShippingOptionOrderItemEntity> _shippingOptionOrderItem;
		private EntityCollection<EventPackageDetailsEntity> _eventPackageDetailsCollectionViaEventPackageOrderItem;
		private EntityCollection<EventTestEntity> _eventTestCollectionViaEventTestOrderItem;
		private EntityCollection<GiftCertificateEntity> _giftCertificateCollectionViaGiftCertificateOrderItem;
		private EntityCollection<LookupEntity> _lookupCollectionViaOrderDetail;
		private EntityCollection<OrderEntity> _orderCollectionViaOrderDetail;
		private EntityCollection<ProductEntity> _productCollectionViaProductOrderItem;
		private EntityCollection<RefundEntity> _refundCollectionViaRefundOrderItem;
		private EntityCollection<ShippingOptionEntity> _shippingOptionCollectionViaShippingOptionOrderItem;
		private EntityCollection<TestEntity> _testCollectionViaProspectActivity;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name EventPackageOrderItem</summary>
			public static readonly string EventPackageOrderItem = "EventPackageOrderItem";
			/// <summary>Member name EventTestOrderItem</summary>
			public static readonly string EventTestOrderItem = "EventTestOrderItem";
			/// <summary>Member name GiftCertificateOrderItem</summary>
			public static readonly string GiftCertificateOrderItem = "GiftCertificateOrderItem";
			/// <summary>Member name OrderDetail</summary>
			public static readonly string OrderDetail = "OrderDetail";
			/// <summary>Member name ProductOrderItem</summary>
			public static readonly string ProductOrderItem = "ProductOrderItem";
			/// <summary>Member name ProspectActivity</summary>
			public static readonly string ProspectActivity = "ProspectActivity";
			/// <summary>Member name RefundOrderItem</summary>
			public static readonly string RefundOrderItem = "RefundOrderItem";
			/// <summary>Member name ShippingOptionOrderItem</summary>
			public static readonly string ShippingOptionOrderItem = "ShippingOptionOrderItem";
			/// <summary>Member name EventPackageDetailsCollectionViaEventPackageOrderItem</summary>
			public static readonly string EventPackageDetailsCollectionViaEventPackageOrderItem = "EventPackageDetailsCollectionViaEventPackageOrderItem";
			/// <summary>Member name EventTestCollectionViaEventTestOrderItem</summary>
			public static readonly string EventTestCollectionViaEventTestOrderItem = "EventTestCollectionViaEventTestOrderItem";
			/// <summary>Member name GiftCertificateCollectionViaGiftCertificateOrderItem</summary>
			public static readonly string GiftCertificateCollectionViaGiftCertificateOrderItem = "GiftCertificateCollectionViaGiftCertificateOrderItem";
			/// <summary>Member name LookupCollectionViaOrderDetail</summary>
			public static readonly string LookupCollectionViaOrderDetail = "LookupCollectionViaOrderDetail";
			/// <summary>Member name OrderCollectionViaOrderDetail</summary>
			public static readonly string OrderCollectionViaOrderDetail = "OrderCollectionViaOrderDetail";
			/// <summary>Member name ProductCollectionViaProductOrderItem</summary>
			public static readonly string ProductCollectionViaProductOrderItem = "ProductCollectionViaProductOrderItem";
			/// <summary>Member name RefundCollectionViaRefundOrderItem</summary>
			public static readonly string RefundCollectionViaRefundOrderItem = "RefundCollectionViaRefundOrderItem";
			/// <summary>Member name ShippingOptionCollectionViaShippingOptionOrderItem</summary>
			public static readonly string ShippingOptionCollectionViaShippingOptionOrderItem = "ShippingOptionCollectionViaShippingOptionOrderItem";
			/// <summary>Member name TestCollectionViaProspectActivity</summary>
			public static readonly string TestCollectionViaProspectActivity = "TestCollectionViaProspectActivity";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OrderItemEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public OrderItemEntity():base("OrderItemEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OrderItemEntity(IEntityFields2 fields):base("OrderItemEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OrderItemEntity</param>
		public OrderItemEntity(IValidator validator):base("OrderItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="orderItemId">PK value for OrderItem which data should be fetched into this OrderItem object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrderItemEntity(System.Int64 orderItemId):base("OrderItemEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OrderItemId = orderItemId;
		}

		/// <summary> CTor</summary>
		/// <param name="orderItemId">PK value for OrderItem which data should be fetched into this OrderItem object</param>
		/// <param name="validator">The custom validator object for this OrderItemEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrderItemEntity(System.Int64 orderItemId, IValidator validator):base("OrderItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OrderItemId = orderItemId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected OrderItemEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventPackageOrderItem = (EntityCollection<EventPackageOrderItemEntity>)info.GetValue("_eventPackageOrderItem", typeof(EntityCollection<EventPackageOrderItemEntity>));
				_eventTestOrderItem = (EntityCollection<EventTestOrderItemEntity>)info.GetValue("_eventTestOrderItem", typeof(EntityCollection<EventTestOrderItemEntity>));
				_giftCertificateOrderItem = (EntityCollection<GiftCertificateOrderItemEntity>)info.GetValue("_giftCertificateOrderItem", typeof(EntityCollection<GiftCertificateOrderItemEntity>));
				_orderDetail = (EntityCollection<OrderDetailEntity>)info.GetValue("_orderDetail", typeof(EntityCollection<OrderDetailEntity>));
				_productOrderItem = (EntityCollection<ProductOrderItemEntity>)info.GetValue("_productOrderItem", typeof(EntityCollection<ProductOrderItemEntity>));
				_prospectActivity = (EntityCollection<ProspectActivityEntity>)info.GetValue("_prospectActivity", typeof(EntityCollection<ProspectActivityEntity>));
				_refundOrderItem = (EntityCollection<RefundOrderItemEntity>)info.GetValue("_refundOrderItem", typeof(EntityCollection<RefundOrderItemEntity>));
				_shippingOptionOrderItem = (EntityCollection<ShippingOptionOrderItemEntity>)info.GetValue("_shippingOptionOrderItem", typeof(EntityCollection<ShippingOptionOrderItemEntity>));
				_eventPackageDetailsCollectionViaEventPackageOrderItem = (EntityCollection<EventPackageDetailsEntity>)info.GetValue("_eventPackageDetailsCollectionViaEventPackageOrderItem", typeof(EntityCollection<EventPackageDetailsEntity>));
				_eventTestCollectionViaEventTestOrderItem = (EntityCollection<EventTestEntity>)info.GetValue("_eventTestCollectionViaEventTestOrderItem", typeof(EntityCollection<EventTestEntity>));
				_giftCertificateCollectionViaGiftCertificateOrderItem = (EntityCollection<GiftCertificateEntity>)info.GetValue("_giftCertificateCollectionViaGiftCertificateOrderItem", typeof(EntityCollection<GiftCertificateEntity>));
				_lookupCollectionViaOrderDetail = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaOrderDetail", typeof(EntityCollection<LookupEntity>));
				_orderCollectionViaOrderDetail = (EntityCollection<OrderEntity>)info.GetValue("_orderCollectionViaOrderDetail", typeof(EntityCollection<OrderEntity>));
				_productCollectionViaProductOrderItem = (EntityCollection<ProductEntity>)info.GetValue("_productCollectionViaProductOrderItem", typeof(EntityCollection<ProductEntity>));
				_refundCollectionViaRefundOrderItem = (EntityCollection<RefundEntity>)info.GetValue("_refundCollectionViaRefundOrderItem", typeof(EntityCollection<RefundEntity>));
				_shippingOptionCollectionViaShippingOptionOrderItem = (EntityCollection<ShippingOptionEntity>)info.GetValue("_shippingOptionCollectionViaShippingOptionOrderItem", typeof(EntityCollection<ShippingOptionEntity>));
				_testCollectionViaProspectActivity = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaProspectActivity", typeof(EntityCollection<TestEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((OrderItemFieldIndex)fieldIndex)
			{
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

				case "EventPackageOrderItem":
					this.EventPackageOrderItem.Add((EventPackageOrderItemEntity)entity);
					break;
				case "EventTestOrderItem":
					this.EventTestOrderItem.Add((EventTestOrderItemEntity)entity);
					break;
				case "GiftCertificateOrderItem":
					this.GiftCertificateOrderItem.Add((GiftCertificateOrderItemEntity)entity);
					break;
				case "OrderDetail":
					this.OrderDetail.Add((OrderDetailEntity)entity);
					break;
				case "ProductOrderItem":
					this.ProductOrderItem.Add((ProductOrderItemEntity)entity);
					break;
				case "ProspectActivity":
					this.ProspectActivity.Add((ProspectActivityEntity)entity);
					break;
				case "RefundOrderItem":
					this.RefundOrderItem.Add((RefundOrderItemEntity)entity);
					break;
				case "ShippingOptionOrderItem":
					this.ShippingOptionOrderItem.Add((ShippingOptionOrderItemEntity)entity);
					break;
				case "EventPackageDetailsCollectionViaEventPackageOrderItem":
					this.EventPackageDetailsCollectionViaEventPackageOrderItem.IsReadOnly = false;
					this.EventPackageDetailsCollectionViaEventPackageOrderItem.Add((EventPackageDetailsEntity)entity);
					this.EventPackageDetailsCollectionViaEventPackageOrderItem.IsReadOnly = true;
					break;
				case "EventTestCollectionViaEventTestOrderItem":
					this.EventTestCollectionViaEventTestOrderItem.IsReadOnly = false;
					this.EventTestCollectionViaEventTestOrderItem.Add((EventTestEntity)entity);
					this.EventTestCollectionViaEventTestOrderItem.IsReadOnly = true;
					break;
				case "GiftCertificateCollectionViaGiftCertificateOrderItem":
					this.GiftCertificateCollectionViaGiftCertificateOrderItem.IsReadOnly = false;
					this.GiftCertificateCollectionViaGiftCertificateOrderItem.Add((GiftCertificateEntity)entity);
					this.GiftCertificateCollectionViaGiftCertificateOrderItem.IsReadOnly = true;
					break;
				case "LookupCollectionViaOrderDetail":
					this.LookupCollectionViaOrderDetail.IsReadOnly = false;
					this.LookupCollectionViaOrderDetail.Add((LookupEntity)entity);
					this.LookupCollectionViaOrderDetail.IsReadOnly = true;
					break;
				case "OrderCollectionViaOrderDetail":
					this.OrderCollectionViaOrderDetail.IsReadOnly = false;
					this.OrderCollectionViaOrderDetail.Add((OrderEntity)entity);
					this.OrderCollectionViaOrderDetail.IsReadOnly = true;
					break;
				case "ProductCollectionViaProductOrderItem":
					this.ProductCollectionViaProductOrderItem.IsReadOnly = false;
					this.ProductCollectionViaProductOrderItem.Add((ProductEntity)entity);
					this.ProductCollectionViaProductOrderItem.IsReadOnly = true;
					break;
				case "RefundCollectionViaRefundOrderItem":
					this.RefundCollectionViaRefundOrderItem.IsReadOnly = false;
					this.RefundCollectionViaRefundOrderItem.Add((RefundEntity)entity);
					this.RefundCollectionViaRefundOrderItem.IsReadOnly = true;
					break;
				case "ShippingOptionCollectionViaShippingOptionOrderItem":
					this.ShippingOptionCollectionViaShippingOptionOrderItem.IsReadOnly = false;
					this.ShippingOptionCollectionViaShippingOptionOrderItem.Add((ShippingOptionEntity)entity);
					this.ShippingOptionCollectionViaShippingOptionOrderItem.IsReadOnly = true;
					break;
				case "TestCollectionViaProspectActivity":
					this.TestCollectionViaProspectActivity.IsReadOnly = false;
					this.TestCollectionViaProspectActivity.Add((TestEntity)entity);
					this.TestCollectionViaProspectActivity.IsReadOnly = true;
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
			return OrderItemEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "EventPackageOrderItem":
					toReturn.Add(OrderItemEntity.Relations.EventPackageOrderItemEntityUsingOrderItemId);
					break;
				case "EventTestOrderItem":
					toReturn.Add(OrderItemEntity.Relations.EventTestOrderItemEntityUsingOrderItemId);
					break;
				case "GiftCertificateOrderItem":
					toReturn.Add(OrderItemEntity.Relations.GiftCertificateOrderItemEntityUsingOrderItemId);
					break;
				case "OrderDetail":
					toReturn.Add(OrderItemEntity.Relations.OrderDetailEntityUsingOrderItemId);
					break;
				case "ProductOrderItem":
					toReturn.Add(OrderItemEntity.Relations.ProductOrderItemEntityUsingOrderItemId);
					break;
				case "ProspectActivity":
					toReturn.Add(OrderItemEntity.Relations.ProspectActivityEntityUsingProspectId);
					break;
				case "RefundOrderItem":
					toReturn.Add(OrderItemEntity.Relations.RefundOrderItemEntityUsingOrderItemId);
					break;
				case "ShippingOptionOrderItem":
					toReturn.Add(OrderItemEntity.Relations.ShippingOptionOrderItemEntityUsingOrderItemId);
					break;
				case "EventPackageDetailsCollectionViaEventPackageOrderItem":
					toReturn.Add(OrderItemEntity.Relations.EventPackageOrderItemEntityUsingOrderItemId, "OrderItemEntity__", "EventPackageOrderItem_", JoinHint.None);
					toReturn.Add(EventPackageOrderItemEntity.Relations.EventPackageDetailsEntityUsingEventPackageId, "EventPackageOrderItem_", string.Empty, JoinHint.None);
					break;
				case "EventTestCollectionViaEventTestOrderItem":
					toReturn.Add(OrderItemEntity.Relations.EventTestOrderItemEntityUsingOrderItemId, "OrderItemEntity__", "EventTestOrderItem_", JoinHint.None);
					toReturn.Add(EventTestOrderItemEntity.Relations.EventTestEntityUsingEventTestId, "EventTestOrderItem_", string.Empty, JoinHint.None);
					break;
				case "GiftCertificateCollectionViaGiftCertificateOrderItem":
					toReturn.Add(OrderItemEntity.Relations.GiftCertificateOrderItemEntityUsingOrderItemId, "OrderItemEntity__", "GiftCertificateOrderItem_", JoinHint.None);
					toReturn.Add(GiftCertificateOrderItemEntity.Relations.GiftCertificateEntityUsingGiftCertificateId, "GiftCertificateOrderItem_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaOrderDetail":
					toReturn.Add(OrderItemEntity.Relations.OrderDetailEntityUsingOrderItemId, "OrderItemEntity__", "OrderDetail_", JoinHint.None);
					toReturn.Add(OrderDetailEntity.Relations.LookupEntityUsingSourceId, "OrderDetail_", string.Empty, JoinHint.None);
					break;
				case "OrderCollectionViaOrderDetail":
					toReturn.Add(OrderItemEntity.Relations.OrderDetailEntityUsingOrderItemId, "OrderItemEntity__", "OrderDetail_", JoinHint.None);
					toReturn.Add(OrderDetailEntity.Relations.OrderEntityUsingOrderId, "OrderDetail_", string.Empty, JoinHint.None);
					break;
				case "ProductCollectionViaProductOrderItem":
					toReturn.Add(OrderItemEntity.Relations.ProductOrderItemEntityUsingOrderItemId, "OrderItemEntity__", "ProductOrderItem_", JoinHint.None);
					toReturn.Add(ProductOrderItemEntity.Relations.ProductEntityUsingProductId, "ProductOrderItem_", string.Empty, JoinHint.None);
					break;
				case "RefundCollectionViaRefundOrderItem":
					toReturn.Add(OrderItemEntity.Relations.RefundOrderItemEntityUsingOrderItemId, "OrderItemEntity__", "RefundOrderItem_", JoinHint.None);
					toReturn.Add(RefundOrderItemEntity.Relations.RefundEntityUsingRefundId, "RefundOrderItem_", string.Empty, JoinHint.None);
					break;
				case "ShippingOptionCollectionViaShippingOptionOrderItem":
					toReturn.Add(OrderItemEntity.Relations.ShippingOptionOrderItemEntityUsingOrderItemId, "OrderItemEntity__", "ShippingOptionOrderItem_", JoinHint.None);
					toReturn.Add(ShippingOptionOrderItemEntity.Relations.ShippingOptionEntityUsingShippingOptionId, "ShippingOptionOrderItem_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaProspectActivity":
					toReturn.Add(OrderItemEntity.Relations.ProspectActivityEntityUsingProspectId, "OrderItemEntity__", "ProspectActivity_", JoinHint.None);
					toReturn.Add(ProspectActivityEntity.Relations.TestEntityUsingActivityId, "ProspectActivity_", string.Empty, JoinHint.None);
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

				case "EventPackageOrderItem":
					this.EventPackageOrderItem.Add((EventPackageOrderItemEntity)relatedEntity);
					break;
				case "EventTestOrderItem":
					this.EventTestOrderItem.Add((EventTestOrderItemEntity)relatedEntity);
					break;
				case "GiftCertificateOrderItem":
					this.GiftCertificateOrderItem.Add((GiftCertificateOrderItemEntity)relatedEntity);
					break;
				case "OrderDetail":
					this.OrderDetail.Add((OrderDetailEntity)relatedEntity);
					break;
				case "ProductOrderItem":
					this.ProductOrderItem.Add((ProductOrderItemEntity)relatedEntity);
					break;
				case "ProspectActivity":
					this.ProspectActivity.Add((ProspectActivityEntity)relatedEntity);
					break;
				case "RefundOrderItem":
					this.RefundOrderItem.Add((RefundOrderItemEntity)relatedEntity);
					break;
				case "ShippingOptionOrderItem":
					this.ShippingOptionOrderItem.Add((ShippingOptionOrderItemEntity)relatedEntity);
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

				case "EventPackageOrderItem":
					base.PerformRelatedEntityRemoval(this.EventPackageOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventTestOrderItem":
					base.PerformRelatedEntityRemoval(this.EventTestOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "GiftCertificateOrderItem":
					base.PerformRelatedEntityRemoval(this.GiftCertificateOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "OrderDetail":
					base.PerformRelatedEntityRemoval(this.OrderDetail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProductOrderItem":
					base.PerformRelatedEntityRemoval(this.ProductOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectActivity":
					base.PerformRelatedEntityRemoval(this.ProspectActivity, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RefundOrderItem":
					base.PerformRelatedEntityRemoval(this.RefundOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ShippingOptionOrderItem":
					base.PerformRelatedEntityRemoval(this.ShippingOptionOrderItem, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventPackageOrderItem);
			toReturn.Add(this.EventTestOrderItem);
			toReturn.Add(this.GiftCertificateOrderItem);
			toReturn.Add(this.OrderDetail);
			toReturn.Add(this.ProductOrderItem);
			toReturn.Add(this.ProspectActivity);
			toReturn.Add(this.RefundOrderItem);
			toReturn.Add(this.ShippingOptionOrderItem);

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
				info.AddValue("_eventPackageOrderItem", ((_eventPackageOrderItem!=null) && (_eventPackageOrderItem.Count>0) && !this.MarkedForDeletion)?_eventPackageOrderItem:null);
				info.AddValue("_eventTestOrderItem", ((_eventTestOrderItem!=null) && (_eventTestOrderItem.Count>0) && !this.MarkedForDeletion)?_eventTestOrderItem:null);
				info.AddValue("_giftCertificateOrderItem", ((_giftCertificateOrderItem!=null) && (_giftCertificateOrderItem.Count>0) && !this.MarkedForDeletion)?_giftCertificateOrderItem:null);
				info.AddValue("_orderDetail", ((_orderDetail!=null) && (_orderDetail.Count>0) && !this.MarkedForDeletion)?_orderDetail:null);
				info.AddValue("_productOrderItem", ((_productOrderItem!=null) && (_productOrderItem.Count>0) && !this.MarkedForDeletion)?_productOrderItem:null);
				info.AddValue("_prospectActivity", ((_prospectActivity!=null) && (_prospectActivity.Count>0) && !this.MarkedForDeletion)?_prospectActivity:null);
				info.AddValue("_refundOrderItem", ((_refundOrderItem!=null) && (_refundOrderItem.Count>0) && !this.MarkedForDeletion)?_refundOrderItem:null);
				info.AddValue("_shippingOptionOrderItem", ((_shippingOptionOrderItem!=null) && (_shippingOptionOrderItem.Count>0) && !this.MarkedForDeletion)?_shippingOptionOrderItem:null);
				info.AddValue("_eventPackageDetailsCollectionViaEventPackageOrderItem", ((_eventPackageDetailsCollectionViaEventPackageOrderItem!=null) && (_eventPackageDetailsCollectionViaEventPackageOrderItem.Count>0) && !this.MarkedForDeletion)?_eventPackageDetailsCollectionViaEventPackageOrderItem:null);
				info.AddValue("_eventTestCollectionViaEventTestOrderItem", ((_eventTestCollectionViaEventTestOrderItem!=null) && (_eventTestCollectionViaEventTestOrderItem.Count>0) && !this.MarkedForDeletion)?_eventTestCollectionViaEventTestOrderItem:null);
				info.AddValue("_giftCertificateCollectionViaGiftCertificateOrderItem", ((_giftCertificateCollectionViaGiftCertificateOrderItem!=null) && (_giftCertificateCollectionViaGiftCertificateOrderItem.Count>0) && !this.MarkedForDeletion)?_giftCertificateCollectionViaGiftCertificateOrderItem:null);
				info.AddValue("_lookupCollectionViaOrderDetail", ((_lookupCollectionViaOrderDetail!=null) && (_lookupCollectionViaOrderDetail.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaOrderDetail:null);
				info.AddValue("_orderCollectionViaOrderDetail", ((_orderCollectionViaOrderDetail!=null) && (_orderCollectionViaOrderDetail.Count>0) && !this.MarkedForDeletion)?_orderCollectionViaOrderDetail:null);
				info.AddValue("_productCollectionViaProductOrderItem", ((_productCollectionViaProductOrderItem!=null) && (_productCollectionViaProductOrderItem.Count>0) && !this.MarkedForDeletion)?_productCollectionViaProductOrderItem:null);
				info.AddValue("_refundCollectionViaRefundOrderItem", ((_refundCollectionViaRefundOrderItem!=null) && (_refundCollectionViaRefundOrderItem.Count>0) && !this.MarkedForDeletion)?_refundCollectionViaRefundOrderItem:null);
				info.AddValue("_shippingOptionCollectionViaShippingOptionOrderItem", ((_shippingOptionCollectionViaShippingOptionOrderItem!=null) && (_shippingOptionCollectionViaShippingOptionOrderItem.Count>0) && !this.MarkedForDeletion)?_shippingOptionCollectionViaShippingOptionOrderItem:null);
				info.AddValue("_testCollectionViaProspectActivity", ((_testCollectionViaProspectActivity!=null) && (_testCollectionViaProspectActivity.Count>0) && !this.MarkedForDeletion)?_testCollectionViaProspectActivity:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OrderItemFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OrderItemFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OrderItemRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageOrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTestOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTestOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestOrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GiftCertificateOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificateOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GiftCertificateOrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderDetailFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProductOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProductOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductOrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectActivity' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectActivityFields.ProspectId, null, ComparisonOperator.Equal, this.OrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RefundOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundOrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingOptionOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingOptionOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionOrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageDetailsCollectionViaEventPackageOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventPackageDetailsCollectionViaEventPackageOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId, "OrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTestCollectionViaEventTestOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventTestCollectionViaEventTestOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId, "OrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GiftCertificate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificateCollectionViaGiftCertificateOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("GiftCertificateCollectionViaGiftCertificateOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId, "OrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaOrderDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId, "OrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Order' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderCollectionViaOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderCollectionViaOrderDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId, "OrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Product' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProductCollectionViaProductOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProductCollectionViaProductOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId, "OrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Refund' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundCollectionViaRefundOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RefundCollectionViaRefundOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId, "OrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingOptionCollectionViaShippingOptionOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ShippingOptionCollectionViaShippingOptionOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId, "OrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaProspectActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaProspectActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId, "OrderItemEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.OrderItemEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventPackageOrderItem);
			collectionsQueue.Enqueue(this._eventTestOrderItem);
			collectionsQueue.Enqueue(this._giftCertificateOrderItem);
			collectionsQueue.Enqueue(this._orderDetail);
			collectionsQueue.Enqueue(this._productOrderItem);
			collectionsQueue.Enqueue(this._prospectActivity);
			collectionsQueue.Enqueue(this._refundOrderItem);
			collectionsQueue.Enqueue(this._shippingOptionOrderItem);
			collectionsQueue.Enqueue(this._eventPackageDetailsCollectionViaEventPackageOrderItem);
			collectionsQueue.Enqueue(this._eventTestCollectionViaEventTestOrderItem);
			collectionsQueue.Enqueue(this._giftCertificateCollectionViaGiftCertificateOrderItem);
			collectionsQueue.Enqueue(this._lookupCollectionViaOrderDetail);
			collectionsQueue.Enqueue(this._orderCollectionViaOrderDetail);
			collectionsQueue.Enqueue(this._productCollectionViaProductOrderItem);
			collectionsQueue.Enqueue(this._refundCollectionViaRefundOrderItem);
			collectionsQueue.Enqueue(this._shippingOptionCollectionViaShippingOptionOrderItem);
			collectionsQueue.Enqueue(this._testCollectionViaProspectActivity);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventPackageOrderItem = (EntityCollection<EventPackageOrderItemEntity>) collectionsQueue.Dequeue();
			this._eventTestOrderItem = (EntityCollection<EventTestOrderItemEntity>) collectionsQueue.Dequeue();
			this._giftCertificateOrderItem = (EntityCollection<GiftCertificateOrderItemEntity>) collectionsQueue.Dequeue();
			this._orderDetail = (EntityCollection<OrderDetailEntity>) collectionsQueue.Dequeue();
			this._productOrderItem = (EntityCollection<ProductOrderItemEntity>) collectionsQueue.Dequeue();
			this._prospectActivity = (EntityCollection<ProspectActivityEntity>) collectionsQueue.Dequeue();
			this._refundOrderItem = (EntityCollection<RefundOrderItemEntity>) collectionsQueue.Dequeue();
			this._shippingOptionOrderItem = (EntityCollection<ShippingOptionOrderItemEntity>) collectionsQueue.Dequeue();
			this._eventPackageDetailsCollectionViaEventPackageOrderItem = (EntityCollection<EventPackageDetailsEntity>) collectionsQueue.Dequeue();
			this._eventTestCollectionViaEventTestOrderItem = (EntityCollection<EventTestEntity>) collectionsQueue.Dequeue();
			this._giftCertificateCollectionViaGiftCertificateOrderItem = (EntityCollection<GiftCertificateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaOrderDetail = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._orderCollectionViaOrderDetail = (EntityCollection<OrderEntity>) collectionsQueue.Dequeue();
			this._productCollectionViaProductOrderItem = (EntityCollection<ProductEntity>) collectionsQueue.Dequeue();
			this._refundCollectionViaRefundOrderItem = (EntityCollection<RefundEntity>) collectionsQueue.Dequeue();
			this._shippingOptionCollectionViaShippingOptionOrderItem = (EntityCollection<ShippingOptionEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaProspectActivity = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventPackageOrderItem != null)
			{
				return true;
			}
			if (this._eventTestOrderItem != null)
			{
				return true;
			}
			if (this._giftCertificateOrderItem != null)
			{
				return true;
			}
			if (this._orderDetail != null)
			{
				return true;
			}
			if (this._productOrderItem != null)
			{
				return true;
			}
			if (this._prospectActivity != null)
			{
				return true;
			}
			if (this._refundOrderItem != null)
			{
				return true;
			}
			if (this._shippingOptionOrderItem != null)
			{
				return true;
			}
			if (this._eventPackageDetailsCollectionViaEventPackageOrderItem != null)
			{
				return true;
			}
			if (this._eventTestCollectionViaEventTestOrderItem != null)
			{
				return true;
			}
			if (this._giftCertificateCollectionViaGiftCertificateOrderItem != null)
			{
				return true;
			}
			if (this._lookupCollectionViaOrderDetail != null)
			{
				return true;
			}
			if (this._orderCollectionViaOrderDetail != null)
			{
				return true;
			}
			if (this._productCollectionViaProductOrderItem != null)
			{
				return true;
			}
			if (this._refundCollectionViaRefundOrderItem != null)
			{
				return true;
			}
			if (this._shippingOptionCollectionViaShippingOptionOrderItem != null)
			{
				return true;
			}
			if (this._testCollectionViaProspectActivity != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GiftCertificateOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProductOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectActivityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingOptionOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundEntityFactory))) : null);
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

			toReturn.Add("EventPackageOrderItem", _eventPackageOrderItem);
			toReturn.Add("EventTestOrderItem", _eventTestOrderItem);
			toReturn.Add("GiftCertificateOrderItem", _giftCertificateOrderItem);
			toReturn.Add("OrderDetail", _orderDetail);
			toReturn.Add("ProductOrderItem", _productOrderItem);
			toReturn.Add("ProspectActivity", _prospectActivity);
			toReturn.Add("RefundOrderItem", _refundOrderItem);
			toReturn.Add("ShippingOptionOrderItem", _shippingOptionOrderItem);
			toReturn.Add("EventPackageDetailsCollectionViaEventPackageOrderItem", _eventPackageDetailsCollectionViaEventPackageOrderItem);
			toReturn.Add("EventTestCollectionViaEventTestOrderItem", _eventTestCollectionViaEventTestOrderItem);
			toReturn.Add("GiftCertificateCollectionViaGiftCertificateOrderItem", _giftCertificateCollectionViaGiftCertificateOrderItem);
			toReturn.Add("LookupCollectionViaOrderDetail", _lookupCollectionViaOrderDetail);
			toReturn.Add("OrderCollectionViaOrderDetail", _orderCollectionViaOrderDetail);
			toReturn.Add("ProductCollectionViaProductOrderItem", _productCollectionViaProductOrderItem);
			toReturn.Add("RefundCollectionViaRefundOrderItem", _refundCollectionViaRefundOrderItem);
			toReturn.Add("ShippingOptionCollectionViaShippingOptionOrderItem", _shippingOptionCollectionViaShippingOptionOrderItem);
			toReturn.Add("TestCollectionViaProspectActivity", _testCollectionViaProspectActivity);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventPackageOrderItem!=null)
			{
				_eventPackageOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_eventTestOrderItem!=null)
			{
				_eventTestOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_giftCertificateOrderItem!=null)
			{
				_giftCertificateOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_orderDetail!=null)
			{
				_orderDetail.ActiveContext = base.ActiveContext;
			}
			if(_productOrderItem!=null)
			{
				_productOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_prospectActivity!=null)
			{
				_prospectActivity.ActiveContext = base.ActiveContext;
			}
			if(_refundOrderItem!=null)
			{
				_refundOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_shippingOptionOrderItem!=null)
			{
				_shippingOptionOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageDetailsCollectionViaEventPackageOrderItem!=null)
			{
				_eventPackageDetailsCollectionViaEventPackageOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_eventTestCollectionViaEventTestOrderItem!=null)
			{
				_eventTestCollectionViaEventTestOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_giftCertificateCollectionViaGiftCertificateOrderItem!=null)
			{
				_giftCertificateCollectionViaGiftCertificateOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaOrderDetail!=null)
			{
				_lookupCollectionViaOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_orderCollectionViaOrderDetail!=null)
			{
				_orderCollectionViaOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_productCollectionViaProductOrderItem!=null)
			{
				_productCollectionViaProductOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_refundCollectionViaRefundOrderItem!=null)
			{
				_refundCollectionViaRefundOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_shippingOptionCollectionViaShippingOptionOrderItem!=null)
			{
				_shippingOptionCollectionViaShippingOptionOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaProspectActivity!=null)
			{
				_testCollectionViaProspectActivity.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventPackageOrderItem = null;
			_eventTestOrderItem = null;
			_giftCertificateOrderItem = null;
			_orderDetail = null;
			_productOrderItem = null;
			_prospectActivity = null;
			_refundOrderItem = null;
			_shippingOptionOrderItem = null;
			_eventPackageDetailsCollectionViaEventPackageOrderItem = null;
			_eventTestCollectionViaEventTestOrderItem = null;
			_giftCertificateCollectionViaGiftCertificateOrderItem = null;
			_lookupCollectionViaOrderDetail = null;
			_orderCollectionViaOrderDetail = null;
			_productCollectionViaProductOrderItem = null;
			_refundCollectionViaRefundOrderItem = null;
			_shippingOptionCollectionViaShippingOptionOrderItem = null;
			_testCollectionViaProspectActivity = null;


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

			_fieldsCustomProperties.Add("OrderItemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Type", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OrderItemEntity</param>
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
		public  static OrderItemRelations Relations
		{
			get	{ return new OrderItemRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPackageOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPackageOrderItem")[0], (int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.EventPackageOrderItemEntity, 0, null, null, null, null, "EventPackageOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTestOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTestOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventTestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventTestOrderItem")[0], (int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.EventTestOrderItemEntity, 0, null, null, null, null, "EventTestOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificateOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificateOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GiftCertificateOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("GiftCertificateOrderItem")[0], (int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.GiftCertificateOrderItemEntity, 0, null, null, null, null, "GiftCertificateOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrderDetail")[0], (int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.OrderDetailEntity, 0, null, null, null, null, "OrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProductOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProductOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProductOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProductOrderItem")[0], (int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.ProductOrderItemEntity, 0, null, null, null, null, "ProductOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectActivity' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectActivity
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectActivityEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectActivity")[0], (int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.ProspectActivityEntity, 0, null, null, null, null, "ProspectActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RefundOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("RefundOrderItem")[0], (int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.RefundOrderItemEntity, 0, null, null, null, null, "RefundOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingOptionOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingOptionOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ShippingOptionOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("ShippingOptionOrderItem")[0], (int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.ShippingOptionOrderItemEntity, 0, null, null, null, null, "ShippingOptionOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageDetailsCollectionViaEventPackageOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = OrderItemEntity.Relations.EventPackageOrderItemEntityUsingOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.EventPackageDetailsEntity, 0, null, null, GetRelationsForField("EventPackageDetailsCollectionViaEventPackageOrderItem"), null, "EventPackageDetailsCollectionViaEventPackageOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTestCollectionViaEventTestOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = OrderItemEntity.Relations.EventTestOrderItemEntityUsingOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "EventTestOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.EventTestEntity, 0, null, null, GetRelationsForField("EventTestCollectionViaEventTestOrderItem"), null, "EventTestCollectionViaEventTestOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificateCollectionViaGiftCertificateOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = OrderItemEntity.Relations.GiftCertificateOrderItemEntityUsingOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "GiftCertificateOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.GiftCertificateEntity, 0, null, null, GetRelationsForField("GiftCertificateCollectionViaGiftCertificateOrderItem"), null, "GiftCertificateCollectionViaGiftCertificateOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaOrderDetail
		{
			get
			{
				IEntityRelation intermediateRelation = OrderItemEntity.Relations.OrderDetailEntityUsingOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "OrderDetail_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaOrderDetail"), null, "LookupCollectionViaOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Order' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderCollectionViaOrderDetail
		{
			get
			{
				IEntityRelation intermediateRelation = OrderItemEntity.Relations.OrderDetailEntityUsingOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "OrderDetail_");
				return new PrefetchPathElement2(new EntityCollection<OrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.OrderEntity, 0, null, null, GetRelationsForField("OrderCollectionViaOrderDetail"), null, "OrderCollectionViaOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Product' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProductCollectionViaProductOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = OrderItemEntity.Relations.ProductOrderItemEntityUsingOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "ProductOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<ProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.ProductEntity, 0, null, null, GetRelationsForField("ProductCollectionViaProductOrderItem"), null, "ProductCollectionViaProductOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Refund' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundCollectionViaRefundOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = OrderItemEntity.Relations.RefundOrderItemEntityUsingOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "RefundOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<RefundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.RefundEntity, 0, null, null, GetRelationsForField("RefundCollectionViaRefundOrderItem"), null, "RefundCollectionViaRefundOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingOptionCollectionViaShippingOptionOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = OrderItemEntity.Relations.ShippingOptionOrderItemEntityUsingOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "ShippingOptionOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.ShippingOptionEntity, 0, null, null, GetRelationsForField("ShippingOptionCollectionViaShippingOptionOrderItem"), null, "ShippingOptionCollectionViaShippingOptionOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaProspectActivity
		{
			get
			{
				IEntityRelation intermediateRelation = OrderItemEntity.Relations.ProspectActivityEntityUsingProspectId;
				intermediateRelation.SetAliases(string.Empty, "ProspectActivity_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderItemEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaProspectActivity"), null, "TestCollectionViaProspectActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OrderItemEntity.CustomProperties;}
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
			get { return OrderItemEntity.FieldsCustomProperties;}
		}

		/// <summary> The OrderItemId property of the Entity OrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderItem"."OrderItemID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 OrderItemId
		{
			get { return (System.Int64)GetValue((int)OrderItemFieldIndex.OrderItemId, true); }
			set	{ SetValue((int)OrderItemFieldIndex.OrderItemId, value); }
		}

		/// <summary> The Type property of the Entity OrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderItem"."Type"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 Type
		{
			get { return (System.Int16)GetValue((int)OrderItemFieldIndex.Type, true); }
			set	{ SetValue((int)OrderItemFieldIndex.Type, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageOrderItemEntity))]
		public virtual EntityCollection<EventPackageOrderItemEntity> EventPackageOrderItem
		{
			get
			{
				if(_eventPackageOrderItem==null)
				{
					_eventPackageOrderItem = new EntityCollection<EventPackageOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageOrderItemEntityFactory)));
					_eventPackageOrderItem.SetContainingEntityInfo(this, "OrderItem");
				}
				return _eventPackageOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTestOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTestOrderItemEntity))]
		public virtual EntityCollection<EventTestOrderItemEntity> EventTestOrderItem
		{
			get
			{
				if(_eventTestOrderItem==null)
				{
					_eventTestOrderItem = new EntityCollection<EventTestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestOrderItemEntityFactory)));
					_eventTestOrderItem.SetContainingEntityInfo(this, "OrderItem");
				}
				return _eventTestOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GiftCertificateOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GiftCertificateOrderItemEntity))]
		public virtual EntityCollection<GiftCertificateOrderItemEntity> GiftCertificateOrderItem
		{
			get
			{
				if(_giftCertificateOrderItem==null)
				{
					_giftCertificateOrderItem = new EntityCollection<GiftCertificateOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateOrderItemEntityFactory)));
					_giftCertificateOrderItem.SetContainingEntityInfo(this, "OrderItem");
				}
				return _giftCertificateOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderDetailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderDetailEntity))]
		public virtual EntityCollection<OrderDetailEntity> OrderDetail
		{
			get
			{
				if(_orderDetail==null)
				{
					_orderDetail = new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory)));
					_orderDetail.SetContainingEntityInfo(this, "OrderItem");
				}
				return _orderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProductOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProductOrderItemEntity))]
		public virtual EntityCollection<ProductOrderItemEntity> ProductOrderItem
		{
			get
			{
				if(_productOrderItem==null)
				{
					_productOrderItem = new EntityCollection<ProductOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductOrderItemEntityFactory)));
					_productOrderItem.SetContainingEntityInfo(this, "OrderItem");
				}
				return _productOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectActivityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectActivityEntity))]
		public virtual EntityCollection<ProspectActivityEntity> ProspectActivity
		{
			get
			{
				if(_prospectActivity==null)
				{
					_prospectActivity = new EntityCollection<ProspectActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectActivityEntityFactory)));
					_prospectActivity.SetContainingEntityInfo(this, "OrderItem");
				}
				return _prospectActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RefundOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RefundOrderItemEntity))]
		public virtual EntityCollection<RefundOrderItemEntity> RefundOrderItem
		{
			get
			{
				if(_refundOrderItem==null)
				{
					_refundOrderItem = new EntityCollection<RefundOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundOrderItemEntityFactory)));
					_refundOrderItem.SetContainingEntityInfo(this, "OrderItem");
				}
				return _refundOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingOptionOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingOptionOrderItemEntity))]
		public virtual EntityCollection<ShippingOptionOrderItemEntity> ShippingOptionOrderItem
		{
			get
			{
				if(_shippingOptionOrderItem==null)
				{
					_shippingOptionOrderItem = new EntityCollection<ShippingOptionOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionOrderItemEntityFactory)));
					_shippingOptionOrderItem.SetContainingEntityInfo(this, "OrderItem");
				}
				return _shippingOptionOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageDetailsEntity))]
		public virtual EntityCollection<EventPackageDetailsEntity> EventPackageDetailsCollectionViaEventPackageOrderItem
		{
			get
			{
				if(_eventPackageDetailsCollectionViaEventPackageOrderItem==null)
				{
					_eventPackageDetailsCollectionViaEventPackageOrderItem = new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory)));
					_eventPackageDetailsCollectionViaEventPackageOrderItem.IsReadOnly=true;
				}
				return _eventPackageDetailsCollectionViaEventPackageOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTestEntity))]
		public virtual EntityCollection<EventTestEntity> EventTestCollectionViaEventTestOrderItem
		{
			get
			{
				if(_eventTestCollectionViaEventTestOrderItem==null)
				{
					_eventTestCollectionViaEventTestOrderItem = new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory)));
					_eventTestCollectionViaEventTestOrderItem.IsReadOnly=true;
				}
				return _eventTestCollectionViaEventTestOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GiftCertificateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GiftCertificateEntity))]
		public virtual EntityCollection<GiftCertificateEntity> GiftCertificateCollectionViaGiftCertificateOrderItem
		{
			get
			{
				if(_giftCertificateCollectionViaGiftCertificateOrderItem==null)
				{
					_giftCertificateCollectionViaGiftCertificateOrderItem = new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory)));
					_giftCertificateCollectionViaGiftCertificateOrderItem.IsReadOnly=true;
				}
				return _giftCertificateCollectionViaGiftCertificateOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaOrderDetail
		{
			get
			{
				if(_lookupCollectionViaOrderDetail==null)
				{
					_lookupCollectionViaOrderDetail = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaOrderDetail.IsReadOnly=true;
				}
				return _lookupCollectionViaOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderEntity))]
		public virtual EntityCollection<OrderEntity> OrderCollectionViaOrderDetail
		{
			get
			{
				if(_orderCollectionViaOrderDetail==null)
				{
					_orderCollectionViaOrderDetail = new EntityCollection<OrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderEntityFactory)));
					_orderCollectionViaOrderDetail.IsReadOnly=true;
				}
				return _orderCollectionViaOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProductEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProductEntity))]
		public virtual EntityCollection<ProductEntity> ProductCollectionViaProductOrderItem
		{
			get
			{
				if(_productCollectionViaProductOrderItem==null)
				{
					_productCollectionViaProductOrderItem = new EntityCollection<ProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory)));
					_productCollectionViaProductOrderItem.IsReadOnly=true;
				}
				return _productCollectionViaProductOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RefundEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RefundEntity))]
		public virtual EntityCollection<RefundEntity> RefundCollectionViaRefundOrderItem
		{
			get
			{
				if(_refundCollectionViaRefundOrderItem==null)
				{
					_refundCollectionViaRefundOrderItem = new EntityCollection<RefundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundEntityFactory)));
					_refundCollectionViaRefundOrderItem.IsReadOnly=true;
				}
				return _refundCollectionViaRefundOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingOptionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingOptionEntity))]
		public virtual EntityCollection<ShippingOptionEntity> ShippingOptionCollectionViaShippingOptionOrderItem
		{
			get
			{
				if(_shippingOptionCollectionViaShippingOptionOrderItem==null)
				{
					_shippingOptionCollectionViaShippingOptionOrderItem = new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory)));
					_shippingOptionCollectionViaShippingOptionOrderItem.IsReadOnly=true;
				}
				return _shippingOptionCollectionViaShippingOptionOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaProspectActivity
		{
			get
			{
				if(_testCollectionViaProspectActivity==null)
				{
					_testCollectionViaProspectActivity = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaProspectActivity.IsReadOnly=true;
				}
				return _testCollectionViaProspectActivity;
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
			get { return (int)Falcon.Data.EntityType.OrderItemEntity; }
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
