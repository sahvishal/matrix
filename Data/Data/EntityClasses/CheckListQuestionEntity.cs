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
	/// Entity class which represents the entity 'CheckListQuestion'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CheckListQuestionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CheckListAnswerEntity> _checkListAnswer;
		private EntityCollection<ChecklistGroupQuestionEntity> _checklistGroupQuestion_;
		private EntityCollection<ChecklistGroupQuestionEntity> _checklistGroupQuestion;
		private EntityCollection<CheckListTemplateQuestionEntity> _checkListTemplateQuestion;
		private EntityCollection<ExitInterviewSignatureEntity> _exitInterviewSignature;
		private EntityCollection<CheckListGroupEntity> _checkListGroupCollectionViaChecklistGroupQuestion;
		private EntityCollection<CheckListGroupEntity> _checkListGroupCollectionViaChecklistGroupQuestion_;
		private EntityCollection<ChecklistGroupQuestionEntity> _checklistGroupQuestionCollectionViaCheckListTemplateQuestion;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaCheckListTemplateQuestion;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaExitInterviewSignature;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCheckListAnswer;
		private EntityCollection<FileEntity> _fileCollectionViaExitInterviewSignature;
		private EntityCollection<LookupEntity> _lookupCollectionViaCheckListAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaExitInterviewSignature;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCheckListAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCheckListAnswer_;
		private LookupEntity _lookup;
		private LookupEntity _lookup_;

		
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
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name CheckListAnswer</summary>
			public static readonly string CheckListAnswer = "CheckListAnswer";
			/// <summary>Member name ChecklistGroupQuestion_</summary>
			public static readonly string ChecklistGroupQuestion_ = "ChecklistGroupQuestion_";
			/// <summary>Member name ChecklistGroupQuestion</summary>
			public static readonly string ChecklistGroupQuestion = "ChecklistGroupQuestion";
			/// <summary>Member name CheckListTemplateQuestion</summary>
			public static readonly string CheckListTemplateQuestion = "CheckListTemplateQuestion";
			/// <summary>Member name ExitInterviewSignature</summary>
			public static readonly string ExitInterviewSignature = "ExitInterviewSignature";
			/// <summary>Member name CheckListGroupCollectionViaChecklistGroupQuestion</summary>
			public static readonly string CheckListGroupCollectionViaChecklistGroupQuestion = "CheckListGroupCollectionViaChecklistGroupQuestion";
			/// <summary>Member name CheckListGroupCollectionViaChecklistGroupQuestion_</summary>
			public static readonly string CheckListGroupCollectionViaChecklistGroupQuestion_ = "CheckListGroupCollectionViaChecklistGroupQuestion_";
			/// <summary>Member name ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion</summary>
			public static readonly string ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion = "ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion";
			/// <summary>Member name CheckListTemplateCollectionViaCheckListTemplateQuestion</summary>
			public static readonly string CheckListTemplateCollectionViaCheckListTemplateQuestion = "CheckListTemplateCollectionViaCheckListTemplateQuestion";
			/// <summary>Member name EventCustomersCollectionViaExitInterviewSignature</summary>
			public static readonly string EventCustomersCollectionViaExitInterviewSignature = "EventCustomersCollectionViaExitInterviewSignature";
			/// <summary>Member name EventCustomersCollectionViaCheckListAnswer</summary>
			public static readonly string EventCustomersCollectionViaCheckListAnswer = "EventCustomersCollectionViaCheckListAnswer";
			/// <summary>Member name FileCollectionViaExitInterviewSignature</summary>
			public static readonly string FileCollectionViaExitInterviewSignature = "FileCollectionViaExitInterviewSignature";
			/// <summary>Member name LookupCollectionViaCheckListAnswer</summary>
			public static readonly string LookupCollectionViaCheckListAnswer = "LookupCollectionViaCheckListAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaExitInterviewSignature</summary>
			public static readonly string OrganizationRoleUserCollectionViaExitInterviewSignature = "OrganizationRoleUserCollectionViaExitInterviewSignature";
			/// <summary>Member name OrganizationRoleUserCollectionViaCheckListAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCheckListAnswer = "OrganizationRoleUserCollectionViaCheckListAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaCheckListAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCheckListAnswer_ = "OrganizationRoleUserCollectionViaCheckListAnswer_";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CheckListQuestionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CheckListQuestionEntity():base("CheckListQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CheckListQuestionEntity(IEntityFields2 fields):base("CheckListQuestionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CheckListQuestionEntity</param>
		public CheckListQuestionEntity(IValidator validator):base("CheckListQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CheckListQuestion which data should be fetched into this CheckListQuestion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckListQuestionEntity(System.Int64 id):base("CheckListQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CheckListQuestion which data should be fetched into this CheckListQuestion object</param>
		/// <param name="validator">The custom validator object for this CheckListQuestionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckListQuestionEntity(System.Int64 id, IValidator validator):base("CheckListQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CheckListQuestionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_checkListAnswer = (EntityCollection<CheckListAnswerEntity>)info.GetValue("_checkListAnswer", typeof(EntityCollection<CheckListAnswerEntity>));
				_checklistGroupQuestion_ = (EntityCollection<ChecklistGroupQuestionEntity>)info.GetValue("_checklistGroupQuestion_", typeof(EntityCollection<ChecklistGroupQuestionEntity>));
				_checklistGroupQuestion = (EntityCollection<ChecklistGroupQuestionEntity>)info.GetValue("_checklistGroupQuestion", typeof(EntityCollection<ChecklistGroupQuestionEntity>));
				_checkListTemplateQuestion = (EntityCollection<CheckListTemplateQuestionEntity>)info.GetValue("_checkListTemplateQuestion", typeof(EntityCollection<CheckListTemplateQuestionEntity>));
				_exitInterviewSignature = (EntityCollection<ExitInterviewSignatureEntity>)info.GetValue("_exitInterviewSignature", typeof(EntityCollection<ExitInterviewSignatureEntity>));
				_checkListGroupCollectionViaChecklistGroupQuestion = (EntityCollection<CheckListGroupEntity>)info.GetValue("_checkListGroupCollectionViaChecklistGroupQuestion", typeof(EntityCollection<CheckListGroupEntity>));
				_checkListGroupCollectionViaChecklistGroupQuestion_ = (EntityCollection<CheckListGroupEntity>)info.GetValue("_checkListGroupCollectionViaChecklistGroupQuestion_", typeof(EntityCollection<CheckListGroupEntity>));
				_checklistGroupQuestionCollectionViaCheckListTemplateQuestion = (EntityCollection<ChecklistGroupQuestionEntity>)info.GetValue("_checklistGroupQuestionCollectionViaCheckListTemplateQuestion", typeof(EntityCollection<ChecklistGroupQuestionEntity>));
				_checkListTemplateCollectionViaCheckListTemplateQuestion = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaCheckListTemplateQuestion", typeof(EntityCollection<CheckListTemplateEntity>));
				_eventCustomersCollectionViaExitInterviewSignature = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaExitInterviewSignature", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaCheckListAnswer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCheckListAnswer", typeof(EntityCollection<EventCustomersEntity>));
				_fileCollectionViaExitInterviewSignature = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaExitInterviewSignature", typeof(EntityCollection<FileEntity>));
				_lookupCollectionViaCheckListAnswer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCheckListAnswer", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaExitInterviewSignature = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaExitInterviewSignature", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCheckListAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCheckListAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCheckListAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCheckListAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
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

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CheckListQuestionFieldIndex)fieldIndex)
			{
				case CheckListQuestionFieldIndex.TypeId:
					DesetupSyncLookup(true, false);
					break;
				case CheckListQuestionFieldIndex.Gender:
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
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "CheckListAnswer":
					this.CheckListAnswer.Add((CheckListAnswerEntity)entity);
					break;
				case "ChecklistGroupQuestion_":
					this.ChecklistGroupQuestion_.Add((ChecklistGroupQuestionEntity)entity);
					break;
				case "ChecklistGroupQuestion":
					this.ChecklistGroupQuestion.Add((ChecklistGroupQuestionEntity)entity);
					break;
				case "CheckListTemplateQuestion":
					this.CheckListTemplateQuestion.Add((CheckListTemplateQuestionEntity)entity);
					break;
				case "ExitInterviewSignature":
					this.ExitInterviewSignature.Add((ExitInterviewSignatureEntity)entity);
					break;
				case "CheckListGroupCollectionViaChecklistGroupQuestion":
					this.CheckListGroupCollectionViaChecklistGroupQuestion.IsReadOnly = false;
					this.CheckListGroupCollectionViaChecklistGroupQuestion.Add((CheckListGroupEntity)entity);
					this.CheckListGroupCollectionViaChecklistGroupQuestion.IsReadOnly = true;
					break;
				case "CheckListGroupCollectionViaChecklistGroupQuestion_":
					this.CheckListGroupCollectionViaChecklistGroupQuestion_.IsReadOnly = false;
					this.CheckListGroupCollectionViaChecklistGroupQuestion_.Add((CheckListGroupEntity)entity);
					this.CheckListGroupCollectionViaChecklistGroupQuestion_.IsReadOnly = true;
					break;
				case "ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion":
					this.ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly = false;
					this.ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion.Add((ChecklistGroupQuestionEntity)entity);
					this.ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly = true;
					break;
				case "CheckListTemplateCollectionViaCheckListTemplateQuestion":
					this.CheckListTemplateCollectionViaCheckListTemplateQuestion.IsReadOnly = false;
					this.CheckListTemplateCollectionViaCheckListTemplateQuestion.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaCheckListTemplateQuestion.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaExitInterviewSignature":
					this.EventCustomersCollectionViaExitInterviewSignature.IsReadOnly = false;
					this.EventCustomersCollectionViaExitInterviewSignature.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaExitInterviewSignature.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCheckListAnswer":
					this.EventCustomersCollectionViaCheckListAnswer.IsReadOnly = false;
					this.EventCustomersCollectionViaCheckListAnswer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCheckListAnswer.IsReadOnly = true;
					break;
				case "FileCollectionViaExitInterviewSignature":
					this.FileCollectionViaExitInterviewSignature.IsReadOnly = false;
					this.FileCollectionViaExitInterviewSignature.Add((FileEntity)entity);
					this.FileCollectionViaExitInterviewSignature.IsReadOnly = true;
					break;
				case "LookupCollectionViaCheckListAnswer":
					this.LookupCollectionViaCheckListAnswer.IsReadOnly = false;
					this.LookupCollectionViaCheckListAnswer.Add((LookupEntity)entity);
					this.LookupCollectionViaCheckListAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewSignature":
					this.OrganizationRoleUserCollectionViaExitInterviewSignature.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaExitInterviewSignature.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaExitInterviewSignature.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCheckListAnswer":
					this.OrganizationRoleUserCollectionViaCheckListAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCheckListAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCheckListAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCheckListAnswer_":
					this.OrganizationRoleUserCollectionViaCheckListAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCheckListAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCheckListAnswer_.IsReadOnly = true;
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
			return CheckListQuestionEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(CheckListQuestionEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "Lookup_":
					toReturn.Add(CheckListQuestionEntity.Relations.LookupEntityUsingGender);
					break;
				case "CheckListAnswer":
					toReturn.Add(CheckListQuestionEntity.Relations.CheckListAnswerEntityUsingQuestionId);
					break;
				case "ChecklistGroupQuestion_":
					toReturn.Add(CheckListQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingQuestionId);
					break;
				case "ChecklistGroupQuestion":
					toReturn.Add(CheckListQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingParentId);
					break;
				case "CheckListTemplateQuestion":
					toReturn.Add(CheckListQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingQuestionId);
					break;
				case "ExitInterviewSignature":
					toReturn.Add(CheckListQuestionEntity.Relations.ExitInterviewSignatureEntityUsingQuestionId);
					break;
				case "CheckListGroupCollectionViaChecklistGroupQuestion":
					toReturn.Add(CheckListQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingParentId, "CheckListQuestionEntity__", "ChecklistGroupQuestion_", JoinHint.None);
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListGroupEntityUsingGroupId, "ChecklistGroupQuestion_", string.Empty, JoinHint.None);
					break;
				case "CheckListGroupCollectionViaChecklistGroupQuestion_":
					toReturn.Add(CheckListQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingQuestionId, "CheckListQuestionEntity__", "ChecklistGroupQuestion_", JoinHint.None);
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListGroupEntityUsingGroupId, "ChecklistGroupQuestion_", string.Empty, JoinHint.None);
					break;
				case "ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion":
					toReturn.Add(CheckListQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingQuestionId, "CheckListQuestionEntity__", "CheckListTemplateQuestion_", JoinHint.None);
					toReturn.Add(CheckListTemplateQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingGroupQuestionId, "CheckListTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaCheckListTemplateQuestion":
					toReturn.Add(CheckListQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingQuestionId, "CheckListQuestionEntity__", "CheckListTemplateQuestion_", JoinHint.None);
					toReturn.Add(CheckListTemplateQuestionEntity.Relations.CheckListTemplateEntityUsingTemplateId, "CheckListTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaExitInterviewSignature":
					toReturn.Add(CheckListQuestionEntity.Relations.ExitInterviewSignatureEntityUsingQuestionId, "CheckListQuestionEntity__", "ExitInterviewSignature_", JoinHint.None);
					toReturn.Add(ExitInterviewSignatureEntity.Relations.EventCustomersEntityUsingEventCustomerId, "ExitInterviewSignature_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCheckListAnswer":
					toReturn.Add(CheckListQuestionEntity.Relations.CheckListAnswerEntityUsingQuestionId, "CheckListQuestionEntity__", "CheckListAnswer_", JoinHint.None);
					toReturn.Add(CheckListAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CheckListAnswer_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaExitInterviewSignature":
					toReturn.Add(CheckListQuestionEntity.Relations.ExitInterviewSignatureEntityUsingQuestionId, "CheckListQuestionEntity__", "ExitInterviewSignature_", JoinHint.None);
					toReturn.Add(ExitInterviewSignatureEntity.Relations.FileEntityUsingSignatureFileId, "ExitInterviewSignature_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCheckListAnswer":
					toReturn.Add(CheckListQuestionEntity.Relations.CheckListAnswerEntityUsingQuestionId, "CheckListQuestionEntity__", "CheckListAnswer_", JoinHint.None);
					toReturn.Add(CheckListAnswerEntity.Relations.LookupEntityUsingType, "CheckListAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewSignature":
					toReturn.Add(CheckListQuestionEntity.Relations.ExitInterviewSignatureEntityUsingQuestionId, "CheckListQuestionEntity__", "ExitInterviewSignature_", JoinHint.None);
					toReturn.Add(ExitInterviewSignatureEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ExitInterviewSignature_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCheckListAnswer":
					toReturn.Add(CheckListQuestionEntity.Relations.CheckListAnswerEntityUsingQuestionId, "CheckListQuestionEntity__", "CheckListAnswer_", JoinHint.None);
					toReturn.Add(CheckListAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CheckListAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCheckListAnswer_":
					toReturn.Add(CheckListQuestionEntity.Relations.CheckListAnswerEntityUsingQuestionId, "CheckListQuestionEntity__", "CheckListAnswer_", JoinHint.None);
					toReturn.Add(CheckListAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "CheckListAnswer_", string.Empty, JoinHint.None);
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
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "CheckListAnswer":
					this.CheckListAnswer.Add((CheckListAnswerEntity)relatedEntity);
					break;
				case "ChecklistGroupQuestion_":
					this.ChecklistGroupQuestion_.Add((ChecklistGroupQuestionEntity)relatedEntity);
					break;
				case "ChecklistGroupQuestion":
					this.ChecklistGroupQuestion.Add((ChecklistGroupQuestionEntity)relatedEntity);
					break;
				case "CheckListTemplateQuestion":
					this.CheckListTemplateQuestion.Add((CheckListTemplateQuestionEntity)relatedEntity);
					break;
				case "ExitInterviewSignature":
					this.ExitInterviewSignature.Add((ExitInterviewSignatureEntity)relatedEntity);
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
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "CheckListAnswer":
					base.PerformRelatedEntityRemoval(this.CheckListAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ChecklistGroupQuestion_":
					base.PerformRelatedEntityRemoval(this.ChecklistGroupQuestion_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ChecklistGroupQuestion":
					base.PerformRelatedEntityRemoval(this.ChecklistGroupQuestion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CheckListTemplateQuestion":
					base.PerformRelatedEntityRemoval(this.CheckListTemplateQuestion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ExitInterviewSignature":
					base.PerformRelatedEntityRemoval(this.ExitInterviewSignature, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CheckListAnswer);
			toReturn.Add(this.ChecklistGroupQuestion_);
			toReturn.Add(this.ChecklistGroupQuestion);
			toReturn.Add(this.CheckListTemplateQuestion);
			toReturn.Add(this.ExitInterviewSignature);

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
				info.AddValue("_checkListAnswer", ((_checkListAnswer!=null) && (_checkListAnswer.Count>0) && !this.MarkedForDeletion)?_checkListAnswer:null);
				info.AddValue("_checklistGroupQuestion_", ((_checklistGroupQuestion_!=null) && (_checklistGroupQuestion_.Count>0) && !this.MarkedForDeletion)?_checklistGroupQuestion_:null);
				info.AddValue("_checklistGroupQuestion", ((_checklistGroupQuestion!=null) && (_checklistGroupQuestion.Count>0) && !this.MarkedForDeletion)?_checklistGroupQuestion:null);
				info.AddValue("_checkListTemplateQuestion", ((_checkListTemplateQuestion!=null) && (_checkListTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_checkListTemplateQuestion:null);
				info.AddValue("_exitInterviewSignature", ((_exitInterviewSignature!=null) && (_exitInterviewSignature.Count>0) && !this.MarkedForDeletion)?_exitInterviewSignature:null);
				info.AddValue("_checkListGroupCollectionViaChecklistGroupQuestion", ((_checkListGroupCollectionViaChecklistGroupQuestion!=null) && (_checkListGroupCollectionViaChecklistGroupQuestion.Count>0) && !this.MarkedForDeletion)?_checkListGroupCollectionViaChecklistGroupQuestion:null);
				info.AddValue("_checkListGroupCollectionViaChecklistGroupQuestion_", ((_checkListGroupCollectionViaChecklistGroupQuestion_!=null) && (_checkListGroupCollectionViaChecklistGroupQuestion_.Count>0) && !this.MarkedForDeletion)?_checkListGroupCollectionViaChecklistGroupQuestion_:null);
				info.AddValue("_checklistGroupQuestionCollectionViaCheckListTemplateQuestion", ((_checklistGroupQuestionCollectionViaCheckListTemplateQuestion!=null) && (_checklistGroupQuestionCollectionViaCheckListTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_checklistGroupQuestionCollectionViaCheckListTemplateQuestion:null);
				info.AddValue("_checkListTemplateCollectionViaCheckListTemplateQuestion", ((_checkListTemplateCollectionViaCheckListTemplateQuestion!=null) && (_checkListTemplateCollectionViaCheckListTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaCheckListTemplateQuestion:null);
				info.AddValue("_eventCustomersCollectionViaExitInterviewSignature", ((_eventCustomersCollectionViaExitInterviewSignature!=null) && (_eventCustomersCollectionViaExitInterviewSignature.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaExitInterviewSignature:null);
				info.AddValue("_eventCustomersCollectionViaCheckListAnswer", ((_eventCustomersCollectionViaCheckListAnswer!=null) && (_eventCustomersCollectionViaCheckListAnswer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCheckListAnswer:null);
				info.AddValue("_fileCollectionViaExitInterviewSignature", ((_fileCollectionViaExitInterviewSignature!=null) && (_fileCollectionViaExitInterviewSignature.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaExitInterviewSignature:null);
				info.AddValue("_lookupCollectionViaCheckListAnswer", ((_lookupCollectionViaCheckListAnswer!=null) && (_lookupCollectionViaCheckListAnswer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCheckListAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaExitInterviewSignature", ((_organizationRoleUserCollectionViaExitInterviewSignature!=null) && (_organizationRoleUserCollectionViaExitInterviewSignature.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaExitInterviewSignature:null);
				info.AddValue("_organizationRoleUserCollectionViaCheckListAnswer", ((_organizationRoleUserCollectionViaCheckListAnswer!=null) && (_organizationRoleUserCollectionViaCheckListAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCheckListAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaCheckListAnswer_", ((_organizationRoleUserCollectionViaCheckListAnswer_!=null) && (_organizationRoleUserCollectionViaCheckListAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCheckListAnswer_:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CheckListQuestionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CheckListQuestionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CheckListQuestionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListAnswerFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChecklistGroupQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChecklistGroupQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChecklistGroupQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChecklistGroupQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChecklistGroupQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChecklistGroupQuestionFields.ParentId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ExitInterviewSignature' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoExitInterviewSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewSignatureFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListGroupCollectionViaChecklistGroupQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListGroupCollectionViaChecklistGroupQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListGroupCollectionViaChecklistGroupQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListGroupCollectionViaChecklistGroupQuestion_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChecklistGroupQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChecklistGroupQuestionCollectionViaCheckListTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaCheckListTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaCheckListTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaExitInterviewSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaExitInterviewSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCheckListAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCheckListAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaExitInterviewSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaExitInterviewSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCheckListAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCheckListAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaExitInterviewSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaExitInterviewSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCheckListAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCheckListAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCheckListAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCheckListAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Gender));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CheckListQuestionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._checkListAnswer);
			collectionsQueue.Enqueue(this._checklistGroupQuestion_);
			collectionsQueue.Enqueue(this._checklistGroupQuestion);
			collectionsQueue.Enqueue(this._checkListTemplateQuestion);
			collectionsQueue.Enqueue(this._exitInterviewSignature);
			collectionsQueue.Enqueue(this._checkListGroupCollectionViaChecklistGroupQuestion);
			collectionsQueue.Enqueue(this._checkListGroupCollectionViaChecklistGroupQuestion_);
			collectionsQueue.Enqueue(this._checklistGroupQuestionCollectionViaCheckListTemplateQuestion);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaCheckListTemplateQuestion);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaExitInterviewSignature);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCheckListAnswer);
			collectionsQueue.Enqueue(this._fileCollectionViaExitInterviewSignature);
			collectionsQueue.Enqueue(this._lookupCollectionViaCheckListAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaExitInterviewSignature);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCheckListAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCheckListAnswer_);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._checkListAnswer = (EntityCollection<CheckListAnswerEntity>) collectionsQueue.Dequeue();
			this._checklistGroupQuestion_ = (EntityCollection<ChecklistGroupQuestionEntity>) collectionsQueue.Dequeue();
			this._checklistGroupQuestion = (EntityCollection<ChecklistGroupQuestionEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateQuestion = (EntityCollection<CheckListTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._exitInterviewSignature = (EntityCollection<ExitInterviewSignatureEntity>) collectionsQueue.Dequeue();
			this._checkListGroupCollectionViaChecklistGroupQuestion = (EntityCollection<CheckListGroupEntity>) collectionsQueue.Dequeue();
			this._checkListGroupCollectionViaChecklistGroupQuestion_ = (EntityCollection<CheckListGroupEntity>) collectionsQueue.Dequeue();
			this._checklistGroupQuestionCollectionViaCheckListTemplateQuestion = (EntityCollection<ChecklistGroupQuestionEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaCheckListTemplateQuestion = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaExitInterviewSignature = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCheckListAnswer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaExitInterviewSignature = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCheckListAnswer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaExitInterviewSignature = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCheckListAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCheckListAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._checkListAnswer != null)
			{
				return true;
			}
			if (this._checklistGroupQuestion_ != null)
			{
				return true;
			}
			if (this._checklistGroupQuestion != null)
			{
				return true;
			}
			if (this._checkListTemplateQuestion != null)
			{
				return true;
			}
			if (this._exitInterviewSignature != null)
			{
				return true;
			}
			if (this._checkListGroupCollectionViaChecklistGroupQuestion != null)
			{
				return true;
			}
			if (this._checkListGroupCollectionViaChecklistGroupQuestion_ != null)
			{
				return true;
			}
			if (this._checklistGroupQuestionCollectionViaCheckListTemplateQuestion != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaCheckListTemplateQuestion != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaExitInterviewSignature != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCheckListAnswer != null)
			{
				return true;
			}
			if (this._fileCollectionViaExitInterviewSignature != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCheckListAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaExitInterviewSignature != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCheckListAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCheckListAnswer_ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ExitInterviewSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewSignatureEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
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
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("CheckListAnswer", _checkListAnswer);
			toReturn.Add("ChecklistGroupQuestion_", _checklistGroupQuestion_);
			toReturn.Add("ChecklistGroupQuestion", _checklistGroupQuestion);
			toReturn.Add("CheckListTemplateQuestion", _checkListTemplateQuestion);
			toReturn.Add("ExitInterviewSignature", _exitInterviewSignature);
			toReturn.Add("CheckListGroupCollectionViaChecklistGroupQuestion", _checkListGroupCollectionViaChecklistGroupQuestion);
			toReturn.Add("CheckListGroupCollectionViaChecklistGroupQuestion_", _checkListGroupCollectionViaChecklistGroupQuestion_);
			toReturn.Add("ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion", _checklistGroupQuestionCollectionViaCheckListTemplateQuestion);
			toReturn.Add("CheckListTemplateCollectionViaCheckListTemplateQuestion", _checkListTemplateCollectionViaCheckListTemplateQuestion);
			toReturn.Add("EventCustomersCollectionViaExitInterviewSignature", _eventCustomersCollectionViaExitInterviewSignature);
			toReturn.Add("EventCustomersCollectionViaCheckListAnswer", _eventCustomersCollectionViaCheckListAnswer);
			toReturn.Add("FileCollectionViaExitInterviewSignature", _fileCollectionViaExitInterviewSignature);
			toReturn.Add("LookupCollectionViaCheckListAnswer", _lookupCollectionViaCheckListAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaExitInterviewSignature", _organizationRoleUserCollectionViaExitInterviewSignature);
			toReturn.Add("OrganizationRoleUserCollectionViaCheckListAnswer", _organizationRoleUserCollectionViaCheckListAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaCheckListAnswer_", _organizationRoleUserCollectionViaCheckListAnswer_);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_checkListAnswer!=null)
			{
				_checkListAnswer.ActiveContext = base.ActiveContext;
			}
			if(_checklistGroupQuestion_!=null)
			{
				_checklistGroupQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_checklistGroupQuestion!=null)
			{
				_checklistGroupQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateQuestion!=null)
			{
				_checkListTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_exitInterviewSignature!=null)
			{
				_exitInterviewSignature.ActiveContext = base.ActiveContext;
			}
			if(_checkListGroupCollectionViaChecklistGroupQuestion!=null)
			{
				_checkListGroupCollectionViaChecklistGroupQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListGroupCollectionViaChecklistGroupQuestion_!=null)
			{
				_checkListGroupCollectionViaChecklistGroupQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_checklistGroupQuestionCollectionViaCheckListTemplateQuestion!=null)
			{
				_checklistGroupQuestionCollectionViaCheckListTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaCheckListTemplateQuestion!=null)
			{
				_checkListTemplateCollectionViaCheckListTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaExitInterviewSignature!=null)
			{
				_eventCustomersCollectionViaExitInterviewSignature.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCheckListAnswer!=null)
			{
				_eventCustomersCollectionViaCheckListAnswer.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaExitInterviewSignature!=null)
			{
				_fileCollectionViaExitInterviewSignature.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCheckListAnswer!=null)
			{
				_lookupCollectionViaCheckListAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaExitInterviewSignature!=null)
			{
				_organizationRoleUserCollectionViaExitInterviewSignature.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCheckListAnswer!=null)
			{
				_organizationRoleUserCollectionViaCheckListAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCheckListAnswer_!=null)
			{
				_organizationRoleUserCollectionViaCheckListAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_checkListAnswer = null;
			_checklistGroupQuestion_ = null;
			_checklistGroupQuestion = null;
			_checkListTemplateQuestion = null;
			_exitInterviewSignature = null;
			_checkListGroupCollectionViaChecklistGroupQuestion = null;
			_checkListGroupCollectionViaChecklistGroupQuestion_ = null;
			_checklistGroupQuestionCollectionViaCheckListTemplateQuestion = null;
			_checkListTemplateCollectionViaCheckListTemplateQuestion = null;
			_eventCustomersCollectionViaExitInterviewSignature = null;
			_eventCustomersCollectionViaCheckListAnswer = null;
			_fileCollectionViaExitInterviewSignature = null;
			_lookupCollectionViaCheckListAnswer = null;
			_organizationRoleUserCollectionViaExitInterviewSignature = null;
			_organizationRoleUserCollectionViaCheckListAnswer = null;
			_organizationRoleUserCollectionViaCheckListAnswer_ = null;
			_lookup = null;
			_lookup_ = null;

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

			_fieldsCustomProperties.Add("Question", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValues", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValueDelimiter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Index", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CheckListQuestionEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "CheckListQuestion", resetFKFields, new int[] { (int)CheckListQuestionFieldIndex.TypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CheckListQuestionEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", CheckListQuestionEntity.Relations.LookupEntityUsingGender, true, signalRelatedEntity, "CheckListQuestion_", resetFKFields, new int[] { (int)CheckListQuestionFieldIndex.Gender } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", CheckListQuestionEntity.Relations.LookupEntityUsingGender, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CheckListQuestionEntity</param>
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
		public  static CheckListQuestionRelations Relations
		{
			get	{ return new CheckListQuestionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CheckListAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListAnswer")[0], (int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.CheckListAnswerEntity, 0, null, null, null, null, "CheckListAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChecklistGroupQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChecklistGroupQuestion_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChecklistGroupQuestion_")[0], (int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, 0, null, null, null, null, "ChecklistGroupQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChecklistGroupQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChecklistGroupQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChecklistGroupQuestion")[0], (int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, 0, null, null, null, null, "ChecklistGroupQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("CheckListTemplateQuestion")[0], (int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.CheckListTemplateQuestionEntity, 0, null, null, null, null, "CheckListTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ExitInterviewSignature' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathExitInterviewSignature
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ExitInterviewSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewSignatureEntityFactory))),
					(IEntityRelation)GetRelationsForField("ExitInterviewSignature")[0], (int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.ExitInterviewSignatureEntity, 0, null, null, null, null, "ExitInterviewSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListGroupCollectionViaChecklistGroupQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "ChecklistGroupQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CheckListGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.CheckListGroupEntity, 0, null, null, GetRelationsForField("CheckListGroupCollectionViaChecklistGroupQuestion"), null, "CheckListGroupCollectionViaChecklistGroupQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListGroupCollectionViaChecklistGroupQuestion_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ChecklistGroupQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CheckListGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.CheckListGroupEntity, 0, null, null, GetRelationsForField("CheckListGroupCollectionViaChecklistGroupQuestion_"), null, "CheckListGroupCollectionViaChecklistGroupQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChecklistGroupQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChecklistGroupQuestionCollectionViaCheckListTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CheckListTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, 0, null, null, GetRelationsForField("ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion"), null, "ChecklistGroupQuestionCollectionViaCheckListTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaCheckListTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CheckListTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaCheckListTemplateQuestion"), null, "CheckListTemplateCollectionViaCheckListTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaExitInterviewSignature
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.ExitInterviewSignatureEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewSignature_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaExitInterviewSignature"), null, "EventCustomersCollectionViaExitInterviewSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCheckListAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.CheckListAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CheckListAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCheckListAnswer"), null, "EventCustomersCollectionViaCheckListAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaExitInterviewSignature
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.ExitInterviewSignatureEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewSignature_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaExitInterviewSignature"), null, "FileCollectionViaExitInterviewSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCheckListAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.CheckListAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CheckListAnswer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCheckListAnswer"), null, "LookupCollectionViaCheckListAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaExitInterviewSignature
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.ExitInterviewSignatureEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewSignature_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaExitInterviewSignature"), null, "OrganizationRoleUserCollectionViaExitInterviewSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCheckListAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.CheckListAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CheckListAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCheckListAnswer"), null, "OrganizationRoleUserCollectionViaCheckListAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCheckListAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListQuestionEntity.Relations.CheckListAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CheckListAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCheckListAnswer_"), null, "OrganizationRoleUserCollectionViaCheckListAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.CheckListQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CheckListQuestionEntity.CustomProperties;}
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
			get { return CheckListQuestionEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity CheckListQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListQuestion"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CheckListQuestionFieldIndex.Id, true); }
			set	{ SetValue((int)CheckListQuestionFieldIndex.Id, value); }
		}

		/// <summary> The Question property of the Entity CheckListQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListQuestion"."Question"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Question
		{
			get { return (System.String)GetValue((int)CheckListQuestionFieldIndex.Question, true); }
			set	{ SetValue((int)CheckListQuestionFieldIndex.Question, value); }
		}

		/// <summary> The TypeId property of the Entity CheckListQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListQuestion"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)CheckListQuestionFieldIndex.TypeId, true); }
			set	{ SetValue((int)CheckListQuestionFieldIndex.TypeId, value); }
		}

		/// <summary> The Gender property of the Entity CheckListQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListQuestion"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Gender
		{
			get { return (System.Int64)GetValue((int)CheckListQuestionFieldIndex.Gender, true); }
			set	{ SetValue((int)CheckListQuestionFieldIndex.Gender, value); }
		}

		/// <summary> The ControlValues property of the Entity CheckListQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListQuestion"."ControlValues"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValues
		{
			get { return (System.String)GetValue((int)CheckListQuestionFieldIndex.ControlValues, true); }
			set	{ SetValue((int)CheckListQuestionFieldIndex.ControlValues, value); }
		}

		/// <summary> The ControlValueDelimiter property of the Entity CheckListQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListQuestion"."ControlValueDelimiter"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValueDelimiter
		{
			get { return (System.String)GetValue((int)CheckListQuestionFieldIndex.ControlValueDelimiter, true); }
			set	{ SetValue((int)CheckListQuestionFieldIndex.ControlValueDelimiter, value); }
		}

		/// <summary> The Index property of the Entity CheckListQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListQuestion"."Index"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Index
		{
			get { return (System.Int32)GetValue((int)CheckListQuestionFieldIndex.Index, true); }
			set	{ SetValue((int)CheckListQuestionFieldIndex.Index, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListAnswerEntity))]
		public virtual EntityCollection<CheckListAnswerEntity> CheckListAnswer
		{
			get
			{
				if(_checkListAnswer==null)
				{
					_checkListAnswer = new EntityCollection<CheckListAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListAnswerEntityFactory)));
					_checkListAnswer.SetContainingEntityInfo(this, "CheckListQuestion");
				}
				return _checkListAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChecklistGroupQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChecklistGroupQuestionEntity))]
		public virtual EntityCollection<ChecklistGroupQuestionEntity> ChecklistGroupQuestion_
		{
			get
			{
				if(_checklistGroupQuestion_==null)
				{
					_checklistGroupQuestion_ = new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory)));
					_checklistGroupQuestion_.SetContainingEntityInfo(this, "CheckListQuestion_");
				}
				return _checklistGroupQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChecklistGroupQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChecklistGroupQuestionEntity))]
		public virtual EntityCollection<ChecklistGroupQuestionEntity> ChecklistGroupQuestion
		{
			get
			{
				if(_checklistGroupQuestion==null)
				{
					_checklistGroupQuestion = new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory)));
					_checklistGroupQuestion.SetContainingEntityInfo(this, "CheckListQuestion");
				}
				return _checklistGroupQuestion;
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
					_checkListTemplateQuestion.SetContainingEntityInfo(this, "CheckListQuestion");
				}
				return _checkListTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ExitInterviewSignatureEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ExitInterviewSignatureEntity))]
		public virtual EntityCollection<ExitInterviewSignatureEntity> ExitInterviewSignature
		{
			get
			{
				if(_exitInterviewSignature==null)
				{
					_exitInterviewSignature = new EntityCollection<ExitInterviewSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewSignatureEntityFactory)));
					_exitInterviewSignature.SetContainingEntityInfo(this, "CheckListQuestion");
				}
				return _exitInterviewSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListGroupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListGroupEntity))]
		public virtual EntityCollection<CheckListGroupEntity> CheckListGroupCollectionViaChecklistGroupQuestion
		{
			get
			{
				if(_checkListGroupCollectionViaChecklistGroupQuestion==null)
				{
					_checkListGroupCollectionViaChecklistGroupQuestion = new EntityCollection<CheckListGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory)));
					_checkListGroupCollectionViaChecklistGroupQuestion.IsReadOnly=true;
				}
				return _checkListGroupCollectionViaChecklistGroupQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListGroupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListGroupEntity))]
		public virtual EntityCollection<CheckListGroupEntity> CheckListGroupCollectionViaChecklistGroupQuestion_
		{
			get
			{
				if(_checkListGroupCollectionViaChecklistGroupQuestion_==null)
				{
					_checkListGroupCollectionViaChecklistGroupQuestion_ = new EntityCollection<CheckListGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory)));
					_checkListGroupCollectionViaChecklistGroupQuestion_.IsReadOnly=true;
				}
				return _checkListGroupCollectionViaChecklistGroupQuestion_;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaCheckListTemplateQuestion
		{
			get
			{
				if(_checkListTemplateCollectionViaCheckListTemplateQuestion==null)
				{
					_checkListTemplateCollectionViaCheckListTemplateQuestion = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaCheckListTemplateQuestion.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaCheckListTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaExitInterviewSignature
		{
			get
			{
				if(_eventCustomersCollectionViaExitInterviewSignature==null)
				{
					_eventCustomersCollectionViaExitInterviewSignature = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaExitInterviewSignature.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaExitInterviewSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaCheckListAnswer
		{
			get
			{
				if(_eventCustomersCollectionViaCheckListAnswer==null)
				{
					_eventCustomersCollectionViaCheckListAnswer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaCheckListAnswer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaCheckListAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaExitInterviewSignature
		{
			get
			{
				if(_fileCollectionViaExitInterviewSignature==null)
				{
					_fileCollectionViaExitInterviewSignature = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaExitInterviewSignature.IsReadOnly=true;
				}
				return _fileCollectionViaExitInterviewSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCheckListAnswer
		{
			get
			{
				if(_lookupCollectionViaCheckListAnswer==null)
				{
					_lookupCollectionViaCheckListAnswer = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCheckListAnswer.IsReadOnly=true;
				}
				return _lookupCollectionViaCheckListAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaExitInterviewSignature
		{
			get
			{
				if(_organizationRoleUserCollectionViaExitInterviewSignature==null)
				{
					_organizationRoleUserCollectionViaExitInterviewSignature = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaExitInterviewSignature.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaExitInterviewSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCheckListAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCheckListAnswer==null)
				{
					_organizationRoleUserCollectionViaCheckListAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCheckListAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCheckListAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCheckListAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCheckListAnswer_==null)
				{
					_organizationRoleUserCollectionViaCheckListAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCheckListAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCheckListAnswer_;
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
							_lookup.UnsetRelatedEntity(this, "CheckListQuestion");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListQuestion");
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
							_lookup_.UnsetRelatedEntity(this, "CheckListQuestion_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListQuestion_");
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
			get { return (int)Falcon.Data.EntityType.CheckListQuestionEntity; }
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
