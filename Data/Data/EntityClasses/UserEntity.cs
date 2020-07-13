///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:45
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
	/// Entity class which represents the entity 'User'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class UserEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUser;
		private EntityCollection<OrganizationEntity> _organizationCollectionViaOrganizationRoleUser;
		private EntityCollection<RoleEntity> _roleCollectionViaOrganizationRoleUser;
		private AddressEntity _address;
		private OrganizationRoleUserEntity _organizationRoleUser__;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private RoleEntity _role;
		private SystemUserInfoEntity _systemUserInfo;
		private UserLoginEntity _userLogin;
		private UserNpiInfoEntity _userNpiInfo;
		
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
			/// <summary>Member name OrganizationRoleUser__</summary>
			public static readonly string OrganizationRoleUser__ = "OrganizationRoleUser__";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name OrganizationCollectionViaOrganizationRoleUser</summary>
			public static readonly string OrganizationCollectionViaOrganizationRoleUser = "OrganizationCollectionViaOrganizationRoleUser";
			/// <summary>Member name RoleCollectionViaOrganizationRoleUser</summary>
			public static readonly string RoleCollectionViaOrganizationRoleUser = "RoleCollectionViaOrganizationRoleUser";
			/// <summary>Member name SystemUserInfo</summary>
			public static readonly string SystemUserInfo = "SystemUserInfo";
			/// <summary>Member name UserLogin</summary>
			public static readonly string UserLogin = "UserLogin";
			/// <summary>Member name UserNpiInfo</summary>
			public static readonly string UserNpiInfo = "UserNpiInfo";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static UserEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public UserEntity():base("UserEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public UserEntity(IEntityFields2 fields):base("UserEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		public UserEntity(IValidator validator):base("UserEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UserEntity(System.Int64 userId):base("UserEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.UserId = userId;
		}

		/// <summary> CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UserEntity(System.Int64 userId, IValidator validator):base("UserEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.UserId = userId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected UserEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_organizationRoleUser = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUser", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationCollectionViaOrganizationRoleUser = (EntityCollection<OrganizationEntity>)info.GetValue("_organizationCollectionViaOrganizationRoleUser", typeof(EntityCollection<OrganizationEntity>));
				_roleCollectionViaOrganizationRoleUser = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaOrganizationRoleUser", typeof(EntityCollection<RoleEntity>));
				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser__ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser__", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser__!=null)
				{
					_organizationRoleUser__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_role = (RoleEntity)info.GetValue("_role", typeof(RoleEntity));
				if(_role!=null)
				{
					_role.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_systemUserInfo = (SystemUserInfoEntity)info.GetValue("_systemUserInfo", typeof(SystemUserInfoEntity));
				if(_systemUserInfo!=null)
				{
					_systemUserInfo.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_userLogin = (UserLoginEntity)info.GetValue("_userLogin", typeof(UserLoginEntity));
				if(_userLogin!=null)
				{
					_userLogin.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_userNpiInfo = (UserNpiInfoEntity)info.GetValue("_userNpiInfo", typeof(UserNpiInfoEntity));
				if(_userNpiInfo!=null)
				{
					_userNpiInfo.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((UserFieldIndex)fieldIndex)
			{
				case UserFieldIndex.HomeAddressId:
					DesetupSyncAddress(true, false);
					break;
				case UserFieldIndex.DefaultRoleId:
					DesetupSyncRole(true, false);
					break;
				case UserFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case UserFieldIndex.ModifiedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser__(true, false);
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
				case "OrganizationRoleUser__":
					this.OrganizationRoleUser__ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "Role":
					this.Role = (RoleEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser.Add((OrganizationRoleUserEntity)entity);
					break;
				case "OrganizationCollectionViaOrganizationRoleUser":
					this.OrganizationCollectionViaOrganizationRoleUser.IsReadOnly = false;
					this.OrganizationCollectionViaOrganizationRoleUser.Add((OrganizationEntity)entity);
					this.OrganizationCollectionViaOrganizationRoleUser.IsReadOnly = true;
					break;
				case "RoleCollectionViaOrganizationRoleUser":
					this.RoleCollectionViaOrganizationRoleUser.IsReadOnly = false;
					this.RoleCollectionViaOrganizationRoleUser.Add((RoleEntity)entity);
					this.RoleCollectionViaOrganizationRoleUser.IsReadOnly = true;
					break;
				case "SystemUserInfo":
					this.SystemUserInfo = (SystemUserInfoEntity)entity;
					break;
				case "UserLogin":
					this.UserLogin = (UserLoginEntity)entity;
					break;
				case "UserNpiInfo":
					this.UserNpiInfo = (UserNpiInfoEntity)entity;
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
			return UserEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(UserEntity.Relations.AddressEntityUsingHomeAddressId);
					break;
				case "OrganizationRoleUser__":
					toReturn.Add(UserEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(UserEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "Role":
					toReturn.Add(UserEntity.Relations.RoleEntityUsingDefaultRoleId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(UserEntity.Relations.OrganizationRoleUserEntityUsingUserId);
					break;
				case "OrganizationCollectionViaOrganizationRoleUser":
					toReturn.Add(UserEntity.Relations.OrganizationRoleUserEntityUsingUserId, "UserEntity__", "OrganizationRoleUser_", JoinHint.None);
					toReturn.Add(OrganizationRoleUserEntity.Relations.OrganizationEntityUsingOrganizationId, "OrganizationRoleUser_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaOrganizationRoleUser":
					toReturn.Add(UserEntity.Relations.OrganizationRoleUserEntityUsingUserId, "UserEntity__", "OrganizationRoleUser_", JoinHint.None);
					toReturn.Add(OrganizationRoleUserEntity.Relations.RoleEntityUsingRoleId, "OrganizationRoleUser_", string.Empty, JoinHint.None);
					break;
				case "SystemUserInfo":
					toReturn.Add(UserEntity.Relations.SystemUserInfoEntityUsingUserId);
					break;
				case "UserLogin":
					toReturn.Add(UserEntity.Relations.UserLoginEntityUsingUserLoginId);
					break;
				case "UserNpiInfo":
					toReturn.Add(UserEntity.Relations.UserNpiInfoEntityUsingUserId);
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
				case "OrganizationRoleUser__":
					SetupSyncOrganizationRoleUser__(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "Role":
					SetupSyncRole(relatedEntity);
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser.Add((OrganizationRoleUserEntity)relatedEntity);
					break;
				case "SystemUserInfo":
					SetupSyncSystemUserInfo(relatedEntity);
					break;
				case "UserLogin":
					SetupSyncUserLogin(relatedEntity);
					break;
				case "UserNpiInfo":
					SetupSyncUserNpiInfo(relatedEntity);
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
				case "OrganizationRoleUser__":
					DesetupSyncOrganizationRoleUser__(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "Role":
					DesetupSyncRole(false, true);
					break;
				case "OrganizationRoleUser":
					base.PerformRelatedEntityRemoval(this.OrganizationRoleUser, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SystemUserInfo":
					DesetupSyncSystemUserInfo(false, true);
					break;
				case "UserLogin":
					DesetupSyncUserLogin(false, true);
					break;
				case "UserNpiInfo":
					DesetupSyncUserNpiInfo(false, true);
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
			if(_systemUserInfo!=null)
			{
				toReturn.Add(_systemUserInfo);
			}

			if(_userLogin!=null)
			{
				toReturn.Add(_userLogin);
			}

			if(_userNpiInfo!=null)
			{
				toReturn.Add(_userNpiInfo);
			}

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
			if(_organizationRoleUser__!=null)
			{
				toReturn.Add(_organizationRoleUser__);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
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
			toReturn.Add(this.OrganizationRoleUser);

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
				info.AddValue("_organizationRoleUser", ((_organizationRoleUser!=null) && (_organizationRoleUser.Count>0) && !this.MarkedForDeletion)?_organizationRoleUser:null);
				info.AddValue("_organizationCollectionViaOrganizationRoleUser", ((_organizationCollectionViaOrganizationRoleUser!=null) && (_organizationCollectionViaOrganizationRoleUser.Count>0) && !this.MarkedForDeletion)?_organizationCollectionViaOrganizationRoleUser:null);
				info.AddValue("_roleCollectionViaOrganizationRoleUser", ((_roleCollectionViaOrganizationRoleUser!=null) && (_roleCollectionViaOrganizationRoleUser.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaOrganizationRoleUser:null);
				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_organizationRoleUser__", (!this.MarkedForDeletion?_organizationRoleUser__:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_role", (!this.MarkedForDeletion?_role:null));
				info.AddValue("_systemUserInfo", (!this.MarkedForDeletion?_systemUserInfo:null));
				info.AddValue("_userLogin", (!this.MarkedForDeletion?_userLogin:null));
				info.AddValue("_userNpiInfo", (!this.MarkedForDeletion?_userNpiInfo:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(UserFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(UserFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new UserRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.UserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationCollectionViaOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationCollectionViaOrganizationRoleUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.UserId, "UserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaOrganizationRoleUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.UserId, "UserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.HomeAddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Role' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.DefaultRoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'SystemUserInfo' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemUserInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemUserInfoFields.UserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'UserLogin' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserLogin()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserLoginFields.UserLoginId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'UserNpiInfo' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserNpiInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserNpiInfoFields.UserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.UserEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._organizationRoleUser);
			collectionsQueue.Enqueue(this._organizationCollectionViaOrganizationRoleUser);
			collectionsQueue.Enqueue(this._roleCollectionViaOrganizationRoleUser);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._organizationRoleUser = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationCollectionViaOrganizationRoleUser = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaOrganizationRoleUser = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._organizationRoleUser != null)
			{
				return true;
			}
			if (this._organizationCollectionViaOrganizationRoleUser != null)
			{
				return true;
			}
			if (this._roleCollectionViaOrganizationRoleUser != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
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
			toReturn.Add("Address", _address);
			toReturn.Add("OrganizationRoleUser__", _organizationRoleUser__);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("Role", _role);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("OrganizationCollectionViaOrganizationRoleUser", _organizationCollectionViaOrganizationRoleUser);
			toReturn.Add("RoleCollectionViaOrganizationRoleUser", _roleCollectionViaOrganizationRoleUser);
			toReturn.Add("SystemUserInfo", _systemUserInfo);
			toReturn.Add("UserLogin", _userLogin);
			toReturn.Add("UserNpiInfo", _userNpiInfo);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_organizationCollectionViaOrganizationRoleUser!=null)
			{
				_organizationCollectionViaOrganizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaOrganizationRoleUser!=null)
			{
				_roleCollectionViaOrganizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser__!=null)
			{
				_organizationRoleUser__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_role!=null)
			{
				_role.ActiveContext = base.ActiveContext;
			}
			if(_systemUserInfo!=null)
			{
				_systemUserInfo.ActiveContext = base.ActiveContext;
			}
			if(_userLogin!=null)
			{
				_userLogin.ActiveContext = base.ActiveContext;
			}
			if(_userNpiInfo!=null)
			{
				_userNpiInfo.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_organizationRoleUser = null;
			_organizationCollectionViaOrganizationRoleUser = null;
			_roleCollectionViaOrganizationRoleUser = null;
			_address = null;
			_organizationRoleUser__ = null;
			_organizationRoleUser_ = null;
			_role = null;
			_systemUserInfo = null;
			_userLogin = null;
			_userNpiInfo = null;
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

			_fieldsCustomProperties.Add("UserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HomeAddressId", fieldHashtable);
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
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Picture", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dob", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ssn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TempUserName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultRoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOfficeExtension", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", UserEntity.Relations.AddressEntityUsingHomeAddressId, true, signalRelatedEntity, "User", resetFKFields, new int[] { (int)UserFieldIndex.HomeAddressId } );		
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
				base.PerformSetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", UserEntity.Relations.AddressEntityUsingHomeAddressId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", UserEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "User__", resetFKFields, new int[] { (int)UserFieldIndex.ModifiedByOrgRoleUserId } );		
			_organizationRoleUser__ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser__(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser__!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser__(true, true);
				_organizationRoleUser__ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", UserEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", UserEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "User_", resetFKFields, new int[] { (int)UserFieldIndex.CreatedByOrgRoleUserId } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", UserEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", UserEntity.Relations.RoleEntityUsingDefaultRoleId, true, signalRelatedEntity, "User", resetFKFields, new int[] { (int)UserFieldIndex.DefaultRoleId } );		
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
				base.PerformSetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", UserEntity.Relations.RoleEntityUsingDefaultRoleId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _systemUserInfo</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSystemUserInfo(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _systemUserInfo, new PropertyChangedEventHandler( OnSystemUserInfoPropertyChanged ), "SystemUserInfo", UserEntity.Relations.SystemUserInfoEntityUsingUserId, false, signalRelatedEntity, "User", false, new int[] { (int)UserFieldIndex.UserId } );
			_systemUserInfo = null;
		}
		
		/// <summary> setups the sync logic for member _systemUserInfo</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSystemUserInfo(IEntity2 relatedEntity)
		{
			if(_systemUserInfo!=relatedEntity)
			{
				DesetupSyncSystemUserInfo(true, true);
				_systemUserInfo = (SystemUserInfoEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _systemUserInfo, new PropertyChangedEventHandler( OnSystemUserInfoPropertyChanged ), "SystemUserInfo", UserEntity.Relations.SystemUserInfoEntityUsingUserId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSystemUserInfoPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _userLogin</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUserLogin(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _userLogin, new PropertyChangedEventHandler( OnUserLoginPropertyChanged ), "UserLogin", UserEntity.Relations.UserLoginEntityUsingUserLoginId, false, signalRelatedEntity, "User", false, new int[] { (int)UserFieldIndex.UserId } );
			_userLogin = null;
		}
		
		/// <summary> setups the sync logic for member _userLogin</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUserLogin(IEntity2 relatedEntity)
		{
			if(_userLogin!=relatedEntity)
			{
				DesetupSyncUserLogin(true, true);
				_userLogin = (UserLoginEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _userLogin, new PropertyChangedEventHandler( OnUserLoginPropertyChanged ), "UserLogin", UserEntity.Relations.UserLoginEntityUsingUserLoginId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserLoginPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _userNpiInfo</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUserNpiInfo(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _userNpiInfo, new PropertyChangedEventHandler( OnUserNpiInfoPropertyChanged ), "UserNpiInfo", UserEntity.Relations.UserNpiInfoEntityUsingUserId, false, signalRelatedEntity, "User", false, new int[] { (int)UserFieldIndex.UserId } );
			_userNpiInfo = null;
		}
		
		/// <summary> setups the sync logic for member _userNpiInfo</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUserNpiInfo(IEntity2 relatedEntity)
		{
			if(_userNpiInfo!=relatedEntity)
			{
				DesetupSyncUserNpiInfo(true, true);
				_userNpiInfo = (UserNpiInfoEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _userNpiInfo, new PropertyChangedEventHandler( OnUserNpiInfoPropertyChanged ), "UserNpiInfo", UserEntity.Relations.UserNpiInfoEntityUsingUserId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserNpiInfoPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this UserEntity</param>
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
		public  static UserRelations Relations
		{
			get	{ return new UserRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationCollectionViaOrganizationRoleUser
		{
			get
			{
				IEntityRelation intermediateRelation = UserEntity.Relations.OrganizationRoleUserEntityUsingUserId;
				intermediateRelation.SetAliases(string.Empty, "OrganizationRoleUser_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, GetRelationsForField("OrganizationCollectionViaOrganizationRoleUser"), null, "OrganizationCollectionViaOrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaOrganizationRoleUser
		{
			get
			{
				IEntityRelation intermediateRelation = UserEntity.Relations.OrganizationRoleUserEntityUsingUserId;
				intermediateRelation.SetAliases(string.Empty, "OrganizationRoleUser_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaOrganizationRoleUser"), null, "RoleCollectionViaOrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Address")[0], (int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser__")[0], (int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Role")[0], (int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, null, null, "Role", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SystemUserInfo' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemUserInfo
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SystemUserInfoEntityFactory))),
					(IEntityRelation)GetRelationsForField("SystemUserInfo")[0], (int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.SystemUserInfoEntity, 0, null, null, null, null, "SystemUserInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UserLogin' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserLogin
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserLoginEntityFactory))),
					(IEntityRelation)GetRelationsForField("UserLogin")[0], (int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.UserLoginEntity, 0, null, null, null, null, "UserLogin", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UserNpiInfo' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserNpiInfo
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserNpiInfoEntityFactory))),
					(IEntityRelation)GetRelationsForField("UserNpiInfo")[0], (int)Falcon.Data.EntityType.UserEntity, (int)Falcon.Data.EntityType.UserNpiInfoEntity, 0, null, null, null, null, "UserNpiInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return UserEntity.CustomProperties;}
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
			get { return UserEntity.FieldsCustomProperties;}
		}

		/// <summary> The UserId property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."UserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 UserId
		{
			get { return (System.Int64)GetValue((int)UserFieldIndex.UserId, true); }
			set	{ SetValue((int)UserFieldIndex.UserId, value); }
		}

		/// <summary> The FirstName property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.FirstName, true); }
			set	{ SetValue((int)UserFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."MiddleName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.MiddleName, true); }
			set	{ SetValue((int)UserFieldIndex.MiddleName, value); }
		}

		/// <summary> The LastName property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.LastName, true); }
			set	{ SetValue((int)UserFieldIndex.LastName, value); }
		}

		/// <summary> The HomeAddressId property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."HomeAddressID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HomeAddressId
		{
			get { return (System.Int64)GetValue((int)UserFieldIndex.HomeAddressId, true); }
			set	{ SetValue((int)UserFieldIndex.HomeAddressId, value); }
		}

		/// <summary> The PhoneOffice property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."PhoneOffice"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOffice
		{
			get { return (System.String)GetValue((int)UserFieldIndex.PhoneOffice, true); }
			set	{ SetValue((int)UserFieldIndex.PhoneOffice, value); }
		}

		/// <summary> The PhoneCell property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."PhoneCell"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)UserFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)UserFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneHome property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."PhoneHome"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneHome
		{
			get { return (System.String)GetValue((int)UserFieldIndex.PhoneHome, true); }
			set	{ SetValue((int)UserFieldIndex.PhoneHome, value); }
		}

		/// <summary> The Email1 property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."EMail1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email1
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Email1, true); }
			set	{ SetValue((int)UserFieldIndex.Email1, value); }
		}

		/// <summary> The Email2 property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."EMail2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email2
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Email2, true); }
			set	{ SetValue((int)UserFieldIndex.Email2, value); }
		}

		/// <summary> The Picture property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."Picture"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Picture
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Picture, true); }
			set	{ SetValue((int)UserFieldIndex.Picture, value); }
		}

		/// <summary> The Dob property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."DOB"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Dob
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.Dob, false); }
			set	{ SetValue((int)UserFieldIndex.Dob, value); }
		}

		/// <summary> The Ssn property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."SSN"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Ssn
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Ssn, true); }
			set	{ SetValue((int)UserFieldIndex.Ssn, value); }
		}

		/// <summary> The DateCreated property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)UserFieldIndex.DateCreated, true); }
			set	{ SetValue((int)UserFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)UserFieldIndex.DateModified, true); }
			set	{ SetValue((int)UserFieldIndex.DateModified, value); }
		}

		/// <summary> The TempUserName property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."TempUserName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TempUserName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.TempUserName, true); }
			set	{ SetValue((int)UserFieldIndex.TempUserName, value); }
		}

		/// <summary> The IsActive property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)UserFieldIndex.IsActive, true); }
			set	{ SetValue((int)UserFieldIndex.IsActive, value); }
		}

		/// <summary> The DefaultRoleId property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."DefaultRoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DefaultRoleId
		{
			get { return (Nullable<System.Int64>)GetValue((int)UserFieldIndex.DefaultRoleId, false); }
			set	{ SetValue((int)UserFieldIndex.DefaultRoleId, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)UserFieldIndex.CreatedByOrgRoleUserId, false); }
			set	{ SetValue((int)UserFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)UserFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)UserFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> The PhoneOfficeExtension property of the Entity User<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUser"."PhoneOfficeExtension"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOfficeExtension
		{
			get { return (System.String)GetValue((int)UserFieldIndex.PhoneOfficeExtension, true); }
			set	{ SetValue((int)UserFieldIndex.PhoneOfficeExtension, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUser
		{
			get
			{
				if(_organizationRoleUser==null)
				{
					_organizationRoleUser = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUser.SetContainingEntityInfo(this, "User");
				}
				return _organizationRoleUser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> OrganizationCollectionViaOrganizationRoleUser
		{
			get
			{
				if(_organizationCollectionViaOrganizationRoleUser==null)
				{
					_organizationCollectionViaOrganizationRoleUser = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organizationCollectionViaOrganizationRoleUser.IsReadOnly=true;
				}
				return _organizationCollectionViaOrganizationRoleUser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaOrganizationRoleUser
		{
			get
			{
				if(_roleCollectionViaOrganizationRoleUser==null)
				{
					_roleCollectionViaOrganizationRoleUser = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaOrganizationRoleUser.IsReadOnly=true;
				}
				return _roleCollectionViaOrganizationRoleUser;
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
							_address.UnsetRelatedEntity(this, "User");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "User");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser__
		{
			get
			{
				return _organizationRoleUser__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser__(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser__ != null)
						{
							_organizationRoleUser__.UnsetRelatedEntity(this, "User__");
						}
					}
					else
					{
						if(_organizationRoleUser__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "User__");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "User_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "User_");
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
							_role.UnsetRelatedEntity(this, "User");
						}
					}
					else
					{
						if(_role!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "User");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'SystemUserInfoEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual SystemUserInfoEntity SystemUserInfo
		{
			get
			{
				return _systemUserInfo;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncSystemUserInfo(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "User");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_systemUserInfo !=null);
						DesetupSyncSystemUserInfo(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("SystemUserInfo");
						}
					}
					else
					{
						if(_systemUserInfo!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "User");
							SetupSyncSystemUserInfo(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserLoginEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserLoginEntity UserLogin
		{
			get
			{
				return _userLogin;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncUserLogin(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "User");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_userLogin !=null);
						DesetupSyncUserLogin(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("UserLogin");
						}
					}
					else
					{
						if(_userLogin!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "User");
							SetupSyncUserLogin(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserNpiInfoEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserNpiInfoEntity UserNpiInfo
		{
			get
			{
				return _userNpiInfo;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncUserNpiInfo(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "User");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_userNpiInfo !=null);
						DesetupSyncUserNpiInfo(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("UserNpiInfo");
						}
					}
					else
					{
						if(_userNpiInfo!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "User");
							SetupSyncUserNpiInfo(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.UserEntity; }
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
