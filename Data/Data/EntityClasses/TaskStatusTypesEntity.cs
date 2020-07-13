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
	/// Entity class which represents the entity 'TaskStatusTypes'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TaskStatusTypesEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<TaskDetailsEntity> _taskDetails;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTaskDetails__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTaskDetails_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTaskDetails;
		private EntityCollection<TaskPriorityTypesEntity> _taskPriorityTypesCollectionViaTaskDetails;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name TaskDetails</summary>
			public static readonly string TaskDetails = "TaskDetails";
			/// <summary>Member name OrganizationRoleUserCollectionViaTaskDetails__</summary>
			public static readonly string OrganizationRoleUserCollectionViaTaskDetails__ = "OrganizationRoleUserCollectionViaTaskDetails__";
			/// <summary>Member name OrganizationRoleUserCollectionViaTaskDetails_</summary>
			public static readonly string OrganizationRoleUserCollectionViaTaskDetails_ = "OrganizationRoleUserCollectionViaTaskDetails_";
			/// <summary>Member name OrganizationRoleUserCollectionViaTaskDetails</summary>
			public static readonly string OrganizationRoleUserCollectionViaTaskDetails = "OrganizationRoleUserCollectionViaTaskDetails";
			/// <summary>Member name TaskPriorityTypesCollectionViaTaskDetails</summary>
			public static readonly string TaskPriorityTypesCollectionViaTaskDetails = "TaskPriorityTypesCollectionViaTaskDetails";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TaskStatusTypesEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TaskStatusTypesEntity():base("TaskStatusTypesEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TaskStatusTypesEntity(IEntityFields2 fields):base("TaskStatusTypesEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TaskStatusTypesEntity</param>
		public TaskStatusTypesEntity(IValidator validator):base("TaskStatusTypesEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="taskStatusId">PK value for TaskStatusTypes which data should be fetched into this TaskStatusTypes object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TaskStatusTypesEntity(System.Int64 taskStatusId):base("TaskStatusTypesEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TaskStatusId = taskStatusId;
		}

		/// <summary> CTor</summary>
		/// <param name="taskStatusId">PK value for TaskStatusTypes which data should be fetched into this TaskStatusTypes object</param>
		/// <param name="validator">The custom validator object for this TaskStatusTypesEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TaskStatusTypesEntity(System.Int64 taskStatusId, IValidator validator):base("TaskStatusTypesEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TaskStatusId = taskStatusId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TaskStatusTypesEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_taskDetails = (EntityCollection<TaskDetailsEntity>)info.GetValue("_taskDetails", typeof(EntityCollection<TaskDetailsEntity>));
				_organizationRoleUserCollectionViaTaskDetails__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTaskDetails__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaTaskDetails_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTaskDetails_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaTaskDetails = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTaskDetails", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_taskPriorityTypesCollectionViaTaskDetails = (EntityCollection<TaskPriorityTypesEntity>)info.GetValue("_taskPriorityTypesCollectionViaTaskDetails", typeof(EntityCollection<TaskPriorityTypesEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((TaskStatusTypesFieldIndex)fieldIndex)
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

				case "TaskDetails":
					this.TaskDetails.Add((TaskDetailsEntity)entity);
					break;
				case "OrganizationRoleUserCollectionViaTaskDetails__":
					this.OrganizationRoleUserCollectionViaTaskDetails__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTaskDetails__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTaskDetails__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTaskDetails_":
					this.OrganizationRoleUserCollectionViaTaskDetails_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTaskDetails_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTaskDetails_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTaskDetails":
					this.OrganizationRoleUserCollectionViaTaskDetails.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTaskDetails.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTaskDetails.IsReadOnly = true;
					break;
				case "TaskPriorityTypesCollectionViaTaskDetails":
					this.TaskPriorityTypesCollectionViaTaskDetails.IsReadOnly = false;
					this.TaskPriorityTypesCollectionViaTaskDetails.Add((TaskPriorityTypesEntity)entity);
					this.TaskPriorityTypesCollectionViaTaskDetails.IsReadOnly = true;
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
			return TaskStatusTypesEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "TaskDetails":
					toReturn.Add(TaskStatusTypesEntity.Relations.TaskDetailsEntityUsingTaskStatusId);
					break;
				case "OrganizationRoleUserCollectionViaTaskDetails__":
					toReturn.Add(TaskStatusTypesEntity.Relations.TaskDetailsEntityUsingTaskStatusId, "TaskStatusTypesEntity__", "TaskDetails_", JoinHint.None);
					toReturn.Add(TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "TaskDetails_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTaskDetails_":
					toReturn.Add(TaskStatusTypesEntity.Relations.TaskDetailsEntityUsingTaskStatusId, "TaskStatusTypesEntity__", "TaskDetails_", JoinHint.None);
					toReturn.Add(TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "TaskDetails_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTaskDetails":
					toReturn.Add(TaskStatusTypesEntity.Relations.TaskDetailsEntityUsingTaskStatusId, "TaskStatusTypesEntity__", "TaskDetails_", JoinHint.None);
					toReturn.Add(TaskDetailsEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "TaskDetails_", string.Empty, JoinHint.None);
					break;
				case "TaskPriorityTypesCollectionViaTaskDetails":
					toReturn.Add(TaskStatusTypesEntity.Relations.TaskDetailsEntityUsingTaskStatusId, "TaskStatusTypesEntity__", "TaskDetails_", JoinHint.None);
					toReturn.Add(TaskDetailsEntity.Relations.TaskPriorityTypesEntityUsingTaskPriorityId, "TaskDetails_", string.Empty, JoinHint.None);
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

				case "TaskDetails":
					this.TaskDetails.Add((TaskDetailsEntity)relatedEntity);
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

				case "TaskDetails":
					base.PerformRelatedEntityRemoval(this.TaskDetails, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.TaskDetails);

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
				info.AddValue("_taskDetails", ((_taskDetails!=null) && (_taskDetails.Count>0) && !this.MarkedForDeletion)?_taskDetails:null);
				info.AddValue("_organizationRoleUserCollectionViaTaskDetails__", ((_organizationRoleUserCollectionViaTaskDetails__!=null) && (_organizationRoleUserCollectionViaTaskDetails__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTaskDetails__:null);
				info.AddValue("_organizationRoleUserCollectionViaTaskDetails_", ((_organizationRoleUserCollectionViaTaskDetails_!=null) && (_organizationRoleUserCollectionViaTaskDetails_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTaskDetails_:null);
				info.AddValue("_organizationRoleUserCollectionViaTaskDetails", ((_organizationRoleUserCollectionViaTaskDetails!=null) && (_organizationRoleUserCollectionViaTaskDetails.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTaskDetails:null);
				info.AddValue("_taskPriorityTypesCollectionViaTaskDetails", ((_taskPriorityTypesCollectionViaTaskDetails!=null) && (_taskPriorityTypesCollectionViaTaskDetails.Count>0) && !this.MarkedForDeletion)?_taskPriorityTypesCollectionViaTaskDetails:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TaskStatusTypesFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TaskStatusTypesFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TaskStatusTypesRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TaskDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTaskDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TaskDetailsFields.TaskStatusId, null, ComparisonOperator.Equal, this.TaskStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTaskDetails__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTaskDetails__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TaskStatusTypesFields.TaskStatusId, null, ComparisonOperator.Equal, this.TaskStatusId, "TaskStatusTypesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTaskDetails_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTaskDetails_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TaskStatusTypesFields.TaskStatusId, null, ComparisonOperator.Equal, this.TaskStatusId, "TaskStatusTypesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTaskDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTaskDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TaskStatusTypesFields.TaskStatusId, null, ComparisonOperator.Equal, this.TaskStatusId, "TaskStatusTypesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TaskPriorityTypes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTaskPriorityTypesCollectionViaTaskDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TaskPriorityTypesCollectionViaTaskDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TaskStatusTypesFields.TaskStatusId, null, ComparisonOperator.Equal, this.TaskStatusId, "TaskStatusTypesEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.TaskStatusTypesEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TaskStatusTypesEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._taskDetails);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTaskDetails__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTaskDetails_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTaskDetails);
			collectionsQueue.Enqueue(this._taskPriorityTypesCollectionViaTaskDetails);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._taskDetails = (EntityCollection<TaskDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTaskDetails__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTaskDetails_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTaskDetails = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._taskPriorityTypesCollectionViaTaskDetails = (EntityCollection<TaskPriorityTypesEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._taskDetails != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTaskDetails__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTaskDetails_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTaskDetails != null)
			{
				return true;
			}
			if (this._taskPriorityTypesCollectionViaTaskDetails != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TaskDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TaskDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TaskPriorityTypesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TaskPriorityTypesEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("TaskDetails", _taskDetails);
			toReturn.Add("OrganizationRoleUserCollectionViaTaskDetails__", _organizationRoleUserCollectionViaTaskDetails__);
			toReturn.Add("OrganizationRoleUserCollectionViaTaskDetails_", _organizationRoleUserCollectionViaTaskDetails_);
			toReturn.Add("OrganizationRoleUserCollectionViaTaskDetails", _organizationRoleUserCollectionViaTaskDetails);
			toReturn.Add("TaskPriorityTypesCollectionViaTaskDetails", _taskPriorityTypesCollectionViaTaskDetails);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_taskDetails!=null)
			{
				_taskDetails.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTaskDetails__!=null)
			{
				_organizationRoleUserCollectionViaTaskDetails__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTaskDetails_!=null)
			{
				_organizationRoleUserCollectionViaTaskDetails_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTaskDetails!=null)
			{
				_organizationRoleUserCollectionViaTaskDetails.ActiveContext = base.ActiveContext;
			}
			if(_taskPriorityTypesCollectionViaTaskDetails!=null)
			{
				_taskPriorityTypesCollectionViaTaskDetails.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_taskDetails = null;
			_organizationRoleUserCollectionViaTaskDetails__ = null;
			_organizationRoleUserCollectionViaTaskDetails_ = null;
			_organizationRoleUserCollectionViaTaskDetails = null;
			_taskPriorityTypesCollectionViaTaskDetails = null;


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

			_fieldsCustomProperties.Add("TaskStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TaskStatusTypesEntity</param>
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
		public  static TaskStatusTypesRelations Relations
		{
			get	{ return new TaskStatusTypesRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TaskDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTaskDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TaskDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TaskDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("TaskDetails")[0], (int)Falcon.Data.EntityType.TaskStatusTypesEntity, (int)Falcon.Data.EntityType.TaskDetailsEntity, 0, null, null, null, null, "TaskDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTaskDetails__
		{
			get
			{
				IEntityRelation intermediateRelation = TaskStatusTypesEntity.Relations.TaskDetailsEntityUsingTaskStatusId;
				intermediateRelation.SetAliases(string.Empty, "TaskDetails_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TaskStatusTypesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTaskDetails__"), null, "OrganizationRoleUserCollectionViaTaskDetails__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTaskDetails_
		{
			get
			{
				IEntityRelation intermediateRelation = TaskStatusTypesEntity.Relations.TaskDetailsEntityUsingTaskStatusId;
				intermediateRelation.SetAliases(string.Empty, "TaskDetails_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TaskStatusTypesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTaskDetails_"), null, "OrganizationRoleUserCollectionViaTaskDetails_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTaskDetails
		{
			get
			{
				IEntityRelation intermediateRelation = TaskStatusTypesEntity.Relations.TaskDetailsEntityUsingTaskStatusId;
				intermediateRelation.SetAliases(string.Empty, "TaskDetails_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TaskStatusTypesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTaskDetails"), null, "OrganizationRoleUserCollectionViaTaskDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TaskPriorityTypes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTaskPriorityTypesCollectionViaTaskDetails
		{
			get
			{
				IEntityRelation intermediateRelation = TaskStatusTypesEntity.Relations.TaskDetailsEntityUsingTaskStatusId;
				intermediateRelation.SetAliases(string.Empty, "TaskDetails_");
				return new PrefetchPathElement2(new EntityCollection<TaskPriorityTypesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TaskPriorityTypesEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TaskStatusTypesEntity, (int)Falcon.Data.EntityType.TaskPriorityTypesEntity, 0, null, null, GetRelationsForField("TaskPriorityTypesCollectionViaTaskDetails"), null, "TaskPriorityTypesCollectionViaTaskDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TaskStatusTypesEntity.CustomProperties;}
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
			get { return TaskStatusTypesEntity.FieldsCustomProperties;}
		}

		/// <summary> The TaskStatusId property of the Entity TaskStatusTypes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskStatusTypes"."TaskStatusID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TaskStatusId
		{
			get { return (System.Int64)GetValue((int)TaskStatusTypesFieldIndex.TaskStatusId, true); }
			set	{ SetValue((int)TaskStatusTypesFieldIndex.TaskStatusId, value); }
		}

		/// <summary> The Name property of the Entity TaskStatusTypes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskStatusTypes"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)TaskStatusTypesFieldIndex.Name, true); }
			set	{ SetValue((int)TaskStatusTypesFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity TaskStatusTypes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskStatusTypes"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)TaskStatusTypesFieldIndex.Description, true); }
			set	{ SetValue((int)TaskStatusTypesFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity TaskStatusTypes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskStatusTypes"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)TaskStatusTypesFieldIndex.DateCreated, true); }
			set	{ SetValue((int)TaskStatusTypesFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity TaskStatusTypes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskStatusTypes"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)TaskStatusTypesFieldIndex.DateModified, true); }
			set	{ SetValue((int)TaskStatusTypesFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity TaskStatusTypes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTaskStatusTypes"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)TaskStatusTypesFieldIndex.IsActive, true); }
			set	{ SetValue((int)TaskStatusTypesFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TaskDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TaskDetailsEntity))]
		public virtual EntityCollection<TaskDetailsEntity> TaskDetails
		{
			get
			{
				if(_taskDetails==null)
				{
					_taskDetails = new EntityCollection<TaskDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TaskDetailsEntityFactory)));
					_taskDetails.SetContainingEntityInfo(this, "TaskStatusTypes");
				}
				return _taskDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTaskDetails__
		{
			get
			{
				if(_organizationRoleUserCollectionViaTaskDetails__==null)
				{
					_organizationRoleUserCollectionViaTaskDetails__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTaskDetails__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTaskDetails__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTaskDetails_
		{
			get
			{
				if(_organizationRoleUserCollectionViaTaskDetails_==null)
				{
					_organizationRoleUserCollectionViaTaskDetails_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTaskDetails_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTaskDetails_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTaskDetails
		{
			get
			{
				if(_organizationRoleUserCollectionViaTaskDetails==null)
				{
					_organizationRoleUserCollectionViaTaskDetails = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTaskDetails.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTaskDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TaskPriorityTypesEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TaskPriorityTypesEntity))]
		public virtual EntityCollection<TaskPriorityTypesEntity> TaskPriorityTypesCollectionViaTaskDetails
		{
			get
			{
				if(_taskPriorityTypesCollectionViaTaskDetails==null)
				{
					_taskPriorityTypesCollectionViaTaskDetails = new EntityCollection<TaskPriorityTypesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TaskPriorityTypesEntityFactory)));
					_taskPriorityTypesCollectionViaTaskDetails.IsReadOnly=true;
				}
				return _taskPriorityTypesCollectionViaTaskDetails;
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
			get { return (int)Falcon.Data.EntityType.TaskStatusTypesEntity; }
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
