///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:25 AM
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
	/// Entity class which represents the entity 'Pvuser'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PvuserEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<PrintVendorPvuserEntity> _printVendorPvuser;
		private EntityCollection<PrintVendorEntity> _printVendorCollectionViaPrintVendorPvuser;
		private EntityCollection<RoleEntity> _roleCollectionViaPrintVendorPvuser;
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
			/// <summary>Member name User</summary>
			public static readonly string User = "User";
			/// <summary>Member name PrintVendorPvuser</summary>
			public static readonly string PrintVendorPvuser = "PrintVendorPvuser";
			/// <summary>Member name PrintVendorCollectionViaPrintVendorPvuser</summary>
			public static readonly string PrintVendorCollectionViaPrintVendorPvuser = "PrintVendorCollectionViaPrintVendorPvuser";
			/// <summary>Member name RoleCollectionViaPrintVendorPvuser</summary>
			public static readonly string RoleCollectionViaPrintVendorPvuser = "RoleCollectionViaPrintVendorPvuser";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PvuserEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PvuserEntity():base("PvuserEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PvuserEntity(IEntityFields2 fields):base("PvuserEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PvuserEntity</param>
		public PvuserEntity(IValidator validator):base("PvuserEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="pvuserId">PK value for Pvuser which data should be fetched into this Pvuser object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PvuserEntity(System.Int64 pvuserId):base("PvuserEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PvuserId = pvuserId;
		}

		/// <summary> CTor</summary>
		/// <param name="pvuserId">PK value for Pvuser which data should be fetched into this Pvuser object</param>
		/// <param name="validator">The custom validator object for this PvuserEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PvuserEntity(System.Int64 pvuserId, IValidator validator):base("PvuserEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PvuserId = pvuserId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PvuserEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_printVendorPvuser = (EntityCollection<PrintVendorPvuserEntity>)info.GetValue("_printVendorPvuser", typeof(EntityCollection<PrintVendorPvuserEntity>));
				_printVendorCollectionViaPrintVendorPvuser = (EntityCollection<PrintVendorEntity>)info.GetValue("_printVendorCollectionViaPrintVendorPvuser", typeof(EntityCollection<PrintVendorEntity>));
				_roleCollectionViaPrintVendorPvuser = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaPrintVendorPvuser", typeof(EntityCollection<RoleEntity>));
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
			switch((PvuserFieldIndex)fieldIndex)
			{
				case PvuserFieldIndex.UserId:
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
				case "User":
					this.User = (UserEntity)entity;
					break;
				case "PrintVendorPvuser":
					this.PrintVendorPvuser.Add((PrintVendorPvuserEntity)entity);
					break;
				case "PrintVendorCollectionViaPrintVendorPvuser":
					this.PrintVendorCollectionViaPrintVendorPvuser.IsReadOnly = false;
					this.PrintVendorCollectionViaPrintVendorPvuser.Add((PrintVendorEntity)entity);
					this.PrintVendorCollectionViaPrintVendorPvuser.IsReadOnly = true;
					break;
				case "RoleCollectionViaPrintVendorPvuser":
					this.RoleCollectionViaPrintVendorPvuser.IsReadOnly = false;
					this.RoleCollectionViaPrintVendorPvuser.Add((RoleEntity)entity);
					this.RoleCollectionViaPrintVendorPvuser.IsReadOnly = true;
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
			return PvuserEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "User":
					toReturn.Add(PvuserEntity.Relations.UserEntityUsingUserId);
					break;
				case "PrintVendorPvuser":
					toReturn.Add(PvuserEntity.Relations.PrintVendorPvuserEntityUsingPvuserId);
					break;
				case "PrintVendorCollectionViaPrintVendorPvuser":
					toReturn.Add(PvuserEntity.Relations.PrintVendorPvuserEntityUsingPvuserId, "PvuserEntity__", "PrintVendorPvuser_", JoinHint.None);
					toReturn.Add(PrintVendorPvuserEntity.Relations.PrintVendorEntityUsingPrintVendorId, "PrintVendorPvuser_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaPrintVendorPvuser":
					toReturn.Add(PvuserEntity.Relations.PrintVendorPvuserEntityUsingPvuserId, "PvuserEntity__", "PrintVendorPvuser_", JoinHint.None);
					toReturn.Add(PrintVendorPvuserEntity.Relations.RoleEntityUsingRoleId, "PrintVendorPvuser_", string.Empty, JoinHint.None);
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
				case "User":
					SetupSyncUser(relatedEntity);
					break;
				case "PrintVendorPvuser":
					this.PrintVendorPvuser.Add((PrintVendorPvuserEntity)relatedEntity);
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
				case "User":
					DesetupSyncUser(false, true);
					break;
				case "PrintVendorPvuser":
					base.PerformRelatedEntityRemoval(this.PrintVendorPvuser, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.PrintVendorPvuser);

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
				info.AddValue("_printVendorPvuser", ((_printVendorPvuser!=null) && (_printVendorPvuser.Count>0) && !this.MarkedForDeletion)?_printVendorPvuser:null);
				info.AddValue("_printVendorCollectionViaPrintVendorPvuser", ((_printVendorCollectionViaPrintVendorPvuser!=null) && (_printVendorCollectionViaPrintVendorPvuser.Count>0) && !this.MarkedForDeletion)?_printVendorCollectionViaPrintVendorPvuser:null);
				info.AddValue("_roleCollectionViaPrintVendorPvuser", ((_roleCollectionViaPrintVendorPvuser!=null) && (_roleCollectionViaPrintVendorPvuser.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaPrintVendorPvuser:null);
				info.AddValue("_user", (!this.MarkedForDeletion?_user:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PvuserFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PvuserFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PvuserRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PrintVendorPvuser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPrintVendorPvuser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PrintVendorPvuserFields.PvuserId, null, ComparisonOperator.Equal, this.PvuserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PrintVendor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPrintVendorCollectionViaPrintVendorPvuser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PrintVendorCollectionViaPrintVendorPvuser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PvuserFields.PvuserId, null, ComparisonOperator.Equal, this.PvuserId, "PvuserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaPrintVendorPvuser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaPrintVendorPvuser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PvuserFields.PvuserId, null, ComparisonOperator.Equal, this.PvuserId, "PvuserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.UserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.PvuserEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PvuserEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._printVendorPvuser);
			collectionsQueue.Enqueue(this._printVendorCollectionViaPrintVendorPvuser);
			collectionsQueue.Enqueue(this._roleCollectionViaPrintVendorPvuser);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._printVendorPvuser = (EntityCollection<PrintVendorPvuserEntity>) collectionsQueue.Dequeue();
			this._printVendorCollectionViaPrintVendorPvuser = (EntityCollection<PrintVendorEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaPrintVendorPvuser = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._printVendorPvuser != null)
			{
				return true;
			}
			if (this._printVendorCollectionViaPrintVendorPvuser != null)
			{
				return true;
			}
			if (this._roleCollectionViaPrintVendorPvuser != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PrintVendorPvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PrintVendorPvuserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PrintVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PrintVendorEntityFactory))) : null);
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
			toReturn.Add("User", _user);
			toReturn.Add("PrintVendorPvuser", _printVendorPvuser);
			toReturn.Add("PrintVendorCollectionViaPrintVendorPvuser", _printVendorCollectionViaPrintVendorPvuser);
			toReturn.Add("RoleCollectionViaPrintVendorPvuser", _roleCollectionViaPrintVendorPvuser);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_printVendorPvuser!=null)
			{
				_printVendorPvuser.ActiveContext = base.ActiveContext;
			}
			if(_printVendorCollectionViaPrintVendorPvuser!=null)
			{
				_printVendorCollectionViaPrintVendorPvuser.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaPrintVendorPvuser!=null)
			{
				_roleCollectionViaPrintVendorPvuser.ActiveContext = base.ActiveContext;
			}
			if(_user!=null)
			{
				_user.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_printVendorPvuser = null;
			_printVendorCollectionViaPrintVendorPvuser = null;
			_roleCollectionViaPrintVendorPvuser = null;
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

			_fieldsCustomProperties.Add("PvuserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _user</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _user, new PropertyChangedEventHandler( OnUserPropertyChanged ), "User", PvuserEntity.Relations.UserEntityUsingUserId, true, signalRelatedEntity, "Pvuser", resetFKFields, new int[] { (int)PvuserFieldIndex.UserId } );		
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
				base.PerformSetupSyncRelatedEntity( _user, new PropertyChangedEventHandler( OnUserPropertyChanged ), "User", PvuserEntity.Relations.UserEntityUsingUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this PvuserEntity</param>
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
		public  static PvuserRelations Relations
		{
			get	{ return new PvuserRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PrintVendorPvuser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPrintVendorPvuser
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PrintVendorPvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PrintVendorPvuserEntityFactory))),
					(IEntityRelation)GetRelationsForField("PrintVendorPvuser")[0], (int)HealthYes.Data.EntityType.PvuserEntity, (int)HealthYes.Data.EntityType.PrintVendorPvuserEntity, 0, null, null, null, null, "PrintVendorPvuser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PrintVendor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPrintVendorCollectionViaPrintVendorPvuser
		{
			get
			{
				IEntityRelation intermediateRelation = PvuserEntity.Relations.PrintVendorPvuserEntityUsingPvuserId;
				intermediateRelation.SetAliases(string.Empty, "PrintVendorPvuser_");
				return new PrefetchPathElement2(new EntityCollection<PrintVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PrintVendorEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.PvuserEntity, (int)HealthYes.Data.EntityType.PrintVendorEntity, 0, null, null, GetRelationsForField("PrintVendorCollectionViaPrintVendorPvuser"), null, "PrintVendorCollectionViaPrintVendorPvuser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaPrintVendorPvuser
		{
			get
			{
				IEntityRelation intermediateRelation = PvuserEntity.Relations.PrintVendorPvuserEntityUsingPvuserId;
				intermediateRelation.SetAliases(string.Empty, "PrintVendorPvuser_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.PvuserEntity, (int)HealthYes.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaPrintVendorPvuser"), null, "RoleCollectionViaPrintVendorPvuser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("User")[0], (int)HealthYes.Data.EntityType.PvuserEntity, (int)HealthYes.Data.EntityType.UserEntity, 0, null, null, null, null, "User", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PvuserEntity.CustomProperties;}
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
			get { return PvuserEntity.FieldsCustomProperties;}
		}

		/// <summary> The PvuserId property of the Entity Pvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPVUser"."PVUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PvuserId
		{
			get { return (System.Int64)GetValue((int)PvuserFieldIndex.PvuserId, true); }
			set	{ SetValue((int)PvuserFieldIndex.PvuserId, value); }
		}

		/// <summary> The UserId property of the Entity Pvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPVUser"."UserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 UserId
		{
			get { return (System.Int64)GetValue((int)PvuserFieldIndex.UserId, true); }
			set	{ SetValue((int)PvuserFieldIndex.UserId, value); }
		}

		/// <summary> The IsActive property of the Entity Pvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPVUser"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)PvuserFieldIndex.IsActive, true); }
			set	{ SetValue((int)PvuserFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity Pvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPVUser"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PvuserFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PvuserFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Pvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPVUser"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)PvuserFieldIndex.DateModified, true); }
			set	{ SetValue((int)PvuserFieldIndex.DateModified, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PrintVendorPvuserEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PrintVendorPvuserEntity))]
		public virtual EntityCollection<PrintVendorPvuserEntity> PrintVendorPvuser
		{
			get
			{
				if(_printVendorPvuser==null)
				{
					_printVendorPvuser = new EntityCollection<PrintVendorPvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PrintVendorPvuserEntityFactory)));
					_printVendorPvuser.SetContainingEntityInfo(this, "Pvuser");
				}
				return _printVendorPvuser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PrintVendorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PrintVendorEntity))]
		public virtual EntityCollection<PrintVendorEntity> PrintVendorCollectionViaPrintVendorPvuser
		{
			get
			{
				if(_printVendorCollectionViaPrintVendorPvuser==null)
				{
					_printVendorCollectionViaPrintVendorPvuser = new EntityCollection<PrintVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PrintVendorEntityFactory)));
					_printVendorCollectionViaPrintVendorPvuser.IsReadOnly=true;
				}
				return _printVendorCollectionViaPrintVendorPvuser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaPrintVendorPvuser
		{
			get
			{
				if(_roleCollectionViaPrintVendorPvuser==null)
				{
					_roleCollectionViaPrintVendorPvuser = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaPrintVendorPvuser.IsReadOnly=true;
				}
				return _roleCollectionViaPrintVendorPvuser;
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
				}
				else
				{
					if(value==null)
					{
						if(_user != null)
						{
							_user.UnsetRelatedEntity(this, "Pvuser");
						}
					}
					else
					{
						if(_user!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Pvuser");
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
			get { return (int)HealthYes.Data.EntityType.PvuserEntity; }
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
