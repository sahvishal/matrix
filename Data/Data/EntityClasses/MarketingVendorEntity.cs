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
	/// Entity class which represents the entity 'MarketingVendor'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MarketingVendorEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MarketingMaterialTypeMarketingVendorEntity> _marketingMaterialTypeMarketingVendor;
		private EntityCollection<MarketingMaterialTypeEntity> _marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name MarketingMaterialTypeMarketingVendor</summary>
			public static readonly string MarketingMaterialTypeMarketingVendor = "MarketingMaterialTypeMarketingVendor";
			/// <summary>Member name MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor</summary>
			public static readonly string MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor = "MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MarketingVendorEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MarketingVendorEntity():base("MarketingVendorEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MarketingVendorEntity(IEntityFields2 fields):base("MarketingVendorEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MarketingVendorEntity</param>
		public MarketingVendorEntity(IValidator validator):base("MarketingVendorEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="marketingVendorId">PK value for MarketingVendor which data should be fetched into this MarketingVendor object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MarketingVendorEntity(System.Int64 marketingVendorId):base("MarketingVendorEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MarketingVendorId = marketingVendorId;
		}

		/// <summary> CTor</summary>
		/// <param name="marketingVendorId">PK value for MarketingVendor which data should be fetched into this MarketingVendor object</param>
		/// <param name="validator">The custom validator object for this MarketingVendorEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MarketingVendorEntity(System.Int64 marketingVendorId, IValidator validator):base("MarketingVendorEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MarketingVendorId = marketingVendorId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MarketingVendorEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_marketingMaterialTypeMarketingVendor = (EntityCollection<MarketingMaterialTypeMarketingVendorEntity>)info.GetValue("_marketingMaterialTypeMarketingVendor", typeof(EntityCollection<MarketingMaterialTypeMarketingVendorEntity>));
				_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor = (EntityCollection<MarketingMaterialTypeEntity>)info.GetValue("_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor", typeof(EntityCollection<MarketingMaterialTypeEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((MarketingVendorFieldIndex)fieldIndex)
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

				case "MarketingMaterialTypeMarketingVendor":
					this.MarketingMaterialTypeMarketingVendor.Add((MarketingMaterialTypeMarketingVendorEntity)entity);
					break;
				case "MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor":
					this.MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor.IsReadOnly = false;
					this.MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor.Add((MarketingMaterialTypeEntity)entity);
					this.MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor.IsReadOnly = true;
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
			return MarketingVendorEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "MarketingMaterialTypeMarketingVendor":
					toReturn.Add(MarketingVendorEntity.Relations.MarketingMaterialTypeMarketingVendorEntityUsingMarketingVendorId);
					break;
				case "MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor":
					toReturn.Add(MarketingVendorEntity.Relations.MarketingMaterialTypeMarketingVendorEntityUsingMarketingVendorId, "MarketingVendorEntity__", "MarketingMaterialTypeMarketingVendor_", JoinHint.None);
					toReturn.Add(MarketingMaterialTypeMarketingVendorEntity.Relations.MarketingMaterialTypeEntityUsingMarketingMaterialTypeId, "MarketingMaterialTypeMarketingVendor_", string.Empty, JoinHint.None);
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

				case "MarketingMaterialTypeMarketingVendor":
					this.MarketingMaterialTypeMarketingVendor.Add((MarketingMaterialTypeMarketingVendorEntity)relatedEntity);
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

				case "MarketingMaterialTypeMarketingVendor":
					base.PerformRelatedEntityRemoval(this.MarketingMaterialTypeMarketingVendor, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.MarketingMaterialTypeMarketingVendor);

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
				info.AddValue("_marketingMaterialTypeMarketingVendor", ((_marketingMaterialTypeMarketingVendor!=null) && (_marketingMaterialTypeMarketingVendor.Count>0) && !this.MarkedForDeletion)?_marketingMaterialTypeMarketingVendor:null);
				info.AddValue("_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor", ((_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor!=null) && (_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor.Count>0) && !this.MarkedForDeletion)?_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MarketingVendorFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MarketingVendorFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MarketingVendorRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingMaterialTypeMarketingVendor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingMaterialTypeMarketingVendor()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingMaterialTypeMarketingVendorFields.MarketingVendorId, null, ComparisonOperator.Equal, this.MarketingVendorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingMaterialType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingVendorFields.MarketingVendorId, null, ComparisonOperator.Equal, this.MarketingVendorId, "MarketingVendorEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.MarketingVendorEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MarketingVendorEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._marketingMaterialTypeMarketingVendor);
			collectionsQueue.Enqueue(this._marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._marketingMaterialTypeMarketingVendor = (EntityCollection<MarketingMaterialTypeMarketingVendorEntity>) collectionsQueue.Dequeue();
			this._marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor = (EntityCollection<MarketingMaterialTypeEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._marketingMaterialTypeMarketingVendor != null)
			{
				return true;
			}
			if (this._marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingMaterialTypeMarketingVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingMaterialTypeMarketingVendorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingMaterialTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingMaterialTypeEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("MarketingMaterialTypeMarketingVendor", _marketingMaterialTypeMarketingVendor);
			toReturn.Add("MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor", _marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_marketingMaterialTypeMarketingVendor!=null)
			{
				_marketingMaterialTypeMarketingVendor.ActiveContext = base.ActiveContext;
			}
			if(_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor!=null)
			{
				_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_marketingMaterialTypeMarketingVendor = null;
			_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor = null;


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

			_fieldsCustomProperties.Add("MarketingVendorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TeamPicture", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContactUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MarketingVendorEntity</param>
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
		public  static MarketingVendorRelations Relations
		{
			get	{ return new MarketingVendorRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingMaterialTypeMarketingVendor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingMaterialTypeMarketingVendor
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MarketingMaterialTypeMarketingVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingMaterialTypeMarketingVendorEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingMaterialTypeMarketingVendor")[0], (int)HealthYes.Data.EntityType.MarketingVendorEntity, (int)HealthYes.Data.EntityType.MarketingMaterialTypeMarketingVendorEntity, 0, null, null, null, null, "MarketingMaterialTypeMarketingVendor", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingMaterialType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingVendorEntity.Relations.MarketingMaterialTypeMarketingVendorEntityUsingMarketingVendorId;
				intermediateRelation.SetAliases(string.Empty, "MarketingMaterialTypeMarketingVendor_");
				return new PrefetchPathElement2(new EntityCollection<MarketingMaterialTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingMaterialTypeEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MarketingVendorEntity, (int)HealthYes.Data.EntityType.MarketingMaterialTypeEntity, 0, null, null, GetRelationsForField("MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor"), null, "MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MarketingVendorEntity.CustomProperties;}
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
			get { return MarketingVendorEntity.FieldsCustomProperties;}
		}

		/// <summary> The MarketingVendorId property of the Entity MarketingVendor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingVendor"."MarketingVendorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MarketingVendorId
		{
			get { return (System.Int64)GetValue((int)MarketingVendorFieldIndex.MarketingVendorId, true); }
			set	{ SetValue((int)MarketingVendorFieldIndex.MarketingVendorId, value); }
		}

		/// <summary> The Name property of the Entity MarketingVendor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingVendor"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)MarketingVendorFieldIndex.Name, true); }
			set	{ SetValue((int)MarketingVendorFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity MarketingVendor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingVendor"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)MarketingVendorFieldIndex.Description, true); }
			set	{ SetValue((int)MarketingVendorFieldIndex.Description, value); }
		}

		/// <summary> The TeamPicture property of the Entity MarketingVendor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingVendor"."TeamPicture"<br/>
		/// Table field type characteristics (type, precision, scale, length): Image, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Byte[] TeamPicture
		{
			get { return (System.Byte[])GetValue((int)MarketingVendorFieldIndex.TeamPicture, true); }
			set	{ SetValue((int)MarketingVendorFieldIndex.TeamPicture, value); }
		}

		/// <summary> The ContactUserId property of the Entity MarketingVendor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingVendor"."ContactUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ContactUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MarketingVendorFieldIndex.ContactUserId, false); }
			set	{ SetValue((int)MarketingVendorFieldIndex.ContactUserId, value); }
		}

		/// <summary> The DateCreated property of the Entity MarketingVendor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingVendor"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MarketingVendorFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MarketingVendorFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MarketingVendor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingVendor"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MarketingVendorFieldIndex.DateModified, true); }
			set	{ SetValue((int)MarketingVendorFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity MarketingVendor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingVendor"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)MarketingVendorFieldIndex.IsActive, true); }
			set	{ SetValue((int)MarketingVendorFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingMaterialTypeMarketingVendorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingMaterialTypeMarketingVendorEntity))]
		public virtual EntityCollection<MarketingMaterialTypeMarketingVendorEntity> MarketingMaterialTypeMarketingVendor
		{
			get
			{
				if(_marketingMaterialTypeMarketingVendor==null)
				{
					_marketingMaterialTypeMarketingVendor = new EntityCollection<MarketingMaterialTypeMarketingVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingMaterialTypeMarketingVendorEntityFactory)));
					_marketingMaterialTypeMarketingVendor.SetContainingEntityInfo(this, "MarketingVendor");
				}
				return _marketingMaterialTypeMarketingVendor;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingMaterialTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingMaterialTypeEntity))]
		public virtual EntityCollection<MarketingMaterialTypeEntity> MarketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor
		{
			get
			{
				if(_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor==null)
				{
					_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor = new EntityCollection<MarketingMaterialTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingMaterialTypeEntityFactory)));
					_marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor.IsReadOnly=true;
				}
				return _marketingMaterialTypeCollectionViaMarketingMaterialTypeMarketingVendor;
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
			get { return (int)HealthYes.Data.EntityType.MarketingVendorEntity; }
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
