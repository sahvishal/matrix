///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:50
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
	/// Entity class which represents the entity 'ChaseProduct'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ChaseProductEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerChaseProductEntity> _customerChaseProduct;
		private EntityCollection<ChaseOutboundEntity> _chaseOutboundCollectionViaCustomerChaseProduct;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerChaseProduct;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name CustomerChaseProduct</summary>
			public static readonly string CustomerChaseProduct = "CustomerChaseProduct";
			/// <summary>Member name ChaseOutboundCollectionViaCustomerChaseProduct</summary>
			public static readonly string ChaseOutboundCollectionViaCustomerChaseProduct = "ChaseOutboundCollectionViaCustomerChaseProduct";
			/// <summary>Member name CustomerProfileCollectionViaCustomerChaseProduct</summary>
			public static readonly string CustomerProfileCollectionViaCustomerChaseProduct = "CustomerProfileCollectionViaCustomerChaseProduct";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ChaseProductEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ChaseProductEntity():base("ChaseProductEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ChaseProductEntity(IEntityFields2 fields):base("ChaseProductEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ChaseProductEntity</param>
		public ChaseProductEntity(IValidator validator):base("ChaseProductEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="chaseProductId">PK value for ChaseProduct which data should be fetched into this ChaseProduct object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseProductEntity(System.Int64 chaseProductId):base("ChaseProductEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ChaseProductId = chaseProductId;
		}

		/// <summary> CTor</summary>
		/// <param name="chaseProductId">PK value for ChaseProduct which data should be fetched into this ChaseProduct object</param>
		/// <param name="validator">The custom validator object for this ChaseProductEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseProductEntity(System.Int64 chaseProductId, IValidator validator):base("ChaseProductEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ChaseProductId = chaseProductId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ChaseProductEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerChaseProduct = (EntityCollection<CustomerChaseProductEntity>)info.GetValue("_customerChaseProduct", typeof(EntityCollection<CustomerChaseProductEntity>));
				_chaseOutboundCollectionViaCustomerChaseProduct = (EntityCollection<ChaseOutboundEntity>)info.GetValue("_chaseOutboundCollectionViaCustomerChaseProduct", typeof(EntityCollection<ChaseOutboundEntity>));
				_customerProfileCollectionViaCustomerChaseProduct = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerChaseProduct", typeof(EntityCollection<CustomerProfileEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ChaseProductFieldIndex)fieldIndex)
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

				case "CustomerChaseProduct":
					this.CustomerChaseProduct.Add((CustomerChaseProductEntity)entity);
					break;
				case "ChaseOutboundCollectionViaCustomerChaseProduct":
					this.ChaseOutboundCollectionViaCustomerChaseProduct.IsReadOnly = false;
					this.ChaseOutboundCollectionViaCustomerChaseProduct.Add((ChaseOutboundEntity)entity);
					this.ChaseOutboundCollectionViaCustomerChaseProduct.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerChaseProduct":
					this.CustomerProfileCollectionViaCustomerChaseProduct.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerChaseProduct.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerChaseProduct.IsReadOnly = true;
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
			return ChaseProductEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "CustomerChaseProduct":
					toReturn.Add(ChaseProductEntity.Relations.CustomerChaseProductEntityUsingChaseProductId);
					break;
				case "ChaseOutboundCollectionViaCustomerChaseProduct":
					toReturn.Add(ChaseProductEntity.Relations.CustomerChaseProductEntityUsingChaseProductId, "ChaseProductEntity__", "CustomerChaseProduct_", JoinHint.None);
					toReturn.Add(CustomerChaseProductEntity.Relations.ChaseOutboundEntityUsingChaseOutboundId, "CustomerChaseProduct_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerChaseProduct":
					toReturn.Add(ChaseProductEntity.Relations.CustomerChaseProductEntityUsingChaseProductId, "ChaseProductEntity__", "CustomerChaseProduct_", JoinHint.None);
					toReturn.Add(CustomerChaseProductEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerChaseProduct_", string.Empty, JoinHint.None);
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

				case "CustomerChaseProduct":
					this.CustomerChaseProduct.Add((CustomerChaseProductEntity)relatedEntity);
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

				case "CustomerChaseProduct":
					base.PerformRelatedEntityRemoval(this.CustomerChaseProduct, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CustomerChaseProduct);

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
				info.AddValue("_customerChaseProduct", ((_customerChaseProduct!=null) && (_customerChaseProduct.Count>0) && !this.MarkedForDeletion)?_customerChaseProduct:null);
				info.AddValue("_chaseOutboundCollectionViaCustomerChaseProduct", ((_chaseOutboundCollectionViaCustomerChaseProduct!=null) && (_chaseOutboundCollectionViaCustomerChaseProduct.Count>0) && !this.MarkedForDeletion)?_chaseOutboundCollectionViaCustomerChaseProduct:null);
				info.AddValue("_customerProfileCollectionViaCustomerChaseProduct", ((_customerProfileCollectionViaCustomerChaseProduct!=null) && (_customerProfileCollectionViaCustomerChaseProduct.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerChaseProduct:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ChaseProductFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ChaseProductFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ChaseProductRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerChaseProduct' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerChaseProduct()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerChaseProductFields.ChaseProductId, null, ComparisonOperator.Equal, this.ChaseProductId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaseOutbound' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseOutboundCollectionViaCustomerChaseProduct()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChaseOutboundCollectionViaCustomerChaseProduct"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseProductFields.ChaseProductId, null, ComparisonOperator.Equal, this.ChaseProductId, "ChaseProductEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerChaseProduct()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerChaseProduct"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseProductFields.ChaseProductId, null, ComparisonOperator.Equal, this.ChaseProductId, "ChaseProductEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ChaseProductEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ChaseProductEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerChaseProduct);
			collectionsQueue.Enqueue(this._chaseOutboundCollectionViaCustomerChaseProduct);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerChaseProduct);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerChaseProduct = (EntityCollection<CustomerChaseProductEntity>) collectionsQueue.Dequeue();
			this._chaseOutboundCollectionViaCustomerChaseProduct = (EntityCollection<ChaseOutboundEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerChaseProduct = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerChaseProduct != null)
			{
				return true;
			}
			if (this._chaseOutboundCollectionViaCustomerChaseProduct != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerChaseProduct != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerChaseProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseProductEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("CustomerChaseProduct", _customerChaseProduct);
			toReturn.Add("ChaseOutboundCollectionViaCustomerChaseProduct", _chaseOutboundCollectionViaCustomerChaseProduct);
			toReturn.Add("CustomerProfileCollectionViaCustomerChaseProduct", _customerProfileCollectionViaCustomerChaseProduct);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerChaseProduct!=null)
			{
				_customerChaseProduct.ActiveContext = base.ActiveContext;
			}
			if(_chaseOutboundCollectionViaCustomerChaseProduct!=null)
			{
				_chaseOutboundCollectionViaCustomerChaseProduct.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerChaseProduct!=null)
			{
				_customerProfileCollectionViaCustomerChaseProduct.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerChaseProduct = null;
			_chaseOutboundCollectionViaCustomerChaseProduct = null;
			_customerProfileCollectionViaCustomerChaseProduct = null;


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

			_fieldsCustomProperties.Add("ChaseProductId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProductLevel", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ChaseProductEntity</param>
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
		public  static ChaseProductRelations Relations
		{
			get	{ return new ChaseProductRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerChaseProduct' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerChaseProduct
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerChaseProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseProductEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerChaseProduct")[0], (int)Falcon.Data.EntityType.ChaseProductEntity, (int)Falcon.Data.EntityType.CustomerChaseProductEntity, 0, null, null, null, null, "CustomerChaseProduct", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseOutbound' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseOutboundCollectionViaCustomerChaseProduct
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseProductEntity.Relations.CustomerChaseProductEntityUsingChaseProductId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseProduct_");
				return new PrefetchPathElement2(new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseProductEntity, (int)Falcon.Data.EntityType.ChaseOutboundEntity, 0, null, null, GetRelationsForField("ChaseOutboundCollectionViaCustomerChaseProduct"), null, "ChaseOutboundCollectionViaCustomerChaseProduct", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerChaseProduct
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseProductEntity.Relations.CustomerChaseProductEntityUsingChaseProductId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseProduct_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseProductEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerChaseProduct"), null, "CustomerProfileCollectionViaCustomerChaseProduct", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ChaseProductEntity.CustomProperties;}
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
			get { return ChaseProductEntity.FieldsCustomProperties;}
		}

		/// <summary> The ChaseProductId property of the Entity ChaseProduct<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseProduct"."ChaseProductId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ChaseProductId
		{
			get { return (System.Int64)GetValue((int)ChaseProductFieldIndex.ChaseProductId, true); }
			set	{ SetValue((int)ChaseProductFieldIndex.ChaseProductId, value); }
		}

		/// <summary> The Name property of the Entity ChaseProduct<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseProduct"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ChaseProductFieldIndex.Name, true); }
			set	{ SetValue((int)ChaseProductFieldIndex.Name, value); }
		}

		/// <summary> The ProductLevel property of the Entity ChaseProduct<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseProduct"."ProductLevel"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ProductLevel
		{
			get { return (System.Int64)GetValue((int)ChaseProductFieldIndex.ProductLevel, true); }
			set	{ SetValue((int)ChaseProductFieldIndex.ProductLevel, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerChaseProductEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerChaseProductEntity))]
		public virtual EntityCollection<CustomerChaseProductEntity> CustomerChaseProduct
		{
			get
			{
				if(_customerChaseProduct==null)
				{
					_customerChaseProduct = new EntityCollection<CustomerChaseProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseProductEntityFactory)));
					_customerChaseProduct.SetContainingEntityInfo(this, "ChaseProduct");
				}
				return _customerChaseProduct;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaseOutboundEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaseOutboundEntity))]
		public virtual EntityCollection<ChaseOutboundEntity> ChaseOutboundCollectionViaCustomerChaseProduct
		{
			get
			{
				if(_chaseOutboundCollectionViaCustomerChaseProduct==null)
				{
					_chaseOutboundCollectionViaCustomerChaseProduct = new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory)));
					_chaseOutboundCollectionViaCustomerChaseProduct.IsReadOnly=true;
				}
				return _chaseOutboundCollectionViaCustomerChaseProduct;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerChaseProduct
		{
			get
			{
				if(_customerProfileCollectionViaCustomerChaseProduct==null)
				{
					_customerProfileCollectionViaCustomerChaseProduct = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerChaseProduct.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerChaseProduct;
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
			get { return (int)Falcon.Data.EntityType.ChaseProductEntity; }
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
