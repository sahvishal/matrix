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
	/// Entity class which represents the entity 'ChaseCampaign'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ChaseCampaignEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerChaseCampaignEntity> _customerChaseCampaign;
		private EntityCollection<ChaseOutboundEntity> _chaseOutboundCollectionViaCustomerChaseCampaign;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerChaseCampaign;
		private ChaseCampaignTypeEntity _chaseCampaignType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ChaseCampaignType</summary>
			public static readonly string ChaseCampaignType = "ChaseCampaignType";
			/// <summary>Member name CustomerChaseCampaign</summary>
			public static readonly string CustomerChaseCampaign = "CustomerChaseCampaign";
			/// <summary>Member name ChaseOutboundCollectionViaCustomerChaseCampaign</summary>
			public static readonly string ChaseOutboundCollectionViaCustomerChaseCampaign = "ChaseOutboundCollectionViaCustomerChaseCampaign";
			/// <summary>Member name CustomerProfileCollectionViaCustomerChaseCampaign</summary>
			public static readonly string CustomerProfileCollectionViaCustomerChaseCampaign = "CustomerProfileCollectionViaCustomerChaseCampaign";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ChaseCampaignEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ChaseCampaignEntity():base("ChaseCampaignEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ChaseCampaignEntity(IEntityFields2 fields):base("ChaseCampaignEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ChaseCampaignEntity</param>
		public ChaseCampaignEntity(IValidator validator):base("ChaseCampaignEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="chaseCampaignId">PK value for ChaseCampaign which data should be fetched into this ChaseCampaign object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseCampaignEntity(System.Int64 chaseCampaignId):base("ChaseCampaignEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ChaseCampaignId = chaseCampaignId;
		}

		/// <summary> CTor</summary>
		/// <param name="chaseCampaignId">PK value for ChaseCampaign which data should be fetched into this ChaseCampaign object</param>
		/// <param name="validator">The custom validator object for this ChaseCampaignEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseCampaignEntity(System.Int64 chaseCampaignId, IValidator validator):base("ChaseCampaignEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ChaseCampaignId = chaseCampaignId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ChaseCampaignEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerChaseCampaign = (EntityCollection<CustomerChaseCampaignEntity>)info.GetValue("_customerChaseCampaign", typeof(EntityCollection<CustomerChaseCampaignEntity>));
				_chaseOutboundCollectionViaCustomerChaseCampaign = (EntityCollection<ChaseOutboundEntity>)info.GetValue("_chaseOutboundCollectionViaCustomerChaseCampaign", typeof(EntityCollection<ChaseOutboundEntity>));
				_customerProfileCollectionViaCustomerChaseCampaign = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerChaseCampaign", typeof(EntityCollection<CustomerProfileEntity>));
				_chaseCampaignType = (ChaseCampaignTypeEntity)info.GetValue("_chaseCampaignType", typeof(ChaseCampaignTypeEntity));
				if(_chaseCampaignType!=null)
				{
					_chaseCampaignType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ChaseCampaignFieldIndex)fieldIndex)
			{
				case ChaseCampaignFieldIndex.ChaseCampaignTypeId:
					DesetupSyncChaseCampaignType(true, false);
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
				case "ChaseCampaignType":
					this.ChaseCampaignType = (ChaseCampaignTypeEntity)entity;
					break;
				case "CustomerChaseCampaign":
					this.CustomerChaseCampaign.Add((CustomerChaseCampaignEntity)entity);
					break;
				case "ChaseOutboundCollectionViaCustomerChaseCampaign":
					this.ChaseOutboundCollectionViaCustomerChaseCampaign.IsReadOnly = false;
					this.ChaseOutboundCollectionViaCustomerChaseCampaign.Add((ChaseOutboundEntity)entity);
					this.ChaseOutboundCollectionViaCustomerChaseCampaign.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerChaseCampaign":
					this.CustomerProfileCollectionViaCustomerChaseCampaign.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerChaseCampaign.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerChaseCampaign.IsReadOnly = true;
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
			return ChaseCampaignEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ChaseCampaignType":
					toReturn.Add(ChaseCampaignEntity.Relations.ChaseCampaignTypeEntityUsingChaseCampaignTypeId);
					break;
				case "CustomerChaseCampaign":
					toReturn.Add(ChaseCampaignEntity.Relations.CustomerChaseCampaignEntityUsingChaseCampaignId);
					break;
				case "ChaseOutboundCollectionViaCustomerChaseCampaign":
					toReturn.Add(ChaseCampaignEntity.Relations.CustomerChaseCampaignEntityUsingChaseCampaignId, "ChaseCampaignEntity__", "CustomerChaseCampaign_", JoinHint.None);
					toReturn.Add(CustomerChaseCampaignEntity.Relations.ChaseOutboundEntityUsingChaseOutboundId, "CustomerChaseCampaign_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerChaseCampaign":
					toReturn.Add(ChaseCampaignEntity.Relations.CustomerChaseCampaignEntityUsingChaseCampaignId, "ChaseCampaignEntity__", "CustomerChaseCampaign_", JoinHint.None);
					toReturn.Add(CustomerChaseCampaignEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerChaseCampaign_", string.Empty, JoinHint.None);
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
				case "ChaseCampaignType":
					SetupSyncChaseCampaignType(relatedEntity);
					break;
				case "CustomerChaseCampaign":
					this.CustomerChaseCampaign.Add((CustomerChaseCampaignEntity)relatedEntity);
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
				case "ChaseCampaignType":
					DesetupSyncChaseCampaignType(false, true);
					break;
				case "CustomerChaseCampaign":
					base.PerformRelatedEntityRemoval(this.CustomerChaseCampaign, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_chaseCampaignType!=null)
			{
				toReturn.Add(_chaseCampaignType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerChaseCampaign);

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
				info.AddValue("_customerChaseCampaign", ((_customerChaseCampaign!=null) && (_customerChaseCampaign.Count>0) && !this.MarkedForDeletion)?_customerChaseCampaign:null);
				info.AddValue("_chaseOutboundCollectionViaCustomerChaseCampaign", ((_chaseOutboundCollectionViaCustomerChaseCampaign!=null) && (_chaseOutboundCollectionViaCustomerChaseCampaign.Count>0) && !this.MarkedForDeletion)?_chaseOutboundCollectionViaCustomerChaseCampaign:null);
				info.AddValue("_customerProfileCollectionViaCustomerChaseCampaign", ((_customerProfileCollectionViaCustomerChaseCampaign!=null) && (_customerProfileCollectionViaCustomerChaseCampaign.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerChaseCampaign:null);
				info.AddValue("_chaseCampaignType", (!this.MarkedForDeletion?_chaseCampaignType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ChaseCampaignFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ChaseCampaignFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ChaseCampaignRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerChaseCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerChaseCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerChaseCampaignFields.ChaseCampaignId, null, ComparisonOperator.Equal, this.ChaseCampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaseOutbound' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseOutboundCollectionViaCustomerChaseCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChaseOutboundCollectionViaCustomerChaseCampaign"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseCampaignFields.ChaseCampaignId, null, ComparisonOperator.Equal, this.ChaseCampaignId, "ChaseCampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerChaseCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerChaseCampaign"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseCampaignFields.ChaseCampaignId, null, ComparisonOperator.Equal, this.ChaseCampaignId, "ChaseCampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ChaseCampaignType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseCampaignType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseCampaignTypeFields.ChaseCampaignTypeId, null, ComparisonOperator.Equal, this.ChaseCampaignTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ChaseCampaignEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ChaseCampaignEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerChaseCampaign);
			collectionsQueue.Enqueue(this._chaseOutboundCollectionViaCustomerChaseCampaign);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerChaseCampaign);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerChaseCampaign = (EntityCollection<CustomerChaseCampaignEntity>) collectionsQueue.Dequeue();
			this._chaseOutboundCollectionViaCustomerChaseCampaign = (EntityCollection<ChaseOutboundEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerChaseCampaign = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerChaseCampaign != null)
			{
				return true;
			}
			if (this._chaseOutboundCollectionViaCustomerChaseCampaign != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerChaseCampaign != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerChaseCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseCampaignEntityFactory))) : null);
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
			toReturn.Add("ChaseCampaignType", _chaseCampaignType);
			toReturn.Add("CustomerChaseCampaign", _customerChaseCampaign);
			toReturn.Add("ChaseOutboundCollectionViaCustomerChaseCampaign", _chaseOutboundCollectionViaCustomerChaseCampaign);
			toReturn.Add("CustomerProfileCollectionViaCustomerChaseCampaign", _customerProfileCollectionViaCustomerChaseCampaign);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerChaseCampaign!=null)
			{
				_customerChaseCampaign.ActiveContext = base.ActiveContext;
			}
			if(_chaseOutboundCollectionViaCustomerChaseCampaign!=null)
			{
				_chaseOutboundCollectionViaCustomerChaseCampaign.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerChaseCampaign!=null)
			{
				_customerProfileCollectionViaCustomerChaseCampaign.ActiveContext = base.ActiveContext;
			}
			if(_chaseCampaignType!=null)
			{
				_chaseCampaignType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerChaseCampaign = null;
			_chaseOutboundCollectionViaCustomerChaseCampaign = null;
			_customerProfileCollectionViaCustomerChaseCampaign = null;
			_chaseCampaignType = null;

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

			_fieldsCustomProperties.Add("ChaseCampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignHouseholdId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChaseCampaignTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("KeyCode", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _chaseCampaignType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncChaseCampaignType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _chaseCampaignType, new PropertyChangedEventHandler( OnChaseCampaignTypePropertyChanged ), "ChaseCampaignType", ChaseCampaignEntity.Relations.ChaseCampaignTypeEntityUsingChaseCampaignTypeId, true, signalRelatedEntity, "ChaseCampaign", resetFKFields, new int[] { (int)ChaseCampaignFieldIndex.ChaseCampaignTypeId } );		
			_chaseCampaignType = null;
		}

		/// <summary> setups the sync logic for member _chaseCampaignType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncChaseCampaignType(IEntity2 relatedEntity)
		{
			if(_chaseCampaignType!=relatedEntity)
			{
				DesetupSyncChaseCampaignType(true, true);
				_chaseCampaignType = (ChaseCampaignTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _chaseCampaignType, new PropertyChangedEventHandler( OnChaseCampaignTypePropertyChanged ), "ChaseCampaignType", ChaseCampaignEntity.Relations.ChaseCampaignTypeEntityUsingChaseCampaignTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnChaseCampaignTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ChaseCampaignEntity</param>
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
		public  static ChaseCampaignRelations Relations
		{
			get	{ return new ChaseCampaignRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerChaseCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerChaseCampaign
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerChaseCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseCampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerChaseCampaign")[0], (int)Falcon.Data.EntityType.ChaseCampaignEntity, (int)Falcon.Data.EntityType.CustomerChaseCampaignEntity, 0, null, null, null, null, "CustomerChaseCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseOutbound' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseOutboundCollectionViaCustomerChaseCampaign
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseCampaignEntity.Relations.CustomerChaseCampaignEntityUsingChaseCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseCampaign_");
				return new PrefetchPathElement2(new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseCampaignEntity, (int)Falcon.Data.EntityType.ChaseOutboundEntity, 0, null, null, GetRelationsForField("ChaseOutboundCollectionViaCustomerChaseCampaign"), null, "ChaseOutboundCollectionViaCustomerChaseCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerChaseCampaign
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseCampaignEntity.Relations.CustomerChaseCampaignEntityUsingChaseCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseCampaign_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseCampaignEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerChaseCampaign"), null, "CustomerProfileCollectionViaCustomerChaseCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseCampaignType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseCampaignType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ChaseCampaignTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaseCampaignType")[0], (int)Falcon.Data.EntityType.ChaseCampaignEntity, (int)Falcon.Data.EntityType.ChaseCampaignTypeEntity, 0, null, null, null, null, "ChaseCampaignType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ChaseCampaignEntity.CustomProperties;}
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
			get { return ChaseCampaignEntity.FieldsCustomProperties;}
		}

		/// <summary> The ChaseCampaignId property of the Entity ChaseCampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseCampaign"."ChaseCampaignId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ChaseCampaignId
		{
			get { return (System.Int64)GetValue((int)ChaseCampaignFieldIndex.ChaseCampaignId, true); }
			set	{ SetValue((int)ChaseCampaignFieldIndex.ChaseCampaignId, value); }
		}

		/// <summary> The CampaignId property of the Entity ChaseCampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseCampaign"."CampaignId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CampaignId
		{
			get { return (System.String)GetValue((int)ChaseCampaignFieldIndex.CampaignId, true); }
			set	{ SetValue((int)ChaseCampaignFieldIndex.CampaignId, value); }
		}

		/// <summary> The CampaignFileId property of the Entity ChaseCampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseCampaign"."CampaignFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CampaignFileId
		{
			get { return (System.String)GetValue((int)ChaseCampaignFieldIndex.CampaignFileId, true); }
			set	{ SetValue((int)ChaseCampaignFieldIndex.CampaignFileId, value); }
		}

		/// <summary> The CampaignName property of the Entity ChaseCampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseCampaign"."CampaignName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CampaignName
		{
			get { return (System.String)GetValue((int)ChaseCampaignFieldIndex.CampaignName, true); }
			set	{ SetValue((int)ChaseCampaignFieldIndex.CampaignName, value); }
		}

		/// <summary> The CampaignCode property of the Entity ChaseCampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseCampaign"."CampaignCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CampaignCode
		{
			get { return (System.String)GetValue((int)ChaseCampaignFieldIndex.CampaignCode, true); }
			set	{ SetValue((int)ChaseCampaignFieldIndex.CampaignCode, value); }
		}

		/// <summary> The CampaignHouseholdId property of the Entity ChaseCampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseCampaign"."CampaignHouseholdId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CampaignHouseholdId
		{
			get { return (System.String)GetValue((int)ChaseCampaignFieldIndex.CampaignHouseholdId, true); }
			set	{ SetValue((int)ChaseCampaignFieldIndex.CampaignHouseholdId, value); }
		}

		/// <summary> The ChaseCampaignTypeId property of the Entity ChaseCampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseCampaign"."ChaseCampaignTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ChaseCampaignTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ChaseCampaignFieldIndex.ChaseCampaignTypeId, false); }
			set	{ SetValue((int)ChaseCampaignFieldIndex.ChaseCampaignTypeId, value); }
		}

		/// <summary> The KeyCode property of the Entity ChaseCampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseCampaign"."KeyCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String KeyCode
		{
			get { return (System.String)GetValue((int)ChaseCampaignFieldIndex.KeyCode, true); }
			set	{ SetValue((int)ChaseCampaignFieldIndex.KeyCode, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerChaseCampaignEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerChaseCampaignEntity))]
		public virtual EntityCollection<CustomerChaseCampaignEntity> CustomerChaseCampaign
		{
			get
			{
				if(_customerChaseCampaign==null)
				{
					_customerChaseCampaign = new EntityCollection<CustomerChaseCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseCampaignEntityFactory)));
					_customerChaseCampaign.SetContainingEntityInfo(this, "ChaseCampaign");
				}
				return _customerChaseCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaseOutboundEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaseOutboundEntity))]
		public virtual EntityCollection<ChaseOutboundEntity> ChaseOutboundCollectionViaCustomerChaseCampaign
		{
			get
			{
				if(_chaseOutboundCollectionViaCustomerChaseCampaign==null)
				{
					_chaseOutboundCollectionViaCustomerChaseCampaign = new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory)));
					_chaseOutboundCollectionViaCustomerChaseCampaign.IsReadOnly=true;
				}
				return _chaseOutboundCollectionViaCustomerChaseCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerChaseCampaign
		{
			get
			{
				if(_customerProfileCollectionViaCustomerChaseCampaign==null)
				{
					_customerProfileCollectionViaCustomerChaseCampaign = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerChaseCampaign.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerChaseCampaign;
			}
		}

		/// <summary> Gets / sets related entity of type 'ChaseCampaignTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ChaseCampaignTypeEntity ChaseCampaignType
		{
			get
			{
				return _chaseCampaignType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncChaseCampaignType(value);
				}
				else
				{
					if(value==null)
					{
						if(_chaseCampaignType != null)
						{
							_chaseCampaignType.UnsetRelatedEntity(this, "ChaseCampaign");
						}
					}
					else
					{
						if(_chaseCampaignType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChaseCampaign");
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
			get { return (int)Falcon.Data.EntityType.ChaseCampaignEntity; }
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
