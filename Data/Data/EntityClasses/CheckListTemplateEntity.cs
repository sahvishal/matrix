///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:50
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
	/// Entity class which represents the entity 'CheckListTemplate'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CheckListTemplateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountEntity> _account_;
		private EntityCollection<AccountEntity> _account;
		private EntityCollection<CheckListTemplateQuestionEntity> _checkListTemplateQuestion;
		private EntityCollection<EventChecklistTemplateEntity> _eventChecklistTemplate;
		private EntityCollection<ChecklistGroupQuestionEntity> _checklistGroupQuestionCollectionViaCheckListTemplateQuestion;
		private EntityCollection<CheckListQuestionEntity> _checkListQuestionCollectionViaCheckListTemplateQuestion;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount___;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount_______;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount_;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount__;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount____;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount______;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount_____;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventChecklistTemplate;
		private EntityCollection<FileEntity> _fileCollectionViaAccount________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_____________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount______________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_______________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_______;
		private EntityCollection<FileEntity> _fileCollectionViaAccount________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount____________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_;
		private EntityCollection<FileEntity> _fileCollectionViaAccount______;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__;
		private EntityCollection<FluConsentTemplateEntity> _fluConsentTemplateCollectionViaAccount_;
		private EntityCollection<FluConsentTemplateEntity> _fluConsentTemplateCollectionViaAccount;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaAccount_;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaAccount;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccount;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccount_;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaAccount;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaAccount_;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaAccount_;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaAccount;
		private LookupEntity _lookup;
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
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Account_</summary>
			public static readonly string Account_ = "Account_";
			/// <summary>Member name Account</summary>
			public static readonly string Account = "Account";
			/// <summary>Member name CheckListTemplateQuestion</summary>
			public static readonly string CheckListTemplateQuestion = "CheckListTemplateQuestion";
			/// <summary>Member name EventChecklistTemplate</summary>
			public static readonly string EventChecklistTemplate = "EventChecklistTemplate";
			/// <summary>Member name ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion</summary>
			public static readonly string ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion = "ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion";
			/// <summary>Member name CheckListQuestionCollectionViaCheckListTemplateQuestion</summary>
			public static readonly string CheckListQuestionCollectionViaCheckListTemplateQuestion = "CheckListQuestionCollectionViaCheckListTemplateQuestion";
			/// <summary>Member name EmailTemplateCollectionViaAccount___</summary>
			public static readonly string EmailTemplateCollectionViaAccount___ = "EmailTemplateCollectionViaAccount___";
			/// <summary>Member name EmailTemplateCollectionViaAccount_______</summary>
			public static readonly string EmailTemplateCollectionViaAccount_______ = "EmailTemplateCollectionViaAccount_______";
			/// <summary>Member name EmailTemplateCollectionViaAccount_</summary>
			public static readonly string EmailTemplateCollectionViaAccount_ = "EmailTemplateCollectionViaAccount_";
			/// <summary>Member name EmailTemplateCollectionViaAccount__</summary>
			public static readonly string EmailTemplateCollectionViaAccount__ = "EmailTemplateCollectionViaAccount__";
			/// <summary>Member name EmailTemplateCollectionViaAccount____</summary>
			public static readonly string EmailTemplateCollectionViaAccount____ = "EmailTemplateCollectionViaAccount____";
			/// <summary>Member name EmailTemplateCollectionViaAccount</summary>
			public static readonly string EmailTemplateCollectionViaAccount = "EmailTemplateCollectionViaAccount";
			/// <summary>Member name EmailTemplateCollectionViaAccount______</summary>
			public static readonly string EmailTemplateCollectionViaAccount______ = "EmailTemplateCollectionViaAccount______";
			/// <summary>Member name EmailTemplateCollectionViaAccount_____</summary>
			public static readonly string EmailTemplateCollectionViaAccount_____ = "EmailTemplateCollectionViaAccount_____";
			/// <summary>Member name EventsCollectionViaEventChecklistTemplate</summary>
			public static readonly string EventsCollectionViaEventChecklistTemplate = "EventsCollectionViaEventChecklistTemplate";
			/// <summary>Member name FileCollectionViaAccount________________</summary>
			public static readonly string FileCollectionViaAccount________________ = "FileCollectionViaAccount________________";
			/// <summary>Member name FileCollectionViaAccount_________________</summary>
			public static readonly string FileCollectionViaAccount_________________ = "FileCollectionViaAccount_________________";
			/// <summary>Member name FileCollectionViaAccount</summary>
			public static readonly string FileCollectionViaAccount = "FileCollectionViaAccount";
			/// <summary>Member name FileCollectionViaAccount_____________</summary>
			public static readonly string FileCollectionViaAccount_____________ = "FileCollectionViaAccount_____________";
			/// <summary>Member name FileCollectionViaAccount______________</summary>
			public static readonly string FileCollectionViaAccount______________ = "FileCollectionViaAccount______________";
			/// <summary>Member name FileCollectionViaAccount_______________</summary>
			public static readonly string FileCollectionViaAccount_______________ = "FileCollectionViaAccount_______________";
			/// <summary>Member name FileCollectionViaAccount_______</summary>
			public static readonly string FileCollectionViaAccount_______ = "FileCollectionViaAccount_______";
			/// <summary>Member name FileCollectionViaAccount________</summary>
			public static readonly string FileCollectionViaAccount________ = "FileCollectionViaAccount________";
			/// <summary>Member name FileCollectionViaAccount_________</summary>
			public static readonly string FileCollectionViaAccount_________ = "FileCollectionViaAccount_________";
			/// <summary>Member name FileCollectionViaAccount____</summary>
			public static readonly string FileCollectionViaAccount____ = "FileCollectionViaAccount____";
			/// <summary>Member name FileCollectionViaAccount_____</summary>
			public static readonly string FileCollectionViaAccount_____ = "FileCollectionViaAccount_____";
			/// <summary>Member name FileCollectionViaAccount___</summary>
			public static readonly string FileCollectionViaAccount___ = "FileCollectionViaAccount___";
			/// <summary>Member name FileCollectionViaAccount__________</summary>
			public static readonly string FileCollectionViaAccount__________ = "FileCollectionViaAccount__________";
			/// <summary>Member name FileCollectionViaAccount____________</summary>
			public static readonly string FileCollectionViaAccount____________ = "FileCollectionViaAccount____________";
			/// <summary>Member name FileCollectionViaAccount_</summary>
			public static readonly string FileCollectionViaAccount_ = "FileCollectionViaAccount_";
			/// <summary>Member name FileCollectionViaAccount______</summary>
			public static readonly string FileCollectionViaAccount______ = "FileCollectionViaAccount______";
			/// <summary>Member name FileCollectionViaAccount___________</summary>
			public static readonly string FileCollectionViaAccount___________ = "FileCollectionViaAccount___________";
			/// <summary>Member name FileCollectionViaAccount__</summary>
			public static readonly string FileCollectionViaAccount__ = "FileCollectionViaAccount__";
			/// <summary>Member name FluConsentTemplateCollectionViaAccount_</summary>
			public static readonly string FluConsentTemplateCollectionViaAccount_ = "FluConsentTemplateCollectionViaAccount_";
			/// <summary>Member name FluConsentTemplateCollectionViaAccount</summary>
			public static readonly string FluConsentTemplateCollectionViaAccount = "FluConsentTemplateCollectionViaAccount";
			/// <summary>Member name HafTemplateCollectionViaAccount_</summary>
			public static readonly string HafTemplateCollectionViaAccount_ = "HafTemplateCollectionViaAccount_";
			/// <summary>Member name HafTemplateCollectionViaAccount</summary>
			public static readonly string HafTemplateCollectionViaAccount = "HafTemplateCollectionViaAccount";
			/// <summary>Member name LookupCollectionViaAccount</summary>
			public static readonly string LookupCollectionViaAccount = "LookupCollectionViaAccount";
			/// <summary>Member name LookupCollectionViaAccount_</summary>
			public static readonly string LookupCollectionViaAccount_ = "LookupCollectionViaAccount_";
			/// <summary>Member name ProspectsCollectionViaAccount</summary>
			public static readonly string ProspectsCollectionViaAccount = "ProspectsCollectionViaAccount";
			/// <summary>Member name ProspectsCollectionViaAccount_</summary>
			public static readonly string ProspectsCollectionViaAccount_ = "ProspectsCollectionViaAccount_";
			/// <summary>Member name SurveyTemplateCollectionViaAccount_</summary>
			public static readonly string SurveyTemplateCollectionViaAccount_ = "SurveyTemplateCollectionViaAccount_";
			/// <summary>Member name SurveyTemplateCollectionViaAccount</summary>
			public static readonly string SurveyTemplateCollectionViaAccount = "SurveyTemplateCollectionViaAccount";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CheckListTemplateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CheckListTemplateEntity():base("CheckListTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CheckListTemplateEntity(IEntityFields2 fields):base("CheckListTemplateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CheckListTemplateEntity</param>
		public CheckListTemplateEntity(IValidator validator):base("CheckListTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CheckListTemplate which data should be fetched into this CheckListTemplate object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckListTemplateEntity(System.Int64 id):base("CheckListTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CheckListTemplate which data should be fetched into this CheckListTemplate object</param>
		/// <param name="validator">The custom validator object for this CheckListTemplateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckListTemplateEntity(System.Int64 id, IValidator validator):base("CheckListTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CheckListTemplateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_account_ = (EntityCollection<AccountEntity>)info.GetValue("_account_", typeof(EntityCollection<AccountEntity>));
				_account = (EntityCollection<AccountEntity>)info.GetValue("_account", typeof(EntityCollection<AccountEntity>));
				_checkListTemplateQuestion = (EntityCollection<CheckListTemplateQuestionEntity>)info.GetValue("_checkListTemplateQuestion", typeof(EntityCollection<CheckListTemplateQuestionEntity>));
				_eventChecklistTemplate = (EntityCollection<EventChecklistTemplateEntity>)info.GetValue("_eventChecklistTemplate", typeof(EntityCollection<EventChecklistTemplateEntity>));
				_checklistGroupQuestionCollectionViaCheckListTemplateQuestion = (EntityCollection<ChecklistGroupQuestionEntity>)info.GetValue("_checklistGroupQuestionCollectionViaCheckListTemplateQuestion", typeof(EntityCollection<ChecklistGroupQuestionEntity>));
				_checkListQuestionCollectionViaCheckListTemplateQuestion = (EntityCollection<CheckListQuestionEntity>)info.GetValue("_checkListQuestionCollectionViaCheckListTemplateQuestion", typeof(EntityCollection<CheckListQuestionEntity>));
				_emailTemplateCollectionViaAccount___ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount___", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount_______ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount_______", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount_ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount_", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount__ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount__", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount____ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount____", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount______ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount______", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount_____ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount_____", typeof(EntityCollection<EmailTemplateEntity>));
				_eventsCollectionViaEventChecklistTemplate = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventChecklistTemplate", typeof(EntityCollection<EventsEntity>));
				_fileCollectionViaAccount________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_____________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_____________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount______________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount______________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_______________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_______________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_______", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount___ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount__________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount____________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount____________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount______", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount___________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount__ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__", typeof(EntityCollection<FileEntity>));
				_fluConsentTemplateCollectionViaAccount_ = (EntityCollection<FluConsentTemplateEntity>)info.GetValue("_fluConsentTemplateCollectionViaAccount_", typeof(EntityCollection<FluConsentTemplateEntity>));
				_fluConsentTemplateCollectionViaAccount = (EntityCollection<FluConsentTemplateEntity>)info.GetValue("_fluConsentTemplateCollectionViaAccount", typeof(EntityCollection<FluConsentTemplateEntity>));
				_hafTemplateCollectionViaAccount_ = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaAccount_", typeof(EntityCollection<HafTemplateEntity>));
				_hafTemplateCollectionViaAccount = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaAccount", typeof(EntityCollection<HafTemplateEntity>));
				_lookupCollectionViaAccount = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccount", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaAccount_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccount_", typeof(EntityCollection<LookupEntity>));
				_prospectsCollectionViaAccount = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaAccount", typeof(EntityCollection<ProspectsEntity>));
				_prospectsCollectionViaAccount_ = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaAccount_", typeof(EntityCollection<ProspectsEntity>));
				_surveyTemplateCollectionViaAccount_ = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaAccount_", typeof(EntityCollection<SurveyTemplateEntity>));
				_surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaAccount", typeof(EntityCollection<SurveyTemplateEntity>));
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
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
			switch((CheckListTemplateFieldIndex)fieldIndex)
			{
				case CheckListTemplateFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CheckListTemplateFieldIndex.ModifiedBy:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case CheckListTemplateFieldIndex.Type:
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
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Account_":
					this.Account_.Add((AccountEntity)entity);
					break;
				case "Account":
					this.Account.Add((AccountEntity)entity);
					break;
				case "CheckListTemplateQuestion":
					this.CheckListTemplateQuestion.Add((CheckListTemplateQuestionEntity)entity);
					break;
				case "EventChecklistTemplate":
					this.EventChecklistTemplate.Add((EventChecklistTemplateEntity)entity);
					break;
				case "ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion":
					this.ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly = false;
					this.ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion.Add((ChecklistGroupQuestionEntity)entity);
					this.ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly = true;
					break;
				case "CheckListQuestionCollectionViaCheckListTemplateQuestion":
					this.CheckListQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly = false;
					this.CheckListQuestionCollectionViaCheckListTemplateQuestion.Add((CheckListQuestionEntity)entity);
					this.CheckListQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount___":
					this.EmailTemplateCollectionViaAccount___.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount___.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount___.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount_______":
					this.EmailTemplateCollectionViaAccount_______.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount_______.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount_______.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount_":
					this.EmailTemplateCollectionViaAccount_.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount_.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount__":
					this.EmailTemplateCollectionViaAccount__.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount__.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount__.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount____":
					this.EmailTemplateCollectionViaAccount____.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount____.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount____.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount":
					this.EmailTemplateCollectionViaAccount.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount______":
					this.EmailTemplateCollectionViaAccount______.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount______.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount______.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount_____":
					this.EmailTemplateCollectionViaAccount_____.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount_____.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount_____.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventChecklistTemplate":
					this.EventsCollectionViaEventChecklistTemplate.IsReadOnly = false;
					this.EventsCollectionViaEventChecklistTemplate.Add((EventsEntity)entity);
					this.EventsCollectionViaEventChecklistTemplate.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount________________":
					this.FileCollectionViaAccount________________.IsReadOnly = false;
					this.FileCollectionViaAccount________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_________________":
					this.FileCollectionViaAccount_________________.IsReadOnly = false;
					this.FileCollectionViaAccount_________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount":
					this.FileCollectionViaAccount.IsReadOnly = false;
					this.FileCollectionViaAccount.Add((FileEntity)entity);
					this.FileCollectionViaAccount.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_____________":
					this.FileCollectionViaAccount_____________.IsReadOnly = false;
					this.FileCollectionViaAccount_____________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_____________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount______________":
					this.FileCollectionViaAccount______________.IsReadOnly = false;
					this.FileCollectionViaAccount______________.Add((FileEntity)entity);
					this.FileCollectionViaAccount______________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_______________":
					this.FileCollectionViaAccount_______________.IsReadOnly = false;
					this.FileCollectionViaAccount_______________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_______________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_______":
					this.FileCollectionViaAccount_______.IsReadOnly = false;
					this.FileCollectionViaAccount_______.Add((FileEntity)entity);
					this.FileCollectionViaAccount_______.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount________":
					this.FileCollectionViaAccount________.IsReadOnly = false;
					this.FileCollectionViaAccount________.Add((FileEntity)entity);
					this.FileCollectionViaAccount________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_________":
					this.FileCollectionViaAccount_________.IsReadOnly = false;
					this.FileCollectionViaAccount_________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount____":
					this.FileCollectionViaAccount____.IsReadOnly = false;
					this.FileCollectionViaAccount____.Add((FileEntity)entity);
					this.FileCollectionViaAccount____.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_____":
					this.FileCollectionViaAccount_____.IsReadOnly = false;
					this.FileCollectionViaAccount_____.Add((FileEntity)entity);
					this.FileCollectionViaAccount_____.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount___":
					this.FileCollectionViaAccount___.IsReadOnly = false;
					this.FileCollectionViaAccount___.Add((FileEntity)entity);
					this.FileCollectionViaAccount___.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount__________":
					this.FileCollectionViaAccount__________.IsReadOnly = false;
					this.FileCollectionViaAccount__________.Add((FileEntity)entity);
					this.FileCollectionViaAccount__________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount____________":
					this.FileCollectionViaAccount____________.IsReadOnly = false;
					this.FileCollectionViaAccount____________.Add((FileEntity)entity);
					this.FileCollectionViaAccount____________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_":
					this.FileCollectionViaAccount_.IsReadOnly = false;
					this.FileCollectionViaAccount_.Add((FileEntity)entity);
					this.FileCollectionViaAccount_.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount______":
					this.FileCollectionViaAccount______.IsReadOnly = false;
					this.FileCollectionViaAccount______.Add((FileEntity)entity);
					this.FileCollectionViaAccount______.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount___________":
					this.FileCollectionViaAccount___________.IsReadOnly = false;
					this.FileCollectionViaAccount___________.Add((FileEntity)entity);
					this.FileCollectionViaAccount___________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount__":
					this.FileCollectionViaAccount__.IsReadOnly = false;
					this.FileCollectionViaAccount__.Add((FileEntity)entity);
					this.FileCollectionViaAccount__.IsReadOnly = true;
					break;
				case "FluConsentTemplateCollectionViaAccount_":
					this.FluConsentTemplateCollectionViaAccount_.IsReadOnly = false;
					this.FluConsentTemplateCollectionViaAccount_.Add((FluConsentTemplateEntity)entity);
					this.FluConsentTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "FluConsentTemplateCollectionViaAccount":
					this.FluConsentTemplateCollectionViaAccount.IsReadOnly = false;
					this.FluConsentTemplateCollectionViaAccount.Add((FluConsentTemplateEntity)entity);
					this.FluConsentTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaAccount_":
					this.HafTemplateCollectionViaAccount_.IsReadOnly = false;
					this.HafTemplateCollectionViaAccount_.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaAccount":
					this.HafTemplateCollectionViaAccount.IsReadOnly = false;
					this.HafTemplateCollectionViaAccount.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccount":
					this.LookupCollectionViaAccount.IsReadOnly = false;
					this.LookupCollectionViaAccount.Add((LookupEntity)entity);
					this.LookupCollectionViaAccount.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccount_":
					this.LookupCollectionViaAccount_.IsReadOnly = false;
					this.LookupCollectionViaAccount_.Add((LookupEntity)entity);
					this.LookupCollectionViaAccount_.IsReadOnly = true;
					break;
				case "ProspectsCollectionViaAccount":
					this.ProspectsCollectionViaAccount.IsReadOnly = false;
					this.ProspectsCollectionViaAccount.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaAccount.IsReadOnly = true;
					break;
				case "ProspectsCollectionViaAccount_":
					this.ProspectsCollectionViaAccount_.IsReadOnly = false;
					this.ProspectsCollectionViaAccount_.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaAccount_.IsReadOnly = true;
					break;
				case "SurveyTemplateCollectionViaAccount_":
					this.SurveyTemplateCollectionViaAccount_.IsReadOnly = false;
					this.SurveyTemplateCollectionViaAccount_.Add((SurveyTemplateEntity)entity);
					this.SurveyTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "SurveyTemplateCollectionViaAccount":
					this.SurveyTemplateCollectionViaAccount.IsReadOnly = false;
					this.SurveyTemplateCollectionViaAccount.Add((SurveyTemplateEntity)entity);
					this.SurveyTemplateCollectionViaAccount.IsReadOnly = true;
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
			return CheckListTemplateEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Lookup":
					toReturn.Add(CheckListTemplateEntity.Relations.LookupEntityUsingType);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(CheckListTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CheckListTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "Account_":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId);
					break;
				case "Account":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId);
					break;
				case "CheckListTemplateQuestion":
					toReturn.Add(CheckListTemplateEntity.Relations.CheckListTemplateQuestionEntityUsingTemplateId);
					break;
				case "EventChecklistTemplate":
					toReturn.Add(CheckListTemplateEntity.Relations.EventChecklistTemplateEntityUsingChecklistTemplateId);
					break;
				case "ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion":
					toReturn.Add(CheckListTemplateEntity.Relations.CheckListTemplateQuestionEntityUsingTemplateId, "CheckListTemplateEntity__", "CheckListTemplateQuestion_", JoinHint.None);
					toReturn.Add(CheckListTemplateQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingGroupQuestionId, "CheckListTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "CheckListQuestionCollectionViaCheckListTemplateQuestion":
					toReturn.Add(CheckListTemplateEntity.Relations.CheckListTemplateQuestionEntityUsingTemplateId, "CheckListTemplateEntity__", "CheckListTemplateQuestion_", JoinHint.None);
					toReturn.Add(CheckListTemplateQuestionEntity.Relations.CheckListQuestionEntityUsingQuestionId, "CheckListTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount___":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingReminderSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount_______":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingReminderSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount_":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingMemberCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount__":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingPcpCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount____":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingConfirmationSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingConfirmationSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount______":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingPcpCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount_____":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingMemberCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventChecklistTemplate":
					toReturn.Add(CheckListTemplateEntity.Relations.EventChecklistTemplateEntityUsingChecklistTemplateId, "CheckListTemplateEntity__", "EventChecklistTemplate_", JoinHint.None);
					toReturn.Add(EventChecklistTemplateEntity.Relations.EventsEntityUsingEventId, "EventChecklistTemplate_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount________________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_________________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_____________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount______________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_______________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_______":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount____":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_____":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount____________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount______":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___________":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FluConsentTemplateCollectionViaAccount_":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FluConsentTemplateCollectionViaAccount":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaAccount_":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaAccount":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccount":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccount_":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, "Account_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaAccount":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, "Account_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaAccount_":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, "Account_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaAccount_":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaAccount":
					toReturn.Add(CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId, "CheckListTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, "Account_", string.Empty, JoinHint.None);
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
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Account_":
					this.Account_.Add((AccountEntity)relatedEntity);
					break;
				case "Account":
					this.Account.Add((AccountEntity)relatedEntity);
					break;
				case "CheckListTemplateQuestion":
					this.CheckListTemplateQuestion.Add((CheckListTemplateQuestionEntity)relatedEntity);
					break;
				case "EventChecklistTemplate":
					this.EventChecklistTemplate.Add((EventChecklistTemplateEntity)relatedEntity);
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
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Account_":
					base.PerformRelatedEntityRemoval(this.Account_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Account":
					base.PerformRelatedEntityRemoval(this.Account, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CheckListTemplateQuestion":
					base.PerformRelatedEntityRemoval(this.CheckListTemplateQuestion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventChecklistTemplate":
					base.PerformRelatedEntityRemoval(this.EventChecklistTemplate, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
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
			toReturn.Add(this.Account_);
			toReturn.Add(this.Account);
			toReturn.Add(this.CheckListTemplateQuestion);
			toReturn.Add(this.EventChecklistTemplate);

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
				info.AddValue("_account_", ((_account_!=null) && (_account_.Count>0) && !this.MarkedForDeletion)?_account_:null);
				info.AddValue("_account", ((_account!=null) && (_account.Count>0) && !this.MarkedForDeletion)?_account:null);
				info.AddValue("_checkListTemplateQuestion", ((_checkListTemplateQuestion!=null) && (_checkListTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_checkListTemplateQuestion:null);
				info.AddValue("_eventChecklistTemplate", ((_eventChecklistTemplate!=null) && (_eventChecklistTemplate.Count>0) && !this.MarkedForDeletion)?_eventChecklistTemplate:null);
				info.AddValue("_checklistGroupQuestionCollectionViaCheckListTemplateQuestion", ((_checklistGroupQuestionCollectionViaCheckListTemplateQuestion!=null) && (_checklistGroupQuestionCollectionViaCheckListTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_checklistGroupQuestionCollectionViaCheckListTemplateQuestion:null);
				info.AddValue("_checkListQuestionCollectionViaCheckListTemplateQuestion", ((_checkListQuestionCollectionViaCheckListTemplateQuestion!=null) && (_checkListQuestionCollectionViaCheckListTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_checkListQuestionCollectionViaCheckListTemplateQuestion:null);
				info.AddValue("_emailTemplateCollectionViaAccount___", ((_emailTemplateCollectionViaAccount___!=null) && (_emailTemplateCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount___:null);
				info.AddValue("_emailTemplateCollectionViaAccount_______", ((_emailTemplateCollectionViaAccount_______!=null) && (_emailTemplateCollectionViaAccount_______.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount_______:null);
				info.AddValue("_emailTemplateCollectionViaAccount_", ((_emailTemplateCollectionViaAccount_!=null) && (_emailTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount_:null);
				info.AddValue("_emailTemplateCollectionViaAccount__", ((_emailTemplateCollectionViaAccount__!=null) && (_emailTemplateCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount__:null);
				info.AddValue("_emailTemplateCollectionViaAccount____", ((_emailTemplateCollectionViaAccount____!=null) && (_emailTemplateCollectionViaAccount____.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount____:null);
				info.AddValue("_emailTemplateCollectionViaAccount", ((_emailTemplateCollectionViaAccount!=null) && (_emailTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount:null);
				info.AddValue("_emailTemplateCollectionViaAccount______", ((_emailTemplateCollectionViaAccount______!=null) && (_emailTemplateCollectionViaAccount______.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount______:null);
				info.AddValue("_emailTemplateCollectionViaAccount_____", ((_emailTemplateCollectionViaAccount_____!=null) && (_emailTemplateCollectionViaAccount_____.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount_____:null);
				info.AddValue("_eventsCollectionViaEventChecklistTemplate", ((_eventsCollectionViaEventChecklistTemplate!=null) && (_eventsCollectionViaEventChecklistTemplate.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventChecklistTemplate:null);
				info.AddValue("_fileCollectionViaAccount________________", ((_fileCollectionViaAccount________________!=null) && (_fileCollectionViaAccount________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount________________:null);
				info.AddValue("_fileCollectionViaAccount_________________", ((_fileCollectionViaAccount_________________!=null) && (_fileCollectionViaAccount_________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_________________:null);
				info.AddValue("_fileCollectionViaAccount", ((_fileCollectionViaAccount!=null) && (_fileCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount:null);
				info.AddValue("_fileCollectionViaAccount_____________", ((_fileCollectionViaAccount_____________!=null) && (_fileCollectionViaAccount_____________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_____________:null);
				info.AddValue("_fileCollectionViaAccount______________", ((_fileCollectionViaAccount______________!=null) && (_fileCollectionViaAccount______________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount______________:null);
				info.AddValue("_fileCollectionViaAccount_______________", ((_fileCollectionViaAccount_______________!=null) && (_fileCollectionViaAccount_______________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_______________:null);
				info.AddValue("_fileCollectionViaAccount_______", ((_fileCollectionViaAccount_______!=null) && (_fileCollectionViaAccount_______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_______:null);
				info.AddValue("_fileCollectionViaAccount________", ((_fileCollectionViaAccount________!=null) && (_fileCollectionViaAccount________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount________:null);
				info.AddValue("_fileCollectionViaAccount_________", ((_fileCollectionViaAccount_________!=null) && (_fileCollectionViaAccount_________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_________:null);
				info.AddValue("_fileCollectionViaAccount____", ((_fileCollectionViaAccount____!=null) && (_fileCollectionViaAccount____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount____:null);
				info.AddValue("_fileCollectionViaAccount_____", ((_fileCollectionViaAccount_____!=null) && (_fileCollectionViaAccount_____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_____:null);
				info.AddValue("_fileCollectionViaAccount___", ((_fileCollectionViaAccount___!=null) && (_fileCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___:null);
				info.AddValue("_fileCollectionViaAccount__________", ((_fileCollectionViaAccount__________!=null) && (_fileCollectionViaAccount__________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__________:null);
				info.AddValue("_fileCollectionViaAccount____________", ((_fileCollectionViaAccount____________!=null) && (_fileCollectionViaAccount____________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount____________:null);
				info.AddValue("_fileCollectionViaAccount_", ((_fileCollectionViaAccount_!=null) && (_fileCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_:null);
				info.AddValue("_fileCollectionViaAccount______", ((_fileCollectionViaAccount______!=null) && (_fileCollectionViaAccount______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount______:null);
				info.AddValue("_fileCollectionViaAccount___________", ((_fileCollectionViaAccount___________!=null) && (_fileCollectionViaAccount___________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___________:null);
				info.AddValue("_fileCollectionViaAccount__", ((_fileCollectionViaAccount__!=null) && (_fileCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__:null);
				info.AddValue("_fluConsentTemplateCollectionViaAccount_", ((_fluConsentTemplateCollectionViaAccount_!=null) && (_fluConsentTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateCollectionViaAccount_:null);
				info.AddValue("_fluConsentTemplateCollectionViaAccount", ((_fluConsentTemplateCollectionViaAccount!=null) && (_fluConsentTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateCollectionViaAccount:null);
				info.AddValue("_hafTemplateCollectionViaAccount_", ((_hafTemplateCollectionViaAccount_!=null) && (_hafTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaAccount_:null);
				info.AddValue("_hafTemplateCollectionViaAccount", ((_hafTemplateCollectionViaAccount!=null) && (_hafTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaAccount:null);
				info.AddValue("_lookupCollectionViaAccount", ((_lookupCollectionViaAccount!=null) && (_lookupCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccount:null);
				info.AddValue("_lookupCollectionViaAccount_", ((_lookupCollectionViaAccount_!=null) && (_lookupCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccount_:null);
				info.AddValue("_prospectsCollectionViaAccount", ((_prospectsCollectionViaAccount!=null) && (_prospectsCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaAccount:null);
				info.AddValue("_prospectsCollectionViaAccount_", ((_prospectsCollectionViaAccount_!=null) && (_prospectsCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaAccount_:null);
				info.AddValue("_surveyTemplateCollectionViaAccount_", ((_surveyTemplateCollectionViaAccount_!=null) && (_surveyTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaAccount_:null);
				info.AddValue("_surveyTemplateCollectionViaAccount", ((_surveyTemplateCollectionViaAccount!=null) && (_surveyTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaAccount:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
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
		public bool TestOriginalFieldValueForNull(CheckListTemplateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CheckListTemplateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CheckListTemplateRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.CheckListTemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.ExitInterviewTemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateQuestionFields.TemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventChecklistTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventChecklistTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventChecklistTemplateFields.ChecklistTemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChecklistGroupQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChecklistGroupQuestionCollectionViaCheckListTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListQuestionCollectionViaCheckListTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListQuestionCollectionViaCheckListTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventChecklistTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventChecklistTemplate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_____________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount______________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_______________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount____________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Type));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CheckListTemplateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._account_);
			collectionsQueue.Enqueue(this._account);
			collectionsQueue.Enqueue(this._checkListTemplateQuestion);
			collectionsQueue.Enqueue(this._eventChecklistTemplate);
			collectionsQueue.Enqueue(this._checklistGroupQuestionCollectionViaCheckListTemplateQuestion);
			collectionsQueue.Enqueue(this._checkListQuestionCollectionViaCheckListTemplateQuestion);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount___);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount_______);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount__);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount____);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount______);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount_____);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventChecklistTemplate);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_____________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount______________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_______________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_______);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount____________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount______);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__);
			collectionsQueue.Enqueue(this._fluConsentTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._fluConsentTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccount);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccount_);
			collectionsQueue.Enqueue(this._prospectsCollectionViaAccount);
			collectionsQueue.Enqueue(this._prospectsCollectionViaAccount_);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaAccount);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._account_ = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._account = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateQuestion = (EntityCollection<CheckListTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._eventChecklistTemplate = (EntityCollection<EventChecklistTemplateEntity>) collectionsQueue.Dequeue();
			this._checklistGroupQuestionCollectionViaCheckListTemplateQuestion = (EntityCollection<ChecklistGroupQuestionEntity>) collectionsQueue.Dequeue();
			this._checkListQuestionCollectionViaCheckListTemplateQuestion = (EntityCollection<CheckListQuestionEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount___ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount_______ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount_ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount__ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount____ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount______ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount_____ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventChecklistTemplate = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_____________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount______________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_______________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount____________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateCollectionViaAccount_ = (EntityCollection<FluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateCollectionViaAccount = (EntityCollection<FluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaAccount_ = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaAccount = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccount = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccount_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaAccount = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaAccount_ = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaAccount_ = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._account_ != null)
			{
				return true;
			}
			if (this._account != null)
			{
				return true;
			}
			if (this._checkListTemplateQuestion != null)
			{
				return true;
			}
			if (this._eventChecklistTemplate != null)
			{
				return true;
			}
			if (this._checklistGroupQuestionCollectionViaCheckListTemplateQuestion != null)
			{
				return true;
			}
			if (this._checkListQuestionCollectionViaCheckListTemplateQuestion != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount_______ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount____ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount______ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount_____ != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventChecklistTemplate != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_____________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount______________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_______________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_______ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount____ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_____ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount__________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount____________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount______ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount___________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._fluConsentTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._fluConsentTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccount != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._prospectsCollectionViaAccount != null)
			{
				return true;
			}
			if (this._prospectsCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._surveyTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._surveyTemplateCollectionViaAccount != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventChecklistTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventChecklistTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Account_", _account_);
			toReturn.Add("Account", _account);
			toReturn.Add("CheckListTemplateQuestion", _checkListTemplateQuestion);
			toReturn.Add("EventChecklistTemplate", _eventChecklistTemplate);
			toReturn.Add("ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion", _checklistGroupQuestionCollectionViaCheckListTemplateQuestion);
			toReturn.Add("CheckListQuestionCollectionViaCheckListTemplateQuestion", _checkListQuestionCollectionViaCheckListTemplateQuestion);
			toReturn.Add("EmailTemplateCollectionViaAccount___", _emailTemplateCollectionViaAccount___);
			toReturn.Add("EmailTemplateCollectionViaAccount_______", _emailTemplateCollectionViaAccount_______);
			toReturn.Add("EmailTemplateCollectionViaAccount_", _emailTemplateCollectionViaAccount_);
			toReturn.Add("EmailTemplateCollectionViaAccount__", _emailTemplateCollectionViaAccount__);
			toReturn.Add("EmailTemplateCollectionViaAccount____", _emailTemplateCollectionViaAccount____);
			toReturn.Add("EmailTemplateCollectionViaAccount", _emailTemplateCollectionViaAccount);
			toReturn.Add("EmailTemplateCollectionViaAccount______", _emailTemplateCollectionViaAccount______);
			toReturn.Add("EmailTemplateCollectionViaAccount_____", _emailTemplateCollectionViaAccount_____);
			toReturn.Add("EventsCollectionViaEventChecklistTemplate", _eventsCollectionViaEventChecklistTemplate);
			toReturn.Add("FileCollectionViaAccount________________", _fileCollectionViaAccount________________);
			toReturn.Add("FileCollectionViaAccount_________________", _fileCollectionViaAccount_________________);
			toReturn.Add("FileCollectionViaAccount", _fileCollectionViaAccount);
			toReturn.Add("FileCollectionViaAccount_____________", _fileCollectionViaAccount_____________);
			toReturn.Add("FileCollectionViaAccount______________", _fileCollectionViaAccount______________);
			toReturn.Add("FileCollectionViaAccount_______________", _fileCollectionViaAccount_______________);
			toReturn.Add("FileCollectionViaAccount_______", _fileCollectionViaAccount_______);
			toReturn.Add("FileCollectionViaAccount________", _fileCollectionViaAccount________);
			toReturn.Add("FileCollectionViaAccount_________", _fileCollectionViaAccount_________);
			toReturn.Add("FileCollectionViaAccount____", _fileCollectionViaAccount____);
			toReturn.Add("FileCollectionViaAccount_____", _fileCollectionViaAccount_____);
			toReturn.Add("FileCollectionViaAccount___", _fileCollectionViaAccount___);
			toReturn.Add("FileCollectionViaAccount__________", _fileCollectionViaAccount__________);
			toReturn.Add("FileCollectionViaAccount____________", _fileCollectionViaAccount____________);
			toReturn.Add("FileCollectionViaAccount_", _fileCollectionViaAccount_);
			toReturn.Add("FileCollectionViaAccount______", _fileCollectionViaAccount______);
			toReturn.Add("FileCollectionViaAccount___________", _fileCollectionViaAccount___________);
			toReturn.Add("FileCollectionViaAccount__", _fileCollectionViaAccount__);
			toReturn.Add("FluConsentTemplateCollectionViaAccount_", _fluConsentTemplateCollectionViaAccount_);
			toReturn.Add("FluConsentTemplateCollectionViaAccount", _fluConsentTemplateCollectionViaAccount);
			toReturn.Add("HafTemplateCollectionViaAccount_", _hafTemplateCollectionViaAccount_);
			toReturn.Add("HafTemplateCollectionViaAccount", _hafTemplateCollectionViaAccount);
			toReturn.Add("LookupCollectionViaAccount", _lookupCollectionViaAccount);
			toReturn.Add("LookupCollectionViaAccount_", _lookupCollectionViaAccount_);
			toReturn.Add("ProspectsCollectionViaAccount", _prospectsCollectionViaAccount);
			toReturn.Add("ProspectsCollectionViaAccount_", _prospectsCollectionViaAccount_);
			toReturn.Add("SurveyTemplateCollectionViaAccount_", _surveyTemplateCollectionViaAccount_);
			toReturn.Add("SurveyTemplateCollectionViaAccount", _surveyTemplateCollectionViaAccount);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_account_!=null)
			{
				_account_.ActiveContext = base.ActiveContext;
			}
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateQuestion!=null)
			{
				_checkListTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_eventChecklistTemplate!=null)
			{
				_eventChecklistTemplate.ActiveContext = base.ActiveContext;
			}
			if(_checklistGroupQuestionCollectionViaCheckListTemplateQuestion!=null)
			{
				_checklistGroupQuestionCollectionViaCheckListTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListQuestionCollectionViaCheckListTemplateQuestion!=null)
			{
				_checkListQuestionCollectionViaCheckListTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount___!=null)
			{
				_emailTemplateCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount_______!=null)
			{
				_emailTemplateCollectionViaAccount_______.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount_!=null)
			{
				_emailTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount__!=null)
			{
				_emailTemplateCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount____!=null)
			{
				_emailTemplateCollectionViaAccount____.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount!=null)
			{
				_emailTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount______!=null)
			{
				_emailTemplateCollectionViaAccount______.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount_____!=null)
			{
				_emailTemplateCollectionViaAccount_____.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventChecklistTemplate!=null)
			{
				_eventsCollectionViaEventChecklistTemplate.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount________________!=null)
			{
				_fileCollectionViaAccount________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_________________!=null)
			{
				_fileCollectionViaAccount_________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount!=null)
			{
				_fileCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_____________!=null)
			{
				_fileCollectionViaAccount_____________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount______________!=null)
			{
				_fileCollectionViaAccount______________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_______________!=null)
			{
				_fileCollectionViaAccount_______________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_______!=null)
			{
				_fileCollectionViaAccount_______.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount________!=null)
			{
				_fileCollectionViaAccount________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_________!=null)
			{
				_fileCollectionViaAccount_________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount____!=null)
			{
				_fileCollectionViaAccount____.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_____!=null)
			{
				_fileCollectionViaAccount_____.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount___!=null)
			{
				_fileCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount__________!=null)
			{
				_fileCollectionViaAccount__________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount____________!=null)
			{
				_fileCollectionViaAccount____________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_!=null)
			{
				_fileCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount______!=null)
			{
				_fileCollectionViaAccount______.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount___________!=null)
			{
				_fileCollectionViaAccount___________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount__!=null)
			{
				_fileCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateCollectionViaAccount_!=null)
			{
				_fluConsentTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateCollectionViaAccount!=null)
			{
				_fluConsentTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaAccount_!=null)
			{
				_hafTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaAccount!=null)
			{
				_hafTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccount!=null)
			{
				_lookupCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccount_!=null)
			{
				_lookupCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaAccount!=null)
			{
				_prospectsCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaAccount_!=null)
			{
				_prospectsCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaAccount_!=null)
			{
				_surveyTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaAccount!=null)
			{
				_surveyTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
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

			_account_ = null;
			_account = null;
			_checkListTemplateQuestion = null;
			_eventChecklistTemplate = null;
			_checklistGroupQuestionCollectionViaCheckListTemplateQuestion = null;
			_checkListQuestionCollectionViaCheckListTemplateQuestion = null;
			_emailTemplateCollectionViaAccount___ = null;
			_emailTemplateCollectionViaAccount_______ = null;
			_emailTemplateCollectionViaAccount_ = null;
			_emailTemplateCollectionViaAccount__ = null;
			_emailTemplateCollectionViaAccount____ = null;
			_emailTemplateCollectionViaAccount = null;
			_emailTemplateCollectionViaAccount______ = null;
			_emailTemplateCollectionViaAccount_____ = null;
			_eventsCollectionViaEventChecklistTemplate = null;
			_fileCollectionViaAccount________________ = null;
			_fileCollectionViaAccount_________________ = null;
			_fileCollectionViaAccount = null;
			_fileCollectionViaAccount_____________ = null;
			_fileCollectionViaAccount______________ = null;
			_fileCollectionViaAccount_______________ = null;
			_fileCollectionViaAccount_______ = null;
			_fileCollectionViaAccount________ = null;
			_fileCollectionViaAccount_________ = null;
			_fileCollectionViaAccount____ = null;
			_fileCollectionViaAccount_____ = null;
			_fileCollectionViaAccount___ = null;
			_fileCollectionViaAccount__________ = null;
			_fileCollectionViaAccount____________ = null;
			_fileCollectionViaAccount_ = null;
			_fileCollectionViaAccount______ = null;
			_fileCollectionViaAccount___________ = null;
			_fileCollectionViaAccount__ = null;
			_fluConsentTemplateCollectionViaAccount_ = null;
			_fluConsentTemplateCollectionViaAccount = null;
			_hafTemplateCollectionViaAccount_ = null;
			_hafTemplateCollectionViaAccount = null;
			_lookupCollectionViaAccount = null;
			_lookupCollectionViaAccount_ = null;
			_prospectsCollectionViaAccount = null;
			_prospectsCollectionViaAccount_ = null;
			_surveyTemplateCollectionViaAccount_ = null;
			_surveyTemplateCollectionViaAccount = null;
			_lookup = null;
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

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HealthPlanId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPublished", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefault", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Type", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CheckListTemplateEntity.Relations.LookupEntityUsingType, true, signalRelatedEntity, "CheckListTemplate", resetFKFields, new int[] { (int)CheckListTemplateFieldIndex.Type } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CheckListTemplateEntity.Relations.LookupEntityUsingType, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CheckListTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "CheckListTemplate_", resetFKFields, new int[] { (int)CheckListTemplateFieldIndex.ModifiedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CheckListTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CheckListTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "CheckListTemplate", resetFKFields, new int[] { (int)CheckListTemplateFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CheckListTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CheckListTemplateEntity</param>
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
		public  static CheckListTemplateRelations Relations
		{
			get	{ return new CheckListTemplateRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccount_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account_")[0], (int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplateQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CheckListTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListTemplateQuestion")[0], (int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateQuestionEntity, 0, null, null, null, null, "CheckListTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventChecklistTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventChecklistTemplate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventChecklistTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventChecklistTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventChecklistTemplate")[0], (int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EventChecklistTemplateEntity, 0, null, null, null, null, "EventChecklistTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChecklistGroupQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChecklistGroupQuestionCollectionViaCheckListTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.CheckListTemplateQuestionEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "CheckListTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, 0, null, null, GetRelationsForField("ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion"), null, "ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListQuestionCollectionViaCheckListTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.CheckListTemplateQuestionEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "CheckListTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.CheckListQuestionEntity, 0, null, null, GetRelationsForField("CheckListQuestionCollectionViaCheckListTemplateQuestion"), null, "CheckListQuestionCollectionViaCheckListTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount___"), null, "EmailTemplateCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount_______
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount_______"), null, "EmailTemplateCollectionViaAccount_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount_"), null, "EmailTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount__"), null, "EmailTemplateCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount____
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount____"), null, "EmailTemplateCollectionViaAccount____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount"), null, "EmailTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount______
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount______"), null, "EmailTemplateCollectionViaAccount______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount_____
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount_____"), null, "EmailTemplateCollectionViaAccount_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventChecklistTemplate
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.EventChecklistTemplateEntityUsingChecklistTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventChecklistTemplate_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventChecklistTemplate"), null, "EventsCollectionViaEventChecklistTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount________________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount________________"), null, "FileCollectionViaAccount________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_________________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_________________"), null, "FileCollectionViaAccount_________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount"), null, "FileCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_____________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_____________"), null, "FileCollectionViaAccount_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount______________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount______________"), null, "FileCollectionViaAccount______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_______________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_______________"), null, "FileCollectionViaAccount_______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_______
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_______"), null, "FileCollectionViaAccount_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount________"), null, "FileCollectionViaAccount________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_________"), null, "FileCollectionViaAccount_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount____
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount____"), null, "FileCollectionViaAccount____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_____
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_____"), null, "FileCollectionViaAccount_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___"), null, "FileCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__________"), null, "FileCollectionViaAccount__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount____________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount____________"), null, "FileCollectionViaAccount____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_"), null, "FileCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount______
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount______"), null, "FileCollectionViaAccount______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___________
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___________"), null, "FileCollectionViaAccount___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__"), null, "FileCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, GetRelationsForField("FluConsentTemplateCollectionViaAccount_"), null, "FluConsentTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, GetRelationsForField("FluConsentTemplateCollectionViaAccount"), null, "FluConsentTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaAccount_"), null, "HafTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaAccount"), null, "HafTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccount"), null, "LookupCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccount_"), null, "LookupCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaAccount"), null, "ProspectsCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaAccount_"), null, "ProspectsCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingCheckListTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaAccount_"), null, "SurveyTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListTemplateEntity.Relations.AccountEntityUsingExitInterviewTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaAccount"), null, "SurveyTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CheckListTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CheckListTemplateEntity.CustomProperties;}
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
			get { return CheckListTemplateEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CheckListTemplateFieldIndex.Id, true); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.Id, value); }
		}

		/// <summary> The Name property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CheckListTemplateFieldIndex.Name, true); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.Name, value); }
		}

		/// <summary> The HealthPlanId property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."HealthPlanId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HealthPlanId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CheckListTemplateFieldIndex.HealthPlanId, false); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.HealthPlanId, value); }
		}

		/// <summary> The IsActive property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CheckListTemplateFieldIndex.IsActive, true); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.IsActive, value); }
		}

		/// <summary> The IsPublished property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."IsPublished"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPublished
		{
			get { return (System.Boolean)GetValue((int)CheckListTemplateFieldIndex.IsPublished, true); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.IsPublished, value); }
		}

		/// <summary> The DateCreated property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CheckListTemplateFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CheckListTemplateFieldIndex.DateModified, false); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.DateModified, value); }
		}

		/// <summary> The CreatedBy property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)CheckListTemplateFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.CreatedBy, value); }
		}

		/// <summary> The ModifiedBy property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)CheckListTemplateFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The IsDefault property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."IsDefault"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefault
		{
			get { return (System.Boolean)GetValue((int)CheckListTemplateFieldIndex.IsDefault, true); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.IsDefault, value); }
		}

		/// <summary> The Type property of the Entity CheckListTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplate"."Type"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Type
		{
			get { return (System.Int64)GetValue((int)CheckListTemplateFieldIndex.Type, true); }
			set	{ SetValue((int)CheckListTemplateFieldIndex.Type, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> Account_
		{
			get
			{
				if(_account_==null)
				{
					_account_ = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_account_.SetContainingEntityInfo(this, "CheckListTemplate_");
				}
				return _account_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> Account
		{
			get
			{
				if(_account==null)
				{
					_account = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_account.SetContainingEntityInfo(this, "CheckListTemplate");
				}
				return _account;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateQuestionEntity))]
		public virtual EntityCollection<CheckListTemplateQuestionEntity> CheckListTemplateQuestion
		{
			get
			{
				if(_checkListTemplateQuestion==null)
				{
					_checkListTemplateQuestion = new EntityCollection<CheckListTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateQuestionEntityFactory)));
					_checkListTemplateQuestion.SetContainingEntityInfo(this, "CheckListTemplate");
				}
				return _checkListTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventChecklistTemplateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventChecklistTemplateEntity))]
		public virtual EntityCollection<EventChecklistTemplateEntity> EventChecklistTemplate
		{
			get
			{
				if(_eventChecklistTemplate==null)
				{
					_eventChecklistTemplate = new EntityCollection<EventChecklistTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventChecklistTemplateEntityFactory)));
					_eventChecklistTemplate.SetContainingEntityInfo(this, "CheckListTemplate");
				}
				return _eventChecklistTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChecklistGroupQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChecklistGroupQuestionEntity))]
		public virtual EntityCollection<ChecklistGroupQuestionEntity> ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion
		{
			get
			{
				if(_checklistGroupQuestionCollectionViaCheckListTemplateQuestion==null)
				{
					_checklistGroupQuestionCollectionViaCheckListTemplateQuestion = new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory)));
					_checklistGroupQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly=true;
				}
				return _checklistGroupQuestionCollectionViaCheckListTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListQuestionEntity))]
		public virtual EntityCollection<CheckListQuestionEntity> CheckListQuestionCollectionViaCheckListTemplateQuestion
		{
			get
			{
				if(_checkListQuestionCollectionViaCheckListTemplateQuestion==null)
				{
					_checkListQuestionCollectionViaCheckListTemplateQuestion = new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory)));
					_checkListQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly=true;
				}
				return _checkListQuestionCollectionViaCheckListTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount___
		{
			get
			{
				if(_emailTemplateCollectionViaAccount___==null)
				{
					_emailTemplateCollectionViaAccount___ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount___.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount_______
		{
			get
			{
				if(_emailTemplateCollectionViaAccount_______==null)
				{
					_emailTemplateCollectionViaAccount_______ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount_______.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount_
		{
			get
			{
				if(_emailTemplateCollectionViaAccount_==null)
				{
					_emailTemplateCollectionViaAccount_ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount_.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount__
		{
			get
			{
				if(_emailTemplateCollectionViaAccount__==null)
				{
					_emailTemplateCollectionViaAccount__ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount__.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount____
		{
			get
			{
				if(_emailTemplateCollectionViaAccount____==null)
				{
					_emailTemplateCollectionViaAccount____ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount____.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount
		{
			get
			{
				if(_emailTemplateCollectionViaAccount==null)
				{
					_emailTemplateCollectionViaAccount = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount______
		{
			get
			{
				if(_emailTemplateCollectionViaAccount______==null)
				{
					_emailTemplateCollectionViaAccount______ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount______.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount_____
		{
			get
			{
				if(_emailTemplateCollectionViaAccount_____==null)
				{
					_emailTemplateCollectionViaAccount_____ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount_____.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventChecklistTemplate
		{
			get
			{
				if(_eventsCollectionViaEventChecklistTemplate==null)
				{
					_eventsCollectionViaEventChecklistTemplate = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventChecklistTemplate.IsReadOnly=true;
				}
				return _eventsCollectionViaEventChecklistTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount________________
		{
			get
			{
				if(_fileCollectionViaAccount________________==null)
				{
					_fileCollectionViaAccount________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_________________
		{
			get
			{
				if(_fileCollectionViaAccount_________________==null)
				{
					_fileCollectionViaAccount_________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount
		{
			get
			{
				if(_fileCollectionViaAccount==null)
				{
					_fileCollectionViaAccount = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount.IsReadOnly=true;
				}
				return _fileCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_____________
		{
			get
			{
				if(_fileCollectionViaAccount_____________==null)
				{
					_fileCollectionViaAccount_____________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_____________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount______________
		{
			get
			{
				if(_fileCollectionViaAccount______________==null)
				{
					_fileCollectionViaAccount______________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount______________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount______________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_______________
		{
			get
			{
				if(_fileCollectionViaAccount_______________==null)
				{
					_fileCollectionViaAccount_______________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_______________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_______________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_______
		{
			get
			{
				if(_fileCollectionViaAccount_______==null)
				{
					_fileCollectionViaAccount_______ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_______.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount________
		{
			get
			{
				if(_fileCollectionViaAccount________==null)
				{
					_fileCollectionViaAccount________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_________
		{
			get
			{
				if(_fileCollectionViaAccount_________==null)
				{
					_fileCollectionViaAccount_________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount____
		{
			get
			{
				if(_fileCollectionViaAccount____==null)
				{
					_fileCollectionViaAccount____ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount____.IsReadOnly=true;
				}
				return _fileCollectionViaAccount____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_____
		{
			get
			{
				if(_fileCollectionViaAccount_____==null)
				{
					_fileCollectionViaAccount_____ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_____.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount___
		{
			get
			{
				if(_fileCollectionViaAccount___==null)
				{
					_fileCollectionViaAccount___ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount___.IsReadOnly=true;
				}
				return _fileCollectionViaAccount___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount__________
		{
			get
			{
				if(_fileCollectionViaAccount__________==null)
				{
					_fileCollectionViaAccount__________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount__________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount__________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount____________
		{
			get
			{
				if(_fileCollectionViaAccount____________==null)
				{
					_fileCollectionViaAccount____________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount____________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_
		{
			get
			{
				if(_fileCollectionViaAccount_==null)
				{
					_fileCollectionViaAccount_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount______
		{
			get
			{
				if(_fileCollectionViaAccount______==null)
				{
					_fileCollectionViaAccount______ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount______.IsReadOnly=true;
				}
				return _fileCollectionViaAccount______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount___________
		{
			get
			{
				if(_fileCollectionViaAccount___________==null)
				{
					_fileCollectionViaAccount___________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount___________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount___________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount__
		{
			get
			{
				if(_fileCollectionViaAccount__==null)
				{
					_fileCollectionViaAccount__ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount__.IsReadOnly=true;
				}
				return _fileCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentTemplateEntity))]
		public virtual EntityCollection<FluConsentTemplateEntity> FluConsentTemplateCollectionViaAccount_
		{
			get
			{
				if(_fluConsentTemplateCollectionViaAccount_==null)
				{
					_fluConsentTemplateCollectionViaAccount_ = new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory)));
					_fluConsentTemplateCollectionViaAccount_.IsReadOnly=true;
				}
				return _fluConsentTemplateCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentTemplateEntity))]
		public virtual EntityCollection<FluConsentTemplateEntity> FluConsentTemplateCollectionViaAccount
		{
			get
			{
				if(_fluConsentTemplateCollectionViaAccount==null)
				{
					_fluConsentTemplateCollectionViaAccount = new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory)));
					_fluConsentTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _fluConsentTemplateCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaAccount_
		{
			get
			{
				if(_hafTemplateCollectionViaAccount_==null)
				{
					_hafTemplateCollectionViaAccount_ = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaAccount_.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaAccount
		{
			get
			{
				if(_hafTemplateCollectionViaAccount==null)
				{
					_hafTemplateCollectionViaAccount = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaAccount
		{
			get
			{
				if(_lookupCollectionViaAccount==null)
				{
					_lookupCollectionViaAccount = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaAccount.IsReadOnly=true;
				}
				return _lookupCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaAccount_
		{
			get
			{
				if(_lookupCollectionViaAccount_==null)
				{
					_lookupCollectionViaAccount_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaAccount_.IsReadOnly=true;
				}
				return _lookupCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectsEntity))]
		public virtual EntityCollection<ProspectsEntity> ProspectsCollectionViaAccount
		{
			get
			{
				if(_prospectsCollectionViaAccount==null)
				{
					_prospectsCollectionViaAccount = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospectsCollectionViaAccount.IsReadOnly=true;
				}
				return _prospectsCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectsEntity))]
		public virtual EntityCollection<ProspectsEntity> ProspectsCollectionViaAccount_
		{
			get
			{
				if(_prospectsCollectionViaAccount_==null)
				{
					_prospectsCollectionViaAccount_ = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospectsCollectionViaAccount_.IsReadOnly=true;
				}
				return _prospectsCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyTemplateEntity))]
		public virtual EntityCollection<SurveyTemplateEntity> SurveyTemplateCollectionViaAccount_
		{
			get
			{
				if(_surveyTemplateCollectionViaAccount_==null)
				{
					_surveyTemplateCollectionViaAccount_ = new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory)));
					_surveyTemplateCollectionViaAccount_.IsReadOnly=true;
				}
				return _surveyTemplateCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyTemplateEntity))]
		public virtual EntityCollection<SurveyTemplateEntity> SurveyTemplateCollectionViaAccount
		{
			get
			{
				if(_surveyTemplateCollectionViaAccount==null)
				{
					_surveyTemplateCollectionViaAccount = new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory)));
					_surveyTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _surveyTemplateCollectionViaAccount;
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
							_lookup.UnsetRelatedEntity(this, "CheckListTemplate");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListTemplate");
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "CheckListTemplate_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListTemplate_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CheckListTemplate");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListTemplate");
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
			get { return (int)Falcon.Data.EntityType.CheckListTemplateEntity; }
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
