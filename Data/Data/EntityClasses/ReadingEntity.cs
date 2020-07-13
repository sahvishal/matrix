///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:46
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
	/// Entity class which represents the entity 'Reading'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ReadingEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<FraminghamCalculationSourceEntity> _framinghamCalculationSource;
		private EntityCollection<MedicalHistoryReadingAssosciationEntity> _medicalHistoryReadingAssosciation;
		private EntityCollection<StandardFindingTestReadingEntity> _standardFindingTestReading;
		private EntityCollection<TestReadingEntity> _testReading;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation;
		private EntityCollection<StandardFindingEntity> _standardFindingCollectionViaStandardFindingTestReading;
		private EntityCollection<TestEntity> _testCollectionViaTestReading;
		private EntityCollection<TestEntity> _testCollectionViaStandardFindingTestReading;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name FraminghamCalculationSource</summary>
			public static readonly string FraminghamCalculationSource = "FraminghamCalculationSource";
			/// <summary>Member name MedicalHistoryReadingAssosciation</summary>
			public static readonly string MedicalHistoryReadingAssosciation = "MedicalHistoryReadingAssosciation";
			/// <summary>Member name StandardFindingTestReading</summary>
			public static readonly string StandardFindingTestReading = "StandardFindingTestReading";
			/// <summary>Member name TestReading</summary>
			public static readonly string TestReading = "TestReading";
			/// <summary>Member name CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation</summary>
			public static readonly string CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation = "CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation";
			/// <summary>Member name StandardFindingCollectionViaStandardFindingTestReading</summary>
			public static readonly string StandardFindingCollectionViaStandardFindingTestReading = "StandardFindingCollectionViaStandardFindingTestReading";
			/// <summary>Member name TestCollectionViaTestReading</summary>
			public static readonly string TestCollectionViaTestReading = "TestCollectionViaTestReading";
			/// <summary>Member name TestCollectionViaStandardFindingTestReading</summary>
			public static readonly string TestCollectionViaStandardFindingTestReading = "TestCollectionViaStandardFindingTestReading";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ReadingEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ReadingEntity():base("ReadingEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ReadingEntity(IEntityFields2 fields):base("ReadingEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ReadingEntity</param>
		public ReadingEntity(IValidator validator):base("ReadingEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="readingId">PK value for Reading which data should be fetched into this Reading object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ReadingEntity(System.Int32 readingId):base("ReadingEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ReadingId = readingId;
		}

		/// <summary> CTor</summary>
		/// <param name="readingId">PK value for Reading which data should be fetched into this Reading object</param>
		/// <param name="validator">The custom validator object for this ReadingEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ReadingEntity(System.Int32 readingId, IValidator validator):base("ReadingEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ReadingId = readingId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ReadingEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_framinghamCalculationSource = (EntityCollection<FraminghamCalculationSourceEntity>)info.GetValue("_framinghamCalculationSource", typeof(EntityCollection<FraminghamCalculationSourceEntity>));
				_medicalHistoryReadingAssosciation = (EntityCollection<MedicalHistoryReadingAssosciationEntity>)info.GetValue("_medicalHistoryReadingAssosciation", typeof(EntityCollection<MedicalHistoryReadingAssosciationEntity>));
				_standardFindingTestReading = (EntityCollection<StandardFindingTestReadingEntity>)info.GetValue("_standardFindingTestReading", typeof(EntityCollection<StandardFindingTestReadingEntity>));
				_testReading = (EntityCollection<TestReadingEntity>)info.GetValue("_testReading", typeof(EntityCollection<TestReadingEntity>));
				_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_standardFindingCollectionViaStandardFindingTestReading = (EntityCollection<StandardFindingEntity>)info.GetValue("_standardFindingCollectionViaStandardFindingTestReading", typeof(EntityCollection<StandardFindingEntity>));
				_testCollectionViaTestReading = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaTestReading", typeof(EntityCollection<TestEntity>));
				_testCollectionViaStandardFindingTestReading = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaStandardFindingTestReading", typeof(EntityCollection<TestEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ReadingFieldIndex)fieldIndex)
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

				case "FraminghamCalculationSource":
					this.FraminghamCalculationSource.Add((FraminghamCalculationSourceEntity)entity);
					break;
				case "MedicalHistoryReadingAssosciation":
					this.MedicalHistoryReadingAssosciation.Add((MedicalHistoryReadingAssosciationEntity)entity);
					break;
				case "StandardFindingTestReading":
					this.StandardFindingTestReading.Add((StandardFindingTestReadingEntity)entity);
					break;
				case "TestReading":
					this.TestReading.Add((TestReadingEntity)entity);
					break;
				case "CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation":
					this.CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation.IsReadOnly = false;
					this.CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation.Add((CustomerHealthQuestionsEntity)entity);
					this.CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation.IsReadOnly = true;
					break;
				case "StandardFindingCollectionViaStandardFindingTestReading":
					this.StandardFindingCollectionViaStandardFindingTestReading.IsReadOnly = false;
					this.StandardFindingCollectionViaStandardFindingTestReading.Add((StandardFindingEntity)entity);
					this.StandardFindingCollectionViaStandardFindingTestReading.IsReadOnly = true;
					break;
				case "TestCollectionViaTestReading":
					this.TestCollectionViaTestReading.IsReadOnly = false;
					this.TestCollectionViaTestReading.Add((TestEntity)entity);
					this.TestCollectionViaTestReading.IsReadOnly = true;
					break;
				case "TestCollectionViaStandardFindingTestReading":
					this.TestCollectionViaStandardFindingTestReading.IsReadOnly = false;
					this.TestCollectionViaStandardFindingTestReading.Add((TestEntity)entity);
					this.TestCollectionViaStandardFindingTestReading.IsReadOnly = true;
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
			return ReadingEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "FraminghamCalculationSource":
					toReturn.Add(ReadingEntity.Relations.FraminghamCalculationSourceEntityUsingReadingId);
					break;
				case "MedicalHistoryReadingAssosciation":
					toReturn.Add(ReadingEntity.Relations.MedicalHistoryReadingAssosciationEntityUsingReadingId);
					break;
				case "StandardFindingTestReading":
					toReturn.Add(ReadingEntity.Relations.StandardFindingTestReadingEntityUsingReadingId);
					break;
				case "TestReading":
					toReturn.Add(ReadingEntity.Relations.TestReadingEntityUsingReadingId);
					break;
				case "CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation":
					toReturn.Add(ReadingEntity.Relations.MedicalHistoryReadingAssosciationEntityUsingReadingId, "ReadingEntity__", "MedicalHistoryReadingAssosciation_", JoinHint.None);
					toReturn.Add(MedicalHistoryReadingAssosciationEntity.Relations.CustomerHealthQuestionsEntityUsingMedicalHistoryQuestionId, "MedicalHistoryReadingAssosciation_", string.Empty, JoinHint.None);
					break;
				case "StandardFindingCollectionViaStandardFindingTestReading":
					toReturn.Add(ReadingEntity.Relations.StandardFindingTestReadingEntityUsingReadingId, "ReadingEntity__", "StandardFindingTestReading_", JoinHint.None);
					toReturn.Add(StandardFindingTestReadingEntity.Relations.StandardFindingEntityUsingStandardFindingId, "StandardFindingTestReading_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaTestReading":
					toReturn.Add(ReadingEntity.Relations.TestReadingEntityUsingReadingId, "ReadingEntity__", "TestReading_", JoinHint.None);
					toReturn.Add(TestReadingEntity.Relations.TestEntityUsingTestId, "TestReading_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaStandardFindingTestReading":
					toReturn.Add(ReadingEntity.Relations.StandardFindingTestReadingEntityUsingReadingId, "ReadingEntity__", "StandardFindingTestReading_", JoinHint.None);
					toReturn.Add(StandardFindingTestReadingEntity.Relations.TestEntityUsingTestId, "StandardFindingTestReading_", string.Empty, JoinHint.None);
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

				case "FraminghamCalculationSource":
					this.FraminghamCalculationSource.Add((FraminghamCalculationSourceEntity)relatedEntity);
					break;
				case "MedicalHistoryReadingAssosciation":
					this.MedicalHistoryReadingAssosciation.Add((MedicalHistoryReadingAssosciationEntity)relatedEntity);
					break;
				case "StandardFindingTestReading":
					this.StandardFindingTestReading.Add((StandardFindingTestReadingEntity)relatedEntity);
					break;
				case "TestReading":
					this.TestReading.Add((TestReadingEntity)relatedEntity);
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

				case "FraminghamCalculationSource":
					base.PerformRelatedEntityRemoval(this.FraminghamCalculationSource, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicalHistoryReadingAssosciation":
					base.PerformRelatedEntityRemoval(this.MedicalHistoryReadingAssosciation, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "StandardFindingTestReading":
					base.PerformRelatedEntityRemoval(this.StandardFindingTestReading, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestReading":
					base.PerformRelatedEntityRemoval(this.TestReading, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.FraminghamCalculationSource);
			toReturn.Add(this.MedicalHistoryReadingAssosciation);
			toReturn.Add(this.StandardFindingTestReading);
			toReturn.Add(this.TestReading);

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
				info.AddValue("_framinghamCalculationSource", ((_framinghamCalculationSource!=null) && (_framinghamCalculationSource.Count>0) && !this.MarkedForDeletion)?_framinghamCalculationSource:null);
				info.AddValue("_medicalHistoryReadingAssosciation", ((_medicalHistoryReadingAssosciation!=null) && (_medicalHistoryReadingAssosciation.Count>0) && !this.MarkedForDeletion)?_medicalHistoryReadingAssosciation:null);
				info.AddValue("_standardFindingTestReading", ((_standardFindingTestReading!=null) && (_standardFindingTestReading.Count>0) && !this.MarkedForDeletion)?_standardFindingTestReading:null);
				info.AddValue("_testReading", ((_testReading!=null) && (_testReading.Count>0) && !this.MarkedForDeletion)?_testReading:null);
				info.AddValue("_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation", ((_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation!=null) && (_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation:null);
				info.AddValue("_standardFindingCollectionViaStandardFindingTestReading", ((_standardFindingCollectionViaStandardFindingTestReading!=null) && (_standardFindingCollectionViaStandardFindingTestReading.Count>0) && !this.MarkedForDeletion)?_standardFindingCollectionViaStandardFindingTestReading:null);
				info.AddValue("_testCollectionViaTestReading", ((_testCollectionViaTestReading!=null) && (_testCollectionViaTestReading.Count>0) && !this.MarkedForDeletion)?_testCollectionViaTestReading:null);
				info.AddValue("_testCollectionViaStandardFindingTestReading", ((_testCollectionViaStandardFindingTestReading!=null) && (_testCollectionViaStandardFindingTestReading.Count>0) && !this.MarkedForDeletion)?_testCollectionViaStandardFindingTestReading:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ReadingFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ReadingFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ReadingRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FraminghamCalculationSource' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFraminghamCalculationSource()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FraminghamCalculationSourceFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalHistoryReadingAssosciation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalHistoryReadingAssosciation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalHistoryReadingAssosciationFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StandardFindingTestReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStandardFindingTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingTestReadingFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestReadingFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReadingFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId, "ReadingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StandardFinding' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStandardFindingCollectionViaStandardFindingTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StandardFindingCollectionViaStandardFindingTestReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReadingFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId, "ReadingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaTestReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReadingFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId, "ReadingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaStandardFindingTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaStandardFindingTestReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReadingFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId, "ReadingEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ReadingEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._framinghamCalculationSource);
			collectionsQueue.Enqueue(this._medicalHistoryReadingAssosciation);
			collectionsQueue.Enqueue(this._standardFindingTestReading);
			collectionsQueue.Enqueue(this._testReading);
			collectionsQueue.Enqueue(this._customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation);
			collectionsQueue.Enqueue(this._standardFindingCollectionViaStandardFindingTestReading);
			collectionsQueue.Enqueue(this._testCollectionViaTestReading);
			collectionsQueue.Enqueue(this._testCollectionViaStandardFindingTestReading);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._framinghamCalculationSource = (EntityCollection<FraminghamCalculationSourceEntity>) collectionsQueue.Dequeue();
			this._medicalHistoryReadingAssosciation = (EntityCollection<MedicalHistoryReadingAssosciationEntity>) collectionsQueue.Dequeue();
			this._standardFindingTestReading = (EntityCollection<StandardFindingTestReadingEntity>) collectionsQueue.Dequeue();
			this._testReading = (EntityCollection<TestReadingEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._standardFindingCollectionViaStandardFindingTestReading = (EntityCollection<StandardFindingEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaTestReading = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaStandardFindingTestReading = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._framinghamCalculationSource != null)
			{
				return true;
			}
			if (this._medicalHistoryReadingAssosciation != null)
			{
				return true;
			}
			if (this._standardFindingTestReading != null)
			{
				return true;
			}
			if (this._testReading != null)
			{
				return true;
			}
			if (this._customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation != null)
			{
				return true;
			}
			if (this._standardFindingCollectionViaStandardFindingTestReading != null)
			{
				return true;
			}
			if (this._testCollectionViaTestReading != null)
			{
				return true;
			}
			if (this._testCollectionViaStandardFindingTestReading != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FraminghamCalculationSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FraminghamCalculationSourceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalHistoryReadingAssosciationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalHistoryReadingAssosciationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
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

			toReturn.Add("FraminghamCalculationSource", _framinghamCalculationSource);
			toReturn.Add("MedicalHistoryReadingAssosciation", _medicalHistoryReadingAssosciation);
			toReturn.Add("StandardFindingTestReading", _standardFindingTestReading);
			toReturn.Add("TestReading", _testReading);
			toReturn.Add("CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation", _customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation);
			toReturn.Add("StandardFindingCollectionViaStandardFindingTestReading", _standardFindingCollectionViaStandardFindingTestReading);
			toReturn.Add("TestCollectionViaTestReading", _testCollectionViaTestReading);
			toReturn.Add("TestCollectionViaStandardFindingTestReading", _testCollectionViaStandardFindingTestReading);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_framinghamCalculationSource!=null)
			{
				_framinghamCalculationSource.ActiveContext = base.ActiveContext;
			}
			if(_medicalHistoryReadingAssosciation!=null)
			{
				_medicalHistoryReadingAssosciation.ActiveContext = base.ActiveContext;
			}
			if(_standardFindingTestReading!=null)
			{
				_standardFindingTestReading.ActiveContext = base.ActiveContext;
			}
			if(_testReading!=null)
			{
				_testReading.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation!=null)
			{
				_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation.ActiveContext = base.ActiveContext;
			}
			if(_standardFindingCollectionViaStandardFindingTestReading!=null)
			{
				_standardFindingCollectionViaStandardFindingTestReading.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaTestReading!=null)
			{
				_testCollectionViaTestReading.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaStandardFindingTestReading!=null)
			{
				_testCollectionViaStandardFindingTestReading.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_framinghamCalculationSource = null;
			_medicalHistoryReadingAssosciation = null;
			_standardFindingTestReading = null;
			_testReading = null;
			_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation = null;
			_standardFindingCollectionViaStandardFindingTestReading = null;
			_testCollectionViaTestReading = null;
			_testCollectionViaStandardFindingTestReading = null;


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

			_fieldsCustomProperties.Add("ReadingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Label", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MeasurementUnit", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultInputSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ReadingEntity</param>
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
		public  static ReadingRelations Relations
		{
			get	{ return new ReadingRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FraminghamCalculationSource' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFraminghamCalculationSource
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FraminghamCalculationSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FraminghamCalculationSourceEntityFactory))),
					(IEntityRelation)GetRelationsForField("FraminghamCalculationSource")[0], (int)Falcon.Data.EntityType.ReadingEntity, (int)Falcon.Data.EntityType.FraminghamCalculationSourceEntity, 0, null, null, null, null, "FraminghamCalculationSource", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalHistoryReadingAssosciation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalHistoryReadingAssosciation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicalHistoryReadingAssosciationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalHistoryReadingAssosciationEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalHistoryReadingAssosciation")[0], (int)Falcon.Data.EntityType.ReadingEntity, (int)Falcon.Data.EntityType.MedicalHistoryReadingAssosciationEntity, 0, null, null, null, null, "MedicalHistoryReadingAssosciation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StandardFindingTestReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStandardFindingTestReading
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("StandardFindingTestReading")[0], (int)Falcon.Data.EntityType.ReadingEntity, (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, 0, null, null, null, null, "StandardFindingTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestReading
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestReading")[0], (int)Falcon.Data.EntityType.ReadingEntity, (int)Falcon.Data.EntityType.TestReadingEntity, 0, null, null, null, null, "TestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation
		{
			get
			{
				IEntityRelation intermediateRelation = ReadingEntity.Relations.MedicalHistoryReadingAssosciationEntityUsingReadingId;
				intermediateRelation.SetAliases(string.Empty, "MedicalHistoryReadingAssosciation_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ReadingEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation"), null, "CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StandardFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStandardFindingCollectionViaStandardFindingTestReading
		{
			get
			{
				IEntityRelation intermediateRelation = ReadingEntity.Relations.StandardFindingTestReadingEntityUsingReadingId;
				intermediateRelation.SetAliases(string.Empty, "StandardFindingTestReading_");
				return new PrefetchPathElement2(new EntityCollection<StandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ReadingEntity, (int)Falcon.Data.EntityType.StandardFindingEntity, 0, null, null, GetRelationsForField("StandardFindingCollectionViaStandardFindingTestReading"), null, "StandardFindingCollectionViaStandardFindingTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaTestReading
		{
			get
			{
				IEntityRelation intermediateRelation = ReadingEntity.Relations.TestReadingEntityUsingReadingId;
				intermediateRelation.SetAliases(string.Empty, "TestReading_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ReadingEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaTestReading"), null, "TestCollectionViaTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaStandardFindingTestReading
		{
			get
			{
				IEntityRelation intermediateRelation = ReadingEntity.Relations.StandardFindingTestReadingEntityUsingReadingId;
				intermediateRelation.SetAliases(string.Empty, "StandardFindingTestReading_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ReadingEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaStandardFindingTestReading"), null, "TestCollectionViaStandardFindingTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ReadingEntity.CustomProperties;}
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
			get { return ReadingEntity.FieldsCustomProperties;}
		}

		/// <summary> The ReadingId property of the Entity Reading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblReading"."ReadingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ReadingId
		{
			get { return (System.Int32)GetValue((int)ReadingFieldIndex.ReadingId, true); }
			set	{ SetValue((int)ReadingFieldIndex.ReadingId, value); }
		}

		/// <summary> The Label property of the Entity Reading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblReading"."Label"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Label
		{
			get { return (System.String)GetValue((int)ReadingFieldIndex.Label, true); }
			set	{ SetValue((int)ReadingFieldIndex.Label, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity Reading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblReading"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)ReadingFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)ReadingFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The CreatedOn property of the Entity Reading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblReading"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedOn
		{
			get { return (System.DateTime)GetValue((int)ReadingFieldIndex.CreatedOn, true); }
			set	{ SetValue((int)ReadingFieldIndex.CreatedOn, value); }
		}

		/// <summary> The MeasurementUnit property of the Entity Reading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblReading"."MeasurementUnit"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MeasurementUnit
		{
			get { return (System.String)GetValue((int)ReadingFieldIndex.MeasurementUnit, true); }
			set	{ SetValue((int)ReadingFieldIndex.MeasurementUnit, value); }
		}

		/// <summary> The DefaultInputSource property of the Entity Reading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblReading"."DefaultInputSource"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DefaultInputSource
		{
			get { return (System.String)GetValue((int)ReadingFieldIndex.DefaultInputSource, true); }
			set	{ SetValue((int)ReadingFieldIndex.DefaultInputSource, value); }
		}

		/// <summary> The IsActive property of the Entity Reading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblReading"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ReadingFieldIndex.IsActive, true); }
			set	{ SetValue((int)ReadingFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FraminghamCalculationSourceEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FraminghamCalculationSourceEntity))]
		public virtual EntityCollection<FraminghamCalculationSourceEntity> FraminghamCalculationSource
		{
			get
			{
				if(_framinghamCalculationSource==null)
				{
					_framinghamCalculationSource = new EntityCollection<FraminghamCalculationSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FraminghamCalculationSourceEntityFactory)));
					_framinghamCalculationSource.SetContainingEntityInfo(this, "Reading");
				}
				return _framinghamCalculationSource;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalHistoryReadingAssosciationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalHistoryReadingAssosciationEntity))]
		public virtual EntityCollection<MedicalHistoryReadingAssosciationEntity> MedicalHistoryReadingAssosciation
		{
			get
			{
				if(_medicalHistoryReadingAssosciation==null)
				{
					_medicalHistoryReadingAssosciation = new EntityCollection<MedicalHistoryReadingAssosciationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalHistoryReadingAssosciationEntityFactory)));
					_medicalHistoryReadingAssosciation.SetContainingEntityInfo(this, "Reading");
				}
				return _medicalHistoryReadingAssosciation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StandardFindingTestReadingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StandardFindingTestReadingEntity))]
		public virtual EntityCollection<StandardFindingTestReadingEntity> StandardFindingTestReading
		{
			get
			{
				if(_standardFindingTestReading==null)
				{
					_standardFindingTestReading = new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory)));
					_standardFindingTestReading.SetContainingEntityInfo(this, "Reading");
				}
				return _standardFindingTestReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestReadingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestReadingEntity))]
		public virtual EntityCollection<TestReadingEntity> TestReading
		{
			get
			{
				if(_testReading==null)
				{
					_testReading = new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory)));
					_testReading.SetContainingEntityInfo(this, "Reading");
				}
				return _testReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation
		{
			get
			{
				if(_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation==null)
				{
					_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation.IsReadOnly=true;
				}
				return _customerHealthQuestionsCollectionViaMedicalHistoryReadingAssosciation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StandardFindingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StandardFindingEntity))]
		public virtual EntityCollection<StandardFindingEntity> StandardFindingCollectionViaStandardFindingTestReading
		{
			get
			{
				if(_standardFindingCollectionViaStandardFindingTestReading==null)
				{
					_standardFindingCollectionViaStandardFindingTestReading = new EntityCollection<StandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingEntityFactory)));
					_standardFindingCollectionViaStandardFindingTestReading.IsReadOnly=true;
				}
				return _standardFindingCollectionViaStandardFindingTestReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaTestReading
		{
			get
			{
				if(_testCollectionViaTestReading==null)
				{
					_testCollectionViaTestReading = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaTestReading.IsReadOnly=true;
				}
				return _testCollectionViaTestReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaStandardFindingTestReading
		{
			get
			{
				if(_testCollectionViaStandardFindingTestReading==null)
				{
					_testCollectionViaStandardFindingTestReading = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaStandardFindingTestReading.IsReadOnly=true;
				}
				return _testCollectionViaStandardFindingTestReading;
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
			get { return (int)Falcon.Data.EntityType.ReadingEntity; }
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
