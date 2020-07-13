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
	/// Entity class which represents the entity 'EventActivityTemplate'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventActivityTemplateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventActivityTemplateCallEntity> _eventActivityTemplateCall;
		private EntityCollection<EventActivityTemplateEmailEntity> _eventActivityTemplateEmail;
		private EntityCollection<EventActivityTemplateHostEntity> _eventActivityTemplateHost;
		private EntityCollection<EventActivityTemplateMeetingEntity> _eventActivityTemplateMeeting;
		private EntityCollection<EventActivityTemplateTaskEntity> _eventActivityTemplateTask;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventActivityTemplateMeeting;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventActivityTemplateTask;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventActivityTemplateCall;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventActivityTemplateEmail;
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
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name EventActivityTemplateCall</summary>
			public static readonly string EventActivityTemplateCall = "EventActivityTemplateCall";
			/// <summary>Member name EventActivityTemplateEmail</summary>
			public static readonly string EventActivityTemplateEmail = "EventActivityTemplateEmail";
			/// <summary>Member name EventActivityTemplateHost</summary>
			public static readonly string EventActivityTemplateHost = "EventActivityTemplateHost";
			/// <summary>Member name EventActivityTemplateMeeting</summary>
			public static readonly string EventActivityTemplateMeeting = "EventActivityTemplateMeeting";
			/// <summary>Member name EventActivityTemplateTask</summary>
			public static readonly string EventActivityTemplateTask = "EventActivityTemplateTask";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventActivityTemplateMeeting</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventActivityTemplateMeeting = "OrganizationRoleUserCollectionViaEventActivityTemplateMeeting";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventActivityTemplateTask</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventActivityTemplateTask = "OrganizationRoleUserCollectionViaEventActivityTemplateTask";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventActivityTemplateCall</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventActivityTemplateCall = "OrganizationRoleUserCollectionViaEventActivityTemplateCall";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventActivityTemplateEmail</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventActivityTemplateEmail = "OrganizationRoleUserCollectionViaEventActivityTemplateEmail";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventActivityTemplateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventActivityTemplateEntity():base("EventActivityTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventActivityTemplateEntity(IEntityFields2 fields):base("EventActivityTemplateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventActivityTemplateEntity</param>
		public EventActivityTemplateEntity(IValidator validator):base("EventActivityTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eventActivityTemplateId">PK value for EventActivityTemplate which data should be fetched into this EventActivityTemplate object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventActivityTemplateEntity(System.Int64 eventActivityTemplateId):base("EventActivityTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EventActivityTemplateId = eventActivityTemplateId;
		}

		/// <summary> CTor</summary>
		/// <param name="eventActivityTemplateId">PK value for EventActivityTemplate which data should be fetched into this EventActivityTemplate object</param>
		/// <param name="validator">The custom validator object for this EventActivityTemplateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventActivityTemplateEntity(System.Int64 eventActivityTemplateId, IValidator validator):base("EventActivityTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EventActivityTemplateId = eventActivityTemplateId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventActivityTemplateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventActivityTemplateCall = (EntityCollection<EventActivityTemplateCallEntity>)info.GetValue("_eventActivityTemplateCall", typeof(EntityCollection<EventActivityTemplateCallEntity>));
				_eventActivityTemplateEmail = (EntityCollection<EventActivityTemplateEmailEntity>)info.GetValue("_eventActivityTemplateEmail", typeof(EntityCollection<EventActivityTemplateEmailEntity>));
				_eventActivityTemplateHost = (EntityCollection<EventActivityTemplateHostEntity>)info.GetValue("_eventActivityTemplateHost", typeof(EntityCollection<EventActivityTemplateHostEntity>));
				_eventActivityTemplateMeeting = (EntityCollection<EventActivityTemplateMeetingEntity>)info.GetValue("_eventActivityTemplateMeeting", typeof(EntityCollection<EventActivityTemplateMeetingEntity>));
				_eventActivityTemplateTask = (EntityCollection<EventActivityTemplateTaskEntity>)info.GetValue("_eventActivityTemplateTask", typeof(EntityCollection<EventActivityTemplateTaskEntity>));
				_organizationRoleUserCollectionViaEventActivityTemplateMeeting = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventActivityTemplateMeeting", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventActivityTemplateTask = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventActivityTemplateTask", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventActivityTemplateCall = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventActivityTemplateCall", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventActivityTemplateEmail = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventActivityTemplateEmail", typeof(EntityCollection<OrganizationRoleUserEntity>));
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
			switch((EventActivityTemplateFieldIndex)fieldIndex)
			{
				case EventActivityTemplateFieldIndex.OrganizationRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
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
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "EventActivityTemplateCall":
					this.EventActivityTemplateCall.Add((EventActivityTemplateCallEntity)entity);
					break;
				case "EventActivityTemplateEmail":
					this.EventActivityTemplateEmail.Add((EventActivityTemplateEmailEntity)entity);
					break;
				case "EventActivityTemplateHost":
					this.EventActivityTemplateHost.Add((EventActivityTemplateHostEntity)entity);
					break;
				case "EventActivityTemplateMeeting":
					this.EventActivityTemplateMeeting.Add((EventActivityTemplateMeetingEntity)entity);
					break;
				case "EventActivityTemplateTask":
					this.EventActivityTemplateTask.Add((EventActivityTemplateTaskEntity)entity);
					break;
				case "OrganizationRoleUserCollectionViaEventActivityTemplateMeeting":
					this.OrganizationRoleUserCollectionViaEventActivityTemplateMeeting.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventActivityTemplateMeeting.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventActivityTemplateMeeting.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventActivityTemplateTask":
					this.OrganizationRoleUserCollectionViaEventActivityTemplateTask.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventActivityTemplateTask.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventActivityTemplateTask.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventActivityTemplateCall":
					this.OrganizationRoleUserCollectionViaEventActivityTemplateCall.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventActivityTemplateCall.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventActivityTemplateCall.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventActivityTemplateEmail":
					this.OrganizationRoleUserCollectionViaEventActivityTemplateEmail.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventActivityTemplateEmail.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventActivityTemplateEmail.IsReadOnly = true;
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
			return EventActivityTemplateEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser":
					toReturn.Add(EventActivityTemplateEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId);
					break;
				case "EventActivityTemplateCall":
					toReturn.Add(EventActivityTemplateEntity.Relations.EventActivityTemplateCallEntityUsingEventActivityTemplateId);
					break;
				case "EventActivityTemplateEmail":
					toReturn.Add(EventActivityTemplateEntity.Relations.EventActivityTemplateEmailEntityUsingEventActivityTemplateId);
					break;
				case "EventActivityTemplateHost":
					toReturn.Add(EventActivityTemplateEntity.Relations.EventActivityTemplateHostEntityUsingEventActivityTemplateId);
					break;
				case "EventActivityTemplateMeeting":
					toReturn.Add(EventActivityTemplateEntity.Relations.EventActivityTemplateMeetingEntityUsingEventActivityTemplateId);
					break;
				case "EventActivityTemplateTask":
					toReturn.Add(EventActivityTemplateEntity.Relations.EventActivityTemplateTaskEntityUsingEventActivityTemplateId);
					break;
				case "OrganizationRoleUserCollectionViaEventActivityTemplateMeeting":
					toReturn.Add(EventActivityTemplateEntity.Relations.EventActivityTemplateMeetingEntityUsingEventActivityTemplateId, "EventActivityTemplateEntity__", "EventActivityTemplateMeeting_", JoinHint.None);
					toReturn.Add(EventActivityTemplateMeetingEntity.Relations.OrganizationRoleUserEntityUsingResponsibleOrgRoleUserId, "EventActivityTemplateMeeting_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventActivityTemplateTask":
					toReturn.Add(EventActivityTemplateEntity.Relations.EventActivityTemplateTaskEntityUsingEventActivityTemplateId, "EventActivityTemplateEntity__", "EventActivityTemplateTask_", JoinHint.None);
					toReturn.Add(EventActivityTemplateTaskEntity.Relations.OrganizationRoleUserEntityUsingResponsibleOrgRoleUserId, "EventActivityTemplateTask_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventActivityTemplateCall":
					toReturn.Add(EventActivityTemplateEntity.Relations.EventActivityTemplateCallEntityUsingEventActivityTemplateId, "EventActivityTemplateEntity__", "EventActivityTemplateCall_", JoinHint.None);
					toReturn.Add(EventActivityTemplateCallEntity.Relations.OrganizationRoleUserEntityUsingResponsibleOrgRoleUserId, "EventActivityTemplateCall_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventActivityTemplateEmail":
					toReturn.Add(EventActivityTemplateEntity.Relations.EventActivityTemplateEmailEntityUsingEventActivityTemplateId, "EventActivityTemplateEntity__", "EventActivityTemplateEmail_", JoinHint.None);
					toReturn.Add(EventActivityTemplateEmailEntity.Relations.OrganizationRoleUserEntityUsingResponsibleOrgRoleUserId, "EventActivityTemplateEmail_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "EventActivityTemplateCall":
					this.EventActivityTemplateCall.Add((EventActivityTemplateCallEntity)relatedEntity);
					break;
				case "EventActivityTemplateEmail":
					this.EventActivityTemplateEmail.Add((EventActivityTemplateEmailEntity)relatedEntity);
					break;
				case "EventActivityTemplateHost":
					this.EventActivityTemplateHost.Add((EventActivityTemplateHostEntity)relatedEntity);
					break;
				case "EventActivityTemplateMeeting":
					this.EventActivityTemplateMeeting.Add((EventActivityTemplateMeetingEntity)relatedEntity);
					break;
				case "EventActivityTemplateTask":
					this.EventActivityTemplateTask.Add((EventActivityTemplateTaskEntity)relatedEntity);
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
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "EventActivityTemplateCall":
					base.PerformRelatedEntityRemoval(this.EventActivityTemplateCall, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventActivityTemplateEmail":
					base.PerformRelatedEntityRemoval(this.EventActivityTemplateEmail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventActivityTemplateHost":
					base.PerformRelatedEntityRemoval(this.EventActivityTemplateHost, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventActivityTemplateMeeting":
					base.PerformRelatedEntityRemoval(this.EventActivityTemplateMeeting, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventActivityTemplateTask":
					base.PerformRelatedEntityRemoval(this.EventActivityTemplateTask, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.EventActivityTemplateCall);
			toReturn.Add(this.EventActivityTemplateEmail);
			toReturn.Add(this.EventActivityTemplateHost);
			toReturn.Add(this.EventActivityTemplateMeeting);
			toReturn.Add(this.EventActivityTemplateTask);

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
				info.AddValue("_eventActivityTemplateCall", ((_eventActivityTemplateCall!=null) && (_eventActivityTemplateCall.Count>0) && !this.MarkedForDeletion)?_eventActivityTemplateCall:null);
				info.AddValue("_eventActivityTemplateEmail", ((_eventActivityTemplateEmail!=null) && (_eventActivityTemplateEmail.Count>0) && !this.MarkedForDeletion)?_eventActivityTemplateEmail:null);
				info.AddValue("_eventActivityTemplateHost", ((_eventActivityTemplateHost!=null) && (_eventActivityTemplateHost.Count>0) && !this.MarkedForDeletion)?_eventActivityTemplateHost:null);
				info.AddValue("_eventActivityTemplateMeeting", ((_eventActivityTemplateMeeting!=null) && (_eventActivityTemplateMeeting.Count>0) && !this.MarkedForDeletion)?_eventActivityTemplateMeeting:null);
				info.AddValue("_eventActivityTemplateTask", ((_eventActivityTemplateTask!=null) && (_eventActivityTemplateTask.Count>0) && !this.MarkedForDeletion)?_eventActivityTemplateTask:null);
				info.AddValue("_organizationRoleUserCollectionViaEventActivityTemplateMeeting", ((_organizationRoleUserCollectionViaEventActivityTemplateMeeting!=null) && (_organizationRoleUserCollectionViaEventActivityTemplateMeeting.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventActivityTemplateMeeting:null);
				info.AddValue("_organizationRoleUserCollectionViaEventActivityTemplateTask", ((_organizationRoleUserCollectionViaEventActivityTemplateTask!=null) && (_organizationRoleUserCollectionViaEventActivityTemplateTask.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventActivityTemplateTask:null);
				info.AddValue("_organizationRoleUserCollectionViaEventActivityTemplateCall", ((_organizationRoleUserCollectionViaEventActivityTemplateCall!=null) && (_organizationRoleUserCollectionViaEventActivityTemplateCall.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventActivityTemplateCall:null);
				info.AddValue("_organizationRoleUserCollectionViaEventActivityTemplateEmail", ((_organizationRoleUserCollectionViaEventActivityTemplateEmail!=null) && (_organizationRoleUserCollectionViaEventActivityTemplateEmail.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventActivityTemplateEmail:null);
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
		public bool TestOriginalFieldValueForNull(EventActivityTemplateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventActivityTemplateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventActivityTemplateRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventActivityTemplateCall' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventActivityTemplateCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventActivityTemplateCallFields.EventActivityTemplateId, null, ComparisonOperator.Equal, this.EventActivityTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventActivityTemplateEmail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventActivityTemplateEmail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventActivityTemplateEmailFields.EventActivityTemplateId, null, ComparisonOperator.Equal, this.EventActivityTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventActivityTemplateHost' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventActivityTemplateHost()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventActivityTemplateHostFields.EventActivityTemplateId, null, ComparisonOperator.Equal, this.EventActivityTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventActivityTemplateMeeting' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventActivityTemplateMeeting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventActivityTemplateMeetingFields.EventActivityTemplateId, null, ComparisonOperator.Equal, this.EventActivityTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventActivityTemplateTask' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventActivityTemplateTask()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventActivityTemplateTaskFields.EventActivityTemplateId, null, ComparisonOperator.Equal, this.EventActivityTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventActivityTemplateMeeting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventActivityTemplateMeeting"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventActivityTemplateFields.EventActivityTemplateId, null, ComparisonOperator.Equal, this.EventActivityTemplateId, "EventActivityTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventActivityTemplateTask()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventActivityTemplateTask"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventActivityTemplateFields.EventActivityTemplateId, null, ComparisonOperator.Equal, this.EventActivityTemplateId, "EventActivityTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventActivityTemplateCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventActivityTemplateCall"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventActivityTemplateFields.EventActivityTemplateId, null, ComparisonOperator.Equal, this.EventActivityTemplateId, "EventActivityTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventActivityTemplateEmail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventActivityTemplateEmail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventActivityTemplateFields.EventActivityTemplateId, null, ComparisonOperator.Equal, this.EventActivityTemplateId, "EventActivityTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.OrganizationRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventActivityTemplateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventActivityTemplateCall);
			collectionsQueue.Enqueue(this._eventActivityTemplateEmail);
			collectionsQueue.Enqueue(this._eventActivityTemplateHost);
			collectionsQueue.Enqueue(this._eventActivityTemplateMeeting);
			collectionsQueue.Enqueue(this._eventActivityTemplateTask);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventActivityTemplateMeeting);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventActivityTemplateTask);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventActivityTemplateCall);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventActivityTemplateEmail);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventActivityTemplateCall = (EntityCollection<EventActivityTemplateCallEntity>) collectionsQueue.Dequeue();
			this._eventActivityTemplateEmail = (EntityCollection<EventActivityTemplateEmailEntity>) collectionsQueue.Dequeue();
			this._eventActivityTemplateHost = (EntityCollection<EventActivityTemplateHostEntity>) collectionsQueue.Dequeue();
			this._eventActivityTemplateMeeting = (EntityCollection<EventActivityTemplateMeetingEntity>) collectionsQueue.Dequeue();
			this._eventActivityTemplateTask = (EntityCollection<EventActivityTemplateTaskEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventActivityTemplateMeeting = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventActivityTemplateTask = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventActivityTemplateCall = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventActivityTemplateEmail = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventActivityTemplateCall != null)
			{
				return true;
			}
			if (this._eventActivityTemplateEmail != null)
			{
				return true;
			}
			if (this._eventActivityTemplateHost != null)
			{
				return true;
			}
			if (this._eventActivityTemplateMeeting != null)
			{
				return true;
			}
			if (this._eventActivityTemplateTask != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventActivityTemplateMeeting != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventActivityTemplateTask != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventActivityTemplateCall != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventActivityTemplateEmail != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventActivityTemplateCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateCallEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventActivityTemplateEmailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateEmailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventActivityTemplateHostEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateHostEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventActivityTemplateMeetingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateMeetingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventActivityTemplateTaskEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateTaskEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("EventActivityTemplateCall", _eventActivityTemplateCall);
			toReturn.Add("EventActivityTemplateEmail", _eventActivityTemplateEmail);
			toReturn.Add("EventActivityTemplateHost", _eventActivityTemplateHost);
			toReturn.Add("EventActivityTemplateMeeting", _eventActivityTemplateMeeting);
			toReturn.Add("EventActivityTemplateTask", _eventActivityTemplateTask);
			toReturn.Add("OrganizationRoleUserCollectionViaEventActivityTemplateMeeting", _organizationRoleUserCollectionViaEventActivityTemplateMeeting);
			toReturn.Add("OrganizationRoleUserCollectionViaEventActivityTemplateTask", _organizationRoleUserCollectionViaEventActivityTemplateTask);
			toReturn.Add("OrganizationRoleUserCollectionViaEventActivityTemplateCall", _organizationRoleUserCollectionViaEventActivityTemplateCall);
			toReturn.Add("OrganizationRoleUserCollectionViaEventActivityTemplateEmail", _organizationRoleUserCollectionViaEventActivityTemplateEmail);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventActivityTemplateCall!=null)
			{
				_eventActivityTemplateCall.ActiveContext = base.ActiveContext;
			}
			if(_eventActivityTemplateEmail!=null)
			{
				_eventActivityTemplateEmail.ActiveContext = base.ActiveContext;
			}
			if(_eventActivityTemplateHost!=null)
			{
				_eventActivityTemplateHost.ActiveContext = base.ActiveContext;
			}
			if(_eventActivityTemplateMeeting!=null)
			{
				_eventActivityTemplateMeeting.ActiveContext = base.ActiveContext;
			}
			if(_eventActivityTemplateTask!=null)
			{
				_eventActivityTemplateTask.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventActivityTemplateMeeting!=null)
			{
				_organizationRoleUserCollectionViaEventActivityTemplateMeeting.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventActivityTemplateTask!=null)
			{
				_organizationRoleUserCollectionViaEventActivityTemplateTask.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventActivityTemplateCall!=null)
			{
				_organizationRoleUserCollectionViaEventActivityTemplateCall.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventActivityTemplateEmail!=null)
			{
				_organizationRoleUserCollectionViaEventActivityTemplateEmail.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventActivityTemplateCall = null;
			_eventActivityTemplateEmail = null;
			_eventActivityTemplateHost = null;
			_eventActivityTemplateMeeting = null;
			_eventActivityTemplateTask = null;
			_organizationRoleUserCollectionViaEventActivityTemplateMeeting = null;
			_organizationRoleUserCollectionViaEventActivityTemplateTask = null;
			_organizationRoleUserCollectionViaEventActivityTemplateCall = null;
			_organizationRoleUserCollectionViaEventActivityTemplateEmail = null;
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

			_fieldsCustomProperties.Add("EventActivityTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TemplateName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsGlobal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventActivityTemplateEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId, true, signalRelatedEntity, "EventActivityTemplate", resetFKFields, new int[] { (int)EventActivityTemplateFieldIndex.OrganizationRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventActivityTemplateEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this EventActivityTemplateEntity</param>
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
		public  static EventActivityTemplateRelations Relations
		{
			get	{ return new EventActivityTemplateRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventActivityTemplateCall' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventActivityTemplateCall
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventActivityTemplateCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateCallEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventActivityTemplateCall")[0], (int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.EventActivityTemplateCallEntity, 0, null, null, null, null, "EventActivityTemplateCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventActivityTemplateEmail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventActivityTemplateEmail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventActivityTemplateEmailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateEmailEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventActivityTemplateEmail")[0], (int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.EventActivityTemplateEmailEntity, 0, null, null, null, null, "EventActivityTemplateEmail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventActivityTemplateHost' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventActivityTemplateHost
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventActivityTemplateHostEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateHostEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventActivityTemplateHost")[0], (int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.EventActivityTemplateHostEntity, 0, null, null, null, null, "EventActivityTemplateHost", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventActivityTemplateMeeting' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventActivityTemplateMeeting
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventActivityTemplateMeetingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateMeetingEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventActivityTemplateMeeting")[0], (int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.EventActivityTemplateMeetingEntity, 0, null, null, null, null, "EventActivityTemplateMeeting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventActivityTemplateTask' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventActivityTemplateTask
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventActivityTemplateTaskEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateTaskEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventActivityTemplateTask")[0], (int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.EventActivityTemplateTaskEntity, 0, null, null, null, null, "EventActivityTemplateTask", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventActivityTemplateMeeting
		{
			get
			{
				IEntityRelation intermediateRelation = EventActivityTemplateEntity.Relations.EventActivityTemplateMeetingEntityUsingEventActivityTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventActivityTemplateMeeting_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventActivityTemplateMeeting"), null, "OrganizationRoleUserCollectionViaEventActivityTemplateMeeting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventActivityTemplateTask
		{
			get
			{
				IEntityRelation intermediateRelation = EventActivityTemplateEntity.Relations.EventActivityTemplateTaskEntityUsingEventActivityTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventActivityTemplateTask_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventActivityTemplateTask"), null, "OrganizationRoleUserCollectionViaEventActivityTemplateTask", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventActivityTemplateCall
		{
			get
			{
				IEntityRelation intermediateRelation = EventActivityTemplateEntity.Relations.EventActivityTemplateCallEntityUsingEventActivityTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventActivityTemplateCall_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventActivityTemplateCall"), null, "OrganizationRoleUserCollectionViaEventActivityTemplateCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventActivityTemplateEmail
		{
			get
			{
				IEntityRelation intermediateRelation = EventActivityTemplateEntity.Relations.EventActivityTemplateEmailEntityUsingEventActivityTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventActivityTemplateEmail_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventActivityTemplateEmail"), null, "OrganizationRoleUserCollectionViaEventActivityTemplateEmail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.EventActivityTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventActivityTemplateEntity.CustomProperties;}
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
			get { return EventActivityTemplateEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventActivityTemplateId property of the Entity EventActivityTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventActivityTemplate"."EventActivityTemplateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 EventActivityTemplateId
		{
			get { return (System.Int64)GetValue((int)EventActivityTemplateFieldIndex.EventActivityTemplateId, true); }
			set	{ SetValue((int)EventActivityTemplateFieldIndex.EventActivityTemplateId, value); }
		}

		/// <summary> The TemplateName property of the Entity EventActivityTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventActivityTemplate"."TemplateName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String TemplateName
		{
			get { return (System.String)GetValue((int)EventActivityTemplateFieldIndex.TemplateName, true); }
			set	{ SetValue((int)EventActivityTemplateFieldIndex.TemplateName, value); }
		}

		/// <summary> The IsGlobal property of the Entity EventActivityTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventActivityTemplate"."IsGlobal"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsGlobal
		{
			get { return (System.Boolean)GetValue((int)EventActivityTemplateFieldIndex.IsGlobal, true); }
			set	{ SetValue((int)EventActivityTemplateFieldIndex.IsGlobal, value); }
		}

		/// <summary> The DateCreated property of the Entity EventActivityTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventActivityTemplate"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)EventActivityTemplateFieldIndex.DateCreated, true); }
			set	{ SetValue((int)EventActivityTemplateFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity EventActivityTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventActivityTemplate"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)EventActivityTemplateFieldIndex.DateModified, true); }
			set	{ SetValue((int)EventActivityTemplateFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity EventActivityTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventActivityTemplate"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)EventActivityTemplateFieldIndex.IsActive, true); }
			set	{ SetValue((int)EventActivityTemplateFieldIndex.IsActive, value); }
		}

		/// <summary> The OrganizationRoleUserId property of the Entity EventActivityTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventActivityTemplate"."OrganizationRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationRoleUserId
		{
			get { return (System.Int64)GetValue((int)EventActivityTemplateFieldIndex.OrganizationRoleUserId, true); }
			set	{ SetValue((int)EventActivityTemplateFieldIndex.OrganizationRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventActivityTemplateCallEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventActivityTemplateCallEntity))]
		public virtual EntityCollection<EventActivityTemplateCallEntity> EventActivityTemplateCall
		{
			get
			{
				if(_eventActivityTemplateCall==null)
				{
					_eventActivityTemplateCall = new EntityCollection<EventActivityTemplateCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateCallEntityFactory)));
					_eventActivityTemplateCall.SetContainingEntityInfo(this, "EventActivityTemplate");
				}
				return _eventActivityTemplateCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventActivityTemplateEmailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventActivityTemplateEmailEntity))]
		public virtual EntityCollection<EventActivityTemplateEmailEntity> EventActivityTemplateEmail
		{
			get
			{
				if(_eventActivityTemplateEmail==null)
				{
					_eventActivityTemplateEmail = new EntityCollection<EventActivityTemplateEmailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateEmailEntityFactory)));
					_eventActivityTemplateEmail.SetContainingEntityInfo(this, "EventActivityTemplate");
				}
				return _eventActivityTemplateEmail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventActivityTemplateHostEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventActivityTemplateHostEntity))]
		public virtual EntityCollection<EventActivityTemplateHostEntity> EventActivityTemplateHost
		{
			get
			{
				if(_eventActivityTemplateHost==null)
				{
					_eventActivityTemplateHost = new EntityCollection<EventActivityTemplateHostEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateHostEntityFactory)));
					_eventActivityTemplateHost.SetContainingEntityInfo(this, "EventActivityTemplate");
				}
				return _eventActivityTemplateHost;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventActivityTemplateMeetingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventActivityTemplateMeetingEntity))]
		public virtual EntityCollection<EventActivityTemplateMeetingEntity> EventActivityTemplateMeeting
		{
			get
			{
				if(_eventActivityTemplateMeeting==null)
				{
					_eventActivityTemplateMeeting = new EntityCollection<EventActivityTemplateMeetingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateMeetingEntityFactory)));
					_eventActivityTemplateMeeting.SetContainingEntityInfo(this, "EventActivityTemplate");
				}
				return _eventActivityTemplateMeeting;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventActivityTemplateTaskEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventActivityTemplateTaskEntity))]
		public virtual EntityCollection<EventActivityTemplateTaskEntity> EventActivityTemplateTask
		{
			get
			{
				if(_eventActivityTemplateTask==null)
				{
					_eventActivityTemplateTask = new EntityCollection<EventActivityTemplateTaskEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventActivityTemplateTaskEntityFactory)));
					_eventActivityTemplateTask.SetContainingEntityInfo(this, "EventActivityTemplate");
				}
				return _eventActivityTemplateTask;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventActivityTemplateMeeting
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventActivityTemplateMeeting==null)
				{
					_organizationRoleUserCollectionViaEventActivityTemplateMeeting = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventActivityTemplateMeeting.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventActivityTemplateMeeting;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventActivityTemplateTask
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventActivityTemplateTask==null)
				{
					_organizationRoleUserCollectionViaEventActivityTemplateTask = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventActivityTemplateTask.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventActivityTemplateTask;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventActivityTemplateCall
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventActivityTemplateCall==null)
				{
					_organizationRoleUserCollectionViaEventActivityTemplateCall = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventActivityTemplateCall.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventActivityTemplateCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventActivityTemplateEmail
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventActivityTemplateEmail==null)
				{
					_organizationRoleUserCollectionViaEventActivityTemplateEmail = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventActivityTemplateEmail.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventActivityTemplateEmail;
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
							_organizationRoleUser.UnsetRelatedEntity(this, "EventActivityTemplate");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventActivityTemplate");
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
			get { return (int)Falcon.Data.EntityType.EventActivityTemplateEntity; }
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
