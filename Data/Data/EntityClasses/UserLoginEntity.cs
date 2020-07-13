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
	/// Entity class which represents the entity 'UserLogin'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class UserLoginEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<PasswordChangelogEntity> _passwordChangelog;
		private EntityCollection<SafeComputerHistoryEntity> _safeComputerHistory;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPasswordChangelog;

		private LoginOtpEntity _loginOtp;
		private LoginSettingsEntity _loginSettings;
		private UserEntity _user;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name PasswordChangelog</summary>
			public static readonly string PasswordChangelog = "PasswordChangelog";
			/// <summary>Member name SafeComputerHistory</summary>
			public static readonly string SafeComputerHistory = "SafeComputerHistory";
			/// <summary>Member name OrganizationRoleUserCollectionViaPasswordChangelog</summary>
			public static readonly string OrganizationRoleUserCollectionViaPasswordChangelog = "OrganizationRoleUserCollectionViaPasswordChangelog";
			/// <summary>Member name LoginOtp</summary>
			public static readonly string LoginOtp = "LoginOtp";
			/// <summary>Member name LoginSettings</summary>
			public static readonly string LoginSettings = "LoginSettings";
			/// <summary>Member name User</summary>
			public static readonly string User = "User";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static UserLoginEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public UserLoginEntity():base("UserLoginEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public UserLoginEntity(IEntityFields2 fields):base("UserLoginEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this UserLoginEntity</param>
		public UserLoginEntity(IValidator validator):base("UserLoginEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="userLoginId">PK value for UserLogin which data should be fetched into this UserLogin object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UserLoginEntity(System.Int64 userLoginId):base("UserLoginEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.UserLoginId = userLoginId;
		}

		/// <summary> CTor</summary>
		/// <param name="userLoginId">PK value for UserLogin which data should be fetched into this UserLogin object</param>
		/// <param name="validator">The custom validator object for this UserLoginEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UserLoginEntity(System.Int64 userLoginId, IValidator validator):base("UserLoginEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.UserLoginId = userLoginId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected UserLoginEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_passwordChangelog = (EntityCollection<PasswordChangelogEntity>)info.GetValue("_passwordChangelog", typeof(EntityCollection<PasswordChangelogEntity>));
				_safeComputerHistory = (EntityCollection<SafeComputerHistoryEntity>)info.GetValue("_safeComputerHistory", typeof(EntityCollection<SafeComputerHistoryEntity>));
				_organizationRoleUserCollectionViaPasswordChangelog = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPasswordChangelog", typeof(EntityCollection<OrganizationRoleUserEntity>));

				_loginOtp = (LoginOtpEntity)info.GetValue("_loginOtp", typeof(LoginOtpEntity));
				if(_loginOtp!=null)
				{
					_loginOtp.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_loginSettings = (LoginSettingsEntity)info.GetValue("_loginSettings", typeof(LoginSettingsEntity));
				if(_loginSettings!=null)
				{
					_loginSettings.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_user = (UserEntity)info.GetValue("_user", typeof(UserEntity));
				if(_user!=null)
				{
					_user.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((UserLoginFieldIndex)fieldIndex)
			{
				case UserLoginFieldIndex.UserLoginId:
					DesetupSyncUser(true, false);
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

				case "PasswordChangelog":
					this.PasswordChangelog.Add((PasswordChangelogEntity)entity);
					break;
				case "SafeComputerHistory":
					this.SafeComputerHistory.Add((SafeComputerHistoryEntity)entity);
					break;
				case "OrganizationRoleUserCollectionViaPasswordChangelog":
					this.OrganizationRoleUserCollectionViaPasswordChangelog.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPasswordChangelog.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPasswordChangelog.IsReadOnly = true;
					break;
				case "LoginOtp":
					this.LoginOtp = (LoginOtpEntity)entity;
					break;
				case "LoginSettings":
					this.LoginSettings = (LoginSettingsEntity)entity;
					break;
				case "User":
					this.User = (UserEntity)entity;
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
			return UserLoginEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "PasswordChangelog":
					toReturn.Add(UserLoginEntity.Relations.PasswordChangelogEntityUsingUserLoginId);
					break;
				case "SafeComputerHistory":
					toReturn.Add(UserLoginEntity.Relations.SafeComputerHistoryEntityUsingUserLoginId);
					break;
				case "OrganizationRoleUserCollectionViaPasswordChangelog":
					toReturn.Add(UserLoginEntity.Relations.PasswordChangelogEntityUsingUserLoginId, "UserLoginEntity__", "PasswordChangelog_", JoinHint.None);
					toReturn.Add(PasswordChangelogEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "PasswordChangelog_", string.Empty, JoinHint.None);
					break;
				case "LoginOtp":
					toReturn.Add(UserLoginEntity.Relations.LoginOtpEntityUsingUserLoginId);
					break;
				case "LoginSettings":
					toReturn.Add(UserLoginEntity.Relations.LoginSettingsEntityUsingUserLoginId);
					break;
				case "User":
					toReturn.Add(UserLoginEntity.Relations.UserEntityUsingUserLoginId);
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

				case "PasswordChangelog":
					this.PasswordChangelog.Add((PasswordChangelogEntity)relatedEntity);
					break;
				case "SafeComputerHistory":
					this.SafeComputerHistory.Add((SafeComputerHistoryEntity)relatedEntity);
					break;
				case "LoginOtp":
					SetupSyncLoginOtp(relatedEntity);
					break;
				case "LoginSettings":
					SetupSyncLoginSettings(relatedEntity);
					break;
				case "User":
					SetupSyncUser(relatedEntity);
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

				case "PasswordChangelog":
					base.PerformRelatedEntityRemoval(this.PasswordChangelog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SafeComputerHistory":
					base.PerformRelatedEntityRemoval(this.SafeComputerHistory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "LoginOtp":
					DesetupSyncLoginOtp(false, true);
					break;
				case "LoginSettings":
					DesetupSyncLoginSettings(false, true);
					break;
				case "User":
					DesetupSyncUser(false, true);
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
			if(_loginOtp!=null)
			{
				toReturn.Add(_loginOtp);
			}

			if(_loginSettings!=null)
			{
				toReturn.Add(_loginSettings);
			}



			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();





			if(_user!=null)
			{
				toReturn.Add(_user);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.PasswordChangelog);
			toReturn.Add(this.SafeComputerHistory);

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
				info.AddValue("_passwordChangelog", ((_passwordChangelog!=null) && (_passwordChangelog.Count>0) && !this.MarkedForDeletion)?_passwordChangelog:null);
				info.AddValue("_safeComputerHistory", ((_safeComputerHistory!=null) && (_safeComputerHistory.Count>0) && !this.MarkedForDeletion)?_safeComputerHistory:null);
				info.AddValue("_organizationRoleUserCollectionViaPasswordChangelog", ((_organizationRoleUserCollectionViaPasswordChangelog!=null) && (_organizationRoleUserCollectionViaPasswordChangelog.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPasswordChangelog:null);

				info.AddValue("_loginOtp", (!this.MarkedForDeletion?_loginOtp:null));
				info.AddValue("_loginSettings", (!this.MarkedForDeletion?_loginSettings:null));
				info.AddValue("_user", (!this.MarkedForDeletion?_user:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// UserName .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCUserName()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)UserLoginFieldIndex.UserName], null, ComparisonOperator.Equal)); 
			return filter;
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(UserLoginFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(UserLoginFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new UserLoginRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PasswordChangelog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPasswordChangelog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PasswordChangelogFields.UserLoginId, null, ComparisonOperator.Equal, this.UserLoginId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SafeComputerHistory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSafeComputerHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SafeComputerHistoryFields.UserLoginId, null, ComparisonOperator.Equal, this.UserLoginId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPasswordChangelog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPasswordChangelog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserLoginFields.UserLoginId, null, ComparisonOperator.Equal, this.UserLoginId, "UserLoginEntity__"));
			return bucket;
		}


		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'LoginOtp' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLoginOtp()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LoginOtpFields.UserLoginId, null, ComparisonOperator.Equal, this.UserLoginId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'LoginSettings' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLoginSettings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LoginSettingsFields.UserLoginId, null, ComparisonOperator.Equal, this.UserLoginId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.UserLoginId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.UserLoginEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(UserLoginEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._passwordChangelog);
			collectionsQueue.Enqueue(this._safeComputerHistory);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPasswordChangelog);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._passwordChangelog = (EntityCollection<PasswordChangelogEntity>) collectionsQueue.Dequeue();
			this._safeComputerHistory = (EntityCollection<SafeComputerHistoryEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPasswordChangelog = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._passwordChangelog != null)
			{
				return true;
			}
			if (this._safeComputerHistory != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPasswordChangelog != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PasswordChangelogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PasswordChangelogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SafeComputerHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SafeComputerHistoryEntityFactory))) : null);
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

			toReturn.Add("PasswordChangelog", _passwordChangelog);
			toReturn.Add("SafeComputerHistory", _safeComputerHistory);
			toReturn.Add("OrganizationRoleUserCollectionViaPasswordChangelog", _organizationRoleUserCollectionViaPasswordChangelog);
			toReturn.Add("LoginOtp", _loginOtp);
			toReturn.Add("LoginSettings", _loginSettings);
			toReturn.Add("User", _user);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_passwordChangelog!=null)
			{
				_passwordChangelog.ActiveContext = base.ActiveContext;
			}
			if(_safeComputerHistory!=null)
			{
				_safeComputerHistory.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPasswordChangelog!=null)
			{
				_organizationRoleUserCollectionViaPasswordChangelog.ActiveContext = base.ActiveContext;
			}

			if(_loginOtp!=null)
			{
				_loginOtp.ActiveContext = base.ActiveContext;
			}
			if(_loginSettings!=null)
			{
				_loginSettings.ActiveContext = base.ActiveContext;
			}
			if(_user!=null)
			{
				_user.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_passwordChangelog = null;
			_safeComputerHistory = null;
			_organizationRoleUserCollectionViaPasswordChangelog = null;

			_loginOtp = null;
			_loginSettings = null;
			_user = null;
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

			_fieldsCustomProperties.Add("UserLoginId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UserName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Password", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsLocked", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LoginAttempts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastLogged", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UserSecurityQuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BrowserSessionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UserVerified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HintQuestion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HintAnswer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsSecurityQuestionVerified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResetPwdQueryString", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastLoginAttemptAt", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Salt", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastPasswordChangeDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTwoFactorAuthrequired", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _loginOtp</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLoginOtp(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _loginOtp, new PropertyChangedEventHandler( OnLoginOtpPropertyChanged ), "LoginOtp", UserLoginEntity.Relations.LoginOtpEntityUsingUserLoginId, false, signalRelatedEntity, "UserLogin", false, new int[] { (int)UserLoginFieldIndex.UserLoginId } );
			_loginOtp = null;
		}
		
		/// <summary> setups the sync logic for member _loginOtp</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLoginOtp(IEntity2 relatedEntity)
		{
			if(_loginOtp!=relatedEntity)
			{
				DesetupSyncLoginOtp(true, true);
				_loginOtp = (LoginOtpEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _loginOtp, new PropertyChangedEventHandler( OnLoginOtpPropertyChanged ), "LoginOtp", UserLoginEntity.Relations.LoginOtpEntityUsingUserLoginId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLoginOtpPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _loginSettings</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLoginSettings(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _loginSettings, new PropertyChangedEventHandler( OnLoginSettingsPropertyChanged ), "LoginSettings", UserLoginEntity.Relations.LoginSettingsEntityUsingUserLoginId, false, signalRelatedEntity, "UserLogin", false, new int[] { (int)UserLoginFieldIndex.UserLoginId } );
			_loginSettings = null;
		}
		
		/// <summary> setups the sync logic for member _loginSettings</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLoginSettings(IEntity2 relatedEntity)
		{
			if(_loginSettings!=relatedEntity)
			{
				DesetupSyncLoginSettings(true, true);
				_loginSettings = (LoginSettingsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _loginSettings, new PropertyChangedEventHandler( OnLoginSettingsPropertyChanged ), "LoginSettings", UserLoginEntity.Relations.LoginSettingsEntityUsingUserLoginId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLoginSettingsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _user</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _user, new PropertyChangedEventHandler( OnUserPropertyChanged ), "User", UserLoginEntity.Relations.UserEntityUsingUserLoginId, true, signalRelatedEntity, "UserLogin", false, new int[] { (int)UserLoginFieldIndex.UserLoginId } );
			_user = null;
		}
		
		/// <summary> setups the sync logic for member _user</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUser(IEntity2 relatedEntity)
		{
			if(_user!=relatedEntity)
			{
				DesetupSyncUser(true, true);
				_user = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _user, new PropertyChangedEventHandler( OnUserPropertyChanged ), "User", UserLoginEntity.Relations.UserEntityUsingUserLoginId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this UserLoginEntity</param>
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
		public  static UserLoginRelations Relations
		{
			get	{ return new UserLoginRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PasswordChangelog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPasswordChangelog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PasswordChangelogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PasswordChangelogEntityFactory))),
					(IEntityRelation)GetRelationsForField("PasswordChangelog")[0], (int)Falcon.Data.EntityType.UserLoginEntity, (int)Falcon.Data.EntityType.PasswordChangelogEntity, 0, null, null, null, null, "PasswordChangelog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SafeComputerHistory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSafeComputerHistory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SafeComputerHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SafeComputerHistoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("SafeComputerHistory")[0], (int)Falcon.Data.EntityType.UserLoginEntity, (int)Falcon.Data.EntityType.SafeComputerHistoryEntity, 0, null, null, null, null, "SafeComputerHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPasswordChangelog
		{
			get
			{
				IEntityRelation intermediateRelation = UserLoginEntity.Relations.PasswordChangelogEntityUsingUserLoginId;
				intermediateRelation.SetAliases(string.Empty, "PasswordChangelog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.UserLoginEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPasswordChangelog"), null, "OrganizationRoleUserCollectionViaPasswordChangelog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}


		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'LoginOtp' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLoginOtp
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LoginOtpEntityFactory))),
					(IEntityRelation)GetRelationsForField("LoginOtp")[0], (int)Falcon.Data.EntityType.UserLoginEntity, (int)Falcon.Data.EntityType.LoginOtpEntity, 0, null, null, null, null, "LoginOtp", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'LoginSettings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLoginSettings
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LoginSettingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("LoginSettings")[0], (int)Falcon.Data.EntityType.UserLoginEntity, (int)Falcon.Data.EntityType.LoginSettingsEntity, 0, null, null, null, null, "LoginSettings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("User")[0], (int)Falcon.Data.EntityType.UserLoginEntity, (int)Falcon.Data.EntityType.UserEntity, 0, null, null, null, null, "User", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return UserLoginEntity.CustomProperties;}
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
			get { return UserLoginEntity.FieldsCustomProperties;}
		}

		/// <summary> The UserLoginId property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."UserLoginID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 UserLoginId
		{
			get { return (System.Int64)GetValue((int)UserLoginFieldIndex.UserLoginId, true); }
			set	{ SetValue((int)UserLoginFieldIndex.UserLoginId, value); }
		}

		/// <summary> The UserName property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."UserName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String UserName
		{
			get { return (System.String)GetValue((int)UserLoginFieldIndex.UserName, true); }
			set	{ SetValue((int)UserLoginFieldIndex.UserName, value); }
		}

		/// <summary> The Password property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."Password"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Password
		{
			get { return (System.String)GetValue((int)UserLoginFieldIndex.Password, true); }
			set	{ SetValue((int)UserLoginFieldIndex.Password, value); }
		}

		/// <summary> The IsActive property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)UserLoginFieldIndex.IsActive, true); }
			set	{ SetValue((int)UserLoginFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)UserLoginFieldIndex.DateCreated, true); }
			set	{ SetValue((int)UserLoginFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)UserLoginFieldIndex.DateModified, true); }
			set	{ SetValue((int)UserLoginFieldIndex.DateModified, value); }
		}

		/// <summary> The IsLocked property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."IsLocked"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsLocked
		{
			get { return (System.Boolean)GetValue((int)UserLoginFieldIndex.IsLocked, true); }
			set	{ SetValue((int)UserLoginFieldIndex.IsLocked, value); }
		}

		/// <summary> The LoginAttempts property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."LoginAttempts"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal LoginAttempts
		{
			get { return (System.Decimal)GetValue((int)UserLoginFieldIndex.LoginAttempts, true); }
			set	{ SetValue((int)UserLoginFieldIndex.LoginAttempts, value); }
		}

		/// <summary> The LastLogged property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."LastLogged"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastLogged
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserLoginFieldIndex.LastLogged, false); }
			set	{ SetValue((int)UserLoginFieldIndex.LastLogged, value); }
		}

		/// <summary> The UserSecurityQuestionId property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."UserSecurityQuestionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UserSecurityQuestionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)UserLoginFieldIndex.UserSecurityQuestionId, false); }
			set	{ SetValue((int)UserLoginFieldIndex.UserSecurityQuestionId, value); }
		}

		/// <summary> The BrowserSessionId property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."BrowserSessionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BrowserSessionId
		{
			get { return (System.String)GetValue((int)UserLoginFieldIndex.BrowserSessionId, true); }
			set	{ SetValue((int)UserLoginFieldIndex.BrowserSessionId, value); }
		}

		/// <summary> The UserVerified property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."UserVerified"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean UserVerified
		{
			get { return (System.Boolean)GetValue((int)UserLoginFieldIndex.UserVerified, true); }
			set	{ SetValue((int)UserLoginFieldIndex.UserVerified, value); }
		}

		/// <summary> The HintQuestion property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."HintQuestion"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String HintQuestion
		{
			get { return (System.String)GetValue((int)UserLoginFieldIndex.HintQuestion, true); }
			set	{ SetValue((int)UserLoginFieldIndex.HintQuestion, value); }
		}

		/// <summary> The HintAnswer property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."HintAnswer"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String HintAnswer
		{
			get { return (System.String)GetValue((int)UserLoginFieldIndex.HintAnswer, true); }
			set	{ SetValue((int)UserLoginFieldIndex.HintAnswer, value); }
		}

		/// <summary> The IsSecurityQuestionVerified property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."IsSecurityQuestionVerified"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsSecurityQuestionVerified
		{
			get { return (System.Boolean)GetValue((int)UserLoginFieldIndex.IsSecurityQuestionVerified, true); }
			set	{ SetValue((int)UserLoginFieldIndex.IsSecurityQuestionVerified, value); }
		}

		/// <summary> The ResetPwdQueryString property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."ResetPwdQueryString"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ResetPwdQueryString
		{
			get { return (System.String)GetValue((int)UserLoginFieldIndex.ResetPwdQueryString, true); }
			set	{ SetValue((int)UserLoginFieldIndex.ResetPwdQueryString, value); }
		}

		/// <summary> The LastLoginAttemptAt property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."LastLoginAttemptAt"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastLoginAttemptAt
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserLoginFieldIndex.LastLoginAttemptAt, false); }
			set	{ SetValue((int)UserLoginFieldIndex.LastLoginAttemptAt, value); }
		}

		/// <summary> The Salt property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."Salt"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 64<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Salt
		{
			get { return (System.String)GetValue((int)UserLoginFieldIndex.Salt, true); }
			set	{ SetValue((int)UserLoginFieldIndex.Salt, value); }
		}

		/// <summary> The LastPasswordChangeDate property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."LastPasswordChangeDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime LastPasswordChangeDate
		{
			get { return (System.DateTime)GetValue((int)UserLoginFieldIndex.LastPasswordChangeDate, true); }
			set	{ SetValue((int)UserLoginFieldIndex.LastPasswordChangeDate, value); }
		}

		/// <summary> The IsTwoFactorAuthrequired property of the Entity UserLogin<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUserLogin"."IsTwoFactorAuthrequired"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsTwoFactorAuthrequired
		{
			get { return (Nullable<System.Boolean>)GetValue((int)UserLoginFieldIndex.IsTwoFactorAuthrequired, false); }
			set	{ SetValue((int)UserLoginFieldIndex.IsTwoFactorAuthrequired, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PasswordChangelogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PasswordChangelogEntity))]
		public virtual EntityCollection<PasswordChangelogEntity> PasswordChangelog
		{
			get
			{
				if(_passwordChangelog==null)
				{
					_passwordChangelog = new EntityCollection<PasswordChangelogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PasswordChangelogEntityFactory)));
					_passwordChangelog.SetContainingEntityInfo(this, "UserLogin");
				}
				return _passwordChangelog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SafeComputerHistoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SafeComputerHistoryEntity))]
		public virtual EntityCollection<SafeComputerHistoryEntity> SafeComputerHistory
		{
			get
			{
				if(_safeComputerHistory==null)
				{
					_safeComputerHistory = new EntityCollection<SafeComputerHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SafeComputerHistoryEntityFactory)));
					_safeComputerHistory.SetContainingEntityInfo(this, "UserLogin");
				}
				return _safeComputerHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPasswordChangelog
		{
			get
			{
				if(_organizationRoleUserCollectionViaPasswordChangelog==null)
				{
					_organizationRoleUserCollectionViaPasswordChangelog = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPasswordChangelog.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPasswordChangelog;
			}
		}


		/// <summary> Gets / sets related entity of type 'LoginOtpEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LoginOtpEntity LoginOtp
		{
			get
			{
				return _loginOtp;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLoginOtp(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "UserLogin");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_loginOtp !=null);
						DesetupSyncLoginOtp(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("LoginOtp");
						}
					}
					else
					{
						if(_loginOtp!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "UserLogin");
							SetupSyncLoginOtp(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LoginSettingsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LoginSettingsEntity LoginSettings
		{
			get
			{
				return _loginSettings;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLoginSettings(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "UserLogin");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_loginSettings !=null);
						DesetupSyncLoginSettings(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("LoginSettings");
						}
					}
					else
					{
						if(_loginSettings!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "UserLogin");
							SetupSyncLoginSettings(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity User
		{
			get
			{
				return _user;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncUser(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "UserLogin");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_user !=null);
						DesetupSyncUser(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("User");
						}
					}
					else
					{
						if(_user!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "UserLogin");
							SetupSyncUser(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.UserLoginEntity; }
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
