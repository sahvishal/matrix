///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:33 AM
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
	/// Entity class which represents the entity 'OsteoporosisTestResults'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OsteoporosisTestResultsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AsitestRecommendationEntity> _asitestRecommendation;
		private EntityCollection<OsteoporosisTestIncidentalFindingsEntity> _osteoporosisTestIncidentalFindings;
		private EntityCollection<IncidentalFindingsEntity> _incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings;
		private AsitestFindingsEntity _asitestFindings;
		private CustomerEventTestsEntity _customerEventTests;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AsitestFindings</summary>
			public static readonly string AsitestFindings = "AsitestFindings";
			/// <summary>Member name CustomerEventTests</summary>
			public static readonly string CustomerEventTests = "CustomerEventTests";
			/// <summary>Member name AsitestRecommendation</summary>
			public static readonly string AsitestRecommendation = "AsitestRecommendation";
			/// <summary>Member name OsteoporosisTestIncidentalFindings</summary>
			public static readonly string OsteoporosisTestIncidentalFindings = "OsteoporosisTestIncidentalFindings";
			/// <summary>Member name IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings</summary>
			public static readonly string IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings = "IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OsteoporosisTestResultsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public OsteoporosisTestResultsEntity():base("OsteoporosisTestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OsteoporosisTestResultsEntity(IEntityFields2 fields):base("OsteoporosisTestResultsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OsteoporosisTestResultsEntity</param>
		public OsteoporosisTestResultsEntity(IValidator validator):base("OsteoporosisTestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="osteoporosisTestId">PK value for OsteoporosisTestResults which data should be fetched into this OsteoporosisTestResults object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OsteoporosisTestResultsEntity(System.Int64 osteoporosisTestId):base("OsteoporosisTestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OsteoporosisTestId = osteoporosisTestId;
		}

		/// <summary> CTor</summary>
		/// <param name="osteoporosisTestId">PK value for OsteoporosisTestResults which data should be fetched into this OsteoporosisTestResults object</param>
		/// <param name="validator">The custom validator object for this OsteoporosisTestResultsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OsteoporosisTestResultsEntity(System.Int64 osteoporosisTestId, IValidator validator):base("OsteoporosisTestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OsteoporosisTestId = osteoporosisTestId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected OsteoporosisTestResultsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_asitestRecommendation = (EntityCollection<AsitestRecommendationEntity>)info.GetValue("_asitestRecommendation", typeof(EntityCollection<AsitestRecommendationEntity>));
				_osteoporosisTestIncidentalFindings = (EntityCollection<OsteoporosisTestIncidentalFindingsEntity>)info.GetValue("_osteoporosisTestIncidentalFindings", typeof(EntityCollection<OsteoporosisTestIncidentalFindingsEntity>));
				_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>)info.GetValue("_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings", typeof(EntityCollection<IncidentalFindingsEntity>));
				_asitestFindings = (AsitestFindingsEntity)info.GetValue("_asitestFindings", typeof(AsitestFindingsEntity));
				if(_asitestFindings!=null)
				{
					_asitestFindings.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerEventTests = (CustomerEventTestsEntity)info.GetValue("_customerEventTests", typeof(CustomerEventTestsEntity));
				if(_customerEventTests!=null)
				{
					_customerEventTests.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((OsteoporosisTestResultsFieldIndex)fieldIndex)
			{
				case OsteoporosisTestResultsFieldIndex.CustomerEventTestId:
					DesetupSyncCustomerEventTests(true, false);
					break;
				case OsteoporosisTestResultsFieldIndex.OsteoporosisTestFindingsId:
					DesetupSyncAsitestFindings(true, false);
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
				case "AsitestFindings":
					this.AsitestFindings = (AsitestFindingsEntity)entity;
					break;
				case "CustomerEventTests":
					this.CustomerEventTests = (CustomerEventTestsEntity)entity;
					break;
				case "AsitestRecommendation":
					this.AsitestRecommendation.Add((AsitestRecommendationEntity)entity);
					break;
				case "OsteoporosisTestIncidentalFindings":
					this.OsteoporosisTestIncidentalFindings.Add((OsteoporosisTestIncidentalFindingsEntity)entity);
					break;
				case "IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings":
					this.IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings.IsReadOnly = false;
					this.IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings.Add((IncidentalFindingsEntity)entity);
					this.IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings.IsReadOnly = true;
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
			return OsteoporosisTestResultsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AsitestFindings":
					toReturn.Add(OsteoporosisTestResultsEntity.Relations.AsitestFindingsEntityUsingOsteoporosisTestFindingsId);
					break;
				case "CustomerEventTests":
					toReturn.Add(OsteoporosisTestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId);
					break;
				case "AsitestRecommendation":
					toReturn.Add(OsteoporosisTestResultsEntity.Relations.AsitestRecommendationEntityUsingAsitestId);
					break;
				case "OsteoporosisTestIncidentalFindings":
					toReturn.Add(OsteoporosisTestResultsEntity.Relations.OsteoporosisTestIncidentalFindingsEntityUsingOsteoporosisTestId);
					break;
				case "IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings":
					toReturn.Add(OsteoporosisTestResultsEntity.Relations.OsteoporosisTestIncidentalFindingsEntityUsingOsteoporosisTestId, "OsteoporosisTestResultsEntity__", "OsteoporosisTestIncidentalFindings_", JoinHint.None);
					toReturn.Add(OsteoporosisTestIncidentalFindingsEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingsId, "OsteoporosisTestIncidentalFindings_", string.Empty, JoinHint.None);
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
				case "AsitestFindings":
					SetupSyncAsitestFindings(relatedEntity);
					break;
				case "CustomerEventTests":
					SetupSyncCustomerEventTests(relatedEntity);
					break;
				case "AsitestRecommendation":
					this.AsitestRecommendation.Add((AsitestRecommendationEntity)relatedEntity);
					break;
				case "OsteoporosisTestIncidentalFindings":
					this.OsteoporosisTestIncidentalFindings.Add((OsteoporosisTestIncidentalFindingsEntity)relatedEntity);
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
				case "AsitestFindings":
					DesetupSyncAsitestFindings(false, true);
					break;
				case "CustomerEventTests":
					DesetupSyncCustomerEventTests(false, true);
					break;
				case "AsitestRecommendation":
					base.PerformRelatedEntityRemoval(this.AsitestRecommendation, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "OsteoporosisTestIncidentalFindings":
					base.PerformRelatedEntityRemoval(this.OsteoporosisTestIncidentalFindings, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_asitestFindings!=null)
			{
				toReturn.Add(_asitestFindings);
			}
			if(_customerEventTests!=null)
			{
				toReturn.Add(_customerEventTests);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AsitestRecommendation);
			toReturn.Add(this.OsteoporosisTestIncidentalFindings);

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
				info.AddValue("_asitestRecommendation", ((_asitestRecommendation!=null) && (_asitestRecommendation.Count>0) && !this.MarkedForDeletion)?_asitestRecommendation:null);
				info.AddValue("_osteoporosisTestIncidentalFindings", ((_osteoporosisTestIncidentalFindings!=null) && (_osteoporosisTestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_osteoporosisTestIncidentalFindings:null);
				info.AddValue("_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings", ((_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings!=null) && (_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings:null);
				info.AddValue("_asitestFindings", (!this.MarkedForDeletion?_asitestFindings:null));
				info.AddValue("_customerEventTests", (!this.MarkedForDeletion?_customerEventTests:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OsteoporosisTestResultsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OsteoporosisTestResultsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OsteoporosisTestResultsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AsitestRecommendation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAsitestRecommendation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AsitestRecommendationFields.AsitestId, null, ComparisonOperator.Equal, this.OsteoporosisTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OsteoporosisTestIncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOsteoporosisTestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OsteoporosisTestIncidentalFindingsFields.OsteoporosisTestId, null, ComparisonOperator.Equal, this.OsteoporosisTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OsteoporosisTestResultsFields.OsteoporosisTestId, null, ComparisonOperator.Equal, this.OsteoporosisTestId, "OsteoporosisTestResultsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AsitestFindings' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAsitestFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AsitestFindingsFields.AsitestFindingsId, null, ComparisonOperator.Equal, this.OsteoporosisTestFindingsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerEventTests' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTests()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestsFields.CustomerEventTestId, null, ComparisonOperator.Equal, this.CustomerEventTestId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.OsteoporosisTestResultsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestResultsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._asitestRecommendation);
			collectionsQueue.Enqueue(this._osteoporosisTestIncidentalFindings);
			collectionsQueue.Enqueue(this._incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._asitestRecommendation = (EntityCollection<AsitestRecommendationEntity>) collectionsQueue.Dequeue();
			this._osteoporosisTestIncidentalFindings = (EntityCollection<OsteoporosisTestIncidentalFindingsEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._asitestRecommendation != null)
			{
				return true;
			}
			if (this._osteoporosisTestIncidentalFindings != null)
			{
				return true;
			}
			if (this._incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AsitestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsitestRecommendationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OsteoporosisTestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestIncidentalFindingsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AsitestFindings", _asitestFindings);
			toReturn.Add("CustomerEventTests", _customerEventTests);
			toReturn.Add("AsitestRecommendation", _asitestRecommendation);
			toReturn.Add("OsteoporosisTestIncidentalFindings", _osteoporosisTestIncidentalFindings);
			toReturn.Add("IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings", _incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_asitestRecommendation!=null)
			{
				_asitestRecommendation.ActiveContext = base.ActiveContext;
			}
			if(_osteoporosisTestIncidentalFindings!=null)
			{
				_osteoporosisTestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings!=null)
			{
				_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_asitestFindings!=null)
			{
				_asitestFindings.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTests!=null)
			{
				_customerEventTests.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_asitestRecommendation = null;
			_osteoporosisTestIncidentalFindings = null;
			_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings = null;
			_asitestFindings = null;
			_customerEventTests = null;

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

			_fieldsCustomProperties.Add("OsteoporosisTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Tscore", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TscoreRight", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EvaluationStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DatedModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManual", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsCritical", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPartial", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OsteoporosisTestFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TechnicianRemarks", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnableToScreen", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedById", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedByRole", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualTscore", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualTscoreRight", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualStandardFinding", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LeftHeel", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RightHeel", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTestNotPerformed", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _asitestFindings</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAsitestFindings(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _asitestFindings, new PropertyChangedEventHandler( OnAsitestFindingsPropertyChanged ), "AsitestFindings", OsteoporosisTestResultsEntity.Relations.AsitestFindingsEntityUsingOsteoporosisTestFindingsId, true, signalRelatedEntity, "OsteoporosisTestResults", resetFKFields, new int[] { (int)OsteoporosisTestResultsFieldIndex.OsteoporosisTestFindingsId } );		
			_asitestFindings = null;
		}

		/// <summary> setups the sync logic for member _asitestFindings</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAsitestFindings(IEntity2 relatedEntity)
		{
			if(_asitestFindings!=relatedEntity)
			{
				DesetupSyncAsitestFindings(true, true);
				_asitestFindings = (AsitestFindingsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _asitestFindings, new PropertyChangedEventHandler( OnAsitestFindingsPropertyChanged ), "AsitestFindings", OsteoporosisTestResultsEntity.Relations.AsitestFindingsEntityUsingOsteoporosisTestFindingsId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAsitestFindingsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerEventTests</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventTests(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", OsteoporosisTestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, signalRelatedEntity, "OsteoporosisTestResults", resetFKFields, new int[] { (int)OsteoporosisTestResultsFieldIndex.CustomerEventTestId } );		
			_customerEventTests = null;
		}

		/// <summary> setups the sync logic for member _customerEventTests</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerEventTests(IEntity2 relatedEntity)
		{
			if(_customerEventTests!=relatedEntity)
			{
				DesetupSyncCustomerEventTests(true, true);
				_customerEventTests = (CustomerEventTestsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", OsteoporosisTestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerEventTestsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OsteoporosisTestResultsEntity</param>
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
		public  static OsteoporosisTestResultsRelations Relations
		{
			get	{ return new OsteoporosisTestResultsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AsitestRecommendation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAsitestRecommendation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AsitestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsitestRecommendationEntityFactory))),
					(IEntityRelation)GetRelationsForField("AsitestRecommendation")[0], (int)HealthYes.Data.EntityType.OsteoporosisTestResultsEntity, (int)HealthYes.Data.EntityType.AsitestRecommendationEntity, 0, null, null, null, null, "AsitestRecommendation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OsteoporosisTestIncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOsteoporosisTestIncidentalFindings
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OsteoporosisTestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestIncidentalFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("OsteoporosisTestIncidentalFindings")[0], (int)HealthYes.Data.EntityType.OsteoporosisTestResultsEntity, (int)HealthYes.Data.EntityType.OsteoporosisTestIncidentalFindingsEntity, 0, null, null, null, null, "OsteoporosisTestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings
		{
			get
			{
				IEntityRelation intermediateRelation = OsteoporosisTestResultsEntity.Relations.OsteoporosisTestIncidentalFindingsEntityUsingOsteoporosisTestId;
				intermediateRelation.SetAliases(string.Empty, "OsteoporosisTestIncidentalFindings_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.OsteoporosisTestResultsEntity, (int)HealthYes.Data.EntityType.IncidentalFindingsEntity, 0, null, null, GetRelationsForField("IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings"), null, "IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AsitestFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAsitestFindings
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AsitestFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("AsitestFindings")[0], (int)HealthYes.Data.EntityType.OsteoporosisTestResultsEntity, (int)HealthYes.Data.EntityType.AsitestFindingsEntity, 0, null, null, null, null, "AsitestFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTests
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTests")[0], (int)HealthYes.Data.EntityType.OsteoporosisTestResultsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, null, null, "CustomerEventTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OsteoporosisTestResultsEntity.CustomProperties;}
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
			get { return OsteoporosisTestResultsEntity.FieldsCustomProperties;}
		}

		/// <summary> The OsteoporosisTestId property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."OsteoporosisTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 OsteoporosisTestId
		{
			get { return (System.Int64)GetValue((int)OsteoporosisTestResultsFieldIndex.OsteoporosisTestId, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.OsteoporosisTestId, value); }
		}

		/// <summary> The CustomerEventTestId property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."CustomerEventTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventTestId
		{
			get { return (System.Int64)GetValue((int)OsteoporosisTestResultsFieldIndex.CustomerEventTestId, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.CustomerEventTestId, value); }
		}

		/// <summary> The Tscore property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."TScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Tscore
		{
			get { return (Nullable<System.Decimal>)GetValue((int)OsteoporosisTestResultsFieldIndex.Tscore, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.Tscore, value); }
		}

		/// <summary> The TscoreRight property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."TScoreRight"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> TscoreRight
		{
			get { return (Nullable<System.Boolean>)GetValue((int)OsteoporosisTestResultsFieldIndex.TscoreRight, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.TscoreRight, value); }
		}

		/// <summary> The EvaluationStatus property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."EvaluationStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte EvaluationStatus
		{
			get { return (System.Byte)GetValue((int)OsteoporosisTestResultsFieldIndex.EvaluationStatus, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.EvaluationStatus, value); }
		}

		/// <summary> The DateCreated property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)OsteoporosisTestResultsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DatedModified property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."DatedModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DatedModified
		{
			get { return (System.DateTime)GetValue((int)OsteoporosisTestResultsFieldIndex.DatedModified, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.DatedModified, value); }
		}

		/// <summary> The IsManual property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."IsManual"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsManual
		{
			get { return (System.Boolean)GetValue((int)OsteoporosisTestResultsFieldIndex.IsManual, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.IsManual, value); }
		}

		/// <summary> The IsCritical property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."IsCritical"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsCritical
		{
			get { return (System.Boolean)GetValue((int)OsteoporosisTestResultsFieldIndex.IsCritical, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.IsCritical, value); }
		}

		/// <summary> The IsPartial property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."IsPartial"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPartial
		{
			get { return (System.Boolean)GetValue((int)OsteoporosisTestResultsFieldIndex.IsPartial, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.IsPartial, value); }
		}

		/// <summary> The OsteoporosisTestFindingsId property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."OsteoporosisTestFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> OsteoporosisTestFindingsId
		{
			get { return (Nullable<System.Int32>)GetValue((int)OsteoporosisTestResultsFieldIndex.OsteoporosisTestFindingsId, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.OsteoporosisTestFindingsId, value); }
		}

		/// <summary> The TechnicianRemarks property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."TechnicianRemarks"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TechnicianRemarks
		{
			get { return (System.String)GetValue((int)OsteoporosisTestResultsFieldIndex.TechnicianRemarks, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.TechnicianRemarks, value); }
		}

		/// <summary> The UnableToScreen property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."UnableToScreen"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean UnableToScreen
		{
			get { return (System.Boolean)GetValue((int)OsteoporosisTestResultsFieldIndex.UnableToScreen, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.UnableToScreen, value); }
		}

		/// <summary> The RecordedById property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."RecordedByID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RecordedById
		{
			get { return (Nullable<System.Int64>)GetValue((int)OsteoporosisTestResultsFieldIndex.RecordedById, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.RecordedById, value); }
		}

		/// <summary> The RecordedByRole property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."RecordedByRole"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> RecordedByRole
		{
			get { return (Nullable<System.Byte>)GetValue((int)OsteoporosisTestResultsFieldIndex.RecordedByRole, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.RecordedByRole, value); }
		}

		/// <summary> The IsManualTscore property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."IsManualTScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualTscore
		{
			get { return (Nullable<System.Boolean>)GetValue((int)OsteoporosisTestResultsFieldIndex.IsManualTscore, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.IsManualTscore, value); }
		}

		/// <summary> The IsManualTscoreRight property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."IsManualTScoreRight"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualTscoreRight
		{
			get { return (Nullable<System.Boolean>)GetValue((int)OsteoporosisTestResultsFieldIndex.IsManualTscoreRight, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.IsManualTscoreRight, value); }
		}

		/// <summary> The IsManualStandardFinding property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."IsManualStandardFinding"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualStandardFinding
		{
			get { return (Nullable<System.Boolean>)GetValue((int)OsteoporosisTestResultsFieldIndex.IsManualStandardFinding, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.IsManualStandardFinding, value); }
		}

		/// <summary> The LeftHeel property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."LeftHeel"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> LeftHeel
		{
			get { return (Nullable<System.Decimal>)GetValue((int)OsteoporosisTestResultsFieldIndex.LeftHeel, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.LeftHeel, value); }
		}

		/// <summary> The RightHeel property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."RightHeel"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> RightHeel
		{
			get { return (Nullable<System.Decimal>)GetValue((int)OsteoporosisTestResultsFieldIndex.RightHeel, false); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.RightHeel, value); }
		}

		/// <summary> The IsTestNotPerformed property of the Entity OsteoporosisTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOsteoporosisTestResults_Legacy"."IsTestNotPerformed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTestNotPerformed
		{
			get { return (System.Boolean)GetValue((int)OsteoporosisTestResultsFieldIndex.IsTestNotPerformed, true); }
			set	{ SetValue((int)OsteoporosisTestResultsFieldIndex.IsTestNotPerformed, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AsitestRecommendationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AsitestRecommendationEntity))]
		public virtual EntityCollection<AsitestRecommendationEntity> AsitestRecommendation
		{
			get
			{
				if(_asitestRecommendation==null)
				{
					_asitestRecommendation = new EntityCollection<AsitestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsitestRecommendationEntityFactory)));
					_asitestRecommendation.SetContainingEntityInfo(this, "OsteoporosisTestResults");
				}
				return _asitestRecommendation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OsteoporosisTestIncidentalFindingsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OsteoporosisTestIncidentalFindingsEntity))]
		public virtual EntityCollection<OsteoporosisTestIncidentalFindingsEntity> OsteoporosisTestIncidentalFindings
		{
			get
			{
				if(_osteoporosisTestIncidentalFindings==null)
				{
					_osteoporosisTestIncidentalFindings = new EntityCollection<OsteoporosisTestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestIncidentalFindingsEntityFactory)));
					_osteoporosisTestIncidentalFindings.SetContainingEntityInfo(this, "OsteoporosisTestResults");
				}
				return _osteoporosisTestIncidentalFindings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingsEntity))]
		public virtual EntityCollection<IncidentalFindingsEntity> IncidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings
		{
			get
			{
				if(_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings==null)
				{
					_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings = new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory)));
					_incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings.IsReadOnly=true;
				}
				return _incidentalFindingsCollectionViaOsteoporosisTestIncidentalFindings;
			}
		}

		/// <summary> Gets / sets related entity of type 'AsitestFindingsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AsitestFindingsEntity AsitestFindings
		{
			get
			{
				return _asitestFindings;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAsitestFindings(value);
				}
				else
				{
					if(value==null)
					{
						if(_asitestFindings != null)
						{
							_asitestFindings.UnsetRelatedEntity(this, "OsteoporosisTestResults");
						}
					}
					else
					{
						if(_asitestFindings!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "OsteoporosisTestResults");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerEventTestsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerEventTestsEntity CustomerEventTests
		{
			get
			{
				return _customerEventTests;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerEventTests(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerEventTests != null)
						{
							_customerEventTests.UnsetRelatedEntity(this, "OsteoporosisTestResults");
						}
					}
					else
					{
						if(_customerEventTests!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "OsteoporosisTestResults");
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
		
		/// <summary>Returns the HealthYes.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)HealthYes.Data.EntityType.OsteoporosisTestResultsEntity; }
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
