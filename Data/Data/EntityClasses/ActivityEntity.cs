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
	/// Entity class which represents the entity 'Activity'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ActivityEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<OrgRoleUserActivityEntity> _orgRoleUserActivity;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaOrgRoleUserActivity;

		private NoteEntity _note;
		private TaskEntity _task;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name OrgRoleUserActivity</summary>
			public static readonly string OrgRoleUserActivity = "OrgRoleUserActivity";
			/// <summary>Member name OrganizationRoleUserCollectionViaOrgRoleUserActivity</summary>
			public static readonly string OrganizationRoleUserCollectionViaOrgRoleUserActivity = "OrganizationRoleUserCollectionViaOrgRoleUserActivity";
			/// <summary>Member name Note</summary>
			public static readonly string Note = "Note";
			/// <summary>Member name Task</summary>
			public static readonly string Task = "Task";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ActivityEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ActivityEntity():base("ActivityEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ActivityEntity(IEntityFields2 fields):base("ActivityEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ActivityEntity</param>
		public ActivityEntity(IValidator validator):base("ActivityEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="activityId">PK value for Activity which data should be fetched into this Activity object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ActivityEntity(System.Int64 activityId):base("ActivityEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ActivityId = activityId;
		}

		/// <summary> CTor</summary>
		/// <param name="activityId">PK value for Activity which data should be fetched into this Activity object</param>
		/// <param name="validator">The custom validator object for this ActivityEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ActivityEntity(System.Int64 activityId, IValidator validator):base("ActivityEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ActivityId = activityId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ActivityEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_orgRoleUserActivity = (EntityCollection<OrgRoleUserActivityEntity>)info.GetValue("_orgRoleUserActivity", typeof(EntityCollection<OrgRoleUserActivityEntity>));
				_organizationRoleUserCollectionViaOrgRoleUserActivity = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaOrgRoleUserActivity", typeof(EntityCollection<OrganizationRoleUserEntity>));

				_note = (NoteEntity)info.GetValue("_note", typeof(NoteEntity));
				if(_note!=null)
				{
					_note.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_task = (TaskEntity)info.GetValue("_task", typeof(TaskEntity));
				if(_task!=null)
				{
					_task.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ActivityFieldIndex)fieldIndex)
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

				case "OrgRoleUserActivity":
					this.OrgRoleUserActivity.Add((OrgRoleUserActivityEntity)entity);
					break;
				case "OrganizationRoleUserCollectionViaOrgRoleUserActivity":
					this.OrganizationRoleUserCollectionViaOrgRoleUserActivity.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaOrgRoleUserActivity.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaOrgRoleUserActivity.IsReadOnly = true;
					break;
				case "Note":
					this.Note = (NoteEntity)entity;
					break;
				case "Task":
					this.Task = (TaskEntity)entity;
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
			return ActivityEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "OrgRoleUserActivity":
					toReturn.Add(ActivityEntity.Relations.OrgRoleUserActivityEntityUsingActivityId);
					break;
				case "OrganizationRoleUserCollectionViaOrgRoleUserActivity":
					toReturn.Add(ActivityEntity.Relations.OrgRoleUserActivityEntityUsingActivityId, "ActivityEntity__", "OrgRoleUserActivity_", JoinHint.None);
					toReturn.Add(OrgRoleUserActivityEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, "OrgRoleUserActivity_", string.Empty, JoinHint.None);
					break;
				case "Note":
					toReturn.Add(ActivityEntity.Relations.NoteEntityUsingNoteId);
					break;
				case "Task":
					toReturn.Add(ActivityEntity.Relations.TaskEntityUsingTaskId);
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

				case "OrgRoleUserActivity":
					this.OrgRoleUserActivity.Add((OrgRoleUserActivityEntity)relatedEntity);
					break;
				case "Note":
					SetupSyncNote(relatedEntity);
					break;
				case "Task":
					SetupSyncTask(relatedEntity);
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

				case "OrgRoleUserActivity":
					base.PerformRelatedEntityRemoval(this.OrgRoleUserActivity, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Note":
					DesetupSyncNote(false, true);
					break;
				case "Task":
					DesetupSyncTask(false, true);
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
			if(_note!=null)
			{
				toReturn.Add(_note);
			}

			if(_task!=null)
			{
				toReturn.Add(_task);
			}

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
			toReturn.Add(this.OrgRoleUserActivity);

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
				info.AddValue("_orgRoleUserActivity", ((_orgRoleUserActivity!=null) && (_orgRoleUserActivity.Count>0) && !this.MarkedForDeletion)?_orgRoleUserActivity:null);
				info.AddValue("_organizationRoleUserCollectionViaOrgRoleUserActivity", ((_organizationRoleUserCollectionViaOrgRoleUserActivity!=null) && (_organizationRoleUserCollectionViaOrgRoleUserActivity.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaOrgRoleUserActivity:null);

				info.AddValue("_note", (!this.MarkedForDeletion?_note:null));
				info.AddValue("_task", (!this.MarkedForDeletion?_task:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ActivityFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ActivityFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ActivityRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrgRoleUserActivity' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrgRoleUserActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrgRoleUserActivityFields.ActivityId, null, ComparisonOperator.Equal, this.ActivityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaOrgRoleUserActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaOrgRoleUserActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActivityFields.ActivityId, null, ComparisonOperator.Equal, this.ActivityId, "ActivityEntity__"));
			return bucket;
		}


		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Note' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNote()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoteFields.NoteId, null, ComparisonOperator.Equal, this.ActivityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Task' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTask()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TaskFields.TaskId, null, ComparisonOperator.Equal, this.ActivityId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ActivityEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ActivityEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._orgRoleUserActivity);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaOrgRoleUserActivity);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._orgRoleUserActivity = (EntityCollection<OrgRoleUserActivityEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaOrgRoleUserActivity = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._orgRoleUserActivity != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaOrgRoleUserActivity != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrgRoleUserActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrgRoleUserActivityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("OrgRoleUserActivity", _orgRoleUserActivity);
			toReturn.Add("OrganizationRoleUserCollectionViaOrgRoleUserActivity", _organizationRoleUserCollectionViaOrgRoleUserActivity);
			toReturn.Add("Note", _note);
			toReturn.Add("Task", _task);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_orgRoleUserActivity!=null)
			{
				_orgRoleUserActivity.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaOrgRoleUserActivity!=null)
			{
				_organizationRoleUserCollectionViaOrgRoleUserActivity.ActiveContext = base.ActiveContext;
			}

			if(_note!=null)
			{
				_note.ActiveContext = base.ActiveContext;
			}
			if(_task!=null)
			{
				_task.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_orgRoleUserActivity = null;
			_organizationRoleUserCollectionViaOrgRoleUserActivity = null;

			_note = null;
			_task = null;
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

			_fieldsCustomProperties.Add("ActivityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Type", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _note</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNote(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _note, new PropertyChangedEventHandler( OnNotePropertyChanged ), "Note", ActivityEntity.Relations.NoteEntityUsingNoteId, false, signalRelatedEntity, "Activity", false, new int[] { (int)ActivityFieldIndex.ActivityId } );
			_note = null;
		}
		
		/// <summary> setups the sync logic for member _note</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNote(IEntity2 relatedEntity)
		{
			if(_note!=relatedEntity)
			{
				DesetupSyncNote(true, true);
				_note = (NoteEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _note, new PropertyChangedEventHandler( OnNotePropertyChanged ), "Note", ActivityEntity.Relations.NoteEntityUsingNoteId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _task</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTask(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _task, new PropertyChangedEventHandler( OnTaskPropertyChanged ), "Task", ActivityEntity.Relations.TaskEntityUsingTaskId, false, signalRelatedEntity, "Activity", false, new int[] { (int)ActivityFieldIndex.ActivityId } );
			_task = null;
		}
		
		/// <summary> setups the sync logic for member _task</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTask(IEntity2 relatedEntity)
		{
			if(_task!=relatedEntity)
			{
				DesetupSyncTask(true, true);
				_task = (TaskEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _task, new PropertyChangedEventHandler( OnTaskPropertyChanged ), "Task", ActivityEntity.Relations.TaskEntityUsingTaskId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTaskPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ActivityEntity</param>
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
		public  static ActivityRelations Relations
		{
			get	{ return new ActivityRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrgRoleUserActivity' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrgRoleUserActivity
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrgRoleUserActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrgRoleUserActivityEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrgRoleUserActivity")[0], (int)Falcon.Data.EntityType.ActivityEntity, (int)Falcon.Data.EntityType.OrgRoleUserActivityEntity, 0, null, null, null, null, "OrgRoleUserActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaOrgRoleUserActivity
		{
			get
			{
				IEntityRelation intermediateRelation = ActivityEntity.Relations.OrgRoleUserActivityEntityUsingActivityId;
				intermediateRelation.SetAliases(string.Empty, "OrgRoleUserActivity_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ActivityEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaOrgRoleUserActivity"), null, "OrganizationRoleUserCollectionViaOrgRoleUserActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}


		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Note' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNote
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(NoteEntityFactory))),
					(IEntityRelation)GetRelationsForField("Note")[0], (int)Falcon.Data.EntityType.ActivityEntity, (int)Falcon.Data.EntityType.NoteEntity, 0, null, null, null, null, "Note", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Task' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTask
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TaskEntityFactory))),
					(IEntityRelation)GetRelationsForField("Task")[0], (int)Falcon.Data.EntityType.ActivityEntity, (int)Falcon.Data.EntityType.TaskEntity, 0, null, null, null, null, "Task", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ActivityEntity.CustomProperties;}
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
			get { return ActivityEntity.FieldsCustomProperties;}
		}

		/// <summary> The ActivityId property of the Entity Activity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblActivity"."ActivityId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ActivityId
		{
			get { return (System.Int64)GetValue((int)ActivityFieldIndex.ActivityId, true); }
			set	{ SetValue((int)ActivityFieldIndex.ActivityId, value); }
		}

		/// <summary> The Type property of the Entity Activity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblActivity"."Type"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Type
		{
			get { return (System.Int32)GetValue((int)ActivityFieldIndex.Type, true); }
			set	{ SetValue((int)ActivityFieldIndex.Type, value); }
		}

		/// <summary> The IsActive property of the Entity Activity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblActivity"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ActivityFieldIndex.IsActive, true); }
			set	{ SetValue((int)ActivityFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity Activity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblActivity"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ActivityFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ActivityFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Activity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblActivity"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ActivityFieldIndex.DateModified, false); }
			set	{ SetValue((int)ActivityFieldIndex.DateModified, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity Activity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblActivity"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)ActivityFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)ActivityFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity Activity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblActivity"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ActivityFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)ActivityFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrgRoleUserActivityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrgRoleUserActivityEntity))]
		public virtual EntityCollection<OrgRoleUserActivityEntity> OrgRoleUserActivity
		{
			get
			{
				if(_orgRoleUserActivity==null)
				{
					_orgRoleUserActivity = new EntityCollection<OrgRoleUserActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrgRoleUserActivityEntityFactory)));
					_orgRoleUserActivity.SetContainingEntityInfo(this, "Activity");
				}
				return _orgRoleUserActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaOrgRoleUserActivity
		{
			get
			{
				if(_organizationRoleUserCollectionViaOrgRoleUserActivity==null)
				{
					_organizationRoleUserCollectionViaOrgRoleUserActivity = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaOrgRoleUserActivity.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaOrgRoleUserActivity;
			}
		}


		/// <summary> Gets / sets related entity of type 'NoteEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual NoteEntity Note
		{
			get
			{
				return _note;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNote(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Activity");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_note !=null);
						DesetupSyncNote(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("Note");
						}
					}
					else
					{
						if(_note!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Activity");
							SetupSyncNote(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TaskEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TaskEntity Task
		{
			get
			{
				return _task;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTask(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Activity");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_task !=null);
						DesetupSyncTask(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("Task");
						}
					}
					else
					{
						if(_task!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Activity");
							SetupSyncTask(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.ActivityEntity; }
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
