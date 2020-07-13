///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:23 AM
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
	/// Entity class which represents the entity 'CarotidArteryTestResults'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CarotidArteryTestResultsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AaatestRecommendationEntity> _aaatestRecommendation;
		private EntityCollection<CarotidArteryTestImagesEntity> _carotidArteryTestImages;
		private EntityCollection<CarotidArteryTestIncidentalFindingsEntity> _carotidArteryTestIncidentalFindings;
		private EntityCollection<CustomerEventTestsEntity> _customerEventTestsCollectionViaAaatestRecommendation;
		private EntityCollection<IncidentalFindingsEntity> _incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings;
		private CarotidArteryTestFindingsEntity _carotidArteryTestFindings_;
		private CarotidArteryTestFindingsEntity _carotidArteryTestFindings;
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
			/// <summary>Member name CarotidArteryTestFindings_</summary>
			public static readonly string CarotidArteryTestFindings_ = "CarotidArteryTestFindings_";
			/// <summary>Member name CarotidArteryTestFindings</summary>
			public static readonly string CarotidArteryTestFindings = "CarotidArteryTestFindings";
			/// <summary>Member name CustomerEventTests</summary>
			public static readonly string CustomerEventTests = "CustomerEventTests";
			/// <summary>Member name AaatestRecommendation</summary>
			public static readonly string AaatestRecommendation = "AaatestRecommendation";
			/// <summary>Member name CarotidArteryTestImages</summary>
			public static readonly string CarotidArteryTestImages = "CarotidArteryTestImages";
			/// <summary>Member name CarotidArteryTestIncidentalFindings</summary>
			public static readonly string CarotidArteryTestIncidentalFindings = "CarotidArteryTestIncidentalFindings";
			/// <summary>Member name CustomerEventTestsCollectionViaAaatestRecommendation</summary>
			public static readonly string CustomerEventTestsCollectionViaAaatestRecommendation = "CustomerEventTestsCollectionViaAaatestRecommendation";
			/// <summary>Member name IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings</summary>
			public static readonly string IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings = "IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CarotidArteryTestResultsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CarotidArteryTestResultsEntity():base("CarotidArteryTestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CarotidArteryTestResultsEntity(IEntityFields2 fields):base("CarotidArteryTestResultsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CarotidArteryTestResultsEntity</param>
		public CarotidArteryTestResultsEntity(IValidator validator):base("CarotidArteryTestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="carotidArteryTestId">PK value for CarotidArteryTestResults which data should be fetched into this CarotidArteryTestResults object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CarotidArteryTestResultsEntity(System.Int64 carotidArteryTestId):base("CarotidArteryTestResultsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CarotidArteryTestId = carotidArteryTestId;
		}

		/// <summary> CTor</summary>
		/// <param name="carotidArteryTestId">PK value for CarotidArteryTestResults which data should be fetched into this CarotidArteryTestResults object</param>
		/// <param name="validator">The custom validator object for this CarotidArteryTestResultsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CarotidArteryTestResultsEntity(System.Int64 carotidArteryTestId, IValidator validator):base("CarotidArteryTestResultsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CarotidArteryTestId = carotidArteryTestId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CarotidArteryTestResultsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_aaatestRecommendation = (EntityCollection<AaatestRecommendationEntity>)info.GetValue("_aaatestRecommendation", typeof(EntityCollection<AaatestRecommendationEntity>));
				_carotidArteryTestImages = (EntityCollection<CarotidArteryTestImagesEntity>)info.GetValue("_carotidArteryTestImages", typeof(EntityCollection<CarotidArteryTestImagesEntity>));
				_carotidArteryTestIncidentalFindings = (EntityCollection<CarotidArteryTestIncidentalFindingsEntity>)info.GetValue("_carotidArteryTestIncidentalFindings", typeof(EntityCollection<CarotidArteryTestIncidentalFindingsEntity>));
				_customerEventTestsCollectionViaAaatestRecommendation = (EntityCollection<CustomerEventTestsEntity>)info.GetValue("_customerEventTestsCollectionViaAaatestRecommendation", typeof(EntityCollection<CustomerEventTestsEntity>));
				_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>)info.GetValue("_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings", typeof(EntityCollection<IncidentalFindingsEntity>));
				_carotidArteryTestFindings_ = (CarotidArteryTestFindingsEntity)info.GetValue("_carotidArteryTestFindings_", typeof(CarotidArteryTestFindingsEntity));
				if(_carotidArteryTestFindings_!=null)
				{
					_carotidArteryTestFindings_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_carotidArteryTestFindings = (CarotidArteryTestFindingsEntity)info.GetValue("_carotidArteryTestFindings", typeof(CarotidArteryTestFindingsEntity));
				if(_carotidArteryTestFindings!=null)
				{
					_carotidArteryTestFindings.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CarotidArteryTestResultsFieldIndex)fieldIndex)
			{
				case CarotidArteryTestResultsFieldIndex.CustomerEventTestId:
					DesetupSyncCustomerEventTests(true, false);
					break;
				case CarotidArteryTestResultsFieldIndex.LcarotidArteryTestFindingsId:
					DesetupSyncCarotidArteryTestFindings(true, false);
					break;
				case CarotidArteryTestResultsFieldIndex.RcarotidArteryTestFindingsId:
					DesetupSyncCarotidArteryTestFindings_(true, false);
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
				case "CarotidArteryTestFindings_":
					this.CarotidArteryTestFindings_ = (CarotidArteryTestFindingsEntity)entity;
					break;
				case "CarotidArteryTestFindings":
					this.CarotidArteryTestFindings = (CarotidArteryTestFindingsEntity)entity;
					break;
				case "CustomerEventTests":
					this.CustomerEventTests = (CustomerEventTestsEntity)entity;
					break;
				case "AaatestRecommendation":
					this.AaatestRecommendation.Add((AaatestRecommendationEntity)entity);
					break;
				case "CarotidArteryTestImages":
					this.CarotidArteryTestImages.Add((CarotidArteryTestImagesEntity)entity);
					break;
				case "CarotidArteryTestIncidentalFindings":
					this.CarotidArteryTestIncidentalFindings.Add((CarotidArteryTestIncidentalFindingsEntity)entity);
					break;
				case "CustomerEventTestsCollectionViaAaatestRecommendation":
					this.CustomerEventTestsCollectionViaAaatestRecommendation.IsReadOnly = false;
					this.CustomerEventTestsCollectionViaAaatestRecommendation.Add((CustomerEventTestsEntity)entity);
					this.CustomerEventTestsCollectionViaAaatestRecommendation.IsReadOnly = true;
					break;
				case "IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings":
					this.IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings.IsReadOnly = false;
					this.IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings.Add((IncidentalFindingsEntity)entity);
					this.IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings.IsReadOnly = true;
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
			return CarotidArteryTestResultsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CarotidArteryTestFindings_":
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.CarotidArteryTestFindingsEntityUsingRcarotidArteryTestFindingsId);
					break;
				case "CarotidArteryTestFindings":
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.CarotidArteryTestFindingsEntityUsingLcarotidArteryTestFindingsId);
					break;
				case "CustomerEventTests":
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId);
					break;
				case "AaatestRecommendation":
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.AaatestRecommendationEntityUsingAaatestId);
					break;
				case "CarotidArteryTestImages":
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.CarotidArteryTestImagesEntityUsingCarotidArteryTestId);
					break;
				case "CarotidArteryTestIncidentalFindings":
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.CarotidArteryTestIncidentalFindingsEntityUsingCarotidArteryTestId);
					break;
				case "CustomerEventTestsCollectionViaAaatestRecommendation":
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.AaatestRecommendationEntityUsingAaatestId, "CarotidArteryTestResultsEntity__", "AaatestRecommendation_", JoinHint.None);
					toReturn.Add(AaatestRecommendationEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, "AaatestRecommendation_", string.Empty, JoinHint.None);
					break;
				case "IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings":
					toReturn.Add(CarotidArteryTestResultsEntity.Relations.CarotidArteryTestIncidentalFindingsEntityUsingCarotidArteryTestId, "CarotidArteryTestResultsEntity__", "CarotidArteryTestIncidentalFindings_", JoinHint.None);
					toReturn.Add(CarotidArteryTestIncidentalFindingsEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingsId, "CarotidArteryTestIncidentalFindings_", string.Empty, JoinHint.None);
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
				case "CarotidArteryTestFindings_":
					SetupSyncCarotidArteryTestFindings_(relatedEntity);
					break;
				case "CarotidArteryTestFindings":
					SetupSyncCarotidArteryTestFindings(relatedEntity);
					break;
				case "CustomerEventTests":
					SetupSyncCustomerEventTests(relatedEntity);
					break;
				case "AaatestRecommendation":
					this.AaatestRecommendation.Add((AaatestRecommendationEntity)relatedEntity);
					break;
				case "CarotidArteryTestImages":
					this.CarotidArteryTestImages.Add((CarotidArteryTestImagesEntity)relatedEntity);
					break;
				case "CarotidArteryTestIncidentalFindings":
					this.CarotidArteryTestIncidentalFindings.Add((CarotidArteryTestIncidentalFindingsEntity)relatedEntity);
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
				case "CarotidArteryTestFindings_":
					DesetupSyncCarotidArteryTestFindings_(false, true);
					break;
				case "CarotidArteryTestFindings":
					DesetupSyncCarotidArteryTestFindings(false, true);
					break;
				case "CustomerEventTests":
					DesetupSyncCustomerEventTests(false, true);
					break;
				case "AaatestRecommendation":
					base.PerformRelatedEntityRemoval(this.AaatestRecommendation, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CarotidArteryTestImages":
					base.PerformRelatedEntityRemoval(this.CarotidArteryTestImages, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CarotidArteryTestIncidentalFindings":
					base.PerformRelatedEntityRemoval(this.CarotidArteryTestIncidentalFindings, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_carotidArteryTestFindings_!=null)
			{
				toReturn.Add(_carotidArteryTestFindings_);
			}
			if(_carotidArteryTestFindings!=null)
			{
				toReturn.Add(_carotidArteryTestFindings);
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
			toReturn.Add(this.AaatestRecommendation);
			toReturn.Add(this.CarotidArteryTestImages);
			toReturn.Add(this.CarotidArteryTestIncidentalFindings);

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
				info.AddValue("_aaatestRecommendation", ((_aaatestRecommendation!=null) && (_aaatestRecommendation.Count>0) && !this.MarkedForDeletion)?_aaatestRecommendation:null);
				info.AddValue("_carotidArteryTestImages", ((_carotidArteryTestImages!=null) && (_carotidArteryTestImages.Count>0) && !this.MarkedForDeletion)?_carotidArteryTestImages:null);
				info.AddValue("_carotidArteryTestIncidentalFindings", ((_carotidArteryTestIncidentalFindings!=null) && (_carotidArteryTestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_carotidArteryTestIncidentalFindings:null);
				info.AddValue("_customerEventTestsCollectionViaAaatestRecommendation", ((_customerEventTestsCollectionViaAaatestRecommendation!=null) && (_customerEventTestsCollectionViaAaatestRecommendation.Count>0) && !this.MarkedForDeletion)?_customerEventTestsCollectionViaAaatestRecommendation:null);
				info.AddValue("_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings", ((_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings!=null) && (_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings.Count>0) && !this.MarkedForDeletion)?_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings:null);
				info.AddValue("_carotidArteryTestFindings_", (!this.MarkedForDeletion?_carotidArteryTestFindings_:null));
				info.AddValue("_carotidArteryTestFindings", (!this.MarkedForDeletion?_carotidArteryTestFindings:null));
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
		public bool TestOriginalFieldValueForNull(CarotidArteryTestResultsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CarotidArteryTestResultsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CarotidArteryTestResultsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AaatestRecommendation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAaatestRecommendation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AaatestRecommendationFields.AaatestId, null, ComparisonOperator.Equal, this.CarotidArteryTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CarotidArteryTestImages' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCarotidArteryTestImages()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestImagesFields.CarotidArteryTestId, null, ComparisonOperator.Equal, this.CarotidArteryTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CarotidArteryTestIncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCarotidArteryTestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestIncidentalFindingsFields.CarotidArteryTestId, null, ComparisonOperator.Equal, this.CarotidArteryTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestsCollectionViaAaatestRecommendation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventTestsCollectionViaAaatestRecommendation"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestResultsFields.CarotidArteryTestId, null, ComparisonOperator.Equal, this.CarotidArteryTestId, "CarotidArteryTestResultsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestResultsFields.CarotidArteryTestId, null, ComparisonOperator.Equal, this.CarotidArteryTestId, "CarotidArteryTestResultsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CarotidArteryTestFindings' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCarotidArteryTestFindings_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestFindingsFields.CarotidArteryTestFindingsId, null, ComparisonOperator.Equal, this.RcarotidArteryTestFindingsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CarotidArteryTestFindings' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCarotidArteryTestFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarotidArteryTestFindingsFields.CarotidArteryTestFindingsId, null, ComparisonOperator.Equal, this.LcarotidArteryTestFindingsId));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.CarotidArteryTestResultsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestResultsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._aaatestRecommendation);
			collectionsQueue.Enqueue(this._carotidArteryTestImages);
			collectionsQueue.Enqueue(this._carotidArteryTestIncidentalFindings);
			collectionsQueue.Enqueue(this._customerEventTestsCollectionViaAaatestRecommendation);
			collectionsQueue.Enqueue(this._incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._aaatestRecommendation = (EntityCollection<AaatestRecommendationEntity>) collectionsQueue.Dequeue();
			this._carotidArteryTestImages = (EntityCollection<CarotidArteryTestImagesEntity>) collectionsQueue.Dequeue();
			this._carotidArteryTestIncidentalFindings = (EntityCollection<CarotidArteryTestIncidentalFindingsEntity>) collectionsQueue.Dequeue();
			this._customerEventTestsCollectionViaAaatestRecommendation = (EntityCollection<CustomerEventTestsEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings = (EntityCollection<IncidentalFindingsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._aaatestRecommendation != null)
			{
				return true;
			}
			if (this._carotidArteryTestImages != null)
			{
				return true;
			}
			if (this._carotidArteryTestIncidentalFindings != null)
			{
				return true;
			}
			if (this._customerEventTestsCollectionViaAaatestRecommendation != null)
			{
				return true;
			}
			if (this._incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AaatestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestRecommendationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CarotidArteryTestImagesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestImagesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CarotidArteryTestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestIncidentalFindingsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))) : null);
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
			toReturn.Add("CarotidArteryTestFindings_", _carotidArteryTestFindings_);
			toReturn.Add("CarotidArteryTestFindings", _carotidArteryTestFindings);
			toReturn.Add("CustomerEventTests", _customerEventTests);
			toReturn.Add("AaatestRecommendation", _aaatestRecommendation);
			toReturn.Add("CarotidArteryTestImages", _carotidArteryTestImages);
			toReturn.Add("CarotidArteryTestIncidentalFindings", _carotidArteryTestIncidentalFindings);
			toReturn.Add("CustomerEventTestsCollectionViaAaatestRecommendation", _customerEventTestsCollectionViaAaatestRecommendation);
			toReturn.Add("IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings", _incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_aaatestRecommendation!=null)
			{
				_aaatestRecommendation.ActiveContext = base.ActiveContext;
			}
			if(_carotidArteryTestImages!=null)
			{
				_carotidArteryTestImages.ActiveContext = base.ActiveContext;
			}
			if(_carotidArteryTestIncidentalFindings!=null)
			{
				_carotidArteryTestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestsCollectionViaAaatestRecommendation!=null)
			{
				_customerEventTestsCollectionViaAaatestRecommendation.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings!=null)
			{
				_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings.ActiveContext = base.ActiveContext;
			}
			if(_carotidArteryTestFindings_!=null)
			{
				_carotidArteryTestFindings_.ActiveContext = base.ActiveContext;
			}
			if(_carotidArteryTestFindings!=null)
			{
				_carotidArteryTestFindings.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTests!=null)
			{
				_customerEventTests.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_aaatestRecommendation = null;
			_carotidArteryTestImages = null;
			_carotidArteryTestIncidentalFindings = null;
			_customerEventTestsCollectionViaAaatestRecommendation = null;
			_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings = null;
			_carotidArteryTestFindings_ = null;
			_carotidArteryTestFindings = null;
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

			_fieldsCustomProperties.Add("CarotidArteryTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ricapsv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ricaedv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Licapsv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Licaedv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Lccapsv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Rccapsv", fieldHashtable);
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

			_fieldsCustomProperties.Add("LcarotidArteryTestFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RcarotidArteryTestFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TechnicianRemarks", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnableToScreen", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedById", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordedByRole", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualRicapsv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualRicaedv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualLicapsv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualLicaedv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualLccapsv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualRccapsv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualLstandardFinding", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManualRstandardFinding", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTestNotPerformed", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _carotidArteryTestFindings_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCarotidArteryTestFindings_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _carotidArteryTestFindings_, new PropertyChangedEventHandler( OnCarotidArteryTestFindings_PropertyChanged ), "CarotidArteryTestFindings_", CarotidArteryTestResultsEntity.Relations.CarotidArteryTestFindingsEntityUsingRcarotidArteryTestFindingsId, true, signalRelatedEntity, "CarotidArteryTestResults_", resetFKFields, new int[] { (int)CarotidArteryTestResultsFieldIndex.RcarotidArteryTestFindingsId } );		
			_carotidArteryTestFindings_ = null;
		}

		/// <summary> setups the sync logic for member _carotidArteryTestFindings_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCarotidArteryTestFindings_(IEntity2 relatedEntity)
		{
			if(_carotidArteryTestFindings_!=relatedEntity)
			{
				DesetupSyncCarotidArteryTestFindings_(true, true);
				_carotidArteryTestFindings_ = (CarotidArteryTestFindingsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _carotidArteryTestFindings_, new PropertyChangedEventHandler( OnCarotidArteryTestFindings_PropertyChanged ), "CarotidArteryTestFindings_", CarotidArteryTestResultsEntity.Relations.CarotidArteryTestFindingsEntityUsingRcarotidArteryTestFindingsId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCarotidArteryTestFindings_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _carotidArteryTestFindings</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCarotidArteryTestFindings(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _carotidArteryTestFindings, new PropertyChangedEventHandler( OnCarotidArteryTestFindingsPropertyChanged ), "CarotidArteryTestFindings", CarotidArteryTestResultsEntity.Relations.CarotidArteryTestFindingsEntityUsingLcarotidArteryTestFindingsId, true, signalRelatedEntity, "CarotidArteryTestResults", resetFKFields, new int[] { (int)CarotidArteryTestResultsFieldIndex.LcarotidArteryTestFindingsId } );		
			_carotidArteryTestFindings = null;
		}

		/// <summary> setups the sync logic for member _carotidArteryTestFindings</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCarotidArteryTestFindings(IEntity2 relatedEntity)
		{
			if(_carotidArteryTestFindings!=relatedEntity)
			{
				DesetupSyncCarotidArteryTestFindings(true, true);
				_carotidArteryTestFindings = (CarotidArteryTestFindingsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _carotidArteryTestFindings, new PropertyChangedEventHandler( OnCarotidArteryTestFindingsPropertyChanged ), "CarotidArteryTestFindings", CarotidArteryTestResultsEntity.Relations.CarotidArteryTestFindingsEntityUsingLcarotidArteryTestFindingsId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCarotidArteryTestFindingsPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", CarotidArteryTestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, signalRelatedEntity, "CarotidArteryTestResults", resetFKFields, new int[] { (int)CarotidArteryTestResultsFieldIndex.CustomerEventTestId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", CarotidArteryTestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CarotidArteryTestResultsEntity</param>
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
		public  static CarotidArteryTestResultsRelations Relations
		{
			get	{ return new CarotidArteryTestResultsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AaatestRecommendation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAaatestRecommendation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AaatestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestRecommendationEntityFactory))),
					(IEntityRelation)GetRelationsForField("AaatestRecommendation")[0], (int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, (int)HealthYes.Data.EntityType.AaatestRecommendationEntity, 0, null, null, null, null, "AaatestRecommendation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CarotidArteryTestImages' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCarotidArteryTestImages
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CarotidArteryTestImagesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestImagesEntityFactory))),
					(IEntityRelation)GetRelationsForField("CarotidArteryTestImages")[0], (int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, (int)HealthYes.Data.EntityType.CarotidArteryTestImagesEntity, 0, null, null, null, null, "CarotidArteryTestImages", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CarotidArteryTestIncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCarotidArteryTestIncidentalFindings
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CarotidArteryTestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestIncidentalFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CarotidArteryTestIncidentalFindings")[0], (int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, (int)HealthYes.Data.EntityType.CarotidArteryTestIncidentalFindingsEntity, 0, null, null, null, null, "CarotidArteryTestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestsCollectionViaAaatestRecommendation
		{
			get
			{
				IEntityRelation intermediateRelation = CarotidArteryTestResultsEntity.Relations.AaatestRecommendationEntityUsingAaatestId;
				intermediateRelation.SetAliases(string.Empty, "AaatestRecommendation_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, GetRelationsForField("CustomerEventTestsCollectionViaAaatestRecommendation"), null, "CustomerEventTestsCollectionViaAaatestRecommendation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings
		{
			get
			{
				IEntityRelation intermediateRelation = CarotidArteryTestResultsEntity.Relations.CarotidArteryTestIncidentalFindingsEntityUsingCarotidArteryTestId;
				intermediateRelation.SetAliases(string.Empty, "CarotidArteryTestIncidentalFindings_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, (int)HealthYes.Data.EntityType.IncidentalFindingsEntity, 0, null, null, GetRelationsForField("IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings"), null, "IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CarotidArteryTestFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCarotidArteryTestFindings_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CarotidArteryTestFindings_")[0], (int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, (int)HealthYes.Data.EntityType.CarotidArteryTestFindingsEntity, 0, null, null, null, null, "CarotidArteryTestFindings_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CarotidArteryTestFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCarotidArteryTestFindings
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CarotidArteryTestFindings")[0], (int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, (int)HealthYes.Data.EntityType.CarotidArteryTestFindingsEntity, 0, null, null, null, null, "CarotidArteryTestFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("CustomerEventTests")[0], (int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, null, null, "CustomerEventTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CarotidArteryTestResultsEntity.CustomProperties;}
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
			get { return CarotidArteryTestResultsEntity.FieldsCustomProperties;}
		}

		/// <summary> The CarotidArteryTestId property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."CarotidArteryTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CarotidArteryTestId
		{
			get { return (System.Int64)GetValue((int)CarotidArteryTestResultsFieldIndex.CarotidArteryTestId, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.CarotidArteryTestId, value); }
		}

		/// <summary> The CustomerEventTestId property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."CustomerEventTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventTestId
		{
			get { return (System.Int64)GetValue((int)CarotidArteryTestResultsFieldIndex.CustomerEventTestId, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.CustomerEventTestId, value); }
		}

		/// <summary> The Ricapsv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."RICAPSV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Ricapsv
		{
			get { return (Nullable<System.Decimal>)GetValue((int)CarotidArteryTestResultsFieldIndex.Ricapsv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.Ricapsv, value); }
		}

		/// <summary> The Ricaedv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."RICAEDV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Ricaedv
		{
			get { return (Nullable<System.Decimal>)GetValue((int)CarotidArteryTestResultsFieldIndex.Ricaedv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.Ricaedv, value); }
		}

		/// <summary> The Licapsv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."LICAPSV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Licapsv
		{
			get { return (Nullable<System.Decimal>)GetValue((int)CarotidArteryTestResultsFieldIndex.Licapsv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.Licapsv, value); }
		}

		/// <summary> The Licaedv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."LICAEDV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Licaedv
		{
			get { return (Nullable<System.Decimal>)GetValue((int)CarotidArteryTestResultsFieldIndex.Licaedv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.Licaedv, value); }
		}

		/// <summary> The Lccapsv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."LCCAPSV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Lccapsv
		{
			get { return (Nullable<System.Decimal>)GetValue((int)CarotidArteryTestResultsFieldIndex.Lccapsv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.Lccapsv, value); }
		}

		/// <summary> The Rccapsv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."RCCAPSV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Rccapsv
		{
			get { return (Nullable<System.Decimal>)GetValue((int)CarotidArteryTestResultsFieldIndex.Rccapsv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.Rccapsv, value); }
		}

		/// <summary> The EvaluationStatus property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."EvaluationStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> EvaluationStatus
		{
			get { return (Nullable<System.Byte>)GetValue((int)CarotidArteryTestResultsFieldIndex.EvaluationStatus, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.EvaluationStatus, value); }
		}

		/// <summary> The DateCreated property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CarotidArteryTestResultsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)CarotidArteryTestResultsFieldIndex.DateModified, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsManual property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsManual"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsManual
		{
			get { return (System.Boolean)GetValue((int)CarotidArteryTestResultsFieldIndex.IsManual, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsManual, value); }
		}

		/// <summary> The IsCritical property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsCritical"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsCritical
		{
			get { return (System.Boolean)GetValue((int)CarotidArteryTestResultsFieldIndex.IsCritical, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsCritical, value); }
		}

		/// <summary> The IsPartial property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsPartial"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPartial
		{
			get { return (System.Boolean)GetValue((int)CarotidArteryTestResultsFieldIndex.IsPartial, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsPartial, value); }
		}

		/// <summary> The LcarotidArteryTestFindingsId property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."LCarotidArteryTestFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> LcarotidArteryTestFindingsId
		{
			get { return (Nullable<System.Int32>)GetValue((int)CarotidArteryTestResultsFieldIndex.LcarotidArteryTestFindingsId, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.LcarotidArteryTestFindingsId, value); }
		}

		/// <summary> The RcarotidArteryTestFindingsId property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."RCarotidArteryTestFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> RcarotidArteryTestFindingsId
		{
			get { return (Nullable<System.Int32>)GetValue((int)CarotidArteryTestResultsFieldIndex.RcarotidArteryTestFindingsId, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.RcarotidArteryTestFindingsId, value); }
		}

		/// <summary> The TechnicianRemarks property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."TechnicianRemarks"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TechnicianRemarks
		{
			get { return (System.String)GetValue((int)CarotidArteryTestResultsFieldIndex.TechnicianRemarks, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.TechnicianRemarks, value); }
		}

		/// <summary> The UnableToScreen property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."UnableToScreen"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean UnableToScreen
		{
			get { return (System.Boolean)GetValue((int)CarotidArteryTestResultsFieldIndex.UnableToScreen, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.UnableToScreen, value); }
		}

		/// <summary> The RecordedById property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."RecordedByID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RecordedById
		{
			get { return (Nullable<System.Int64>)GetValue((int)CarotidArteryTestResultsFieldIndex.RecordedById, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.RecordedById, value); }
		}

		/// <summary> The RecordedByRole property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."RecordedByRole"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> RecordedByRole
		{
			get { return (Nullable<System.Byte>)GetValue((int)CarotidArteryTestResultsFieldIndex.RecordedByRole, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.RecordedByRole, value); }
		}

		/// <summary> The IsManualRicapsv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsManualRICAPSV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualRicapsv
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CarotidArteryTestResultsFieldIndex.IsManualRicapsv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsManualRicapsv, value); }
		}

		/// <summary> The IsManualRicaedv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsManualRICAEDV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualRicaedv
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CarotidArteryTestResultsFieldIndex.IsManualRicaedv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsManualRicaedv, value); }
		}

		/// <summary> The IsManualLicapsv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsManualLICAPSV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualLicapsv
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CarotidArteryTestResultsFieldIndex.IsManualLicapsv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsManualLicapsv, value); }
		}

		/// <summary> The IsManualLicaedv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsManualLICAEDV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualLicaedv
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CarotidArteryTestResultsFieldIndex.IsManualLicaedv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsManualLicaedv, value); }
		}

		/// <summary> The IsManualLccapsv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsManualLCCAPSV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualLccapsv
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CarotidArteryTestResultsFieldIndex.IsManualLccapsv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsManualLccapsv, value); }
		}

		/// <summary> The IsManualRccapsv property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsManualRCCAPSV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualRccapsv
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CarotidArteryTestResultsFieldIndex.IsManualRccapsv, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsManualRccapsv, value); }
		}

		/// <summary> The IsManualLstandardFinding property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsManualLStandardFinding"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualLstandardFinding
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CarotidArteryTestResultsFieldIndex.IsManualLstandardFinding, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsManualLstandardFinding, value); }
		}

		/// <summary> The IsManualRstandardFinding property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsManualRStandardFinding"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManualRstandardFinding
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CarotidArteryTestResultsFieldIndex.IsManualRstandardFinding, false); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsManualRstandardFinding, value); }
		}

		/// <summary> The IsTestNotPerformed property of the Entity CarotidArteryTestResults<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCarotidArteryTestResults_Legacy"."IsTestNotPerformed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTestNotPerformed
		{
			get { return (System.Boolean)GetValue((int)CarotidArteryTestResultsFieldIndex.IsTestNotPerformed, true); }
			set	{ SetValue((int)CarotidArteryTestResultsFieldIndex.IsTestNotPerformed, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AaatestRecommendationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AaatestRecommendationEntity))]
		public virtual EntityCollection<AaatestRecommendationEntity> AaatestRecommendation
		{
			get
			{
				if(_aaatestRecommendation==null)
				{
					_aaatestRecommendation = new EntityCollection<AaatestRecommendationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestRecommendationEntityFactory)));
					_aaatestRecommendation.SetContainingEntityInfo(this, "CarotidArteryTestResults");
				}
				return _aaatestRecommendation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CarotidArteryTestImagesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CarotidArteryTestImagesEntity))]
		public virtual EntityCollection<CarotidArteryTestImagesEntity> CarotidArteryTestImages
		{
			get
			{
				if(_carotidArteryTestImages==null)
				{
					_carotidArteryTestImages = new EntityCollection<CarotidArteryTestImagesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestImagesEntityFactory)));
					_carotidArteryTestImages.SetContainingEntityInfo(this, "CarotidArteryTestResults");
				}
				return _carotidArteryTestImages;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CarotidArteryTestIncidentalFindingsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CarotidArteryTestIncidentalFindingsEntity))]
		public virtual EntityCollection<CarotidArteryTestIncidentalFindingsEntity> CarotidArteryTestIncidentalFindings
		{
			get
			{
				if(_carotidArteryTestIncidentalFindings==null)
				{
					_carotidArteryTestIncidentalFindings = new EntityCollection<CarotidArteryTestIncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CarotidArteryTestIncidentalFindingsEntityFactory)));
					_carotidArteryTestIncidentalFindings.SetContainingEntityInfo(this, "CarotidArteryTestResults");
				}
				return _carotidArteryTestIncidentalFindings;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestsEntity))]
		public virtual EntityCollection<CustomerEventTestsEntity> CustomerEventTestsCollectionViaAaatestRecommendation
		{
			get
			{
				if(_customerEventTestsCollectionViaAaatestRecommendation==null)
				{
					_customerEventTestsCollectionViaAaatestRecommendation = new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory)));
					_customerEventTestsCollectionViaAaatestRecommendation.IsReadOnly=true;
				}
				return _customerEventTestsCollectionViaAaatestRecommendation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingsEntity))]
		public virtual EntityCollection<IncidentalFindingsEntity> IncidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings
		{
			get
			{
				if(_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings==null)
				{
					_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings = new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory)));
					_incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings.IsReadOnly=true;
				}
				return _incidentalFindingsCollectionViaCarotidArteryTestIncidentalFindings;
			}
		}

		/// <summary> Gets / sets related entity of type 'CarotidArteryTestFindingsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CarotidArteryTestFindingsEntity CarotidArteryTestFindings_
		{
			get
			{
				return _carotidArteryTestFindings_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCarotidArteryTestFindings_(value);
				}
				else
				{
					if(value==null)
					{
						if(_carotidArteryTestFindings_ != null)
						{
							_carotidArteryTestFindings_.UnsetRelatedEntity(this, "CarotidArteryTestResults_");
						}
					}
					else
					{
						if(_carotidArteryTestFindings_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CarotidArteryTestResults_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CarotidArteryTestFindingsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CarotidArteryTestFindingsEntity CarotidArteryTestFindings
		{
			get
			{
				return _carotidArteryTestFindings;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCarotidArteryTestFindings(value);
				}
				else
				{
					if(value==null)
					{
						if(_carotidArteryTestFindings != null)
						{
							_carotidArteryTestFindings.UnsetRelatedEntity(this, "CarotidArteryTestResults");
						}
					}
					else
					{
						if(_carotidArteryTestFindings!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CarotidArteryTestResults");
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
							_customerEventTests.UnsetRelatedEntity(this, "CarotidArteryTestResults");
						}
					}
					else
					{
						if(_customerEventTests!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CarotidArteryTestResults");
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
			get { return (int)HealthYes.Data.EntityType.CarotidArteryTestResultsEntity; }
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
