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
	/// Entity class which represents the entity 'FluConsentQuestion'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class FluConsentQuestionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<FluConsentAnswerEntity> _fluConsentAnswer;
		private EntityCollection<FluConsentQuestionEntity> _fluConsentQuestion_;
		private EntityCollection<FluConsentTemplateQuestionEntity> _fluConsentTemplateQuestion;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaFluConsentAnswer;
		private EntityCollection<FluConsentTemplateEntity> _fluConsentTemplateCollectionViaFluConsentTemplateQuestion;
		private EntityCollection<LookupEntity> _lookupCollectionViaFluConsentQuestion__;
		private EntityCollection<LookupEntity> _lookupCollectionViaFluConsentQuestion_;
		private EntityCollection<LookupEntity> _lookupCollectionViaFluConsentQuestion;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaFluConsentAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaFluConsentAnswer;
		private FluConsentQuestionEntity _fluConsentQuestion;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;
		private LookupEntity _lookup__;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name FluConsentQuestion</summary>
			public static readonly string FluConsentQuestion = "FluConsentQuestion";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Lookup__</summary>
			public static readonly string Lookup__ = "Lookup__";
			/// <summary>Member name FluConsentAnswer</summary>
			public static readonly string FluConsentAnswer = "FluConsentAnswer";
			/// <summary>Member name FluConsentQuestion_</summary>
			public static readonly string FluConsentQuestion_ = "FluConsentQuestion_";
			/// <summary>Member name FluConsentTemplateQuestion</summary>
			public static readonly string FluConsentTemplateQuestion = "FluConsentTemplateQuestion";
			/// <summary>Member name EventCustomersCollectionViaFluConsentAnswer</summary>
			public static readonly string EventCustomersCollectionViaFluConsentAnswer = "EventCustomersCollectionViaFluConsentAnswer";
			/// <summary>Member name FluConsentTemplateCollectionViaFluConsentTemplateQuestion</summary>
			public static readonly string FluConsentTemplateCollectionViaFluConsentTemplateQuestion = "FluConsentTemplateCollectionViaFluConsentTemplateQuestion";
			/// <summary>Member name LookupCollectionViaFluConsentQuestion__</summary>
			public static readonly string LookupCollectionViaFluConsentQuestion__ = "LookupCollectionViaFluConsentQuestion__";
			/// <summary>Member name LookupCollectionViaFluConsentQuestion_</summary>
			public static readonly string LookupCollectionViaFluConsentQuestion_ = "LookupCollectionViaFluConsentQuestion_";
			/// <summary>Member name LookupCollectionViaFluConsentQuestion</summary>
			public static readonly string LookupCollectionViaFluConsentQuestion = "LookupCollectionViaFluConsentQuestion";
			/// <summary>Member name OrganizationRoleUserCollectionViaFluConsentAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaFluConsentAnswer_ = "OrganizationRoleUserCollectionViaFluConsentAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaFluConsentAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaFluConsentAnswer = "OrganizationRoleUserCollectionViaFluConsentAnswer";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static FluConsentQuestionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public FluConsentQuestionEntity():base("FluConsentQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public FluConsentQuestionEntity(IEntityFields2 fields):base("FluConsentQuestionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this FluConsentQuestionEntity</param>
		public FluConsentQuestionEntity(IValidator validator):base("FluConsentQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for FluConsentQuestion which data should be fetched into this FluConsentQuestion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FluConsentQuestionEntity(System.Int64 id):base("FluConsentQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for FluConsentQuestion which data should be fetched into this FluConsentQuestion object</param>
		/// <param name="validator">The custom validator object for this FluConsentQuestionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FluConsentQuestionEntity(System.Int64 id, IValidator validator):base("FluConsentQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected FluConsentQuestionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_fluConsentAnswer = (EntityCollection<FluConsentAnswerEntity>)info.GetValue("_fluConsentAnswer", typeof(EntityCollection<FluConsentAnswerEntity>));
				_fluConsentQuestion_ = (EntityCollection<FluConsentQuestionEntity>)info.GetValue("_fluConsentQuestion_", typeof(EntityCollection<FluConsentQuestionEntity>));
				_fluConsentTemplateQuestion = (EntityCollection<FluConsentTemplateQuestionEntity>)info.GetValue("_fluConsentTemplateQuestion", typeof(EntityCollection<FluConsentTemplateQuestionEntity>));
				_eventCustomersCollectionViaFluConsentAnswer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaFluConsentAnswer", typeof(EntityCollection<EventCustomersEntity>));
				_fluConsentTemplateCollectionViaFluConsentTemplateQuestion = (EntityCollection<FluConsentTemplateEntity>)info.GetValue("_fluConsentTemplateCollectionViaFluConsentTemplateQuestion", typeof(EntityCollection<FluConsentTemplateEntity>));
				_lookupCollectionViaFluConsentQuestion__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaFluConsentQuestion__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaFluConsentQuestion_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaFluConsentQuestion_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaFluConsentQuestion = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaFluConsentQuestion", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaFluConsentAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaFluConsentAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaFluConsentAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaFluConsentAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_fluConsentQuestion = (FluConsentQuestionEntity)info.GetValue("_fluConsentQuestion", typeof(FluConsentQuestionEntity));
				if(_fluConsentQuestion!=null)
				{
					_fluConsentQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
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
				_lookup__ = (LookupEntity)info.GetValue("_lookup__", typeof(LookupEntity));
				if(_lookup__!=null)
				{
					_lookup__.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((FluConsentQuestionFieldIndex)fieldIndex)
			{
				case FluConsentQuestionFieldIndex.TypeId:
					DesetupSyncLookup_(true, false);
					break;
				case FluConsentQuestionFieldIndex.Gender:
					DesetupSyncLookup(true, false);
					break;
				case FluConsentQuestionFieldIndex.ParentId:
					DesetupSyncFluConsentQuestion(true, false);
					break;
				case FluConsentQuestionFieldIndex.FluConsentQuestionType:
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
				case "FluConsentQuestion":
					this.FluConsentQuestion = (FluConsentQuestionEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Lookup__":
					this.Lookup__ = (LookupEntity)entity;
					break;
				case "FluConsentAnswer":
					this.FluConsentAnswer.Add((FluConsentAnswerEntity)entity);
					break;
				case "FluConsentQuestion_":
					this.FluConsentQuestion_.Add((FluConsentQuestionEntity)entity);
					break;
				case "FluConsentTemplateQuestion":
					this.FluConsentTemplateQuestion.Add((FluConsentTemplateQuestionEntity)entity);
					break;
				case "EventCustomersCollectionViaFluConsentAnswer":
					this.EventCustomersCollectionViaFluConsentAnswer.IsReadOnly = false;
					this.EventCustomersCollectionViaFluConsentAnswer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaFluConsentAnswer.IsReadOnly = true;
					break;
				case "FluConsentTemplateCollectionViaFluConsentTemplateQuestion":
					this.FluConsentTemplateCollectionViaFluConsentTemplateQuestion.IsReadOnly = false;
					this.FluConsentTemplateCollectionViaFluConsentTemplateQuestion.Add((FluConsentTemplateEntity)entity);
					this.FluConsentTemplateCollectionViaFluConsentTemplateQuestion.IsReadOnly = true;
					break;
				case "LookupCollectionViaFluConsentQuestion__":
					this.LookupCollectionViaFluConsentQuestion__.IsReadOnly = false;
					this.LookupCollectionViaFluConsentQuestion__.Add((LookupEntity)entity);
					this.LookupCollectionViaFluConsentQuestion__.IsReadOnly = true;
					break;
				case "LookupCollectionViaFluConsentQuestion_":
					this.LookupCollectionViaFluConsentQuestion_.IsReadOnly = false;
					this.LookupCollectionViaFluConsentQuestion_.Add((LookupEntity)entity);
					this.LookupCollectionViaFluConsentQuestion_.IsReadOnly = true;
					break;
				case "LookupCollectionViaFluConsentQuestion":
					this.LookupCollectionViaFluConsentQuestion.IsReadOnly = false;
					this.LookupCollectionViaFluConsentQuestion.Add((LookupEntity)entity);
					this.LookupCollectionViaFluConsentQuestion.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaFluConsentAnswer_":
					this.OrganizationRoleUserCollectionViaFluConsentAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaFluConsentAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaFluConsentAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaFluConsentAnswer":
					this.OrganizationRoleUserCollectionViaFluConsentAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaFluConsentAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaFluConsentAnswer.IsReadOnly = true;
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
			return FluConsentQuestionEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "FluConsentQuestion":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingIdParentId);
					break;
				case "Lookup_":
					toReturn.Add(FluConsentQuestionEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "Lookup":
					toReturn.Add(FluConsentQuestionEntity.Relations.LookupEntityUsingGender);
					break;
				case "Lookup__":
					toReturn.Add(FluConsentQuestionEntity.Relations.LookupEntityUsingFluConsentQuestionType);
					break;
				case "FluConsentAnswer":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentAnswerEntityUsingQuestionId);
					break;
				case "FluConsentQuestion_":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingParentId);
					break;
				case "FluConsentTemplateQuestion":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentTemplateQuestionEntityUsingQuestionId);
					break;
				case "EventCustomersCollectionViaFluConsentAnswer":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentAnswerEntityUsingQuestionId, "FluConsentQuestionEntity__", "FluConsentAnswer_", JoinHint.None);
					toReturn.Add(FluConsentAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "FluConsentAnswer_", string.Empty, JoinHint.None);
					break;
				case "FluConsentTemplateCollectionViaFluConsentTemplateQuestion":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentTemplateQuestionEntityUsingQuestionId, "FluConsentQuestionEntity__", "FluConsentTemplateQuestion_", JoinHint.None);
					toReturn.Add(FluConsentTemplateQuestionEntity.Relations.FluConsentTemplateEntityUsingTemplateId, "FluConsentTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaFluConsentQuestion__":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingParentId, "FluConsentQuestionEntity__", "FluConsentQuestion_", JoinHint.None);
					toReturn.Add(FluConsentQuestionEntity.Relations.LookupEntityUsingFluConsentQuestionType, "FluConsentQuestion_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaFluConsentQuestion_":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingParentId, "FluConsentQuestionEntity__", "FluConsentQuestion_", JoinHint.None);
					toReturn.Add(FluConsentQuestionEntity.Relations.LookupEntityUsingTypeId, "FluConsentQuestion_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaFluConsentQuestion":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingParentId, "FluConsentQuestionEntity__", "FluConsentQuestion_", JoinHint.None);
					toReturn.Add(FluConsentQuestionEntity.Relations.LookupEntityUsingGender, "FluConsentQuestion_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaFluConsentAnswer_":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentAnswerEntityUsingQuestionId, "FluConsentQuestionEntity__", "FluConsentAnswer_", JoinHint.None);
					toReturn.Add(FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "FluConsentAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaFluConsentAnswer":
					toReturn.Add(FluConsentQuestionEntity.Relations.FluConsentAnswerEntityUsingQuestionId, "FluConsentQuestionEntity__", "FluConsentAnswer_", JoinHint.None);
					toReturn.Add(FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "FluConsentAnswer_", string.Empty, JoinHint.None);
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
				case "FluConsentQuestion":
					SetupSyncFluConsentQuestion(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "Lookup__":
					SetupSyncLookup__(relatedEntity);
					break;
				case "FluConsentAnswer":
					this.FluConsentAnswer.Add((FluConsentAnswerEntity)relatedEntity);
					break;
				case "FluConsentQuestion_":
					this.FluConsentQuestion_.Add((FluConsentQuestionEntity)relatedEntity);
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
				case "FluConsentQuestion":
					DesetupSyncFluConsentQuestion(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "Lookup__":
					DesetupSyncLookup__(false, true);
					break;
				case "FluConsentAnswer":
					base.PerformRelatedEntityRemoval(this.FluConsentAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "FluConsentQuestion_":
					base.PerformRelatedEntityRemoval(this.FluConsentQuestion_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_fluConsentQuestion!=null)
			{
				toReturn.Add(_fluConsentQuestion);
			}
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_lookup__!=null)
			{
				toReturn.Add(_lookup__);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.FluConsentAnswer);
			toReturn.Add(this.FluConsentQuestion_);
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
				info.AddValue("_fluConsentAnswer", ((_fluConsentAnswer!=null) && (_fluConsentAnswer.Count>0) && !this.MarkedForDeletion)?_fluConsentAnswer:null);
				info.AddValue("_fluConsentQuestion_", ((_fluConsentQuestion_!=null) && (_fluConsentQuestion_.Count>0) && !this.MarkedForDeletion)?_fluConsentQuestion_:null);
				info.AddValue("_fluConsentTemplateQuestion", ((_fluConsentTemplateQuestion!=null) && (_fluConsentTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateQuestion:null);
				info.AddValue("_eventCustomersCollectionViaFluConsentAnswer", ((_eventCustomersCollectionViaFluConsentAnswer!=null) && (_eventCustomersCollectionViaFluConsentAnswer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaFluConsentAnswer:null);
				info.AddValue("_fluConsentTemplateCollectionViaFluConsentTemplateQuestion", ((_fluConsentTemplateCollectionViaFluConsentTemplateQuestion!=null) && (_fluConsentTemplateCollectionViaFluConsentTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateCollectionViaFluConsentTemplateQuestion:null);
				info.AddValue("_lookupCollectionViaFluConsentQuestion__", ((_lookupCollectionViaFluConsentQuestion__!=null) && (_lookupCollectionViaFluConsentQuestion__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaFluConsentQuestion__:null);
				info.AddValue("_lookupCollectionViaFluConsentQuestion_", ((_lookupCollectionViaFluConsentQuestion_!=null) && (_lookupCollectionViaFluConsentQuestion_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaFluConsentQuestion_:null);
				info.AddValue("_lookupCollectionViaFluConsentQuestion", ((_lookupCollectionViaFluConsentQuestion!=null) && (_lookupCollectionViaFluConsentQuestion.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaFluConsentQuestion:null);
				info.AddValue("_organizationRoleUserCollectionViaFluConsentAnswer_", ((_organizationRoleUserCollectionViaFluConsentAnswer_!=null) && (_organizationRoleUserCollectionViaFluConsentAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaFluConsentAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaFluConsentAnswer", ((_organizationRoleUserCollectionViaFluConsentAnswer!=null) && (_organizationRoleUserCollectionViaFluConsentAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaFluConsentAnswer:null);
				info.AddValue("_fluConsentQuestion", (!this.MarkedForDeletion?_fluConsentQuestion:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_lookup__", (!this.MarkedForDeletion?_lookup__:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(FluConsentQuestionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(FluConsentQuestionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new FluConsentQuestionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentAnswerFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.ParentId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaFluConsentAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaFluConsentAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateCollectionViaFluConsentTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentTemplateCollectionViaFluConsentTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaFluConsentQuestion__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaFluConsentQuestion__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaFluConsentQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaFluConsentQuestion_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaFluConsentQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaFluConsentQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaFluConsentAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaFluConsentAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaFluConsentAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaFluConsentAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "FluConsentQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'FluConsentQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.Id, null, ComparisonOperator.Equal, this.ParentId));
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
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.FluConsentQuestionType));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.FluConsentQuestionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._fluConsentAnswer);
			collectionsQueue.Enqueue(this._fluConsentQuestion_);
			collectionsQueue.Enqueue(this._fluConsentTemplateQuestion);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaFluConsentAnswer);
			collectionsQueue.Enqueue(this._fluConsentTemplateCollectionViaFluConsentTemplateQuestion);
			collectionsQueue.Enqueue(this._lookupCollectionViaFluConsentQuestion__);
			collectionsQueue.Enqueue(this._lookupCollectionViaFluConsentQuestion_);
			collectionsQueue.Enqueue(this._lookupCollectionViaFluConsentQuestion);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaFluConsentAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaFluConsentAnswer);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._fluConsentAnswer = (EntityCollection<FluConsentAnswerEntity>) collectionsQueue.Dequeue();
			this._fluConsentQuestion_ = (EntityCollection<FluConsentQuestionEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateQuestion = (EntityCollection<FluConsentTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaFluConsentAnswer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateCollectionViaFluConsentTemplateQuestion = (EntityCollection<FluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaFluConsentQuestion__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaFluConsentQuestion_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaFluConsentQuestion = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaFluConsentAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaFluConsentAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._fluConsentAnswer != null)
			{
				return true;
			}
			if (this._fluConsentQuestion_ != null)
			{
				return true;
			}
			if (this._fluConsentTemplateQuestion != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaFluConsentAnswer != null)
			{
				return true;
			}
			if (this._fluConsentTemplateCollectionViaFluConsentTemplateQuestion != null)
			{
				return true;
			}
			if (this._lookupCollectionViaFluConsentQuestion__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaFluConsentQuestion_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaFluConsentQuestion != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaFluConsentAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaFluConsentAnswer != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
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
			toReturn.Add("FluConsentQuestion", _fluConsentQuestion);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Lookup__", _lookup__);
			toReturn.Add("FluConsentAnswer", _fluConsentAnswer);
			toReturn.Add("FluConsentQuestion_", _fluConsentQuestion_);
			toReturn.Add("FluConsentTemplateQuestion", _fluConsentTemplateQuestion);
			toReturn.Add("EventCustomersCollectionViaFluConsentAnswer", _eventCustomersCollectionViaFluConsentAnswer);
			toReturn.Add("FluConsentTemplateCollectionViaFluConsentTemplateQuestion", _fluConsentTemplateCollectionViaFluConsentTemplateQuestion);
			toReturn.Add("LookupCollectionViaFluConsentQuestion__", _lookupCollectionViaFluConsentQuestion__);
			toReturn.Add("LookupCollectionViaFluConsentQuestion_", _lookupCollectionViaFluConsentQuestion_);
			toReturn.Add("LookupCollectionViaFluConsentQuestion", _lookupCollectionViaFluConsentQuestion);
			toReturn.Add("OrganizationRoleUserCollectionViaFluConsentAnswer_", _organizationRoleUserCollectionViaFluConsentAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaFluConsentAnswer", _organizationRoleUserCollectionViaFluConsentAnswer);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_fluConsentAnswer!=null)
			{
				_fluConsentAnswer.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentQuestion_!=null)
			{
				_fluConsentQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateQuestion!=null)
			{
				_fluConsentTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaFluConsentAnswer!=null)
			{
				_eventCustomersCollectionViaFluConsentAnswer.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateCollectionViaFluConsentTemplateQuestion!=null)
			{
				_fluConsentTemplateCollectionViaFluConsentTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaFluConsentQuestion__!=null)
			{
				_lookupCollectionViaFluConsentQuestion__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaFluConsentQuestion_!=null)
			{
				_lookupCollectionViaFluConsentQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaFluConsentQuestion!=null)
			{
				_lookupCollectionViaFluConsentQuestion.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaFluConsentAnswer_!=null)
			{
				_organizationRoleUserCollectionViaFluConsentAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaFluConsentAnswer!=null)
			{
				_organizationRoleUserCollectionViaFluConsentAnswer.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentQuestion!=null)
			{
				_fluConsentQuestion.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_lookup__!=null)
			{
				_lookup__.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_fluConsentAnswer = null;
			_fluConsentQuestion_ = null;
			_fluConsentTemplateQuestion = null;
			_eventCustomersCollectionViaFluConsentAnswer = null;
			_fluConsentTemplateCollectionViaFluConsentTemplateQuestion = null;
			_lookupCollectionViaFluConsentQuestion__ = null;
			_lookupCollectionViaFluConsentQuestion_ = null;
			_lookupCollectionViaFluConsentQuestion = null;
			_organizationRoleUserCollectionViaFluConsentAnswer_ = null;
			_organizationRoleUserCollectionViaFluConsentAnswer = null;
			_fluConsentQuestion = null;
			_lookup_ = null;
			_lookup = null;
			_lookup__ = null;

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

			_fieldsCustomProperties.Add("ParentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValues", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValueDelimiter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Index", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FluConsentQuestionType", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _fluConsentQuestion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFluConsentQuestion(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _fluConsentQuestion, new PropertyChangedEventHandler( OnFluConsentQuestionPropertyChanged ), "FluConsentQuestion", FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingIdParentId, true, signalRelatedEntity, "FluConsentQuestion_", resetFKFields, new int[] { (int)FluConsentQuestionFieldIndex.ParentId } );		
			_fluConsentQuestion = null;
		}

		/// <summary> setups the sync logic for member _fluConsentQuestion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFluConsentQuestion(IEntity2 relatedEntity)
		{
			if(_fluConsentQuestion!=relatedEntity)
			{
				DesetupSyncFluConsentQuestion(true, true);
				_fluConsentQuestion = (FluConsentQuestionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _fluConsentQuestion, new PropertyChangedEventHandler( OnFluConsentQuestionPropertyChanged ), "FluConsentQuestion", FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingIdParentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFluConsentQuestionPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", FluConsentQuestionEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "FluConsentQuestion_", resetFKFields, new int[] { (int)FluConsentQuestionFieldIndex.TypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", FluConsentQuestionEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", FluConsentQuestionEntity.Relations.LookupEntityUsingGender, true, signalRelatedEntity, "FluConsentQuestion", resetFKFields, new int[] { (int)FluConsentQuestionFieldIndex.Gender } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", FluConsentQuestionEntity.Relations.LookupEntityUsingGender, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", FluConsentQuestionEntity.Relations.LookupEntityUsingFluConsentQuestionType, true, signalRelatedEntity, "FluConsentQuestion__", resetFKFields, new int[] { (int)FluConsentQuestionFieldIndex.FluConsentQuestionType } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", FluConsentQuestionEntity.Relations.LookupEntityUsingFluConsentQuestionType, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this FluConsentQuestionEntity</param>
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
		public  static FluConsentQuestionRelations Relations
		{
			get	{ return new FluConsentQuestionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FluConsentAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("FluConsentAnswer")[0], (int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.FluConsentAnswerEntity, 0, null, null, null, null, "FluConsentAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentQuestion_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FluConsentQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("FluConsentQuestion_")[0], (int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.FluConsentQuestionEntity, 0, null, null, null, null, "FluConsentQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("FluConsentTemplateQuestion")[0], (int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.FluConsentTemplateQuestionEntity, 0, null, null, null, null, "FluConsentTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaFluConsentAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentQuestionEntity.Relations.FluConsentAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaFluConsentAnswer"), null, "EventCustomersCollectionViaFluConsentAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateCollectionViaFluConsentTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentQuestionEntity.Relations.FluConsentTemplateQuestionEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, GetRelationsForField("FluConsentTemplateCollectionViaFluConsentTemplateQuestion"), null, "FluConsentTemplateCollectionViaFluConsentTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaFluConsentQuestion__
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaFluConsentQuestion__"), null, "LookupCollectionViaFluConsentQuestion__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaFluConsentQuestion_
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaFluConsentQuestion_"), null, "LookupCollectionViaFluConsentQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaFluConsentQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentQuestionEntity.Relations.FluConsentQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaFluConsentQuestion"), null, "LookupCollectionViaFluConsentQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaFluConsentAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentQuestionEntity.Relations.FluConsentAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaFluConsentAnswer_"), null, "OrganizationRoleUserCollectionViaFluConsentAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaFluConsentAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = FluConsentQuestionEntity.Relations.FluConsentAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaFluConsentAnswer"), null, "OrganizationRoleUserCollectionViaFluConsentAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentQuestion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("FluConsentQuestion")[0], (int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.FluConsentQuestionEntity, 0, null, null, null, null, "FluConsentQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup__")[0], (int)Falcon.Data.EntityType.FluConsentQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return FluConsentQuestionEntity.CustomProperties;}
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
			get { return FluConsentQuestionEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity FluConsentQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentQuestion"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)FluConsentQuestionFieldIndex.Id, true); }
			set	{ SetValue((int)FluConsentQuestionFieldIndex.Id, value); }
		}

		/// <summary> The Question property of the Entity FluConsentQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentQuestion"."Question"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Question
		{
			get { return (System.String)GetValue((int)FluConsentQuestionFieldIndex.Question, true); }
			set	{ SetValue((int)FluConsentQuestionFieldIndex.Question, value); }
		}

		/// <summary> The TypeId property of the Entity FluConsentQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentQuestion"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)FluConsentQuestionFieldIndex.TypeId, true); }
			set	{ SetValue((int)FluConsentQuestionFieldIndex.TypeId, value); }
		}

		/// <summary> The Gender property of the Entity FluConsentQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentQuestion"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Gender
		{
			get { return (System.Int64)GetValue((int)FluConsentQuestionFieldIndex.Gender, true); }
			set	{ SetValue((int)FluConsentQuestionFieldIndex.Gender, value); }
		}

		/// <summary> The ParentId property of the Entity FluConsentQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentQuestion"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)FluConsentQuestionFieldIndex.ParentId, false); }
			set	{ SetValue((int)FluConsentQuestionFieldIndex.ParentId, value); }
		}

		/// <summary> The ControlValues property of the Entity FluConsentQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentQuestion"."ControlValues"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValues
		{
			get { return (System.String)GetValue((int)FluConsentQuestionFieldIndex.ControlValues, true); }
			set	{ SetValue((int)FluConsentQuestionFieldIndex.ControlValues, value); }
		}

		/// <summary> The ControlValueDelimiter property of the Entity FluConsentQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentQuestion"."ControlValueDelimiter"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValueDelimiter
		{
			get { return (System.String)GetValue((int)FluConsentQuestionFieldIndex.ControlValueDelimiter, true); }
			set	{ SetValue((int)FluConsentQuestionFieldIndex.ControlValueDelimiter, value); }
		}

		/// <summary> The Index property of the Entity FluConsentQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentQuestion"."Index"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Index
		{
			get { return (System.Int64)GetValue((int)FluConsentQuestionFieldIndex.Index, true); }
			set	{ SetValue((int)FluConsentQuestionFieldIndex.Index, value); }
		}

		/// <summary> The FluConsentQuestionType property of the Entity FluConsentQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentQuestion"."FluConsentQuestionType"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 FluConsentQuestionType
		{
			get { return (System.Int64)GetValue((int)FluConsentQuestionFieldIndex.FluConsentQuestionType, true); }
			set	{ SetValue((int)FluConsentQuestionFieldIndex.FluConsentQuestionType, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentAnswerEntity))]
		public virtual EntityCollection<FluConsentAnswerEntity> FluConsentAnswer
		{
			get
			{
				if(_fluConsentAnswer==null)
				{
					_fluConsentAnswer = new EntityCollection<FluConsentAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentAnswerEntityFactory)));
					_fluConsentAnswer.SetContainingEntityInfo(this, "FluConsentQuestion");
				}
				return _fluConsentAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentQuestionEntity))]
		public virtual EntityCollection<FluConsentQuestionEntity> FluConsentQuestion_
		{
			get
			{
				if(_fluConsentQuestion_==null)
				{
					_fluConsentQuestion_ = new EntityCollection<FluConsentQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory)));
					_fluConsentQuestion_.SetContainingEntityInfo(this, "FluConsentQuestion");
				}
				return _fluConsentQuestion_;
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
					_fluConsentTemplateQuestion.SetContainingEntityInfo(this, "FluConsentQuestion");
				}
				return _fluConsentTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaFluConsentAnswer
		{
			get
			{
				if(_eventCustomersCollectionViaFluConsentAnswer==null)
				{
					_eventCustomersCollectionViaFluConsentAnswer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaFluConsentAnswer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaFluConsentAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentTemplateEntity))]
		public virtual EntityCollection<FluConsentTemplateEntity> FluConsentTemplateCollectionViaFluConsentTemplateQuestion
		{
			get
			{
				if(_fluConsentTemplateCollectionViaFluConsentTemplateQuestion==null)
				{
					_fluConsentTemplateCollectionViaFluConsentTemplateQuestion = new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory)));
					_fluConsentTemplateCollectionViaFluConsentTemplateQuestion.IsReadOnly=true;
				}
				return _fluConsentTemplateCollectionViaFluConsentTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaFluConsentQuestion__
		{
			get
			{
				if(_lookupCollectionViaFluConsentQuestion__==null)
				{
					_lookupCollectionViaFluConsentQuestion__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaFluConsentQuestion__.IsReadOnly=true;
				}
				return _lookupCollectionViaFluConsentQuestion__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaFluConsentQuestion_
		{
			get
			{
				if(_lookupCollectionViaFluConsentQuestion_==null)
				{
					_lookupCollectionViaFluConsentQuestion_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaFluConsentQuestion_.IsReadOnly=true;
				}
				return _lookupCollectionViaFluConsentQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaFluConsentQuestion
		{
			get
			{
				if(_lookupCollectionViaFluConsentQuestion==null)
				{
					_lookupCollectionViaFluConsentQuestion = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaFluConsentQuestion.IsReadOnly=true;
				}
				return _lookupCollectionViaFluConsentQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaFluConsentAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaFluConsentAnswer_==null)
				{
					_organizationRoleUserCollectionViaFluConsentAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaFluConsentAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaFluConsentAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaFluConsentAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaFluConsentAnswer==null)
				{
					_organizationRoleUserCollectionViaFluConsentAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaFluConsentAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaFluConsentAnswer;
			}
		}

		/// <summary> Gets / sets related entity of type 'FluConsentQuestionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FluConsentQuestionEntity FluConsentQuestion
		{
			get
			{
				return _fluConsentQuestion;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFluConsentQuestion(value);
				}
				else
				{
					if(value==null)
					{
						if(_fluConsentQuestion != null)
						{
							_fluConsentQuestion.UnsetRelatedEntity(this, "FluConsentQuestion_");
						}
					}
					else
					{
						if(_fluConsentQuestion!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentQuestion_");
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
							_lookup_.UnsetRelatedEntity(this, "FluConsentQuestion_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentQuestion_");
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
							_lookup.UnsetRelatedEntity(this, "FluConsentQuestion");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentQuestion");
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
							_lookup__.UnsetRelatedEntity(this, "FluConsentQuestion__");
						}
					}
					else
					{
						if(_lookup__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentQuestion__");
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
			get { return (int)Falcon.Data.EntityType.FluConsentQuestionEntity; }
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
