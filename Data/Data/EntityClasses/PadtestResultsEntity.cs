///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:30 AM
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
	/// Entity class which represents the entity 'PadtestResults'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PadtestResultsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<OsteoporosisTestRecommendationEntity> _osteoporosisTestRecommendation;
		private EntityCollection<PadtestIncidentalFindingsEntity> _padtestIncidentalFindings;
		private EntityCollection<IncidentalFindingsEntity> _incidentalFindingsCollectionViaPadtestIncidentalFindings;
		private CustomerEventTestsEntity _customerEventTests;
		private PadtestFindingsEntity _padtestFindings;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerEventTests</summary>
			public static readonly string CustomerEventTests = "CustomerEventTests";
			/// <summary>Member name PadtestFindings</summary>
			public static readonly string PadtestFindings = "PadtestFindings";
			/// <summary>Member name OsteoporosisTestRecommendation</summary>
			public static readonly string OsteoporosisTestRecommendation = "OsteoporosisTestRecommendation";
			/// <summary>Member name PadtestIncidentalFindings</summary>
			public static readonly string PadtestIncidentalFindings = "PadtestIncidentalFindings";
			/// <summary>Member name IncidentalFindingsCollectionViaPadtestIncidentalFindings</summary>
			public static readonly string IncidentalFindingsCollectionViaPadtestIncidentalFindings = "IncidentalFindingsCollectionViaPadtestIncidentalFindings";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PadtestResultsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PadtestResultsEntity():base("PadtestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PadtestResultsEntity(IEntityFields2 fields):base("PadtestResultsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PadtestResultsEntity</param>
		public PadtestResultsEntity(IValidator validator):base("PadtestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="padtestId">PK value for PadtestResults which data should be fetched into this PadtestResults object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PadtestResultsEntity(System.Int64 padtestId):base("PadtestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PadtestId = padtestId;
		}

		/// <summary> CTor</summary>
		/// <param name="padtestId">PK value for PadtestResults which data should be fetched into this PadtestResults object</param>
		/// <param name="validator">The custom validator object for this PadtestResultsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PadtestResultsEntity(System.Int64 padtestId, IValidator validator):base("PadtestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PadtestId = padtestId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PadtestResultsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_osteoporosisTestRecommendation = (EntityCollection<OsteoporosisTestRecommendationEntity>)info.GetValue("_osteoporosisTestRecommendation", typeof(EntityCollection<OsteoporosisTestRecommendationEntity>));
				_padtestIncidentalFindings = (EntityCollection<PadtestIncidentalFindingsEntity>)info.GetValue("_padtestIncidentalFindings", typeof(EntityCollection<PadtestIncidentalFindingsEntity>));
				_incidentalFindingsCollectionViaPadtestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>)info.GetValue("_incidentalFindingsCollectionViaPadtestIncidentalFindings", typeof(EntityCollection<IncidentalFindingsEntity>));
				_customerEventTests = (CustomerEventTestsEntity)info.GetValue("_customerEventTests", typeof(CustomerEventTestsEntity));
				if(_customerEventTests!=null)
				{
					_customerEventTests.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_padtestFindings = (PadtestFindingsEntity)info.GetValue("_padtestFindings", typeof(PadtestFindingsEntity));
				if(_padtestFindings!=null)
				{
					_padtestFindings.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PadtestResultsFieldIndex)fieldIndex)
			{
				case PadtestResultsFieldIndex.CustomerEventTestId:
					DesetupSyncCustomerEventTests(true, false);
					break;
				case PadtestResultsFieldIndex.PadtestFindingsId:
					DesetupSyncPadtestFindings(true, false);
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
				case "CustomerEventTests":
					this.CustomerEventTests = (CustomerEventTestsEntity)entity;
					break;
				case "PadtestFindings":
					this.PadtestFindings = (PadtestFindingsEntity)entity;
					break;
				case "OsteoporosisTestRecommendation":
					this.OsteoporosisTestRecommendation.Add((OsteoporosisTestRecommendationEntity)entity);
					break;
				case "PadtestIncidentalFindings":
					this.PadtestIncidentalFindings.Add((PadtestIncidentalFindingsEntity)entity);
					break;
				case "IncidentalFindingsCollectionViaPadtestIncidentalFindings":
					this.IncidentalFindingsCollectionViaPadtestIncidentalFindings.IsReadOnly = false;
					this.IncidentalFindingsCollectionViaPadtestIncidentalFindings.Add((IncidentalFindingsEntity)entity);
					this.IncidentalFindingsCollectionViaPadtestIncidentalFindings.IsReadOnly = true;
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
			return PadtestResultsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerEventTests":
					toReturn.Add(PadtestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId);
					break;
				case "PadtestFindings":
					toReturn.Add(PadtestResultsEntity.Relations.PadtestFindingsEntityUsingPadtestFindingsId);
					break;
				case "OsteoporosisTestRecommendation":
					toReturn.Add(PadtestResultsEntity.Relations.OsteoporosisTestRecommendationEntityUsingOsteoporosisTestId);
					break;
				case "PadtestIncidentalFindings":
					toReturn.Add(PadtestResultsEntity.Relations.PadtestIncidentalFindingsEntityUsingPadtestId);
					break;
				case "IncidentalFindingsCollectionViaPadtestIncidentalFindings":
					toReturn.Add(PadtestResultsEntity.Relations.PadtestIncidentalFindingsEntityUsingPadtestId, "PadtestResultsEntity__", "PadtestIncidentalFindings_", JoinHint.None);
					toReturn.Add(PadtestIncidentalFindingsEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingsId, "PadtestIncidentalFindings_", string.Empty, JoinHint.None);
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
				case "CustomerEventTests":
					SetupSyncCustomerEventTests(relatedEntity);
					break;
				case "PadtestFindings":
					SetupSyncPadtestFindings(relatedEntity);
					break;
				case "OsteoporosisTestRecommendation":
					this.OsteoporosisTestRecommendation.Add((OsteoporosisTestRecommendationEntity)relatedEntity);
					break;
				case "PadtestIncidentalFindings":
					this.PadtestIncidentalFindings.Add((PadtestIncidentalFindingsEntity)relatedEntity);
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
				case "CustomerEventTests":
					DesetupSyncCustomerEventTests(false, true);
					break;
				case "PadtestFindings":
					DesetupSyncPadtestFindings(false, true);
					break;
				case "OsteoporosisTestRecommendation":
					base.PerformRelatedEntityRemoval(this.OsteoporosisTestRecommendation, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PadtestIncidentalFindings":
					base.PerformRelatedEntityRemoval(this.PadtestIncidentalFindings, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_customerEventTests!=null)
			{
				toReturn.Add(_customerEventTests);
			}
			if(_padtestFindings!=null)
			{
				toReturn.Add(_padtestFindings);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.OsteoporosisTestRecommendation);
			toReturn.Add(this.PadtestIncidentalFindings);

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
				info.AddValue("_osteoporosisTestRecommendation", ((_osteoporosisTestRecommendation!=null) && (_osteoporosisTestRecommendation.Count>0) && !this.MarkedForDeletion)?_osteoporosisTestRecommendation:null);
				info.AddValue("_padtestIncidentalFindings", ((_padtestIncidentalFindings!=null) && (_padtestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_padtestIncidentalFindings:null);
				info.AddValue("_incidentalFindingsCollectionViaPadtestIncidentalFindings", ((_incidentalFindingsCollectionViaPadtestIncidentalFindings!=null) && (_incidentalFindingsCollectionViaPadtestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_incidentalFindingsCollectionViaPadtestIncidentalFindings:null);
				info.AddValue("_customerEventTests", (!this.MarkedForDeletion?_customerEventTests:null));
				info.AddValue("_padtestFindings", (!this.MarkedForDeletion?_padtestFindings:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PadtestResultsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PadtestResultsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PadtestResultsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OsteoporosisTestRecommendation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOsteoporosisTestRecommendation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OsteoporosisTestRecommendationFields.OsteoporosisTestId, null, ComparisonOperator.Equal, this.PadtestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PadtestIncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPadtestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PadtestIncidentalFindingsFields.PadtestId, null, ComparisonOperator.Equal, this.PadtestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingsCollectionViaPadtestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingsCollectionViaPadtestIncidentalFindings"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PadtestResultsFields.PadtestId, null, ComparisonOperator.Equal, this.PadtestId, "PadtestResultsEntity__"));
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

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PadtestFindings' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPadtestFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PadtestFindingsFields.PadtestFindingsId, null, ComparisonOperator.Equal, this.PadtestFindingsId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.PadtestResultsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PadtestResultsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._osteoporosisTestRecommendation);
			collectionsQueue.Enqueue(this._padtestIncidentalFindings);
			collectionsQueue.Enqueue(this._incidentalFindingsCollectionViaPadtestIncidentalFindings);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._osteoporosisTestRecommendation = (EntityCollection<OsteoporosisTestRecommendationEntity>) collectionsQueue.Dequeue();
			this._padtestIncidentalFindings = (EntityCollection<PadtestIncidentalFindingsEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingsCollectionViaPadtestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._osteoporosisTestRecommendation != null)
			{
				return true;
			}
			if (this._padtestIncidentalFindings != null)
			{
				return true;
			}
			if (this._incidentalFindingsCollectionViaPadtestIncidentalFindings != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OsteoporosisTestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestRecommendationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PadtestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PadtestIncidentalFindingsEntityFactory))) : null);
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
			toReturn.Add("CustomerEventTests", _customerEventTests);
			toReturn.Add("PadtestFindings", _padtestFindings);
			toReturn.Add("OsteoporosisTestRecommendation", _osteoporosisTestRecommendation);
			toReturn.Add("PadtestIncidentalFindings", _padtestIncidentalFindings);
			toReturn.Add("IncidentalFindingsCollectionViaPadtestIncidentalFindings", _incidentalFindingsCollectionViaPadtestIncidentalFindings);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_osteoporosisTestRecommendation!=null)
			{
				_osteoporosisTestRecommendation.ActiveContext = base.ActiveContext;
			}
			if(_padtestIncidentalFindings!=null)
			{
				_padtestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingsCollectionViaPadtestIncidentalFindings!=null)
			{
				_incidentalFindingsCollectionViaPadtestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTests!=null)
			{
				_customerEventTests.ActiveContext = base.ActiveContext;
			}
			if(_padtestFindings!=null)
			{
				_padtestFindings.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_osteoporosisTestRecommendation = null;
			_padtestIncidentalFindings = null;
			_incidentalFindingsCollectionViaPadtestIncidentalFindings = null;
			_customerEventTests = null;
			_padtestFindings = null;

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

			_fieldsCustomProperties.Add("PadtestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RightAbi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SystolicRarm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SystolicRankle", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LeftAbi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SystolicLarm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SystolicLankle", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EvaluationStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManual", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsCritical", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPartial", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PadtestFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TechnicianRemarks", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnableToScreen", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedById", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedByRole", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualRightAbi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualSystolicRarm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualSystolicRankle", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualLeftAbi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualSystolicLarm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualSystolicLankle", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualStandardFinding", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPencilDopplerUsed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTestNotPerformed", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerEventTests</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventTests(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", PadtestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, signalRelatedEntity, "PadtestResults", resetFKFields, new int[] { (int)PadtestResultsFieldIndex.CustomerEventTestId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", PadtestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _padtestFindings</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPadtestFindings(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _padtestFindings, new PropertyChangedEventHandler( OnPadtestFindingsPropertyChanged ), "PadtestFindings", PadtestResultsEntity.Relations.PadtestFindingsEntityUsingPadtestFindingsId, true, signalRelatedEntity, "PadtestResults", resetFKFields, new int[] { (int)PadtestResultsFieldIndex.PadtestFindingsId } );		
			_padtestFindings = null;
		}

		/// <summary> setups the sync logic for member _padtestFindings</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPadtestFindings(IEntity2 relatedEntity)
		{
			if(_padtestFindings!=relatedEntity)
			{
				DesetupSyncPadtestFindings(true, true);
				_padtestFindings = (PadtestFindingsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _padtestFindings, new PropertyChangedEventHandler( OnPadtestFindingsPropertyChanged ), "PadtestFindings", PadtestResultsEntity.Relations.PadtestFindingsEntityUsingPadtestFindingsId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPadtestFindingsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PadtestResultsEntity</param>
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
		public  static PadtestResultsRelations Relations
		{
			get	{ return new PadtestResultsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OsteoporosisTestRecommendation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOsteoporosisTestRecommendation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OsteoporosisTestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestRecommendationEntityFactory))),
					(IEntityRelation)GetRelationsForField("OsteoporosisTestRecommendation")[0], (int)HealthYes.Data.EntityType.PadtestResultsEntity, (int)HealthYes.Data.EntityType.OsteoporosisTestRecommendationEntity, 0, null, null, null, null, "OsteoporosisTestRecommendation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PadtestIncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPadtestIncidentalFindings
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PadtestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PadtestIncidentalFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("PadtestIncidentalFindings")[0], (int)HealthYes.Data.EntityType.PadtestResultsEntity, (int)HealthYes.Data.EntityType.PadtestIncidentalFindingsEntity, 0, null, null, null, null, "PadtestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingsCollectionViaPadtestIncidentalFindings
		{
			get
			{
				IEntityRelation intermediateRelation = PadtestResultsEntity.Relations.PadtestIncidentalFindingsEntityUsingPadtestId;
				intermediateRelation.SetAliases(string.Empty, "PadtestIncidentalFindings_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.PadtestResultsEntity, (int)HealthYes.Data.EntityType.IncidentalFindingsEntity, 0, null, null, GetRelationsForField("IncidentalFindingsCollectionViaPadtestIncidentalFindings"), null, "IncidentalFindingsCollectionViaPadtestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("CustomerEventTests")[0], (int)HealthYes.Data.EntityType.PadtestResultsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, null, null, "CustomerEventTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PadtestFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPadtestFindings
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PadtestFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("PadtestFindings")[0], (int)HealthYes.Data.EntityType.PadtestResultsEntity, (int)HealthYes.Data.EntityType.PadtestFindingsEntity, 0, null, null, null, null, "PadtestFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PadtestResultsEntity.CustomProperties;}
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
			get { return PadtestResultsEntity.FieldsCustomProperties;}
		}

		/// <summary> The PadtestId property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."PADTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PadtestId
		{
			get { return (System.Int64)GetValue((int)PadtestResultsFieldIndex.PadtestId, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.PadtestId, value); }
		}

		/// <summary> The CustomerEventTestId property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."CustomerEventTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventTestId
		{
			get { return (System.Int64)GetValue((int)PadtestResultsFieldIndex.CustomerEventTestId, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.CustomerEventTestId, value); }
		}

		/// <summary> The RightAbi property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."RightABI"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> RightAbi
		{
			get { return (Nullable<System.Decimal>)GetValue((int)PadtestResultsFieldIndex.RightAbi, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.RightAbi, value); }
		}

		/// <summary> The SystolicRarm property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."SystolicRArm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> SystolicRarm
		{
			get { return (Nullable<System.Int32>)GetValue((int)PadtestResultsFieldIndex.SystolicRarm, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.SystolicRarm, value); }
		}

		/// <summary> The SystolicRankle property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."SystolicRAnkle"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> SystolicRankle
		{
			get { return (Nullable<System.Int32>)GetValue((int)PadtestResultsFieldIndex.SystolicRankle, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.SystolicRankle, value); }
		}

		/// <summary> The LeftAbi property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."LeftABI"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> LeftAbi
		{
			get { return (Nullable<System.Decimal>)GetValue((int)PadtestResultsFieldIndex.LeftAbi, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.LeftAbi, value); }
		}

		/// <summary> The SystolicLarm property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."SystolicLArm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> SystolicLarm
		{
			get { return (Nullable<System.Int32>)GetValue((int)PadtestResultsFieldIndex.SystolicLarm, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.SystolicLarm, value); }
		}

		/// <summary> The SystolicLankle property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."SystolicLAnkle"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> SystolicLankle
		{
			get { return (Nullable<System.Int32>)GetValue((int)PadtestResultsFieldIndex.SystolicLankle, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.SystolicLankle, value); }
		}

		/// <summary> The EvaluationStatus property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."EvaluationStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte EvaluationStatus
		{
			get { return (System.Byte)GetValue((int)PadtestResultsFieldIndex.EvaluationStatus, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.EvaluationStatus, value); }
		}

		/// <summary> The DateCreated property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PadtestResultsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)PadtestResultsFieldIndex.DateModified, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsManual property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsManual"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsManual
		{
			get { return (System.Boolean)GetValue((int)PadtestResultsFieldIndex.IsManual, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsManual, value); }
		}

		/// <summary> The IsCritical property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsCritical"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsCritical
		{
			get { return (System.Boolean)GetValue((int)PadtestResultsFieldIndex.IsCritical, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsCritical, value); }
		}

		/// <summary> The IsPartial property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsPartial"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPartial
		{
			get { return (System.Boolean)GetValue((int)PadtestResultsFieldIndex.IsPartial, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsPartial, value); }
		}

		/// <summary> The PadtestFindingsId property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."PADTestFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> PadtestFindingsId
		{
			get { return (Nullable<System.Int32>)GetValue((int)PadtestResultsFieldIndex.PadtestFindingsId, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.PadtestFindingsId, value); }
		}

		/// <summary> The TechnicianRemarks property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."TechnicianRemarks"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TechnicianRemarks
		{
			get { return (System.String)GetValue((int)PadtestResultsFieldIndex.TechnicianRemarks, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.TechnicianRemarks, value); }
		}

		/// <summary> The UnableToScreen property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."UnableToScreen"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean UnableToScreen
		{
			get { return (System.Boolean)GetValue((int)PadtestResultsFieldIndex.UnableToScreen, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.UnableToScreen, value); }
		}

		/// <summary> The RecordedById property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."RecordedByID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RecordedById
		{
			get { return (Nullable<System.Int64>)GetValue((int)PadtestResultsFieldIndex.RecordedById, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.RecordedById, value); }
		}

		/// <summary> The RecordedByRole property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."RecordedByRole"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> RecordedByRole
		{
			get { return (Nullable<System.Byte>)GetValue((int)PadtestResultsFieldIndex.RecordedByRole, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.RecordedByRole, value); }
		}

		/// <summary> The IsManualRightAbi property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsManualRightABI"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualRightAbi
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PadtestResultsFieldIndex.IsManualRightAbi, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsManualRightAbi, value); }
		}

		/// <summary> The IsManualSystolicRarm property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsManualSystolicRArm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualSystolicRarm
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PadtestResultsFieldIndex.IsManualSystolicRarm, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsManualSystolicRarm, value); }
		}

		/// <summary> The IsManualSystolicRankle property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsManualSystolicRAnkle"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualSystolicRankle
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PadtestResultsFieldIndex.IsManualSystolicRankle, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsManualSystolicRankle, value); }
		}

		/// <summary> The IsManualLeftAbi property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsManualLeftABI"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualLeftAbi
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PadtestResultsFieldIndex.IsManualLeftAbi, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsManualLeftAbi, value); }
		}

		/// <summary> The IsManualSystolicLarm property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsManualSystolicLArm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualSystolicLarm
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PadtestResultsFieldIndex.IsManualSystolicLarm, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsManualSystolicLarm, value); }
		}

		/// <summary> The IsManualSystolicLankle property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsManualSystolicLAnkle"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualSystolicLankle
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PadtestResultsFieldIndex.IsManualSystolicLankle, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsManualSystolicLankle, value); }
		}

		/// <summary> The IsManualStandardFinding property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsManualStandardFinding"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualStandardFinding
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PadtestResultsFieldIndex.IsManualStandardFinding, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsManualStandardFinding, value); }
		}

		/// <summary> The IsPencilDopplerUsed property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsPencilDopplerUsed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsPencilDopplerUsed
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PadtestResultsFieldIndex.IsPencilDopplerUsed, false); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsPencilDopplerUsed, value); }
		}

		/// <summary> The IsTestNotPerformed property of the Entity PadtestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestResults_Legacy"."IsTestNotPerformed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTestNotPerformed
		{
			get { return (System.Boolean)GetValue((int)PadtestResultsFieldIndex.IsTestNotPerformed, true); }
			set	{ SetValue((int)PadtestResultsFieldIndex.IsTestNotPerformed, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OsteoporosisTestRecommendationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OsteoporosisTestRecommendationEntity))]
		public virtual EntityCollection<OsteoporosisTestRecommendationEntity> OsteoporosisTestRecommendation
		{
			get
			{
				if(_osteoporosisTestRecommendation==null)
				{
					_osteoporosisTestRecommendation = new EntityCollection<OsteoporosisTestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestRecommendationEntityFactory)));
					_osteoporosisTestRecommendation.SetContainingEntityInfo(this, "PadtestResults");
				}
				return _osteoporosisTestRecommendation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PadtestIncidentalFindingsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PadtestIncidentalFindingsEntity))]
		public virtual EntityCollection<PadtestIncidentalFindingsEntity> PadtestIncidentalFindings
		{
			get
			{
				if(_padtestIncidentalFindings==null)
				{
					_padtestIncidentalFindings = new EntityCollection<PadtestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PadtestIncidentalFindingsEntityFactory)));
					_padtestIncidentalFindings.SetContainingEntityInfo(this, "PadtestResults");
				}
				return _padtestIncidentalFindings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingsEntity))]
		public virtual EntityCollection<IncidentalFindingsEntity> IncidentalFindingsCollectionViaPadtestIncidentalFindings
		{
			get
			{
				if(_incidentalFindingsCollectionViaPadtestIncidentalFindings==null)
				{
					_incidentalFindingsCollectionViaPadtestIncidentalFindings = new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory)));
					_incidentalFindingsCollectionViaPadtestIncidentalFindings.IsReadOnly=true;
				}
				return _incidentalFindingsCollectionViaPadtestIncidentalFindings;
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
							_customerEventTests.UnsetRelatedEntity(this, "PadtestResults");
						}
					}
					else
					{
						if(_customerEventTests!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PadtestResults");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PadtestFindingsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PadtestFindingsEntity PadtestFindings
		{
			get
			{
				return _padtestFindings;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPadtestFindings(value);
				}
				else
				{
					if(value==null)
					{
						if(_padtestFindings != null)
						{
							_padtestFindings.UnsetRelatedEntity(this, "PadtestResults");
						}
					}
					else
					{
						if(_padtestFindings!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PadtestResults");
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
			get { return (int)HealthYes.Data.EntityType.PadtestResultsEntity; }
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
