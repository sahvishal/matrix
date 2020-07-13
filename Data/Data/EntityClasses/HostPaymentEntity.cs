///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'HostPayment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class HostPaymentEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<HostPaymentTransactionEntity> _hostPaymentTransaction;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostPaymentTransaction_;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostPaymentTransaction;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHostPaymentTransaction;
		private AddressEntity _address;
		private EventsEntity _events;
		private LookupEntity _lookup___;
		private LookupEntity _lookup__;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private ProspectsEntity _prospects;

		
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
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name Lookup___</summary>
			public static readonly string Lookup___ = "Lookup___";
			/// <summary>Member name Lookup__</summary>
			public static readonly string Lookup__ = "Lookup__";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Prospects</summary>
			public static readonly string Prospects = "Prospects";
			/// <summary>Member name HostPaymentTransaction</summary>
			public static readonly string HostPaymentTransaction = "HostPaymentTransaction";
			/// <summary>Member name LookupCollectionViaHostPaymentTransaction_</summary>
			public static readonly string LookupCollectionViaHostPaymentTransaction_ = "LookupCollectionViaHostPaymentTransaction_";
			/// <summary>Member name LookupCollectionViaHostPaymentTransaction</summary>
			public static readonly string LookupCollectionViaHostPaymentTransaction = "LookupCollectionViaHostPaymentTransaction";
			/// <summary>Member name OrganizationRoleUserCollectionViaHostPaymentTransaction</summary>
			public static readonly string OrganizationRoleUserCollectionViaHostPaymentTransaction = "OrganizationRoleUserCollectionViaHostPaymentTransaction";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static HostPaymentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public HostPaymentEntity():base("HostPaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public HostPaymentEntity(IEntityFields2 fields):base("HostPaymentEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this HostPaymentEntity</param>
		public HostPaymentEntity(IValidator validator):base("HostPaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="hostPaymentId">PK value for HostPayment which data should be fetched into this HostPayment object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HostPaymentEntity(System.Int64 hostPaymentId):base("HostPaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.HostPaymentId = hostPaymentId;
		}

		/// <summary> CTor</summary>
		/// <param name="hostPaymentId">PK value for HostPayment which data should be fetched into this HostPayment object</param>
		/// <param name="validator">The custom validator object for this HostPaymentEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HostPaymentEntity(System.Int64 hostPaymentId, IValidator validator):base("HostPaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.HostPaymentId = hostPaymentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected HostPaymentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_hostPaymentTransaction = (EntityCollection<HostPaymentTransactionEntity>)info.GetValue("_hostPaymentTransaction", typeof(EntityCollection<HostPaymentTransactionEntity>));
				_lookupCollectionViaHostPaymentTransaction_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostPaymentTransaction_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostPaymentTransaction = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostPaymentTransaction", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaHostPaymentTransaction = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHostPaymentTransaction", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup___ = (LookupEntity)info.GetValue("_lookup___", typeof(LookupEntity));
				if(_lookup___!=null)
				{
					_lookup___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup__ = (LookupEntity)info.GetValue("_lookup__", typeof(LookupEntity));
				if(_lookup__!=null)
				{
					_lookup__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_prospects = (ProspectsEntity)info.GetValue("_prospects", typeof(ProspectsEntity));
				if(_prospects!=null)
				{
					_prospects.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((HostPaymentFieldIndex)fieldIndex)
			{
				case HostPaymentFieldIndex.HostId:
					DesetupSyncProspects(true, false);
					break;
				case HostPaymentFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case HostPaymentFieldIndex.MailingAddressId:
					DesetupSyncAddress(true, false);
					break;
				case HostPaymentFieldIndex.CreatorOrganizationRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case HostPaymentFieldIndex.DepositType:
					DesetupSyncLookup__(true, false);
					break;
				case HostPaymentFieldIndex.Status:
					DesetupSyncLookup___(true, false);
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
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "Lookup___":
					this.Lookup___ = (LookupEntity)entity;
					break;
				case "Lookup__":
					this.Lookup__ = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Prospects":
					this.Prospects = (ProspectsEntity)entity;
					break;
				case "HostPaymentTransaction":
					this.HostPaymentTransaction.Add((HostPaymentTransactionEntity)entity);
					break;
				case "LookupCollectionViaHostPaymentTransaction_":
					this.LookupCollectionViaHostPaymentTransaction_.IsReadOnly = false;
					this.LookupCollectionViaHostPaymentTransaction_.Add((LookupEntity)entity);
					this.LookupCollectionViaHostPaymentTransaction_.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostPaymentTransaction":
					this.LookupCollectionViaHostPaymentTransaction.IsReadOnly = false;
					this.LookupCollectionViaHostPaymentTransaction.Add((LookupEntity)entity);
					this.LookupCollectionViaHostPaymentTransaction.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHostPaymentTransaction":
					this.OrganizationRoleUserCollectionViaHostPaymentTransaction.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHostPaymentTransaction.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHostPaymentTransaction.IsReadOnly = true;
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
			return HostPaymentEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(HostPaymentEntity.Relations.AddressEntityUsingMailingAddressId);
					break;
				case "Events":
					toReturn.Add(HostPaymentEntity.Relations.EventsEntityUsingEventId);
					break;
				case "Lookup___":
					toReturn.Add(HostPaymentEntity.Relations.LookupEntityUsingStatus);
					break;
				case "Lookup__":
					toReturn.Add(HostPaymentEntity.Relations.LookupEntityUsingDepositType);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(HostPaymentEntity.Relations.OrganizationRoleUserEntityUsingCreatorOrganizationRoleUserId);
					break;
				case "Prospects":
					toReturn.Add(HostPaymentEntity.Relations.ProspectsEntityUsingHostId);
					break;
				case "HostPaymentTransaction":
					toReturn.Add(HostPaymentEntity.Relations.HostPaymentTransactionEntityUsingHostPaymentId);
					break;
				case "LookupCollectionViaHostPaymentTransaction_":
					toReturn.Add(HostPaymentEntity.Relations.HostPaymentTransactionEntityUsingHostPaymentId, "HostPaymentEntity__", "HostPaymentTransaction_", JoinHint.None);
					toReturn.Add(HostPaymentTransactionEntity.Relations.LookupEntityUsingTransactionType, "HostPaymentTransaction_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostPaymentTransaction":
					toReturn.Add(HostPaymentEntity.Relations.HostPaymentTransactionEntityUsingHostPaymentId, "HostPaymentEntity__", "HostPaymentTransaction_", JoinHint.None);
					toReturn.Add(HostPaymentTransactionEntity.Relations.LookupEntityUsingPaymentMethod, "HostPaymentTransaction_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHostPaymentTransaction":
					toReturn.Add(HostPaymentEntity.Relations.HostPaymentTransactionEntityUsingHostPaymentId, "HostPaymentEntity__", "HostPaymentTransaction_", JoinHint.None);
					toReturn.Add(HostPaymentTransactionEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "HostPaymentTransaction_", string.Empty, JoinHint.None);
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
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "Lookup___":
					SetupSyncLookup___(relatedEntity);
					break;
				case "Lookup__":
					SetupSyncLookup__(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Prospects":
					SetupSyncProspects(relatedEntity);
					break;
				case "HostPaymentTransaction":
					this.HostPaymentTransaction.Add((HostPaymentTransactionEntity)relatedEntity);
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
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "Lookup___":
					DesetupSyncLookup___(false, true);
					break;
				case "Lookup__":
					DesetupSyncLookup__(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Prospects":
					DesetupSyncProspects(false, true);
					break;
				case "HostPaymentTransaction":
					base.PerformRelatedEntityRemoval(this.HostPaymentTransaction, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_lookup___!=null)
			{
				toReturn.Add(_lookup___);
			}
			if(_lookup__!=null)
			{
				toReturn.Add(_lookup__);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_prospects!=null)
			{
				toReturn.Add(_prospects);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.HostPaymentTransaction);

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
				info.AddValue("_hostPaymentTransaction", ((_hostPaymentTransaction!=null) && (_hostPaymentTransaction.Count>0) && !this.MarkedForDeletion)?_hostPaymentTransaction:null);
				info.AddValue("_lookupCollectionViaHostPaymentTransaction_", ((_lookupCollectionViaHostPaymentTransaction_!=null) && (_lookupCollectionViaHostPaymentTransaction_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostPaymentTransaction_:null);
				info.AddValue("_lookupCollectionViaHostPaymentTransaction", ((_lookupCollectionViaHostPaymentTransaction!=null) && (_lookupCollectionViaHostPaymentTransaction.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostPaymentTransaction:null);
				info.AddValue("_organizationRoleUserCollectionViaHostPaymentTransaction", ((_organizationRoleUserCollectionViaHostPaymentTransaction!=null) && (_organizationRoleUserCollectionViaHostPaymentTransaction.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHostPaymentTransaction:null);
				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_lookup___", (!this.MarkedForDeletion?_lookup___:null));
				info.AddValue("_lookup__", (!this.MarkedForDeletion?_lookup__:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_prospects", (!this.MarkedForDeletion?_prospects:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(HostPaymentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(HostPaymentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new HostPaymentRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostPaymentTransaction' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostPaymentTransaction()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostPaymentTransactionFields.HostPaymentId, null, ComparisonOperator.Equal, this.HostPaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostPaymentTransaction_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostPaymentTransaction_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostPaymentFields.HostPaymentId, null, ComparisonOperator.Equal, this.HostPaymentId, "HostPaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostPaymentTransaction()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostPaymentTransaction"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostPaymentFields.HostPaymentId, null, ComparisonOperator.Equal, this.HostPaymentId, "HostPaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHostPaymentTransaction()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHostPaymentTransaction"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostPaymentFields.HostPaymentId, null, ComparisonOperator.Equal, this.HostPaymentId, "HostPaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.MailingAddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Events' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.EventId, null, ComparisonOperator.Equal, this.EventId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Status));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.DepositType));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatorOrganizationRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Prospects' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.HostId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.HostPaymentEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(HostPaymentEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._hostPaymentTransaction);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostPaymentTransaction_);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostPaymentTransaction);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHostPaymentTransaction);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._hostPaymentTransaction = (EntityCollection<HostPaymentTransactionEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostPaymentTransaction_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostPaymentTransaction = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHostPaymentTransaction = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._hostPaymentTransaction != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostPaymentTransaction_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostPaymentTransaction != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHostPaymentTransaction != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostPaymentTransactionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostPaymentTransactionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
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
			toReturn.Add("Address", _address);
			toReturn.Add("Events", _events);
			toReturn.Add("Lookup___", _lookup___);
			toReturn.Add("Lookup__", _lookup__);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Prospects", _prospects);
			toReturn.Add("HostPaymentTransaction", _hostPaymentTransaction);
			toReturn.Add("LookupCollectionViaHostPaymentTransaction_", _lookupCollectionViaHostPaymentTransaction_);
			toReturn.Add("LookupCollectionViaHostPaymentTransaction", _lookupCollectionViaHostPaymentTransaction);
			toReturn.Add("OrganizationRoleUserCollectionViaHostPaymentTransaction", _organizationRoleUserCollectionViaHostPaymentTransaction);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_hostPaymentTransaction!=null)
			{
				_hostPaymentTransaction.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostPaymentTransaction_!=null)
			{
				_lookupCollectionViaHostPaymentTransaction_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostPaymentTransaction!=null)
			{
				_lookupCollectionViaHostPaymentTransaction.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHostPaymentTransaction!=null)
			{
				_organizationRoleUserCollectionViaHostPaymentTransaction.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_lookup___!=null)
			{
				_lookup___.ActiveContext = base.ActiveContext;
			}
			if(_lookup__!=null)
			{
				_lookup__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_prospects!=null)
			{
				_prospects.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_hostPaymentTransaction = null;
			_lookupCollectionViaHostPaymentTransaction_ = null;
			_lookupCollectionViaHostPaymentTransaction = null;
			_organizationRoleUserCollectionViaHostPaymentTransaction = null;
			_address = null;
			_events = null;
			_lookup___ = null;
			_lookup__ = null;
			_organizationRoleUser = null;
			_prospects = null;

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

			_fieldsCustomProperties.Add("HostPaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDeposit", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HostId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Amount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentMode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PayableTo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailingOrganizationName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailingAttentionOf", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailingAddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DueDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatorOrganizationRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DepositType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DepositFullRefundDays", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", HostPaymentEntity.Relations.AddressEntityUsingMailingAddressId, true, signalRelatedEntity, "HostPayment", resetFKFields, new int[] { (int)HostPaymentFieldIndex.MailingAddressId } );		
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
				base.PerformSetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", HostPaymentEntity.Relations.AddressEntityUsingMailingAddressId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", HostPaymentEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "HostPayment", resetFKFields, new int[] { (int)HostPaymentFieldIndex.EventId } );		
			_events = null;
		}

		/// <summary> setups the sync logic for member _events</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEvents(IEntity2 relatedEntity)
		{
			if(_events!=relatedEntity)
			{
				DesetupSyncEvents(true, true);
				_events = (EventsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", HostPaymentEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup___, new PropertyChangedEventHandler( OnLookup___PropertyChanged ), "Lookup___", HostPaymentEntity.Relations.LookupEntityUsingStatus, true, signalRelatedEntity, "HostPayment", resetFKFields, new int[] { (int)HostPaymentFieldIndex.Status } );		
			_lookup___ = null;
		}

		/// <summary> setups the sync logic for member _lookup___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup___(IEntity2 relatedEntity)
		{
			if(_lookup___!=relatedEntity)
			{
				DesetupSyncLookup___(true, true);
				_lookup___ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup___, new PropertyChangedEventHandler( OnLookup___PropertyChanged ), "Lookup___", HostPaymentEntity.Relations.LookupEntityUsingStatus, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", HostPaymentEntity.Relations.LookupEntityUsingDepositType, true, signalRelatedEntity, "HostPayment__", resetFKFields, new int[] { (int)HostPaymentFieldIndex.DepositType } );		
			_lookup__ = null;
		}

		/// <summary> setups the sync logic for member _lookup__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup__(IEntity2 relatedEntity)
		{
			if(_lookup__!=relatedEntity)
			{
				DesetupSyncLookup__(true, true);
				_lookup__ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", HostPaymentEntity.Relations.LookupEntityUsingDepositType, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup__PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", HostPaymentEntity.Relations.OrganizationRoleUserEntityUsingCreatorOrganizationRoleUserId, true, signalRelatedEntity, "HostPayment", resetFKFields, new int[] { (int)HostPaymentFieldIndex.CreatorOrganizationRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", HostPaymentEntity.Relations.OrganizationRoleUserEntityUsingCreatorOrganizationRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _prospects</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncProspects(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _prospects, new PropertyChangedEventHandler( OnProspectsPropertyChanged ), "Prospects", HostPaymentEntity.Relations.ProspectsEntityUsingHostId, true, signalRelatedEntity, "HostPayment", resetFKFields, new int[] { (int)HostPaymentFieldIndex.HostId } );		
			_prospects = null;
		}

		/// <summary> setups the sync logic for member _prospects</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncProspects(IEntity2 relatedEntity)
		{
			if(_prospects!=relatedEntity)
			{
				DesetupSyncProspects(true, true);
				_prospects = (ProspectsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _prospects, new PropertyChangedEventHandler( OnProspectsPropertyChanged ), "Prospects", HostPaymentEntity.Relations.ProspectsEntityUsingHostId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProspectsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this HostPaymentEntity</param>
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
		public  static HostPaymentRelations Relations
		{
			get	{ return new HostPaymentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostPaymentTransaction' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostPaymentTransaction
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HostPaymentTransactionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostPaymentTransactionEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostPaymentTransaction")[0], (int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.HostPaymentTransactionEntity, 0, null, null, null, null, "HostPaymentTransaction", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostPaymentTransaction_
		{
			get
			{
				IEntityRelation intermediateRelation = HostPaymentEntity.Relations.HostPaymentTransactionEntityUsingHostPaymentId;
				intermediateRelation.SetAliases(string.Empty, "HostPaymentTransaction_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostPaymentTransaction_"), null, "LookupCollectionViaHostPaymentTransaction_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostPaymentTransaction
		{
			get
			{
				IEntityRelation intermediateRelation = HostPaymentEntity.Relations.HostPaymentTransactionEntityUsingHostPaymentId;
				intermediateRelation.SetAliases(string.Empty, "HostPaymentTransaction_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostPaymentTransaction"), null, "LookupCollectionViaHostPaymentTransaction", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHostPaymentTransaction
		{
			get
			{
				IEntityRelation intermediateRelation = HostPaymentEntity.Relations.HostPaymentTransactionEntityUsingHostPaymentId;
				intermediateRelation.SetAliases(string.Empty, "HostPaymentTransaction_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHostPaymentTransaction"), null, "OrganizationRoleUserCollectionViaHostPaymentTransaction", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Address")[0], (int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup___")[0], (int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup__")[0], (int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspects
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Prospects")[0], (int)Falcon.Data.EntityType.HostPaymentEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, null, null, "Prospects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return HostPaymentEntity.CustomProperties;}
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
			get { return HostPaymentEntity.FieldsCustomProperties;}
		}

		/// <summary> The HostPaymentId property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."HostPaymentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 HostPaymentId
		{
			get { return (System.Int64)GetValue((int)HostPaymentFieldIndex.HostPaymentId, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.HostPaymentId, value); }
		}

		/// <summary> The IsDeposit property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."IsDeposit"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDeposit
		{
			get { return (System.Boolean)GetValue((int)HostPaymentFieldIndex.IsDeposit, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.IsDeposit, value); }
		}

		/// <summary> The HostId property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."HostID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HostId
		{
			get { return (System.Int64)GetValue((int)HostPaymentFieldIndex.HostId, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.HostId, value); }
		}

		/// <summary> The EventId property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)HostPaymentFieldIndex.EventId, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.EventId, value); }
		}

		/// <summary> The Amount property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."Amount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Amount
		{
			get { return (System.Decimal)GetValue((int)HostPaymentFieldIndex.Amount, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.Amount, value); }
		}

		/// <summary> The PaymentMode property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."PaymentMode"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PaymentMode
		{
			get { return (System.Int64)GetValue((int)HostPaymentFieldIndex.PaymentMode, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.PaymentMode, value); }
		}

		/// <summary> The PayableTo property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."PayableTo"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PayableTo
		{
			get { return (System.String)GetValue((int)HostPaymentFieldIndex.PayableTo, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.PayableTo, value); }
		}

		/// <summary> The MailingOrganizationName property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."MailingOrganizationName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MailingOrganizationName
		{
			get { return (System.String)GetValue((int)HostPaymentFieldIndex.MailingOrganizationName, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.MailingOrganizationName, value); }
		}

		/// <summary> The MailingAttentionOf property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."MailingAttentionOf"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MailingAttentionOf
		{
			get { return (System.String)GetValue((int)HostPaymentFieldIndex.MailingAttentionOf, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.MailingAttentionOf, value); }
		}

		/// <summary> The MailingAddressId property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."MailingAddressID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MailingAddressId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HostPaymentFieldIndex.MailingAddressId, false); }
			set	{ SetValue((int)HostPaymentFieldIndex.MailingAddressId, value); }
		}

		/// <summary> The DueDate property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."DueDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DueDate
		{
			get { return (System.DateTime)GetValue((int)HostPaymentFieldIndex.DueDate, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.DueDate, value); }
		}

		/// <summary> The CreatorOrganizationRoleUserId property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."CreatorOrganizationRoleUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatorOrganizationRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HostPaymentFieldIndex.CreatorOrganizationRoleUserId, false); }
			set	{ SetValue((int)HostPaymentFieldIndex.CreatorOrganizationRoleUserId, value); }
		}

		/// <summary> The DateCreated property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)HostPaymentFieldIndex.DateCreated, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.DateCreated, value); }
		}

		/// <summary> The DepositType property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."DepositType"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DepositType
		{
			get { return (Nullable<System.Int64>)GetValue((int)HostPaymentFieldIndex.DepositType, false); }
			set	{ SetValue((int)HostPaymentFieldIndex.DepositType, value); }
		}

		/// <summary> The DepositFullRefundDays property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."DepositFullRefundDays"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DepositFullRefundDays
		{
			get { return (Nullable<System.Int32>)GetValue((int)HostPaymentFieldIndex.DepositFullRefundDays, false); }
			set	{ SetValue((int)HostPaymentFieldIndex.DepositFullRefundDays, value); }
		}

		/// <summary> The IsActive property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)HostPaymentFieldIndex.IsActive, true); }
			set	{ SetValue((int)HostPaymentFieldIndex.IsActive, value); }
		}

		/// <summary> The Status property of the Entity HostPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostPayment"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Status
		{
			get { return (Nullable<System.Int64>)GetValue((int)HostPaymentFieldIndex.Status, false); }
			set	{ SetValue((int)HostPaymentFieldIndex.Status, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HostPaymentTransactionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HostPaymentTransactionEntity))]
		public virtual EntityCollection<HostPaymentTransactionEntity> HostPaymentTransaction
		{
			get
			{
				if(_hostPaymentTransaction==null)
				{
					_hostPaymentTransaction = new EntityCollection<HostPaymentTransactionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostPaymentTransactionEntityFactory)));
					_hostPaymentTransaction.SetContainingEntityInfo(this, "HostPayment");
				}
				return _hostPaymentTransaction;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaHostPaymentTransaction_
		{
			get
			{
				if(_lookupCollectionViaHostPaymentTransaction_==null)
				{
					_lookupCollectionViaHostPaymentTransaction_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaHostPaymentTransaction_.IsReadOnly=true;
				}
				return _lookupCollectionViaHostPaymentTransaction_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaHostPaymentTransaction
		{
			get
			{
				if(_lookupCollectionViaHostPaymentTransaction==null)
				{
					_lookupCollectionViaHostPaymentTransaction = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaHostPaymentTransaction.IsReadOnly=true;
				}
				return _lookupCollectionViaHostPaymentTransaction;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHostPaymentTransaction
		{
			get
			{
				if(_organizationRoleUserCollectionViaHostPaymentTransaction==null)
				{
					_organizationRoleUserCollectionViaHostPaymentTransaction = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHostPaymentTransaction.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHostPaymentTransaction;
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
							_address.UnsetRelatedEntity(this, "HostPayment");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HostPayment");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventsEntity Events
		{
			get
			{
				return _events;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEvents(value);
				}
				else
				{
					if(value==null)
					{
						if(_events != null)
						{
							_events.UnsetRelatedEntity(this, "HostPayment");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HostPayment");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup___
		{
			get
			{
				return _lookup___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup___(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup___ != null)
						{
							_lookup___.UnsetRelatedEntity(this, "HostPayment");
						}
					}
					else
					{
						if(_lookup___!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HostPayment");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup__
		{
			get
			{
				return _lookup__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup__(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup__ != null)
						{
							_lookup__.UnsetRelatedEntity(this, "HostPayment__");
						}
					}
					else
					{
						if(_lookup__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HostPayment__");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "HostPayment");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HostPayment");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ProspectsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ProspectsEntity Prospects
		{
			get
			{
				return _prospects;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncProspects(value);
				}
				else
				{
					if(value==null)
					{
						if(_prospects != null)
						{
							_prospects.UnsetRelatedEntity(this, "HostPayment");
						}
					}
					else
					{
						if(_prospects!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HostPayment");
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
			get { return (int)Falcon.Data.EntityType.HostPaymentEntity; }
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
