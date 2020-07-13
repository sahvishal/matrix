///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:43
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
	/// Entity class which represents the entity 'Scripts'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ScriptsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallQueueEntity> _callQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueue_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueue;
		private ScriptTypeEntity _scriptType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ScriptType</summary>
			public static readonly string ScriptType = "ScriptType";
			/// <summary>Member name CallQueue</summary>
			public static readonly string CallQueue = "CallQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueue_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueue_ = "OrganizationRoleUserCollectionViaCallQueue_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueue</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueue = "OrganizationRoleUserCollectionViaCallQueue";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ScriptsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ScriptsEntity():base("ScriptsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ScriptsEntity(IEntityFields2 fields):base("ScriptsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ScriptsEntity</param>
		public ScriptsEntity(IValidator validator):base("ScriptsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="scriptId">PK value for Scripts which data should be fetched into this Scripts object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ScriptsEntity(System.Int64 scriptId):base("ScriptsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ScriptId = scriptId;
		}

		/// <summary> CTor</summary>
		/// <param name="scriptId">PK value for Scripts which data should be fetched into this Scripts object</param>
		/// <param name="validator">The custom validator object for this ScriptsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ScriptsEntity(System.Int64 scriptId, IValidator validator):base("ScriptsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ScriptId = scriptId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ScriptsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callQueue = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueue", typeof(EntityCollection<CallQueueEntity>));
				_organizationRoleUserCollectionViaCallQueue_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueue_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_scriptType = (ScriptTypeEntity)info.GetValue("_scriptType", typeof(ScriptTypeEntity));
				if(_scriptType!=null)
				{
					_scriptType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ScriptsFieldIndex)fieldIndex)
			{
				case ScriptsFieldIndex.ScriptTypeId:
					DesetupSyncScriptType(true, false);
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
				case "ScriptType":
					this.ScriptType = (ScriptTypeEntity)entity;
					break;
				case "CallQueue":
					this.CallQueue.Add((CallQueueEntity)entity);
					break;
				case "OrganizationRoleUserCollectionViaCallQueue_":
					this.OrganizationRoleUserCollectionViaCallQueue_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueue_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueue_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueue":
					this.OrganizationRoleUserCollectionViaCallQueue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueue.IsReadOnly = true;
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
			return ScriptsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ScriptType":
					toReturn.Add(ScriptsEntity.Relations.ScriptTypeEntityUsingScriptTypeId);
					break;
				case "CallQueue":
					toReturn.Add(ScriptsEntity.Relations.CallQueueEntityUsingScriptId);
					break;
				case "OrganizationRoleUserCollectionViaCallQueue_":
					toReturn.Add(ScriptsEntity.Relations.CallQueueEntityUsingScriptId, "ScriptsEntity__", "CallQueue_", JoinHint.None);
					toReturn.Add(CallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "CallQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueue":
					toReturn.Add(ScriptsEntity.Relations.CallQueueEntityUsingScriptId, "ScriptsEntity__", "CallQueue_", JoinHint.None);
					toReturn.Add(CallQueueEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CallQueue_", string.Empty, JoinHint.None);
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
				case "ScriptType":
					SetupSyncScriptType(relatedEntity);
					break;
				case "CallQueue":
					this.CallQueue.Add((CallQueueEntity)relatedEntity);
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
				case "ScriptType":
					DesetupSyncScriptType(false, true);
					break;
				case "CallQueue":
					base.PerformRelatedEntityRemoval(this.CallQueue, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_scriptType!=null)
			{
				toReturn.Add(_scriptType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CallQueue);

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
				info.AddValue("_callQueue", ((_callQueue!=null) && (_callQueue.Count>0) && !this.MarkedForDeletion)?_callQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueue_", ((_organizationRoleUserCollectionViaCallQueue_!=null) && (_organizationRoleUserCollectionViaCallQueue_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueue_:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueue", ((_organizationRoleUserCollectionViaCallQueue!=null) && (_organizationRoleUserCollectionViaCallQueue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueue:null);
				info.AddValue("_scriptType", (!this.MarkedForDeletion?_scriptType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ScriptsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ScriptsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ScriptsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.ScriptId, null, ComparisonOperator.Equal, this.ScriptId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueue_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueue_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScriptsFields.ScriptId, null, ComparisonOperator.Equal, this.ScriptId, "ScriptsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScriptsFields.ScriptId, null, ComparisonOperator.Equal, this.ScriptId, "ScriptsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ScriptType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScriptType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScriptTypeFields.ScriptTypeId, null, ComparisonOperator.Equal, this.ScriptTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ScriptsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ScriptsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueue_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueue);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callQueue = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueue_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueue_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueue != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
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
			toReturn.Add("ScriptType", _scriptType);
			toReturn.Add("CallQueue", _callQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueue_", _organizationRoleUserCollectionViaCallQueue_);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueue", _organizationRoleUserCollectionViaCallQueue);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callQueue!=null)
			{
				_callQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueue_!=null)
			{
				_organizationRoleUserCollectionViaCallQueue_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueue!=null)
			{
				_organizationRoleUserCollectionViaCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_scriptType!=null)
			{
				_scriptType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callQueue = null;
			_organizationRoleUserCollectionViaCallQueue_ = null;
			_organizationRoleUserCollectionViaCallQueue = null;
			_scriptType = null;

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

			_fieldsCustomProperties.Add("ScriptId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScriptText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefault", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScriptTypeId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _scriptType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncScriptType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _scriptType, new PropertyChangedEventHandler( OnScriptTypePropertyChanged ), "ScriptType", ScriptsEntity.Relations.ScriptTypeEntityUsingScriptTypeId, true, signalRelatedEntity, "Scripts", resetFKFields, new int[] { (int)ScriptsFieldIndex.ScriptTypeId } );		
			_scriptType = null;
		}

		/// <summary> setups the sync logic for member _scriptType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncScriptType(IEntity2 relatedEntity)
		{
			if(_scriptType!=relatedEntity)
			{
				DesetupSyncScriptType(true, true);
				_scriptType = (ScriptTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _scriptType, new PropertyChangedEventHandler( OnScriptTypePropertyChanged ), "ScriptType", ScriptsEntity.Relations.ScriptTypeEntityUsingScriptTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnScriptTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ScriptsEntity</param>
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
		public  static ScriptsRelations Relations
		{
			get	{ return new ScriptsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueue")[0], (int)Falcon.Data.EntityType.ScriptsEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, null, null, "CallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueue_
		{
			get
			{
				IEntityRelation intermediateRelation = ScriptsEntity.Relations.CallQueueEntityUsingScriptId;
				intermediateRelation.SetAliases(string.Empty, "CallQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ScriptsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueue_"), null, "OrganizationRoleUserCollectionViaCallQueue_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = ScriptsEntity.Relations.CallQueueEntityUsingScriptId;
				intermediateRelation.SetAliases(string.Empty, "CallQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ScriptsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueue"), null, "OrganizationRoleUserCollectionViaCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScriptType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScriptType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ScriptTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("ScriptType")[0], (int)Falcon.Data.EntityType.ScriptsEntity, (int)Falcon.Data.EntityType.ScriptTypeEntity, 0, null, null, null, null, "ScriptType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ScriptsEntity.CustomProperties;}
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
			get { return ScriptsEntity.FieldsCustomProperties;}
		}

		/// <summary> The ScriptId property of the Entity Scripts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScripts"."ScriptID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ScriptId
		{
			get { return (System.Int64)GetValue((int)ScriptsFieldIndex.ScriptId, true); }
			set	{ SetValue((int)ScriptsFieldIndex.ScriptId, value); }
		}

		/// <summary> The Name property of the Entity Scripts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScripts"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ScriptsFieldIndex.Name, true); }
			set	{ SetValue((int)ScriptsFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity Scripts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScripts"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)ScriptsFieldIndex.Description, true); }
			set	{ SetValue((int)ScriptsFieldIndex.Description, value); }
		}

		/// <summary> The ScriptText property of the Entity Scripts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScripts"."ScriptText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 8000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ScriptText
		{
			get { return (System.String)GetValue((int)ScriptsFieldIndex.ScriptText, true); }
			set	{ SetValue((int)ScriptsFieldIndex.ScriptText, value); }
		}

		/// <summary> The DateCreated property of the Entity Scripts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScripts"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ScriptsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ScriptsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Scripts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScripts"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ScriptsFieldIndex.DateModified, true); }
			set	{ SetValue((int)ScriptsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity Scripts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScripts"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ScriptsFieldIndex.IsActive, true); }
			set	{ SetValue((int)ScriptsFieldIndex.IsActive, value); }
		}

		/// <summary> The IsDefault property of the Entity Scripts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScripts"."IsDefault"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefault
		{
			get { return (System.Boolean)GetValue((int)ScriptsFieldIndex.IsDefault, true); }
			set	{ SetValue((int)ScriptsFieldIndex.IsDefault, value); }
		}

		/// <summary> The ScriptTypeId property of the Entity Scripts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScripts"."ScriptTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ScriptTypeId
		{
			get { return (System.Int64)GetValue((int)ScriptsFieldIndex.ScriptTypeId, true); }
			set	{ SetValue((int)ScriptsFieldIndex.ScriptTypeId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueue
		{
			get
			{
				if(_callQueue==null)
				{
					_callQueue = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueue.SetContainingEntityInfo(this, "Scripts");
				}
				return _callQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueue_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueue_==null)
				{
					_organizationRoleUserCollectionViaCallQueue_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueue_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueue_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueue
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueue==null)
				{
					_organizationRoleUserCollectionViaCallQueue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueue;
			}
		}

		/// <summary> Gets / sets related entity of type 'ScriptTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ScriptTypeEntity ScriptType
		{
			get
			{
				return _scriptType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncScriptType(value);
				}
				else
				{
					if(value==null)
					{
						if(_scriptType != null)
						{
							_scriptType.UnsetRelatedEntity(this, "Scripts");
						}
					}
					else
					{
						if(_scriptType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Scripts");
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
			get { return (int)Falcon.Data.EntityType.ScriptsEntity; }
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
