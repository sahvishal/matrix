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
	/// Entity class which represents the entity 'MedicareQuestion'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MedicareQuestionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerMedicareQuestionAnswerEntity> _customerMedicareQuestionAnswer;
		private EntityCollection<MedicareGroupDependencyRuleEntity> _medicareGroupDependencyRule;
		private EntityCollection<MedicareQuestionEntity> _medicareQuestion_;
		private EntityCollection<MedicareQuestionDependencyRuleEntity> _medicareQuestionDependencyRule_;
		private EntityCollection<MedicareQuestionDependencyRuleEntity> _medicareQuestionDependencyRule;
		private EntityCollection<MedicareQuestionsRemarksEntity> _medicareQuestionsRemarks__;
		private EntityCollection<MedicareQuestionsRemarksEntity> _medicareQuestionsRemarks_;
		private EntityCollection<MedicareQuestionsRemarksEntity> _medicareQuestionsRemarks;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCustomerMedicareQuestionAnswer;
		private EntityCollection<LookupEntity> _lookupCollectionViaMedicareQuestion;
		private EntityCollection<MedicareQuestionGroupEntity> _medicareQuestionGroupCollectionViaMedicareQuestion;
		private EntityCollection<MedicareQuestionGroupEntity> _medicareQuestionGroupCollectionViaMedicareGroupDependencyRule;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer;
		private LookupEntity _lookup;
		private MedicareQuestionEntity _medicareQuestion;
		private MedicareQuestionGroupEntity _medicareQuestionGroup;

		
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
			/// <summary>Member name MedicareQuestion</summary>
			public static readonly string MedicareQuestion = "MedicareQuestion";
			/// <summary>Member name MedicareQuestionGroup</summary>
			public static readonly string MedicareQuestionGroup = "MedicareQuestionGroup";
			/// <summary>Member name CustomerMedicareQuestionAnswer</summary>
			public static readonly string CustomerMedicareQuestionAnswer = "CustomerMedicareQuestionAnswer";
			/// <summary>Member name MedicareGroupDependencyRule</summary>
			public static readonly string MedicareGroupDependencyRule = "MedicareGroupDependencyRule";
			/// <summary>Member name MedicareQuestion_</summary>
			public static readonly string MedicareQuestion_ = "MedicareQuestion_";
			/// <summary>Member name MedicareQuestionDependencyRule_</summary>
			public static readonly string MedicareQuestionDependencyRule_ = "MedicareQuestionDependencyRule_";
			/// <summary>Member name MedicareQuestionDependencyRule</summary>
			public static readonly string MedicareQuestionDependencyRule = "MedicareQuestionDependencyRule";
			/// <summary>Member name MedicareQuestionsRemarks__</summary>
			public static readonly string MedicareQuestionsRemarks__ = "MedicareQuestionsRemarks__";
			/// <summary>Member name MedicareQuestionsRemarks_</summary>
			public static readonly string MedicareQuestionsRemarks_ = "MedicareQuestionsRemarks_";
			/// <summary>Member name MedicareQuestionsRemarks</summary>
			public static readonly string MedicareQuestionsRemarks = "MedicareQuestionsRemarks";
			/// <summary>Member name EventCustomersCollectionViaCustomerMedicareQuestionAnswer</summary>
			public static readonly string EventCustomersCollectionViaCustomerMedicareQuestionAnswer = "EventCustomersCollectionViaCustomerMedicareQuestionAnswer";
			/// <summary>Member name LookupCollectionViaMedicareQuestion</summary>
			public static readonly string LookupCollectionViaMedicareQuestion = "LookupCollectionViaMedicareQuestion";
			/// <summary>Member name MedicareQuestionGroupCollectionViaMedicareQuestion</summary>
			public static readonly string MedicareQuestionGroupCollectionViaMedicareQuestion = "MedicareQuestionGroupCollectionViaMedicareQuestion";
			/// <summary>Member name MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule</summary>
			public static readonly string MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule = "MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = "OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MedicareQuestionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MedicareQuestionEntity():base("MedicareQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MedicareQuestionEntity(IEntityFields2 fields):base("MedicareQuestionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MedicareQuestionEntity</param>
		public MedicareQuestionEntity(IValidator validator):base("MedicareQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="questionId">PK value for MedicareQuestion which data should be fetched into this MedicareQuestion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicareQuestionEntity(System.Int64 questionId):base("MedicareQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.QuestionId = questionId;
		}

		/// <summary> CTor</summary>
		/// <param name="questionId">PK value for MedicareQuestion which data should be fetched into this MedicareQuestion object</param>
		/// <param name="validator">The custom validator object for this MedicareQuestionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicareQuestionEntity(System.Int64 questionId, IValidator validator):base("MedicareQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.QuestionId = questionId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MedicareQuestionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerMedicareQuestionAnswer = (EntityCollection<CustomerMedicareQuestionAnswerEntity>)info.GetValue("_customerMedicareQuestionAnswer", typeof(EntityCollection<CustomerMedicareQuestionAnswerEntity>));
				_medicareGroupDependencyRule = (EntityCollection<MedicareGroupDependencyRuleEntity>)info.GetValue("_medicareGroupDependencyRule", typeof(EntityCollection<MedicareGroupDependencyRuleEntity>));
				_medicareQuestion_ = (EntityCollection<MedicareQuestionEntity>)info.GetValue("_medicareQuestion_", typeof(EntityCollection<MedicareQuestionEntity>));
				_medicareQuestionDependencyRule_ = (EntityCollection<MedicareQuestionDependencyRuleEntity>)info.GetValue("_medicareQuestionDependencyRule_", typeof(EntityCollection<MedicareQuestionDependencyRuleEntity>));
				_medicareQuestionDependencyRule = (EntityCollection<MedicareQuestionDependencyRuleEntity>)info.GetValue("_medicareQuestionDependencyRule", typeof(EntityCollection<MedicareQuestionDependencyRuleEntity>));
				_medicareQuestionsRemarks__ = (EntityCollection<MedicareQuestionsRemarksEntity>)info.GetValue("_medicareQuestionsRemarks__", typeof(EntityCollection<MedicareQuestionsRemarksEntity>));
				_medicareQuestionsRemarks_ = (EntityCollection<MedicareQuestionsRemarksEntity>)info.GetValue("_medicareQuestionsRemarks_", typeof(EntityCollection<MedicareQuestionsRemarksEntity>));
				_medicareQuestionsRemarks = (EntityCollection<MedicareQuestionsRemarksEntity>)info.GetValue("_medicareQuestionsRemarks", typeof(EntityCollection<MedicareQuestionsRemarksEntity>));
				_eventCustomersCollectionViaCustomerMedicareQuestionAnswer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCustomerMedicareQuestionAnswer", typeof(EntityCollection<EventCustomersEntity>));
				_lookupCollectionViaMedicareQuestion = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaMedicareQuestion", typeof(EntityCollection<LookupEntity>));
				_medicareQuestionGroupCollectionViaMedicareQuestion = (EntityCollection<MedicareQuestionGroupEntity>)info.GetValue("_medicareQuestionGroupCollectionViaMedicareQuestion", typeof(EntityCollection<MedicareQuestionGroupEntity>));
				_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule = (EntityCollection<MedicareQuestionGroupEntity>)info.GetValue("_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule", typeof(EntityCollection<MedicareQuestionGroupEntity>));
				_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_medicareQuestion = (MedicareQuestionEntity)info.GetValue("_medicareQuestion", typeof(MedicareQuestionEntity));
				if(_medicareQuestion!=null)
				{
					_medicareQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_medicareQuestionGroup = (MedicareQuestionGroupEntity)info.GetValue("_medicareQuestionGroup", typeof(MedicareQuestionGroupEntity));
				if(_medicareQuestionGroup!=null)
				{
					_medicareQuestionGroup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MedicareQuestionFieldIndex)fieldIndex)
			{
				case MedicareQuestionFieldIndex.GroupId:
					DesetupSyncMedicareQuestionGroup(true, false);
					break;
				case MedicareQuestionFieldIndex.ControlType:
					DesetupSyncLookup(true, false);
					break;
				case MedicareQuestionFieldIndex.ParentQuestionId:
					DesetupSyncMedicareQuestion(true, false);
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
				case "MedicareQuestion":
					this.MedicareQuestion = (MedicareQuestionEntity)entity;
					break;
				case "MedicareQuestionGroup":
					this.MedicareQuestionGroup = (MedicareQuestionGroupEntity)entity;
					break;
				case "CustomerMedicareQuestionAnswer":
					this.CustomerMedicareQuestionAnswer.Add((CustomerMedicareQuestionAnswerEntity)entity);
					break;
				case "MedicareGroupDependencyRule":
					this.MedicareGroupDependencyRule.Add((MedicareGroupDependencyRuleEntity)entity);
					break;
				case "MedicareQuestion_":
					this.MedicareQuestion_.Add((MedicareQuestionEntity)entity);
					break;
				case "MedicareQuestionDependencyRule_":
					this.MedicareQuestionDependencyRule_.Add((MedicareQuestionDependencyRuleEntity)entity);
					break;
				case "MedicareQuestionDependencyRule":
					this.MedicareQuestionDependencyRule.Add((MedicareQuestionDependencyRuleEntity)entity);
					break;
				case "MedicareQuestionsRemarks__":
					this.MedicareQuestionsRemarks__.Add((MedicareQuestionsRemarksEntity)entity);
					break;
				case "MedicareQuestionsRemarks_":
					this.MedicareQuestionsRemarks_.Add((MedicareQuestionsRemarksEntity)entity);
					break;
				case "MedicareQuestionsRemarks":
					this.MedicareQuestionsRemarks.Add((MedicareQuestionsRemarksEntity)entity);
					break;
				case "EventCustomersCollectionViaCustomerMedicareQuestionAnswer":
					this.EventCustomersCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly = false;
					this.EventCustomersCollectionViaCustomerMedicareQuestionAnswer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly = true;
					break;
				case "LookupCollectionViaMedicareQuestion":
					this.LookupCollectionViaMedicareQuestion.IsReadOnly = false;
					this.LookupCollectionViaMedicareQuestion.Add((LookupEntity)entity);
					this.LookupCollectionViaMedicareQuestion.IsReadOnly = true;
					break;
				case "MedicareQuestionGroupCollectionViaMedicareQuestion":
					this.MedicareQuestionGroupCollectionViaMedicareQuestion.IsReadOnly = false;
					this.MedicareQuestionGroupCollectionViaMedicareQuestion.Add((MedicareQuestionGroupEntity)entity);
					this.MedicareQuestionGroupCollectionViaMedicareQuestion.IsReadOnly = true;
					break;
				case "MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule":
					this.MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule.IsReadOnly = false;
					this.MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule.Add((MedicareQuestionGroupEntity)entity);
					this.MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer":
					this.OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly = true;
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
			return MedicareQuestionEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(MedicareQuestionEntity.Relations.LookupEntityUsingControlType);
					break;
				case "MedicareQuestion":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionEntityUsingQuestionIdParentQuestionId);
					break;
				case "MedicareQuestionGroup":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionGroupEntityUsingGroupId);
					break;
				case "CustomerMedicareQuestionAnswer":
					toReturn.Add(MedicareQuestionEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingQuestionId);
					break;
				case "MedicareGroupDependencyRule":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareGroupDependencyRuleEntityUsingQuestionId);
					break;
				case "MedicareQuestion_":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionEntityUsingParentQuestionId);
					break;
				case "MedicareQuestionDependencyRule_":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionDependencyRuleEntityUsingDependentQuestionId);
					break;
				case "MedicareQuestionDependencyRule":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionDependencyRuleEntityUsingQuestionId);
					break;
				case "MedicareQuestionsRemarks__":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionsRemarksEntityUsingCombinedQuestionId);
					break;
				case "MedicareQuestionsRemarks_":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionsRemarksEntityUsingDependentQuestionId);
					break;
				case "MedicareQuestionsRemarks":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionsRemarksEntityUsingQuestionId);
					break;
				case "EventCustomersCollectionViaCustomerMedicareQuestionAnswer":
					toReturn.Add(MedicareQuestionEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingQuestionId, "MedicareQuestionEntity__", "CustomerMedicareQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerMedicareQuestionAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CustomerMedicareQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaMedicareQuestion":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionEntityUsingParentQuestionId, "MedicareQuestionEntity__", "MedicareQuestion_", JoinHint.None);
					toReturn.Add(MedicareQuestionEntity.Relations.LookupEntityUsingControlType, "MedicareQuestion_", string.Empty, JoinHint.None);
					break;
				case "MedicareQuestionGroupCollectionViaMedicareQuestion":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionEntityUsingParentQuestionId, "MedicareQuestionEntity__", "MedicareQuestion_", JoinHint.None);
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareQuestionGroupEntityUsingGroupId, "MedicareQuestion_", string.Empty, JoinHint.None);
					break;
				case "MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule":
					toReturn.Add(MedicareQuestionEntity.Relations.MedicareGroupDependencyRuleEntityUsingQuestionId, "MedicareQuestionEntity__", "MedicareGroupDependencyRule_", JoinHint.None);
					toReturn.Add(MedicareGroupDependencyRuleEntity.Relations.MedicareQuestionGroupEntityUsingDependentGroupId, "MedicareGroupDependencyRule_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer":
					toReturn.Add(MedicareQuestionEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingQuestionId, "MedicareQuestionEntity__", "CustomerMedicareQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerMedicareQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreateBy, "CustomerMedicareQuestionAnswer_", string.Empty, JoinHint.None);
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
				case "MedicareQuestion":
					SetupSyncMedicareQuestion(relatedEntity);
					break;
				case "MedicareQuestionGroup":
					SetupSyncMedicareQuestionGroup(relatedEntity);
					break;
				case "CustomerMedicareQuestionAnswer":
					this.CustomerMedicareQuestionAnswer.Add((CustomerMedicareQuestionAnswerEntity)relatedEntity);
					break;
				case "MedicareGroupDependencyRule":
					this.MedicareGroupDependencyRule.Add((MedicareGroupDependencyRuleEntity)relatedEntity);
					break;
				case "MedicareQuestion_":
					this.MedicareQuestion_.Add((MedicareQuestionEntity)relatedEntity);
					break;
				case "MedicareQuestionDependencyRule_":
					this.MedicareQuestionDependencyRule_.Add((MedicareQuestionDependencyRuleEntity)relatedEntity);
					break;
				case "MedicareQuestionDependencyRule":
					this.MedicareQuestionDependencyRule.Add((MedicareQuestionDependencyRuleEntity)relatedEntity);
					break;
				case "MedicareQuestionsRemarks__":
					this.MedicareQuestionsRemarks__.Add((MedicareQuestionsRemarksEntity)relatedEntity);
					break;
				case "MedicareQuestionsRemarks_":
					this.MedicareQuestionsRemarks_.Add((MedicareQuestionsRemarksEntity)relatedEntity);
					break;
				case "MedicareQuestionsRemarks":
					this.MedicareQuestionsRemarks.Add((MedicareQuestionsRemarksEntity)relatedEntity);
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
				case "MedicareQuestion":
					DesetupSyncMedicareQuestion(false, true);
					break;
				case "MedicareQuestionGroup":
					DesetupSyncMedicareQuestionGroup(false, true);
					break;
				case "CustomerMedicareQuestionAnswer":
					base.PerformRelatedEntityRemoval(this.CustomerMedicareQuestionAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicareGroupDependencyRule":
					base.PerformRelatedEntityRemoval(this.MedicareGroupDependencyRule, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicareQuestion_":
					base.PerformRelatedEntityRemoval(this.MedicareQuestion_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicareQuestionDependencyRule_":
					base.PerformRelatedEntityRemoval(this.MedicareQuestionDependencyRule_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicareQuestionDependencyRule":
					base.PerformRelatedEntityRemoval(this.MedicareQuestionDependencyRule, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicareQuestionsRemarks__":
					base.PerformRelatedEntityRemoval(this.MedicareQuestionsRemarks__, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicareQuestionsRemarks_":
					base.PerformRelatedEntityRemoval(this.MedicareQuestionsRemarks_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicareQuestionsRemarks":
					base.PerformRelatedEntityRemoval(this.MedicareQuestionsRemarks, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_medicareQuestion!=null)
			{
				toReturn.Add(_medicareQuestion);
			}
			if(_medicareQuestionGroup!=null)
			{
				toReturn.Add(_medicareQuestionGroup);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerMedicareQuestionAnswer);
			toReturn.Add(this.MedicareGroupDependencyRule);
			toReturn.Add(this.MedicareQuestion_);
			toReturn.Add(this.MedicareQuestionDependencyRule_);
			toReturn.Add(this.MedicareQuestionDependencyRule);
			toReturn.Add(this.MedicareQuestionsRemarks__);
			toReturn.Add(this.MedicareQuestionsRemarks_);
			toReturn.Add(this.MedicareQuestionsRemarks);

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
				info.AddValue("_customerMedicareQuestionAnswer", ((_customerMedicareQuestionAnswer!=null) && (_customerMedicareQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_customerMedicareQuestionAnswer:null);
				info.AddValue("_medicareGroupDependencyRule", ((_medicareGroupDependencyRule!=null) && (_medicareGroupDependencyRule.Count>0) && !this.MarkedForDeletion)?_medicareGroupDependencyRule:null);
				info.AddValue("_medicareQuestion_", ((_medicareQuestion_!=null) && (_medicareQuestion_.Count>0) && !this.MarkedForDeletion)?_medicareQuestion_:null);
				info.AddValue("_medicareQuestionDependencyRule_", ((_medicareQuestionDependencyRule_!=null) && (_medicareQuestionDependencyRule_.Count>0) && !this.MarkedForDeletion)?_medicareQuestionDependencyRule_:null);
				info.AddValue("_medicareQuestionDependencyRule", ((_medicareQuestionDependencyRule!=null) && (_medicareQuestionDependencyRule.Count>0) && !this.MarkedForDeletion)?_medicareQuestionDependencyRule:null);
				info.AddValue("_medicareQuestionsRemarks__", ((_medicareQuestionsRemarks__!=null) && (_medicareQuestionsRemarks__.Count>0) && !this.MarkedForDeletion)?_medicareQuestionsRemarks__:null);
				info.AddValue("_medicareQuestionsRemarks_", ((_medicareQuestionsRemarks_!=null) && (_medicareQuestionsRemarks_.Count>0) && !this.MarkedForDeletion)?_medicareQuestionsRemarks_:null);
				info.AddValue("_medicareQuestionsRemarks", ((_medicareQuestionsRemarks!=null) && (_medicareQuestionsRemarks.Count>0) && !this.MarkedForDeletion)?_medicareQuestionsRemarks:null);
				info.AddValue("_eventCustomersCollectionViaCustomerMedicareQuestionAnswer", ((_eventCustomersCollectionViaCustomerMedicareQuestionAnswer!=null) && (_eventCustomersCollectionViaCustomerMedicareQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCustomerMedicareQuestionAnswer:null);
				info.AddValue("_lookupCollectionViaMedicareQuestion", ((_lookupCollectionViaMedicareQuestion!=null) && (_lookupCollectionViaMedicareQuestion.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaMedicareQuestion:null);
				info.AddValue("_medicareQuestionGroupCollectionViaMedicareQuestion", ((_medicareQuestionGroupCollectionViaMedicareQuestion!=null) && (_medicareQuestionGroupCollectionViaMedicareQuestion.Count>0) && !this.MarkedForDeletion)?_medicareQuestionGroupCollectionViaMedicareQuestion:null);
				info.AddValue("_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule", ((_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule!=null) && (_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule.Count>0) && !this.MarkedForDeletion)?_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer", ((_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer!=null) && (_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_medicareQuestion", (!this.MarkedForDeletion?_medicareQuestion:null));
				info.AddValue("_medicareQuestionGroup", (!this.MarkedForDeletion?_medicareQuestionGroup:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MedicareQuestionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MedicareQuestionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MedicareQuestionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerMedicareQuestionAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerMedicareQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerMedicareQuestionAnswerFields.QuestionId, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareGroupDependencyRule' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareGroupDependencyRule()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareGroupDependencyRuleFields.QuestionId, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionFields.ParentQuestionId, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareQuestionDependencyRule' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestionDependencyRule_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionDependencyRuleFields.DependentQuestionId, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareQuestionDependencyRule' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestionDependencyRule()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionDependencyRuleFields.QuestionId, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareQuestionsRemarks' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestionsRemarks__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionsRemarksFields.CombinedQuestionId, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareQuestionsRemarks' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestionsRemarks_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionsRemarksFields.DependentQuestionId, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareQuestionsRemarks' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestionsRemarks()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionsRemarksFields.QuestionId, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCustomerMedicareQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCustomerMedicareQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.QuestionId, "MedicareQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaMedicareQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaMedicareQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.QuestionId, "MedicareQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareQuestionGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestionGroupCollectionViaMedicareQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MedicareQuestionGroupCollectionViaMedicareQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.QuestionId, "MedicareQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareQuestionGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestionGroupCollectionViaMedicareGroupDependencyRule()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.QuestionId, "MedicareQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.QuestionId, "MedicareQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ControlType));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MedicareQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.ParentQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MedicareQuestionGroup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestionGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicareQuestionGroupFields.GroupId, null, ComparisonOperator.Equal, this.GroupId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MedicareQuestionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerMedicareQuestionAnswer);
			collectionsQueue.Enqueue(this._medicareGroupDependencyRule);
			collectionsQueue.Enqueue(this._medicareQuestion_);
			collectionsQueue.Enqueue(this._medicareQuestionDependencyRule_);
			collectionsQueue.Enqueue(this._medicareQuestionDependencyRule);
			collectionsQueue.Enqueue(this._medicareQuestionsRemarks__);
			collectionsQueue.Enqueue(this._medicareQuestionsRemarks_);
			collectionsQueue.Enqueue(this._medicareQuestionsRemarks);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCustomerMedicareQuestionAnswer);
			collectionsQueue.Enqueue(this._lookupCollectionViaMedicareQuestion);
			collectionsQueue.Enqueue(this._medicareQuestionGroupCollectionViaMedicareQuestion);
			collectionsQueue.Enqueue(this._medicareQuestionGroupCollectionViaMedicareGroupDependencyRule);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerMedicareQuestionAnswer = (EntityCollection<CustomerMedicareQuestionAnswerEntity>) collectionsQueue.Dequeue();
			this._medicareGroupDependencyRule = (EntityCollection<MedicareGroupDependencyRuleEntity>) collectionsQueue.Dequeue();
			this._medicareQuestion_ = (EntityCollection<MedicareQuestionEntity>) collectionsQueue.Dequeue();
			this._medicareQuestionDependencyRule_ = (EntityCollection<MedicareQuestionDependencyRuleEntity>) collectionsQueue.Dequeue();
			this._medicareQuestionDependencyRule = (EntityCollection<MedicareQuestionDependencyRuleEntity>) collectionsQueue.Dequeue();
			this._medicareQuestionsRemarks__ = (EntityCollection<MedicareQuestionsRemarksEntity>) collectionsQueue.Dequeue();
			this._medicareQuestionsRemarks_ = (EntityCollection<MedicareQuestionsRemarksEntity>) collectionsQueue.Dequeue();
			this._medicareQuestionsRemarks = (EntityCollection<MedicareQuestionsRemarksEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCustomerMedicareQuestionAnswer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaMedicareQuestion = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._medicareQuestionGroupCollectionViaMedicareQuestion = (EntityCollection<MedicareQuestionGroupEntity>) collectionsQueue.Dequeue();
			this._medicareQuestionGroupCollectionViaMedicareGroupDependencyRule = (EntityCollection<MedicareQuestionGroupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerMedicareQuestionAnswer != null)
			{
				return true;
			}
			if (this._medicareGroupDependencyRule != null)
			{
				return true;
			}
			if (this._medicareQuestion_ != null)
			{
				return true;
			}
			if (this._medicareQuestionDependencyRule_ != null)
			{
				return true;
			}
			if (this._medicareQuestionDependencyRule != null)
			{
				return true;
			}
			if (this._medicareQuestionsRemarks__ != null)
			{
				return true;
			}
			if (this._medicareQuestionsRemarks_ != null)
			{
				return true;
			}
			if (this._medicareQuestionsRemarks != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCustomerMedicareQuestionAnswer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaMedicareQuestion != null)
			{
				return true;
			}
			if (this._medicareQuestionGroupCollectionViaMedicareQuestion != null)
			{
				return true;
			}
			if (this._medicareQuestionGroupCollectionViaMedicareGroupDependencyRule != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerMedicareQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerMedicareQuestionAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareGroupDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareGroupDependencyRuleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionDependencyRuleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionDependencyRuleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareQuestionsRemarksEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionsRemarksEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareQuestionsRemarksEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionsRemarksEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareQuestionsRemarksEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionsRemarksEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionGroupEntityFactory))) : null);
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
			toReturn.Add("MedicareQuestion", _medicareQuestion);
			toReturn.Add("MedicareQuestionGroup", _medicareQuestionGroup);
			toReturn.Add("CustomerMedicareQuestionAnswer", _customerMedicareQuestionAnswer);
			toReturn.Add("MedicareGroupDependencyRule", _medicareGroupDependencyRule);
			toReturn.Add("MedicareQuestion_", _medicareQuestion_);
			toReturn.Add("MedicareQuestionDependencyRule_", _medicareQuestionDependencyRule_);
			toReturn.Add("MedicareQuestionDependencyRule", _medicareQuestionDependencyRule);
			toReturn.Add("MedicareQuestionsRemarks__", _medicareQuestionsRemarks__);
			toReturn.Add("MedicareQuestionsRemarks_", _medicareQuestionsRemarks_);
			toReturn.Add("MedicareQuestionsRemarks", _medicareQuestionsRemarks);
			toReturn.Add("EventCustomersCollectionViaCustomerMedicareQuestionAnswer", _eventCustomersCollectionViaCustomerMedicareQuestionAnswer);
			toReturn.Add("LookupCollectionViaMedicareQuestion", _lookupCollectionViaMedicareQuestion);
			toReturn.Add("MedicareQuestionGroupCollectionViaMedicareQuestion", _medicareQuestionGroupCollectionViaMedicareQuestion);
			toReturn.Add("MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule", _medicareQuestionGroupCollectionViaMedicareGroupDependencyRule);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer", _organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerMedicareQuestionAnswer!=null)
			{
				_customerMedicareQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_medicareGroupDependencyRule!=null)
			{
				_medicareGroupDependencyRule.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestion_!=null)
			{
				_medicareQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestionDependencyRule_!=null)
			{
				_medicareQuestionDependencyRule_.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestionDependencyRule!=null)
			{
				_medicareQuestionDependencyRule.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestionsRemarks__!=null)
			{
				_medicareQuestionsRemarks__.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestionsRemarks_!=null)
			{
				_medicareQuestionsRemarks_.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestionsRemarks!=null)
			{
				_medicareQuestionsRemarks.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCustomerMedicareQuestionAnswer!=null)
			{
				_eventCustomersCollectionViaCustomerMedicareQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaMedicareQuestion!=null)
			{
				_lookupCollectionViaMedicareQuestion.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestionGroupCollectionViaMedicareQuestion!=null)
			{
				_medicareQuestionGroupCollectionViaMedicareQuestion.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule!=null)
			{
				_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer!=null)
			{
				_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestion!=null)
			{
				_medicareQuestion.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestionGroup!=null)
			{
				_medicareQuestionGroup.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerMedicareQuestionAnswer = null;
			_medicareGroupDependencyRule = null;
			_medicareQuestion_ = null;
			_medicareQuestionDependencyRule_ = null;
			_medicareQuestionDependencyRule = null;
			_medicareQuestionsRemarks__ = null;
			_medicareQuestionsRemarks_ = null;
			_medicareQuestionsRemarks = null;
			_eventCustomersCollectionViaCustomerMedicareQuestionAnswer = null;
			_lookupCollectionViaMedicareQuestion = null;
			_medicareQuestionGroupCollectionViaMedicareQuestion = null;
			_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule = null;
			_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = null;
			_lookup = null;
			_medicareQuestion = null;
			_medicareQuestionGroup = null;

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

			_fieldsCustomProperties.Add("QuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Question", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValue", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Delimiter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsRequired", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DisplaySequence", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentQuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefault", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultValue", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", MedicareQuestionEntity.Relations.LookupEntityUsingControlType, true, signalRelatedEntity, "MedicareQuestion", resetFKFields, new int[] { (int)MedicareQuestionFieldIndex.ControlType } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", MedicareQuestionEntity.Relations.LookupEntityUsingControlType, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _medicareQuestion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicareQuestion(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicareQuestion, new PropertyChangedEventHandler( OnMedicareQuestionPropertyChanged ), "MedicareQuestion", MedicareQuestionEntity.Relations.MedicareQuestionEntityUsingQuestionIdParentQuestionId, true, signalRelatedEntity, "MedicareQuestion_", resetFKFields, new int[] { (int)MedicareQuestionFieldIndex.ParentQuestionId } );		
			_medicareQuestion = null;
		}

		/// <summary> setups the sync logic for member _medicareQuestion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicareQuestion(IEntity2 relatedEntity)
		{
			if(_medicareQuestion!=relatedEntity)
			{
				DesetupSyncMedicareQuestion(true, true);
				_medicareQuestion = (MedicareQuestionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicareQuestion, new PropertyChangedEventHandler( OnMedicareQuestionPropertyChanged ), "MedicareQuestion", MedicareQuestionEntity.Relations.MedicareQuestionEntityUsingQuestionIdParentQuestionId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicareQuestionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _medicareQuestionGroup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicareQuestionGroup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicareQuestionGroup, new PropertyChangedEventHandler( OnMedicareQuestionGroupPropertyChanged ), "MedicareQuestionGroup", MedicareQuestionEntity.Relations.MedicareQuestionGroupEntityUsingGroupId, true, signalRelatedEntity, "MedicareQuestion", resetFKFields, new int[] { (int)MedicareQuestionFieldIndex.GroupId } );		
			_medicareQuestionGroup = null;
		}

		/// <summary> setups the sync logic for member _medicareQuestionGroup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicareQuestionGroup(IEntity2 relatedEntity)
		{
			if(_medicareQuestionGroup!=relatedEntity)
			{
				DesetupSyncMedicareQuestionGroup(true, true);
				_medicareQuestionGroup = (MedicareQuestionGroupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicareQuestionGroup, new PropertyChangedEventHandler( OnMedicareQuestionGroupPropertyChanged ), "MedicareQuestionGroup", MedicareQuestionEntity.Relations.MedicareQuestionGroupEntityUsingGroupId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicareQuestionGroupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MedicareQuestionEntity</param>
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
		public  static MedicareQuestionRelations Relations
		{
			get	{ return new MedicareQuestionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerMedicareQuestionAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerMedicareQuestionAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerMedicareQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerMedicareQuestionAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerMedicareQuestionAnswer")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.CustomerMedicareQuestionAnswerEntity, 0, null, null, null, null, "CustomerMedicareQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareGroupDependencyRule' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareGroupDependencyRule
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicareGroupDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareGroupDependencyRuleEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicareGroupDependencyRule")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareGroupDependencyRuleEntity, 0, null, null, null, null, "MedicareGroupDependencyRule", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestion_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicareQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicareQuestion_")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionEntity, 0, null, null, null, null, "MedicareQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestionDependencyRule' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestionDependencyRule_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicareQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionDependencyRuleEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicareQuestionDependencyRule_")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionDependencyRuleEntity, 0, null, null, null, null, "MedicareQuestionDependencyRule_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestionDependencyRule' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestionDependencyRule
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicareQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionDependencyRuleEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicareQuestionDependencyRule")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionDependencyRuleEntity, 0, null, null, null, null, "MedicareQuestionDependencyRule", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestionsRemarks' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestionsRemarks__
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicareQuestionsRemarksEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionsRemarksEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicareQuestionsRemarks__")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionsRemarksEntity, 0, null, null, null, null, "MedicareQuestionsRemarks__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestionsRemarks' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestionsRemarks_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicareQuestionsRemarksEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionsRemarksEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicareQuestionsRemarks_")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionsRemarksEntity, 0, null, null, null, null, "MedicareQuestionsRemarks_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestionsRemarks' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestionsRemarks
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicareQuestionsRemarksEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionsRemarksEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicareQuestionsRemarks")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionsRemarksEntity, 0, null, null, null, null, "MedicareQuestionsRemarks", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCustomerMedicareQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = MedicareQuestionEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerMedicareQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCustomerMedicareQuestionAnswer"), null, "EventCustomersCollectionViaCustomerMedicareQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaMedicareQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = MedicareQuestionEntity.Relations.MedicareQuestionEntityUsingParentQuestionId;
				intermediateRelation.SetAliases(string.Empty, "MedicareQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaMedicareQuestion"), null, "LookupCollectionViaMedicareQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestionGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestionGroupCollectionViaMedicareQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = MedicareQuestionEntity.Relations.MedicareQuestionEntityUsingParentQuestionId;
				intermediateRelation.SetAliases(string.Empty, "MedicareQuestion_");
				return new PrefetchPathElement2(new EntityCollection<MedicareQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionGroupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionGroupEntity, 0, null, null, GetRelationsForField("MedicareQuestionGroupCollectionViaMedicareQuestion"), null, "MedicareQuestionGroupCollectionViaMedicareQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestionGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestionGroupCollectionViaMedicareGroupDependencyRule
		{
			get
			{
				IEntityRelation intermediateRelation = MedicareQuestionEntity.Relations.MedicareGroupDependencyRuleEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "MedicareGroupDependencyRule_");
				return new PrefetchPathElement2(new EntityCollection<MedicareQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionGroupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionGroupEntity, 0, null, null, GetRelationsForField("MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule"), null, "MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = MedicareQuestionEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerMedicareQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer"), null, "OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicareQuestion")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionEntity, 0, null, null, null, null, "MedicareQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestionGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestionGroup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionGroupEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicareQuestionGroup")[0], (int)Falcon.Data.EntityType.MedicareQuestionEntity, (int)Falcon.Data.EntityType.MedicareQuestionGroupEntity, 0, null, null, null, null, "MedicareQuestionGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MedicareQuestionEntity.CustomProperties;}
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
			get { return MedicareQuestionEntity.FieldsCustomProperties;}
		}

		/// <summary> The QuestionId property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."QuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 QuestionId
		{
			get { return (System.Int64)GetValue((int)MedicareQuestionFieldIndex.QuestionId, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.QuestionId, value); }
		}

		/// <summary> The GroupId property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."GroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GroupId
		{
			get { return (System.Int64)GetValue((int)MedicareQuestionFieldIndex.GroupId, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.GroupId, value); }
		}

		/// <summary> The Question property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."Question"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Question
		{
			get { return (System.String)GetValue((int)MedicareQuestionFieldIndex.Question, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.Question, value); }
		}

		/// <summary> The ControlValue property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."ControlValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ControlValue
		{
			get { return (System.String)GetValue((int)MedicareQuestionFieldIndex.ControlValue, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.ControlValue, value); }
		}

		/// <summary> The ControlType property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."ControlType"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ControlType
		{
			get { return (System.Int64)GetValue((int)MedicareQuestionFieldIndex.ControlType, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.ControlType, value); }
		}

		/// <summary> The Delimiter property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."Delimiter"<br/>
		/// Table field type characteristics (type, precision, scale, length): NChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Delimiter
		{
			get { return (System.String)GetValue((int)MedicareQuestionFieldIndex.Delimiter, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.Delimiter, value); }
		}

		/// <summary> The IsActive property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)MedicareQuestionFieldIndex.IsActive, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.IsActive, value); }
		}

		/// <summary> The IsRequired property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."IsRequired"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsRequired
		{
			get { return (System.Boolean)GetValue((int)MedicareQuestionFieldIndex.IsRequired, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.IsRequired, value); }
		}

		/// <summary> The DisplaySequence property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."DisplaySequence"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 DisplaySequence
		{
			get { return (System.Int32)GetValue((int)MedicareQuestionFieldIndex.DisplaySequence, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.DisplaySequence, value); }
		}

		/// <summary> The ParentQuestionId property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."ParentQuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentQuestionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MedicareQuestionFieldIndex.ParentQuestionId, false); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.ParentQuestionId, value); }
		}

		/// <summary> The IsDefault property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."IsDefault"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefault
		{
			get { return (System.Boolean)GetValue((int)MedicareQuestionFieldIndex.IsDefault, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.IsDefault, value); }
		}

		/// <summary> The DefaultValue property of the Entity MedicareQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicareQuestion"."DefaultValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): NChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DefaultValue
		{
			get { return (System.String)GetValue((int)MedicareQuestionFieldIndex.DefaultValue, true); }
			set	{ SetValue((int)MedicareQuestionFieldIndex.DefaultValue, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerMedicareQuestionAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerMedicareQuestionAnswerEntity))]
		public virtual EntityCollection<CustomerMedicareQuestionAnswerEntity> CustomerMedicareQuestionAnswer
		{
			get
			{
				if(_customerMedicareQuestionAnswer==null)
				{
					_customerMedicareQuestionAnswer = new EntityCollection<CustomerMedicareQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerMedicareQuestionAnswerEntityFactory)));
					_customerMedicareQuestionAnswer.SetContainingEntityInfo(this, "MedicareQuestion");
				}
				return _customerMedicareQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareGroupDependencyRuleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareGroupDependencyRuleEntity))]
		public virtual EntityCollection<MedicareGroupDependencyRuleEntity> MedicareGroupDependencyRule
		{
			get
			{
				if(_medicareGroupDependencyRule==null)
				{
					_medicareGroupDependencyRule = new EntityCollection<MedicareGroupDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareGroupDependencyRuleEntityFactory)));
					_medicareGroupDependencyRule.SetContainingEntityInfo(this, "MedicareQuestion");
				}
				return _medicareGroupDependencyRule;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareQuestionEntity))]
		public virtual EntityCollection<MedicareQuestionEntity> MedicareQuestion_
		{
			get
			{
				if(_medicareQuestion_==null)
				{
					_medicareQuestion_ = new EntityCollection<MedicareQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionEntityFactory)));
					_medicareQuestion_.SetContainingEntityInfo(this, "MedicareQuestion");
				}
				return _medicareQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareQuestionDependencyRuleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareQuestionDependencyRuleEntity))]
		public virtual EntityCollection<MedicareQuestionDependencyRuleEntity> MedicareQuestionDependencyRule_
		{
			get
			{
				if(_medicareQuestionDependencyRule_==null)
				{
					_medicareQuestionDependencyRule_ = new EntityCollection<MedicareQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionDependencyRuleEntityFactory)));
					_medicareQuestionDependencyRule_.SetContainingEntityInfo(this, "MedicareQuestion_");
				}
				return _medicareQuestionDependencyRule_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareQuestionDependencyRuleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareQuestionDependencyRuleEntity))]
		public virtual EntityCollection<MedicareQuestionDependencyRuleEntity> MedicareQuestionDependencyRule
		{
			get
			{
				if(_medicareQuestionDependencyRule==null)
				{
					_medicareQuestionDependencyRule = new EntityCollection<MedicareQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionDependencyRuleEntityFactory)));
					_medicareQuestionDependencyRule.SetContainingEntityInfo(this, "MedicareQuestion");
				}
				return _medicareQuestionDependencyRule;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareQuestionsRemarksEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareQuestionsRemarksEntity))]
		public virtual EntityCollection<MedicareQuestionsRemarksEntity> MedicareQuestionsRemarks__
		{
			get
			{
				if(_medicareQuestionsRemarks__==null)
				{
					_medicareQuestionsRemarks__ = new EntityCollection<MedicareQuestionsRemarksEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionsRemarksEntityFactory)));
					_medicareQuestionsRemarks__.SetContainingEntityInfo(this, "MedicareQuestion__");
				}
				return _medicareQuestionsRemarks__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareQuestionsRemarksEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareQuestionsRemarksEntity))]
		public virtual EntityCollection<MedicareQuestionsRemarksEntity> MedicareQuestionsRemarks_
		{
			get
			{
				if(_medicareQuestionsRemarks_==null)
				{
					_medicareQuestionsRemarks_ = new EntityCollection<MedicareQuestionsRemarksEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionsRemarksEntityFactory)));
					_medicareQuestionsRemarks_.SetContainingEntityInfo(this, "MedicareQuestion_");
				}
				return _medicareQuestionsRemarks_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareQuestionsRemarksEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareQuestionsRemarksEntity))]
		public virtual EntityCollection<MedicareQuestionsRemarksEntity> MedicareQuestionsRemarks
		{
			get
			{
				if(_medicareQuestionsRemarks==null)
				{
					_medicareQuestionsRemarks = new EntityCollection<MedicareQuestionsRemarksEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionsRemarksEntityFactory)));
					_medicareQuestionsRemarks.SetContainingEntityInfo(this, "MedicareQuestion");
				}
				return _medicareQuestionsRemarks;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaCustomerMedicareQuestionAnswer
		{
			get
			{
				if(_eventCustomersCollectionViaCustomerMedicareQuestionAnswer==null)
				{
					_eventCustomersCollectionViaCustomerMedicareQuestionAnswer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaCustomerMedicareQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaMedicareQuestion
		{
			get
			{
				if(_lookupCollectionViaMedicareQuestion==null)
				{
					_lookupCollectionViaMedicareQuestion = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaMedicareQuestion.IsReadOnly=true;
				}
				return _lookupCollectionViaMedicareQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareQuestionGroupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareQuestionGroupEntity))]
		public virtual EntityCollection<MedicareQuestionGroupEntity> MedicareQuestionGroupCollectionViaMedicareQuestion
		{
			get
			{
				if(_medicareQuestionGroupCollectionViaMedicareQuestion==null)
				{
					_medicareQuestionGroupCollectionViaMedicareQuestion = new EntityCollection<MedicareQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionGroupEntityFactory)));
					_medicareQuestionGroupCollectionViaMedicareQuestion.IsReadOnly=true;
				}
				return _medicareQuestionGroupCollectionViaMedicareQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareQuestionGroupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareQuestionGroupEntity))]
		public virtual EntityCollection<MedicareQuestionGroupEntity> MedicareQuestionGroupCollectionViaMedicareGroupDependencyRule
		{
			get
			{
				if(_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule==null)
				{
					_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule = new EntityCollection<MedicareQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionGroupEntityFactory)));
					_medicareQuestionGroupCollectionViaMedicareGroupDependencyRule.IsReadOnly=true;
				}
				return _medicareQuestionGroupCollectionViaMedicareGroupDependencyRule;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer==null)
				{
					_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer;
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
							_lookup.UnsetRelatedEntity(this, "MedicareQuestion");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicareQuestion");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MedicareQuestionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicareQuestionEntity MedicareQuestion
		{
			get
			{
				return _medicareQuestion;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicareQuestion(value);
				}
				else
				{
					if(value==null)
					{
						if(_medicareQuestion != null)
						{
							_medicareQuestion.UnsetRelatedEntity(this, "MedicareQuestion_");
						}
					}
					else
					{
						if(_medicareQuestion!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicareQuestion_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MedicareQuestionGroupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicareQuestionGroupEntity MedicareQuestionGroup
		{
			get
			{
				return _medicareQuestionGroup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicareQuestionGroup(value);
				}
				else
				{
					if(value==null)
					{
						if(_medicareQuestionGroup != null)
						{
							_medicareQuestionGroup.UnsetRelatedEntity(this, "MedicareQuestion");
						}
					}
					else
					{
						if(_medicareQuestionGroup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicareQuestion");
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
			get { return (int)Falcon.Data.EntityType.MedicareQuestionEntity; }
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
