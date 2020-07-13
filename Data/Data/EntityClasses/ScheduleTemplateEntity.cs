///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:44
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
	/// Entity class which represents the entity 'ScheduleTemplate'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ScheduleTemplateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventScheduleTemplateEntity> _eventScheduleTemplate;
		private EntityCollection<ScheduleTemplateFranchiseeAccessEntity> _scheduleTemplateFranchiseeAccess;
		private EntityCollection<ScheduleTemplateTimeEntity> _scheduleTemplateTime;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventScheduleTemplate;
		private EntityCollection<OrganizationEntity> _organizationCollectionViaScheduleTemplateFranchiseeAccess;
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
			/// <summary>Member name EventScheduleTemplate</summary>
			public static readonly string EventScheduleTemplate = "EventScheduleTemplate";
			/// <summary>Member name ScheduleTemplateFranchiseeAccess</summary>
			public static readonly string ScheduleTemplateFranchiseeAccess = "ScheduleTemplateFranchiseeAccess";
			/// <summary>Member name ScheduleTemplateTime</summary>
			public static readonly string ScheduleTemplateTime = "ScheduleTemplateTime";
			/// <summary>Member name EventsCollectionViaEventScheduleTemplate</summary>
			public static readonly string EventsCollectionViaEventScheduleTemplate = "EventsCollectionViaEventScheduleTemplate";
			/// <summary>Member name OrganizationCollectionViaScheduleTemplateFranchiseeAccess</summary>
			public static readonly string OrganizationCollectionViaScheduleTemplateFranchiseeAccess = "OrganizationCollectionViaScheduleTemplateFranchiseeAccess";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ScheduleTemplateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ScheduleTemplateEntity():base("ScheduleTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ScheduleTemplateEntity(IEntityFields2 fields):base("ScheduleTemplateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ScheduleTemplateEntity</param>
		public ScheduleTemplateEntity(IValidator validator):base("ScheduleTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="scheduleTemplateId">PK value for ScheduleTemplate which data should be fetched into this ScheduleTemplate object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ScheduleTemplateEntity(System.Int64 scheduleTemplateId):base("ScheduleTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ScheduleTemplateId = scheduleTemplateId;
		}

		/// <summary> CTor</summary>
		/// <param name="scheduleTemplateId">PK value for ScheduleTemplate which data should be fetched into this ScheduleTemplate object</param>
		/// <param name="validator">The custom validator object for this ScheduleTemplateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ScheduleTemplateEntity(System.Int64 scheduleTemplateId, IValidator validator):base("ScheduleTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ScheduleTemplateId = scheduleTemplateId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ScheduleTemplateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventScheduleTemplate = (EntityCollection<EventScheduleTemplateEntity>)info.GetValue("_eventScheduleTemplate", typeof(EntityCollection<EventScheduleTemplateEntity>));
				_scheduleTemplateFranchiseeAccess = (EntityCollection<ScheduleTemplateFranchiseeAccessEntity>)info.GetValue("_scheduleTemplateFranchiseeAccess", typeof(EntityCollection<ScheduleTemplateFranchiseeAccessEntity>));
				_scheduleTemplateTime = (EntityCollection<ScheduleTemplateTimeEntity>)info.GetValue("_scheduleTemplateTime", typeof(EntityCollection<ScheduleTemplateTimeEntity>));
				_eventsCollectionViaEventScheduleTemplate = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventScheduleTemplate", typeof(EntityCollection<EventsEntity>));
				_organizationCollectionViaScheduleTemplateFranchiseeAccess = (EntityCollection<OrganizationEntity>)info.GetValue("_organizationCollectionViaScheduleTemplateFranchiseeAccess", typeof(EntityCollection<OrganizationEntity>));
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
			switch((ScheduleTemplateFieldIndex)fieldIndex)
			{
				case ScheduleTemplateFieldIndex.ModifiedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case ScheduleTemplateFieldIndex.ModifiedByOrgRoleUserId:
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
				case "EventScheduleTemplate":
					this.EventScheduleTemplate.Add((EventScheduleTemplateEntity)entity);
					break;
				case "ScheduleTemplateFranchiseeAccess":
					this.ScheduleTemplateFranchiseeAccess.Add((ScheduleTemplateFranchiseeAccessEntity)entity);
					break;
				case "ScheduleTemplateTime":
					this.ScheduleTemplateTime.Add((ScheduleTemplateTimeEntity)entity);
					break;
				case "EventsCollectionViaEventScheduleTemplate":
					this.EventsCollectionViaEventScheduleTemplate.IsReadOnly = false;
					this.EventsCollectionViaEventScheduleTemplate.Add((EventsEntity)entity);
					this.EventsCollectionViaEventScheduleTemplate.IsReadOnly = true;
					break;
				case "OrganizationCollectionViaScheduleTemplateFranchiseeAccess":
					this.OrganizationCollectionViaScheduleTemplateFranchiseeAccess.IsReadOnly = false;
					this.OrganizationCollectionViaScheduleTemplateFranchiseeAccess.Add((OrganizationEntity)entity);
					this.OrganizationCollectionViaScheduleTemplateFranchiseeAccess.IsReadOnly = true;
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
			return ScheduleTemplateEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(ScheduleTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(ScheduleTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "EventScheduleTemplate":
					toReturn.Add(ScheduleTemplateEntity.Relations.EventScheduleTemplateEntityUsingScheduleTemplateId);
					break;
				case "ScheduleTemplateFranchiseeAccess":
					toReturn.Add(ScheduleTemplateEntity.Relations.ScheduleTemplateFranchiseeAccessEntityUsingScheduleTemplateId);
					break;
				case "ScheduleTemplateTime":
					toReturn.Add(ScheduleTemplateEntity.Relations.ScheduleTemplateTimeEntityUsingScheduleTemplateId);
					break;
				case "EventsCollectionViaEventScheduleTemplate":
					toReturn.Add(ScheduleTemplateEntity.Relations.EventScheduleTemplateEntityUsingScheduleTemplateId, "ScheduleTemplateEntity__", "EventScheduleTemplate_", JoinHint.None);
					toReturn.Add(EventScheduleTemplateEntity.Relations.EventsEntityUsingEventId, "EventScheduleTemplate_", string.Empty, JoinHint.None);
					break;
				case "OrganizationCollectionViaScheduleTemplateFranchiseeAccess":
					toReturn.Add(ScheduleTemplateEntity.Relations.ScheduleTemplateFranchiseeAccessEntityUsingScheduleTemplateId, "ScheduleTemplateEntity__", "ScheduleTemplateFranchiseeAccess_", JoinHint.None);
					toReturn.Add(ScheduleTemplateFranchiseeAccessEntity.Relations.OrganizationEntityUsingOrganizationId, "ScheduleTemplateFranchiseeAccess_", string.Empty, JoinHint.None);
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
				case "EventScheduleTemplate":
					this.EventScheduleTemplate.Add((EventScheduleTemplateEntity)relatedEntity);
					break;
				case "ScheduleTemplateFranchiseeAccess":
					this.ScheduleTemplateFranchiseeAccess.Add((ScheduleTemplateFranchiseeAccessEntity)relatedEntity);
					break;
				case "ScheduleTemplateTime":
					this.ScheduleTemplateTime.Add((ScheduleTemplateTimeEntity)relatedEntity);
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
				case "EventScheduleTemplate":
					base.PerformRelatedEntityRemoval(this.EventScheduleTemplate, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ScheduleTemplateFranchiseeAccess":
					base.PerformRelatedEntityRemoval(this.ScheduleTemplateFranchiseeAccess, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ScheduleTemplateTime":
					base.PerformRelatedEntityRemoval(this.ScheduleTemplateTime, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.EventScheduleTemplate);
			toReturn.Add(this.ScheduleTemplateFranchiseeAccess);
			toReturn.Add(this.ScheduleTemplateTime);

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
				info.AddValue("_eventScheduleTemplate", ((_eventScheduleTemplate!=null) && (_eventScheduleTemplate.Count>0) && !this.MarkedForDeletion)?_eventScheduleTemplate:null);
				info.AddValue("_scheduleTemplateFranchiseeAccess", ((_scheduleTemplateFranchiseeAccess!=null) && (_scheduleTemplateFranchiseeAccess.Count>0) && !this.MarkedForDeletion)?_scheduleTemplateFranchiseeAccess:null);
				info.AddValue("_scheduleTemplateTime", ((_scheduleTemplateTime!=null) && (_scheduleTemplateTime.Count>0) && !this.MarkedForDeletion)?_scheduleTemplateTime:null);
				info.AddValue("_eventsCollectionViaEventScheduleTemplate", ((_eventsCollectionViaEventScheduleTemplate!=null) && (_eventsCollectionViaEventScheduleTemplate.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventScheduleTemplate:null);
				info.AddValue("_organizationCollectionViaScheduleTemplateFranchiseeAccess", ((_organizationCollectionViaScheduleTemplateFranchiseeAccess!=null) && (_organizationCollectionViaScheduleTemplateFranchiseeAccess.Count>0) && !this.MarkedForDeletion)?_organizationCollectionViaScheduleTemplateFranchiseeAccess:null);
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
		public bool TestOriginalFieldValueForNull(ScheduleTemplateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ScheduleTemplateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ScheduleTemplateRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventScheduleTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventScheduleTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventScheduleTemplateFields.ScheduleTemplateId, null, ComparisonOperator.Equal, this.ScheduleTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ScheduleTemplateFranchiseeAccess' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScheduleTemplateFranchiseeAccess()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScheduleTemplateFranchiseeAccessFields.ScheduleTemplateId, null, ComparisonOperator.Equal, this.ScheduleTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ScheduleTemplateTime' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScheduleTemplateTime()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScheduleTemplateTimeFields.ScheduleTemplateId, null, ComparisonOperator.Equal, this.ScheduleTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventScheduleTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventScheduleTemplate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScheduleTemplateFields.ScheduleTemplateId, null, ComparisonOperator.Equal, this.ScheduleTemplateId, "ScheduleTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationCollectionViaScheduleTemplateFranchiseeAccess()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationCollectionViaScheduleTemplateFranchiseeAccess"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScheduleTemplateFields.ScheduleTemplateId, null, ComparisonOperator.Equal, this.ScheduleTemplateId, "ScheduleTemplateEntity__"));
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
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ScheduleTemplateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventScheduleTemplate);
			collectionsQueue.Enqueue(this._scheduleTemplateFranchiseeAccess);
			collectionsQueue.Enqueue(this._scheduleTemplateTime);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventScheduleTemplate);
			collectionsQueue.Enqueue(this._organizationCollectionViaScheduleTemplateFranchiseeAccess);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventScheduleTemplate = (EntityCollection<EventScheduleTemplateEntity>) collectionsQueue.Dequeue();
			this._scheduleTemplateFranchiseeAccess = (EntityCollection<ScheduleTemplateFranchiseeAccessEntity>) collectionsQueue.Dequeue();
			this._scheduleTemplateTime = (EntityCollection<ScheduleTemplateTimeEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventScheduleTemplate = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._organizationCollectionViaScheduleTemplateFranchiseeAccess = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventScheduleTemplate != null)
			{
				return true;
			}
			if (this._scheduleTemplateFranchiseeAccess != null)
			{
				return true;
			}
			if (this._scheduleTemplateTime != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventScheduleTemplate != null)
			{
				return true;
			}
			if (this._organizationCollectionViaScheduleTemplateFranchiseeAccess != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventScheduleTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventScheduleTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ScheduleTemplateFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateFranchiseeAccessEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ScheduleTemplateTimeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateTimeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
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
			toReturn.Add("EventScheduleTemplate", _eventScheduleTemplate);
			toReturn.Add("ScheduleTemplateFranchiseeAccess", _scheduleTemplateFranchiseeAccess);
			toReturn.Add("ScheduleTemplateTime", _scheduleTemplateTime);
			toReturn.Add("EventsCollectionViaEventScheduleTemplate", _eventsCollectionViaEventScheduleTemplate);
			toReturn.Add("OrganizationCollectionViaScheduleTemplateFranchiseeAccess", _organizationCollectionViaScheduleTemplateFranchiseeAccess);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventScheduleTemplate!=null)
			{
				_eventScheduleTemplate.ActiveContext = base.ActiveContext;
			}
			if(_scheduleTemplateFranchiseeAccess!=null)
			{
				_scheduleTemplateFranchiseeAccess.ActiveContext = base.ActiveContext;
			}
			if(_scheduleTemplateTime!=null)
			{
				_scheduleTemplateTime.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventScheduleTemplate!=null)
			{
				_eventsCollectionViaEventScheduleTemplate.ActiveContext = base.ActiveContext;
			}
			if(_organizationCollectionViaScheduleTemplateFranchiseeAccess!=null)
			{
				_organizationCollectionViaScheduleTemplateFranchiseeAccess.ActiveContext = base.ActiveContext;
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

			_eventScheduleTemplate = null;
			_scheduleTemplateFranchiseeAccess = null;
			_scheduleTemplateTime = null;
			_eventsCollectionViaEventScheduleTemplate = null;
			_organizationCollectionViaScheduleTemplateFranchiseeAccess = null;
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

			_fieldsCustomProperties.Add("ScheduleTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsGlobal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", ScheduleTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "ScheduleTemplate_", resetFKFields, new int[] { (int)ScheduleTemplateFieldIndex.ModifiedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", ScheduleTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", ScheduleTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "ScheduleTemplate", resetFKFields, new int[] { (int)ScheduleTemplateFieldIndex.ModifiedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", ScheduleTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this ScheduleTemplateEntity</param>
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
		public  static ScheduleTemplateRelations Relations
		{
			get	{ return new ScheduleTemplateRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventScheduleTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventScheduleTemplate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventScheduleTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventScheduleTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventScheduleTemplate")[0], (int)Falcon.Data.EntityType.ScheduleTemplateEntity, (int)Falcon.Data.EntityType.EventScheduleTemplateEntity, 0, null, null, null, null, "EventScheduleTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScheduleTemplateFranchiseeAccess' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScheduleTemplateFranchiseeAccess
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ScheduleTemplateFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateFranchiseeAccessEntityFactory))),
					(IEntityRelation)GetRelationsForField("ScheduleTemplateFranchiseeAccess")[0], (int)Falcon.Data.EntityType.ScheduleTemplateEntity, (int)Falcon.Data.EntityType.ScheduleTemplateFranchiseeAccessEntity, 0, null, null, null, null, "ScheduleTemplateFranchiseeAccess", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScheduleTemplateTime' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScheduleTemplateTime
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ScheduleTemplateTimeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateTimeEntityFactory))),
					(IEntityRelation)GetRelationsForField("ScheduleTemplateTime")[0], (int)Falcon.Data.EntityType.ScheduleTemplateEntity, (int)Falcon.Data.EntityType.ScheduleTemplateTimeEntity, 0, null, null, null, null, "ScheduleTemplateTime", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventScheduleTemplate
		{
			get
			{
				IEntityRelation intermediateRelation = ScheduleTemplateEntity.Relations.EventScheduleTemplateEntityUsingScheduleTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventScheduleTemplate_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ScheduleTemplateEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventScheduleTemplate"), null, "EventsCollectionViaEventScheduleTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationCollectionViaScheduleTemplateFranchiseeAccess
		{
			get
			{
				IEntityRelation intermediateRelation = ScheduleTemplateEntity.Relations.ScheduleTemplateFranchiseeAccessEntityUsingScheduleTemplateId;
				intermediateRelation.SetAliases(string.Empty, "ScheduleTemplateFranchiseeAccess_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ScheduleTemplateEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, GetRelationsForField("OrganizationCollectionViaScheduleTemplateFranchiseeAccess"), null, "OrganizationCollectionViaScheduleTemplateFranchiseeAccess", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.ScheduleTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.ScheduleTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ScheduleTemplateEntity.CustomProperties;}
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
			get { return ScheduleTemplateEntity.FieldsCustomProperties;}
		}

		/// <summary> The ScheduleTemplateId property of the Entity ScheduleTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScheduleTemplate"."ScheduleTemplateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ScheduleTemplateId
		{
			get { return (System.Int64)GetValue((int)ScheduleTemplateFieldIndex.ScheduleTemplateId, true); }
			set	{ SetValue((int)ScheduleTemplateFieldIndex.ScheduleTemplateId, value); }
		}

		/// <summary> The Name property of the Entity ScheduleTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScheduleTemplate"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ScheduleTemplateFieldIndex.Name, true); }
			set	{ SetValue((int)ScheduleTemplateFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity ScheduleTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScheduleTemplate"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)ScheduleTemplateFieldIndex.Description, true); }
			set	{ SetValue((int)ScheduleTemplateFieldIndex.Description, value); }
		}

		/// <summary> The IsGlobal property of the Entity ScheduleTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScheduleTemplate"."IsGlobal"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsGlobal
		{
			get { return (System.Boolean)GetValue((int)ScheduleTemplateFieldIndex.IsGlobal, true); }
			set	{ SetValue((int)ScheduleTemplateFieldIndex.IsGlobal, value); }
		}

		/// <summary> The DateCreated property of the Entity ScheduleTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScheduleTemplate"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ScheduleTemplateFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ScheduleTemplateFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity ScheduleTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScheduleTemplate"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ScheduleTemplateFieldIndex.DateModified, true); }
			set	{ SetValue((int)ScheduleTemplateFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity ScheduleTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScheduleTemplate"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ScheduleTemplateFieldIndex.IsActive, true); }
			set	{ SetValue((int)ScheduleTemplateFieldIndex.IsActive, value); }
		}

		/// <summary> The ModifiedBy property of the Entity ScheduleTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScheduleTemplate"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ModifiedBy
		{
			get { return (System.Int64)GetValue((int)ScheduleTemplateFieldIndex.ModifiedBy, true); }
			set	{ SetValue((int)ScheduleTemplateFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity ScheduleTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblScheduleTemplate"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ScheduleTemplateFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)ScheduleTemplateFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventScheduleTemplateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventScheduleTemplateEntity))]
		public virtual EntityCollection<EventScheduleTemplateEntity> EventScheduleTemplate
		{
			get
			{
				if(_eventScheduleTemplate==null)
				{
					_eventScheduleTemplate = new EntityCollection<EventScheduleTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventScheduleTemplateEntityFactory)));
					_eventScheduleTemplate.SetContainingEntityInfo(this, "ScheduleTemplate");
				}
				return _eventScheduleTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ScheduleTemplateFranchiseeAccessEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ScheduleTemplateFranchiseeAccessEntity))]
		public virtual EntityCollection<ScheduleTemplateFranchiseeAccessEntity> ScheduleTemplateFranchiseeAccess
		{
			get
			{
				if(_scheduleTemplateFranchiseeAccess==null)
				{
					_scheduleTemplateFranchiseeAccess = new EntityCollection<ScheduleTemplateFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateFranchiseeAccessEntityFactory)));
					_scheduleTemplateFranchiseeAccess.SetContainingEntityInfo(this, "ScheduleTemplate");
				}
				return _scheduleTemplateFranchiseeAccess;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ScheduleTemplateTimeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ScheduleTemplateTimeEntity))]
		public virtual EntityCollection<ScheduleTemplateTimeEntity> ScheduleTemplateTime
		{
			get
			{
				if(_scheduleTemplateTime==null)
				{
					_scheduleTemplateTime = new EntityCollection<ScheduleTemplateTimeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateTimeEntityFactory)));
					_scheduleTemplateTime.SetContainingEntityInfo(this, "ScheduleTemplate");
				}
				return _scheduleTemplateTime;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventScheduleTemplate
		{
			get
			{
				if(_eventsCollectionViaEventScheduleTemplate==null)
				{
					_eventsCollectionViaEventScheduleTemplate = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventScheduleTemplate.IsReadOnly=true;
				}
				return _eventsCollectionViaEventScheduleTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> OrganizationCollectionViaScheduleTemplateFranchiseeAccess
		{
			get
			{
				if(_organizationCollectionViaScheduleTemplateFranchiseeAccess==null)
				{
					_organizationCollectionViaScheduleTemplateFranchiseeAccess = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organizationCollectionViaScheduleTemplateFranchiseeAccess.IsReadOnly=true;
				}
				return _organizationCollectionViaScheduleTemplateFranchiseeAccess;
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "ScheduleTemplate_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ScheduleTemplate_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "ScheduleTemplate");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ScheduleTemplate");
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
			get { return (int)Falcon.Data.EntityType.ScheduleTemplateEntity; }
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
