///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:27 AM
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
using HealthYes.Data;
using HealthYes.Data.HelperClasses;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'CarotidArteryTestFindings'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CarotidArteryTestFindingsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CarotidArteryTestResultsEntity> _carotidArteryTestResults_;
		private EntityCollection<CarotidArteryTestResultsEntity> _carotidArteryTestResults;
		private EntityCollection<CustomerEventTestsEntity> _customerEventTestsCollectionViaCarotidArteryTestResults_;
		private EntityCollection<CustomerEventTestsEntity> _customerEventTestsCollectionViaCarotidArteryTestResults;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name CarotidArteryTestResults_</summary>
			public static readonly string CarotidArteryTestResults_ = "CarotidArteryTestResults_";
			/// <summary>Member name CarotidArteryTestResults</summary>
			public static readonly string CarotidArteryTestResults = "CarotidArteryTestResults";
			/// <summary>Member name CustomerEventTestsCollectionViaCarotidArteryTestResults_</summary>
			public static readonly string CustomerEventTestsCollectionViaCarotidArteryTestResults_ = "CustomerEventTestsCollectionViaCarotidArteryTestResults_";
			/// <summary>Member name CustomerEventTestsCollectionViaCarotidArteryTestResults</summary>
			public static readonly string CustomerEventTestsCollectionViaCarotidArteryTestResults = "CustomerEventTestsCollectionViaCarotidArteryTestResults";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CarotidArteryTestFindingsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CarotidArteryTestFindingsEntity():base("CarotidArteryTestFindingsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CarotidArteryTestFindingsEntity(IEntityFields2 fields):base("CarotidArteryTestFindingsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CarotidArteryTestFindingsEntity</param>
		public CarotidArteryTestFindingsEntity(IValidator validator):base("CarotidArteryTestFindingsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="carotidArteryTestFindingsId">PK value for CarotidArteryTestFindings which data should be fetched into this CarotidArteryTestFindings object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CarotidArteryTestFindingsEntity(System.Int32 carotidArteryTestFindingsId):base("CarotidArteryTestFindingsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CarotidArteryTestFindingsId = carotidArteryTestFindingsId;
		}

		/// <summary> CTor</summary>
		/// <param name="carotidArteryTestFindingsId">PK value for CarotidArteryTestFindings which data should be fetched into this CarotidArteryTestFindings object</param>
		/// <param name="validator">The custom validator object for this CarotidArteryTestFindingsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CarotidArteryTestFindingsEntity(System.Int32 carotidArteryTestFindingsId, IValidator validator):base("CarotidArteryTestFindingsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CarotidArteryTestFindingsId = carotidArteryTestFindingsId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CarotidArteryTestFindingsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_carotidArteryTestResults_ = (EntityCollection<CarotidArteryTestResultsEntity>)info.GetValue("_carotidArteryTestResults_", typeof(EntityCollection<CarotidArteryTestResultsEntity>));
				_carotidArteryTestResults = (EntityCollection<CarotidArteryTestResultsEntity>)info.GetValue("_carotidArteryTestResults", typeof(EntityCollection<CarotidArteryTestResultsEntity>));
				_customerEventTestsCollectionViaCarotidArteryTestResults_ = (EntityCollection<CustomerEventTestsEntity>)info.GetValue("_customerEventTestsCollectionViaCarotidArteryTestResults_", typeof(EntityCollection<CustomerEventTestsEntity>));
				_customerEventTestsCollectionViaCarotidArteryTestResults = (EntityCollection<CustomerEventTestsEntity>)info.GetValue("_customerEventTestsCollectionViaCarotidArteryTestResults", typeof(EntityCollection<CustomerEventTestsEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CarotidArteryTestFindingsFieldIndex)fieldIndex)
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

				case "CarotidArteryTestResults_":
					this.CarotidArteryTestResults_.Add((CarotidArteryTestResultsEntity)entity);
					break;
				case "CarotidArteryTestResults":
					this.CarotidArteryTestResults.Add((CarotidArteryTestResultsEntity)entity);
					break;
				case "CustomerEventTestsCollectionViaCarotidArteryTestResults_":
					this.CustomerEventTestsCollectionViaCarotidArteryTestResults_.IsReadOnly = false;
					this.CustomerEventTestsCollectionViaCarotidArteryTestResults_.Add((CustomerEventTestsEntity)entity);
					this.CustomerEventTestsCollectionViaCarotidArteryTestResults_.IsReadOnly = true;
					break;
				case "CustomerEventTestsCollectionViaCarotidArteryTestResults":
					this.CustomerEventTestsCollectionViaCarotidArteryTestResults.IsReadOnly = false;
					this.CustomerEventTestsCollectionViaCarotidArteryTestResults.Add((CustomerEventTestsEntity)entity);
					this.CustomerEventTestsCollectionViaCarotidArteryTestResults.IsReadOnly = true;
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
			return CarotidArteryTestFindingsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "CarotidArteryTestResults_":
					toReturn.Add(CarotidArteryTestFindingsEntity.Relations.CarotidArteryTestResultsEntityUsingRcarotidArteryTestFindingsId);
					break;
				case "CarotidArteryTestResults":
					toReturn.Add(CarotidArteryTestFindingsEntity.Relations.CarotidArteryTestResultsEntityUsingLcarotidArteryTestFindingsId);
					break;
				case "CustomerEventTestsCollectionViaCarotidArteryTestResults_":
					toReturn.Add(CarotidArteryTestFindingsEntity.Relations.CarotidArteryTestResultsEntityUsingRcarotidArteryTestFindingsId, "CarotidArteryTestFindingsEntity__", "CarotidArteryTestResults_", JoinHint.None);
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, "CarotidArteryTestResults_", string.Empty, JoinHint.None);
					break;
				case "CustomerEventTestsCollectionViaCarotidArteryTestResults":
					toReturn.Add(CarotidArteryTestFindingsEntity.Relations.CarotidArteryTestResultsEntityUsingLcarotidArteryTestFindingsId, "CarotidArteryTestFindingsEntity__", "CarotidArteryTestResults_", JoinHint.None);
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, "CarotidArteryTestResults_", string.Empty, JoinHint.None);
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

				case "CarotidArteryTestResults_":
					this.CarotidArteryTestResults_.Add((CarotidArteryTestResultsEntity)relatedEntity);
					break;
				case "CarotidArteryTestResults":
					this.CarotidArteryTestResults.Add((CarotidArteryTestResultsEntity)relatedEntity);
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

				case "CarotidArteryTestResults_":
					base.PerformRelatedEntityRemoval(this.CarotidArteryTestResults_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CarotidArteryTestResults":
					base.PerformRelatedEntityRemoval(this.CarotidArteryTestResults, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CarotidArteryTestResults_);
			toReturn.Add(this.CarotidArteryTestResults);

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
				info.AddValue("_carotidArteryTestResults_", ((_carotidArteryTestResults_!=null) && (_carotidArteryTestResults_.Count>0) && !this.MarkedForDeletion)?_carotidArteryTestResults_:null);
				info.AddValue("_carotidArteryTestResults", ((_carotidArteryTestResults!=null) && (_carotidArteryTestResults.Count>0) && !this.MarkedForDeletion)?_carotidArteryTestResults:null);
				info.AddValue("_customerEventTestsCollectionViaCarotidArteryTestResults_", ((_customerEventTestsCollectionViaCarotidArteryTestResults_!=null) && (_customerEventTestsCollectionViaCarotidArteryTestResults_.Count>0) && !this.MarkedForDeletion)?_customerEventTestsCollectionViaCarotidArteryTestResults_:null);
				info.AddValue("_customerEventTestsCollectionViaCarotidArteryTestResults", ((_customerEventTestsCollectionViaCarotidArteryTestResults!=null) && (_customerEventTestsCollectionViaCarotidArteryTestResults.Count>0) && !this.MarkedForDeletion)?_customerEventTestsCollectionViaCarotidArteryTestResults:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CarotidArteryTestFindingsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CarotidArteryTestFindingsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CarotidArteryTestFindingsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CarotidArteryTestResults' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCarotidArteryTestResults_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestResultsFields.RcarotidArteryTestFindingsId, null, ComparisonOperator.Equal, this.CarotidArteryTestFindingsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CarotidArteryTestResults' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCarotidArteryTestResults()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestResultsFields.LcarotidArteryTestFindingsId, null, ComparisonOperator.Equal, this.CarotidArteryTestFindingsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestsCollectionViaCarotidArteryTestResults_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventTestsCollectionViaCarotidArteryTestResults_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestFindingsFields.CarotidArteryTestFindingsId, null, ComparisonOperator.Equal, this.CarotidArteryTestFindingsId, "CarotidArteryTestFindingsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestsCollectionViaCarotidArteryTestResults()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventTestsCollectionViaCarotidArteryTestResults"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestFindingsFields.CarotidArteryTestFindingsId, null, ComparisonOperator.Equal, this.CarotidArteryTestFindingsId, "CarotidArteryTestFindingsEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.CarotidArteryTestFindingsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestFindingsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._carotidArteryTestResults_);
			collectionsQueue.Enqueue(this._carotidArteryTestResults);
			collectionsQueue.Enqueue(this._customerEventTestsCollectionViaCarotidArteryTestResults_);
			collectionsQueue.Enqueue(this._customerEventTestsCollectionViaCarotidArteryTestResults);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._carotidArteryTestResults_ = (EntityCollection<CarotidArteryTestResultsEntity>) collectionsQueue.Dequeue();
			this._carotidArteryTestResults = (EntityCollection<CarotidArteryTestResultsEntity>) collectionsQueue.Dequeue();
			this._customerEventTestsCollectionViaCarotidArteryTestResults_ = (EntityCollection<CustomerEventTestsEntity>) collectionsQueue.Dequeue();
			this._customerEventTestsCollectionViaCarotidArteryTestResults = (EntityCollection<CustomerEventTestsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._carotidArteryTestResults_ != null)
			{
				return true;
			}
			if (this._carotidArteryTestResults != null)
			{
				return true;
			}
			if (this._customerEventTestsCollectionViaCarotidArteryTestResults_ != null)
			{
				return true;
			}
			if (this._customerEventTestsCollectionViaCarotidArteryTestResults != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CarotidArteryTestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestResultsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CarotidArteryTestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestResultsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("CarotidArteryTestResults_", _carotidArteryTestResults_);
			toReturn.Add("CarotidArteryTestResults", _carotidArteryTestResults);
			toReturn.Add("CustomerEventTestsCollectionViaCarotidArteryTestResults_", _customerEventTestsCollectionViaCarotidArteryTestResults_);
			toReturn.Add("CustomerEventTestsCollectionViaCarotidArteryTestResults", _customerEventTestsCollectionViaCarotidArteryTestResults);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_carotidArteryTestResults_!=null)
			{
				_carotidArteryTestResults_.ActiveContext = base.ActiveContext;
			}
			if(_carotidArteryTestResults!=null)
			{
				_carotidArteryTestResults.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestsCollectionViaCarotidArteryTestResults_!=null)
			{
				_customerEventTestsCollectionViaCarotidArteryTestResults_.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestsCollectionViaCarotidArteryTestResults!=null)
			{
				_customerEventTestsCollectionViaCarotidArteryTestResults.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_carotidArteryTestResults_ = null;
			_carotidArteryTestResults = null;
			_customerEventTestsCollectionViaCarotidArteryTestResults_ = null;
			_customerEventTestsCollectionViaCarotidArteryTestResults = null;


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

			_fieldsCustomProperties.Add("CarotidArteryTestFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Label", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CarotidArteryTestFindingsEntity</param>
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
		public  static CarotidArteryTestFindingsRelations Relations
		{
			get	{ return new CarotidArteryTestFindingsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CarotidArteryTestResults' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCarotidArteryTestResults_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CarotidArteryTestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestResultsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CarotidArteryTestResults_")[0], (int)HealthYes.Data.EntityType.CarotidArteryTestFindingsEntity, (int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, 0, null, null, null, null, "CarotidArteryTestResults_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CarotidArteryTestResults' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCarotidArteryTestResults
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CarotidArteryTestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestResultsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CarotidArteryTestResults")[0], (int)HealthYes.Data.EntityType.CarotidArteryTestFindingsEntity, (int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, 0, null, null, null, null, "CarotidArteryTestResults", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestsCollectionViaCarotidArteryTestResults_
		{
			get
			{
				IEntityRelation intermediateRelation = CarotidArteryTestFindingsEntity.Relations.CarotidArteryTestResultsEntityUsingRcarotidArteryTestFindingsId;
				intermediateRelation.SetAliases(string.Empty, "CarotidArteryTestResults_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.CarotidArteryTestFindingsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, GetRelationsForField("CustomerEventTestsCollectionViaCarotidArteryTestResults_"), null, "CustomerEventTestsCollectionViaCarotidArteryTestResults_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestsCollectionViaCarotidArteryTestResults
		{
			get
			{
				IEntityRelation intermediateRelation = CarotidArteryTestFindingsEntity.Relations.CarotidArteryTestResultsEntityUsingLcarotidArteryTestFindingsId;
				intermediateRelation.SetAliases(string.Empty, "CarotidArteryTestResults_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.CarotidArteryTestFindingsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, GetRelationsForField("CustomerEventTestsCollectionViaCarotidArteryTestResults"), null, "CustomerEventTestsCollectionViaCarotidArteryTestResults", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CarotidArteryTestFindingsEntity.CustomProperties;}
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
			get { return CarotidArteryTestFindingsEntity.FieldsCustomProperties;}
		}

		/// <summary> The CarotidArteryTestFindingsId property of the Entity CarotidArteryTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestFindings_Legacy"."CarotidArteryTestFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 CarotidArteryTestFindingsId
		{
			get { return (System.Int32)GetValue((int)CarotidArteryTestFindingsFieldIndex.CarotidArteryTestFindingsId, true); }
			set	{ SetValue((int)CarotidArteryTestFindingsFieldIndex.CarotidArteryTestFindingsId, value); }
		}

		/// <summary> The Label property of the Entity CarotidArteryTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestFindings_Legacy"."Label"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Label
		{
			get { return (System.String)GetValue((int)CarotidArteryTestFindingsFieldIndex.Label, true); }
			set	{ SetValue((int)CarotidArteryTestFindingsFieldIndex.Label, value); }
		}

		/// <summary> The Description property of the Entity CarotidArteryTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestFindings_Legacy"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CarotidArteryTestFindingsFieldIndex.Description, true); }
			set	{ SetValue((int)CarotidArteryTestFindingsFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity CarotidArteryTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestFindings_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CarotidArteryTestFindingsFieldIndex.DateCreated, false); }
			set	{ SetValue((int)CarotidArteryTestFindingsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity CarotidArteryTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestFindings_Legacy"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CarotidArteryTestFindingsFieldIndex.DateModified, false); }
			set	{ SetValue((int)CarotidArteryTestFindingsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity CarotidArteryTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestFindings_Legacy"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsActive
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CarotidArteryTestFindingsFieldIndex.IsActive, false); }
			set	{ SetValue((int)CarotidArteryTestFindingsFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CarotidArteryTestResultsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CarotidArteryTestResultsEntity))]
		public virtual EntityCollection<CarotidArteryTestResultsEntity> CarotidArteryTestResults_
		{
			get
			{
				if(_carotidArteryTestResults_==null)
				{
					_carotidArteryTestResults_ = new EntityCollection<CarotidArteryTestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestResultsEntityFactory)));
					_carotidArteryTestResults_.SetContainingEntityInfo(this, "CarotidArteryTestFindings_");
				}
				return _carotidArteryTestResults_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CarotidArteryTestResultsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CarotidArteryTestResultsEntity))]
		public virtual EntityCollection<CarotidArteryTestResultsEntity> CarotidArteryTestResults
		{
			get
			{
				if(_carotidArteryTestResults==null)
				{
					_carotidArteryTestResults = new EntityCollection<CarotidArteryTestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestResultsEntityFactory)));
					_carotidArteryTestResults.SetContainingEntityInfo(this, "CarotidArteryTestFindings");
				}
				return _carotidArteryTestResults;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestsEntity))]
		public virtual EntityCollection<CustomerEventTestsEntity> CustomerEventTestsCollectionViaCarotidArteryTestResults_
		{
			get
			{
				if(_customerEventTestsCollectionViaCarotidArteryTestResults_==null)
				{
					_customerEventTestsCollectionViaCarotidArteryTestResults_ = new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory)));
					_customerEventTestsCollectionViaCarotidArteryTestResults_.IsReadOnly=true;
				}
				return _customerEventTestsCollectionViaCarotidArteryTestResults_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestsEntity))]
		public virtual EntityCollection<CustomerEventTestsEntity> CustomerEventTestsCollectionViaCarotidArteryTestResults
		{
			get
			{
				if(_customerEventTestsCollectionViaCarotidArteryTestResults==null)
				{
					_customerEventTestsCollectionViaCarotidArteryTestResults = new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory)));
					_customerEventTestsCollectionViaCarotidArteryTestResults.IsReadOnly=true;
				}
				return _customerEventTestsCollectionViaCarotidArteryTestResults;
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
		
		/// <summary>Returns the HealthYes.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)HealthYes.Data.EntityType.CarotidArteryTestFindingsEntity; }
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
