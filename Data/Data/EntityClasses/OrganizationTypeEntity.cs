﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:46
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
	/// Entity class which represents the entity 'OrganizationType'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OrganizationTypeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<OrganizationEntity> _organization;
		private EntityCollection<RoleEntity> _role;
		private EntityCollection<AddressEntity> _addressCollectionViaOrganization;
		private EntityCollection<FileEntity> _fileCollectionViaOrganization_;
		private EntityCollection<FileEntity> _fileCollectionViaOrganization;
		private EntityCollection<RoleEntity> _roleCollectionViaRole;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";
			/// <summary>Member name AddressCollectionViaOrganization</summary>
			public static readonly string AddressCollectionViaOrganization = "AddressCollectionViaOrganization";
			/// <summary>Member name FileCollectionViaOrganization_</summary>
			public static readonly string FileCollectionViaOrganization_ = "FileCollectionViaOrganization_";
			/// <summary>Member name FileCollectionViaOrganization</summary>
			public static readonly string FileCollectionViaOrganization = "FileCollectionViaOrganization";
			/// <summary>Member name RoleCollectionViaRole</summary>
			public static readonly string RoleCollectionViaRole = "RoleCollectionViaRole";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OrganizationTypeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public OrganizationTypeEntity():base("OrganizationTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OrganizationTypeEntity(IEntityFields2 fields):base("OrganizationTypeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OrganizationTypeEntity</param>
		public OrganizationTypeEntity(IValidator validator):base("OrganizationTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="organizationTypeId">PK value for OrganizationType which data should be fetched into this OrganizationType object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrganizationTypeEntity(System.Int64 organizationTypeId):base("OrganizationTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OrganizationTypeId = organizationTypeId;
		}

		/// <summary> CTor</summary>
		/// <param name="organizationTypeId">PK value for OrganizationType which data should be fetched into this OrganizationType object</param>
		/// <param name="validator">The custom validator object for this OrganizationTypeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrganizationTypeEntity(System.Int64 organizationTypeId, IValidator validator):base("OrganizationTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OrganizationTypeId = organizationTypeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected OrganizationTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_organization = (EntityCollection<OrganizationEntity>)info.GetValue("_organization", typeof(EntityCollection<OrganizationEntity>));
				_role = (EntityCollection<RoleEntity>)info.GetValue("_role", typeof(EntityCollection<RoleEntity>));
				_addressCollectionViaOrganization = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaOrganization", typeof(EntityCollection<AddressEntity>));
				_fileCollectionViaOrganization_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaOrganization_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaOrganization = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaOrganization", typeof(EntityCollection<FileEntity>));
				_roleCollectionViaRole = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaRole", typeof(EntityCollection<RoleEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((OrganizationTypeFieldIndex)fieldIndex)
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

				case "Organization":
					this.Organization.Add((OrganizationEntity)entity);
					break;
				case "Role":
					this.Role.Add((RoleEntity)entity);
					break;
				case "AddressCollectionViaOrganization":
					this.AddressCollectionViaOrganization.IsReadOnly = false;
					this.AddressCollectionViaOrganization.Add((AddressEntity)entity);
					this.AddressCollectionViaOrganization.IsReadOnly = true;
					break;
				case "FileCollectionViaOrganization_":
					this.FileCollectionViaOrganization_.IsReadOnly = false;
					this.FileCollectionViaOrganization_.Add((FileEntity)entity);
					this.FileCollectionViaOrganization_.IsReadOnly = true;
					break;
				case "FileCollectionViaOrganization":
					this.FileCollectionViaOrganization.IsReadOnly = false;
					this.FileCollectionViaOrganization.Add((FileEntity)entity);
					this.FileCollectionViaOrganization.IsReadOnly = true;
					break;
				case "RoleCollectionViaRole":
					this.RoleCollectionViaRole.IsReadOnly = false;
					this.RoleCollectionViaRole.Add((RoleEntity)entity);
					this.RoleCollectionViaRole.IsReadOnly = true;
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
			return OrganizationTypeEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "Organization":
					toReturn.Add(OrganizationTypeEntity.Relations.OrganizationEntityUsingOrganizationTypeId);
					break;
				case "Role":
					toReturn.Add(OrganizationTypeEntity.Relations.RoleEntityUsingOrganizationTypeId);
					break;
				case "AddressCollectionViaOrganization":
					toReturn.Add(OrganizationTypeEntity.Relations.OrganizationEntityUsingOrganizationTypeId, "OrganizationTypeEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.AddressEntityUsingBusinessAddressId, "Organization_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaOrganization_":
					toReturn.Add(OrganizationTypeEntity.Relations.OrganizationEntityUsingOrganizationTypeId, "OrganizationTypeEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.FileEntityUsingTeamImageId, "Organization_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaOrganization":
					toReturn.Add(OrganizationTypeEntity.Relations.OrganizationEntityUsingOrganizationTypeId, "OrganizationTypeEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.FileEntityUsingLogoImageId, "Organization_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaRole":
					toReturn.Add(OrganizationTypeEntity.Relations.RoleEntityUsingOrganizationTypeId, "OrganizationTypeEntity__", "Role_", JoinHint.None);
					toReturn.Add(RoleEntity.Relations.RoleEntityUsingParentId, "Role_", string.Empty, JoinHint.None);
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

				case "Organization":
					this.Organization.Add((OrganizationEntity)relatedEntity);
					break;
				case "Role":
					this.Role.Add((RoleEntity)relatedEntity);
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

				case "Organization":
					base.PerformRelatedEntityRemoval(this.Organization, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Role":
					base.PerformRelatedEntityRemoval(this.Role, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.Organization);
			toReturn.Add(this.Role);

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
				info.AddValue("_organization", ((_organization!=null) && (_organization.Count>0) && !this.MarkedForDeletion)?_organization:null);
				info.AddValue("_role", ((_role!=null) && (_role.Count>0) && !this.MarkedForDeletion)?_role:null);
				info.AddValue("_addressCollectionViaOrganization", ((_addressCollectionViaOrganization!=null) && (_addressCollectionViaOrganization.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaOrganization:null);
				info.AddValue("_fileCollectionViaOrganization_", ((_fileCollectionViaOrganization_!=null) && (_fileCollectionViaOrganization_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaOrganization_:null);
				info.AddValue("_fileCollectionViaOrganization", ((_fileCollectionViaOrganization!=null) && (_fileCollectionViaOrganization.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaOrganization:null);
				info.AddValue("_roleCollectionViaRole", ((_roleCollectionViaRole!=null) && (_roleCollectionViaRole.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaRole:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// Alias .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCAlias()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)OrganizationTypeFieldIndex.Alias], null, ComparisonOperator.Equal)); 
			return filter;
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OrganizationTypeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OrganizationTypeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OrganizationTypeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationTypeId, null, ComparisonOperator.Equal, this.OrganizationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.OrganizationTypeId, null, ComparisonOperator.Equal, this.OrganizationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationTypeFields.OrganizationTypeId, null, ComparisonOperator.Equal, this.OrganizationTypeId, "OrganizationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaOrganization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaOrganization_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationTypeFields.OrganizationTypeId, null, ComparisonOperator.Equal, this.OrganizationTypeId, "OrganizationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationTypeFields.OrganizationTypeId, null, ComparisonOperator.Equal, this.OrganizationTypeId, "OrganizationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaRole"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationTypeFields.OrganizationTypeId, null, ComparisonOperator.Equal, this.OrganizationTypeId, "OrganizationTypeEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.OrganizationTypeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._organization);
			collectionsQueue.Enqueue(this._role);
			collectionsQueue.Enqueue(this._addressCollectionViaOrganization);
			collectionsQueue.Enqueue(this._fileCollectionViaOrganization_);
			collectionsQueue.Enqueue(this._fileCollectionViaOrganization);
			collectionsQueue.Enqueue(this._roleCollectionViaRole);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._organization = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
			this._role = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaOrganization = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaOrganization_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaOrganization = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaRole = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._organization != null)
			{
				return true;
			}
			if (this._role != null)
			{
				return true;
			}
			if (this._addressCollectionViaOrganization != null)
			{
				return true;
			}
			if (this._fileCollectionViaOrganization_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaOrganization != null)
			{
				return true;
			}
			if (this._roleCollectionViaRole != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("Organization", _organization);
			toReturn.Add("Role", _role);
			toReturn.Add("AddressCollectionViaOrganization", _addressCollectionViaOrganization);
			toReturn.Add("FileCollectionViaOrganization_", _fileCollectionViaOrganization_);
			toReturn.Add("FileCollectionViaOrganization", _fileCollectionViaOrganization);
			toReturn.Add("RoleCollectionViaRole", _roleCollectionViaRole);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_organization!=null)
			{
				_organization.ActiveContext = base.ActiveContext;
			}
			if(_role!=null)
			{
				_role.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaOrganization!=null)
			{
				_addressCollectionViaOrganization.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaOrganization_!=null)
			{
				_fileCollectionViaOrganization_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaOrganization!=null)
			{
				_fileCollectionViaOrganization.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaRole!=null)
			{
				_roleCollectionViaRole.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_organization = null;
			_role = null;
			_addressCollectionViaOrganization = null;
			_fileCollectionViaOrganization_ = null;
			_fileCollectionViaOrganization = null;
			_roleCollectionViaRole = null;


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

			_fieldsCustomProperties.Add("OrganizationTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OrganizationTypeEntity</param>
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
		public  static OrganizationTypeRelations Relations
		{
			get	{ return new OrganizationTypeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization")[0], (int)Falcon.Data.EntityType.OrganizationTypeEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRole
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))),
					(IEntityRelation)GetRelationsForField("Role")[0], (int)Falcon.Data.EntityType.OrganizationTypeEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, null, null, "Role", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationTypeEntity.Relations.OrganizationEntityUsingOrganizationTypeId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationTypeEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaOrganization"), null, "AddressCollectionViaOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaOrganization_
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationTypeEntity.Relations.OrganizationEntityUsingOrganizationTypeId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationTypeEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaOrganization_"), null, "FileCollectionViaOrganization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationTypeEntity.Relations.OrganizationEntityUsingOrganizationTypeId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationTypeEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaOrganization"), null, "FileCollectionViaOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaRole
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationTypeEntity.Relations.RoleEntityUsingOrganizationTypeId;
				intermediateRelation.SetAliases(string.Empty, "Role_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationTypeEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaRole"), null, "RoleCollectionViaRole", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OrganizationTypeEntity.CustomProperties;}
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
			get { return OrganizationTypeEntity.FieldsCustomProperties;}
		}

		/// <summary> The OrganizationTypeId property of the Entity OrganizationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganizationType"."OrganizationTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 OrganizationTypeId
		{
			get { return (System.Int64)GetValue((int)OrganizationTypeFieldIndex.OrganizationTypeId, true); }
			set	{ SetValue((int)OrganizationTypeFieldIndex.OrganizationTypeId, value); }
		}

		/// <summary> The Name property of the Entity OrganizationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganizationType"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)OrganizationTypeFieldIndex.Name, true); }
			set	{ SetValue((int)OrganizationTypeFieldIndex.Name, value); }
		}

		/// <summary> The Alias property of the Entity OrganizationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganizationType"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)OrganizationTypeFieldIndex.Alias, true); }
			set	{ SetValue((int)OrganizationTypeFieldIndex.Alias, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> Organization
		{
			get
			{
				if(_organization==null)
				{
					_organization = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organization.SetContainingEntityInfo(this, "OrganizationType");
				}
				return _organization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> Role
		{
			get
			{
				if(_role==null)
				{
					_role = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_role.SetContainingEntityInfo(this, "OrganizationType");
				}
				return _role;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaOrganization
		{
			get
			{
				if(_addressCollectionViaOrganization==null)
				{
					_addressCollectionViaOrganization = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaOrganization.IsReadOnly=true;
				}
				return _addressCollectionViaOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaOrganization_
		{
			get
			{
				if(_fileCollectionViaOrganization_==null)
				{
					_fileCollectionViaOrganization_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaOrganization_.IsReadOnly=true;
				}
				return _fileCollectionViaOrganization_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaOrganization
		{
			get
			{
				if(_fileCollectionViaOrganization==null)
				{
					_fileCollectionViaOrganization = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaOrganization.IsReadOnly=true;
				}
				return _fileCollectionViaOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaRole
		{
			get
			{
				if(_roleCollectionViaRole==null)
				{
					_roleCollectionViaRole = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaRole.IsReadOnly=true;
				}
				return _roleCollectionViaRole;
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
			get { return (int)Falcon.Data.EntityType.OrganizationTypeEntity; }
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