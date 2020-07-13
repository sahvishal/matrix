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
	/// Entity class which represents the entity 'EventAppointmentCancellationLog'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventAppointmentCancellationLogEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CustomerRegistrationNotesEntity _customerRegistrationNotes;
		private EventCustomersEntity _eventCustomers;
		private EventsEntity _events;
		private LookupEntity _lookup;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private RefundRequestEntity _refundRequest;
		private RescheduleCancelDispositionEntity _rescheduleCancelDisposition;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerRegistrationNotes</summary>
			public static readonly string CustomerRegistrationNotes = "CustomerRegistrationNotes";
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name RefundRequest</summary>
			public static readonly string RefundRequest = "RefundRequest";
			/// <summary>Member name RescheduleCancelDisposition</summary>
			public static readonly string RescheduleCancelDisposition = "RescheduleCancelDisposition";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventAppointmentCancellationLogEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventAppointmentCancellationLogEntity():base("EventAppointmentCancellationLogEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventAppointmentCancellationLogEntity(IEntityFields2 fields):base("EventAppointmentCancellationLogEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventAppointmentCancellationLogEntity</param>
		public EventAppointmentCancellationLogEntity(IValidator validator):base("EventAppointmentCancellationLogEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for EventAppointmentCancellationLog which data should be fetched into this EventAppointmentCancellationLog object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventAppointmentCancellationLogEntity(System.Int64 id):base("EventAppointmentCancellationLogEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for EventAppointmentCancellationLog which data should be fetched into this EventAppointmentCancellationLog object</param>
		/// <param name="validator">The custom validator object for this EventAppointmentCancellationLogEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventAppointmentCancellationLogEntity(System.Int64 id, IValidator validator):base("EventAppointmentCancellationLogEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventAppointmentCancellationLogEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_customerRegistrationNotes = (CustomerRegistrationNotesEntity)info.GetValue("_customerRegistrationNotes", typeof(CustomerRegistrationNotesEntity));
				if(_customerRegistrationNotes!=null)
				{
					_customerRegistrationNotes.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomers = (EventCustomersEntity)info.GetValue("_eventCustomers", typeof(EventCustomersEntity));
				if(_eventCustomers!=null)
				{
					_eventCustomers.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_refundRequest = (RefundRequestEntity)info.GetValue("_refundRequest", typeof(RefundRequestEntity));
				if(_refundRequest!=null)
				{
					_refundRequest.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_rescheduleCancelDisposition = (RescheduleCancelDispositionEntity)info.GetValue("_rescheduleCancelDisposition", typeof(RescheduleCancelDispositionEntity));
				if(_rescheduleCancelDisposition!=null)
				{
					_rescheduleCancelDisposition.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EventAppointmentCancellationLogFieldIndex)fieldIndex)
			{
				case EventAppointmentCancellationLogFieldIndex.EventCustomerId:
					DesetupSyncEventCustomers(true, false);
					break;
				case EventAppointmentCancellationLogFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case EventAppointmentCancellationLogFieldIndex.ReasonId:
					DesetupSyncLookup(true, false);
					break;
				case EventAppointmentCancellationLogFieldIndex.NoteId:
					DesetupSyncCustomerRegistrationNotes(true, false);
					break;
				case EventAppointmentCancellationLogFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case EventAppointmentCancellationLogFieldIndex.RefundRequestId:
					DesetupSyncRefundRequest(true, false);
					break;
				case EventAppointmentCancellationLogFieldIndex.SubReasonId:
					DesetupSyncRescheduleCancelDisposition(true, false);
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
				case "CustomerRegistrationNotes":
					this.CustomerRegistrationNotes = (CustomerRegistrationNotesEntity)entity;
					break;
				case "EventCustomers":
					this.EventCustomers = (EventCustomersEntity)entity;
					break;
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "RefundRequest":
					this.RefundRequest = (RefundRequestEntity)entity;
					break;
				case "RescheduleCancelDisposition":
					this.RescheduleCancelDisposition = (RescheduleCancelDispositionEntity)entity;
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
			return EventAppointmentCancellationLogEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerRegistrationNotes":
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.CustomerRegistrationNotesEntityUsingNoteId);
					break;
				case "EventCustomers":
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.EventCustomersEntityUsingEventCustomerId);
					break;
				case "Events":
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.EventsEntityUsingEventId);
					break;
				case "Lookup":
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.LookupEntityUsingReasonId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "RefundRequest":
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.RefundRequestEntityUsingRefundRequestId);
					break;
				case "RescheduleCancelDisposition":
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.RescheduleCancelDispositionEntityUsingSubReasonId);
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
				case "CustomerRegistrationNotes":
					SetupSyncCustomerRegistrationNotes(relatedEntity);
					break;
				case "EventCustomers":
					SetupSyncEventCustomers(relatedEntity);
					break;
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "RefundRequest":
					SetupSyncRefundRequest(relatedEntity);
					break;
				case "RescheduleCancelDisposition":
					SetupSyncRescheduleCancelDisposition(relatedEntity);
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
				case "CustomerRegistrationNotes":
					DesetupSyncCustomerRegistrationNotes(false, true);
					break;
				case "EventCustomers":
					DesetupSyncEventCustomers(false, true);
					break;
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "RefundRequest":
					DesetupSyncRefundRequest(false, true);
					break;
				case "RescheduleCancelDisposition":
					DesetupSyncRescheduleCancelDisposition(false, true);
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
			if(_customerRegistrationNotes!=null)
			{
				toReturn.Add(_customerRegistrationNotes);
			}
			if(_eventCustomers!=null)
			{
				toReturn.Add(_eventCustomers);
			}
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_refundRequest!=null)
			{
				toReturn.Add(_refundRequest);
			}
			if(_rescheduleCancelDisposition!=null)
			{
				toReturn.Add(_rescheduleCancelDisposition);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();


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


				info.AddValue("_customerRegistrationNotes", (!this.MarkedForDeletion?_customerRegistrationNotes:null));
				info.AddValue("_eventCustomers", (!this.MarkedForDeletion?_eventCustomers:null));
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_refundRequest", (!this.MarkedForDeletion?_refundRequest:null));
				info.AddValue("_rescheduleCancelDisposition", (!this.MarkedForDeletion?_rescheduleCancelDisposition:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(EventAppointmentCancellationLogFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventAppointmentCancellationLogFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventAppointmentCancellationLogRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerRegistrationNotes' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerRegistrationNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Events' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.EventId, null, ComparisonOperator.Equal, this.EventId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ReasonId));
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

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'RefundRequest' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundRequest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'RescheduleCancelDisposition' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRescheduleCancelDisposition()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RescheduleCancelDispositionFields.Id, null, ComparisonOperator.Equal, this.SubReasonId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventAppointmentCancellationLogEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{


			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CustomerRegistrationNotes", _customerRegistrationNotes);
			toReturn.Add("EventCustomers", _eventCustomers);
			toReturn.Add("Events", _events);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("RefundRequest", _refundRequest);
			toReturn.Add("RescheduleCancelDisposition", _rescheduleCancelDisposition);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_customerRegistrationNotes!=null)
			{
				_customerRegistrationNotes.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomers!=null)
			{
				_eventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_refundRequest!=null)
			{
				_refundRequest.ActiveContext = base.ActiveContext;
			}
			if(_rescheduleCancelDisposition!=null)
			{
				_rescheduleCancelDisposition.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_customerRegistrationNotes = null;
			_eventCustomers = null;
			_events = null;
			_lookup = null;
			_organizationRoleUser = null;
			_refundRequest = null;
			_rescheduleCancelDisposition = null;

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

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoteId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RefundRequestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SubReasonId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerRegistrationNotes</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerRegistrationNotes(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerRegistrationNotes, new PropertyChangedEventHandler( OnCustomerRegistrationNotesPropertyChanged ), "CustomerRegistrationNotes", EventAppointmentCancellationLogEntity.Relations.CustomerRegistrationNotesEntityUsingNoteId, true, signalRelatedEntity, "EventAppointmentCancellationLog", resetFKFields, new int[] { (int)EventAppointmentCancellationLogFieldIndex.NoteId } );		
			_customerRegistrationNotes = null;
		}

		/// <summary> setups the sync logic for member _customerRegistrationNotes</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerRegistrationNotes(IEntity2 relatedEntity)
		{
			if(_customerRegistrationNotes!=relatedEntity)
			{
				DesetupSyncCustomerRegistrationNotes(true, true);
				_customerRegistrationNotes = (CustomerRegistrationNotesEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerRegistrationNotes, new PropertyChangedEventHandler( OnCustomerRegistrationNotesPropertyChanged ), "CustomerRegistrationNotes", EventAppointmentCancellationLogEntity.Relations.CustomerRegistrationNotesEntityUsingNoteId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerRegistrationNotesPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomers</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomers(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", EventAppointmentCancellationLogEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, signalRelatedEntity, "EventAppointmentCancellationLog", resetFKFields, new int[] { (int)EventAppointmentCancellationLogFieldIndex.EventCustomerId } );		
			_eventCustomers = null;
		}

		/// <summary> setups the sync logic for member _eventCustomers</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomers(IEntity2 relatedEntity)
		{
			if(_eventCustomers!=relatedEntity)
			{
				DesetupSyncEventCustomers(true, true);
				_eventCustomers = (EventCustomersEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", EventAppointmentCancellationLogEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomersPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventAppointmentCancellationLogEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "EventAppointmentCancellationLog", resetFKFields, new int[] { (int)EventAppointmentCancellationLogFieldIndex.EventId } );		
			_events = null;
		}

		/// <summary> setups the sync logic for member _events</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEvents(IEntity2 relatedEntity)
		{
			if(_events!=relatedEntity)
			{
				DesetupSyncEvents(true, true);
				_events = (EventsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventAppointmentCancellationLogEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventsPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventAppointmentCancellationLogEntity.Relations.LookupEntityUsingReasonId, true, signalRelatedEntity, "EventAppointmentCancellationLog", resetFKFields, new int[] { (int)EventAppointmentCancellationLogFieldIndex.ReasonId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventAppointmentCancellationLogEntity.Relations.LookupEntityUsingReasonId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventAppointmentCancellationLogEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "EventAppointmentCancellationLog", resetFKFields, new int[] { (int)EventAppointmentCancellationLogFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventAppointmentCancellationLogEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _refundRequest</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRefundRequest(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _refundRequest, new PropertyChangedEventHandler( OnRefundRequestPropertyChanged ), "RefundRequest", EventAppointmentCancellationLogEntity.Relations.RefundRequestEntityUsingRefundRequestId, true, signalRelatedEntity, "EventAppointmentCancellationLog", resetFKFields, new int[] { (int)EventAppointmentCancellationLogFieldIndex.RefundRequestId } );		
			_refundRequest = null;
		}

		/// <summary> setups the sync logic for member _refundRequest</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRefundRequest(IEntity2 relatedEntity)
		{
			if(_refundRequest!=relatedEntity)
			{
				DesetupSyncRefundRequest(true, true);
				_refundRequest = (RefundRequestEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _refundRequest, new PropertyChangedEventHandler( OnRefundRequestPropertyChanged ), "RefundRequest", EventAppointmentCancellationLogEntity.Relations.RefundRequestEntityUsingRefundRequestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRefundRequestPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _rescheduleCancelDisposition</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRescheduleCancelDisposition(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _rescheduleCancelDisposition, new PropertyChangedEventHandler( OnRescheduleCancelDispositionPropertyChanged ), "RescheduleCancelDisposition", EventAppointmentCancellationLogEntity.Relations.RescheduleCancelDispositionEntityUsingSubReasonId, true, signalRelatedEntity, "EventAppointmentCancellationLog", resetFKFields, new int[] { (int)EventAppointmentCancellationLogFieldIndex.SubReasonId } );		
			_rescheduleCancelDisposition = null;
		}

		/// <summary> setups the sync logic for member _rescheduleCancelDisposition</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRescheduleCancelDisposition(IEntity2 relatedEntity)
		{
			if(_rescheduleCancelDisposition!=relatedEntity)
			{
				DesetupSyncRescheduleCancelDisposition(true, true);
				_rescheduleCancelDisposition = (RescheduleCancelDispositionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _rescheduleCancelDisposition, new PropertyChangedEventHandler( OnRescheduleCancelDispositionPropertyChanged ), "RescheduleCancelDisposition", EventAppointmentCancellationLogEntity.Relations.RescheduleCancelDispositionEntityUsingSubReasonId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRescheduleCancelDispositionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EventAppointmentCancellationLogEntity</param>
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
		public  static EventAppointmentCancellationLogRelations Relations
		{
			get	{ return new EventAppointmentCancellationLogRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerRegistrationNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerRegistrationNotes
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerRegistrationNotes")[0], (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, 0, null, null, null, null, "CustomerRegistrationNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomers
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundRequest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundRequest
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))),
					(IEntityRelation)GetRelationsForField("RefundRequest")[0], (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, (int)Falcon.Data.EntityType.RefundRequestEntity, 0, null, null, null, null, "RefundRequest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RescheduleCancelDisposition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRescheduleCancelDisposition
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory))),
					(IEntityRelation)GetRelationsForField("RescheduleCancelDisposition")[0], (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, (int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, 0, null, null, null, null, "RescheduleCancelDisposition", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventAppointmentCancellationLogEntity.CustomProperties;}
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
			get { return EventAppointmentCancellationLogEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity EventAppointmentCancellationLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointmentCancellationLog"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)EventAppointmentCancellationLogFieldIndex.Id, true); }
			set	{ SetValue((int)EventAppointmentCancellationLogFieldIndex.Id, value); }
		}

		/// <summary> The EventCustomerId property of the Entity EventAppointmentCancellationLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointmentCancellationLog"."EventCustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventCustomerId
		{
			get { return (System.Int64)GetValue((int)EventAppointmentCancellationLogFieldIndex.EventCustomerId, true); }
			set	{ SetValue((int)EventAppointmentCancellationLogFieldIndex.EventCustomerId, value); }
		}

		/// <summary> The EventId property of the Entity EventAppointmentCancellationLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointmentCancellationLog"."EventId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)EventAppointmentCancellationLogFieldIndex.EventId, true); }
			set	{ SetValue((int)EventAppointmentCancellationLogFieldIndex.EventId, value); }
		}

		/// <summary> The ReasonId property of the Entity EventAppointmentCancellationLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointmentCancellationLog"."ReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ReasonId
		{
			get { return (System.Int64)GetValue((int)EventAppointmentCancellationLogFieldIndex.ReasonId, true); }
			set	{ SetValue((int)EventAppointmentCancellationLogFieldIndex.ReasonId, value); }
		}

		/// <summary> The NoteId property of the Entity EventAppointmentCancellationLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointmentCancellationLog"."NoteId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> NoteId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventAppointmentCancellationLogFieldIndex.NoteId, false); }
			set	{ SetValue((int)EventAppointmentCancellationLogFieldIndex.NoteId, value); }
		}

		/// <summary> The DateCreated property of the Entity EventAppointmentCancellationLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointmentCancellationLog"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)EventAppointmentCancellationLogFieldIndex.DateCreated, true); }
			set	{ SetValue((int)EventAppointmentCancellationLogFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedBy property of the Entity EventAppointmentCancellationLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointmentCancellationLog"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)EventAppointmentCancellationLogFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)EventAppointmentCancellationLogFieldIndex.CreatedBy, value); }
		}

		/// <summary> The RefundRequestId property of the Entity EventAppointmentCancellationLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointmentCancellationLog"."RefundRequestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RefundRequestId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventAppointmentCancellationLogFieldIndex.RefundRequestId, false); }
			set	{ SetValue((int)EventAppointmentCancellationLogFieldIndex.RefundRequestId, value); }
		}

		/// <summary> The SubReasonId property of the Entity EventAppointmentCancellationLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointmentCancellationLog"."SubReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SubReasonId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventAppointmentCancellationLogFieldIndex.SubReasonId, false); }
			set	{ SetValue((int)EventAppointmentCancellationLogFieldIndex.SubReasonId, value); }
		}



		/// <summary> Gets / sets related entity of type 'CustomerRegistrationNotesEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerRegistrationNotesEntity CustomerRegistrationNotes
		{
			get
			{
				return _customerRegistrationNotes;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerRegistrationNotes(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerRegistrationNotes != null)
						{
							_customerRegistrationNotes.UnsetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
					else
					{
						if(_customerRegistrationNotes!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomersEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomersEntity EventCustomers
		{
			get
			{
				return _eventCustomers;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomers(value);
				}
				else
				{
					if(value==null)
					{
						if(_eventCustomers != null)
						{
							_eventCustomers.UnsetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
					else
					{
						if(_eventCustomers!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventsEntity Events
		{
			get
			{
				return _events;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEvents(value);
				}
				else
				{
					if(value==null)
					{
						if(_events != null)
						{
							_events.UnsetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventAppointmentCancellationLog");
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
							_lookup.UnsetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventAppointmentCancellationLog");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'RefundRequestEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual RefundRequestEntity RefundRequest
		{
			get
			{
				return _refundRequest;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncRefundRequest(value);
				}
				else
				{
					if(value==null)
					{
						if(_refundRequest != null)
						{
							_refundRequest.UnsetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
					else
					{
						if(_refundRequest!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'RescheduleCancelDispositionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual RescheduleCancelDispositionEntity RescheduleCancelDisposition
		{
			get
			{
				return _rescheduleCancelDisposition;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncRescheduleCancelDisposition(value);
				}
				else
				{
					if(value==null)
					{
						if(_rescheduleCancelDisposition != null)
						{
							_rescheduleCancelDisposition.UnsetRelatedEntity(this, "EventAppointmentCancellationLog");
						}
					}
					else
					{
						if(_rescheduleCancelDisposition!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventAppointmentCancellationLog");
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
			get { return (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity; }
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
