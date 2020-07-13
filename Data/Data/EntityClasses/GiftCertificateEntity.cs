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
	/// Entity class which represents the entity 'GiftCertificate'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class GiftCertificateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<GiftCertificateOrderItemEntity> _giftCertificateOrderItem;
		private EntityCollection<GiftCertificatePaymentEntity> _giftCertificatePayment;
		private EntityCollection<RefundRequestGiftCertificateEntity> _refundRequestGiftCertificate;
		private EntityCollection<OrderItemEntity> _orderItemCollectionViaGiftCertificateOrderItem;
		private EntityCollection<PaymentEntity> _paymentCollectionViaGiftCertificatePayment;
		private EntityCollection<RefundRequestEntity> _refundRequestCollectionViaRefundRequestGiftCertificate;
		private GiftCertificateTypeEntity _giftCertificateType;
		private PackageEntity _package;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name GiftCertificateType</summary>
			public static readonly string GiftCertificateType = "GiftCertificateType";
			/// <summary>Member name Package</summary>
			public static readonly string Package = "Package";
			/// <summary>Member name GiftCertificateOrderItem</summary>
			public static readonly string GiftCertificateOrderItem = "GiftCertificateOrderItem";
			/// <summary>Member name GiftCertificatePayment</summary>
			public static readonly string GiftCertificatePayment = "GiftCertificatePayment";
			/// <summary>Member name RefundRequestGiftCertificate</summary>
			public static readonly string RefundRequestGiftCertificate = "RefundRequestGiftCertificate";
			/// <summary>Member name OrderItemCollectionViaGiftCertificateOrderItem</summary>
			public static readonly string OrderItemCollectionViaGiftCertificateOrderItem = "OrderItemCollectionViaGiftCertificateOrderItem";
			/// <summary>Member name PaymentCollectionViaGiftCertificatePayment</summary>
			public static readonly string PaymentCollectionViaGiftCertificatePayment = "PaymentCollectionViaGiftCertificatePayment";
			/// <summary>Member name RefundRequestCollectionViaRefundRequestGiftCertificate</summary>
			public static readonly string RefundRequestCollectionViaRefundRequestGiftCertificate = "RefundRequestCollectionViaRefundRequestGiftCertificate";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static GiftCertificateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public GiftCertificateEntity():base("GiftCertificateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public GiftCertificateEntity(IEntityFields2 fields):base("GiftCertificateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this GiftCertificateEntity</param>
		public GiftCertificateEntity(IValidator validator):base("GiftCertificateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="giftCertificateId">PK value for GiftCertificate which data should be fetched into this GiftCertificate object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GiftCertificateEntity(System.Int64 giftCertificateId):base("GiftCertificateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.GiftCertificateId = giftCertificateId;
		}

		/// <summary> CTor</summary>
		/// <param name="giftCertificateId">PK value for GiftCertificate which data should be fetched into this GiftCertificate object</param>
		/// <param name="validator">The custom validator object for this GiftCertificateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GiftCertificateEntity(System.Int64 giftCertificateId, IValidator validator):base("GiftCertificateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.GiftCertificateId = giftCertificateId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected GiftCertificateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_giftCertificateOrderItem = (EntityCollection<GiftCertificateOrderItemEntity>)info.GetValue("_giftCertificateOrderItem", typeof(EntityCollection<GiftCertificateOrderItemEntity>));
				_giftCertificatePayment = (EntityCollection<GiftCertificatePaymentEntity>)info.GetValue("_giftCertificatePayment", typeof(EntityCollection<GiftCertificatePaymentEntity>));
				_refundRequestGiftCertificate = (EntityCollection<RefundRequestGiftCertificateEntity>)info.GetValue("_refundRequestGiftCertificate", typeof(EntityCollection<RefundRequestGiftCertificateEntity>));
				_orderItemCollectionViaGiftCertificateOrderItem = (EntityCollection<OrderItemEntity>)info.GetValue("_orderItemCollectionViaGiftCertificateOrderItem", typeof(EntityCollection<OrderItemEntity>));
				_paymentCollectionViaGiftCertificatePayment = (EntityCollection<PaymentEntity>)info.GetValue("_paymentCollectionViaGiftCertificatePayment", typeof(EntityCollection<PaymentEntity>));
				_refundRequestCollectionViaRefundRequestGiftCertificate = (EntityCollection<RefundRequestEntity>)info.GetValue("_refundRequestCollectionViaRefundRequestGiftCertificate", typeof(EntityCollection<RefundRequestEntity>));
				_giftCertificateType = (GiftCertificateTypeEntity)info.GetValue("_giftCertificateType", typeof(GiftCertificateTypeEntity));
				if(_giftCertificateType!=null)
				{
					_giftCertificateType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_package = (PackageEntity)info.GetValue("_package", typeof(PackageEntity));
				if(_package!=null)
				{
					_package.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((GiftCertificateFieldIndex)fieldIndex)
			{
				case GiftCertificateFieldIndex.TypeId:
					DesetupSyncGiftCertificateType(true, false);
					break;
				case GiftCertificateFieldIndex.ApplicablePackageId:
					DesetupSyncPackage(true, false);
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
				case "GiftCertificateType":
					this.GiftCertificateType = (GiftCertificateTypeEntity)entity;
					break;
				case "Package":
					this.Package = (PackageEntity)entity;
					break;
				case "GiftCertificateOrderItem":
					this.GiftCertificateOrderItem.Add((GiftCertificateOrderItemEntity)entity);
					break;
				case "GiftCertificatePayment":
					this.GiftCertificatePayment.Add((GiftCertificatePaymentEntity)entity);
					break;
				case "RefundRequestGiftCertificate":
					this.RefundRequestGiftCertificate.Add((RefundRequestGiftCertificateEntity)entity);
					break;
				case "OrderItemCollectionViaGiftCertificateOrderItem":
					this.OrderItemCollectionViaGiftCertificateOrderItem.IsReadOnly = false;
					this.OrderItemCollectionViaGiftCertificateOrderItem.Add((OrderItemEntity)entity);
					this.OrderItemCollectionViaGiftCertificateOrderItem.IsReadOnly = true;
					break;
				case "PaymentCollectionViaGiftCertificatePayment":
					this.PaymentCollectionViaGiftCertificatePayment.IsReadOnly = false;
					this.PaymentCollectionViaGiftCertificatePayment.Add((PaymentEntity)entity);
					this.PaymentCollectionViaGiftCertificatePayment.IsReadOnly = true;
					break;
				case "RefundRequestCollectionViaRefundRequestGiftCertificate":
					this.RefundRequestCollectionViaRefundRequestGiftCertificate.IsReadOnly = false;
					this.RefundRequestCollectionViaRefundRequestGiftCertificate.Add((RefundRequestEntity)entity);
					this.RefundRequestCollectionViaRefundRequestGiftCertificate.IsReadOnly = true;
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
			return GiftCertificateEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "GiftCertificateType":
					toReturn.Add(GiftCertificateEntity.Relations.GiftCertificateTypeEntityUsingTypeId);
					break;
				case "Package":
					toReturn.Add(GiftCertificateEntity.Relations.PackageEntityUsingApplicablePackageId);
					break;
				case "GiftCertificateOrderItem":
					toReturn.Add(GiftCertificateEntity.Relations.GiftCertificateOrderItemEntityUsingGiftCertificateId);
					break;
				case "GiftCertificatePayment":
					toReturn.Add(GiftCertificateEntity.Relations.GiftCertificatePaymentEntityUsingGiftCertificateId);
					break;
				case "RefundRequestGiftCertificate":
					toReturn.Add(GiftCertificateEntity.Relations.RefundRequestGiftCertificateEntityUsingGiftCertificateId);
					break;
				case "OrderItemCollectionViaGiftCertificateOrderItem":
					toReturn.Add(GiftCertificateEntity.Relations.GiftCertificateOrderItemEntityUsingGiftCertificateId, "GiftCertificateEntity__", "GiftCertificateOrderItem_", JoinHint.None);
					toReturn.Add(GiftCertificateOrderItemEntity.Relations.OrderItemEntityUsingOrderItemId, "GiftCertificateOrderItem_", string.Empty, JoinHint.None);
					break;
				case "PaymentCollectionViaGiftCertificatePayment":
					toReturn.Add(GiftCertificateEntity.Relations.GiftCertificatePaymentEntityUsingGiftCertificateId, "GiftCertificateEntity__", "GiftCertificatePayment_", JoinHint.None);
					toReturn.Add(GiftCertificatePaymentEntity.Relations.PaymentEntityUsingPaymentId, "GiftCertificatePayment_", string.Empty, JoinHint.None);
					break;
				case "RefundRequestCollectionViaRefundRequestGiftCertificate":
					toReturn.Add(GiftCertificateEntity.Relations.RefundRequestGiftCertificateEntityUsingGiftCertificateId, "GiftCertificateEntity__", "RefundRequestGiftCertificate_", JoinHint.None);
					toReturn.Add(RefundRequestGiftCertificateEntity.Relations.RefundRequestEntityUsingRefundRequestId, "RefundRequestGiftCertificate_", string.Empty, JoinHint.None);
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
				case "GiftCertificateType":
					SetupSyncGiftCertificateType(relatedEntity);
					break;
				case "Package":
					SetupSyncPackage(relatedEntity);
					break;
				case "GiftCertificateOrderItem":
					this.GiftCertificateOrderItem.Add((GiftCertificateOrderItemEntity)relatedEntity);
					break;
				case "GiftCertificatePayment":
					this.GiftCertificatePayment.Add((GiftCertificatePaymentEntity)relatedEntity);
					break;
				case "RefundRequestGiftCertificate":
					this.RefundRequestGiftCertificate.Add((RefundRequestGiftCertificateEntity)relatedEntity);
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
				case "GiftCertificateType":
					DesetupSyncGiftCertificateType(false, true);
					break;
				case "Package":
					DesetupSyncPackage(false, true);
					break;
				case "GiftCertificateOrderItem":
					base.PerformRelatedEntityRemoval(this.GiftCertificateOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "GiftCertificatePayment":
					base.PerformRelatedEntityRemoval(this.GiftCertificatePayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RefundRequestGiftCertificate":
					base.PerformRelatedEntityRemoval(this.RefundRequestGiftCertificate, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_giftCertificateType!=null)
			{
				toReturn.Add(_giftCertificateType);
			}
			if(_package!=null)
			{
				toReturn.Add(_package);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.GiftCertificateOrderItem);
			toReturn.Add(this.GiftCertificatePayment);
			toReturn.Add(this.RefundRequestGiftCertificate);

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
				info.AddValue("_giftCertificateOrderItem", ((_giftCertificateOrderItem!=null) && (_giftCertificateOrderItem.Count>0) && !this.MarkedForDeletion)?_giftCertificateOrderItem:null);
				info.AddValue("_giftCertificatePayment", ((_giftCertificatePayment!=null) && (_giftCertificatePayment.Count>0) && !this.MarkedForDeletion)?_giftCertificatePayment:null);
				info.AddValue("_refundRequestGiftCertificate", ((_refundRequestGiftCertificate!=null) && (_refundRequestGiftCertificate.Count>0) && !this.MarkedForDeletion)?_refundRequestGiftCertificate:null);
				info.AddValue("_orderItemCollectionViaGiftCertificateOrderItem", ((_orderItemCollectionViaGiftCertificateOrderItem!=null) && (_orderItemCollectionViaGiftCertificateOrderItem.Count>0) && !this.MarkedForDeletion)?_orderItemCollectionViaGiftCertificateOrderItem:null);
				info.AddValue("_paymentCollectionViaGiftCertificatePayment", ((_paymentCollectionViaGiftCertificatePayment!=null) && (_paymentCollectionViaGiftCertificatePayment.Count>0) && !this.MarkedForDeletion)?_paymentCollectionViaGiftCertificatePayment:null);
				info.AddValue("_refundRequestCollectionViaRefundRequestGiftCertificate", ((_refundRequestCollectionViaRefundRequestGiftCertificate!=null) && (_refundRequestCollectionViaRefundRequestGiftCertificate.Count>0) && !this.MarkedForDeletion)?_refundRequestCollectionViaRefundRequestGiftCertificate:null);
				info.AddValue("_giftCertificateType", (!this.MarkedForDeletion?_giftCertificateType:null));
				info.AddValue("_package", (!this.MarkedForDeletion?_package:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(GiftCertificateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(GiftCertificateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new GiftCertificateRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GiftCertificateOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificateOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GiftCertificateOrderItemFields.GiftCertificateId, null, ComparisonOperator.Equal, this.GiftCertificateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GiftCertificatePayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificatePayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GiftCertificatePaymentFields.GiftCertificateId, null, ComparisonOperator.Equal, this.GiftCertificateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RefundRequestGiftCertificate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundRequestGiftCertificate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestGiftCertificateFields.GiftCertificateId, null, ComparisonOperator.Equal, this.GiftCertificateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderItemCollectionViaGiftCertificateOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderItemCollectionViaGiftCertificateOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GiftCertificateFields.GiftCertificateId, null, ComparisonOperator.Equal, this.GiftCertificateId, "GiftCertificateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Payment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentCollectionViaGiftCertificatePayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PaymentCollectionViaGiftCertificatePayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GiftCertificateFields.GiftCertificateId, null, ComparisonOperator.Equal, this.GiftCertificateId, "GiftCertificateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RefundRequest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundRequestCollectionViaRefundRequestGiftCertificate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RefundRequestCollectionViaRefundRequestGiftCertificate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GiftCertificateFields.GiftCertificateId, null, ComparisonOperator.Equal, this.GiftCertificateId, "GiftCertificateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GiftCertificateType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificateType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GiftCertificateTypeFields.GiftCertificateTypeId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Package' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.ApplicablePackageId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.GiftCertificateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._giftCertificateOrderItem);
			collectionsQueue.Enqueue(this._giftCertificatePayment);
			collectionsQueue.Enqueue(this._refundRequestGiftCertificate);
			collectionsQueue.Enqueue(this._orderItemCollectionViaGiftCertificateOrderItem);
			collectionsQueue.Enqueue(this._paymentCollectionViaGiftCertificatePayment);
			collectionsQueue.Enqueue(this._refundRequestCollectionViaRefundRequestGiftCertificate);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._giftCertificateOrderItem = (EntityCollection<GiftCertificateOrderItemEntity>) collectionsQueue.Dequeue();
			this._giftCertificatePayment = (EntityCollection<GiftCertificatePaymentEntity>) collectionsQueue.Dequeue();
			this._refundRequestGiftCertificate = (EntityCollection<RefundRequestGiftCertificateEntity>) collectionsQueue.Dequeue();
			this._orderItemCollectionViaGiftCertificateOrderItem = (EntityCollection<OrderItemEntity>) collectionsQueue.Dequeue();
			this._paymentCollectionViaGiftCertificatePayment = (EntityCollection<PaymentEntity>) collectionsQueue.Dequeue();
			this._refundRequestCollectionViaRefundRequestGiftCertificate = (EntityCollection<RefundRequestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._giftCertificateOrderItem != null)
			{
				return true;
			}
			if (this._giftCertificatePayment != null)
			{
				return true;
			}
			if (this._refundRequestGiftCertificate != null)
			{
				return true;
			}
			if (this._orderItemCollectionViaGiftCertificateOrderItem != null)
			{
				return true;
			}
			if (this._paymentCollectionViaGiftCertificatePayment != null)
			{
				return true;
			}
			if (this._refundRequestCollectionViaRefundRequestGiftCertificate != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GiftCertificateOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GiftCertificatePaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificatePaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundRequestGiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestGiftCertificateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("GiftCertificateType", _giftCertificateType);
			toReturn.Add("Package", _package);
			toReturn.Add("GiftCertificateOrderItem", _giftCertificateOrderItem);
			toReturn.Add("GiftCertificatePayment", _giftCertificatePayment);
			toReturn.Add("RefundRequestGiftCertificate", _refundRequestGiftCertificate);
			toReturn.Add("OrderItemCollectionViaGiftCertificateOrderItem", _orderItemCollectionViaGiftCertificateOrderItem);
			toReturn.Add("PaymentCollectionViaGiftCertificatePayment", _paymentCollectionViaGiftCertificatePayment);
			toReturn.Add("RefundRequestCollectionViaRefundRequestGiftCertificate", _refundRequestCollectionViaRefundRequestGiftCertificate);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_giftCertificateOrderItem!=null)
			{
				_giftCertificateOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_giftCertificatePayment!=null)
			{
				_giftCertificatePayment.ActiveContext = base.ActiveContext;
			}
			if(_refundRequestGiftCertificate!=null)
			{
				_refundRequestGiftCertificate.ActiveContext = base.ActiveContext;
			}
			if(_orderItemCollectionViaGiftCertificateOrderItem!=null)
			{
				_orderItemCollectionViaGiftCertificateOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_paymentCollectionViaGiftCertificatePayment!=null)
			{
				_paymentCollectionViaGiftCertificatePayment.ActiveContext = base.ActiveContext;
			}
			if(_refundRequestCollectionViaRefundRequestGiftCertificate!=null)
			{
				_refundRequestCollectionViaRefundRequestGiftCertificate.ActiveContext = base.ActiveContext;
			}
			if(_giftCertificateType!=null)
			{
				_giftCertificateType.ActiveContext = base.ActiveContext;
			}
			if(_package!=null)
			{
				_package.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_giftCertificateOrderItem = null;
			_giftCertificatePayment = null;
			_refundRequestGiftCertificate = null;
			_orderItemCollectionViaGiftCertificateOrderItem = null;
			_paymentCollectionViaGiftCertificatePayment = null;
			_refundRequestCollectionViaRefundRequestGiftCertificate = null;
			_giftCertificateType = null;
			_package = null;

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

			_fieldsCustomProperties.Add("GiftCertificateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClaimCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Amount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FromName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ToName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Message", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ExpirationDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrgazizationRoleUserCreatorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ApplicablePackageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ToEmail", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _giftCertificateType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGiftCertificateType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _giftCertificateType, new PropertyChangedEventHandler( OnGiftCertificateTypePropertyChanged ), "GiftCertificateType", GiftCertificateEntity.Relations.GiftCertificateTypeEntityUsingTypeId, true, signalRelatedEntity, "GiftCertificate", resetFKFields, new int[] { (int)GiftCertificateFieldIndex.TypeId } );		
			_giftCertificateType = null;
		}

		/// <summary> setups the sync logic for member _giftCertificateType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGiftCertificateType(IEntity2 relatedEntity)
		{
			if(_giftCertificateType!=relatedEntity)
			{
				DesetupSyncGiftCertificateType(true, true);
				_giftCertificateType = (GiftCertificateTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _giftCertificateType, new PropertyChangedEventHandler( OnGiftCertificateTypePropertyChanged ), "GiftCertificateType", GiftCertificateEntity.Relations.GiftCertificateTypeEntityUsingTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGiftCertificateTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _package</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPackage(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _package, new PropertyChangedEventHandler( OnPackagePropertyChanged ), "Package", GiftCertificateEntity.Relations.PackageEntityUsingApplicablePackageId, true, signalRelatedEntity, "GiftCertificate", resetFKFields, new int[] { (int)GiftCertificateFieldIndex.ApplicablePackageId } );		
			_package = null;
		}

		/// <summary> setups the sync logic for member _package</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPackage(IEntity2 relatedEntity)
		{
			if(_package!=relatedEntity)
			{
				DesetupSyncPackage(true, true);
				_package = (PackageEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _package, new PropertyChangedEventHandler( OnPackagePropertyChanged ), "Package", GiftCertificateEntity.Relations.PackageEntityUsingApplicablePackageId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPackagePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this GiftCertificateEntity</param>
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
		public  static GiftCertificateRelations Relations
		{
			get	{ return new GiftCertificateRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificateOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificateOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GiftCertificateOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("GiftCertificateOrderItem")[0], (int)Falcon.Data.EntityType.GiftCertificateEntity, (int)Falcon.Data.EntityType.GiftCertificateOrderItemEntity, 0, null, null, null, null, "GiftCertificateOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificatePayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificatePayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GiftCertificatePaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificatePaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("GiftCertificatePayment")[0], (int)Falcon.Data.EntityType.GiftCertificateEntity, (int)Falcon.Data.EntityType.GiftCertificatePaymentEntity, 0, null, null, null, null, "GiftCertificatePayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundRequestGiftCertificate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundRequestGiftCertificate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RefundRequestGiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestGiftCertificateEntityFactory))),
					(IEntityRelation)GetRelationsForField("RefundRequestGiftCertificate")[0], (int)Falcon.Data.EntityType.GiftCertificateEntity, (int)Falcon.Data.EntityType.RefundRequestGiftCertificateEntity, 0, null, null, null, null, "RefundRequestGiftCertificate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderItemCollectionViaGiftCertificateOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = GiftCertificateEntity.Relations.GiftCertificateOrderItemEntityUsingGiftCertificateId;
				intermediateRelation.SetAliases(string.Empty, "GiftCertificateOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.GiftCertificateEntity, (int)Falcon.Data.EntityType.OrderItemEntity, 0, null, null, GetRelationsForField("OrderItemCollectionViaGiftCertificateOrderItem"), null, "OrderItemCollectionViaGiftCertificateOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Payment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentCollectionViaGiftCertificatePayment
		{
			get
			{
				IEntityRelation intermediateRelation = GiftCertificateEntity.Relations.GiftCertificatePaymentEntityUsingGiftCertificateId;
				intermediateRelation.SetAliases(string.Empty, "GiftCertificatePayment_");
				return new PrefetchPathElement2(new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.GiftCertificateEntity, (int)Falcon.Data.EntityType.PaymentEntity, 0, null, null, GetRelationsForField("PaymentCollectionViaGiftCertificatePayment"), null, "PaymentCollectionViaGiftCertificatePayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundRequest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundRequestCollectionViaRefundRequestGiftCertificate
		{
			get
			{
				IEntityRelation intermediateRelation = GiftCertificateEntity.Relations.RefundRequestGiftCertificateEntityUsingGiftCertificateId;
				intermediateRelation.SetAliases(string.Empty, "RefundRequestGiftCertificate_");
				return new PrefetchPathElement2(new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.GiftCertificateEntity, (int)Falcon.Data.EntityType.RefundRequestEntity, 0, null, null, GetRelationsForField("RefundRequestCollectionViaRefundRequestGiftCertificate"), null, "RefundRequestCollectionViaRefundRequestGiftCertificate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificateType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificateType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("GiftCertificateType")[0], (int)Falcon.Data.EntityType.GiftCertificateEntity, (int)Falcon.Data.EntityType.GiftCertificateTypeEntity, 0, null, null, null, null, "GiftCertificateType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackage
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("Package")[0], (int)Falcon.Data.EntityType.GiftCertificateEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, null, null, "Package", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return GiftCertificateEntity.CustomProperties;}
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
			get { return GiftCertificateEntity.FieldsCustomProperties;}
		}

		/// <summary> The GiftCertificateId property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."GiftCertificateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 GiftCertificateId
		{
			get { return (System.Int64)GetValue((int)GiftCertificateFieldIndex.GiftCertificateId, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.GiftCertificateId, value); }
		}

		/// <summary> The TypeId property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."TypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)GiftCertificateFieldIndex.TypeId, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.TypeId, value); }
		}

		/// <summary> The ClaimCode property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."ClaimCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ClaimCode
		{
			get { return (System.String)GetValue((int)GiftCertificateFieldIndex.ClaimCode, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.ClaimCode, value); }
		}

		/// <summary> The Amount property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."Amount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Amount
		{
			get { return (System.Decimal)GetValue((int)GiftCertificateFieldIndex.Amount, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.Amount, value); }
		}

		/// <summary> The FromName property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."FromName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FromName
		{
			get { return (System.String)GetValue((int)GiftCertificateFieldIndex.FromName, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.FromName, value); }
		}

		/// <summary> The ToName property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."ToName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ToName
		{
			get { return (System.String)GetValue((int)GiftCertificateFieldIndex.ToName, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.ToName, value); }
		}

		/// <summary> The Message property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."Message"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Message
		{
			get { return (System.String)GetValue((int)GiftCertificateFieldIndex.Message, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.Message, value); }
		}

		/// <summary> The ExpirationDate property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."ExpirationDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ExpirationDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)GiftCertificateFieldIndex.ExpirationDate, false); }
			set	{ SetValue((int)GiftCertificateFieldIndex.ExpirationDate, value); }
		}

		/// <summary> The DateCreated property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)GiftCertificateFieldIndex.DateCreated, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.DateCreated, value); }
		}

		/// <summary> The OrgazizationRoleUserCreatorId property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."OrgazizationRoleUserCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> OrgazizationRoleUserCreatorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)GiftCertificateFieldIndex.OrgazizationRoleUserCreatorId, false); }
			set	{ SetValue((int)GiftCertificateFieldIndex.OrgazizationRoleUserCreatorId, value); }
		}

		/// <summary> The ApplicablePackageId property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."ApplicablePackageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ApplicablePackageId
		{
			get { return (Nullable<System.Int64>)GetValue((int)GiftCertificateFieldIndex.ApplicablePackageId, false); }
			set	{ SetValue((int)GiftCertificateFieldIndex.ApplicablePackageId, value); }
		}

		/// <summary> The IsActive property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)GiftCertificateFieldIndex.IsActive, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.IsActive, value); }
		}

		/// <summary> The ToEmail property of the Entity GiftCertificate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblGiftCertificate"."ToEmail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ToEmail
		{
			get { return (System.String)GetValue((int)GiftCertificateFieldIndex.ToEmail, true); }
			set	{ SetValue((int)GiftCertificateFieldIndex.ToEmail, value); }
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
					_giftCertificateOrderItem.SetContainingEntityInfo(this, "GiftCertificate");
				}
				return _giftCertificateOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GiftCertificatePaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GiftCertificatePaymentEntity))]
		public virtual EntityCollection<GiftCertificatePaymentEntity> GiftCertificatePayment
		{
			get
			{
				if(_giftCertificatePayment==null)
				{
					_giftCertificatePayment = new EntityCollection<GiftCertificatePaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificatePaymentEntityFactory)));
					_giftCertificatePayment.SetContainingEntityInfo(this, "GiftCertificate");
				}
				return _giftCertificatePayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RefundRequestGiftCertificateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RefundRequestGiftCertificateEntity))]
		public virtual EntityCollection<RefundRequestGiftCertificateEntity> RefundRequestGiftCertificate
		{
			get
			{
				if(_refundRequestGiftCertificate==null)
				{
					_refundRequestGiftCertificate = new EntityCollection<RefundRequestGiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestGiftCertificateEntityFactory)));
					_refundRequestGiftCertificate.SetContainingEntityInfo(this, "GiftCertificate");
				}
				return _refundRequestGiftCertificate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderItemEntity))]
		public virtual EntityCollection<OrderItemEntity> OrderItemCollectionViaGiftCertificateOrderItem
		{
			get
			{
				if(_orderItemCollectionViaGiftCertificateOrderItem==null)
				{
					_orderItemCollectionViaGiftCertificateOrderItem = new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory)));
					_orderItemCollectionViaGiftCertificateOrderItem.IsReadOnly=true;
				}
				return _orderItemCollectionViaGiftCertificateOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PaymentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PaymentEntity))]
		public virtual EntityCollection<PaymentEntity> PaymentCollectionViaGiftCertificatePayment
		{
			get
			{
				if(_paymentCollectionViaGiftCertificatePayment==null)
				{
					_paymentCollectionViaGiftCertificatePayment = new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory)));
					_paymentCollectionViaGiftCertificatePayment.IsReadOnly=true;
				}
				return _paymentCollectionViaGiftCertificatePayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RefundRequestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RefundRequestEntity))]
		public virtual EntityCollection<RefundRequestEntity> RefundRequestCollectionViaRefundRequestGiftCertificate
		{
			get
			{
				if(_refundRequestCollectionViaRefundRequestGiftCertificate==null)
				{
					_refundRequestCollectionViaRefundRequestGiftCertificate = new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory)));
					_refundRequestCollectionViaRefundRequestGiftCertificate.IsReadOnly=true;
				}
				return _refundRequestCollectionViaRefundRequestGiftCertificate;
			}
		}

		/// <summary> Gets / sets related entity of type 'GiftCertificateTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GiftCertificateTypeEntity GiftCertificateType
		{
			get
			{
				return _giftCertificateType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGiftCertificateType(value);
				}
				else
				{
					if(value==null)
					{
						if(_giftCertificateType != null)
						{
							_giftCertificateType.UnsetRelatedEntity(this, "GiftCertificate");
						}
					}
					else
					{
						if(_giftCertificateType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "GiftCertificate");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PackageEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PackageEntity Package
		{
			get
			{
				return _package;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPackage(value);
				}
				else
				{
					if(value==null)
					{
						if(_package != null)
						{
							_package.UnsetRelatedEntity(this, "GiftCertificate");
						}
					}
					else
					{
						if(_package!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "GiftCertificate");
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
			get { return (int)Falcon.Data.EntityType.GiftCertificateEntity; }
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
