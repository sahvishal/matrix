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
	/// Entity class which represents the entity 'Calls'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CallsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallCenterNotesEntity> _callCenterNotes;
		private EntityCollection<CallQueueCustomerCallEntity> _callQueueCustomerCall;
		private EntityCollection<CustomerAccountGlocomNumberEntity> _customerAccountGlocomNumber;
		private EntityCollection<CustomerCallQueueCallAttemptEntity> _customerCallQueueCallAttempt;
		private EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity> _preAssessmentCustomerCallQueueCallAttempt;
		private EntityCollection<PreQualificationResultEntity> _preQualificationResult;
		private EntityCollection<ProspectCustomerCallEntity> _prospectCustomerCall;
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomerCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomerCollectionViaCallQueueCustomerCall;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaPreQualificationResult;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerAccountGlocomNumber;
		private EntityCollection<EventsEntity> _eventsCollectionViaPreQualificationResult;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult_____;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult____;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult______;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult________;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult_______;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult___;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult_;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaProspectCustomerCall;
		private EntityCollection<TagEntity> _tagCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<TagEntity> _tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
		private EntityCollection<TempCartEntity> _tempCartCollectionViaPreQualificationResult;
		private AccountEntity _account;
		private CallQueueEntity _callQueue;
		private CampaignEntity _campaign;
		private LookupEntity _lookup__;
		private LookupEntity _lookup;
		private LookupEntity _lookup_;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private CallDetailsEntity _callDetails;
		
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
			/// <summary>Member name CallQueue</summary>
			public static readonly string CallQueue = "CallQueue";
			/// <summary>Member name Campaign</summary>
			public static readonly string Campaign = "Campaign";
			/// <summary>Member name Lookup__</summary>
			public static readonly string Lookup__ = "Lookup__";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CallCenterNotes</summary>
			public static readonly string CallCenterNotes = "CallCenterNotes";
			/// <summary>Member name CallQueueCustomerCall</summary>
			public static readonly string CallQueueCustomerCall = "CallQueueCustomerCall";
			/// <summary>Member name CustomerAccountGlocomNumber</summary>
			public static readonly string CustomerAccountGlocomNumber = "CustomerAccountGlocomNumber";
			/// <summary>Member name CustomerCallQueueCallAttempt</summary>
			public static readonly string CustomerCallQueueCallAttempt = "CustomerCallQueueCallAttempt";
			/// <summary>Member name PreAssessmentCustomerCallQueueCallAttempt</summary>
			public static readonly string PreAssessmentCustomerCallQueueCallAttempt = "PreAssessmentCustomerCallQueueCallAttempt";
			/// <summary>Member name PreQualificationResult</summary>
			public static readonly string PreQualificationResult = "PreQualificationResult";
			/// <summary>Member name ProspectCustomerCall</summary>
			public static readonly string ProspectCustomerCall = "ProspectCustomerCall";
			/// <summary>Member name CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt = "CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name CallQueueCustomerCollectionViaCallQueueCustomerCall</summary>
			public static readonly string CallQueueCustomerCollectionViaCallQueueCustomerCall = "CallQueueCustomerCollectionViaCallQueueCustomerCall";
			/// <summary>Member name CustomerProfileCollectionViaPreQualificationResult</summary>
			public static readonly string CustomerProfileCollectionViaPreQualificationResult = "CustomerProfileCollectionViaPreQualificationResult";
			/// <summary>Member name CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt</summary>
			public static readonly string CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = "CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt";
			/// <summary>Member name CustomerProfileCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string CustomerProfileCollectionViaCustomerCallQueueCallAttempt = "CustomerProfileCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name CustomerProfileCollectionViaCustomerAccountGlocomNumber</summary>
			public static readonly string CustomerProfileCollectionViaCustomerAccountGlocomNumber = "CustomerProfileCollectionViaCustomerAccountGlocomNumber";
			/// <summary>Member name EventsCollectionViaPreQualificationResult</summary>
			public static readonly string EventsCollectionViaPreQualificationResult = "EventsCollectionViaPreQualificationResult";
			/// <summary>Member name LookupCollectionViaPreQualificationResult_____</summary>
			public static readonly string LookupCollectionViaPreQualificationResult_____ = "LookupCollectionViaPreQualificationResult_____";
			/// <summary>Member name LookupCollectionViaPreQualificationResult____</summary>
			public static readonly string LookupCollectionViaPreQualificationResult____ = "LookupCollectionViaPreQualificationResult____";
			/// <summary>Member name LookupCollectionViaPreQualificationResult______</summary>
			public static readonly string LookupCollectionViaPreQualificationResult______ = "LookupCollectionViaPreQualificationResult______";
			/// <summary>Member name LookupCollectionViaPreQualificationResult________</summary>
			public static readonly string LookupCollectionViaPreQualificationResult________ = "LookupCollectionViaPreQualificationResult________";
			/// <summary>Member name LookupCollectionViaPreQualificationResult_______</summary>
			public static readonly string LookupCollectionViaPreQualificationResult_______ = "LookupCollectionViaPreQualificationResult_______";
			/// <summary>Member name LookupCollectionViaPreQualificationResult___</summary>
			public static readonly string LookupCollectionViaPreQualificationResult___ = "LookupCollectionViaPreQualificationResult___";
			/// <summary>Member name LookupCollectionViaPreQualificationResult</summary>
			public static readonly string LookupCollectionViaPreQualificationResult = "LookupCollectionViaPreQualificationResult";
			/// <summary>Member name LookupCollectionViaPreQualificationResult_</summary>
			public static readonly string LookupCollectionViaPreQualificationResult_ = "LookupCollectionViaPreQualificationResult_";
			/// <summary>Member name LookupCollectionViaPreQualificationResult__</summary>
			public static readonly string LookupCollectionViaPreQualificationResult__ = "LookupCollectionViaPreQualificationResult__";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt = "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt</summary>
			public static readonly string OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = "OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt";
			/// <summary>Member name ProspectCustomerCollectionViaProspectCustomerCall</summary>
			public static readonly string ProspectCustomerCollectionViaProspectCustomerCall = "ProspectCustomerCollectionViaProspectCustomerCall";
			/// <summary>Member name TagCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string TagCollectionViaCustomerCallQueueCallAttempt = "TagCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt</summary>
			public static readonly string TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt = "TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt";
			/// <summary>Member name TempCartCollectionViaPreQualificationResult</summary>
			public static readonly string TempCartCollectionViaPreQualificationResult = "TempCartCollectionViaPreQualificationResult";
			/// <summary>Member name CallDetails</summary>
			public static readonly string CallDetails = "CallDetails";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CallsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CallsEntity():base("CallsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CallsEntity(IEntityFields2 fields):base("CallsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CallsEntity</param>
		public CallsEntity(IValidator validator):base("CallsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="callId">PK value for Calls which data should be fetched into this Calls object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallsEntity(System.Int64 callId):base("CallsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CallId = callId;
		}

		/// <summary> CTor</summary>
		/// <param name="callId">PK value for Calls which data should be fetched into this Calls object</param>
		/// <param name="validator">The custom validator object for this CallsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallsEntity(System.Int64 callId, IValidator validator):base("CallsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CallId = callId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CallsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callCenterNotes = (EntityCollection<CallCenterNotesEntity>)info.GetValue("_callCenterNotes", typeof(EntityCollection<CallCenterNotesEntity>));
				_callQueueCustomerCall = (EntityCollection<CallQueueCustomerCallEntity>)info.GetValue("_callQueueCustomerCall", typeof(EntityCollection<CallQueueCustomerCallEntity>));
				_customerAccountGlocomNumber = (EntityCollection<CustomerAccountGlocomNumberEntity>)info.GetValue("_customerAccountGlocomNumber", typeof(EntityCollection<CustomerAccountGlocomNumberEntity>));
				_customerCallQueueCallAttempt = (EntityCollection<CustomerCallQueueCallAttemptEntity>)info.GetValue("_customerCallQueueCallAttempt", typeof(EntityCollection<CustomerCallQueueCallAttemptEntity>));
				_preAssessmentCustomerCallQueueCallAttempt = (EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>)info.GetValue("_preAssessmentCustomerCallQueueCallAttempt", typeof(EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>));
				_preQualificationResult = (EntityCollection<PreQualificationResultEntity>)info.GetValue("_preQualificationResult", typeof(EntityCollection<PreQualificationResultEntity>));
				_prospectCustomerCall = (EntityCollection<ProspectCustomerCallEntity>)info.GetValue("_prospectCustomerCall", typeof(EntityCollection<ProspectCustomerCallEntity>));
				_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<CallQueueCustomerEntity>));
				_callQueueCustomerCollectionViaCallQueueCustomerCall = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomerCollectionViaCallQueueCustomerCall", typeof(EntityCollection<CallQueueCustomerEntity>));
				_customerProfileCollectionViaPreQualificationResult = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaPreQualificationResult", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerAccountGlocomNumber = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerAccountGlocomNumber", typeof(EntityCollection<CustomerProfileEntity>));
				_eventsCollectionViaPreQualificationResult = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaPreQualificationResult", typeof(EntityCollection<EventsEntity>));
				_lookupCollectionViaPreQualificationResult_____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult_____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult________ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult________", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult_______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult_______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult__", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_prospectCustomerCollectionViaProspectCustomerCall = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaProspectCustomerCall", typeof(EntityCollection<ProspectCustomerEntity>));
				_tagCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<TagEntity>)info.GetValue("_tagCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<TagEntity>));
				_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<TagEntity>)info.GetValue("_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt", typeof(EntityCollection<TagEntity>));
				_tempCartCollectionViaPreQualificationResult = (EntityCollection<TempCartEntity>)info.GetValue("_tempCartCollectionViaPreQualificationResult", typeof(EntityCollection<TempCartEntity>));
				_account = (AccountEntity)info.GetValue("_account", typeof(AccountEntity));
				if(_account!=null)
				{
					_account.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_callQueue = (CallQueueEntity)info.GetValue("_callQueue", typeof(CallQueueEntity));
				if(_callQueue!=null)
				{
					_callQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_campaign = (CampaignEntity)info.GetValue("_campaign", typeof(CampaignEntity));
				if(_campaign!=null)
				{
					_campaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup__ = (LookupEntity)info.GetValue("_lookup__", typeof(LookupEntity));
				if(_lookup__!=null)
				{
					_lookup__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup_ = (LookupEntity)info.GetValue("_lookup_", typeof(LookupEntity));
				if(_lookup_!=null)
				{
					_lookup_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_callDetails = (CallDetailsEntity)info.GetValue("_callDetails", typeof(CallDetailsEntity));
				if(_callDetails!=null)
				{
					_callDetails.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CallsFieldIndex)fieldIndex)
			{
				case CallsFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CallsFieldIndex.CampaignId:
					DesetupSyncCampaign(true, false);
					break;
				case CallsFieldIndex.NotInterestedReasonId:
					DesetupSyncLookup(true, false);
					break;
				case CallsFieldIndex.HealthPlanId:
					DesetupSyncAccount(true, false);
					break;
				case CallsFieldIndex.CallQueueId:
					DesetupSyncCallQueue(true, false);
					break;
				case CallsFieldIndex.DialerType:
					DesetupSyncLookup_(true, false);
					break;
				case CallsFieldIndex.ProductTypeId:
					DesetupSyncLookup__(true, false);
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
				case "CallQueue":
					this.CallQueue = (CallQueueEntity)entity;
					break;
				case "Campaign":
					this.Campaign = (CampaignEntity)entity;
					break;
				case "Lookup__":
					this.Lookup__ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CallCenterNotes":
					this.CallCenterNotes.Add((CallCenterNotesEntity)entity);
					break;
				case "CallQueueCustomerCall":
					this.CallQueueCustomerCall.Add((CallQueueCustomerCallEntity)entity);
					break;
				case "CustomerAccountGlocomNumber":
					this.CustomerAccountGlocomNumber.Add((CustomerAccountGlocomNumberEntity)entity);
					break;
				case "CustomerCallQueueCallAttempt":
					this.CustomerCallQueueCallAttempt.Add((CustomerCallQueueCallAttemptEntity)entity);
					break;
				case "PreAssessmentCustomerCallQueueCallAttempt":
					this.PreAssessmentCustomerCallQueueCallAttempt.Add((PreAssessmentCustomerCallQueueCallAttemptEntity)entity);
					break;
				case "PreQualificationResult":
					this.PreQualificationResult.Add((PreQualificationResultEntity)entity);
					break;
				case "ProspectCustomerCall":
					this.ProspectCustomerCall.Add((ProspectCustomerCallEntity)entity);
					break;
				case "CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt":
					this.CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt.Add((CallQueueCustomerEntity)entity);
					this.CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "CallQueueCustomerCollectionViaCallQueueCustomerCall":
					this.CallQueueCustomerCollectionViaCallQueueCustomerCall.IsReadOnly = false;
					this.CallQueueCustomerCollectionViaCallQueueCustomerCall.Add((CallQueueCustomerEntity)entity);
					this.CallQueueCustomerCollectionViaCallQueueCustomerCall.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaPreQualificationResult":
					this.CustomerProfileCollectionViaPreQualificationResult.IsReadOnly = false;
					this.CustomerProfileCollectionViaPreQualificationResult.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaPreQualificationResult.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					this.CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerCallQueueCallAttempt":
					this.CustomerProfileCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerCallQueueCallAttempt.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerAccountGlocomNumber":
					this.CustomerProfileCollectionViaCustomerAccountGlocomNumber.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerAccountGlocomNumber.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerAccountGlocomNumber.IsReadOnly = true;
					break;
				case "EventsCollectionViaPreQualificationResult":
					this.EventsCollectionViaPreQualificationResult.IsReadOnly = false;
					this.EventsCollectionViaPreQualificationResult.Add((EventsEntity)entity);
					this.EventsCollectionViaPreQualificationResult.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult_____":
					this.LookupCollectionViaPreQualificationResult_____.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult_____.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult_____.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult____":
					this.LookupCollectionViaPreQualificationResult____.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult____.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult____.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult______":
					this.LookupCollectionViaPreQualificationResult______.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult______.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult______.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult________":
					this.LookupCollectionViaPreQualificationResult________.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult________.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult________.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult_______":
					this.LookupCollectionViaPreQualificationResult_______.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult_______.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult_______.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult___":
					this.LookupCollectionViaPreQualificationResult___.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult___.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult___.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult":
					this.LookupCollectionViaPreQualificationResult.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult_":
					this.LookupCollectionViaPreQualificationResult_.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult_.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult_.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult__":
					this.LookupCollectionViaPreQualificationResult__.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult__.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt":
					this.OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					this.OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaProspectCustomerCall":
					this.ProspectCustomerCollectionViaProspectCustomerCall.IsReadOnly = false;
					this.ProspectCustomerCollectionViaProspectCustomerCall.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaProspectCustomerCall.IsReadOnly = true;
					break;
				case "TagCollectionViaCustomerCallQueueCallAttempt":
					this.TagCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.TagCollectionViaCustomerCallQueueCallAttempt.Add((TagEntity)entity);
					this.TagCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					this.TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Add((TagEntity)entity);
					this.TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "TempCartCollectionViaPreQualificationResult":
					this.TempCartCollectionViaPreQualificationResult.IsReadOnly = false;
					this.TempCartCollectionViaPreQualificationResult.Add((TempCartEntity)entity);
					this.TempCartCollectionViaPreQualificationResult.IsReadOnly = true;
					break;
				case "CallDetails":
					this.CallDetails = (CallDetailsEntity)entity;
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
			return CallsEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(CallsEntity.Relations.AccountEntityUsingHealthPlanId);
					break;
				case "CallQueue":
					toReturn.Add(CallsEntity.Relations.CallQueueEntityUsingCallQueueId);
					break;
				case "Campaign":
					toReturn.Add(CallsEntity.Relations.CampaignEntityUsingCampaignId);
					break;
				case "Lookup__":
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingProductTypeId);
					break;
				case "Lookup":
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingNotInterestedReasonId);
					break;
				case "Lookup_":
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingDialerType);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CallsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "CallCenterNotes":
					toReturn.Add(CallsEntity.Relations.CallCenterNotesEntityUsingCallId);
					break;
				case "CallQueueCustomerCall":
					toReturn.Add(CallsEntity.Relations.CallQueueCustomerCallEntityUsingCallId);
					break;
				case "CustomerAccountGlocomNumber":
					toReturn.Add(CallsEntity.Relations.CustomerAccountGlocomNumberEntityUsingCallId);
					break;
				case "CustomerCallQueueCallAttempt":
					toReturn.Add(CallsEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallId);
					break;
				case "PreAssessmentCustomerCallQueueCallAttempt":
					toReturn.Add(CallsEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCallId);
					break;
				case "PreQualificationResult":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId);
					break;
				case "ProspectCustomerCall":
					toReturn.Add(CallsEntity.Relations.ProspectCustomerCallEntityUsingCallId);
					break;
				case "CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(CallsEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallId, "CallsEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCustomerCollectionViaCallQueueCustomerCall":
					toReturn.Add(CallsEntity.Relations.CallQueueCustomerCallEntityUsingCallId, "CallsEntity__", "CallQueueCustomerCall_", JoinHint.None);
					toReturn.Add(CallQueueCustomerCallEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId, "CallQueueCustomerCall_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaPreQualificationResult":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.CustomerProfileEntityUsingCustomerId, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					toReturn.Add(CallsEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCallId, "CallsEntity__", "PreAssessmentCustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.CustomerProfileEntityUsingCustomerId, "PreAssessmentCustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(CallsEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallId, "CallsEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerAccountGlocomNumber":
					toReturn.Add(CallsEntity.Relations.CustomerAccountGlocomNumberEntityUsingCallId, "CallsEntity__", "CustomerAccountGlocomNumber_", JoinHint.None);
					toReturn.Add(CustomerAccountGlocomNumberEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerAccountGlocomNumber_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaPreQualificationResult":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.EventsEntityUsingEventId, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult_____":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingHighBloodPressure, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult____":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingHeartDisease, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult______":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingHighCholestrol, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult________":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingSmoker, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult_______":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingOverWeight, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult___":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingDiagnosedHeartProblem, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingAgeOverPreQualificationQuestion, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult_":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingChestPain, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult__":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingDiabetic, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(CallsEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallId, "CallsEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					toReturn.Add(CallsEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCallId, "CallsEntity__", "PreAssessmentCustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "PreAssessmentCustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaProspectCustomerCall":
					toReturn.Add(CallsEntity.Relations.ProspectCustomerCallEntityUsingCallId, "CallsEntity__", "ProspectCustomerCall_", JoinHint.None);
					toReturn.Add(ProspectCustomerCallEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "ProspectCustomerCall_", string.Empty, JoinHint.None);
					break;
				case "TagCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(CallsEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallId, "CallsEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.TagEntityUsingNotInterestedReasonId, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt":
					toReturn.Add(CallsEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCallId, "CallsEntity__", "PreAssessmentCustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.TagEntityUsingNotInterestedReasonId, "PreAssessmentCustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "TempCartCollectionViaPreQualificationResult":
					toReturn.Add(CallsEntity.Relations.PreQualificationResultEntityUsingCallId, "CallsEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.TempCartEntityUsingTempCartId, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "CallDetails":
					toReturn.Add(CallsEntity.Relations.CallDetailsEntityUsingCallDetailsId);
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
				case "CallQueue":
					SetupSyncCallQueue(relatedEntity);
					break;
				case "Campaign":
					SetupSyncCampaign(relatedEntity);
					break;
				case "Lookup__":
					SetupSyncLookup__(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CallCenterNotes":
					this.CallCenterNotes.Add((CallCenterNotesEntity)relatedEntity);
					break;
				case "CallQueueCustomerCall":
					this.CallQueueCustomerCall.Add((CallQueueCustomerCallEntity)relatedEntity);
					break;
				case "CustomerAccountGlocomNumber":
					this.CustomerAccountGlocomNumber.Add((CustomerAccountGlocomNumberEntity)relatedEntity);
					break;
				case "CustomerCallQueueCallAttempt":
					this.CustomerCallQueueCallAttempt.Add((CustomerCallQueueCallAttemptEntity)relatedEntity);
					break;
				case "PreAssessmentCustomerCallQueueCallAttempt":
					this.PreAssessmentCustomerCallQueueCallAttempt.Add((PreAssessmentCustomerCallQueueCallAttemptEntity)relatedEntity);
					break;
				case "PreQualificationResult":
					this.PreQualificationResult.Add((PreQualificationResultEntity)relatedEntity);
					break;
				case "ProspectCustomerCall":
					this.ProspectCustomerCall.Add((ProspectCustomerCallEntity)relatedEntity);
					break;
				case "CallDetails":
					SetupSyncCallDetails(relatedEntity);
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
				case "CallQueue":
					DesetupSyncCallQueue(false, true);
					break;
				case "Campaign":
					DesetupSyncCampaign(false, true);
					break;
				case "Lookup__":
					DesetupSyncLookup__(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CallCenterNotes":
					base.PerformRelatedEntityRemoval(this.CallCenterNotes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallQueueCustomerCall":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomerCall, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerAccountGlocomNumber":
					base.PerformRelatedEntityRemoval(this.CustomerAccountGlocomNumber, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerCallQueueCallAttempt":
					base.PerformRelatedEntityRemoval(this.CustomerCallQueueCallAttempt, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreAssessmentCustomerCallQueueCallAttempt":
					base.PerformRelatedEntityRemoval(this.PreAssessmentCustomerCallQueueCallAttempt, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreQualificationResult":
					base.PerformRelatedEntityRemoval(this.PreQualificationResult, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectCustomerCall":
					base.PerformRelatedEntityRemoval(this.ProspectCustomerCall, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallDetails":
					DesetupSyncCallDetails(false, true);
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
			if(_callDetails!=null)
			{
				toReturn.Add(_callDetails);
			}

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
			if(_callQueue!=null)
			{
				toReturn.Add(_callQueue);
			}
			if(_campaign!=null)
			{
				toReturn.Add(_campaign);
			}
			if(_lookup__!=null)
			{
				toReturn.Add(_lookup__);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
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
			toReturn.Add(this.CallCenterNotes);
			toReturn.Add(this.CallQueueCustomerCall);
			toReturn.Add(this.CustomerAccountGlocomNumber);
			toReturn.Add(this.CustomerCallQueueCallAttempt);
			toReturn.Add(this.PreAssessmentCustomerCallQueueCallAttempt);
			toReturn.Add(this.PreQualificationResult);
			toReturn.Add(this.ProspectCustomerCall);

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
				info.AddValue("_callCenterNotes", ((_callCenterNotes!=null) && (_callCenterNotes.Count>0) && !this.MarkedForDeletion)?_callCenterNotes:null);
				info.AddValue("_callQueueCustomerCall", ((_callQueueCustomerCall!=null) && (_callQueueCustomerCall.Count>0) && !this.MarkedForDeletion)?_callQueueCustomerCall:null);
				info.AddValue("_customerAccountGlocomNumber", ((_customerAccountGlocomNumber!=null) && (_customerAccountGlocomNumber.Count>0) && !this.MarkedForDeletion)?_customerAccountGlocomNumber:null);
				info.AddValue("_customerCallQueueCallAttempt", ((_customerCallQueueCallAttempt!=null) && (_customerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_customerCallQueueCallAttempt:null);
				info.AddValue("_preAssessmentCustomerCallQueueCallAttempt", ((_preAssessmentCustomerCallQueueCallAttempt!=null) && (_preAssessmentCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_preAssessmentCustomerCallQueueCallAttempt:null);
				info.AddValue("_preQualificationResult", ((_preQualificationResult!=null) && (_preQualificationResult.Count>0) && !this.MarkedForDeletion)?_preQualificationResult:null);
				info.AddValue("_prospectCustomerCall", ((_prospectCustomerCall!=null) && (_prospectCustomerCall.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCall:null);
				info.AddValue("_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt", ((_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt!=null) && (_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_callQueueCustomerCollectionViaCallQueueCustomerCall", ((_callQueueCustomerCollectionViaCallQueueCustomerCall!=null) && (_callQueueCustomerCollectionViaCallQueueCustomerCall.Count>0) && !this.MarkedForDeletion)?_callQueueCustomerCollectionViaCallQueueCustomerCall:null);
				info.AddValue("_customerProfileCollectionViaPreQualificationResult", ((_customerProfileCollectionViaPreQualificationResult!=null) && (_customerProfileCollectionViaPreQualificationResult.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaPreQualificationResult:null);
				info.AddValue("_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt", ((_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null) && (_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt:null);
				info.AddValue("_customerProfileCollectionViaCustomerCallQueueCallAttempt", ((_customerProfileCollectionViaCustomerCallQueueCallAttempt!=null) && (_customerProfileCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_customerProfileCollectionViaCustomerAccountGlocomNumber", ((_customerProfileCollectionViaCustomerAccountGlocomNumber!=null) && (_customerProfileCollectionViaCustomerAccountGlocomNumber.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerAccountGlocomNumber:null);
				info.AddValue("_eventsCollectionViaPreQualificationResult", ((_eventsCollectionViaPreQualificationResult!=null) && (_eventsCollectionViaPreQualificationResult.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaPreQualificationResult:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult_____", ((_lookupCollectionViaPreQualificationResult_____!=null) && (_lookupCollectionViaPreQualificationResult_____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult_____:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult____", ((_lookupCollectionViaPreQualificationResult____!=null) && (_lookupCollectionViaPreQualificationResult____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult____:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult______", ((_lookupCollectionViaPreQualificationResult______!=null) && (_lookupCollectionViaPreQualificationResult______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult______:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult________", ((_lookupCollectionViaPreQualificationResult________!=null) && (_lookupCollectionViaPreQualificationResult________.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult________:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult_______", ((_lookupCollectionViaPreQualificationResult_______!=null) && (_lookupCollectionViaPreQualificationResult_______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult_______:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult___", ((_lookupCollectionViaPreQualificationResult___!=null) && (_lookupCollectionViaPreQualificationResult___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult___:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult", ((_lookupCollectionViaPreQualificationResult!=null) && (_lookupCollectionViaPreQualificationResult.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult_", ((_lookupCollectionViaPreQualificationResult_!=null) && (_lookupCollectionViaPreQualificationResult_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult_:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult__", ((_lookupCollectionViaPreQualificationResult__!=null) && (_lookupCollectionViaPreQualificationResult__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult__:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt", ((_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt!=null) && (_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt", ((_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null) && (_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt:null);
				info.AddValue("_prospectCustomerCollectionViaProspectCustomerCall", ((_prospectCustomerCollectionViaProspectCustomerCall!=null) && (_prospectCustomerCollectionViaProspectCustomerCall.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaProspectCustomerCall:null);
				info.AddValue("_tagCollectionViaCustomerCallQueueCallAttempt", ((_tagCollectionViaCustomerCallQueueCallAttempt!=null) && (_tagCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_tagCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt", ((_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null) && (_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt:null);
				info.AddValue("_tempCartCollectionViaPreQualificationResult", ((_tempCartCollectionViaPreQualificationResult!=null) && (_tempCartCollectionViaPreQualificationResult.Count>0) && !this.MarkedForDeletion)?_tempCartCollectionViaPreQualificationResult:null);
				info.AddValue("_account", (!this.MarkedForDeletion?_account:null));
				info.AddValue("_callQueue", (!this.MarkedForDeletion?_callQueue:null));
				info.AddValue("_campaign", (!this.MarkedForDeletion?_campaign:null));
				info.AddValue("_lookup__", (!this.MarkedForDeletion?_lookup__:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_callDetails", (!this.MarkedForDeletion?_callDetails:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CallsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CallsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CallsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallCenterNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallCenterNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallCenterNotesFields.CallId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomerCall' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerCallFields.CallId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerAccountGlocomNumber' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerAccountGlocomNumber()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerAccountGlocomNumberFields.CallId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerCallQueueCallAttempt' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerCallQueueCallAttemptFields.CallId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreAssessmentCustomerCallQueueCallAttempt' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreAssessmentCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreAssessmentCustomerCallQueueCallAttemptFields.CallId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationResult' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationResultFields.CallId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomerCall' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerCallFields.CallId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerCollectionViaCallQueueCustomerCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCustomerCollectionViaCallQueueCustomerCall"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaPreQualificationResult"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerAccountGlocomNumber()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerAccountGlocomNumber"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaPreQualificationResult"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaProspectCustomerCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaProspectCustomerCall"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Tag' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTagCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TagCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Tag' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTagCollectionViaPreAssessmentCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TempCart' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTempCartCollectionViaPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TempCartCollectionViaPreQualificationResult"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId, "CallsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Account' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.HealthPlanId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Campaign' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ProductTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.NotInterestedReasonId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.DialerType));
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
		/// the related entity of type 'CallDetails' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallDetailsFields.CallDetailsId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CallsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callCenterNotes);
			collectionsQueue.Enqueue(this._callQueueCustomerCall);
			collectionsQueue.Enqueue(this._customerAccountGlocomNumber);
			collectionsQueue.Enqueue(this._customerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._preAssessmentCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._preQualificationResult);
			collectionsQueue.Enqueue(this._prospectCustomerCall);
			collectionsQueue.Enqueue(this._callQueueCustomerCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._callQueueCustomerCollectionViaCallQueueCustomerCall);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaPreQualificationResult);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerAccountGlocomNumber);
			collectionsQueue.Enqueue(this._eventsCollectionViaPreQualificationResult);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult_____);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult____);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult______);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult________);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult_______);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult___);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult_);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaProspectCustomerCall);
			collectionsQueue.Enqueue(this._tagCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._tempCartCollectionViaPreQualificationResult);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callCenterNotes = (EntityCollection<CallCenterNotesEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomerCall = (EntityCollection<CallQueueCustomerCallEntity>) collectionsQueue.Dequeue();
			this._customerAccountGlocomNumber = (EntityCollection<CustomerAccountGlocomNumberEntity>) collectionsQueue.Dequeue();
			this._customerCallQueueCallAttempt = (EntityCollection<CustomerCallQueueCallAttemptEntity>) collectionsQueue.Dequeue();
			this._preAssessmentCustomerCallQueueCallAttempt = (EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>) collectionsQueue.Dequeue();
			this._preQualificationResult = (EntityCollection<PreQualificationResultEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCall = (EntityCollection<ProspectCustomerCallEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomerCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomerCollectionViaCallQueueCustomerCall = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaPreQualificationResult = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerAccountGlocomNumber = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaPreQualificationResult = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult_____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult________ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult_______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaProspectCustomerCall = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
			this._tagCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<TagEntity>) collectionsQueue.Dequeue();
			this._tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt = (EntityCollection<TagEntity>) collectionsQueue.Dequeue();
			this._tempCartCollectionViaPreQualificationResult = (EntityCollection<TempCartEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callCenterNotes != null)
			{
				return true;
			}
			if (this._callQueueCustomerCall != null)
			{
				return true;
			}
			if (this._customerAccountGlocomNumber != null)
			{
				return true;
			}
			if (this._customerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._preAssessmentCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._preQualificationResult != null)
			{
				return true;
			}
			if (this._prospectCustomerCall != null)
			{
				return true;
			}
			if (this._callQueueCustomerCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._callQueueCustomerCollectionViaCallQueueCustomerCall != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaPreQualificationResult != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerAccountGlocomNumber != null)
			{
				return true;
			}
			if (this._eventsCollectionViaPreQualificationResult != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult_____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult________ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult_______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaProspectCustomerCall != null)
			{
				return true;
			}
			if (this._tagCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._tempCartCollectionViaPreQualificationResult != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallCenterNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerCallEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerAccountGlocomNumberEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerAccountGlocomNumberEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerCallQueueCallAttemptEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreAssessmentCustomerCallQueueCallAttemptEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationResultEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerCallEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory))) : null);
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
			toReturn.Add("CallQueue", _callQueue);
			toReturn.Add("Campaign", _campaign);
			toReturn.Add("Lookup__", _lookup__);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CallCenterNotes", _callCenterNotes);
			toReturn.Add("CallQueueCustomerCall", _callQueueCustomerCall);
			toReturn.Add("CustomerAccountGlocomNumber", _customerAccountGlocomNumber);
			toReturn.Add("CustomerCallQueueCallAttempt", _customerCallQueueCallAttempt);
			toReturn.Add("PreAssessmentCustomerCallQueueCallAttempt", _preAssessmentCustomerCallQueueCallAttempt);
			toReturn.Add("PreQualificationResult", _preQualificationResult);
			toReturn.Add("ProspectCustomerCall", _prospectCustomerCall);
			toReturn.Add("CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt", _callQueueCustomerCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("CallQueueCustomerCollectionViaCallQueueCustomerCall", _callQueueCustomerCollectionViaCallQueueCustomerCall);
			toReturn.Add("CustomerProfileCollectionViaPreQualificationResult", _customerProfileCollectionViaPreQualificationResult);
			toReturn.Add("CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt", _customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			toReturn.Add("CustomerProfileCollectionViaCustomerCallQueueCallAttempt", _customerProfileCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("CustomerProfileCollectionViaCustomerAccountGlocomNumber", _customerProfileCollectionViaCustomerAccountGlocomNumber);
			toReturn.Add("EventsCollectionViaPreQualificationResult", _eventsCollectionViaPreQualificationResult);
			toReturn.Add("LookupCollectionViaPreQualificationResult_____", _lookupCollectionViaPreQualificationResult_____);
			toReturn.Add("LookupCollectionViaPreQualificationResult____", _lookupCollectionViaPreQualificationResult____);
			toReturn.Add("LookupCollectionViaPreQualificationResult______", _lookupCollectionViaPreQualificationResult______);
			toReturn.Add("LookupCollectionViaPreQualificationResult________", _lookupCollectionViaPreQualificationResult________);
			toReturn.Add("LookupCollectionViaPreQualificationResult_______", _lookupCollectionViaPreQualificationResult_______);
			toReturn.Add("LookupCollectionViaPreQualificationResult___", _lookupCollectionViaPreQualificationResult___);
			toReturn.Add("LookupCollectionViaPreQualificationResult", _lookupCollectionViaPreQualificationResult);
			toReturn.Add("LookupCollectionViaPreQualificationResult_", _lookupCollectionViaPreQualificationResult_);
			toReturn.Add("LookupCollectionViaPreQualificationResult__", _lookupCollectionViaPreQualificationResult__);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt", _organizationRoleUserCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt", _organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			toReturn.Add("ProspectCustomerCollectionViaProspectCustomerCall", _prospectCustomerCollectionViaProspectCustomerCall);
			toReturn.Add("TagCollectionViaCustomerCallQueueCallAttempt", _tagCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt", _tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt);
			toReturn.Add("TempCartCollectionViaPreQualificationResult", _tempCartCollectionViaPreQualificationResult);
			toReturn.Add("CallDetails", _callDetails);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callCenterNotes!=null)
			{
				_callCenterNotes.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomerCall!=null)
			{
				_callQueueCustomerCall.ActiveContext = base.ActiveContext;
			}
			if(_customerAccountGlocomNumber!=null)
			{
				_customerAccountGlocomNumber.ActiveContext = base.ActiveContext;
			}
			if(_customerCallQueueCallAttempt!=null)
			{
				_customerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_preAssessmentCustomerCallQueueCallAttempt!=null)
			{
				_preAssessmentCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationResult!=null)
			{
				_preQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCall!=null)
			{
				_prospectCustomerCall.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomerCollectionViaCallQueueCustomerCall!=null)
			{
				_callQueueCustomerCollectionViaCallQueueCustomerCall.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaPreQualificationResult!=null)
			{
				_customerProfileCollectionViaPreQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null)
			{
				_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_customerProfileCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerAccountGlocomNumber!=null)
			{
				_customerProfileCollectionViaCustomerAccountGlocomNumber.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaPreQualificationResult!=null)
			{
				_eventsCollectionViaPreQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult_____!=null)
			{
				_lookupCollectionViaPreQualificationResult_____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult____!=null)
			{
				_lookupCollectionViaPreQualificationResult____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult______!=null)
			{
				_lookupCollectionViaPreQualificationResult______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult________!=null)
			{
				_lookupCollectionViaPreQualificationResult________.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult_______!=null)
			{
				_lookupCollectionViaPreQualificationResult_______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult___!=null)
			{
				_lookupCollectionViaPreQualificationResult___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult!=null)
			{
				_lookupCollectionViaPreQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult_!=null)
			{
				_lookupCollectionViaPreQualificationResult_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult__!=null)
			{
				_lookupCollectionViaPreQualificationResult__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null)
			{
				_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaProspectCustomerCall!=null)
			{
				_prospectCustomerCollectionViaProspectCustomerCall.ActiveContext = base.ActiveContext;
			}
			if(_tagCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_tagCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt!=null)
			{
				_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_tempCartCollectionViaPreQualificationResult!=null)
			{
				_tempCartCollectionViaPreQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_callQueue!=null)
			{
				_callQueue.ActiveContext = base.ActiveContext;
			}
			if(_campaign!=null)
			{
				_campaign.ActiveContext = base.ActiveContext;
			}
			if(_lookup__!=null)
			{
				_lookup__.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_callDetails!=null)
			{
				_callDetails.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callCenterNotes = null;
			_callQueueCustomerCall = null;
			_customerAccountGlocomNumber = null;
			_customerCallQueueCallAttempt = null;
			_preAssessmentCustomerCallQueueCallAttempt = null;
			_preQualificationResult = null;
			_prospectCustomerCall = null;
			_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt = null;
			_callQueueCustomerCollectionViaCallQueueCustomerCall = null;
			_customerProfileCollectionViaPreQualificationResult = null;
			_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = null;
			_customerProfileCollectionViaCustomerCallQueueCallAttempt = null;
			_customerProfileCollectionViaCustomerAccountGlocomNumber = null;
			_eventsCollectionViaPreQualificationResult = null;
			_lookupCollectionViaPreQualificationResult_____ = null;
			_lookupCollectionViaPreQualificationResult____ = null;
			_lookupCollectionViaPreQualificationResult______ = null;
			_lookupCollectionViaPreQualificationResult________ = null;
			_lookupCollectionViaPreQualificationResult_______ = null;
			_lookupCollectionViaPreQualificationResult___ = null;
			_lookupCollectionViaPreQualificationResult = null;
			_lookupCollectionViaPreQualificationResult_ = null;
			_lookupCollectionViaPreQualificationResult__ = null;
			_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = null;
			_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = null;
			_prospectCustomerCollectionViaProspectCustomerCall = null;
			_tagCollectionViaCustomerCallQueueCallAttempt = null;
			_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt = null;
			_tempCartCollectionViaPreQualificationResult = null;
			_account = null;
			_callQueue = null;
			_campaign = null;
			_lookup__ = null;
			_lookup = null;
			_lookup_ = null;
			_organizationRoleUser = null;
			_callDetails = null;
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

			_fieldsCustomProperties.Add("CallId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsNewCustomer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CalledCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TimeCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TimeEnd", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallBackNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IncomingPhoneLine", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallersPhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallerName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PromoCodeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OutBound", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Disposition", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReadAndUnderstoodNotes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsUploaded", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotInterestedReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HealthPlanId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallQueueId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomTags", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsContacted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DialerType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvalidNumberCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProductTypeId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _account</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAccount(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CallsEntity.Relations.AccountEntityUsingHealthPlanId, true, signalRelatedEntity, "Calls", resetFKFields, new int[] { (int)CallsFieldIndex.HealthPlanId } );		
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
				base.PerformSetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CallsEntity.Relations.AccountEntityUsingHealthPlanId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _callQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", CallsEntity.Relations.CallQueueEntityUsingCallQueueId, true, signalRelatedEntity, "Calls", resetFKFields, new int[] { (int)CallsFieldIndex.CallQueueId } );		
			_callQueue = null;
		}

		/// <summary> setups the sync logic for member _callQueue</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCallQueue(IEntity2 relatedEntity)
		{
			if(_callQueue!=relatedEntity)
			{
				DesetupSyncCallQueue(true, true);
				_callQueue = (CallQueueEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", CallsEntity.Relations.CallQueueEntityUsingCallQueueId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallQueuePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _campaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", CallsEntity.Relations.CampaignEntityUsingCampaignId, true, signalRelatedEntity, "Calls", resetFKFields, new int[] { (int)CallsFieldIndex.CampaignId } );		
			_campaign = null;
		}

		/// <summary> setups the sync logic for member _campaign</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCampaign(IEntity2 relatedEntity)
		{
			if(_campaign!=relatedEntity)
			{
				DesetupSyncCampaign(true, true);
				_campaign = (CampaignEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", CallsEntity.Relations.CampaignEntityUsingCampaignId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCampaignPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", CallsEntity.Relations.LookupEntityUsingProductTypeId, true, signalRelatedEntity, "Calls__", resetFKFields, new int[] { (int)CallsFieldIndex.ProductTypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", CallsEntity.Relations.LookupEntityUsingProductTypeId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallsEntity.Relations.LookupEntityUsingNotInterestedReasonId, true, signalRelatedEntity, "Calls", resetFKFields, new int[] { (int)CallsFieldIndex.NotInterestedReasonId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallsEntity.Relations.LookupEntityUsingNotInterestedReasonId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", CallsEntity.Relations.LookupEntityUsingDialerType, true, signalRelatedEntity, "Calls_", resetFKFields, new int[] { (int)CallsFieldIndex.DialerType } );		
			_lookup_ = null;
		}

		/// <summary> setups the sync logic for member _lookup_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup_(IEntity2 relatedEntity)
		{
			if(_lookup_!=relatedEntity)
			{
				DesetupSyncLookup_(true, true);
				_lookup_ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", CallsEntity.Relations.LookupEntityUsingDialerType, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "Calls", resetFKFields, new int[] { (int)CallsFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _callDetails</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallDetails(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callDetails, new PropertyChangedEventHandler( OnCallDetailsPropertyChanged ), "CallDetails", CallsEntity.Relations.CallDetailsEntityUsingCallDetailsId, false, signalRelatedEntity, "Calls", false, new int[] { (int)CallsFieldIndex.CallId } );
			_callDetails = null;
		}
		
		/// <summary> setups the sync logic for member _callDetails</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCallDetails(IEntity2 relatedEntity)
		{
			if(_callDetails!=relatedEntity)
			{
				DesetupSyncCallDetails(true, true);
				_callDetails = (CallDetailsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _callDetails, new PropertyChangedEventHandler( OnCallDetailsPropertyChanged ), "CallDetails", CallsEntity.Relations.CallDetailsEntityUsingCallDetailsId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallDetailsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CallsEntity</param>
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
		public  static CallsRelations Relations
		{
			get	{ return new CallsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallCenterNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallCenterNotes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallCenterNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallCenterNotes")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CallCenterNotesEntity, 0, null, null, null, null, "CallCenterNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomerCall' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerCall
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerCallEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomerCall")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CallQueueCustomerCallEntity, 0, null, null, null, null, "CallQueueCustomerCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerAccountGlocomNumber' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerAccountGlocomNumber
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerAccountGlocomNumberEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerAccountGlocomNumberEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerAccountGlocomNumber")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CustomerAccountGlocomNumberEntity, 0, null, null, null, null, "CustomerAccountGlocomNumber", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerCallQueueCallAttempt' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerCallQueueCallAttempt
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerCallQueueCallAttemptEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerCallQueueCallAttempt")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CustomerCallQueueCallAttemptEntity, 0, null, null, null, null, "CustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreAssessmentCustomerCallQueueCallAttempt' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreAssessmentCustomerCallQueueCallAttemptEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreAssessmentCustomerCallQueueCallAttempt")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.PreAssessmentCustomerCallQueueCallAttemptEntity, 0, null, null, null, null, "PreAssessmentCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationResult' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationResult
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreQualificationResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationResultEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationResult")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.PreQualificationResultEntity, 0, null, null, null, null, "PreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomerCall' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCall
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerCallEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectCustomerCall")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.ProspectCustomerCallEntity, 0, null, null, null, null, "ProspectCustomerCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, GetRelationsForField("CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt"), null, "CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerCollectionViaCallQueueCustomerCall
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.CallQueueCustomerCallEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomerCall_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, GetRelationsForField("CallQueueCustomerCollectionViaCallQueueCustomerCall"), null, "CallQueueCustomerCollectionViaCallQueueCustomerCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaPreQualificationResult
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaPreQualificationResult"), null, "CustomerProfileCollectionViaPreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreAssessmentCustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt"), null, "CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerCallQueueCallAttempt"), null, "CustomerProfileCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerAccountGlocomNumber
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.CustomerAccountGlocomNumberEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "CustomerAccountGlocomNumber_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerAccountGlocomNumber"), null, "CustomerProfileCollectionViaCustomerAccountGlocomNumber", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaPreQualificationResult
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaPreQualificationResult"), null, "EventsCollectionViaPreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult_____
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult_____"), null, "LookupCollectionViaPreQualificationResult_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult____
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult____"), null, "LookupCollectionViaPreQualificationResult____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult______
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult______"), null, "LookupCollectionViaPreQualificationResult______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult________
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult________"), null, "LookupCollectionViaPreQualificationResult________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult_______
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult_______"), null, "LookupCollectionViaPreQualificationResult_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult___
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult___"), null, "LookupCollectionViaPreQualificationResult___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult"), null, "LookupCollectionViaPreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult_
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult_"), null, "LookupCollectionViaPreQualificationResult_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult__
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult__"), null, "LookupCollectionViaPreQualificationResult__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt"), null, "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreAssessmentCustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt"), null, "OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaProspectCustomerCall
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.ProspectCustomerCallEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "ProspectCustomerCall_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaProspectCustomerCall"), null, "ProspectCustomerCollectionViaProspectCustomerCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Tag' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTagCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<TagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.TagEntity, 0, null, null, GetRelationsForField("TagCollectionViaCustomerCallQueueCallAttempt"), null, "TagCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Tag' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTagCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreAssessmentCustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<TagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.TagEntity, 0, null, null, GetRelationsForField("TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt"), null, "TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TempCart' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTempCartCollectionViaPreQualificationResult
		{
			get
			{
				IEntityRelation intermediateRelation = CallsEntity.Relations.PreQualificationResultEntityUsingCallId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.TempCartEntity, 0, null, null, GetRelationsForField("TempCartCollectionViaPreQualificationResult"), null, "TempCartCollectionViaPreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueue
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueue")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, null, null, "CallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaign
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("Campaign")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, null, null, "Campaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup__")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallDetails
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallDetails")[0], (int)Falcon.Data.EntityType.CallsEntity, (int)Falcon.Data.EntityType.CallDetailsEntity, 0, null, null, null, null, "CallDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CallsEntity.CustomProperties;}
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
			get { return CallsEntity.FieldsCustomProperties;}
		}

		/// <summary> The CallId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CallID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CallId
		{
			get { return (System.Int64)GetValue((int)CallsFieldIndex.CallId, true); }
			set	{ SetValue((int)CallsFieldIndex.CallId, value); }
		}

		/// <summary> The IsNewCustomer property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."IsNewCustomer"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsNewCustomer
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CallsFieldIndex.IsNewCustomer, false); }
			set	{ SetValue((int)CallsFieldIndex.IsNewCustomer, value); }
		}

		/// <summary> The CalledCustomerId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CalledCustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CalledCustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.CalledCustomerId, false); }
			set	{ SetValue((int)CallsFieldIndex.CalledCustomerId, value); }
		}

		/// <summary> The TimeCreated property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."TimeCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> TimeCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallsFieldIndex.TimeCreated, false); }
			set	{ SetValue((int)CallsFieldIndex.TimeCreated, value); }
		}

		/// <summary> The TimeEnd property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."TimeEnd"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> TimeEnd
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallsFieldIndex.TimeEnd, false); }
			set	{ SetValue((int)CallsFieldIndex.TimeEnd, value); }
		}

		/// <summary> The CallStatus property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CallStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CallStatus
		{
			get { return (System.String)GetValue((int)CallsFieldIndex.CallStatus, true); }
			set	{ SetValue((int)CallsFieldIndex.CallStatus, value); }
		}

		/// <summary> The EventId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EventId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.EventId, false); }
			set	{ SetValue((int)CallsFieldIndex.EventId, value); }
		}

		/// <summary> The DateCreated property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CallsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CallsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)CallsFieldIndex.DateModified, true); }
			set	{ SetValue((int)CallsFieldIndex.DateModified, value); }
		}

		/// <summary> The CallBackNumber property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CallBackNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CallBackNumber
		{
			get { return (System.String)GetValue((int)CallsFieldIndex.CallBackNumber, true); }
			set	{ SetValue((int)CallsFieldIndex.CallBackNumber, value); }
		}

		/// <summary> The IncomingPhoneLine property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."IncomingPhoneLine"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IncomingPhoneLine
		{
			get { return (System.String)GetValue((int)CallsFieldIndex.IncomingPhoneLine, true); }
			set	{ SetValue((int)CallsFieldIndex.IncomingPhoneLine, value); }
		}

		/// <summary> The CallersPhoneNumber property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CallersPhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CallersPhoneNumber
		{
			get { return (System.String)GetValue((int)CallsFieldIndex.CallersPhoneNumber, true); }
			set	{ SetValue((int)CallsFieldIndex.CallersPhoneNumber, value); }
		}

		/// <summary> The CallerName property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CallerName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CallerName
		{
			get { return (System.String)GetValue((int)CallsFieldIndex.CallerName, true); }
			set	{ SetValue((int)CallsFieldIndex.CallerName, value); }
		}

		/// <summary> The PromoCodeId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."PromoCodeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PromoCodeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.PromoCodeId, false); }
			set	{ SetValue((int)CallsFieldIndex.PromoCodeId, value); }
		}

		/// <summary> The AffiliateId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."AffiliateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AffiliateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.AffiliateId, false); }
			set	{ SetValue((int)CallsFieldIndex.AffiliateId, value); }
		}

		/// <summary> The OutBound property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."OutBound"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> OutBound
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CallsFieldIndex.OutBound, false); }
			set	{ SetValue((int)CallsFieldIndex.OutBound, value); }
		}

		/// <summary> The Status property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Status
		{
			get { return (System.Int64)GetValue((int)CallsFieldIndex.Status, true); }
			set	{ SetValue((int)CallsFieldIndex.Status, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)CallsFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)CallsFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The Disposition property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."Disposition"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Disposition
		{
			get { return (System.String)GetValue((int)CallsFieldIndex.Disposition, true); }
			set	{ SetValue((int)CallsFieldIndex.Disposition, value); }
		}

		/// <summary> The ReadAndUnderstoodNotes property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."ReadAndUnderstoodNotes"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> ReadAndUnderstoodNotes
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CallsFieldIndex.ReadAndUnderstoodNotes, false); }
			set	{ SetValue((int)CallsFieldIndex.ReadAndUnderstoodNotes, value); }
		}

		/// <summary> The IsUploaded property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."IsUploaded"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsUploaded
		{
			get { return (System.Boolean)GetValue((int)CallsFieldIndex.IsUploaded, true); }
			set	{ SetValue((int)CallsFieldIndex.IsUploaded, value); }
		}

		/// <summary> The CampaignId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CampaignId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CampaignId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.CampaignId, false); }
			set	{ SetValue((int)CallsFieldIndex.CampaignId, value); }
		}

		/// <summary> The NotInterestedReasonId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."NotInterestedReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> NotInterestedReasonId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.NotInterestedReasonId, false); }
			set	{ SetValue((int)CallsFieldIndex.NotInterestedReasonId, value); }
		}

		/// <summary> The HealthPlanId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."HealthPlanId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HealthPlanId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.HealthPlanId, false); }
			set	{ SetValue((int)CallsFieldIndex.HealthPlanId, value); }
		}

		/// <summary> The CallQueueId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CallQueueId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CallQueueId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.CallQueueId, false); }
			set	{ SetValue((int)CallsFieldIndex.CallQueueId, value); }
		}

		/// <summary> The CustomTags property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."CustomTags"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CustomTags
		{
			get { return (System.String)GetValue((int)CallsFieldIndex.CustomTags, true); }
			set	{ SetValue((int)CallsFieldIndex.CustomTags, value); }
		}

		/// <summary> The IsContacted property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."IsContacted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsContacted
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CallsFieldIndex.IsContacted, false); }
			set	{ SetValue((int)CallsFieldIndex.IsContacted, value); }
		}

		/// <summary> The DialerType property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."DialerType"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DialerType
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.DialerType, false); }
			set	{ SetValue((int)CallsFieldIndex.DialerType, value); }
		}

		/// <summary> The InvalidNumberCount property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."InvalidNumberCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte InvalidNumberCount
		{
			get { return (System.Byte)GetValue((int)CallsFieldIndex.InvalidNumberCount, true); }
			set	{ SetValue((int)CallsFieldIndex.InvalidNumberCount, value); }
		}

		/// <summary> The ProductTypeId property of the Entity Calls<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCalls"."ProductTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProductTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallsFieldIndex.ProductTypeId, false); }
			set	{ SetValue((int)CallsFieldIndex.ProductTypeId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallCenterNotesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallCenterNotesEntity))]
		public virtual EntityCollection<CallCenterNotesEntity> CallCenterNotes
		{
			get
			{
				if(_callCenterNotes==null)
				{
					_callCenterNotes = new EntityCollection<CallCenterNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterNotesEntityFactory)));
					_callCenterNotes.SetContainingEntityInfo(this, "Calls");
				}
				return _callCenterNotes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerCallEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerCallEntity))]
		public virtual EntityCollection<CallQueueCustomerCallEntity> CallQueueCustomerCall
		{
			get
			{
				if(_callQueueCustomerCall==null)
				{
					_callQueueCustomerCall = new EntityCollection<CallQueueCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerCallEntityFactory)));
					_callQueueCustomerCall.SetContainingEntityInfo(this, "Calls");
				}
				return _callQueueCustomerCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerAccountGlocomNumberEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerAccountGlocomNumberEntity))]
		public virtual EntityCollection<CustomerAccountGlocomNumberEntity> CustomerAccountGlocomNumber
		{
			get
			{
				if(_customerAccountGlocomNumber==null)
				{
					_customerAccountGlocomNumber = new EntityCollection<CustomerAccountGlocomNumberEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerAccountGlocomNumberEntityFactory)));
					_customerAccountGlocomNumber.SetContainingEntityInfo(this, "Calls");
				}
				return _customerAccountGlocomNumber;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerCallQueueCallAttemptEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerCallQueueCallAttemptEntity))]
		public virtual EntityCollection<CustomerCallQueueCallAttemptEntity> CustomerCallQueueCallAttempt
		{
			get
			{
				if(_customerCallQueueCallAttempt==null)
				{
					_customerCallQueueCallAttempt = new EntityCollection<CustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerCallQueueCallAttemptEntityFactory)));
					_customerCallQueueCallAttempt.SetContainingEntityInfo(this, "Calls");
				}
				return _customerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreAssessmentCustomerCallQueueCallAttemptEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreAssessmentCustomerCallQueueCallAttemptEntity))]
		public virtual EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity> PreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				if(_preAssessmentCustomerCallQueueCallAttempt==null)
				{
					_preAssessmentCustomerCallQueueCallAttempt = new EntityCollection<PreAssessmentCustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreAssessmentCustomerCallQueueCallAttemptEntityFactory)));
					_preAssessmentCustomerCallQueueCallAttempt.SetContainingEntityInfo(this, "Calls");
				}
				return _preAssessmentCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationResultEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationResultEntity))]
		public virtual EntityCollection<PreQualificationResultEntity> PreQualificationResult
		{
			get
			{
				if(_preQualificationResult==null)
				{
					_preQualificationResult = new EntityCollection<PreQualificationResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationResultEntityFactory)));
					_preQualificationResult.SetContainingEntityInfo(this, "Calls");
				}
				return _preQualificationResult;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerCallEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerCallEntity))]
		public virtual EntityCollection<ProspectCustomerCallEntity> ProspectCustomerCall
		{
			get
			{
				if(_prospectCustomerCall==null)
				{
					_prospectCustomerCall = new EntityCollection<ProspectCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerCallEntityFactory)));
					_prospectCustomerCall.SetContainingEntityInfo(this, "Calls");
				}
				return _prospectCustomerCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomerCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomerCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _callQueueCustomerCollectionViaCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomerCollectionViaCallQueueCustomerCall
		{
			get
			{
				if(_callQueueCustomerCollectionViaCallQueueCustomerCall==null)
				{
					_callQueueCustomerCollectionViaCallQueueCustomerCall = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomerCollectionViaCallQueueCustomerCall.IsReadOnly=true;
				}
				return _callQueueCustomerCollectionViaCallQueueCustomerCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaPreQualificationResult
		{
			get
			{
				if(_customerProfileCollectionViaPreQualificationResult==null)
				{
					_customerProfileCollectionViaPreQualificationResult = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaPreQualificationResult.IsReadOnly=true;
				}
				return _customerProfileCollectionViaPreQualificationResult;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				if(_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt==null)
				{
					_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _customerProfileCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_customerProfileCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_customerProfileCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerAccountGlocomNumber
		{
			get
			{
				if(_customerProfileCollectionViaCustomerAccountGlocomNumber==null)
				{
					_customerProfileCollectionViaCustomerAccountGlocomNumber = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerAccountGlocomNumber.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerAccountGlocomNumber;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaPreQualificationResult
		{
			get
			{
				if(_eventsCollectionViaPreQualificationResult==null)
				{
					_eventsCollectionViaPreQualificationResult = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaPreQualificationResult.IsReadOnly=true;
				}
				return _eventsCollectionViaPreQualificationResult;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult_____
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult_____==null)
				{
					_lookupCollectionViaPreQualificationResult_____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult_____.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult____
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult____==null)
				{
					_lookupCollectionViaPreQualificationResult____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult____.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult______
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult______==null)
				{
					_lookupCollectionViaPreQualificationResult______ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult______.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult________
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult________==null)
				{
					_lookupCollectionViaPreQualificationResult________ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult________.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult_______
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult_______==null)
				{
					_lookupCollectionViaPreQualificationResult_______ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult_______.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult___
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult___==null)
				{
					_lookupCollectionViaPreQualificationResult___ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult___.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult==null)
				{
					_lookupCollectionViaPreQualificationResult = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult_
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult_==null)
				{
					_lookupCollectionViaPreQualificationResult_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult_.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult__
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult__==null)
				{
					_lookupCollectionViaPreQualificationResult__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult__.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				if(_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt==null)
				{
					_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerEntity))]
		public virtual EntityCollection<ProspectCustomerEntity> ProspectCustomerCollectionViaProspectCustomerCall
		{
			get
			{
				if(_prospectCustomerCollectionViaProspectCustomerCall==null)
				{
					_prospectCustomerCollectionViaProspectCustomerCall = new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory)));
					_prospectCustomerCollectionViaProspectCustomerCall.IsReadOnly=true;
				}
				return _prospectCustomerCollectionViaProspectCustomerCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TagEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TagEntity))]
		public virtual EntityCollection<TagEntity> TagCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_tagCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_tagCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<TagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory)));
					_tagCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _tagCollectionViaCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TagEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TagEntity))]
		public virtual EntityCollection<TagEntity> TagCollectionViaPreAssessmentCustomerCallQueueCallAttempt
		{
			get
			{
				if(_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt==null)
				{
					_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt = new EntityCollection<TagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory)));
					_tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _tagCollectionViaPreAssessmentCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TempCartEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TempCartEntity))]
		public virtual EntityCollection<TempCartEntity> TempCartCollectionViaPreQualificationResult
		{
			get
			{
				if(_tempCartCollectionViaPreQualificationResult==null)
				{
					_tempCartCollectionViaPreQualificationResult = new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory)));
					_tempCartCollectionViaPreQualificationResult.IsReadOnly=true;
				}
				return _tempCartCollectionViaPreQualificationResult;
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
							_account.UnsetRelatedEntity(this, "Calls");
						}
					}
					else
					{
						if(_account!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Calls");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CallQueueEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallQueueEntity CallQueue
		{
			get
			{
				return _callQueue;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCallQueue(value);
				}
				else
				{
					if(value==null)
					{
						if(_callQueue != null)
						{
							_callQueue.UnsetRelatedEntity(this, "Calls");
						}
					}
					else
					{
						if(_callQueue!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Calls");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CampaignEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CampaignEntity Campaign
		{
			get
			{
				return _campaign;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCampaign(value);
				}
				else
				{
					if(value==null)
					{
						if(_campaign != null)
						{
							_campaign.UnsetRelatedEntity(this, "Calls");
						}
					}
					else
					{
						if(_campaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Calls");
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
							_lookup__.UnsetRelatedEntity(this, "Calls__");
						}
					}
					else
					{
						if(_lookup__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Calls__");
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
							_lookup.UnsetRelatedEntity(this, "Calls");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Calls");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup_
		{
			get
			{
				return _lookup_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup_(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup_ != null)
						{
							_lookup_.UnsetRelatedEntity(this, "Calls_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Calls_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Calls");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Calls");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CallDetailsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallDetailsEntity CallDetails
		{
			get
			{
				return _callDetails;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCallDetails(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Calls");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_callDetails !=null);
						DesetupSyncCallDetails(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("CallDetails");
						}
					}
					else
					{
						if(_callDetails!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Calls");
							SetupSyncCallDetails(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.CallsEntity; }
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
