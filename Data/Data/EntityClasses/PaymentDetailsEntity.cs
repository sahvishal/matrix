///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:31 AM
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
using HealthYes.Data;
using HealthYes.Data.HelperClasses;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'PaymentDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PaymentDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CashPaymentDetailsEntity> _cashPaymentDetails;
		private EntityCollection<ChequePaymentDetailsEntity> _chequePaymentDetails;
		private EntityCollection<EcheckPaymentDetailsEntity> _echeckPaymentDetails;
		private EntityCollection<PaymentCouponsEntity> _paymentCoupons;
		private EntityCollection<CouponsEntity> _couponsCollectionViaPaymentCoupons;
		private EventCustomersEntity _eventCustomers;
		private PaymentTypeEntity _paymentType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
			/// <summary>Member name PaymentType</summary>
			public static readonly string PaymentType = "PaymentType";
			/// <summary>Member name CashPaymentDetails</summary>
			public static readonly string CashPaymentDetails = "CashPaymentDetails";
			/// <summary>Member name ChequePaymentDetails</summary>
			public static readonly string ChequePaymentDetails = "ChequePaymentDetails";
			/// <summary>Member name EcheckPaymentDetails</summary>
			public static readonly string EcheckPaymentDetails = "EcheckPaymentDetails";
			/// <summary>Member name PaymentCoupons</summary>
			public static readonly string PaymentCoupons = "PaymentCoupons";
			/// <summary>Member name CouponsCollectionViaPaymentCoupons</summary>
			public static readonly string CouponsCollectionViaPaymentCoupons = "CouponsCollectionViaPaymentCoupons";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PaymentDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PaymentDetailsEntity():base("PaymentDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PaymentDetailsEntity(IEntityFields2 fields):base("PaymentDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PaymentDetailsEntity</param>
		public PaymentDetailsEntity(IValidator validator):base("PaymentDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="paymentId">PK value for PaymentDetails which data should be fetched into this PaymentDetails object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PaymentDetailsEntity(System.Int64 paymentId):base("PaymentDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PaymentId = paymentId;
		}

		/// <summary> CTor</summary>
		/// <param name="paymentId">PK value for PaymentDetails which data should be fetched into this PaymentDetails object</param>
		/// <param name="validator">The custom validator object for this PaymentDetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PaymentDetailsEntity(System.Int64 paymentId, IValidator validator):base("PaymentDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PaymentId = paymentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PaymentDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_cashPaymentDetails = (EntityCollection<CashPaymentDetailsEntity>)info.GetValue("_cashPaymentDetails", typeof(EntityCollection<CashPaymentDetailsEntity>));
				_chequePaymentDetails = (EntityCollection<ChequePaymentDetailsEntity>)info.GetValue("_chequePaymentDetails", typeof(EntityCollection<ChequePaymentDetailsEntity>));
				_echeckPaymentDetails = (EntityCollection<EcheckPaymentDetailsEntity>)info.GetValue("_echeckPaymentDetails", typeof(EntityCollection<EcheckPaymentDetailsEntity>));
				_paymentCoupons = (EntityCollection<PaymentCouponsEntity>)info.GetValue("_paymentCoupons", typeof(EntityCollection<PaymentCouponsEntity>));
				_couponsCollectionViaPaymentCoupons = (EntityCollection<CouponsEntity>)info.GetValue("_couponsCollectionViaPaymentCoupons", typeof(EntityCollection<CouponsEntity>));
				_eventCustomers = (EventCustomersEntity)info.GetValue("_eventCustomers", typeof(EventCustomersEntity));
				if(_eventCustomers!=null)
				{
					_eventCustomers.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_paymentType = (PaymentTypeEntity)info.GetValue("_paymentType", typeof(PaymentTypeEntity));
				if(_paymentType!=null)
				{
					_paymentType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PaymentDetailsFieldIndex)fieldIndex)
			{
				case PaymentDetailsFieldIndex.PaymentTypeId:
					DesetupSyncPaymentType(true, false);
					break;
				case PaymentDetailsFieldIndex.EventCustomerId:
					DesetupSyncEventCustomers(true, false);
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
				case "EventCustomers":
					this.EventCustomers = (EventCustomersEntity)entity;
					break;
				case "PaymentType":
					this.PaymentType = (PaymentTypeEntity)entity;
					break;
				case "CashPaymentDetails":
					this.CashPaymentDetails.Add((CashPaymentDetailsEntity)entity);
					break;
				case "ChequePaymentDetails":
					this.ChequePaymentDetails.Add((ChequePaymentDetailsEntity)entity);
					break;
				case "EcheckPaymentDetails":
					this.EcheckPaymentDetails.Add((EcheckPaymentDetailsEntity)entity);
					break;
				case "PaymentCoupons":
					this.PaymentCoupons.Add((PaymentCouponsEntity)entity);
					break;
				case "CouponsCollectionViaPaymentCoupons":
					this.CouponsCollectionViaPaymentCoupons.IsReadOnly = false;
					this.CouponsCollectionViaPaymentCoupons.Add((CouponsEntity)entity);
					this.CouponsCollectionViaPaymentCoupons.IsReadOnly = true;
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
			return PaymentDetailsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "EventCustomers":
					toReturn.Add(PaymentDetailsEntity.Relations.EventCustomersEntityUsingEventCustomerId);
					break;
				case "PaymentType":
					toReturn.Add(PaymentDetailsEntity.Relations.PaymentTypeEntityUsingPaymentTypeId);
					break;
				case "CashPaymentDetails":
					toReturn.Add(PaymentDetailsEntity.Relations.CashPaymentDetailsEntityUsingPaymentId);
					break;
				case "ChequePaymentDetails":
					toReturn.Add(PaymentDetailsEntity.Relations.ChequePaymentDetailsEntityUsingPaymentId);
					break;
				case "EcheckPaymentDetails":
					toReturn.Add(PaymentDetailsEntity.Relations.EcheckPaymentDetailsEntityUsingPaymentId);
					break;
				case "PaymentCoupons":
					toReturn.Add(PaymentDetailsEntity.Relations.PaymentCouponsEntityUsingPaymentDetailsId);
					break;
				case "CouponsCollectionViaPaymentCoupons":
					toReturn.Add(PaymentDetailsEntity.Relations.PaymentCouponsEntityUsingPaymentDetailsId, "PaymentDetailsEntity__", "PaymentCoupons_", JoinHint.None);
					toReturn.Add(PaymentCouponsEntity.Relations.CouponsEntityUsingCouponId, "PaymentCoupons_", string.Empty, JoinHint.None);
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
				case "EventCustomers":
					SetupSyncEventCustomers(relatedEntity);
					break;
				case "PaymentType":
					SetupSyncPaymentType(relatedEntity);
					break;
				case "CashPaymentDetails":
					this.CashPaymentDetails.Add((CashPaymentDetailsEntity)relatedEntity);
					break;
				case "ChequePaymentDetails":
					this.ChequePaymentDetails.Add((ChequePaymentDetailsEntity)relatedEntity);
					break;
				case "EcheckPaymentDetails":
					this.EcheckPaymentDetails.Add((EcheckPaymentDetailsEntity)relatedEntity);
					break;
				case "PaymentCoupons":
					this.PaymentCoupons.Add((PaymentCouponsEntity)relatedEntity);
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
				case "EventCustomers":
					DesetupSyncEventCustomers(false, true);
					break;
				case "PaymentType":
					DesetupSyncPaymentType(false, true);
					break;
				case "CashPaymentDetails":
					base.PerformRelatedEntityRemoval(this.CashPaymentDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ChequePaymentDetails":
					base.PerformRelatedEntityRemoval(this.ChequePaymentDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EcheckPaymentDetails":
					base.PerformRelatedEntityRemoval(this.EcheckPaymentDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PaymentCoupons":
					base.PerformRelatedEntityRemoval(this.PaymentCoupons, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_eventCustomers!=null)
			{
				toReturn.Add(_eventCustomers);
			}
			if(_paymentType!=null)
			{
				toReturn.Add(_paymentType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CashPaymentDetails);
			toReturn.Add(this.ChequePaymentDetails);
			toReturn.Add(this.EcheckPaymentDetails);
			toReturn.Add(this.PaymentCoupons);

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
				info.AddValue("_cashPaymentDetails", ((_cashPaymentDetails!=null) && (_cashPaymentDetails.Count>0) && !this.MarkedForDeletion)?_cashPaymentDetails:null);
				info.AddValue("_chequePaymentDetails", ((_chequePaymentDetails!=null) && (_chequePaymentDetails.Count>0) && !this.MarkedForDeletion)?_chequePaymentDetails:null);
				info.AddValue("_echeckPaymentDetails", ((_echeckPaymentDetails!=null) && (_echeckPaymentDetails.Count>0) && !this.MarkedForDeletion)?_echeckPaymentDetails:null);
				info.AddValue("_paymentCoupons", ((_paymentCoupons!=null) && (_paymentCoupons.Count>0) && !this.MarkedForDeletion)?_paymentCoupons:null);
				info.AddValue("_couponsCollectionViaPaymentCoupons", ((_couponsCollectionViaPaymentCoupons!=null) && (_couponsCollectionViaPaymentCoupons.Count>0) && !this.MarkedForDeletion)?_couponsCollectionViaPaymentCoupons:null);
				info.AddValue("_eventCustomers", (!this.MarkedForDeletion?_eventCustomers:null));
				info.AddValue("_paymentType", (!this.MarkedForDeletion?_paymentType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PaymentDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PaymentDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PaymentDetailsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CashPaymentDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCashPaymentDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CashPaymentDetailsFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChequePaymentDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChequePaymentDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChequePaymentDetailsFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EcheckPaymentDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEcheckPaymentDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EcheckPaymentDetailsFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PaymentCoupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentCoupons()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentCouponsFields.PaymentDetailsId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponsCollectionViaPaymentCoupons()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CouponsCollectionViaPaymentCoupons"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentDetailsFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId, "PaymentDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PaymentType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentTypeFields.PaymentTypeId, null, ComparisonOperator.Equal, this.PaymentTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.PaymentDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PaymentDetailsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._cashPaymentDetails);
			collectionsQueue.Enqueue(this._chequePaymentDetails);
			collectionsQueue.Enqueue(this._echeckPaymentDetails);
			collectionsQueue.Enqueue(this._paymentCoupons);
			collectionsQueue.Enqueue(this._couponsCollectionViaPaymentCoupons);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._cashPaymentDetails = (EntityCollection<CashPaymentDetailsEntity>) collectionsQueue.Dequeue();
			this._chequePaymentDetails = (EntityCollection<ChequePaymentDetailsEntity>) collectionsQueue.Dequeue();
			this._echeckPaymentDetails = (EntityCollection<EcheckPaymentDetailsEntity>) collectionsQueue.Dequeue();
			this._paymentCoupons = (EntityCollection<PaymentCouponsEntity>) collectionsQueue.Dequeue();
			this._couponsCollectionViaPaymentCoupons = (EntityCollection<CouponsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._cashPaymentDetails != null)
			{
				return true;
			}
			if (this._chequePaymentDetails != null)
			{
				return true;
			}
			if (this._echeckPaymentDetails != null)
			{
				return true;
			}
			if (this._paymentCoupons != null)
			{
				return true;
			}
			if (this._couponsCollectionViaPaymentCoupons != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CashPaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CashPaymentDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChequePaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChequePaymentDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EcheckPaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EcheckPaymentDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PaymentCouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentCouponsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("EventCustomers", _eventCustomers);
			toReturn.Add("PaymentType", _paymentType);
			toReturn.Add("CashPaymentDetails", _cashPaymentDetails);
			toReturn.Add("ChequePaymentDetails", _chequePaymentDetails);
			toReturn.Add("EcheckPaymentDetails", _echeckPaymentDetails);
			toReturn.Add("PaymentCoupons", _paymentCoupons);
			toReturn.Add("CouponsCollectionViaPaymentCoupons", _couponsCollectionViaPaymentCoupons);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_cashPaymentDetails!=null)
			{
				_cashPaymentDetails.ActiveContext = base.ActiveContext;
			}
			if(_chequePaymentDetails!=null)
			{
				_chequePaymentDetails.ActiveContext = base.ActiveContext;
			}
			if(_echeckPaymentDetails!=null)
			{
				_echeckPaymentDetails.ActiveContext = base.ActiveContext;
			}
			if(_paymentCoupons!=null)
			{
				_paymentCoupons.ActiveContext = base.ActiveContext;
			}
			if(_couponsCollectionViaPaymentCoupons!=null)
			{
				_couponsCollectionViaPaymentCoupons.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomers!=null)
			{
				_eventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_paymentType!=null)
			{
				_paymentType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_cashPaymentDetails = null;
			_chequePaymentDetails = null;
			_echeckPaymentDetails = null;
			_paymentCoupons = null;
			_couponsCollectionViaPaymentCoupons = null;
			_eventCustomers = null;
			_paymentType = null;

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

			_fieldsCustomProperties.Add("PaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentTotalAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentNet", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaidAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnpaidAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WiringId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DrOrCr", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPaid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorPayAccrId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentPayingId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _eventCustomers</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomers(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", PaymentDetailsEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, signalRelatedEntity, "PaymentDetails", resetFKFields, new int[] { (int)PaymentDetailsFieldIndex.EventCustomerId } );		
			_eventCustomers = null;
		}

		/// <summary> setups the sync logic for member _eventCustomers</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomers(IEntity2 relatedEntity)
		{
			if(_eventCustomers!=relatedEntity)
			{
				DesetupSyncEventCustomers(true, true);
				_eventCustomers = (EventCustomersEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", PaymentDetailsEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomersPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _paymentType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPaymentType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _paymentType, new PropertyChangedEventHandler( OnPaymentTypePropertyChanged ), "PaymentType", PaymentDetailsEntity.Relations.PaymentTypeEntityUsingPaymentTypeId, true, signalRelatedEntity, "PaymentDetails", resetFKFields, new int[] { (int)PaymentDetailsFieldIndex.PaymentTypeId } );		
			_paymentType = null;
		}

		/// <summary> setups the sync logic for member _paymentType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPaymentType(IEntity2 relatedEntity)
		{
			if(_paymentType!=relatedEntity)
			{
				DesetupSyncPaymentType(true, true);
				_paymentType = (PaymentTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _paymentType, new PropertyChangedEventHandler( OnPaymentTypePropertyChanged ), "PaymentType", PaymentDetailsEntity.Relations.PaymentTypeEntityUsingPaymentTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPaymentTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PaymentDetailsEntity</param>
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
		public  static PaymentDetailsRelations Relations
		{
			get	{ return new PaymentDetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CashPaymentDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCashPaymentDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CashPaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CashPaymentDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CashPaymentDetails")[0], (int)HealthYes.Data.EntityType.PaymentDetailsEntity, (int)HealthYes.Data.EntityType.CashPaymentDetailsEntity, 0, null, null, null, null, "CashPaymentDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChequePaymentDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChequePaymentDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChequePaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChequePaymentDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChequePaymentDetails")[0], (int)HealthYes.Data.EntityType.PaymentDetailsEntity, (int)HealthYes.Data.EntityType.ChequePaymentDetailsEntity, 0, null, null, null, null, "ChequePaymentDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EcheckPaymentDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEcheckPaymentDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EcheckPaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EcheckPaymentDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("EcheckPaymentDetails")[0], (int)HealthYes.Data.EntityType.PaymentDetailsEntity, (int)HealthYes.Data.EntityType.EcheckPaymentDetailsEntity, 0, null, null, null, null, "EcheckPaymentDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PaymentCoupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentCoupons
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PaymentCouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentCouponsEntityFactory))),
					(IEntityRelation)GetRelationsForField("PaymentCoupons")[0], (int)HealthYes.Data.EntityType.PaymentDetailsEntity, (int)HealthYes.Data.EntityType.PaymentCouponsEntity, 0, null, null, null, null, "PaymentCoupons", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponsCollectionViaPaymentCoupons
		{
			get
			{
				IEntityRelation intermediateRelation = PaymentDetailsEntity.Relations.PaymentCouponsEntityUsingPaymentDetailsId;
				intermediateRelation.SetAliases(string.Empty, "PaymentCoupons_");
				return new PrefetchPathElement2(new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.PaymentDetailsEntity, (int)HealthYes.Data.EntityType.CouponsEntity, 0, null, null, GetRelationsForField("CouponsCollectionViaPaymentCoupons"), null, "CouponsCollectionViaPaymentCoupons", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomers
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)HealthYes.Data.EntityType.PaymentDetailsEntity, (int)HealthYes.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PaymentType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PaymentTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("PaymentType")[0], (int)HealthYes.Data.EntityType.PaymentDetailsEntity, (int)HealthYes.Data.EntityType.PaymentTypeEntity, 0, null, null, null, null, "PaymentType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PaymentDetailsEntity.CustomProperties;}
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
			get { return PaymentDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The PaymentId property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."PaymentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PaymentId
		{
			get { return (System.Int64)GetValue((int)PaymentDetailsFieldIndex.PaymentId, true); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.PaymentId, value); }
		}

		/// <summary> The PaymentTotalAmount property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."PaymentTotalAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal PaymentTotalAmount
		{
			get { return (System.Decimal)GetValue((int)PaymentDetailsFieldIndex.PaymentTotalAmount, true); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.PaymentTotalAmount, value); }
		}

		/// <summary> The PaymentTypeId property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."PaymentTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PaymentTypeId
		{
			get { return (System.Int64)GetValue((int)PaymentDetailsFieldIndex.PaymentTypeId, true); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.PaymentTypeId, value); }
		}

		/// <summary> The DateCreated property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PaymentDetailsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)PaymentDetailsFieldIndex.DateModified, true); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.DateModified, value); }
		}

		/// <summary> The PaymentUserId property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."PaymentUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PaymentUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PaymentDetailsFieldIndex.PaymentUserId, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.PaymentUserId, value); }
		}

		/// <summary> The RoleId property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RoleId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PaymentDetailsFieldIndex.RoleId, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.RoleId, value); }
		}

		/// <summary> The PaymentNet property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."PaymentNet"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> PaymentNet
		{
			get { return (Nullable<System.Decimal>)GetValue((int)PaymentDetailsFieldIndex.PaymentNet, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.PaymentNet, value); }
		}

		/// <summary> The PaidAmount property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."PaidAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> PaidAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)PaymentDetailsFieldIndex.PaidAmount, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.PaidAmount, value); }
		}

		/// <summary> The UnpaidAmount property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."UnpaidAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> UnpaidAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)PaymentDetailsFieldIndex.UnpaidAmount, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.UnpaidAmount, value); }
		}

		/// <summary> The WiringId property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."WiringID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> WiringId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PaymentDetailsFieldIndex.WiringId, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.WiringId, value); }
		}

		/// <summary> The DrOrCr property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."DrOrCr"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> DrOrCr
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PaymentDetailsFieldIndex.DrOrCr, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.DrOrCr, value); }
		}

		/// <summary> The IsPaid property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."IsPaid"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPaid
		{
			get { return (System.Boolean)GetValue((int)PaymentDetailsFieldIndex.IsPaid, true); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.IsPaid, value); }
		}

		/// <summary> The EventCustomerId property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."EventCustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EventCustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PaymentDetailsFieldIndex.EventCustomerId, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.EventCustomerId, value); }
		}

		/// <summary> The MedicalVendorPayAccrId property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."MedicalVendorPayAccrID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MedicalVendorPayAccrId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PaymentDetailsFieldIndex.MedicalVendorPayAccrId, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.MedicalVendorPayAccrId, value); }
		}

		/// <summary> The ParentPayingId property of the Entity PaymentDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPaymentDetails_Legacy"."ParentPayingID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentPayingId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PaymentDetailsFieldIndex.ParentPayingId, false); }
			set	{ SetValue((int)PaymentDetailsFieldIndex.ParentPayingId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CashPaymentDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CashPaymentDetailsEntity))]
		public virtual EntityCollection<CashPaymentDetailsEntity> CashPaymentDetails
		{
			get
			{
				if(_cashPaymentDetails==null)
				{
					_cashPaymentDetails = new EntityCollection<CashPaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CashPaymentDetailsEntityFactory)));
					_cashPaymentDetails.SetContainingEntityInfo(this, "PaymentDetails");
				}
				return _cashPaymentDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChequePaymentDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChequePaymentDetailsEntity))]
		public virtual EntityCollection<ChequePaymentDetailsEntity> ChequePaymentDetails
		{
			get
			{
				if(_chequePaymentDetails==null)
				{
					_chequePaymentDetails = new EntityCollection<ChequePaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChequePaymentDetailsEntityFactory)));
					_chequePaymentDetails.SetContainingEntityInfo(this, "PaymentDetails");
				}
				return _chequePaymentDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EcheckPaymentDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EcheckPaymentDetailsEntity))]
		public virtual EntityCollection<EcheckPaymentDetailsEntity> EcheckPaymentDetails
		{
			get
			{
				if(_echeckPaymentDetails==null)
				{
					_echeckPaymentDetails = new EntityCollection<EcheckPaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EcheckPaymentDetailsEntityFactory)));
					_echeckPaymentDetails.SetContainingEntityInfo(this, "PaymentDetails");
				}
				return _echeckPaymentDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PaymentCouponsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PaymentCouponsEntity))]
		public virtual EntityCollection<PaymentCouponsEntity> PaymentCoupons
		{
			get
			{
				if(_paymentCoupons==null)
				{
					_paymentCoupons = new EntityCollection<PaymentCouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentCouponsEntityFactory)));
					_paymentCoupons.SetContainingEntityInfo(this, "PaymentDetails");
				}
				return _paymentCoupons;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouponsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouponsEntity))]
		public virtual EntityCollection<CouponsEntity> CouponsCollectionViaPaymentCoupons
		{
			get
			{
				if(_couponsCollectionViaPaymentCoupons==null)
				{
					_couponsCollectionViaPaymentCoupons = new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory)));
					_couponsCollectionViaPaymentCoupons.IsReadOnly=true;
				}
				return _couponsCollectionViaPaymentCoupons;
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomersEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomersEntity EventCustomers
		{
			get
			{
				return _eventCustomers;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomers(value);
				}
				else
				{
					if(value==null)
					{
						if(_eventCustomers != null)
						{
							_eventCustomers.UnsetRelatedEntity(this, "PaymentDetails");
						}
					}
					else
					{
						if(_eventCustomers!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PaymentDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PaymentTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PaymentTypeEntity PaymentType
		{
			get
			{
				return _paymentType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPaymentType(value);
				}
				else
				{
					if(value==null)
					{
						if(_paymentType != null)
						{
							_paymentType.UnsetRelatedEntity(this, "PaymentDetails");
						}
					}
					else
					{
						if(_paymentType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PaymentDetails");
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
		
		/// <summary>Returns the HealthYes.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)HealthYes.Data.EntityType.PaymentDetailsEntity; }
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
