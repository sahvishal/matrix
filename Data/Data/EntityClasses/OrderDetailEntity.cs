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
	/// Entity class which represents the entity 'OrderDetail'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OrderDetailEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventCustomerOrderDetailEntity> _eventCustomerOrderDetail;
		private EntityCollection<ShippingDetailOrderDetailEntity> _shippingDetailOrderDetail;
		private EntityCollection<SourceCodeOrderDetailEntity> _sourceCodeOrderDetail;
		private EntityCollection<TestOrderItemEntity> _testOrderItem;
		private EntityCollection<CouponsEntity> _couponsCollectionViaSourceCodeOrderDetail;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerOrderDetail;
		private EntityCollection<PaymentEntity> _paymentCollectionViaTestOrderItem;
		private EntityCollection<ShippingDetailEntity> _shippingDetailCollectionViaShippingDetailOrderDetail;
		private LookupEntity _lookup;
		private OrderEntity _order;
		private OrderItemEntity _orderItem;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Order</summary>
			public static readonly string Order = "Order";
			/// <summary>Member name OrderItem</summary>
			public static readonly string OrderItem = "OrderItem";
			/// <summary>Member name EventCustomerOrderDetail</summary>
			public static readonly string EventCustomerOrderDetail = "EventCustomerOrderDetail";
			/// <summary>Member name ShippingDetailOrderDetail</summary>
			public static readonly string ShippingDetailOrderDetail = "ShippingDetailOrderDetail";
			/// <summary>Member name SourceCodeOrderDetail</summary>
			public static readonly string SourceCodeOrderDetail = "SourceCodeOrderDetail";
			/// <summary>Member name TestOrderItem</summary>
			public static readonly string TestOrderItem = "TestOrderItem";
			/// <summary>Member name CouponsCollectionViaSourceCodeOrderDetail</summary>
			public static readonly string CouponsCollectionViaSourceCodeOrderDetail = "CouponsCollectionViaSourceCodeOrderDetail";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerOrderDetail</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerOrderDetail = "EventCustomersCollectionViaEventCustomerOrderDetail";
			/// <summary>Member name PaymentCollectionViaTestOrderItem</summary>
			public static readonly string PaymentCollectionViaTestOrderItem = "PaymentCollectionViaTestOrderItem";
			/// <summary>Member name ShippingDetailCollectionViaShippingDetailOrderDetail</summary>
			public static readonly string ShippingDetailCollectionViaShippingDetailOrderDetail = "ShippingDetailCollectionViaShippingDetailOrderDetail";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OrderDetailEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public OrderDetailEntity():base("OrderDetailEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OrderDetailEntity(IEntityFields2 fields):base("OrderDetailEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OrderDetailEntity</param>
		public OrderDetailEntity(IValidator validator):base("OrderDetailEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="orderDetailId">PK value for OrderDetail which data should be fetched into this OrderDetail object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrderDetailEntity(System.Int64 orderDetailId):base("OrderDetailEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OrderDetailId = orderDetailId;
		}

		/// <summary> CTor</summary>
		/// <param name="orderDetailId">PK value for OrderDetail which data should be fetched into this OrderDetail object</param>
		/// <param name="validator">The custom validator object for this OrderDetailEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrderDetailEntity(System.Int64 orderDetailId, IValidator validator):base("OrderDetailEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OrderDetailId = orderDetailId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected OrderDetailEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventCustomerOrderDetail = (EntityCollection<EventCustomerOrderDetailEntity>)info.GetValue("_eventCustomerOrderDetail", typeof(EntityCollection<EventCustomerOrderDetailEntity>));
				_shippingDetailOrderDetail = (EntityCollection<ShippingDetailOrderDetailEntity>)info.GetValue("_shippingDetailOrderDetail", typeof(EntityCollection<ShippingDetailOrderDetailEntity>));
				_sourceCodeOrderDetail = (EntityCollection<SourceCodeOrderDetailEntity>)info.GetValue("_sourceCodeOrderDetail", typeof(EntityCollection<SourceCodeOrderDetailEntity>));
				_testOrderItem = (EntityCollection<TestOrderItemEntity>)info.GetValue("_testOrderItem", typeof(EntityCollection<TestOrderItemEntity>));
				_couponsCollectionViaSourceCodeOrderDetail = (EntityCollection<CouponsEntity>)info.GetValue("_couponsCollectionViaSourceCodeOrderDetail", typeof(EntityCollection<CouponsEntity>));
				_eventCustomersCollectionViaEventCustomerOrderDetail = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerOrderDetail", typeof(EntityCollection<EventCustomersEntity>));
				_paymentCollectionViaTestOrderItem = (EntityCollection<PaymentEntity>)info.GetValue("_paymentCollectionViaTestOrderItem", typeof(EntityCollection<PaymentEntity>));
				_shippingDetailCollectionViaShippingDetailOrderDetail = (EntityCollection<ShippingDetailEntity>)info.GetValue("_shippingDetailCollectionViaShippingDetailOrderDetail", typeof(EntityCollection<ShippingDetailEntity>));
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_order = (OrderEntity)info.GetValue("_order", typeof(OrderEntity));
				if(_order!=null)
				{
					_order.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_orderItem = (OrderItemEntity)info.GetValue("_orderItem", typeof(OrderItemEntity));
				if(_orderItem!=null)
				{
					_orderItem.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((OrderDetailFieldIndex)fieldIndex)
			{
				case OrderDetailFieldIndex.OrderId:
					DesetupSyncOrder(true, false);
					break;
				case OrderDetailFieldIndex.OrderItemId:
					DesetupSyncOrderItem(true, false);
					break;
				case OrderDetailFieldIndex.SourceId:
					DesetupSyncLookup(true, false);
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
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Order":
					this.Order = (OrderEntity)entity;
					break;
				case "OrderItem":
					this.OrderItem = (OrderItemEntity)entity;
					break;
				case "EventCustomerOrderDetail":
					this.EventCustomerOrderDetail.Add((EventCustomerOrderDetailEntity)entity);
					break;
				case "ShippingDetailOrderDetail":
					this.ShippingDetailOrderDetail.Add((ShippingDetailOrderDetailEntity)entity);
					break;
				case "SourceCodeOrderDetail":
					this.SourceCodeOrderDetail.Add((SourceCodeOrderDetailEntity)entity);
					break;
				case "TestOrderItem":
					this.TestOrderItem.Add((TestOrderItemEntity)entity);
					break;
				case "CouponsCollectionViaSourceCodeOrderDetail":
					this.CouponsCollectionViaSourceCodeOrderDetail.IsReadOnly = false;
					this.CouponsCollectionViaSourceCodeOrderDetail.Add((CouponsEntity)entity);
					this.CouponsCollectionViaSourceCodeOrderDetail.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerOrderDetail":
					this.EventCustomersCollectionViaEventCustomerOrderDetail.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerOrderDetail.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerOrderDetail.IsReadOnly = true;
					break;
				case "PaymentCollectionViaTestOrderItem":
					this.PaymentCollectionViaTestOrderItem.IsReadOnly = false;
					this.PaymentCollectionViaTestOrderItem.Add((PaymentEntity)entity);
					this.PaymentCollectionViaTestOrderItem.IsReadOnly = true;
					break;
				case "ShippingDetailCollectionViaShippingDetailOrderDetail":
					this.ShippingDetailCollectionViaShippingDetailOrderDetail.IsReadOnly = false;
					this.ShippingDetailCollectionViaShippingDetailOrderDetail.Add((ShippingDetailEntity)entity);
					this.ShippingDetailCollectionViaShippingDetailOrderDetail.IsReadOnly = true;
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
			return OrderDetailEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Lookup":
					toReturn.Add(OrderDetailEntity.Relations.LookupEntityUsingSourceId);
					break;
				case "Order":
					toReturn.Add(OrderDetailEntity.Relations.OrderEntityUsingOrderId);
					break;
				case "OrderItem":
					toReturn.Add(OrderDetailEntity.Relations.OrderItemEntityUsingOrderItemId);
					break;
				case "EventCustomerOrderDetail":
					toReturn.Add(OrderDetailEntity.Relations.EventCustomerOrderDetailEntityUsingOrderDetailId);
					break;
				case "ShippingDetailOrderDetail":
					toReturn.Add(OrderDetailEntity.Relations.ShippingDetailOrderDetailEntityUsingOrderDetailId);
					break;
				case "SourceCodeOrderDetail":
					toReturn.Add(OrderDetailEntity.Relations.SourceCodeOrderDetailEntityUsingOrderDetailId);
					break;
				case "TestOrderItem":
					toReturn.Add(OrderDetailEntity.Relations.TestOrderItemEntityUsingOrderItemId);
					break;
				case "CouponsCollectionViaSourceCodeOrderDetail":
					toReturn.Add(OrderDetailEntity.Relations.SourceCodeOrderDetailEntityUsingOrderDetailId, "OrderDetailEntity__", "SourceCodeOrderDetail_", JoinHint.None);
					toReturn.Add(SourceCodeOrderDetailEntity.Relations.CouponsEntityUsingSourceCodeId, "SourceCodeOrderDetail_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerOrderDetail":
					toReturn.Add(OrderDetailEntity.Relations.EventCustomerOrderDetailEntityUsingOrderDetailId, "OrderDetailEntity__", "EventCustomerOrderDetail_", JoinHint.None);
					toReturn.Add(EventCustomerOrderDetailEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerOrderDetail_", string.Empty, JoinHint.None);
					break;
				case "PaymentCollectionViaTestOrderItem":
					toReturn.Add(OrderDetailEntity.Relations.TestOrderItemEntityUsingOrderItemId, "OrderDetailEntity__", "TestOrderItem_", JoinHint.None);
					toReturn.Add(TestOrderItemEntity.Relations.PaymentEntityUsingTestId, "TestOrderItem_", string.Empty, JoinHint.None);
					break;
				case "ShippingDetailCollectionViaShippingDetailOrderDetail":
					toReturn.Add(OrderDetailEntity.Relations.ShippingDetailOrderDetailEntityUsingOrderDetailId, "OrderDetailEntity__", "ShippingDetailOrderDetail_", JoinHint.None);
					toReturn.Add(ShippingDetailOrderDetailEntity.Relations.ShippingDetailEntityUsingShippingDetailId, "ShippingDetailOrderDetail_", string.Empty, JoinHint.None);
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
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "Order":
					SetupSyncOrder(relatedEntity);
					break;
				case "OrderItem":
					SetupSyncOrderItem(relatedEntity);
					break;
				case "EventCustomerOrderDetail":
					this.EventCustomerOrderDetail.Add((EventCustomerOrderDetailEntity)relatedEntity);
					break;
				case "ShippingDetailOrderDetail":
					this.ShippingDetailOrderDetail.Add((ShippingDetailOrderDetailEntity)relatedEntity);
					break;
				case "SourceCodeOrderDetail":
					this.SourceCodeOrderDetail.Add((SourceCodeOrderDetailEntity)relatedEntity);
					break;
				case "TestOrderItem":
					this.TestOrderItem.Add((TestOrderItemEntity)relatedEntity);
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
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "Order":
					DesetupSyncOrder(false, true);
					break;
				case "OrderItem":
					DesetupSyncOrderItem(false, true);
					break;
				case "EventCustomerOrderDetail":
					base.PerformRelatedEntityRemoval(this.EventCustomerOrderDetail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ShippingDetailOrderDetail":
					base.PerformRelatedEntityRemoval(this.ShippingDetailOrderDetail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SourceCodeOrderDetail":
					base.PerformRelatedEntityRemoval(this.SourceCodeOrderDetail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestOrderItem":
					base.PerformRelatedEntityRemoval(this.TestOrderItem, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_order!=null)
			{
				toReturn.Add(_order);
			}
			if(_orderItem!=null)
			{
				toReturn.Add(_orderItem);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventCustomerOrderDetail);
			toReturn.Add(this.ShippingDetailOrderDetail);
			toReturn.Add(this.SourceCodeOrderDetail);
			toReturn.Add(this.TestOrderItem);

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
				info.AddValue("_eventCustomerOrderDetail", ((_eventCustomerOrderDetail!=null) && (_eventCustomerOrderDetail.Count>0) && !this.MarkedForDeletion)?_eventCustomerOrderDetail:null);
				info.AddValue("_shippingDetailOrderDetail", ((_shippingDetailOrderDetail!=null) && (_shippingDetailOrderDetail.Count>0) && !this.MarkedForDeletion)?_shippingDetailOrderDetail:null);
				info.AddValue("_sourceCodeOrderDetail", ((_sourceCodeOrderDetail!=null) && (_sourceCodeOrderDetail.Count>0) && !this.MarkedForDeletion)?_sourceCodeOrderDetail:null);
				info.AddValue("_testOrderItem", ((_testOrderItem!=null) && (_testOrderItem.Count>0) && !this.MarkedForDeletion)?_testOrderItem:null);
				info.AddValue("_couponsCollectionViaSourceCodeOrderDetail", ((_couponsCollectionViaSourceCodeOrderDetail!=null) && (_couponsCollectionViaSourceCodeOrderDetail.Count>0) && !this.MarkedForDeletion)?_couponsCollectionViaSourceCodeOrderDetail:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerOrderDetail", ((_eventCustomersCollectionViaEventCustomerOrderDetail!=null) && (_eventCustomersCollectionViaEventCustomerOrderDetail.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerOrderDetail:null);
				info.AddValue("_paymentCollectionViaTestOrderItem", ((_paymentCollectionViaTestOrderItem!=null) && (_paymentCollectionViaTestOrderItem.Count>0) && !this.MarkedForDeletion)?_paymentCollectionViaTestOrderItem:null);
				info.AddValue("_shippingDetailCollectionViaShippingDetailOrderDetail", ((_shippingDetailCollectionViaShippingDetailOrderDetail!=null) && (_shippingDetailCollectionViaShippingDetailOrderDetail.Count>0) && !this.MarkedForDeletion)?_shippingDetailCollectionViaShippingDetailOrderDetail:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_order", (!this.MarkedForDeletion?_order:null));
				info.AddValue("_orderItem", (!this.MarkedForDeletion?_orderItem:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OrderDetailFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OrderDetailFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OrderDetailRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerOrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerOrderDetailFields.OrderDetailId, null, ComparisonOperator.Equal, this.OrderDetailId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingDetailOrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingDetailOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingDetailOrderDetailFields.OrderDetailId, null, ComparisonOperator.Equal, this.OrderDetailId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SourceCodeOrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSourceCodeOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SourceCodeOrderDetailFields.OrderDetailId, null, ComparisonOperator.Equal, this.OrderDetailId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestOrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderDetailId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponsCollectionViaSourceCodeOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CouponsCollectionViaSourceCodeOrderDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderDetailFields.OrderDetailId, null, ComparisonOperator.Equal, this.OrderDetailId, "OrderDetailEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerOrderDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderDetailFields.OrderDetailId, null, ComparisonOperator.Equal, this.OrderDetailId, "OrderDetailEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Payment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentCollectionViaTestOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PaymentCollectionViaTestOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderDetailFields.OrderDetailId, null, ComparisonOperator.Equal, this.OrderDetailId, "OrderDetailEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingDetailCollectionViaShippingDetailOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ShippingDetailCollectionViaShippingDetailOrderDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderDetailFields.OrderDetailId, null, ComparisonOperator.Equal, this.OrderDetailId, "OrderDetailEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.SourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Order' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderFields.OrderId, null, ComparisonOperator.Equal, this.OrderId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrderItem' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderItemFields.OrderItemId, null, ComparisonOperator.Equal, this.OrderItemId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.OrderDetailEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventCustomerOrderDetail);
			collectionsQueue.Enqueue(this._shippingDetailOrderDetail);
			collectionsQueue.Enqueue(this._sourceCodeOrderDetail);
			collectionsQueue.Enqueue(this._testOrderItem);
			collectionsQueue.Enqueue(this._couponsCollectionViaSourceCodeOrderDetail);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerOrderDetail);
			collectionsQueue.Enqueue(this._paymentCollectionViaTestOrderItem);
			collectionsQueue.Enqueue(this._shippingDetailCollectionViaShippingDetailOrderDetail);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventCustomerOrderDetail = (EntityCollection<EventCustomerOrderDetailEntity>) collectionsQueue.Dequeue();
			this._shippingDetailOrderDetail = (EntityCollection<ShippingDetailOrderDetailEntity>) collectionsQueue.Dequeue();
			this._sourceCodeOrderDetail = (EntityCollection<SourceCodeOrderDetailEntity>) collectionsQueue.Dequeue();
			this._testOrderItem = (EntityCollection<TestOrderItemEntity>) collectionsQueue.Dequeue();
			this._couponsCollectionViaSourceCodeOrderDetail = (EntityCollection<CouponsEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerOrderDetail = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._paymentCollectionViaTestOrderItem = (EntityCollection<PaymentEntity>) collectionsQueue.Dequeue();
			this._shippingDetailCollectionViaShippingDetailOrderDetail = (EntityCollection<ShippingDetailEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventCustomerOrderDetail != null)
			{
				return true;
			}
			if (this._shippingDetailOrderDetail != null)
			{
				return true;
			}
			if (this._sourceCodeOrderDetail != null)
			{
				return true;
			}
			if (this._testOrderItem != null)
			{
				return true;
			}
			if (this._couponsCollectionViaSourceCodeOrderDetail != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerOrderDetail != null)
			{
				return true;
			}
			if (this._paymentCollectionViaTestOrderItem != null)
			{
				return true;
			}
			if (this._shippingDetailCollectionViaShippingDetailOrderDetail != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerOrderDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingDetailOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailOrderDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SourceCodeOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SourceCodeOrderDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Order", _order);
			toReturn.Add("OrderItem", _orderItem);
			toReturn.Add("EventCustomerOrderDetail", _eventCustomerOrderDetail);
			toReturn.Add("ShippingDetailOrderDetail", _shippingDetailOrderDetail);
			toReturn.Add("SourceCodeOrderDetail", _sourceCodeOrderDetail);
			toReturn.Add("TestOrderItem", _testOrderItem);
			toReturn.Add("CouponsCollectionViaSourceCodeOrderDetail", _couponsCollectionViaSourceCodeOrderDetail);
			toReturn.Add("EventCustomersCollectionViaEventCustomerOrderDetail", _eventCustomersCollectionViaEventCustomerOrderDetail);
			toReturn.Add("PaymentCollectionViaTestOrderItem", _paymentCollectionViaTestOrderItem);
			toReturn.Add("ShippingDetailCollectionViaShippingDetailOrderDetail", _shippingDetailCollectionViaShippingDetailOrderDetail);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventCustomerOrderDetail!=null)
			{
				_eventCustomerOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_shippingDetailOrderDetail!=null)
			{
				_shippingDetailOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_sourceCodeOrderDetail!=null)
			{
				_sourceCodeOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_testOrderItem!=null)
			{
				_testOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_couponsCollectionViaSourceCodeOrderDetail!=null)
			{
				_couponsCollectionViaSourceCodeOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerOrderDetail!=null)
			{
				_eventCustomersCollectionViaEventCustomerOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_paymentCollectionViaTestOrderItem!=null)
			{
				_paymentCollectionViaTestOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_shippingDetailCollectionViaShippingDetailOrderDetail!=null)
			{
				_shippingDetailCollectionViaShippingDetailOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_order!=null)
			{
				_order.ActiveContext = base.ActiveContext;
			}
			if(_orderItem!=null)
			{
				_orderItem.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventCustomerOrderDetail = null;
			_shippingDetailOrderDetail = null;
			_sourceCodeOrderDetail = null;
			_testOrderItem = null;
			_couponsCollectionViaSourceCodeOrderDetail = null;
			_eventCustomersCollectionViaEventCustomerOrderDetail = null;
			_paymentCollectionViaTestOrderItem = null;
			_shippingDetailCollectionViaShippingDetailOrderDetail = null;
			_lookup = null;
			_order = null;
			_orderItem = null;

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

			_fieldsCustomProperties.Add("OrderDetailId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrderId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ForOrganizationRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrderItemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Quantity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Price", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserCreatorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SourceId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", OrderDetailEntity.Relations.LookupEntityUsingSourceId, true, signalRelatedEntity, "OrderDetail", resetFKFields, new int[] { (int)OrderDetailFieldIndex.SourceId } );		
			_lookup = null;
		}

		/// <summary> setups the sync logic for member _lookup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup(IEntity2 relatedEntity)
		{
			if(_lookup!=relatedEntity)
			{
				DesetupSyncLookup(true, true);
				_lookup = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", OrderDetailEntity.Relations.LookupEntityUsingSourceId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _order</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrder(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _order, new PropertyChangedEventHandler( OnOrderPropertyChanged ), "Order", OrderDetailEntity.Relations.OrderEntityUsingOrderId, true, signalRelatedEntity, "OrderDetail", resetFKFields, new int[] { (int)OrderDetailFieldIndex.OrderId } );		
			_order = null;
		}

		/// <summary> setups the sync logic for member _order</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrder(IEntity2 relatedEntity)
		{
			if(_order!=relatedEntity)
			{
				DesetupSyncOrder(true, true);
				_order = (OrderEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _order, new PropertyChangedEventHandler( OnOrderPropertyChanged ), "Order", OrderDetailEntity.Relations.OrderEntityUsingOrderId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrderPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _orderItem</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrderItem(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _orderItem, new PropertyChangedEventHandler( OnOrderItemPropertyChanged ), "OrderItem", OrderDetailEntity.Relations.OrderItemEntityUsingOrderItemId, true, signalRelatedEntity, "OrderDetail", resetFKFields, new int[] { (int)OrderDetailFieldIndex.OrderItemId } );		
			_orderItem = null;
		}

		/// <summary> setups the sync logic for member _orderItem</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrderItem(IEntity2 relatedEntity)
		{
			if(_orderItem!=relatedEntity)
			{
				DesetupSyncOrderItem(true, true);
				_orderItem = (OrderItemEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _orderItem, new PropertyChangedEventHandler( OnOrderItemPropertyChanged ), "OrderItem", OrderDetailEntity.Relations.OrderItemEntityUsingOrderItemId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrderItemPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OrderDetailEntity</param>
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
		public  static OrderDetailRelations Relations
		{
			get	{ return new OrderDetailRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerOrderDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerOrderDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerOrderDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerOrderDetail")[0], (int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.EventCustomerOrderDetailEntity, 0, null, null, null, null, "EventCustomerOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingDetailOrderDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingDetailOrderDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ShippingDetailOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailOrderDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("ShippingDetailOrderDetail")[0], (int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.ShippingDetailOrderDetailEntity, 0, null, null, null, null, "ShippingDetailOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("SourceCodeOrderDetail")[0], (int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.SourceCodeOrderDetailEntity, 0, null, null, null, null, "SourceCodeOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestOrderItem")[0], (int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.TestOrderItemEntity, 0, null, null, null, null, "TestOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponsCollectionViaSourceCodeOrderDetail
		{
			get
			{
				IEntityRelation intermediateRelation = OrderDetailEntity.Relations.SourceCodeOrderDetailEntityUsingOrderDetailId;
				intermediateRelation.SetAliases(string.Empty, "SourceCodeOrderDetail_");
				return new PrefetchPathElement2(new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.CouponsEntity, 0, null, null, GetRelationsForField("CouponsCollectionViaSourceCodeOrderDetail"), null, "CouponsCollectionViaSourceCodeOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerOrderDetail
		{
			get
			{
				IEntityRelation intermediateRelation = OrderDetailEntity.Relations.EventCustomerOrderDetailEntityUsingOrderDetailId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerOrderDetail_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerOrderDetail"), null, "EventCustomersCollectionViaEventCustomerOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Payment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentCollectionViaTestOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = OrderDetailEntity.Relations.TestOrderItemEntityUsingOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "TestOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.PaymentEntity, 0, null, null, GetRelationsForField("PaymentCollectionViaTestOrderItem"), null, "PaymentCollectionViaTestOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingDetailCollectionViaShippingDetailOrderDetail
		{
			get
			{
				IEntityRelation intermediateRelation = OrderDetailEntity.Relations.ShippingDetailOrderDetailEntityUsingOrderDetailId;
				intermediateRelation.SetAliases(string.Empty, "ShippingDetailOrderDetail_");
				return new PrefetchPathElement2(new EntityCollection<ShippingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.ShippingDetailEntity, 0, null, null, GetRelationsForField("ShippingDetailCollectionViaShippingDetailOrderDetail"), null, "ShippingDetailCollectionViaShippingDetailOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Order' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrder
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrderEntityFactory))),
					(IEntityRelation)GetRelationsForField("Order")[0], (int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.OrderEntity, 0, null, null, null, null, "Order", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderItem
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrderItem")[0], (int)Falcon.Data.EntityType.OrderDetailEntity, (int)Falcon.Data.EntityType.OrderItemEntity, 0, null, null, null, null, "OrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OrderDetailEntity.CustomProperties;}
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
			get { return OrderDetailEntity.FieldsCustomProperties;}
		}

		/// <summary> The OrderDetailId property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."OrderDetailID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 OrderDetailId
		{
			get { return (System.Int64)GetValue((int)OrderDetailFieldIndex.OrderDetailId, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.OrderDetailId, value); }
		}

		/// <summary> The OrderId property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."OrderID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrderId
		{
			get { return (System.Int64)GetValue((int)OrderDetailFieldIndex.OrderId, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.OrderId, value); }
		}

		/// <summary> The ForOrganizationRoleUserId property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."ForOrganizationRoleUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ForOrganizationRoleUserId
		{
			get { return (System.Int64)GetValue((int)OrderDetailFieldIndex.ForOrganizationRoleUserId, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.ForOrganizationRoleUserId, value); }
		}

		/// <summary> The OrderItemId property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."OrderItemID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrderItemId
		{
			get { return (System.Int64)GetValue((int)OrderDetailFieldIndex.OrderItemId, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.OrderItemId, value); }
		}

		/// <summary> The Description property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)OrderDetailFieldIndex.Description, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.Description, value); }
		}

		/// <summary> The Quantity property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."Quantity"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Quantity
		{
			get { return (System.Int32)GetValue((int)OrderDetailFieldIndex.Quantity, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.Quantity, value); }
		}

		/// <summary> The Price property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."Price"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Price
		{
			get { return (System.Decimal)GetValue((int)OrderDetailFieldIndex.Price, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.Price, value); }
		}

		/// <summary> The Status property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 Status
		{
			get { return (System.Int16)GetValue((int)OrderDetailFieldIndex.Status, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.Status, value); }
		}

		/// <summary> The DateCreated property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)OrderDetailFieldIndex.DateCreated, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.DateCreated, value); }
		}

		/// <summary> The OrganizationRoleUserCreatorId property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."OrganizationRoleUserCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationRoleUserCreatorId
		{
			get { return (System.Int64)GetValue((int)OrderDetailFieldIndex.OrganizationRoleUserCreatorId, true); }
			set	{ SetValue((int)OrderDetailFieldIndex.OrganizationRoleUserCreatorId, value); }
		}

		/// <summary> The SourceId property of the Entity OrderDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrderDetail"."SourceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SourceId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OrderDetailFieldIndex.SourceId, false); }
			set	{ SetValue((int)OrderDetailFieldIndex.SourceId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerOrderDetailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerOrderDetailEntity))]
		public virtual EntityCollection<EventCustomerOrderDetailEntity> EventCustomerOrderDetail
		{
			get
			{
				if(_eventCustomerOrderDetail==null)
				{
					_eventCustomerOrderDetail = new EntityCollection<EventCustomerOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerOrderDetailEntityFactory)));
					_eventCustomerOrderDetail.SetContainingEntityInfo(this, "OrderDetail");
				}
				return _eventCustomerOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingDetailOrderDetailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingDetailOrderDetailEntity))]
		public virtual EntityCollection<ShippingDetailOrderDetailEntity> ShippingDetailOrderDetail
		{
			get
			{
				if(_shippingDetailOrderDetail==null)
				{
					_shippingDetailOrderDetail = new EntityCollection<ShippingDetailOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailOrderDetailEntityFactory)));
					_shippingDetailOrderDetail.SetContainingEntityInfo(this, "OrderDetail");
				}
				return _shippingDetailOrderDetail;
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
					_sourceCodeOrderDetail.SetContainingEntityInfo(this, "OrderDetail");
				}
				return _sourceCodeOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestOrderItemEntity))]
		public virtual EntityCollection<TestOrderItemEntity> TestOrderItem
		{
			get
			{
				if(_testOrderItem==null)
				{
					_testOrderItem = new EntityCollection<TestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestOrderItemEntityFactory)));
					_testOrderItem.SetContainingEntityInfo(this, "OrderDetail");
				}
				return _testOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouponsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouponsEntity))]
		public virtual EntityCollection<CouponsEntity> CouponsCollectionViaSourceCodeOrderDetail
		{
			get
			{
				if(_couponsCollectionViaSourceCodeOrderDetail==null)
				{
					_couponsCollectionViaSourceCodeOrderDetail = new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory)));
					_couponsCollectionViaSourceCodeOrderDetail.IsReadOnly=true;
				}
				return _couponsCollectionViaSourceCodeOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerOrderDetail
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerOrderDetail==null)
				{
					_eventCustomersCollectionViaEventCustomerOrderDetail = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerOrderDetail.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PaymentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PaymentEntity))]
		public virtual EntityCollection<PaymentEntity> PaymentCollectionViaTestOrderItem
		{
			get
			{
				if(_paymentCollectionViaTestOrderItem==null)
				{
					_paymentCollectionViaTestOrderItem = new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory)));
					_paymentCollectionViaTestOrderItem.IsReadOnly=true;
				}
				return _paymentCollectionViaTestOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingDetailEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingDetailEntity))]
		public virtual EntityCollection<ShippingDetailEntity> ShippingDetailCollectionViaShippingDetailOrderDetail
		{
			get
			{
				if(_shippingDetailCollectionViaShippingDetailOrderDetail==null)
				{
					_shippingDetailCollectionViaShippingDetailOrderDetail = new EntityCollection<ShippingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailEntityFactory)));
					_shippingDetailCollectionViaShippingDetailOrderDetail.IsReadOnly=true;
				}
				return _shippingDetailCollectionViaShippingDetailOrderDetail;
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup
		{
			get
			{
				return _lookup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup != null)
						{
							_lookup.UnsetRelatedEntity(this, "OrderDetail");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "OrderDetail");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrderEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrderEntity Order
		{
			get
			{
				return _order;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrder(value);
				}
				else
				{
					if(value==null)
					{
						if(_order != null)
						{
							_order.UnsetRelatedEntity(this, "OrderDetail");
						}
					}
					else
					{
						if(_order!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "OrderDetail");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrderItemEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrderItemEntity OrderItem
		{
			get
			{
				return _orderItem;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrderItem(value);
				}
				else
				{
					if(value==null)
					{
						if(_orderItem != null)
						{
							_orderItem.UnsetRelatedEntity(this, "OrderDetail");
						}
					}
					else
					{
						if(_orderItem!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "OrderDetail");
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
			get { return (int)Falcon.Data.EntityType.OrderDetailEntity; }
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
