///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:51
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
	/// Entity class which represents the entity 'SmsReceived'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class SmsReceivedEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerUnsubscribedSmsNotificationEntity> _customerUnsubscribedSmsNotification;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerUnsubscribedSmsNotification;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerUnsubscribedSmsNotification;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name CustomerUnsubscribedSmsNotification</summary>
			public static readonly string CustomerUnsubscribedSmsNotification = "CustomerUnsubscribedSmsNotification";
			/// <summary>Member name CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification</summary>
			public static readonly string CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification = "CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification";
			/// <summary>Member name LookupCollectionViaCustomerUnsubscribedSmsNotification</summary>
			public static readonly string LookupCollectionViaCustomerUnsubscribedSmsNotification = "LookupCollectionViaCustomerUnsubscribedSmsNotification";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SmsReceivedEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public SmsReceivedEntity():base("SmsReceivedEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SmsReceivedEntity(IEntityFields2 fields):base("SmsReceivedEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SmsReceivedEntity</param>
		public SmsReceivedEntity(IValidator validator):base("SmsReceivedEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for SmsReceived which data should be fetched into this SmsReceived object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SmsReceivedEntity(System.Int64 id):base("SmsReceivedEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for SmsReceived which data should be fetched into this SmsReceived object</param>
		/// <param name="validator">The custom validator object for this SmsReceivedEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SmsReceivedEntity(System.Int64 id, IValidator validator):base("SmsReceivedEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected SmsReceivedEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerUnsubscribedSmsNotification = (EntityCollection<CustomerUnsubscribedSmsNotificationEntity>)info.GetValue("_customerUnsubscribedSmsNotification", typeof(EntityCollection<CustomerUnsubscribedSmsNotificationEntity>));
				_customerProfileCollectionViaCustomerUnsubscribedSmsNotification = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerUnsubscribedSmsNotification", typeof(EntityCollection<CustomerProfileEntity>));
				_lookupCollectionViaCustomerUnsubscribedSmsNotification = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerUnsubscribedSmsNotification", typeof(EntityCollection<LookupEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((SmsReceivedFieldIndex)fieldIndex)
			{
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

				case "CustomerUnsubscribedSmsNotification":
					this.CustomerUnsubscribedSmsNotification.Add((CustomerUnsubscribedSmsNotificationEntity)entity);
					break;
				case "CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification":
					this.CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerUnsubscribedSmsNotification":
					this.LookupCollectionViaCustomerUnsubscribedSmsNotification.IsReadOnly = false;
					this.LookupCollectionViaCustomerUnsubscribedSmsNotification.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerUnsubscribedSmsNotification.IsReadOnly = true;
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
			return SmsReceivedEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "CustomerUnsubscribedSmsNotification":
					toReturn.Add(SmsReceivedEntity.Relations.CustomerUnsubscribedSmsNotificationEntityUsingSmsReceivedId);
					break;
				case "CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification":
					toReturn.Add(SmsReceivedEntity.Relations.CustomerUnsubscribedSmsNotificationEntityUsingSmsReceivedId, "SmsReceivedEntity__", "CustomerUnsubscribedSmsNotification_", JoinHint.None);
					toReturn.Add(CustomerUnsubscribedSmsNotificationEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerUnsubscribedSmsNotification_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerUnsubscribedSmsNotification":
					toReturn.Add(SmsReceivedEntity.Relations.CustomerUnsubscribedSmsNotificationEntityUsingSmsReceivedId, "SmsReceivedEntity__", "CustomerUnsubscribedSmsNotification_", JoinHint.None);
					toReturn.Add(CustomerUnsubscribedSmsNotificationEntity.Relations.LookupEntityUsingStatusId, "CustomerUnsubscribedSmsNotification_", string.Empty, JoinHint.None);
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

				case "CustomerUnsubscribedSmsNotification":
					this.CustomerUnsubscribedSmsNotification.Add((CustomerUnsubscribedSmsNotificationEntity)relatedEntity);
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

				case "CustomerUnsubscribedSmsNotification":
					base.PerformRelatedEntityRemoval(this.CustomerUnsubscribedSmsNotification, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerUnsubscribedSmsNotification);

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
				info.AddValue("_customerUnsubscribedSmsNotification", ((_customerUnsubscribedSmsNotification!=null) && (_customerUnsubscribedSmsNotification.Count>0) && !this.MarkedForDeletion)?_customerUnsubscribedSmsNotification:null);
				info.AddValue("_customerProfileCollectionViaCustomerUnsubscribedSmsNotification", ((_customerProfileCollectionViaCustomerUnsubscribedSmsNotification!=null) && (_customerProfileCollectionViaCustomerUnsubscribedSmsNotification.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerUnsubscribedSmsNotification:null);
				info.AddValue("_lookupCollectionViaCustomerUnsubscribedSmsNotification", ((_lookupCollectionViaCustomerUnsubscribedSmsNotification!=null) && (_lookupCollectionViaCustomerUnsubscribedSmsNotification.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerUnsubscribedSmsNotification:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(SmsReceivedFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(SmsReceivedFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new SmsReceivedRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerUnsubscribedSmsNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerUnsubscribedSmsNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerUnsubscribedSmsNotificationFields.SmsReceivedId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerUnsubscribedSmsNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SmsReceivedFields.Id, null, ComparisonOperator.Equal, this.Id, "SmsReceivedEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerUnsubscribedSmsNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerUnsubscribedSmsNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SmsReceivedFields.Id, null, ComparisonOperator.Equal, this.Id, "SmsReceivedEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.SmsReceivedEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(SmsReceivedEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerUnsubscribedSmsNotification);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerUnsubscribedSmsNotification);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerUnsubscribedSmsNotification);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerUnsubscribedSmsNotification = (EntityCollection<CustomerUnsubscribedSmsNotificationEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerUnsubscribedSmsNotification = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerUnsubscribedSmsNotification = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerUnsubscribedSmsNotification != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerUnsubscribedSmsNotification != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerUnsubscribedSmsNotification != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerUnsubscribedSmsNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerUnsubscribedSmsNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("CustomerUnsubscribedSmsNotification", _customerUnsubscribedSmsNotification);
			toReturn.Add("CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification", _customerProfileCollectionViaCustomerUnsubscribedSmsNotification);
			toReturn.Add("LookupCollectionViaCustomerUnsubscribedSmsNotification", _lookupCollectionViaCustomerUnsubscribedSmsNotification);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerUnsubscribedSmsNotification!=null)
			{
				_customerUnsubscribedSmsNotification.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerUnsubscribedSmsNotification!=null)
			{
				_customerProfileCollectionViaCustomerUnsubscribedSmsNotification.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerUnsubscribedSmsNotification!=null)
			{
				_lookupCollectionViaCustomerUnsubscribedSmsNotification.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerUnsubscribedSmsNotification = null;
			_customerProfileCollectionViaCustomerUnsubscribedSmsNotification = null;
			_lookupCollectionViaCustomerUnsubscribedSmsNotification = null;


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

			_fieldsCustomProperties.Add("PhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Message", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this SmsReceivedEntity</param>
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
		public  static SmsReceivedRelations Relations
		{
			get	{ return new SmsReceivedRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerUnsubscribedSmsNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerUnsubscribedSmsNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerUnsubscribedSmsNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerUnsubscribedSmsNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerUnsubscribedSmsNotification")[0], (int)Falcon.Data.EntityType.SmsReceivedEntity, (int)Falcon.Data.EntityType.CustomerUnsubscribedSmsNotificationEntity, 0, null, null, null, null, "CustomerUnsubscribedSmsNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerUnsubscribedSmsNotification
		{
			get
			{
				IEntityRelation intermediateRelation = SmsReceivedEntity.Relations.CustomerUnsubscribedSmsNotificationEntityUsingSmsReceivedId;
				intermediateRelation.SetAliases(string.Empty, "CustomerUnsubscribedSmsNotification_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SmsReceivedEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification"), null, "CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerUnsubscribedSmsNotification
		{
			get
			{
				IEntityRelation intermediateRelation = SmsReceivedEntity.Relations.CustomerUnsubscribedSmsNotificationEntityUsingSmsReceivedId;
				intermediateRelation.SetAliases(string.Empty, "CustomerUnsubscribedSmsNotification_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SmsReceivedEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerUnsubscribedSmsNotification"), null, "LookupCollectionViaCustomerUnsubscribedSmsNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return SmsReceivedEntity.CustomProperties;}
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
			get { return SmsReceivedEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity SmsReceived<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSmsReceived"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)SmsReceivedFieldIndex.Id, true); }
			set	{ SetValue((int)SmsReceivedFieldIndex.Id, value); }
		}

		/// <summary> The PhoneNumber property of the Entity SmsReceived<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSmsReceived"."PhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PhoneNumber
		{
			get { return (System.String)GetValue((int)SmsReceivedFieldIndex.PhoneNumber, true); }
			set	{ SetValue((int)SmsReceivedFieldIndex.PhoneNumber, value); }
		}

		/// <summary> The DateCreated property of the Entity SmsReceived<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSmsReceived"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)SmsReceivedFieldIndex.DateCreated, true); }
			set	{ SetValue((int)SmsReceivedFieldIndex.DateCreated, value); }
		}

		/// <summary> The Message property of the Entity SmsReceived<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSmsReceived"."Message"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Message
		{
			get { return (System.String)GetValue((int)SmsReceivedFieldIndex.Message, true); }
			set	{ SetValue((int)SmsReceivedFieldIndex.Message, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerUnsubscribedSmsNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerUnsubscribedSmsNotificationEntity))]
		public virtual EntityCollection<CustomerUnsubscribedSmsNotificationEntity> CustomerUnsubscribedSmsNotification
		{
			get
			{
				if(_customerUnsubscribedSmsNotification==null)
				{
					_customerUnsubscribedSmsNotification = new EntityCollection<CustomerUnsubscribedSmsNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerUnsubscribedSmsNotificationEntityFactory)));
					_customerUnsubscribedSmsNotification.SetContainingEntityInfo(this, "SmsReceived");
				}
				return _customerUnsubscribedSmsNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerUnsubscribedSmsNotification
		{
			get
			{
				if(_customerProfileCollectionViaCustomerUnsubscribedSmsNotification==null)
				{
					_customerProfileCollectionViaCustomerUnsubscribedSmsNotification = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerUnsubscribedSmsNotification.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerUnsubscribedSmsNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerUnsubscribedSmsNotification
		{
			get
			{
				if(_lookupCollectionViaCustomerUnsubscribedSmsNotification==null)
				{
					_lookupCollectionViaCustomerUnsubscribedSmsNotification = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerUnsubscribedSmsNotification.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerUnsubscribedSmsNotification;
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
			get { return (int)Falcon.Data.EntityType.SmsReceivedEntity; }
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
