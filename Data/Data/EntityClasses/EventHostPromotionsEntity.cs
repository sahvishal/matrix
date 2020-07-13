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
	/// Entity class which represents the entity 'EventHostPromotions'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventHostPromotionsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private EventsEntity _events;

		
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



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventHostPromotionsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventHostPromotionsEntity():base("EventHostPromotionsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventHostPromotionsEntity(IEntityFields2 fields):base("EventHostPromotionsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventHostPromotionsEntity</param>
		public EventHostPromotionsEntity(IValidator validator):base("EventHostPromotionsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eventPromotionId">PK value for EventHostPromotions which data should be fetched into this EventHostPromotions object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventHostPromotionsEntity(System.Int64 eventPromotionId):base("EventHostPromotionsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EventPromotionId = eventPromotionId;
		}

		/// <summary> CTor</summary>
		/// <param name="eventPromotionId">PK value for EventHostPromotions which data should be fetched into this EventHostPromotions object</param>
		/// <param name="validator">The custom validator object for this EventHostPromotionsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventHostPromotionsEntity(System.Int64 eventPromotionId, IValidator validator):base("EventHostPromotionsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EventPromotionId = eventPromotionId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventHostPromotionsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EventHostPromotionsFieldIndex)fieldIndex)
			{
				case EventHostPromotionsFieldIndex.EventId:
					DesetupSyncEvents(true, false);
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



				default:
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return EventHostPromotionsEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(EventHostPromotionsEntity.Relations.EventsEntityUsingEventId);
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


				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(EventHostPromotionsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventHostPromotionsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventHostPromotionsRelations().GetAllRelations();
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

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventHostPromotionsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EventHostPromotionsEntityFactory));
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
			toReturn.Add("Events", _events);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_events = null;

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

			_fieldsCustomProperties.Add("EventPromotionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BHostAllowPostersAndFlyers", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TotalPosters", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TotalHostPosters", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TotalRepPosters", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BPosterPlacementDiscussedWithHost", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BHostWillPostAnnouncement", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BAnnouncementStartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BAnnouncemcentEndDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BHostAllowBulletinInserts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BInsertDate1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BInsertDate2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NumberofInserts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BHostAllowVerbalAnnnouncements", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BVerbalAnnouncementByRepresentative", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BVerbalAnnouncementBySalesRep", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VerbalAnnouncementBySalesRepDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BHostAllowsDirectMailsToMembers", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BProvidedWithMailingInformation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DirectMailingListArrivalDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BHostAllowEmailingtheMembersOfTheOrganisation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateEmailsProvided", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventHostPromotionsEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "EventHostPromotions", resetFKFields, new int[] { (int)EventHostPromotionsFieldIndex.EventId } );		
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
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventHostPromotionsEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EventHostPromotionsEntity</param>
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
		public  static EventHostPromotionsRelations Relations
		{
			get	{ return new EventHostPromotionsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.EventHostPromotionsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventHostPromotionsEntity.CustomProperties;}
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
			get { return EventHostPromotionsEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventPromotionId property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."EventPromotionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 EventPromotionId
		{
			get { return (System.Int64)GetValue((int)EventHostPromotionsFieldIndex.EventPromotionId, true); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.EventPromotionId, value); }
		}

		/// <summary> The EventId property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)EventHostPromotionsFieldIndex.EventId, true); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.EventId, value); }
		}

		/// <summary> The BHostAllowPostersAndFlyers property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bHostAllowPostersAndFlyers"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean BHostAllowPostersAndFlyers
		{
			get { return (System.Boolean)GetValue((int)EventHostPromotionsFieldIndex.BHostAllowPostersAndFlyers, true); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BHostAllowPostersAndFlyers, value); }
		}

		/// <summary> The TotalPosters property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."TotalPosters"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> TotalPosters
		{
			get { return (Nullable<System.Decimal>)GetValue((int)EventHostPromotionsFieldIndex.TotalPosters, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.TotalPosters, value); }
		}

		/// <summary> The TotalHostPosters property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."TotalHostPosters"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> TotalHostPosters
		{
			get { return (Nullable<System.Decimal>)GetValue((int)EventHostPromotionsFieldIndex.TotalHostPosters, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.TotalHostPosters, value); }
		}

		/// <summary> The TotalRepPosters property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."TotalRepPosters"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> TotalRepPosters
		{
			get { return (Nullable<System.Decimal>)GetValue((int)EventHostPromotionsFieldIndex.TotalRepPosters, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.TotalRepPosters, value); }
		}

		/// <summary> The BPosterPlacementDiscussedWithHost property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bPosterPlacementDiscussedWithHost"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> BPosterPlacementDiscussedWithHost
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventHostPromotionsFieldIndex.BPosterPlacementDiscussedWithHost, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BPosterPlacementDiscussedWithHost, value); }
		}

		/// <summary> The BHostWillPostAnnouncement property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bHostWillPostAnnouncement"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean BHostWillPostAnnouncement
		{
			get { return (System.Boolean)GetValue((int)EventHostPromotionsFieldIndex.BHostWillPostAnnouncement, true); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BHostWillPostAnnouncement, value); }
		}

		/// <summary> The BAnnouncementStartDate property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bAnnouncementStartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> BAnnouncementStartDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventHostPromotionsFieldIndex.BAnnouncementStartDate, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BAnnouncementStartDate, value); }
		}

		/// <summary> The BAnnouncemcentEndDate property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bAnnouncemcentEndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> BAnnouncemcentEndDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventHostPromotionsFieldIndex.BAnnouncemcentEndDate, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BAnnouncemcentEndDate, value); }
		}

		/// <summary> The BHostAllowBulletinInserts property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bHostAllowBulletinInserts"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean BHostAllowBulletinInserts
		{
			get { return (System.Boolean)GetValue((int)EventHostPromotionsFieldIndex.BHostAllowBulletinInserts, true); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BHostAllowBulletinInserts, value); }
		}

		/// <summary> The BInsertDate1 property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bInsertDate1"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> BInsertDate1
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventHostPromotionsFieldIndex.BInsertDate1, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BInsertDate1, value); }
		}

		/// <summary> The BInsertDate2 property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bInsertDate2"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> BInsertDate2
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventHostPromotionsFieldIndex.BInsertDate2, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BInsertDate2, value); }
		}

		/// <summary> The NumberofInserts property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."NumberofInserts"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> NumberofInserts
		{
			get { return (Nullable<System.Decimal>)GetValue((int)EventHostPromotionsFieldIndex.NumberofInserts, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.NumberofInserts, value); }
		}

		/// <summary> The BHostAllowVerbalAnnnouncements property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bHostAllowVerbalAnnnouncements"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean BHostAllowVerbalAnnnouncements
		{
			get { return (System.Boolean)GetValue((int)EventHostPromotionsFieldIndex.BHostAllowVerbalAnnnouncements, true); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BHostAllowVerbalAnnnouncements, value); }
		}

		/// <summary> The BVerbalAnnouncementByRepresentative property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bVerbalAnnouncementByRepresentative"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> BVerbalAnnouncementByRepresentative
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventHostPromotionsFieldIndex.BVerbalAnnouncementByRepresentative, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BVerbalAnnouncementByRepresentative, value); }
		}

		/// <summary> The BVerbalAnnouncementBySalesRep property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bVerbalAnnouncementBySalesRep"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> BVerbalAnnouncementBySalesRep
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventHostPromotionsFieldIndex.BVerbalAnnouncementBySalesRep, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BVerbalAnnouncementBySalesRep, value); }
		}

		/// <summary> The VerbalAnnouncementBySalesRepDate property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."VerbalAnnouncementBySalesRepDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> VerbalAnnouncementBySalesRepDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventHostPromotionsFieldIndex.VerbalAnnouncementBySalesRepDate, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.VerbalAnnouncementBySalesRepDate, value); }
		}

		/// <summary> The BHostAllowsDirectMailsToMembers property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bHostAllowsDirectMailsToMembers"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean BHostAllowsDirectMailsToMembers
		{
			get { return (System.Boolean)GetValue((int)EventHostPromotionsFieldIndex.BHostAllowsDirectMailsToMembers, true); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BHostAllowsDirectMailsToMembers, value); }
		}

		/// <summary> The BProvidedWithMailingInformation property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bProvidedWithMailingInformation"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> BProvidedWithMailingInformation
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventHostPromotionsFieldIndex.BProvidedWithMailingInformation, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BProvidedWithMailingInformation, value); }
		}

		/// <summary> The DirectMailingListArrivalDate property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."DirectMailingListArrivalDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DirectMailingListArrivalDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventHostPromotionsFieldIndex.DirectMailingListArrivalDate, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.DirectMailingListArrivalDate, value); }
		}

		/// <summary> The BHostAllowEmailingtheMembersOfTheOrganisation property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."bHostAllowEmailingtheMembersOfTheOrganisation"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> BHostAllowEmailingtheMembersOfTheOrganisation
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventHostPromotionsFieldIndex.BHostAllowEmailingtheMembersOfTheOrganisation, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.BHostAllowEmailingtheMembersOfTheOrganisation, value); }
		}

		/// <summary> The DateEmailsProvided property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."DateEmailsProvided"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateEmailsProvided
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventHostPromotionsFieldIndex.DateEmailsProvided, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.DateEmailsProvided, value); }
		}

		/// <summary> The DateCreated property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventHostPromotionsFieldIndex.DateCreated, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventHostPromotionsFieldIndex.DateModified, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity EventHostPromotions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventHostPromotions"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsActive
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventHostPromotionsFieldIndex.IsActive, false); }
			set	{ SetValue((int)EventHostPromotionsFieldIndex.IsActive, value); }
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
							_events.UnsetRelatedEntity(this, "EventHostPromotions");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventHostPromotions");
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
			get { return (int)Falcon.Data.EntityType.EventHostPromotionsEntity; }
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
