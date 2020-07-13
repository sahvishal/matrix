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
	/// Entity class which represents the entity 'Ndc'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class NdcEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CurrentMedicationEntity> _currentMedication;
		private EntityCollection<EventCustomerCurrentMedicationEntity> _eventCustomerCurrentMedication;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCurrentMedication;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerCurrentMedication;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCurrentMedication;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name CurrentMedication</summary>
			public static readonly string CurrentMedication = "CurrentMedication";
			/// <summary>Member name EventCustomerCurrentMedication</summary>
			public static readonly string EventCustomerCurrentMedication = "EventCustomerCurrentMedication";
			/// <summary>Member name CustomerProfileCollectionViaCurrentMedication</summary>
			public static readonly string CustomerProfileCollectionViaCurrentMedication = "CustomerProfileCollectionViaCurrentMedication";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerCurrentMedication</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerCurrentMedication = "EventCustomersCollectionViaEventCustomerCurrentMedication";
			/// <summary>Member name OrganizationRoleUserCollectionViaCurrentMedication</summary>
			public static readonly string OrganizationRoleUserCollectionViaCurrentMedication = "OrganizationRoleUserCollectionViaCurrentMedication";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static NdcEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public NdcEntity():base("NdcEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public NdcEntity(IEntityFields2 fields):base("NdcEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this NdcEntity</param>
		public NdcEntity(IValidator validator):base("NdcEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Ndc which data should be fetched into this Ndc object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NdcEntity(System.Int64 id):base("NdcEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Ndc which data should be fetched into this Ndc object</param>
		/// <param name="validator">The custom validator object for this NdcEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NdcEntity(System.Int64 id, IValidator validator):base("NdcEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected NdcEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_currentMedication = (EntityCollection<CurrentMedicationEntity>)info.GetValue("_currentMedication", typeof(EntityCollection<CurrentMedicationEntity>));
				_eventCustomerCurrentMedication = (EntityCollection<EventCustomerCurrentMedicationEntity>)info.GetValue("_eventCustomerCurrentMedication", typeof(EntityCollection<EventCustomerCurrentMedicationEntity>));
				_customerProfileCollectionViaCurrentMedication = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCurrentMedication", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaEventCustomerCurrentMedication = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerCurrentMedication", typeof(EntityCollection<EventCustomersEntity>));
				_organizationRoleUserCollectionViaCurrentMedication = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCurrentMedication", typeof(EntityCollection<OrganizationRoleUserEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((NdcFieldIndex)fieldIndex)
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

				case "CurrentMedication":
					this.CurrentMedication.Add((CurrentMedicationEntity)entity);
					break;
				case "EventCustomerCurrentMedication":
					this.EventCustomerCurrentMedication.Add((EventCustomerCurrentMedicationEntity)entity);
					break;
				case "CustomerProfileCollectionViaCurrentMedication":
					this.CustomerProfileCollectionViaCurrentMedication.IsReadOnly = false;
					this.CustomerProfileCollectionViaCurrentMedication.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCurrentMedication.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerCurrentMedication":
					this.EventCustomersCollectionViaEventCustomerCurrentMedication.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerCurrentMedication.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerCurrentMedication.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCurrentMedication":
					this.OrganizationRoleUserCollectionViaCurrentMedication.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCurrentMedication.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCurrentMedication.IsReadOnly = true;
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
			return NdcEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "CurrentMedication":
					toReturn.Add(NdcEntity.Relations.CurrentMedicationEntityUsingNdcId);
					break;
				case "EventCustomerCurrentMedication":
					toReturn.Add(NdcEntity.Relations.EventCustomerCurrentMedicationEntityUsingNdcId);
					break;
				case "CustomerProfileCollectionViaCurrentMedication":
					toReturn.Add(NdcEntity.Relations.CurrentMedicationEntityUsingNdcId, "NdcEntity__", "CurrentMedication_", JoinHint.None);
					toReturn.Add(CurrentMedicationEntity.Relations.CustomerProfileEntityUsingCustomerId, "CurrentMedication_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerCurrentMedication":
					toReturn.Add(NdcEntity.Relations.EventCustomerCurrentMedicationEntityUsingNdcId, "NdcEntity__", "EventCustomerCurrentMedication_", JoinHint.None);
					toReturn.Add(EventCustomerCurrentMedicationEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerCurrentMedication_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCurrentMedication":
					toReturn.Add(NdcEntity.Relations.CurrentMedicationEntityUsingNdcId, "NdcEntity__", "CurrentMedication_", JoinHint.None);
					toReturn.Add(CurrentMedicationEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CurrentMedication_", string.Empty, JoinHint.None);
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

				case "CurrentMedication":
					this.CurrentMedication.Add((CurrentMedicationEntity)relatedEntity);
					break;
				case "EventCustomerCurrentMedication":
					this.EventCustomerCurrentMedication.Add((EventCustomerCurrentMedicationEntity)relatedEntity);
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

				case "CurrentMedication":
					base.PerformRelatedEntityRemoval(this.CurrentMedication, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerCurrentMedication":
					base.PerformRelatedEntityRemoval(this.EventCustomerCurrentMedication, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CurrentMedication);
			toReturn.Add(this.EventCustomerCurrentMedication);

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
				info.AddValue("_currentMedication", ((_currentMedication!=null) && (_currentMedication.Count>0) && !this.MarkedForDeletion)?_currentMedication:null);
				info.AddValue("_eventCustomerCurrentMedication", ((_eventCustomerCurrentMedication!=null) && (_eventCustomerCurrentMedication.Count>0) && !this.MarkedForDeletion)?_eventCustomerCurrentMedication:null);
				info.AddValue("_customerProfileCollectionViaCurrentMedication", ((_customerProfileCollectionViaCurrentMedication!=null) && (_customerProfileCollectionViaCurrentMedication.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCurrentMedication:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerCurrentMedication", ((_eventCustomersCollectionViaEventCustomerCurrentMedication!=null) && (_eventCustomersCollectionViaEventCustomerCurrentMedication.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerCurrentMedication:null);
				info.AddValue("_organizationRoleUserCollectionViaCurrentMedication", ((_organizationRoleUserCollectionViaCurrentMedication!=null) && (_organizationRoleUserCollectionViaCurrentMedication.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCurrentMedication:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(NdcFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(NdcFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new NdcRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CurrentMedication' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCurrentMedication()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CurrentMedicationFields.NdcId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerCurrentMedication' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerCurrentMedication()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerCurrentMedicationFields.NdcId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCurrentMedication()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCurrentMedication"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NdcFields.Id, null, ComparisonOperator.Equal, this.Id, "NdcEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerCurrentMedication()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerCurrentMedication"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NdcFields.Id, null, ComparisonOperator.Equal, this.Id, "NdcEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCurrentMedication()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCurrentMedication"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NdcFields.Id, null, ComparisonOperator.Equal, this.Id, "NdcEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.NdcEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(NdcEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._currentMedication);
			collectionsQueue.Enqueue(this._eventCustomerCurrentMedication);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCurrentMedication);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerCurrentMedication);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCurrentMedication);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._currentMedication = (EntityCollection<CurrentMedicationEntity>) collectionsQueue.Dequeue();
			this._eventCustomerCurrentMedication = (EntityCollection<EventCustomerCurrentMedicationEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCurrentMedication = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerCurrentMedication = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCurrentMedication = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._currentMedication != null)
			{
				return true;
			}
			if (this._eventCustomerCurrentMedication != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCurrentMedication != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerCurrentMedication != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCurrentMedication != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CurrentMedicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CurrentMedicationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerCurrentMedicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCurrentMedicationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("CurrentMedication", _currentMedication);
			toReturn.Add("EventCustomerCurrentMedication", _eventCustomerCurrentMedication);
			toReturn.Add("CustomerProfileCollectionViaCurrentMedication", _customerProfileCollectionViaCurrentMedication);
			toReturn.Add("EventCustomersCollectionViaEventCustomerCurrentMedication", _eventCustomersCollectionViaEventCustomerCurrentMedication);
			toReturn.Add("OrganizationRoleUserCollectionViaCurrentMedication", _organizationRoleUserCollectionViaCurrentMedication);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_currentMedication!=null)
			{
				_currentMedication.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerCurrentMedication!=null)
			{
				_eventCustomerCurrentMedication.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCurrentMedication!=null)
			{
				_customerProfileCollectionViaCurrentMedication.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerCurrentMedication!=null)
			{
				_eventCustomersCollectionViaEventCustomerCurrentMedication.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCurrentMedication!=null)
			{
				_organizationRoleUserCollectionViaCurrentMedication.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_currentMedication = null;
			_eventCustomerCurrentMedication = null;
			_customerProfileCollectionViaCurrentMedication = null;
			_eventCustomersCollectionViaEventCustomerCurrentMedication = null;
			_organizationRoleUserCollectionViaCurrentMedication = null;


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

			_fieldsCustomProperties.Add("ProductName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NdcCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Route", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dose", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActiveNumeratorStrength", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActiveIngredUnit", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this NdcEntity</param>
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
		public  static NdcRelations Relations
		{
			get	{ return new NdcRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CurrentMedication' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCurrentMedication
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CurrentMedicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CurrentMedicationEntityFactory))),
					(IEntityRelation)GetRelationsForField("CurrentMedication")[0], (int)Falcon.Data.EntityType.NdcEntity, (int)Falcon.Data.EntityType.CurrentMedicationEntity, 0, null, null, null, null, "CurrentMedication", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerCurrentMedication' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerCurrentMedication
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerCurrentMedicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCurrentMedicationEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerCurrentMedication")[0], (int)Falcon.Data.EntityType.NdcEntity, (int)Falcon.Data.EntityType.EventCustomerCurrentMedicationEntity, 0, null, null, null, null, "EventCustomerCurrentMedication", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCurrentMedication
		{
			get
			{
				IEntityRelation intermediateRelation = NdcEntity.Relations.CurrentMedicationEntityUsingNdcId;
				intermediateRelation.SetAliases(string.Empty, "CurrentMedication_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NdcEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCurrentMedication"), null, "CustomerProfileCollectionViaCurrentMedication", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerCurrentMedication
		{
			get
			{
				IEntityRelation intermediateRelation = NdcEntity.Relations.EventCustomerCurrentMedicationEntityUsingNdcId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerCurrentMedication_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NdcEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerCurrentMedication"), null, "EventCustomersCollectionViaEventCustomerCurrentMedication", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCurrentMedication
		{
			get
			{
				IEntityRelation intermediateRelation = NdcEntity.Relations.CurrentMedicationEntityUsingNdcId;
				intermediateRelation.SetAliases(string.Empty, "CurrentMedication_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NdcEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCurrentMedication"), null, "OrganizationRoleUserCollectionViaCurrentMedication", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return NdcEntity.CustomProperties;}
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
			get { return NdcEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity Ndc<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNdc"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)NdcFieldIndex.Id, true); }
			set	{ SetValue((int)NdcFieldIndex.Id, value); }
		}

		/// <summary> The ProductName property of the Entity Ndc<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNdc"."ProductName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ProductName
		{
			get { return (System.String)GetValue((int)NdcFieldIndex.ProductName, true); }
			set	{ SetValue((int)NdcFieldIndex.ProductName, value); }
		}

		/// <summary> The NdcCode property of the Entity Ndc<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNdc"."NdcCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String NdcCode
		{
			get { return (System.String)GetValue((int)NdcFieldIndex.NdcCode, true); }
			set	{ SetValue((int)NdcFieldIndex.NdcCode, value); }
		}

		/// <summary> The Route property of the Entity Ndc<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNdc"."Route"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Route
		{
			get { return (System.String)GetValue((int)NdcFieldIndex.Route, true); }
			set	{ SetValue((int)NdcFieldIndex.Route, value); }
		}

		/// <summary> The Dose property of the Entity Ndc<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNdc"."Dose"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Dose
		{
			get { return (System.String)GetValue((int)NdcFieldIndex.Dose, true); }
			set	{ SetValue((int)NdcFieldIndex.Dose, value); }
		}

		/// <summary> The ActiveNumeratorStrength property of the Entity Ndc<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNdc"."ActiveNumeratorStrength"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ActiveNumeratorStrength
		{
			get { return (System.String)GetValue((int)NdcFieldIndex.ActiveNumeratorStrength, true); }
			set	{ SetValue((int)NdcFieldIndex.ActiveNumeratorStrength, value); }
		}

		/// <summary> The ActiveIngredUnit property of the Entity Ndc<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNdc"."ActiveIngredUnit"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ActiveIngredUnit
		{
			get { return (System.String)GetValue((int)NdcFieldIndex.ActiveIngredUnit, true); }
			set	{ SetValue((int)NdcFieldIndex.ActiveIngredUnit, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CurrentMedicationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CurrentMedicationEntity))]
		public virtual EntityCollection<CurrentMedicationEntity> CurrentMedication
		{
			get
			{
				if(_currentMedication==null)
				{
					_currentMedication = new EntityCollection<CurrentMedicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CurrentMedicationEntityFactory)));
					_currentMedication.SetContainingEntityInfo(this, "Ndc");
				}
				return _currentMedication;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerCurrentMedicationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerCurrentMedicationEntity))]
		public virtual EntityCollection<EventCustomerCurrentMedicationEntity> EventCustomerCurrentMedication
		{
			get
			{
				if(_eventCustomerCurrentMedication==null)
				{
					_eventCustomerCurrentMedication = new EntityCollection<EventCustomerCurrentMedicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCurrentMedicationEntityFactory)));
					_eventCustomerCurrentMedication.SetContainingEntityInfo(this, "Ndc");
				}
				return _eventCustomerCurrentMedication;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCurrentMedication
		{
			get
			{
				if(_customerProfileCollectionViaCurrentMedication==null)
				{
					_customerProfileCollectionViaCurrentMedication = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCurrentMedication.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCurrentMedication;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerCurrentMedication
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerCurrentMedication==null)
				{
					_eventCustomersCollectionViaEventCustomerCurrentMedication = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerCurrentMedication.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerCurrentMedication;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCurrentMedication
		{
			get
			{
				if(_organizationRoleUserCollectionViaCurrentMedication==null)
				{
					_organizationRoleUserCollectionViaCurrentMedication = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCurrentMedication.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCurrentMedication;
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
			get { return (int)Falcon.Data.EntityType.NdcEntity; }
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
