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
	/// Entity class which represents the entity 'Refund'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class RefundEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<RefundOrderItemEntity> _refundOrderItem;
		private EntityCollection<OrderItemEntity> _orderItemCollectionViaRefundOrderItem;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name RefundOrderItem</summary>
			public static readonly string RefundOrderItem = "RefundOrderItem";
			/// <summary>Member name OrderItemCollectionViaRefundOrderItem</summary>
			public static readonly string OrderItemCollectionViaRefundOrderItem = "OrderItemCollectionViaRefundOrderItem";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static RefundEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public RefundEntity():base("RefundEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public RefundEntity(IEntityFields2 fields):base("RefundEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this RefundEntity</param>
		public RefundEntity(IValidator validator):base("RefundEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="refundId">PK value for Refund which data should be fetched into this Refund object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RefundEntity(System.Int64 refundId):base("RefundEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.RefundId = refundId;
		}

		/// <summary> CTor</summary>
		/// <param name="refundId">PK value for Refund which data should be fetched into this Refund object</param>
		/// <param name="validator">The custom validator object for this RefundEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RefundEntity(System.Int64 refundId, IValidator validator):base("RefundEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.RefundId = refundId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected RefundEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_refundOrderItem = (EntityCollection<RefundOrderItemEntity>)info.GetValue("_refundOrderItem", typeof(EntityCollection<RefundOrderItemEntity>));
				_orderItemCollectionViaRefundOrderItem = (EntityCollection<OrderItemEntity>)info.GetValue("_orderItemCollectionViaRefundOrderItem", typeof(EntityCollection<OrderItemEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((RefundFieldIndex)fieldIndex)
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

				case "RefundOrderItem":
					this.RefundOrderItem.Add((RefundOrderItemEntity)entity);
					break;
				case "OrderItemCollectionViaRefundOrderItem":
					this.OrderItemCollectionViaRefundOrderItem.IsReadOnly = false;
					this.OrderItemCollectionViaRefundOrderItem.Add((OrderItemEntity)entity);
					this.OrderItemCollectionViaRefundOrderItem.IsReadOnly = true;
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
			return RefundEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "RefundOrderItem":
					toReturn.Add(RefundEntity.Relations.RefundOrderItemEntityUsingRefundId);
					break;
				case "OrderItemCollectionViaRefundOrderItem":
					toReturn.Add(RefundEntity.Relations.RefundOrderItemEntityUsingRefundId, "RefundEntity__", "RefundOrderItem_", JoinHint.None);
					toReturn.Add(RefundOrderItemEntity.Relations.OrderItemEntityUsingOrderItemId, "RefundOrderItem_", string.Empty, JoinHint.None);
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

				case "RefundOrderItem":
					this.RefundOrderItem.Add((RefundOrderItemEntity)relatedEntity);
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

				case "RefundOrderItem":
					base.PerformRelatedEntityRemoval(this.RefundOrderItem, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.RefundOrderItem);

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
				info.AddValue("_refundOrderItem", ((_refundOrderItem!=null) && (_refundOrderItem.Count>0) && !this.MarkedForDeletion)?_refundOrderItem:null);
				info.AddValue("_orderItemCollectionViaRefundOrderItem", ((_orderItemCollectionViaRefundOrderItem!=null) && (_orderItemCollectionViaRefundOrderItem.Count>0) && !this.MarkedForDeletion)?_orderItemCollectionViaRefundOrderItem:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(RefundFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(RefundFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new RefundRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RefundOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundOrderItemFields.RefundId, null, ComparisonOperator.Equal, this.RefundId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderItemCollectionViaRefundOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderItemCollectionViaRefundOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundFields.RefundId, null, ComparisonOperator.Equal, this.RefundId, "RefundEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.RefundEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(RefundEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._refundOrderItem);
			collectionsQueue.Enqueue(this._orderItemCollectionViaRefundOrderItem);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._refundOrderItem = (EntityCollection<RefundOrderItemEntity>) collectionsQueue.Dequeue();
			this._orderItemCollectionViaRefundOrderItem = (EntityCollection<OrderItemEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._refundOrderItem != null)
			{
				return true;
			}
			if (this._orderItemCollectionViaRefundOrderItem != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("RefundOrderItem", _refundOrderItem);
			toReturn.Add("OrderItemCollectionViaRefundOrderItem", _orderItemCollectionViaRefundOrderItem);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_refundOrderItem!=null)
			{
				_refundOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_orderItemCollectionViaRefundOrderItem!=null)
			{
				_orderItemCollectionViaRefundOrderItem.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_refundOrderItem = null;
			_orderItemCollectionViaRefundOrderItem = null;


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

			_fieldsCustomProperties.Add("RefundId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Amount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserCreatorId", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this RefundEntity</param>
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
		public  static RefundRelations Relations
		{
			get	{ return new RefundRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RefundOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("RefundOrderItem")[0], (int)Falcon.Data.EntityType.RefundEntity, (int)Falcon.Data.EntityType.RefundOrderItemEntity, 0, null, null, null, null, "RefundOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderItemCollectionViaRefundOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = RefundEntity.Relations.RefundOrderItemEntityUsingRefundId;
				intermediateRelation.SetAliases(string.Empty, "RefundOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RefundEntity, (int)Falcon.Data.EntityType.OrderItemEntity, 0, null, null, GetRelationsForField("OrderItemCollectionViaRefundOrderItem"), null, "OrderItemCollectionViaRefundOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return RefundEntity.CustomProperties;}
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
			get { return RefundEntity.FieldsCustomProperties;}
		}

		/// <summary> The RefundId property of the Entity Refund<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefund"."RefundID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 RefundId
		{
			get { return (System.Int64)GetValue((int)RefundFieldIndex.RefundId, true); }
			set	{ SetValue((int)RefundFieldIndex.RefundId, value); }
		}

		/// <summary> The ReasonId property of the Entity Refund<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefund"."ReasonID"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 ReasonId
		{
			get { return (System.Int16)GetValue((int)RefundFieldIndex.ReasonId, true); }
			set	{ SetValue((int)RefundFieldIndex.ReasonId, value); }
		}

		/// <summary> The Amount property of the Entity Refund<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefund"."Amount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Amount
		{
			get { return (System.Decimal)GetValue((int)RefundFieldIndex.Amount, true); }
			set	{ SetValue((int)RefundFieldIndex.Amount, value); }
		}

		/// <summary> The Notes property of the Entity Refund<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefund"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)RefundFieldIndex.Notes, true); }
			set	{ SetValue((int)RefundFieldIndex.Notes, value); }
		}

		/// <summary> The DateCreated property of the Entity Refund<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefund"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)RefundFieldIndex.DateCreated, true); }
			set	{ SetValue((int)RefundFieldIndex.DateCreated, value); }
		}

		/// <summary> The OrganizationRoleUserCreatorId property of the Entity Refund<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefund"."OrganizationRoleUserCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationRoleUserCreatorId
		{
			get { return (System.Int64)GetValue((int)RefundFieldIndex.OrganizationRoleUserCreatorId, true); }
			set	{ SetValue((int)RefundFieldIndex.OrganizationRoleUserCreatorId, value); }
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
					_refundOrderItem.SetContainingEntityInfo(this, "Refund");
				}
				return _refundOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderItemEntity))]
		public virtual EntityCollection<OrderItemEntity> OrderItemCollectionViaRefundOrderItem
		{
			get
			{
				if(_orderItemCollectionViaRefundOrderItem==null)
				{
					_orderItemCollectionViaRefundOrderItem = new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory)));
					_orderItemCollectionViaRefundOrderItem.IsReadOnly=true;
				}
				return _orderItemCollectionViaRefundOrderItem;
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
			get { return (int)Falcon.Data.EntityType.RefundEntity; }
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
