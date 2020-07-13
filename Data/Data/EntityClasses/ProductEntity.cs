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
	/// Entity class which represents the entity 'Product'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ProductEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventProductExclusionEntity> _eventProductExclusion;
		private EntityCollection<ProductOrderItemEntity> _productOrderItem;
		private EntityCollection<ProductShippingOptionEntity> _productShippingOption;
		private EntityCollection<ProductSourceCodeDiscountEntity> _productSourceCodeDiscount;
		private EntityCollection<CouponsEntity> _couponsCollectionViaProductSourceCodeDiscount;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventProductExclusion;
		private EntityCollection<OrderItemEntity> _orderItemCollectionViaProductOrderItem;
		private EntityCollection<ShippingOptionEntity> _shippingOptionCollectionViaProductShippingOption;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name EventProductExclusion</summary>
			public static readonly string EventProductExclusion = "EventProductExclusion";
			/// <summary>Member name ProductOrderItem</summary>
			public static readonly string ProductOrderItem = "ProductOrderItem";
			/// <summary>Member name ProductShippingOption</summary>
			public static readonly string ProductShippingOption = "ProductShippingOption";
			/// <summary>Member name ProductSourceCodeDiscount</summary>
			public static readonly string ProductSourceCodeDiscount = "ProductSourceCodeDiscount";
			/// <summary>Member name CouponsCollectionViaProductSourceCodeDiscount</summary>
			public static readonly string CouponsCollectionViaProductSourceCodeDiscount = "CouponsCollectionViaProductSourceCodeDiscount";
			/// <summary>Member name EventsCollectionViaEventProductExclusion</summary>
			public static readonly string EventsCollectionViaEventProductExclusion = "EventsCollectionViaEventProductExclusion";
			/// <summary>Member name OrderItemCollectionViaProductOrderItem</summary>
			public static readonly string OrderItemCollectionViaProductOrderItem = "OrderItemCollectionViaProductOrderItem";
			/// <summary>Member name ShippingOptionCollectionViaProductShippingOption</summary>
			public static readonly string ShippingOptionCollectionViaProductShippingOption = "ShippingOptionCollectionViaProductShippingOption";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ProductEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ProductEntity():base("ProductEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ProductEntity(IEntityFields2 fields):base("ProductEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ProductEntity</param>
		public ProductEntity(IValidator validator):base("ProductEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="productId">PK value for Product which data should be fetched into this Product object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProductEntity(System.Int64 productId):base("ProductEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ProductId = productId;
		}

		/// <summary> CTor</summary>
		/// <param name="productId">PK value for Product which data should be fetched into this Product object</param>
		/// <param name="validator">The custom validator object for this ProductEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProductEntity(System.Int64 productId, IValidator validator):base("ProductEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ProductId = productId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ProductEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventProductExclusion = (EntityCollection<EventProductExclusionEntity>)info.GetValue("_eventProductExclusion", typeof(EntityCollection<EventProductExclusionEntity>));
				_productOrderItem = (EntityCollection<ProductOrderItemEntity>)info.GetValue("_productOrderItem", typeof(EntityCollection<ProductOrderItemEntity>));
				_productShippingOption = (EntityCollection<ProductShippingOptionEntity>)info.GetValue("_productShippingOption", typeof(EntityCollection<ProductShippingOptionEntity>));
				_productSourceCodeDiscount = (EntityCollection<ProductSourceCodeDiscountEntity>)info.GetValue("_productSourceCodeDiscount", typeof(EntityCollection<ProductSourceCodeDiscountEntity>));
				_couponsCollectionViaProductSourceCodeDiscount = (EntityCollection<CouponsEntity>)info.GetValue("_couponsCollectionViaProductSourceCodeDiscount", typeof(EntityCollection<CouponsEntity>));
				_eventsCollectionViaEventProductExclusion = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventProductExclusion", typeof(EntityCollection<EventsEntity>));
				_orderItemCollectionViaProductOrderItem = (EntityCollection<OrderItemEntity>)info.GetValue("_orderItemCollectionViaProductOrderItem", typeof(EntityCollection<OrderItemEntity>));
				_shippingOptionCollectionViaProductShippingOption = (EntityCollection<ShippingOptionEntity>)info.GetValue("_shippingOptionCollectionViaProductShippingOption", typeof(EntityCollection<ShippingOptionEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ProductFieldIndex)fieldIndex)
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

				case "EventProductExclusion":
					this.EventProductExclusion.Add((EventProductExclusionEntity)entity);
					break;
				case "ProductOrderItem":
					this.ProductOrderItem.Add((ProductOrderItemEntity)entity);
					break;
				case "ProductShippingOption":
					this.ProductShippingOption.Add((ProductShippingOptionEntity)entity);
					break;
				case "ProductSourceCodeDiscount":
					this.ProductSourceCodeDiscount.Add((ProductSourceCodeDiscountEntity)entity);
					break;
				case "CouponsCollectionViaProductSourceCodeDiscount":
					this.CouponsCollectionViaProductSourceCodeDiscount.IsReadOnly = false;
					this.CouponsCollectionViaProductSourceCodeDiscount.Add((CouponsEntity)entity);
					this.CouponsCollectionViaProductSourceCodeDiscount.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventProductExclusion":
					this.EventsCollectionViaEventProductExclusion.IsReadOnly = false;
					this.EventsCollectionViaEventProductExclusion.Add((EventsEntity)entity);
					this.EventsCollectionViaEventProductExclusion.IsReadOnly = true;
					break;
				case "OrderItemCollectionViaProductOrderItem":
					this.OrderItemCollectionViaProductOrderItem.IsReadOnly = false;
					this.OrderItemCollectionViaProductOrderItem.Add((OrderItemEntity)entity);
					this.OrderItemCollectionViaProductOrderItem.IsReadOnly = true;
					break;
				case "ShippingOptionCollectionViaProductShippingOption":
					this.ShippingOptionCollectionViaProductShippingOption.IsReadOnly = false;
					this.ShippingOptionCollectionViaProductShippingOption.Add((ShippingOptionEntity)entity);
					this.ShippingOptionCollectionViaProductShippingOption.IsReadOnly = true;
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
			return ProductEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "EventProductExclusion":
					toReturn.Add(ProductEntity.Relations.EventProductExclusionEntityUsingProductId);
					break;
				case "ProductOrderItem":
					toReturn.Add(ProductEntity.Relations.ProductOrderItemEntityUsingProductId);
					break;
				case "ProductShippingOption":
					toReturn.Add(ProductEntity.Relations.ProductShippingOptionEntityUsingProductId);
					break;
				case "ProductSourceCodeDiscount":
					toReturn.Add(ProductEntity.Relations.ProductSourceCodeDiscountEntityUsingProductId);
					break;
				case "CouponsCollectionViaProductSourceCodeDiscount":
					toReturn.Add(ProductEntity.Relations.ProductSourceCodeDiscountEntityUsingProductId, "ProductEntity__", "ProductSourceCodeDiscount_", JoinHint.None);
					toReturn.Add(ProductSourceCodeDiscountEntity.Relations.CouponsEntityUsingSourceCodeId, "ProductSourceCodeDiscount_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventProductExclusion":
					toReturn.Add(ProductEntity.Relations.EventProductExclusionEntityUsingProductId, "ProductEntity__", "EventProductExclusion_", JoinHint.None);
					toReturn.Add(EventProductExclusionEntity.Relations.EventsEntityUsingEventId, "EventProductExclusion_", string.Empty, JoinHint.None);
					break;
				case "OrderItemCollectionViaProductOrderItem":
					toReturn.Add(ProductEntity.Relations.ProductOrderItemEntityUsingProductId, "ProductEntity__", "ProductOrderItem_", JoinHint.None);
					toReturn.Add(ProductOrderItemEntity.Relations.OrderItemEntityUsingOrderItemId, "ProductOrderItem_", string.Empty, JoinHint.None);
					break;
				case "ShippingOptionCollectionViaProductShippingOption":
					toReturn.Add(ProductEntity.Relations.ProductShippingOptionEntityUsingProductId, "ProductEntity__", "ProductShippingOption_", JoinHint.None);
					toReturn.Add(ProductShippingOptionEntity.Relations.ShippingOptionEntityUsingShippingOptionId, "ProductShippingOption_", string.Empty, JoinHint.None);
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

				case "EventProductExclusion":
					this.EventProductExclusion.Add((EventProductExclusionEntity)relatedEntity);
					break;
				case "ProductOrderItem":
					this.ProductOrderItem.Add((ProductOrderItemEntity)relatedEntity);
					break;
				case "ProductShippingOption":
					this.ProductShippingOption.Add((ProductShippingOptionEntity)relatedEntity);
					break;
				case "ProductSourceCodeDiscount":
					this.ProductSourceCodeDiscount.Add((ProductSourceCodeDiscountEntity)relatedEntity);
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

				case "EventProductExclusion":
					base.PerformRelatedEntityRemoval(this.EventProductExclusion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProductOrderItem":
					base.PerformRelatedEntityRemoval(this.ProductOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProductShippingOption":
					base.PerformRelatedEntityRemoval(this.ProductShippingOption, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProductSourceCodeDiscount":
					base.PerformRelatedEntityRemoval(this.ProductSourceCodeDiscount, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.EventProductExclusion);
			toReturn.Add(this.ProductOrderItem);
			toReturn.Add(this.ProductShippingOption);
			toReturn.Add(this.ProductSourceCodeDiscount);

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
				info.AddValue("_eventProductExclusion", ((_eventProductExclusion!=null) && (_eventProductExclusion.Count>0) && !this.MarkedForDeletion)?_eventProductExclusion:null);
				info.AddValue("_productOrderItem", ((_productOrderItem!=null) && (_productOrderItem.Count>0) && !this.MarkedForDeletion)?_productOrderItem:null);
				info.AddValue("_productShippingOption", ((_productShippingOption!=null) && (_productShippingOption.Count>0) && !this.MarkedForDeletion)?_productShippingOption:null);
				info.AddValue("_productSourceCodeDiscount", ((_productSourceCodeDiscount!=null) && (_productSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_productSourceCodeDiscount:null);
				info.AddValue("_couponsCollectionViaProductSourceCodeDiscount", ((_couponsCollectionViaProductSourceCodeDiscount!=null) && (_couponsCollectionViaProductSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_couponsCollectionViaProductSourceCodeDiscount:null);
				info.AddValue("_eventsCollectionViaEventProductExclusion", ((_eventsCollectionViaEventProductExclusion!=null) && (_eventsCollectionViaEventProductExclusion.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventProductExclusion:null);
				info.AddValue("_orderItemCollectionViaProductOrderItem", ((_orderItemCollectionViaProductOrderItem!=null) && (_orderItemCollectionViaProductOrderItem.Count>0) && !this.MarkedForDeletion)?_orderItemCollectionViaProductOrderItem:null);
				info.AddValue("_shippingOptionCollectionViaProductShippingOption", ((_shippingOptionCollectionViaProductShippingOption!=null) && (_shippingOptionCollectionViaProductShippingOption.Count>0) && !this.MarkedForDeletion)?_shippingOptionCollectionViaProductShippingOption:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ProductFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ProductFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ProductRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventProductExclusion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventProductExclusion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventProductExclusionFields.ProductId, null, ComparisonOperator.Equal, this.ProductId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProductOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProductOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductOrderItemFields.ProductId, null, ComparisonOperator.Equal, this.ProductId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProductShippingOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProductShippingOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductShippingOptionFields.ProductId, null, ComparisonOperator.Equal, this.ProductId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProductSourceCodeDiscount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProductSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductSourceCodeDiscountFields.ProductId, null, ComparisonOperator.Equal, this.ProductId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponsCollectionViaProductSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CouponsCollectionViaProductSourceCodeDiscount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductFields.ProductId, null, ComparisonOperator.Equal, this.ProductId, "ProductEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventProductExclusion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventProductExclusion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductFields.ProductId, null, ComparisonOperator.Equal, this.ProductId, "ProductEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderItemCollectionViaProductOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderItemCollectionViaProductOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductFields.ProductId, null, ComparisonOperator.Equal, this.ProductId, "ProductEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingOptionCollectionViaProductShippingOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ShippingOptionCollectionViaProductShippingOption"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductFields.ProductId, null, ComparisonOperator.Equal, this.ProductId, "ProductEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ProductEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventProductExclusion);
			collectionsQueue.Enqueue(this._productOrderItem);
			collectionsQueue.Enqueue(this._productShippingOption);
			collectionsQueue.Enqueue(this._productSourceCodeDiscount);
			collectionsQueue.Enqueue(this._couponsCollectionViaProductSourceCodeDiscount);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventProductExclusion);
			collectionsQueue.Enqueue(this._orderItemCollectionViaProductOrderItem);
			collectionsQueue.Enqueue(this._shippingOptionCollectionViaProductShippingOption);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventProductExclusion = (EntityCollection<EventProductExclusionEntity>) collectionsQueue.Dequeue();
			this._productOrderItem = (EntityCollection<ProductOrderItemEntity>) collectionsQueue.Dequeue();
			this._productShippingOption = (EntityCollection<ProductShippingOptionEntity>) collectionsQueue.Dequeue();
			this._productSourceCodeDiscount = (EntityCollection<ProductSourceCodeDiscountEntity>) collectionsQueue.Dequeue();
			this._couponsCollectionViaProductSourceCodeDiscount = (EntityCollection<CouponsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventProductExclusion = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._orderItemCollectionViaProductOrderItem = (EntityCollection<OrderItemEntity>) collectionsQueue.Dequeue();
			this._shippingOptionCollectionViaProductShippingOption = (EntityCollection<ShippingOptionEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventProductExclusion != null)
			{
				return true;
			}
			if (this._productOrderItem != null)
			{
				return true;
			}
			if (this._productShippingOption != null)
			{
				return true;
			}
			if (this._productSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._couponsCollectionViaProductSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventProductExclusion != null)
			{
				return true;
			}
			if (this._orderItemCollectionViaProductOrderItem != null)
			{
				return true;
			}
			if (this._shippingOptionCollectionViaProductShippingOption != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventProductExclusionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventProductExclusionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProductOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProductShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductShippingOptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProductSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductSourceCodeDiscountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("EventProductExclusion", _eventProductExclusion);
			toReturn.Add("ProductOrderItem", _productOrderItem);
			toReturn.Add("ProductShippingOption", _productShippingOption);
			toReturn.Add("ProductSourceCodeDiscount", _productSourceCodeDiscount);
			toReturn.Add("CouponsCollectionViaProductSourceCodeDiscount", _couponsCollectionViaProductSourceCodeDiscount);
			toReturn.Add("EventsCollectionViaEventProductExclusion", _eventsCollectionViaEventProductExclusion);
			toReturn.Add("OrderItemCollectionViaProductOrderItem", _orderItemCollectionViaProductOrderItem);
			toReturn.Add("ShippingOptionCollectionViaProductShippingOption", _shippingOptionCollectionViaProductShippingOption);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventProductExclusion!=null)
			{
				_eventProductExclusion.ActiveContext = base.ActiveContext;
			}
			if(_productOrderItem!=null)
			{
				_productOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_productShippingOption!=null)
			{
				_productShippingOption.ActiveContext = base.ActiveContext;
			}
			if(_productSourceCodeDiscount!=null)
			{
				_productSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_couponsCollectionViaProductSourceCodeDiscount!=null)
			{
				_couponsCollectionViaProductSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventProductExclusion!=null)
			{
				_eventsCollectionViaEventProductExclusion.ActiveContext = base.ActiveContext;
			}
			if(_orderItemCollectionViaProductOrderItem!=null)
			{
				_orderItemCollectionViaProductOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_shippingOptionCollectionViaProductShippingOption!=null)
			{
				_shippingOptionCollectionViaProductShippingOption.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventProductExclusion = null;
			_productOrderItem = null;
			_productShippingOption = null;
			_productSourceCodeDiscount = null;
			_couponsCollectionViaProductSourceCodeDiscount = null;
			_eventsCollectionViaEventProductExclusion = null;
			_orderItemCollectionViaProductOrderItem = null;
			_shippingOptionCollectionViaProductShippingOption = null;


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

			_fieldsCustomProperties.Add("ProductId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShortDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Price", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Weight", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Height", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Width", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Depth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ForOrderDisplayHtmlString", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ProductEntity</param>
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
		public  static ProductRelations Relations
		{
			get	{ return new ProductRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventProductExclusion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventProductExclusion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventProductExclusionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventProductExclusionEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventProductExclusion")[0], (int)Falcon.Data.EntityType.ProductEntity, (int)Falcon.Data.EntityType.EventProductExclusionEntity, 0, null, null, null, null, "EventProductExclusion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("ProductOrderItem")[0], (int)Falcon.Data.EntityType.ProductEntity, (int)Falcon.Data.EntityType.ProductOrderItemEntity, 0, null, null, null, null, "ProductOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProductShippingOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProductShippingOption
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProductShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductShippingOptionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProductShippingOption")[0], (int)Falcon.Data.EntityType.ProductEntity, (int)Falcon.Data.EntityType.ProductShippingOptionEntity, 0, null, null, null, null, "ProductShippingOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("ProductSourceCodeDiscount")[0], (int)Falcon.Data.EntityType.ProductEntity, (int)Falcon.Data.EntityType.ProductSourceCodeDiscountEntity, 0, null, null, null, null, "ProductSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponsCollectionViaProductSourceCodeDiscount
		{
			get
			{
				IEntityRelation intermediateRelation = ProductEntity.Relations.ProductSourceCodeDiscountEntityUsingProductId;
				intermediateRelation.SetAliases(string.Empty, "ProductSourceCodeDiscount_");
				return new PrefetchPathElement2(new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProductEntity, (int)Falcon.Data.EntityType.CouponsEntity, 0, null, null, GetRelationsForField("CouponsCollectionViaProductSourceCodeDiscount"), null, "CouponsCollectionViaProductSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventProductExclusion
		{
			get
			{
				IEntityRelation intermediateRelation = ProductEntity.Relations.EventProductExclusionEntityUsingProductId;
				intermediateRelation.SetAliases(string.Empty, "EventProductExclusion_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProductEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventProductExclusion"), null, "EventsCollectionViaEventProductExclusion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderItemCollectionViaProductOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = ProductEntity.Relations.ProductOrderItemEntityUsingProductId;
				intermediateRelation.SetAliases(string.Empty, "ProductOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProductEntity, (int)Falcon.Data.EntityType.OrderItemEntity, 0, null, null, GetRelationsForField("OrderItemCollectionViaProductOrderItem"), null, "OrderItemCollectionViaProductOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingOptionCollectionViaProductShippingOption
		{
			get
			{
				IEntityRelation intermediateRelation = ProductEntity.Relations.ProductShippingOptionEntityUsingProductId;
				intermediateRelation.SetAliases(string.Empty, "ProductShippingOption_");
				return new PrefetchPathElement2(new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProductEntity, (int)Falcon.Data.EntityType.ShippingOptionEntity, 0, null, null, GetRelationsForField("ShippingOptionCollectionViaProductShippingOption"), null, "ShippingOptionCollectionViaProductShippingOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ProductEntity.CustomProperties;}
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
			get { return ProductEntity.FieldsCustomProperties;}
		}

		/// <summary> The ProductId property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."ProductID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ProductId
		{
			get { return (System.Int64)GetValue((int)ProductFieldIndex.ProductId, true); }
			set	{ SetValue((int)ProductFieldIndex.ProductId, value); }
		}

		/// <summary> The Name property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ProductFieldIndex.Name, true); }
			set	{ SetValue((int)ProductFieldIndex.Name, value); }
		}

		/// <summary> The ShortDescription property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."ShortDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ShortDescription
		{
			get { return (System.String)GetValue((int)ProductFieldIndex.ShortDescription, true); }
			set	{ SetValue((int)ProductFieldIndex.ShortDescription, value); }
		}

		/// <summary> The Description property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): Text, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)ProductFieldIndex.Description, true); }
			set	{ SetValue((int)ProductFieldIndex.Description, value); }
		}

		/// <summary> The Price property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."Price"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Price
		{
			get { return (System.Decimal)GetValue((int)ProductFieldIndex.Price, true); }
			set	{ SetValue((int)ProductFieldIndex.Price, value); }
		}

		/// <summary> The Weight property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."Weight"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Double> Weight
		{
			get { return (Nullable<System.Double>)GetValue((int)ProductFieldIndex.Weight, false); }
			set	{ SetValue((int)ProductFieldIndex.Weight, value); }
		}

		/// <summary> The Height property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."Height"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Double> Height
		{
			get { return (Nullable<System.Double>)GetValue((int)ProductFieldIndex.Height, false); }
			set	{ SetValue((int)ProductFieldIndex.Height, value); }
		}

		/// <summary> The Width property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."Width"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Double> Width
		{
			get { return (Nullable<System.Double>)GetValue((int)ProductFieldIndex.Width, false); }
			set	{ SetValue((int)ProductFieldIndex.Width, value); }
		}

		/// <summary> The Depth property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."Depth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Double> Depth
		{
			get { return (Nullable<System.Double>)GetValue((int)ProductFieldIndex.Depth, false); }
			set	{ SetValue((int)ProductFieldIndex.Depth, value); }
		}

		/// <summary> The DateCreated property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ProductFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ProductFieldIndex.DateCreated, value); }
		}

		/// <summary> The IsActive property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ProductFieldIndex.IsActive, true); }
			set	{ SetValue((int)ProductFieldIndex.IsActive, value); }
		}

		/// <summary> The ForOrderDisplayHtmlString property of the Entity Product<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProduct"."ForOrderDisplayHtmlString"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ForOrderDisplayHtmlString
		{
			get { return (System.String)GetValue((int)ProductFieldIndex.ForOrderDisplayHtmlString, true); }
			set	{ SetValue((int)ProductFieldIndex.ForOrderDisplayHtmlString, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventProductExclusionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventProductExclusionEntity))]
		public virtual EntityCollection<EventProductExclusionEntity> EventProductExclusion
		{
			get
			{
				if(_eventProductExclusion==null)
				{
					_eventProductExclusion = new EntityCollection<EventProductExclusionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventProductExclusionEntityFactory)));
					_eventProductExclusion.SetContainingEntityInfo(this, "Product");
				}
				return _eventProductExclusion;
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
					_productOrderItem.SetContainingEntityInfo(this, "Product");
				}
				return _productOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProductShippingOptionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProductShippingOptionEntity))]
		public virtual EntityCollection<ProductShippingOptionEntity> ProductShippingOption
		{
			get
			{
				if(_productShippingOption==null)
				{
					_productShippingOption = new EntityCollection<ProductShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductShippingOptionEntityFactory)));
					_productShippingOption.SetContainingEntityInfo(this, "Product");
				}
				return _productShippingOption;
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
					_productSourceCodeDiscount.SetContainingEntityInfo(this, "Product");
				}
				return _productSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouponsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouponsEntity))]
		public virtual EntityCollection<CouponsEntity> CouponsCollectionViaProductSourceCodeDiscount
		{
			get
			{
				if(_couponsCollectionViaProductSourceCodeDiscount==null)
				{
					_couponsCollectionViaProductSourceCodeDiscount = new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory)));
					_couponsCollectionViaProductSourceCodeDiscount.IsReadOnly=true;
				}
				return _couponsCollectionViaProductSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventProductExclusion
		{
			get
			{
				if(_eventsCollectionViaEventProductExclusion==null)
				{
					_eventsCollectionViaEventProductExclusion = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventProductExclusion.IsReadOnly=true;
				}
				return _eventsCollectionViaEventProductExclusion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderItemEntity))]
		public virtual EntityCollection<OrderItemEntity> OrderItemCollectionViaProductOrderItem
		{
			get
			{
				if(_orderItemCollectionViaProductOrderItem==null)
				{
					_orderItemCollectionViaProductOrderItem = new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory)));
					_orderItemCollectionViaProductOrderItem.IsReadOnly=true;
				}
				return _orderItemCollectionViaProductOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingOptionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingOptionEntity))]
		public virtual EntityCollection<ShippingOptionEntity> ShippingOptionCollectionViaProductShippingOption
		{
			get
			{
				if(_shippingOptionCollectionViaProductShippingOption==null)
				{
					_shippingOptionCollectionViaProductShippingOption = new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory)));
					_shippingOptionCollectionViaProductShippingOption.IsReadOnly=true;
				}
				return _shippingOptionCollectionViaProductShippingOption;
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
			get { return (int)Falcon.Data.EntityType.ProductEntity; }
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
