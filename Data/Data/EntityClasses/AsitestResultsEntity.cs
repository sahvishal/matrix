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
	/// Entity class which represents the entity 'AsitestResults'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AsitestResultsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ASIRawDataReadingEntity> _asirawDataReading;
		private EntityCollection<AsitestIncidentalFindingsEntity> _asitestIncidentalFindings;
		private EntityCollection<AsiunableScreenReasonEntity> _asiunableScreenReason;
		private EntityCollection<CarotidArteryTestRecommendationEntity> _carotidArteryTestRecommendation;
		private EntityCollection<IncidentalFindingsEntity> _incidentalFindingsCollectionViaAsitestIncidentalFindings;
		private EntityCollection<UnableScreenReasonEntity> _unableScreenReasonCollectionViaAsiunableScreenReason;
		private AaatestFindingsEntity _aaatestFindings;
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
			/// <summary>Member name AaatestFindings</summary>
			public static readonly string AaatestFindings = "AaatestFindings";
			/// <summary>Member name CustomerEventTests</summary>
			public static readonly string CustomerEventTests = "CustomerEventTests";
			/// <summary>Member name AsirawDataReading</summary>
			public static readonly string AsirawDataReading = "AsirawDataReading";
			/// <summary>Member name AsitestIncidentalFindings</summary>
			public static readonly string AsitestIncidentalFindings = "AsitestIncidentalFindings";
			/// <summary>Member name AsiunableScreenReason</summary>
			public static readonly string AsiunableScreenReason = "AsiunableScreenReason";
			/// <summary>Member name CarotidArteryTestRecommendation</summary>
			public static readonly string CarotidArteryTestRecommendation = "CarotidArteryTestRecommendation";
			/// <summary>Member name IncidentalFindingsCollectionViaAsitestIncidentalFindings</summary>
			public static readonly string IncidentalFindingsCollectionViaAsitestIncidentalFindings = "IncidentalFindingsCollectionViaAsitestIncidentalFindings";
			/// <summary>Member name UnableScreenReasonCollectionViaAsiunableScreenReason</summary>
			public static readonly string UnableScreenReasonCollectionViaAsiunableScreenReason = "UnableScreenReasonCollectionViaAsiunableScreenReason";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AsitestResultsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AsitestResultsEntity():base("AsitestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AsitestResultsEntity(IEntityFields2 fields):base("AsitestResultsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AsitestResultsEntity</param>
		public AsitestResultsEntity(IValidator validator):base("AsitestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="asitestId">PK value for AsitestResults which data should be fetched into this AsitestResults object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AsitestResultsEntity(System.Int64 asitestId):base("AsitestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AsitestId = asitestId;
		}

		/// <summary> CTor</summary>
		/// <param name="asitestId">PK value for AsitestResults which data should be fetched into this AsitestResults object</param>
		/// <param name="validator">The custom validator object for this AsitestResultsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AsitestResultsEntity(System.Int64 asitestId, IValidator validator):base("AsitestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AsitestId = asitestId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AsitestResultsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_asirawDataReading = (EntityCollection<ASIRawDataReadingEntity>)info.GetValue("_asirawDataReading", typeof(EntityCollection<ASIRawDataReadingEntity>));
				_asitestIncidentalFindings = (EntityCollection<AsitestIncidentalFindingsEntity>)info.GetValue("_asitestIncidentalFindings", typeof(EntityCollection<AsitestIncidentalFindingsEntity>));
				_asiunableScreenReason = (EntityCollection<AsiunableScreenReasonEntity>)info.GetValue("_asiunableScreenReason", typeof(EntityCollection<AsiunableScreenReasonEntity>));
				_carotidArteryTestRecommendation = (EntityCollection<CarotidArteryTestRecommendationEntity>)info.GetValue("_carotidArteryTestRecommendation", typeof(EntityCollection<CarotidArteryTestRecommendationEntity>));
				_incidentalFindingsCollectionViaAsitestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>)info.GetValue("_incidentalFindingsCollectionViaAsitestIncidentalFindings", typeof(EntityCollection<IncidentalFindingsEntity>));
				_unableScreenReasonCollectionViaAsiunableScreenReason = (EntityCollection<UnableScreenReasonEntity>)info.GetValue("_unableScreenReasonCollectionViaAsiunableScreenReason", typeof(EntityCollection<UnableScreenReasonEntity>));
				_aaatestFindings = (AaatestFindingsEntity)info.GetValue("_aaatestFindings", typeof(AaatestFindingsEntity));
				if(_aaatestFindings!=null)
				{
					_aaatestFindings.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AsitestResultsFieldIndex)fieldIndex)
			{
				case AsitestResultsFieldIndex.CustomerEventTestId:
					DesetupSyncCustomerEventTests(true, false);
					break;
				case AsitestResultsFieldIndex.AsitestFindingsId:
					DesetupSyncAaatestFindings(true, false);
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
				case "AaatestFindings":
					this.AaatestFindings = (AaatestFindingsEntity)entity;
					break;
				case "CustomerEventTests":
					this.CustomerEventTests = (CustomerEventTestsEntity)entity;
					break;
				case "AsirawDataReading":
					this.AsirawDataReading.Add((ASIRawDataReadingEntity)entity);
					break;
				case "AsitestIncidentalFindings":
					this.AsitestIncidentalFindings.Add((AsitestIncidentalFindingsEntity)entity);
					break;
				case "AsiunableScreenReason":
					this.AsiunableScreenReason.Add((AsiunableScreenReasonEntity)entity);
					break;
				case "CarotidArteryTestRecommendation":
					this.CarotidArteryTestRecommendation.Add((CarotidArteryTestRecommendationEntity)entity);
					break;
				case "IncidentalFindingsCollectionViaAsitestIncidentalFindings":
					this.IncidentalFindingsCollectionViaAsitestIncidentalFindings.IsReadOnly = false;
					this.IncidentalFindingsCollectionViaAsitestIncidentalFindings.Add((IncidentalFindingsEntity)entity);
					this.IncidentalFindingsCollectionViaAsitestIncidentalFindings.IsReadOnly = true;
					break;
				case "UnableScreenReasonCollectionViaAsiunableScreenReason":
					this.UnableScreenReasonCollectionViaAsiunableScreenReason.IsReadOnly = false;
					this.UnableScreenReasonCollectionViaAsiunableScreenReason.Add((UnableScreenReasonEntity)entity);
					this.UnableScreenReasonCollectionViaAsiunableScreenReason.IsReadOnly = true;
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
			return AsitestResultsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AaatestFindings":
					toReturn.Add(AsitestResultsEntity.Relations.AaatestFindingsEntityUsingAsitestFindingsId);
					break;
				case "CustomerEventTests":
					toReturn.Add(AsitestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId);
					break;
				case "AsirawDataReading":
					toReturn.Add(AsitestResultsEntity.Relations.ASIRawDataReadingEntityUsingAsitestId);
					break;
				case "AsitestIncidentalFindings":
					toReturn.Add(AsitestResultsEntity.Relations.AsitestIncidentalFindingsEntityUsingAsitestId);
					break;
				case "AsiunableScreenReason":
					toReturn.Add(AsitestResultsEntity.Relations.AsiunableScreenReasonEntityUsingAsitestId);
					break;
				case "CarotidArteryTestRecommendation":
					toReturn.Add(AsitestResultsEntity.Relations.CarotidArteryTestRecommendationEntityUsingCarotidArteryTestId);
					break;
				case "IncidentalFindingsCollectionViaAsitestIncidentalFindings":
					toReturn.Add(AsitestResultsEntity.Relations.AsitestIncidentalFindingsEntityUsingAsitestId, "AsitestResultsEntity__", "AsitestIncidentalFindings_", JoinHint.None);
					toReturn.Add(AsitestIncidentalFindingsEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingsId, "AsitestIncidentalFindings_", string.Empty, JoinHint.None);
					break;
				case "UnableScreenReasonCollectionViaAsiunableScreenReason":
					toReturn.Add(AsitestResultsEntity.Relations.AsiunableScreenReasonEntityUsingAsitestId, "AsitestResultsEntity__", "AsiunableScreenReason_", JoinHint.None);
					toReturn.Add(AsiunableScreenReasonEntity.Relations.UnableScreenReasonEntityUsingUnableScreenReasonId, "AsiunableScreenReason_", string.Empty, JoinHint.None);
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
				case "AaatestFindings":
					SetupSyncAaatestFindings(relatedEntity);
					break;
				case "CustomerEventTests":
					SetupSyncCustomerEventTests(relatedEntity);
					break;
				case "AsirawDataReading":
					this.AsirawDataReading.Add((ASIRawDataReadingEntity)relatedEntity);
					break;
				case "AsitestIncidentalFindings":
					this.AsitestIncidentalFindings.Add((AsitestIncidentalFindingsEntity)relatedEntity);
					break;
				case "AsiunableScreenReason":
					this.AsiunableScreenReason.Add((AsiunableScreenReasonEntity)relatedEntity);
					break;
				case "CarotidArteryTestRecommendation":
					this.CarotidArteryTestRecommendation.Add((CarotidArteryTestRecommendationEntity)relatedEntity);
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
				case "AaatestFindings":
					DesetupSyncAaatestFindings(false, true);
					break;
				case "CustomerEventTests":
					DesetupSyncCustomerEventTests(false, true);
					break;
				case "AsirawDataReading":
					base.PerformRelatedEntityRemoval(this.AsirawDataReading, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AsitestIncidentalFindings":
					base.PerformRelatedEntityRemoval(this.AsitestIncidentalFindings, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AsiunableScreenReason":
					base.PerformRelatedEntityRemoval(this.AsiunableScreenReason, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CarotidArteryTestRecommendation":
					base.PerformRelatedEntityRemoval(this.CarotidArteryTestRecommendation, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_aaatestFindings!=null)
			{
				toReturn.Add(_aaatestFindings);
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
			toReturn.Add(this.AsirawDataReading);
			toReturn.Add(this.AsitestIncidentalFindings);
			toReturn.Add(this.AsiunableScreenReason);
			toReturn.Add(this.CarotidArteryTestRecommendation);

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
				info.AddValue("_asirawDataReading", ((_asirawDataReading!=null) && (_asirawDataReading.Count>0) && !this.MarkedForDeletion)?_asirawDataReading:null);
				info.AddValue("_asitestIncidentalFindings", ((_asitestIncidentalFindings!=null) && (_asitestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_asitestIncidentalFindings:null);
				info.AddValue("_asiunableScreenReason", ((_asiunableScreenReason!=null) && (_asiunableScreenReason.Count>0) && !this.MarkedForDeletion)?_asiunableScreenReason:null);
				info.AddValue("_carotidArteryTestRecommendation", ((_carotidArteryTestRecommendation!=null) && (_carotidArteryTestRecommendation.Count>0) && !this.MarkedForDeletion)?_carotidArteryTestRecommendation:null);
				info.AddValue("_incidentalFindingsCollectionViaAsitestIncidentalFindings", ((_incidentalFindingsCollectionViaAsitestIncidentalFindings!=null) && (_incidentalFindingsCollectionViaAsitestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_incidentalFindingsCollectionViaAsitestIncidentalFindings:null);
				info.AddValue("_unableScreenReasonCollectionViaAsiunableScreenReason", ((_unableScreenReasonCollectionViaAsiunableScreenReason!=null) && (_unableScreenReasonCollectionViaAsiunableScreenReason.Count>0) && !this.MarkedForDeletion)?_unableScreenReasonCollectionViaAsiunableScreenReason:null);
				info.AddValue("_aaatestFindings", (!this.MarkedForDeletion?_aaatestFindings:null));
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
		public bool TestOriginalFieldValueForNull(AsitestResultsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AsitestResultsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AsitestResultsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ASIRawDataReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAsirawDataReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ASIRawDataReadingFields.AsitestId, null, ComparisonOperator.Equal, this.AsitestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AsitestIncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAsitestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AsitestIncidentalFindingsFields.AsitestId, null, ComparisonOperator.Equal, this.AsitestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AsiunableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAsiunableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AsiunableScreenReasonFields.AsitestId, null, ComparisonOperator.Equal, this.AsitestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CarotidArteryTestRecommendation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCarotidArteryTestRecommendation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestRecommendationFields.CarotidArteryTestId, null, ComparisonOperator.Equal, this.AsitestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingsCollectionViaAsitestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingsCollectionViaAsitestIncidentalFindings"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AsitestResultsFields.AsitestId, null, ComparisonOperator.Equal, this.AsitestId, "AsitestResultsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UnableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUnableScreenReasonCollectionViaAsiunableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UnableScreenReasonCollectionViaAsiunableScreenReason"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AsitestResultsFields.AsitestId, null, ComparisonOperator.Equal, this.AsitestId, "AsitestResultsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AaatestFindings' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAaatestFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AaatestFindingsFields.AaatestFindingsId, null, ComparisonOperator.Equal, this.AsitestFindingsId));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.AsitestResultsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AsitestResultsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._asirawDataReading);
			collectionsQueue.Enqueue(this._asitestIncidentalFindings);
			collectionsQueue.Enqueue(this._asiunableScreenReason);
			collectionsQueue.Enqueue(this._carotidArteryTestRecommendation);
			collectionsQueue.Enqueue(this._incidentalFindingsCollectionViaAsitestIncidentalFindings);
			collectionsQueue.Enqueue(this._unableScreenReasonCollectionViaAsiunableScreenReason);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._asirawDataReading = (EntityCollection<ASIRawDataReadingEntity>) collectionsQueue.Dequeue();
			this._asitestIncidentalFindings = (EntityCollection<AsitestIncidentalFindingsEntity>) collectionsQueue.Dequeue();
			this._asiunableScreenReason = (EntityCollection<AsiunableScreenReasonEntity>) collectionsQueue.Dequeue();
			this._carotidArteryTestRecommendation = (EntityCollection<CarotidArteryTestRecommendationEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingsCollectionViaAsitestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>) collectionsQueue.Dequeue();
			this._unableScreenReasonCollectionViaAsiunableScreenReason = (EntityCollection<UnableScreenReasonEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._asirawDataReading != null)
			{
				return true;
			}
			if (this._asitestIncidentalFindings != null)
			{
				return true;
			}
			if (this._asiunableScreenReason != null)
			{
				return true;
			}
			if (this._carotidArteryTestRecommendation != null)
			{
				return true;
			}
			if (this._incidentalFindingsCollectionViaAsitestIncidentalFindings != null)
			{
				return true;
			}
			if (this._unableScreenReasonCollectionViaAsiunableScreenReason != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ASIRawDataReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ASIRawDataReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AsitestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsitestIncidentalFindingsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AsiunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsiunableScreenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CarotidArteryTestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestRecommendationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UnableScreenReasonEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AaatestFindings", _aaatestFindings);
			toReturn.Add("CustomerEventTests", _customerEventTests);
			toReturn.Add("AsirawDataReading", _asirawDataReading);
			toReturn.Add("AsitestIncidentalFindings", _asitestIncidentalFindings);
			toReturn.Add("AsiunableScreenReason", _asiunableScreenReason);
			toReturn.Add("CarotidArteryTestRecommendation", _carotidArteryTestRecommendation);
			toReturn.Add("IncidentalFindingsCollectionViaAsitestIncidentalFindings", _incidentalFindingsCollectionViaAsitestIncidentalFindings);
			toReturn.Add("UnableScreenReasonCollectionViaAsiunableScreenReason", _unableScreenReasonCollectionViaAsiunableScreenReason);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_asirawDataReading!=null)
			{
				_asirawDataReading.ActiveContext = base.ActiveContext;
			}
			if(_asitestIncidentalFindings!=null)
			{
				_asitestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_asiunableScreenReason!=null)
			{
				_asiunableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_carotidArteryTestRecommendation!=null)
			{
				_carotidArteryTestRecommendation.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingsCollectionViaAsitestIncidentalFindings!=null)
			{
				_incidentalFindingsCollectionViaAsitestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_unableScreenReasonCollectionViaAsiunableScreenReason!=null)
			{
				_unableScreenReasonCollectionViaAsiunableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_aaatestFindings!=null)
			{
				_aaatestFindings.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTests!=null)
			{
				_customerEventTests.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_asirawDataReading = null;
			_asitestIncidentalFindings = null;
			_asiunableScreenReason = null;
			_carotidArteryTestRecommendation = null;
			_incidentalFindingsCollectionViaAsitestIncidentalFindings = null;
			_unableScreenReasonCollectionViaAsiunableScreenReason = null;
			_aaatestFindings = null;
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

			_fieldsCustomProperties.Add("AsitestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Asi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Pattern", fieldHashtable);
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

			_fieldsCustomProperties.Add("AsitestFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TechnicianRemarks", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnableToScreen", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedById", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedByRole", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualAsi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualPattern", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualStandardFinding", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTestNotPerformed", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _aaatestFindings</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAaatestFindings(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _aaatestFindings, new PropertyChangedEventHandler( OnAaatestFindingsPropertyChanged ), "AaatestFindings", AsitestResultsEntity.Relations.AaatestFindingsEntityUsingAsitestFindingsId, true, signalRelatedEntity, "AsitestResults", resetFKFields, new int[] { (int)AsitestResultsFieldIndex.AsitestFindingsId } );		
			_aaatestFindings = null;
		}

		/// <summary> setups the sync logic for member _aaatestFindings</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAaatestFindings(IEntity2 relatedEntity)
		{
			if(_aaatestFindings!=relatedEntity)
			{
				DesetupSyncAaatestFindings(true, true);
				_aaatestFindings = (AaatestFindingsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _aaatestFindings, new PropertyChangedEventHandler( OnAaatestFindingsPropertyChanged ), "AaatestFindings", AsitestResultsEntity.Relations.AaatestFindingsEntityUsingAsitestFindingsId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAaatestFindingsPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", AsitestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, signalRelatedEntity, "AsitestResults", resetFKFields, new int[] { (int)AsitestResultsFieldIndex.CustomerEventTestId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", AsitestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this AsitestResultsEntity</param>
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
		public  static AsitestResultsRelations Relations
		{
			get	{ return new AsitestResultsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ASIRawDataReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAsirawDataReading
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ASIRawDataReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ASIRawDataReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("AsirawDataReading")[0], (int)HealthYes.Data.EntityType.AsitestResultsEntity, (int)HealthYes.Data.EntityType.ASIRawDataReadingEntity, 0, null, null, null, null, "AsirawDataReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AsitestIncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAsitestIncidentalFindings
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AsitestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsitestIncidentalFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("AsitestIncidentalFindings")[0], (int)HealthYes.Data.EntityType.AsitestResultsEntity, (int)HealthYes.Data.EntityType.AsitestIncidentalFindingsEntity, 0, null, null, null, null, "AsitestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AsiunableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAsiunableScreenReason
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AsiunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsiunableScreenReasonEntityFactory))),
					(IEntityRelation)GetRelationsForField("AsiunableScreenReason")[0], (int)HealthYes.Data.EntityType.AsitestResultsEntity, (int)HealthYes.Data.EntityType.AsiunableScreenReasonEntity, 0, null, null, null, null, "AsiunableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CarotidArteryTestRecommendation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCarotidArteryTestRecommendation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CarotidArteryTestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestRecommendationEntityFactory))),
					(IEntityRelation)GetRelationsForField("CarotidArteryTestRecommendation")[0], (int)HealthYes.Data.EntityType.AsitestResultsEntity, (int)HealthYes.Data.EntityType.CarotidArteryTestRecommendationEntity, 0, null, null, null, null, "CarotidArteryTestRecommendation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingsCollectionViaAsitestIncidentalFindings
		{
			get
			{
				IEntityRelation intermediateRelation = AsitestResultsEntity.Relations.AsitestIncidentalFindingsEntityUsingAsitestId;
				intermediateRelation.SetAliases(string.Empty, "AsitestIncidentalFindings_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.AsitestResultsEntity, (int)HealthYes.Data.EntityType.IncidentalFindingsEntity, 0, null, null, GetRelationsForField("IncidentalFindingsCollectionViaAsitestIncidentalFindings"), null, "IncidentalFindingsCollectionViaAsitestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UnableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUnableScreenReasonCollectionViaAsiunableScreenReason
		{
			get
			{
				IEntityRelation intermediateRelation = AsitestResultsEntity.Relations.AsiunableScreenReasonEntityUsingAsitestId;
				intermediateRelation.SetAliases(string.Empty, "AsiunableScreenReason_");
				return new PrefetchPathElement2(new EntityCollection<UnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UnableScreenReasonEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.AsitestResultsEntity, (int)HealthYes.Data.EntityType.UnableScreenReasonEntity, 0, null, null, GetRelationsForField("UnableScreenReasonCollectionViaAsiunableScreenReason"), null, "UnableScreenReasonCollectionViaAsiunableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AaatestFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAaatestFindings
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AaatestFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("AaatestFindings")[0], (int)HealthYes.Data.EntityType.AsitestResultsEntity, (int)HealthYes.Data.EntityType.AaatestFindingsEntity, 0, null, null, null, null, "AaatestFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("CustomerEventTests")[0], (int)HealthYes.Data.EntityType.AsitestResultsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, null, null, "CustomerEventTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AsitestResultsEntity.CustomProperties;}
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
			get { return AsitestResultsEntity.FieldsCustomProperties;}
		}

		/// <summary> The AsitestId property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."ASITestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 AsitestId
		{
			get { return (System.Int64)GetValue((int)AsitestResultsFieldIndex.AsitestId, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.AsitestId, value); }
		}

		/// <summary> The CustomerEventTestId property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."CustomerEventTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventTestId
		{
			get { return (System.Int64)GetValue((int)AsitestResultsFieldIndex.CustomerEventTestId, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.CustomerEventTestId, value); }
		}

		/// <summary> The Asi property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."ASI"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Asi
		{
			get { return (Nullable<System.Int32>)GetValue((int)AsitestResultsFieldIndex.Asi, false); }
			set	{ SetValue((int)AsitestResultsFieldIndex.Asi, value); }
		}

		/// <summary> The Pattern property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."Pattern"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Pattern
		{
			get { return (System.String)GetValue((int)AsitestResultsFieldIndex.Pattern, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.Pattern, value); }
		}

		/// <summary> The EvaluationStatus property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."EvaluationStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> EvaluationStatus
		{
			get { return (Nullable<System.Byte>)GetValue((int)AsitestResultsFieldIndex.EvaluationStatus, false); }
			set	{ SetValue((int)AsitestResultsFieldIndex.EvaluationStatus, value); }
		}

		/// <summary> The DateCreated property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)AsitestResultsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)AsitestResultsFieldIndex.DateModified, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsManual property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."IsManual"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsManual
		{
			get { return (System.Boolean)GetValue((int)AsitestResultsFieldIndex.IsManual, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.IsManual, value); }
		}

		/// <summary> The IsCritical property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."IsCritical"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsCritical
		{
			get { return (System.Boolean)GetValue((int)AsitestResultsFieldIndex.IsCritical, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.IsCritical, value); }
		}

		/// <summary> The IsPartial property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."IsPartial"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPartial
		{
			get { return (System.Boolean)GetValue((int)AsitestResultsFieldIndex.IsPartial, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.IsPartial, value); }
		}

		/// <summary> The AsitestFindingsId property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."ASITestFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> AsitestFindingsId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AsitestResultsFieldIndex.AsitestFindingsId, false); }
			set	{ SetValue((int)AsitestResultsFieldIndex.AsitestFindingsId, value); }
		}

		/// <summary> The TechnicianRemarks property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."TechnicianRemarks"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TechnicianRemarks
		{
			get { return (System.String)GetValue((int)AsitestResultsFieldIndex.TechnicianRemarks, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.TechnicianRemarks, value); }
		}

		/// <summary> The UnableToScreen property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."UnableToScreen"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean UnableToScreen
		{
			get { return (System.Boolean)GetValue((int)AsitestResultsFieldIndex.UnableToScreen, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.UnableToScreen, value); }
		}

		/// <summary> The RecordedById property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."RecordedByID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RecordedById
		{
			get { return (Nullable<System.Int64>)GetValue((int)AsitestResultsFieldIndex.RecordedById, false); }
			set	{ SetValue((int)AsitestResultsFieldIndex.RecordedById, value); }
		}

		/// <summary> The RecordedByRole property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."RecordedByRole"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> RecordedByRole
		{
			get { return (Nullable<System.Byte>)GetValue((int)AsitestResultsFieldIndex.RecordedByRole, false); }
			set	{ SetValue((int)AsitestResultsFieldIndex.RecordedByRole, value); }
		}

		/// <summary> The IsManualAsi property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."IsManualASI"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualAsi
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AsitestResultsFieldIndex.IsManualAsi, false); }
			set	{ SetValue((int)AsitestResultsFieldIndex.IsManualAsi, value); }
		}

		/// <summary> The IsManualPattern property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."IsManualPattern"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualPattern
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AsitestResultsFieldIndex.IsManualPattern, false); }
			set	{ SetValue((int)AsitestResultsFieldIndex.IsManualPattern, value); }
		}

		/// <summary> The IsManualStandardFinding property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."IsManualStandardFinding"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualStandardFinding
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AsitestResultsFieldIndex.IsManualStandardFinding, false); }
			set	{ SetValue((int)AsitestResultsFieldIndex.IsManualStandardFinding, value); }
		}

		/// <summary> The IsTestNotPerformed property of the Entity AsitestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestResults_Legacy"."IsTestNotPerformed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTestNotPerformed
		{
			get { return (System.Boolean)GetValue((int)AsitestResultsFieldIndex.IsTestNotPerformed, true); }
			set	{ SetValue((int)AsitestResultsFieldIndex.IsTestNotPerformed, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ASIRawDataReadingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ASIRawDataReadingEntity))]
		public virtual EntityCollection<ASIRawDataReadingEntity> AsirawDataReading
		{
			get
			{
				if(_asirawDataReading==null)
				{
					_asirawDataReading = new EntityCollection<ASIRawDataReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ASIRawDataReadingEntityFactory)));
					_asirawDataReading.SetContainingEntityInfo(this, "AsitestResults");
				}
				return _asirawDataReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AsitestIncidentalFindingsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AsitestIncidentalFindingsEntity))]
		public virtual EntityCollection<AsitestIncidentalFindingsEntity> AsitestIncidentalFindings
		{
			get
			{
				if(_asitestIncidentalFindings==null)
				{
					_asitestIncidentalFindings = new EntityCollection<AsitestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsitestIncidentalFindingsEntityFactory)));
					_asitestIncidentalFindings.SetContainingEntityInfo(this, "AsitestResults");
				}
				return _asitestIncidentalFindings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AsiunableScreenReasonEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AsiunableScreenReasonEntity))]
		public virtual EntityCollection<AsiunableScreenReasonEntity> AsiunableScreenReason
		{
			get
			{
				if(_asiunableScreenReason==null)
				{
					_asiunableScreenReason = new EntityCollection<AsiunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsiunableScreenReasonEntityFactory)));
					_asiunableScreenReason.SetContainingEntityInfo(this, "AsitestResults");
				}
				return _asiunableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CarotidArteryTestRecommendationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CarotidArteryTestRecommendationEntity))]
		public virtual EntityCollection<CarotidArteryTestRecommendationEntity> CarotidArteryTestRecommendation
		{
			get
			{
				if(_carotidArteryTestRecommendation==null)
				{
					_carotidArteryTestRecommendation = new EntityCollection<CarotidArteryTestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestRecommendationEntityFactory)));
					_carotidArteryTestRecommendation.SetContainingEntityInfo(this, "AsitestResults");
				}
				return _carotidArteryTestRecommendation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingsEntity))]
		public virtual EntityCollection<IncidentalFindingsEntity> IncidentalFindingsCollectionViaAsitestIncidentalFindings
		{
			get
			{
				if(_incidentalFindingsCollectionViaAsitestIncidentalFindings==null)
				{
					_incidentalFindingsCollectionViaAsitestIncidentalFindings = new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory)));
					_incidentalFindingsCollectionViaAsitestIncidentalFindings.IsReadOnly=true;
				}
				return _incidentalFindingsCollectionViaAsitestIncidentalFindings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UnableScreenReasonEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UnableScreenReasonEntity))]
		public virtual EntityCollection<UnableScreenReasonEntity> UnableScreenReasonCollectionViaAsiunableScreenReason
		{
			get
			{
				if(_unableScreenReasonCollectionViaAsiunableScreenReason==null)
				{
					_unableScreenReasonCollectionViaAsiunableScreenReason = new EntityCollection<UnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UnableScreenReasonEntityFactory)));
					_unableScreenReasonCollectionViaAsiunableScreenReason.IsReadOnly=true;
				}
				return _unableScreenReasonCollectionViaAsiunableScreenReason;
			}
		}

		/// <summary> Gets / sets related entity of type 'AaatestFindingsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AaatestFindingsEntity AaatestFindings
		{
			get
			{
				return _aaatestFindings;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAaatestFindings(value);
				}
				else
				{
					if(value==null)
					{
						if(_aaatestFindings != null)
						{
							_aaatestFindings.UnsetRelatedEntity(this, "AsitestResults");
						}
					}
					else
					{
						if(_aaatestFindings!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AsitestResults");
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
							_customerEventTests.UnsetRelatedEntity(this, "AsitestResults");
						}
					}
					else
					{
						if(_customerEventTests!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AsitestResults");
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
			get { return (int)HealthYes.Data.EntityType.AsitestResultsEntity; }
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
