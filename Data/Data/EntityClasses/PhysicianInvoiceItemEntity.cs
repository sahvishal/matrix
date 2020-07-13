﻿///////////////////////////////////////////////////////////////
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
	/// Entity class which represents the entity 'PhysicianInvoiceItem'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PhysicianInvoiceItemEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CustomerProfileEntity _customerProfile;
		private EventsEntity _events;
		private PhysicianEvaluationEntity _physicianEvaluation;
		private PhysicianInvoiceEntity _physicianInvoice;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name PhysicianEvaluation</summary>
			public static readonly string PhysicianEvaluation = "PhysicianEvaluation";
			/// <summary>Member name PhysicianInvoice</summary>
			public static readonly string PhysicianInvoice = "PhysicianInvoice";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PhysicianInvoiceItemEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PhysicianInvoiceItemEntity():base("PhysicianInvoiceItemEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PhysicianInvoiceItemEntity(IEntityFields2 fields):base("PhysicianInvoiceItemEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PhysicianInvoiceItemEntity</param>
		public PhysicianInvoiceItemEntity(IValidator validator):base("PhysicianInvoiceItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="physicianInvoiceItemId">PK value for PhysicianInvoiceItem which data should be fetched into this PhysicianInvoiceItem object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianInvoiceItemEntity(System.Int64 physicianInvoiceItemId):base("PhysicianInvoiceItemEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PhysicianInvoiceItemId = physicianInvoiceItemId;
		}

		/// <summary> CTor</summary>
		/// <param name="physicianInvoiceItemId">PK value for PhysicianInvoiceItem which data should be fetched into this PhysicianInvoiceItem object</param>
		/// <param name="validator">The custom validator object for this PhysicianInvoiceItemEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianInvoiceItemEntity(System.Int64 physicianInvoiceItemId, IValidator validator):base("PhysicianInvoiceItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PhysicianInvoiceItemId = physicianInvoiceItemId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PhysicianInvoiceItemEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_physicianEvaluation = (PhysicianEvaluationEntity)info.GetValue("_physicianEvaluation", typeof(PhysicianEvaluationEntity));
				if(_physicianEvaluation!=null)
				{
					_physicianEvaluation.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_physicianInvoice = (PhysicianInvoiceEntity)info.GetValue("_physicianInvoice", typeof(PhysicianInvoiceEntity));
				if(_physicianInvoice!=null)
				{
					_physicianInvoice.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PhysicianInvoiceItemFieldIndex)fieldIndex)
			{
				case PhysicianInvoiceItemFieldIndex.PhysicianInvoiceId:
					DesetupSyncPhysicianInvoice(true, false);
					break;
				case PhysicianInvoiceItemFieldIndex.PhysicianEvaluationId:
					DesetupSyncPhysicianEvaluation(true, false);
					break;
				case PhysicianInvoiceItemFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case PhysicianInvoiceItemFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
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
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "PhysicianEvaluation":
					this.PhysicianEvaluation = (PhysicianEvaluationEntity)entity;
					break;
				case "PhysicianInvoice":
					this.PhysicianInvoice = (PhysicianInvoiceEntity)entity;
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
			return PhysicianInvoiceItemEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerProfile":
					toReturn.Add(PhysicianInvoiceItemEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "Events":
					toReturn.Add(PhysicianInvoiceItemEntity.Relations.EventsEntityUsingEventId);
					break;
				case "PhysicianEvaluation":
					toReturn.Add(PhysicianInvoiceItemEntity.Relations.PhysicianEvaluationEntityUsingPhysicianEvaluationId);
					break;
				case "PhysicianInvoice":
					toReturn.Add(PhysicianInvoiceItemEntity.Relations.PhysicianInvoiceEntityUsingPhysicianInvoiceId);
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
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "PhysicianEvaluation":
					SetupSyncPhysicianEvaluation(relatedEntity);
					break;
				case "PhysicianInvoice":
					SetupSyncPhysicianInvoice(relatedEntity);
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
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "PhysicianEvaluation":
					DesetupSyncPhysicianEvaluation(false, true);
					break;
				case "PhysicianInvoice":
					DesetupSyncPhysicianInvoice(false, true);
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
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_physicianEvaluation!=null)
			{
				toReturn.Add(_physicianEvaluation);
			}
			if(_physicianInvoice!=null)
			{
				toReturn.Add(_physicianInvoice);
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


				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_physicianEvaluation", (!this.MarkedForDeletion?_physicianEvaluation:null));
				info.AddValue("_physicianInvoice", (!this.MarkedForDeletion?_physicianInvoice:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PhysicianInvoiceItemFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PhysicianInvoiceItemFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PhysicianInvoiceItemRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
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
		/// the related entity of type 'PhysicianEvaluation' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianEvaluation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEvaluationFields.PhysicianEvaluationId, null, ComparisonOperator.Equal, this.PhysicianEvaluationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PhysicianInvoice' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianInvoice()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianInvoiceFields.PhysicianInvoiceId, null, ComparisonOperator.Equal, this.PhysicianInvoiceId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PhysicianInvoiceItemEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceItemEntityFactory));
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
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Events", _events);
			toReturn.Add("PhysicianEvaluation", _physicianEvaluation);
			toReturn.Add("PhysicianInvoice", _physicianInvoice);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_physicianEvaluation!=null)
			{
				_physicianEvaluation.ActiveContext = base.ActiveContext;
			}
			if(_physicianInvoice!=null)
			{
				_physicianInvoice.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_customerProfile = null;
			_events = null;
			_physicianEvaluation = null;
			_physicianInvoice = null;

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

			_fieldsCustomProperties.Add("PhysicianInvoiceItemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhysicianInvoiceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhysicianEvaluationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReviewDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PodName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PackageName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AmountEarned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PodId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", PhysicianInvoiceItemEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "PhysicianInvoiceItem", resetFKFields, new int[] { (int)PhysicianInvoiceItemFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", PhysicianInvoiceItemEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", PhysicianInvoiceItemEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "PhysicianInvoiceItem", resetFKFields, new int[] { (int)PhysicianInvoiceItemFieldIndex.EventId } );		
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
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", PhysicianInvoiceItemEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _physicianEvaluation</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPhysicianEvaluation(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _physicianEvaluation, new PropertyChangedEventHandler( OnPhysicianEvaluationPropertyChanged ), "PhysicianEvaluation", PhysicianInvoiceItemEntity.Relations.PhysicianEvaluationEntityUsingPhysicianEvaluationId, true, signalRelatedEntity, "PhysicianInvoiceItem", resetFKFields, new int[] { (int)PhysicianInvoiceItemFieldIndex.PhysicianEvaluationId } );		
			_physicianEvaluation = null;
		}

		/// <summary> setups the sync logic for member _physicianEvaluation</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPhysicianEvaluation(IEntity2 relatedEntity)
		{
			if(_physicianEvaluation!=relatedEntity)
			{
				DesetupSyncPhysicianEvaluation(true, true);
				_physicianEvaluation = (PhysicianEvaluationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _physicianEvaluation, new PropertyChangedEventHandler( OnPhysicianEvaluationPropertyChanged ), "PhysicianEvaluation", PhysicianInvoiceItemEntity.Relations.PhysicianEvaluationEntityUsingPhysicianEvaluationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPhysicianEvaluationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _physicianInvoice</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPhysicianInvoice(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _physicianInvoice, new PropertyChangedEventHandler( OnPhysicianInvoicePropertyChanged ), "PhysicianInvoice", PhysicianInvoiceItemEntity.Relations.PhysicianInvoiceEntityUsingPhysicianInvoiceId, true, signalRelatedEntity, "PhysicianInvoiceItem", resetFKFields, new int[] { (int)PhysicianInvoiceItemFieldIndex.PhysicianInvoiceId } );		
			_physicianInvoice = null;
		}

		/// <summary> setups the sync logic for member _physicianInvoice</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPhysicianInvoice(IEntity2 relatedEntity)
		{
			if(_physicianInvoice!=relatedEntity)
			{
				DesetupSyncPhysicianInvoice(true, true);
				_physicianInvoice = (PhysicianInvoiceEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _physicianInvoice, new PropertyChangedEventHandler( OnPhysicianInvoicePropertyChanged ), "PhysicianInvoice", PhysicianInvoiceItemEntity.Relations.PhysicianInvoiceEntityUsingPhysicianInvoiceId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPhysicianInvoicePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PhysicianInvoiceItemEntity</param>
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
		public  static PhysicianInvoiceItemRelations Relations
		{
			get	{ return new PhysicianInvoiceItemRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.PhysicianInvoiceItemEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.PhysicianInvoiceItemEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianEvaluation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianEvaluation
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianEvaluation")[0], (int)Falcon.Data.EntityType.PhysicianInvoiceItemEntity, (int)Falcon.Data.EntityType.PhysicianEvaluationEntity, 0, null, null, null, null, "PhysicianEvaluation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianInvoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianInvoice
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianInvoice")[0], (int)Falcon.Data.EntityType.PhysicianInvoiceItemEntity, (int)Falcon.Data.EntityType.PhysicianInvoiceEntity, 0, null, null, null, null, "PhysicianInvoice", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PhysicianInvoiceItemEntity.CustomProperties;}
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
			get { return PhysicianInvoiceItemEntity.FieldsCustomProperties;}
		}

		/// <summary> The PhysicianInvoiceItemId property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."PhysicianInvoiceItemID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 PhysicianInvoiceItemId
		{
			get { return (System.Int64)GetValue((int)PhysicianInvoiceItemFieldIndex.PhysicianInvoiceItemId, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.PhysicianInvoiceItemId, value); }
		}

		/// <summary> The PhysicianInvoiceId property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."PhysicianInvoiceID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PhysicianInvoiceId
		{
			get { return (System.Int64)GetValue((int)PhysicianInvoiceItemFieldIndex.PhysicianInvoiceId, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.PhysicianInvoiceId, value); }
		}

		/// <summary> The PhysicianEvaluationId property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."PhysicianEvaluationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PhysicianEvaluationId
		{
			get { return (System.Int64)GetValue((int)PhysicianInvoiceItemFieldIndex.PhysicianEvaluationId, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.PhysicianEvaluationId, value); }
		}

		/// <summary> The EventId property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)PhysicianInvoiceItemFieldIndex.EventId, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.EventId, value); }
		}

		/// <summary> The CustomerId property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)PhysicianInvoiceItemFieldIndex.CustomerId, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.CustomerId, value); }
		}

		/// <summary> The ReviewDate property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."ReviewDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ReviewDate
		{
			get { return (System.DateTime)GetValue((int)PhysicianInvoiceItemFieldIndex.ReviewDate, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.ReviewDate, value); }
		}

		/// <summary> The EventDate property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."EventDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime EventDate
		{
			get { return (System.DateTime)GetValue((int)PhysicianInvoiceItemFieldIndex.EventDate, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.EventDate, value); }
		}

		/// <summary> The PodName property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."PodName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PodName
		{
			get { return (System.String)GetValue((int)PhysicianInvoiceItemFieldIndex.PodName, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.PodName, value); }
		}

		/// <summary> The EventName property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."EventName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EventName
		{
			get { return (System.String)GetValue((int)PhysicianInvoiceItemFieldIndex.EventName, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.EventName, value); }
		}

		/// <summary> The CustomerName property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."CustomerName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CustomerName
		{
			get { return (System.String)GetValue((int)PhysicianInvoiceItemFieldIndex.CustomerName, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.CustomerName, value); }
		}

		/// <summary> The PackageName property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."PackageName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PackageName
		{
			get { return (System.String)GetValue((int)PhysicianInvoiceItemFieldIndex.PackageName, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.PackageName, value); }
		}

		/// <summary> The AmountEarned property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."AmountEarned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal AmountEarned
		{
			get { return (System.Decimal)GetValue((int)PhysicianInvoiceItemFieldIndex.AmountEarned, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.AmountEarned, value); }
		}

		/// <summary> The PodId property of the Entity PhysicianInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianInvoiceItem"."PodID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PodId
		{
			get { return (System.Int64)GetValue((int)PhysicianInvoiceItemFieldIndex.PodId, true); }
			set	{ SetValue((int)PhysicianInvoiceItemFieldIndex.PodId, value); }
		}



		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "PhysicianInvoiceItem");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianInvoiceItem");
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
							_events.UnsetRelatedEntity(this, "PhysicianInvoiceItem");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianInvoiceItem");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PhysicianEvaluationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PhysicianEvaluationEntity PhysicianEvaluation
		{
			get
			{
				return _physicianEvaluation;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPhysicianEvaluation(value);
				}
				else
				{
					if(value==null)
					{
						if(_physicianEvaluation != null)
						{
							_physicianEvaluation.UnsetRelatedEntity(this, "PhysicianInvoiceItem");
						}
					}
					else
					{
						if(_physicianEvaluation!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianInvoiceItem");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PhysicianInvoiceEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PhysicianInvoiceEntity PhysicianInvoice
		{
			get
			{
				return _physicianInvoice;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPhysicianInvoice(value);
				}
				else
				{
					if(value==null)
					{
						if(_physicianInvoice != null)
						{
							_physicianInvoice.UnsetRelatedEntity(this, "PhysicianInvoiceItem");
						}
					}
					else
					{
						if(_physicianInvoice!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PhysicianInvoiceItem");
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
			get { return (int)Falcon.Data.EntityType.PhysicianInvoiceItemEntity; }
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
