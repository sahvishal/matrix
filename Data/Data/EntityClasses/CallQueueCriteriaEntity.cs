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
	/// Entity class which represents the entity 'CallQueueCriteria'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CallQueueCriteriaEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomer;
		private EntityCollection<AccountEntity> _accountCollectionViaCallQueueCustomer;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaCallQueueCustomer;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCallQueueCustomer;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCallQueueCustomer;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCallQueueCustomer;
		private EntityCollection<EventsEntity> _eventsCollectionViaCallQueueCustomer;
		private EntityCollection<LanguageEntity> _languageCollectionViaCallQueueCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaCallQueueCustomer;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer_;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaCallQueueCustomer;
		private CallQueueEntity _callQueue;
		private CriteriaEntity _criteria;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CallQueue</summary>
			public static readonly string CallQueue = "CallQueue";
			/// <summary>Member name Criteria</summary>
			public static readonly string Criteria = "Criteria";
			/// <summary>Member name CallQueueCustomer</summary>
			public static readonly string CallQueueCustomer = "CallQueueCustomer";
			/// <summary>Member name AccountCollectionViaCallQueueCustomer</summary>
			public static readonly string AccountCollectionViaCallQueueCustomer = "AccountCollectionViaCallQueueCustomer";
			/// <summary>Member name ActivityTypeCollectionViaCallQueueCustomer</summary>
			public static readonly string ActivityTypeCollectionViaCallQueueCustomer = "ActivityTypeCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCollectionViaCallQueueCustomer = "CallQueueCollectionViaCallQueueCustomer";
			/// <summary>Member name CampaignCollectionViaCallQueueCustomer</summary>
			public static readonly string CampaignCollectionViaCallQueueCustomer = "CampaignCollectionViaCallQueueCustomer";
			/// <summary>Member name CustomerProfileCollectionViaCallQueueCustomer</summary>
			public static readonly string CustomerProfileCollectionViaCallQueueCustomer = "CustomerProfileCollectionViaCallQueueCustomer";
			/// <summary>Member name EventCustomersCollectionViaCallQueueCustomer</summary>
			public static readonly string EventCustomersCollectionViaCallQueueCustomer = "EventCustomersCollectionViaCallQueueCustomer";
			/// <summary>Member name EventsCollectionViaCallQueueCustomer</summary>
			public static readonly string EventsCollectionViaCallQueueCustomer = "EventsCollectionViaCallQueueCustomer";
			/// <summary>Member name LanguageCollectionViaCallQueueCustomer</summary>
			public static readonly string LanguageCollectionViaCallQueueCustomer = "LanguageCollectionViaCallQueueCustomer";
			/// <summary>Member name LookupCollectionViaCallQueueCustomer</summary>
			public static readonly string LookupCollectionViaCallQueueCustomer = "LookupCollectionViaCallQueueCustomer";
			/// <summary>Member name NotesDetailsCollectionViaCallQueueCustomer</summary>
			public static readonly string NotesDetailsCollectionViaCallQueueCustomer = "NotesDetailsCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer = "OrganizationRoleUserCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer__ = "OrganizationRoleUserCollectionViaCallQueueCustomer__";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer_ = "OrganizationRoleUserCollectionViaCallQueueCustomer_";
			/// <summary>Member name ProspectCustomerCollectionViaCallQueueCustomer</summary>
			public static readonly string ProspectCustomerCollectionViaCallQueueCustomer = "ProspectCustomerCollectionViaCallQueueCustomer";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CallQueueCriteriaEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CallQueueCriteriaEntity():base("CallQueueCriteriaEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CallQueueCriteriaEntity(IEntityFields2 fields):base("CallQueueCriteriaEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CallQueueCriteriaEntity</param>
		public CallQueueCriteriaEntity(IValidator validator):base("CallQueueCriteriaEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="callQueueCriteriaId">PK value for CallQueueCriteria which data should be fetched into this CallQueueCriteria object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallQueueCriteriaEntity(System.Int64 callQueueCriteriaId):base("CallQueueCriteriaEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CallQueueCriteriaId = callQueueCriteriaId;
		}

		/// <summary> CTor</summary>
		/// <param name="callQueueCriteriaId">PK value for CallQueueCriteria which data should be fetched into this CallQueueCriteria object</param>
		/// <param name="validator">The custom validator object for this CallQueueCriteriaEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallQueueCriteriaEntity(System.Int64 callQueueCriteriaId, IValidator validator):base("CallQueueCriteriaEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CallQueueCriteriaId = callQueueCriteriaId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CallQueueCriteriaEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomer", typeof(EntityCollection<CallQueueCustomerEntity>));
				_accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaCallQueueCustomer", typeof(EntityCollection<AccountEntity>));
				_activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCallQueueCustomer", typeof(EntityCollection<ActivityTypeEntity>));
				_callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueEntity>));
				_campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCallQueueCustomer", typeof(EntityCollection<CampaignEntity>));
				_customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCallQueueCustomer", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCallQueueCustomer", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCallQueueCustomer", typeof(EntityCollection<EventsEntity>));
				_languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCallQueueCustomer", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCallQueueCustomer", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCallQueueCustomer", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaCallQueueCustomer", typeof(EntityCollection<ProspectCustomerEntity>));
				_callQueue = (CallQueueEntity)info.GetValue("_callQueue", typeof(CallQueueEntity));
				if(_callQueue!=null)
				{
					_callQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_criteria = (CriteriaEntity)info.GetValue("_criteria", typeof(CriteriaEntity));
				if(_criteria!=null)
				{
					_criteria.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CallQueueCriteriaFieldIndex)fieldIndex)
			{
				case CallQueueCriteriaFieldIndex.CallQueueId:
					DesetupSyncCallQueue(true, false);
					break;
				case CallQueueCriteriaFieldIndex.CriteriaId:
					DesetupSyncCriteria(true, false);
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
				case "CallQueue":
					this.CallQueue = (CallQueueEntity)entity;
					break;
				case "Criteria":
					this.Criteria = (CriteriaEntity)entity;
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)entity);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.AccountCollectionViaCallQueueCustomer.Add((AccountEntity)entity);
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ActivityTypeCollectionViaCallQueueCustomer.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCollectionViaCallQueueCustomer.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CampaignCollectionViaCallQueueCustomer.Add((CampaignEntity)entity);
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CustomerProfileCollectionViaCallQueueCustomer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventCustomersCollectionViaCallQueueCustomer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "EventsCollectionViaCallQueueCustomer":
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventsCollectionViaCallQueueCustomer.Add((EventsEntity)entity);
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LanguageCollectionViaCallQueueCustomer.Add((LanguageEntity)entity);
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LookupCollectionViaCallQueueCustomer":
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LookupCollectionViaCallQueueCustomer.Add((LookupEntity)entity);
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.NotesDetailsCollectionViaCallQueueCustomer.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ProspectCustomerCollectionViaCallQueueCustomer.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = true;
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
			return CallQueueCriteriaEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CallQueue":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId);
					break;
				case "Criteria":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CriteriaEntityUsingCriteriaId);
					break;
				case "CallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId, "CallQueueCriteriaEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
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
				case "CallQueue":
					SetupSyncCallQueue(relatedEntity);
					break;
				case "Criteria":
					SetupSyncCriteria(relatedEntity);
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)relatedEntity);
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
				case "CallQueue":
					DesetupSyncCallQueue(false, true);
					break;
				case "Criteria":
					DesetupSyncCriteria(false, true);
					break;
				case "CallQueueCustomer":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomer, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_callQueue!=null)
			{
				toReturn.Add(_callQueue);
			}
			if(_criteria!=null)
			{
				toReturn.Add(_criteria);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CallQueueCustomer);

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
				info.AddValue("_callQueueCustomer", ((_callQueueCustomer!=null) && (_callQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCustomer:null);
				info.AddValue("_accountCollectionViaCallQueueCustomer", ((_accountCollectionViaCallQueueCustomer!=null) && (_accountCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaCallQueueCustomer:null);
				info.AddValue("_activityTypeCollectionViaCallQueueCustomer", ((_activityTypeCollectionViaCallQueueCustomer!=null) && (_activityTypeCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCollectionViaCallQueueCustomer", ((_callQueueCollectionViaCallQueueCustomer!=null) && (_callQueueCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaCallQueueCustomer:null);
				info.AddValue("_campaignCollectionViaCallQueueCustomer", ((_campaignCollectionViaCallQueueCustomer!=null) && (_campaignCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCallQueueCustomer:null);
				info.AddValue("_customerProfileCollectionViaCallQueueCustomer", ((_customerProfileCollectionViaCallQueueCustomer!=null) && (_customerProfileCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventCustomersCollectionViaCallQueueCustomer", ((_eventCustomersCollectionViaCallQueueCustomer!=null) && (_eventCustomersCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventsCollectionViaCallQueueCustomer", ((_eventsCollectionViaCallQueueCustomer!=null) && (_eventsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCallQueueCustomer:null);
				info.AddValue("_languageCollectionViaCallQueueCustomer", ((_languageCollectionViaCallQueueCustomer!=null) && (_languageCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCallQueueCustomer:null);
				info.AddValue("_lookupCollectionViaCallQueueCustomer", ((_lookupCollectionViaCallQueueCustomer!=null) && (_lookupCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCallQueueCustomer:null);
				info.AddValue("_notesDetailsCollectionViaCallQueueCustomer", ((_notesDetailsCollectionViaCallQueueCustomer!=null) && (_notesDetailsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer", ((_organizationRoleUserCollectionViaCallQueueCustomer!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer__", ((_organizationRoleUserCollectionViaCallQueueCustomer__!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer__:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer_", ((_organizationRoleUserCollectionViaCallQueueCustomer_!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer_:null);
				info.AddValue("_prospectCustomerCollectionViaCallQueueCustomer", ((_prospectCustomerCollectionViaCallQueueCustomer!=null) && (_prospectCustomerCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueue", (!this.MarkedForDeletion?_callQueue:null));
				info.AddValue("_criteria", (!this.MarkedForDeletion?_criteria:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CallQueueCriteriaFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CallQueueCriteriaFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CallQueueCriteriaRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId, "CallQueueCriteriaEntity__"));
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
		/// the related entity of type 'Criteria' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CriteriaFields.CriteriaId, null, ComparisonOperator.Equal, this.CriteriaId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CallQueueCriteriaEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callQueueCustomer);
			collectionsQueue.Enqueue(this._accountCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._campaignCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._languageCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer_);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaCallQueueCustomer);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callQueueCustomer != null)
			{
				return true;
			}
			if (this._accountCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._campaignCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._languageCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer_ != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaCallQueueCustomer != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CallQueue", _callQueue);
			toReturn.Add("Criteria", _criteria);
			toReturn.Add("CallQueueCustomer", _callQueueCustomer);
			toReturn.Add("AccountCollectionViaCallQueueCustomer", _accountCollectionViaCallQueueCustomer);
			toReturn.Add("ActivityTypeCollectionViaCallQueueCustomer", _activityTypeCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCollectionViaCallQueueCustomer", _callQueueCollectionViaCallQueueCustomer);
			toReturn.Add("CampaignCollectionViaCallQueueCustomer", _campaignCollectionViaCallQueueCustomer);
			toReturn.Add("CustomerProfileCollectionViaCallQueueCustomer", _customerProfileCollectionViaCallQueueCustomer);
			toReturn.Add("EventCustomersCollectionViaCallQueueCustomer", _eventCustomersCollectionViaCallQueueCustomer);
			toReturn.Add("EventsCollectionViaCallQueueCustomer", _eventsCollectionViaCallQueueCustomer);
			toReturn.Add("LanguageCollectionViaCallQueueCustomer", _languageCollectionViaCallQueueCustomer);
			toReturn.Add("LookupCollectionViaCallQueueCustomer", _lookupCollectionViaCallQueueCustomer);
			toReturn.Add("NotesDetailsCollectionViaCallQueueCustomer", _notesDetailsCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer", _organizationRoleUserCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer__", _organizationRoleUserCollectionViaCallQueueCustomer__);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer_", _organizationRoleUserCollectionViaCallQueueCustomer_);
			toReturn.Add("ProspectCustomerCollectionViaCallQueueCustomer", _prospectCustomerCollectionViaCallQueueCustomer);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callQueueCustomer!=null)
			{
				_callQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaCallQueueCustomer!=null)
			{
				_accountCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCallQueueCustomer!=null)
			{
				_activityTypeCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaCallQueueCustomer!=null)
			{
				_campaignCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCallQueueCustomer!=null)
			{
				_customerProfileCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCallQueueCustomer!=null)
			{
				_eventCustomersCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCallQueueCustomer!=null)
			{
				_eventsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCallQueueCustomer!=null)
			{
				_languageCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCallQueueCustomer!=null)
			{
				_lookupCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCallQueueCustomer!=null)
			{
				_notesDetailsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer__!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer_!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer_.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaCallQueueCustomer!=null)
			{
				_prospectCustomerCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueue!=null)
			{
				_callQueue.ActiveContext = base.ActiveContext;
			}
			if(_criteria!=null)
			{
				_criteria.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callQueueCustomer = null;
			_accountCollectionViaCallQueueCustomer = null;
			_activityTypeCollectionViaCallQueueCustomer = null;
			_callQueueCollectionViaCallQueueCustomer = null;
			_campaignCollectionViaCallQueueCustomer = null;
			_customerProfileCollectionViaCallQueueCustomer = null;
			_eventCustomersCollectionViaCallQueueCustomer = null;
			_eventsCollectionViaCallQueueCustomer = null;
			_languageCollectionViaCallQueueCustomer = null;
			_lookupCollectionViaCallQueueCustomer = null;
			_notesDetailsCollectionViaCallQueueCustomer = null;
			_organizationRoleUserCollectionViaCallQueueCustomer = null;
			_organizationRoleUserCollectionViaCallQueueCustomer__ = null;
			_organizationRoleUserCollectionViaCallQueueCustomer_ = null;
			_prospectCustomerCollectionViaCallQueueCustomer = null;
			_callQueue = null;
			_criteria = null;

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

			_fieldsCustomProperties.Add("CallQueueCriteriaId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallQueueId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CriteriaId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Zipcode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Radius", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Condition", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sequence", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallReason", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _callQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", CallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId, true, signalRelatedEntity, "CallQueueCriteria", resetFKFields, new int[] { (int)CallQueueCriteriaFieldIndex.CallQueueId } );		
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
				base.PerformSetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", CallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _criteria</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCriteria(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _criteria, new PropertyChangedEventHandler( OnCriteriaPropertyChanged ), "Criteria", CallQueueCriteriaEntity.Relations.CriteriaEntityUsingCriteriaId, true, signalRelatedEntity, "CallQueueCriteria", resetFKFields, new int[] { (int)CallQueueCriteriaFieldIndex.CriteriaId } );		
			_criteria = null;
		}

		/// <summary> setups the sync logic for member _criteria</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCriteria(IEntity2 relatedEntity)
		{
			if(_criteria!=relatedEntity)
			{
				DesetupSyncCriteria(true, true);
				_criteria = (CriteriaEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _criteria, new PropertyChangedEventHandler( OnCriteriaPropertyChanged ), "Criteria", CallQueueCriteriaEntity.Relations.CriteriaEntityUsingCriteriaId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCriteriaPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CallQueueCriteriaEntity</param>
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
		public  static CallQueueCriteriaRelations Relations
		{
			get	{ return new CallQueueCriteriaRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomer")[0], (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, null, null, "CallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaCallQueueCustomer"), null, "AccountCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCallQueueCustomer"), null, "ActivityTypeCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaCallQueueCustomer"), null, "CallQueueCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCallQueueCustomer"), null, "CampaignCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCallQueueCustomer"), null, "CustomerProfileCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCallQueueCustomer"), null, "EventCustomersCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCallQueueCustomer"), null, "EventsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCallQueueCustomer"), null, "LanguageCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCallQueueCustomer"), null, "LookupCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCallQueueCustomer"), null, "NotesDetailsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer__"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer_"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCriteriaEntity.Relations.CallQueueCustomerEntityUsingCallQueueCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaCallQueueCustomer"), null, "ProspectCustomerCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("CallQueue")[0], (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, null, null, "CallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Criteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCriteria
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CriteriaEntityFactory))),
					(IEntityRelation)GetRelationsForField("Criteria")[0], (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CriteriaEntity, 0, null, null, null, null, "Criteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CallQueueCriteriaEntity.CustomProperties;}
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
			get { return CallQueueCriteriaEntity.FieldsCustomProperties;}
		}

		/// <summary> The CallQueueCriteriaId property of the Entity CallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCriteria"."CallQueueCriteriaId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CallQueueCriteriaId
		{
			get { return (System.Int64)GetValue((int)CallQueueCriteriaFieldIndex.CallQueueCriteriaId, true); }
			set	{ SetValue((int)CallQueueCriteriaFieldIndex.CallQueueCriteriaId, value); }
		}

		/// <summary> The CallQueueId property of the Entity CallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCriteria"."CallQueueId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CallQueueId
		{
			get { return (System.Int64)GetValue((int)CallQueueCriteriaFieldIndex.CallQueueId, true); }
			set	{ SetValue((int)CallQueueCriteriaFieldIndex.CallQueueId, value); }
		}

		/// <summary> The CriteriaId property of the Entity CallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCriteria"."CriteriaId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CriteriaId
		{
			get { return (System.Int64)GetValue((int)CallQueueCriteriaFieldIndex.CriteriaId, true); }
			set	{ SetValue((int)CallQueueCriteriaFieldIndex.CriteriaId, value); }
		}

		/// <summary> The Zipcode property of the Entity CallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCriteria"."Zipcode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Zipcode
		{
			get { return (System.String)GetValue((int)CallQueueCriteriaFieldIndex.Zipcode, true); }
			set	{ SetValue((int)CallQueueCriteriaFieldIndex.Zipcode, value); }
		}

		/// <summary> The Radius property of the Entity CallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCriteria"."Radius"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Radius
		{
			get { return (System.Int32)GetValue((int)CallQueueCriteriaFieldIndex.Radius, true); }
			set	{ SetValue((int)CallQueueCriteriaFieldIndex.Radius, value); }
		}

		/// <summary> The Condition property of the Entity CallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCriteria"."Condition"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Condition
		{
			get { return (System.Boolean)GetValue((int)CallQueueCriteriaFieldIndex.Condition, true); }
			set	{ SetValue((int)CallQueueCriteriaFieldIndex.Condition, value); }
		}

		/// <summary> The IsActive property of the Entity CallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCriteria"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CallQueueCriteriaFieldIndex.IsActive, true); }
			set	{ SetValue((int)CallQueueCriteriaFieldIndex.IsActive, value); }
		}

		/// <summary> The Sequence property of the Entity CallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCriteria"."Sequence"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Sequence
		{
			get { return (System.Int32)GetValue((int)CallQueueCriteriaFieldIndex.Sequence, true); }
			set	{ SetValue((int)CallQueueCriteriaFieldIndex.Sequence, value); }
		}

		/// <summary> The CallReason property of the Entity CallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCriteria"."CallReason"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CallReason
		{
			get { return (System.String)GetValue((int)CallQueueCriteriaFieldIndex.CallReason, true); }
			set	{ SetValue((int)CallQueueCriteriaFieldIndex.CallReason, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomer
		{
			get
			{
				if(_callQueueCustomer==null)
				{
					_callQueueCustomer = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomer.SetContainingEntityInfo(this, "CallQueueCriteria");
				}
				return _callQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaCallQueueCustomer
		{
			get
			{
				if(_accountCollectionViaCallQueueCustomer==null)
				{
					_accountCollectionViaCallQueueCustomer = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _accountCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActivityTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActivityTypeEntity))]
		public virtual EntityCollection<ActivityTypeEntity> ActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				if(_activityTypeCollectionViaCallQueueCustomer==null)
				{
					_activityTypeCollectionViaCallQueueCustomer = new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory)));
					_activityTypeCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _activityTypeCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				if(_callQueueCollectionViaCallQueueCustomer==null)
				{
					_callQueueCollectionViaCallQueueCustomer = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _callQueueCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaCallQueueCustomer
		{
			get
			{
				if(_campaignCollectionViaCallQueueCustomer==null)
				{
					_campaignCollectionViaCallQueueCustomer = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _campaignCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				if(_customerProfileCollectionViaCallQueueCustomer==null)
				{
					_customerProfileCollectionViaCallQueueCustomer = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				if(_eventCustomersCollectionViaCallQueueCustomer==null)
				{
					_eventCustomersCollectionViaCallQueueCustomer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCallQueueCustomer
		{
			get
			{
				if(_eventsCollectionViaCallQueueCustomer==null)
				{
					_eventsCollectionViaCallQueueCustomer = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _eventsCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LanguageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LanguageEntity))]
		public virtual EntityCollection<LanguageEntity> LanguageCollectionViaCallQueueCustomer
		{
			get
			{
				if(_languageCollectionViaCallQueueCustomer==null)
				{
					_languageCollectionViaCallQueueCustomer = new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory)));
					_languageCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _languageCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCallQueueCustomer
		{
			get
			{
				if(_lookupCollectionViaCallQueueCustomer==null)
				{
					_lookupCollectionViaCallQueueCustomer = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _lookupCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotesDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotesDetailsEntity))]
		public virtual EntityCollection<NotesDetailsEntity> NotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				if(_notesDetailsCollectionViaCallQueueCustomer==null)
				{
					_notesDetailsCollectionViaCallQueueCustomer = new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory)));
					_notesDetailsCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _notesDetailsCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer__==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer_==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerEntity))]
		public virtual EntityCollection<ProspectCustomerEntity> ProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				if(_prospectCustomerCollectionViaCallQueueCustomer==null)
				{
					_prospectCustomerCollectionViaCallQueueCustomer = new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory)));
					_prospectCustomerCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _prospectCustomerCollectionViaCallQueueCustomer;
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
							_callQueue.UnsetRelatedEntity(this, "CallQueueCriteria");
						}
					}
					else
					{
						if(_callQueue!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCriteria");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CriteriaEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CriteriaEntity Criteria
		{
			get
			{
				return _criteria;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCriteria(value);
				}
				else
				{
					if(value==null)
					{
						if(_criteria != null)
						{
							_criteria.UnsetRelatedEntity(this, "CallQueueCriteria");
						}
					}
					else
					{
						if(_criteria!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCriteria");
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
			get { return (int)Falcon.Data.EntityType.CallQueueCriteriaEntity; }
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
