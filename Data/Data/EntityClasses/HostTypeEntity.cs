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
	/// Entity class which represents the entity 'HostType'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class HostTypeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<HostsEntity> _hosts;
		private EntityCollection<AddressEntity> _addressCollectionViaHosts;
		private EntityCollection<HostContactsEntity> _hostContactsCollectionViaHosts_;
		private EntityCollection<HostContactsEntity> _hostContactsCollectionViaHosts;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name Hosts</summary>
			public static readonly string Hosts = "Hosts";
			/// <summary>Member name AddressCollectionViaHosts</summary>
			public static readonly string AddressCollectionViaHosts = "AddressCollectionViaHosts";
			/// <summary>Member name HostContactsCollectionViaHosts_</summary>
			public static readonly string HostContactsCollectionViaHosts_ = "HostContactsCollectionViaHosts_";
			/// <summary>Member name HostContactsCollectionViaHosts</summary>
			public static readonly string HostContactsCollectionViaHosts = "HostContactsCollectionViaHosts";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static HostTypeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public HostTypeEntity():base("HostTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public HostTypeEntity(IEntityFields2 fields):base("HostTypeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this HostTypeEntity</param>
		public HostTypeEntity(IValidator validator):base("HostTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="hostTypeId">PK value for HostType which data should be fetched into this HostType object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HostTypeEntity(System.Int64 hostTypeId):base("HostTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.HostTypeId = hostTypeId;
		}

		/// <summary> CTor</summary>
		/// <param name="hostTypeId">PK value for HostType which data should be fetched into this HostType object</param>
		/// <param name="validator">The custom validator object for this HostTypeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HostTypeEntity(System.Int64 hostTypeId, IValidator validator):base("HostTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.HostTypeId = hostTypeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected HostTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_hosts = (EntityCollection<HostsEntity>)info.GetValue("_hosts", typeof(EntityCollection<HostsEntity>));
				_addressCollectionViaHosts = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaHosts", typeof(EntityCollection<AddressEntity>));
				_hostContactsCollectionViaHosts_ = (EntityCollection<HostContactsEntity>)info.GetValue("_hostContactsCollectionViaHosts_", typeof(EntityCollection<HostContactsEntity>));
				_hostContactsCollectionViaHosts = (EntityCollection<HostContactsEntity>)info.GetValue("_hostContactsCollectionViaHosts", typeof(EntityCollection<HostContactsEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((HostTypeFieldIndex)fieldIndex)
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

				case "Hosts":
					this.Hosts.Add((HostsEntity)entity);
					break;
				case "AddressCollectionViaHosts":
					this.AddressCollectionViaHosts.IsReadOnly = false;
					this.AddressCollectionViaHosts.Add((AddressEntity)entity);
					this.AddressCollectionViaHosts.IsReadOnly = true;
					break;
				case "HostContactsCollectionViaHosts_":
					this.HostContactsCollectionViaHosts_.IsReadOnly = false;
					this.HostContactsCollectionViaHosts_.Add((HostContactsEntity)entity);
					this.HostContactsCollectionViaHosts_.IsReadOnly = true;
					break;
				case "HostContactsCollectionViaHosts":
					this.HostContactsCollectionViaHosts.IsReadOnly = false;
					this.HostContactsCollectionViaHosts.Add((HostContactsEntity)entity);
					this.HostContactsCollectionViaHosts.IsReadOnly = true;
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
			return HostTypeEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "Hosts":
					toReturn.Add(HostTypeEntity.Relations.HostsEntityUsingHostTypeId);
					break;
				case "AddressCollectionViaHosts":
					toReturn.Add(HostTypeEntity.Relations.HostsEntityUsingHostTypeId, "HostTypeEntity__", "Hosts_", JoinHint.None);
					toReturn.Add(HostsEntity.Relations.AddressEntityUsingAddressId, "Hosts_", string.Empty, JoinHint.None);
					break;
				case "HostContactsCollectionViaHosts_":
					toReturn.Add(HostTypeEntity.Relations.HostsEntityUsingHostTypeId, "HostTypeEntity__", "Hosts_", JoinHint.None);
					toReturn.Add(HostsEntity.Relations.HostContactsEntityUsingContactId2, "Hosts_", string.Empty, JoinHint.None);
					break;
				case "HostContactsCollectionViaHosts":
					toReturn.Add(HostTypeEntity.Relations.HostsEntityUsingHostTypeId, "HostTypeEntity__", "Hosts_", JoinHint.None);
					toReturn.Add(HostsEntity.Relations.HostContactsEntityUsingContactId1, "Hosts_", string.Empty, JoinHint.None);
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

				case "Hosts":
					this.Hosts.Add((HostsEntity)relatedEntity);
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

				case "Hosts":
					base.PerformRelatedEntityRemoval(this.Hosts, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.Hosts);

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
				info.AddValue("_hosts", ((_hosts!=null) && (_hosts.Count>0) && !this.MarkedForDeletion)?_hosts:null);
				info.AddValue("_addressCollectionViaHosts", ((_addressCollectionViaHosts!=null) && (_addressCollectionViaHosts.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaHosts:null);
				info.AddValue("_hostContactsCollectionViaHosts_", ((_hostContactsCollectionViaHosts_!=null) && (_hostContactsCollectionViaHosts_.Count>0) && !this.MarkedForDeletion)?_hostContactsCollectionViaHosts_:null);
				info.AddValue("_hostContactsCollectionViaHosts", ((_hostContactsCollectionViaHosts!=null) && (_hostContactsCollectionViaHosts.Count>0) && !this.MarkedForDeletion)?_hostContactsCollectionViaHosts:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(HostTypeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(HostTypeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new HostTypeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Hosts' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHosts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostsFields.HostTypeId, null, ComparisonOperator.Equal, this.HostTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaHosts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaHosts"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostTypeFields.HostTypeId, null, ComparisonOperator.Equal, this.HostTypeId, "HostTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostContacts' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostContactsCollectionViaHosts_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HostContactsCollectionViaHosts_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostTypeFields.HostTypeId, null, ComparisonOperator.Equal, this.HostTypeId, "HostTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostContacts' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostContactsCollectionViaHosts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HostContactsCollectionViaHosts"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostTypeFields.HostTypeId, null, ComparisonOperator.Equal, this.HostTypeId, "HostTypeEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.HostTypeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(HostTypeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._hosts);
			collectionsQueue.Enqueue(this._addressCollectionViaHosts);
			collectionsQueue.Enqueue(this._hostContactsCollectionViaHosts_);
			collectionsQueue.Enqueue(this._hostContactsCollectionViaHosts);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._hosts = (EntityCollection<HostsEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaHosts = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._hostContactsCollectionViaHosts_ = (EntityCollection<HostContactsEntity>) collectionsQueue.Dequeue();
			this._hostContactsCollectionViaHosts = (EntityCollection<HostContactsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._hosts != null)
			{
				return true;
			}
			if (this._addressCollectionViaHosts != null)
			{
				return true;
			}
			if (this._hostContactsCollectionViaHosts_ != null)
			{
				return true;
			}
			if (this._hostContactsCollectionViaHosts != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostContactsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostContactsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("Hosts", _hosts);
			toReturn.Add("AddressCollectionViaHosts", _addressCollectionViaHosts);
			toReturn.Add("HostContactsCollectionViaHosts_", _hostContactsCollectionViaHosts_);
			toReturn.Add("HostContactsCollectionViaHosts", _hostContactsCollectionViaHosts);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_hosts!=null)
			{
				_hosts.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaHosts!=null)
			{
				_addressCollectionViaHosts.ActiveContext = base.ActiveContext;
			}
			if(_hostContactsCollectionViaHosts_!=null)
			{
				_hostContactsCollectionViaHosts_.ActiveContext = base.ActiveContext;
			}
			if(_hostContactsCollectionViaHosts!=null)
			{
				_hostContactsCollectionViaHosts.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_hosts = null;
			_addressCollectionViaHosts = null;
			_hostContactsCollectionViaHosts_ = null;
			_hostContactsCollectionViaHosts = null;


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

			_fieldsCustomProperties.Add("HostTypeId", fieldHashtable);
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
		/// <param name="validator">The validator object for this HostTypeEntity</param>
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
		public  static HostTypeRelations Relations
		{
			get	{ return new HostTypeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Hosts' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHosts
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HostsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Hosts")[0], (int)HealthYes.Data.EntityType.HostTypeEntity, (int)HealthYes.Data.EntityType.HostsEntity, 0, null, null, null, null, "Hosts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaHosts
		{
			get
			{
				IEntityRelation intermediateRelation = HostTypeEntity.Relations.HostsEntityUsingHostTypeId;
				intermediateRelation.SetAliases(string.Empty, "Hosts_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.HostTypeEntity, (int)HealthYes.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaHosts"), null, "AddressCollectionViaHosts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostContacts' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostContactsCollectionViaHosts_
		{
			get
			{
				IEntityRelation intermediateRelation = HostTypeEntity.Relations.HostsEntityUsingHostTypeId;
				intermediateRelation.SetAliases(string.Empty, "Hosts_");
				return new PrefetchPathElement2(new EntityCollection<HostContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostContactsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.HostTypeEntity, (int)HealthYes.Data.EntityType.HostContactsEntity, 0, null, null, GetRelationsForField("HostContactsCollectionViaHosts_"), null, "HostContactsCollectionViaHosts_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostContacts' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostContactsCollectionViaHosts
		{
			get
			{
				IEntityRelation intermediateRelation = HostTypeEntity.Relations.HostsEntityUsingHostTypeId;
				intermediateRelation.SetAliases(string.Empty, "Hosts_");
				return new PrefetchPathElement2(new EntityCollection<HostContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostContactsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.HostTypeEntity, (int)HealthYes.Data.EntityType.HostContactsEntity, 0, null, null, GetRelationsForField("HostContactsCollectionViaHosts"), null, "HostContactsCollectionViaHosts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return HostTypeEntity.CustomProperties;}
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
			get { return HostTypeEntity.FieldsCustomProperties;}
		}

		/// <summary> The HostTypeId property of the Entity HostType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostType"."HostTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 HostTypeId
		{
			get { return (System.Int64)GetValue((int)HostTypeFieldIndex.HostTypeId, true); }
			set	{ SetValue((int)HostTypeFieldIndex.HostTypeId, value); }
		}

		/// <summary> The Name property of the Entity HostType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostType"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)HostTypeFieldIndex.Name, true); }
			set	{ SetValue((int)HostTypeFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity HostType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostType"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)HostTypeFieldIndex.Description, true); }
			set	{ SetValue((int)HostTypeFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity HostType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostType"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)HostTypeFieldIndex.DateCreated, true); }
			set	{ SetValue((int)HostTypeFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity HostType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostType"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)HostTypeFieldIndex.DateModified, true); }
			set	{ SetValue((int)HostTypeFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity HostType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostType"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)HostTypeFieldIndex.IsActive, true); }
			set	{ SetValue((int)HostTypeFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HostsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HostsEntity))]
		public virtual EntityCollection<HostsEntity> Hosts
		{
			get
			{
				if(_hosts==null)
				{
					_hosts = new EntityCollection<HostsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostsEntityFactory)));
					_hosts.SetContainingEntityInfo(this, "HostType");
				}
				return _hosts;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaHosts
		{
			get
			{
				if(_addressCollectionViaHosts==null)
				{
					_addressCollectionViaHosts = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaHosts.IsReadOnly=true;
				}
				return _addressCollectionViaHosts;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HostContactsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HostContactsEntity))]
		public virtual EntityCollection<HostContactsEntity> HostContactsCollectionViaHosts_
		{
			get
			{
				if(_hostContactsCollectionViaHosts_==null)
				{
					_hostContactsCollectionViaHosts_ = new EntityCollection<HostContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostContactsEntityFactory)));
					_hostContactsCollectionViaHosts_.IsReadOnly=true;
				}
				return _hostContactsCollectionViaHosts_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HostContactsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HostContactsEntity))]
		public virtual EntityCollection<HostContactsEntity> HostContactsCollectionViaHosts
		{
			get
			{
				if(_hostContactsCollectionViaHosts==null)
				{
					_hostContactsCollectionViaHosts = new EntityCollection<HostContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostContactsEntityFactory)));
					_hostContactsCollectionViaHosts.IsReadOnly=true;
				}
				return _hostContactsCollectionViaHosts;
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
			get { return (int)HealthYes.Data.EntityType.HostTypeEntity; }
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
