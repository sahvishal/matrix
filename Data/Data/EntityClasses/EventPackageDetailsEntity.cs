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
	/// Entity class which represents the entity 'EventPackageDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventPackageDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerOrderHistoryEntity> _customerOrderHistory;
		private EntityCollection<EventPackageOrderItemEntity> _eventPackageOrderItem;
		private EntityCollection<EventPackageTestEntity> _eventPackageTest;
		private EntityCollection<EventPaymentDetailsEntity> _eventPaymentDetails;
		private EntityCollection<CorporateUploadEntity> _corporateUploadCollectionViaCustomerOrderHistory;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaEventPaymentDetails;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerOrderHistory;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCustomerOrderHistory;
		private EntityCollection<EventsEntity> _eventsCollectionViaCustomerOrderHistory;
		private EntityCollection<EventTestEntity> _eventTestCollectionViaEventPackageTest;
		private EntityCollection<EventTestEntity> _eventTestCollectionViaCustomerOrderHistory;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerOrderHistory;
		private EntityCollection<OrderItemEntity> _orderItemCollectionViaEventPackageOrderItem;
		private EventsEntity _events;
		private HafTemplateEntity _hafTemplate;
		private LookupEntity _lookup;
		private PackageEntity _package;
		private PodRoomEntity _podRoom;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name HafTemplate</summary>
			public static readonly string HafTemplate = "HafTemplate";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Package</summary>
			public static readonly string Package = "Package";
			/// <summary>Member name PodRoom</summary>
			public static readonly string PodRoom = "PodRoom";
			/// <summary>Member name CustomerOrderHistory</summary>
			public static readonly string CustomerOrderHistory = "CustomerOrderHistory";
			/// <summary>Member name EventPackageOrderItem</summary>
			public static readonly string EventPackageOrderItem = "EventPackageOrderItem";
			/// <summary>Member name EventPackageTest</summary>
			public static readonly string EventPackageTest = "EventPackageTest";
			/// <summary>Member name EventPaymentDetails</summary>
			public static readonly string EventPaymentDetails = "EventPaymentDetails";
			/// <summary>Member name CorporateUploadCollectionViaCustomerOrderHistory</summary>
			public static readonly string CorporateUploadCollectionViaCustomerOrderHistory = "CorporateUploadCollectionViaCustomerOrderHistory";
			/// <summary>Member name CustomerProfileCollectionViaEventPaymentDetails</summary>
			public static readonly string CustomerProfileCollectionViaEventPaymentDetails = "CustomerProfileCollectionViaEventPaymentDetails";
			/// <summary>Member name CustomerProfileCollectionViaCustomerOrderHistory</summary>
			public static readonly string CustomerProfileCollectionViaCustomerOrderHistory = "CustomerProfileCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventCustomersCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventCustomersCollectionViaCustomerOrderHistory = "EventCustomersCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventsCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventsCollectionViaCustomerOrderHistory = "EventsCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventTestCollectionViaEventPackageTest</summary>
			public static readonly string EventTestCollectionViaEventPackageTest = "EventTestCollectionViaEventPackageTest";
			/// <summary>Member name EventTestCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventTestCollectionViaCustomerOrderHistory = "EventTestCollectionViaCustomerOrderHistory";
			/// <summary>Member name LookupCollectionViaCustomerOrderHistory</summary>
			public static readonly string LookupCollectionViaCustomerOrderHistory = "LookupCollectionViaCustomerOrderHistory";
			/// <summary>Member name OrderItemCollectionViaEventPackageOrderItem</summary>
			public static readonly string OrderItemCollectionViaEventPackageOrderItem = "OrderItemCollectionViaEventPackageOrderItem";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventPackageDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventPackageDetailsEntity():base("EventPackageDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventPackageDetailsEntity(IEntityFields2 fields):base("EventPackageDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventPackageDetailsEntity</param>
		public EventPackageDetailsEntity(IValidator validator):base("EventPackageDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eventPackageId">PK value for EventPackageDetails which data should be fetched into this EventPackageDetails object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventPackageDetailsEntity(System.Int64 eventPackageId):base("EventPackageDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EventPackageId = eventPackageId;
		}

		/// <summary> CTor</summary>
		/// <param name="eventPackageId">PK value for EventPackageDetails which data should be fetched into this EventPackageDetails object</param>
		/// <param name="validator">The custom validator object for this EventPackageDetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventPackageDetailsEntity(System.Int64 eventPackageId, IValidator validator):base("EventPackageDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EventPackageId = eventPackageId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventPackageDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerOrderHistory = (EntityCollection<CustomerOrderHistoryEntity>)info.GetValue("_customerOrderHistory", typeof(EntityCollection<CustomerOrderHistoryEntity>));
				_eventPackageOrderItem = (EntityCollection<EventPackageOrderItemEntity>)info.GetValue("_eventPackageOrderItem", typeof(EntityCollection<EventPackageOrderItemEntity>));
				_eventPackageTest = (EntityCollection<EventPackageTestEntity>)info.GetValue("_eventPackageTest", typeof(EntityCollection<EventPackageTestEntity>));
				_eventPaymentDetails = (EntityCollection<EventPaymentDetailsEntity>)info.GetValue("_eventPaymentDetails", typeof(EntityCollection<EventPaymentDetailsEntity>));
				_corporateUploadCollectionViaCustomerOrderHistory = (EntityCollection<CorporateUploadEntity>)info.GetValue("_corporateUploadCollectionViaCustomerOrderHistory", typeof(EntityCollection<CorporateUploadEntity>));
				_customerProfileCollectionViaEventPaymentDetails = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaEventPaymentDetails", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerOrderHistory = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerOrderHistory", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaCustomerOrderHistory = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaCustomerOrderHistory = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventsEntity>));
				_eventTestCollectionViaEventPackageTest = (EntityCollection<EventTestEntity>)info.GetValue("_eventTestCollectionViaEventPackageTest", typeof(EntityCollection<EventTestEntity>));
				_eventTestCollectionViaCustomerOrderHistory = (EntityCollection<EventTestEntity>)info.GetValue("_eventTestCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventTestEntity>));
				_lookupCollectionViaCustomerOrderHistory = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerOrderHistory", typeof(EntityCollection<LookupEntity>));
				_orderItemCollectionViaEventPackageOrderItem = (EntityCollection<OrderItemEntity>)info.GetValue("_orderItemCollectionViaEventPackageOrderItem", typeof(EntityCollection<OrderItemEntity>));
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hafTemplate = (HafTemplateEntity)info.GetValue("_hafTemplate", typeof(HafTemplateEntity));
				if(_hafTemplate!=null)
				{
					_hafTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_package = (PackageEntity)info.GetValue("_package", typeof(PackageEntity));
				if(_package!=null)
				{
					_package.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_podRoom = (PodRoomEntity)info.GetValue("_podRoom", typeof(PodRoomEntity));
				if(_podRoom!=null)
				{
					_podRoom.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EventPackageDetailsFieldIndex)fieldIndex)
			{
				case EventPackageDetailsFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case EventPackageDetailsFieldIndex.PackageId:
					DesetupSyncPackage(true, false);
					break;
				case EventPackageDetailsFieldIndex.HafTemplateId:
					DesetupSyncHafTemplate(true, false);
					break;
				case EventPackageDetailsFieldIndex.Gender:
					DesetupSyncLookup(true, false);
					break;
				case EventPackageDetailsFieldIndex.PodRoomId:
					DesetupSyncPodRoom(true, false);
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
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "HafTemplate":
					this.HafTemplate = (HafTemplateEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Package":
					this.Package = (PackageEntity)entity;
					break;
				case "PodRoom":
					this.PodRoom = (PodRoomEntity)entity;
					break;
				case "CustomerOrderHistory":
					this.CustomerOrderHistory.Add((CustomerOrderHistoryEntity)entity);
					break;
				case "EventPackageOrderItem":
					this.EventPackageOrderItem.Add((EventPackageOrderItemEntity)entity);
					break;
				case "EventPackageTest":
					this.EventPackageTest.Add((EventPackageTestEntity)entity);
					break;
				case "EventPaymentDetails":
					this.EventPaymentDetails.Add((EventPaymentDetailsEntity)entity);
					break;
				case "CorporateUploadCollectionViaCustomerOrderHistory":
					this.CorporateUploadCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.CorporateUploadCollectionViaCustomerOrderHistory.Add((CorporateUploadEntity)entity);
					this.CorporateUploadCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaEventPaymentDetails":
					this.CustomerProfileCollectionViaEventPaymentDetails.IsReadOnly = false;
					this.CustomerProfileCollectionViaEventPaymentDetails.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaEventPaymentDetails.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerOrderHistory":
					this.CustomerProfileCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerOrderHistory.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCustomerOrderHistory":
					this.EventCustomersCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventCustomersCollectionViaCustomerOrderHistory.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventsCollectionViaCustomerOrderHistory":
					this.EventsCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventsCollectionViaCustomerOrderHistory.Add((EventsEntity)entity);
					this.EventsCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventTestCollectionViaEventPackageTest":
					this.EventTestCollectionViaEventPackageTest.IsReadOnly = false;
					this.EventTestCollectionViaEventPackageTest.Add((EventTestEntity)entity);
					this.EventTestCollectionViaEventPackageTest.IsReadOnly = true;
					break;
				case "EventTestCollectionViaCustomerOrderHistory":
					this.EventTestCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventTestCollectionViaCustomerOrderHistory.Add((EventTestEntity)entity);
					this.EventTestCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerOrderHistory":
					this.LookupCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.LookupCollectionViaCustomerOrderHistory.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "OrderItemCollectionViaEventPackageOrderItem":
					this.OrderItemCollectionViaEventPackageOrderItem.IsReadOnly = false;
					this.OrderItemCollectionViaEventPackageOrderItem.Add((OrderItemEntity)entity);
					this.OrderItemCollectionViaEventPackageOrderItem.IsReadOnly = true;
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
			return EventPackageDetailsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Events":
					toReturn.Add(EventPackageDetailsEntity.Relations.EventsEntityUsingEventId);
					break;
				case "HafTemplate":
					toReturn.Add(EventPackageDetailsEntity.Relations.HafTemplateEntityUsingHafTemplateId);
					break;
				case "Lookup":
					toReturn.Add(EventPackageDetailsEntity.Relations.LookupEntityUsingGender);
					break;
				case "Package":
					toReturn.Add(EventPackageDetailsEntity.Relations.PackageEntityUsingPackageId);
					break;
				case "PodRoom":
					toReturn.Add(EventPackageDetailsEntity.Relations.PodRoomEntityUsingPodRoomId);
					break;
				case "CustomerOrderHistory":
					toReturn.Add(EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId);
					break;
				case "EventPackageOrderItem":
					toReturn.Add(EventPackageDetailsEntity.Relations.EventPackageOrderItemEntityUsingEventPackageId);
					break;
				case "EventPackageTest":
					toReturn.Add(EventPackageDetailsEntity.Relations.EventPackageTestEntityUsingEventPackageId);
					break;
				case "EventPaymentDetails":
					toReturn.Add(EventPackageDetailsEntity.Relations.EventPaymentDetailsEntityUsingEventPackageId);
					break;
				case "CorporateUploadCollectionViaCustomerOrderHistory":
					toReturn.Add(EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId, "EventPackageDetailsEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.CorporateUploadEntityUsingUploadId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaEventPaymentDetails":
					toReturn.Add(EventPackageDetailsEntity.Relations.EventPaymentDetailsEntityUsingEventPackageId, "EventPackageDetailsEntity__", "EventPaymentDetails_", JoinHint.None);
					toReturn.Add(EventPaymentDetailsEntity.Relations.CustomerProfileEntityUsingCustomerId, "EventPaymentDetails_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerOrderHistory":
					toReturn.Add(EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId, "EventPackageDetailsEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCustomerOrderHistory":
					toReturn.Add(EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId, "EventPackageDetailsEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCustomerOrderHistory":
					toReturn.Add(EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId, "EventPackageDetailsEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventsEntityUsingEventId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventTestCollectionViaEventPackageTest":
					toReturn.Add(EventPackageDetailsEntity.Relations.EventPackageTestEntityUsingEventPackageId, "EventPackageDetailsEntity__", "EventPackageTest_", JoinHint.None);
					toReturn.Add(EventPackageTestEntity.Relations.EventTestEntityUsingEventTestId, "EventPackageTest_", string.Empty, JoinHint.None);
					break;
				case "EventTestCollectionViaCustomerOrderHistory":
					toReturn.Add(EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId, "EventPackageDetailsEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventTestEntityUsingEventTestId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerOrderHistory":
					toReturn.Add(EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId, "EventPackageDetailsEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.LookupEntityUsingOrderItemStatusId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "OrderItemCollectionViaEventPackageOrderItem":
					toReturn.Add(EventPackageDetailsEntity.Relations.EventPackageOrderItemEntityUsingEventPackageId, "EventPackageDetailsEntity__", "EventPackageOrderItem_", JoinHint.None);
					toReturn.Add(EventPackageOrderItemEntity.Relations.OrderItemEntityUsingOrderItemId, "EventPackageOrderItem_", string.Empty, JoinHint.None);
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
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "HafTemplate":
					SetupSyncHafTemplate(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "Package":
					SetupSyncPackage(relatedEntity);
					break;
				case "PodRoom":
					SetupSyncPodRoom(relatedEntity);
					break;
				case "CustomerOrderHistory":
					this.CustomerOrderHistory.Add((CustomerOrderHistoryEntity)relatedEntity);
					break;
				case "EventPackageOrderItem":
					this.EventPackageOrderItem.Add((EventPackageOrderItemEntity)relatedEntity);
					break;
				case "EventPackageTest":
					this.EventPackageTest.Add((EventPackageTestEntity)relatedEntity);
					break;
				case "EventPaymentDetails":
					this.EventPaymentDetails.Add((EventPaymentDetailsEntity)relatedEntity);
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
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "HafTemplate":
					DesetupSyncHafTemplate(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "Package":
					DesetupSyncPackage(false, true);
					break;
				case "PodRoom":
					DesetupSyncPodRoom(false, true);
					break;
				case "CustomerOrderHistory":
					base.PerformRelatedEntityRemoval(this.CustomerOrderHistory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventPackageOrderItem":
					base.PerformRelatedEntityRemoval(this.EventPackageOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventPackageTest":
					base.PerformRelatedEntityRemoval(this.EventPackageTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventPaymentDetails":
					base.PerformRelatedEntityRemoval(this.EventPaymentDetails, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_hafTemplate!=null)
			{
				toReturn.Add(_hafTemplate);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_package!=null)
			{
				toReturn.Add(_package);
			}
			if(_podRoom!=null)
			{
				toReturn.Add(_podRoom);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerOrderHistory);
			toReturn.Add(this.EventPackageOrderItem);
			toReturn.Add(this.EventPackageTest);
			toReturn.Add(this.EventPaymentDetails);

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
				info.AddValue("_customerOrderHistory", ((_customerOrderHistory!=null) && (_customerOrderHistory.Count>0) && !this.MarkedForDeletion)?_customerOrderHistory:null);
				info.AddValue("_eventPackageOrderItem", ((_eventPackageOrderItem!=null) && (_eventPackageOrderItem.Count>0) && !this.MarkedForDeletion)?_eventPackageOrderItem:null);
				info.AddValue("_eventPackageTest", ((_eventPackageTest!=null) && (_eventPackageTest.Count>0) && !this.MarkedForDeletion)?_eventPackageTest:null);
				info.AddValue("_eventPaymentDetails", ((_eventPaymentDetails!=null) && (_eventPaymentDetails.Count>0) && !this.MarkedForDeletion)?_eventPaymentDetails:null);
				info.AddValue("_corporateUploadCollectionViaCustomerOrderHistory", ((_corporateUploadCollectionViaCustomerOrderHistory!=null) && (_corporateUploadCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_corporateUploadCollectionViaCustomerOrderHistory:null);
				info.AddValue("_customerProfileCollectionViaEventPaymentDetails", ((_customerProfileCollectionViaEventPaymentDetails!=null) && (_customerProfileCollectionViaEventPaymentDetails.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaEventPaymentDetails:null);
				info.AddValue("_customerProfileCollectionViaCustomerOrderHistory", ((_customerProfileCollectionViaCustomerOrderHistory!=null) && (_customerProfileCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventCustomersCollectionViaCustomerOrderHistory", ((_eventCustomersCollectionViaCustomerOrderHistory!=null) && (_eventCustomersCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventsCollectionViaCustomerOrderHistory", ((_eventsCollectionViaCustomerOrderHistory!=null) && (_eventsCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventTestCollectionViaEventPackageTest", ((_eventTestCollectionViaEventPackageTest!=null) && (_eventTestCollectionViaEventPackageTest.Count>0) && !this.MarkedForDeletion)?_eventTestCollectionViaEventPackageTest:null);
				info.AddValue("_eventTestCollectionViaCustomerOrderHistory", ((_eventTestCollectionViaCustomerOrderHistory!=null) && (_eventTestCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventTestCollectionViaCustomerOrderHistory:null);
				info.AddValue("_lookupCollectionViaCustomerOrderHistory", ((_lookupCollectionViaCustomerOrderHistory!=null) && (_lookupCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerOrderHistory:null);
				info.AddValue("_orderItemCollectionViaEventPackageOrderItem", ((_orderItemCollectionViaEventPackageOrderItem!=null) && (_orderItemCollectionViaEventPackageOrderItem.Count>0) && !this.MarkedForDeletion)?_orderItemCollectionViaEventPackageOrderItem:null);
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_hafTemplate", (!this.MarkedForDeletion?_hafTemplate:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_package", (!this.MarkedForDeletion?_package:null));
				info.AddValue("_podRoom", (!this.MarkedForDeletion?_podRoom:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(EventPackageDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventPackageDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventPackageDetailsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerOrderHistory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerOrderHistoryFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageOrderItemFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageTestFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPaymentDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPaymentDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPaymentDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CorporateUpload' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCorporateUploadCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CorporateUploadCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId, "EventPackageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaEventPaymentDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaEventPaymentDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId, "EventPackageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId, "EventPackageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId, "EventPackageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId, "EventPackageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTestCollectionViaEventPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventTestCollectionViaEventPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId, "EventPackageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTestCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventTestCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId, "EventPackageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId, "EventPackageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderItemCollectionViaEventPackageOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderItemCollectionViaEventPackageOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.EventPackageId, null, ComparisonOperator.Equal, this.EventPackageId, "EventPackageDetailsEntity__"));
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
		/// the related entity of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HafTemplateId));
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
		/// the related entity of type 'Package' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PodRoom' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodRoom()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodRoomFields.PodRoomId, null, ComparisonOperator.Equal, this.PodRoomId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventPackageDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerOrderHistory);
			collectionsQueue.Enqueue(this._eventPackageOrderItem);
			collectionsQueue.Enqueue(this._eventPackageTest);
			collectionsQueue.Enqueue(this._eventPaymentDetails);
			collectionsQueue.Enqueue(this._corporateUploadCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaEventPaymentDetails);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventsCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventTestCollectionViaEventPackageTest);
			collectionsQueue.Enqueue(this._eventTestCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._orderItemCollectionViaEventPackageOrderItem);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerOrderHistory = (EntityCollection<CustomerOrderHistoryEntity>) collectionsQueue.Dequeue();
			this._eventPackageOrderItem = (EntityCollection<EventPackageOrderItemEntity>) collectionsQueue.Dequeue();
			this._eventPackageTest = (EntityCollection<EventPackageTestEntity>) collectionsQueue.Dequeue();
			this._eventPaymentDetails = (EntityCollection<EventPaymentDetailsEntity>) collectionsQueue.Dequeue();
			this._corporateUploadCollectionViaCustomerOrderHistory = (EntityCollection<CorporateUploadEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaEventPaymentDetails = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerOrderHistory = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCustomerOrderHistory = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCustomerOrderHistory = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventTestCollectionViaEventPackageTest = (EntityCollection<EventTestEntity>) collectionsQueue.Dequeue();
			this._eventTestCollectionViaCustomerOrderHistory = (EntityCollection<EventTestEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerOrderHistory = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._orderItemCollectionViaEventPackageOrderItem = (EntityCollection<OrderItemEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerOrderHistory != null)
			{
				return true;
			}
			if (this._eventPackageOrderItem != null)
			{
				return true;
			}
			if (this._eventPackageTest != null)
			{
				return true;
			}
			if (this._eventPaymentDetails != null)
			{
				return true;
			}
			if (this._corporateUploadCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaEventPaymentDetails != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventTestCollectionViaEventPackageTest != null)
			{
				return true;
			}
			if (this._eventTestCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._orderItemCollectionViaEventPackageOrderItem != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerOrderHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerOrderHistoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPaymentDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Events", _events);
			toReturn.Add("HafTemplate", _hafTemplate);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Package", _package);
			toReturn.Add("PodRoom", _podRoom);
			toReturn.Add("CustomerOrderHistory", _customerOrderHistory);
			toReturn.Add("EventPackageOrderItem", _eventPackageOrderItem);
			toReturn.Add("EventPackageTest", _eventPackageTest);
			toReturn.Add("EventPaymentDetails", _eventPaymentDetails);
			toReturn.Add("CorporateUploadCollectionViaCustomerOrderHistory", _corporateUploadCollectionViaCustomerOrderHistory);
			toReturn.Add("CustomerProfileCollectionViaEventPaymentDetails", _customerProfileCollectionViaEventPaymentDetails);
			toReturn.Add("CustomerProfileCollectionViaCustomerOrderHistory", _customerProfileCollectionViaCustomerOrderHistory);
			toReturn.Add("EventCustomersCollectionViaCustomerOrderHistory", _eventCustomersCollectionViaCustomerOrderHistory);
			toReturn.Add("EventsCollectionViaCustomerOrderHistory", _eventsCollectionViaCustomerOrderHistory);
			toReturn.Add("EventTestCollectionViaEventPackageTest", _eventTestCollectionViaEventPackageTest);
			toReturn.Add("EventTestCollectionViaCustomerOrderHistory", _eventTestCollectionViaCustomerOrderHistory);
			toReturn.Add("LookupCollectionViaCustomerOrderHistory", _lookupCollectionViaCustomerOrderHistory);
			toReturn.Add("OrderItemCollectionViaEventPackageOrderItem", _orderItemCollectionViaEventPackageOrderItem);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerOrderHistory!=null)
			{
				_customerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageOrderItem!=null)
			{
				_eventPackageOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageTest!=null)
			{
				_eventPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_eventPaymentDetails!=null)
			{
				_eventPaymentDetails.ActiveContext = base.ActiveContext;
			}
			if(_corporateUploadCollectionViaCustomerOrderHistory!=null)
			{
				_corporateUploadCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaEventPaymentDetails!=null)
			{
				_customerProfileCollectionViaEventPaymentDetails.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerOrderHistory!=null)
			{
				_customerProfileCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCustomerOrderHistory!=null)
			{
				_eventCustomersCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCustomerOrderHistory!=null)
			{
				_eventsCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventTestCollectionViaEventPackageTest!=null)
			{
				_eventTestCollectionViaEventPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_eventTestCollectionViaCustomerOrderHistory!=null)
			{
				_eventTestCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerOrderHistory!=null)
			{
				_lookupCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_orderItemCollectionViaEventPackageOrderItem!=null)
			{
				_orderItemCollectionViaEventPackageOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplate!=null)
			{
				_hafTemplate.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_package!=null)
			{
				_package.ActiveContext = base.ActiveContext;
			}
			if(_podRoom!=null)
			{
				_podRoom.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerOrderHistory = null;
			_eventPackageOrderItem = null;
			_eventPackageTest = null;
			_eventPaymentDetails = null;
			_corporateUploadCollectionViaCustomerOrderHistory = null;
			_customerProfileCollectionViaEventPaymentDetails = null;
			_customerProfileCollectionViaCustomerOrderHistory = null;
			_eventCustomersCollectionViaCustomerOrderHistory = null;
			_eventsCollectionViaCustomerOrderHistory = null;
			_eventTestCollectionViaEventPackageTest = null;
			_eventTestCollectionViaCustomerOrderHistory = null;
			_lookupCollectionViaCustomerOrderHistory = null;
			_orderItemCollectionViaEventPackageOrderItem = null;
			_events = null;
			_hafTemplate = null;
			_lookup = null;
			_package = null;
			_podRoom = null;

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

			_fieldsCustomProperties.Add("EventPackageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PackageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PackagePrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AvailableThroughOnline", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AvailableThroughCallCenter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AvailableThroughTechnician", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AvailableThroughAdmin", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScreeningTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HafTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsRecommended", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MostPopular", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BestValue", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PodRoomId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventPackageDetailsEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "EventPackageDetails", resetFKFields, new int[] { (int)EventPackageDetailsFieldIndex.EventId } );		
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
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventPackageDetailsEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _hafTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHafTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", EventPackageDetailsEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, signalRelatedEntity, "EventPackageDetails", resetFKFields, new int[] { (int)EventPackageDetailsFieldIndex.HafTemplateId } );		
			_hafTemplate = null;
		}

		/// <summary> setups the sync logic for member _hafTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHafTemplate(IEntity2 relatedEntity)
		{
			if(_hafTemplate!=relatedEntity)
			{
				DesetupSyncHafTemplate(true, true);
				_hafTemplate = (HafTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", EventPackageDetailsEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHafTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventPackageDetailsEntity.Relations.LookupEntityUsingGender, true, signalRelatedEntity, "EventPackageDetails", resetFKFields, new int[] { (int)EventPackageDetailsFieldIndex.Gender } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventPackageDetailsEntity.Relations.LookupEntityUsingGender, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _package</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPackage(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _package, new PropertyChangedEventHandler( OnPackagePropertyChanged ), "Package", EventPackageDetailsEntity.Relations.PackageEntityUsingPackageId, true, signalRelatedEntity, "EventPackageDetails", resetFKFields, new int[] { (int)EventPackageDetailsFieldIndex.PackageId } );		
			_package = null;
		}

		/// <summary> setups the sync logic for member _package</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPackage(IEntity2 relatedEntity)
		{
			if(_package!=relatedEntity)
			{
				DesetupSyncPackage(true, true);
				_package = (PackageEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _package, new PropertyChangedEventHandler( OnPackagePropertyChanged ), "Package", EventPackageDetailsEntity.Relations.PackageEntityUsingPackageId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPackagePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _podRoom</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPodRoom(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _podRoom, new PropertyChangedEventHandler( OnPodRoomPropertyChanged ), "PodRoom", EventPackageDetailsEntity.Relations.PodRoomEntityUsingPodRoomId, true, signalRelatedEntity, "EventPackageDetails", resetFKFields, new int[] { (int)EventPackageDetailsFieldIndex.PodRoomId } );		
			_podRoom = null;
		}

		/// <summary> setups the sync logic for member _podRoom</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPodRoom(IEntity2 relatedEntity)
		{
			if(_podRoom!=relatedEntity)
			{
				DesetupSyncPodRoom(true, true);
				_podRoom = (PodRoomEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _podRoom, new PropertyChangedEventHandler( OnPodRoomPropertyChanged ), "PodRoom", EventPackageDetailsEntity.Relations.PodRoomEntityUsingPodRoomId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPodRoomPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EventPackageDetailsEntity</param>
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
		public  static EventPackageDetailsRelations Relations
		{
			get	{ return new EventPackageDetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerOrderHistory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerOrderHistory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerOrderHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerOrderHistoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerOrderHistory")[0], (int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.CustomerOrderHistoryEntity, 0, null, null, null, null, "CustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPackageOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPackageOrderItem")[0], (int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.EventPackageOrderItemEntity, 0, null, null, null, null, "EventPackageOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPackageTest")[0], (int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.EventPackageTestEntity, 0, null, null, null, null, "EventPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPaymentDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPaymentDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPaymentDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPaymentDetails")[0], (int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.EventPaymentDetailsEntity, 0, null, null, null, null, "EventPaymentDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CorporateUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCorporateUploadCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.CorporateUploadEntity, 0, null, null, GetRelationsForField("CorporateUploadCollectionViaCustomerOrderHistory"), null, "CorporateUploadCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaEventPaymentDetails
		{
			get
			{
				IEntityRelation intermediateRelation = EventPackageDetailsEntity.Relations.EventPaymentDetailsEntityUsingEventPackageId;
				intermediateRelation.SetAliases(string.Empty, "EventPaymentDetails_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaEventPaymentDetails"), null, "CustomerProfileCollectionViaEventPaymentDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerOrderHistory"), null, "CustomerProfileCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCustomerOrderHistory"), null, "EventCustomersCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCustomerOrderHistory"), null, "EventsCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTestCollectionViaEventPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventPackageDetailsEntity.Relations.EventPackageTestEntityUsingEventPackageId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageTest_");
				return new PrefetchPathElement2(new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.EventTestEntity, 0, null, null, GetRelationsForField("EventTestCollectionViaEventPackageTest"), null, "EventTestCollectionViaEventPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTestCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.EventTestEntity, 0, null, null, GetRelationsForField("EventTestCollectionViaCustomerOrderHistory"), null, "EventTestCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventPackageDetailsEntity.Relations.CustomerOrderHistoryEntityUsingEventPackageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerOrderHistory"), null, "LookupCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderItemCollectionViaEventPackageOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = EventPackageDetailsEntity.Relations.EventPackageOrderItemEntityUsingEventPackageId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.OrderItemEntity, 0, null, null, GetRelationsForField("OrderItemCollectionViaEventPackageOrderItem"), null, "OrderItemCollectionViaEventPackageOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("HafTemplate")[0], (int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, null, null, "HafTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackage
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("Package")[0], (int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, null, null, "Package", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodRoom' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodRoom
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodRoom")[0], (int)Falcon.Data.EntityType.EventPackageDetailsEntity, (int)Falcon.Data.EntityType.PodRoomEntity, 0, null, null, null, null, "PodRoom", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventPackageDetailsEntity.CustomProperties;}
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
			get { return EventPackageDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventPackageId property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."EventPackageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 EventPackageId
		{
			get { return (System.Int64)GetValue((int)EventPackageDetailsFieldIndex.EventPackageId, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.EventPackageId, value); }
		}

		/// <summary> The EventId property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)EventPackageDetailsFieldIndex.EventId, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.EventId, value); }
		}

		/// <summary> The PackageId property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."PackageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PackageId
		{
			get { return (System.Int64)GetValue((int)EventPackageDetailsFieldIndex.PackageId, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.PackageId, value); }
		}

		/// <summary> The PackagePrice property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."PackagePrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal PackagePrice
		{
			get { return (System.Decimal)GetValue((int)EventPackageDetailsFieldIndex.PackagePrice, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.PackagePrice, value); }
		}

		/// <summary> The DateCreated property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)EventPackageDetailsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)EventPackageDetailsFieldIndex.DateModified, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.DateModified, value); }
		}

		/// <summary> The AvailableThroughOnline property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."AvailableThroughOnline"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AvailableThroughOnline
		{
			get { return (System.Boolean)GetValue((int)EventPackageDetailsFieldIndex.AvailableThroughOnline, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.AvailableThroughOnline, value); }
		}

		/// <summary> The AvailableThroughCallCenter property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."AvailableThroughCallCenter"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AvailableThroughCallCenter
		{
			get { return (System.Boolean)GetValue((int)EventPackageDetailsFieldIndex.AvailableThroughCallCenter, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.AvailableThroughCallCenter, value); }
		}

		/// <summary> The AvailableThroughTechnician property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."AvailableThroughTechnician"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AvailableThroughTechnician
		{
			get { return (System.Boolean)GetValue((int)EventPackageDetailsFieldIndex.AvailableThroughTechnician, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.AvailableThroughTechnician, value); }
		}

		/// <summary> The AvailableThroughAdmin property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."AvailableThroughAdmin"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AvailableThroughAdmin
		{
			get { return (System.Boolean)GetValue((int)EventPackageDetailsFieldIndex.AvailableThroughAdmin, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.AvailableThroughAdmin, value); }
		}

		/// <summary> The ScreeningTime property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."ScreeningTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ScreeningTime
		{
			get { return (Nullable<System.Int32>)GetValue((int)EventPackageDetailsFieldIndex.ScreeningTime, false); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.ScreeningTime, value); }
		}

		/// <summary> The HafTemplateId property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."HAFTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HafTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventPackageDetailsFieldIndex.HafTemplateId, false); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.HafTemplateId, value); }
		}

		/// <summary> The IsRecommended property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."IsRecommended"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsRecommended
		{
			get { return (System.Boolean)GetValue((int)EventPackageDetailsFieldIndex.IsRecommended, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.IsRecommended, value); }
		}

		/// <summary> The Gender property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Gender
		{
			get { return (System.Int64)GetValue((int)EventPackageDetailsFieldIndex.Gender, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.Gender, value); }
		}

		/// <summary> The MostPopular property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."MostPopular"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean MostPopular
		{
			get { return (System.Boolean)GetValue((int)EventPackageDetailsFieldIndex.MostPopular, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.MostPopular, value); }
		}

		/// <summary> The BestValue property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."BestValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean BestValue
		{
			get { return (System.Boolean)GetValue((int)EventPackageDetailsFieldIndex.BestValue, true); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.BestValue, value); }
		}

		/// <summary> The PodRoomId property of the Entity EventPackageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventPackageDetails"."PodRoomID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PodRoomId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventPackageDetailsFieldIndex.PodRoomId, false); }
			set	{ SetValue((int)EventPackageDetailsFieldIndex.PodRoomId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerOrderHistoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerOrderHistoryEntity))]
		public virtual EntityCollection<CustomerOrderHistoryEntity> CustomerOrderHistory
		{
			get
			{
				if(_customerOrderHistory==null)
				{
					_customerOrderHistory = new EntityCollection<CustomerOrderHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerOrderHistoryEntityFactory)));
					_customerOrderHistory.SetContainingEntityInfo(this, "EventPackageDetails");
				}
				return _customerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageOrderItemEntity))]
		public virtual EntityCollection<EventPackageOrderItemEntity> EventPackageOrderItem
		{
			get
			{
				if(_eventPackageOrderItem==null)
				{
					_eventPackageOrderItem = new EntityCollection<EventPackageOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageOrderItemEntityFactory)));
					_eventPackageOrderItem.SetContainingEntityInfo(this, "EventPackageDetails");
				}
				return _eventPackageOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageTestEntity))]
		public virtual EntityCollection<EventPackageTestEntity> EventPackageTest
		{
			get
			{
				if(_eventPackageTest==null)
				{
					_eventPackageTest = new EntityCollection<EventPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageTestEntityFactory)));
					_eventPackageTest.SetContainingEntityInfo(this, "EventPackageDetails");
				}
				return _eventPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPaymentDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPaymentDetailsEntity))]
		public virtual EntityCollection<EventPaymentDetailsEntity> EventPaymentDetails
		{
			get
			{
				if(_eventPaymentDetails==null)
				{
					_eventPaymentDetails = new EntityCollection<EventPaymentDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPaymentDetailsEntityFactory)));
					_eventPaymentDetails.SetContainingEntityInfo(this, "EventPackageDetails");
				}
				return _eventPaymentDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CorporateUploadEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CorporateUploadEntity))]
		public virtual EntityCollection<CorporateUploadEntity> CorporateUploadCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_corporateUploadCollectionViaCustomerOrderHistory==null)
				{
					_corporateUploadCollectionViaCustomerOrderHistory = new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory)));
					_corporateUploadCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _corporateUploadCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaEventPaymentDetails
		{
			get
			{
				if(_customerProfileCollectionViaEventPaymentDetails==null)
				{
					_customerProfileCollectionViaEventPaymentDetails = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaEventPaymentDetails.IsReadOnly=true;
				}
				return _customerProfileCollectionViaEventPaymentDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_customerProfileCollectionViaCustomerOrderHistory==null)
				{
					_customerProfileCollectionViaCustomerOrderHistory = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventCustomersCollectionViaCustomerOrderHistory==null)
				{
					_eventCustomersCollectionViaCustomerOrderHistory = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventsCollectionViaCustomerOrderHistory==null)
				{
					_eventsCollectionViaCustomerOrderHistory = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventsCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTestEntity))]
		public virtual EntityCollection<EventTestEntity> EventTestCollectionViaEventPackageTest
		{
			get
			{
				if(_eventTestCollectionViaEventPackageTest==null)
				{
					_eventTestCollectionViaEventPackageTest = new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory)));
					_eventTestCollectionViaEventPackageTest.IsReadOnly=true;
				}
				return _eventTestCollectionViaEventPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTestEntity))]
		public virtual EntityCollection<EventTestEntity> EventTestCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventTestCollectionViaCustomerOrderHistory==null)
				{
					_eventTestCollectionViaCustomerOrderHistory = new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory)));
					_eventTestCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventTestCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_lookupCollectionViaCustomerOrderHistory==null)
				{
					_lookupCollectionViaCustomerOrderHistory = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderItemEntity))]
		public virtual EntityCollection<OrderItemEntity> OrderItemCollectionViaEventPackageOrderItem
		{
			get
			{
				if(_orderItemCollectionViaEventPackageOrderItem==null)
				{
					_orderItemCollectionViaEventPackageOrderItem = new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory)));
					_orderItemCollectionViaEventPackageOrderItem.IsReadOnly=true;
				}
				return _orderItemCollectionViaEventPackageOrderItem;
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
							_events.UnsetRelatedEntity(this, "EventPackageDetails");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventPackageDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HafTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HafTemplateEntity HafTemplate
		{
			get
			{
				return _hafTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHafTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_hafTemplate != null)
						{
							_hafTemplate.UnsetRelatedEntity(this, "EventPackageDetails");
						}
					}
					else
					{
						if(_hafTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventPackageDetails");
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
							_lookup.UnsetRelatedEntity(this, "EventPackageDetails");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventPackageDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PackageEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PackageEntity Package
		{
			get
			{
				return _package;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPackage(value);
				}
				else
				{
					if(value==null)
					{
						if(_package != null)
						{
							_package.UnsetRelatedEntity(this, "EventPackageDetails");
						}
					}
					else
					{
						if(_package!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventPackageDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PodRoomEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PodRoomEntity PodRoom
		{
			get
			{
				return _podRoom;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPodRoom(value);
				}
				else
				{
					if(value==null)
					{
						if(_podRoom != null)
						{
							_podRoom.UnsetRelatedEntity(this, "EventPackageDetails");
						}
					}
					else
					{
						if(_podRoom!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventPackageDetails");
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
			get { return (int)Falcon.Data.EntityType.EventPackageDetailsEntity; }
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
