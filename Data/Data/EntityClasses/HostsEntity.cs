///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:30 AM
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
	/// Entity class which represents the entity 'Hosts'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class HostsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<HostNotesEntity> _hostNotes;
		private EntityCollection<UserEntity> _userCollectionViaHostNotes;
		private AddressEntity _address;
		private HostContactsEntity _hostContacts_;
		private HostContactsEntity _hostContacts;
		private HostTypeEntity _hostType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Address</summary>
			public static readonly string Address = "Address";
			/// <summary>Member name HostContacts_</summary>
			public static readonly string HostContacts_ = "HostContacts_";
			/// <summary>Member name HostContacts</summary>
			public static readonly string HostContacts = "HostContacts";
			/// <summary>Member name HostType</summary>
			public static readonly string HostType = "HostType";
			/// <summary>Member name HostNotes</summary>
			public static readonly string HostNotes = "HostNotes";
			/// <summary>Member name UserCollectionViaHostNotes</summary>
			public static readonly string UserCollectionViaHostNotes = "UserCollectionViaHostNotes";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static HostsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public HostsEntity():base("HostsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public HostsEntity(IEntityFields2 fields):base("HostsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this HostsEntity</param>
		public HostsEntity(IValidator validator):base("HostsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="hostId">PK value for Hosts which data should be fetched into this Hosts object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HostsEntity(System.Int64 hostId):base("HostsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.HostId = hostId;
		}

		/// <summary> CTor</summary>
		/// <param name="hostId">PK value for Hosts which data should be fetched into this Hosts object</param>
		/// <param name="validator">The custom validator object for this HostsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HostsEntity(System.Int64 hostId, IValidator validator):base("HostsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.HostId = hostId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected HostsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_hostNotes = (EntityCollection<HostNotesEntity>)info.GetValue("_hostNotes", typeof(EntityCollection<HostNotesEntity>));
				_userCollectionViaHostNotes = (EntityCollection<UserEntity>)info.GetValue("_userCollectionViaHostNotes", typeof(EntityCollection<UserEntity>));
				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hostContacts_ = (HostContactsEntity)info.GetValue("_hostContacts_", typeof(HostContactsEntity));
				if(_hostContacts_!=null)
				{
					_hostContacts_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hostContacts = (HostContactsEntity)info.GetValue("_hostContacts", typeof(HostContactsEntity));
				if(_hostContacts!=null)
				{
					_hostContacts.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hostType = (HostTypeEntity)info.GetValue("_hostType", typeof(HostTypeEntity));
				if(_hostType!=null)
				{
					_hostType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((HostsFieldIndex)fieldIndex)
			{
				case HostsFieldIndex.AddressId:
					DesetupSyncAddress(true, false);
					break;
				case HostsFieldIndex.HostTypeId:
					DesetupSyncHostType(true, false);
					break;
				case HostsFieldIndex.ContactId1:
					DesetupSyncHostContacts(true, false);
					break;
				case HostsFieldIndex.ContactId2:
					DesetupSyncHostContacts_(true, false);
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
				case "Address":
					this.Address = (AddressEntity)entity;
					break;
				case "HostContacts_":
					this.HostContacts_ = (HostContactsEntity)entity;
					break;
				case "HostContacts":
					this.HostContacts = (HostContactsEntity)entity;
					break;
				case "HostType":
					this.HostType = (HostTypeEntity)entity;
					break;
				case "HostNotes":
					this.HostNotes.Add((HostNotesEntity)entity);
					break;
				case "UserCollectionViaHostNotes":
					this.UserCollectionViaHostNotes.IsReadOnly = false;
					this.UserCollectionViaHostNotes.Add((UserEntity)entity);
					this.UserCollectionViaHostNotes.IsReadOnly = true;
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
			return HostsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Address":
					toReturn.Add(HostsEntity.Relations.AddressEntityUsingAddressId);
					break;
				case "HostContacts_":
					toReturn.Add(HostsEntity.Relations.HostContactsEntityUsingContactId2);
					break;
				case "HostContacts":
					toReturn.Add(HostsEntity.Relations.HostContactsEntityUsingContactId1);
					break;
				case "HostType":
					toReturn.Add(HostsEntity.Relations.HostTypeEntityUsingHostTypeId);
					break;
				case "HostNotes":
					toReturn.Add(HostsEntity.Relations.HostNotesEntityUsingHostId);
					break;
				case "UserCollectionViaHostNotes":
					toReturn.Add(HostsEntity.Relations.HostNotesEntityUsingHostId, "HostsEntity__", "HostNotes_", JoinHint.None);
					toReturn.Add(HostNotesEntity.Relations.UserEntityUsingUserId, "HostNotes_", string.Empty, JoinHint.None);
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
				case "Address":
					SetupSyncAddress(relatedEntity);
					break;
				case "HostContacts_":
					SetupSyncHostContacts_(relatedEntity);
					break;
				case "HostContacts":
					SetupSyncHostContacts(relatedEntity);
					break;
				case "HostType":
					SetupSyncHostType(relatedEntity);
					break;
				case "HostNotes":
					this.HostNotes.Add((HostNotesEntity)relatedEntity);
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
				case "Address":
					DesetupSyncAddress(false, true);
					break;
				case "HostContacts_":
					DesetupSyncHostContacts_(false, true);
					break;
				case "HostContacts":
					DesetupSyncHostContacts(false, true);
					break;
				case "HostType":
					DesetupSyncHostType(false, true);
					break;
				case "HostNotes":
					base.PerformRelatedEntityRemoval(this.HostNotes, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_address!=null)
			{
				toReturn.Add(_address);
			}
			if(_hostContacts_!=null)
			{
				toReturn.Add(_hostContacts_);
			}
			if(_hostContacts!=null)
			{
				toReturn.Add(_hostContacts);
			}
			if(_hostType!=null)
			{
				toReturn.Add(_hostType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.HostNotes);

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
				info.AddValue("_hostNotes", ((_hostNotes!=null) && (_hostNotes.Count>0) && !this.MarkedForDeletion)?_hostNotes:null);
				info.AddValue("_userCollectionViaHostNotes", ((_userCollectionViaHostNotes!=null) && (_userCollectionViaHostNotes.Count>0) && !this.MarkedForDeletion)?_userCollectionViaHostNotes:null);
				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_hostContacts_", (!this.MarkedForDeletion?_hostContacts_:null));
				info.AddValue("_hostContacts", (!this.MarkedForDeletion?_hostContacts:null));
				info.AddValue("_hostType", (!this.MarkedForDeletion?_hostType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(HostsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(HostsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new HostsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostNotesFields.HostId, null, ComparisonOperator.Equal, this.HostId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'User' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserCollectionViaHostNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UserCollectionViaHostNotes"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostsFields.HostId, null, ComparisonOperator.Equal, this.HostId, "HostsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HostContacts' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostContacts_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostContactsFields.ContactId, null, ComparisonOperator.Equal, this.ContactId2));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HostContacts' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostContacts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostContactsFields.ContactId, null, ComparisonOperator.Equal, this.ContactId1));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HostType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostTypeFields.HostTypeId, null, ComparisonOperator.Equal, this.HostTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.HostsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(HostsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._hostNotes);
			collectionsQueue.Enqueue(this._userCollectionViaHostNotes);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._hostNotes = (EntityCollection<HostNotesEntity>) collectionsQueue.Dequeue();
			this._userCollectionViaHostNotes = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._hostNotes != null)
			{
				return true;
			}
			if (this._userCollectionViaHostNotes != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Address", _address);
			toReturn.Add("HostContacts_", _hostContacts_);
			toReturn.Add("HostContacts", _hostContacts);
			toReturn.Add("HostType", _hostType);
			toReturn.Add("HostNotes", _hostNotes);
			toReturn.Add("UserCollectionViaHostNotes", _userCollectionViaHostNotes);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_hostNotes!=null)
			{
				_hostNotes.ActiveContext = base.ActiveContext;
			}
			if(_userCollectionViaHostNotes!=null)
			{
				_userCollectionViaHostNotes.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_hostContacts_!=null)
			{
				_hostContacts_.ActiveContext = base.ActiveContext;
			}
			if(_hostContacts!=null)
			{
				_hostContacts.ActiveContext = base.ActiveContext;
			}
			if(_hostType!=null)
			{
				_hostType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_hostNotes = null;
			_userCollectionViaHostNotes = null;
			_address = null;
			_hostContacts_ = null;
			_hostContacts = null;
			_hostType = null;

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

			_fieldsCustomProperties.Add("HostId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WebAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Map", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HostSize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HostTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MethodObtainedId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContactId1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrimaryContactId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContactId2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOffice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHome", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email2", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", HostsEntity.Relations.AddressEntityUsingAddressId, true, signalRelatedEntity, "Hosts", resetFKFields, new int[] { (int)HostsFieldIndex.AddressId } );		
			_address = null;
		}

		/// <summary> setups the sync logic for member _address</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAddress(IEntity2 relatedEntity)
		{
			if(_address!=relatedEntity)
			{
				DesetupSyncAddress(true, true);
				_address = (AddressEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", HostsEntity.Relations.AddressEntityUsingAddressId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAddressPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _hostContacts_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHostContacts_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hostContacts_, new PropertyChangedEventHandler( OnHostContacts_PropertyChanged ), "HostContacts_", HostsEntity.Relations.HostContactsEntityUsingContactId2, true, signalRelatedEntity, "Hosts_", resetFKFields, new int[] { (int)HostsFieldIndex.ContactId2 } );		
			_hostContacts_ = null;
		}

		/// <summary> setups the sync logic for member _hostContacts_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHostContacts_(IEntity2 relatedEntity)
		{
			if(_hostContacts_!=relatedEntity)
			{
				DesetupSyncHostContacts_(true, true);
				_hostContacts_ = (HostContactsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hostContacts_, new PropertyChangedEventHandler( OnHostContacts_PropertyChanged ), "HostContacts_", HostsEntity.Relations.HostContactsEntityUsingContactId2, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHostContacts_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _hostContacts</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHostContacts(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hostContacts, new PropertyChangedEventHandler( OnHostContactsPropertyChanged ), "HostContacts", HostsEntity.Relations.HostContactsEntityUsingContactId1, true, signalRelatedEntity, "Hosts", resetFKFields, new int[] { (int)HostsFieldIndex.ContactId1 } );		
			_hostContacts = null;
		}

		/// <summary> setups the sync logic for member _hostContacts</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHostContacts(IEntity2 relatedEntity)
		{
			if(_hostContacts!=relatedEntity)
			{
				DesetupSyncHostContacts(true, true);
				_hostContacts = (HostContactsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hostContacts, new PropertyChangedEventHandler( OnHostContactsPropertyChanged ), "HostContacts", HostsEntity.Relations.HostContactsEntityUsingContactId1, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHostContactsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _hostType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHostType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hostType, new PropertyChangedEventHandler( OnHostTypePropertyChanged ), "HostType", HostsEntity.Relations.HostTypeEntityUsingHostTypeId, true, signalRelatedEntity, "Hosts", resetFKFields, new int[] { (int)HostsFieldIndex.HostTypeId } );		
			_hostType = null;
		}

		/// <summary> setups the sync logic for member _hostType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHostType(IEntity2 relatedEntity)
		{
			if(_hostType!=relatedEntity)
			{
				DesetupSyncHostType(true, true);
				_hostType = (HostTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hostType, new PropertyChangedEventHandler( OnHostTypePropertyChanged ), "HostType", HostsEntity.Relations.HostTypeEntityUsingHostTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHostTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this HostsEntity</param>
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
		public  static HostsRelations Relations
		{
			get	{ return new HostsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostNotes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HostNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostNotes")[0], (int)HealthYes.Data.EntityType.HostsEntity, (int)HealthYes.Data.EntityType.HostNotesEntity, 0, null, null, null, null, "HostNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserCollectionViaHostNotes
		{
			get
			{
				IEntityRelation intermediateRelation = HostsEntity.Relations.HostNotesEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostNotes_");
				return new PrefetchPathElement2(new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.HostsEntity, (int)HealthYes.Data.EntityType.UserEntity, 0, null, null, GetRelationsForField("UserCollectionViaHostNotes"), null, "UserCollectionViaHostNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddress
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),
					(IEntityRelation)GetRelationsForField("Address")[0], (int)HealthYes.Data.EntityType.HostsEntity, (int)HealthYes.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostContacts' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostContacts_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HostContactsEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostContacts_")[0], (int)HealthYes.Data.EntityType.HostsEntity, (int)HealthYes.Data.EntityType.HostContactsEntity, 0, null, null, null, null, "HostContacts_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostContacts' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostContacts
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HostContactsEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostContacts")[0], (int)HealthYes.Data.EntityType.HostsEntity, (int)HealthYes.Data.EntityType.HostContactsEntity, 0, null, null, null, null, "HostContacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HostTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostType")[0], (int)HealthYes.Data.EntityType.HostsEntity, (int)HealthYes.Data.EntityType.HostTypeEntity, 0, null, null, null, null, "HostType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return HostsEntity.CustomProperties;}
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
			get { return HostsEntity.FieldsCustomProperties;}
		}

		/// <summary> The HostId property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."HostID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 HostId
		{
			get { return (System.Int64)GetValue((int)HostsFieldIndex.HostId, true); }
			set	{ SetValue((int)HostsFieldIndex.HostId, value); }
		}

		/// <summary> The Name property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)HostsFieldIndex.Name, true); }
			set	{ SetValue((int)HostsFieldIndex.Name, value); }
		}

		/// <summary> The AddressId property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."AddressID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AddressId
		{
			get { return (System.Int64)GetValue((int)HostsFieldIndex.AddressId, true); }
			set	{ SetValue((int)HostsFieldIndex.AddressId, value); }
		}

		/// <summary> The WebAddress property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."WebAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String WebAddress
		{
			get { return (System.String)GetValue((int)HostsFieldIndex.WebAddress, true); }
			set	{ SetValue((int)HostsFieldIndex.WebAddress, value); }
		}

		/// <summary> The Map property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."Map"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Map
		{
			get { return (System.String)GetValue((int)HostsFieldIndex.Map, true); }
			set	{ SetValue((int)HostsFieldIndex.Map, value); }
		}

		/// <summary> The HostSize property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."HostSize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal HostSize
		{
			get { return (System.Decimal)GetValue((int)HostsFieldIndex.HostSize, true); }
			set	{ SetValue((int)HostsFieldIndex.HostSize, value); }
		}

		/// <summary> The HostTypeId property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."HostTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HostTypeId
		{
			get { return (System.Int64)GetValue((int)HostsFieldIndex.HostTypeId, true); }
			set	{ SetValue((int)HostsFieldIndex.HostTypeId, value); }
		}

		/// <summary> The MethodObtainedId property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."MethodObtainedID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MethodObtainedId
		{
			get { return (System.Int64)GetValue((int)HostsFieldIndex.MethodObtainedId, true); }
			set	{ SetValue((int)HostsFieldIndex.MethodObtainedId, value); }
		}

		/// <summary> The ContactId1 property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."ContactID1"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ContactId1
		{
			get { return (Nullable<System.Int64>)GetValue((int)HostsFieldIndex.ContactId1, false); }
			set	{ SetValue((int)HostsFieldIndex.ContactId1, value); }
		}

		/// <summary> The PrimaryContactId property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."PrimaryContactID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PrimaryContactId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HostsFieldIndex.PrimaryContactId, false); }
			set	{ SetValue((int)HostsFieldIndex.PrimaryContactId, value); }
		}

		/// <summary> The ContactId2 property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."ContactID2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ContactId2
		{
			get { return (Nullable<System.Int64>)GetValue((int)HostsFieldIndex.ContactId2, false); }
			set	{ SetValue((int)HostsFieldIndex.ContactId2, value); }
		}

		/// <summary> The Status property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Status
		{
			get { return (System.String)GetValue((int)HostsFieldIndex.Status, true); }
			set	{ SetValue((int)HostsFieldIndex.Status, value); }
		}

		/// <summary> The ProspectId property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."ProspectID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProspectId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HostsFieldIndex.ProspectId, false); }
			set	{ SetValue((int)HostsFieldIndex.ProspectId, value); }
		}

		/// <summary> The IsActive property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)HostsFieldIndex.IsActive, true); }
			set	{ SetValue((int)HostsFieldIndex.IsActive, value); }
		}

		/// <summary> The PhoneOffice property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."PhoneOffice"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOffice
		{
			get { return (System.String)GetValue((int)HostsFieldIndex.PhoneOffice, true); }
			set	{ SetValue((int)HostsFieldIndex.PhoneOffice, value); }
		}

		/// <summary> The PhoneCell property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."PhoneCell"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)HostsFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)HostsFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneHome property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."PhoneHome"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneHome
		{
			get { return (System.String)GetValue((int)HostsFieldIndex.PhoneHome, true); }
			set	{ SetValue((int)HostsFieldIndex.PhoneHome, value); }
		}

		/// <summary> The Email1 property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."EMail1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email1
		{
			get { return (System.String)GetValue((int)HostsFieldIndex.Email1, true); }
			set	{ SetValue((int)HostsFieldIndex.Email1, value); }
		}

		/// <summary> The Email2 property of the Entity Hosts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHosts"."EMail2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email2
		{
			get { return (System.String)GetValue((int)HostsFieldIndex.Email2, true); }
			set	{ SetValue((int)HostsFieldIndex.Email2, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HostNotesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HostNotesEntity))]
		public virtual EntityCollection<HostNotesEntity> HostNotes
		{
			get
			{
				if(_hostNotes==null)
				{
					_hostNotes = new EntityCollection<HostNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostNotesEntityFactory)));
					_hostNotes.SetContainingEntityInfo(this, "Hosts");
				}
				return _hostNotes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UserCollectionViaHostNotes
		{
			get
			{
				if(_userCollectionViaHostNotes==null)
				{
					_userCollectionViaHostNotes = new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory)));
					_userCollectionViaHostNotes.IsReadOnly=true;
				}
				return _userCollectionViaHostNotes;
			}
		}

		/// <summary> Gets / sets related entity of type 'AddressEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AddressEntity Address
		{
			get
			{
				return _address;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAddress(value);
				}
				else
				{
					if(value==null)
					{
						if(_address != null)
						{
							_address.UnsetRelatedEntity(this, "Hosts");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Hosts");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HostContactsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HostContactsEntity HostContacts_
		{
			get
			{
				return _hostContacts_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHostContacts_(value);
				}
				else
				{
					if(value==null)
					{
						if(_hostContacts_ != null)
						{
							_hostContacts_.UnsetRelatedEntity(this, "Hosts_");
						}
					}
					else
					{
						if(_hostContacts_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Hosts_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HostContactsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HostContactsEntity HostContacts
		{
			get
			{
				return _hostContacts;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHostContacts(value);
				}
				else
				{
					if(value==null)
					{
						if(_hostContacts != null)
						{
							_hostContacts.UnsetRelatedEntity(this, "Hosts");
						}
					}
					else
					{
						if(_hostContacts!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Hosts");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HostTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HostTypeEntity HostType
		{
			get
			{
				return _hostType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHostType(value);
				}
				else
				{
					if(value==null)
					{
						if(_hostType != null)
						{
							_hostType.UnsetRelatedEntity(this, "Hosts");
						}
					}
					else
					{
						if(_hostType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Hosts");
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
		
		/// <summary>Returns the HealthYes.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)HealthYes.Data.EntityType.HostsEntity; }
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
