///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:52
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
	/// Entity class which represents the entity 'FluConsentTemplate'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class FluConsentTemplateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountEntity> _account;
		private EntityCollection<EventFluConsentTemplateEntity> _eventFluConsentTemplate;
		private EntityCollection<FluConsentTemplateQuestionEntity> _fluConsentTemplateQuestion;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount_;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount_;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount___;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount__;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventFluConsentTemplate;
		private EntityCollection<FileEntity> _fileCollectionViaAccount________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount______;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_______;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_;
		private EntityCollection<FileEntity> _fileCollectionViaAccount;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__;
		private EntityCollection<FileEntity> _fileCollectionViaAccount____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___;
		private EntityCollection<FluConsentQuestionEntity> _fluConsentQuestionCollectionViaFluConsentTemplateQuestion;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaAccount;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccount;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaAccount;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaAccount;
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
			/// <summary>Member name Account</summary>
			public static readonly string Account = "Account";
			/// <summary>Member name EventFluConsentTemplate</summary>
			public static readonly string EventFluConsentTemplate = "EventFluConsentTemplate";
			/// <summary>Member name FluConsentTemplateQuestion</summary>
			public static readonly string FluConsentTemplateQuestion = "FluConsentTemplateQuestion";
			/// <summary>Member name CheckListTemplateCollectionViaAccount</summary>
			public static readonly string CheckListTemplateCollectionViaAccount = "CheckListTemplateCollectionViaAccount";
			/// <summary>Member name CheckListTemplateCollectionViaAccount_</summary>
			public static readonly string CheckListTemplateCollectionViaAccount_ = "CheckListTemplateCollectionViaAccount_";
			/// <summary>Member name EmailTemplateCollectionViaAccount</summary>
			public static readonly string EmailTemplateCollectionViaAccount = "EmailTemplateCollectionViaAccount";
			/// <summary>Member name EmailTemplateCollectionViaAccount_</summary>
			public static readonly string EmailTemplateCollectionViaAccount_ = "EmailTemplateCollectionViaAccount_";
			/// <summary>Member name EmailTemplateCollectionViaAccount___</summary>
			public static readonly string EmailTemplateCollectionViaAccount___ = "EmailTemplateCollectionViaAccount___";
			/// <summary>Member name EmailTemplateCollectionViaAccount__</summary>
			public static readonly string EmailTemplateCollectionViaAccount__ = "EmailTemplateCollectionViaAccount__";
			/// <summary>Member name EventsCollectionViaEventFluConsentTemplate</summary>
			public static readonly string EventsCollectionViaEventFluConsentTemplate = "EventsCollectionViaEventFluConsentTemplate";
			/// <summary>Member name FileCollectionViaAccount________</summary>
			public static readonly string FileCollectionViaAccount________ = "FileCollectionViaAccount________";
			/// <summary>Member name FileCollectionViaAccount_____</summary>
			public static readonly string FileCollectionViaAccount_____ = "FileCollectionViaAccount_____";
			/// <summary>Member name FileCollectionViaAccount______</summary>
			public static readonly string FileCollectionViaAccount______ = "FileCollectionViaAccount______";
			/// <summary>Member name FileCollectionViaAccount_______</summary>
			public static readonly string FileCollectionViaAccount_______ = "FileCollectionViaAccount_______";
			/// <summary>Member name FileCollectionViaAccount_</summary>
			public static readonly string FileCollectionViaAccount_ = "FileCollectionViaAccount_";
			/// <summary>Member name FileCollectionViaAccount</summary>
			public static readonly string FileCollectionViaAccount = "FileCollectionViaAccount";
			/// <summary>Member name FileCollectionViaAccount__</summary>
			public static readonly string FileCollectionViaAccount__ = "FileCollectionViaAccount__";
			/// <summary>Member name FileCollectionViaAccount____</summary>
			public static readonly string FileCollectionViaAccount____ = "FileCollectionViaAccount____";
			/// <summary>Member name FileCollectionViaAccount___</summary>
			public static readonly string FileCollectionViaAccount___ = "FileCollectionViaAccount___";
			/// <summary>Member name FluConsentQuestionCollectionViaFluConsentTemplateQuestion</summary>
			public static readonly string FluConsentQuestionCollectionViaFluConsentTemplateQuestion = "FluConsentQuestionCollectionViaFluConsentTemplateQuestion";
			/// <summary>Member name HafTemplateCollectionViaAccount</summary>
			public static readonly string HafTemplateCollectionViaAccount = "HafTemplateCollectionViaAccount";
			/// <summary>Member name LookupCollectionViaAccount</summary>
			public static readonly string LookupCollectionViaAccount = "LookupCollectionViaAccount";
			/// <summary>Member name ProspectsCollectionViaAccount</summary>
			public static readonly string ProspectsCollectionViaAccount = "ProspectsCollectionViaAccount";
			/// <summary>Member name SurveyTemplateCollectionViaAccount</summary>
			public static readonly string SurveyTemplateCollectionViaAccount = "SurveyTemplateCollectionViaAccount";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static FluConsentTemplateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public FluConsentTemplateEntity():base("FluConsentTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public FluConsentTemplateEntity(IEntityFields2 fields):base("FluConsentTemplateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this FluConsentTemplateEntity</param>
		public FluConsentTemplateEntity(IValidator validator):base("FluConsentTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for FluConsentTemplate which data should be fetched into this FluConsentTemplate object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FluConsentTemplateEntity(System.Int64 id):base("FluConsentTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for FluConsentTemplate which data should be fetched into this FluConsentTemplate object</param>
		/// <param name="validator">The custom validator object for this FluConsentTemplateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FluConsentTemplateEntity(System.Int64 id, IValidator validator):base("FluConsentTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected FluConsentTemplateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_account = (EntityCollection<AccountEntity>)info.GetValue("_account", typeof(EntityCollection<AccountEntity>));
				_eventFluConsentTemplate = (EntityCollection<EventFluConsentTemplateEntity>)info.GetValue("_eventFluConsentTemplate", typeof(EntityCollection<EventFluConsentTemplateEntity>));
				_fluConsentTemplateQuestion = (EntityCollection<FluConsentTemplateQuestionEntity>)info.GetValue("_fluConsentTemplateQuestion", typeof(EntityCollection<FluConsentTemplateQuestionEntity>));
				_checkListTemplateCollectionViaAccount = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount_ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount_", typeof(EntityCollection<CheckListTemplateEntity>));
				_emailTemplateCollectionViaAccount = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount_ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount_", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount___ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount___", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount__ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount__", typeof(EntityCollection<EmailTemplateEntity>));
				_eventsCollectionViaEventFluConsentTemplate = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventFluConsentTemplate", typeof(EntityCollection<EventsEntity>));
				_fileCollectionViaAccount________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount______", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_______", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount__ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount___ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___", typeof(EntityCollection<FileEntity>));
				_fluConsentQuestionCollectionViaFluConsentTemplateQuestion = (EntityCollection<FluConsentQuestionEntity>)info.GetValue("_fluConsentQuestionCollectionViaFluConsentTemplateQuestion", typeof(EntityCollection<FluConsentQuestionEntity>));
				_hafTemplateCollectionViaAccount = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaAccount", typeof(EntityCollection<HafTemplateEntity>));
				_lookupCollectionViaAccount = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccount", typeof(EntityCollection<LookupEntity>));
				_prospectsCollectionViaAccount = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaAccount", typeof(EntityCollection<ProspectsEntity>));
				_surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaAccount", typeof(EntityCollection<SurveyTemplateEntity>));
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
			switch((FluConsentTemplateFieldIndex)fieldIndex)
			{
				case FluConsentTemplateFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case FluConsentTemplateFieldIndex.ModifiedBy:
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
				case "Account":
					this.Account.Add((AccountEntity)entity);
					break;
				case "EventFluConsentTemplate":
					this.EventFluConsentTemplate.Add((EventFluConsentTemplateEntity)entity);
					break;
				case "FluConsentTemplateQuestion":
					this.FluConsentTemplateQuestion.Add((FluConsentTemplateQuestionEntity)entity);
					break;
				case "CheckListTemplateCollectionViaAccount":
					this.CheckListTemplateCollectionViaAccount.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "CheckListTemplateCollectionViaAccount_":
					this.CheckListTemplateCollectionViaAccount_.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount_.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount":
					this.EmailTemplateCollectionViaAccount.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount_":
					this.EmailTemplateCollectionViaAccount_.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount_.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount___":
					this.EmailTemplateCollectionViaAccount___.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount___.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount___.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount__":
					this.EmailTemplateCollectionViaAccount__.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount__.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount__.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventFluConsentTemplate":
					this.EventsCollectionViaEventFluConsentTemplate.IsReadOnly = false;
					this.EventsCollectionViaEventFluConsentTemplate.Add((EventsEntity)entity);
					this.EventsCollectionViaEventFluConsentTemplate.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount________":
					this.FileCollectionViaAccount________.IsReadOnly = false;
					this.FileCollectionViaAccount________.Add((FileEntity)entity);
					this.FileCollectionViaAccount________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_____":
					this.FileCollectionViaAccount_____.IsReadOnly = false;
					this.FileCollectionViaAccount_____.Add((FileEntity)entity);
					this.FileCollectionViaAccount_____.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount______":
					this.FileCollectionViaAccount______.IsReadOnly = false;
					this.FileCollectionViaAccount______.Add((FileEntity)entity);
					this.FileCollectionViaAccount______.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_______":
					this.FileCollectionViaAccount_______.IsReadOnly = false;
					this.FileCollectionViaAccount_______.Add((FileEntity)entity);
					this.FileCollectionViaAccount_______.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_":
					this.FileCollectionViaAccount_.IsReadOnly = false;
					this.FileCollectionViaAccount_.Add((FileEntity)entity);
					this.FileCollectionViaAccount_.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount":
					this.FileCollectionViaAccount.IsReadOnly = false;
					this.FileCollectionViaAccount.Add((FileEntity)entity);
					this.FileCollectionViaAccount.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount__":
					this.FileCollectionViaAccount__.IsReadOnly = false;
					this.FileCollectionViaAccount__.Add((FileEntity)entity);
					this.FileCollectionViaAccount__.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount____":
					this.FileCollectionViaAccount____.IsReadOnly = false;
					this.FileCollectionViaAccount____.Add((FileEntity)entity);
					this.FileCollectionViaAccount____.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount___":
					this.FileCollectionViaAccount___.IsReadOnly = false;
					this.FileCollectionViaAccount___.Add((FileEntity)entity);
					this.FileCollectionViaAccount___.IsReadOnly = true;
					break;
				case "FluConsentQuestionCollectionViaFluConsentTemplateQuestion":
					this.FluConsentQuestionCollectionViaFluConsentTemplateQuestion.IsReadOnly = false;
					this.FluConsentQuestionCollectionViaFluConsentTemplateQuestion.Add((FluConsentQuestionEntity)entity);
					this.FluConsentQuestionCollectionViaFluConsentTemplateQuestion.IsReadOnly = true;
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
				case "ProspectsCollectionViaAccount":
					this.ProspectsCollectionViaAccount.IsReadOnly = false;
					this.ProspectsCollectionViaAccount.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaAccount.IsReadOnly = true;
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
			return FluConsentTemplateEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(FluConsentTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(FluConsentTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "Account":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId);
					break;
				case "EventFluConsentTemplate":
					toReturn.Add(FluConsentTemplateEntity.Relations.EventFluConsentTemplateEntityUsingTemplateId);
					break;
				case "FluConsentTemplateQuestion":
					toReturn.Add(FluConsentTemplateEntity.Relations.FluConsentTemplateQuestionEntityUsingTemplateId);
					break;
				case "CheckListTemplateCollectionViaAccount":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount_":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingConfirmationSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount_":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingMemberCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount___":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingReminderSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount__":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingPcpCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventFluConsentTemplate":
					toReturn.Add(FluConsentTemplateEntity.Relations.EventFluConsentTemplateEntityUsingTemplateId, "FluConsentTemplateEntity__", "EventFluConsentTemplate_", JoinHint.None);
					toReturn.Add(EventFluConsentTemplateEntity.Relations.EventsEntityUsingEventId, "EventFluConsentTemplate_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount________":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_____":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount______":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_______":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount____":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FluConsentQuestionCollectionViaFluConsentTemplateQuestion":
					toReturn.Add(FluConsentTemplateEntity.Relations.FluConsentTemplateQuestionEntityUsingTemplateId, "FluConsentTemplateEntity__", "FluConsentTemplateQuestion_", JoinHint.None);
					toReturn.Add(FluConsentTemplateQuestionEntity.Relations.FluConsentQuestionEntityUsingQuestionId, "FluConsentTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaAccount":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccount":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, "Account_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaAccount":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, "Account_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaAccount":
					toReturn.Add(FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId, "FluConsentTemplateEntity__", "Account_", JoinHint.None);
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
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Account":
					this.Account.Add((AccountEntity)relatedEntity);
					break;
				case "EventFluConsentTemplate":
					this.EventFluConsentTemplate.Add((EventFluConsentTemplateEntity)relatedEntity);
					break;
				case "FluConsentTemplateQuestion":
					this.FluConsentTemplateQuestion.Add((FluConsentTemplateQuestionEntity)relatedEntity);
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
				case "Account":
					base.PerformRelatedEntityRemoval(this.Account, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventFluConsentTemplate":
					base.PerformRelatedEntityRemoval(this.EventFluConsentTemplate, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "FluConsentTemplateQuestion":
					base.PerformRelatedEntityRemoval(this.FluConsentTemplateQuestion, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.Account);
			toReturn.Add(this.EventFluConsentTemplate);
			toReturn.Add(this.FluConsentTemplateQuestion);

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
				info.AddValue("_account", ((_account!=null) && (_account.Count>0) && !this.MarkedForDeletion)?_account:null);
				info.AddValue("_eventFluConsentTemplate", ((_eventFluConsentTemplate!=null) && (_eventFluConsentTemplate.Count>0) && !this.MarkedForDeletion)?_eventFluConsentTemplate:null);
				info.AddValue("_fluConsentTemplateQuestion", ((_fluConsentTemplateQuestion!=null) && (_fluConsentTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateQuestion:null);
				info.AddValue("_checkListTemplateCollectionViaAccount", ((_checkListTemplateCollectionViaAccount!=null) && (_checkListTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount:null);
				info.AddValue("_checkListTemplateCollectionViaAccount_", ((_checkListTemplateCollectionViaAccount_!=null) && (_checkListTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount_:null);
				info.AddValue("_emailTemplateCollectionViaAccount", ((_emailTemplateCollectionViaAccount!=null) && (_emailTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount:null);
				info.AddValue("_emailTemplateCollectionViaAccount_", ((_emailTemplateCollectionViaAccount_!=null) && (_emailTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount_:null);
				info.AddValue("_emailTemplateCollectionViaAccount___", ((_emailTemplateCollectionViaAccount___!=null) && (_emailTemplateCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount___:null);
				info.AddValue("_emailTemplateCollectionViaAccount__", ((_emailTemplateCollectionViaAccount__!=null) && (_emailTemplateCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount__:null);
				info.AddValue("_eventsCollectionViaEventFluConsentTemplate", ((_eventsCollectionViaEventFluConsentTemplate!=null) && (_eventsCollectionViaEventFluConsentTemplate.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventFluConsentTemplate:null);
				info.AddValue("_fileCollectionViaAccount________", ((_fileCollectionViaAccount________!=null) && (_fileCollectionViaAccount________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount________:null);
				info.AddValue("_fileCollectionViaAccount_____", ((_fileCollectionViaAccount_____!=null) && (_fileCollectionViaAccount_____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_____:null);
				info.AddValue("_fileCollectionViaAccount______", ((_fileCollectionViaAccount______!=null) && (_fileCollectionViaAccount______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount______:null);
				info.AddValue("_fileCollectionViaAccount_______", ((_fileCollectionViaAccount_______!=null) && (_fileCollectionViaAccount_______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_______:null);
				info.AddValue("_fileCollectionViaAccount_", ((_fileCollectionViaAccount_!=null) && (_fileCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_:null);
				info.AddValue("_fileCollectionViaAccount", ((_fileCollectionViaAccount!=null) && (_fileCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount:null);
				info.AddValue("_fileCollectionViaAccount__", ((_fileCollectionViaAccount__!=null) && (_fileCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__:null);
				info.AddValue("_fileCollectionViaAccount____", ((_fileCollectionViaAccount____!=null) && (_fileCollectionViaAccount____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount____:null);
				info.AddValue("_fileCollectionViaAccount___", ((_fileCollectionViaAccount___!=null) && (_fileCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___:null);
				info.AddValue("_fluConsentQuestionCollectionViaFluConsentTemplateQuestion", ((_fluConsentQuestionCollectionViaFluConsentTemplateQuestion!=null) && (_fluConsentQuestionCollectionViaFluConsentTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_fluConsentQuestionCollectionViaFluConsentTemplateQuestion:null);
				info.AddValue("_hafTemplateCollectionViaAccount", ((_hafTemplateCollectionViaAccount!=null) && (_hafTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaAccount:null);
				info.AddValue("_lookupCollectionViaAccount", ((_lookupCollectionViaAccount!=null) && (_lookupCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccount:null);
				info.AddValue("_prospectsCollectionViaAccount", ((_prospectsCollectionViaAccount!=null) && (_prospectsCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaAccount:null);
				info.AddValue("_surveyTemplateCollectionViaAccount", ((_surveyTemplateCollectionViaAccount!=null) && (_surveyTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaAccount:null);
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
		public bool TestOriginalFieldValueForNull(FluConsentTemplateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(FluConsentTemplateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new FluConsentTemplateRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.FluConsentTemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventFluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventFluConsentTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventFluConsentTemplateFields.TemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateQuestionFields.TemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventFluConsentTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventFluConsentTemplate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentQuestionCollectionViaFluConsentTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentQuestionCollectionViaFluConsentTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentTemplateEntity__"));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.FluConsentTemplateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._account);
			collectionsQueue.Enqueue(this._eventFluConsentTemplate);
			collectionsQueue.Enqueue(this._fluConsentTemplateQuestion);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount___);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount__);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventFluConsentTemplate);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount______);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_______);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___);
			collectionsQueue.Enqueue(this._fluConsentQuestionCollectionViaFluConsentTemplateQuestion);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccount);
			collectionsQueue.Enqueue(this._prospectsCollectionViaAccount);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaAccount);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._account = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._eventFluConsentTemplate = (EntityCollection<EventFluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateQuestion = (EntityCollection<FluConsentTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount_ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount_ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount___ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount__ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventFluConsentTemplate = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fluConsentQuestionCollectionViaFluConsentTemplateQuestion = (EntityCollection<FluConsentQuestionEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaAccount = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccount = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaAccount = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._account != null)
			{
				return true;
			}
			if (this._eventFluConsentTemplate != null)
			{
				return true;
			}
			if (this._fluConsentTemplateQuestion != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventFluConsentTemplate != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_____ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount______ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_______ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount____ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._fluConsentQuestionCollectionViaFluConsentTemplateQuestion != null)
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
			if (this._prospectsCollectionViaAccount != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventFluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventFluConsentTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Account", _account);
			toReturn.Add("EventFluConsentTemplate", _eventFluConsentTemplate);
			toReturn.Add("FluConsentTemplateQuestion", _fluConsentTemplateQuestion);
			toReturn.Add("CheckListTemplateCollectionViaAccount", _checkListTemplateCollectionViaAccount);
			toReturn.Add("CheckListTemplateCollectionViaAccount_", _checkListTemplateCollectionViaAccount_);
			toReturn.Add("EmailTemplateCollectionViaAccount", _emailTemplateCollectionViaAccount);
			toReturn.Add("EmailTemplateCollectionViaAccount_", _emailTemplateCollectionViaAccount_);
			toReturn.Add("EmailTemplateCollectionViaAccount___", _emailTemplateCollectionViaAccount___);
			toReturn.Add("EmailTemplateCollectionViaAccount__", _emailTemplateCollectionViaAccount__);
			toReturn.Add("EventsCollectionViaEventFluConsentTemplate", _eventsCollectionViaEventFluConsentTemplate);
			toReturn.Add("FileCollectionViaAccount________", _fileCollectionViaAccount________);
			toReturn.Add("FileCollectionViaAccount_____", _fileCollectionViaAccount_____);
			toReturn.Add("FileCollectionViaAccount______", _fileCollectionViaAccount______);
			toReturn.Add("FileCollectionViaAccount_______", _fileCollectionViaAccount_______);
			toReturn.Add("FileCollectionViaAccount_", _fileCollectionViaAccount_);
			toReturn.Add("FileCollectionViaAccount", _fileCollectionViaAccount);
			toReturn.Add("FileCollectionViaAccount__", _fileCollectionViaAccount__);
			toReturn.Add("FileCollectionViaAccount____", _fileCollectionViaAccount____);
			toReturn.Add("FileCollectionViaAccount___", _fileCollectionViaAccount___);
			toReturn.Add("FluConsentQuestionCollectionViaFluConsentTemplateQuestion", _fluConsentQuestionCollectionViaFluConsentTemplateQuestion);
			toReturn.Add("HafTemplateCollectionViaAccount", _hafTemplateCollectionViaAccount);
			toReturn.Add("LookupCollectionViaAccount", _lookupCollectionViaAccount);
			toReturn.Add("ProspectsCollectionViaAccount", _prospectsCollectionViaAccount);
			toReturn.Add("SurveyTemplateCollectionViaAccount", _surveyTemplateCollectionViaAccount);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_eventFluConsentTemplate!=null)
			{
				_eventFluConsentTemplate.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateQuestion!=null)
			{
				_fluConsentTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount!=null)
			{
				_checkListTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount_!=null)
			{
				_checkListTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount!=null)
			{
				_emailTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount_!=null)
			{
				_emailTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount___!=null)
			{
				_emailTemplateCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount__!=null)
			{
				_emailTemplateCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventFluConsentTemplate!=null)
			{
				_eventsCollectionViaEventFluConsentTemplate.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount________!=null)
			{
				_fileCollectionViaAccount________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_____!=null)
			{
				_fileCollectionViaAccount_____.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount______!=null)
			{
				_fileCollectionViaAccount______.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_______!=null)
			{
				_fileCollectionViaAccount_______.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_!=null)
			{
				_fileCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount!=null)
			{
				_fileCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount__!=null)
			{
				_fileCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount____!=null)
			{
				_fileCollectionViaAccount____.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount___!=null)
			{
				_fileCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentQuestionCollectionViaFluConsentTemplateQuestion!=null)
			{
				_fluConsentQuestionCollectionViaFluConsentTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaAccount!=null)
			{
				_hafTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccount!=null)
			{
				_lookupCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaAccount!=null)
			{
				_prospectsCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaAccount!=null)
			{
				_surveyTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
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

			_account = null;
			_eventFluConsentTemplate = null;
			_fluConsentTemplateQuestion = null;
			_checkListTemplateCollectionViaAccount = null;
			_checkListTemplateCollectionViaAccount_ = null;
			_emailTemplateCollectionViaAccount = null;
			_emailTemplateCollectionViaAccount_ = null;
			_emailTemplateCollectionViaAccount___ = null;
			_emailTemplateCollectionViaAccount__ = null;
			_eventsCollectionViaEventFluConsentTemplate = null;
			_fileCollectionViaAccount________ = null;
			_fileCollectionViaAccount_____ = null;
			_fileCollectionViaAccount______ = null;
			_fileCollectionViaAccount_______ = null;
			_fileCollectionViaAccount_ = null;
			_fileCollectionViaAccount = null;
			_fileCollectionViaAccount__ = null;
			_fileCollectionViaAccount____ = null;
			_fileCollectionViaAccount___ = null;
			_fluConsentQuestionCollectionViaFluConsentTemplateQuestion = null;
			_hafTemplateCollectionViaAccount = null;
			_lookupCollectionViaAccount = null;
			_prospectsCollectionViaAccount = null;
			_surveyTemplateCollectionViaAccount = null;
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

			_fieldsCustomProperties.Add("IsPublished", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", FluConsentTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "FluConsentTemplate_", resetFKFields, new int[] { (int)FluConsentTemplateFieldIndex.ModifiedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", FluConsentTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", FluConsentTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "FluConsentTemplate", resetFKFields, new int[] { (int)FluConsentTemplateFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", FluConsentTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this FluConsentTemplateEntity</param>
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
		public  static FluConsentTemplateRelations Relations
		{
			get	{ return new FluConsentTemplateRelations(); }
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
		public static IPrefetchPathElement2 PrefetchPathAccount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventFluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventFluConsentTemplate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventFluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventFluConsentTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventFluConsentTemplate")[0], (int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.EventFluConsentTemplateEntity, 0, null, null, null, null, "EventFluConsentTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplateQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FluConsentTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("FluConsentTemplateQuestion")[0], (int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FluConsentTemplateQuestionEntity, 0, null, null, null, null, "FluConsentTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount"), null, "CheckListTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount_"), null, "CheckListTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount"), null, "EmailTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount_"), null, "EmailTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount___"), null, "EmailTemplateCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount__"), null, "EmailTemplateCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventFluConsentTemplate
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.EventFluConsentTemplateEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventFluConsentTemplate_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventFluConsentTemplate"), null, "EventsCollectionViaEventFluConsentTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount________
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount________"), null, "FileCollectionViaAccount________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_____
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_____"), null, "FileCollectionViaAccount_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount______
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount______"), null, "FileCollectionViaAccount______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_______
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_______"), null, "FileCollectionViaAccount_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_"), null, "FileCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount"), null, "FileCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__"), null, "FileCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount____
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount____"), null, "FileCollectionViaAccount____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___"), null, "FileCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentQuestionCollectionViaFluConsentTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.FluConsentTemplateQuestionEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.FluConsentQuestionEntity, 0, null, null, GetRelationsForField("FluConsentQuestionCollectionViaFluConsentTemplateQuestion"), null, "FluConsentQuestionCollectionViaFluConsentTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaAccount"), null, "HafTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccount"), null, "LookupCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaAccount"), null, "ProspectsCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentTemplateEntity.Relations.AccountEntityUsingFluConsentTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaAccount"), null, "SurveyTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.FluConsentTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return FluConsentTemplateEntity.CustomProperties;}
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
			get { return FluConsentTemplateEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity FluConsentTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentTemplate"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)FluConsentTemplateFieldIndex.Id, true); }
			set	{ SetValue((int)FluConsentTemplateFieldIndex.Id, value); }
		}

		/// <summary> The Name property of the Entity FluConsentTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentTemplate"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)FluConsentTemplateFieldIndex.Name, true); }
			set	{ SetValue((int)FluConsentTemplateFieldIndex.Name, value); }
		}

		/// <summary> The IsPublished property of the Entity FluConsentTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentTemplate"."IsPublished"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPublished
		{
			get { return (System.Boolean)GetValue((int)FluConsentTemplateFieldIndex.IsPublished, true); }
			set	{ SetValue((int)FluConsentTemplateFieldIndex.IsPublished, value); }
		}

		/// <summary> The IsActive property of the Entity FluConsentTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentTemplate"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)FluConsentTemplateFieldIndex.IsActive, true); }
			set	{ SetValue((int)FluConsentTemplateFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity FluConsentTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentTemplate"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)FluConsentTemplateFieldIndex.DateCreated, true); }
			set	{ SetValue((int)FluConsentTemplateFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedBy property of the Entity FluConsentTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentTemplate"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)FluConsentTemplateFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)FluConsentTemplateFieldIndex.CreatedBy, value); }
		}

		/// <summary> The DateModified property of the Entity FluConsentTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentTemplate"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)FluConsentTemplateFieldIndex.DateModified, false); }
			set	{ SetValue((int)FluConsentTemplateFieldIndex.DateModified, value); }
		}

		/// <summary> The ModifiedBy property of the Entity FluConsentTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentTemplate"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)FluConsentTemplateFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)FluConsentTemplateFieldIndex.ModifiedBy, value); }
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
					_account.SetContainingEntityInfo(this, "FluConsentTemplate");
				}
				return _account;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventFluConsentTemplateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventFluConsentTemplateEntity))]
		public virtual EntityCollection<EventFluConsentTemplateEntity> EventFluConsentTemplate
		{
			get
			{
				if(_eventFluConsentTemplate==null)
				{
					_eventFluConsentTemplate = new EntityCollection<EventFluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventFluConsentTemplateEntityFactory)));
					_eventFluConsentTemplate.SetContainingEntityInfo(this, "FluConsentTemplate");
				}
				return _eventFluConsentTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentTemplateQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentTemplateQuestionEntity))]
		public virtual EntityCollection<FluConsentTemplateQuestionEntity> FluConsentTemplateQuestion
		{
			get
			{
				if(_fluConsentTemplateQuestion==null)
				{
					_fluConsentTemplateQuestion = new EntityCollection<FluConsentTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateQuestionEntityFactory)));
					_fluConsentTemplateQuestion.SetContainingEntityInfo(this, "FluConsentTemplate");
				}
				return _fluConsentTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount==null)
				{
					_checkListTemplateCollectionViaAccount = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount_
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount_==null)
				{
					_checkListTemplateCollectionViaAccount_ = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount_.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount_;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventFluConsentTemplate
		{
			get
			{
				if(_eventsCollectionViaEventFluConsentTemplate==null)
				{
					_eventsCollectionViaEventFluConsentTemplate = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventFluConsentTemplate.IsReadOnly=true;
				}
				return _eventsCollectionViaEventFluConsentTemplate;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentQuestionEntity))]
		public virtual EntityCollection<FluConsentQuestionEntity> FluConsentQuestionCollectionViaFluConsentTemplateQuestion
		{
			get
			{
				if(_fluConsentQuestionCollectionViaFluConsentTemplateQuestion==null)
				{
					_fluConsentQuestionCollectionViaFluConsentTemplateQuestion = new EntityCollection<FluConsentQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory)));
					_fluConsentQuestionCollectionViaFluConsentTemplateQuestion.IsReadOnly=true;
				}
				return _fluConsentQuestionCollectionViaFluConsentTemplateQuestion;
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "FluConsentTemplate_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentTemplate_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "FluConsentTemplate");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentTemplate");
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
			get { return (int)Falcon.Data.EntityType.FluConsentTemplateEntity; }
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
