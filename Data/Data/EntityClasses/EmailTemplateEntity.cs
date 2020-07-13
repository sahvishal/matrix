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
	/// Entity class which represents the entity 'EmailTemplate'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EmailTemplateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountEntity> _account__;
		private EntityCollection<AccountEntity> _account___;
		private EntityCollection<AccountEntity> _account;
		private EntityCollection<AccountEntity> _account_;
		private EntityCollection<EmailTemplateMacroEntity> _emailTemplateMacro;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount__;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount____;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount_;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount_____;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount_______;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount___;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount______;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___________________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__________________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount____________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_______________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount______________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_____________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount____________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount________________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_______________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount______________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_____________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_________________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount________________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount______;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_______;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_;
		private EntityCollection<FileEntity> _fileCollectionViaAccount;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__;
		private EntityCollection<FileEntity> _fileCollectionViaAccount____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount______________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount________________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_______________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_____________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount____________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_________________;
		private EntityCollection<FluConsentTemplateEntity> _fluConsentTemplateCollectionViaAccount;
		private EntityCollection<FluConsentTemplateEntity> _fluConsentTemplateCollectionViaAccount_;
		private EntityCollection<FluConsentTemplateEntity> _fluConsentTemplateCollectionViaAccount__;
		private EntityCollection<FluConsentTemplateEntity> _fluConsentTemplateCollectionViaAccount___;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaAccount__;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaAccount___;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaAccount_;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaAccount;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccount_;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccount;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccount___;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccount__;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaAccount___;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaAccount_;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaAccount;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaAccount__;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaAccount___;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaAccount;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaAccount_;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaAccount__;
		private EntityCollection<TemplateMacroEntity> _templateMacroCollectionViaEmailTemplateMacro;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;
		private NotificationTypeEntity _notificationType;
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
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name NotificationType</summary>
			public static readonly string NotificationType = "NotificationType";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Account__</summary>
			public static readonly string Account__ = "Account__";
			/// <summary>Member name Account___</summary>
			public static readonly string Account___ = "Account___";
			/// <summary>Member name Account</summary>
			public static readonly string Account = "Account";
			/// <summary>Member name Account_</summary>
			public static readonly string Account_ = "Account_";
			/// <summary>Member name EmailTemplateMacro</summary>
			public static readonly string EmailTemplateMacro = "EmailTemplateMacro";
			/// <summary>Member name CheckListTemplateCollectionViaAccount__</summary>
			public static readonly string CheckListTemplateCollectionViaAccount__ = "CheckListTemplateCollectionViaAccount__";
			/// <summary>Member name CheckListTemplateCollectionViaAccount____</summary>
			public static readonly string CheckListTemplateCollectionViaAccount____ = "CheckListTemplateCollectionViaAccount____";
			/// <summary>Member name CheckListTemplateCollectionViaAccount</summary>
			public static readonly string CheckListTemplateCollectionViaAccount = "CheckListTemplateCollectionViaAccount";
			/// <summary>Member name CheckListTemplateCollectionViaAccount_</summary>
			public static readonly string CheckListTemplateCollectionViaAccount_ = "CheckListTemplateCollectionViaAccount_";
			/// <summary>Member name CheckListTemplateCollectionViaAccount_____</summary>
			public static readonly string CheckListTemplateCollectionViaAccount_____ = "CheckListTemplateCollectionViaAccount_____";
			/// <summary>Member name CheckListTemplateCollectionViaAccount_______</summary>
			public static readonly string CheckListTemplateCollectionViaAccount_______ = "CheckListTemplateCollectionViaAccount_______";
			/// <summary>Member name CheckListTemplateCollectionViaAccount___</summary>
			public static readonly string CheckListTemplateCollectionViaAccount___ = "CheckListTemplateCollectionViaAccount___";
			/// <summary>Member name CheckListTemplateCollectionViaAccount______</summary>
			public static readonly string CheckListTemplateCollectionViaAccount______ = "CheckListTemplateCollectionViaAccount______";
			/// <summary>Member name FileCollectionViaAccount___________________________________</summary>
			public static readonly string FileCollectionViaAccount___________________________________ = "FileCollectionViaAccount___________________________________";
			/// <summary>Member name FileCollectionViaAccount__________________________________</summary>
			public static readonly string FileCollectionViaAccount__________________________________ = "FileCollectionViaAccount__________________________________";
			/// <summary>Member name FileCollectionViaAccount____________________</summary>
			public static readonly string FileCollectionViaAccount____________________ = "FileCollectionViaAccount____________________";
			/// <summary>Member name FileCollectionViaAccount___________________</summary>
			public static readonly string FileCollectionViaAccount___________________ = "FileCollectionViaAccount___________________";
			/// <summary>Member name FileCollectionViaAccount__________________</summary>
			public static readonly string FileCollectionViaAccount__________________ = "FileCollectionViaAccount__________________";
			/// <summary>Member name FileCollectionViaAccount___________________________</summary>
			public static readonly string FileCollectionViaAccount___________________________ = "FileCollectionViaAccount___________________________";
			/// <summary>Member name FileCollectionViaAccount__________________________</summary>
			public static readonly string FileCollectionViaAccount__________________________ = "FileCollectionViaAccount__________________________";
			/// <summary>Member name FileCollectionViaAccount_______________________________</summary>
			public static readonly string FileCollectionViaAccount_______________________________ = "FileCollectionViaAccount_______________________________";
			/// <summary>Member name FileCollectionViaAccount______________________________</summary>
			public static readonly string FileCollectionViaAccount______________________________ = "FileCollectionViaAccount______________________________";
			/// <summary>Member name FileCollectionViaAccount_____________________________</summary>
			public static readonly string FileCollectionViaAccount_____________________________ = "FileCollectionViaAccount_____________________________";
			/// <summary>Member name FileCollectionViaAccount____________________________</summary>
			public static readonly string FileCollectionViaAccount____________________________ = "FileCollectionViaAccount____________________________";
			/// <summary>Member name FileCollectionViaAccount________________________________</summary>
			public static readonly string FileCollectionViaAccount________________________________ = "FileCollectionViaAccount________________________________";
			/// <summary>Member name FileCollectionViaAccount_______________________</summary>
			public static readonly string FileCollectionViaAccount_______________________ = "FileCollectionViaAccount_______________________";
			/// <summary>Member name FileCollectionViaAccount______________________</summary>
			public static readonly string FileCollectionViaAccount______________________ = "FileCollectionViaAccount______________________";
			/// <summary>Member name FileCollectionViaAccount_____________________</summary>
			public static readonly string FileCollectionViaAccount_____________________ = "FileCollectionViaAccount_____________________";
			/// <summary>Member name FileCollectionViaAccount_________________________________</summary>
			public static readonly string FileCollectionViaAccount_________________________________ = "FileCollectionViaAccount_________________________________";
			/// <summary>Member name FileCollectionViaAccount_________________________</summary>
			public static readonly string FileCollectionViaAccount_________________________ = "FileCollectionViaAccount_________________________";
			/// <summary>Member name FileCollectionViaAccount________________________</summary>
			public static readonly string FileCollectionViaAccount________________________ = "FileCollectionViaAccount________________________";
			/// <summary>Member name FileCollectionViaAccount______</summary>
			public static readonly string FileCollectionViaAccount______ = "FileCollectionViaAccount______";
			/// <summary>Member name FileCollectionViaAccount_____</summary>
			public static readonly string FileCollectionViaAccount_____ = "FileCollectionViaAccount_____";
			/// <summary>Member name FileCollectionViaAccount_______</summary>
			public static readonly string FileCollectionViaAccount_______ = "FileCollectionViaAccount_______";
			/// <summary>Member name FileCollectionViaAccount_________</summary>
			public static readonly string FileCollectionViaAccount_________ = "FileCollectionViaAccount_________";
			/// <summary>Member name FileCollectionViaAccount________</summary>
			public static readonly string FileCollectionViaAccount________ = "FileCollectionViaAccount________";
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
			/// <summary>Member name FileCollectionViaAccount__________</summary>
			public static readonly string FileCollectionViaAccount__________ = "FileCollectionViaAccount__________";
			/// <summary>Member name FileCollectionViaAccount______________</summary>
			public static readonly string FileCollectionViaAccount______________ = "FileCollectionViaAccount______________";
			/// <summary>Member name FileCollectionViaAccount________________</summary>
			public static readonly string FileCollectionViaAccount________________ = "FileCollectionViaAccount________________";
			/// <summary>Member name FileCollectionViaAccount_______________</summary>
			public static readonly string FileCollectionViaAccount_______________ = "FileCollectionViaAccount_______________";
			/// <summary>Member name FileCollectionViaAccount_____________</summary>
			public static readonly string FileCollectionViaAccount_____________ = "FileCollectionViaAccount_____________";
			/// <summary>Member name FileCollectionViaAccount___________</summary>
			public static readonly string FileCollectionViaAccount___________ = "FileCollectionViaAccount___________";
			/// <summary>Member name FileCollectionViaAccount____________</summary>
			public static readonly string FileCollectionViaAccount____________ = "FileCollectionViaAccount____________";
			/// <summary>Member name FileCollectionViaAccount_________________</summary>
			public static readonly string FileCollectionViaAccount_________________ = "FileCollectionViaAccount_________________";
			/// <summary>Member name FluConsentTemplateCollectionViaAccount</summary>
			public static readonly string FluConsentTemplateCollectionViaAccount = "FluConsentTemplateCollectionViaAccount";
			/// <summary>Member name FluConsentTemplateCollectionViaAccount_</summary>
			public static readonly string FluConsentTemplateCollectionViaAccount_ = "FluConsentTemplateCollectionViaAccount_";
			/// <summary>Member name FluConsentTemplateCollectionViaAccount__</summary>
			public static readonly string FluConsentTemplateCollectionViaAccount__ = "FluConsentTemplateCollectionViaAccount__";
			/// <summary>Member name FluConsentTemplateCollectionViaAccount___</summary>
			public static readonly string FluConsentTemplateCollectionViaAccount___ = "FluConsentTemplateCollectionViaAccount___";
			/// <summary>Member name HafTemplateCollectionViaAccount__</summary>
			public static readonly string HafTemplateCollectionViaAccount__ = "HafTemplateCollectionViaAccount__";
			/// <summary>Member name HafTemplateCollectionViaAccount___</summary>
			public static readonly string HafTemplateCollectionViaAccount___ = "HafTemplateCollectionViaAccount___";
			/// <summary>Member name HafTemplateCollectionViaAccount_</summary>
			public static readonly string HafTemplateCollectionViaAccount_ = "HafTemplateCollectionViaAccount_";
			/// <summary>Member name HafTemplateCollectionViaAccount</summary>
			public static readonly string HafTemplateCollectionViaAccount = "HafTemplateCollectionViaAccount";
			/// <summary>Member name LookupCollectionViaAccount_</summary>
			public static readonly string LookupCollectionViaAccount_ = "LookupCollectionViaAccount_";
			/// <summary>Member name LookupCollectionViaAccount</summary>
			public static readonly string LookupCollectionViaAccount = "LookupCollectionViaAccount";
			/// <summary>Member name LookupCollectionViaAccount___</summary>
			public static readonly string LookupCollectionViaAccount___ = "LookupCollectionViaAccount___";
			/// <summary>Member name LookupCollectionViaAccount__</summary>
			public static readonly string LookupCollectionViaAccount__ = "LookupCollectionViaAccount__";
			/// <summary>Member name ProspectsCollectionViaAccount___</summary>
			public static readonly string ProspectsCollectionViaAccount___ = "ProspectsCollectionViaAccount___";
			/// <summary>Member name ProspectsCollectionViaAccount_</summary>
			public static readonly string ProspectsCollectionViaAccount_ = "ProspectsCollectionViaAccount_";
			/// <summary>Member name ProspectsCollectionViaAccount</summary>
			public static readonly string ProspectsCollectionViaAccount = "ProspectsCollectionViaAccount";
			/// <summary>Member name ProspectsCollectionViaAccount__</summary>
			public static readonly string ProspectsCollectionViaAccount__ = "ProspectsCollectionViaAccount__";
			/// <summary>Member name SurveyTemplateCollectionViaAccount___</summary>
			public static readonly string SurveyTemplateCollectionViaAccount___ = "SurveyTemplateCollectionViaAccount___";
			/// <summary>Member name SurveyTemplateCollectionViaAccount</summary>
			public static readonly string SurveyTemplateCollectionViaAccount = "SurveyTemplateCollectionViaAccount";
			/// <summary>Member name SurveyTemplateCollectionViaAccount_</summary>
			public static readonly string SurveyTemplateCollectionViaAccount_ = "SurveyTemplateCollectionViaAccount_";
			/// <summary>Member name SurveyTemplateCollectionViaAccount__</summary>
			public static readonly string SurveyTemplateCollectionViaAccount__ = "SurveyTemplateCollectionViaAccount__";
			/// <summary>Member name TemplateMacroCollectionViaEmailTemplateMacro</summary>
			public static readonly string TemplateMacroCollectionViaEmailTemplateMacro = "TemplateMacroCollectionViaEmailTemplateMacro";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EmailTemplateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EmailTemplateEntity():base("EmailTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EmailTemplateEntity(IEntityFields2 fields):base("EmailTemplateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EmailTemplateEntity</param>
		public EmailTemplateEntity(IValidator validator):base("EmailTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="emailTemplateId">PK value for EmailTemplate which data should be fetched into this EmailTemplate object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EmailTemplateEntity(System.Int32 emailTemplateId):base("EmailTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EmailTemplateId = emailTemplateId;
		}

		/// <summary> CTor</summary>
		/// <param name="emailTemplateId">PK value for EmailTemplate which data should be fetched into this EmailTemplate object</param>
		/// <param name="validator">The custom validator object for this EmailTemplateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EmailTemplateEntity(System.Int32 emailTemplateId, IValidator validator):base("EmailTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EmailTemplateId = emailTemplateId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EmailTemplateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_account__ = (EntityCollection<AccountEntity>)info.GetValue("_account__", typeof(EntityCollection<AccountEntity>));
				_account___ = (EntityCollection<AccountEntity>)info.GetValue("_account___", typeof(EntityCollection<AccountEntity>));
				_account = (EntityCollection<AccountEntity>)info.GetValue("_account", typeof(EntityCollection<AccountEntity>));
				_account_ = (EntityCollection<AccountEntity>)info.GetValue("_account_", typeof(EntityCollection<AccountEntity>));
				_emailTemplateMacro = (EntityCollection<EmailTemplateMacroEntity>)info.GetValue("_emailTemplateMacro", typeof(EntityCollection<EmailTemplateMacroEntity>));
				_checkListTemplateCollectionViaAccount__ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount__", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount____ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount____", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount_ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount_", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount_____ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount_____", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount_______ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount_______", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount___ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount___", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount______ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount______", typeof(EntityCollection<CheckListTemplateEntity>));
				_fileCollectionViaAccount___________________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___________________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount__________________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__________________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount____________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount____________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount___________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount__________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount___________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount__________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_______________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_______________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount______________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount______________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_____________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_____________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount____________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount____________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount________________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount________________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_______________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_______________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount______________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount______________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_____________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_____________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_________________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_________________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount________________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount________________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount______", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_______", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount__ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount___ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount__________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount______________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount______________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount________________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_______________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_______________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_____________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_____________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount___________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount____________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount____________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_________________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_________________", typeof(EntityCollection<FileEntity>));
				_fluConsentTemplateCollectionViaAccount = (EntityCollection<FluConsentTemplateEntity>)info.GetValue("_fluConsentTemplateCollectionViaAccount", typeof(EntityCollection<FluConsentTemplateEntity>));
				_fluConsentTemplateCollectionViaAccount_ = (EntityCollection<FluConsentTemplateEntity>)info.GetValue("_fluConsentTemplateCollectionViaAccount_", typeof(EntityCollection<FluConsentTemplateEntity>));
				_fluConsentTemplateCollectionViaAccount__ = (EntityCollection<FluConsentTemplateEntity>)info.GetValue("_fluConsentTemplateCollectionViaAccount__", typeof(EntityCollection<FluConsentTemplateEntity>));
				_fluConsentTemplateCollectionViaAccount___ = (EntityCollection<FluConsentTemplateEntity>)info.GetValue("_fluConsentTemplateCollectionViaAccount___", typeof(EntityCollection<FluConsentTemplateEntity>));
				_hafTemplateCollectionViaAccount__ = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaAccount__", typeof(EntityCollection<HafTemplateEntity>));
				_hafTemplateCollectionViaAccount___ = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaAccount___", typeof(EntityCollection<HafTemplateEntity>));
				_hafTemplateCollectionViaAccount_ = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaAccount_", typeof(EntityCollection<HafTemplateEntity>));
				_hafTemplateCollectionViaAccount = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaAccount", typeof(EntityCollection<HafTemplateEntity>));
				_lookupCollectionViaAccount_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccount_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaAccount = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccount", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaAccount___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccount___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaAccount__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccount__", typeof(EntityCollection<LookupEntity>));
				_prospectsCollectionViaAccount___ = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaAccount___", typeof(EntityCollection<ProspectsEntity>));
				_prospectsCollectionViaAccount_ = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaAccount_", typeof(EntityCollection<ProspectsEntity>));
				_prospectsCollectionViaAccount = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaAccount", typeof(EntityCollection<ProspectsEntity>));
				_prospectsCollectionViaAccount__ = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaAccount__", typeof(EntityCollection<ProspectsEntity>));
				_surveyTemplateCollectionViaAccount___ = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaAccount___", typeof(EntityCollection<SurveyTemplateEntity>));
				_surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaAccount", typeof(EntityCollection<SurveyTemplateEntity>));
				_surveyTemplateCollectionViaAccount_ = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaAccount_", typeof(EntityCollection<SurveyTemplateEntity>));
				_surveyTemplateCollectionViaAccount__ = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaAccount__", typeof(EntityCollection<SurveyTemplateEntity>));
				_templateMacroCollectionViaEmailTemplateMacro = (EntityCollection<TemplateMacroEntity>)info.GetValue("_templateMacroCollectionViaEmailTemplateMacro", typeof(EntityCollection<TemplateMacroEntity>));
				_lookup_ = (LookupEntity)info.GetValue("_lookup_", typeof(LookupEntity));
				if(_lookup_!=null)
				{
					_lookup_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_notificationType = (NotificationTypeEntity)info.GetValue("_notificationType", typeof(NotificationTypeEntity));
				if(_notificationType!=null)
				{
					_notificationType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EmailTemplateFieldIndex)fieldIndex)
			{
				case EmailTemplateFieldIndex.ModifiedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case EmailTemplateFieldIndex.TemplateType:
					DesetupSyncLookup(true, false);
					break;
				case EmailTemplateFieldIndex.NotificationTypeId:
					DesetupSyncNotificationType(true, false);
					break;
				case EmailTemplateFieldIndex.CoverLetterTypeLookupId:
					DesetupSyncLookup_(true, false);
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
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "NotificationType":
					this.NotificationType = (NotificationTypeEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Account__":
					this.Account__.Add((AccountEntity)entity);
					break;
				case "Account___":
					this.Account___.Add((AccountEntity)entity);
					break;
				case "Account":
					this.Account.Add((AccountEntity)entity);
					break;
				case "Account_":
					this.Account_.Add((AccountEntity)entity);
					break;
				case "EmailTemplateMacro":
					this.EmailTemplateMacro.Add((EmailTemplateMacroEntity)entity);
					break;
				case "CheckListTemplateCollectionViaAccount__":
					this.CheckListTemplateCollectionViaAccount__.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount__.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount__.IsReadOnly = true;
					break;
				case "CheckListTemplateCollectionViaAccount____":
					this.CheckListTemplateCollectionViaAccount____.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount____.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount____.IsReadOnly = true;
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
				case "CheckListTemplateCollectionViaAccount_____":
					this.CheckListTemplateCollectionViaAccount_____.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount_____.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount_____.IsReadOnly = true;
					break;
				case "CheckListTemplateCollectionViaAccount_______":
					this.CheckListTemplateCollectionViaAccount_______.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount_______.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount_______.IsReadOnly = true;
					break;
				case "CheckListTemplateCollectionViaAccount___":
					this.CheckListTemplateCollectionViaAccount___.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount___.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount___.IsReadOnly = true;
					break;
				case "CheckListTemplateCollectionViaAccount______":
					this.CheckListTemplateCollectionViaAccount______.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount______.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount______.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount___________________________________":
					this.FileCollectionViaAccount___________________________________.IsReadOnly = false;
					this.FileCollectionViaAccount___________________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount___________________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount__________________________________":
					this.FileCollectionViaAccount__________________________________.IsReadOnly = false;
					this.FileCollectionViaAccount__________________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount__________________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount____________________":
					this.FileCollectionViaAccount____________________.IsReadOnly = false;
					this.FileCollectionViaAccount____________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount____________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount___________________":
					this.FileCollectionViaAccount___________________.IsReadOnly = false;
					this.FileCollectionViaAccount___________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount___________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount__________________":
					this.FileCollectionViaAccount__________________.IsReadOnly = false;
					this.FileCollectionViaAccount__________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount__________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount___________________________":
					this.FileCollectionViaAccount___________________________.IsReadOnly = false;
					this.FileCollectionViaAccount___________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount___________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount__________________________":
					this.FileCollectionViaAccount__________________________.IsReadOnly = false;
					this.FileCollectionViaAccount__________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount__________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_______________________________":
					this.FileCollectionViaAccount_______________________________.IsReadOnly = false;
					this.FileCollectionViaAccount_______________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_______________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount______________________________":
					this.FileCollectionViaAccount______________________________.IsReadOnly = false;
					this.FileCollectionViaAccount______________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount______________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_____________________________":
					this.FileCollectionViaAccount_____________________________.IsReadOnly = false;
					this.FileCollectionViaAccount_____________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_____________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount____________________________":
					this.FileCollectionViaAccount____________________________.IsReadOnly = false;
					this.FileCollectionViaAccount____________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount____________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount________________________________":
					this.FileCollectionViaAccount________________________________.IsReadOnly = false;
					this.FileCollectionViaAccount________________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount________________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_______________________":
					this.FileCollectionViaAccount_______________________.IsReadOnly = false;
					this.FileCollectionViaAccount_______________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_______________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount______________________":
					this.FileCollectionViaAccount______________________.IsReadOnly = false;
					this.FileCollectionViaAccount______________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount______________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_____________________":
					this.FileCollectionViaAccount_____________________.IsReadOnly = false;
					this.FileCollectionViaAccount_____________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_____________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_________________________________":
					this.FileCollectionViaAccount_________________________________.IsReadOnly = false;
					this.FileCollectionViaAccount_________________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_________________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_________________________":
					this.FileCollectionViaAccount_________________________.IsReadOnly = false;
					this.FileCollectionViaAccount_________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount________________________":
					this.FileCollectionViaAccount________________________.IsReadOnly = false;
					this.FileCollectionViaAccount________________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount________________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount______":
					this.FileCollectionViaAccount______.IsReadOnly = false;
					this.FileCollectionViaAccount______.Add((FileEntity)entity);
					this.FileCollectionViaAccount______.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_____":
					this.FileCollectionViaAccount_____.IsReadOnly = false;
					this.FileCollectionViaAccount_____.Add((FileEntity)entity);
					this.FileCollectionViaAccount_____.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_______":
					this.FileCollectionViaAccount_______.IsReadOnly = false;
					this.FileCollectionViaAccount_______.Add((FileEntity)entity);
					this.FileCollectionViaAccount_______.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_________":
					this.FileCollectionViaAccount_________.IsReadOnly = false;
					this.FileCollectionViaAccount_________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount________":
					this.FileCollectionViaAccount________.IsReadOnly = false;
					this.FileCollectionViaAccount________.Add((FileEntity)entity);
					this.FileCollectionViaAccount________.IsReadOnly = true;
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
				case "FileCollectionViaAccount__________":
					this.FileCollectionViaAccount__________.IsReadOnly = false;
					this.FileCollectionViaAccount__________.Add((FileEntity)entity);
					this.FileCollectionViaAccount__________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount______________":
					this.FileCollectionViaAccount______________.IsReadOnly = false;
					this.FileCollectionViaAccount______________.Add((FileEntity)entity);
					this.FileCollectionViaAccount______________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount________________":
					this.FileCollectionViaAccount________________.IsReadOnly = false;
					this.FileCollectionViaAccount________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount________________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_______________":
					this.FileCollectionViaAccount_______________.IsReadOnly = false;
					this.FileCollectionViaAccount_______________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_______________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_____________":
					this.FileCollectionViaAccount_____________.IsReadOnly = false;
					this.FileCollectionViaAccount_____________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_____________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount___________":
					this.FileCollectionViaAccount___________.IsReadOnly = false;
					this.FileCollectionViaAccount___________.Add((FileEntity)entity);
					this.FileCollectionViaAccount___________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount____________":
					this.FileCollectionViaAccount____________.IsReadOnly = false;
					this.FileCollectionViaAccount____________.Add((FileEntity)entity);
					this.FileCollectionViaAccount____________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_________________":
					this.FileCollectionViaAccount_________________.IsReadOnly = false;
					this.FileCollectionViaAccount_________________.Add((FileEntity)entity);
					this.FileCollectionViaAccount_________________.IsReadOnly = true;
					break;
				case "FluConsentTemplateCollectionViaAccount":
					this.FluConsentTemplateCollectionViaAccount.IsReadOnly = false;
					this.FluConsentTemplateCollectionViaAccount.Add((FluConsentTemplateEntity)entity);
					this.FluConsentTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "FluConsentTemplateCollectionViaAccount_":
					this.FluConsentTemplateCollectionViaAccount_.IsReadOnly = false;
					this.FluConsentTemplateCollectionViaAccount_.Add((FluConsentTemplateEntity)entity);
					this.FluConsentTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "FluConsentTemplateCollectionViaAccount__":
					this.FluConsentTemplateCollectionViaAccount__.IsReadOnly = false;
					this.FluConsentTemplateCollectionViaAccount__.Add((FluConsentTemplateEntity)entity);
					this.FluConsentTemplateCollectionViaAccount__.IsReadOnly = true;
					break;
				case "FluConsentTemplateCollectionViaAccount___":
					this.FluConsentTemplateCollectionViaAccount___.IsReadOnly = false;
					this.FluConsentTemplateCollectionViaAccount___.Add((FluConsentTemplateEntity)entity);
					this.FluConsentTemplateCollectionViaAccount___.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaAccount__":
					this.HafTemplateCollectionViaAccount__.IsReadOnly = false;
					this.HafTemplateCollectionViaAccount__.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaAccount__.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaAccount___":
					this.HafTemplateCollectionViaAccount___.IsReadOnly = false;
					this.HafTemplateCollectionViaAccount___.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaAccount___.IsReadOnly = true;
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
				case "LookupCollectionViaAccount_":
					this.LookupCollectionViaAccount_.IsReadOnly = false;
					this.LookupCollectionViaAccount_.Add((LookupEntity)entity);
					this.LookupCollectionViaAccount_.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccount":
					this.LookupCollectionViaAccount.IsReadOnly = false;
					this.LookupCollectionViaAccount.Add((LookupEntity)entity);
					this.LookupCollectionViaAccount.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccount___":
					this.LookupCollectionViaAccount___.IsReadOnly = false;
					this.LookupCollectionViaAccount___.Add((LookupEntity)entity);
					this.LookupCollectionViaAccount___.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccount__":
					this.LookupCollectionViaAccount__.IsReadOnly = false;
					this.LookupCollectionViaAccount__.Add((LookupEntity)entity);
					this.LookupCollectionViaAccount__.IsReadOnly = true;
					break;
				case "ProspectsCollectionViaAccount___":
					this.ProspectsCollectionViaAccount___.IsReadOnly = false;
					this.ProspectsCollectionViaAccount___.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaAccount___.IsReadOnly = true;
					break;
				case "ProspectsCollectionViaAccount_":
					this.ProspectsCollectionViaAccount_.IsReadOnly = false;
					this.ProspectsCollectionViaAccount_.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaAccount_.IsReadOnly = true;
					break;
				case "ProspectsCollectionViaAccount":
					this.ProspectsCollectionViaAccount.IsReadOnly = false;
					this.ProspectsCollectionViaAccount.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaAccount.IsReadOnly = true;
					break;
				case "ProspectsCollectionViaAccount__":
					this.ProspectsCollectionViaAccount__.IsReadOnly = false;
					this.ProspectsCollectionViaAccount__.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaAccount__.IsReadOnly = true;
					break;
				case "SurveyTemplateCollectionViaAccount___":
					this.SurveyTemplateCollectionViaAccount___.IsReadOnly = false;
					this.SurveyTemplateCollectionViaAccount___.Add((SurveyTemplateEntity)entity);
					this.SurveyTemplateCollectionViaAccount___.IsReadOnly = true;
					break;
				case "SurveyTemplateCollectionViaAccount":
					this.SurveyTemplateCollectionViaAccount.IsReadOnly = false;
					this.SurveyTemplateCollectionViaAccount.Add((SurveyTemplateEntity)entity);
					this.SurveyTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "SurveyTemplateCollectionViaAccount_":
					this.SurveyTemplateCollectionViaAccount_.IsReadOnly = false;
					this.SurveyTemplateCollectionViaAccount_.Add((SurveyTemplateEntity)entity);
					this.SurveyTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "SurveyTemplateCollectionViaAccount__":
					this.SurveyTemplateCollectionViaAccount__.IsReadOnly = false;
					this.SurveyTemplateCollectionViaAccount__.Add((SurveyTemplateEntity)entity);
					this.SurveyTemplateCollectionViaAccount__.IsReadOnly = true;
					break;
				case "TemplateMacroCollectionViaEmailTemplateMacro":
					this.TemplateMacroCollectionViaEmailTemplateMacro.IsReadOnly = false;
					this.TemplateMacroCollectionViaEmailTemplateMacro.Add((TemplateMacroEntity)entity);
					this.TemplateMacroCollectionViaEmailTemplateMacro.IsReadOnly = true;
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
			return EmailTemplateEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Lookup_":
					toReturn.Add(EmailTemplateEntity.Relations.LookupEntityUsingCoverLetterTypeLookupId);
					break;
				case "Lookup":
					toReturn.Add(EmailTemplateEntity.Relations.LookupEntityUsingTemplateType);
					break;
				case "NotificationType":
					toReturn.Add(EmailTemplateEntity.Relations.NotificationTypeEntityUsingNotificationTypeId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(EmailTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "Account__":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId);
					break;
				case "Account___":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId);
					break;
				case "Account":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId);
					break;
				case "Account_":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId);
					break;
				case "EmailTemplateMacro":
					toReturn.Add(EmailTemplateEntity.Relations.EmailTemplateMacroEntityUsingEmailTemplateId);
					break;
				case "CheckListTemplateCollectionViaAccount__":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount____":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount_":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount_____":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount_______":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount___":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount______":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___________________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__________________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount____________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_______________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount______________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_____________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount____________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount________________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_______________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount______________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_____________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_________________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount________________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount______":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_____":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_______":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount____":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount______________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_______________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_____________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount____________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_________________":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FluConsentTemplateCollectionViaAccount":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FluConsentTemplateCollectionViaAccount_":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FluConsentTemplateCollectionViaAccount__":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FluConsentTemplateCollectionViaAccount___":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaAccount__":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaAccount___":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaAccount_":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaAccount":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccount_":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccount":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccount___":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccount__":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, "Account_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaAccount___":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, "Account_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaAccount_":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, "Account_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaAccount":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, "Account_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaAccount__":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, "Account_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaAccount___":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaAccount":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaAccount_":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaAccount__":
					toReturn.Add(EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId, "EmailTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "TemplateMacroCollectionViaEmailTemplateMacro":
					toReturn.Add(EmailTemplateEntity.Relations.EmailTemplateMacroEntityUsingEmailTemplateId, "EmailTemplateEntity__", "EmailTemplateMacro_", JoinHint.None);
					toReturn.Add(EmailTemplateMacroEntity.Relations.TemplateMacroEntityUsingTemplateMacroId, "EmailTemplateMacro_", string.Empty, JoinHint.None);
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
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "NotificationType":
					SetupSyncNotificationType(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Account__":
					this.Account__.Add((AccountEntity)relatedEntity);
					break;
				case "Account___":
					this.Account___.Add((AccountEntity)relatedEntity);
					break;
				case "Account":
					this.Account.Add((AccountEntity)relatedEntity);
					break;
				case "Account_":
					this.Account_.Add((AccountEntity)relatedEntity);
					break;
				case "EmailTemplateMacro":
					this.EmailTemplateMacro.Add((EmailTemplateMacroEntity)relatedEntity);
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
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "NotificationType":
					DesetupSyncNotificationType(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Account__":
					base.PerformRelatedEntityRemoval(this.Account__, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Account___":
					base.PerformRelatedEntityRemoval(this.Account___, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Account":
					base.PerformRelatedEntityRemoval(this.Account, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Account_":
					base.PerformRelatedEntityRemoval(this.Account_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EmailTemplateMacro":
					base.PerformRelatedEntityRemoval(this.EmailTemplateMacro, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_notificationType!=null)
			{
				toReturn.Add(_notificationType);
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
			toReturn.Add(this.Account__);
			toReturn.Add(this.Account___);
			toReturn.Add(this.Account);
			toReturn.Add(this.Account_);
			toReturn.Add(this.EmailTemplateMacro);

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
				info.AddValue("_account__", ((_account__!=null) && (_account__.Count>0) && !this.MarkedForDeletion)?_account__:null);
				info.AddValue("_account___", ((_account___!=null) && (_account___.Count>0) && !this.MarkedForDeletion)?_account___:null);
				info.AddValue("_account", ((_account!=null) && (_account.Count>0) && !this.MarkedForDeletion)?_account:null);
				info.AddValue("_account_", ((_account_!=null) && (_account_.Count>0) && !this.MarkedForDeletion)?_account_:null);
				info.AddValue("_emailTemplateMacro", ((_emailTemplateMacro!=null) && (_emailTemplateMacro.Count>0) && !this.MarkedForDeletion)?_emailTemplateMacro:null);
				info.AddValue("_checkListTemplateCollectionViaAccount__", ((_checkListTemplateCollectionViaAccount__!=null) && (_checkListTemplateCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount__:null);
				info.AddValue("_checkListTemplateCollectionViaAccount____", ((_checkListTemplateCollectionViaAccount____!=null) && (_checkListTemplateCollectionViaAccount____.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount____:null);
				info.AddValue("_checkListTemplateCollectionViaAccount", ((_checkListTemplateCollectionViaAccount!=null) && (_checkListTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount:null);
				info.AddValue("_checkListTemplateCollectionViaAccount_", ((_checkListTemplateCollectionViaAccount_!=null) && (_checkListTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount_:null);
				info.AddValue("_checkListTemplateCollectionViaAccount_____", ((_checkListTemplateCollectionViaAccount_____!=null) && (_checkListTemplateCollectionViaAccount_____.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount_____:null);
				info.AddValue("_checkListTemplateCollectionViaAccount_______", ((_checkListTemplateCollectionViaAccount_______!=null) && (_checkListTemplateCollectionViaAccount_______.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount_______:null);
				info.AddValue("_checkListTemplateCollectionViaAccount___", ((_checkListTemplateCollectionViaAccount___!=null) && (_checkListTemplateCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount___:null);
				info.AddValue("_checkListTemplateCollectionViaAccount______", ((_checkListTemplateCollectionViaAccount______!=null) && (_checkListTemplateCollectionViaAccount______.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount______:null);
				info.AddValue("_fileCollectionViaAccount___________________________________", ((_fileCollectionViaAccount___________________________________!=null) && (_fileCollectionViaAccount___________________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___________________________________:null);
				info.AddValue("_fileCollectionViaAccount__________________________________", ((_fileCollectionViaAccount__________________________________!=null) && (_fileCollectionViaAccount__________________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__________________________________:null);
				info.AddValue("_fileCollectionViaAccount____________________", ((_fileCollectionViaAccount____________________!=null) && (_fileCollectionViaAccount____________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount____________________:null);
				info.AddValue("_fileCollectionViaAccount___________________", ((_fileCollectionViaAccount___________________!=null) && (_fileCollectionViaAccount___________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___________________:null);
				info.AddValue("_fileCollectionViaAccount__________________", ((_fileCollectionViaAccount__________________!=null) && (_fileCollectionViaAccount__________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__________________:null);
				info.AddValue("_fileCollectionViaAccount___________________________", ((_fileCollectionViaAccount___________________________!=null) && (_fileCollectionViaAccount___________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___________________________:null);
				info.AddValue("_fileCollectionViaAccount__________________________", ((_fileCollectionViaAccount__________________________!=null) && (_fileCollectionViaAccount__________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__________________________:null);
				info.AddValue("_fileCollectionViaAccount_______________________________", ((_fileCollectionViaAccount_______________________________!=null) && (_fileCollectionViaAccount_______________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_______________________________:null);
				info.AddValue("_fileCollectionViaAccount______________________________", ((_fileCollectionViaAccount______________________________!=null) && (_fileCollectionViaAccount______________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount______________________________:null);
				info.AddValue("_fileCollectionViaAccount_____________________________", ((_fileCollectionViaAccount_____________________________!=null) && (_fileCollectionViaAccount_____________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_____________________________:null);
				info.AddValue("_fileCollectionViaAccount____________________________", ((_fileCollectionViaAccount____________________________!=null) && (_fileCollectionViaAccount____________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount____________________________:null);
				info.AddValue("_fileCollectionViaAccount________________________________", ((_fileCollectionViaAccount________________________________!=null) && (_fileCollectionViaAccount________________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount________________________________:null);
				info.AddValue("_fileCollectionViaAccount_______________________", ((_fileCollectionViaAccount_______________________!=null) && (_fileCollectionViaAccount_______________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_______________________:null);
				info.AddValue("_fileCollectionViaAccount______________________", ((_fileCollectionViaAccount______________________!=null) && (_fileCollectionViaAccount______________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount______________________:null);
				info.AddValue("_fileCollectionViaAccount_____________________", ((_fileCollectionViaAccount_____________________!=null) && (_fileCollectionViaAccount_____________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_____________________:null);
				info.AddValue("_fileCollectionViaAccount_________________________________", ((_fileCollectionViaAccount_________________________________!=null) && (_fileCollectionViaAccount_________________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_________________________________:null);
				info.AddValue("_fileCollectionViaAccount_________________________", ((_fileCollectionViaAccount_________________________!=null) && (_fileCollectionViaAccount_________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_________________________:null);
				info.AddValue("_fileCollectionViaAccount________________________", ((_fileCollectionViaAccount________________________!=null) && (_fileCollectionViaAccount________________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount________________________:null);
				info.AddValue("_fileCollectionViaAccount______", ((_fileCollectionViaAccount______!=null) && (_fileCollectionViaAccount______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount______:null);
				info.AddValue("_fileCollectionViaAccount_____", ((_fileCollectionViaAccount_____!=null) && (_fileCollectionViaAccount_____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_____:null);
				info.AddValue("_fileCollectionViaAccount_______", ((_fileCollectionViaAccount_______!=null) && (_fileCollectionViaAccount_______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_______:null);
				info.AddValue("_fileCollectionViaAccount_________", ((_fileCollectionViaAccount_________!=null) && (_fileCollectionViaAccount_________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_________:null);
				info.AddValue("_fileCollectionViaAccount________", ((_fileCollectionViaAccount________!=null) && (_fileCollectionViaAccount________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount________:null);
				info.AddValue("_fileCollectionViaAccount_", ((_fileCollectionViaAccount_!=null) && (_fileCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_:null);
				info.AddValue("_fileCollectionViaAccount", ((_fileCollectionViaAccount!=null) && (_fileCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount:null);
				info.AddValue("_fileCollectionViaAccount__", ((_fileCollectionViaAccount__!=null) && (_fileCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__:null);
				info.AddValue("_fileCollectionViaAccount____", ((_fileCollectionViaAccount____!=null) && (_fileCollectionViaAccount____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount____:null);
				info.AddValue("_fileCollectionViaAccount___", ((_fileCollectionViaAccount___!=null) && (_fileCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___:null);
				info.AddValue("_fileCollectionViaAccount__________", ((_fileCollectionViaAccount__________!=null) && (_fileCollectionViaAccount__________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__________:null);
				info.AddValue("_fileCollectionViaAccount______________", ((_fileCollectionViaAccount______________!=null) && (_fileCollectionViaAccount______________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount______________:null);
				info.AddValue("_fileCollectionViaAccount________________", ((_fileCollectionViaAccount________________!=null) && (_fileCollectionViaAccount________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount________________:null);
				info.AddValue("_fileCollectionViaAccount_______________", ((_fileCollectionViaAccount_______________!=null) && (_fileCollectionViaAccount_______________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_______________:null);
				info.AddValue("_fileCollectionViaAccount_____________", ((_fileCollectionViaAccount_____________!=null) && (_fileCollectionViaAccount_____________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_____________:null);
				info.AddValue("_fileCollectionViaAccount___________", ((_fileCollectionViaAccount___________!=null) && (_fileCollectionViaAccount___________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___________:null);
				info.AddValue("_fileCollectionViaAccount____________", ((_fileCollectionViaAccount____________!=null) && (_fileCollectionViaAccount____________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount____________:null);
				info.AddValue("_fileCollectionViaAccount_________________", ((_fileCollectionViaAccount_________________!=null) && (_fileCollectionViaAccount_________________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_________________:null);
				info.AddValue("_fluConsentTemplateCollectionViaAccount", ((_fluConsentTemplateCollectionViaAccount!=null) && (_fluConsentTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateCollectionViaAccount:null);
				info.AddValue("_fluConsentTemplateCollectionViaAccount_", ((_fluConsentTemplateCollectionViaAccount_!=null) && (_fluConsentTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateCollectionViaAccount_:null);
				info.AddValue("_fluConsentTemplateCollectionViaAccount__", ((_fluConsentTemplateCollectionViaAccount__!=null) && (_fluConsentTemplateCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateCollectionViaAccount__:null);
				info.AddValue("_fluConsentTemplateCollectionViaAccount___", ((_fluConsentTemplateCollectionViaAccount___!=null) && (_fluConsentTemplateCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateCollectionViaAccount___:null);
				info.AddValue("_hafTemplateCollectionViaAccount__", ((_hafTemplateCollectionViaAccount__!=null) && (_hafTemplateCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaAccount__:null);
				info.AddValue("_hafTemplateCollectionViaAccount___", ((_hafTemplateCollectionViaAccount___!=null) && (_hafTemplateCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaAccount___:null);
				info.AddValue("_hafTemplateCollectionViaAccount_", ((_hafTemplateCollectionViaAccount_!=null) && (_hafTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaAccount_:null);
				info.AddValue("_hafTemplateCollectionViaAccount", ((_hafTemplateCollectionViaAccount!=null) && (_hafTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaAccount:null);
				info.AddValue("_lookupCollectionViaAccount_", ((_lookupCollectionViaAccount_!=null) && (_lookupCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccount_:null);
				info.AddValue("_lookupCollectionViaAccount", ((_lookupCollectionViaAccount!=null) && (_lookupCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccount:null);
				info.AddValue("_lookupCollectionViaAccount___", ((_lookupCollectionViaAccount___!=null) && (_lookupCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccount___:null);
				info.AddValue("_lookupCollectionViaAccount__", ((_lookupCollectionViaAccount__!=null) && (_lookupCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccount__:null);
				info.AddValue("_prospectsCollectionViaAccount___", ((_prospectsCollectionViaAccount___!=null) && (_prospectsCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaAccount___:null);
				info.AddValue("_prospectsCollectionViaAccount_", ((_prospectsCollectionViaAccount_!=null) && (_prospectsCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaAccount_:null);
				info.AddValue("_prospectsCollectionViaAccount", ((_prospectsCollectionViaAccount!=null) && (_prospectsCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaAccount:null);
				info.AddValue("_prospectsCollectionViaAccount__", ((_prospectsCollectionViaAccount__!=null) && (_prospectsCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaAccount__:null);
				info.AddValue("_surveyTemplateCollectionViaAccount___", ((_surveyTemplateCollectionViaAccount___!=null) && (_surveyTemplateCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaAccount___:null);
				info.AddValue("_surveyTemplateCollectionViaAccount", ((_surveyTemplateCollectionViaAccount!=null) && (_surveyTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaAccount:null);
				info.AddValue("_surveyTemplateCollectionViaAccount_", ((_surveyTemplateCollectionViaAccount_!=null) && (_surveyTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaAccount_:null);
				info.AddValue("_surveyTemplateCollectionViaAccount__", ((_surveyTemplateCollectionViaAccount__!=null) && (_surveyTemplateCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaAccount__:null);
				info.AddValue("_templateMacroCollectionViaEmailTemplateMacro", ((_templateMacroCollectionViaEmailTemplateMacro!=null) && (_templateMacroCollectionViaEmailTemplateMacro.Count>0) && !this.MarkedForDeletion)?_templateMacroCollectionViaEmailTemplateMacro:null);
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_notificationType", (!this.MarkedForDeletion?_notificationType:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// EmailTitle .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCEmailTitle()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)EmailTemplateFieldIndex.EmailTitle], null, ComparisonOperator.Equal)); 
			return filter;
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(EmailTemplateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EmailTemplateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EmailTemplateRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.PcpCoverLetterTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.ReminderSmsTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.ConfirmationSmsTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.MemberCoverLetterTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplateMacro' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateMacro()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateMacroFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___________________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___________________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__________________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__________________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount____________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount____________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_______________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_______________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount______________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount______________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_____________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_____________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount____________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount____________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount________________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount________________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_______________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_______________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount______________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount______________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_____________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_____________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_________________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_________________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount________________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount________________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount______________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_______________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_____________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount____________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_________________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentTemplateCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentTemplateCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TemplateMacro' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTemplateMacroCollectionViaEmailTemplateMacro()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TemplateMacroCollectionViaEmailTemplateMacro"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.EmailTemplateId, "EmailTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.CoverLetterTypeLookupId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.TemplateType));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'NotificationType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EmailTemplateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._account__);
			collectionsQueue.Enqueue(this._account___);
			collectionsQueue.Enqueue(this._account);
			collectionsQueue.Enqueue(this._account_);
			collectionsQueue.Enqueue(this._emailTemplateMacro);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount__);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount____);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount_____);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount_______);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount___);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount______);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___________________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__________________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount____________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_______________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount______________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_____________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount____________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount________________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_______________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount______________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_____________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_________________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount________________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount______);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_______);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount______________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount________________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_______________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_____________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount____________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_________________);
			collectionsQueue.Enqueue(this._fluConsentTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._fluConsentTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._fluConsentTemplateCollectionViaAccount__);
			collectionsQueue.Enqueue(this._fluConsentTemplateCollectionViaAccount___);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaAccount__);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaAccount___);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccount_);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccount);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccount___);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccount__);
			collectionsQueue.Enqueue(this._prospectsCollectionViaAccount___);
			collectionsQueue.Enqueue(this._prospectsCollectionViaAccount_);
			collectionsQueue.Enqueue(this._prospectsCollectionViaAccount);
			collectionsQueue.Enqueue(this._prospectsCollectionViaAccount__);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaAccount___);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaAccount__);
			collectionsQueue.Enqueue(this._templateMacroCollectionViaEmailTemplateMacro);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._account__ = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._account___ = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._account = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._account_ = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._emailTemplateMacro = (EntityCollection<EmailTemplateMacroEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount__ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount____ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount_ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount_____ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount_______ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount___ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount______ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___________________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__________________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount____________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_______________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount______________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_____________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount____________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount________________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_______________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount______________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_____________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_________________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount________________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount______________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_______________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_____________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount____________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_________________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateCollectionViaAccount = (EntityCollection<FluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateCollectionViaAccount_ = (EntityCollection<FluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateCollectionViaAccount__ = (EntityCollection<FluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateCollectionViaAccount___ = (EntityCollection<FluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaAccount__ = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaAccount___ = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaAccount_ = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaAccount = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccount_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccount = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccount___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccount__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaAccount___ = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaAccount_ = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaAccount = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaAccount__ = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaAccount___ = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaAccount_ = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaAccount__ = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
			this._templateMacroCollectionViaEmailTemplateMacro = (EntityCollection<TemplateMacroEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._account__ != null)
			{
				return true;
			}
			if (this._account___ != null)
			{
				return true;
			}
			if (this._account != null)
			{
				return true;
			}
			if (this._account_ != null)
			{
				return true;
			}
			if (this._emailTemplateMacro != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaAccount____ != null)
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
			if (this._checkListTemplateCollectionViaAccount_____ != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaAccount_______ != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaAccount______ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount___________________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount__________________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount____________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount___________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount__________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount___________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount__________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_______________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount______________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_____________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount____________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount________________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_______________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount______________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_____________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_________________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount________________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount______ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_____ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_______ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount________ != null)
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
			if (this._fileCollectionViaAccount__________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount______________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount________________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_______________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_____________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount___________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount____________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_________________ != null)
			{
				return true;
			}
			if (this._fluConsentTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._fluConsentTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._fluConsentTemplateCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._fluConsentTemplateCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaAccount___ != null)
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
			if (this._lookupCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccount != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._prospectsCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._prospectsCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._prospectsCollectionViaAccount != null)
			{
				return true;
			}
			if (this._prospectsCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._surveyTemplateCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._surveyTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._surveyTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._surveyTemplateCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._templateMacroCollectionViaEmailTemplateMacro != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateMacroEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateMacroEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TemplateMacroEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TemplateMacroEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("NotificationType", _notificationType);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Account__", _account__);
			toReturn.Add("Account___", _account___);
			toReturn.Add("Account", _account);
			toReturn.Add("Account_", _account_);
			toReturn.Add("EmailTemplateMacro", _emailTemplateMacro);
			toReturn.Add("CheckListTemplateCollectionViaAccount__", _checkListTemplateCollectionViaAccount__);
			toReturn.Add("CheckListTemplateCollectionViaAccount____", _checkListTemplateCollectionViaAccount____);
			toReturn.Add("CheckListTemplateCollectionViaAccount", _checkListTemplateCollectionViaAccount);
			toReturn.Add("CheckListTemplateCollectionViaAccount_", _checkListTemplateCollectionViaAccount_);
			toReturn.Add("CheckListTemplateCollectionViaAccount_____", _checkListTemplateCollectionViaAccount_____);
			toReturn.Add("CheckListTemplateCollectionViaAccount_______", _checkListTemplateCollectionViaAccount_______);
			toReturn.Add("CheckListTemplateCollectionViaAccount___", _checkListTemplateCollectionViaAccount___);
			toReturn.Add("CheckListTemplateCollectionViaAccount______", _checkListTemplateCollectionViaAccount______);
			toReturn.Add("FileCollectionViaAccount___________________________________", _fileCollectionViaAccount___________________________________);
			toReturn.Add("FileCollectionViaAccount__________________________________", _fileCollectionViaAccount__________________________________);
			toReturn.Add("FileCollectionViaAccount____________________", _fileCollectionViaAccount____________________);
			toReturn.Add("FileCollectionViaAccount___________________", _fileCollectionViaAccount___________________);
			toReturn.Add("FileCollectionViaAccount__________________", _fileCollectionViaAccount__________________);
			toReturn.Add("FileCollectionViaAccount___________________________", _fileCollectionViaAccount___________________________);
			toReturn.Add("FileCollectionViaAccount__________________________", _fileCollectionViaAccount__________________________);
			toReturn.Add("FileCollectionViaAccount_______________________________", _fileCollectionViaAccount_______________________________);
			toReturn.Add("FileCollectionViaAccount______________________________", _fileCollectionViaAccount______________________________);
			toReturn.Add("FileCollectionViaAccount_____________________________", _fileCollectionViaAccount_____________________________);
			toReturn.Add("FileCollectionViaAccount____________________________", _fileCollectionViaAccount____________________________);
			toReturn.Add("FileCollectionViaAccount________________________________", _fileCollectionViaAccount________________________________);
			toReturn.Add("FileCollectionViaAccount_______________________", _fileCollectionViaAccount_______________________);
			toReturn.Add("FileCollectionViaAccount______________________", _fileCollectionViaAccount______________________);
			toReturn.Add("FileCollectionViaAccount_____________________", _fileCollectionViaAccount_____________________);
			toReturn.Add("FileCollectionViaAccount_________________________________", _fileCollectionViaAccount_________________________________);
			toReturn.Add("FileCollectionViaAccount_________________________", _fileCollectionViaAccount_________________________);
			toReturn.Add("FileCollectionViaAccount________________________", _fileCollectionViaAccount________________________);
			toReturn.Add("FileCollectionViaAccount______", _fileCollectionViaAccount______);
			toReturn.Add("FileCollectionViaAccount_____", _fileCollectionViaAccount_____);
			toReturn.Add("FileCollectionViaAccount_______", _fileCollectionViaAccount_______);
			toReturn.Add("FileCollectionViaAccount_________", _fileCollectionViaAccount_________);
			toReturn.Add("FileCollectionViaAccount________", _fileCollectionViaAccount________);
			toReturn.Add("FileCollectionViaAccount_", _fileCollectionViaAccount_);
			toReturn.Add("FileCollectionViaAccount", _fileCollectionViaAccount);
			toReturn.Add("FileCollectionViaAccount__", _fileCollectionViaAccount__);
			toReturn.Add("FileCollectionViaAccount____", _fileCollectionViaAccount____);
			toReturn.Add("FileCollectionViaAccount___", _fileCollectionViaAccount___);
			toReturn.Add("FileCollectionViaAccount__________", _fileCollectionViaAccount__________);
			toReturn.Add("FileCollectionViaAccount______________", _fileCollectionViaAccount______________);
			toReturn.Add("FileCollectionViaAccount________________", _fileCollectionViaAccount________________);
			toReturn.Add("FileCollectionViaAccount_______________", _fileCollectionViaAccount_______________);
			toReturn.Add("FileCollectionViaAccount_____________", _fileCollectionViaAccount_____________);
			toReturn.Add("FileCollectionViaAccount___________", _fileCollectionViaAccount___________);
			toReturn.Add("FileCollectionViaAccount____________", _fileCollectionViaAccount____________);
			toReturn.Add("FileCollectionViaAccount_________________", _fileCollectionViaAccount_________________);
			toReturn.Add("FluConsentTemplateCollectionViaAccount", _fluConsentTemplateCollectionViaAccount);
			toReturn.Add("FluConsentTemplateCollectionViaAccount_", _fluConsentTemplateCollectionViaAccount_);
			toReturn.Add("FluConsentTemplateCollectionViaAccount__", _fluConsentTemplateCollectionViaAccount__);
			toReturn.Add("FluConsentTemplateCollectionViaAccount___", _fluConsentTemplateCollectionViaAccount___);
			toReturn.Add("HafTemplateCollectionViaAccount__", _hafTemplateCollectionViaAccount__);
			toReturn.Add("HafTemplateCollectionViaAccount___", _hafTemplateCollectionViaAccount___);
			toReturn.Add("HafTemplateCollectionViaAccount_", _hafTemplateCollectionViaAccount_);
			toReturn.Add("HafTemplateCollectionViaAccount", _hafTemplateCollectionViaAccount);
			toReturn.Add("LookupCollectionViaAccount_", _lookupCollectionViaAccount_);
			toReturn.Add("LookupCollectionViaAccount", _lookupCollectionViaAccount);
			toReturn.Add("LookupCollectionViaAccount___", _lookupCollectionViaAccount___);
			toReturn.Add("LookupCollectionViaAccount__", _lookupCollectionViaAccount__);
			toReturn.Add("ProspectsCollectionViaAccount___", _prospectsCollectionViaAccount___);
			toReturn.Add("ProspectsCollectionViaAccount_", _prospectsCollectionViaAccount_);
			toReturn.Add("ProspectsCollectionViaAccount", _prospectsCollectionViaAccount);
			toReturn.Add("ProspectsCollectionViaAccount__", _prospectsCollectionViaAccount__);
			toReturn.Add("SurveyTemplateCollectionViaAccount___", _surveyTemplateCollectionViaAccount___);
			toReturn.Add("SurveyTemplateCollectionViaAccount", _surveyTemplateCollectionViaAccount);
			toReturn.Add("SurveyTemplateCollectionViaAccount_", _surveyTemplateCollectionViaAccount_);
			toReturn.Add("SurveyTemplateCollectionViaAccount__", _surveyTemplateCollectionViaAccount__);
			toReturn.Add("TemplateMacroCollectionViaEmailTemplateMacro", _templateMacroCollectionViaEmailTemplateMacro);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_account__!=null)
			{
				_account__.ActiveContext = base.ActiveContext;
			}
			if(_account___!=null)
			{
				_account___.ActiveContext = base.ActiveContext;
			}
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_account_!=null)
			{
				_account_.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateMacro!=null)
			{
				_emailTemplateMacro.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount__!=null)
			{
				_checkListTemplateCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount____!=null)
			{
				_checkListTemplateCollectionViaAccount____.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount!=null)
			{
				_checkListTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount_!=null)
			{
				_checkListTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount_____!=null)
			{
				_checkListTemplateCollectionViaAccount_____.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount_______!=null)
			{
				_checkListTemplateCollectionViaAccount_______.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount___!=null)
			{
				_checkListTemplateCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount______!=null)
			{
				_checkListTemplateCollectionViaAccount______.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount___________________________________!=null)
			{
				_fileCollectionViaAccount___________________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount__________________________________!=null)
			{
				_fileCollectionViaAccount__________________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount____________________!=null)
			{
				_fileCollectionViaAccount____________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount___________________!=null)
			{
				_fileCollectionViaAccount___________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount__________________!=null)
			{
				_fileCollectionViaAccount__________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount___________________________!=null)
			{
				_fileCollectionViaAccount___________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount__________________________!=null)
			{
				_fileCollectionViaAccount__________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_______________________________!=null)
			{
				_fileCollectionViaAccount_______________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount______________________________!=null)
			{
				_fileCollectionViaAccount______________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_____________________________!=null)
			{
				_fileCollectionViaAccount_____________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount____________________________!=null)
			{
				_fileCollectionViaAccount____________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount________________________________!=null)
			{
				_fileCollectionViaAccount________________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_______________________!=null)
			{
				_fileCollectionViaAccount_______________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount______________________!=null)
			{
				_fileCollectionViaAccount______________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_____________________!=null)
			{
				_fileCollectionViaAccount_____________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_________________________________!=null)
			{
				_fileCollectionViaAccount_________________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_________________________!=null)
			{
				_fileCollectionViaAccount_________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount________________________!=null)
			{
				_fileCollectionViaAccount________________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount______!=null)
			{
				_fileCollectionViaAccount______.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_____!=null)
			{
				_fileCollectionViaAccount_____.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_______!=null)
			{
				_fileCollectionViaAccount_______.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_________!=null)
			{
				_fileCollectionViaAccount_________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount________!=null)
			{
				_fileCollectionViaAccount________.ActiveContext = base.ActiveContext;
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
			if(_fileCollectionViaAccount__________!=null)
			{
				_fileCollectionViaAccount__________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount______________!=null)
			{
				_fileCollectionViaAccount______________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount________________!=null)
			{
				_fileCollectionViaAccount________________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_______________!=null)
			{
				_fileCollectionViaAccount_______________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_____________!=null)
			{
				_fileCollectionViaAccount_____________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount___________!=null)
			{
				_fileCollectionViaAccount___________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount____________!=null)
			{
				_fileCollectionViaAccount____________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_________________!=null)
			{
				_fileCollectionViaAccount_________________.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateCollectionViaAccount!=null)
			{
				_fluConsentTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateCollectionViaAccount_!=null)
			{
				_fluConsentTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateCollectionViaAccount__!=null)
			{
				_fluConsentTemplateCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateCollectionViaAccount___!=null)
			{
				_fluConsentTemplateCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaAccount__!=null)
			{
				_hafTemplateCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaAccount___!=null)
			{
				_hafTemplateCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaAccount_!=null)
			{
				_hafTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaAccount!=null)
			{
				_hafTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccount_!=null)
			{
				_lookupCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccount!=null)
			{
				_lookupCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccount___!=null)
			{
				_lookupCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccount__!=null)
			{
				_lookupCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaAccount___!=null)
			{
				_prospectsCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaAccount_!=null)
			{
				_prospectsCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaAccount!=null)
			{
				_prospectsCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaAccount__!=null)
			{
				_prospectsCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaAccount___!=null)
			{
				_surveyTemplateCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaAccount!=null)
			{
				_surveyTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaAccount_!=null)
			{
				_surveyTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaAccount__!=null)
			{
				_surveyTemplateCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_templateMacroCollectionViaEmailTemplateMacro!=null)
			{
				_templateMacroCollectionViaEmailTemplateMacro.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_notificationType!=null)
			{
				_notificationType.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_account__ = null;
			_account___ = null;
			_account = null;
			_account_ = null;
			_emailTemplateMacro = null;
			_checkListTemplateCollectionViaAccount__ = null;
			_checkListTemplateCollectionViaAccount____ = null;
			_checkListTemplateCollectionViaAccount = null;
			_checkListTemplateCollectionViaAccount_ = null;
			_checkListTemplateCollectionViaAccount_____ = null;
			_checkListTemplateCollectionViaAccount_______ = null;
			_checkListTemplateCollectionViaAccount___ = null;
			_checkListTemplateCollectionViaAccount______ = null;
			_fileCollectionViaAccount___________________________________ = null;
			_fileCollectionViaAccount__________________________________ = null;
			_fileCollectionViaAccount____________________ = null;
			_fileCollectionViaAccount___________________ = null;
			_fileCollectionViaAccount__________________ = null;
			_fileCollectionViaAccount___________________________ = null;
			_fileCollectionViaAccount__________________________ = null;
			_fileCollectionViaAccount_______________________________ = null;
			_fileCollectionViaAccount______________________________ = null;
			_fileCollectionViaAccount_____________________________ = null;
			_fileCollectionViaAccount____________________________ = null;
			_fileCollectionViaAccount________________________________ = null;
			_fileCollectionViaAccount_______________________ = null;
			_fileCollectionViaAccount______________________ = null;
			_fileCollectionViaAccount_____________________ = null;
			_fileCollectionViaAccount_________________________________ = null;
			_fileCollectionViaAccount_________________________ = null;
			_fileCollectionViaAccount________________________ = null;
			_fileCollectionViaAccount______ = null;
			_fileCollectionViaAccount_____ = null;
			_fileCollectionViaAccount_______ = null;
			_fileCollectionViaAccount_________ = null;
			_fileCollectionViaAccount________ = null;
			_fileCollectionViaAccount_ = null;
			_fileCollectionViaAccount = null;
			_fileCollectionViaAccount__ = null;
			_fileCollectionViaAccount____ = null;
			_fileCollectionViaAccount___ = null;
			_fileCollectionViaAccount__________ = null;
			_fileCollectionViaAccount______________ = null;
			_fileCollectionViaAccount________________ = null;
			_fileCollectionViaAccount_______________ = null;
			_fileCollectionViaAccount_____________ = null;
			_fileCollectionViaAccount___________ = null;
			_fileCollectionViaAccount____________ = null;
			_fileCollectionViaAccount_________________ = null;
			_fluConsentTemplateCollectionViaAccount = null;
			_fluConsentTemplateCollectionViaAccount_ = null;
			_fluConsentTemplateCollectionViaAccount__ = null;
			_fluConsentTemplateCollectionViaAccount___ = null;
			_hafTemplateCollectionViaAccount__ = null;
			_hafTemplateCollectionViaAccount___ = null;
			_hafTemplateCollectionViaAccount_ = null;
			_hafTemplateCollectionViaAccount = null;
			_lookupCollectionViaAccount_ = null;
			_lookupCollectionViaAccount = null;
			_lookupCollectionViaAccount___ = null;
			_lookupCollectionViaAccount__ = null;
			_prospectsCollectionViaAccount___ = null;
			_prospectsCollectionViaAccount_ = null;
			_prospectsCollectionViaAccount = null;
			_prospectsCollectionViaAccount__ = null;
			_surveyTemplateCollectionViaAccount___ = null;
			_surveyTemplateCollectionViaAccount = null;
			_surveyTemplateCollectionViaAccount_ = null;
			_surveyTemplateCollectionViaAccount__ = null;
			_templateMacroCollectionViaEmailTemplateMacro = null;
			_lookup_ = null;
			_lookup = null;
			_notificationType = null;
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

			_fieldsCustomProperties.Add("EmailTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmailTitle", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmailSubject", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmailBody", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TemplateType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotificationTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsEditable", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CoverLetterTypeLookupId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", EmailTemplateEntity.Relations.LookupEntityUsingCoverLetterTypeLookupId, true, signalRelatedEntity, "EmailTemplate_", resetFKFields, new int[] { (int)EmailTemplateFieldIndex.CoverLetterTypeLookupId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", EmailTemplateEntity.Relations.LookupEntityUsingCoverLetterTypeLookupId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EmailTemplateEntity.Relations.LookupEntityUsingTemplateType, true, signalRelatedEntity, "EmailTemplate", resetFKFields, new int[] { (int)EmailTemplateFieldIndex.TemplateType } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EmailTemplateEntity.Relations.LookupEntityUsingTemplateType, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _notificationType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNotificationType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _notificationType, new PropertyChangedEventHandler( OnNotificationTypePropertyChanged ), "NotificationType", EmailTemplateEntity.Relations.NotificationTypeEntityUsingNotificationTypeId, true, signalRelatedEntity, "EmailTemplate", resetFKFields, new int[] { (int)EmailTemplateFieldIndex.NotificationTypeId } );		
			_notificationType = null;
		}

		/// <summary> setups the sync logic for member _notificationType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNotificationType(IEntity2 relatedEntity)
		{
			if(_notificationType!=relatedEntity)
			{
				DesetupSyncNotificationType(true, true);
				_notificationType = (NotificationTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _notificationType, new PropertyChangedEventHandler( OnNotificationTypePropertyChanged ), "NotificationType", EmailTemplateEntity.Relations.NotificationTypeEntityUsingNotificationTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotificationTypePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EmailTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "EmailTemplate", resetFKFields, new int[] { (int)EmailTemplateFieldIndex.ModifiedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EmailTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this EmailTemplateEntity</param>
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
		public  static EmailTemplateRelations Relations
		{
			get	{ return new EmailTemplateRelations(); }
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
		public static IPrefetchPathElement2 PrefetchPathAccount__
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account__")[0], (int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccount___
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account___")[0], (int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccount_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account_")[0], (int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplateMacro' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateMacro
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EmailTemplateMacroEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateMacroEntityFactory))),
					(IEntityRelation)GetRelationsForField("EmailTemplateMacro")[0], (int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateMacroEntity, 0, null, null, null, null, "EmailTemplateMacro", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount__"), null, "CheckListTemplateCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount____
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount____"), null, "CheckListTemplateCollectionViaAccount____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount"), null, "CheckListTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount_"), null, "CheckListTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount_____
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount_____"), null, "CheckListTemplateCollectionViaAccount_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount_______
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount_______"), null, "CheckListTemplateCollectionViaAccount_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount___"), null, "CheckListTemplateCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount______
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount______"), null, "CheckListTemplateCollectionViaAccount______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___________________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___________________________________"), null, "FileCollectionViaAccount___________________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__________________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__________________________________"), null, "FileCollectionViaAccount__________________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount____________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount____________________"), null, "FileCollectionViaAccount____________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___________________"), null, "FileCollectionViaAccount___________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__________________"), null, "FileCollectionViaAccount__________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___________________________"), null, "FileCollectionViaAccount___________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__________________________"), null, "FileCollectionViaAccount__________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_______________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_______________________________"), null, "FileCollectionViaAccount_______________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount______________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount______________________________"), null, "FileCollectionViaAccount______________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_____________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_____________________________"), null, "FileCollectionViaAccount_____________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount____________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount____________________________"), null, "FileCollectionViaAccount____________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount________________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount________________________________"), null, "FileCollectionViaAccount________________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_______________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_______________________"), null, "FileCollectionViaAccount_______________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount______________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount______________________"), null, "FileCollectionViaAccount______________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_____________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_____________________"), null, "FileCollectionViaAccount_____________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_________________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_________________________________"), null, "FileCollectionViaAccount_________________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_________________________"), null, "FileCollectionViaAccount_________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount________________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount________________________"), null, "FileCollectionViaAccount________________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount______
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount______"), null, "FileCollectionViaAccount______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_____
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_____"), null, "FileCollectionViaAccount_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_______
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_______"), null, "FileCollectionViaAccount_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_________"), null, "FileCollectionViaAccount_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount________"), null, "FileCollectionViaAccount________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_"), null, "FileCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount"), null, "FileCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__"), null, "FileCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount____
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount____"), null, "FileCollectionViaAccount____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___"), null, "FileCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__________"), null, "FileCollectionViaAccount__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount______________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount______________"), null, "FileCollectionViaAccount______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount________________"), null, "FileCollectionViaAccount________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_______________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_______________"), null, "FileCollectionViaAccount_______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_____________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_____________"), null, "FileCollectionViaAccount_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___________"), null, "FileCollectionViaAccount___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount____________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount____________"), null, "FileCollectionViaAccount____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_________________
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_________________"), null, "FileCollectionViaAccount_________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, GetRelationsForField("FluConsentTemplateCollectionViaAccount"), null, "FluConsentTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, GetRelationsForField("FluConsentTemplateCollectionViaAccount_"), null, "FluConsentTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, GetRelationsForField("FluConsentTemplateCollectionViaAccount__"), null, "FluConsentTemplateCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, GetRelationsForField("FluConsentTemplateCollectionViaAccount___"), null, "FluConsentTemplateCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaAccount__"), null, "HafTemplateCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaAccount___"), null, "HafTemplateCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaAccount_"), null, "HafTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaAccount"), null, "HafTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccount_"), null, "LookupCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccount"), null, "LookupCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccount___"), null, "LookupCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccount__"), null, "LookupCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaAccount___"), null, "ProspectsCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaAccount_"), null, "ProspectsCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaAccount"), null, "ProspectsCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaAccount__"), null, "ProspectsCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingReminderSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaAccount___"), null, "SurveyTemplateCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingConfirmationSmsTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaAccount"), null, "SurveyTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingMemberCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaAccount_"), null, "SurveyTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.AccountEntityUsingPcpCoverLetterTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaAccount__"), null, "SurveyTemplateCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TemplateMacro' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTemplateMacroCollectionViaEmailTemplateMacro
		{
			get
			{
				IEntityRelation intermediateRelation = EmailTemplateEntity.Relations.EmailTemplateMacroEntityUsingEmailTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EmailTemplateMacro_");
				return new PrefetchPathElement2(new EntityCollection<TemplateMacroEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TemplateMacroEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.TemplateMacroEntity, 0, null, null, GetRelationsForField("TemplateMacroCollectionViaEmailTemplateMacro"), null, "TemplateMacroCollectionViaEmailTemplateMacro", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("NotificationType")[0], (int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.NotificationTypeEntity, 0, null, null, null, null, "NotificationType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.EmailTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EmailTemplateEntity.CustomProperties;}
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
			get { return EmailTemplateEntity.FieldsCustomProperties;}
		}

		/// <summary> The EmailTemplateId property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."EmailTemplateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 EmailTemplateId
		{
			get { return (System.Int32)GetValue((int)EmailTemplateFieldIndex.EmailTemplateId, true); }
			set	{ SetValue((int)EmailTemplateFieldIndex.EmailTemplateId, value); }
		}

		/// <summary> The EmailTitle property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."EmailTitle"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 256<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EmailTitle
		{
			get { return (System.String)GetValue((int)EmailTemplateFieldIndex.EmailTitle, true); }
			set	{ SetValue((int)EmailTemplateFieldIndex.EmailTitle, value); }
		}

		/// <summary> The EmailSubject property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."EmailSubject"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EmailSubject
		{
			get { return (System.String)GetValue((int)EmailTemplateFieldIndex.EmailSubject, true); }
			set	{ SetValue((int)EmailTemplateFieldIndex.EmailSubject, value); }
		}

		/// <summary> The EmailBody property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."EmailBody"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EmailBody
		{
			get { return (System.String)GetValue((int)EmailTemplateFieldIndex.EmailBody, true); }
			set	{ SetValue((int)EmailTemplateFieldIndex.EmailBody, value); }
		}

		/// <summary> The DateCreated property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)EmailTemplateFieldIndex.DateCreated, true); }
			set	{ SetValue((int)EmailTemplateFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EmailTemplateFieldIndex.DateModified, false); }
			set	{ SetValue((int)EmailTemplateFieldIndex.DateModified, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EmailTemplateFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)EmailTemplateFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> The TemplateType property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."TemplateType"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TemplateType
		{
			get { return (System.Int64)GetValue((int)EmailTemplateFieldIndex.TemplateType, true); }
			set	{ SetValue((int)EmailTemplateFieldIndex.TemplateType, value); }
		}

		/// <summary> The NotificationTypeId property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."NotificationTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NotificationTypeId
		{
			get { return (System.Int32)GetValue((int)EmailTemplateFieldIndex.NotificationTypeId, true); }
			set	{ SetValue((int)EmailTemplateFieldIndex.NotificationTypeId, value); }
		}

		/// <summary> The IsEditable property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."IsEditable"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsEditable
		{
			get { return (System.Boolean)GetValue((int)EmailTemplateFieldIndex.IsEditable, true); }
			set	{ SetValue((int)EmailTemplateFieldIndex.IsEditable, value); }
		}

		/// <summary> The CoverLetterTypeLookupId property of the Entity EmailTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEmailTemplate"."CoverLetterTypeLookupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CoverLetterTypeLookupId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EmailTemplateFieldIndex.CoverLetterTypeLookupId, false); }
			set	{ SetValue((int)EmailTemplateFieldIndex.CoverLetterTypeLookupId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> Account__
		{
			get
			{
				if(_account__==null)
				{
					_account__ = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_account__.SetContainingEntityInfo(this, "EmailTemplate__");
				}
				return _account__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> Account___
		{
			get
			{
				if(_account___==null)
				{
					_account___ = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_account___.SetContainingEntityInfo(this, "EmailTemplate___");
				}
				return _account___;
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
					_account.SetContainingEntityInfo(this, "EmailTemplate");
				}
				return _account;
			}
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
					_account_.SetContainingEntityInfo(this, "EmailTemplate_");
				}
				return _account_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateMacroEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateMacroEntity))]
		public virtual EntityCollection<EmailTemplateMacroEntity> EmailTemplateMacro
		{
			get
			{
				if(_emailTemplateMacro==null)
				{
					_emailTemplateMacro = new EntityCollection<EmailTemplateMacroEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateMacroEntityFactory)));
					_emailTemplateMacro.SetContainingEntityInfo(this, "EmailTemplate");
				}
				return _emailTemplateMacro;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount__
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount__==null)
				{
					_checkListTemplateCollectionViaAccount__ = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount__.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount____
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount____==null)
				{
					_checkListTemplateCollectionViaAccount____ = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount____.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount____;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount_____
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount_____==null)
				{
					_checkListTemplateCollectionViaAccount_____ = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount_____.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount_______
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount_______==null)
				{
					_checkListTemplateCollectionViaAccount_______ = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount_______.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount___
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount___==null)
				{
					_checkListTemplateCollectionViaAccount___ = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount___.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount______
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount______==null)
				{
					_checkListTemplateCollectionViaAccount______ = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount______.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount___________________________________
		{
			get
			{
				if(_fileCollectionViaAccount___________________________________==null)
				{
					_fileCollectionViaAccount___________________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount___________________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount___________________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount__________________________________
		{
			get
			{
				if(_fileCollectionViaAccount__________________________________==null)
				{
					_fileCollectionViaAccount__________________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount__________________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount__________________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount____________________
		{
			get
			{
				if(_fileCollectionViaAccount____________________==null)
				{
					_fileCollectionViaAccount____________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount____________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount____________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount___________________
		{
			get
			{
				if(_fileCollectionViaAccount___________________==null)
				{
					_fileCollectionViaAccount___________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount___________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount___________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount__________________
		{
			get
			{
				if(_fileCollectionViaAccount__________________==null)
				{
					_fileCollectionViaAccount__________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount__________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount__________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount___________________________
		{
			get
			{
				if(_fileCollectionViaAccount___________________________==null)
				{
					_fileCollectionViaAccount___________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount___________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount___________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount__________________________
		{
			get
			{
				if(_fileCollectionViaAccount__________________________==null)
				{
					_fileCollectionViaAccount__________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount__________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount__________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_______________________________
		{
			get
			{
				if(_fileCollectionViaAccount_______________________________==null)
				{
					_fileCollectionViaAccount_______________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_______________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_______________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount______________________________
		{
			get
			{
				if(_fileCollectionViaAccount______________________________==null)
				{
					_fileCollectionViaAccount______________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount______________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount______________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_____________________________
		{
			get
			{
				if(_fileCollectionViaAccount_____________________________==null)
				{
					_fileCollectionViaAccount_____________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_____________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_____________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount____________________________
		{
			get
			{
				if(_fileCollectionViaAccount____________________________==null)
				{
					_fileCollectionViaAccount____________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount____________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount____________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount________________________________
		{
			get
			{
				if(_fileCollectionViaAccount________________________________==null)
				{
					_fileCollectionViaAccount________________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount________________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount________________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_______________________
		{
			get
			{
				if(_fileCollectionViaAccount_______________________==null)
				{
					_fileCollectionViaAccount_______________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_______________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_______________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount______________________
		{
			get
			{
				if(_fileCollectionViaAccount______________________==null)
				{
					_fileCollectionViaAccount______________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount______________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount______________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_____________________
		{
			get
			{
				if(_fileCollectionViaAccount_____________________==null)
				{
					_fileCollectionViaAccount_____________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_____________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_____________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_________________________________
		{
			get
			{
				if(_fileCollectionViaAccount_________________________________==null)
				{
					_fileCollectionViaAccount_________________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_________________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_________________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_________________________
		{
			get
			{
				if(_fileCollectionViaAccount_________________________==null)
				{
					_fileCollectionViaAccount_________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_________________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount________________________
		{
			get
			{
				if(_fileCollectionViaAccount________________________==null)
				{
					_fileCollectionViaAccount________________________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount________________________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount________________________;
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
		public virtual EntityCollection<FluConsentTemplateEntity> FluConsentTemplateCollectionViaAccount__
		{
			get
			{
				if(_fluConsentTemplateCollectionViaAccount__==null)
				{
					_fluConsentTemplateCollectionViaAccount__ = new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory)));
					_fluConsentTemplateCollectionViaAccount__.IsReadOnly=true;
				}
				return _fluConsentTemplateCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentTemplateEntity))]
		public virtual EntityCollection<FluConsentTemplateEntity> FluConsentTemplateCollectionViaAccount___
		{
			get
			{
				if(_fluConsentTemplateCollectionViaAccount___==null)
				{
					_fluConsentTemplateCollectionViaAccount___ = new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory)));
					_fluConsentTemplateCollectionViaAccount___.IsReadOnly=true;
				}
				return _fluConsentTemplateCollectionViaAccount___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaAccount__
		{
			get
			{
				if(_hafTemplateCollectionViaAccount__==null)
				{
					_hafTemplateCollectionViaAccount__ = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaAccount__.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaAccount___
		{
			get
			{
				if(_hafTemplateCollectionViaAccount___==null)
				{
					_hafTemplateCollectionViaAccount___ = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaAccount___.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaAccount___;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaAccount___
		{
			get
			{
				if(_lookupCollectionViaAccount___==null)
				{
					_lookupCollectionViaAccount___ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaAccount___.IsReadOnly=true;
				}
				return _lookupCollectionViaAccount___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaAccount__
		{
			get
			{
				if(_lookupCollectionViaAccount__==null)
				{
					_lookupCollectionViaAccount__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaAccount__.IsReadOnly=true;
				}
				return _lookupCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectsEntity))]
		public virtual EntityCollection<ProspectsEntity> ProspectsCollectionViaAccount___
		{
			get
			{
				if(_prospectsCollectionViaAccount___==null)
				{
					_prospectsCollectionViaAccount___ = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospectsCollectionViaAccount___.IsReadOnly=true;
				}
				return _prospectsCollectionViaAccount___;
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
		public virtual EntityCollection<ProspectsEntity> ProspectsCollectionViaAccount__
		{
			get
			{
				if(_prospectsCollectionViaAccount__==null)
				{
					_prospectsCollectionViaAccount__ = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospectsCollectionViaAccount__.IsReadOnly=true;
				}
				return _prospectsCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyTemplateEntity))]
		public virtual EntityCollection<SurveyTemplateEntity> SurveyTemplateCollectionViaAccount___
		{
			get
			{
				if(_surveyTemplateCollectionViaAccount___==null)
				{
					_surveyTemplateCollectionViaAccount___ = new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory)));
					_surveyTemplateCollectionViaAccount___.IsReadOnly=true;
				}
				return _surveyTemplateCollectionViaAccount___;
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
		public virtual EntityCollection<SurveyTemplateEntity> SurveyTemplateCollectionViaAccount__
		{
			get
			{
				if(_surveyTemplateCollectionViaAccount__==null)
				{
					_surveyTemplateCollectionViaAccount__ = new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory)));
					_surveyTemplateCollectionViaAccount__.IsReadOnly=true;
				}
				return _surveyTemplateCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TemplateMacroEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TemplateMacroEntity))]
		public virtual EntityCollection<TemplateMacroEntity> TemplateMacroCollectionViaEmailTemplateMacro
		{
			get
			{
				if(_templateMacroCollectionViaEmailTemplateMacro==null)
				{
					_templateMacroCollectionViaEmailTemplateMacro = new EntityCollection<TemplateMacroEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TemplateMacroEntityFactory)));
					_templateMacroCollectionViaEmailTemplateMacro.IsReadOnly=true;
				}
				return _templateMacroCollectionViaEmailTemplateMacro;
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
							_lookup_.UnsetRelatedEntity(this, "EmailTemplate_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EmailTemplate_");
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
							_lookup.UnsetRelatedEntity(this, "EmailTemplate");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EmailTemplate");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'NotificationTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual NotificationTypeEntity NotificationType
		{
			get
			{
				return _notificationType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNotificationType(value);
				}
				else
				{
					if(value==null)
					{
						if(_notificationType != null)
						{
							_notificationType.UnsetRelatedEntity(this, "EmailTemplate");
						}
					}
					else
					{
						if(_notificationType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EmailTemplate");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "EmailTemplate");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EmailTemplate");
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
			get { return (int)Falcon.Data.EntityType.EmailTemplateEntity; }
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
