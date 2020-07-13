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
	/// Entity class which represents the entity 'HostEventDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class HostEventDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private EventsEntity _events;
		private ProspectsEntity _prospects;

		
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
			/// <summary>Member name Prospects</summary>
			public static readonly string Prospects = "Prospects";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static HostEventDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public HostEventDetailsEntity():base("HostEventDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public HostEventDetailsEntity(IEntityFields2 fields):base("HostEventDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this HostEventDetailsEntity</param>
		public HostEventDetailsEntity(IValidator validator):base("HostEventDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="hostEventId">PK value for HostEventDetails which data should be fetched into this HostEventDetails object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HostEventDetailsEntity(System.Int64 hostEventId):base("HostEventDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.HostEventId = hostEventId;
		}

		/// <summary> CTor</summary>
		/// <param name="hostEventId">PK value for HostEventDetails which data should be fetched into this HostEventDetails object</param>
		/// <param name="validator">The custom validator object for this HostEventDetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HostEventDetailsEntity(System.Int64 hostEventId, IValidator validator):base("HostEventDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.HostEventId = hostEventId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected HostEventDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_prospects = (ProspectsEntity)info.GetValue("_prospects", typeof(ProspectsEntity));
				if(_prospects!=null)
				{
					_prospects.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((HostEventDetailsFieldIndex)fieldIndex)
			{
				case HostEventDetailsFieldIndex.HostId:
					DesetupSyncProspects(true, false);
					break;
				case HostEventDetailsFieldIndex.EventId:
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
				case "Prospects":
					this.Prospects = (ProspectsEntity)entity;
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
			return HostEventDetailsEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(HostEventDetailsEntity.Relations.EventsEntityUsingEventId);
					break;
				case "Prospects":
					toReturn.Add(HostEventDetailsEntity.Relations.ProspectsEntityUsingHostId);
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
				case "Prospects":
					SetupSyncProspects(relatedEntity);
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
				case "Prospects":
					DesetupSyncProspects(false, true);
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
			if(_prospects!=null)
			{
				toReturn.Add(_prospects);
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
				info.AddValue("_prospects", (!this.MarkedForDeletion?_prospects:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(HostEventDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(HostEventDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new HostEventDetailsRelations().GetAllRelations();
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
		/// the related entity of type 'Prospects' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.HostId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.HostEventDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(HostEventDetailsEntityFactory));
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
			toReturn.Add("Prospects", _prospects);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_prospects!=null)
			{
				_prospects.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_events = null;
			_prospects = null;

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

			_fieldsCustomProperties.Add("HostEventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HostId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BConfirmMinRequirements", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BConfirmedVisually", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConfirmedVisuallyComments", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DepositAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PayByCheck", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PayByCreditCard", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentDueDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DepositDueDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InstructionForCallCenter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsHostRatedbyTechnician", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", HostEventDetailsEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "HostEventDetails", resetFKFields, new int[] { (int)HostEventDetailsFieldIndex.EventId } );		
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
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", HostEventDetailsEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _prospects</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncProspects(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _prospects, new PropertyChangedEventHandler( OnProspectsPropertyChanged ), "Prospects", HostEventDetailsEntity.Relations.ProspectsEntityUsingHostId, true, signalRelatedEntity, "HostEventDetails", resetFKFields, new int[] { (int)HostEventDetailsFieldIndex.HostId } );		
			_prospects = null;
		}

		/// <summary> setups the sync logic for member _prospects</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncProspects(IEntity2 relatedEntity)
		{
			if(_prospects!=relatedEntity)
			{
				DesetupSyncProspects(true, true);
				_prospects = (ProspectsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _prospects, new PropertyChangedEventHandler( OnProspectsPropertyChanged ), "Prospects", HostEventDetailsEntity.Relations.ProspectsEntityUsingHostId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProspectsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this HostEventDetailsEntity</param>
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
		public  static HostEventDetailsRelations Relations
		{
			get	{ return new HostEventDetailsRelations(); }
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
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.HostEventDetailsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspects
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Prospects")[0], (int)Falcon.Data.EntityType.HostEventDetailsEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, null, null, "Prospects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return HostEventDetailsEntity.CustomProperties;}
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
			get { return HostEventDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The HostEventId property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."HostEventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 HostEventId
		{
			get { return (System.Int64)GetValue((int)HostEventDetailsFieldIndex.HostEventId, true); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.HostEventId, value); }
		}

		/// <summary> The HostId property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."HostID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HostId
		{
			get { return (System.Int64)GetValue((int)HostEventDetailsFieldIndex.HostId, true); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.HostId, value); }
		}

		/// <summary> The EventId property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)HostEventDetailsFieldIndex.EventId, true); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.EventId, value); }
		}

		/// <summary> The BConfirmMinRequirements property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."bConfirmMinRequirements"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> BConfirmMinRequirements
		{
			get { return (Nullable<System.Boolean>)GetValue((int)HostEventDetailsFieldIndex.BConfirmMinRequirements, false); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.BConfirmMinRequirements, value); }
		}

		/// <summary> The BConfirmedVisually property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."bConfirmedVisually"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> BConfirmedVisually
		{
			get { return (Nullable<System.Boolean>)GetValue((int)HostEventDetailsFieldIndex.BConfirmedVisually, false); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.BConfirmedVisually, value); }
		}

		/// <summary> The ConfirmedVisuallyComments property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."ConfirmedVisuallyComments"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ConfirmedVisuallyComments
		{
			get { return (System.String)GetValue((int)HostEventDetailsFieldIndex.ConfirmedVisuallyComments, true); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.ConfirmedVisuallyComments, value); }
		}

		/// <summary> The DateCreated property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)HostEventDetailsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)HostEventDetailsFieldIndex.DateModified, true); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.DateModified, value); }
		}

		/// <summary> The DepositAmount property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."DepositAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> DepositAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)HostEventDetailsFieldIndex.DepositAmount, false); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.DepositAmount, value); }
		}

		/// <summary> The PayByCheck property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."PayByCheck"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> PayByCheck
		{
			get { return (Nullable<System.Boolean>)GetValue((int)HostEventDetailsFieldIndex.PayByCheck, false); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.PayByCheck, value); }
		}

		/// <summary> The PayByCreditCard property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."PayByCreditCard"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> PayByCreditCard
		{
			get { return (Nullable<System.Boolean>)GetValue((int)HostEventDetailsFieldIndex.PayByCreditCard, false); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.PayByCreditCard, value); }
		}

		/// <summary> The PaymentDueDate property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."PaymentDueDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> PaymentDueDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)HostEventDetailsFieldIndex.PaymentDueDate, false); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.PaymentDueDate, value); }
		}

		/// <summary> The DepositDueDate property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."DepositDueDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DepositDueDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)HostEventDetailsFieldIndex.DepositDueDate, false); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.DepositDueDate, value); }
		}

		/// <summary> The InstructionForCallCenter property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."InstructionForCallCenter"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String InstructionForCallCenter
		{
			get { return (System.String)GetValue((int)HostEventDetailsFieldIndex.InstructionForCallCenter, true); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.InstructionForCallCenter, value); }
		}

		/// <summary> The IsHostRatedbyTechnician property of the Entity HostEventDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHostEventDetails"."IsHostRatedbyTechnician"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsHostRatedbyTechnician
		{
			get { return (System.Boolean)GetValue((int)HostEventDetailsFieldIndex.IsHostRatedbyTechnician, true); }
			set	{ SetValue((int)HostEventDetailsFieldIndex.IsHostRatedbyTechnician, value); }
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
							_events.UnsetRelatedEntity(this, "HostEventDetails");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HostEventDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ProspectsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ProspectsEntity Prospects
		{
			get
			{
				return _prospects;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncProspects(value);
				}
				else
				{
					if(value==null)
					{
						if(_prospects != null)
						{
							_prospects.UnsetRelatedEntity(this, "HostEventDetails");
						}
					}
					else
					{
						if(_prospects!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HostEventDetails");
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
			get { return (int)Falcon.Data.EntityType.HostEventDetailsEntity; }
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
