///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:50
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
	/// Entity class which represents the entity 'ChaseChannelLevel'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ChaseChannelLevelEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerChaseChannelEntity> _customerChaseChannel;
		private EntityCollection<ChaseOutboundEntity> _chaseOutboundCollectionViaCustomerChaseChannel;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerChaseChannel;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name CustomerChaseChannel</summary>
			public static readonly string CustomerChaseChannel = "CustomerChaseChannel";
			/// <summary>Member name ChaseOutboundCollectionViaCustomerChaseChannel</summary>
			public static readonly string ChaseOutboundCollectionViaCustomerChaseChannel = "ChaseOutboundCollectionViaCustomerChaseChannel";
			/// <summary>Member name CustomerProfileCollectionViaCustomerChaseChannel</summary>
			public static readonly string CustomerProfileCollectionViaCustomerChaseChannel = "CustomerProfileCollectionViaCustomerChaseChannel";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ChaseChannelLevelEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ChaseChannelLevelEntity():base("ChaseChannelLevelEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ChaseChannelLevelEntity(IEntityFields2 fields):base("ChaseChannelLevelEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ChaseChannelLevelEntity</param>
		public ChaseChannelLevelEntity(IValidator validator):base("ChaseChannelLevelEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="chaseChannelLevelId">PK value for ChaseChannelLevel which data should be fetched into this ChaseChannelLevel object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseChannelLevelEntity(System.Int64 chaseChannelLevelId):base("ChaseChannelLevelEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ChaseChannelLevelId = chaseChannelLevelId;
		}

		/// <summary> CTor</summary>
		/// <param name="chaseChannelLevelId">PK value for ChaseChannelLevel which data should be fetched into this ChaseChannelLevel object</param>
		/// <param name="validator">The custom validator object for this ChaseChannelLevelEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseChannelLevelEntity(System.Int64 chaseChannelLevelId, IValidator validator):base("ChaseChannelLevelEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ChaseChannelLevelId = chaseChannelLevelId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ChaseChannelLevelEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerChaseChannel = (EntityCollection<CustomerChaseChannelEntity>)info.GetValue("_customerChaseChannel", typeof(EntityCollection<CustomerChaseChannelEntity>));
				_chaseOutboundCollectionViaCustomerChaseChannel = (EntityCollection<ChaseOutboundEntity>)info.GetValue("_chaseOutboundCollectionViaCustomerChaseChannel", typeof(EntityCollection<ChaseOutboundEntity>));
				_customerProfileCollectionViaCustomerChaseChannel = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerChaseChannel", typeof(EntityCollection<CustomerProfileEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ChaseChannelLevelFieldIndex)fieldIndex)
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

				case "CustomerChaseChannel":
					this.CustomerChaseChannel.Add((CustomerChaseChannelEntity)entity);
					break;
				case "ChaseOutboundCollectionViaCustomerChaseChannel":
					this.ChaseOutboundCollectionViaCustomerChaseChannel.IsReadOnly = false;
					this.ChaseOutboundCollectionViaCustomerChaseChannel.Add((ChaseOutboundEntity)entity);
					this.ChaseOutboundCollectionViaCustomerChaseChannel.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerChaseChannel":
					this.CustomerProfileCollectionViaCustomerChaseChannel.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerChaseChannel.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerChaseChannel.IsReadOnly = true;
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
			return ChaseChannelLevelEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "CustomerChaseChannel":
					toReturn.Add(ChaseChannelLevelEntity.Relations.CustomerChaseChannelEntityUsingChaseChannelLevelId);
					break;
				case "ChaseOutboundCollectionViaCustomerChaseChannel":
					toReturn.Add(ChaseChannelLevelEntity.Relations.CustomerChaseChannelEntityUsingChaseChannelLevelId, "ChaseChannelLevelEntity__", "CustomerChaseChannel_", JoinHint.None);
					toReturn.Add(CustomerChaseChannelEntity.Relations.ChaseOutboundEntityUsingChaseOutboundId, "CustomerChaseChannel_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerChaseChannel":
					toReturn.Add(ChaseChannelLevelEntity.Relations.CustomerChaseChannelEntityUsingChaseChannelLevelId, "ChaseChannelLevelEntity__", "CustomerChaseChannel_", JoinHint.None);
					toReturn.Add(CustomerChaseChannelEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerChaseChannel_", string.Empty, JoinHint.None);
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

				case "CustomerChaseChannel":
					this.CustomerChaseChannel.Add((CustomerChaseChannelEntity)relatedEntity);
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

				case "CustomerChaseChannel":
					base.PerformRelatedEntityRemoval(this.CustomerChaseChannel, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CustomerChaseChannel);

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
				info.AddValue("_customerChaseChannel", ((_customerChaseChannel!=null) && (_customerChaseChannel.Count>0) && !this.MarkedForDeletion)?_customerChaseChannel:null);
				info.AddValue("_chaseOutboundCollectionViaCustomerChaseChannel", ((_chaseOutboundCollectionViaCustomerChaseChannel!=null) && (_chaseOutboundCollectionViaCustomerChaseChannel.Count>0) && !this.MarkedForDeletion)?_chaseOutboundCollectionViaCustomerChaseChannel:null);
				info.AddValue("_customerProfileCollectionViaCustomerChaseChannel", ((_customerProfileCollectionViaCustomerChaseChannel!=null) && (_customerProfileCollectionViaCustomerChaseChannel.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerChaseChannel:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ChaseChannelLevelFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ChaseChannelLevelFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ChaseChannelLevelRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerChaseChannel' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerChaseChannel()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerChaseChannelFields.ChaseChannelLevelId, null, ComparisonOperator.Equal, this.ChaseChannelLevelId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaseOutbound' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseOutboundCollectionViaCustomerChaseChannel()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChaseOutboundCollectionViaCustomerChaseChannel"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseChannelLevelFields.ChaseChannelLevelId, null, ComparisonOperator.Equal, this.ChaseChannelLevelId, "ChaseChannelLevelEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerChaseChannel()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerChaseChannel"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseChannelLevelFields.ChaseChannelLevelId, null, ComparisonOperator.Equal, this.ChaseChannelLevelId, "ChaseChannelLevelEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ChaseChannelLevelEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ChaseChannelLevelEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerChaseChannel);
			collectionsQueue.Enqueue(this._chaseOutboundCollectionViaCustomerChaseChannel);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerChaseChannel);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerChaseChannel = (EntityCollection<CustomerChaseChannelEntity>) collectionsQueue.Dequeue();
			this._chaseOutboundCollectionViaCustomerChaseChannel = (EntityCollection<ChaseOutboundEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerChaseChannel = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerChaseChannel != null)
			{
				return true;
			}
			if (this._chaseOutboundCollectionViaCustomerChaseChannel != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerChaseChannel != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerChaseChannelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseChannelEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("CustomerChaseChannel", _customerChaseChannel);
			toReturn.Add("ChaseOutboundCollectionViaCustomerChaseChannel", _chaseOutboundCollectionViaCustomerChaseChannel);
			toReturn.Add("CustomerProfileCollectionViaCustomerChaseChannel", _customerProfileCollectionViaCustomerChaseChannel);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerChaseChannel!=null)
			{
				_customerChaseChannel.ActiveContext = base.ActiveContext;
			}
			if(_chaseOutboundCollectionViaCustomerChaseChannel!=null)
			{
				_chaseOutboundCollectionViaCustomerChaseChannel.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerChaseChannel!=null)
			{
				_customerProfileCollectionViaCustomerChaseChannel.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerChaseChannel = null;
			_chaseOutboundCollectionViaCustomerChaseChannel = null;
			_customerProfileCollectionViaCustomerChaseChannel = null;


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

			_fieldsCustomProperties.Add("ChaseChannelLevelId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChannelName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChannelLevel", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ChaseChannelLevelEntity</param>
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
		public  static ChaseChannelLevelRelations Relations
		{
			get	{ return new ChaseChannelLevelRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerChaseChannel' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerChaseChannel
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerChaseChannelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseChannelEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerChaseChannel")[0], (int)Falcon.Data.EntityType.ChaseChannelLevelEntity, (int)Falcon.Data.EntityType.CustomerChaseChannelEntity, 0, null, null, null, null, "CustomerChaseChannel", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseOutbound' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseOutboundCollectionViaCustomerChaseChannel
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseChannelLevelEntity.Relations.CustomerChaseChannelEntityUsingChaseChannelLevelId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseChannel_");
				return new PrefetchPathElement2(new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseChannelLevelEntity, (int)Falcon.Data.EntityType.ChaseOutboundEntity, 0, null, null, GetRelationsForField("ChaseOutboundCollectionViaCustomerChaseChannel"), null, "ChaseOutboundCollectionViaCustomerChaseChannel", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerChaseChannel
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseChannelLevelEntity.Relations.CustomerChaseChannelEntityUsingChaseChannelLevelId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseChannel_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseChannelLevelEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerChaseChannel"), null, "CustomerProfileCollectionViaCustomerChaseChannel", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ChaseChannelLevelEntity.CustomProperties;}
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
			get { return ChaseChannelLevelEntity.FieldsCustomProperties;}
		}

		/// <summary> The ChaseChannelLevelId property of the Entity ChaseChannelLevel<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseChannelLevel"."ChaseChannelLevelId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ChaseChannelLevelId
		{
			get { return (System.Int64)GetValue((int)ChaseChannelLevelFieldIndex.ChaseChannelLevelId, true); }
			set	{ SetValue((int)ChaseChannelLevelFieldIndex.ChaseChannelLevelId, value); }
		}

		/// <summary> The ChannelName property of the Entity ChaseChannelLevel<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseChannelLevel"."ChannelName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ChannelName
		{
			get { return (System.String)GetValue((int)ChaseChannelLevelFieldIndex.ChannelName, true); }
			set	{ SetValue((int)ChaseChannelLevelFieldIndex.ChannelName, value); }
		}

		/// <summary> The ChannelLevel property of the Entity ChaseChannelLevel<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseChannelLevel"."ChannelLevel"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ChannelLevel
		{
			get { return (System.Int64)GetValue((int)ChaseChannelLevelFieldIndex.ChannelLevel, true); }
			set	{ SetValue((int)ChaseChannelLevelFieldIndex.ChannelLevel, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerChaseChannelEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerChaseChannelEntity))]
		public virtual EntityCollection<CustomerChaseChannelEntity> CustomerChaseChannel
		{
			get
			{
				if(_customerChaseChannel==null)
				{
					_customerChaseChannel = new EntityCollection<CustomerChaseChannelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseChannelEntityFactory)));
					_customerChaseChannel.SetContainingEntityInfo(this, "ChaseChannelLevel");
				}
				return _customerChaseChannel;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaseOutboundEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaseOutboundEntity))]
		public virtual EntityCollection<ChaseOutboundEntity> ChaseOutboundCollectionViaCustomerChaseChannel
		{
			get
			{
				if(_chaseOutboundCollectionViaCustomerChaseChannel==null)
				{
					_chaseOutboundCollectionViaCustomerChaseChannel = new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory)));
					_chaseOutboundCollectionViaCustomerChaseChannel.IsReadOnly=true;
				}
				return _chaseOutboundCollectionViaCustomerChaseChannel;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerChaseChannel
		{
			get
			{
				if(_customerProfileCollectionViaCustomerChaseChannel==null)
				{
					_customerProfileCollectionViaCustomerChaseChannel = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerChaseChannel.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerChaseChannel;
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
			get { return (int)Falcon.Data.EntityType.ChaseChannelLevelEntity; }
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
