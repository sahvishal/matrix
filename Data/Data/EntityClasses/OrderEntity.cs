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
	/// Entity class which represents the entity 'Order'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OrderEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<OrderDetailEntity> _orderDetail;
		private EntityCollection<PaymentOrderEntity> _paymentOrder;
		private EntityCollection<RefundRequestEntity> _refundRequest;
		private EntityCollection<LookupEntity> _lookupCollectionViaRefundRequest;
		private EntityCollection<LookupEntity> _lookupCollectionViaOrderDetail;
		private EntityCollection<OrderItemEntity> _orderItemCollectionViaOrderDetail;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaRefundRequest;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaRefundRequest_;
		private EntityCollection<PaymentEntity> _paymentCollectionViaPaymentOrder;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name OrderDetail</summary>
			public static readonly string OrderDetail = "OrderDetail";
			/// <summary>Member name PaymentOrder</summary>
			public static readonly string PaymentOrder = "PaymentOrder";
			/// <summary>Member name RefundRequest</summary>
			public static readonly string RefundRequest = "RefundRequest";
			/// <summary>Member name LookupCollectionViaRefundRequest</summary>
			public static readonly string LookupCollectionViaRefundRequest = "LookupCollectionViaRefundRequest";
			/// <summary>Member name LookupCollectionViaOrderDetail</summary>
			public static readonly string LookupCollectionViaOrderDetail = "LookupCollectionViaOrderDetail";
			/// <summary>Member name OrderItemCollectionViaOrderDetail</summary>
			public static readonly string OrderItemCollectionViaOrderDetail = "OrderItemCollectionViaOrderDetail";
			/// <summary>Member name OrganizationRoleUserCollectionViaRefundRequest</summary>
			public static readonly string OrganizationRoleUserCollectionViaRefundRequest = "OrganizationRoleUserCollectionViaRefundRequest";
			/// <summary>Member name OrganizationRoleUserCollectionViaRefundRequest_</summary>
			public static readonly string OrganizationRoleUserCollectionViaRefundRequest_ = "OrganizationRoleUserCollectionViaRefundRequest_";
			/// <summary>Member name PaymentCollectionViaPaymentOrder</summary>
			public static readonly string PaymentCollectionViaPaymentOrder = "PaymentCollectionViaPaymentOrder";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OrderEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public OrderEntity():base("OrderEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OrderEntity(IEntityFields2 fields):base("OrderEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OrderEntity</param>
		public OrderEntity(IValidator validator):base("OrderEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="orderId">PK value for Order which data should be fetched into this Order object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrderEntity(System.Int64 orderId):base("OrderEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OrderId = orderId;
		}

		/// <summary> CTor</summary>
		/// <param name="orderId">PK value for Order which data should be fetched into this Order object</param>
		/// <param name="validator">The custom validator object for this OrderEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrderEntity(System.Int64 orderId, IValidator validator):base("OrderEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OrderId = orderId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected OrderEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_orderDetail = (EntityCollection<OrderDetailEntity>)info.GetValue("_orderDetail", typeof(EntityCollection<OrderDetailEntity>));
				_paymentOrder = (EntityCollection<PaymentOrderEntity>)info.GetValue("_paymentOrder", typeof(EntityCollection<PaymentOrderEntity>));
				_refundRequest = (EntityCollection<RefundRequestEntity>)info.GetValue("_refundRequest", typeof(EntityCollection<RefundRequestEntity>));
				_lookupCollectionViaRefundRequest = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaRefundRequest", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaOrderDetail = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaOrderDetail", typeof(EntityCollection<LookupEntity>));
				_orderItemCollectionViaOrderDetail = (EntityCollection<OrderItemEntity>)info.GetValue("_orderItemCollectionViaOrderDetail", typeof(EntityCollection<OrderItemEntity>));
				_organizationRoleUserCollectionViaRefundRequest = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaRefundRequest", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaRefundRequest_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaRefundRequest_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_paymentCollectionViaPaymentOrder = (EntityCollection<PaymentEntity>)info.GetValue("_paymentCollectionViaPaymentOrder", typeof(EntityCollection<PaymentEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((OrderFieldIndex)fieldIndex)
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

				case "OrderDetail":
					this.OrderDetail.Add((OrderDetailEntity)entity);
					break;
				case "PaymentOrder":
					this.PaymentOrder.Add((PaymentOrderEntity)entity);
					break;
				case "RefundRequest":
					this.RefundRequest.Add((RefundRequestEntity)entity);
					break;
				case "LookupCollectionViaRefundRequest":
					this.LookupCollectionViaRefundRequest.IsReadOnly = false;
					this.LookupCollectionViaRefundRequest.Add((LookupEntity)entity);
					this.LookupCollectionViaRefundRequest.IsReadOnly = true;
					break;
				case "LookupCollectionViaOrderDetail":
					this.LookupCollectionViaOrderDetail.IsReadOnly = false;
					this.LookupCollectionViaOrderDetail.Add((LookupEntity)entity);
					this.LookupCollectionViaOrderDetail.IsReadOnly = true;
					break;
				case "OrderItemCollectionViaOrderDetail":
					this.OrderItemCollectionViaOrderDetail.IsReadOnly = false;
					this.OrderItemCollectionViaOrderDetail.Add((OrderItemEntity)entity);
					this.OrderItemCollectionViaOrderDetail.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaRefundRequest":
					this.OrganizationRoleUserCollectionViaRefundRequest.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaRefundRequest.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaRefundRequest.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaRefundRequest_":
					this.OrganizationRoleUserCollectionViaRefundRequest_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaRefundRequest_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaRefundRequest_.IsReadOnly = true;
					break;
				case "PaymentCollectionViaPaymentOrder":
					this.PaymentCollectionViaPaymentOrder.IsReadOnly = false;
					this.PaymentCollectionViaPaymentOrder.Add((PaymentEntity)entity);
					this.PaymentCollectionViaPaymentOrder.IsReadOnly = true;
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
			return OrderEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "OrderDetail":
					toReturn.Add(OrderEntity.Relations.OrderDetailEntityUsingOrderId);
					break;
				case "PaymentOrder":
					toReturn.Add(OrderEntity.Relations.PaymentOrderEntityUsingOrderId);
					break;
				case "RefundRequest":
					toReturn.Add(OrderEntity.Relations.RefundRequestEntityUsingOrderId);
					break;
				case "LookupCollectionViaRefundRequest":
					toReturn.Add(OrderEntity.Relations.RefundRequestEntityUsingOrderId, "OrderEntity__", "RefundRequest_", JoinHint.None);
					toReturn.Add(RefundRequestEntity.Relations.LookupEntityUsingRequestStatus, "RefundRequest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaOrderDetail":
					toReturn.Add(OrderEntity.Relations.OrderDetailEntityUsingOrderId, "OrderEntity__", "OrderDetail_", JoinHint.None);
					toReturn.Add(OrderDetailEntity.Relations.LookupEntityUsingSourceId, "OrderDetail_", string.Empty, JoinHint.None);
					break;
				case "OrderItemCollectionViaOrderDetail":
					toReturn.Add(OrderEntity.Relations.OrderDetailEntityUsingOrderId, "OrderEntity__", "OrderDetail_", JoinHint.None);
					toReturn.Add(OrderDetailEntity.Relations.OrderItemEntityUsingOrderItemId, "OrderDetail_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaRefundRequest":
					toReturn.Add(OrderEntity.Relations.RefundRequestEntityUsingOrderId, "OrderEntity__", "RefundRequest_", JoinHint.None);
					toReturn.Add(RefundRequestEntity.Relations.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId, "RefundRequest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaRefundRequest_":
					toReturn.Add(OrderEntity.Relations.RefundRequestEntityUsingOrderId, "OrderEntity__", "RefundRequest_", JoinHint.None);
					toReturn.Add(RefundRequestEntity.Relations.OrganizationRoleUserEntityUsingProcessedByOrgRoleUserId, "RefundRequest_", string.Empty, JoinHint.None);
					break;
				case "PaymentCollectionViaPaymentOrder":
					toReturn.Add(OrderEntity.Relations.PaymentOrderEntityUsingOrderId, "OrderEntity__", "PaymentOrder_", JoinHint.None);
					toReturn.Add(PaymentOrderEntity.Relations.PaymentEntityUsingPaymentId, "PaymentOrder_", string.Empty, JoinHint.None);
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

				case "OrderDetail":
					this.OrderDetail.Add((OrderDetailEntity)relatedEntity);
					break;
				case "PaymentOrder":
					this.PaymentOrder.Add((PaymentOrderEntity)relatedEntity);
					break;
				case "RefundRequest":
					this.RefundRequest.Add((RefundRequestEntity)relatedEntity);
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

				case "OrderDetail":
					base.PerformRelatedEntityRemoval(this.OrderDetail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PaymentOrder":
					base.PerformRelatedEntityRemoval(this.PaymentOrder, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RefundRequest":
					base.PerformRelatedEntityRemoval(this.RefundRequest, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.OrderDetail);
			toReturn.Add(this.PaymentOrder);
			toReturn.Add(this.RefundRequest);

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
				info.AddValue("_orderDetail", ((_orderDetail!=null) && (_orderDetail.Count>0) && !this.MarkedForDeletion)?_orderDetail:null);
				info.AddValue("_paymentOrder", ((_paymentOrder!=null) && (_paymentOrder.Count>0) && !this.MarkedForDeletion)?_paymentOrder:null);
				info.AddValue("_refundRequest", ((_refundRequest!=null) && (_refundRequest.Count>0) && !this.MarkedForDeletion)?_refundRequest:null);
				info.AddValue("_lookupCollectionViaRefundRequest", ((_lookupCollectionViaRefundRequest!=null) && (_lookupCollectionViaRefundRequest.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaRefundRequest:null);
				info.AddValue("_lookupCollectionViaOrderDetail", ((_lookupCollectionViaOrderDetail!=null) && (_lookupCollectionViaOrderDetail.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaOrderDetail:null);
				info.AddValue("_orderItemCollectionViaOrderDetail", ((_orderItemCollectionViaOrderDetail!=null) && (_orderItemCollectionViaOrderDetail.Count>0) && !this.MarkedForDeletion)?_orderItemCollectionViaOrderDetail:null);
				info.AddValue("_organizationRoleUserCollectionViaRefundRequest", ((_organizationRoleUserCollectionViaRefundRequest!=null) && (_organizationRoleUserCollectionViaRefundRequest.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaRefundRequest:null);
				info.AddValue("_organizationRoleUserCollectionViaRefundRequest_", ((_organizationRoleUserCollectionViaRefundRequest_!=null) && (_organizationRoleUserCollectionViaRefundRequest_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaRefundRequest_:null);
				info.AddValue("_paymentCollectionViaPaymentOrder", ((_paymentCollectionViaPaymentOrder!=null) && (_paymentCollectionViaPaymentOrder.Count>0) && !this.MarkedForDeletion)?_paymentCollectionViaPaymentOrder:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OrderFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OrderFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OrderRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderDetailFields.OrderId, null, ComparisonOperator.Equal, this.OrderId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PaymentOrder' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentOrderFields.OrderId, null, ComparisonOperator.Equal, this.OrderId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RefundRequest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundRequest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestFields.OrderId, null, ComparisonOperator.Equal, this.OrderId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaRefundRequest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaRefundRequest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderFields.OrderId, null, ComparisonOperator.Equal, this.OrderId, "OrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaOrderDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderFields.OrderId, null, ComparisonOperator.Equal, this.OrderId, "OrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderItemCollectionViaOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderItemCollectionViaOrderDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderFields.OrderId, null, ComparisonOperator.Equal, this.OrderId, "OrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaRefundRequest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaRefundRequest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderFields.OrderId, null, ComparisonOperator.Equal, this.OrderId, "OrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaRefundRequest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaRefundRequest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderFields.OrderId, null, ComparisonOperator.Equal, this.OrderId, "OrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Payment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentCollectionViaPaymentOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PaymentCollectionViaPaymentOrder"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderFields.OrderId, null, ComparisonOperator.Equal, this.OrderId, "OrderEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.OrderEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(OrderEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._orderDetail);
			collectionsQueue.Enqueue(this._paymentOrder);
			collectionsQueue.Enqueue(this._refundRequest);
			collectionsQueue.Enqueue(this._lookupCollectionViaRefundRequest);
			collectionsQueue.Enqueue(this._lookupCollectionViaOrderDetail);
			collectionsQueue.Enqueue(this._orderItemCollectionViaOrderDetail);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaRefundRequest);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaRefundRequest_);
			collectionsQueue.Enqueue(this._paymentCollectionViaPaymentOrder);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._orderDetail = (EntityCollection<OrderDetailEntity>) collectionsQueue.Dequeue();
			this._paymentOrder = (EntityCollection<PaymentOrderEntity>) collectionsQueue.Dequeue();
			this._refundRequest = (EntityCollection<RefundRequestEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaRefundRequest = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaOrderDetail = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._orderItemCollectionViaOrderDetail = (EntityCollection<OrderItemEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaRefundRequest = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaRefundRequest_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._paymentCollectionViaPaymentOrder = (EntityCollection<PaymentEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._orderDetail != null)
			{
				return true;
			}
			if (this._paymentOrder != null)
			{
				return true;
			}
			if (this._refundRequest != null)
			{
				return true;
			}
			if (this._lookupCollectionViaRefundRequest != null)
			{
				return true;
			}
			if (this._lookupCollectionViaOrderDetail != null)
			{
				return true;
			}
			if (this._orderItemCollectionViaOrderDetail != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaRefundRequest != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaRefundRequest_ != null)
			{
				return true;
			}
			if (this._paymentCollectionViaPaymentOrder != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PaymentOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentOrderEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("OrderDetail", _orderDetail);
			toReturn.Add("PaymentOrder", _paymentOrder);
			toReturn.Add("RefundRequest", _refundRequest);
			toReturn.Add("LookupCollectionViaRefundRequest", _lookupCollectionViaRefundRequest);
			toReturn.Add("LookupCollectionViaOrderDetail", _lookupCollectionViaOrderDetail);
			toReturn.Add("OrderItemCollectionViaOrderDetail", _orderItemCollectionViaOrderDetail);
			toReturn.Add("OrganizationRoleUserCollectionViaRefundRequest", _organizationRoleUserCollectionViaRefundRequest);
			toReturn.Add("OrganizationRoleUserCollectionViaRefundRequest_", _organizationRoleUserCollectionViaRefundRequest_);
			toReturn.Add("PaymentCollectionViaPaymentOrder", _paymentCollectionViaPaymentOrder);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_orderDetail!=null)
			{
				_orderDetail.ActiveContext = base.ActiveContext;
			}
			if(_paymentOrder!=null)
			{
				_paymentOrder.ActiveContext = base.ActiveContext;
			}
			if(_refundRequest!=null)
			{
				_refundRequest.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaRefundRequest!=null)
			{
				_lookupCollectionViaRefundRequest.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaOrderDetail!=null)
			{
				_lookupCollectionViaOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_orderItemCollectionViaOrderDetail!=null)
			{
				_orderItemCollectionViaOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaRefundRequest!=null)
			{
				_organizationRoleUserCollectionViaRefundRequest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaRefundRequest_!=null)
			{
				_organizationRoleUserCollectionViaRefundRequest_.ActiveContext = base.ActiveContext;
			}
			if(_paymentCollectionViaPaymentOrder!=null)
			{
				_paymentCollectionViaPaymentOrder.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_orderDetail = null;
			_paymentOrder = null;
			_refundRequest = null;
			_lookupCollectionViaRefundRequest = null;
			_lookupCollectionViaOrderDetail = null;
			_orderItemCollectionViaOrderDetail = null;
			_organizationRoleUserCollectionViaRefundRequest = null;
			_organizationRoleUserCollectionViaRefundRequest_ = null;
			_paymentCollectionViaPaymentOrder = null;


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

			_fieldsCustomProperties.Add("OrderId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Type", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserCreatorId", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OrderEntity</param>
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
		public  static OrderRelations Relations
		{
			get	{ return new OrderRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrderDetail")[0], (int)Falcon.Data.EntityType.OrderEntity, (int)Falcon.Data.EntityType.OrderDetailEntity, 0, null, null, null, null, "OrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PaymentOrder' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentOrder
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PaymentOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentOrderEntityFactory))),
					(IEntityRelation)GetRelationsForField("PaymentOrder")[0], (int)Falcon.Data.EntityType.OrderEntity, (int)Falcon.Data.EntityType.PaymentOrderEntity, 0, null, null, null, null, "PaymentOrder", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundRequest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundRequest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))),
					(IEntityRelation)GetRelationsForField("RefundRequest")[0], (int)Falcon.Data.EntityType.OrderEntity, (int)Falcon.Data.EntityType.RefundRequestEntity, 0, null, null, null, null, "RefundRequest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaRefundRequest
		{
			get
			{
				IEntityRelation intermediateRelation = OrderEntity.Relations.RefundRequestEntityUsingOrderId;
				intermediateRelation.SetAliases(string.Empty, "RefundRequest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaRefundRequest"), null, "LookupCollectionViaRefundRequest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaOrderDetail
		{
			get
			{
				IEntityRelation intermediateRelation = OrderEntity.Relations.OrderDetailEntityUsingOrderId;
				intermediateRelation.SetAliases(string.Empty, "OrderDetail_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaOrderDetail"), null, "LookupCollectionViaOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderItemCollectionViaOrderDetail
		{
			get
			{
				IEntityRelation intermediateRelation = OrderEntity.Relations.OrderDetailEntityUsingOrderId;
				intermediateRelation.SetAliases(string.Empty, "OrderDetail_");
				return new PrefetchPathElement2(new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderEntity, (int)Falcon.Data.EntityType.OrderItemEntity, 0, null, null, GetRelationsForField("OrderItemCollectionViaOrderDetail"), null, "OrderItemCollectionViaOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaRefundRequest
		{
			get
			{
				IEntityRelation intermediateRelation = OrderEntity.Relations.RefundRequestEntityUsingOrderId;
				intermediateRelation.SetAliases(string.Empty, "RefundRequest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaRefundRequest"), null, "OrganizationRoleUserCollectionViaRefundRequest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaRefundRequest_
		{
			get
			{
				IEntityRelation intermediateRelation = OrderEntity.Relations.RefundRequestEntityUsingOrderId;
				intermediateRelation.SetAliases(string.Empty, "RefundRequest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaRefundRequest_"), null, "OrganizationRoleUserCollectionViaRefundRequest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Payment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentCollectionViaPaymentOrder
		{
			get
			{
				IEntityRelation intermediateRelation = OrderEntity.Relations.PaymentOrderEntityUsingOrderId;
				intermediateRelation.SetAliases(string.Empty, "PaymentOrder_");
				return new PrefetchPathElement2(new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrderEntity, (int)Falcon.Data.EntityType.PaymentEntity, 0, null, null, GetRelationsForField("PaymentCollectionViaPaymentOrder"), null, "PaymentCollectionViaPaymentOrder", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OrderEntity.CustomProperties;}
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
			get { return OrderEntity.FieldsCustomProperties;}
		}

		/// <summary> The OrderId property of the Entity Order<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrder"."OrderID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 OrderId
		{
			get { return (System.Int64)GetValue((int)OrderFieldIndex.OrderId, true); }
			set	{ SetValue((int)OrderFieldIndex.OrderId, value); }
		}

		/// <summary> The Type property of the Entity Order<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrder"."Type"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte Type
		{
			get { return (System.Byte)GetValue((int)OrderFieldIndex.Type, true); }
			set	{ SetValue((int)OrderFieldIndex.Type, value); }
		}

		/// <summary> The DateCreated property of the Entity Order<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrder"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)OrderFieldIndex.DateCreated, true); }
			set	{ SetValue((int)OrderFieldIndex.DateCreated, value); }
		}

		/// <summary> The OrganizationRoleUserCreatorId property of the Entity Order<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrder"."OrganizationRoleUserCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationRoleUserCreatorId
		{
			get { return (System.Int64)GetValue((int)OrderFieldIndex.OrganizationRoleUserCreatorId, true); }
			set	{ SetValue((int)OrderFieldIndex.OrganizationRoleUserCreatorId, value); }
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
					_orderDetail.SetContainingEntityInfo(this, "Order");
				}
				return _orderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PaymentOrderEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PaymentOrderEntity))]
		public virtual EntityCollection<PaymentOrderEntity> PaymentOrder
		{
			get
			{
				if(_paymentOrder==null)
				{
					_paymentOrder = new EntityCollection<PaymentOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentOrderEntityFactory)));
					_paymentOrder.SetContainingEntityInfo(this, "Order");
				}
				return _paymentOrder;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RefundRequestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RefundRequestEntity))]
		public virtual EntityCollection<RefundRequestEntity> RefundRequest
		{
			get
			{
				if(_refundRequest==null)
				{
					_refundRequest = new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory)));
					_refundRequest.SetContainingEntityInfo(this, "Order");
				}
				return _refundRequest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaRefundRequest
		{
			get
			{
				if(_lookupCollectionViaRefundRequest==null)
				{
					_lookupCollectionViaRefundRequest = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaRefundRequest.IsReadOnly=true;
				}
				return _lookupCollectionViaRefundRequest;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderItemEntity))]
		public virtual EntityCollection<OrderItemEntity> OrderItemCollectionViaOrderDetail
		{
			get
			{
				if(_orderItemCollectionViaOrderDetail==null)
				{
					_orderItemCollectionViaOrderDetail = new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory)));
					_orderItemCollectionViaOrderDetail.IsReadOnly=true;
				}
				return _orderItemCollectionViaOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaRefundRequest
		{
			get
			{
				if(_organizationRoleUserCollectionViaRefundRequest==null)
				{
					_organizationRoleUserCollectionViaRefundRequest = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaRefundRequest.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaRefundRequest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaRefundRequest_
		{
			get
			{
				if(_organizationRoleUserCollectionViaRefundRequest_==null)
				{
					_organizationRoleUserCollectionViaRefundRequest_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaRefundRequest_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaRefundRequest_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PaymentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PaymentEntity))]
		public virtual EntityCollection<PaymentEntity> PaymentCollectionViaPaymentOrder
		{
			get
			{
				if(_paymentCollectionViaPaymentOrder==null)
				{
					_paymentCollectionViaPaymentOrder = new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory)));
					_paymentCollectionViaPaymentOrder.IsReadOnly=true;
				}
				return _paymentCollectionViaPaymentOrder;
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
			get { return (int)Falcon.Data.EntityType.OrderEntity; }
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
