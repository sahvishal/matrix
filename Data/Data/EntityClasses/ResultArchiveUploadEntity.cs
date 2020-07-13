///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'ResultArchiveUpload'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ResultArchiveUploadEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ResultArchiveUploadLogEntity> _resultArchiveUploadLog;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaResultArchiveUploadLog;
		private EntityCollection<TestEntity> _testCollectionViaResultArchiveUploadLog;
		private EventsEntity _events;
		private FileEntity _file_;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name File_</summary>
			public static readonly string File_ = "File_";
			/// <summary>Member name ResultArchiveUploadLog</summary>
			public static readonly string ResultArchiveUploadLog = "ResultArchiveUploadLog";
			/// <summary>Member name CustomerProfileCollectionViaResultArchiveUploadLog</summary>
			public static readonly string CustomerProfileCollectionViaResultArchiveUploadLog = "CustomerProfileCollectionViaResultArchiveUploadLog";
			/// <summary>Member name TestCollectionViaResultArchiveUploadLog</summary>
			public static readonly string TestCollectionViaResultArchiveUploadLog = "TestCollectionViaResultArchiveUploadLog";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ResultArchiveUploadEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ResultArchiveUploadEntity():base("ResultArchiveUploadEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ResultArchiveUploadEntity(IEntityFields2 fields):base("ResultArchiveUploadEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ResultArchiveUploadEntity</param>
		public ResultArchiveUploadEntity(IValidator validator):base("ResultArchiveUploadEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="resultArchiveUploadId">PK value for ResultArchiveUpload which data should be fetched into this ResultArchiveUpload object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ResultArchiveUploadEntity(System.Int64 resultArchiveUploadId):base("ResultArchiveUploadEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ResultArchiveUploadId = resultArchiveUploadId;
		}

		/// <summary> CTor</summary>
		/// <param name="resultArchiveUploadId">PK value for ResultArchiveUpload which data should be fetched into this ResultArchiveUpload object</param>
		/// <param name="validator">The custom validator object for this ResultArchiveUploadEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ResultArchiveUploadEntity(System.Int64 resultArchiveUploadId, IValidator validator):base("ResultArchiveUploadEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ResultArchiveUploadId = resultArchiveUploadId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ResultArchiveUploadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_resultArchiveUploadLog = (EntityCollection<ResultArchiveUploadLogEntity>)info.GetValue("_resultArchiveUploadLog", typeof(EntityCollection<ResultArchiveUploadLogEntity>));
				_customerProfileCollectionViaResultArchiveUploadLog = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaResultArchiveUploadLog", typeof(EntityCollection<CustomerProfileEntity>));
				_testCollectionViaResultArchiveUploadLog = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaResultArchiveUploadLog", typeof(EntityCollection<TestEntity>));
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file_ = (FileEntity)info.GetValue("_file_", typeof(FileEntity));
				if(_file_!=null)
				{
					_file_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ResultArchiveUploadFieldIndex)fieldIndex)
			{
				case ResultArchiveUploadFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case ResultArchiveUploadFieldIndex.FileId:
					DesetupSyncFile_(true, false);
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
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "File_":
					this.File_ = (FileEntity)entity;
					break;
				case "ResultArchiveUploadLog":
					this.ResultArchiveUploadLog.Add((ResultArchiveUploadLogEntity)entity);
					break;
				case "CustomerProfileCollectionViaResultArchiveUploadLog":
					this.CustomerProfileCollectionViaResultArchiveUploadLog.IsReadOnly = false;
					this.CustomerProfileCollectionViaResultArchiveUploadLog.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaResultArchiveUploadLog.IsReadOnly = true;
					break;
				case "TestCollectionViaResultArchiveUploadLog":
					this.TestCollectionViaResultArchiveUploadLog.IsReadOnly = false;
					this.TestCollectionViaResultArchiveUploadLog.Add((TestEntity)entity);
					this.TestCollectionViaResultArchiveUploadLog.IsReadOnly = true;
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
			return ResultArchiveUploadEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Events":
					toReturn.Add(ResultArchiveUploadEntity.Relations.EventsEntityUsingEventId);
					break;
				case "File_":
					toReturn.Add(ResultArchiveUploadEntity.Relations.FileEntityUsingFileId);
					break;
				case "ResultArchiveUploadLog":
					toReturn.Add(ResultArchiveUploadEntity.Relations.ResultArchiveUploadLogEntityUsingResultArchiveUploadId);
					break;
				case "CustomerProfileCollectionViaResultArchiveUploadLog":
					toReturn.Add(ResultArchiveUploadEntity.Relations.ResultArchiveUploadLogEntityUsingResultArchiveUploadId, "ResultArchiveUploadEntity__", "ResultArchiveUploadLog_", JoinHint.None);
					toReturn.Add(ResultArchiveUploadLogEntity.Relations.CustomerProfileEntityUsingCustomerId, "ResultArchiveUploadLog_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaResultArchiveUploadLog":
					toReturn.Add(ResultArchiveUploadEntity.Relations.ResultArchiveUploadLogEntityUsingResultArchiveUploadId, "ResultArchiveUploadEntity__", "ResultArchiveUploadLog_", JoinHint.None);
					toReturn.Add(ResultArchiveUploadLogEntity.Relations.TestEntityUsingTestId, "ResultArchiveUploadLog_", string.Empty, JoinHint.None);
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
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "File_":
					SetupSyncFile_(relatedEntity);
					break;
				case "ResultArchiveUploadLog":
					this.ResultArchiveUploadLog.Add((ResultArchiveUploadLogEntity)relatedEntity);
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
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "File_":
					DesetupSyncFile_(false, true);
					break;
				case "ResultArchiveUploadLog":
					base.PerformRelatedEntityRemoval(this.ResultArchiveUploadLog, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_file_!=null)
			{
				toReturn.Add(_file_);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ResultArchiveUploadLog);

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
				info.AddValue("_resultArchiveUploadLog", ((_resultArchiveUploadLog!=null) && (_resultArchiveUploadLog.Count>0) && !this.MarkedForDeletion)?_resultArchiveUploadLog:null);
				info.AddValue("_customerProfileCollectionViaResultArchiveUploadLog", ((_customerProfileCollectionViaResultArchiveUploadLog!=null) && (_customerProfileCollectionViaResultArchiveUploadLog.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaResultArchiveUploadLog:null);
				info.AddValue("_testCollectionViaResultArchiveUploadLog", ((_testCollectionViaResultArchiveUploadLog!=null) && (_testCollectionViaResultArchiveUploadLog.Count>0) && !this.MarkedForDeletion)?_testCollectionViaResultArchiveUploadLog:null);
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_file_", (!this.MarkedForDeletion?_file_:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ResultArchiveUploadFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ResultArchiveUploadFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ResultArchiveUploadRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ResultArchiveUploadLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoResultArchiveUploadLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ResultArchiveUploadLogFields.ResultArchiveUploadId, null, ComparisonOperator.Equal, this.ResultArchiveUploadId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaResultArchiveUploadLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaResultArchiveUploadLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ResultArchiveUploadFields.ResultArchiveUploadId, null, ComparisonOperator.Equal, this.ResultArchiveUploadId, "ResultArchiveUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaResultArchiveUploadLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaResultArchiveUploadLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ResultArchiveUploadFields.ResultArchiveUploadId, null, ComparisonOperator.Equal, this.ResultArchiveUploadId, "ResultArchiveUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Events' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.EventId, null, ComparisonOperator.Equal, this.EventId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.FileId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ResultArchiveUploadEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._resultArchiveUploadLog);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaResultArchiveUploadLog);
			collectionsQueue.Enqueue(this._testCollectionViaResultArchiveUploadLog);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._resultArchiveUploadLog = (EntityCollection<ResultArchiveUploadLogEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaResultArchiveUploadLog = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaResultArchiveUploadLog = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._resultArchiveUploadLog != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaResultArchiveUploadLog != null)
			{
				return true;
			}
			if (this._testCollectionViaResultArchiveUploadLog != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ResultArchiveUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
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
			toReturn.Add("Events", _events);
			toReturn.Add("File_", _file_);
			toReturn.Add("ResultArchiveUploadLog", _resultArchiveUploadLog);
			toReturn.Add("CustomerProfileCollectionViaResultArchiveUploadLog", _customerProfileCollectionViaResultArchiveUploadLog);
			toReturn.Add("TestCollectionViaResultArchiveUploadLog", _testCollectionViaResultArchiveUploadLog);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_resultArchiveUploadLog!=null)
			{
				_resultArchiveUploadLog.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaResultArchiveUploadLog!=null)
			{
				_customerProfileCollectionViaResultArchiveUploadLog.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaResultArchiveUploadLog!=null)
			{
				_testCollectionViaResultArchiveUploadLog.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_file_!=null)
			{
				_file_.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_resultArchiveUploadLog = null;
			_customerProfileCollectionViaResultArchiveUploadLog = null;
			_testCollectionViaResultArchiveUploadLog = null;
			_events = null;
			_file_ = null;

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

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UploadStartTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UploadEndTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParseStartTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParseEndTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerRecordsFound", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultArchiveUploadId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UploadPercentage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParsePercentage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UploadedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", ResultArchiveUploadEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "ResultArchiveUpload", resetFKFields, new int[] { (int)ResultArchiveUploadFieldIndex.EventId } );		
			_events = null;
		}

		/// <summary> setups the sync logic for member _events</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEvents(IEntity2 relatedEntity)
		{
			if(_events!=relatedEntity)
			{
				DesetupSyncEvents(true, true);
				_events = (EventsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", ResultArchiveUploadEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", ResultArchiveUploadEntity.Relations.FileEntityUsingFileId, true, signalRelatedEntity, "ResultArchiveUpload", resetFKFields, new int[] { (int)ResultArchiveUploadFieldIndex.FileId } );		
			_file_ = null;
		}

		/// <summary> setups the sync logic for member _file_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile_(IEntity2 relatedEntity)
		{
			if(_file_!=relatedEntity)
			{
				DesetupSyncFile_(true, true);
				_file_ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", ResultArchiveUploadEntity.Relations.FileEntityUsingFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ResultArchiveUploadEntity</param>
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
		public  static ResultArchiveUploadRelations Relations
		{
			get	{ return new ResultArchiveUploadRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ResultArchiveUploadLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathResultArchiveUploadLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ResultArchiveUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("ResultArchiveUploadLog")[0], (int)Falcon.Data.EntityType.ResultArchiveUploadEntity, (int)Falcon.Data.EntityType.ResultArchiveUploadLogEntity, 0, null, null, null, null, "ResultArchiveUploadLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaResultArchiveUploadLog
		{
			get
			{
				IEntityRelation intermediateRelation = ResultArchiveUploadEntity.Relations.ResultArchiveUploadLogEntityUsingResultArchiveUploadId;
				intermediateRelation.SetAliases(string.Empty, "ResultArchiveUploadLog_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ResultArchiveUploadEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaResultArchiveUploadLog"), null, "CustomerProfileCollectionViaResultArchiveUploadLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaResultArchiveUploadLog
		{
			get
			{
				IEntityRelation intermediateRelation = ResultArchiveUploadEntity.Relations.ResultArchiveUploadLogEntityUsingResultArchiveUploadId;
				intermediateRelation.SetAliases(string.Empty, "ResultArchiveUploadLog_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ResultArchiveUploadEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaResultArchiveUploadLog"), null, "TestCollectionViaResultArchiveUploadLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.ResultArchiveUploadEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File_")[0], (int)Falcon.Data.EntityType.ResultArchiveUploadEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ResultArchiveUploadEntity.CustomProperties;}
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
			get { return ResultArchiveUploadEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventId property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)ResultArchiveUploadFieldIndex.EventId, true); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.EventId, value); }
		}

		/// <summary> The UploadStartTime property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."UploadStartTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime UploadStartTime
		{
			get { return (System.DateTime)GetValue((int)ResultArchiveUploadFieldIndex.UploadStartTime, true); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.UploadStartTime, value); }
		}

		/// <summary> The UploadEndTime property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."UploadEndTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> UploadEndTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ResultArchiveUploadFieldIndex.UploadEndTime, false); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.UploadEndTime, value); }
		}

		/// <summary> The ParseStartTime property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."ParseStartTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ParseStartTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ResultArchiveUploadFieldIndex.ParseStartTime, false); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.ParseStartTime, value); }
		}

		/// <summary> The ParseEndTime property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."ParseEndTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ParseEndTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ResultArchiveUploadFieldIndex.ParseEndTime, false); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.ParseEndTime, value); }
		}

		/// <summary> The CustomerRecordsFound property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."CustomerRecordsFound"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CustomerRecordsFound
		{
			get { return (System.Int32)GetValue((int)ResultArchiveUploadFieldIndex.CustomerRecordsFound, true); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.CustomerRecordsFound, value); }
		}

		/// <summary> The Status property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Status
		{
			get { return (System.Int32)GetValue((int)ResultArchiveUploadFieldIndex.Status, true); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.Status, value); }
		}

		/// <summary> The ResultArchiveUploadId property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."ResultArchiveUploadID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ResultArchiveUploadId
		{
			get { return (System.Int64)GetValue((int)ResultArchiveUploadFieldIndex.ResultArchiveUploadId, true); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.ResultArchiveUploadId, value); }
		}

		/// <summary> The FileId property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."FileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> FileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ResultArchiveUploadFieldIndex.FileId, false); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.FileId, value); }
		}

		/// <summary> The UploadPercentage property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."UploadPercentage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> UploadPercentage
		{
			get { return (Nullable<System.Int32>)GetValue((int)ResultArchiveUploadFieldIndex.UploadPercentage, false); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.UploadPercentage, value); }
		}

		/// <summary> The ParsePercentage property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."ParsePercentage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ParsePercentage
		{
			get { return (Nullable<System.Int32>)GetValue((int)ResultArchiveUploadFieldIndex.ParsePercentage, false); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.ParsePercentage, value); }
		}

		/// <summary> The UploadedByOrgRoleUserId property of the Entity ResultArchiveUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblResultArchiveUpload"."UploadedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 UploadedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)ResultArchiveUploadFieldIndex.UploadedByOrgRoleUserId, true); }
			set	{ SetValue((int)ResultArchiveUploadFieldIndex.UploadedByOrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ResultArchiveUploadLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ResultArchiveUploadLogEntity))]
		public virtual EntityCollection<ResultArchiveUploadLogEntity> ResultArchiveUploadLog
		{
			get
			{
				if(_resultArchiveUploadLog==null)
				{
					_resultArchiveUploadLog = new EntityCollection<ResultArchiveUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadLogEntityFactory)));
					_resultArchiveUploadLog.SetContainingEntityInfo(this, "ResultArchiveUpload");
				}
				return _resultArchiveUploadLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaResultArchiveUploadLog
		{
			get
			{
				if(_customerProfileCollectionViaResultArchiveUploadLog==null)
				{
					_customerProfileCollectionViaResultArchiveUploadLog = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaResultArchiveUploadLog.IsReadOnly=true;
				}
				return _customerProfileCollectionViaResultArchiveUploadLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaResultArchiveUploadLog
		{
			get
			{
				if(_testCollectionViaResultArchiveUploadLog==null)
				{
					_testCollectionViaResultArchiveUploadLog = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaResultArchiveUploadLog.IsReadOnly=true;
				}
				return _testCollectionViaResultArchiveUploadLog;
			}
		}

		/// <summary> Gets / sets related entity of type 'EventsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventsEntity Events
		{
			get
			{
				return _events;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEvents(value);
				}
				else
				{
					if(value==null)
					{
						if(_events != null)
						{
							_events.UnsetRelatedEntity(this, "ResultArchiveUpload");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ResultArchiveUpload");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File_
		{
			get
			{
				return _file_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile_(value);
				}
				else
				{
					if(value==null)
					{
						if(_file_ != null)
						{
							_file_.UnsetRelatedEntity(this, "ResultArchiveUpload");
						}
					}
					else
					{
						if(_file_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ResultArchiveUpload");
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
			get { return (int)Falcon.Data.EntityType.ResultArchiveUploadEntity; }
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
