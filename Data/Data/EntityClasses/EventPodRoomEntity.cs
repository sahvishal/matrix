///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:48
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
	/// Entity class which represents the entity 'EventPodRoom'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventPodRoomEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventPodRoomTestEntity> _eventPodRoomTest;
		private EntityCollection<EventSchedulingSlotEntity> _eventSchedulingSlot;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventSchedulingSlot;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventSchedulingSlot;
		private EntityCollection<TestEntity> _testCollectionViaEventPodRoomTest;
		private EventPodEntity _eventPod;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name EventPod</summary>
			public static readonly string EventPod = "EventPod";
			/// <summary>Member name EventPodRoomTest</summary>
			public static readonly string EventPodRoomTest = "EventPodRoomTest";
			/// <summary>Member name EventSchedulingSlot</summary>
			public static readonly string EventSchedulingSlot = "EventSchedulingSlot";
			/// <summary>Member name EventsCollectionViaEventSchedulingSlot</summary>
			public static readonly string EventsCollectionViaEventSchedulingSlot = "EventsCollectionViaEventSchedulingSlot";
			/// <summary>Member name LookupCollectionViaEventSchedulingSlot</summary>
			public static readonly string LookupCollectionViaEventSchedulingSlot = "LookupCollectionViaEventSchedulingSlot";
			/// <summary>Member name TestCollectionViaEventPodRoomTest</summary>
			public static readonly string TestCollectionViaEventPodRoomTest = "TestCollectionViaEventPodRoomTest";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventPodRoomEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventPodRoomEntity():base("EventPodRoomEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventPodRoomEntity(IEntityFields2 fields):base("EventPodRoomEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventPodRoomEntity</param>
		public EventPodRoomEntity(IValidator validator):base("EventPodRoomEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eventPodRoomId">PK value for EventPodRoom which data should be fetched into this EventPodRoom object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventPodRoomEntity(System.Int64 eventPodRoomId):base("EventPodRoomEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EventPodRoomId = eventPodRoomId;
		}

		/// <summary> CTor</summary>
		/// <param name="eventPodRoomId">PK value for EventPodRoom which data should be fetched into this EventPodRoom object</param>
		/// <param name="validator">The custom validator object for this EventPodRoomEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventPodRoomEntity(System.Int64 eventPodRoomId, IValidator validator):base("EventPodRoomEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EventPodRoomId = eventPodRoomId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventPodRoomEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventPodRoomTest = (EntityCollection<EventPodRoomTestEntity>)info.GetValue("_eventPodRoomTest", typeof(EntityCollection<EventPodRoomTestEntity>));
				_eventSchedulingSlot = (EntityCollection<EventSchedulingSlotEntity>)info.GetValue("_eventSchedulingSlot", typeof(EntityCollection<EventSchedulingSlotEntity>));
				_eventsCollectionViaEventSchedulingSlot = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventSchedulingSlot", typeof(EntityCollection<EventsEntity>));
				_lookupCollectionViaEventSchedulingSlot = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventSchedulingSlot", typeof(EntityCollection<LookupEntity>));
				_testCollectionViaEventPodRoomTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventPodRoomTest", typeof(EntityCollection<TestEntity>));
				_eventPod = (EventPodEntity)info.GetValue("_eventPod", typeof(EventPodEntity));
				if(_eventPod!=null)
				{
					_eventPod.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EventPodRoomFieldIndex)fieldIndex)
			{
				case EventPodRoomFieldIndex.EventPodId:
					DesetupSyncEventPod(true, false);
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
				case "EventPod":
					this.EventPod = (EventPodEntity)entity;
					break;
				case "EventPodRoomTest":
					this.EventPodRoomTest.Add((EventPodRoomTestEntity)entity);
					break;
				case "EventSchedulingSlot":
					this.EventSchedulingSlot.Add((EventSchedulingSlotEntity)entity);
					break;
				case "EventsCollectionViaEventSchedulingSlot":
					this.EventsCollectionViaEventSchedulingSlot.IsReadOnly = false;
					this.EventsCollectionViaEventSchedulingSlot.Add((EventsEntity)entity);
					this.EventsCollectionViaEventSchedulingSlot.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventSchedulingSlot":
					this.LookupCollectionViaEventSchedulingSlot.IsReadOnly = false;
					this.LookupCollectionViaEventSchedulingSlot.Add((LookupEntity)entity);
					this.LookupCollectionViaEventSchedulingSlot.IsReadOnly = true;
					break;
				case "TestCollectionViaEventPodRoomTest":
					this.TestCollectionViaEventPodRoomTest.IsReadOnly = false;
					this.TestCollectionViaEventPodRoomTest.Add((TestEntity)entity);
					this.TestCollectionViaEventPodRoomTest.IsReadOnly = true;
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
			return EventPodRoomEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "EventPod":
					toReturn.Add(EventPodRoomEntity.Relations.EventPodEntityUsingEventPodId);
					break;
				case "EventPodRoomTest":
					toReturn.Add(EventPodRoomEntity.Relations.EventPodRoomTestEntityUsingEventPodRoomId);
					break;
				case "EventSchedulingSlot":
					toReturn.Add(EventPodRoomEntity.Relations.EventSchedulingSlotEntityUsingEventPodRoomId);
					break;
				case "EventsCollectionViaEventSchedulingSlot":
					toReturn.Add(EventPodRoomEntity.Relations.EventSchedulingSlotEntityUsingEventPodRoomId, "EventPodRoomEntity__", "EventSchedulingSlot_", JoinHint.None);
					toReturn.Add(EventSchedulingSlotEntity.Relations.EventsEntityUsingEventId, "EventSchedulingSlot_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventSchedulingSlot":
					toReturn.Add(EventPodRoomEntity.Relations.EventSchedulingSlotEntityUsingEventPodRoomId, "EventPodRoomEntity__", "EventSchedulingSlot_", JoinHint.None);
					toReturn.Add(EventSchedulingSlotEntity.Relations.LookupEntityUsingStatus, "EventSchedulingSlot_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventPodRoomTest":
					toReturn.Add(EventPodRoomEntity.Relations.EventPodRoomTestEntityUsingEventPodRoomId, "EventPodRoomEntity__", "EventPodRoomTest_", JoinHint.None);
					toReturn.Add(EventPodRoomTestEntity.Relations.TestEntityUsingTestId, "EventPodRoomTest_", string.Empty, JoinHint.None);
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
				case "EventPod":
					SetupSyncEventPod(relatedEntity);
					break;
				case "EventPodRoomTest":
					this.EventPodRoomTest.Add((EventPodRoomTestEntity)relatedEntity);
					break;
				case "EventSchedulingSlot":
					this.EventSchedulingSlot.Add((EventSchedulingSlotEntity)relatedEntity);
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
				case "EventPod":
					DesetupSyncEventPod(false, true);
					break;
				case "EventPodRoomTest":
					base.PerformRelatedEntityRemoval(this.EventPodRoomTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventSchedulingSlot":
					base.PerformRelatedEntityRemoval(this.EventSchedulingSlot, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_eventPod!=null)
			{
				toReturn.Add(_eventPod);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventPodRoomTest);
			toReturn.Add(this.EventSchedulingSlot);

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
				info.AddValue("_eventPodRoomTest", ((_eventPodRoomTest!=null) && (_eventPodRoomTest.Count>0) && !this.MarkedForDeletion)?_eventPodRoomTest:null);
				info.AddValue("_eventSchedulingSlot", ((_eventSchedulingSlot!=null) && (_eventSchedulingSlot.Count>0) && !this.MarkedForDeletion)?_eventSchedulingSlot:null);
				info.AddValue("_eventsCollectionViaEventSchedulingSlot", ((_eventsCollectionViaEventSchedulingSlot!=null) && (_eventsCollectionViaEventSchedulingSlot.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventSchedulingSlot:null);
				info.AddValue("_lookupCollectionViaEventSchedulingSlot", ((_lookupCollectionViaEventSchedulingSlot!=null) && (_lookupCollectionViaEventSchedulingSlot.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventSchedulingSlot:null);
				info.AddValue("_testCollectionViaEventPodRoomTest", ((_testCollectionViaEventPodRoomTest!=null) && (_testCollectionViaEventPodRoomTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventPodRoomTest:null);
				info.AddValue("_eventPod", (!this.MarkedForDeletion?_eventPod:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(EventPodRoomFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventPodRoomFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventPodRoomRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPodRoomTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPodRoomTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPodRoomTestFields.EventPodRoomId, null, ComparisonOperator.Equal, this.EventPodRoomId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventSchedulingSlot' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventSchedulingSlot()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventSchedulingSlotFields.EventPodRoomId, null, ComparisonOperator.Equal, this.EventPodRoomId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventSchedulingSlot()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventSchedulingSlot"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPodRoomFields.EventPodRoomId, null, ComparisonOperator.Equal, this.EventPodRoomId, "EventPodRoomEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventSchedulingSlot()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventSchedulingSlot"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPodRoomFields.EventPodRoomId, null, ComparisonOperator.Equal, this.EventPodRoomId, "EventPodRoomEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventPodRoomTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventPodRoomTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPodRoomFields.EventPodRoomId, null, ComparisonOperator.Equal, this.EventPodRoomId, "EventPodRoomEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventPod' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPodFields.EventPodId, null, ComparisonOperator.Equal, this.EventPodId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventPodRoomEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventPodRoomTest);
			collectionsQueue.Enqueue(this._eventSchedulingSlot);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventSchedulingSlot);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventSchedulingSlot);
			collectionsQueue.Enqueue(this._testCollectionViaEventPodRoomTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventPodRoomTest = (EntityCollection<EventPodRoomTestEntity>) collectionsQueue.Dequeue();
			this._eventSchedulingSlot = (EntityCollection<EventSchedulingSlotEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventSchedulingSlot = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventSchedulingSlot = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventPodRoomTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventPodRoomTest != null)
			{
				return true;
			}
			if (this._eventSchedulingSlot != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventSchedulingSlot != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventSchedulingSlot != null)
			{
				return true;
			}
			if (this._testCollectionViaEventPodRoomTest != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventSchedulingSlotEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventSchedulingSlotEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
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
			toReturn.Add("EventPod", _eventPod);
			toReturn.Add("EventPodRoomTest", _eventPodRoomTest);
			toReturn.Add("EventSchedulingSlot", _eventSchedulingSlot);
			toReturn.Add("EventsCollectionViaEventSchedulingSlot", _eventsCollectionViaEventSchedulingSlot);
			toReturn.Add("LookupCollectionViaEventSchedulingSlot", _lookupCollectionViaEventSchedulingSlot);
			toReturn.Add("TestCollectionViaEventPodRoomTest", _testCollectionViaEventPodRoomTest);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventPodRoomTest!=null)
			{
				_eventPodRoomTest.ActiveContext = base.ActiveContext;
			}
			if(_eventSchedulingSlot!=null)
			{
				_eventSchedulingSlot.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventSchedulingSlot!=null)
			{
				_eventsCollectionViaEventSchedulingSlot.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventSchedulingSlot!=null)
			{
				_lookupCollectionViaEventSchedulingSlot.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventPodRoomTest!=null)
			{
				_testCollectionViaEventPodRoomTest.ActiveContext = base.ActiveContext;
			}
			if(_eventPod!=null)
			{
				_eventPod.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventPodRoomTest = null;
			_eventSchedulingSlot = null;
			_eventsCollectionViaEventSchedulingSlot = null;
			_lookupCollectionViaEventSchedulingSlot = null;
			_testCollectionViaEventPodRoomTest = null;
			_eventPod = null;

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

			_fieldsCustomProperties.Add("EventPodRoomId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventPodId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoomNo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Duration", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _eventPod</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventPod(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventPod, new PropertyChangedEventHandler( OnEventPodPropertyChanged ), "EventPod", EventPodRoomEntity.Relations.EventPodEntityUsingEventPodId, true, signalRelatedEntity, "EventPodRoom", resetFKFields, new int[] { (int)EventPodRoomFieldIndex.EventPodId } );		
			_eventPod = null;
		}

		/// <summary> setups the sync logic for member _eventPod</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventPod(IEntity2 relatedEntity)
		{
			if(_eventPod!=relatedEntity)
			{
				DesetupSyncEventPod(true, true);
				_eventPod = (EventPodEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventPod, new PropertyChangedEventHandler( OnEventPodPropertyChanged ), "EventPod", EventPodRoomEntity.Relations.EventPodEntityUsingEventPodId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventPodPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EventPodRoomEntity</param>
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
		public  static EventPodRoomRelations Relations
		{
			get	{ return new EventPodRoomRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPodRoomTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPodRoomTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPodRoomTest")[0], (int)Falcon.Data.EntityType.EventPodRoomEntity, (int)Falcon.Data.EntityType.EventPodRoomTestEntity, 0, null, null, null, null, "EventPodRoomTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventSchedulingSlot' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventSchedulingSlot
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventSchedulingSlotEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventSchedulingSlotEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventSchedulingSlot")[0], (int)Falcon.Data.EntityType.EventPodRoomEntity, (int)Falcon.Data.EntityType.EventSchedulingSlotEntity, 0, null, null, null, null, "EventSchedulingSlot", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventSchedulingSlot
		{
			get
			{
				IEntityRelation intermediateRelation = EventPodRoomEntity.Relations.EventSchedulingSlotEntityUsingEventPodRoomId;
				intermediateRelation.SetAliases(string.Empty, "EventSchedulingSlot_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPodRoomEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventSchedulingSlot"), null, "EventsCollectionViaEventSchedulingSlot", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventSchedulingSlot
		{
			get
			{
				IEntityRelation intermediateRelation = EventPodRoomEntity.Relations.EventSchedulingSlotEntityUsingEventPodRoomId;
				intermediateRelation.SetAliases(string.Empty, "EventSchedulingSlot_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPodRoomEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventSchedulingSlot"), null, "LookupCollectionViaEventSchedulingSlot", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventPodRoomTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventPodRoomEntity.Relations.EventPodRoomTestEntityUsingEventPodRoomId;
				intermediateRelation.SetAliases(string.Empty, "EventPodRoomTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPodRoomEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventPodRoomTest"), null, "TestCollectionViaEventPodRoomTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPod' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPod
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventPodEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPod")[0], (int)Falcon.Data.EntityType.EventPodRoomEntity, (int)Falcon.Data.EntityType.EventPodEntity, 0, null, null, null, null, "EventPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventPodRoomEntity.CustomProperties;}
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
			get { return EventPodRoomEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventPodRoomId property of the Entity EventPodRoom<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPodRoom"."EventPodRoomId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 EventPodRoomId
		{
			get { return (System.Int64)GetValue((int)EventPodRoomFieldIndex.EventPodRoomId, true); }
			set	{ SetValue((int)EventPodRoomFieldIndex.EventPodRoomId, value); }
		}

		/// <summary> The EventPodId property of the Entity EventPodRoom<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPodRoom"."EventPodId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventPodId
		{
			get { return (System.Int64)GetValue((int)EventPodRoomFieldIndex.EventPodId, true); }
			set	{ SetValue((int)EventPodRoomFieldIndex.EventPodId, value); }
		}

		/// <summary> The RoomNo property of the Entity EventPodRoom<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPodRoom"."RoomNo"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RoomNo
		{
			get { return (System.Int32)GetValue((int)EventPodRoomFieldIndex.RoomNo, true); }
			set	{ SetValue((int)EventPodRoomFieldIndex.RoomNo, value); }
		}

		/// <summary> The Duration property of the Entity EventPodRoom<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPodRoom"."Duration"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Duration
		{
			get { return (System.Int32)GetValue((int)EventPodRoomFieldIndex.Duration, true); }
			set	{ SetValue((int)EventPodRoomFieldIndex.Duration, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPodRoomTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPodRoomTestEntity))]
		public virtual EntityCollection<EventPodRoomTestEntity> EventPodRoomTest
		{
			get
			{
				if(_eventPodRoomTest==null)
				{
					_eventPodRoomTest = new EntityCollection<EventPodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomTestEntityFactory)));
					_eventPodRoomTest.SetContainingEntityInfo(this, "EventPodRoom");
				}
				return _eventPodRoomTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventSchedulingSlotEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventSchedulingSlotEntity))]
		public virtual EntityCollection<EventSchedulingSlotEntity> EventSchedulingSlot
		{
			get
			{
				if(_eventSchedulingSlot==null)
				{
					_eventSchedulingSlot = new EntityCollection<EventSchedulingSlotEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventSchedulingSlotEntityFactory)));
					_eventSchedulingSlot.SetContainingEntityInfo(this, "EventPodRoom");
				}
				return _eventSchedulingSlot;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventSchedulingSlot
		{
			get
			{
				if(_eventsCollectionViaEventSchedulingSlot==null)
				{
					_eventsCollectionViaEventSchedulingSlot = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventSchedulingSlot.IsReadOnly=true;
				}
				return _eventsCollectionViaEventSchedulingSlot;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventSchedulingSlot
		{
			get
			{
				if(_lookupCollectionViaEventSchedulingSlot==null)
				{
					_lookupCollectionViaEventSchedulingSlot = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventSchedulingSlot.IsReadOnly=true;
				}
				return _lookupCollectionViaEventSchedulingSlot;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventPodRoomTest
		{
			get
			{
				if(_testCollectionViaEventPodRoomTest==null)
				{
					_testCollectionViaEventPodRoomTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventPodRoomTest.IsReadOnly=true;
				}
				return _testCollectionViaEventPodRoomTest;
			}
		}

		/// <summary> Gets / sets related entity of type 'EventPodEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventPodEntity EventPod
		{
			get
			{
				return _eventPod;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventPod(value);
				}
				else
				{
					if(value==null)
					{
						if(_eventPod != null)
						{
							_eventPod.UnsetRelatedEntity(this, "EventPodRoom");
						}
					}
					else
					{
						if(_eventPod!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventPodRoom");
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
			get { return (int)Falcon.Data.EntityType.EventPodRoomEntity; }
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
