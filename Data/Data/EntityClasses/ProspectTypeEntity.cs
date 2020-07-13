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
	/// Entity class which represents the entity 'ProspectType'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ProspectTypeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ProspectsEntity> _prospects;
		private EntityCollection<AddressEntity> _addressCollectionViaProspects;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaProspects;
		private EntityCollection<ProspectListDetailsEntity> _prospectListDetailsCollectionViaProspects;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name Prospects</summary>
			public static readonly string Prospects = "Prospects";
			/// <summary>Member name AddressCollectionViaProspects</summary>
			public static readonly string AddressCollectionViaProspects = "AddressCollectionViaProspects";
			/// <summary>Member name OrganizationRoleUserCollectionViaProspects</summary>
			public static readonly string OrganizationRoleUserCollectionViaProspects = "OrganizationRoleUserCollectionViaProspects";
			/// <summary>Member name ProspectListDetailsCollectionViaProspects</summary>
			public static readonly string ProspectListDetailsCollectionViaProspects = "ProspectListDetailsCollectionViaProspects";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ProspectTypeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ProspectTypeEntity():base("ProspectTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ProspectTypeEntity(IEntityFields2 fields):base("ProspectTypeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ProspectTypeEntity</param>
		public ProspectTypeEntity(IValidator validator):base("ProspectTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="prospectTypeId">PK value for ProspectType which data should be fetched into this ProspectType object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectTypeEntity(System.Int64 prospectTypeId):base("ProspectTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ProspectTypeId = prospectTypeId;
		}

		/// <summary> CTor</summary>
		/// <param name="prospectTypeId">PK value for ProspectType which data should be fetched into this ProspectType object</param>
		/// <param name="validator">The custom validator object for this ProspectTypeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectTypeEntity(System.Int64 prospectTypeId, IValidator validator):base("ProspectTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ProspectTypeId = prospectTypeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ProspectTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_prospects = (EntityCollection<ProspectsEntity>)info.GetValue("_prospects", typeof(EntityCollection<ProspectsEntity>));
				_addressCollectionViaProspects = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaProspects", typeof(EntityCollection<AddressEntity>));
				_organizationRoleUserCollectionViaProspects = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaProspects", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_prospectListDetailsCollectionViaProspects = (EntityCollection<ProspectListDetailsEntity>)info.GetValue("_prospectListDetailsCollectionViaProspects", typeof(EntityCollection<ProspectListDetailsEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ProspectTypeFieldIndex)fieldIndex)
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

				case "Prospects":
					this.Prospects.Add((ProspectsEntity)entity);
					break;
				case "AddressCollectionViaProspects":
					this.AddressCollectionViaProspects.IsReadOnly = false;
					this.AddressCollectionViaProspects.Add((AddressEntity)entity);
					this.AddressCollectionViaProspects.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaProspects":
					this.OrganizationRoleUserCollectionViaProspects.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaProspects.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaProspects.IsReadOnly = true;
					break;
				case "ProspectListDetailsCollectionViaProspects":
					this.ProspectListDetailsCollectionViaProspects.IsReadOnly = false;
					this.ProspectListDetailsCollectionViaProspects.Add((ProspectListDetailsEntity)entity);
					this.ProspectListDetailsCollectionViaProspects.IsReadOnly = true;
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
			return ProspectTypeEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "Prospects":
					toReturn.Add(ProspectTypeEntity.Relations.ProspectsEntityUsingProspectTypeId);
					break;
				case "AddressCollectionViaProspects":
					toReturn.Add(ProspectTypeEntity.Relations.ProspectsEntityUsingProspectTypeId, "ProspectTypeEntity__", "Prospects_", JoinHint.None);
					toReturn.Add(ProspectsEntity.Relations.AddressEntityUsingAddressId, "Prospects_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaProspects":
					toReturn.Add(ProspectTypeEntity.Relations.ProspectsEntityUsingProspectTypeId, "ProspectTypeEntity__", "Prospects_", JoinHint.None);
					toReturn.Add(ProspectsEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, "Prospects_", string.Empty, JoinHint.None);
					break;
				case "ProspectListDetailsCollectionViaProspects":
					toReturn.Add(ProspectTypeEntity.Relations.ProspectsEntityUsingProspectTypeId, "ProspectTypeEntity__", "Prospects_", JoinHint.None);
					toReturn.Add(ProspectsEntity.Relations.ProspectListDetailsEntityUsingProspectListId, "Prospects_", string.Empty, JoinHint.None);
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

				case "Prospects":
					this.Prospects.Add((ProspectsEntity)relatedEntity);
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

				case "Prospects":
					base.PerformRelatedEntityRemoval(this.Prospects, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.Prospects);

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
				info.AddValue("_prospects", ((_prospects!=null) && (_prospects.Count>0) && !this.MarkedForDeletion)?_prospects:null);
				info.AddValue("_addressCollectionViaProspects", ((_addressCollectionViaProspects!=null) && (_addressCollectionViaProspects.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaProspects:null);
				info.AddValue("_organizationRoleUserCollectionViaProspects", ((_organizationRoleUserCollectionViaProspects!=null) && (_organizationRoleUserCollectionViaProspects.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaProspects:null);
				info.AddValue("_prospectListDetailsCollectionViaProspects", ((_prospectListDetailsCollectionViaProspects!=null) && (_prospectListDetailsCollectionViaProspects.Count>0) && !this.MarkedForDeletion)?_prospectListDetailsCollectionViaProspects:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ProspectTypeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ProspectTypeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ProspectTypeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectTypeId, null, ComparisonOperator.Equal, this.ProspectTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaProspects"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectTypeFields.ProspectTypeId, null, ComparisonOperator.Equal, this.ProspectTypeId, "ProspectTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaProspects"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectTypeFields.ProspectTypeId, null, ComparisonOperator.Equal, this.ProspectTypeId, "ProspectTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectListDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectListDetailsCollectionViaProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectListDetailsCollectionViaProspects"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectTypeFields.ProspectTypeId, null, ComparisonOperator.Equal, this.ProspectTypeId, "ProspectTypeEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ProspectTypeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ProspectTypeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._prospects);
			collectionsQueue.Enqueue(this._addressCollectionViaProspects);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaProspects);
			collectionsQueue.Enqueue(this._prospectListDetailsCollectionViaProspects);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._prospects = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaProspects = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaProspects = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._prospectListDetailsCollectionViaProspects = (EntityCollection<ProspectListDetailsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._prospects != null)
			{
				return true;
			}
			if (this._addressCollectionViaProspects != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaProspects != null)
			{
				return true;
			}
			if (this._prospectListDetailsCollectionViaProspects != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("Prospects", _prospects);
			toReturn.Add("AddressCollectionViaProspects", _addressCollectionViaProspects);
			toReturn.Add("OrganizationRoleUserCollectionViaProspects", _organizationRoleUserCollectionViaProspects);
			toReturn.Add("ProspectListDetailsCollectionViaProspects", _prospectListDetailsCollectionViaProspects);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_prospects!=null)
			{
				_prospects.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaProspects!=null)
			{
				_addressCollectionViaProspects.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaProspects!=null)
			{
				_organizationRoleUserCollectionViaProspects.ActiveContext = base.ActiveContext;
			}
			if(_prospectListDetailsCollectionViaProspects!=null)
			{
				_prospectListDetailsCollectionViaProspects.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_prospects = null;
			_addressCollectionViaProspects = null;
			_organizationRoleUserCollectionViaProspects = null;
			_prospectListDetailsCollectionViaProspects = null;


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

			_fieldsCustomProperties.Add("ProspectTypeId", fieldHashtable);
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
		/// <param name="validator">The validator object for this ProspectTypeEntity</param>
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
		public  static ProspectTypeRelations Relations
		{
			get	{ return new ProspectTypeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspects
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Prospects")[0], (int)Falcon.Data.EntityType.ProspectTypeEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, null, null, "Prospects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaProspects
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectTypeEntity.Relations.ProspectsEntityUsingProspectTypeId;
				intermediateRelation.SetAliases(string.Empty, "Prospects_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectTypeEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaProspects"), null, "AddressCollectionViaProspects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaProspects
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectTypeEntity.Relations.ProspectsEntityUsingProspectTypeId;
				intermediateRelation.SetAliases(string.Empty, "Prospects_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaProspects"), null, "OrganizationRoleUserCollectionViaProspects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectListDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectListDetailsCollectionViaProspects
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectTypeEntity.Relations.ProspectsEntityUsingProspectTypeId;
				intermediateRelation.SetAliases(string.Empty, "Prospects_");
				return new PrefetchPathElement2(new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectTypeEntity, (int)Falcon.Data.EntityType.ProspectListDetailsEntity, 0, null, null, GetRelationsForField("ProspectListDetailsCollectionViaProspects"), null, "ProspectListDetailsCollectionViaProspects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ProspectTypeEntity.CustomProperties;}
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
			get { return ProspectTypeEntity.FieldsCustomProperties;}
		}

		/// <summary> The ProspectTypeId property of the Entity ProspectType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectType"."ProspectTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ProspectTypeId
		{
			get { return (System.Int64)GetValue((int)ProspectTypeFieldIndex.ProspectTypeId, true); }
			set	{ SetValue((int)ProspectTypeFieldIndex.ProspectTypeId, value); }
		}

		/// <summary> The Name property of the Entity ProspectType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectType"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ProspectTypeFieldIndex.Name, true); }
			set	{ SetValue((int)ProspectTypeFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity ProspectType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectType"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)ProspectTypeFieldIndex.Description, true); }
			set	{ SetValue((int)ProspectTypeFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity ProspectType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectType"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ProspectTypeFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ProspectTypeFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity ProspectType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectType"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ProspectTypeFieldIndex.DateModified, true); }
			set	{ SetValue((int)ProspectTypeFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity ProspectType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectType"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ProspectTypeFieldIndex.IsActive, true); }
			set	{ SetValue((int)ProspectTypeFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectsEntity))]
		public virtual EntityCollection<ProspectsEntity> Prospects
		{
			get
			{
				if(_prospects==null)
				{
					_prospects = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospects.SetContainingEntityInfo(this, "ProspectType");
				}
				return _prospects;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaProspects
		{
			get
			{
				if(_addressCollectionViaProspects==null)
				{
					_addressCollectionViaProspects = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaProspects.IsReadOnly=true;
				}
				return _addressCollectionViaProspects;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaProspects
		{
			get
			{
				if(_organizationRoleUserCollectionViaProspects==null)
				{
					_organizationRoleUserCollectionViaProspects = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaProspects.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaProspects;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectListDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectListDetailsEntity))]
		public virtual EntityCollection<ProspectListDetailsEntity> ProspectListDetailsCollectionViaProspects
		{
			get
			{
				if(_prospectListDetailsCollectionViaProspects==null)
				{
					_prospectListDetailsCollectionViaProspects = new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory)));
					_prospectListDetailsCollectionViaProspects.IsReadOnly=true;
				}
				return _prospectListDetailsCollectionViaProspects;
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
			get { return (int)Falcon.Data.EntityType.ProspectTypeEntity; }
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
