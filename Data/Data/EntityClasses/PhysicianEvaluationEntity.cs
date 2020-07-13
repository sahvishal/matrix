///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:48
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
	/// Entity class which represents the entity 'PhysicianEvaluation'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PhysicianEvaluationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<PhysicianEarningsEntity> _physicianEarnings;
		private EntityCollection<PhysicianInvoiceItemEntity> _physicianInvoiceItem;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaPhysicianInvoiceItem;
		private EntityCollection<EventsEntity> _eventsCollectionViaPhysicianInvoiceItem;
		private EntityCollection<PhysicianInvoiceEntity> _physicianInvoiceCollectionViaPhysicianInvoiceItem;
		private EntityCollection<PhysicianProfileEntity> _physicianProfileCollectionViaPhysicianEarnings;
		private EventCustomersEntity _eventCustomers;
		private PhysicianProfileEntity _physicianProfile;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
			/// <summary>Member name PhysicianProfile</summary>
			public static readonly string PhysicianProfile = "PhysicianProfile";
			/// <summary>Member name PhysicianEarnings</summary>
			public static readonly string PhysicianEarnings = "PhysicianEarnings";
			/// <summary>Member name PhysicianInvoiceItem</summary>
			public static readonly string PhysicianInvoiceItem = "PhysicianInvoiceItem";
			/// <summary>Member name CustomerProfileCollectionViaPhysicianInvoiceItem</summary>
			public static readonly string CustomerProfileCollectionViaPhysicianInvoiceItem = "CustomerProfileCollectionViaPhysicianInvoiceItem";
			/// <summary>Member name EventsCollectionViaPhysicianInvoiceItem</summary>
			public static readonly string EventsCollectionViaPhysicianInvoiceItem = "EventsCollectionViaPhysicianInvoiceItem";
			/// <summary>Member name PhysicianInvoiceCollectionViaPhysicianInvoiceItem</summary>
			public static readonly string PhysicianInvoiceCollectionViaPhysicianInvoiceItem = "PhysicianInvoiceCollectionViaPhysicianInvoiceItem";
			/// <summary>Member name PhysicianProfileCollectionViaPhysicianEarnings</summary>
			public static readonly string PhysicianProfileCollectionViaPhysicianEarnings = "PhysicianProfileCollectionViaPhysicianEarnings";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PhysicianEvaluationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PhysicianEvaluationEntity():base("PhysicianEvaluationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PhysicianEvaluationEntity(IEntityFields2 fields):base("PhysicianEvaluationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PhysicianEvaluationEntity</param>
		public PhysicianEvaluationEntity(IValidator validator):base("PhysicianEvaluationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="physicianEvaluationId">PK value for PhysicianEvaluation which data should be fetched into this PhysicianEvaluation object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianEvaluationEntity(System.Int64 physicianEvaluationId):base("PhysicianEvaluationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PhysicianEvaluationId = physicianEvaluationId;
		}

		/// <summary> CTor</summary>
		/// <param name="physicianEvaluationId">PK value for PhysicianEvaluation which data should be fetched into this PhysicianEvaluation object</param>
		/// <param name="validator">The custom validator object for this PhysicianEvaluationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianEvaluationEntity(System.Int64 physicianEvaluationId, IValidator validator):base("PhysicianEvaluationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PhysicianEvaluationId = physicianEvaluationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PhysicianEvaluationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_physicianEarnings = (EntityCollection<PhysicianEarningsEntity>)info.GetValue("_physicianEarnings", typeof(EntityCollection<PhysicianEarningsEntity>));
				_physicianInvoiceItem = (EntityCollection<PhysicianInvoiceItemEntity>)info.GetValue("_physicianInvoiceItem", typeof(EntityCollection<PhysicianInvoiceItemEntity>));
				_customerProfileCollectionViaPhysicianInvoiceItem = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaPhysicianInvoiceItem", typeof(EntityCollection<CustomerProfileEntity>));
				_eventsCollectionViaPhysicianInvoiceItem = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaPhysicianInvoiceItem", typeof(EntityCollection<EventsEntity>));
				_physicianInvoiceCollectionViaPhysicianInvoiceItem = (EntityCollection<PhysicianInvoiceEntity>)info.GetValue("_physicianInvoiceCollectionViaPhysicianInvoiceItem", typeof(EntityCollection<PhysicianInvoiceEntity>));
				_physicianProfileCollectionViaPhysicianEarnings = (EntityCollection<PhysicianProfileEntity>)info.GetValue("_physicianProfileCollectionViaPhysicianEarnings", typeof(EntityCollection<PhysicianProfileEntity>));
				_eventCustomers = (EventCustomersEntity)info.GetValue("_eventCustomers", typeof(EventCustomersEntity));
				if(_eventCustomers!=null)
				{
					_eventCustomers.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_physicianProfile = (PhysicianProfileEntity)info.GetValue("_physicianProfile", typeof(PhysicianProfileEntity));
				if(_physicianProfile!=null)
				{
					_physicianProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PhysicianEvaluationFieldIndex)fieldIndex)
			{
				case PhysicianEvaluationFieldIndex.PhysicianId:
					DesetupSyncPhysicianProfile(true, false);
					break;
				case PhysicianEvaluationFieldIndex.EventCustomerId:
					DesetupSyncEventCustomers(true, false);
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
				case "EventCustomers":
					this.EventCustomers = (EventCustomersEntity)entity;
					break;
				case "PhysicianProfile":
					this.PhysicianProfile = (PhysicianProfileEntity)entity;
					break;
				case "PhysicianEarnings":
					this.PhysicianEarnings.Add((PhysicianEarningsEntity)entity);
					break;
				case "PhysicianInvoiceItem":
					this.PhysicianInvoiceItem.Add((PhysicianInvoiceItemEntity)entity);
					break;
				case "CustomerProfileCollectionViaPhysicianInvoiceItem":
					this.CustomerProfileCollectionViaPhysicianInvoiceItem.IsReadOnly = false;
					this.CustomerProfileCollectionViaPhysicianInvoiceItem.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaPhysicianInvoiceItem.IsReadOnly = true;
					break;
				case "EventsCollectionViaPhysicianInvoiceItem":
					this.EventsCollectionViaPhysicianInvoiceItem.IsReadOnly = false;
					this.EventsCollectionViaPhysicianInvoiceItem.Add((EventsEntity)entity);
					this.EventsCollectionViaPhysicianInvoiceItem.IsReadOnly = true;
					break;
				case "PhysicianInvoiceCollectionViaPhysicianInvoiceItem":
					this.PhysicianInvoiceCollectionViaPhysicianInvoiceItem.IsReadOnly = false;
					this.PhysicianInvoiceCollectionViaPhysicianInvoiceItem.Add((PhysicianInvoiceEntity)entity);
					this.PhysicianInvoiceCollectionViaPhysicianInvoiceItem.IsReadOnly = true;
					break;
				case "PhysicianProfileCollectionViaPhysicianEarnings":
					this.PhysicianProfileCollectionViaPhysicianEarnings.IsReadOnly = false;
					this.PhysicianProfileCollectionViaPhysicianEarnings.Add((PhysicianProfileEntity)entity);
					this.PhysicianProfileCollectionViaPhysicianEarnings.IsReadOnly = true;
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
			return PhysicianEvaluationEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "EventCustomers":
					toReturn.Add(PhysicianEvaluationEntity.Relations.EventCustomersEntityUsingEventCustomerId);
					break;
				case "PhysicianProfile":
					toReturn.Add(PhysicianEvaluationEntity.Relations.PhysicianProfileEntityUsingPhysicianId);
					break;
				case "PhysicianEarnings":
					toReturn.Add(PhysicianEvaluationEntity.Relations.PhysicianEarningsEntityUsingPhysicianEvaluationId);
					break;
				case "PhysicianInvoiceItem":
					toReturn.Add(PhysicianEvaluationEntity.Relations.PhysicianInvoiceItemEntityUsingPhysicianEvaluationId);
					break;
				case "CustomerProfileCollectionViaPhysicianInvoiceItem":
					toReturn.Add(PhysicianEvaluationEntity.Relations.PhysicianInvoiceItemEntityUsingPhysicianEvaluationId, "PhysicianEvaluationEntity__", "PhysicianInvoiceItem_", JoinHint.None);
					toReturn.Add(PhysicianInvoiceItemEntity.Relations.CustomerProfileEntityUsingCustomerId, "PhysicianInvoiceItem_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaPhysicianInvoiceItem":
					toReturn.Add(PhysicianEvaluationEntity.Relations.PhysicianInvoiceItemEntityUsingPhysicianEvaluationId, "PhysicianEvaluationEntity__", "PhysicianInvoiceItem_", JoinHint.None);
					toReturn.Add(PhysicianInvoiceItemEntity.Relations.EventsEntityUsingEventId, "PhysicianInvoiceItem_", string.Empty, JoinHint.None);
					break;
				case "PhysicianInvoiceCollectionViaPhysicianInvoiceItem":
					toReturn.Add(PhysicianEvaluationEntity.Relations.PhysicianInvoiceItemEntityUsingPhysicianEvaluationId, "PhysicianEvaluationEntity__", "PhysicianInvoiceItem_", JoinHint.None);
					toReturn.Add(PhysicianInvoiceItemEntity.Relations.PhysicianInvoiceEntityUsingPhysicianInvoiceId, "PhysicianInvoiceItem_", string.Empty, JoinHint.None);
					break;
				case "PhysicianProfileCollectionViaPhysicianEarnings":
					toReturn.Add(PhysicianEvaluationEntity.Relations.PhysicianEarningsEntityUsingPhysicianEvaluationId, "PhysicianEvaluationEntity__", "PhysicianEarnings_", JoinHint.None);
					toReturn.Add(PhysicianEarningsEntity.Relations.PhysicianProfileEntityUsingPhysicianId, "PhysicianEarnings_", string.Empty, JoinHint.None);
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
				case "EventCustomers":
					SetupSyncEventCustomers(relatedEntity);
					break;
				case "PhysicianProfile":
					SetupSyncPhysicianProfile(relatedEntity);
					break;
				case "PhysicianEarnings":
					this.PhysicianEarnings.Add((PhysicianEarningsEntity)relatedEntity);
					break;
				case "PhysicianInvoiceItem":
					this.PhysicianInvoiceItem.Add((PhysicianInvoiceItemEntity)relatedEntity);
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
				case "EventCustomers":
					DesetupSyncEventCustomers(false, true);
					break;
				case "PhysicianProfile":
					DesetupSyncPhysicianProfile(false, true);
					break;
				case "PhysicianEarnings":
					base.PerformRelatedEntityRemoval(this.PhysicianEarnings, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianInvoiceItem":
					base.PerformRelatedEntityRemoval(this.PhysicianInvoiceItem, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_eventCustomers!=null)
			{
				toReturn.Add(_eventCustomers);
			}
			if(_physicianProfile!=null)
			{
				toReturn.Add(_physicianProfile);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.PhysicianEarnings);
			toReturn.Add(this.PhysicianInvoiceItem);

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
				info.AddValue("_physicianEarnings", ((_physicianEarnings!=null) && (_physicianEarnings.Count>0) && !this.MarkedForDeletion)?_physicianEarnings:null);
				info.AddValue("_physicianInvoiceItem", ((_physicianInvoiceItem!=null) && (_physicianInvoiceItem.Count>0) && !this.MarkedForDeletion)?_physicianInvoiceItem:null);
				info.AddValue("_customerProfileCollectionViaPhysicianInvoiceItem", ((_customerProfileCollectionViaPhysicianInvoiceItem!=null) && (_customerProfileCollectionViaPhysicianInvoiceItem.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaPhysicianInvoiceItem:null);
				info.AddValue("_eventsCollectionViaPhysicianInvoiceItem", ((_eventsCollectionViaPhysicianInvoiceItem!=null) && (_eventsCollectionViaPhysicianInvoiceItem.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaPhysicianInvoiceItem:null);
				info.AddValue("_physicianInvoiceCollectionViaPhysicianInvoiceItem", ((_physicianInvoiceCollectionViaPhysicianInvoiceItem!=null) && (_physicianInvoiceCollectionViaPhysicianInvoiceItem.Count>0) && !this.MarkedForDeletion)?_physicianInvoiceCollectionViaPhysicianInvoiceItem:null);
				info.AddValue("_physicianProfileCollectionViaPhysicianEarnings", ((_physicianProfileCollectionViaPhysicianEarnings!=null) && (_physicianProfileCollectionViaPhysicianEarnings.Count>0) && !this.MarkedForDeletion)?_physicianProfileCollectionViaPhysicianEarnings:null);
				info.AddValue("_eventCustomers", (!this.MarkedForDeletion?_eventCustomers:null));
				info.AddValue("_physicianProfile", (!this.MarkedForDeletion?_physicianProfile:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PhysicianEvaluationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PhysicianEvaluationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PhysicianEvaluationRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianEarnings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianEarnings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEarningsFields.PhysicianEvaluationId, null, ComparisonOperator.Equal, this.PhysicianEvaluationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianInvoiceItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianInvoiceItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianInvoiceItemFields.PhysicianEvaluationId, null, ComparisonOperator.Equal, this.PhysicianEvaluationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaPhysicianInvoiceItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaPhysicianInvoiceItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEvaluationFields.PhysicianEvaluationId, null, ComparisonOperator.Equal, this.PhysicianEvaluationId, "PhysicianEvaluationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaPhysicianInvoiceItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaPhysicianInvoiceItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEvaluationFields.PhysicianEvaluationId, null, ComparisonOperator.Equal, this.PhysicianEvaluationId, "PhysicianEvaluationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianInvoice' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianInvoiceCollectionViaPhysicianInvoiceItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianInvoiceCollectionViaPhysicianInvoiceItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEvaluationFields.PhysicianEvaluationId, null, ComparisonOperator.Equal, this.PhysicianEvaluationId, "PhysicianEvaluationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfileCollectionViaPhysicianEarnings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianProfileCollectionViaPhysicianEarnings"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEvaluationFields.PhysicianEvaluationId, null, ComparisonOperator.Equal, this.PhysicianEvaluationId, "PhysicianEvaluationEntity__"));
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
		/// the related entity of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.PhysicianId, null, ComparisonOperator.Equal, this.PhysicianId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PhysicianEvaluationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._physicianEarnings);
			collectionsQueue.Enqueue(this._physicianInvoiceItem);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaPhysicianInvoiceItem);
			collectionsQueue.Enqueue(this._eventsCollectionViaPhysicianInvoiceItem);
			collectionsQueue.Enqueue(this._physicianInvoiceCollectionViaPhysicianInvoiceItem);
			collectionsQueue.Enqueue(this._physicianProfileCollectionViaPhysicianEarnings);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._physicianEarnings = (EntityCollection<PhysicianEarningsEntity>) collectionsQueue.Dequeue();
			this._physicianInvoiceItem = (EntityCollection<PhysicianInvoiceItemEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaPhysicianInvoiceItem = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaPhysicianInvoiceItem = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._physicianInvoiceCollectionViaPhysicianInvoiceItem = (EntityCollection<PhysicianInvoiceEntity>) collectionsQueue.Dequeue();
			this._physicianProfileCollectionViaPhysicianEarnings = (EntityCollection<PhysicianProfileEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._physicianEarnings != null)
			{
				return true;
			}
			if (this._physicianInvoiceItem != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaPhysicianInvoiceItem != null)
			{
				return true;
			}
			if (this._eventsCollectionViaPhysicianInvoiceItem != null)
			{
				return true;
			}
			if (this._physicianInvoiceCollectionViaPhysicianInvoiceItem != null)
			{
				return true;
			}
			if (this._physicianProfileCollectionViaPhysicianEarnings != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianEarningsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEarningsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianInvoiceItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("EventCustomers", _eventCustomers);
			toReturn.Add("PhysicianProfile", _physicianProfile);
			toReturn.Add("PhysicianEarnings", _physicianEarnings);
			toReturn.Add("PhysicianInvoiceItem", _physicianInvoiceItem);
			toReturn.Add("CustomerProfileCollectionViaPhysicianInvoiceItem", _customerProfileCollectionViaPhysicianInvoiceItem);
			toReturn.Add("EventsCollectionViaPhysicianInvoiceItem", _eventsCollectionViaPhysicianInvoiceItem);
			toReturn.Add("PhysicianInvoiceCollectionViaPhysicianInvoiceItem", _physicianInvoiceCollectionViaPhysicianInvoiceItem);
			toReturn.Add("PhysicianProfileCollectionViaPhysicianEarnings", _physicianProfileCollectionViaPhysicianEarnings);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_physicianEarnings!=null)
			{
				_physicianEarnings.ActiveContext = base.ActiveContext;
			}
			if(_physicianInvoiceItem!=null)
			{
				_physicianInvoiceItem.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaPhysicianInvoiceItem!=null)
			{
				_customerProfileCollectionViaPhysicianInvoiceItem.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaPhysicianInvoiceItem!=null)
			{
				_eventsCollectionViaPhysicianInvoiceItem.ActiveContext = base.ActiveContext;
			}
			if(_physicianInvoiceCollectionViaPhysicianInvoiceItem!=null)
			{
				_physicianInvoiceCollectionViaPhysicianInvoiceItem.ActiveContext = base.ActiveContext;
			}
			if(_physicianProfileCollectionViaPhysicianEarnings!=null)
			{
				_physicianProfileCollectionViaPhysicianEarnings.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomers!=null)
			{
				_eventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_physicianProfile!=null)
			{
				_physicianProfile.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_physicianEarnings = null;
			_physicianInvoiceItem = null;
			_customerProfileCollectionViaPhysicianInvoiceItem = null;
			_eventsCollectionViaPhysicianInvoiceItem = null;
			_physicianInvoiceCollectionViaPhysicianInvoiceItem = null;
			_physicianProfileCollectionViaPhysicianEarnings = null;
			_eventCustomers = null;
			_physicianProfile = null;

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

			_fieldsCustomProperties.Add("PhysicianEvaluationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhysicianId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EvaluationStartTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EvaluationEndTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ipaddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPrimaryEvaluator", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _eventCustomers</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomers(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", PhysicianEvaluationEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, signalRelatedEntity, "PhysicianEvaluation", resetFKFields, new int[] { (int)PhysicianEvaluationFieldIndex.EventCustomerId } );		
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
				base.PerformSetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", PhysicianEvaluationEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _physicianProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPhysicianProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _physicianProfile, new PropertyChangedEventHandler( OnPhysicianProfilePropertyChanged ), "PhysicianProfile", PhysicianEvaluationEntity.Relations.PhysicianProfileEntityUsingPhysicianId, true, signalRelatedEntity, "PhysicianEvaluation", resetFKFields, new int[] { (int)PhysicianEvaluationFieldIndex.PhysicianId } );		
			_physicianProfile = null;
		}

		/// <summary> setups the sync logic for member _physicianProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPhysicianProfile(IEntity2 relatedEntity)
		{
			if(_physicianProfile!=relatedEntity)
			{
				DesetupSyncPhysicianProfile(true, true);
				_physicianProfile = (PhysicianProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _physicianProfile, new PropertyChangedEventHandler( OnPhysicianProfilePropertyChanged ), "PhysicianProfile", PhysicianEvaluationEntity.Relations.PhysicianProfileEntityUsingPhysicianId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPhysicianProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PhysicianEvaluationEntity</param>
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
		public  static PhysicianEvaluationRelations Relations
		{
			get	{ return new PhysicianEvaluationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianEarnings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianEarnings
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianEarningsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEarningsEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianEarnings")[0], (int)Falcon.Data.EntityType.PhysicianEvaluationEntity, (int)Falcon.Data.EntityType.PhysicianEarningsEntity, 0, null, null, null, null, "PhysicianEarnings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianInvoiceItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianInvoiceItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianInvoiceItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianInvoiceItem")[0], (int)Falcon.Data.EntityType.PhysicianEvaluationEntity, (int)Falcon.Data.EntityType.PhysicianInvoiceItemEntity, 0, null, null, null, null, "PhysicianInvoiceItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaPhysicianInvoiceItem
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianEvaluationEntity.Relations.PhysicianInvoiceItemEntityUsingPhysicianEvaluationId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianInvoiceItem_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianEvaluationEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaPhysicianInvoiceItem"), null, "CustomerProfileCollectionViaPhysicianInvoiceItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaPhysicianInvoiceItem
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianEvaluationEntity.Relations.PhysicianInvoiceItemEntityUsingPhysicianEvaluationId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianInvoiceItem_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianEvaluationEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaPhysicianInvoiceItem"), null, "EventsCollectionViaPhysicianInvoiceItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianInvoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianInvoiceCollectionViaPhysicianInvoiceItem
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianEvaluationEntity.Relations.PhysicianInvoiceItemEntityUsingPhysicianEvaluationId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianInvoiceItem_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianEvaluationEntity, (int)Falcon.Data.EntityType.PhysicianInvoiceEntity, 0, null, null, GetRelationsForField("PhysicianInvoiceCollectionViaPhysicianInvoiceItem"), null, "PhysicianInvoiceCollectionViaPhysicianInvoiceItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfileCollectionViaPhysicianEarnings
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianEvaluationEntity.Relations.PhysicianEarningsEntityUsingPhysicianEvaluationId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianEarnings_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianEvaluationEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, GetRelationsForField("PhysicianProfileCollectionViaPhysicianEarnings"), null, "PhysicianProfileCollectionViaPhysicianEarnings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)Falcon.Data.EntityType.PhysicianEvaluationEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianProfile")[0], (int)Falcon.Data.EntityType.PhysicianEvaluationEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, null, null, "PhysicianProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PhysicianEvaluationEntity.CustomProperties;}
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
			get { return PhysicianEvaluationEntity.FieldsCustomProperties;}
		}

		/// <summary> The PhysicianEvaluationId property of the Entity PhysicianEvaluation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianEvaluation"."PhysicianEvaluationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PhysicianEvaluationId
		{
			get { return (System.Int64)GetValue((int)PhysicianEvaluationFieldIndex.PhysicianEvaluationId, true); }
			set	{ SetValue((int)PhysicianEvaluationFieldIndex.PhysicianEvaluationId, value); }
		}

		/// <summary> The PhysicianId property of the Entity PhysicianEvaluation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianEvaluation"."PhysicianID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PhysicianId
		{
			get { return (System.Int64)GetValue((int)PhysicianEvaluationFieldIndex.PhysicianId, true); }
			set	{ SetValue((int)PhysicianEvaluationFieldIndex.PhysicianId, value); }
		}

		/// <summary> The EventCustomerId property of the Entity PhysicianEvaluation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianEvaluation"."EventCustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventCustomerId
		{
			get { return (System.Int64)GetValue((int)PhysicianEvaluationFieldIndex.EventCustomerId, true); }
			set	{ SetValue((int)PhysicianEvaluationFieldIndex.EventCustomerId, value); }
		}

		/// <summary> The EvaluationStartTime property of the Entity PhysicianEvaluation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianEvaluation"."EvaluationStartTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime EvaluationStartTime
		{
			get { return (System.DateTime)GetValue((int)PhysicianEvaluationFieldIndex.EvaluationStartTime, true); }
			set	{ SetValue((int)PhysicianEvaluationFieldIndex.EvaluationStartTime, value); }
		}

		/// <summary> The EvaluationEndTime property of the Entity PhysicianEvaluation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianEvaluation"."EvaluationEndTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> EvaluationEndTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PhysicianEvaluationFieldIndex.EvaluationEndTime, false); }
			set	{ SetValue((int)PhysicianEvaluationFieldIndex.EvaluationEndTime, value); }
		}

		/// <summary> The Ipaddress property of the Entity PhysicianEvaluation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianEvaluation"."IPAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Ipaddress
		{
			get { return (System.String)GetValue((int)PhysicianEvaluationFieldIndex.Ipaddress, true); }
			set	{ SetValue((int)PhysicianEvaluationFieldIndex.Ipaddress, value); }
		}

		/// <summary> The IsPrimaryEvaluator property of the Entity PhysicianEvaluation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianEvaluation"."IsPrimaryEvaluator"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPrimaryEvaluator
		{
			get { return (System.Boolean)GetValue((int)PhysicianEvaluationFieldIndex.IsPrimaryEvaluator, true); }
			set	{ SetValue((int)PhysicianEvaluationFieldIndex.IsPrimaryEvaluator, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianEarningsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianEarningsEntity))]
		public virtual EntityCollection<PhysicianEarningsEntity> PhysicianEarnings
		{
			get
			{
				if(_physicianEarnings==null)
				{
					_physicianEarnings = new EntityCollection<PhysicianEarningsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEarningsEntityFactory)));
					_physicianEarnings.SetContainingEntityInfo(this, "PhysicianEvaluation");
				}
				return _physicianEarnings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianInvoiceItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianInvoiceItemEntity))]
		public virtual EntityCollection<PhysicianInvoiceItemEntity> PhysicianInvoiceItem
		{
			get
			{
				if(_physicianInvoiceItem==null)
				{
					_physicianInvoiceItem = new EntityCollection<PhysicianInvoiceItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceItemEntityFactory)));
					_physicianInvoiceItem.SetContainingEntityInfo(this, "PhysicianEvaluation");
				}
				return _physicianInvoiceItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaPhysicianInvoiceItem
		{
			get
			{
				if(_customerProfileCollectionViaPhysicianInvoiceItem==null)
				{
					_customerProfileCollectionViaPhysicianInvoiceItem = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaPhysicianInvoiceItem.IsReadOnly=true;
				}
				return _customerProfileCollectionViaPhysicianInvoiceItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaPhysicianInvoiceItem
		{
			get
			{
				if(_eventsCollectionViaPhysicianInvoiceItem==null)
				{
					_eventsCollectionViaPhysicianInvoiceItem = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaPhysicianInvoiceItem.IsReadOnly=true;
				}
				return _eventsCollectionViaPhysicianInvoiceItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianInvoiceEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianInvoiceEntity))]
		public virtual EntityCollection<PhysicianInvoiceEntity> PhysicianInvoiceCollectionViaPhysicianInvoiceItem
		{
			get
			{
				if(_physicianInvoiceCollectionViaPhysicianInvoiceItem==null)
				{
					_physicianInvoiceCollectionViaPhysicianInvoiceItem = new EntityCollection<PhysicianInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory)));
					_physicianInvoiceCollectionViaPhysicianInvoiceItem.IsReadOnly=true;
				}
				return _physicianInvoiceCollectionViaPhysicianInvoiceItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianProfileEntity))]
		public virtual EntityCollection<PhysicianProfileEntity> PhysicianProfileCollectionViaPhysicianEarnings
		{
			get
			{
				if(_physicianProfileCollectionViaPhysicianEarnings==null)
				{
					_physicianProfileCollectionViaPhysicianEarnings = new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory)));
					_physicianProfileCollectionViaPhysicianEarnings.IsReadOnly=true;
				}
				return _physicianProfileCollectionViaPhysicianEarnings;
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
							_eventCustomers.UnsetRelatedEntity(this, "PhysicianEvaluation");
						}
					}
					else
					{
						if(_eventCustomers!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianEvaluation");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PhysicianProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PhysicianProfileEntity PhysicianProfile
		{
			get
			{
				return _physicianProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPhysicianProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_physicianProfile != null)
						{
							_physicianProfile.UnsetRelatedEntity(this, "PhysicianEvaluation");
						}
					}
					else
					{
						if(_physicianProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianEvaluation");
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
			get { return (int)Falcon.Data.EntityType.PhysicianEvaluationEntity; }
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
