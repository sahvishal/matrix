///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, April 27, 2011 3:49:51 PM
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
	/// Entity class which represents the entity 'EventRole'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventRoleEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventPodTeamEntity> _eventPodTeam;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventPodTeam;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaEventPodTeam;
		private RoleEntity _role;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";
			/// <summary>Member name EventPodTeam</summary>
			public static readonly string EventPodTeam = "EventPodTeam";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventPodTeam</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventPodTeam = "OrganizationRoleUserCollectionViaEventPodTeam";
			/// <summary>Member name PodDetailsCollectionViaEventPodTeam</summary>
			public static readonly string PodDetailsCollectionViaEventPodTeam = "PodDetailsCollectionViaEventPodTeam";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventRoleEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventRoleEntity():base("EventRoleEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventRoleEntity(IEntityFields2 fields):base("EventRoleEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventRoleEntity</param>
		public EventRoleEntity(IValidator validator):base("EventRoleEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eventRoleId">PK value for EventRole which data should be fetched into this EventRole object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventRoleEntity(System.Int64 eventRoleId):base("EventRoleEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EventRoleId = eventRoleId;
		}

		/// <summary> CTor</summary>
		/// <param name="eventRoleId">PK value for EventRole which data should be fetched into this EventRole object</param>
		/// <param name="validator">The custom validator object for this EventRoleEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventRoleEntity(System.Int64 eventRoleId, IValidator validator):base("EventRoleEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EventRoleId = eventRoleId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventRoleEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventPodTeam = (EntityCollection<EventPodTeamEntity>)info.GetValue("_eventPodTeam", typeof(EntityCollection<EventPodTeamEntity>));
				_organizationRoleUserCollectionViaEventPodTeam = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventPodTeam", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_podDetailsCollectionViaEventPodTeam = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaEventPodTeam", typeof(EntityCollection<PodDetailsEntity>));
				_role = (RoleEntity)info.GetValue("_role", typeof(RoleEntity));
				if(_role!=null)
				{
					_role.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EventRoleFieldIndex)fieldIndex)
			{
				case EventRoleFieldIndex.RoleId:
					DesetupSyncRole(true, false);
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
				case "Role":
					this.Role = (RoleEntity)entity;
					break;
				case "EventPodTeam":
					this.EventPodTeam.Add((EventPodTeamEntity)entity);
					break;
				case "OrganizationRoleUserCollectionViaEventPodTeam":
					this.OrganizationRoleUserCollectionViaEventPodTeam.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventPodTeam.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventPodTeam.IsReadOnly = true;
					break;
				case "PodDetailsCollectionViaEventPodTeam":
					this.PodDetailsCollectionViaEventPodTeam.IsReadOnly = false;
					this.PodDetailsCollectionViaEventPodTeam.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaEventPodTeam.IsReadOnly = true;
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
			return EventRoleEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Role":
					toReturn.Add(EventRoleEntity.Relations.RoleEntityUsingRoleId);
					break;
				case "EventPodTeam":
					toReturn.Add(EventRoleEntity.Relations.EventPodTeamEntityUsingEventRoleId);
					break;
				case "OrganizationRoleUserCollectionViaEventPodTeam":
					toReturn.Add(EventRoleEntity.Relations.EventPodTeamEntityUsingEventRoleId, "EventRoleEntity__", "EventPodTeam_", JoinHint.None);
					toReturn.Add(EventPodTeamEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, "EventPodTeam_", string.Empty, JoinHint.None);
					break;
				case "PodDetailsCollectionViaEventPodTeam":
					toReturn.Add(EventRoleEntity.Relations.EventPodTeamEntityUsingEventRoleId, "EventRoleEntity__", "EventPodTeam_", JoinHint.None);
					toReturn.Add(EventPodTeamEntity.Relations.PodDetailsEntityUsingPodId, "EventPodTeam_", string.Empty, JoinHint.None);
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
				case "Role":
					SetupSyncRole(relatedEntity);
					break;
				case "EventPodTeam":
					this.EventPodTeam.Add((EventPodTeamEntity)relatedEntity);
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
				case "Role":
					DesetupSyncRole(false, true);
					break;
				case "EventPodTeam":
					base.PerformRelatedEntityRemoval(this.EventPodTeam, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_role!=null)
			{
				toReturn.Add(_role);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventPodTeam);

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
				info.AddValue("_eventPodTeam", ((_eventPodTeam!=null) && (_eventPodTeam.Count>0) && !this.MarkedForDeletion)?_eventPodTeam:null);
				info.AddValue("_organizationRoleUserCollectionViaEventPodTeam", ((_organizationRoleUserCollectionViaEventPodTeam!=null) && (_organizationRoleUserCollectionViaEventPodTeam.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventPodTeam:null);
				info.AddValue("_podDetailsCollectionViaEventPodTeam", ((_podDetailsCollectionViaEventPodTeam!=null) && (_podDetailsCollectionViaEventPodTeam.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaEventPodTeam:null);
				info.AddValue("_role", (!this.MarkedForDeletion?_role:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(EventRoleFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventRoleFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventRoleRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPodTeam' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPodTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPodTeamFields.EventRoleId, null, ComparisonOperator.Equal, this.EventRoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventPodTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventPodTeam"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventRoleFields.EventRoleId, null, ComparisonOperator.Equal, this.EventRoleId, "EventRoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaEventPodTeam()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaEventPodTeam"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventRoleFields.EventRoleId, null, ComparisonOperator.Equal, this.EventRoleId, "EventRoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Role' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventRoleEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EventRoleEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventPodTeam);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventPodTeam);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaEventPodTeam);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventPodTeam = (EntityCollection<EventPodTeamEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventPodTeam = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaEventPodTeam = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventPodTeam != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventPodTeam != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaEventPodTeam != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPodTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodTeamEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Role", _role);
			toReturn.Add("EventPodTeam", _eventPodTeam);
			toReturn.Add("OrganizationRoleUserCollectionViaEventPodTeam", _organizationRoleUserCollectionViaEventPodTeam);
			toReturn.Add("PodDetailsCollectionViaEventPodTeam", _podDetailsCollectionViaEventPodTeam);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventPodTeam!=null)
			{
				_eventPodTeam.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventPodTeam!=null)
			{
				_organizationRoleUserCollectionViaEventPodTeam.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaEventPodTeam!=null)
			{
				_podDetailsCollectionViaEventPodTeam.ActiveContext = base.ActiveContext;
			}
			if(_role!=null)
			{
				_role.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventPodTeam = null;
			_organizationRoleUserCollectionViaEventPodTeam = null;
			_podDetailsCollectionViaEventPodTeam = null;
			_role = null;

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

			_fieldsCustomProperties.Add("EventRoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoleName", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _role</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRole(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", EventRoleEntity.Relations.RoleEntityUsingRoleId, true, signalRelatedEntity, "EventRole", resetFKFields, new int[] { (int)EventRoleFieldIndex.RoleId } );		
			_role = null;
		}

		/// <summary> setups the sync logic for member _role</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRole(IEntity2 relatedEntity)
		{
			if(_role!=relatedEntity)
			{
				DesetupSyncRole(true, true);
				_role = (RoleEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", EventRoleEntity.Relations.RoleEntityUsingRoleId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRolePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EventRoleEntity</param>
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
		public  static EventRoleRelations Relations
		{
			get	{ return new EventRoleRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPodTeam' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPodTeam
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPodTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodTeamEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPodTeam")[0], (int)Falcon.Data.EntityType.EventRoleEntity, (int)Falcon.Data.EntityType.EventPodTeamEntity, 0, null, null, null, null, "EventPodTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventPodTeam
		{
			get
			{
				IEntityRelation intermediateRelation = EventRoleEntity.Relations.EventPodTeamEntityUsingEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "EventPodTeam_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventRoleEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventPodTeam"), null, "OrganizationRoleUserCollectionViaEventPodTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaEventPodTeam
		{
			get
			{
				IEntityRelation intermediateRelation = EventRoleEntity.Relations.EventPodTeamEntityUsingEventRoleId;
				intermediateRelation.SetAliases(string.Empty, "EventPodTeam_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventRoleEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaEventPodTeam"), null, "PodDetailsCollectionViaEventPodTeam", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRole
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))),
					(IEntityRelation)GetRelationsForField("Role")[0], (int)Falcon.Data.EntityType.EventRoleEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, null, null, "Role", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventRoleEntity.CustomProperties;}
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
			get { return EventRoleEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventRoleId property of the Entity EventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventRole"."EventRoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 EventRoleId
		{
			get { return (System.Int64)GetValue((int)EventRoleFieldIndex.EventRoleId, true); }
			set	{ SetValue((int)EventRoleFieldIndex.EventRoleId, value); }
		}

		/// <summary> The RoleId property of the Entity EventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventRole"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 RoleId
		{
			get { return (System.Int64)GetValue((int)EventRoleFieldIndex.RoleId, true); }
			set	{ SetValue((int)EventRoleFieldIndex.RoleId, value); }
		}

		/// <summary> The RoleName property of the Entity EventRole<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventRole"."RoleName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String RoleName
		{
			get { return (System.String)GetValue((int)EventRoleFieldIndex.RoleName, true); }
			set	{ SetValue((int)EventRoleFieldIndex.RoleName, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPodTeamEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPodTeamEntity))]
		public virtual EntityCollection<EventPodTeamEntity> EventPodTeam
		{
			get
			{
				if(_eventPodTeam==null)
				{
					_eventPodTeam = new EntityCollection<EventPodTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodTeamEntityFactory)));
					_eventPodTeam.SetContainingEntityInfo(this, "EventRole");
				}
				return _eventPodTeam;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventPodTeam
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventPodTeam==null)
				{
					_organizationRoleUserCollectionViaEventPodTeam = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventPodTeam.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventPodTeam;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaEventPodTeam
		{
			get
			{
				if(_podDetailsCollectionViaEventPodTeam==null)
				{
					_podDetailsCollectionViaEventPodTeam = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaEventPodTeam.IsReadOnly=true;
				}
				return _podDetailsCollectionViaEventPodTeam;
			}
		}

		/// <summary> Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual RoleEntity Role
		{
			get
			{
				return _role;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncRole(value);
				}
				else
				{
					if(value==null)
					{
						if(_role != null)
						{
							_role.UnsetRelatedEntity(this, "EventRole");
						}
					}
					else
					{
						if(_role!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventRole");
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
			get { return (int)Falcon.Data.EntityType.EventRoleEntity; }
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
