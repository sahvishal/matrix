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
	/// Entity class which represents the entity 'StandardFinding'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class StandardFindingEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<StandardFindingTestReadingEntity> _standardFindingTestReading;
		private EntityCollection<ReadingEntity> _readingCollectionViaStandardFindingTestReading;
		private EntityCollection<TestEntity> _testCollectionViaStandardFindingTestReading;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name StandardFindingTestReading</summary>
			public static readonly string StandardFindingTestReading = "StandardFindingTestReading";
			/// <summary>Member name ReadingCollectionViaStandardFindingTestReading</summary>
			public static readonly string ReadingCollectionViaStandardFindingTestReading = "ReadingCollectionViaStandardFindingTestReading";
			/// <summary>Member name TestCollectionViaStandardFindingTestReading</summary>
			public static readonly string TestCollectionViaStandardFindingTestReading = "TestCollectionViaStandardFindingTestReading";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static StandardFindingEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public StandardFindingEntity():base("StandardFindingEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public StandardFindingEntity(IEntityFields2 fields):base("StandardFindingEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this StandardFindingEntity</param>
		public StandardFindingEntity(IValidator validator):base("StandardFindingEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="standardFindingId">PK value for StandardFinding which data should be fetched into this StandardFinding object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public StandardFindingEntity(System.Int32 standardFindingId):base("StandardFindingEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.StandardFindingId = standardFindingId;
		}

		/// <summary> CTor</summary>
		/// <param name="standardFindingId">PK value for StandardFinding which data should be fetched into this StandardFinding object</param>
		/// <param name="validator">The custom validator object for this StandardFindingEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public StandardFindingEntity(System.Int32 standardFindingId, IValidator validator):base("StandardFindingEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.StandardFindingId = standardFindingId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected StandardFindingEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_standardFindingTestReading = (EntityCollection<StandardFindingTestReadingEntity>)info.GetValue("_standardFindingTestReading", typeof(EntityCollection<StandardFindingTestReadingEntity>));
				_readingCollectionViaStandardFindingTestReading = (EntityCollection<ReadingEntity>)info.GetValue("_readingCollectionViaStandardFindingTestReading", typeof(EntityCollection<ReadingEntity>));
				_testCollectionViaStandardFindingTestReading = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaStandardFindingTestReading", typeof(EntityCollection<TestEntity>));
				_lookup_ = (LookupEntity)info.GetValue("_lookup_", typeof(LookupEntity));
				if(_lookup_!=null)
				{
					_lookup_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((StandardFindingFieldIndex)fieldIndex)
			{
				case StandardFindingFieldIndex.ResultInterpretation:
					DesetupSyncLookup(true, false);
					break;
				case StandardFindingFieldIndex.PathwayRecommendation:
					DesetupSyncLookup_(true, false);
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
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "StandardFindingTestReading":
					this.StandardFindingTestReading.Add((StandardFindingTestReadingEntity)entity);
					break;
				case "ReadingCollectionViaStandardFindingTestReading":
					this.ReadingCollectionViaStandardFindingTestReading.IsReadOnly = false;
					this.ReadingCollectionViaStandardFindingTestReading.Add((ReadingEntity)entity);
					this.ReadingCollectionViaStandardFindingTestReading.IsReadOnly = true;
					break;
				case "TestCollectionViaStandardFindingTestReading":
					this.TestCollectionViaStandardFindingTestReading.IsReadOnly = false;
					this.TestCollectionViaStandardFindingTestReading.Add((TestEntity)entity);
					this.TestCollectionViaStandardFindingTestReading.IsReadOnly = true;
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
			return StandardFindingEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Lookup_":
					toReturn.Add(StandardFindingEntity.Relations.LookupEntityUsingPathwayRecommendation);
					break;
				case "Lookup":
					toReturn.Add(StandardFindingEntity.Relations.LookupEntityUsingResultInterpretation);
					break;
				case "StandardFindingTestReading":
					toReturn.Add(StandardFindingEntity.Relations.StandardFindingTestReadingEntityUsingStandardFindingId);
					break;
				case "ReadingCollectionViaStandardFindingTestReading":
					toReturn.Add(StandardFindingEntity.Relations.StandardFindingTestReadingEntityUsingStandardFindingId, "StandardFindingEntity__", "StandardFindingTestReading_", JoinHint.None);
					toReturn.Add(StandardFindingTestReadingEntity.Relations.ReadingEntityUsingReadingId, "StandardFindingTestReading_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaStandardFindingTestReading":
					toReturn.Add(StandardFindingEntity.Relations.StandardFindingTestReadingEntityUsingStandardFindingId, "StandardFindingEntity__", "StandardFindingTestReading_", JoinHint.None);
					toReturn.Add(StandardFindingTestReadingEntity.Relations.TestEntityUsingTestId, "StandardFindingTestReading_", string.Empty, JoinHint.None);
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
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "StandardFindingTestReading":
					this.StandardFindingTestReading.Add((StandardFindingTestReadingEntity)relatedEntity);
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
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "StandardFindingTestReading":
					base.PerformRelatedEntityRemoval(this.StandardFindingTestReading, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.StandardFindingTestReading);

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
				info.AddValue("_standardFindingTestReading", ((_standardFindingTestReading!=null) && (_standardFindingTestReading.Count>0) && !this.MarkedForDeletion)?_standardFindingTestReading:null);
				info.AddValue("_readingCollectionViaStandardFindingTestReading", ((_readingCollectionViaStandardFindingTestReading!=null) && (_readingCollectionViaStandardFindingTestReading.Count>0) && !this.MarkedForDeletion)?_readingCollectionViaStandardFindingTestReading:null);
				info.AddValue("_testCollectionViaStandardFindingTestReading", ((_testCollectionViaStandardFindingTestReading!=null) && (_testCollectionViaStandardFindingTestReading.Count>0) && !this.MarkedForDeletion)?_testCollectionViaStandardFindingTestReading:null);
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(StandardFindingFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(StandardFindingFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new StandardFindingRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StandardFindingTestReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStandardFindingTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingTestReadingFields.StandardFindingId, null, ComparisonOperator.Equal, this.StandardFindingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Reading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReadingCollectionViaStandardFindingTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ReadingCollectionViaStandardFindingTestReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingFields.StandardFindingId, null, ComparisonOperator.Equal, this.StandardFindingId, "StandardFindingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaStandardFindingTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaStandardFindingTestReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingFields.StandardFindingId, null, ComparisonOperator.Equal, this.StandardFindingId, "StandardFindingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.PathwayRecommendation));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ResultInterpretation));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.StandardFindingEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._standardFindingTestReading);
			collectionsQueue.Enqueue(this._readingCollectionViaStandardFindingTestReading);
			collectionsQueue.Enqueue(this._testCollectionViaStandardFindingTestReading);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._standardFindingTestReading = (EntityCollection<StandardFindingTestReadingEntity>) collectionsQueue.Dequeue();
			this._readingCollectionViaStandardFindingTestReading = (EntityCollection<ReadingEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaStandardFindingTestReading = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._standardFindingTestReading != null)
			{
				return true;
			}
			if (this._readingCollectionViaStandardFindingTestReading != null)
			{
				return true;
			}
			if (this._testCollectionViaStandardFindingTestReading != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))) : null);
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
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("StandardFindingTestReading", _standardFindingTestReading);
			toReturn.Add("ReadingCollectionViaStandardFindingTestReading", _readingCollectionViaStandardFindingTestReading);
			toReturn.Add("TestCollectionViaStandardFindingTestReading", _testCollectionViaStandardFindingTestReading);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_standardFindingTestReading!=null)
			{
				_standardFindingTestReading.ActiveContext = base.ActiveContext;
			}
			if(_readingCollectionViaStandardFindingTestReading!=null)
			{
				_readingCollectionViaStandardFindingTestReading.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaStandardFindingTestReading!=null)
			{
				_testCollectionViaStandardFindingTestReading.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_standardFindingTestReading = null;
			_readingCollectionViaStandardFindingTestReading = null;
			_testCollectionViaStandardFindingTestReading = null;
			_lookup_ = null;
			_lookup = null;

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

			_fieldsCustomProperties.Add("StandardFindingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Label", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MinValue", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaxValue", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultInterpretation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LongDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WorstCaseOrder", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PathwayRecommendation", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", StandardFindingEntity.Relations.LookupEntityUsingPathwayRecommendation, true, signalRelatedEntity, "StandardFinding_", resetFKFields, new int[] { (int)StandardFindingFieldIndex.PathwayRecommendation } );		
			_lookup_ = null;
		}

		/// <summary> setups the sync logic for member _lookup_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup_(IEntity2 relatedEntity)
		{
			if(_lookup_!=relatedEntity)
			{
				DesetupSyncLookup_(true, true);
				_lookup_ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", StandardFindingEntity.Relations.LookupEntityUsingPathwayRecommendation, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", StandardFindingEntity.Relations.LookupEntityUsingResultInterpretation, true, signalRelatedEntity, "StandardFinding", resetFKFields, new int[] { (int)StandardFindingFieldIndex.ResultInterpretation } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", StandardFindingEntity.Relations.LookupEntityUsingResultInterpretation, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this StandardFindingEntity</param>
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
		public  static StandardFindingRelations Relations
		{
			get	{ return new StandardFindingRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StandardFindingTestReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStandardFindingTestReading
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("StandardFindingTestReading")[0], (int)Falcon.Data.EntityType.StandardFindingEntity, (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, 0, null, null, null, null, "StandardFindingTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Reading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReadingCollectionViaStandardFindingTestReading
		{
			get
			{
				IEntityRelation intermediateRelation = StandardFindingEntity.Relations.StandardFindingTestReadingEntityUsingStandardFindingId;
				intermediateRelation.SetAliases(string.Empty, "StandardFindingTestReading_");
				return new PrefetchPathElement2(new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StandardFindingEntity, (int)Falcon.Data.EntityType.ReadingEntity, 0, null, null, GetRelationsForField("ReadingCollectionViaStandardFindingTestReading"), null, "ReadingCollectionViaStandardFindingTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaStandardFindingTestReading
		{
			get
			{
				IEntityRelation intermediateRelation = StandardFindingEntity.Relations.StandardFindingTestReadingEntityUsingStandardFindingId;
				intermediateRelation.SetAliases(string.Empty, "StandardFindingTestReading_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StandardFindingEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaStandardFindingTestReading"), null, "TestCollectionViaStandardFindingTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.StandardFindingEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.StandardFindingEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return StandardFindingEntity.CustomProperties;}
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
			get { return StandardFindingEntity.FieldsCustomProperties;}
		}

		/// <summary> The StandardFindingId property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."StandardFindingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 StandardFindingId
		{
			get { return (System.Int32)GetValue((int)StandardFindingFieldIndex.StandardFindingId, true); }
			set	{ SetValue((int)StandardFindingFieldIndex.StandardFindingId, value); }
		}

		/// <summary> The Label property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."Label"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Label
		{
			get { return (System.String)GetValue((int)StandardFindingFieldIndex.Label, true); }
			set	{ SetValue((int)StandardFindingFieldIndex.Label, value); }
		}

		/// <summary> The Description property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)StandardFindingFieldIndex.Description, true); }
			set	{ SetValue((int)StandardFindingFieldIndex.Description, value); }
		}

		/// <summary> The MinValue property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."MinValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MinValue
		{
			get { return (Nullable<System.Decimal>)GetValue((int)StandardFindingFieldIndex.MinValue, false); }
			set	{ SetValue((int)StandardFindingFieldIndex.MinValue, value); }
		}

		/// <summary> The MaxValue property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."MaxValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MaxValue
		{
			get { return (Nullable<System.Decimal>)GetValue((int)StandardFindingFieldIndex.MaxValue, false); }
			set	{ SetValue((int)StandardFindingFieldIndex.MaxValue, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)StandardFindingFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)StandardFindingFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The CreatedOn property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedOn
		{
			get { return (System.DateTime)GetValue((int)StandardFindingFieldIndex.CreatedOn, true); }
			set	{ SetValue((int)StandardFindingFieldIndex.CreatedOn, value); }
		}

		/// <summary> The UpdatedByOrgRoleUserId property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."UpdatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 UpdatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)StandardFindingFieldIndex.UpdatedByOrgRoleUserId, true); }
			set	{ SetValue((int)StandardFindingFieldIndex.UpdatedByOrgRoleUserId, value); }
		}

		/// <summary> The UpdatedOn property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."UpdatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime UpdatedOn
		{
			get { return (System.DateTime)GetValue((int)StandardFindingFieldIndex.UpdatedOn, true); }
			set	{ SetValue((int)StandardFindingFieldIndex.UpdatedOn, value); }
		}

		/// <summary> The IsActive property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)StandardFindingFieldIndex.IsActive, true); }
			set	{ SetValue((int)StandardFindingFieldIndex.IsActive, value); }
		}

		/// <summary> The ResultInterpretation property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."Interpretation"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ResultInterpretation
		{
			get { return (Nullable<System.Int64>)GetValue((int)StandardFindingFieldIndex.ResultInterpretation, false); }
			set	{ SetValue((int)StandardFindingFieldIndex.ResultInterpretation, value); }
		}

		/// <summary> The LongDescription property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."LongDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LongDescription
		{
			get { return (System.String)GetValue((int)StandardFindingFieldIndex.LongDescription, true); }
			set	{ SetValue((int)StandardFindingFieldIndex.LongDescription, value); }
		}

		/// <summary> The WorstCaseOrder property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."WorstCaseOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> WorstCaseOrder
		{
			get { return (Nullable<System.Int32>)GetValue((int)StandardFindingFieldIndex.WorstCaseOrder, false); }
			set	{ SetValue((int)StandardFindingFieldIndex.WorstCaseOrder, value); }
		}

		/// <summary> The PathwayRecommendation property of the Entity StandardFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFinding"."PathwayRecommendation"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PathwayRecommendation
		{
			get { return (Nullable<System.Int64>)GetValue((int)StandardFindingFieldIndex.PathwayRecommendation, false); }
			set	{ SetValue((int)StandardFindingFieldIndex.PathwayRecommendation, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StandardFindingTestReadingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StandardFindingTestReadingEntity))]
		public virtual EntityCollection<StandardFindingTestReadingEntity> StandardFindingTestReading
		{
			get
			{
				if(_standardFindingTestReading==null)
				{
					_standardFindingTestReading = new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory)));
					_standardFindingTestReading.SetContainingEntityInfo(this, "StandardFinding");
				}
				return _standardFindingTestReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReadingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReadingEntity))]
		public virtual EntityCollection<ReadingEntity> ReadingCollectionViaStandardFindingTestReading
		{
			get
			{
				if(_readingCollectionViaStandardFindingTestReading==null)
				{
					_readingCollectionViaStandardFindingTestReading = new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory)));
					_readingCollectionViaStandardFindingTestReading.IsReadOnly=true;
				}
				return _readingCollectionViaStandardFindingTestReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaStandardFindingTestReading
		{
			get
			{
				if(_testCollectionViaStandardFindingTestReading==null)
				{
					_testCollectionViaStandardFindingTestReading = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaStandardFindingTestReading.IsReadOnly=true;
				}
				return _testCollectionViaStandardFindingTestReading;
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup_
		{
			get
			{
				return _lookup_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup_(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup_ != null)
						{
							_lookup_.UnsetRelatedEntity(this, "StandardFinding_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "StandardFinding_");
						}
					}
				}
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
							_lookup.UnsetRelatedEntity(this, "StandardFinding");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "StandardFinding");
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
			get { return (int)Falcon.Data.EntityType.StandardFindingEntity; }
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
