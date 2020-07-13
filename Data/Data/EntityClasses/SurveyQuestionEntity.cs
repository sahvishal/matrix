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
	/// Entity class which represents the entity 'SurveyQuestion'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class SurveyQuestionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<SurveyAnswerEntity> _surveyAnswer;
		private EntityCollection<SurveyQuestionEntity> _surveyQuestion_;
		private EntityCollection<SurveyTemplateQuestionEntity> _surveyTemplateQuestion;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaSurveyAnswer;
		private EntityCollection<LookupEntity> _lookupCollectionViaSurveyQuestion;
		private EntityCollection<LookupEntity> _lookupCollectionViaSurveyQuestion_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaSurveyAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaSurveyAnswer_;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaSurveyTemplateQuestion;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;
		private SurveyQuestionEntity _surveyQuestion;

		
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
			/// <summary>Member name SurveyQuestion</summary>
			public static readonly string SurveyQuestion = "SurveyQuestion";
			/// <summary>Member name SurveyAnswer</summary>
			public static readonly string SurveyAnswer = "SurveyAnswer";
			/// <summary>Member name SurveyQuestion_</summary>
			public static readonly string SurveyQuestion_ = "SurveyQuestion_";
			/// <summary>Member name SurveyTemplateQuestion</summary>
			public static readonly string SurveyTemplateQuestion = "SurveyTemplateQuestion";
			/// <summary>Member name EventCustomersCollectionViaSurveyAnswer</summary>
			public static readonly string EventCustomersCollectionViaSurveyAnswer = "EventCustomersCollectionViaSurveyAnswer";
			/// <summary>Member name LookupCollectionViaSurveyQuestion</summary>
			public static readonly string LookupCollectionViaSurveyQuestion = "LookupCollectionViaSurveyQuestion";
			/// <summary>Member name LookupCollectionViaSurveyQuestion_</summary>
			public static readonly string LookupCollectionViaSurveyQuestion_ = "LookupCollectionViaSurveyQuestion_";
			/// <summary>Member name OrganizationRoleUserCollectionViaSurveyAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaSurveyAnswer = "OrganizationRoleUserCollectionViaSurveyAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaSurveyAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaSurveyAnswer_ = "OrganizationRoleUserCollectionViaSurveyAnswer_";
			/// <summary>Member name SurveyTemplateCollectionViaSurveyTemplateQuestion</summary>
			public static readonly string SurveyTemplateCollectionViaSurveyTemplateQuestion = "SurveyTemplateCollectionViaSurveyTemplateQuestion";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SurveyQuestionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public SurveyQuestionEntity():base("SurveyQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SurveyQuestionEntity(IEntityFields2 fields):base("SurveyQuestionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SurveyQuestionEntity</param>
		public SurveyQuestionEntity(IValidator validator):base("SurveyQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for SurveyQuestion which data should be fetched into this SurveyQuestion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SurveyQuestionEntity(System.Int64 id):base("SurveyQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for SurveyQuestion which data should be fetched into this SurveyQuestion object</param>
		/// <param name="validator">The custom validator object for this SurveyQuestionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SurveyQuestionEntity(System.Int64 id, IValidator validator):base("SurveyQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected SurveyQuestionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_surveyAnswer = (EntityCollection<SurveyAnswerEntity>)info.GetValue("_surveyAnswer", typeof(EntityCollection<SurveyAnswerEntity>));
				_surveyQuestion_ = (EntityCollection<SurveyQuestionEntity>)info.GetValue("_surveyQuestion_", typeof(EntityCollection<SurveyQuestionEntity>));
				_surveyTemplateQuestion = (EntityCollection<SurveyTemplateQuestionEntity>)info.GetValue("_surveyTemplateQuestion", typeof(EntityCollection<SurveyTemplateQuestionEntity>));
				_eventCustomersCollectionViaSurveyAnswer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaSurveyAnswer", typeof(EntityCollection<EventCustomersEntity>));
				_lookupCollectionViaSurveyQuestion = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaSurveyQuestion", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaSurveyQuestion_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaSurveyQuestion_", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaSurveyAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaSurveyAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaSurveyAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaSurveyAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_surveyTemplateCollectionViaSurveyTemplateQuestion = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaSurveyTemplateQuestion", typeof(EntityCollection<SurveyTemplateEntity>));
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
				_surveyQuestion = (SurveyQuestionEntity)info.GetValue("_surveyQuestion", typeof(SurveyQuestionEntity));
				if(_surveyQuestion!=null)
				{
					_surveyQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((SurveyQuestionFieldIndex)fieldIndex)
			{
				case SurveyQuestionFieldIndex.TypeId:
					DesetupSyncLookup_(true, false);
					break;
				case SurveyQuestionFieldIndex.ParentId:
					DesetupSyncSurveyQuestion(true, false);
					break;
				case SurveyQuestionFieldIndex.Gender:
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
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "SurveyQuestion":
					this.SurveyQuestion = (SurveyQuestionEntity)entity;
					break;
				case "SurveyAnswer":
					this.SurveyAnswer.Add((SurveyAnswerEntity)entity);
					break;
				case "SurveyQuestion_":
					this.SurveyQuestion_.Add((SurveyQuestionEntity)entity);
					break;
				case "SurveyTemplateQuestion":
					this.SurveyTemplateQuestion.Add((SurveyTemplateQuestionEntity)entity);
					break;
				case "EventCustomersCollectionViaSurveyAnswer":
					this.EventCustomersCollectionViaSurveyAnswer.IsReadOnly = false;
					this.EventCustomersCollectionViaSurveyAnswer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaSurveyAnswer.IsReadOnly = true;
					break;
				case "LookupCollectionViaSurveyQuestion":
					this.LookupCollectionViaSurveyQuestion.IsReadOnly = false;
					this.LookupCollectionViaSurveyQuestion.Add((LookupEntity)entity);
					this.LookupCollectionViaSurveyQuestion.IsReadOnly = true;
					break;
				case "LookupCollectionViaSurveyQuestion_":
					this.LookupCollectionViaSurveyQuestion_.IsReadOnly = false;
					this.LookupCollectionViaSurveyQuestion_.Add((LookupEntity)entity);
					this.LookupCollectionViaSurveyQuestion_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaSurveyAnswer":
					this.OrganizationRoleUserCollectionViaSurveyAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaSurveyAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaSurveyAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaSurveyAnswer_":
					this.OrganizationRoleUserCollectionViaSurveyAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaSurveyAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaSurveyAnswer_.IsReadOnly = true;
					break;
				case "SurveyTemplateCollectionViaSurveyTemplateQuestion":
					this.SurveyTemplateCollectionViaSurveyTemplateQuestion.IsReadOnly = false;
					this.SurveyTemplateCollectionViaSurveyTemplateQuestion.Add((SurveyTemplateEntity)entity);
					this.SurveyTemplateCollectionViaSurveyTemplateQuestion.IsReadOnly = true;
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
			return SurveyQuestionEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(SurveyQuestionEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "Lookup":
					toReturn.Add(SurveyQuestionEntity.Relations.LookupEntityUsingGender);
					break;
				case "SurveyQuestion":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyQuestionEntityUsingIdParentId);
					break;
				case "SurveyAnswer":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyAnswerEntityUsingQuestionId);
					break;
				case "SurveyQuestion_":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyQuestionEntityUsingParentId);
					break;
				case "SurveyTemplateQuestion":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyTemplateQuestionEntityUsingQuestionId);
					break;
				case "EventCustomersCollectionViaSurveyAnswer":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyAnswerEntityUsingQuestionId, "SurveyQuestionEntity__", "SurveyAnswer_", JoinHint.None);
					toReturn.Add(SurveyAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "SurveyAnswer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaSurveyQuestion":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyQuestionEntityUsingParentId, "SurveyQuestionEntity__", "SurveyQuestion_", JoinHint.None);
					toReturn.Add(SurveyQuestionEntity.Relations.LookupEntityUsingGender, "SurveyQuestion_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaSurveyQuestion_":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyQuestionEntityUsingParentId, "SurveyQuestionEntity__", "SurveyQuestion_", JoinHint.None);
					toReturn.Add(SurveyQuestionEntity.Relations.LookupEntityUsingTypeId, "SurveyQuestion_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaSurveyAnswer":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyAnswerEntityUsingQuestionId, "SurveyQuestionEntity__", "SurveyAnswer_", JoinHint.None);
					toReturn.Add(SurveyAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "SurveyAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaSurveyAnswer_":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyAnswerEntityUsingQuestionId, "SurveyQuestionEntity__", "SurveyAnswer_", JoinHint.None);
					toReturn.Add(SurveyAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "SurveyAnswer_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaSurveyTemplateQuestion":
					toReturn.Add(SurveyQuestionEntity.Relations.SurveyTemplateQuestionEntityUsingQuestionId, "SurveyQuestionEntity__", "SurveyTemplateQuestion_", JoinHint.None);
					toReturn.Add(SurveyTemplateQuestionEntity.Relations.SurveyTemplateEntityUsingTemplateId, "SurveyTemplateQuestion_", string.Empty, JoinHint.None);
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
				case "SurveyQuestion":
					SetupSyncSurveyQuestion(relatedEntity);
					break;
				case "SurveyAnswer":
					this.SurveyAnswer.Add((SurveyAnswerEntity)relatedEntity);
					break;
				case "SurveyQuestion_":
					this.SurveyQuestion_.Add((SurveyQuestionEntity)relatedEntity);
					break;
				case "SurveyTemplateQuestion":
					this.SurveyTemplateQuestion.Add((SurveyTemplateQuestionEntity)relatedEntity);
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
				case "SurveyQuestion":
					DesetupSyncSurveyQuestion(false, true);
					break;
				case "SurveyAnswer":
					base.PerformRelatedEntityRemoval(this.SurveyAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SurveyQuestion_":
					base.PerformRelatedEntityRemoval(this.SurveyQuestion_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SurveyTemplateQuestion":
					base.PerformRelatedEntityRemoval(this.SurveyTemplateQuestion, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_surveyQuestion!=null)
			{
				toReturn.Add(_surveyQuestion);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.SurveyAnswer);
			toReturn.Add(this.SurveyQuestion_);
			toReturn.Add(this.SurveyTemplateQuestion);

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
				info.AddValue("_surveyAnswer", ((_surveyAnswer!=null) && (_surveyAnswer.Count>0) && !this.MarkedForDeletion)?_surveyAnswer:null);
				info.AddValue("_surveyQuestion_", ((_surveyQuestion_!=null) && (_surveyQuestion_.Count>0) && !this.MarkedForDeletion)?_surveyQuestion_:null);
				info.AddValue("_surveyTemplateQuestion", ((_surveyTemplateQuestion!=null) && (_surveyTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_surveyTemplateQuestion:null);
				info.AddValue("_eventCustomersCollectionViaSurveyAnswer", ((_eventCustomersCollectionViaSurveyAnswer!=null) && (_eventCustomersCollectionViaSurveyAnswer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaSurveyAnswer:null);
				info.AddValue("_lookupCollectionViaSurveyQuestion", ((_lookupCollectionViaSurveyQuestion!=null) && (_lookupCollectionViaSurveyQuestion.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaSurveyQuestion:null);
				info.AddValue("_lookupCollectionViaSurveyQuestion_", ((_lookupCollectionViaSurveyQuestion_!=null) && (_lookupCollectionViaSurveyQuestion_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaSurveyQuestion_:null);
				info.AddValue("_organizationRoleUserCollectionViaSurveyAnswer", ((_organizationRoleUserCollectionViaSurveyAnswer!=null) && (_organizationRoleUserCollectionViaSurveyAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaSurveyAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaSurveyAnswer_", ((_organizationRoleUserCollectionViaSurveyAnswer_!=null) && (_organizationRoleUserCollectionViaSurveyAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaSurveyAnswer_:null);
				info.AddValue("_surveyTemplateCollectionViaSurveyTemplateQuestion", ((_surveyTemplateCollectionViaSurveyTemplateQuestion!=null) && (_surveyTemplateCollectionViaSurveyTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaSurveyTemplateQuestion:null);
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_surveyQuestion", (!this.MarkedForDeletion?_surveyQuestion:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(SurveyQuestionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(SurveyQuestionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new SurveyQuestionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyAnswerFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyQuestionFields.ParentId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyTemplateQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaSurveyAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaSurveyAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "SurveyQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaSurveyQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaSurveyQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "SurveyQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaSurveyQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaSurveyQuestion_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "SurveyQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaSurveyAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaSurveyAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "SurveyQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaSurveyAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaSurveyAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "SurveyQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaSurveyTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaSurveyTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "SurveyQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Gender));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'SurveyQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyQuestionFields.Id, null, ComparisonOperator.Equal, this.ParentId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.SurveyQuestionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(SurveyQuestionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._surveyAnswer);
			collectionsQueue.Enqueue(this._surveyQuestion_);
			collectionsQueue.Enqueue(this._surveyTemplateQuestion);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaSurveyAnswer);
			collectionsQueue.Enqueue(this._lookupCollectionViaSurveyQuestion);
			collectionsQueue.Enqueue(this._lookupCollectionViaSurveyQuestion_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaSurveyAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaSurveyAnswer_);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaSurveyTemplateQuestion);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._surveyAnswer = (EntityCollection<SurveyAnswerEntity>) collectionsQueue.Dequeue();
			this._surveyQuestion_ = (EntityCollection<SurveyQuestionEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateQuestion = (EntityCollection<SurveyTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaSurveyAnswer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaSurveyQuestion = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaSurveyQuestion_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaSurveyAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaSurveyAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaSurveyTemplateQuestion = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._surveyAnswer != null)
			{
				return true;
			}
			if (this._surveyQuestion_ != null)
			{
				return true;
			}
			if (this._surveyTemplateQuestion != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaSurveyAnswer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaSurveyQuestion != null)
			{
				return true;
			}
			if (this._lookupCollectionViaSurveyQuestion_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaSurveyAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaSurveyAnswer_ != null)
			{
				return true;
			}
			if (this._surveyTemplateCollectionViaSurveyTemplateQuestion != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
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
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("SurveyQuestion", _surveyQuestion);
			toReturn.Add("SurveyAnswer", _surveyAnswer);
			toReturn.Add("SurveyQuestion_", _surveyQuestion_);
			toReturn.Add("SurveyTemplateQuestion", _surveyTemplateQuestion);
			toReturn.Add("EventCustomersCollectionViaSurveyAnswer", _eventCustomersCollectionViaSurveyAnswer);
			toReturn.Add("LookupCollectionViaSurveyQuestion", _lookupCollectionViaSurveyQuestion);
			toReturn.Add("LookupCollectionViaSurveyQuestion_", _lookupCollectionViaSurveyQuestion_);
			toReturn.Add("OrganizationRoleUserCollectionViaSurveyAnswer", _organizationRoleUserCollectionViaSurveyAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaSurveyAnswer_", _organizationRoleUserCollectionViaSurveyAnswer_);
			toReturn.Add("SurveyTemplateCollectionViaSurveyTemplateQuestion", _surveyTemplateCollectionViaSurveyTemplateQuestion);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_surveyAnswer!=null)
			{
				_surveyAnswer.ActiveContext = base.ActiveContext;
			}
			if(_surveyQuestion_!=null)
			{
				_surveyQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateQuestion!=null)
			{
				_surveyTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaSurveyAnswer!=null)
			{
				_eventCustomersCollectionViaSurveyAnswer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaSurveyQuestion!=null)
			{
				_lookupCollectionViaSurveyQuestion.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaSurveyQuestion_!=null)
			{
				_lookupCollectionViaSurveyQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaSurveyAnswer!=null)
			{
				_organizationRoleUserCollectionViaSurveyAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaSurveyAnswer_!=null)
			{
				_organizationRoleUserCollectionViaSurveyAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaSurveyTemplateQuestion!=null)
			{
				_surveyTemplateCollectionViaSurveyTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_surveyQuestion!=null)
			{
				_surveyQuestion.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_surveyAnswer = null;
			_surveyQuestion_ = null;
			_surveyTemplateQuestion = null;
			_eventCustomersCollectionViaSurveyAnswer = null;
			_lookupCollectionViaSurveyQuestion = null;
			_lookupCollectionViaSurveyQuestion_ = null;
			_organizationRoleUserCollectionViaSurveyAnswer = null;
			_organizationRoleUserCollectionViaSurveyAnswer_ = null;
			_surveyTemplateCollectionViaSurveyTemplateQuestion = null;
			_lookup_ = null;
			_lookup = null;
			_surveyQuestion = null;

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

			_fieldsCustomProperties.Add("ParentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValues", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValueDelimiter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Index", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", SurveyQuestionEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "SurveyQuestion_", resetFKFields, new int[] { (int)SurveyQuestionFieldIndex.TypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", SurveyQuestionEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", SurveyQuestionEntity.Relations.LookupEntityUsingGender, true, signalRelatedEntity, "SurveyQuestion", resetFKFields, new int[] { (int)SurveyQuestionFieldIndex.Gender } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", SurveyQuestionEntity.Relations.LookupEntityUsingGender, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _surveyQuestion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSurveyQuestion(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _surveyQuestion, new PropertyChangedEventHandler( OnSurveyQuestionPropertyChanged ), "SurveyQuestion", SurveyQuestionEntity.Relations.SurveyQuestionEntityUsingIdParentId, true, signalRelatedEntity, "SurveyQuestion_", resetFKFields, new int[] { (int)SurveyQuestionFieldIndex.ParentId } );		
			_surveyQuestion = null;
		}

		/// <summary> setups the sync logic for member _surveyQuestion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSurveyQuestion(IEntity2 relatedEntity)
		{
			if(_surveyQuestion!=relatedEntity)
			{
				DesetupSyncSurveyQuestion(true, true);
				_surveyQuestion = (SurveyQuestionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _surveyQuestion, new PropertyChangedEventHandler( OnSurveyQuestionPropertyChanged ), "SurveyQuestion", SurveyQuestionEntity.Relations.SurveyQuestionEntityUsingIdParentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSurveyQuestionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this SurveyQuestionEntity</param>
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
		public  static SurveyQuestionRelations Relations
		{
			get	{ return new SurveyQuestionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SurveyAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("SurveyAnswer")[0], (int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.SurveyAnswerEntity, 0, null, null, null, null, "SurveyAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyQuestion_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SurveyQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("SurveyQuestion_")[0], (int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.SurveyQuestionEntity, 0, null, null, null, null, "SurveyQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplateQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SurveyTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("SurveyTemplateQuestion")[0], (int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.SurveyTemplateQuestionEntity, 0, null, null, null, null, "SurveyTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaSurveyAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = SurveyQuestionEntity.Relations.SurveyAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "SurveyAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaSurveyAnswer"), null, "EventCustomersCollectionViaSurveyAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaSurveyQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = SurveyQuestionEntity.Relations.SurveyQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "SurveyQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaSurveyQuestion"), null, "LookupCollectionViaSurveyQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaSurveyQuestion_
		{
			get
			{
				IEntityRelation intermediateRelation = SurveyQuestionEntity.Relations.SurveyQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "SurveyQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaSurveyQuestion_"), null, "LookupCollectionViaSurveyQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaSurveyAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = SurveyQuestionEntity.Relations.SurveyAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "SurveyAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaSurveyAnswer"), null, "OrganizationRoleUserCollectionViaSurveyAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaSurveyAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = SurveyQuestionEntity.Relations.SurveyAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "SurveyAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaSurveyAnswer_"), null, "OrganizationRoleUserCollectionViaSurveyAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaSurveyTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = SurveyQuestionEntity.Relations.SurveyTemplateQuestionEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "SurveyTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaSurveyTemplateQuestion"), null, "SurveyTemplateCollectionViaSurveyTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyQuestion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SurveyQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("SurveyQuestion")[0], (int)Falcon.Data.EntityType.SurveyQuestionEntity, (int)Falcon.Data.EntityType.SurveyQuestionEntity, 0, null, null, null, null, "SurveyQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return SurveyQuestionEntity.CustomProperties;}
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
			get { return SurveyQuestionEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity SurveyQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSurveyQuestion"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)SurveyQuestionFieldIndex.Id, true); }
			set	{ SetValue((int)SurveyQuestionFieldIndex.Id, value); }
		}

		/// <summary> The Question property of the Entity SurveyQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSurveyQuestion"."Question"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Question
		{
			get { return (System.String)GetValue((int)SurveyQuestionFieldIndex.Question, true); }
			set	{ SetValue((int)SurveyQuestionFieldIndex.Question, value); }
		}

		/// <summary> The TypeId property of the Entity SurveyQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSurveyQuestion"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)SurveyQuestionFieldIndex.TypeId, true); }
			set	{ SetValue((int)SurveyQuestionFieldIndex.TypeId, value); }
		}

		/// <summary> The ParentId property of the Entity SurveyQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSurveyQuestion"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)SurveyQuestionFieldIndex.ParentId, false); }
			set	{ SetValue((int)SurveyQuestionFieldIndex.ParentId, value); }
		}

		/// <summary> The Gender property of the Entity SurveyQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSurveyQuestion"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Gender
		{
			get { return (System.Int64)GetValue((int)SurveyQuestionFieldIndex.Gender, true); }
			set	{ SetValue((int)SurveyQuestionFieldIndex.Gender, value); }
		}

		/// <summary> The ControlValues property of the Entity SurveyQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSurveyQuestion"."ControlValues"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValues
		{
			get { return (System.String)GetValue((int)SurveyQuestionFieldIndex.ControlValues, true); }
			set	{ SetValue((int)SurveyQuestionFieldIndex.ControlValues, value); }
		}

		/// <summary> The ControlValueDelimiter property of the Entity SurveyQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSurveyQuestion"."ControlValueDelimiter"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValueDelimiter
		{
			get { return (System.String)GetValue((int)SurveyQuestionFieldIndex.ControlValueDelimiter, true); }
			set	{ SetValue((int)SurveyQuestionFieldIndex.ControlValueDelimiter, value); }
		}

		/// <summary> The Index property of the Entity SurveyQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSurveyQuestion"."Index"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Index
		{
			get { return (System.Int32)GetValue((int)SurveyQuestionFieldIndex.Index, true); }
			set	{ SetValue((int)SurveyQuestionFieldIndex.Index, value); }
		}

		/// <summary> The IsActive property of the Entity SurveyQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSurveyQuestion"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)SurveyQuestionFieldIndex.IsActive, true); }
			set	{ SetValue((int)SurveyQuestionFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyAnswerEntity))]
		public virtual EntityCollection<SurveyAnswerEntity> SurveyAnswer
		{
			get
			{
				if(_surveyAnswer==null)
				{
					_surveyAnswer = new EntityCollection<SurveyAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyAnswerEntityFactory)));
					_surveyAnswer.SetContainingEntityInfo(this, "SurveyQuestion");
				}
				return _surveyAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyQuestionEntity))]
		public virtual EntityCollection<SurveyQuestionEntity> SurveyQuestion_
		{
			get
			{
				if(_surveyQuestion_==null)
				{
					_surveyQuestion_ = new EntityCollection<SurveyQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyQuestionEntityFactory)));
					_surveyQuestion_.SetContainingEntityInfo(this, "SurveyQuestion");
				}
				return _surveyQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyTemplateQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyTemplateQuestionEntity))]
		public virtual EntityCollection<SurveyTemplateQuestionEntity> SurveyTemplateQuestion
		{
			get
			{
				if(_surveyTemplateQuestion==null)
				{
					_surveyTemplateQuestion = new EntityCollection<SurveyTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateQuestionEntityFactory)));
					_surveyTemplateQuestion.SetContainingEntityInfo(this, "SurveyQuestion");
				}
				return _surveyTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaSurveyAnswer
		{
			get
			{
				if(_eventCustomersCollectionViaSurveyAnswer==null)
				{
					_eventCustomersCollectionViaSurveyAnswer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaSurveyAnswer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaSurveyAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaSurveyQuestion
		{
			get
			{
				if(_lookupCollectionViaSurveyQuestion==null)
				{
					_lookupCollectionViaSurveyQuestion = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaSurveyQuestion.IsReadOnly=true;
				}
				return _lookupCollectionViaSurveyQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaSurveyQuestion_
		{
			get
			{
				if(_lookupCollectionViaSurveyQuestion_==null)
				{
					_lookupCollectionViaSurveyQuestion_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaSurveyQuestion_.IsReadOnly=true;
				}
				return _lookupCollectionViaSurveyQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaSurveyAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaSurveyAnswer==null)
				{
					_organizationRoleUserCollectionViaSurveyAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaSurveyAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaSurveyAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaSurveyAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaSurveyAnswer_==null)
				{
					_organizationRoleUserCollectionViaSurveyAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaSurveyAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaSurveyAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyTemplateEntity))]
		public virtual EntityCollection<SurveyTemplateEntity> SurveyTemplateCollectionViaSurveyTemplateQuestion
		{
			get
			{
				if(_surveyTemplateCollectionViaSurveyTemplateQuestion==null)
				{
					_surveyTemplateCollectionViaSurveyTemplateQuestion = new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory)));
					_surveyTemplateCollectionViaSurveyTemplateQuestion.IsReadOnly=true;
				}
				return _surveyTemplateCollectionViaSurveyTemplateQuestion;
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
							_lookup_.UnsetRelatedEntity(this, "SurveyQuestion_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SurveyQuestion_");
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
							_lookup.UnsetRelatedEntity(this, "SurveyQuestion");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SurveyQuestion");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'SurveyQuestionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual SurveyQuestionEntity SurveyQuestion
		{
			get
			{
				return _surveyQuestion;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncSurveyQuestion(value);
				}
				else
				{
					if(value==null)
					{
						if(_surveyQuestion != null)
						{
							_surveyQuestion.UnsetRelatedEntity(this, "SurveyQuestion_");
						}
					}
					else
					{
						if(_surveyQuestion!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SurveyQuestion_");
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
			get { return (int)Falcon.Data.EntityType.SurveyQuestionEntity; }
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
