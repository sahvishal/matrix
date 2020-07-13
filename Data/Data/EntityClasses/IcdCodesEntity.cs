///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:49
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
	/// Entity class which represents the entity 'IcdCodes'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class IcdCodesEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerIcdCodeEntity> _customerIcdCode;
		private EntityCollection<EventCustomerIcdCodesEntity> _eventCustomerIcdCodes;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerIcdCode;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerIcdCodes;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerIcdCode;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CustomerIcdCode</summary>
			public static readonly string CustomerIcdCode = "CustomerIcdCode";
			/// <summary>Member name EventCustomerIcdCodes</summary>
			public static readonly string EventCustomerIcdCodes = "EventCustomerIcdCodes";
			/// <summary>Member name CustomerProfileCollectionViaCustomerIcdCode</summary>
			public static readonly string CustomerProfileCollectionViaCustomerIcdCode = "CustomerProfileCollectionViaCustomerIcdCode";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerIcdCodes</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerIcdCodes = "EventCustomersCollectionViaEventCustomerIcdCodes";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerIcdCode</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerIcdCode = "OrganizationRoleUserCollectionViaCustomerIcdCode";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static IcdCodesEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public IcdCodesEntity():base("IcdCodesEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public IcdCodesEntity(IEntityFields2 fields):base("IcdCodesEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this IcdCodesEntity</param>
		public IcdCodesEntity(IValidator validator):base("IcdCodesEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for IcdCodes which data should be fetched into this IcdCodes object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public IcdCodesEntity(System.Int64 id):base("IcdCodesEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for IcdCodes which data should be fetched into this IcdCodes object</param>
		/// <param name="validator">The custom validator object for this IcdCodesEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public IcdCodesEntity(System.Int64 id, IValidator validator):base("IcdCodesEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected IcdCodesEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerIcdCode = (EntityCollection<CustomerIcdCodeEntity>)info.GetValue("_customerIcdCode", typeof(EntityCollection<CustomerIcdCodeEntity>));
				_eventCustomerIcdCodes = (EntityCollection<EventCustomerIcdCodesEntity>)info.GetValue("_eventCustomerIcdCodes", typeof(EntityCollection<EventCustomerIcdCodesEntity>));
				_customerProfileCollectionViaCustomerIcdCode = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerIcdCode", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaEventCustomerIcdCodes = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerIcdCodes", typeof(EntityCollection<EventCustomersEntity>));
				_organizationRoleUserCollectionViaCustomerIcdCode = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerIcdCode", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((IcdCodesFieldIndex)fieldIndex)
			{
				case IcdCodesFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case IcdCodesFieldIndex.ModifiedBy:
					DesetupSyncOrganizationRoleUser_(true, false);
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
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CustomerIcdCode":
					this.CustomerIcdCode.Add((CustomerIcdCodeEntity)entity);
					break;
				case "EventCustomerIcdCodes":
					this.EventCustomerIcdCodes.Add((EventCustomerIcdCodesEntity)entity);
					break;
				case "CustomerProfileCollectionViaCustomerIcdCode":
					this.CustomerProfileCollectionViaCustomerIcdCode.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerIcdCode.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerIcdCode.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerIcdCodes":
					this.EventCustomersCollectionViaEventCustomerIcdCodes.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerIcdCodes.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerIcdCodes.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerIcdCode":
					this.OrganizationRoleUserCollectionViaCustomerIcdCode.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerIcdCode.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerIcdCode.IsReadOnly = true;
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
			return IcdCodesEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser_":
					toReturn.Add(IcdCodesEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(IcdCodesEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "CustomerIcdCode":
					toReturn.Add(IcdCodesEntity.Relations.CustomerIcdCodeEntityUsingIcdCodeId);
					break;
				case "EventCustomerIcdCodes":
					toReturn.Add(IcdCodesEntity.Relations.EventCustomerIcdCodesEntityUsingIcdCodeId);
					break;
				case "CustomerProfileCollectionViaCustomerIcdCode":
					toReturn.Add(IcdCodesEntity.Relations.CustomerIcdCodeEntityUsingIcdCodeId, "IcdCodesEntity__", "CustomerIcdCode_", JoinHint.None);
					toReturn.Add(CustomerIcdCodeEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerIcdCode_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerIcdCodes":
					toReturn.Add(IcdCodesEntity.Relations.EventCustomerIcdCodesEntityUsingIcdCodeId, "IcdCodesEntity__", "EventCustomerIcdCodes_", JoinHint.None);
					toReturn.Add(EventCustomerIcdCodesEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerIcdCodes_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerIcdCode":
					toReturn.Add(IcdCodesEntity.Relations.CustomerIcdCodeEntityUsingIcdCodeId, "IcdCodesEntity__", "CustomerIcdCode_", JoinHint.None);
					toReturn.Add(CustomerIcdCodeEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CustomerIcdCode_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CustomerIcdCode":
					this.CustomerIcdCode.Add((CustomerIcdCodeEntity)relatedEntity);
					break;
				case "EventCustomerIcdCodes":
					this.EventCustomerIcdCodes.Add((EventCustomerIcdCodesEntity)relatedEntity);
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
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CustomerIcdCode":
					base.PerformRelatedEntityRemoval(this.CustomerIcdCode, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerIcdCodes":
					base.PerformRelatedEntityRemoval(this.EventCustomerIcdCodes, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerIcdCode);
			toReturn.Add(this.EventCustomerIcdCodes);

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
				info.AddValue("_customerIcdCode", ((_customerIcdCode!=null) && (_customerIcdCode.Count>0) && !this.MarkedForDeletion)?_customerIcdCode:null);
				info.AddValue("_eventCustomerIcdCodes", ((_eventCustomerIcdCodes!=null) && (_eventCustomerIcdCodes.Count>0) && !this.MarkedForDeletion)?_eventCustomerIcdCodes:null);
				info.AddValue("_customerProfileCollectionViaCustomerIcdCode", ((_customerProfileCollectionViaCustomerIcdCode!=null) && (_customerProfileCollectionViaCustomerIcdCode.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerIcdCode:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerIcdCodes", ((_eventCustomersCollectionViaEventCustomerIcdCodes!=null) && (_eventCustomersCollectionViaEventCustomerIcdCodes.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerIcdCodes:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerIcdCode", ((_organizationRoleUserCollectionViaCustomerIcdCode!=null) && (_organizationRoleUserCollectionViaCustomerIcdCode.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerIcdCode:null);
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(IcdCodesFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(IcdCodesFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new IcdCodesRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerIcdCode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerIcdCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerIcdCodeFields.IcdCodeId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerIcdCodes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerIcdCodes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerIcdCodesFields.IcdCodeId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerIcdCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerIcdCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IcdCodesFields.Id, null, ComparisonOperator.Equal, this.Id, "IcdCodesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerIcdCodes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerIcdCodes"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IcdCodesFields.Id, null, ComparisonOperator.Equal, this.Id, "IcdCodesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerIcdCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerIcdCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IcdCodesFields.Id, null, ComparisonOperator.Equal, this.Id, "IcdCodesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.IcdCodesEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(IcdCodesEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerIcdCode);
			collectionsQueue.Enqueue(this._eventCustomerIcdCodes);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerIcdCode);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerIcdCodes);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerIcdCode);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerIcdCode = (EntityCollection<CustomerIcdCodeEntity>) collectionsQueue.Dequeue();
			this._eventCustomerIcdCodes = (EntityCollection<EventCustomerIcdCodesEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerIcdCode = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerIcdCodes = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerIcdCode = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerIcdCode != null)
			{
				return true;
			}
			if (this._eventCustomerIcdCodes != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerIcdCode != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerIcdCodes != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerIcdCode != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerIcdCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerIcdCodeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerIcdCodesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerIcdCodesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CustomerIcdCode", _customerIcdCode);
			toReturn.Add("EventCustomerIcdCodes", _eventCustomerIcdCodes);
			toReturn.Add("CustomerProfileCollectionViaCustomerIcdCode", _customerProfileCollectionViaCustomerIcdCode);
			toReturn.Add("EventCustomersCollectionViaEventCustomerIcdCodes", _eventCustomersCollectionViaEventCustomerIcdCodes);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerIcdCode", _organizationRoleUserCollectionViaCustomerIcdCode);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerIcdCode!=null)
			{
				_customerIcdCode.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerIcdCodes!=null)
			{
				_eventCustomerIcdCodes.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerIcdCode!=null)
			{
				_customerProfileCollectionViaCustomerIcdCode.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerIcdCodes!=null)
			{
				_eventCustomersCollectionViaEventCustomerIcdCodes.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerIcdCode!=null)
			{
				_organizationRoleUserCollectionViaCustomerIcdCode.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerIcdCode = null;
			_eventCustomerIcdCodes = null;
			_customerProfileCollectionViaCustomerIcdCode = null;
			_eventCustomersCollectionViaEventCustomerIcdCodes = null;
			_organizationRoleUserCollectionViaCustomerIcdCode = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser = null;

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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IcdCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", IcdCodesEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "IcdCodes_", resetFKFields, new int[] { (int)IcdCodesFieldIndex.ModifiedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", IcdCodesEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", IcdCodesEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "IcdCodes", resetFKFields, new int[] { (int)IcdCodesFieldIndex.CreatedBy } );		
			_organizationRoleUser = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser(true, true);
				_organizationRoleUser = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", IcdCodesEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this IcdCodesEntity</param>
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
		public  static IcdCodesRelations Relations
		{
			get	{ return new IcdCodesRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerIcdCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerIcdCode
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerIcdCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerIcdCodeEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerIcdCode")[0], (int)Falcon.Data.EntityType.IcdCodesEntity, (int)Falcon.Data.EntityType.CustomerIcdCodeEntity, 0, null, null, null, null, "CustomerIcdCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerIcdCodes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerIcdCodes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerIcdCodesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerIcdCodesEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerIcdCodes")[0], (int)Falcon.Data.EntityType.IcdCodesEntity, (int)Falcon.Data.EntityType.EventCustomerIcdCodesEntity, 0, null, null, null, null, "EventCustomerIcdCodes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerIcdCode
		{
			get
			{
				IEntityRelation intermediateRelation = IcdCodesEntity.Relations.CustomerIcdCodeEntityUsingIcdCodeId;
				intermediateRelation.SetAliases(string.Empty, "CustomerIcdCode_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.IcdCodesEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerIcdCode"), null, "CustomerProfileCollectionViaCustomerIcdCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerIcdCodes
		{
			get
			{
				IEntityRelation intermediateRelation = IcdCodesEntity.Relations.EventCustomerIcdCodesEntityUsingIcdCodeId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerIcdCodes_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.IcdCodesEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerIcdCodes"), null, "EventCustomersCollectionViaEventCustomerIcdCodes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerIcdCode
		{
			get
			{
				IEntityRelation intermediateRelation = IcdCodesEntity.Relations.CustomerIcdCodeEntityUsingIcdCodeId;
				intermediateRelation.SetAliases(string.Empty, "CustomerIcdCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.IcdCodesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerIcdCode"), null, "OrganizationRoleUserCollectionViaCustomerIcdCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.IcdCodesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.IcdCodesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return IcdCodesEntity.CustomProperties;}
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
			get { return IcdCodesEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity IcdCodes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIcdCodes"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)IcdCodesFieldIndex.Id, true); }
			set	{ SetValue((int)IcdCodesFieldIndex.Id, value); }
		}

		/// <summary> The IcdCode property of the Entity IcdCodes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIcdCodes"."IcdCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String IcdCode
		{
			get { return (System.String)GetValue((int)IcdCodesFieldIndex.IcdCode, true); }
			set	{ SetValue((int)IcdCodesFieldIndex.IcdCode, value); }
		}

		/// <summary> The DateCreated property of the Entity IcdCodes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIcdCodes"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)IcdCodesFieldIndex.DateCreated, true); }
			set	{ SetValue((int)IcdCodesFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedBy property of the Entity IcdCodes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIcdCodes"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)IcdCodesFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)IcdCodesFieldIndex.CreatedBy, value); }
		}

		/// <summary> The DateModified property of the Entity IcdCodes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIcdCodes"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)IcdCodesFieldIndex.DateModified, false); }
			set	{ SetValue((int)IcdCodesFieldIndex.DateModified, value); }
		}

		/// <summary> The ModifiedBy property of the Entity IcdCodes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIcdCodes"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)IcdCodesFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)IcdCodesFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The IsActive property of the Entity IcdCodes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIcdCodes"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)IcdCodesFieldIndex.IsActive, true); }
			set	{ SetValue((int)IcdCodesFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerIcdCodeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerIcdCodeEntity))]
		public virtual EntityCollection<CustomerIcdCodeEntity> CustomerIcdCode
		{
			get
			{
				if(_customerIcdCode==null)
				{
					_customerIcdCode = new EntityCollection<CustomerIcdCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerIcdCodeEntityFactory)));
					_customerIcdCode.SetContainingEntityInfo(this, "IcdCodes");
				}
				return _customerIcdCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerIcdCodesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerIcdCodesEntity))]
		public virtual EntityCollection<EventCustomerIcdCodesEntity> EventCustomerIcdCodes
		{
			get
			{
				if(_eventCustomerIcdCodes==null)
				{
					_eventCustomerIcdCodes = new EntityCollection<EventCustomerIcdCodesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerIcdCodesEntityFactory)));
					_eventCustomerIcdCodes.SetContainingEntityInfo(this, "IcdCodes");
				}
				return _eventCustomerIcdCodes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerIcdCode
		{
			get
			{
				if(_customerProfileCollectionViaCustomerIcdCode==null)
				{
					_customerProfileCollectionViaCustomerIcdCode = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerIcdCode.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerIcdCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerIcdCodes
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerIcdCodes==null)
				{
					_eventCustomersCollectionViaEventCustomerIcdCodes = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerIcdCodes.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerIcdCodes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerIcdCode
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerIcdCode==null)
				{
					_organizationRoleUserCollectionViaCustomerIcdCode = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerIcdCode.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerIcdCode;
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "IcdCodes_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "IcdCodes_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser
		{
			get
			{
				return _organizationRoleUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser != null)
						{
							_organizationRoleUser.UnsetRelatedEntity(this, "IcdCodes");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "IcdCodes");
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
			get { return (int)Falcon.Data.EntityType.IcdCodesEntity; }
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
