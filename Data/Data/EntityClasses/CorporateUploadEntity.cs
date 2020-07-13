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
	/// Entity class which represents the entity 'CorporateUpload'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CorporateUploadEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerOrderHistoryEntity> _customerOrderHistory;
		private EntityCollection<MemberUploadLogEntity> _memberUploadLog;
		private EntityCollection<MemberUploadParseDetailEntity> _memberUploadParseDetail;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaMemberUploadLog;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerOrderHistory;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCustomerOrderHistory;
		private EntityCollection<EventPackageDetailsEntity> _eventPackageDetailsCollectionViaCustomerOrderHistory;
		private EntityCollection<EventsEntity> _eventsCollectionViaCustomerOrderHistory;
		private EntityCollection<EventTestEntity> _eventTestCollectionViaCustomerOrderHistory;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerOrderHistory;
		private AccountEntity _account;
		private FileEntity _file_;
		private FileEntity _file;
		private FileEntity _file__;
		private LookupEntity _lookup;
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
			/// <summary>Member name Account</summary>
			public static readonly string Account = "Account";
			/// <summary>Member name File_</summary>
			public static readonly string File_ = "File_";
			/// <summary>Member name File</summary>
			public static readonly string File = "File";
			/// <summary>Member name File__</summary>
			public static readonly string File__ = "File__";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CustomerOrderHistory</summary>
			public static readonly string CustomerOrderHistory = "CustomerOrderHistory";
			/// <summary>Member name MemberUploadLog</summary>
			public static readonly string MemberUploadLog = "MemberUploadLog";
			/// <summary>Member name MemberUploadParseDetail</summary>
			public static readonly string MemberUploadParseDetail = "MemberUploadParseDetail";
			/// <summary>Member name CustomerProfileCollectionViaMemberUploadLog</summary>
			public static readonly string CustomerProfileCollectionViaMemberUploadLog = "CustomerProfileCollectionViaMemberUploadLog";
			/// <summary>Member name CustomerProfileCollectionViaCustomerOrderHistory</summary>
			public static readonly string CustomerProfileCollectionViaCustomerOrderHistory = "CustomerProfileCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventCustomersCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventCustomersCollectionViaCustomerOrderHistory = "EventCustomersCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventPackageDetailsCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventPackageDetailsCollectionViaCustomerOrderHistory = "EventPackageDetailsCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventsCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventsCollectionViaCustomerOrderHistory = "EventsCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventTestCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventTestCollectionViaCustomerOrderHistory = "EventTestCollectionViaCustomerOrderHistory";
			/// <summary>Member name LookupCollectionViaCustomerOrderHistory</summary>
			public static readonly string LookupCollectionViaCustomerOrderHistory = "LookupCollectionViaCustomerOrderHistory";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CorporateUploadEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CorporateUploadEntity():base("CorporateUploadEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CorporateUploadEntity(IEntityFields2 fields):base("CorporateUploadEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CorporateUploadEntity</param>
		public CorporateUploadEntity(IValidator validator):base("CorporateUploadEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CorporateUpload which data should be fetched into this CorporateUpload object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CorporateUploadEntity(System.Int64 id):base("CorporateUploadEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CorporateUpload which data should be fetched into this CorporateUpload object</param>
		/// <param name="validator">The custom validator object for this CorporateUploadEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CorporateUploadEntity(System.Int64 id, IValidator validator):base("CorporateUploadEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CorporateUploadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerOrderHistory = (EntityCollection<CustomerOrderHistoryEntity>)info.GetValue("_customerOrderHistory", typeof(EntityCollection<CustomerOrderHistoryEntity>));
				_memberUploadLog = (EntityCollection<MemberUploadLogEntity>)info.GetValue("_memberUploadLog", typeof(EntityCollection<MemberUploadLogEntity>));
				_memberUploadParseDetail = (EntityCollection<MemberUploadParseDetailEntity>)info.GetValue("_memberUploadParseDetail", typeof(EntityCollection<MemberUploadParseDetailEntity>));
				_customerProfileCollectionViaMemberUploadLog = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaMemberUploadLog", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerOrderHistory = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerOrderHistory", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaCustomerOrderHistory = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventCustomersEntity>));
				_eventPackageDetailsCollectionViaCustomerOrderHistory = (EntityCollection<EventPackageDetailsEntity>)info.GetValue("_eventPackageDetailsCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventPackageDetailsEntity>));
				_eventsCollectionViaCustomerOrderHistory = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventsEntity>));
				_eventTestCollectionViaCustomerOrderHistory = (EntityCollection<EventTestEntity>)info.GetValue("_eventTestCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventTestEntity>));
				_lookupCollectionViaCustomerOrderHistory = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerOrderHistory", typeof(EntityCollection<LookupEntity>));
				_account = (AccountEntity)info.GetValue("_account", typeof(AccountEntity));
				if(_account!=null)
				{
					_account.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file_ = (FileEntity)info.GetValue("_file_", typeof(FileEntity));
				if(_file_!=null)
				{
					_file_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file = (FileEntity)info.GetValue("_file", typeof(FileEntity));
				if(_file!=null)
				{
					_file.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file__ = (FileEntity)info.GetValue("_file__", typeof(FileEntity));
				if(_file__!=null)
				{
					_file__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CorporateUploadFieldIndex)fieldIndex)
			{
				case CorporateUploadFieldIndex.FileId:
					DesetupSyncFile(true, false);
					break;
				case CorporateUploadFieldIndex.UploadedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CorporateUploadFieldIndex.LogFileId:
					DesetupSyncFile_(true, false);
					break;
				case CorporateUploadFieldIndex.AccountId:
					DesetupSyncAccount(true, false);
					break;
				case CorporateUploadFieldIndex.AdjustOrderLogFileId:
					DesetupSyncFile__(true, false);
					break;
				case CorporateUploadFieldIndex.SourceId:
					DesetupSyncLookup(true, false);
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
				case "Account":
					this.Account = (AccountEntity)entity;
					break;
				case "File_":
					this.File_ = (FileEntity)entity;
					break;
				case "File":
					this.File = (FileEntity)entity;
					break;
				case "File__":
					this.File__ = (FileEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CustomerOrderHistory":
					this.CustomerOrderHistory.Add((CustomerOrderHistoryEntity)entity);
					break;
				case "MemberUploadLog":
					this.MemberUploadLog.Add((MemberUploadLogEntity)entity);
					break;
				case "MemberUploadParseDetail":
					this.MemberUploadParseDetail.Add((MemberUploadParseDetailEntity)entity);
					break;
				case "CustomerProfileCollectionViaMemberUploadLog":
					this.CustomerProfileCollectionViaMemberUploadLog.IsReadOnly = false;
					this.CustomerProfileCollectionViaMemberUploadLog.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaMemberUploadLog.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerOrderHistory":
					this.CustomerProfileCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerOrderHistory.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCustomerOrderHistory":
					this.EventCustomersCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventCustomersCollectionViaCustomerOrderHistory.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventPackageDetailsCollectionViaCustomerOrderHistory":
					this.EventPackageDetailsCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventPackageDetailsCollectionViaCustomerOrderHistory.Add((EventPackageDetailsEntity)entity);
					this.EventPackageDetailsCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventsCollectionViaCustomerOrderHistory":
					this.EventsCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventsCollectionViaCustomerOrderHistory.Add((EventsEntity)entity);
					this.EventsCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventTestCollectionViaCustomerOrderHistory":
					this.EventTestCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventTestCollectionViaCustomerOrderHistory.Add((EventTestEntity)entity);
					this.EventTestCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerOrderHistory":
					this.LookupCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.LookupCollectionViaCustomerOrderHistory.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerOrderHistory.IsReadOnly = true;
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
			return CorporateUploadEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Account":
					toReturn.Add(CorporateUploadEntity.Relations.AccountEntityUsingAccountId);
					break;
				case "File_":
					toReturn.Add(CorporateUploadEntity.Relations.FileEntityUsingLogFileId);
					break;
				case "File":
					toReturn.Add(CorporateUploadEntity.Relations.FileEntityUsingFileId);
					break;
				case "File__":
					toReturn.Add(CorporateUploadEntity.Relations.FileEntityUsingAdjustOrderLogFileId);
					break;
				case "Lookup":
					toReturn.Add(CorporateUploadEntity.Relations.LookupEntityUsingSourceId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CorporateUploadEntity.Relations.OrganizationRoleUserEntityUsingUploadedBy);
					break;
				case "CustomerOrderHistory":
					toReturn.Add(CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId);
					break;
				case "MemberUploadLog":
					toReturn.Add(CorporateUploadEntity.Relations.MemberUploadLogEntityUsingCorporateUploadId);
					break;
				case "MemberUploadParseDetail":
					toReturn.Add(CorporateUploadEntity.Relations.MemberUploadParseDetailEntityUsingCorporateUploadId);
					break;
				case "CustomerProfileCollectionViaMemberUploadLog":
					toReturn.Add(CorporateUploadEntity.Relations.MemberUploadLogEntityUsingCorporateUploadId, "CorporateUploadEntity__", "MemberUploadLog_", JoinHint.None);
					toReturn.Add(MemberUploadLogEntity.Relations.CustomerProfileEntityUsingCustomerId, "MemberUploadLog_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerOrderHistory":
					toReturn.Add(CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId, "CorporateUploadEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCustomerOrderHistory":
					toReturn.Add(CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId, "CorporateUploadEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventPackageDetailsCollectionViaCustomerOrderHistory":
					toReturn.Add(CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId, "CorporateUploadEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventPackageDetailsEntityUsingEventPackageId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCustomerOrderHistory":
					toReturn.Add(CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId, "CorporateUploadEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventsEntityUsingEventId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventTestCollectionViaCustomerOrderHistory":
					toReturn.Add(CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId, "CorporateUploadEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventTestEntityUsingEventTestId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerOrderHistory":
					toReturn.Add(CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId, "CorporateUploadEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.LookupEntityUsingOrderItemStatusId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
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
				case "Account":
					SetupSyncAccount(relatedEntity);
					break;
				case "File_":
					SetupSyncFile_(relatedEntity);
					break;
				case "File":
					SetupSyncFile(relatedEntity);
					break;
				case "File__":
					SetupSyncFile__(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CustomerOrderHistory":
					this.CustomerOrderHistory.Add((CustomerOrderHistoryEntity)relatedEntity);
					break;
				case "MemberUploadLog":
					this.MemberUploadLog.Add((MemberUploadLogEntity)relatedEntity);
					break;
				case "MemberUploadParseDetail":
					this.MemberUploadParseDetail.Add((MemberUploadParseDetailEntity)relatedEntity);
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
				case "Account":
					DesetupSyncAccount(false, true);
					break;
				case "File_":
					DesetupSyncFile_(false, true);
					break;
				case "File":
					DesetupSyncFile(false, true);
					break;
				case "File__":
					DesetupSyncFile__(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CustomerOrderHistory":
					base.PerformRelatedEntityRemoval(this.CustomerOrderHistory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MemberUploadLog":
					base.PerformRelatedEntityRemoval(this.MemberUploadLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MemberUploadParseDetail":
					base.PerformRelatedEntityRemoval(this.MemberUploadParseDetail, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_account!=null)
			{
				toReturn.Add(_account);
			}
			if(_file_!=null)
			{
				toReturn.Add(_file_);
			}
			if(_file!=null)
			{
				toReturn.Add(_file);
			}
			if(_file__!=null)
			{
				toReturn.Add(_file__);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
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
			toReturn.Add(this.CustomerOrderHistory);
			toReturn.Add(this.MemberUploadLog);
			toReturn.Add(this.MemberUploadParseDetail);

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
				info.AddValue("_customerOrderHistory", ((_customerOrderHistory!=null) && (_customerOrderHistory.Count>0) && !this.MarkedForDeletion)?_customerOrderHistory:null);
				info.AddValue("_memberUploadLog", ((_memberUploadLog!=null) && (_memberUploadLog.Count>0) && !this.MarkedForDeletion)?_memberUploadLog:null);
				info.AddValue("_memberUploadParseDetail", ((_memberUploadParseDetail!=null) && (_memberUploadParseDetail.Count>0) && !this.MarkedForDeletion)?_memberUploadParseDetail:null);
				info.AddValue("_customerProfileCollectionViaMemberUploadLog", ((_customerProfileCollectionViaMemberUploadLog!=null) && (_customerProfileCollectionViaMemberUploadLog.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaMemberUploadLog:null);
				info.AddValue("_customerProfileCollectionViaCustomerOrderHistory", ((_customerProfileCollectionViaCustomerOrderHistory!=null) && (_customerProfileCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventCustomersCollectionViaCustomerOrderHistory", ((_eventCustomersCollectionViaCustomerOrderHistory!=null) && (_eventCustomersCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventPackageDetailsCollectionViaCustomerOrderHistory", ((_eventPackageDetailsCollectionViaCustomerOrderHistory!=null) && (_eventPackageDetailsCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventPackageDetailsCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventsCollectionViaCustomerOrderHistory", ((_eventsCollectionViaCustomerOrderHistory!=null) && (_eventsCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventTestCollectionViaCustomerOrderHistory", ((_eventTestCollectionViaCustomerOrderHistory!=null) && (_eventTestCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventTestCollectionViaCustomerOrderHistory:null);
				info.AddValue("_lookupCollectionViaCustomerOrderHistory", ((_lookupCollectionViaCustomerOrderHistory!=null) && (_lookupCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerOrderHistory:null);
				info.AddValue("_account", (!this.MarkedForDeletion?_account:null));
				info.AddValue("_file_", (!this.MarkedForDeletion?_file_:null));
				info.AddValue("_file", (!this.MarkedForDeletion?_file:null));
				info.AddValue("_file__", (!this.MarkedForDeletion?_file__:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
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
		public bool TestOriginalFieldValueForNull(CorporateUploadFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CorporateUploadFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CorporateUploadRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerOrderHistory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerOrderHistoryFields.UploadId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MemberUploadLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMemberUploadLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MemberUploadLogFields.CorporateUploadId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MemberUploadParseDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMemberUploadParseDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MemberUploadParseDetailFields.CorporateUploadId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaMemberUploadLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaMemberUploadLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CorporateUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CorporateUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CorporateUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageDetailsCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventPackageDetailsCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CorporateUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CorporateUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTestCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventTestCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CorporateUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CorporateUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Account' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.LogFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.FileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.AdjustOrderLogFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.SourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.UploadedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CorporateUploadEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerOrderHistory);
			collectionsQueue.Enqueue(this._memberUploadLog);
			collectionsQueue.Enqueue(this._memberUploadParseDetail);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaMemberUploadLog);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventPackageDetailsCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventsCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventTestCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerOrderHistory);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerOrderHistory = (EntityCollection<CustomerOrderHistoryEntity>) collectionsQueue.Dequeue();
			this._memberUploadLog = (EntityCollection<MemberUploadLogEntity>) collectionsQueue.Dequeue();
			this._memberUploadParseDetail = (EntityCollection<MemberUploadParseDetailEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaMemberUploadLog = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerOrderHistory = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCustomerOrderHistory = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventPackageDetailsCollectionViaCustomerOrderHistory = (EntityCollection<EventPackageDetailsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCustomerOrderHistory = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventTestCollectionViaCustomerOrderHistory = (EntityCollection<EventTestEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerOrderHistory = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerOrderHistory != null)
			{
				return true;
			}
			if (this._memberUploadLog != null)
			{
				return true;
			}
			if (this._memberUploadParseDetail != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaMemberUploadLog != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventPackageDetailsCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventTestCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerOrderHistory != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerOrderHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerOrderHistoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MemberUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MemberUploadLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MemberUploadParseDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MemberUploadParseDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Account", _account);
			toReturn.Add("File_", _file_);
			toReturn.Add("File", _file);
			toReturn.Add("File__", _file__);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CustomerOrderHistory", _customerOrderHistory);
			toReturn.Add("MemberUploadLog", _memberUploadLog);
			toReturn.Add("MemberUploadParseDetail", _memberUploadParseDetail);
			toReturn.Add("CustomerProfileCollectionViaMemberUploadLog", _customerProfileCollectionViaMemberUploadLog);
			toReturn.Add("CustomerProfileCollectionViaCustomerOrderHistory", _customerProfileCollectionViaCustomerOrderHistory);
			toReturn.Add("EventCustomersCollectionViaCustomerOrderHistory", _eventCustomersCollectionViaCustomerOrderHistory);
			toReturn.Add("EventPackageDetailsCollectionViaCustomerOrderHistory", _eventPackageDetailsCollectionViaCustomerOrderHistory);
			toReturn.Add("EventsCollectionViaCustomerOrderHistory", _eventsCollectionViaCustomerOrderHistory);
			toReturn.Add("EventTestCollectionViaCustomerOrderHistory", _eventTestCollectionViaCustomerOrderHistory);
			toReturn.Add("LookupCollectionViaCustomerOrderHistory", _lookupCollectionViaCustomerOrderHistory);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerOrderHistory!=null)
			{
				_customerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_memberUploadLog!=null)
			{
				_memberUploadLog.ActiveContext = base.ActiveContext;
			}
			if(_memberUploadParseDetail!=null)
			{
				_memberUploadParseDetail.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaMemberUploadLog!=null)
			{
				_customerProfileCollectionViaMemberUploadLog.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerOrderHistory!=null)
			{
				_customerProfileCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCustomerOrderHistory!=null)
			{
				_eventCustomersCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageDetailsCollectionViaCustomerOrderHistory!=null)
			{
				_eventPackageDetailsCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCustomerOrderHistory!=null)
			{
				_eventsCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventTestCollectionViaCustomerOrderHistory!=null)
			{
				_eventTestCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerOrderHistory!=null)
			{
				_lookupCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_file_!=null)
			{
				_file_.ActiveContext = base.ActiveContext;
			}
			if(_file!=null)
			{
				_file.ActiveContext = base.ActiveContext;
			}
			if(_file__!=null)
			{
				_file__.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerOrderHistory = null;
			_memberUploadLog = null;
			_memberUploadParseDetail = null;
			_customerProfileCollectionViaMemberUploadLog = null;
			_customerProfileCollectionViaCustomerOrderHistory = null;
			_eventCustomersCollectionViaCustomerOrderHistory = null;
			_eventPackageDetailsCollectionViaCustomerOrderHistory = null;
			_eventsCollectionViaCustomerOrderHistory = null;
			_eventTestCollectionViaCustomerOrderHistory = null;
			_lookupCollectionViaCustomerOrderHistory = null;
			_account = null;
			_file_ = null;
			_file = null;
			_file__ = null;
			_lookup = null;
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

			_fieldsCustomProperties.Add("FileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SuccessfullUploadCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FailedUploadCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UploadTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UploadedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LogFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AccountId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdjustOrderLogFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SourceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParseStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTermByAbsence", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _account</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAccount(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CorporateUploadEntity.Relations.AccountEntityUsingAccountId, true, signalRelatedEntity, "CorporateUpload", resetFKFields, new int[] { (int)CorporateUploadFieldIndex.AccountId } );		
			_account = null;
		}

		/// <summary> setups the sync logic for member _account</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAccount(IEntity2 relatedEntity)
		{
			if(_account!=relatedEntity)
			{
				DesetupSyncAccount(true, true);
				_account = (AccountEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CorporateUploadEntity.Relations.AccountEntityUsingAccountId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAccountPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", CorporateUploadEntity.Relations.FileEntityUsingLogFileId, true, signalRelatedEntity, "CorporateUpload_", resetFKFields, new int[] { (int)CorporateUploadFieldIndex.LogFileId } );		
			_file_ = null;
		}

		/// <summary> setups the sync logic for member _file_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile_(IEntity2 relatedEntity)
		{
			if(_file_!=relatedEntity)
			{
				DesetupSyncFile_(true, true);
				_file_ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", CorporateUploadEntity.Relations.FileEntityUsingLogFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", CorporateUploadEntity.Relations.FileEntityUsingFileId, true, signalRelatedEntity, "CorporateUpload", resetFKFields, new int[] { (int)CorporateUploadFieldIndex.FileId } );		
			_file = null;
		}

		/// <summary> setups the sync logic for member _file</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile(IEntity2 relatedEntity)
		{
			if(_file!=relatedEntity)
			{
				DesetupSyncFile(true, true);
				_file = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", CorporateUploadEntity.Relations.FileEntityUsingFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file__, new PropertyChangedEventHandler( OnFile__PropertyChanged ), "File__", CorporateUploadEntity.Relations.FileEntityUsingAdjustOrderLogFileId, true, signalRelatedEntity, "CorporateUpload__", resetFKFields, new int[] { (int)CorporateUploadFieldIndex.AdjustOrderLogFileId } );		
			_file__ = null;
		}

		/// <summary> setups the sync logic for member _file__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile__(IEntity2 relatedEntity)
		{
			if(_file__!=relatedEntity)
			{
				DesetupSyncFile__(true, true);
				_file__ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file__, new PropertyChangedEventHandler( OnFile__PropertyChanged ), "File__", CorporateUploadEntity.Relations.FileEntityUsingAdjustOrderLogFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CorporateUploadEntity.Relations.LookupEntityUsingSourceId, true, signalRelatedEntity, "CorporateUpload", resetFKFields, new int[] { (int)CorporateUploadFieldIndex.SourceId } );		
			_lookup = null;
		}

		/// <summary> setups the sync logic for member _lookup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup(IEntity2 relatedEntity)
		{
			if(_lookup!=relatedEntity)
			{
				DesetupSyncLookup(true, true);
				_lookup = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CorporateUploadEntity.Relations.LookupEntityUsingSourceId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookupPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CorporateUploadEntity.Relations.OrganizationRoleUserEntityUsingUploadedBy, true, signalRelatedEntity, "CorporateUpload", resetFKFields, new int[] { (int)CorporateUploadFieldIndex.UploadedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CorporateUploadEntity.Relations.OrganizationRoleUserEntityUsingUploadedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CorporateUploadEntity</param>
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
		public  static CorporateUploadRelations Relations
		{
			get	{ return new CorporateUploadRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerOrderHistory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerOrderHistory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerOrderHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerOrderHistoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerOrderHistory")[0], (int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.CustomerOrderHistoryEntity, 0, null, null, null, null, "CustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MemberUploadLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMemberUploadLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MemberUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MemberUploadLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("MemberUploadLog")[0], (int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.MemberUploadLogEntity, 0, null, null, null, null, "MemberUploadLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MemberUploadParseDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMemberUploadParseDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MemberUploadParseDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MemberUploadParseDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("MemberUploadParseDetail")[0], (int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.MemberUploadParseDetailEntity, 0, null, null, null, null, "MemberUploadParseDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaMemberUploadLog
		{
			get
			{
				IEntityRelation intermediateRelation = CorporateUploadEntity.Relations.MemberUploadLogEntityUsingCorporateUploadId;
				intermediateRelation.SetAliases(string.Empty, "MemberUploadLog_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaMemberUploadLog"), null, "CustomerProfileCollectionViaMemberUploadLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerOrderHistory"), null, "CustomerProfileCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCustomerOrderHistory"), null, "EventCustomersCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageDetailsCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.EventPackageDetailsEntity, 0, null, null, GetRelationsForField("EventPackageDetailsCollectionViaCustomerOrderHistory"), null, "EventPackageDetailsCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCustomerOrderHistory"), null, "EventsCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTestCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.EventTestEntity, 0, null, null, GetRelationsForField("EventTestCollectionViaCustomerOrderHistory"), null, "EventTestCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = CorporateUploadEntity.Relations.CustomerOrderHistoryEntityUsingUploadId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerOrderHistory"), null, "LookupCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccount
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File_")[0], (int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File")[0], (int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File__")[0], (int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CorporateUploadEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CorporateUploadEntity.CustomProperties;}
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
			get { return CorporateUploadEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CorporateUploadFieldIndex.Id, true); }
			set	{ SetValue((int)CorporateUploadFieldIndex.Id, value); }
		}

		/// <summary> The FileId property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."FileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 FileId
		{
			get { return (System.Int64)GetValue((int)CorporateUploadFieldIndex.FileId, true); }
			set	{ SetValue((int)CorporateUploadFieldIndex.FileId, value); }
		}

		/// <summary> The SuccessfullUploadCount property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."SuccessfullUploadCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 SuccessfullUploadCount
		{
			get { return (System.Int64)GetValue((int)CorporateUploadFieldIndex.SuccessfullUploadCount, true); }
			set	{ SetValue((int)CorporateUploadFieldIndex.SuccessfullUploadCount, value); }
		}

		/// <summary> The FailedUploadCount property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."FailedUploadCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 FailedUploadCount
		{
			get { return (System.Int64)GetValue((int)CorporateUploadFieldIndex.FailedUploadCount, true); }
			set	{ SetValue((int)CorporateUploadFieldIndex.FailedUploadCount, value); }
		}

		/// <summary> The UploadTime property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."UploadTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime UploadTime
		{
			get { return (System.DateTime)GetValue((int)CorporateUploadFieldIndex.UploadTime, true); }
			set	{ SetValue((int)CorporateUploadFieldIndex.UploadTime, value); }
		}

		/// <summary> The UploadedBy property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."UploadedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 UploadedBy
		{
			get { return (System.Int64)GetValue((int)CorporateUploadFieldIndex.UploadedBy, true); }
			set	{ SetValue((int)CorporateUploadFieldIndex.UploadedBy, value); }
		}

		/// <summary> The LogFileId property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."LogFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LogFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CorporateUploadFieldIndex.LogFileId, false); }
			set	{ SetValue((int)CorporateUploadFieldIndex.LogFileId, value); }
		}

		/// <summary> The AccountId property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."AccountId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AccountId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CorporateUploadFieldIndex.AccountId, false); }
			set	{ SetValue((int)CorporateUploadFieldIndex.AccountId, value); }
		}

		/// <summary> The AdjustOrderLogFileId property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."AdjustOrderLogFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AdjustOrderLogFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CorporateUploadFieldIndex.AdjustOrderLogFileId, false); }
			set	{ SetValue((int)CorporateUploadFieldIndex.AdjustOrderLogFileId, value); }
		}

		/// <summary> The SourceId property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."SourceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 SourceId
		{
			get { return (System.Int64)GetValue((int)CorporateUploadFieldIndex.SourceId, true); }
			set	{ SetValue((int)CorporateUploadFieldIndex.SourceId, value); }
		}

		/// <summary> The ParseStatus property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."ParseStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ParseStatus
		{
			get { return (Nullable<System.Int32>)GetValue((int)CorporateUploadFieldIndex.ParseStatus, false); }
			set	{ SetValue((int)CorporateUploadFieldIndex.ParseStatus, value); }
		}

		/// <summary> The IsTermByAbsence property of the Entity CorporateUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCorporateUpload"."IsTermByAbsence"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsTermByAbsence
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CorporateUploadFieldIndex.IsTermByAbsence, false); }
			set	{ SetValue((int)CorporateUploadFieldIndex.IsTermByAbsence, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerOrderHistoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerOrderHistoryEntity))]
		public virtual EntityCollection<CustomerOrderHistoryEntity> CustomerOrderHistory
		{
			get
			{
				if(_customerOrderHistory==null)
				{
					_customerOrderHistory = new EntityCollection<CustomerOrderHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerOrderHistoryEntityFactory)));
					_customerOrderHistory.SetContainingEntityInfo(this, "CorporateUpload");
				}
				return _customerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MemberUploadLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MemberUploadLogEntity))]
		public virtual EntityCollection<MemberUploadLogEntity> MemberUploadLog
		{
			get
			{
				if(_memberUploadLog==null)
				{
					_memberUploadLog = new EntityCollection<MemberUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MemberUploadLogEntityFactory)));
					_memberUploadLog.SetContainingEntityInfo(this, "CorporateUpload");
				}
				return _memberUploadLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MemberUploadParseDetailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MemberUploadParseDetailEntity))]
		public virtual EntityCollection<MemberUploadParseDetailEntity> MemberUploadParseDetail
		{
			get
			{
				if(_memberUploadParseDetail==null)
				{
					_memberUploadParseDetail = new EntityCollection<MemberUploadParseDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MemberUploadParseDetailEntityFactory)));
					_memberUploadParseDetail.SetContainingEntityInfo(this, "CorporateUpload");
				}
				return _memberUploadParseDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaMemberUploadLog
		{
			get
			{
				if(_customerProfileCollectionViaMemberUploadLog==null)
				{
					_customerProfileCollectionViaMemberUploadLog = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaMemberUploadLog.IsReadOnly=true;
				}
				return _customerProfileCollectionViaMemberUploadLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_customerProfileCollectionViaCustomerOrderHistory==null)
				{
					_customerProfileCollectionViaCustomerOrderHistory = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventCustomersCollectionViaCustomerOrderHistory==null)
				{
					_eventCustomersCollectionViaCustomerOrderHistory = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageDetailsEntity))]
		public virtual EntityCollection<EventPackageDetailsEntity> EventPackageDetailsCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventPackageDetailsCollectionViaCustomerOrderHistory==null)
				{
					_eventPackageDetailsCollectionViaCustomerOrderHistory = new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory)));
					_eventPackageDetailsCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventPackageDetailsCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventsCollectionViaCustomerOrderHistory==null)
				{
					_eventsCollectionViaCustomerOrderHistory = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventsCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTestEntity))]
		public virtual EntityCollection<EventTestEntity> EventTestCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventTestCollectionViaCustomerOrderHistory==null)
				{
					_eventTestCollectionViaCustomerOrderHistory = new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory)));
					_eventTestCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventTestCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_lookupCollectionViaCustomerOrderHistory==null)
				{
					_lookupCollectionViaCustomerOrderHistory = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets / sets related entity of type 'AccountEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AccountEntity Account
		{
			get
			{
				return _account;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAccount(value);
				}
				else
				{
					if(value==null)
					{
						if(_account != null)
						{
							_account.UnsetRelatedEntity(this, "CorporateUpload");
						}
					}
					else
					{
						if(_account!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CorporateUpload");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File_
		{
			get
			{
				return _file_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile_(value);
				}
				else
				{
					if(value==null)
					{
						if(_file_ != null)
						{
							_file_.UnsetRelatedEntity(this, "CorporateUpload_");
						}
					}
					else
					{
						if(_file_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CorporateUpload_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File
		{
			get
			{
				return _file;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile(value);
				}
				else
				{
					if(value==null)
					{
						if(_file != null)
						{
							_file.UnsetRelatedEntity(this, "CorporateUpload");
						}
					}
					else
					{
						if(_file!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CorporateUpload");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File__
		{
			get
			{
				return _file__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile__(value);
				}
				else
				{
					if(value==null)
					{
						if(_file__ != null)
						{
							_file__.UnsetRelatedEntity(this, "CorporateUpload__");
						}
					}
					else
					{
						if(_file__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CorporateUpload__");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup
		{
			get
			{
				return _lookup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup != null)
						{
							_lookup.UnsetRelatedEntity(this, "CorporateUpload");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CorporateUpload");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CorporateUpload");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CorporateUpload");
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
			get { return (int)Falcon.Data.EntityType.CorporateUploadEntity; }
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
