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
	/// Entity class which represents the entity 'InsurancePayment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class InsurancePaymentEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ClaimEntity> _claim;
		private EntityCollection<EncounterEntity> _encounterCollectionViaClaim;
		private PaymentEntity _payment;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Payment</summary>
			public static readonly string Payment = "Payment";
			/// <summary>Member name Claim</summary>
			public static readonly string Claim = "Claim";
			/// <summary>Member name EncounterCollectionViaClaim</summary>
			public static readonly string EncounterCollectionViaClaim = "EncounterCollectionViaClaim";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static InsurancePaymentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public InsurancePaymentEntity():base("InsurancePaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public InsurancePaymentEntity(IEntityFields2 fields):base("InsurancePaymentEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this InsurancePaymentEntity</param>
		public InsurancePaymentEntity(IValidator validator):base("InsurancePaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="insurancePaymentId">PK value for InsurancePayment which data should be fetched into this InsurancePayment object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InsurancePaymentEntity(System.Int64 insurancePaymentId):base("InsurancePaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.InsurancePaymentId = insurancePaymentId;
		}

		/// <summary> CTor</summary>
		/// <param name="insurancePaymentId">PK value for InsurancePayment which data should be fetched into this InsurancePayment object</param>
		/// <param name="validator">The custom validator object for this InsurancePaymentEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InsurancePaymentEntity(System.Int64 insurancePaymentId, IValidator validator):base("InsurancePaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.InsurancePaymentId = insurancePaymentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected InsurancePaymentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_claim = (EntityCollection<ClaimEntity>)info.GetValue("_claim", typeof(EntityCollection<ClaimEntity>));
				_encounterCollectionViaClaim = (EntityCollection<EncounterEntity>)info.GetValue("_encounterCollectionViaClaim", typeof(EntityCollection<EncounterEntity>));
				_payment = (PaymentEntity)info.GetValue("_payment", typeof(PaymentEntity));
				if(_payment!=null)
				{
					_payment.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((InsurancePaymentFieldIndex)fieldIndex)
			{
				case InsurancePaymentFieldIndex.PaymentId:
					DesetupSyncPayment(true, false);
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
				case "Payment":
					this.Payment = (PaymentEntity)entity;
					break;
				case "Claim":
					this.Claim.Add((ClaimEntity)entity);
					break;
				case "EncounterCollectionViaClaim":
					this.EncounterCollectionViaClaim.IsReadOnly = false;
					this.EncounterCollectionViaClaim.Add((EncounterEntity)entity);
					this.EncounterCollectionViaClaim.IsReadOnly = true;
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
			return InsurancePaymentEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Payment":
					toReturn.Add(InsurancePaymentEntity.Relations.PaymentEntityUsingPaymentId);
					break;
				case "Claim":
					toReturn.Add(InsurancePaymentEntity.Relations.ClaimEntityUsingInsurancePaymentId);
					break;
				case "EncounterCollectionViaClaim":
					toReturn.Add(InsurancePaymentEntity.Relations.ClaimEntityUsingInsurancePaymentId, "InsurancePaymentEntity__", "Claim_", JoinHint.None);
					toReturn.Add(ClaimEntity.Relations.EncounterEntityUsingEncounterId, "Claim_", string.Empty, JoinHint.None);
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
				case "Payment":
					SetupSyncPayment(relatedEntity);
					break;
				case "Claim":
					this.Claim.Add((ClaimEntity)relatedEntity);
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
				case "Payment":
					DesetupSyncPayment(false, true);
					break;
				case "Claim":
					base.PerformRelatedEntityRemoval(this.Claim, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_payment!=null)
			{
				toReturn.Add(_payment);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Claim);

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
				info.AddValue("_claim", ((_claim!=null) && (_claim.Count>0) && !this.MarkedForDeletion)?_claim:null);
				info.AddValue("_encounterCollectionViaClaim", ((_encounterCollectionViaClaim!=null) && (_encounterCollectionViaClaim.Count>0) && !this.MarkedForDeletion)?_encounterCollectionViaClaim:null);
				info.AddValue("_payment", (!this.MarkedForDeletion?_payment:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(InsurancePaymentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(InsurancePaymentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new InsurancePaymentRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Claim' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClaim()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClaimFields.InsurancePaymentId, null, ComparisonOperator.Equal, this.InsurancePaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Encounter' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEncounterCollectionViaClaim()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EncounterCollectionViaClaim"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InsurancePaymentFields.InsurancePaymentId, null, ComparisonOperator.Equal, this.InsurancePaymentId, "InsurancePaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Payment' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.InsurancePaymentEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(InsurancePaymentEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._claim);
			collectionsQueue.Enqueue(this._encounterCollectionViaClaim);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._claim = (EntityCollection<ClaimEntity>) collectionsQueue.Dequeue();
			this._encounterCollectionViaClaim = (EntityCollection<EncounterEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._claim != null)
			{
				return true;
			}
			if (this._encounterCollectionViaClaim != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClaimEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClaimEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Payment", _payment);
			toReturn.Add("Claim", _claim);
			toReturn.Add("EncounterCollectionViaClaim", _encounterCollectionViaClaim);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_claim!=null)
			{
				_claim.ActiveContext = base.ActiveContext;
			}
			if(_encounterCollectionViaClaim!=null)
			{
				_encounterCollectionViaClaim.ActiveContext = base.ActiveContext;
			}
			if(_payment!=null)
			{
				_payment.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_claim = null;
			_encounterCollectionViaClaim = null;
			_payment = null;

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

			_fieldsCustomProperties.Add("InsurancePaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AmountToBePaid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Amount", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _payment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPayment(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _payment, new PropertyChangedEventHandler( OnPaymentPropertyChanged ), "Payment", InsurancePaymentEntity.Relations.PaymentEntityUsingPaymentId, true, signalRelatedEntity, "InsurancePayment", resetFKFields, new int[] { (int)InsurancePaymentFieldIndex.PaymentId } );		
			_payment = null;
		}

		/// <summary> setups the sync logic for member _payment</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPayment(IEntity2 relatedEntity)
		{
			if(_payment!=relatedEntity)
			{
				DesetupSyncPayment(true, true);
				_payment = (PaymentEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _payment, new PropertyChangedEventHandler( OnPaymentPropertyChanged ), "Payment", InsurancePaymentEntity.Relations.PaymentEntityUsingPaymentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPaymentPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this InsurancePaymentEntity</param>
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
		public  static InsurancePaymentRelations Relations
		{
			get	{ return new InsurancePaymentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Claim' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClaim
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClaimEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClaimEntityFactory))),
					(IEntityRelation)GetRelationsForField("Claim")[0], (int)Falcon.Data.EntityType.InsurancePaymentEntity, (int)Falcon.Data.EntityType.ClaimEntity, 0, null, null, null, null, "Claim", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Encounter' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEncounterCollectionViaClaim
		{
			get
			{
				IEntityRelation intermediateRelation = InsurancePaymentEntity.Relations.ClaimEntityUsingInsurancePaymentId;
				intermediateRelation.SetAliases(string.Empty, "Claim_");
				return new PrefetchPathElement2(new EntityCollection<EncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.InsurancePaymentEntity, (int)Falcon.Data.EntityType.EncounterEntity, 0, null, null, GetRelationsForField("EncounterCollectionViaClaim"), null, "EncounterCollectionViaClaim", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Payment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPayment
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("Payment")[0], (int)Falcon.Data.EntityType.InsurancePaymentEntity, (int)Falcon.Data.EntityType.PaymentEntity, 0, null, null, null, null, "Payment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return InsurancePaymentEntity.CustomProperties;}
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
			get { return InsurancePaymentEntity.FieldsCustomProperties;}
		}

		/// <summary> The InsurancePaymentId property of the Entity InsurancePayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblInsurancePayment"."InsurancePaymentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 InsurancePaymentId
		{
			get { return (System.Int64)GetValue((int)InsurancePaymentFieldIndex.InsurancePaymentId, true); }
			set	{ SetValue((int)InsurancePaymentFieldIndex.InsurancePaymentId, value); }
		}

		/// <summary> The PaymentId property of the Entity InsurancePayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblInsurancePayment"."PaymentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PaymentId
		{
			get { return (System.Int64)GetValue((int)InsurancePaymentFieldIndex.PaymentId, true); }
			set	{ SetValue((int)InsurancePaymentFieldIndex.PaymentId, value); }
		}

		/// <summary> The AmountToBePaid property of the Entity InsurancePayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblInsurancePayment"."AmountToBePaid"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal AmountToBePaid
		{
			get { return (System.Decimal)GetValue((int)InsurancePaymentFieldIndex.AmountToBePaid, true); }
			set	{ SetValue((int)InsurancePaymentFieldIndex.AmountToBePaid, value); }
		}

		/// <summary> The Amount property of the Entity InsurancePayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblInsurancePayment"."Amount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Amount
		{
			get { return (System.Decimal)GetValue((int)InsurancePaymentFieldIndex.Amount, true); }
			set	{ SetValue((int)InsurancePaymentFieldIndex.Amount, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClaimEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClaimEntity))]
		public virtual EntityCollection<ClaimEntity> Claim
		{
			get
			{
				if(_claim==null)
				{
					_claim = new EntityCollection<ClaimEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClaimEntityFactory)));
					_claim.SetContainingEntityInfo(this, "InsurancePayment");
				}
				return _claim;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EncounterEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EncounterEntity))]
		public virtual EntityCollection<EncounterEntity> EncounterCollectionViaClaim
		{
			get
			{
				if(_encounterCollectionViaClaim==null)
				{
					_encounterCollectionViaClaim = new EntityCollection<EncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory)));
					_encounterCollectionViaClaim.IsReadOnly=true;
				}
				return _encounterCollectionViaClaim;
			}
		}

		/// <summary> Gets / sets related entity of type 'PaymentEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PaymentEntity Payment
		{
			get
			{
				return _payment;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPayment(value);
				}
				else
				{
					if(value==null)
					{
						if(_payment != null)
						{
							_payment.UnsetRelatedEntity(this, "InsurancePayment");
						}
					}
					else
					{
						if(_payment!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "InsurancePayment");
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
			get { return (int)Falcon.Data.EntityType.InsurancePaymentEntity; }
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
