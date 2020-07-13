///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:25 AM
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
	/// Entity class which represents the entity 'ResultOrderCatalog'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ResultOrderCatalogEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ResultOrderEntity> _resultOrder;
		private EntityCollection<OrderShippingInformationEntity> _orderShippingInformationCollectionViaResultOrder;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name ResultOrder</summary>
			public static readonly string ResultOrder = "ResultOrder";
			/// <summary>Member name OrderShippingInformationCollectionViaResultOrder</summary>
			public static readonly string OrderShippingInformationCollectionViaResultOrder = "OrderShippingInformationCollectionViaResultOrder";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ResultOrderCatalogEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ResultOrderCatalogEntity():base("ResultOrderCatalogEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ResultOrderCatalogEntity(IEntityFields2 fields):base("ResultOrderCatalogEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ResultOrderCatalogEntity</param>
		public ResultOrderCatalogEntity(IValidator validator):base("ResultOrderCatalogEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="resultOrderCatalogId">PK value for ResultOrderCatalog which data should be fetched into this ResultOrderCatalog object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ResultOrderCatalogEntity(System.Int64 resultOrderCatalogId):base("ResultOrderCatalogEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ResultOrderCatalogId = resultOrderCatalogId;
		}

		/// <summary> CTor</summary>
		/// <param name="resultOrderCatalogId">PK value for ResultOrderCatalog which data should be fetched into this ResultOrderCatalog object</param>
		/// <param name="validator">The custom validator object for this ResultOrderCatalogEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ResultOrderCatalogEntity(System.Int64 resultOrderCatalogId, IValidator validator):base("ResultOrderCatalogEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ResultOrderCatalogId = resultOrderCatalogId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ResultOrderCatalogEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_resultOrder = (EntityCollection<ResultOrderEntity>)info.GetValue("_resultOrder", typeof(EntityCollection<ResultOrderEntity>));
				_orderShippingInformationCollectionViaResultOrder = (EntityCollection<OrderShippingInformationEntity>)info.GetValue("_orderShippingInformationCollectionViaResultOrder", typeof(EntityCollection<OrderShippingInformationEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ResultOrderCatalogFieldIndex)fieldIndex)
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

				case "ResultOrder":
					this.ResultOrder.Add((ResultOrderEntity)entity);
					break;
				case "OrderShippingInformationCollectionViaResultOrder":
					this.OrderShippingInformationCollectionViaResultOrder.IsReadOnly = false;
					this.OrderShippingInformationCollectionViaResultOrder.Add((OrderShippingInformationEntity)entity);
					this.OrderShippingInformationCollectionViaResultOrder.IsReadOnly = true;
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
			return ResultOrderCatalogEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "ResultOrder":
					toReturn.Add(ResultOrderCatalogEntity.Relations.ResultOrderEntityUsingResultCatalogId);
					break;
				case "OrderShippingInformationCollectionViaResultOrder":
					toReturn.Add(ResultOrderCatalogEntity.Relations.ResultOrderEntityUsingResultCatalogId, "ResultOrderCatalogEntity__", "ResultOrder_", JoinHint.None);
					toReturn.Add(ResultOrderEntity.Relations.OrderShippingInformationEntityUsingOrderShippingInformationId, "ResultOrder_", string.Empty, JoinHint.None);
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

				case "ResultOrder":
					this.ResultOrder.Add((ResultOrderEntity)relatedEntity);
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

				case "ResultOrder":
					base.PerformRelatedEntityRemoval(this.ResultOrder, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.ResultOrder);

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
				info.AddValue("_resultOrder", ((_resultOrder!=null) && (_resultOrder.Count>0) && !this.MarkedForDeletion)?_resultOrder:null);
				info.AddValue("_orderShippingInformationCollectionViaResultOrder", ((_orderShippingInformationCollectionViaResultOrder!=null) && (_orderShippingInformationCollectionViaResultOrder.Count>0) && !this.MarkedForDeletion)?_orderShippingInformationCollectionViaResultOrder:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ResultOrderCatalogFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ResultOrderCatalogFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ResultOrderCatalogRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ResultOrder' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoResultOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ResultOrderFields.ResultCatalogId, null, ComparisonOperator.Equal, this.ResultOrderCatalogId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderShippingInformation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderShippingInformationCollectionViaResultOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderShippingInformationCollectionViaResultOrder"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ResultOrderCatalogFields.ResultOrderCatalogId, null, ComparisonOperator.Equal, this.ResultOrderCatalogId, "ResultOrderCatalogEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.ResultOrderCatalogEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ResultOrderCatalogEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._resultOrder);
			collectionsQueue.Enqueue(this._orderShippingInformationCollectionViaResultOrder);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._resultOrder = (EntityCollection<ResultOrderEntity>) collectionsQueue.Dequeue();
			this._orderShippingInformationCollectionViaResultOrder = (EntityCollection<OrderShippingInformationEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._resultOrder != null)
			{
				return true;
			}
			if (this._orderShippingInformationCollectionViaResultOrder != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ResultOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultOrderEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderShippingInformationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderShippingInformationEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("ResultOrder", _resultOrder);
			toReturn.Add("OrderShippingInformationCollectionViaResultOrder", _orderShippingInformationCollectionViaResultOrder);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_resultOrder!=null)
			{
				_resultOrder.ActiveContext = base.ActiveContext;
			}
			if(_orderShippingInformationCollectionViaResultOrder!=null)
			{
				_orderShippingInformationCollectionViaResultOrder.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_resultOrder = null;
			_orderShippingInformationCollectionViaResultOrder = null;


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

			_fieldsCustomProperties.Add("ResultOrderCatalogId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Title", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SalePrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CostPrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Disclaimer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShippableToPobox", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ResultOrderCatalogEntity</param>
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
		public  static ResultOrderCatalogRelations Relations
		{
			get	{ return new ResultOrderCatalogRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ResultOrder' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathResultOrder
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ResultOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultOrderEntityFactory))),
					(IEntityRelation)GetRelationsForField("ResultOrder")[0], (int)HealthYes.Data.EntityType.ResultOrderCatalogEntity, (int)HealthYes.Data.EntityType.ResultOrderEntity, 0, null, null, null, null, "ResultOrder", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderShippingInformation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderShippingInformationCollectionViaResultOrder
		{
			get
			{
				IEntityRelation intermediateRelation = ResultOrderCatalogEntity.Relations.ResultOrderEntityUsingResultCatalogId;
				intermediateRelation.SetAliases(string.Empty, "ResultOrder_");
				return new PrefetchPathElement2(new EntityCollection<OrderShippingInformationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderShippingInformationEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.ResultOrderCatalogEntity, (int)HealthYes.Data.EntityType.OrderShippingInformationEntity, 0, null, null, GetRelationsForField("OrderShippingInformationCollectionViaResultOrder"), null, "OrderShippingInformationCollectionViaResultOrder", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ResultOrderCatalogEntity.CustomProperties;}
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
			get { return ResultOrderCatalogEntity.FieldsCustomProperties;}
		}

		/// <summary> The ResultOrderCatalogId property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."ResultOrderCatalogID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ResultOrderCatalogId
		{
			get { return (System.Int64)GetValue((int)ResultOrderCatalogFieldIndex.ResultOrderCatalogId, true); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.ResultOrderCatalogId, value); }
		}

		/// <summary> The Title property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."Title"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1025<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Title
		{
			get { return (System.String)GetValue((int)ResultOrderCatalogFieldIndex.Title, true); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.Title, value); }
		}

		/// <summary> The Description property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): Text, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)ResultOrderCatalogFieldIndex.Description, true); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.Description, value); }
		}

		/// <summary> The SalePrice property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."SalePrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal SalePrice
		{
			get { return (System.Decimal)GetValue((int)ResultOrderCatalogFieldIndex.SalePrice, true); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.SalePrice, value); }
		}

		/// <summary> The CostPrice property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."CostPrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal CostPrice
		{
			get { return (System.Decimal)GetValue((int)ResultOrderCatalogFieldIndex.CostPrice, true); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.CostPrice, value); }
		}

		/// <summary> The Disclaimer property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."Disclaimer"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Disclaimer
		{
			get { return (System.String)GetValue((int)ResultOrderCatalogFieldIndex.Disclaimer, true); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.Disclaimer, value); }
		}

		/// <summary> The ShippableToPobox property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."ShippableToPOBox"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShippableToPobox
		{
			get { return (System.Boolean)GetValue((int)ResultOrderCatalogFieldIndex.ShippableToPobox, true); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.ShippableToPobox, value); }
		}

		/// <summary> The IsActive property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ResultOrderCatalogFieldIndex.IsActive, true); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ResultOrderCatalogFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity ResultOrderCatalog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultOrderCatalog"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ResultOrderCatalogFieldIndex.DateModified, false); }
			set	{ SetValue((int)ResultOrderCatalogFieldIndex.DateModified, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ResultOrderEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ResultOrderEntity))]
		public virtual EntityCollection<ResultOrderEntity> ResultOrder
		{
			get
			{
				if(_resultOrder==null)
				{
					_resultOrder = new EntityCollection<ResultOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultOrderEntityFactory)));
					_resultOrder.SetContainingEntityInfo(this, "ResultOrderCatalog");
				}
				return _resultOrder;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderShippingInformationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderShippingInformationEntity))]
		public virtual EntityCollection<OrderShippingInformationEntity> OrderShippingInformationCollectionViaResultOrder
		{
			get
			{
				if(_orderShippingInformationCollectionViaResultOrder==null)
				{
					_orderShippingInformationCollectionViaResultOrder = new EntityCollection<OrderShippingInformationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderShippingInformationEntityFactory)));
					_orderShippingInformationCollectionViaResultOrder.IsReadOnly=true;
				}
				return _orderShippingInformationCollectionViaResultOrder;
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
			get { return (int)HealthYes.Data.EntityType.ResultOrderCatalogEntity; }
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
