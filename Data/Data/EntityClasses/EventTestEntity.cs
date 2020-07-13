///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'EventTest'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventTestEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerOrderHistoryEntity> _customerOrderHistory;
		private EntityCollection<EventPackageTestEntity> _eventPackageTest;
		private EntityCollection<EventTestOrderItemEntity> _eventTestOrderItem;
		private EntityCollection<CorporateUploadEntity> _corporateUploadCollectionViaCustomerOrderHistory;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerOrderHistory;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCustomerOrderHistory;
		private EntityCollection<EventPackageDetailsEntity> _eventPackageDetailsCollectionViaEventPackageTest;
		private EntityCollection<EventPackageDetailsEntity> _eventPackageDetailsCollectionViaCustomerOrderHistory;
		private EntityCollection<EventsEntity> _eventsCollectionViaCustomerOrderHistory;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerOrderHistory;
		private EntityCollection<OrderItemEntity> _orderItemCollectionViaEventTestOrderItem;
		private EventsEntity _events;
		private HafTemplateEntity _hafTemplate;
		private LookupEntity _lookup__;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;
		private PreQualificationTestTemplateEntity _preQualificationTestTemplate;
		private TestEntity _test;

		
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
			/// <summary>Member name Lookup__</summary>
			public static readonly string Lookup__ = "Lookup__";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name PreQualificationTestTemplate</summary>
			public static readonly string PreQualificationTestTemplate = "PreQualificationTestTemplate";
			/// <summary>Member name Test</summary>
			public static readonly string Test = "Test";
			/// <summary>Member name CustomerOrderHistory</summary>
			public static readonly string CustomerOrderHistory = "CustomerOrderHistory";
			/// <summary>Member name EventPackageTest</summary>
			public static readonly string EventPackageTest = "EventPackageTest";
			/// <summary>Member name EventTestOrderItem</summary>
			public static readonly string EventTestOrderItem = "EventTestOrderItem";
			/// <summary>Member name CorporateUploadCollectionViaCustomerOrderHistory</summary>
			public static readonly string CorporateUploadCollectionViaCustomerOrderHistory = "CorporateUploadCollectionViaCustomerOrderHistory";
			/// <summary>Member name CustomerProfileCollectionViaCustomerOrderHistory</summary>
			public static readonly string CustomerProfileCollectionViaCustomerOrderHistory = "CustomerProfileCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventCustomersCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventCustomersCollectionViaCustomerOrderHistory = "EventCustomersCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventPackageDetailsCollectionViaEventPackageTest</summary>
			public static readonly string EventPackageDetailsCollectionViaEventPackageTest = "EventPackageDetailsCollectionViaEventPackageTest";
			/// <summary>Member name EventPackageDetailsCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventPackageDetailsCollectionViaCustomerOrderHistory = "EventPackageDetailsCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventsCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventsCollectionViaCustomerOrderHistory = "EventsCollectionViaCustomerOrderHistory";
			/// <summary>Member name LookupCollectionViaCustomerOrderHistory</summary>
			public static readonly string LookupCollectionViaCustomerOrderHistory = "LookupCollectionViaCustomerOrderHistory";
			/// <summary>Member name OrderItemCollectionViaEventTestOrderItem</summary>
			public static readonly string OrderItemCollectionViaEventTestOrderItem = "OrderItemCollectionViaEventTestOrderItem";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventTestEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventTestEntity():base("EventTestEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventTestEntity(IEntityFields2 fields):base("EventTestEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventTestEntity</param>
		public EventTestEntity(IValidator validator):base("EventTestEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eventTestId">PK value for EventTest which data should be fetched into this EventTest object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventTestEntity(System.Int64 eventTestId):base("EventTestEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EventTestId = eventTestId;
		}

		/// <summary> CTor</summary>
		/// <param name="eventTestId">PK value for EventTest which data should be fetched into this EventTest object</param>
		/// <param name="validator">The custom validator object for this EventTestEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventTestEntity(System.Int64 eventTestId, IValidator validator):base("EventTestEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EventTestId = eventTestId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventTestEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerOrderHistory = (EntityCollection<CustomerOrderHistoryEntity>)info.GetValue("_customerOrderHistory", typeof(EntityCollection<CustomerOrderHistoryEntity>));
				_eventPackageTest = (EntityCollection<EventPackageTestEntity>)info.GetValue("_eventPackageTest", typeof(EntityCollection<EventPackageTestEntity>));
				_eventTestOrderItem = (EntityCollection<EventTestOrderItemEntity>)info.GetValue("_eventTestOrderItem", typeof(EntityCollection<EventTestOrderItemEntity>));
				_corporateUploadCollectionViaCustomerOrderHistory = (EntityCollection<CorporateUploadEntity>)info.GetValue("_corporateUploadCollectionViaCustomerOrderHistory", typeof(EntityCollection<CorporateUploadEntity>));
				_customerProfileCollectionViaCustomerOrderHistory = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerOrderHistory", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaCustomerOrderHistory = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventCustomersEntity>));
				_eventPackageDetailsCollectionViaEventPackageTest = (EntityCollection<EventPackageDetailsEntity>)info.GetValue("_eventPackageDetailsCollectionViaEventPackageTest", typeof(EntityCollection<EventPackageDetailsEntity>));
				_eventPackageDetailsCollectionViaCustomerOrderHistory = (EntityCollection<EventPackageDetailsEntity>)info.GetValue("_eventPackageDetailsCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventPackageDetailsEntity>));
				_eventsCollectionViaCustomerOrderHistory = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventsEntity>));
				_lookupCollectionViaCustomerOrderHistory = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerOrderHistory", typeof(EntityCollection<LookupEntity>));
				_orderItemCollectionViaEventTestOrderItem = (EntityCollection<OrderItemEntity>)info.GetValue("_orderItemCollectionViaEventTestOrderItem", typeof(EntityCollection<OrderItemEntity>));
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
				_lookup__ = (LookupEntity)info.GetValue("_lookup__", typeof(LookupEntity));
				if(_lookup__!=null)
				{
					_lookup__.AfterSave+=new EventHandler(OnEntityAfterSave);
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
				_preQualificationTestTemplate = (PreQualificationTestTemplateEntity)info.GetValue("_preQualificationTestTemplate", typeof(PreQualificationTestTemplateEntity));
				if(_preQualificationTestTemplate!=null)
				{
					_preQualificationTestTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_test = (TestEntity)info.GetValue("_test", typeof(TestEntity));
				if(_test!=null)
				{
					_test.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EventTestFieldIndex)fieldIndex)
			{
				case EventTestFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case EventTestFieldIndex.TestId:
					DesetupSyncTest(true, false);
					break;
				case EventTestFieldIndex.HafTemplateId:
					DesetupSyncHafTemplate(true, false);
					break;
				case EventTestFieldIndex.Gender:
					DesetupSyncLookup(true, false);
					break;
				case EventTestFieldIndex.GroupId:
					DesetupSyncLookup_(true, false);
					break;
				case EventTestFieldIndex.PreQualificationQuestionTemplateId:
					DesetupSyncPreQualificationTestTemplate(true, false);
					break;
				case EventTestFieldIndex.ResultEntryTypeId:
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
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "HafTemplate":
					this.HafTemplate = (HafTemplateEntity)entity;
					break;
				case "Lookup__":
					this.Lookup__ = (LookupEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "PreQualificationTestTemplate":
					this.PreQualificationTestTemplate = (PreQualificationTestTemplateEntity)entity;
					break;
				case "Test":
					this.Test = (TestEntity)entity;
					break;
				case "CustomerOrderHistory":
					this.CustomerOrderHistory.Add((CustomerOrderHistoryEntity)entity);
					break;
				case "EventPackageTest":
					this.EventPackageTest.Add((EventPackageTestEntity)entity);
					break;
				case "EventTestOrderItem":
					this.EventTestOrderItem.Add((EventTestOrderItemEntity)entity);
					break;
				case "CorporateUploadCollectionViaCustomerOrderHistory":
					this.CorporateUploadCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.CorporateUploadCollectionViaCustomerOrderHistory.Add((CorporateUploadEntity)entity);
					this.CorporateUploadCollectionViaCustomerOrderHistory.IsReadOnly = true;
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
				case "EventPackageDetailsCollectionViaEventPackageTest":
					this.EventPackageDetailsCollectionViaEventPackageTest.IsReadOnly = false;
					this.EventPackageDetailsCollectionViaEventPackageTest.Add((EventPackageDetailsEntity)entity);
					this.EventPackageDetailsCollectionViaEventPackageTest.IsReadOnly = true;
					break;
				case "EventPackageDetailsCollectionViaCustomerOrderHistory":
					this.EventPackageDetailsCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventPackageDetailsCollectionViaCustomerOrderHistory.Add((EventPackageDetailsEntity)entity);
					this.EventPackageDetailsCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventsCollectionViaCustomerOrderHistory":
					this.EventsCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventsCollectionViaCustomerOrderHistory.Add((EventsEntity)entity);
					this.EventsCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerOrderHistory":
					this.LookupCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.LookupCollectionViaCustomerOrderHistory.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "OrderItemCollectionViaEventTestOrderItem":
					this.OrderItemCollectionViaEventTestOrderItem.IsReadOnly = false;
					this.OrderItemCollectionViaEventTestOrderItem.Add((OrderItemEntity)entity);
					this.OrderItemCollectionViaEventTestOrderItem.IsReadOnly = true;
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
			return EventTestEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(EventTestEntity.Relations.EventsEntityUsingEventId);
					break;
				case "HafTemplate":
					toReturn.Add(EventTestEntity.Relations.HafTemplateEntityUsingHafTemplateId);
					break;
				case "Lookup__":
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingResultEntryTypeId);
					break;
				case "Lookup_":
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingGroupId);
					break;
				case "Lookup":
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingGender);
					break;
				case "PreQualificationTestTemplate":
					toReturn.Add(EventTestEntity.Relations.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId);
					break;
				case "Test":
					toReturn.Add(EventTestEntity.Relations.TestEntityUsingTestId);
					break;
				case "CustomerOrderHistory":
					toReturn.Add(EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId);
					break;
				case "EventPackageTest":
					toReturn.Add(EventTestEntity.Relations.EventPackageTestEntityUsingEventTestId);
					break;
				case "EventTestOrderItem":
					toReturn.Add(EventTestEntity.Relations.EventTestOrderItemEntityUsingEventTestId);
					break;
				case "CorporateUploadCollectionViaCustomerOrderHistory":
					toReturn.Add(EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId, "EventTestEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.CorporateUploadEntityUsingUploadId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerOrderHistory":
					toReturn.Add(EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId, "EventTestEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCustomerOrderHistory":
					toReturn.Add(EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId, "EventTestEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventPackageDetailsCollectionViaEventPackageTest":
					toReturn.Add(EventTestEntity.Relations.EventPackageTestEntityUsingEventTestId, "EventTestEntity__", "EventPackageTest_", JoinHint.None);
					toReturn.Add(EventPackageTestEntity.Relations.EventPackageDetailsEntityUsingEventPackageId, "EventPackageTest_", string.Empty, JoinHint.None);
					break;
				case "EventPackageDetailsCollectionViaCustomerOrderHistory":
					toReturn.Add(EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId, "EventTestEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventPackageDetailsEntityUsingEventPackageId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCustomerOrderHistory":
					toReturn.Add(EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId, "EventTestEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventsEntityUsingEventId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerOrderHistory":
					toReturn.Add(EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId, "EventTestEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.LookupEntityUsingOrderItemStatusId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "OrderItemCollectionViaEventTestOrderItem":
					toReturn.Add(EventTestEntity.Relations.EventTestOrderItemEntityUsingEventTestId, "EventTestEntity__", "EventTestOrderItem_", JoinHint.None);
					toReturn.Add(EventTestOrderItemEntity.Relations.OrderItemEntityUsingOrderItemId, "EventTestOrderItem_", string.Empty, JoinHint.None);
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
				case "Lookup__":
					SetupSyncLookup__(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "PreQualificationTestTemplate":
					SetupSyncPreQualificationTestTemplate(relatedEntity);
					break;
				case "Test":
					SetupSyncTest(relatedEntity);
					break;
				case "CustomerOrderHistory":
					this.CustomerOrderHistory.Add((CustomerOrderHistoryEntity)relatedEntity);
					break;
				case "EventPackageTest":
					this.EventPackageTest.Add((EventPackageTestEntity)relatedEntity);
					break;
				case "EventTestOrderItem":
					this.EventTestOrderItem.Add((EventTestOrderItemEntity)relatedEntity);
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
				case "Lookup__":
					DesetupSyncLookup__(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "PreQualificationTestTemplate":
					DesetupSyncPreQualificationTestTemplate(false, true);
					break;
				case "Test":
					DesetupSyncTest(false, true);
					break;
				case "CustomerOrderHistory":
					base.PerformRelatedEntityRemoval(this.CustomerOrderHistory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventPackageTest":
					base.PerformRelatedEntityRemoval(this.EventPackageTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventTestOrderItem":
					base.PerformRelatedEntityRemoval(this.EventTestOrderItem, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_lookup__!=null)
			{
				toReturn.Add(_lookup__);
			}
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_preQualificationTestTemplate!=null)
			{
				toReturn.Add(_preQualificationTestTemplate);
			}
			if(_test!=null)
			{
				toReturn.Add(_test);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerOrderHistory);
			toReturn.Add(this.EventPackageTest);
			toReturn.Add(this.EventTestOrderItem);

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
				info.AddValue("_eventPackageTest", ((_eventPackageTest!=null) && (_eventPackageTest.Count>0) && !this.MarkedForDeletion)?_eventPackageTest:null);
				info.AddValue("_eventTestOrderItem", ((_eventTestOrderItem!=null) && (_eventTestOrderItem.Count>0) && !this.MarkedForDeletion)?_eventTestOrderItem:null);
				info.AddValue("_corporateUploadCollectionViaCustomerOrderHistory", ((_corporateUploadCollectionViaCustomerOrderHistory!=null) && (_corporateUploadCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_corporateUploadCollectionViaCustomerOrderHistory:null);
				info.AddValue("_customerProfileCollectionViaCustomerOrderHistory", ((_customerProfileCollectionViaCustomerOrderHistory!=null) && (_customerProfileCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventCustomersCollectionViaCustomerOrderHistory", ((_eventCustomersCollectionViaCustomerOrderHistory!=null) && (_eventCustomersCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventPackageDetailsCollectionViaEventPackageTest", ((_eventPackageDetailsCollectionViaEventPackageTest!=null) && (_eventPackageDetailsCollectionViaEventPackageTest.Count>0) && !this.MarkedForDeletion)?_eventPackageDetailsCollectionViaEventPackageTest:null);
				info.AddValue("_eventPackageDetailsCollectionViaCustomerOrderHistory", ((_eventPackageDetailsCollectionViaCustomerOrderHistory!=null) && (_eventPackageDetailsCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventPackageDetailsCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventsCollectionViaCustomerOrderHistory", ((_eventsCollectionViaCustomerOrderHistory!=null) && (_eventsCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCustomerOrderHistory:null);
				info.AddValue("_lookupCollectionViaCustomerOrderHistory", ((_lookupCollectionViaCustomerOrderHistory!=null) && (_lookupCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerOrderHistory:null);
				info.AddValue("_orderItemCollectionViaEventTestOrderItem", ((_orderItemCollectionViaEventTestOrderItem!=null) && (_orderItemCollectionViaEventTestOrderItem.Count>0) && !this.MarkedForDeletion)?_orderItemCollectionViaEventTestOrderItem:null);
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_hafTemplate", (!this.MarkedForDeletion?_hafTemplate:null));
				info.AddValue("_lookup__", (!this.MarkedForDeletion?_lookup__:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_preQualificationTestTemplate", (!this.MarkedForDeletion?_preQualificationTestTemplate:null));
				info.AddValue("_test", (!this.MarkedForDeletion?_test:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(EventTestFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventTestFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventTestRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerOrderHistory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerOrderHistoryFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageTestFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTestOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTestOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestOrderItemFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CorporateUpload' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCorporateUploadCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CorporateUploadCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId, "EventTestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId, "EventTestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId, "EventTestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageDetailsCollectionViaEventPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventPackageDetailsCollectionViaEventPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId, "EventTestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageDetailsCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventPackageDetailsCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId, "EventTestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId, "EventTestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId, "EventTestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderItemCollectionViaEventTestOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderItemCollectionViaEventTestOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.EventTestId, null, ComparisonOperator.Equal, this.EventTestId, "EventTestEntity__"));
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
		public virtual IRelationPredicateBucket GetRelationInfoLookup__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ResultEntryTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.GroupId));
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
		/// the related entity of type 'PreQualificationTestTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTestTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.PreQualificationQuestionTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Test' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventTestEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerOrderHistory);
			collectionsQueue.Enqueue(this._eventPackageTest);
			collectionsQueue.Enqueue(this._eventTestOrderItem);
			collectionsQueue.Enqueue(this._corporateUploadCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventPackageDetailsCollectionViaEventPackageTest);
			collectionsQueue.Enqueue(this._eventPackageDetailsCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventsCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._orderItemCollectionViaEventTestOrderItem);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerOrderHistory = (EntityCollection<CustomerOrderHistoryEntity>) collectionsQueue.Dequeue();
			this._eventPackageTest = (EntityCollection<EventPackageTestEntity>) collectionsQueue.Dequeue();
			this._eventTestOrderItem = (EntityCollection<EventTestOrderItemEntity>) collectionsQueue.Dequeue();
			this._corporateUploadCollectionViaCustomerOrderHistory = (EntityCollection<CorporateUploadEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerOrderHistory = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCustomerOrderHistory = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventPackageDetailsCollectionViaEventPackageTest = (EntityCollection<EventPackageDetailsEntity>) collectionsQueue.Dequeue();
			this._eventPackageDetailsCollectionViaCustomerOrderHistory = (EntityCollection<EventPackageDetailsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCustomerOrderHistory = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerOrderHistory = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._orderItemCollectionViaEventTestOrderItem = (EntityCollection<OrderItemEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerOrderHistory != null)
			{
				return true;
			}
			if (this._eventPackageTest != null)
			{
				return true;
			}
			if (this._eventTestOrderItem != null)
			{
				return true;
			}
			if (this._corporateUploadCollectionViaCustomerOrderHistory != null)
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
			if (this._eventPackageDetailsCollectionViaEventPackageTest != null)
			{
				return true;
			}
			if (this._eventPackageDetailsCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._orderItemCollectionViaEventTestOrderItem != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
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
			toReturn.Add("Lookup__", _lookup__);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("PreQualificationTestTemplate", _preQualificationTestTemplate);
			toReturn.Add("Test", _test);
			toReturn.Add("CustomerOrderHistory", _customerOrderHistory);
			toReturn.Add("EventPackageTest", _eventPackageTest);
			toReturn.Add("EventTestOrderItem", _eventTestOrderItem);
			toReturn.Add("CorporateUploadCollectionViaCustomerOrderHistory", _corporateUploadCollectionViaCustomerOrderHistory);
			toReturn.Add("CustomerProfileCollectionViaCustomerOrderHistory", _customerProfileCollectionViaCustomerOrderHistory);
			toReturn.Add("EventCustomersCollectionViaCustomerOrderHistory", _eventCustomersCollectionViaCustomerOrderHistory);
			toReturn.Add("EventPackageDetailsCollectionViaEventPackageTest", _eventPackageDetailsCollectionViaEventPackageTest);
			toReturn.Add("EventPackageDetailsCollectionViaCustomerOrderHistory", _eventPackageDetailsCollectionViaCustomerOrderHistory);
			toReturn.Add("EventsCollectionViaCustomerOrderHistory", _eventsCollectionViaCustomerOrderHistory);
			toReturn.Add("LookupCollectionViaCustomerOrderHistory", _lookupCollectionViaCustomerOrderHistory);
			toReturn.Add("OrderItemCollectionViaEventTestOrderItem", _orderItemCollectionViaEventTestOrderItem);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerOrderHistory!=null)
			{
				_customerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageTest!=null)
			{
				_eventPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_eventTestOrderItem!=null)
			{
				_eventTestOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_corporateUploadCollectionViaCustomerOrderHistory!=null)
			{
				_corporateUploadCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerOrderHistory!=null)
			{
				_customerProfileCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCustomerOrderHistory!=null)
			{
				_eventCustomersCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageDetailsCollectionViaEventPackageTest!=null)
			{
				_eventPackageDetailsCollectionViaEventPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageDetailsCollectionViaCustomerOrderHistory!=null)
			{
				_eventPackageDetailsCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCustomerOrderHistory!=null)
			{
				_eventsCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerOrderHistory!=null)
			{
				_lookupCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_orderItemCollectionViaEventTestOrderItem!=null)
			{
				_orderItemCollectionViaEventTestOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplate!=null)
			{
				_hafTemplate.ActiveContext = base.ActiveContext;
			}
			if(_lookup__!=null)
			{
				_lookup__.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTestTemplate!=null)
			{
				_preQualificationTestTemplate.ActiveContext = base.ActiveContext;
			}
			if(_test!=null)
			{
				_test.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerOrderHistory = null;
			_eventPackageTest = null;
			_eventTestOrderItem = null;
			_corporateUploadCollectionViaCustomerOrderHistory = null;
			_customerProfileCollectionViaCustomerOrderHistory = null;
			_eventCustomersCollectionViaCustomerOrderHistory = null;
			_eventPackageDetailsCollectionViaEventPackageTest = null;
			_eventPackageDetailsCollectionViaCustomerOrderHistory = null;
			_eventsCollectionViaCustomerOrderHistory = null;
			_lookupCollectionViaCustomerOrderHistory = null;
			_orderItemCollectionViaEventTestOrderItem = null;
			_events = null;
			_hafTemplate = null;
			_lookup__ = null;
			_lookup_ = null;
			_lookup = null;
			_preQualificationTestTemplate = null;
			_test = null;

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

			_fieldsCustomProperties.Add("EventTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Price", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RefundPrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowInAlaCarte", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScreeningTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HafTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WithPackagePrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReimbursementRate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTestReviewableByPhysician", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreQualificationQuestionTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultEntryTypeId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventTestEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "EventTest", resetFKFields, new int[] { (int)EventTestFieldIndex.EventId } );		
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
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventTestEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", EventTestEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, signalRelatedEntity, "EventTest", resetFKFields, new int[] { (int)EventTestFieldIndex.HafTemplateId } );		
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
				base.PerformSetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", EventTestEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", EventTestEntity.Relations.LookupEntityUsingResultEntryTypeId, true, signalRelatedEntity, "EventTest__", resetFKFields, new int[] { (int)EventTestFieldIndex.ResultEntryTypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", EventTestEntity.Relations.LookupEntityUsingResultEntryTypeId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", EventTestEntity.Relations.LookupEntityUsingGroupId, true, signalRelatedEntity, "EventTest_", resetFKFields, new int[] { (int)EventTestFieldIndex.GroupId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", EventTestEntity.Relations.LookupEntityUsingGroupId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventTestEntity.Relations.LookupEntityUsingGender, true, signalRelatedEntity, "EventTest", resetFKFields, new int[] { (int)EventTestFieldIndex.Gender } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventTestEntity.Relations.LookupEntityUsingGender, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _preQualificationTestTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPreQualificationTestTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _preQualificationTestTemplate, new PropertyChangedEventHandler( OnPreQualificationTestTemplatePropertyChanged ), "PreQualificationTestTemplate", EventTestEntity.Relations.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId, true, signalRelatedEntity, "EventTest", resetFKFields, new int[] { (int)EventTestFieldIndex.PreQualificationQuestionTemplateId } );		
			_preQualificationTestTemplate = null;
		}

		/// <summary> setups the sync logic for member _preQualificationTestTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPreQualificationTestTemplate(IEntity2 relatedEntity)
		{
			if(_preQualificationTestTemplate!=relatedEntity)
			{
				DesetupSyncPreQualificationTestTemplate(true, true);
				_preQualificationTestTemplate = (PreQualificationTestTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _preQualificationTestTemplate, new PropertyChangedEventHandler( OnPreQualificationTestTemplatePropertyChanged ), "PreQualificationTestTemplate", EventTestEntity.Relations.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPreQualificationTestTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _test</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTest(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", EventTestEntity.Relations.TestEntityUsingTestId, true, signalRelatedEntity, "EventTest", resetFKFields, new int[] { (int)EventTestFieldIndex.TestId } );		
			_test = null;
		}

		/// <summary> setups the sync logic for member _test</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTest(IEntity2 relatedEntity)
		{
			if(_test!=relatedEntity)
			{
				DesetupSyncTest(true, true);
				_test = (TestEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", EventTestEntity.Relations.TestEntityUsingTestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTestPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EventTestEntity</param>
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
		public  static EventTestRelations Relations
		{
			get	{ return new EventTestRelations(); }
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
					(IEntityRelation)GetRelationsForField("CustomerOrderHistory")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.CustomerOrderHistoryEntity, 0, null, null, null, null, "CustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("EventPackageTest")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.EventPackageTestEntity, 0, null, null, null, null, "EventPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTestOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTestOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventTestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventTestOrderItem")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.EventTestOrderItemEntity, 0, null, null, null, null, "EventTestOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CorporateUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCorporateUploadCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.CorporateUploadEntity, 0, null, null, GetRelationsForField("CorporateUploadCollectionViaCustomerOrderHistory"), null, "CorporateUploadCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerOrderHistory"), null, "CustomerProfileCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCustomerOrderHistory"), null, "EventCustomersCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageDetailsCollectionViaEventPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventTestEntity.Relations.EventPackageTestEntityUsingEventTestId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageTest_");
				return new PrefetchPathElement2(new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.EventPackageDetailsEntity, 0, null, null, GetRelationsForField("EventPackageDetailsCollectionViaEventPackageTest"), null, "EventPackageDetailsCollectionViaEventPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageDetailsCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.EventPackageDetailsEntity, 0, null, null, GetRelationsForField("EventPackageDetailsCollectionViaCustomerOrderHistory"), null, "EventPackageDetailsCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCustomerOrderHistory"), null, "EventsCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventTestEntity.Relations.CustomerOrderHistoryEntityUsingEventTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerOrderHistory"), null, "LookupCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderItemCollectionViaEventTestOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = EventTestEntity.Relations.EventTestOrderItemEntityUsingEventTestId;
				intermediateRelation.SetAliases(string.Empty, "EventTestOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.OrderItemEntity, 0, null, null, GetRelationsForField("OrderItemCollectionViaEventTestOrderItem"), null, "OrderItemCollectionViaEventTestOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("HafTemplate")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, null, null, "HafTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup__")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTestTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTestTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationTestTemplate")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, 0, null, null, null, null, "PreQualificationTestTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTest
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))),
					(IEntityRelation)GetRelationsForField("Test")[0], (int)Falcon.Data.EntityType.EventTestEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventTestEntity.CustomProperties;}
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
			get { return EventTestEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventTestId property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."EventTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 EventTestId
		{
			get { return (System.Int64)GetValue((int)EventTestFieldIndex.EventTestId, true); }
			set	{ SetValue((int)EventTestFieldIndex.EventTestId, value); }
		}

		/// <summary> The EventId property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)EventTestFieldIndex.EventId, true); }
			set	{ SetValue((int)EventTestFieldIndex.EventId, value); }
		}

		/// <summary> The TestId property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."TestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TestId
		{
			get { return (System.Int64)GetValue((int)EventTestFieldIndex.TestId, true); }
			set	{ SetValue((int)EventTestFieldIndex.TestId, value); }
		}

		/// <summary> The Price property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."Price"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Price
		{
			get { return (System.Decimal)GetValue((int)EventTestFieldIndex.Price, true); }
			set	{ SetValue((int)EventTestFieldIndex.Price, value); }
		}

		/// <summary> The DateCreated property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)EventTestFieldIndex.DateCreated, true); }
			set	{ SetValue((int)EventTestFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)EventTestFieldIndex.DateModified, true); }
			set	{ SetValue((int)EventTestFieldIndex.DateModified, value); }
		}

		/// <summary> The RefundPrice property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."RefundPrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal RefundPrice
		{
			get { return (System.Decimal)GetValue((int)EventTestFieldIndex.RefundPrice, true); }
			set	{ SetValue((int)EventTestFieldIndex.RefundPrice, value); }
		}

		/// <summary> The ShowInAlaCarte property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."ShowInAlaCarte"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowInAlaCarte
		{
			get { return (System.Boolean)GetValue((int)EventTestFieldIndex.ShowInAlaCarte, true); }
			set	{ SetValue((int)EventTestFieldIndex.ShowInAlaCarte, value); }
		}

		/// <summary> The ScreeningTime property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."ScreeningTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ScreeningTime
		{
			get { return (Nullable<System.Int32>)GetValue((int)EventTestFieldIndex.ScreeningTime, false); }
			set	{ SetValue((int)EventTestFieldIndex.ScreeningTime, value); }
		}

		/// <summary> The HafTemplateId property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."HAFTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HafTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventTestFieldIndex.HafTemplateId, false); }
			set	{ SetValue((int)EventTestFieldIndex.HafTemplateId, value); }
		}

		/// <summary> The WithPackagePrice property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."WithPackagePrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal WithPackagePrice
		{
			get { return (System.Decimal)GetValue((int)EventTestFieldIndex.WithPackagePrice, true); }
			set	{ SetValue((int)EventTestFieldIndex.WithPackagePrice, value); }
		}

		/// <summary> The Gender property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Gender
		{
			get { return (System.Int64)GetValue((int)EventTestFieldIndex.Gender, true); }
			set	{ SetValue((int)EventTestFieldIndex.Gender, value); }
		}

		/// <summary> The GroupId property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."GroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GroupId
		{
			get { return (System.Int64)GetValue((int)EventTestFieldIndex.GroupId, true); }
			set	{ SetValue((int)EventTestFieldIndex.GroupId, value); }
		}

		/// <summary> The ReimbursementRate property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."ReimbursementRate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal ReimbursementRate
		{
			get { return (System.Decimal)GetValue((int)EventTestFieldIndex.ReimbursementRate, true); }
			set	{ SetValue((int)EventTestFieldIndex.ReimbursementRate, value); }
		}

		/// <summary> The IsTestReviewableByPhysician property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."IsTestReviewableByPhysician"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsTestReviewableByPhysician
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventTestFieldIndex.IsTestReviewableByPhysician, false); }
			set	{ SetValue((int)EventTestFieldIndex.IsTestReviewableByPhysician, value); }
		}

		/// <summary> The PreQualificationQuestionTemplateId property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."PreQualificationQuestionTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PreQualificationQuestionTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventTestFieldIndex.PreQualificationQuestionTemplateId, false); }
			set	{ SetValue((int)EventTestFieldIndex.PreQualificationQuestionTemplateId, value); }
		}

		/// <summary> The ResultEntryTypeId property of the Entity EventTest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventTest"."ResultEntryTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ResultEntryTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventTestFieldIndex.ResultEntryTypeId, false); }
			set	{ SetValue((int)EventTestFieldIndex.ResultEntryTypeId, value); }
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
					_customerOrderHistory.SetContainingEntityInfo(this, "EventTest");
				}
				return _customerOrderHistory;
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
					_eventPackageTest.SetContainingEntityInfo(this, "EventTest");
				}
				return _eventPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTestOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTestOrderItemEntity))]
		public virtual EntityCollection<EventTestOrderItemEntity> EventTestOrderItem
		{
			get
			{
				if(_eventTestOrderItem==null)
				{
					_eventTestOrderItem = new EntityCollection<EventTestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestOrderItemEntityFactory)));
					_eventTestOrderItem.SetContainingEntityInfo(this, "EventTest");
				}
				return _eventTestOrderItem;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageDetailsEntity))]
		public virtual EntityCollection<EventPackageDetailsEntity> EventPackageDetailsCollectionViaEventPackageTest
		{
			get
			{
				if(_eventPackageDetailsCollectionViaEventPackageTest==null)
				{
					_eventPackageDetailsCollectionViaEventPackageTest = new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory)));
					_eventPackageDetailsCollectionViaEventPackageTest.IsReadOnly=true;
				}
				return _eventPackageDetailsCollectionViaEventPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageDetailsEntity))]
		public virtual EntityCollection<EventPackageDetailsEntity> EventPackageDetailsCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventPackageDetailsCollectionViaCustomerOrderHistory==null)
				{
					_eventPackageDetailsCollectionViaCustomerOrderHistory = new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory)));
					_eventPackageDetailsCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventPackageDetailsCollectionViaCustomerOrderHistory;
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
		public virtual EntityCollection<OrderItemEntity> OrderItemCollectionViaEventTestOrderItem
		{
			get
			{
				if(_orderItemCollectionViaEventTestOrderItem==null)
				{
					_orderItemCollectionViaEventTestOrderItem = new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory)));
					_orderItemCollectionViaEventTestOrderItem.IsReadOnly=true;
				}
				return _orderItemCollectionViaEventTestOrderItem;
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
							_events.UnsetRelatedEntity(this, "EventTest");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventTest");
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
							_hafTemplate.UnsetRelatedEntity(this, "EventTest");
						}
					}
					else
					{
						if(_hafTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventTest");
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
							_lookup__.UnsetRelatedEntity(this, "EventTest__");
						}
					}
					else
					{
						if(_lookup__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventTest__");
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
							_lookup_.UnsetRelatedEntity(this, "EventTest_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventTest_");
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
							_lookup.UnsetRelatedEntity(this, "EventTest");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventTest");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PreQualificationTestTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PreQualificationTestTemplateEntity PreQualificationTestTemplate
		{
			get
			{
				return _preQualificationTestTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPreQualificationTestTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_preQualificationTestTemplate != null)
						{
							_preQualificationTestTemplate.UnsetRelatedEntity(this, "EventTest");
						}
					}
					else
					{
						if(_preQualificationTestTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventTest");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TestEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TestEntity Test
		{
			get
			{
				return _test;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTest(value);
				}
				else
				{
					if(value==null)
					{
						if(_test != null)
						{
							_test.UnsetRelatedEntity(this, "EventTest");
						}
					}
					else
					{
						if(_test!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventTest");
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
			get { return (int)Falcon.Data.EntityType.EventTestEntity; }
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
