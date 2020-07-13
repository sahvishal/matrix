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
	/// Entity class which represents the entity 'Country'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CountryEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AddressEntity> _address;
		private EntityCollection<StateEntity> _state;
		private EntityCollection<CityEntity> _cityCollectionViaAddress;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAddress;
		private EntityCollection<StateEntity> _stateCollectionViaAddress;
		private EntityCollection<ZipEntity> _zipCollectionViaAddress;


		
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
			/// <summary>Member name State</summary>
			public static readonly string State = "State";
			/// <summary>Member name CityCollectionViaAddress</summary>
			public static readonly string CityCollectionViaAddress = "CityCollectionViaAddress";
			/// <summary>Member name OrganizationRoleUserCollectionViaAddress</summary>
			public static readonly string OrganizationRoleUserCollectionViaAddress = "OrganizationRoleUserCollectionViaAddress";
			/// <summary>Member name StateCollectionViaAddress</summary>
			public static readonly string StateCollectionViaAddress = "StateCollectionViaAddress";
			/// <summary>Member name ZipCollectionViaAddress</summary>
			public static readonly string ZipCollectionViaAddress = "ZipCollectionViaAddress";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CountryEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CountryEntity():base("CountryEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CountryEntity(IEntityFields2 fields):base("CountryEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CountryEntity</param>
		public CountryEntity(IValidator validator):base("CountryEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="countryId">PK value for Country which data should be fetched into this Country object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CountryEntity(System.Int64 countryId):base("CountryEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CountryId = countryId;
		}

		/// <summary> CTor</summary>
		/// <param name="countryId">PK value for Country which data should be fetched into this Country object</param>
		/// <param name="validator">The custom validator object for this CountryEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CountryEntity(System.Int64 countryId, IValidator validator):base("CountryEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CountryId = countryId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CountryEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_address = (EntityCollection<AddressEntity>)info.GetValue("_address", typeof(EntityCollection<AddressEntity>));
				_state = (EntityCollection<StateEntity>)info.GetValue("_state", typeof(EntityCollection<StateEntity>));
				_cityCollectionViaAddress = (EntityCollection<CityEntity>)info.GetValue("_cityCollectionViaAddress", typeof(EntityCollection<CityEntity>));
				_organizationRoleUserCollectionViaAddress = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAddress", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_stateCollectionViaAddress = (EntityCollection<StateEntity>)info.GetValue("_stateCollectionViaAddress", typeof(EntityCollection<StateEntity>));
				_zipCollectionViaAddress = (EntityCollection<ZipEntity>)info.GetValue("_zipCollectionViaAddress", typeof(EntityCollection<ZipEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CountryFieldIndex)fieldIndex)
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

				case "Address":
					this.Address.Add((AddressEntity)entity);
					break;
				case "State":
					this.State.Add((StateEntity)entity);
					break;
				case "CityCollectionViaAddress":
					this.CityCollectionViaAddress.IsReadOnly = false;
					this.CityCollectionViaAddress.Add((CityEntity)entity);
					this.CityCollectionViaAddress.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAddress":
					this.OrganizationRoleUserCollectionViaAddress.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAddress.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAddress.IsReadOnly = true;
					break;
				case "StateCollectionViaAddress":
					this.StateCollectionViaAddress.IsReadOnly = false;
					this.StateCollectionViaAddress.Add((StateEntity)entity);
					this.StateCollectionViaAddress.IsReadOnly = true;
					break;
				case "ZipCollectionViaAddress":
					this.ZipCollectionViaAddress.IsReadOnly = false;
					this.ZipCollectionViaAddress.Add((ZipEntity)entity);
					this.ZipCollectionViaAddress.IsReadOnly = true;
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
			return CountryEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(CountryEntity.Relations.AddressEntityUsingCountryId);
					break;
				case "State":
					toReturn.Add(CountryEntity.Relations.StateEntityUsingCountryId);
					break;
				case "CityCollectionViaAddress":
					toReturn.Add(CountryEntity.Relations.AddressEntityUsingCountryId, "CountryEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.CityEntityUsingCityId, "Address_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAddress":
					toReturn.Add(CountryEntity.Relations.AddressEntityUsingCountryId, "CountryEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.OrganizationRoleUserEntityUsingVerificationOrgRoleUserId, "Address_", string.Empty, JoinHint.None);
					break;
				case "StateCollectionViaAddress":
					toReturn.Add(CountryEntity.Relations.AddressEntityUsingCountryId, "CountryEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.StateEntityUsingStateId, "Address_", string.Empty, JoinHint.None);
					break;
				case "ZipCollectionViaAddress":
					toReturn.Add(CountryEntity.Relations.AddressEntityUsingCountryId, "CountryEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.ZipEntityUsingZipId, "Address_", string.Empty, JoinHint.None);
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
					this.Address.Add((AddressEntity)relatedEntity);
					break;
				case "State":
					this.State.Add((StateEntity)relatedEntity);
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
					base.PerformRelatedEntityRemoval(this.Address, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "State":
					base.PerformRelatedEntityRemoval(this.State, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.Address);
			toReturn.Add(this.State);

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
				info.AddValue("_address", ((_address!=null) && (_address.Count>0) && !this.MarkedForDeletion)?_address:null);
				info.AddValue("_state", ((_state!=null) && (_state.Count>0) && !this.MarkedForDeletion)?_state:null);
				info.AddValue("_cityCollectionViaAddress", ((_cityCollectionViaAddress!=null) && (_cityCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_cityCollectionViaAddress:null);
				info.AddValue("_organizationRoleUserCollectionViaAddress", ((_organizationRoleUserCollectionViaAddress!=null) && (_organizationRoleUserCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAddress:null);
				info.AddValue("_stateCollectionViaAddress", ((_stateCollectionViaAddress!=null) && (_stateCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_stateCollectionViaAddress:null);
				info.AddValue("_zipCollectionViaAddress", ((_zipCollectionViaAddress!=null) && (_zipCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_zipCollectionViaAddress:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CountryFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CountryFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CountryRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.CountryId, null, ComparisonOperator.Equal, this.CountryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'State' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoState()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.CountryId, null, ComparisonOperator.Equal, this.CountryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'City' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCityCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CityCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryFields.CountryId, null, ComparisonOperator.Equal, this.CountryId, "CountryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryFields.CountryId, null, ComparisonOperator.Equal, this.CountryId, "CountryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'State' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStateCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StateCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryFields.CountryId, null, ComparisonOperator.Equal, this.CountryId, "CountryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Zip' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoZipCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ZipCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryFields.CountryId, null, ComparisonOperator.Equal, this.CountryId, "CountryEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CountryEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._address);
			collectionsQueue.Enqueue(this._state);
			collectionsQueue.Enqueue(this._cityCollectionViaAddress);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAddress);
			collectionsQueue.Enqueue(this._stateCollectionViaAddress);
			collectionsQueue.Enqueue(this._zipCollectionViaAddress);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._address = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._state = (EntityCollection<StateEntity>) collectionsQueue.Dequeue();
			this._cityCollectionViaAddress = (EntityCollection<CityEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAddress = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._stateCollectionViaAddress = (EntityCollection<StateEntity>) collectionsQueue.Dequeue();
			this._zipCollectionViaAddress = (EntityCollection<ZipEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._address != null)
			{
				return true;
			}
			if (this._state != null)
			{
				return true;
			}
			if (this._cityCollectionViaAddress != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAddress != null)
			{
				return true;
			}
			if (this._stateCollectionViaAddress != null)
			{
				return true;
			}
			if (this._zipCollectionViaAddress != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory))) : null);
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
			toReturn.Add("State", _state);
			toReturn.Add("CityCollectionViaAddress", _cityCollectionViaAddress);
			toReturn.Add("OrganizationRoleUserCollectionViaAddress", _organizationRoleUserCollectionViaAddress);
			toReturn.Add("StateCollectionViaAddress", _stateCollectionViaAddress);
			toReturn.Add("ZipCollectionViaAddress", _zipCollectionViaAddress);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_state!=null)
			{
				_state.ActiveContext = base.ActiveContext;
			}
			if(_cityCollectionViaAddress!=null)
			{
				_cityCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAddress!=null)
			{
				_organizationRoleUserCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_stateCollectionViaAddress!=null)
			{
				_stateCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_zipCollectionViaAddress!=null)
			{
				_zipCollectionViaAddress.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_address = null;
			_state = null;
			_cityCollectionViaAddress = null;
			_organizationRoleUserCollectionViaAddress = null;
			_stateCollectionViaAddress = null;
			_zipCollectionViaAddress = null;


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

			_fieldsCustomProperties.Add("CountryId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CountryCode", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CountryEntity</param>
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
		public  static CountryRelations Relations
		{
			get	{ return new CountryRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddress
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),
					(IEntityRelation)GetRelationsForField("Address")[0], (int)Falcon.Data.EntityType.CountryEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'State' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathState
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))),
					(IEntityRelation)GetRelationsForField("State")[0], (int)Falcon.Data.EntityType.CountryEntity, (int)Falcon.Data.EntityType.StateEntity, 0, null, null, null, null, "State", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'City' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCityCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = CountryEntity.Relations.AddressEntityUsingCountryId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CountryEntity, (int)Falcon.Data.EntityType.CityEntity, 0, null, null, GetRelationsForField("CityCollectionViaAddress"), null, "CityCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = CountryEntity.Relations.AddressEntityUsingCountryId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CountryEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAddress"), null, "OrganizationRoleUserCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'State' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStateCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = CountryEntity.Relations.AddressEntityUsingCountryId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CountryEntity, (int)Falcon.Data.EntityType.StateEntity, 0, null, null, GetRelationsForField("StateCollectionViaAddress"), null, "StateCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Zip' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathZipCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = CountryEntity.Relations.AddressEntityUsingCountryId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CountryEntity, (int)Falcon.Data.EntityType.ZipEntity, 0, null, null, GetRelationsForField("ZipCollectionViaAddress"), null, "ZipCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CountryEntity.CustomProperties;}
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
			get { return CountryEntity.FieldsCustomProperties;}
		}

		/// <summary> The CountryId property of the Entity Country<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCountry"."CountryID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CountryId
		{
			get { return (System.Int64)GetValue((int)CountryFieldIndex.CountryId, true); }
			set	{ SetValue((int)CountryFieldIndex.CountryId, value); }
		}

		/// <summary> The Name property of the Entity Country<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCountry"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CountryFieldIndex.Name, true); }
			set	{ SetValue((int)CountryFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity Country<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCountry"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CountryFieldIndex.Description, true); }
			set	{ SetValue((int)CountryFieldIndex.Description, value); }
		}

		/// <summary> The IsActive property of the Entity Country<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCountry"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CountryFieldIndex.IsActive, true); }
			set	{ SetValue((int)CountryFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity Country<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCountry"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CountryFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CountryFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Country<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCountry"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)CountryFieldIndex.DateModified, true); }
			set	{ SetValue((int)CountryFieldIndex.DateModified, value); }
		}

		/// <summary> The CountryCode property of the Entity Country<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCountry"."CountryCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CountryCode
		{
			get { return (System.String)GetValue((int)CountryFieldIndex.CountryCode, true); }
			set	{ SetValue((int)CountryFieldIndex.CountryCode, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> Address
		{
			get
			{
				if(_address==null)
				{
					_address = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_address.SetContainingEntityInfo(this, "Country");
				}
				return _address;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StateEntity))]
		public virtual EntityCollection<StateEntity> State
		{
			get
			{
				if(_state==null)
				{
					_state = new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory)));
					_state.SetContainingEntityInfo(this, "Country");
				}
				return _state;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CityEntity))]
		public virtual EntityCollection<CityEntity> CityCollectionViaAddress
		{
			get
			{
				if(_cityCollectionViaAddress==null)
				{
					_cityCollectionViaAddress = new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory)));
					_cityCollectionViaAddress.IsReadOnly=true;
				}
				return _cityCollectionViaAddress;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAddress
		{
			get
			{
				if(_organizationRoleUserCollectionViaAddress==null)
				{
					_organizationRoleUserCollectionViaAddress = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAddress.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAddress;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StateEntity))]
		public virtual EntityCollection<StateEntity> StateCollectionViaAddress
		{
			get
			{
				if(_stateCollectionViaAddress==null)
				{
					_stateCollectionViaAddress = new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory)));
					_stateCollectionViaAddress.IsReadOnly=true;
				}
				return _stateCollectionViaAddress;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ZipEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ZipEntity))]
		public virtual EntityCollection<ZipEntity> ZipCollectionViaAddress
		{
			get
			{
				if(_zipCollectionViaAddress==null)
				{
					_zipCollectionViaAddress = new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory)));
					_zipCollectionViaAddress.IsReadOnly=true;
				}
				return _zipCollectionViaAddress;
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
			get { return (int)Falcon.Data.EntityType.CountryEntity; }
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
