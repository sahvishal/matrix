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
	/// Entity class which represents the entity 'StandardFindingTestReading'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class StandardFindingTestReadingEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerEventReadingEntity> _customerEventReading;
		private EntityCollection<CustomerEventTestStandardFindingEntity> _customerEventTestStandardFinding;
		private EntityCollection<CustomerEventScreeningTestsEntity> _customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding;
		private EntityCollection<CustomerEventScreeningTestsEntity> _customerEventScreeningTestsCollectionViaCustomerEventReading;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerEventReading;
		private EntityCollection<TestReadingEntity> _testReadingCollectionViaCustomerEventReading;
		private ReadingEntity _reading;
		private StandardFindingEntity _standardFinding;
		private TestEntity _test;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Reading</summary>
			public static readonly string Reading = "Reading";
			/// <summary>Member name StandardFinding</summary>
			public static readonly string StandardFinding = "StandardFinding";
			/// <summary>Member name Test</summary>
			public static readonly string Test = "Test";
			/// <summary>Member name CustomerEventReading</summary>
			public static readonly string CustomerEventReading = "CustomerEventReading";
			/// <summary>Member name CustomerEventTestStandardFinding</summary>
			public static readonly string CustomerEventTestStandardFinding = "CustomerEventTestStandardFinding";
			/// <summary>Member name CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding</summary>
			public static readonly string CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding = "CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding";
			/// <summary>Member name CustomerEventScreeningTestsCollectionViaCustomerEventReading</summary>
			public static readonly string CustomerEventScreeningTestsCollectionViaCustomerEventReading = "CustomerEventScreeningTestsCollectionViaCustomerEventReading";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerEventReading</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerEventReading = "OrganizationRoleUserCollectionViaCustomerEventReading";
			/// <summary>Member name TestReadingCollectionViaCustomerEventReading</summary>
			public static readonly string TestReadingCollectionViaCustomerEventReading = "TestReadingCollectionViaCustomerEventReading";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static StandardFindingTestReadingEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public StandardFindingTestReadingEntity():base("StandardFindingTestReadingEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public StandardFindingTestReadingEntity(IEntityFields2 fields):base("StandardFindingTestReadingEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this StandardFindingTestReadingEntity</param>
		public StandardFindingTestReadingEntity(IValidator validator):base("StandardFindingTestReadingEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="standardFindingTestReadingId">PK value for StandardFindingTestReading which data should be fetched into this StandardFindingTestReading object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public StandardFindingTestReadingEntity(System.Int32 standardFindingTestReadingId):base("StandardFindingTestReadingEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.StandardFindingTestReadingId = standardFindingTestReadingId;
		}

		/// <summary> CTor</summary>
		/// <param name="standardFindingTestReadingId">PK value for StandardFindingTestReading which data should be fetched into this StandardFindingTestReading object</param>
		/// <param name="validator">The custom validator object for this StandardFindingTestReadingEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public StandardFindingTestReadingEntity(System.Int32 standardFindingTestReadingId, IValidator validator):base("StandardFindingTestReadingEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.StandardFindingTestReadingId = standardFindingTestReadingId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected StandardFindingTestReadingEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerEventReading = (EntityCollection<CustomerEventReadingEntity>)info.GetValue("_customerEventReading", typeof(EntityCollection<CustomerEventReadingEntity>));
				_customerEventTestStandardFinding = (EntityCollection<CustomerEventTestStandardFindingEntity>)info.GetValue("_customerEventTestStandardFinding", typeof(EntityCollection<CustomerEventTestStandardFindingEntity>));
				_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding = (EntityCollection<CustomerEventScreeningTestsEntity>)info.GetValue("_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding", typeof(EntityCollection<CustomerEventScreeningTestsEntity>));
				_customerEventScreeningTestsCollectionViaCustomerEventReading = (EntityCollection<CustomerEventScreeningTestsEntity>)info.GetValue("_customerEventScreeningTestsCollectionViaCustomerEventReading", typeof(EntityCollection<CustomerEventScreeningTestsEntity>));
				_organizationRoleUserCollectionViaCustomerEventReading = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerEventReading", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_testReadingCollectionViaCustomerEventReading = (EntityCollection<TestReadingEntity>)info.GetValue("_testReadingCollectionViaCustomerEventReading", typeof(EntityCollection<TestReadingEntity>));
				_reading = (ReadingEntity)info.GetValue("_reading", typeof(ReadingEntity));
				if(_reading!=null)
				{
					_reading.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_standardFinding = (StandardFindingEntity)info.GetValue("_standardFinding", typeof(StandardFindingEntity));
				if(_standardFinding!=null)
				{
					_standardFinding.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_test = (TestEntity)info.GetValue("_test", typeof(TestEntity));
				if(_test!=null)
				{
					_test.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((StandardFindingTestReadingFieldIndex)fieldIndex)
			{
				case StandardFindingTestReadingFieldIndex.StandardFindingId:
					DesetupSyncStandardFinding(true, false);
					break;
				case StandardFindingTestReadingFieldIndex.TestId:
					DesetupSyncTest(true, false);
					break;
				case StandardFindingTestReadingFieldIndex.ReadingId:
					DesetupSyncReading(true, false);
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
				case "Reading":
					this.Reading = (ReadingEntity)entity;
					break;
				case "StandardFinding":
					this.StandardFinding = (StandardFindingEntity)entity;
					break;
				case "Test":
					this.Test = (TestEntity)entity;
					break;
				case "CustomerEventReading":
					this.CustomerEventReading.Add((CustomerEventReadingEntity)entity);
					break;
				case "CustomerEventTestStandardFinding":
					this.CustomerEventTestStandardFinding.Add((CustomerEventTestStandardFindingEntity)entity);
					break;
				case "CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding":
					this.CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding.IsReadOnly = false;
					this.CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding.Add((CustomerEventScreeningTestsEntity)entity);
					this.CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding.IsReadOnly = true;
					break;
				case "CustomerEventScreeningTestsCollectionViaCustomerEventReading":
					this.CustomerEventScreeningTestsCollectionViaCustomerEventReading.IsReadOnly = false;
					this.CustomerEventScreeningTestsCollectionViaCustomerEventReading.Add((CustomerEventScreeningTestsEntity)entity);
					this.CustomerEventScreeningTestsCollectionViaCustomerEventReading.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventReading":
					this.OrganizationRoleUserCollectionViaCustomerEventReading.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerEventReading.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerEventReading.IsReadOnly = true;
					break;
				case "TestReadingCollectionViaCustomerEventReading":
					this.TestReadingCollectionViaCustomerEventReading.IsReadOnly = false;
					this.TestReadingCollectionViaCustomerEventReading.Add((TestReadingEntity)entity);
					this.TestReadingCollectionViaCustomerEventReading.IsReadOnly = true;
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
			return StandardFindingTestReadingEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Reading":
					toReturn.Add(StandardFindingTestReadingEntity.Relations.ReadingEntityUsingReadingId);
					break;
				case "StandardFinding":
					toReturn.Add(StandardFindingTestReadingEntity.Relations.StandardFindingEntityUsingStandardFindingId);
					break;
				case "Test":
					toReturn.Add(StandardFindingTestReadingEntity.Relations.TestEntityUsingTestId);
					break;
				case "CustomerEventReading":
					toReturn.Add(StandardFindingTestReadingEntity.Relations.CustomerEventReadingEntityUsingStandardFindingTestReadingId);
					break;
				case "CustomerEventTestStandardFinding":
					toReturn.Add(StandardFindingTestReadingEntity.Relations.CustomerEventTestStandardFindingEntityUsingStandardFindingTestReadingId);
					break;
				case "CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding":
					toReturn.Add(StandardFindingTestReadingEntity.Relations.CustomerEventTestStandardFindingEntityUsingStandardFindingTestReadingId, "StandardFindingTestReadingEntity__", "CustomerEventTestStandardFinding_", JoinHint.None);
					toReturn.Add(CustomerEventTestStandardFindingEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId, "CustomerEventTestStandardFinding_", string.Empty, JoinHint.None);
					break;
				case "CustomerEventScreeningTestsCollectionViaCustomerEventReading":
					toReturn.Add(StandardFindingTestReadingEntity.Relations.CustomerEventReadingEntityUsingStandardFindingTestReadingId, "StandardFindingTestReadingEntity__", "CustomerEventReading_", JoinHint.None);
					toReturn.Add(CustomerEventReadingEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId, "CustomerEventReading_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventReading":
					toReturn.Add(StandardFindingTestReadingEntity.Relations.CustomerEventReadingEntityUsingStandardFindingTestReadingId, "StandardFindingTestReadingEntity__", "CustomerEventReading_", JoinHint.None);
					toReturn.Add(CustomerEventReadingEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId, "CustomerEventReading_", string.Empty, JoinHint.None);
					break;
				case "TestReadingCollectionViaCustomerEventReading":
					toReturn.Add(StandardFindingTestReadingEntity.Relations.CustomerEventReadingEntityUsingStandardFindingTestReadingId, "StandardFindingTestReadingEntity__", "CustomerEventReading_", JoinHint.None);
					toReturn.Add(CustomerEventReadingEntity.Relations.TestReadingEntityUsingTestReadingId, "CustomerEventReading_", string.Empty, JoinHint.None);
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
				case "Reading":
					SetupSyncReading(relatedEntity);
					break;
				case "StandardFinding":
					SetupSyncStandardFinding(relatedEntity);
					break;
				case "Test":
					SetupSyncTest(relatedEntity);
					break;
				case "CustomerEventReading":
					this.CustomerEventReading.Add((CustomerEventReadingEntity)relatedEntity);
					break;
				case "CustomerEventTestStandardFinding":
					this.CustomerEventTestStandardFinding.Add((CustomerEventTestStandardFindingEntity)relatedEntity);
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
				case "Reading":
					DesetupSyncReading(false, true);
					break;
				case "StandardFinding":
					DesetupSyncStandardFinding(false, true);
					break;
				case "Test":
					DesetupSyncTest(false, true);
					break;
				case "CustomerEventReading":
					base.PerformRelatedEntityRemoval(this.CustomerEventReading, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventTestStandardFinding":
					base.PerformRelatedEntityRemoval(this.CustomerEventTestStandardFinding, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_reading!=null)
			{
				toReturn.Add(_reading);
			}
			if(_standardFinding!=null)
			{
				toReturn.Add(_standardFinding);
			}
			if(_test!=null)
			{
				toReturn.Add(_test);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerEventReading);
			toReturn.Add(this.CustomerEventTestStandardFinding);

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
				info.AddValue("_customerEventReading", ((_customerEventReading!=null) && (_customerEventReading.Count>0) && !this.MarkedForDeletion)?_customerEventReading:null);
				info.AddValue("_customerEventTestStandardFinding", ((_customerEventTestStandardFinding!=null) && (_customerEventTestStandardFinding.Count>0) && !this.MarkedForDeletion)?_customerEventTestStandardFinding:null);
				info.AddValue("_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding", ((_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding!=null) && (_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding.Count>0) && !this.MarkedForDeletion)?_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding:null);
				info.AddValue("_customerEventScreeningTestsCollectionViaCustomerEventReading", ((_customerEventScreeningTestsCollectionViaCustomerEventReading!=null) && (_customerEventScreeningTestsCollectionViaCustomerEventReading.Count>0) && !this.MarkedForDeletion)?_customerEventScreeningTestsCollectionViaCustomerEventReading:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerEventReading", ((_organizationRoleUserCollectionViaCustomerEventReading!=null) && (_organizationRoleUserCollectionViaCustomerEventReading.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerEventReading:null);
				info.AddValue("_testReadingCollectionViaCustomerEventReading", ((_testReadingCollectionViaCustomerEventReading!=null) && (_testReadingCollectionViaCustomerEventReading.Count>0) && !this.MarkedForDeletion)?_testReadingCollectionViaCustomerEventReading:null);
				info.AddValue("_reading", (!this.MarkedForDeletion?_reading:null));
				info.AddValue("_standardFinding", (!this.MarkedForDeletion?_standardFinding:null));
				info.AddValue("_test", (!this.MarkedForDeletion?_test:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(StandardFindingTestReadingFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(StandardFindingTestReadingFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new StandardFindingTestReadingRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventReadingFields.StandardFindingTestReadingId, null, ComparisonOperator.Equal, this.StandardFindingTestReadingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTestStandardFinding' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestStandardFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestStandardFindingFields.StandardFindingTestReadingId, null, ComparisonOperator.Equal, this.StandardFindingTestReadingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventScreeningTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingTestReadingFields.StandardFindingTestReadingId, null, ComparisonOperator.Equal, this.StandardFindingTestReadingId, "StandardFindingTestReadingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventScreeningTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventScreeningTestsCollectionViaCustomerEventReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventScreeningTestsCollectionViaCustomerEventReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingTestReadingFields.StandardFindingTestReadingId, null, ComparisonOperator.Equal, this.StandardFindingTestReadingId, "StandardFindingTestReadingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerEventReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerEventReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingTestReadingFields.StandardFindingTestReadingId, null, ComparisonOperator.Equal, this.StandardFindingTestReadingId, "StandardFindingTestReadingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestReadingCollectionViaCustomerEventReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestReadingCollectionViaCustomerEventReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingTestReadingFields.StandardFindingTestReadingId, null, ComparisonOperator.Equal, this.StandardFindingTestReadingId, "StandardFindingTestReadingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Reading' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReadingFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'StandardFinding' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStandardFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingFields.StandardFindingId, null, ComparisonOperator.Equal, this.StandardFindingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Test' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.StandardFindingTestReadingEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerEventReading);
			collectionsQueue.Enqueue(this._customerEventTestStandardFinding);
			collectionsQueue.Enqueue(this._customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding);
			collectionsQueue.Enqueue(this._customerEventScreeningTestsCollectionViaCustomerEventReading);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerEventReading);
			collectionsQueue.Enqueue(this._testReadingCollectionViaCustomerEventReading);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerEventReading = (EntityCollection<CustomerEventReadingEntity>) collectionsQueue.Dequeue();
			this._customerEventTestStandardFinding = (EntityCollection<CustomerEventTestStandardFindingEntity>) collectionsQueue.Dequeue();
			this._customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding = (EntityCollection<CustomerEventScreeningTestsEntity>) collectionsQueue.Dequeue();
			this._customerEventScreeningTestsCollectionViaCustomerEventReading = (EntityCollection<CustomerEventScreeningTestsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerEventReading = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._testReadingCollectionViaCustomerEventReading = (EntityCollection<TestReadingEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerEventReading != null)
			{
				return true;
			}
			if (this._customerEventTestStandardFinding != null)
			{
				return true;
			}
			if (this._customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding != null)
			{
				return true;
			}
			if (this._customerEventScreeningTestsCollectionViaCustomerEventReading != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerEventReading != null)
			{
				return true;
			}
			if (this._testReadingCollectionViaCustomerEventReading != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestStandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestStandardFindingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Reading", _reading);
			toReturn.Add("StandardFinding", _standardFinding);
			toReturn.Add("Test", _test);
			toReturn.Add("CustomerEventReading", _customerEventReading);
			toReturn.Add("CustomerEventTestStandardFinding", _customerEventTestStandardFinding);
			toReturn.Add("CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding", _customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding);
			toReturn.Add("CustomerEventScreeningTestsCollectionViaCustomerEventReading", _customerEventScreeningTestsCollectionViaCustomerEventReading);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerEventReading", _organizationRoleUserCollectionViaCustomerEventReading);
			toReturn.Add("TestReadingCollectionViaCustomerEventReading", _testReadingCollectionViaCustomerEventReading);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerEventReading!=null)
			{
				_customerEventReading.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestStandardFinding!=null)
			{
				_customerEventTestStandardFinding.ActiveContext = base.ActiveContext;
			}
			if(_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding!=null)
			{
				_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding.ActiveContext = base.ActiveContext;
			}
			if(_customerEventScreeningTestsCollectionViaCustomerEventReading!=null)
			{
				_customerEventScreeningTestsCollectionViaCustomerEventReading.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerEventReading!=null)
			{
				_organizationRoleUserCollectionViaCustomerEventReading.ActiveContext = base.ActiveContext;
			}
			if(_testReadingCollectionViaCustomerEventReading!=null)
			{
				_testReadingCollectionViaCustomerEventReading.ActiveContext = base.ActiveContext;
			}
			if(_reading!=null)
			{
				_reading.ActiveContext = base.ActiveContext;
			}
			if(_standardFinding!=null)
			{
				_standardFinding.ActiveContext = base.ActiveContext;
			}
			if(_test!=null)
			{
				_test.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerEventReading = null;
			_customerEventTestStandardFinding = null;
			_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding = null;
			_customerEventScreeningTestsCollectionViaCustomerEventReading = null;
			_organizationRoleUserCollectionViaCustomerEventReading = null;
			_testReadingCollectionViaCustomerEventReading = null;
			_reading = null;
			_standardFinding = null;
			_test = null;

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

			_fieldsCustomProperties.Add("StandardFindingTestReadingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StandardFindingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReadingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _reading</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncReading(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _reading, new PropertyChangedEventHandler( OnReadingPropertyChanged ), "Reading", StandardFindingTestReadingEntity.Relations.ReadingEntityUsingReadingId, true, signalRelatedEntity, "StandardFindingTestReading", resetFKFields, new int[] { (int)StandardFindingTestReadingFieldIndex.ReadingId } );		
			_reading = null;
		}

		/// <summary> setups the sync logic for member _reading</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncReading(IEntity2 relatedEntity)
		{
			if(_reading!=relatedEntity)
			{
				DesetupSyncReading(true, true);
				_reading = (ReadingEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _reading, new PropertyChangedEventHandler( OnReadingPropertyChanged ), "Reading", StandardFindingTestReadingEntity.Relations.ReadingEntityUsingReadingId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReadingPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _standardFinding</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncStandardFinding(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _standardFinding, new PropertyChangedEventHandler( OnStandardFindingPropertyChanged ), "StandardFinding", StandardFindingTestReadingEntity.Relations.StandardFindingEntityUsingStandardFindingId, true, signalRelatedEntity, "StandardFindingTestReading", resetFKFields, new int[] { (int)StandardFindingTestReadingFieldIndex.StandardFindingId } );		
			_standardFinding = null;
		}

		/// <summary> setups the sync logic for member _standardFinding</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncStandardFinding(IEntity2 relatedEntity)
		{
			if(_standardFinding!=relatedEntity)
			{
				DesetupSyncStandardFinding(true, true);
				_standardFinding = (StandardFindingEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _standardFinding, new PropertyChangedEventHandler( OnStandardFindingPropertyChanged ), "StandardFinding", StandardFindingTestReadingEntity.Relations.StandardFindingEntityUsingStandardFindingId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnStandardFindingPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _test</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTest(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", StandardFindingTestReadingEntity.Relations.TestEntityUsingTestId, true, signalRelatedEntity, "StandardFindingTestReading", resetFKFields, new int[] { (int)StandardFindingTestReadingFieldIndex.TestId } );		
			_test = null;
		}

		/// <summary> setups the sync logic for member _test</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTest(IEntity2 relatedEntity)
		{
			if(_test!=relatedEntity)
			{
				DesetupSyncTest(true, true);
				_test = (TestEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", StandardFindingTestReadingEntity.Relations.TestEntityUsingTestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTestPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this StandardFindingTestReadingEntity</param>
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
		public  static StandardFindingTestReadingRelations Relations
		{
			get	{ return new StandardFindingTestReadingRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventReading
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventReading")[0], (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, (int)Falcon.Data.EntityType.CustomerEventReadingEntity, 0, null, null, null, null, "CustomerEventReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTestStandardFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestStandardFinding
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventTestStandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestStandardFindingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTestStandardFinding")[0], (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, (int)Falcon.Data.EntityType.CustomerEventTestStandardFindingEntity, 0, null, null, null, null, "CustomerEventTestStandardFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventScreeningTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding
		{
			get
			{
				IEntityRelation intermediateRelation = StandardFindingTestReadingEntity.Relations.CustomerEventTestStandardFindingEntityUsingStandardFindingTestReadingId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestStandardFinding_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, 0, null, null, GetRelationsForField("CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding"), null, "CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventScreeningTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventScreeningTestsCollectionViaCustomerEventReading
		{
			get
			{
				IEntityRelation intermediateRelation = StandardFindingTestReadingEntity.Relations.CustomerEventReadingEntityUsingStandardFindingTestReadingId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventReading_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, 0, null, null, GetRelationsForField("CustomerEventScreeningTestsCollectionViaCustomerEventReading"), null, "CustomerEventScreeningTestsCollectionViaCustomerEventReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerEventReading
		{
			get
			{
				IEntityRelation intermediateRelation = StandardFindingTestReadingEntity.Relations.CustomerEventReadingEntityUsingStandardFindingTestReadingId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventReading_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerEventReading"), null, "OrganizationRoleUserCollectionViaCustomerEventReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestReadingCollectionViaCustomerEventReading
		{
			get
			{
				IEntityRelation intermediateRelation = StandardFindingTestReadingEntity.Relations.CustomerEventReadingEntityUsingStandardFindingTestReadingId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventReading_");
				return new PrefetchPathElement2(new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, (int)Falcon.Data.EntityType.TestReadingEntity, 0, null, null, GetRelationsForField("TestReadingCollectionViaCustomerEventReading"), null, "TestReadingCollectionViaCustomerEventReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Reading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReading
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("Reading")[0], (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, (int)Falcon.Data.EntityType.ReadingEntity, 0, null, null, null, null, "Reading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StandardFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStandardFinding
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingEntityFactory))),
					(IEntityRelation)GetRelationsForField("StandardFinding")[0], (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, (int)Falcon.Data.EntityType.StandardFindingEntity, 0, null, null, null, null, "StandardFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTest
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))),
					(IEntityRelation)GetRelationsForField("Test")[0], (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return StandardFindingTestReadingEntity.CustomProperties;}
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
			get { return StandardFindingTestReadingEntity.FieldsCustomProperties;}
		}

		/// <summary> The StandardFindingTestReadingId property of the Entity StandardFindingTestReading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFindingTestReading"."StandardFindingTestReadingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 StandardFindingTestReadingId
		{
			get { return (System.Int32)GetValue((int)StandardFindingTestReadingFieldIndex.StandardFindingTestReadingId, true); }
			set	{ SetValue((int)StandardFindingTestReadingFieldIndex.StandardFindingTestReadingId, value); }
		}

		/// <summary> The StandardFindingId property of the Entity StandardFindingTestReading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFindingTestReading"."StandardFindingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 StandardFindingId
		{
			get { return (System.Int32)GetValue((int)StandardFindingTestReadingFieldIndex.StandardFindingId, true); }
			set	{ SetValue((int)StandardFindingTestReadingFieldIndex.StandardFindingId, value); }
		}

		/// <summary> The TestId property of the Entity StandardFindingTestReading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFindingTestReading"."TestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TestId
		{
			get { return (System.Int64)GetValue((int)StandardFindingTestReadingFieldIndex.TestId, true); }
			set	{ SetValue((int)StandardFindingTestReadingFieldIndex.TestId, value); }
		}

		/// <summary> The ReadingId property of the Entity StandardFindingTestReading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFindingTestReading"."ReadingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ReadingId
		{
			get { return (Nullable<System.Int32>)GetValue((int)StandardFindingTestReadingFieldIndex.ReadingId, false); }
			set	{ SetValue((int)StandardFindingTestReadingFieldIndex.ReadingId, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity StandardFindingTestReading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFindingTestReading"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)StandardFindingTestReadingFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)StandardFindingTestReadingFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The CreatedOn property of the Entity StandardFindingTestReading<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblStandardFindingTestReading"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedOn
		{
			get { return (System.DateTime)GetValue((int)StandardFindingTestReadingFieldIndex.CreatedOn, true); }
			set	{ SetValue((int)StandardFindingTestReadingFieldIndex.CreatedOn, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventReadingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventReadingEntity))]
		public virtual EntityCollection<CustomerEventReadingEntity> CustomerEventReading
		{
			get
			{
				if(_customerEventReading==null)
				{
					_customerEventReading = new EntityCollection<CustomerEventReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventReadingEntityFactory)));
					_customerEventReading.SetContainingEntityInfo(this, "StandardFindingTestReading");
				}
				return _customerEventReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestStandardFindingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestStandardFindingEntity))]
		public virtual EntityCollection<CustomerEventTestStandardFindingEntity> CustomerEventTestStandardFinding
		{
			get
			{
				if(_customerEventTestStandardFinding==null)
				{
					_customerEventTestStandardFinding = new EntityCollection<CustomerEventTestStandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestStandardFindingEntityFactory)));
					_customerEventTestStandardFinding.SetContainingEntityInfo(this, "StandardFindingTestReading");
				}
				return _customerEventTestStandardFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventScreeningTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventScreeningTestsEntity))]
		public virtual EntityCollection<CustomerEventScreeningTestsEntity> CustomerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding
		{
			get
			{
				if(_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding==null)
				{
					_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding = new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory)));
					_customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding.IsReadOnly=true;
				}
				return _customerEventScreeningTestsCollectionViaCustomerEventTestStandardFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventScreeningTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventScreeningTestsEntity))]
		public virtual EntityCollection<CustomerEventScreeningTestsEntity> CustomerEventScreeningTestsCollectionViaCustomerEventReading
		{
			get
			{
				if(_customerEventScreeningTestsCollectionViaCustomerEventReading==null)
				{
					_customerEventScreeningTestsCollectionViaCustomerEventReading = new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory)));
					_customerEventScreeningTestsCollectionViaCustomerEventReading.IsReadOnly=true;
				}
				return _customerEventScreeningTestsCollectionViaCustomerEventReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerEventReading
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerEventReading==null)
				{
					_organizationRoleUserCollectionViaCustomerEventReading = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerEventReading.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerEventReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestReadingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestReadingEntity))]
		public virtual EntityCollection<TestReadingEntity> TestReadingCollectionViaCustomerEventReading
		{
			get
			{
				if(_testReadingCollectionViaCustomerEventReading==null)
				{
					_testReadingCollectionViaCustomerEventReading = new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory)));
					_testReadingCollectionViaCustomerEventReading.IsReadOnly=true;
				}
				return _testReadingCollectionViaCustomerEventReading;
			}
		}

		/// <summary> Gets / sets related entity of type 'ReadingEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ReadingEntity Reading
		{
			get
			{
				return _reading;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncReading(value);
				}
				else
				{
					if(value==null)
					{
						if(_reading != null)
						{
							_reading.UnsetRelatedEntity(this, "StandardFindingTestReading");
						}
					}
					else
					{
						if(_reading!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "StandardFindingTestReading");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'StandardFindingEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual StandardFindingEntity StandardFinding
		{
			get
			{
				return _standardFinding;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncStandardFinding(value);
				}
				else
				{
					if(value==null)
					{
						if(_standardFinding != null)
						{
							_standardFinding.UnsetRelatedEntity(this, "StandardFindingTestReading");
						}
					}
					else
					{
						if(_standardFinding!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "StandardFindingTestReading");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TestEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TestEntity Test
		{
			get
			{
				return _test;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTest(value);
				}
				else
				{
					if(value==null)
					{
						if(_test != null)
						{
							_test.UnsetRelatedEntity(this, "StandardFindingTestReading");
						}
					}
					else
					{
						if(_test!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "StandardFindingTestReading");
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
			get { return (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity; }
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
