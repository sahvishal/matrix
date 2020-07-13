///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:26 AM
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
	/// Entity class which represents the entity 'AaatestResults'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AaatestResultsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AaatestIncidentalFindingsEntity> _aaatestIncidentalFindings;
		private EntityCollection<AaaunableScreenReasonEntity> _aaaunableScreenReason;
		private EntityCollection<PadtestRecommendationEntity> _padtestRecommendation;
		private EntityCollection<IncidentalFindingsEntity> _incidentalFindingsCollectionViaAaatestIncidentalFindings;
		private EntityCollection<UnableScreenReasonEntity> _unableScreenReasonCollectionViaAaaunableScreenReason;
		private CustomerEventTestsEntity _customerEventTests;
		private OsteoporosisTestFindingsEntity _osteoporosisTestFindings;

		
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
			/// <summary>Member name OsteoporosisTestFindings</summary>
			public static readonly string OsteoporosisTestFindings = "OsteoporosisTestFindings";
			/// <summary>Member name AaatestIncidentalFindings</summary>
			public static readonly string AaatestIncidentalFindings = "AaatestIncidentalFindings";
			/// <summary>Member name AaaunableScreenReason</summary>
			public static readonly string AaaunableScreenReason = "AaaunableScreenReason";
			/// <summary>Member name PadtestRecommendation</summary>
			public static readonly string PadtestRecommendation = "PadtestRecommendation";
			/// <summary>Member name IncidentalFindingsCollectionViaAaatestIncidentalFindings</summary>
			public static readonly string IncidentalFindingsCollectionViaAaatestIncidentalFindings = "IncidentalFindingsCollectionViaAaatestIncidentalFindings";
			/// <summary>Member name UnableScreenReasonCollectionViaAaaunableScreenReason</summary>
			public static readonly string UnableScreenReasonCollectionViaAaaunableScreenReason = "UnableScreenReasonCollectionViaAaaunableScreenReason";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AaatestResultsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AaatestResultsEntity():base("AaatestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AaatestResultsEntity(IEntityFields2 fields):base("AaatestResultsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AaatestResultsEntity</param>
		public AaatestResultsEntity(IValidator validator):base("AaatestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="aaatestId">PK value for AaatestResults which data should be fetched into this AaatestResults object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AaatestResultsEntity(System.Int64 aaatestId):base("AaatestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AaatestId = aaatestId;
		}

		/// <summary> CTor</summary>
		/// <param name="aaatestId">PK value for AaatestResults which data should be fetched into this AaatestResults object</param>
		/// <param name="validator">The custom validator object for this AaatestResultsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AaatestResultsEntity(System.Int64 aaatestId, IValidator validator):base("AaatestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AaatestId = aaatestId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AaatestResultsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_aaatestIncidentalFindings = (EntityCollection<AaatestIncidentalFindingsEntity>)info.GetValue("_aaatestIncidentalFindings", typeof(EntityCollection<AaatestIncidentalFindingsEntity>));
				_aaaunableScreenReason = (EntityCollection<AaaunableScreenReasonEntity>)info.GetValue("_aaaunableScreenReason", typeof(EntityCollection<AaaunableScreenReasonEntity>));
				_padtestRecommendation = (EntityCollection<PadtestRecommendationEntity>)info.GetValue("_padtestRecommendation", typeof(EntityCollection<PadtestRecommendationEntity>));
				_incidentalFindingsCollectionViaAaatestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>)info.GetValue("_incidentalFindingsCollectionViaAaatestIncidentalFindings", typeof(EntityCollection<IncidentalFindingsEntity>));
				_unableScreenReasonCollectionViaAaaunableScreenReason = (EntityCollection<UnableScreenReasonEntity>)info.GetValue("_unableScreenReasonCollectionViaAaaunableScreenReason", typeof(EntityCollection<UnableScreenReasonEntity>));
				_customerEventTests = (CustomerEventTestsEntity)info.GetValue("_customerEventTests", typeof(CustomerEventTestsEntity));
				if(_customerEventTests!=null)
				{
					_customerEventTests.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_osteoporosisTestFindings = (OsteoporosisTestFindingsEntity)info.GetValue("_osteoporosisTestFindings", typeof(OsteoporosisTestFindingsEntity));
				if(_osteoporosisTestFindings!=null)
				{
					_osteoporosisTestFindings.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AaatestResultsFieldIndex)fieldIndex)
			{
				case AaatestResultsFieldIndex.CustomerEventTestId:
					DesetupSyncCustomerEventTests(true, false);
					break;
				case AaatestResultsFieldIndex.AaatestFindingsId:
					DesetupSyncOsteoporosisTestFindings(true, false);
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
				case "OsteoporosisTestFindings":
					this.OsteoporosisTestFindings = (OsteoporosisTestFindingsEntity)entity;
					break;
				case "AaatestIncidentalFindings":
					this.AaatestIncidentalFindings.Add((AaatestIncidentalFindingsEntity)entity);
					break;
				case "AaaunableScreenReason":
					this.AaaunableScreenReason.Add((AaaunableScreenReasonEntity)entity);
					break;
				case "PadtestRecommendation":
					this.PadtestRecommendation.Add((PadtestRecommendationEntity)entity);
					break;
				case "IncidentalFindingsCollectionViaAaatestIncidentalFindings":
					this.IncidentalFindingsCollectionViaAaatestIncidentalFindings.IsReadOnly = false;
					this.IncidentalFindingsCollectionViaAaatestIncidentalFindings.Add((IncidentalFindingsEntity)entity);
					this.IncidentalFindingsCollectionViaAaatestIncidentalFindings.IsReadOnly = true;
					break;
				case "UnableScreenReasonCollectionViaAaaunableScreenReason":
					this.UnableScreenReasonCollectionViaAaaunableScreenReason.IsReadOnly = false;
					this.UnableScreenReasonCollectionViaAaaunableScreenReason.Add((UnableScreenReasonEntity)entity);
					this.UnableScreenReasonCollectionViaAaaunableScreenReason.IsReadOnly = true;
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
			return AaatestResultsEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(AaatestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId);
					break;
				case "OsteoporosisTestFindings":
					toReturn.Add(AaatestResultsEntity.Relations.OsteoporosisTestFindingsEntityUsingAaatestFindingsId);
					break;
				case "AaatestIncidentalFindings":
					toReturn.Add(AaatestResultsEntity.Relations.AaatestIncidentalFindingsEntityUsingAaatestId);
					break;
				case "AaaunableScreenReason":
					toReturn.Add(AaatestResultsEntity.Relations.AaaunableScreenReasonEntityUsingAaatestId);
					break;
				case "PadtestRecommendation":
					toReturn.Add(AaatestResultsEntity.Relations.PadtestRecommendationEntityUsingPadtestId);
					break;
				case "IncidentalFindingsCollectionViaAaatestIncidentalFindings":
					toReturn.Add(AaatestResultsEntity.Relations.AaatestIncidentalFindingsEntityUsingAaatestId, "AaatestResultsEntity__", "AaatestIncidentalFindings_", JoinHint.None);
					toReturn.Add(AaatestIncidentalFindingsEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingsId, "AaatestIncidentalFindings_", string.Empty, JoinHint.None);
					break;
				case "UnableScreenReasonCollectionViaAaaunableScreenReason":
					toReturn.Add(AaatestResultsEntity.Relations.AaaunableScreenReasonEntityUsingAaatestId, "AaatestResultsEntity__", "AaaunableScreenReason_", JoinHint.None);
					toReturn.Add(AaaunableScreenReasonEntity.Relations.UnableScreenReasonEntityUsingUnableScreenReasonId, "AaaunableScreenReason_", string.Empty, JoinHint.None);
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
				case "OsteoporosisTestFindings":
					SetupSyncOsteoporosisTestFindings(relatedEntity);
					break;
				case "AaatestIncidentalFindings":
					this.AaatestIncidentalFindings.Add((AaatestIncidentalFindingsEntity)relatedEntity);
					break;
				case "AaaunableScreenReason":
					this.AaaunableScreenReason.Add((AaaunableScreenReasonEntity)relatedEntity);
					break;
				case "PadtestRecommendation":
					this.PadtestRecommendation.Add((PadtestRecommendationEntity)relatedEntity);
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
				case "OsteoporosisTestFindings":
					DesetupSyncOsteoporosisTestFindings(false, true);
					break;
				case "AaatestIncidentalFindings":
					base.PerformRelatedEntityRemoval(this.AaatestIncidentalFindings, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AaaunableScreenReason":
					base.PerformRelatedEntityRemoval(this.AaaunableScreenReason, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PadtestRecommendation":
					base.PerformRelatedEntityRemoval(this.PadtestRecommendation, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_osteoporosisTestFindings!=null)
			{
				toReturn.Add(_osteoporosisTestFindings);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AaatestIncidentalFindings);
			toReturn.Add(this.AaaunableScreenReason);
			toReturn.Add(this.PadtestRecommendation);

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
				info.AddValue("_aaatestIncidentalFindings", ((_aaatestIncidentalFindings!=null) && (_aaatestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_aaatestIncidentalFindings:null);
				info.AddValue("_aaaunableScreenReason", ((_aaaunableScreenReason!=null) && (_aaaunableScreenReason.Count>0) && !this.MarkedForDeletion)?_aaaunableScreenReason:null);
				info.AddValue("_padtestRecommendation", ((_padtestRecommendation!=null) && (_padtestRecommendation.Count>0) && !this.MarkedForDeletion)?_padtestRecommendation:null);
				info.AddValue("_incidentalFindingsCollectionViaAaatestIncidentalFindings", ((_incidentalFindingsCollectionViaAaatestIncidentalFindings!=null) && (_incidentalFindingsCollectionViaAaatestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_incidentalFindingsCollectionViaAaatestIncidentalFindings:null);
				info.AddValue("_unableScreenReasonCollectionViaAaaunableScreenReason", ((_unableScreenReasonCollectionViaAaaunableScreenReason!=null) && (_unableScreenReasonCollectionViaAaaunableScreenReason.Count>0) && !this.MarkedForDeletion)?_unableScreenReasonCollectionViaAaaunableScreenReason:null);
				info.AddValue("_customerEventTests", (!this.MarkedForDeletion?_customerEventTests:null));
				info.AddValue("_osteoporosisTestFindings", (!this.MarkedForDeletion?_osteoporosisTestFindings:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AaatestResultsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AaatestResultsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AaatestResultsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AaatestIncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAaatestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AaatestIncidentalFindingsFields.AaatestId, null, ComparisonOperator.Equal, this.AaatestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AaaunableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAaaunableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AaaunableScreenReasonFields.AaatestId, null, ComparisonOperator.Equal, this.AaatestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PadtestRecommendation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPadtestRecommendation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PadtestRecommendationFields.PadtestId, null, ComparisonOperator.Equal, this.AaatestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingsCollectionViaAaatestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingsCollectionViaAaatestIncidentalFindings"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AaatestResultsFields.AaatestId, null, ComparisonOperator.Equal, this.AaatestId, "AaatestResultsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UnableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUnableScreenReasonCollectionViaAaaunableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UnableScreenReasonCollectionViaAaaunableScreenReason"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AaatestResultsFields.AaatestId, null, ComparisonOperator.Equal, this.AaatestId, "AaatestResultsEntity__"));
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
		/// the related entity of type 'OsteoporosisTestFindings' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOsteoporosisTestFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OsteoporosisTestFindingsFields.OsteoporosisTestFindingsId, null, ComparisonOperator.Equal, this.AaatestFindingsId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.AaatestResultsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AaatestResultsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._aaatestIncidentalFindings);
			collectionsQueue.Enqueue(this._aaaunableScreenReason);
			collectionsQueue.Enqueue(this._padtestRecommendation);
			collectionsQueue.Enqueue(this._incidentalFindingsCollectionViaAaatestIncidentalFindings);
			collectionsQueue.Enqueue(this._unableScreenReasonCollectionViaAaaunableScreenReason);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._aaatestIncidentalFindings = (EntityCollection<AaatestIncidentalFindingsEntity>) collectionsQueue.Dequeue();
			this._aaaunableScreenReason = (EntityCollection<AaaunableScreenReasonEntity>) collectionsQueue.Dequeue();
			this._padtestRecommendation = (EntityCollection<PadtestRecommendationEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingsCollectionViaAaatestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>) collectionsQueue.Dequeue();
			this._unableScreenReasonCollectionViaAaaunableScreenReason = (EntityCollection<UnableScreenReasonEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._aaatestIncidentalFindings != null)
			{
				return true;
			}
			if (this._aaaunableScreenReason != null)
			{
				return true;
			}
			if (this._padtestRecommendation != null)
			{
				return true;
			}
			if (this._incidentalFindingsCollectionViaAaatestIncidentalFindings != null)
			{
				return true;
			}
			if (this._unableScreenReasonCollectionViaAaaunableScreenReason != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AaatestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestIncidentalFindingsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AaaunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaaunableScreenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PadtestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PadtestRecommendationEntityFactory))) : null);
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
			toReturn.Add("CustomerEventTests", _customerEventTests);
			toReturn.Add("OsteoporosisTestFindings", _osteoporosisTestFindings);
			toReturn.Add("AaatestIncidentalFindings", _aaatestIncidentalFindings);
			toReturn.Add("AaaunableScreenReason", _aaaunableScreenReason);
			toReturn.Add("PadtestRecommendation", _padtestRecommendation);
			toReturn.Add("IncidentalFindingsCollectionViaAaatestIncidentalFindings", _incidentalFindingsCollectionViaAaatestIncidentalFindings);
			toReturn.Add("UnableScreenReasonCollectionViaAaaunableScreenReason", _unableScreenReasonCollectionViaAaaunableScreenReason);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_aaatestIncidentalFindings!=null)
			{
				_aaatestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_aaaunableScreenReason!=null)
			{
				_aaaunableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_padtestRecommendation!=null)
			{
				_padtestRecommendation.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingsCollectionViaAaatestIncidentalFindings!=null)
			{
				_incidentalFindingsCollectionViaAaatestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_unableScreenReasonCollectionViaAaaunableScreenReason!=null)
			{
				_unableScreenReasonCollectionViaAaaunableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTests!=null)
			{
				_customerEventTests.ActiveContext = base.ActiveContext;
			}
			if(_osteoporosisTestFindings!=null)
			{
				_osteoporosisTestFindings.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_aaatestIncidentalFindings = null;
			_aaaunableScreenReason = null;
			_padtestRecommendation = null;
			_incidentalFindingsCollectionViaAaatestIncidentalFindings = null;
			_unableScreenReasonCollectionViaAaaunableScreenReason = null;
			_customerEventTests = null;
			_osteoporosisTestFindings = null;

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

			_fieldsCustomProperties.Add("AaatestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EvaluationStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AortaSize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsFusiform", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsSaccular", fieldHashtable);
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

			_fieldsCustomProperties.Add("AaatestFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TechnicianRemarks", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnableToScreen", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedById", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedByRole", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualAortaSize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualFusiform", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualSaccular", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualStandardFinding", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTestNotPerformed", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerEventTests</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventTests(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", AaatestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, signalRelatedEntity, "AaatestResults", resetFKFields, new int[] { (int)AaatestResultsFieldIndex.CustomerEventTestId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", AaatestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _osteoporosisTestFindings</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOsteoporosisTestFindings(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _osteoporosisTestFindings, new PropertyChangedEventHandler( OnOsteoporosisTestFindingsPropertyChanged ), "OsteoporosisTestFindings", AaatestResultsEntity.Relations.OsteoporosisTestFindingsEntityUsingAaatestFindingsId, true, signalRelatedEntity, "AaatestResults", resetFKFields, new int[] { (int)AaatestResultsFieldIndex.AaatestFindingsId } );		
			_osteoporosisTestFindings = null;
		}

		/// <summary> setups the sync logic for member _osteoporosisTestFindings</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOsteoporosisTestFindings(IEntity2 relatedEntity)
		{
			if(_osteoporosisTestFindings!=relatedEntity)
			{
				DesetupSyncOsteoporosisTestFindings(true, true);
				_osteoporosisTestFindings = (OsteoporosisTestFindingsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _osteoporosisTestFindings, new PropertyChangedEventHandler( OnOsteoporosisTestFindingsPropertyChanged ), "OsteoporosisTestFindings", AaatestResultsEntity.Relations.OsteoporosisTestFindingsEntityUsingAaatestFindingsId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOsteoporosisTestFindingsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AaatestResultsEntity</param>
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
		public  static AaatestResultsRelations Relations
		{
			get	{ return new AaatestResultsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AaatestIncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAaatestIncidentalFindings
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AaatestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestIncidentalFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("AaatestIncidentalFindings")[0], (int)HealthYes.Data.EntityType.AaatestResultsEntity, (int)HealthYes.Data.EntityType.AaatestIncidentalFindingsEntity, 0, null, null, null, null, "AaatestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AaaunableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAaaunableScreenReason
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AaaunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaaunableScreenReasonEntityFactory))),
					(IEntityRelation)GetRelationsForField("AaaunableScreenReason")[0], (int)HealthYes.Data.EntityType.AaatestResultsEntity, (int)HealthYes.Data.EntityType.AaaunableScreenReasonEntity, 0, null, null, null, null, "AaaunableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PadtestRecommendation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPadtestRecommendation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PadtestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PadtestRecommendationEntityFactory))),
					(IEntityRelation)GetRelationsForField("PadtestRecommendation")[0], (int)HealthYes.Data.EntityType.AaatestResultsEntity, (int)HealthYes.Data.EntityType.PadtestRecommendationEntity, 0, null, null, null, null, "PadtestRecommendation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingsCollectionViaAaatestIncidentalFindings
		{
			get
			{
				IEntityRelation intermediateRelation = AaatestResultsEntity.Relations.AaatestIncidentalFindingsEntityUsingAaatestId;
				intermediateRelation.SetAliases(string.Empty, "AaatestIncidentalFindings_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.AaatestResultsEntity, (int)HealthYes.Data.EntityType.IncidentalFindingsEntity, 0, null, null, GetRelationsForField("IncidentalFindingsCollectionViaAaatestIncidentalFindings"), null, "IncidentalFindingsCollectionViaAaatestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UnableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUnableScreenReasonCollectionViaAaaunableScreenReason
		{
			get
			{
				IEntityRelation intermediateRelation = AaatestResultsEntity.Relations.AaaunableScreenReasonEntityUsingAaatestId;
				intermediateRelation.SetAliases(string.Empty, "AaaunableScreenReason_");
				return new PrefetchPathElement2(new EntityCollection<UnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UnableScreenReasonEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.AaatestResultsEntity, (int)HealthYes.Data.EntityType.UnableScreenReasonEntity, 0, null, null, GetRelationsForField("UnableScreenReasonCollectionViaAaaunableScreenReason"), null, "UnableScreenReasonCollectionViaAaaunableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("CustomerEventTests")[0], (int)HealthYes.Data.EntityType.AaatestResultsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, null, null, "CustomerEventTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OsteoporosisTestFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOsteoporosisTestFindings
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("OsteoporosisTestFindings")[0], (int)HealthYes.Data.EntityType.AaatestResultsEntity, (int)HealthYes.Data.EntityType.OsteoporosisTestFindingsEntity, 0, null, null, null, null, "OsteoporosisTestFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AaatestResultsEntity.CustomProperties;}
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
			get { return AaatestResultsEntity.FieldsCustomProperties;}
		}

		/// <summary> The AaatestId property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."AAATestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 AaatestId
		{
			get { return (System.Int64)GetValue((int)AaatestResultsFieldIndex.AaatestId, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.AaatestId, value); }
		}

		/// <summary> The CustomerEventTestId property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."CustomerEventTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventTestId
		{
			get { return (System.Int64)GetValue((int)AaatestResultsFieldIndex.CustomerEventTestId, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.CustomerEventTestId, value); }
		}

		/// <summary> The EvaluationStatus property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."EvaluationStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EvaluationStatus
		{
			get { return (System.Int32)GetValue((int)AaatestResultsFieldIndex.EvaluationStatus, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.EvaluationStatus, value); }
		}

		/// <summary> The AortaSize property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."AortaSize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> AortaSize
		{
			get { return (Nullable<System.Decimal>)GetValue((int)AaatestResultsFieldIndex.AortaSize, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.AortaSize, value); }
		}

		/// <summary> The IsFusiform property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsFusiform"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsFusiform
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AaatestResultsFieldIndex.IsFusiform, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsFusiform, value); }
		}

		/// <summary> The IsSaccular property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsSaccular"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsSaccular
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AaatestResultsFieldIndex.IsSaccular, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsSaccular, value); }
		}

		/// <summary> The DateCreated property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)AaatestResultsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)AaatestResultsFieldIndex.DateModified, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsManual property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsManual"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsManual
		{
			get { return (System.Boolean)GetValue((int)AaatestResultsFieldIndex.IsManual, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsManual, value); }
		}

		/// <summary> The IsCritical property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsCritical"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsCritical
		{
			get { return (System.Boolean)GetValue((int)AaatestResultsFieldIndex.IsCritical, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsCritical, value); }
		}

		/// <summary> The IsPartial property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsPartial"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPartial
		{
			get { return (System.Boolean)GetValue((int)AaatestResultsFieldIndex.IsPartial, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsPartial, value); }
		}

		/// <summary> The AaatestFindingsId property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."AAATestFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> AaatestFindingsId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AaatestResultsFieldIndex.AaatestFindingsId, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.AaatestFindingsId, value); }
		}

		/// <summary> The TechnicianRemarks property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."TechnicianRemarks"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TechnicianRemarks
		{
			get { return (System.String)GetValue((int)AaatestResultsFieldIndex.TechnicianRemarks, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.TechnicianRemarks, value); }
		}

		/// <summary> The UnableToScreen property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."UnableToScreen"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean UnableToScreen
		{
			get { return (System.Boolean)GetValue((int)AaatestResultsFieldIndex.UnableToScreen, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.UnableToScreen, value); }
		}

		/// <summary> The RecordedById property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."RecordedByID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RecordedById
		{
			get { return (Nullable<System.Int64>)GetValue((int)AaatestResultsFieldIndex.RecordedById, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.RecordedById, value); }
		}

		/// <summary> The RecordedByRole property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."RecordedByRole"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> RecordedByRole
		{
			get { return (Nullable<System.Byte>)GetValue((int)AaatestResultsFieldIndex.RecordedByRole, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.RecordedByRole, value); }
		}

		/// <summary> The IsManualAortaSize property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsManualAortaSize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualAortaSize
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AaatestResultsFieldIndex.IsManualAortaSize, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsManualAortaSize, value); }
		}

		/// <summary> The IsManualFusiform property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsManualFusiform"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualFusiform
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AaatestResultsFieldIndex.IsManualFusiform, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsManualFusiform, value); }
		}

		/// <summary> The IsManualSaccular property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsManualSaccular"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualSaccular
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AaatestResultsFieldIndex.IsManualSaccular, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsManualSaccular, value); }
		}

		/// <summary> The IsManualStandardFinding property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsManualStandardFinding"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualStandardFinding
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AaatestResultsFieldIndex.IsManualStandardFinding, false); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsManualStandardFinding, value); }
		}

		/// <summary> The IsTestNotPerformed property of the Entity AaatestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestResults_Legacy"."IsTestNotPerformed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTestNotPerformed
		{
			get { return (System.Boolean)GetValue((int)AaatestResultsFieldIndex.IsTestNotPerformed, true); }
			set	{ SetValue((int)AaatestResultsFieldIndex.IsTestNotPerformed, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AaatestIncidentalFindingsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AaatestIncidentalFindingsEntity))]
		public virtual EntityCollection<AaatestIncidentalFindingsEntity> AaatestIncidentalFindings
		{
			get
			{
				if(_aaatestIncidentalFindings==null)
				{
					_aaatestIncidentalFindings = new EntityCollection<AaatestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestIncidentalFindingsEntityFactory)));
					_aaatestIncidentalFindings.SetContainingEntityInfo(this, "AaatestResults");
				}
				return _aaatestIncidentalFindings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AaaunableScreenReasonEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AaaunableScreenReasonEntity))]
		public virtual EntityCollection<AaaunableScreenReasonEntity> AaaunableScreenReason
		{
			get
			{
				if(_aaaunableScreenReason==null)
				{
					_aaaunableScreenReason = new EntityCollection<AaaunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaaunableScreenReasonEntityFactory)));
					_aaaunableScreenReason.SetContainingEntityInfo(this, "AaatestResults");
				}
				return _aaaunableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PadtestRecommendationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PadtestRecommendationEntity))]
		public virtual EntityCollection<PadtestRecommendationEntity> PadtestRecommendation
		{
			get
			{
				if(_padtestRecommendation==null)
				{
					_padtestRecommendation = new EntityCollection<PadtestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PadtestRecommendationEntityFactory)));
					_padtestRecommendation.SetContainingEntityInfo(this, "AaatestResults");
				}
				return _padtestRecommendation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingsEntity))]
		public virtual EntityCollection<IncidentalFindingsEntity> IncidentalFindingsCollectionViaAaatestIncidentalFindings
		{
			get
			{
				if(_incidentalFindingsCollectionViaAaatestIncidentalFindings==null)
				{
					_incidentalFindingsCollectionViaAaatestIncidentalFindings = new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory)));
					_incidentalFindingsCollectionViaAaatestIncidentalFindings.IsReadOnly=true;
				}
				return _incidentalFindingsCollectionViaAaatestIncidentalFindings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UnableScreenReasonEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UnableScreenReasonEntity))]
		public virtual EntityCollection<UnableScreenReasonEntity> UnableScreenReasonCollectionViaAaaunableScreenReason
		{
			get
			{
				if(_unableScreenReasonCollectionViaAaaunableScreenReason==null)
				{
					_unableScreenReasonCollectionViaAaaunableScreenReason = new EntityCollection<UnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UnableScreenReasonEntityFactory)));
					_unableScreenReasonCollectionViaAaaunableScreenReason.IsReadOnly=true;
				}
				return _unableScreenReasonCollectionViaAaaunableScreenReason;
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
							_customerEventTests.UnsetRelatedEntity(this, "AaatestResults");
						}
					}
					else
					{
						if(_customerEventTests!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AaatestResults");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OsteoporosisTestFindingsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OsteoporosisTestFindingsEntity OsteoporosisTestFindings
		{
			get
			{
				return _osteoporosisTestFindings;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOsteoporosisTestFindings(value);
				}
				else
				{
					if(value==null)
					{
						if(_osteoporosisTestFindings != null)
						{
							_osteoporosisTestFindings.UnsetRelatedEntity(this, "AaatestResults");
						}
					}
					else
					{
						if(_osteoporosisTestFindings!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AaatestResults");
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
			get { return (int)HealthYes.Data.EntityType.AaatestResultsEntity; }
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
