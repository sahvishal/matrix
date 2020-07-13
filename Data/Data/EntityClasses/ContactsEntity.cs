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
	/// Entity class which represents the entity 'Contacts'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ContactsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ContactFranchiseeAccessEntity> _contactFranchiseeAccess;
		private EntityCollection<ContactNotesEntity> _contactNotes;
		private EntityCollection<OrganizationEntity> _organizationCollectionViaContactFranchiseeAccess;
		private ContactTypeEntity _contactType;
		private RoleEntity _role_;
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
			/// <summary>Member name ContactType</summary>
			public static readonly string ContactType = "ContactType";
			/// <summary>Member name Role_</summary>
			public static readonly string Role_ = "Role_";
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";
			/// <summary>Member name ContactFranchiseeAccess</summary>
			public static readonly string ContactFranchiseeAccess = "ContactFranchiseeAccess";
			/// <summary>Member name ContactNotes</summary>
			public static readonly string ContactNotes = "ContactNotes";
			/// <summary>Member name OrganizationCollectionViaContactFranchiseeAccess</summary>
			public static readonly string OrganizationCollectionViaContactFranchiseeAccess = "OrganizationCollectionViaContactFranchiseeAccess";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ContactsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ContactsEntity():base("ContactsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ContactsEntity(IEntityFields2 fields):base("ContactsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ContactsEntity</param>
		public ContactsEntity(IValidator validator):base("ContactsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="contactId">PK value for Contacts which data should be fetched into this Contacts object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ContactsEntity(System.Int64 contactId):base("ContactsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ContactId = contactId;
		}

		/// <summary> CTor</summary>
		/// <param name="contactId">PK value for Contacts which data should be fetched into this Contacts object</param>
		/// <param name="validator">The custom validator object for this ContactsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ContactsEntity(System.Int64 contactId, IValidator validator):base("ContactsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ContactId = contactId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ContactsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_contactFranchiseeAccess = (EntityCollection<ContactFranchiseeAccessEntity>)info.GetValue("_contactFranchiseeAccess", typeof(EntityCollection<ContactFranchiseeAccessEntity>));
				_contactNotes = (EntityCollection<ContactNotesEntity>)info.GetValue("_contactNotes", typeof(EntityCollection<ContactNotesEntity>));
				_organizationCollectionViaContactFranchiseeAccess = (EntityCollection<OrganizationEntity>)info.GetValue("_organizationCollectionViaContactFranchiseeAccess", typeof(EntityCollection<OrganizationEntity>));
				_contactType = (ContactTypeEntity)info.GetValue("_contactType", typeof(ContactTypeEntity));
				if(_contactType!=null)
				{
					_contactType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_role_ = (RoleEntity)info.GetValue("_role_", typeof(RoleEntity));
				if(_role_!=null)
				{
					_role_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
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
			switch((ContactsFieldIndex)fieldIndex)
			{
				case ContactsFieldIndex.AddedRoleId:
					DesetupSyncRole(true, false);
					break;
				case ContactsFieldIndex.ModifiedRoleId:
					DesetupSyncRole_(true, false);
					break;
				case ContactsFieldIndex.ContactTypeId:
					DesetupSyncContactType(true, false);
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
				case "ContactType":
					this.ContactType = (ContactTypeEntity)entity;
					break;
				case "Role_":
					this.Role_ = (RoleEntity)entity;
					break;
				case "Role":
					this.Role = (RoleEntity)entity;
					break;
				case "ContactFranchiseeAccess":
					this.ContactFranchiseeAccess.Add((ContactFranchiseeAccessEntity)entity);
					break;
				case "ContactNotes":
					this.ContactNotes.Add((ContactNotesEntity)entity);
					break;
				case "OrganizationCollectionViaContactFranchiseeAccess":
					this.OrganizationCollectionViaContactFranchiseeAccess.IsReadOnly = false;
					this.OrganizationCollectionViaContactFranchiseeAccess.Add((OrganizationEntity)entity);
					this.OrganizationCollectionViaContactFranchiseeAccess.IsReadOnly = true;
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
			return ContactsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ContactType":
					toReturn.Add(ContactsEntity.Relations.ContactTypeEntityUsingContactTypeId);
					break;
				case "Role_":
					toReturn.Add(ContactsEntity.Relations.RoleEntityUsingModifiedRoleId);
					break;
				case "Role":
					toReturn.Add(ContactsEntity.Relations.RoleEntityUsingAddedRoleId);
					break;
				case "ContactFranchiseeAccess":
					toReturn.Add(ContactsEntity.Relations.ContactFranchiseeAccessEntityUsingContactId);
					break;
				case "ContactNotes":
					toReturn.Add(ContactsEntity.Relations.ContactNotesEntityUsingContactId);
					break;
				case "OrganizationCollectionViaContactFranchiseeAccess":
					toReturn.Add(ContactsEntity.Relations.ContactFranchiseeAccessEntityUsingContactId, "ContactsEntity__", "ContactFranchiseeAccess_", JoinHint.None);
					toReturn.Add(ContactFranchiseeAccessEntity.Relations.OrganizationEntityUsingOrganizationId, "ContactFranchiseeAccess_", string.Empty, JoinHint.None);
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
				case "ContactType":
					SetupSyncContactType(relatedEntity);
					break;
				case "Role_":
					SetupSyncRole_(relatedEntity);
					break;
				case "Role":
					SetupSyncRole(relatedEntity);
					break;
				case "ContactFranchiseeAccess":
					this.ContactFranchiseeAccess.Add((ContactFranchiseeAccessEntity)relatedEntity);
					break;
				case "ContactNotes":
					this.ContactNotes.Add((ContactNotesEntity)relatedEntity);
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
				case "ContactType":
					DesetupSyncContactType(false, true);
					break;
				case "Role_":
					DesetupSyncRole_(false, true);
					break;
				case "Role":
					DesetupSyncRole(false, true);
					break;
				case "ContactFranchiseeAccess":
					base.PerformRelatedEntityRemoval(this.ContactFranchiseeAccess, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ContactNotes":
					base.PerformRelatedEntityRemoval(this.ContactNotes, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_contactType!=null)
			{
				toReturn.Add(_contactType);
			}
			if(_role_!=null)
			{
				toReturn.Add(_role_);
			}
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
			toReturn.Add(this.ContactFranchiseeAccess);
			toReturn.Add(this.ContactNotes);

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
				info.AddValue("_contactFranchiseeAccess", ((_contactFranchiseeAccess!=null) && (_contactFranchiseeAccess.Count>0) && !this.MarkedForDeletion)?_contactFranchiseeAccess:null);
				info.AddValue("_contactNotes", ((_contactNotes!=null) && (_contactNotes.Count>0) && !this.MarkedForDeletion)?_contactNotes:null);
				info.AddValue("_organizationCollectionViaContactFranchiseeAccess", ((_organizationCollectionViaContactFranchiseeAccess!=null) && (_organizationCollectionViaContactFranchiseeAccess.Count>0) && !this.MarkedForDeletion)?_organizationCollectionViaContactFranchiseeAccess:null);
				info.AddValue("_contactType", (!this.MarkedForDeletion?_contactType:null));
				info.AddValue("_role_", (!this.MarkedForDeletion?_role_:null));
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
		public bool TestOriginalFieldValueForNull(ContactsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ContactsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ContactsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ContactFranchiseeAccess' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactFranchiseeAccess()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactFranchiseeAccessFields.ContactId, null, ComparisonOperator.Equal, this.ContactId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ContactNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactNotesFields.ContactId, null, ComparisonOperator.Equal, this.ContactId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationCollectionViaContactFranchiseeAccess()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationCollectionViaContactFranchiseeAccess"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactsFields.ContactId, null, ComparisonOperator.Equal, this.ContactId, "ContactsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ContactType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactTypeFields.ContactTypeId, null, ComparisonOperator.Equal, this.ContactTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Role' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.ModifiedRoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Role' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.AddedRoleId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ContactsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._contactFranchiseeAccess);
			collectionsQueue.Enqueue(this._contactNotes);
			collectionsQueue.Enqueue(this._organizationCollectionViaContactFranchiseeAccess);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._contactFranchiseeAccess = (EntityCollection<ContactFranchiseeAccessEntity>) collectionsQueue.Dequeue();
			this._contactNotes = (EntityCollection<ContactNotesEntity>) collectionsQueue.Dequeue();
			this._organizationCollectionViaContactFranchiseeAccess = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._contactFranchiseeAccess != null)
			{
				return true;
			}
			if (this._contactNotes != null)
			{
				return true;
			}
			if (this._organizationCollectionViaContactFranchiseeAccess != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactFranchiseeAccessEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ContactType", _contactType);
			toReturn.Add("Role_", _role_);
			toReturn.Add("Role", _role);
			toReturn.Add("ContactFranchiseeAccess", _contactFranchiseeAccess);
			toReturn.Add("ContactNotes", _contactNotes);
			toReturn.Add("OrganizationCollectionViaContactFranchiseeAccess", _organizationCollectionViaContactFranchiseeAccess);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_contactFranchiseeAccess!=null)
			{
				_contactFranchiseeAccess.ActiveContext = base.ActiveContext;
			}
			if(_contactNotes!=null)
			{
				_contactNotes.ActiveContext = base.ActiveContext;
			}
			if(_organizationCollectionViaContactFranchiseeAccess!=null)
			{
				_organizationCollectionViaContactFranchiseeAccess.ActiveContext = base.ActiveContext;
			}
			if(_contactType!=null)
			{
				_contactType.ActiveContext = base.ActiveContext;
			}
			if(_role_!=null)
			{
				_role_.ActiveContext = base.ActiveContext;
			}
			if(_role!=null)
			{
				_role.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_contactFranchiseeAccess = null;
			_contactNotes = null;
			_organizationCollectionViaContactFranchiseeAccess = null;
			_contactType = null;
			_role_ = null;
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

			_fieldsCustomProperties.Add("ContactId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Salutation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHome", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOffice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOfficeExtension", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Fax", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Addedby", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPrimary", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Title", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Website", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Organisation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddedRoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedRoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContactTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Address1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Address2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("City", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("State", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Country", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmailOffice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateOfBirth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmployeeId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _contactType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncContactType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _contactType, new PropertyChangedEventHandler( OnContactTypePropertyChanged ), "ContactType", ContactsEntity.Relations.ContactTypeEntityUsingContactTypeId, true, signalRelatedEntity, "Contacts", resetFKFields, new int[] { (int)ContactsFieldIndex.ContactTypeId } );		
			_contactType = null;
		}

		/// <summary> setups the sync logic for member _contactType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncContactType(IEntity2 relatedEntity)
		{
			if(_contactType!=relatedEntity)
			{
				DesetupSyncContactType(true, true);
				_contactType = (ContactTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _contactType, new PropertyChangedEventHandler( OnContactTypePropertyChanged ), "ContactType", ContactsEntity.Relations.ContactTypeEntityUsingContactTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnContactTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _role_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRole_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _role_, new PropertyChangedEventHandler( OnRole_PropertyChanged ), "Role_", ContactsEntity.Relations.RoleEntityUsingModifiedRoleId, true, signalRelatedEntity, "Contacts_", resetFKFields, new int[] { (int)ContactsFieldIndex.ModifiedRoleId } );		
			_role_ = null;
		}

		/// <summary> setups the sync logic for member _role_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRole_(IEntity2 relatedEntity)
		{
			if(_role_!=relatedEntity)
			{
				DesetupSyncRole_(true, true);
				_role_ = (RoleEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _role_, new PropertyChangedEventHandler( OnRole_PropertyChanged ), "Role_", ContactsEntity.Relations.RoleEntityUsingModifiedRoleId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRole_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _role</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRole(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", ContactsEntity.Relations.RoleEntityUsingAddedRoleId, true, signalRelatedEntity, "Contacts", resetFKFields, new int[] { (int)ContactsFieldIndex.AddedRoleId } );		
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
				base.PerformSetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", ContactsEntity.Relations.RoleEntityUsingAddedRoleId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this ContactsEntity</param>
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
		public  static ContactsRelations Relations
		{
			get	{ return new ContactsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactFranchiseeAccess' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactFranchiseeAccess
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ContactFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactFranchiseeAccessEntityFactory))),
					(IEntityRelation)GetRelationsForField("ContactFranchiseeAccess")[0], (int)Falcon.Data.EntityType.ContactsEntity, (int)Falcon.Data.EntityType.ContactFranchiseeAccessEntity, 0, null, null, null, null, "ContactFranchiseeAccess", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactNotes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ContactNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("ContactNotes")[0], (int)Falcon.Data.EntityType.ContactsEntity, (int)Falcon.Data.EntityType.ContactNotesEntity, 0, null, null, null, null, "ContactNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationCollectionViaContactFranchiseeAccess
		{
			get
			{
				IEntityRelation intermediateRelation = ContactsEntity.Relations.ContactFranchiseeAccessEntityUsingContactId;
				intermediateRelation.SetAliases(string.Empty, "ContactFranchiseeAccess_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ContactsEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, GetRelationsForField("OrganizationCollectionViaContactFranchiseeAccess"), null, "OrganizationCollectionViaContactFranchiseeAccess", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("ContactType")[0], (int)Falcon.Data.EntityType.ContactsEntity, (int)Falcon.Data.EntityType.ContactTypeEntity, 0, null, null, null, null, "ContactType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRole_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))),
					(IEntityRelation)GetRelationsForField("Role_")[0], (int)Falcon.Data.EntityType.ContactsEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, null, null, "Role_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Role")[0], (int)Falcon.Data.EntityType.ContactsEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, null, null, "Role", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ContactsEntity.CustomProperties;}
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
			get { return ContactsEntity.FieldsCustomProperties;}
		}

		/// <summary> The ContactId property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."ContactID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ContactId
		{
			get { return (System.Int64)GetValue((int)ContactsFieldIndex.ContactId, true); }
			set	{ SetValue((int)ContactsFieldIndex.ContactId, value); }
		}

		/// <summary> The Salutation property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Salutation"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Salutation
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Salutation, true); }
			set	{ SetValue((int)ContactsFieldIndex.Salutation, value); }
		}

		/// <summary> The FirstName property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.FirstName, true); }
			set	{ SetValue((int)ContactsFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."MiddleName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.MiddleName, true); }
			set	{ SetValue((int)ContactsFieldIndex.MiddleName, value); }
		}

		/// <summary> The LastName property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.LastName, true); }
			set	{ SetValue((int)ContactsFieldIndex.LastName, value); }
		}

		/// <summary> The PhoneHome property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."PhoneHome"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneHome
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.PhoneHome, true); }
			set	{ SetValue((int)ContactsFieldIndex.PhoneHome, value); }
		}

		/// <summary> The PhoneCell property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."PhoneCell"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)ContactsFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneOffice property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."PhoneOffice"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOffice
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.PhoneOffice, true); }
			set	{ SetValue((int)ContactsFieldIndex.PhoneOffice, value); }
		}

		/// <summary> The PhoneOfficeExtension property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."PhoneOfficeExtension"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOfficeExtension
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.PhoneOfficeExtension, true); }
			set	{ SetValue((int)ContactsFieldIndex.PhoneOfficeExtension, value); }
		}

		/// <summary> The Fax property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Fax"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Fax
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Fax, true); }
			set	{ SetValue((int)ContactsFieldIndex.Fax, value); }
		}

		/// <summary> The Email property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."EMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Email, true); }
			set	{ SetValue((int)ContactsFieldIndex.Email, value); }
		}

		/// <summary> The Addedby property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Addedby"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Addedby
		{
			get { return (Nullable<System.Int64>)GetValue((int)ContactsFieldIndex.Addedby, false); }
			set	{ SetValue((int)ContactsFieldIndex.Addedby, value); }
		}

		/// <summary> The ModifiedBy property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)ContactsFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)ContactsFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The DateCreated property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ContactsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ContactsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ContactsFieldIndex.DateModified, true); }
			set	{ SetValue((int)ContactsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsPrimary property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."isPrimary"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> IsPrimary
		{
			get { return (Nullable<System.Int32>)GetValue((int)ContactsFieldIndex.IsPrimary, false); }
			set	{ SetValue((int)ContactsFieldIndex.IsPrimary, value); }
		}

		/// <summary> The Title property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Title"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Title
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Title, true); }
			set	{ SetValue((int)ContactsFieldIndex.Title, value); }
		}

		/// <summary> The Gender property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> Gender
		{
			get { return (Nullable<System.Boolean>)GetValue((int)ContactsFieldIndex.Gender, false); }
			set	{ SetValue((int)ContactsFieldIndex.Gender, value); }
		}

		/// <summary> The Website property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Website"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Website
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Website, true); }
			set	{ SetValue((int)ContactsFieldIndex.Website, value); }
		}

		/// <summary> The Organisation property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Organisation"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Organisation
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Organisation, true); }
			set	{ SetValue((int)ContactsFieldIndex.Organisation, value); }
		}

		/// <summary> The Status property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Status
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Status, true); }
			set	{ SetValue((int)ContactsFieldIndex.Status, value); }
		}

		/// <summary> The AddedRoleId property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."AddedRoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AddedRoleId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ContactsFieldIndex.AddedRoleId, false); }
			set	{ SetValue((int)ContactsFieldIndex.AddedRoleId, value); }
		}

		/// <summary> The ModifiedRoleId property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."ModifiedRoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedRoleId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ContactsFieldIndex.ModifiedRoleId, false); }
			set	{ SetValue((int)ContactsFieldIndex.ModifiedRoleId, value); }
		}

		/// <summary> The ContactTypeId property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."ContactTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ContactTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ContactsFieldIndex.ContactTypeId, false); }
			set	{ SetValue((int)ContactsFieldIndex.ContactTypeId, value); }
		}

		/// <summary> The Address1 property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Address1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Address1
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Address1, true); }
			set	{ SetValue((int)ContactsFieldIndex.Address1, value); }
		}

		/// <summary> The Address2 property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Address2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Address2
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Address2, true); }
			set	{ SetValue((int)ContactsFieldIndex.Address2, value); }
		}

		/// <summary> The City property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."City"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String City
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.City, true); }
			set	{ SetValue((int)ContactsFieldIndex.City, value); }
		}

		/// <summary> The State property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."State"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String State
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.State, true); }
			set	{ SetValue((int)ContactsFieldIndex.State, value); }
		}

		/// <summary> The Country property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."Country"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Country
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.Country, true); }
			set	{ SetValue((int)ContactsFieldIndex.Country, value); }
		}

		/// <summary> The ZipCode property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."ZipCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ZipCode
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.ZipCode, true); }
			set	{ SetValue((int)ContactsFieldIndex.ZipCode, value); }
		}

		/// <summary> The EmailOffice property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."EmailOffice"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmailOffice
		{
			get { return (System.String)GetValue((int)ContactsFieldIndex.EmailOffice, true); }
			set	{ SetValue((int)ContactsFieldIndex.EmailOffice, value); }
		}

		/// <summary> The DateOfBirth property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."DateOfBirth"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateOfBirth
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ContactsFieldIndex.DateOfBirth, false); }
			set	{ SetValue((int)ContactsFieldIndex.DateOfBirth, value); }
		}

		/// <summary> The IsActive property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ContactsFieldIndex.IsActive, true); }
			set	{ SetValue((int)ContactsFieldIndex.IsActive, value); }
		}

		/// <summary> The EmployeeId property of the Entity Contacts<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContacts"."EmployeeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EmployeeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ContactsFieldIndex.EmployeeId, false); }
			set	{ SetValue((int)ContactsFieldIndex.EmployeeId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactFranchiseeAccessEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactFranchiseeAccessEntity))]
		public virtual EntityCollection<ContactFranchiseeAccessEntity> ContactFranchiseeAccess
		{
			get
			{
				if(_contactFranchiseeAccess==null)
				{
					_contactFranchiseeAccess = new EntityCollection<ContactFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactFranchiseeAccessEntityFactory)));
					_contactFranchiseeAccess.SetContainingEntityInfo(this, "Contacts");
				}
				return _contactFranchiseeAccess;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactNotesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactNotesEntity))]
		public virtual EntityCollection<ContactNotesEntity> ContactNotes
		{
			get
			{
				if(_contactNotes==null)
				{
					_contactNotes = new EntityCollection<ContactNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactNotesEntityFactory)));
					_contactNotes.SetContainingEntityInfo(this, "Contacts");
				}
				return _contactNotes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> OrganizationCollectionViaContactFranchiseeAccess
		{
			get
			{
				if(_organizationCollectionViaContactFranchiseeAccess==null)
				{
					_organizationCollectionViaContactFranchiseeAccess = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organizationCollectionViaContactFranchiseeAccess.IsReadOnly=true;
				}
				return _organizationCollectionViaContactFranchiseeAccess;
			}
		}

		/// <summary> Gets / sets related entity of type 'ContactTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ContactTypeEntity ContactType
		{
			get
			{
				return _contactType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncContactType(value);
				}
				else
				{
					if(value==null)
					{
						if(_contactType != null)
						{
							_contactType.UnsetRelatedEntity(this, "Contacts");
						}
					}
					else
					{
						if(_contactType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Contacts");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual RoleEntity Role_
		{
			get
			{
				return _role_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncRole_(value);
				}
				else
				{
					if(value==null)
					{
						if(_role_ != null)
						{
							_role_.UnsetRelatedEntity(this, "Contacts_");
						}
					}
					else
					{
						if(_role_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Contacts_");
						}
					}
				}
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
							_role.UnsetRelatedEntity(this, "Contacts");
						}
					}
					else
					{
						if(_role!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Contacts");
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
			get { return (int)Falcon.Data.EntityType.ContactsEntity; }
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
