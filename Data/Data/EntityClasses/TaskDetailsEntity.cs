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
	/// Entity class which represents the entity 'TaskDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TaskDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventTaskDetailsEntity> _eventTaskDetails;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventTaskDetails;
		private OrganizationRoleUserEntity _organizationRoleUser__;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private TaskPriorityTypesEntity _taskPriorityTypes;
		private TaskStatusTypesEntity _taskStatusTypes;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name OrganizationRoleUser__</summary>
			public static readonly string OrganizationRoleUser__ = "OrganizationRoleUser__";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name TaskPriorityTypes</summary>
			public static readonly string TaskPriorityTypes = "TaskPriorityTypes";
			/// <summary>Member name TaskStatusTypes</summary>
			public static readonly string TaskStatusTypes = "TaskStatusTypes";
			/// <summary>Member name EventTaskDetails</summary>
			public static readonly string EventTaskDetails = "EventTaskDetails";
			/// <summary>Member name EventsCollectionViaEventTaskDetails</summary>
			public static readonly string EventsCollectionViaEventTaskDetails = "EventsCollectionViaEventTaskDetails";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TaskDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TaskDetailsEntity():base("TaskDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TaskDetailsEntity(IEntityFields2 fields):base("TaskDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TaskDetailsEntity</param>
		public TaskDetailsEntity(IValidator validator):base("TaskDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="taskId">PK value for TaskDetails which data should be fetched into this TaskDetails object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TaskDetailsEntity(System.Int64 taskId):base("TaskDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TaskId = taskId;
		}

		/// <summary> CTor</summary>
		/// <param name="taskId">PK value for TaskDetails which data should be fetched into this TaskDetails object</param>
		/// <param name="validator">The custom validator object for this TaskDetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TaskDetailsEntity(System.Int64 taskId, IValidator validator):base("TaskDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TaskId = taskId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TaskDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventTaskDetails = (EntityCollection<EventTaskDetailsEntity>)info.GetValue("_eventTaskDetails", typeof(EntityCollection<EventTaskDetailsEntity>));
				_eventsCollectionViaEventTaskDetails = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventTaskDetails", typeof(EntityCollection<EventsEntity>));
				_organizationRoleUser__ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser__", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser__!=null)
				{
					_organizationRoleUser__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_taskPriorityTypes = (TaskPriorityTypesEntity)info.GetValue("_taskPriorityTypes", typeof(TaskPriorityTypesEntity));
				if(_taskPriorityTypes!=null)
				{
					_taskPriorityTypes.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_taskStatusTypes = (TaskStatusTypesEntity)info.GetValue("_taskStatusTypes", typeof(TaskStatusTypesEntity));
				if(_taskStatusTypes!=null)
				{
					_taskStatusTypes.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TaskDetailsFieldIndex)fieldIndex)
			{
				case TaskDetailsFieldIndex.TaskPriorityId:
					DesetupSyncTaskPriorityTypes(true, false);
					break;
				case TaskDetailsFieldIndex.TaskStatusId:
					DesetupSyncTaskStatusTypes(true, false);
					break;
				case TaskDetailsFieldIndex.AssignedToOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case TaskDetailsFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case TaskDetailsFieldIndex.ModifiedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser__(true, false);
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
				case "OrganizationRoleUser__":
					this.OrganizationRoleUser__ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "TaskPriorityTypes":
					this.TaskPriorityTypes = (TaskPriorityTypesEntity)entity;
					break;
				case "TaskStatusTypes":
					this.TaskStatusTypes = (TaskStatusTypesEntity)entity;
					break;
				case "EventTaskDetails":
					this.EventTaskDetails.Add((EventTaskDetailsEntity)entity);
					break;
				case "EventsCollectionViaEventTaskDetails":
					this.EventsCollectionViaEventTaskDetails.IsReadOnly = false;
					this.EventsCollectionViaEventTaskDetails.Add((EventsEntity)entity);
					this.EventsCollectionViaEventTaskDetails.IsReadOnly = true;
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
			return TaskDetailsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser__":
					toReturn.Add(TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId);
					break;
				case "TaskPriorityTypes":
					toReturn.Add(TaskDetailsEntity.Relations.TaskPriorityTypesEntityUsingTaskPriorityId);
					break;
				case "TaskStatusTypes":
					toReturn.Add(TaskDetailsEntity.Relations.TaskStatusTypesEntityUsingTaskStatusId);
					break;
				case "EventTaskDetails":
					toReturn.Add(TaskDetailsEntity.Relations.EventTaskDetailsEntityUsingTaskId);
					break;
				case "EventsCollectionViaEventTaskDetails":
					toReturn.Add(TaskDetailsEntity.Relations.EventTaskDetailsEntityUsingTaskId, "TaskDetailsEntity__", "EventTaskDetails_", JoinHint.None);
					toReturn.Add(EventTaskDetailsEntity.Relations.EventsEntityUsingEventId, "EventTaskDetails_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser__":
					SetupSyncOrganizationRoleUser__(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "TaskPriorityTypes":
					SetupSyncTaskPriorityTypes(relatedEntity);
					break;
				case "TaskStatusTypes":
					SetupSyncTaskStatusTypes(relatedEntity);
					break;
				case "EventTaskDetails":
					this.EventTaskDetails.Add((EventTaskDetailsEntity)relatedEntity);
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
				case "OrganizationRoleUser__":
					DesetupSyncOrganizationRoleUser__(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "TaskPriorityTypes":
					DesetupSyncTaskPriorityTypes(false, true);
					break;
				case "TaskStatusTypes":
					DesetupSyncTaskStatusTypes(false, true);
					break;
				case "EventTaskDetails":
					base.PerformRelatedEntityRemoval(this.EventTaskDetails, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organizationRoleUser__!=null)
			{
				toReturn.Add(_organizationRoleUser__);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_taskPriorityTypes!=null)
			{
				toReturn.Add(_taskPriorityTypes);
			}
			if(_taskStatusTypes!=null)
			{
				toReturn.Add(_taskStatusTypes);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventTaskDetails);

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
				info.AddValue("_eventTaskDetails", ((_eventTaskDetails!=null) && (_eventTaskDetails.Count>0) && !this.MarkedForDeletion)?_eventTaskDetails:null);
				info.AddValue("_eventsCollectionViaEventTaskDetails", ((_eventsCollectionViaEventTaskDetails!=null) && (_eventsCollectionViaEventTaskDetails.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventTaskDetails:null);
				info.AddValue("_organizationRoleUser__", (!this.MarkedForDeletion?_organizationRoleUser__:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_taskPriorityTypes", (!this.MarkedForDeletion?_taskPriorityTypes:null));
				info.AddValue("_taskStatusTypes", (!this.MarkedForDeletion?_taskStatusTypes:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TaskDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TaskDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TaskDetailsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTaskDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTaskDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTaskDetailsFields.TaskId, null, ComparisonOperator.Equal, this.TaskId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventTaskDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventTaskDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TaskDetailsFields.TaskId, null, ComparisonOperator.Equal, this.TaskId, "TaskDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.AssignedToOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TaskPriorityTypes' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTaskPriorityTypes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TaskPriorityTypesFields.TaskPriorityId, null, ComparisonOperator.Equal, this.TaskPriorityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TaskStatusTypes' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTaskStatusTypes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TaskStatusTypesFields.TaskStatusId, null, ComparisonOperator.Equal, this.TaskStatusId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.TaskDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TaskDetailsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventTaskDetails);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventTaskDetails);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventTaskDetails = (EntityCollection<EventTaskDetailsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventTaskDetails = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventTaskDetails != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventTaskDetails != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTaskDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTaskDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("OrganizationRoleUser__", _organizationRoleUser__);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("TaskPriorityTypes", _taskPriorityTypes);
			toReturn.Add("TaskStatusTypes", _taskStatusTypes);
			toReturn.Add("EventTaskDetails", _eventTaskDetails);
			toReturn.Add("EventsCollectionViaEventTaskDetails", _eventsCollectionViaEventTaskDetails);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventTaskDetails!=null)
			{
				_eventTaskDetails.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventTaskDetails!=null)
			{
				_eventsCollectionViaEventTaskDetails.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser__!=null)
			{
				_organizationRoleUser__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_taskPriorityTypes!=null)
			{
				_taskPriorityTypes.ActiveContext = base.ActiveContext;
			}
			if(_taskStatusTypes!=null)
			{
				_taskStatusTypes.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventTaskDetails = null;
			_eventsCollectionViaEventTaskDetails = null;
			_organizationRoleUser__ = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser = null;
			_taskPriorityTypes = null;
			_taskStatusTypes = null;

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

			_fieldsCustomProperties.Add("TaskId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Subject", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StartTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DueDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DueTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TaskPriorityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TaskStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AssignedToOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "TaskDetails__", resetFKFields, new int[] { (int)TaskDetailsFieldIndex.ModifiedByOrgRoleUserId } );		
			_organizationRoleUser__ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser__(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser__!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser__(true, true);
				_organizationRoleUser__ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "TaskDetails_", resetFKFields, new int[] { (int)TaskDetailsFieldIndex.CreatedByOrgRoleUserId } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, true, signalRelatedEntity, "TaskDetails", resetFKFields, new int[] { (int)TaskDetailsFieldIndex.AssignedToOrgRoleUserId } );		
			_organizationRoleUser = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser(true, true);
				_organizationRoleUser = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _taskPriorityTypes</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTaskPriorityTypes(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _taskPriorityTypes, new PropertyChangedEventHandler( OnTaskPriorityTypesPropertyChanged ), "TaskPriorityTypes", TaskDetailsEntity.Relations.TaskPriorityTypesEntityUsingTaskPriorityId, true, signalRelatedEntity, "TaskDetails", resetFKFields, new int[] { (int)TaskDetailsFieldIndex.TaskPriorityId } );		
			_taskPriorityTypes = null;
		}

		/// <summary> setups the sync logic for member _taskPriorityTypes</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTaskPriorityTypes(IEntity2 relatedEntity)
		{
			if(_taskPriorityTypes!=relatedEntity)
			{
				DesetupSyncTaskPriorityTypes(true, true);
				_taskPriorityTypes = (TaskPriorityTypesEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _taskPriorityTypes, new PropertyChangedEventHandler( OnTaskPriorityTypesPropertyChanged ), "TaskPriorityTypes", TaskDetailsEntity.Relations.TaskPriorityTypesEntityUsingTaskPriorityId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTaskPriorityTypesPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _taskStatusTypes</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTaskStatusTypes(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _taskStatusTypes, new PropertyChangedEventHandler( OnTaskStatusTypesPropertyChanged ), "TaskStatusTypes", TaskDetailsEntity.Relations.TaskStatusTypesEntityUsingTaskStatusId, true, signalRelatedEntity, "TaskDetails", resetFKFields, new int[] { (int)TaskDetailsFieldIndex.TaskStatusId } );		
			_taskStatusTypes = null;
		}

		/// <summary> setups the sync logic for member _taskStatusTypes</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTaskStatusTypes(IEntity2 relatedEntity)
		{
			if(_taskStatusTypes!=relatedEntity)
			{
				DesetupSyncTaskStatusTypes(true, true);
				_taskStatusTypes = (TaskStatusTypesEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _taskStatusTypes, new PropertyChangedEventHandler( OnTaskStatusTypesPropertyChanged ), "TaskStatusTypes", TaskDetailsEntity.Relations.TaskStatusTypesEntityUsingTaskStatusId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTaskStatusTypesPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TaskDetailsEntity</param>
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
		public  static TaskDetailsRelations Relations
		{
			get	{ return new TaskDetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTaskDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTaskDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventTaskDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTaskDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventTaskDetails")[0], (int)Falcon.Data.EntityType.TaskDetailsEntity, (int)Falcon.Data.EntityType.EventTaskDetailsEntity, 0, null, null, null, null, "EventTaskDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventTaskDetails
		{
			get
			{
				IEntityRelation intermediateRelation = TaskDetailsEntity.Relations.EventTaskDetailsEntityUsingTaskId;
				intermediateRelation.SetAliases(string.Empty, "EventTaskDetails_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TaskDetailsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventTaskDetails"), null, "EventsCollectionViaEventTaskDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser__")[0], (int)Falcon.Data.EntityType.TaskDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.TaskDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.TaskDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TaskPriorityTypes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTaskPriorityTypes
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TaskPriorityTypesEntityFactory))),
					(IEntityRelation)GetRelationsForField("TaskPriorityTypes")[0], (int)Falcon.Data.EntityType.TaskDetailsEntity, (int)Falcon.Data.EntityType.TaskPriorityTypesEntity, 0, null, null, null, null, "TaskPriorityTypes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TaskStatusTypes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTaskStatusTypes
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TaskStatusTypesEntityFactory))),
					(IEntityRelation)GetRelationsForField("TaskStatusTypes")[0], (int)Falcon.Data.EntityType.TaskDetailsEntity, (int)Falcon.Data.EntityType.TaskStatusTypesEntity, 0, null, null, null, null, "TaskStatusTypes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TaskDetailsEntity.CustomProperties;}
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
			get { return TaskDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The TaskId property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."TaskID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TaskId
		{
			get { return (System.Int64)GetValue((int)TaskDetailsFieldIndex.TaskId, true); }
			set	{ SetValue((int)TaskDetailsFieldIndex.TaskId, value); }
		}

		/// <summary> The Subject property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."Subject"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Subject
		{
			get { return (System.String)GetValue((int)TaskDetailsFieldIndex.Subject, true); }
			set	{ SetValue((int)TaskDetailsFieldIndex.Subject, value); }
		}

		/// <summary> The Notes property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)TaskDetailsFieldIndex.Notes, true); }
			set	{ SetValue((int)TaskDetailsFieldIndex.Notes, value); }
		}

		/// <summary> The StartDate property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."StartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> StartDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TaskDetailsFieldIndex.StartDate, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.StartDate, value); }
		}

		/// <summary> The StartTime property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."StartTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> StartTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TaskDetailsFieldIndex.StartTime, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.StartTime, value); }
		}

		/// <summary> The DueDate property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."DueDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DueDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TaskDetailsFieldIndex.DueDate, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.DueDate, value); }
		}

		/// <summary> The DueTime property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."DueTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DueTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TaskDetailsFieldIndex.DueTime, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.DueTime, value); }
		}

		/// <summary> The ModifiedBy property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)TaskDetailsFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The TaskPriorityId property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."TaskPriorityID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TaskPriorityId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TaskDetailsFieldIndex.TaskPriorityId, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.TaskPriorityId, value); }
		}

		/// <summary> The TaskStatusId property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."TaskStatusID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TaskStatusId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TaskDetailsFieldIndex.TaskStatusId, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.TaskStatusId, value); }
		}

		/// <summary> The IsActive property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)TaskDetailsFieldIndex.IsActive, true); }
			set	{ SetValue((int)TaskDetailsFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)TaskDetailsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)TaskDetailsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TaskDetailsFieldIndex.DateModified, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.DateModified, value); }
		}

		/// <summary> The AssignedToOrgRoleUserId property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."AssignedToOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AssignedToOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TaskDetailsFieldIndex.AssignedToOrgRoleUserId, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.AssignedToOrgRoleUserId, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)TaskDetailsFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)TaskDetailsFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity TaskDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskDetails"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TaskDetailsFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)TaskDetailsFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTaskDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTaskDetailsEntity))]
		public virtual EntityCollection<EventTaskDetailsEntity> EventTaskDetails
		{
			get
			{
				if(_eventTaskDetails==null)
				{
					_eventTaskDetails = new EntityCollection<EventTaskDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTaskDetailsEntityFactory)));
					_eventTaskDetails.SetContainingEntityInfo(this, "TaskDetails");
				}
				return _eventTaskDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventTaskDetails
		{
			get
			{
				if(_eventsCollectionViaEventTaskDetails==null)
				{
					_eventsCollectionViaEventTaskDetails = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventTaskDetails.IsReadOnly=true;
				}
				return _eventsCollectionViaEventTaskDetails;
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser__
		{
			get
			{
				return _organizationRoleUser__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser__(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser__ != null)
						{
							_organizationRoleUser__.UnsetRelatedEntity(this, "TaskDetails__");
						}
					}
					else
					{
						if(_organizationRoleUser__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TaskDetails__");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "TaskDetails_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TaskDetails_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser
		{
			get
			{
				return _organizationRoleUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser != null)
						{
							_organizationRoleUser.UnsetRelatedEntity(this, "TaskDetails");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TaskDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TaskPriorityTypesEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TaskPriorityTypesEntity TaskPriorityTypes
		{
			get
			{
				return _taskPriorityTypes;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTaskPriorityTypes(value);
				}
				else
				{
					if(value==null)
					{
						if(_taskPriorityTypes != null)
						{
							_taskPriorityTypes.UnsetRelatedEntity(this, "TaskDetails");
						}
					}
					else
					{
						if(_taskPriorityTypes!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TaskDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TaskStatusTypesEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TaskStatusTypesEntity TaskStatusTypes
		{
			get
			{
				return _taskStatusTypes;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTaskStatusTypes(value);
				}
				else
				{
					if(value==null)
					{
						if(_taskStatusTypes != null)
						{
							_taskStatusTypes.UnsetRelatedEntity(this, "TaskDetails");
						}
					}
					else
					{
						if(_taskStatusTypes!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TaskDetails");
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
			get { return (int)Falcon.Data.EntityType.TaskDetailsEntity; }
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
