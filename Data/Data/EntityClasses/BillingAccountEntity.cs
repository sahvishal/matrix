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
	/// Entity class which represents the entity 'BillingAccount'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class BillingAccountEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<BillingAccountTestEntity> _billingAccountTest;
		private EntityCollection<CustomerBillingAccountEntity> _customerBillingAccount;
		private EntityCollection<EncounterEntity> _encounter;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerBillingAccount;
		private EntityCollection<TestEntity> _testCollectionViaBillingAccountTest;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name BillingAccountTest</summary>
			public static readonly string BillingAccountTest = "BillingAccountTest";
			/// <summary>Member name CustomerBillingAccount</summary>
			public static readonly string CustomerBillingAccount = "CustomerBillingAccount";
			/// <summary>Member name Encounter</summary>
			public static readonly string Encounter = "Encounter";
			/// <summary>Member name CustomerProfileCollectionViaCustomerBillingAccount</summary>
			public static readonly string CustomerProfileCollectionViaCustomerBillingAccount = "CustomerProfileCollectionViaCustomerBillingAccount";
			/// <summary>Member name TestCollectionViaBillingAccountTest</summary>
			public static readonly string TestCollectionViaBillingAccountTest = "TestCollectionViaBillingAccountTest";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static BillingAccountEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public BillingAccountEntity():base("BillingAccountEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public BillingAccountEntity(IEntityFields2 fields):base("BillingAccountEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this BillingAccountEntity</param>
		public BillingAccountEntity(IValidator validator):base("BillingAccountEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="billingAccountId">PK value for BillingAccount which data should be fetched into this BillingAccount object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public BillingAccountEntity(System.Int64 billingAccountId):base("BillingAccountEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.BillingAccountId = billingAccountId;
		}

		/// <summary> CTor</summary>
		/// <param name="billingAccountId">PK value for BillingAccount which data should be fetched into this BillingAccount object</param>
		/// <param name="validator">The custom validator object for this BillingAccountEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public BillingAccountEntity(System.Int64 billingAccountId, IValidator validator):base("BillingAccountEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.BillingAccountId = billingAccountId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected BillingAccountEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_billingAccountTest = (EntityCollection<BillingAccountTestEntity>)info.GetValue("_billingAccountTest", typeof(EntityCollection<BillingAccountTestEntity>));
				_customerBillingAccount = (EntityCollection<CustomerBillingAccountEntity>)info.GetValue("_customerBillingAccount", typeof(EntityCollection<CustomerBillingAccountEntity>));
				_encounter = (EntityCollection<EncounterEntity>)info.GetValue("_encounter", typeof(EntityCollection<EncounterEntity>));
				_customerProfileCollectionViaCustomerBillingAccount = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerBillingAccount", typeof(EntityCollection<CustomerProfileEntity>));
				_testCollectionViaBillingAccountTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaBillingAccountTest", typeof(EntityCollection<TestEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((BillingAccountFieldIndex)fieldIndex)
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

				case "BillingAccountTest":
					this.BillingAccountTest.Add((BillingAccountTestEntity)entity);
					break;
				case "CustomerBillingAccount":
					this.CustomerBillingAccount.Add((CustomerBillingAccountEntity)entity);
					break;
				case "Encounter":
					this.Encounter.Add((EncounterEntity)entity);
					break;
				case "CustomerProfileCollectionViaCustomerBillingAccount":
					this.CustomerProfileCollectionViaCustomerBillingAccount.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerBillingAccount.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerBillingAccount.IsReadOnly = true;
					break;
				case "TestCollectionViaBillingAccountTest":
					this.TestCollectionViaBillingAccountTest.IsReadOnly = false;
					this.TestCollectionViaBillingAccountTest.Add((TestEntity)entity);
					this.TestCollectionViaBillingAccountTest.IsReadOnly = true;
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
			return BillingAccountEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "BillingAccountTest":
					toReturn.Add(BillingAccountEntity.Relations.BillingAccountTestEntityUsingBillingAccountId);
					break;
				case "CustomerBillingAccount":
					toReturn.Add(BillingAccountEntity.Relations.CustomerBillingAccountEntityUsingBillingAccountId);
					break;
				case "Encounter":
					toReturn.Add(BillingAccountEntity.Relations.EncounterEntityUsingBillingAccountId);
					break;
				case "CustomerProfileCollectionViaCustomerBillingAccount":
					toReturn.Add(BillingAccountEntity.Relations.CustomerBillingAccountEntityUsingBillingAccountId, "BillingAccountEntity__", "CustomerBillingAccount_", JoinHint.None);
					toReturn.Add(CustomerBillingAccountEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerBillingAccount_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaBillingAccountTest":
					toReturn.Add(BillingAccountEntity.Relations.BillingAccountTestEntityUsingBillingAccountId, "BillingAccountEntity__", "BillingAccountTest_", JoinHint.None);
					toReturn.Add(BillingAccountTestEntity.Relations.TestEntityUsingTestId, "BillingAccountTest_", string.Empty, JoinHint.None);
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

				case "BillingAccountTest":
					this.BillingAccountTest.Add((BillingAccountTestEntity)relatedEntity);
					break;
				case "CustomerBillingAccount":
					this.CustomerBillingAccount.Add((CustomerBillingAccountEntity)relatedEntity);
					break;
				case "Encounter":
					this.Encounter.Add((EncounterEntity)relatedEntity);
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

				case "BillingAccountTest":
					base.PerformRelatedEntityRemoval(this.BillingAccountTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerBillingAccount":
					base.PerformRelatedEntityRemoval(this.CustomerBillingAccount, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Encounter":
					base.PerformRelatedEntityRemoval(this.Encounter, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.BillingAccountTest);
			toReturn.Add(this.CustomerBillingAccount);
			toReturn.Add(this.Encounter);

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
				info.AddValue("_billingAccountTest", ((_billingAccountTest!=null) && (_billingAccountTest.Count>0) && !this.MarkedForDeletion)?_billingAccountTest:null);
				info.AddValue("_customerBillingAccount", ((_customerBillingAccount!=null) && (_customerBillingAccount.Count>0) && !this.MarkedForDeletion)?_customerBillingAccount:null);
				info.AddValue("_encounter", ((_encounter!=null) && (_encounter.Count>0) && !this.MarkedForDeletion)?_encounter:null);
				info.AddValue("_customerProfileCollectionViaCustomerBillingAccount", ((_customerProfileCollectionViaCustomerBillingAccount!=null) && (_customerProfileCollectionViaCustomerBillingAccount.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerBillingAccount:null);
				info.AddValue("_testCollectionViaBillingAccountTest", ((_testCollectionViaBillingAccountTest!=null) && (_testCollectionViaBillingAccountTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaBillingAccountTest:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(BillingAccountFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(BillingAccountFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new BillingAccountRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BillingAccountTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBillingAccountTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BillingAccountTestFields.BillingAccountId, null, ComparisonOperator.Equal, this.BillingAccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerBillingAccount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerBillingAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerBillingAccountFields.BillingAccountId, null, ComparisonOperator.Equal, this.BillingAccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Encounter' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEncounter()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EncounterFields.BillingAccountId, null, ComparisonOperator.Equal, this.BillingAccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerBillingAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerBillingAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BillingAccountFields.BillingAccountId, null, ComparisonOperator.Equal, this.BillingAccountId, "BillingAccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaBillingAccountTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaBillingAccountTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BillingAccountFields.BillingAccountId, null, ComparisonOperator.Equal, this.BillingAccountId, "BillingAccountEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.BillingAccountEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._billingAccountTest);
			collectionsQueue.Enqueue(this._customerBillingAccount);
			collectionsQueue.Enqueue(this._encounter);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerBillingAccount);
			collectionsQueue.Enqueue(this._testCollectionViaBillingAccountTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._billingAccountTest = (EntityCollection<BillingAccountTestEntity>) collectionsQueue.Dequeue();
			this._customerBillingAccount = (EntityCollection<CustomerBillingAccountEntity>) collectionsQueue.Dequeue();
			this._encounter = (EntityCollection<EncounterEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerBillingAccount = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaBillingAccountTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._billingAccountTest != null)
			{
				return true;
			}
			if (this._customerBillingAccount != null)
			{
				return true;
			}
			if (this._encounter != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerBillingAccount != null)
			{
				return true;
			}
			if (this._testCollectionViaBillingAccountTest != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BillingAccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerBillingAccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerBillingAccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("BillingAccountTest", _billingAccountTest);
			toReturn.Add("CustomerBillingAccount", _customerBillingAccount);
			toReturn.Add("Encounter", _encounter);
			toReturn.Add("CustomerProfileCollectionViaCustomerBillingAccount", _customerProfileCollectionViaCustomerBillingAccount);
			toReturn.Add("TestCollectionViaBillingAccountTest", _testCollectionViaBillingAccountTest);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_billingAccountTest!=null)
			{
				_billingAccountTest.ActiveContext = base.ActiveContext;
			}
			if(_customerBillingAccount!=null)
			{
				_customerBillingAccount.ActiveContext = base.ActiveContext;
			}
			if(_encounter!=null)
			{
				_encounter.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerBillingAccount!=null)
			{
				_customerProfileCollectionViaCustomerBillingAccount.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaBillingAccountTest!=null)
			{
				_testCollectionViaBillingAccountTest.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_billingAccountTest = null;
			_customerBillingAccount = null;
			_encounter = null;
			_customerProfileCollectionViaCustomerBillingAccount = null;
			_testCollectionViaBillingAccountTest = null;


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

			_fieldsCustomProperties.Add("BillingAccountId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerKey", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UserName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Password", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this BillingAccountEntity</param>
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
		public  static BillingAccountRelations Relations
		{
			get	{ return new BillingAccountRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BillingAccountTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBillingAccountTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<BillingAccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("BillingAccountTest")[0], (int)Falcon.Data.EntityType.BillingAccountEntity, (int)Falcon.Data.EntityType.BillingAccountTestEntity, 0, null, null, null, null, "BillingAccountTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerBillingAccount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerBillingAccount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerBillingAccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerBillingAccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerBillingAccount")[0], (int)Falcon.Data.EntityType.BillingAccountEntity, (int)Falcon.Data.EntityType.CustomerBillingAccountEntity, 0, null, null, null, null, "CustomerBillingAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Encounter' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEncounter
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory))),
					(IEntityRelation)GetRelationsForField("Encounter")[0], (int)Falcon.Data.EntityType.BillingAccountEntity, (int)Falcon.Data.EntityType.EncounterEntity, 0, null, null, null, null, "Encounter", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerBillingAccount
		{
			get
			{
				IEntityRelation intermediateRelation = BillingAccountEntity.Relations.CustomerBillingAccountEntityUsingBillingAccountId;
				intermediateRelation.SetAliases(string.Empty, "CustomerBillingAccount_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.BillingAccountEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerBillingAccount"), null, "CustomerProfileCollectionViaCustomerBillingAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaBillingAccountTest
		{
			get
			{
				IEntityRelation intermediateRelation = BillingAccountEntity.Relations.BillingAccountTestEntityUsingBillingAccountId;
				intermediateRelation.SetAliases(string.Empty, "BillingAccountTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.BillingAccountEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaBillingAccountTest"), null, "TestCollectionViaBillingAccountTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return BillingAccountEntity.CustomProperties;}
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
			get { return BillingAccountEntity.FieldsCustomProperties;}
		}

		/// <summary> The BillingAccountId property of the Entity BillingAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblBillingAccount"."BillingAccountId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 BillingAccountId
		{
			get { return (System.Int64)GetValue((int)BillingAccountFieldIndex.BillingAccountId, true); }
			set	{ SetValue((int)BillingAccountFieldIndex.BillingAccountId, value); }
		}

		/// <summary> The Name property of the Entity BillingAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblBillingAccount"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)BillingAccountFieldIndex.Name, true); }
			set	{ SetValue((int)BillingAccountFieldIndex.Name, value); }
		}

		/// <summary> The CustomerKey property of the Entity BillingAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblBillingAccount"."CustomerKey"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CustomerKey
		{
			get { return (System.String)GetValue((int)BillingAccountFieldIndex.CustomerKey, true); }
			set	{ SetValue((int)BillingAccountFieldIndex.CustomerKey, value); }
		}

		/// <summary> The UserName property of the Entity BillingAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblBillingAccount"."UserName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String UserName
		{
			get { return (System.String)GetValue((int)BillingAccountFieldIndex.UserName, true); }
			set	{ SetValue((int)BillingAccountFieldIndex.UserName, value); }
		}

		/// <summary> The Password property of the Entity BillingAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblBillingAccount"."Password"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Password
		{
			get { return (System.String)GetValue((int)BillingAccountFieldIndex.Password, true); }
			set	{ SetValue((int)BillingAccountFieldIndex.Password, value); }
		}

		/// <summary> The IsActive property of the Entity BillingAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblBillingAccount"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)BillingAccountFieldIndex.IsActive, true); }
			set	{ SetValue((int)BillingAccountFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BillingAccountTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BillingAccountTestEntity))]
		public virtual EntityCollection<BillingAccountTestEntity> BillingAccountTest
		{
			get
			{
				if(_billingAccountTest==null)
				{
					_billingAccountTest = new EntityCollection<BillingAccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountTestEntityFactory)));
					_billingAccountTest.SetContainingEntityInfo(this, "BillingAccount");
				}
				return _billingAccountTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerBillingAccountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerBillingAccountEntity))]
		public virtual EntityCollection<CustomerBillingAccountEntity> CustomerBillingAccount
		{
			get
			{
				if(_customerBillingAccount==null)
				{
					_customerBillingAccount = new EntityCollection<CustomerBillingAccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerBillingAccountEntityFactory)));
					_customerBillingAccount.SetContainingEntityInfo(this, "BillingAccount");
				}
				return _customerBillingAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EncounterEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EncounterEntity))]
		public virtual EntityCollection<EncounterEntity> Encounter
		{
			get
			{
				if(_encounter==null)
				{
					_encounter = new EntityCollection<EncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory)));
					_encounter.SetContainingEntityInfo(this, "BillingAccount");
				}
				return _encounter;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerBillingAccount
		{
			get
			{
				if(_customerProfileCollectionViaCustomerBillingAccount==null)
				{
					_customerProfileCollectionViaCustomerBillingAccount = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerBillingAccount.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerBillingAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaBillingAccountTest
		{
			get
			{
				if(_testCollectionViaBillingAccountTest==null)
				{
					_testCollectionViaBillingAccountTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaBillingAccountTest.IsReadOnly=true;
				}
				return _testCollectionViaBillingAccountTest;
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
			get { return (int)Falcon.Data.EntityType.BillingAccountEntity; }
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
