///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:48
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
	/// Entity class which represents the entity 'EventCustomerResult'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventCustomerResultEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CdcontentGeneratorTrackingEntity> _cdcontentGeneratorTracking;
		private EntityCollection<CriticalCustomerCommunicationRecordEntity> _criticalCustomerCommunicationRecord;
		private EntityCollection<CustomerEventScreeningTestsEntity> _customerEventScreeningTests;
		private EntityCollection<CustomerResultScreeningCommunicationEntity> _customerResultScreeningCommunication;
		private EntityCollection<EventCustomerPdfgenerationErrorLogEntity> _eventCustomerPdfgenerationErrorLog;
		private EntityCollection<KynLabValuesEntity> _kynLabValues;
		private EntityCollection<MolinaAttestationEntity> _molinaAttestation;
		private EntityCollection<PriorityInQueueEntity> _priorityInQueue;
		private EntityCollection<WellMedAttestationEntity> _wellMedAttestation;
		private EntityCollection<FileEntity> _fileCollectionViaWellMedAttestation;
		private EntityCollection<LookupEntity> _lookupCollectionViaKynLabValues;
		private EntityCollection<LookupEntity> _lookupCollectionViaMolinaAttestation;
		private EntityCollection<LookupEntity> _lookupCollectionViaWellMedAttestation;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaPriorityInQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCdcontentGeneratorTracking;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPriorityInQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPriorityInQueue_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerResultScreeningCommunication_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerResultScreeningCommunication;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaKynLabValues;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerResultScreeningCommunication__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaKynLabValues_;
		private EntityCollection<TestEntity> _testCollectionViaCustomerEventScreeningTests;
		private EntityCollection<TestEntity> _testCollectionViaKynLabValues;
		private CustomerProfileEntity _customerProfile;
		private EventsEntity _events;
		private LookupEntity _lookup;
		private OrganizationRoleUserEntity _organizationRoleUser___;
		private OrganizationRoleUserEntity _organizationRoleUser__;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser____;
		private OrganizationRoleUserEntity _organizationRoleUser______;
		private OrganizationRoleUserEntity _organizationRoleUser________;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private OrganizationRoleUserEntity _organizationRoleUser_____;
		private OrganizationRoleUserEntity _organizationRoleUser_______;
		private EventCustomerResultBloodLabEntity _eventCustomerResultBloodLab;
		private EventCustomerResultBloodLabParserEntity _eventCustomerResultBloodLabParser;
		private EventCustomerResultTraleEntity _eventCustomerResultTrale;
		private EventCustomersEntity _eventCustomers;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser___</summary>
			public static readonly string OrganizationRoleUser___ = "OrganizationRoleUser___";
			/// <summary>Member name OrganizationRoleUser__</summary>
			public static readonly string OrganizationRoleUser__ = "OrganizationRoleUser__";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser____</summary>
			public static readonly string OrganizationRoleUser____ = "OrganizationRoleUser____";
			/// <summary>Member name OrganizationRoleUser______</summary>
			public static readonly string OrganizationRoleUser______ = "OrganizationRoleUser______";
			/// <summary>Member name OrganizationRoleUser________</summary>
			public static readonly string OrganizationRoleUser________ = "OrganizationRoleUser________";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name OrganizationRoleUser_____</summary>
			public static readonly string OrganizationRoleUser_____ = "OrganizationRoleUser_____";
			/// <summary>Member name OrganizationRoleUser_______</summary>
			public static readonly string OrganizationRoleUser_______ = "OrganizationRoleUser_______";
			/// <summary>Member name CdcontentGeneratorTracking</summary>
			public static readonly string CdcontentGeneratorTracking = "CdcontentGeneratorTracking";
			/// <summary>Member name CriticalCustomerCommunicationRecord</summary>
			public static readonly string CriticalCustomerCommunicationRecord = "CriticalCustomerCommunicationRecord";
			/// <summary>Member name CustomerEventScreeningTests</summary>
			public static readonly string CustomerEventScreeningTests = "CustomerEventScreeningTests";
			/// <summary>Member name CustomerResultScreeningCommunication</summary>
			public static readonly string CustomerResultScreeningCommunication = "CustomerResultScreeningCommunication";
			/// <summary>Member name EventCustomerPdfgenerationErrorLog</summary>
			public static readonly string EventCustomerPdfgenerationErrorLog = "EventCustomerPdfgenerationErrorLog";
			/// <summary>Member name KynLabValues</summary>
			public static readonly string KynLabValues = "KynLabValues";
			/// <summary>Member name MolinaAttestation</summary>
			public static readonly string MolinaAttestation = "MolinaAttestation";
			/// <summary>Member name PriorityInQueue</summary>
			public static readonly string PriorityInQueue = "PriorityInQueue";
			/// <summary>Member name WellMedAttestation</summary>
			public static readonly string WellMedAttestation = "WellMedAttestation";
			/// <summary>Member name FileCollectionViaWellMedAttestation</summary>
			public static readonly string FileCollectionViaWellMedAttestation = "FileCollectionViaWellMedAttestation";
			/// <summary>Member name LookupCollectionViaKynLabValues</summary>
			public static readonly string LookupCollectionViaKynLabValues = "LookupCollectionViaKynLabValues";
			/// <summary>Member name LookupCollectionViaMolinaAttestation</summary>
			public static readonly string LookupCollectionViaMolinaAttestation = "LookupCollectionViaMolinaAttestation";
			/// <summary>Member name LookupCollectionViaWellMedAttestation</summary>
			public static readonly string LookupCollectionViaWellMedAttestation = "LookupCollectionViaWellMedAttestation";
			/// <summary>Member name NotesDetailsCollectionViaPriorityInQueue</summary>
			public static readonly string NotesDetailsCollectionViaPriorityInQueue = "NotesDetailsCollectionViaPriorityInQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaCdcontentGeneratorTracking</summary>
			public static readonly string OrganizationRoleUserCollectionViaCdcontentGeneratorTracking = "OrganizationRoleUserCollectionViaCdcontentGeneratorTracking";
			/// <summary>Member name OrganizationRoleUserCollectionViaPriorityInQueue</summary>
			public static readonly string OrganizationRoleUserCollectionViaPriorityInQueue = "OrganizationRoleUserCollectionViaPriorityInQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaPriorityInQueue_</summary>
			public static readonly string OrganizationRoleUserCollectionViaPriorityInQueue_ = "OrganizationRoleUserCollectionViaPriorityInQueue_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_ = "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication = "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication";
			/// <summary>Member name OrganizationRoleUserCollectionViaKynLabValues</summary>
			public static readonly string OrganizationRoleUserCollectionViaKynLabValues = "OrganizationRoleUserCollectionViaKynLabValues";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__ = "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__";
			/// <summary>Member name OrganizationRoleUserCollectionViaKynLabValues_</summary>
			public static readonly string OrganizationRoleUserCollectionViaKynLabValues_ = "OrganizationRoleUserCollectionViaKynLabValues_";
			/// <summary>Member name TestCollectionViaCustomerEventScreeningTests</summary>
			public static readonly string TestCollectionViaCustomerEventScreeningTests = "TestCollectionViaCustomerEventScreeningTests";
			/// <summary>Member name TestCollectionViaKynLabValues</summary>
			public static readonly string TestCollectionViaKynLabValues = "TestCollectionViaKynLabValues";
			/// <summary>Member name EventCustomerResultBloodLab</summary>
			public static readonly string EventCustomerResultBloodLab = "EventCustomerResultBloodLab";
			/// <summary>Member name EventCustomerResultBloodLabParser</summary>
			public static readonly string EventCustomerResultBloodLabParser = "EventCustomerResultBloodLabParser";
			/// <summary>Member name EventCustomerResultTrale</summary>
			public static readonly string EventCustomerResultTrale = "EventCustomerResultTrale";
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventCustomerResultEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventCustomerResultEntity():base("EventCustomerResultEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventCustomerResultEntity(IEntityFields2 fields):base("EventCustomerResultEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventCustomerResultEntity</param>
		public EventCustomerResultEntity(IValidator validator):base("EventCustomerResultEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eventCustomerResultId">PK value for EventCustomerResult which data should be fetched into this EventCustomerResult object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventCustomerResultEntity(System.Int64 eventCustomerResultId):base("EventCustomerResultEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EventCustomerResultId = eventCustomerResultId;
		}

		/// <summary> CTor</summary>
		/// <param name="eventCustomerResultId">PK value for EventCustomerResult which data should be fetched into this EventCustomerResult object</param>
		/// <param name="validator">The custom validator object for this EventCustomerResultEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventCustomerResultEntity(System.Int64 eventCustomerResultId, IValidator validator):base("EventCustomerResultEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EventCustomerResultId = eventCustomerResultId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventCustomerResultEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_cdcontentGeneratorTracking = (EntityCollection<CdcontentGeneratorTrackingEntity>)info.GetValue("_cdcontentGeneratorTracking", typeof(EntityCollection<CdcontentGeneratorTrackingEntity>));
				_criticalCustomerCommunicationRecord = (EntityCollection<CriticalCustomerCommunicationRecordEntity>)info.GetValue("_criticalCustomerCommunicationRecord", typeof(EntityCollection<CriticalCustomerCommunicationRecordEntity>));
				_customerEventScreeningTests = (EntityCollection<CustomerEventScreeningTestsEntity>)info.GetValue("_customerEventScreeningTests", typeof(EntityCollection<CustomerEventScreeningTestsEntity>));
				_customerResultScreeningCommunication = (EntityCollection<CustomerResultScreeningCommunicationEntity>)info.GetValue("_customerResultScreeningCommunication", typeof(EntityCollection<CustomerResultScreeningCommunicationEntity>));
				_eventCustomerPdfgenerationErrorLog = (EntityCollection<EventCustomerPdfgenerationErrorLogEntity>)info.GetValue("_eventCustomerPdfgenerationErrorLog", typeof(EntityCollection<EventCustomerPdfgenerationErrorLogEntity>));
				_kynLabValues = (EntityCollection<KynLabValuesEntity>)info.GetValue("_kynLabValues", typeof(EntityCollection<KynLabValuesEntity>));
				_molinaAttestation = (EntityCollection<MolinaAttestationEntity>)info.GetValue("_molinaAttestation", typeof(EntityCollection<MolinaAttestationEntity>));
				_priorityInQueue = (EntityCollection<PriorityInQueueEntity>)info.GetValue("_priorityInQueue", typeof(EntityCollection<PriorityInQueueEntity>));
				_wellMedAttestation = (EntityCollection<WellMedAttestationEntity>)info.GetValue("_wellMedAttestation", typeof(EntityCollection<WellMedAttestationEntity>));
				_fileCollectionViaWellMedAttestation = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaWellMedAttestation", typeof(EntityCollection<FileEntity>));
				_lookupCollectionViaKynLabValues = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaKynLabValues", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaMolinaAttestation = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaMolinaAttestation", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaWellMedAttestation = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaWellMedAttestation", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaPriorityInQueue = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaPriorityInQueue", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationRoleUserCollectionViaCdcontentGeneratorTracking = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCdcontentGeneratorTracking", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPriorityInQueue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPriorityInQueue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPriorityInQueue_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPriorityInQueue_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerResultScreeningCommunication = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerResultScreeningCommunication", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaKynLabValues = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaKynLabValues", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaKynLabValues_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaKynLabValues_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_testCollectionViaCustomerEventScreeningTests = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaCustomerEventScreeningTests", typeof(EntityCollection<TestEntity>));
				_testCollectionViaKynLabValues = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaKynLabValues", typeof(EntityCollection<TestEntity>));
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser___ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser___", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser___!=null)
				{
					_organizationRoleUser___.AfterSave+=new EventHandler(OnEntityAfterSave);
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
				_organizationRoleUser____ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser____", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser____!=null)
				{
					_organizationRoleUser____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser______ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser______", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser______!=null)
				{
					_organizationRoleUser______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser________ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser________", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser________!=null)
				{
					_organizationRoleUser________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_____ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_____", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_____!=null)
				{
					_organizationRoleUser_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_______ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_______", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_______!=null)
				{
					_organizationRoleUser_______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomerResultBloodLab = (EventCustomerResultBloodLabEntity)info.GetValue("_eventCustomerResultBloodLab", typeof(EventCustomerResultBloodLabEntity));
				if(_eventCustomerResultBloodLab!=null)
				{
					_eventCustomerResultBloodLab.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomerResultBloodLabParser = (EventCustomerResultBloodLabParserEntity)info.GetValue("_eventCustomerResultBloodLabParser", typeof(EventCustomerResultBloodLabParserEntity));
				if(_eventCustomerResultBloodLabParser!=null)
				{
					_eventCustomerResultBloodLabParser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomerResultTrale = (EventCustomerResultTraleEntity)info.GetValue("_eventCustomerResultTrale", typeof(EventCustomerResultTraleEntity));
				if(_eventCustomerResultTrale!=null)
				{
					_eventCustomerResultTrale.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomers = (EventCustomersEntity)info.GetValue("_eventCustomers", typeof(EventCustomersEntity));
				if(_eventCustomers!=null)
				{
					_eventCustomers.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EventCustomerResultFieldIndex)fieldIndex)
			{
				case EventCustomerResultFieldIndex.EventCustomerResultId:
					DesetupSyncEventCustomers(true, false);
					break;
				case EventCustomerResultFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case EventCustomerResultFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case EventCustomerResultFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case EventCustomerResultFieldIndex.ModifiedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case EventCustomerResultFieldIndex.ResultSummary:
					DesetupSyncLookup(true, false);
					break;
				case EventCustomerResultFieldIndex.RegeneratedBy:
					DesetupSyncOrganizationRoleUser__(true, false);
					break;
				case EventCustomerResultFieldIndex.SignedOffBy:
					DesetupSyncOrganizationRoleUser___(true, false);
					break;
				case EventCustomerResultFieldIndex.VerifiedBy:
					DesetupSyncOrganizationRoleUser____(true, false);
					break;
				case EventCustomerResultFieldIndex.CodedBy:
					DesetupSyncOrganizationRoleUser_____(true, false);
					break;
				case EventCustomerResultFieldIndex.InvoiceDateUpdatedBy:
					DesetupSyncOrganizationRoleUser______(true, false);
					break;
				case EventCustomerResultFieldIndex.ChatPdfReviewedByPhysicianId:
					DesetupSyncOrganizationRoleUser_______(true, false);
					break;
				case EventCustomerResultFieldIndex.ChatPdfReviewedByOverreadPhysicianId:
					DesetupSyncOrganizationRoleUser________(true, false);
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
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser___":
					this.OrganizationRoleUser___ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser__":
					this.OrganizationRoleUser__ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser____":
					this.OrganizationRoleUser____ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser______":
					this.OrganizationRoleUser______ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser________":
					this.OrganizationRoleUser________ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser_____":
					this.OrganizationRoleUser_____ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser_______":
					this.OrganizationRoleUser_______ = (OrganizationRoleUserEntity)entity;
					break;
				case "CdcontentGeneratorTracking":
					this.CdcontentGeneratorTracking.Add((CdcontentGeneratorTrackingEntity)entity);
					break;
				case "CriticalCustomerCommunicationRecord":
					this.CriticalCustomerCommunicationRecord.Add((CriticalCustomerCommunicationRecordEntity)entity);
					break;
				case "CustomerEventScreeningTests":
					this.CustomerEventScreeningTests.Add((CustomerEventScreeningTestsEntity)entity);
					break;
				case "CustomerResultScreeningCommunication":
					this.CustomerResultScreeningCommunication.Add((CustomerResultScreeningCommunicationEntity)entity);
					break;
				case "EventCustomerPdfgenerationErrorLog":
					this.EventCustomerPdfgenerationErrorLog.Add((EventCustomerPdfgenerationErrorLogEntity)entity);
					break;
				case "KynLabValues":
					this.KynLabValues.Add((KynLabValuesEntity)entity);
					break;
				case "MolinaAttestation":
					this.MolinaAttestation.Add((MolinaAttestationEntity)entity);
					break;
				case "PriorityInQueue":
					this.PriorityInQueue.Add((PriorityInQueueEntity)entity);
					break;
				case "WellMedAttestation":
					this.WellMedAttestation.Add((WellMedAttestationEntity)entity);
					break;
				case "FileCollectionViaWellMedAttestation":
					this.FileCollectionViaWellMedAttestation.IsReadOnly = false;
					this.FileCollectionViaWellMedAttestation.Add((FileEntity)entity);
					this.FileCollectionViaWellMedAttestation.IsReadOnly = true;
					break;
				case "LookupCollectionViaKynLabValues":
					this.LookupCollectionViaKynLabValues.IsReadOnly = false;
					this.LookupCollectionViaKynLabValues.Add((LookupEntity)entity);
					this.LookupCollectionViaKynLabValues.IsReadOnly = true;
					break;
				case "LookupCollectionViaMolinaAttestation":
					this.LookupCollectionViaMolinaAttestation.IsReadOnly = false;
					this.LookupCollectionViaMolinaAttestation.Add((LookupEntity)entity);
					this.LookupCollectionViaMolinaAttestation.IsReadOnly = true;
					break;
				case "LookupCollectionViaWellMedAttestation":
					this.LookupCollectionViaWellMedAttestation.IsReadOnly = false;
					this.LookupCollectionViaWellMedAttestation.Add((LookupEntity)entity);
					this.LookupCollectionViaWellMedAttestation.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaPriorityInQueue":
					this.NotesDetailsCollectionViaPriorityInQueue.IsReadOnly = false;
					this.NotesDetailsCollectionViaPriorityInQueue.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaPriorityInQueue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCdcontentGeneratorTracking":
					this.OrganizationRoleUserCollectionViaCdcontentGeneratorTracking.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCdcontentGeneratorTracking.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCdcontentGeneratorTracking.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPriorityInQueue":
					this.OrganizationRoleUserCollectionViaPriorityInQueue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPriorityInQueue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPriorityInQueue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPriorityInQueue_":
					this.OrganizationRoleUserCollectionViaPriorityInQueue_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPriorityInQueue_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPriorityInQueue_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_":
					this.OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication":
					this.OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaKynLabValues":
					this.OrganizationRoleUserCollectionViaKynLabValues.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaKynLabValues.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaKynLabValues.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__":
					this.OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaKynLabValues_":
					this.OrganizationRoleUserCollectionViaKynLabValues_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaKynLabValues_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaKynLabValues_.IsReadOnly = true;
					break;
				case "TestCollectionViaCustomerEventScreeningTests":
					this.TestCollectionViaCustomerEventScreeningTests.IsReadOnly = false;
					this.TestCollectionViaCustomerEventScreeningTests.Add((TestEntity)entity);
					this.TestCollectionViaCustomerEventScreeningTests.IsReadOnly = true;
					break;
				case "TestCollectionViaKynLabValues":
					this.TestCollectionViaKynLabValues.IsReadOnly = false;
					this.TestCollectionViaKynLabValues.Add((TestEntity)entity);
					this.TestCollectionViaKynLabValues.IsReadOnly = true;
					break;
				case "EventCustomerResultBloodLab":
					this.EventCustomerResultBloodLab = (EventCustomerResultBloodLabEntity)entity;
					break;
				case "EventCustomerResultBloodLabParser":
					this.EventCustomerResultBloodLabParser = (EventCustomerResultBloodLabParserEntity)entity;
					break;
				case "EventCustomerResultTrale":
					this.EventCustomerResultTrale = (EventCustomerResultTraleEntity)entity;
					break;
				case "EventCustomers":
					this.EventCustomers = (EventCustomersEntity)entity;
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
			return EventCustomerResultEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerProfile":
					toReturn.Add(EventCustomerResultEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "Events":
					toReturn.Add(EventCustomerResultEntity.Relations.EventsEntityUsingEventId);
					break;
				case "Lookup":
					toReturn.Add(EventCustomerResultEntity.Relations.LookupEntityUsingResultSummary);
					break;
				case "OrganizationRoleUser___":
					toReturn.Add(EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingSignedOffBy);
					break;
				case "OrganizationRoleUser__":
					toReturn.Add(EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingRegeneratedBy);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser____":
					toReturn.Add(EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingVerifiedBy);
					break;
				case "OrganizationRoleUser______":
					toReturn.Add(EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingInvoiceDateUpdatedBy);
					break;
				case "OrganizationRoleUser________":
					toReturn.Add(EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingChatPdfReviewedByOverreadPhysicianId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser_____":
					toReturn.Add(EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingCodedBy);
					break;
				case "OrganizationRoleUser_______":
					toReturn.Add(EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingChatPdfReviewedByPhysicianId);
					break;
				case "CdcontentGeneratorTracking":
					toReturn.Add(EventCustomerResultEntity.Relations.CdcontentGeneratorTrackingEntityUsingEventCustomerResultId);
					break;
				case "CriticalCustomerCommunicationRecord":
					toReturn.Add(EventCustomerResultEntity.Relations.CriticalCustomerCommunicationRecordEntityUsingEventCustomerResultId);
					break;
				case "CustomerEventScreeningTests":
					toReturn.Add(EventCustomerResultEntity.Relations.CustomerEventScreeningTestsEntityUsingEventCustomerResultId);
					break;
				case "CustomerResultScreeningCommunication":
					toReturn.Add(EventCustomerResultEntity.Relations.CustomerResultScreeningCommunicationEntityUsingEventCustomerResultId);
					break;
				case "EventCustomerPdfgenerationErrorLog":
					toReturn.Add(EventCustomerResultEntity.Relations.EventCustomerPdfgenerationErrorLogEntityUsingEventCustomerResultId);
					break;
				case "KynLabValues":
					toReturn.Add(EventCustomerResultEntity.Relations.KynLabValuesEntityUsingEventCustomerResultId);
					break;
				case "MolinaAttestation":
					toReturn.Add(EventCustomerResultEntity.Relations.MolinaAttestationEntityUsingEventCustomerResultId);
					break;
				case "PriorityInQueue":
					toReturn.Add(EventCustomerResultEntity.Relations.PriorityInQueueEntityUsingEventCustomerResultId);
					break;
				case "WellMedAttestation":
					toReturn.Add(EventCustomerResultEntity.Relations.WellMedAttestationEntityUsingEventCustomerResultId);
					break;
				case "FileCollectionViaWellMedAttestation":
					toReturn.Add(EventCustomerResultEntity.Relations.WellMedAttestationEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "WellMedAttestation_", JoinHint.None);
					toReturn.Add(WellMedAttestationEntity.Relations.FileEntityUsingProviderSignatureFileId, "WellMedAttestation_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaKynLabValues":
					toReturn.Add(EventCustomerResultEntity.Relations.KynLabValuesEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "KynLabValues_", JoinHint.None);
					toReturn.Add(KynLabValuesEntity.Relations.LookupEntityUsingFastingStatus, "KynLabValues_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaMolinaAttestation":
					toReturn.Add(EventCustomerResultEntity.Relations.MolinaAttestationEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "MolinaAttestation_", JoinHint.None);
					toReturn.Add(MolinaAttestationEntity.Relations.LookupEntityUsingStatusId, "MolinaAttestation_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaWellMedAttestation":
					toReturn.Add(EventCustomerResultEntity.Relations.WellMedAttestationEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "WellMedAttestation_", JoinHint.None);
					toReturn.Add(WellMedAttestationEntity.Relations.LookupEntityUsingStatusId, "WellMedAttestation_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaPriorityInQueue":
					toReturn.Add(EventCustomerResultEntity.Relations.PriorityInQueueEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "PriorityInQueue_", JoinHint.None);
					toReturn.Add(PriorityInQueueEntity.Relations.NotesDetailsEntityUsingNoteId, "PriorityInQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCdcontentGeneratorTracking":
					toReturn.Add(EventCustomerResultEntity.Relations.CdcontentGeneratorTrackingEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "CdcontentGeneratorTracking_", JoinHint.None);
					toReturn.Add(CdcontentGeneratorTrackingEntity.Relations.OrganizationRoleUserEntityUsingDownloadedByOrgRoleUserId, "CdcontentGeneratorTracking_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPriorityInQueue":
					toReturn.Add(EventCustomerResultEntity.Relations.PriorityInQueueEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "PriorityInQueue_", JoinHint.None);
					toReturn.Add(PriorityInQueueEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "PriorityInQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPriorityInQueue_":
					toReturn.Add(EventCustomerResultEntity.Relations.PriorityInQueueEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "PriorityInQueue_", JoinHint.None);
					toReturn.Add(PriorityInQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "PriorityInQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_":
					toReturn.Add(EventCustomerResultEntity.Relations.CustomerResultScreeningCommunicationEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "CustomerResultScreeningCommunication_", JoinHint.None);
					toReturn.Add(CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingFranchiseeAdminOrgRoleUserId, "CustomerResultScreeningCommunication_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication":
					toReturn.Add(EventCustomerResultEntity.Relations.CustomerResultScreeningCommunicationEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "CustomerResultScreeningCommunication_", JoinHint.None);
					toReturn.Add(CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingCommunicationInitiatedByOrgRoleUserId, "CustomerResultScreeningCommunication_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaKynLabValues":
					toReturn.Add(EventCustomerResultEntity.Relations.KynLabValuesEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "KynLabValues_", JoinHint.None);
					toReturn.Add(KynLabValuesEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "KynLabValues_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__":
					toReturn.Add(EventCustomerResultEntity.Relations.CustomerResultScreeningCommunicationEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "CustomerResultScreeningCommunication_", JoinHint.None);
					toReturn.Add(CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingPhysicianOrgRoleUserId, "CustomerResultScreeningCommunication_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaKynLabValues_":
					toReturn.Add(EventCustomerResultEntity.Relations.KynLabValuesEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "KynLabValues_", JoinHint.None);
					toReturn.Add(KynLabValuesEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "KynLabValues_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaCustomerEventScreeningTests":
					toReturn.Add(EventCustomerResultEntity.Relations.CustomerEventScreeningTestsEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "CustomerEventScreeningTests_", JoinHint.None);
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestEntityUsingTestId, "CustomerEventScreeningTests_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaKynLabValues":
					toReturn.Add(EventCustomerResultEntity.Relations.KynLabValuesEntityUsingEventCustomerResultId, "EventCustomerResultEntity__", "KynLabValues_", JoinHint.None);
					toReturn.Add(KynLabValuesEntity.Relations.TestEntityUsingTestId, "KynLabValues_", string.Empty, JoinHint.None);
					break;
				case "EventCustomerResultBloodLab":
					toReturn.Add(EventCustomerResultEntity.Relations.EventCustomerResultBloodLabEntityUsingEventCustomerResultId);
					break;
				case "EventCustomerResultBloodLabParser":
					toReturn.Add(EventCustomerResultEntity.Relations.EventCustomerResultBloodLabParserEntityUsingEventCustomerResultId);
					break;
				case "EventCustomerResultTrale":
					toReturn.Add(EventCustomerResultEntity.Relations.EventCustomerResultTraleEntityUsingEventCustomerResultId);
					break;
				case "EventCustomers":
					toReturn.Add(EventCustomerResultEntity.Relations.EventCustomersEntityUsingEventCustomerResultId);
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
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser___":
					SetupSyncOrganizationRoleUser___(relatedEntity);
					break;
				case "OrganizationRoleUser__":
					SetupSyncOrganizationRoleUser__(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser____":
					SetupSyncOrganizationRoleUser____(relatedEntity);
					break;
				case "OrganizationRoleUser______":
					SetupSyncOrganizationRoleUser______(relatedEntity);
					break;
				case "OrganizationRoleUser________":
					SetupSyncOrganizationRoleUser________(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "OrganizationRoleUser_____":
					SetupSyncOrganizationRoleUser_____(relatedEntity);
					break;
				case "OrganizationRoleUser_______":
					SetupSyncOrganizationRoleUser_______(relatedEntity);
					break;
				case "CdcontentGeneratorTracking":
					this.CdcontentGeneratorTracking.Add((CdcontentGeneratorTrackingEntity)relatedEntity);
					break;
				case "CriticalCustomerCommunicationRecord":
					this.CriticalCustomerCommunicationRecord.Add((CriticalCustomerCommunicationRecordEntity)relatedEntity);
					break;
				case "CustomerEventScreeningTests":
					this.CustomerEventScreeningTests.Add((CustomerEventScreeningTestsEntity)relatedEntity);
					break;
				case "CustomerResultScreeningCommunication":
					this.CustomerResultScreeningCommunication.Add((CustomerResultScreeningCommunicationEntity)relatedEntity);
					break;
				case "EventCustomerPdfgenerationErrorLog":
					this.EventCustomerPdfgenerationErrorLog.Add((EventCustomerPdfgenerationErrorLogEntity)relatedEntity);
					break;
				case "KynLabValues":
					this.KynLabValues.Add((KynLabValuesEntity)relatedEntity);
					break;
				case "MolinaAttestation":
					this.MolinaAttestation.Add((MolinaAttestationEntity)relatedEntity);
					break;
				case "PriorityInQueue":
					this.PriorityInQueue.Add((PriorityInQueueEntity)relatedEntity);
					break;
				case "WellMedAttestation":
					this.WellMedAttestation.Add((WellMedAttestationEntity)relatedEntity);
					break;
				case "EventCustomerResultBloodLab":
					SetupSyncEventCustomerResultBloodLab(relatedEntity);
					break;
				case "EventCustomerResultBloodLabParser":
					SetupSyncEventCustomerResultBloodLabParser(relatedEntity);
					break;
				case "EventCustomerResultTrale":
					SetupSyncEventCustomerResultTrale(relatedEntity);
					break;
				case "EventCustomers":
					SetupSyncEventCustomers(relatedEntity);
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
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser___":
					DesetupSyncOrganizationRoleUser___(false, true);
					break;
				case "OrganizationRoleUser__":
					DesetupSyncOrganizationRoleUser__(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser____":
					DesetupSyncOrganizationRoleUser____(false, true);
					break;
				case "OrganizationRoleUser______":
					DesetupSyncOrganizationRoleUser______(false, true);
					break;
				case "OrganizationRoleUser________":
					DesetupSyncOrganizationRoleUser________(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "OrganizationRoleUser_____":
					DesetupSyncOrganizationRoleUser_____(false, true);
					break;
				case "OrganizationRoleUser_______":
					DesetupSyncOrganizationRoleUser_______(false, true);
					break;
				case "CdcontentGeneratorTracking":
					base.PerformRelatedEntityRemoval(this.CdcontentGeneratorTracking, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CriticalCustomerCommunicationRecord":
					base.PerformRelatedEntityRemoval(this.CriticalCustomerCommunicationRecord, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventScreeningTests":
					base.PerformRelatedEntityRemoval(this.CustomerEventScreeningTests, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerResultScreeningCommunication":
					base.PerformRelatedEntityRemoval(this.CustomerResultScreeningCommunication, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerPdfgenerationErrorLog":
					base.PerformRelatedEntityRemoval(this.EventCustomerPdfgenerationErrorLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "KynLabValues":
					base.PerformRelatedEntityRemoval(this.KynLabValues, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MolinaAttestation":
					base.PerformRelatedEntityRemoval(this.MolinaAttestation, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PriorityInQueue":
					base.PerformRelatedEntityRemoval(this.PriorityInQueue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "WellMedAttestation":
					base.PerformRelatedEntityRemoval(this.WellMedAttestation, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerResultBloodLab":
					DesetupSyncEventCustomerResultBloodLab(false, true);
					break;
				case "EventCustomerResultBloodLabParser":
					DesetupSyncEventCustomerResultBloodLabParser(false, true);
					break;
				case "EventCustomerResultTrale":
					DesetupSyncEventCustomerResultTrale(false, true);
					break;
				case "EventCustomers":
					DesetupSyncEventCustomers(false, true);
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
			if(_eventCustomerResultBloodLab!=null)
			{
				toReturn.Add(_eventCustomerResultBloodLab);
			}

			if(_eventCustomerResultBloodLabParser!=null)
			{
				toReturn.Add(_eventCustomerResultBloodLabParser);
			}

			if(_eventCustomerResultTrale!=null)
			{
				toReturn.Add(_eventCustomerResultTrale);
			}



			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_organizationRoleUser___!=null)
			{
				toReturn.Add(_organizationRoleUser___);
			}
			if(_organizationRoleUser__!=null)
			{
				toReturn.Add(_organizationRoleUser__);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_organizationRoleUser____!=null)
			{
				toReturn.Add(_organizationRoleUser____);
			}
			if(_organizationRoleUser______!=null)
			{
				toReturn.Add(_organizationRoleUser______);
			}
			if(_organizationRoleUser________!=null)
			{
				toReturn.Add(_organizationRoleUser________);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_organizationRoleUser_____!=null)
			{
				toReturn.Add(_organizationRoleUser_____);
			}
			if(_organizationRoleUser_______!=null)
			{
				toReturn.Add(_organizationRoleUser_______);
			}






			if(_eventCustomers!=null)
			{
				toReturn.Add(_eventCustomers);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CdcontentGeneratorTracking);
			toReturn.Add(this.CriticalCustomerCommunicationRecord);
			toReturn.Add(this.CustomerEventScreeningTests);
			toReturn.Add(this.CustomerResultScreeningCommunication);
			toReturn.Add(this.EventCustomerPdfgenerationErrorLog);
			toReturn.Add(this.KynLabValues);
			toReturn.Add(this.MolinaAttestation);
			toReturn.Add(this.PriorityInQueue);
			toReturn.Add(this.WellMedAttestation);

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
				info.AddValue("_cdcontentGeneratorTracking", ((_cdcontentGeneratorTracking!=null) && (_cdcontentGeneratorTracking.Count>0) && !this.MarkedForDeletion)?_cdcontentGeneratorTracking:null);
				info.AddValue("_criticalCustomerCommunicationRecord", ((_criticalCustomerCommunicationRecord!=null) && (_criticalCustomerCommunicationRecord.Count>0) && !this.MarkedForDeletion)?_criticalCustomerCommunicationRecord:null);
				info.AddValue("_customerEventScreeningTests", ((_customerEventScreeningTests!=null) && (_customerEventScreeningTests.Count>0) && !this.MarkedForDeletion)?_customerEventScreeningTests:null);
				info.AddValue("_customerResultScreeningCommunication", ((_customerResultScreeningCommunication!=null) && (_customerResultScreeningCommunication.Count>0) && !this.MarkedForDeletion)?_customerResultScreeningCommunication:null);
				info.AddValue("_eventCustomerPdfgenerationErrorLog", ((_eventCustomerPdfgenerationErrorLog!=null) && (_eventCustomerPdfgenerationErrorLog.Count>0) && !this.MarkedForDeletion)?_eventCustomerPdfgenerationErrorLog:null);
				info.AddValue("_kynLabValues", ((_kynLabValues!=null) && (_kynLabValues.Count>0) && !this.MarkedForDeletion)?_kynLabValues:null);
				info.AddValue("_molinaAttestation", ((_molinaAttestation!=null) && (_molinaAttestation.Count>0) && !this.MarkedForDeletion)?_molinaAttestation:null);
				info.AddValue("_priorityInQueue", ((_priorityInQueue!=null) && (_priorityInQueue.Count>0) && !this.MarkedForDeletion)?_priorityInQueue:null);
				info.AddValue("_wellMedAttestation", ((_wellMedAttestation!=null) && (_wellMedAttestation.Count>0) && !this.MarkedForDeletion)?_wellMedAttestation:null);
				info.AddValue("_fileCollectionViaWellMedAttestation", ((_fileCollectionViaWellMedAttestation!=null) && (_fileCollectionViaWellMedAttestation.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaWellMedAttestation:null);
				info.AddValue("_lookupCollectionViaKynLabValues", ((_lookupCollectionViaKynLabValues!=null) && (_lookupCollectionViaKynLabValues.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaKynLabValues:null);
				info.AddValue("_lookupCollectionViaMolinaAttestation", ((_lookupCollectionViaMolinaAttestation!=null) && (_lookupCollectionViaMolinaAttestation.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaMolinaAttestation:null);
				info.AddValue("_lookupCollectionViaWellMedAttestation", ((_lookupCollectionViaWellMedAttestation!=null) && (_lookupCollectionViaWellMedAttestation.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaWellMedAttestation:null);
				info.AddValue("_notesDetailsCollectionViaPriorityInQueue", ((_notesDetailsCollectionViaPriorityInQueue!=null) && (_notesDetailsCollectionViaPriorityInQueue.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaPriorityInQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaCdcontentGeneratorTracking", ((_organizationRoleUserCollectionViaCdcontentGeneratorTracking!=null) && (_organizationRoleUserCollectionViaCdcontentGeneratorTracking.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCdcontentGeneratorTracking:null);
				info.AddValue("_organizationRoleUserCollectionViaPriorityInQueue", ((_organizationRoleUserCollectionViaPriorityInQueue!=null) && (_organizationRoleUserCollectionViaPriorityInQueue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPriorityInQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaPriorityInQueue_", ((_organizationRoleUserCollectionViaPriorityInQueue_!=null) && (_organizationRoleUserCollectionViaPriorityInQueue_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPriorityInQueue_:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_", ((_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_!=null) && (_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerResultScreeningCommunication", ((_organizationRoleUserCollectionViaCustomerResultScreeningCommunication!=null) && (_organizationRoleUserCollectionViaCustomerResultScreeningCommunication.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerResultScreeningCommunication:null);
				info.AddValue("_organizationRoleUserCollectionViaKynLabValues", ((_organizationRoleUserCollectionViaKynLabValues!=null) && (_organizationRoleUserCollectionViaKynLabValues.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaKynLabValues:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__", ((_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__!=null) && (_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__:null);
				info.AddValue("_organizationRoleUserCollectionViaKynLabValues_", ((_organizationRoleUserCollectionViaKynLabValues_!=null) && (_organizationRoleUserCollectionViaKynLabValues_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaKynLabValues_:null);
				info.AddValue("_testCollectionViaCustomerEventScreeningTests", ((_testCollectionViaCustomerEventScreeningTests!=null) && (_testCollectionViaCustomerEventScreeningTests.Count>0) && !this.MarkedForDeletion)?_testCollectionViaCustomerEventScreeningTests:null);
				info.AddValue("_testCollectionViaKynLabValues", ((_testCollectionViaKynLabValues!=null) && (_testCollectionViaKynLabValues.Count>0) && !this.MarkedForDeletion)?_testCollectionViaKynLabValues:null);
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_organizationRoleUser___", (!this.MarkedForDeletion?_organizationRoleUser___:null));
				info.AddValue("_organizationRoleUser__", (!this.MarkedForDeletion?_organizationRoleUser__:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser____", (!this.MarkedForDeletion?_organizationRoleUser____:null));
				info.AddValue("_organizationRoleUser______", (!this.MarkedForDeletion?_organizationRoleUser______:null));
				info.AddValue("_organizationRoleUser________", (!this.MarkedForDeletion?_organizationRoleUser________:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_organizationRoleUser_____", (!this.MarkedForDeletion?_organizationRoleUser_____:null));
				info.AddValue("_organizationRoleUser_______", (!this.MarkedForDeletion?_organizationRoleUser_______:null));
				info.AddValue("_eventCustomerResultBloodLab", (!this.MarkedForDeletion?_eventCustomerResultBloodLab:null));
				info.AddValue("_eventCustomerResultBloodLabParser", (!this.MarkedForDeletion?_eventCustomerResultBloodLabParser:null));
				info.AddValue("_eventCustomerResultTrale", (!this.MarkedForDeletion?_eventCustomerResultTrale:null));
				info.AddValue("_eventCustomers", (!this.MarkedForDeletion?_eventCustomers:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(EventCustomerResultFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventCustomerResultFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventCustomerResultRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CdcontentGeneratorTracking' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCdcontentGeneratorTracking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CdcontentGeneratorTrackingFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CriticalCustomerCommunicationRecord' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCriticalCustomerCommunicationRecord()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CriticalCustomerCommunicationRecordFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventScreeningTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventScreeningTests()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerResultScreeningCommunication' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerResultScreeningCommunication()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerResultScreeningCommunicationFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerPdfgenerationErrorLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerPdfgenerationErrorLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerPdfgenerationErrorLogFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'KynLabValues' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoKynLabValues()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(KynLabValuesFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MolinaAttestation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMolinaAttestation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MolinaAttestationFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PriorityInQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPriorityInQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PriorityInQueueFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'WellMedAttestation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoWellMedAttestation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(WellMedAttestationFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaWellMedAttestation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaWellMedAttestation"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaKynLabValues()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaKynLabValues"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaMolinaAttestation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaMolinaAttestation"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaWellMedAttestation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaWellMedAttestation"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaPriorityInQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaPriorityInQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCdcontentGeneratorTracking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCdcontentGeneratorTracking"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPriorityInQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPriorityInQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPriorityInQueue_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPriorityInQueue_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerResultScreeningCommunication()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaKynLabValues()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaKynLabValues"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaKynLabValues_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaKynLabValues_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaCustomerEventScreeningTests()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaCustomerEventScreeningTests"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaKynLabValues()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaKynLabValues"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId, "EventCustomerResultEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
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
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ResultSummary));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.SignedOffBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.RegeneratedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.VerifiedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.InvoiceDateUpdatedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ChatPdfReviewedByOverreadPhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CodedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ChatPdfReviewedByPhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerResultBloodLab' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResultBloodLab()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultBloodLabFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerResultBloodLabParser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResultBloodLabParser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultBloodLabParserFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerResultTrale' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResultTrale()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultTraleFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventCustomerResultEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._cdcontentGeneratorTracking);
			collectionsQueue.Enqueue(this._criticalCustomerCommunicationRecord);
			collectionsQueue.Enqueue(this._customerEventScreeningTests);
			collectionsQueue.Enqueue(this._customerResultScreeningCommunication);
			collectionsQueue.Enqueue(this._eventCustomerPdfgenerationErrorLog);
			collectionsQueue.Enqueue(this._kynLabValues);
			collectionsQueue.Enqueue(this._molinaAttestation);
			collectionsQueue.Enqueue(this._priorityInQueue);
			collectionsQueue.Enqueue(this._wellMedAttestation);
			collectionsQueue.Enqueue(this._fileCollectionViaWellMedAttestation);
			collectionsQueue.Enqueue(this._lookupCollectionViaKynLabValues);
			collectionsQueue.Enqueue(this._lookupCollectionViaMolinaAttestation);
			collectionsQueue.Enqueue(this._lookupCollectionViaWellMedAttestation);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaPriorityInQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCdcontentGeneratorTracking);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPriorityInQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPriorityInQueue_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerResultScreeningCommunication_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerResultScreeningCommunication);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaKynLabValues);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerResultScreeningCommunication__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaKynLabValues_);
			collectionsQueue.Enqueue(this._testCollectionViaCustomerEventScreeningTests);
			collectionsQueue.Enqueue(this._testCollectionViaKynLabValues);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._cdcontentGeneratorTracking = (EntityCollection<CdcontentGeneratorTrackingEntity>) collectionsQueue.Dequeue();
			this._criticalCustomerCommunicationRecord = (EntityCollection<CriticalCustomerCommunicationRecordEntity>) collectionsQueue.Dequeue();
			this._customerEventScreeningTests = (EntityCollection<CustomerEventScreeningTestsEntity>) collectionsQueue.Dequeue();
			this._customerResultScreeningCommunication = (EntityCollection<CustomerResultScreeningCommunicationEntity>) collectionsQueue.Dequeue();
			this._eventCustomerPdfgenerationErrorLog = (EntityCollection<EventCustomerPdfgenerationErrorLogEntity>) collectionsQueue.Dequeue();
			this._kynLabValues = (EntityCollection<KynLabValuesEntity>) collectionsQueue.Dequeue();
			this._molinaAttestation = (EntityCollection<MolinaAttestationEntity>) collectionsQueue.Dequeue();
			this._priorityInQueue = (EntityCollection<PriorityInQueueEntity>) collectionsQueue.Dequeue();
			this._wellMedAttestation = (EntityCollection<WellMedAttestationEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaWellMedAttestation = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaKynLabValues = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaMolinaAttestation = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaWellMedAttestation = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaPriorityInQueue = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCdcontentGeneratorTracking = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPriorityInQueue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPriorityInQueue_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerResultScreeningCommunication_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerResultScreeningCommunication = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaKynLabValues = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerResultScreeningCommunication__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaKynLabValues_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaCustomerEventScreeningTests = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaKynLabValues = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._cdcontentGeneratorTracking != null)
			{
				return true;
			}
			if (this._criticalCustomerCommunicationRecord != null)
			{
				return true;
			}
			if (this._customerEventScreeningTests != null)
			{
				return true;
			}
			if (this._customerResultScreeningCommunication != null)
			{
				return true;
			}
			if (this._eventCustomerPdfgenerationErrorLog != null)
			{
				return true;
			}
			if (this._kynLabValues != null)
			{
				return true;
			}
			if (this._molinaAttestation != null)
			{
				return true;
			}
			if (this._priorityInQueue != null)
			{
				return true;
			}
			if (this._wellMedAttestation != null)
			{
				return true;
			}
			if (this._fileCollectionViaWellMedAttestation != null)
			{
				return true;
			}
			if (this._lookupCollectionViaKynLabValues != null)
			{
				return true;
			}
			if (this._lookupCollectionViaMolinaAttestation != null)
			{
				return true;
			}
			if (this._lookupCollectionViaWellMedAttestation != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaPriorityInQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCdcontentGeneratorTracking != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPriorityInQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPriorityInQueue_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerResultScreeningCommunication_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerResultScreeningCommunication != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaKynLabValues != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerResultScreeningCommunication__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaKynLabValues_ != null)
			{
				return true;
			}
			if (this._testCollectionViaCustomerEventScreeningTests != null)
			{
				return true;
			}
			if (this._testCollectionViaKynLabValues != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CdcontentGeneratorTrackingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CdcontentGeneratorTrackingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CriticalCustomerCommunicationRecordEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CriticalCustomerCommunicationRecordEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerResultScreeningCommunicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerResultScreeningCommunicationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerPdfgenerationErrorLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPdfgenerationErrorLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<KynLabValuesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(KynLabValuesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MolinaAttestationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MolinaAttestationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PriorityInQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PriorityInQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<WellMedAttestationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(WellMedAttestationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Events", _events);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser___", _organizationRoleUser___);
			toReturn.Add("OrganizationRoleUser__", _organizationRoleUser__);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser____", _organizationRoleUser____);
			toReturn.Add("OrganizationRoleUser______", _organizationRoleUser______);
			toReturn.Add("OrganizationRoleUser________", _organizationRoleUser________);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("OrganizationRoleUser_____", _organizationRoleUser_____);
			toReturn.Add("OrganizationRoleUser_______", _organizationRoleUser_______);
			toReturn.Add("CdcontentGeneratorTracking", _cdcontentGeneratorTracking);
			toReturn.Add("CriticalCustomerCommunicationRecord", _criticalCustomerCommunicationRecord);
			toReturn.Add("CustomerEventScreeningTests", _customerEventScreeningTests);
			toReturn.Add("CustomerResultScreeningCommunication", _customerResultScreeningCommunication);
			toReturn.Add("EventCustomerPdfgenerationErrorLog", _eventCustomerPdfgenerationErrorLog);
			toReturn.Add("KynLabValues", _kynLabValues);
			toReturn.Add("MolinaAttestation", _molinaAttestation);
			toReturn.Add("PriorityInQueue", _priorityInQueue);
			toReturn.Add("WellMedAttestation", _wellMedAttestation);
			toReturn.Add("FileCollectionViaWellMedAttestation", _fileCollectionViaWellMedAttestation);
			toReturn.Add("LookupCollectionViaKynLabValues", _lookupCollectionViaKynLabValues);
			toReturn.Add("LookupCollectionViaMolinaAttestation", _lookupCollectionViaMolinaAttestation);
			toReturn.Add("LookupCollectionViaWellMedAttestation", _lookupCollectionViaWellMedAttestation);
			toReturn.Add("NotesDetailsCollectionViaPriorityInQueue", _notesDetailsCollectionViaPriorityInQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaCdcontentGeneratorTracking", _organizationRoleUserCollectionViaCdcontentGeneratorTracking);
			toReturn.Add("OrganizationRoleUserCollectionViaPriorityInQueue", _organizationRoleUserCollectionViaPriorityInQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaPriorityInQueue_", _organizationRoleUserCollectionViaPriorityInQueue_);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_", _organizationRoleUserCollectionViaCustomerResultScreeningCommunication_);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication", _organizationRoleUserCollectionViaCustomerResultScreeningCommunication);
			toReturn.Add("OrganizationRoleUserCollectionViaKynLabValues", _organizationRoleUserCollectionViaKynLabValues);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__", _organizationRoleUserCollectionViaCustomerResultScreeningCommunication__);
			toReturn.Add("OrganizationRoleUserCollectionViaKynLabValues_", _organizationRoleUserCollectionViaKynLabValues_);
			toReturn.Add("TestCollectionViaCustomerEventScreeningTests", _testCollectionViaCustomerEventScreeningTests);
			toReturn.Add("TestCollectionViaKynLabValues", _testCollectionViaKynLabValues);
			toReturn.Add("EventCustomerResultBloodLab", _eventCustomerResultBloodLab);
			toReturn.Add("EventCustomerResultBloodLabParser", _eventCustomerResultBloodLabParser);
			toReturn.Add("EventCustomerResultTrale", _eventCustomerResultTrale);
			toReturn.Add("EventCustomers", _eventCustomers);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_cdcontentGeneratorTracking!=null)
			{
				_cdcontentGeneratorTracking.ActiveContext = base.ActiveContext;
			}
			if(_criticalCustomerCommunicationRecord!=null)
			{
				_criticalCustomerCommunicationRecord.ActiveContext = base.ActiveContext;
			}
			if(_customerEventScreeningTests!=null)
			{
				_customerEventScreeningTests.ActiveContext = base.ActiveContext;
			}
			if(_customerResultScreeningCommunication!=null)
			{
				_customerResultScreeningCommunication.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerPdfgenerationErrorLog!=null)
			{
				_eventCustomerPdfgenerationErrorLog.ActiveContext = base.ActiveContext;
			}
			if(_kynLabValues!=null)
			{
				_kynLabValues.ActiveContext = base.ActiveContext;
			}
			if(_molinaAttestation!=null)
			{
				_molinaAttestation.ActiveContext = base.ActiveContext;
			}
			if(_priorityInQueue!=null)
			{
				_priorityInQueue.ActiveContext = base.ActiveContext;
			}
			if(_wellMedAttestation!=null)
			{
				_wellMedAttestation.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaWellMedAttestation!=null)
			{
				_fileCollectionViaWellMedAttestation.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaKynLabValues!=null)
			{
				_lookupCollectionViaKynLabValues.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaMolinaAttestation!=null)
			{
				_lookupCollectionViaMolinaAttestation.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaWellMedAttestation!=null)
			{
				_lookupCollectionViaWellMedAttestation.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaPriorityInQueue!=null)
			{
				_notesDetailsCollectionViaPriorityInQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCdcontentGeneratorTracking!=null)
			{
				_organizationRoleUserCollectionViaCdcontentGeneratorTracking.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPriorityInQueue!=null)
			{
				_organizationRoleUserCollectionViaPriorityInQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPriorityInQueue_!=null)
			{
				_organizationRoleUserCollectionViaPriorityInQueue_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_!=null)
			{
				_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerResultScreeningCommunication!=null)
			{
				_organizationRoleUserCollectionViaCustomerResultScreeningCommunication.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaKynLabValues!=null)
			{
				_organizationRoleUserCollectionViaKynLabValues.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__!=null)
			{
				_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaKynLabValues_!=null)
			{
				_organizationRoleUserCollectionViaKynLabValues_.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaCustomerEventScreeningTests!=null)
			{
				_testCollectionViaCustomerEventScreeningTests.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaKynLabValues!=null)
			{
				_testCollectionViaKynLabValues.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser___!=null)
			{
				_organizationRoleUser___.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser__!=null)
			{
				_organizationRoleUser__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser____!=null)
			{
				_organizationRoleUser____.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser______!=null)
			{
				_organizationRoleUser______.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser________!=null)
			{
				_organizationRoleUser________.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_____!=null)
			{
				_organizationRoleUser_____.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_______!=null)
			{
				_organizationRoleUser_______.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerResultBloodLab!=null)
			{
				_eventCustomerResultBloodLab.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerResultBloodLabParser!=null)
			{
				_eventCustomerResultBloodLabParser.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerResultTrale!=null)
			{
				_eventCustomerResultTrale.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomers!=null)
			{
				_eventCustomers.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_cdcontentGeneratorTracking = null;
			_criticalCustomerCommunicationRecord = null;
			_customerEventScreeningTests = null;
			_customerResultScreeningCommunication = null;
			_eventCustomerPdfgenerationErrorLog = null;
			_kynLabValues = null;
			_molinaAttestation = null;
			_priorityInQueue = null;
			_wellMedAttestation = null;
			_fileCollectionViaWellMedAttestation = null;
			_lookupCollectionViaKynLabValues = null;
			_lookupCollectionViaMolinaAttestation = null;
			_lookupCollectionViaWellMedAttestation = null;
			_notesDetailsCollectionViaPriorityInQueue = null;
			_organizationRoleUserCollectionViaCdcontentGeneratorTracking = null;
			_organizationRoleUserCollectionViaPriorityInQueue = null;
			_organizationRoleUserCollectionViaPriorityInQueue_ = null;
			_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_ = null;
			_organizationRoleUserCollectionViaCustomerResultScreeningCommunication = null;
			_organizationRoleUserCollectionViaKynLabValues = null;
			_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__ = null;
			_organizationRoleUserCollectionViaKynLabValues_ = null;
			_testCollectionViaCustomerEventScreeningTests = null;
			_testCollectionViaKynLabValues = null;
			_customerProfile = null;
			_events = null;
			_lookup = null;
			_organizationRoleUser___ = null;
			_organizationRoleUser__ = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser____ = null;
			_organizationRoleUser______ = null;
			_organizationRoleUser________ = null;
			_organizationRoleUser = null;
			_organizationRoleUser_____ = null;
			_organizationRoleUser_______ = null;
			_eventCustomerResultBloodLab = null;
			_eventCustomerResultBloodLabParser = null;
			_eventCustomerResultTrale = null;
			_eventCustomers = null;
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

			_fieldsCustomProperties.Add("EventCustomerResultId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsClinicalFormGenerated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsResultPdfgenerated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPartial", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultSummary", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PathwayRecommendation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RegenerationDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RegeneratedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsFasting", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsRevertedToEvaluation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPennedBack", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SignedOffBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SignedOffOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VerifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VerifiedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CodedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CodedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AcesApprovedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoiceDateUpdatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsIpResultGenerated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChatPdfReviewedByPhysicianId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChatPdfReviewedByPhysicianDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChatPdfReviewedByOverreadPhysicianId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChatPdfReviewedByOverreadPhysicianDate", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", EventCustomerResultEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "EventCustomerResult", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", EventCustomerResultEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventCustomerResultEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "EventCustomerResult", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.EventId } );		
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
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventCustomerResultEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventCustomerResultEntity.Relations.LookupEntityUsingResultSummary, true, signalRelatedEntity, "EventCustomerResult", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.ResultSummary } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventCustomerResultEntity.Relations.LookupEntityUsingResultSummary, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser___, new PropertyChangedEventHandler( OnOrganizationRoleUser___PropertyChanged ), "OrganizationRoleUser___", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingSignedOffBy, true, signalRelatedEntity, "EventCustomerResult___", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.SignedOffBy } );		
			_organizationRoleUser___ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser___(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser___!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser___(true, true);
				_organizationRoleUser___ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser___, new PropertyChangedEventHandler( OnOrganizationRoleUser___PropertyChanged ), "OrganizationRoleUser___", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingSignedOffBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser___PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingRegeneratedBy, true, signalRelatedEntity, "EventCustomerResult__", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.RegeneratedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingRegeneratedBy, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "EventCustomerResult_", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.ModifiedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser____, new PropertyChangedEventHandler( OnOrganizationRoleUser____PropertyChanged ), "OrganizationRoleUser____", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingVerifiedBy, true, signalRelatedEntity, "EventCustomerResult____", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.VerifiedBy } );		
			_organizationRoleUser____ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser____(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser____!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser____(true, true);
				_organizationRoleUser____ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser____, new PropertyChangedEventHandler( OnOrganizationRoleUser____PropertyChanged ), "OrganizationRoleUser____", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingVerifiedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser______, new PropertyChangedEventHandler( OnOrganizationRoleUser______PropertyChanged ), "OrganizationRoleUser______", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingInvoiceDateUpdatedBy, true, signalRelatedEntity, "EventCustomerResult______", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.InvoiceDateUpdatedBy } );		
			_organizationRoleUser______ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser______(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser______!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser______(true, true);
				_organizationRoleUser______ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser______, new PropertyChangedEventHandler( OnOrganizationRoleUser______PropertyChanged ), "OrganizationRoleUser______", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingInvoiceDateUpdatedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser________, new PropertyChangedEventHandler( OnOrganizationRoleUser________PropertyChanged ), "OrganizationRoleUser________", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingChatPdfReviewedByOverreadPhysicianId, true, signalRelatedEntity, "EventCustomerResult_______", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.ChatPdfReviewedByOverreadPhysicianId } );		
			_organizationRoleUser________ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser________(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser________!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser________(true, true);
				_organizationRoleUser________ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser________, new PropertyChangedEventHandler( OnOrganizationRoleUser________PropertyChanged ), "OrganizationRoleUser________", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingChatPdfReviewedByOverreadPhysicianId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser________PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "EventCustomerResult", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_____, new PropertyChangedEventHandler( OnOrganizationRoleUser_____PropertyChanged ), "OrganizationRoleUser_____", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingCodedBy, true, signalRelatedEntity, "EventCustomerResult_____", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.CodedBy } );		
			_organizationRoleUser_____ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_____(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_____!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_____(true, true);
				_organizationRoleUser_____ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_____, new PropertyChangedEventHandler( OnOrganizationRoleUser_____PropertyChanged ), "OrganizationRoleUser_____", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingCodedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_______, new PropertyChangedEventHandler( OnOrganizationRoleUser_______PropertyChanged ), "OrganizationRoleUser_______", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingChatPdfReviewedByPhysicianId, true, signalRelatedEntity, "EventCustomerResult________", resetFKFields, new int[] { (int)EventCustomerResultFieldIndex.ChatPdfReviewedByPhysicianId } );		
			_organizationRoleUser_______ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_______(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_______!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_______(true, true);
				_organizationRoleUser_______ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_______, new PropertyChangedEventHandler( OnOrganizationRoleUser_______PropertyChanged ), "OrganizationRoleUser_______", EventCustomerResultEntity.Relations.OrganizationRoleUserEntityUsingChatPdfReviewedByPhysicianId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomerResultBloodLab</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerResultBloodLab(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerResultBloodLab, new PropertyChangedEventHandler( OnEventCustomerResultBloodLabPropertyChanged ), "EventCustomerResultBloodLab", EventCustomerResultEntity.Relations.EventCustomerResultBloodLabEntityUsingEventCustomerResultId, false, signalRelatedEntity, "EventCustomerResult", false, new int[] { (int)EventCustomerResultFieldIndex.EventCustomerResultId } );
			_eventCustomerResultBloodLab = null;
		}
		
		/// <summary> setups the sync logic for member _eventCustomerResultBloodLab</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomerResultBloodLab(IEntity2 relatedEntity)
		{
			if(_eventCustomerResultBloodLab!=relatedEntity)
			{
				DesetupSyncEventCustomerResultBloodLab(true, true);
				_eventCustomerResultBloodLab = (EventCustomerResultBloodLabEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomerResultBloodLab, new PropertyChangedEventHandler( OnEventCustomerResultBloodLabPropertyChanged ), "EventCustomerResultBloodLab", EventCustomerResultEntity.Relations.EventCustomerResultBloodLabEntityUsingEventCustomerResultId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomerResultBloodLabPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomerResultBloodLabParser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerResultBloodLabParser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerResultBloodLabParser, new PropertyChangedEventHandler( OnEventCustomerResultBloodLabParserPropertyChanged ), "EventCustomerResultBloodLabParser", EventCustomerResultEntity.Relations.EventCustomerResultBloodLabParserEntityUsingEventCustomerResultId, false, signalRelatedEntity, "EventCustomerResult", false, new int[] { (int)EventCustomerResultFieldIndex.EventCustomerResultId } );
			_eventCustomerResultBloodLabParser = null;
		}
		
		/// <summary> setups the sync logic for member _eventCustomerResultBloodLabParser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomerResultBloodLabParser(IEntity2 relatedEntity)
		{
			if(_eventCustomerResultBloodLabParser!=relatedEntity)
			{
				DesetupSyncEventCustomerResultBloodLabParser(true, true);
				_eventCustomerResultBloodLabParser = (EventCustomerResultBloodLabParserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomerResultBloodLabParser, new PropertyChangedEventHandler( OnEventCustomerResultBloodLabParserPropertyChanged ), "EventCustomerResultBloodLabParser", EventCustomerResultEntity.Relations.EventCustomerResultBloodLabParserEntityUsingEventCustomerResultId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomerResultBloodLabParserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomerResultTrale</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerResultTrale(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerResultTrale, new PropertyChangedEventHandler( OnEventCustomerResultTralePropertyChanged ), "EventCustomerResultTrale", EventCustomerResultEntity.Relations.EventCustomerResultTraleEntityUsingEventCustomerResultId, false, signalRelatedEntity, "EventCustomerResult", false, new int[] { (int)EventCustomerResultFieldIndex.EventCustomerResultId } );
			_eventCustomerResultTrale = null;
		}
		
		/// <summary> setups the sync logic for member _eventCustomerResultTrale</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomerResultTrale(IEntity2 relatedEntity)
		{
			if(_eventCustomerResultTrale!=relatedEntity)
			{
				DesetupSyncEventCustomerResultTrale(true, true);
				_eventCustomerResultTrale = (EventCustomerResultTraleEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomerResultTrale, new PropertyChangedEventHandler( OnEventCustomerResultTralePropertyChanged ), "EventCustomerResultTrale", EventCustomerResultEntity.Relations.EventCustomerResultTraleEntityUsingEventCustomerResultId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomerResultTralePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomers</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomers(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", EventCustomerResultEntity.Relations.EventCustomersEntityUsingEventCustomerResultId, true, signalRelatedEntity, "EventCustomerResult", false, new int[] { (int)EventCustomerResultFieldIndex.EventCustomerResultId } );
			_eventCustomers = null;
		}
		
		/// <summary> setups the sync logic for member _eventCustomers</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomers(IEntity2 relatedEntity)
		{
			if(_eventCustomers!=relatedEntity)
			{
				DesetupSyncEventCustomers(true, true);
				_eventCustomers = (EventCustomersEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", EventCustomerResultEntity.Relations.EventCustomersEntityUsingEventCustomerResultId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomersPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EventCustomerResultEntity</param>
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
		public  static EventCustomerResultRelations Relations
		{
			get	{ return new EventCustomerResultRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CdcontentGeneratorTracking' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCdcontentGeneratorTracking
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CdcontentGeneratorTrackingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CdcontentGeneratorTrackingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CdcontentGeneratorTracking")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.CdcontentGeneratorTrackingEntity, 0, null, null, null, null, "CdcontentGeneratorTracking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CriticalCustomerCommunicationRecord' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCriticalCustomerCommunicationRecord
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CriticalCustomerCommunicationRecordEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CriticalCustomerCommunicationRecordEntityFactory))),
					(IEntityRelation)GetRelationsForField("CriticalCustomerCommunicationRecord")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.CriticalCustomerCommunicationRecordEntity, 0, null, null, null, null, "CriticalCustomerCommunicationRecord", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventScreeningTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventScreeningTests
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventScreeningTests")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, 0, null, null, null, null, "CustomerEventScreeningTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerResultScreeningCommunication' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerResultScreeningCommunication
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerResultScreeningCommunicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerResultScreeningCommunicationEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerResultScreeningCommunication")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.CustomerResultScreeningCommunicationEntity, 0, null, null, null, null, "CustomerResultScreeningCommunication", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerPdfgenerationErrorLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerPdfgenerationErrorLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerPdfgenerationErrorLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPdfgenerationErrorLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerPdfgenerationErrorLog")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.EventCustomerPdfgenerationErrorLogEntity, 0, null, null, null, null, "EventCustomerPdfgenerationErrorLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'KynLabValues' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathKynLabValues
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<KynLabValuesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(KynLabValuesEntityFactory))),
					(IEntityRelation)GetRelationsForField("KynLabValues")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.KynLabValuesEntity, 0, null, null, null, null, "KynLabValues", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MolinaAttestation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMolinaAttestation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MolinaAttestationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MolinaAttestationEntityFactory))),
					(IEntityRelation)GetRelationsForField("MolinaAttestation")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.MolinaAttestationEntity, 0, null, null, null, null, "MolinaAttestation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PriorityInQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPriorityInQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PriorityInQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PriorityInQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("PriorityInQueue")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.PriorityInQueueEntity, 0, null, null, null, null, "PriorityInQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'WellMedAttestation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathWellMedAttestation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<WellMedAttestationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(WellMedAttestationEntityFactory))),
					(IEntityRelation)GetRelationsForField("WellMedAttestation")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.WellMedAttestationEntity, 0, null, null, null, null, "WellMedAttestation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaWellMedAttestation
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.WellMedAttestationEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "WellMedAttestation_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaWellMedAttestation"), null, "FileCollectionViaWellMedAttestation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaKynLabValues
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.KynLabValuesEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "KynLabValues_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaKynLabValues"), null, "LookupCollectionViaKynLabValues", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaMolinaAttestation
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.MolinaAttestationEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "MolinaAttestation_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaMolinaAttestation"), null, "LookupCollectionViaMolinaAttestation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaWellMedAttestation
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.WellMedAttestationEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "WellMedAttestation_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaWellMedAttestation"), null, "LookupCollectionViaWellMedAttestation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaPriorityInQueue
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.PriorityInQueueEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "PriorityInQueue_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaPriorityInQueue"), null, "NotesDetailsCollectionViaPriorityInQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCdcontentGeneratorTracking
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.CdcontentGeneratorTrackingEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "CdcontentGeneratorTracking_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCdcontentGeneratorTracking"), null, "OrganizationRoleUserCollectionViaCdcontentGeneratorTracking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPriorityInQueue
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.PriorityInQueueEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "PriorityInQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPriorityInQueue"), null, "OrganizationRoleUserCollectionViaPriorityInQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPriorityInQueue_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.PriorityInQueueEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "PriorityInQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPriorityInQueue_"), null, "OrganizationRoleUserCollectionViaPriorityInQueue_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.CustomerResultScreeningCommunicationEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "CustomerResultScreeningCommunication_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_"), null, "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerResultScreeningCommunication
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.CustomerResultScreeningCommunicationEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "CustomerResultScreeningCommunication_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication"), null, "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaKynLabValues
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.KynLabValuesEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "KynLabValues_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaKynLabValues"), null, "OrganizationRoleUserCollectionViaKynLabValues", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.CustomerResultScreeningCommunicationEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "CustomerResultScreeningCommunication_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__"), null, "OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaKynLabValues_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.KynLabValuesEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "KynLabValues_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaKynLabValues_"), null, "OrganizationRoleUserCollectionViaKynLabValues_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaCustomerEventScreeningTests
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.CustomerEventScreeningTestsEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventScreeningTests_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaCustomerEventScreeningTests"), null, "TestCollectionViaCustomerEventScreeningTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaKynLabValues
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomerResultEntity.Relations.KynLabValuesEntityUsingEventCustomerResultId;
				intermediateRelation.SetAliases(string.Empty, "KynLabValues_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaKynLabValues"), null, "TestCollectionViaKynLabValues", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser___")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser__")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser____")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser______")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser________")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_____")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_______")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerResultBloodLab' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerResultBloodLab
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultBloodLabEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerResultBloodLab")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.EventCustomerResultBloodLabEntity, 0, null, null, null, null, "EventCustomerResultBloodLab", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerResultBloodLabParser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerResultBloodLabParser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultBloodLabParserEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerResultBloodLabParser")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.EventCustomerResultBloodLabParserEntity, 0, null, null, null, null, "EventCustomerResultBloodLabParser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerResultTrale' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerResultTrale
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultTraleEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerResultTrale")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.EventCustomerResultTraleEntity, 0, null, null, null, null, "EventCustomerResultTrale", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomers
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)Falcon.Data.EntityType.EventCustomerResultEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventCustomerResultEntity.CustomProperties;}
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
			get { return EventCustomerResultEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventCustomerResultId property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."EventCustomerResultId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 EventCustomerResultId
		{
			get { return (System.Int64)GetValue((int)EventCustomerResultFieldIndex.EventCustomerResultId, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.EventCustomerResultId, value); }
		}

		/// <summary> The CustomerId property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)EventCustomerResultFieldIndex.CustomerId, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.CustomerId, value); }
		}

		/// <summary> The EventId property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)EventCustomerResultFieldIndex.EventId, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.EventId, value); }
		}

		/// <summary> The IsClinicalFormGenerated property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."IsClinicalFormGenerated"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsClinicalFormGenerated
		{
			get { return (System.Boolean)GetValue((int)EventCustomerResultFieldIndex.IsClinicalFormGenerated, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.IsClinicalFormGenerated, value); }
		}

		/// <summary> The IsResultPdfgenerated property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."IsResultPDFGenerated"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsResultPdfgenerated
		{
			get { return (System.Boolean)GetValue((int)EventCustomerResultFieldIndex.IsResultPdfgenerated, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.IsResultPdfgenerated, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)EventCustomerResultFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> The DateCreated property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)EventCustomerResultFieldIndex.DateCreated, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomerResultFieldIndex.DateModified, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.DateModified, value); }
		}

		/// <summary> The ResultState property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."ResultState"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ResultState
		{
			get { return (System.Int32)GetValue((int)EventCustomerResultFieldIndex.ResultState, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.ResultState, value); }
		}

		/// <summary> The IsPartial property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."IsPartial"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPartial
		{
			get { return (System.Boolean)GetValue((int)EventCustomerResultFieldIndex.IsPartial, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.IsPartial, value); }
		}

		/// <summary> The ResultSummary property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."ResultSummary"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ResultSummary
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.ResultSummary, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.ResultSummary, value); }
		}

		/// <summary> The PathwayRecommendation property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."PathwayRecommendation"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PathwayRecommendation
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.PathwayRecommendation, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.PathwayRecommendation, value); }
		}

		/// <summary> The RegenerationDate property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."RegenerationDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> RegenerationDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomerResultFieldIndex.RegenerationDate, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.RegenerationDate, value); }
		}

		/// <summary> The RegeneratedBy property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."RegeneratedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RegeneratedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.RegeneratedBy, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.RegeneratedBy, value); }
		}

		/// <summary> The IsFasting property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."IsFasting"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsFasting
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventCustomerResultFieldIndex.IsFasting, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.IsFasting, value); }
		}

		/// <summary> The IsRevertedToEvaluation property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."IsRevertedToEvaluation"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsRevertedToEvaluation
		{
			get { return (System.Boolean)GetValue((int)EventCustomerResultFieldIndex.IsRevertedToEvaluation, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.IsRevertedToEvaluation, value); }
		}

		/// <summary> The IsPennedBack property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."IsPennedBack"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPennedBack
		{
			get { return (System.Boolean)GetValue((int)EventCustomerResultFieldIndex.IsPennedBack, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.IsPennedBack, value); }
		}

		/// <summary> The SignedOffBy property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."SignedOffBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SignedOffBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.SignedOffBy, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.SignedOffBy, value); }
		}

		/// <summary> The SignedOffOn property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."SignedOffOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> SignedOffOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomerResultFieldIndex.SignedOffOn, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.SignedOffOn, value); }
		}

		/// <summary> The VerifiedBy property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."VerifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> VerifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.VerifiedBy, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.VerifiedBy, value); }
		}

		/// <summary> The VerifiedOn property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."VerifiedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> VerifiedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomerResultFieldIndex.VerifiedOn, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.VerifiedOn, value); }
		}

		/// <summary> The CodedBy property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."CodedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CodedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.CodedBy, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.CodedBy, value); }
		}

		/// <summary> The CodedOn property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."CodedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CodedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomerResultFieldIndex.CodedOn, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.CodedOn, value); }
		}

		/// <summary> The AcesApprovedOn property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."AcesApprovedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> AcesApprovedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomerResultFieldIndex.AcesApprovedOn, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.AcesApprovedOn, value); }
		}

		/// <summary> The InvoiceDateUpdatedBy property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."InvoiceDateUpdatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> InvoiceDateUpdatedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.InvoiceDateUpdatedBy, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.InvoiceDateUpdatedBy, value); }
		}

		/// <summary> The IsIpResultGenerated property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."IsIpResultGenerated"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsIpResultGenerated
		{
			get { return (System.Boolean)GetValue((int)EventCustomerResultFieldIndex.IsIpResultGenerated, true); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.IsIpResultGenerated, value); }
		}

		/// <summary> The ChatPdfReviewedByPhysicianId property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."ChatPdfReviewedByPhysicianId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ChatPdfReviewedByPhysicianId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.ChatPdfReviewedByPhysicianId, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.ChatPdfReviewedByPhysicianId, value); }
		}

		/// <summary> The ChatPdfReviewedByPhysicianDate property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."ChatPdfReviewedByPhysicianDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ChatPdfReviewedByPhysicianDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomerResultFieldIndex.ChatPdfReviewedByPhysicianDate, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.ChatPdfReviewedByPhysicianDate, value); }
		}

		/// <summary> The ChatPdfReviewedByOverreadPhysicianId property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."ChatPdfReviewedByOverreadPhysicianId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ChatPdfReviewedByOverreadPhysicianId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomerResultFieldIndex.ChatPdfReviewedByOverreadPhysicianId, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.ChatPdfReviewedByOverreadPhysicianId, value); }
		}

		/// <summary> The ChatPdfReviewedByOverreadPhysicianDate property of the Entity EventCustomerResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomerResult"."ChatPdfReviewedByOverreadPhysicianDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ChatPdfReviewedByOverreadPhysicianDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomerResultFieldIndex.ChatPdfReviewedByOverreadPhysicianDate, false); }
			set	{ SetValue((int)EventCustomerResultFieldIndex.ChatPdfReviewedByOverreadPhysicianDate, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CdcontentGeneratorTrackingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CdcontentGeneratorTrackingEntity))]
		public virtual EntityCollection<CdcontentGeneratorTrackingEntity> CdcontentGeneratorTracking
		{
			get
			{
				if(_cdcontentGeneratorTracking==null)
				{
					_cdcontentGeneratorTracking = new EntityCollection<CdcontentGeneratorTrackingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CdcontentGeneratorTrackingEntityFactory)));
					_cdcontentGeneratorTracking.SetContainingEntityInfo(this, "EventCustomerResult");
				}
				return _cdcontentGeneratorTracking;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CriticalCustomerCommunicationRecordEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CriticalCustomerCommunicationRecordEntity))]
		public virtual EntityCollection<CriticalCustomerCommunicationRecordEntity> CriticalCustomerCommunicationRecord
		{
			get
			{
				if(_criticalCustomerCommunicationRecord==null)
				{
					_criticalCustomerCommunicationRecord = new EntityCollection<CriticalCustomerCommunicationRecordEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CriticalCustomerCommunicationRecordEntityFactory)));
					_criticalCustomerCommunicationRecord.SetContainingEntityInfo(this, "EventCustomerResult");
				}
				return _criticalCustomerCommunicationRecord;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventScreeningTestsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventScreeningTestsEntity))]
		public virtual EntityCollection<CustomerEventScreeningTestsEntity> CustomerEventScreeningTests
		{
			get
			{
				if(_customerEventScreeningTests==null)
				{
					_customerEventScreeningTests = new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory)));
					_customerEventScreeningTests.SetContainingEntityInfo(this, "EventCustomerResult");
				}
				return _customerEventScreeningTests;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerResultScreeningCommunicationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerResultScreeningCommunicationEntity))]
		public virtual EntityCollection<CustomerResultScreeningCommunicationEntity> CustomerResultScreeningCommunication
		{
			get
			{
				if(_customerResultScreeningCommunication==null)
				{
					_customerResultScreeningCommunication = new EntityCollection<CustomerResultScreeningCommunicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerResultScreeningCommunicationEntityFactory)));
					_customerResultScreeningCommunication.SetContainingEntityInfo(this, "EventCustomerResult");
				}
				return _customerResultScreeningCommunication;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerPdfgenerationErrorLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerPdfgenerationErrorLogEntity))]
		public virtual EntityCollection<EventCustomerPdfgenerationErrorLogEntity> EventCustomerPdfgenerationErrorLog
		{
			get
			{
				if(_eventCustomerPdfgenerationErrorLog==null)
				{
					_eventCustomerPdfgenerationErrorLog = new EntityCollection<EventCustomerPdfgenerationErrorLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPdfgenerationErrorLogEntityFactory)));
					_eventCustomerPdfgenerationErrorLog.SetContainingEntityInfo(this, "EventCustomerResult");
				}
				return _eventCustomerPdfgenerationErrorLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'KynLabValuesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(KynLabValuesEntity))]
		public virtual EntityCollection<KynLabValuesEntity> KynLabValues
		{
			get
			{
				if(_kynLabValues==null)
				{
					_kynLabValues = new EntityCollection<KynLabValuesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(KynLabValuesEntityFactory)));
					_kynLabValues.SetContainingEntityInfo(this, "EventCustomerResult");
				}
				return _kynLabValues;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MolinaAttestationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MolinaAttestationEntity))]
		public virtual EntityCollection<MolinaAttestationEntity> MolinaAttestation
		{
			get
			{
				if(_molinaAttestation==null)
				{
					_molinaAttestation = new EntityCollection<MolinaAttestationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MolinaAttestationEntityFactory)));
					_molinaAttestation.SetContainingEntityInfo(this, "EventCustomerResult");
				}
				return _molinaAttestation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PriorityInQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PriorityInQueueEntity))]
		public virtual EntityCollection<PriorityInQueueEntity> PriorityInQueue
		{
			get
			{
				if(_priorityInQueue==null)
				{
					_priorityInQueue = new EntityCollection<PriorityInQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PriorityInQueueEntityFactory)));
					_priorityInQueue.SetContainingEntityInfo(this, "EventCustomerResult");
				}
				return _priorityInQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'WellMedAttestationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(WellMedAttestationEntity))]
		public virtual EntityCollection<WellMedAttestationEntity> WellMedAttestation
		{
			get
			{
				if(_wellMedAttestation==null)
				{
					_wellMedAttestation = new EntityCollection<WellMedAttestationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(WellMedAttestationEntityFactory)));
					_wellMedAttestation.SetContainingEntityInfo(this, "EventCustomerResult");
				}
				return _wellMedAttestation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaWellMedAttestation
		{
			get
			{
				if(_fileCollectionViaWellMedAttestation==null)
				{
					_fileCollectionViaWellMedAttestation = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaWellMedAttestation.IsReadOnly=true;
				}
				return _fileCollectionViaWellMedAttestation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaKynLabValues
		{
			get
			{
				if(_lookupCollectionViaKynLabValues==null)
				{
					_lookupCollectionViaKynLabValues = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaKynLabValues.IsReadOnly=true;
				}
				return _lookupCollectionViaKynLabValues;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaMolinaAttestation
		{
			get
			{
				if(_lookupCollectionViaMolinaAttestation==null)
				{
					_lookupCollectionViaMolinaAttestation = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaMolinaAttestation.IsReadOnly=true;
				}
				return _lookupCollectionViaMolinaAttestation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaWellMedAttestation
		{
			get
			{
				if(_lookupCollectionViaWellMedAttestation==null)
				{
					_lookupCollectionViaWellMedAttestation = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaWellMedAttestation.IsReadOnly=true;
				}
				return _lookupCollectionViaWellMedAttestation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotesDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotesDetailsEntity))]
		public virtual EntityCollection<NotesDetailsEntity> NotesDetailsCollectionViaPriorityInQueue
		{
			get
			{
				if(_notesDetailsCollectionViaPriorityInQueue==null)
				{
					_notesDetailsCollectionViaPriorityInQueue = new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory)));
					_notesDetailsCollectionViaPriorityInQueue.IsReadOnly=true;
				}
				return _notesDetailsCollectionViaPriorityInQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCdcontentGeneratorTracking
		{
			get
			{
				if(_organizationRoleUserCollectionViaCdcontentGeneratorTracking==null)
				{
					_organizationRoleUserCollectionViaCdcontentGeneratorTracking = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCdcontentGeneratorTracking.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCdcontentGeneratorTracking;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPriorityInQueue
		{
			get
			{
				if(_organizationRoleUserCollectionViaPriorityInQueue==null)
				{
					_organizationRoleUserCollectionViaPriorityInQueue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPriorityInQueue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPriorityInQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPriorityInQueue_
		{
			get
			{
				if(_organizationRoleUserCollectionViaPriorityInQueue_==null)
				{
					_organizationRoleUserCollectionViaPriorityInQueue_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPriorityInQueue_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPriorityInQueue_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_==null)
				{
					_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerResultScreeningCommunication_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerResultScreeningCommunication_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerResultScreeningCommunication==null)
				{
					_organizationRoleUserCollectionViaCustomerResultScreeningCommunication = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerResultScreeningCommunication.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerResultScreeningCommunication;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaKynLabValues
		{
			get
			{
				if(_organizationRoleUserCollectionViaKynLabValues==null)
				{
					_organizationRoleUserCollectionViaKynLabValues = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaKynLabValues.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaKynLabValues;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerResultScreeningCommunication__
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__==null)
				{
					_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerResultScreeningCommunication__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerResultScreeningCommunication__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaKynLabValues_
		{
			get
			{
				if(_organizationRoleUserCollectionViaKynLabValues_==null)
				{
					_organizationRoleUserCollectionViaKynLabValues_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaKynLabValues_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaKynLabValues_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaCustomerEventScreeningTests
		{
			get
			{
				if(_testCollectionViaCustomerEventScreeningTests==null)
				{
					_testCollectionViaCustomerEventScreeningTests = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaCustomerEventScreeningTests.IsReadOnly=true;
				}
				return _testCollectionViaCustomerEventScreeningTests;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaKynLabValues
		{
			get
			{
				if(_testCollectionViaKynLabValues==null)
				{
					_testCollectionViaKynLabValues = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaKynLabValues.IsReadOnly=true;
				}
				return _testCollectionViaKynLabValues;
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "EventCustomerResult");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult");
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
							_events.UnsetRelatedEntity(this, "EventCustomerResult");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult");
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
							_lookup.UnsetRelatedEntity(this, "EventCustomerResult");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser___
		{
			get
			{
				return _organizationRoleUser___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser___(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser___ != null)
						{
							_organizationRoleUser___.UnsetRelatedEntity(this, "EventCustomerResult___");
						}
					}
					else
					{
						if(_organizationRoleUser___!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult___");
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
							_organizationRoleUser__.UnsetRelatedEntity(this, "EventCustomerResult__");
						}
					}
					else
					{
						if(_organizationRoleUser__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult__");
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "EventCustomerResult_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser____
		{
			get
			{
				return _organizationRoleUser____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser____(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser____ != null)
						{
							_organizationRoleUser____.UnsetRelatedEntity(this, "EventCustomerResult____");
						}
					}
					else
					{
						if(_organizationRoleUser____!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult____");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser______
		{
			get
			{
				return _organizationRoleUser______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser______(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser______ != null)
						{
							_organizationRoleUser______.UnsetRelatedEntity(this, "EventCustomerResult______");
						}
					}
					else
					{
						if(_organizationRoleUser______!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult______");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser________
		{
			get
			{
				return _organizationRoleUser________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser________(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser________ != null)
						{
							_organizationRoleUser________.UnsetRelatedEntity(this, "EventCustomerResult_______");
						}
					}
					else
					{
						if(_organizationRoleUser________!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult_______");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "EventCustomerResult");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_____
		{
			get
			{
				return _organizationRoleUser_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_____ != null)
						{
							_organizationRoleUser_____.UnsetRelatedEntity(this, "EventCustomerResult_____");
						}
					}
					else
					{
						if(_organizationRoleUser_____!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult_____");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_______
		{
			get
			{
				return _organizationRoleUser_______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_______(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_______ != null)
						{
							_organizationRoleUser_______.UnsetRelatedEntity(this, "EventCustomerResult________");
						}
					}
					else
					{
						if(_organizationRoleUser_______!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomerResult________");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomerResultBloodLabEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomerResultBloodLabEntity EventCustomerResultBloodLab
		{
			get
			{
				return _eventCustomerResultBloodLab;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomerResultBloodLab(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomerResult");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_eventCustomerResultBloodLab !=null);
						DesetupSyncEventCustomerResultBloodLab(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("EventCustomerResultBloodLab");
						}
					}
					else
					{
						if(_eventCustomerResultBloodLab!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomerResult");
							SetupSyncEventCustomerResultBloodLab(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomerResultBloodLabParserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomerResultBloodLabParserEntity EventCustomerResultBloodLabParser
		{
			get
			{
				return _eventCustomerResultBloodLabParser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomerResultBloodLabParser(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomerResult");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_eventCustomerResultBloodLabParser !=null);
						DesetupSyncEventCustomerResultBloodLabParser(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("EventCustomerResultBloodLabParser");
						}
					}
					else
					{
						if(_eventCustomerResultBloodLabParser!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomerResult");
							SetupSyncEventCustomerResultBloodLabParser(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomerResultTraleEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomerResultTraleEntity EventCustomerResultTrale
		{
			get
			{
				return _eventCustomerResultTrale;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomerResultTrale(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomerResult");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_eventCustomerResultTrale !=null);
						DesetupSyncEventCustomerResultTrale(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("EventCustomerResultTrale");
						}
					}
					else
					{
						if(_eventCustomerResultTrale!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomerResult");
							SetupSyncEventCustomerResultTrale(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomersEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomersEntity EventCustomers
		{
			get
			{
				return _eventCustomers;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomers(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomerResult");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_eventCustomers !=null);
						DesetupSyncEventCustomers(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("EventCustomers");
						}
					}
					else
					{
						if(_eventCustomers!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomerResult");
							SetupSyncEventCustomers(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.EventCustomerResultEntity; }
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
