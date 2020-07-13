///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:32 AM
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
	/// Entity class which represents the entity 'MedicalVendorPayments'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MedicalVendorPaymentsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MedicalVendorMvuserCustomerPaymentsEntity> _medicalVendorMvuserCustomerPayments;
		private EntityCollection<MedicalVendorTestPaymentsEntity> _medicalVendorTestPayments;
		private EntityCollection<CustomerEventTestsEntity> _customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments;
		private EntityCollection<MedicalVendorMvuserEntity> _medicalVendorMvuserCollectionViaMedicalVendorTestPayments;
		private EntityCollection<MedicalVendorMvuserEntity> _medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments;
		private EntityCollection<TestEntity> _testCollectionViaMedicalVendorTestPayments;
		private MedicalVendorEntity _medicalVendor;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name MedicalVendor</summary>
			public static readonly string MedicalVendor = "MedicalVendor";
			/// <summary>Member name MedicalVendorMvuserCustomerPayments</summary>
			public static readonly string MedicalVendorMvuserCustomerPayments = "MedicalVendorMvuserCustomerPayments";
			/// <summary>Member name MedicalVendorTestPayments</summary>
			public static readonly string MedicalVendorTestPayments = "MedicalVendorTestPayments";
			/// <summary>Member name CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments</summary>
			public static readonly string CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments = "CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments";
			/// <summary>Member name MedicalVendorMvuserCollectionViaMedicalVendorTestPayments</summary>
			public static readonly string MedicalVendorMvuserCollectionViaMedicalVendorTestPayments = "MedicalVendorMvuserCollectionViaMedicalVendorTestPayments";
			/// <summary>Member name MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments</summary>
			public static readonly string MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments = "MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments";
			/// <summary>Member name TestCollectionViaMedicalVendorTestPayments</summary>
			public static readonly string TestCollectionViaMedicalVendorTestPayments = "TestCollectionViaMedicalVendorTestPayments";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MedicalVendorPaymentsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MedicalVendorPaymentsEntity():base("MedicalVendorPaymentsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MedicalVendorPaymentsEntity(IEntityFields2 fields):base("MedicalVendorPaymentsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MedicalVendorPaymentsEntity</param>
		public MedicalVendorPaymentsEntity(IValidator validator):base("MedicalVendorPaymentsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="medicalVendorPaymentId">PK value for MedicalVendorPayments which data should be fetched into this MedicalVendorPayments object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorPaymentsEntity(System.Int64 medicalVendorPaymentId):base("MedicalVendorPaymentsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MedicalVendorPaymentId = medicalVendorPaymentId;
		}

		/// <summary> CTor</summary>
		/// <param name="medicalVendorPaymentId">PK value for MedicalVendorPayments which data should be fetched into this MedicalVendorPayments object</param>
		/// <param name="validator">The custom validator object for this MedicalVendorPaymentsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorPaymentsEntity(System.Int64 medicalVendorPaymentId, IValidator validator):base("MedicalVendorPaymentsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MedicalVendorPaymentId = medicalVendorPaymentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MedicalVendorPaymentsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_medicalVendorMvuserCustomerPayments = (EntityCollection<MedicalVendorMvuserCustomerPaymentsEntity>)info.GetValue("_medicalVendorMvuserCustomerPayments", typeof(EntityCollection<MedicalVendorMvuserCustomerPaymentsEntity>));
				_medicalVendorTestPayments = (EntityCollection<MedicalVendorTestPaymentsEntity>)info.GetValue("_medicalVendorTestPayments", typeof(EntityCollection<MedicalVendorTestPaymentsEntity>));
				_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments = (EntityCollection<CustomerEventTestsEntity>)info.GetValue("_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments", typeof(EntityCollection<CustomerEventTestsEntity>));
				_medicalVendorMvuserCollectionViaMedicalVendorTestPayments = (EntityCollection<MedicalVendorMvuserEntity>)info.GetValue("_medicalVendorMvuserCollectionViaMedicalVendorTestPayments", typeof(EntityCollection<MedicalVendorMvuserEntity>));
				_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments = (EntityCollection<MedicalVendorMvuserEntity>)info.GetValue("_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments", typeof(EntityCollection<MedicalVendorMvuserEntity>));
				_testCollectionViaMedicalVendorTestPayments = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaMedicalVendorTestPayments", typeof(EntityCollection<TestEntity>));
				_medicalVendor = (MedicalVendorEntity)info.GetValue("_medicalVendor", typeof(MedicalVendorEntity));
				if(_medicalVendor!=null)
				{
					_medicalVendor.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MedicalVendorPaymentsFieldIndex)fieldIndex)
			{
				case MedicalVendorPaymentsFieldIndex.MedicalVendorId:
					DesetupSyncMedicalVendor(true, false);
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
				case "MedicalVendor":
					this.MedicalVendor = (MedicalVendorEntity)entity;
					break;
				case "MedicalVendorMvuserCustomerPayments":
					this.MedicalVendorMvuserCustomerPayments.Add((MedicalVendorMvuserCustomerPaymentsEntity)entity);
					break;
				case "MedicalVendorTestPayments":
					this.MedicalVendorTestPayments.Add((MedicalVendorTestPaymentsEntity)entity);
					break;
				case "CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments":
					this.CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments.IsReadOnly = false;
					this.CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments.Add((CustomerEventTestsEntity)entity);
					this.CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments.IsReadOnly = true;
					break;
				case "MedicalVendorMvuserCollectionViaMedicalVendorTestPayments":
					this.MedicalVendorMvuserCollectionViaMedicalVendorTestPayments.IsReadOnly = false;
					this.MedicalVendorMvuserCollectionViaMedicalVendorTestPayments.Add((MedicalVendorMvuserEntity)entity);
					this.MedicalVendorMvuserCollectionViaMedicalVendorTestPayments.IsReadOnly = true;
					break;
				case "MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments":
					this.MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments.IsReadOnly = false;
					this.MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments.Add((MedicalVendorMvuserEntity)entity);
					this.MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments.IsReadOnly = true;
					break;
				case "TestCollectionViaMedicalVendorTestPayments":
					this.TestCollectionViaMedicalVendorTestPayments.IsReadOnly = false;
					this.TestCollectionViaMedicalVendorTestPayments.Add((TestEntity)entity);
					this.TestCollectionViaMedicalVendorTestPayments.IsReadOnly = true;
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
			return MedicalVendorPaymentsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "MedicalVendor":
					toReturn.Add(MedicalVendorPaymentsEntity.Relations.MedicalVendorEntityUsingMedicalVendorId);
					break;
				case "MedicalVendorMvuserCustomerPayments":
					toReturn.Add(MedicalVendorPaymentsEntity.Relations.MedicalVendorMvuserCustomerPaymentsEntityUsingMedicalVendorPaymentId);
					break;
				case "MedicalVendorTestPayments":
					toReturn.Add(MedicalVendorPaymentsEntity.Relations.MedicalVendorTestPaymentsEntityUsingMedicalVendorPaymentId);
					break;
				case "CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments":
					toReturn.Add(MedicalVendorPaymentsEntity.Relations.MedicalVendorMvuserCustomerPaymentsEntityUsingMedicalVendorPaymentId, "MedicalVendorPaymentsEntity__", "MedicalVendorMvuserCustomerPayments_", JoinHint.None);
					toReturn.Add(MedicalVendorMvuserCustomerPaymentsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, "MedicalVendorMvuserCustomerPayments_", string.Empty, JoinHint.None);
					break;
				case "MedicalVendorMvuserCollectionViaMedicalVendorTestPayments":
					toReturn.Add(MedicalVendorPaymentsEntity.Relations.MedicalVendorTestPaymentsEntityUsingMedicalVendorPaymentId, "MedicalVendorPaymentsEntity__", "MedicalVendorTestPayments_", JoinHint.None);
					toReturn.Add(MedicalVendorTestPaymentsEntity.Relations.MedicalVendorMvuserEntityUsingMedicalVendorMvuserId, "MedicalVendorTestPayments_", string.Empty, JoinHint.None);
					break;
				case "MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments":
					toReturn.Add(MedicalVendorPaymentsEntity.Relations.MedicalVendorMvuserCustomerPaymentsEntityUsingMedicalVendorPaymentId, "MedicalVendorPaymentsEntity__", "MedicalVendorMvuserCustomerPayments_", JoinHint.None);
					toReturn.Add(MedicalVendorMvuserCustomerPaymentsEntity.Relations.MedicalVendorMvuserEntityUsingMedicalVendorMvuserId, "MedicalVendorMvuserCustomerPayments_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaMedicalVendorTestPayments":
					toReturn.Add(MedicalVendorPaymentsEntity.Relations.MedicalVendorTestPaymentsEntityUsingMedicalVendorPaymentId, "MedicalVendorPaymentsEntity__", "MedicalVendorTestPayments_", JoinHint.None);
					toReturn.Add(MedicalVendorTestPaymentsEntity.Relations.TestEntityUsingTestId, "MedicalVendorTestPayments_", string.Empty, JoinHint.None);
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
				case "MedicalVendor":
					SetupSyncMedicalVendor(relatedEntity);
					break;
				case "MedicalVendorMvuserCustomerPayments":
					this.MedicalVendorMvuserCustomerPayments.Add((MedicalVendorMvuserCustomerPaymentsEntity)relatedEntity);
					break;
				case "MedicalVendorTestPayments":
					this.MedicalVendorTestPayments.Add((MedicalVendorTestPaymentsEntity)relatedEntity);
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
				case "MedicalVendor":
					DesetupSyncMedicalVendor(false, true);
					break;
				case "MedicalVendorMvuserCustomerPayments":
					base.PerformRelatedEntityRemoval(this.MedicalVendorMvuserCustomerPayments, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicalVendorTestPayments":
					base.PerformRelatedEntityRemoval(this.MedicalVendorTestPayments, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_medicalVendor!=null)
			{
				toReturn.Add(_medicalVendor);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.MedicalVendorMvuserCustomerPayments);
			toReturn.Add(this.MedicalVendorTestPayments);

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
				info.AddValue("_medicalVendorMvuserCustomerPayments", ((_medicalVendorMvuserCustomerPayments!=null) && (_medicalVendorMvuserCustomerPayments.Count>0) && !this.MarkedForDeletion)?_medicalVendorMvuserCustomerPayments:null);
				info.AddValue("_medicalVendorTestPayments", ((_medicalVendorTestPayments!=null) && (_medicalVendorTestPayments.Count>0) && !this.MarkedForDeletion)?_medicalVendorTestPayments:null);
				info.AddValue("_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments", ((_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments!=null) && (_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments.Count>0) && !this.MarkedForDeletion)?_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments:null);
				info.AddValue("_medicalVendorMvuserCollectionViaMedicalVendorTestPayments", ((_medicalVendorMvuserCollectionViaMedicalVendorTestPayments!=null) && (_medicalVendorMvuserCollectionViaMedicalVendorTestPayments.Count>0) && !this.MarkedForDeletion)?_medicalVendorMvuserCollectionViaMedicalVendorTestPayments:null);
				info.AddValue("_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments", ((_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments!=null) && (_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments.Count>0) && !this.MarkedForDeletion)?_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments:null);
				info.AddValue("_testCollectionViaMedicalVendorTestPayments", ((_testCollectionViaMedicalVendorTestPayments!=null) && (_testCollectionViaMedicalVendorTestPayments.Count>0) && !this.MarkedForDeletion)?_testCollectionViaMedicalVendorTestPayments:null);
				info.AddValue("_medicalVendor", (!this.MarkedForDeletion?_medicalVendor:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MedicalVendorPaymentsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MedicalVendorPaymentsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MedicalVendorPaymentsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendorMvuserCustomerPayments' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorMvuserCustomerPayments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorMvuserCustomerPaymentsFields.MedicalVendorPaymentId, null, ComparisonOperator.Equal, this.MedicalVendorPaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendorTestPayments' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorTestPayments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorTestPaymentsFields.MedicalVendorPaymentId, null, ComparisonOperator.Equal, this.MedicalVendorPaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorPaymentsFields.MedicalVendorPaymentId, null, ComparisonOperator.Equal, this.MedicalVendorPaymentId, "MedicalVendorPaymentsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendorMvuser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorMvuserCollectionViaMedicalVendorTestPayments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MedicalVendorMvuserCollectionViaMedicalVendorTestPayments"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorPaymentsFields.MedicalVendorPaymentId, null, ComparisonOperator.Equal, this.MedicalVendorPaymentId, "MedicalVendorPaymentsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendorMvuser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorPaymentsFields.MedicalVendorPaymentId, null, ComparisonOperator.Equal, this.MedicalVendorPaymentId, "MedicalVendorPaymentsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaMedicalVendorTestPayments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaMedicalVendorTestPayments"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorPaymentsFields.MedicalVendorPaymentId, null, ComparisonOperator.Equal, this.MedicalVendorPaymentId, "MedicalVendorPaymentsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MedicalVendor' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendor()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorFields.MedicalVendorId, null, ComparisonOperator.Equal, this.MedicalVendorId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.MedicalVendorPaymentsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorPaymentsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._medicalVendorMvuserCustomerPayments);
			collectionsQueue.Enqueue(this._medicalVendorTestPayments);
			collectionsQueue.Enqueue(this._customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments);
			collectionsQueue.Enqueue(this._medicalVendorMvuserCollectionViaMedicalVendorTestPayments);
			collectionsQueue.Enqueue(this._medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments);
			collectionsQueue.Enqueue(this._testCollectionViaMedicalVendorTestPayments);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._medicalVendorMvuserCustomerPayments = (EntityCollection<MedicalVendorMvuserCustomerPaymentsEntity>) collectionsQueue.Dequeue();
			this._medicalVendorTestPayments = (EntityCollection<MedicalVendorTestPaymentsEntity>) collectionsQueue.Dequeue();
			this._customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments = (EntityCollection<CustomerEventTestsEntity>) collectionsQueue.Dequeue();
			this._medicalVendorMvuserCollectionViaMedicalVendorTestPayments = (EntityCollection<MedicalVendorMvuserEntity>) collectionsQueue.Dequeue();
			this._medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments = (EntityCollection<MedicalVendorMvuserEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaMedicalVendorTestPayments = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._medicalVendorMvuserCustomerPayments != null)
			{
				return true;
			}
			if (this._medicalVendorTestPayments != null)
			{
				return true;
			}
			if (this._customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments != null)
			{
				return true;
			}
			if (this._medicalVendorMvuserCollectionViaMedicalVendorTestPayments != null)
			{
				return true;
			}
			if (this._medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments != null)
			{
				return true;
			}
			if (this._testCollectionViaMedicalVendorTestPayments != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorMvuserCustomerPaymentsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserCustomerPaymentsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorTestPaymentsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorTestPaymentsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorMvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorMvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory))) : null);
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
			toReturn.Add("MedicalVendor", _medicalVendor);
			toReturn.Add("MedicalVendorMvuserCustomerPayments", _medicalVendorMvuserCustomerPayments);
			toReturn.Add("MedicalVendorTestPayments", _medicalVendorTestPayments);
			toReturn.Add("CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments", _customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments);
			toReturn.Add("MedicalVendorMvuserCollectionViaMedicalVendorTestPayments", _medicalVendorMvuserCollectionViaMedicalVendorTestPayments);
			toReturn.Add("MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments", _medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments);
			toReturn.Add("TestCollectionViaMedicalVendorTestPayments", _testCollectionViaMedicalVendorTestPayments);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_medicalVendorMvuserCustomerPayments!=null)
			{
				_medicalVendorMvuserCustomerPayments.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorTestPayments!=null)
			{
				_medicalVendorTestPayments.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments!=null)
			{
				_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorMvuserCollectionViaMedicalVendorTestPayments!=null)
			{
				_medicalVendorMvuserCollectionViaMedicalVendorTestPayments.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments!=null)
			{
				_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaMedicalVendorTestPayments!=null)
			{
				_testCollectionViaMedicalVendorTestPayments.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendor!=null)
			{
				_medicalVendor.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_medicalVendorMvuserCustomerPayments = null;
			_medicalVendorTestPayments = null;
			_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments = null;
			_medicalVendorMvuserCollectionViaMedicalVendorTestPayments = null;
			_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments = null;
			_testCollectionViaMedicalVendorTestPayments = null;
			_medicalVendor = null;

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

			_fieldsCustomProperties.Add("MedicalVendorPaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateFrom", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateTo", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _medicalVendor</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicalVendor(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicalVendor, new PropertyChangedEventHandler( OnMedicalVendorPropertyChanged ), "MedicalVendor", MedicalVendorPaymentsEntity.Relations.MedicalVendorEntityUsingMedicalVendorId, true, signalRelatedEntity, "MedicalVendorPayments", resetFKFields, new int[] { (int)MedicalVendorPaymentsFieldIndex.MedicalVendorId } );		
			_medicalVendor = null;
		}

		/// <summary> setups the sync logic for member _medicalVendor</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicalVendor(IEntity2 relatedEntity)
		{
			if(_medicalVendor!=relatedEntity)
			{
				DesetupSyncMedicalVendor(true, true);
				_medicalVendor = (MedicalVendorEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicalVendor, new PropertyChangedEventHandler( OnMedicalVendorPropertyChanged ), "MedicalVendor", MedicalVendorPaymentsEntity.Relations.MedicalVendorEntityUsingMedicalVendorId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicalVendorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MedicalVendorPaymentsEntity</param>
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
		public  static MedicalVendorPaymentsRelations Relations
		{
			get	{ return new MedicalVendorPaymentsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorMvuserCustomerPayments' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorMvuserCustomerPayments
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicalVendorMvuserCustomerPaymentsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserCustomerPaymentsEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorMvuserCustomerPayments")[0], (int)HealthYes.Data.EntityType.MedicalVendorPaymentsEntity, (int)HealthYes.Data.EntityType.MedicalVendorMvuserCustomerPaymentsEntity, 0, null, null, null, null, "MedicalVendorMvuserCustomerPayments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorTestPayments' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorTestPayments
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicalVendorTestPaymentsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorTestPaymentsEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorTestPayments")[0], (int)HealthYes.Data.EntityType.MedicalVendorPaymentsEntity, (int)HealthYes.Data.EntityType.MedicalVendorTestPaymentsEntity, 0, null, null, null, null, "MedicalVendorTestPayments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments
		{
			get
			{
				IEntityRelation intermediateRelation = MedicalVendorPaymentsEntity.Relations.MedicalVendorMvuserCustomerPaymentsEntityUsingMedicalVendorPaymentId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorMvuserCustomerPayments_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MedicalVendorPaymentsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, GetRelationsForField("CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments"), null, "CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorMvuser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorMvuserCollectionViaMedicalVendorTestPayments
		{
			get
			{
				IEntityRelation intermediateRelation = MedicalVendorPaymentsEntity.Relations.MedicalVendorTestPaymentsEntityUsingMedicalVendorPaymentId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorTestPayments_");
				return new PrefetchPathElement2(new EntityCollection<MedicalVendorMvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MedicalVendorPaymentsEntity, (int)HealthYes.Data.EntityType.MedicalVendorMvuserEntity, 0, null, null, GetRelationsForField("MedicalVendorMvuserCollectionViaMedicalVendorTestPayments"), null, "MedicalVendorMvuserCollectionViaMedicalVendorTestPayments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorMvuser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments
		{
			get
			{
				IEntityRelation intermediateRelation = MedicalVendorPaymentsEntity.Relations.MedicalVendorMvuserCustomerPaymentsEntityUsingMedicalVendorPaymentId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorMvuserCustomerPayments_");
				return new PrefetchPathElement2(new EntityCollection<MedicalVendorMvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MedicalVendorPaymentsEntity, (int)HealthYes.Data.EntityType.MedicalVendorMvuserEntity, 0, null, null, GetRelationsForField("MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments"), null, "MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaMedicalVendorTestPayments
		{
			get
			{
				IEntityRelation intermediateRelation = MedicalVendorPaymentsEntity.Relations.MedicalVendorTestPaymentsEntityUsingMedicalVendorPaymentId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorTestPayments_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MedicalVendorPaymentsEntity, (int)HealthYes.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaMedicalVendorTestPayments"), null, "TestCollectionViaMedicalVendorTestPayments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendor
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendor")[0], (int)HealthYes.Data.EntityType.MedicalVendorPaymentsEntity, (int)HealthYes.Data.EntityType.MedicalVendorEntity, 0, null, null, null, null, "MedicalVendor", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MedicalVendorPaymentsEntity.CustomProperties;}
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
			get { return MedicalVendorPaymentsEntity.FieldsCustomProperties;}
		}

		/// <summary> The MedicalVendorPaymentId property of the Entity MedicalVendorPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPayments"."MedicalVendorPaymentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 MedicalVendorPaymentId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorPaymentsFieldIndex.MedicalVendorPaymentId, true); }
			set	{ SetValue((int)MedicalVendorPaymentsFieldIndex.MedicalVendorPaymentId, value); }
		}

		/// <summary> The MedicalVendorId property of the Entity MedicalVendorPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPayments"."MedicalVendorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MedicalVendorId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorPaymentsFieldIndex.MedicalVendorId, true); }
			set	{ SetValue((int)MedicalVendorPaymentsFieldIndex.MedicalVendorId, value); }
		}

		/// <summary> The PaymentId property of the Entity MedicalVendorPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPayments"."PaymentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PaymentId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorPaymentsFieldIndex.PaymentId, true); }
			set	{ SetValue((int)MedicalVendorPaymentsFieldIndex.PaymentId, value); }
		}

		/// <summary> The DateCreated property of the Entity MedicalVendorPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPayments"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MedicalVendorPaymentsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MedicalVendorPaymentsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MedicalVendorPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPayments"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MedicalVendorPaymentsFieldIndex.DateModified, true); }
			set	{ SetValue((int)MedicalVendorPaymentsFieldIndex.DateModified, value); }
		}

		/// <summary> The DateFrom property of the Entity MedicalVendorPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPayments"."DateFrom"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateFrom
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MedicalVendorPaymentsFieldIndex.DateFrom, false); }
			set	{ SetValue((int)MedicalVendorPaymentsFieldIndex.DateFrom, value); }
		}

		/// <summary> The DateTo property of the Entity MedicalVendorPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPayments"."DateTo"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateTo
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MedicalVendorPaymentsFieldIndex.DateTo, false); }
			set	{ SetValue((int)MedicalVendorPaymentsFieldIndex.DateTo, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorMvuserCustomerPaymentsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorMvuserCustomerPaymentsEntity))]
		public virtual EntityCollection<MedicalVendorMvuserCustomerPaymentsEntity> MedicalVendorMvuserCustomerPayments
		{
			get
			{
				if(_medicalVendorMvuserCustomerPayments==null)
				{
					_medicalVendorMvuserCustomerPayments = new EntityCollection<MedicalVendorMvuserCustomerPaymentsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserCustomerPaymentsEntityFactory)));
					_medicalVendorMvuserCustomerPayments.SetContainingEntityInfo(this, "MedicalVendorPayments");
				}
				return _medicalVendorMvuserCustomerPayments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorTestPaymentsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorTestPaymentsEntity))]
		public virtual EntityCollection<MedicalVendorTestPaymentsEntity> MedicalVendorTestPayments
		{
			get
			{
				if(_medicalVendorTestPayments==null)
				{
					_medicalVendorTestPayments = new EntityCollection<MedicalVendorTestPaymentsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorTestPaymentsEntityFactory)));
					_medicalVendorTestPayments.SetContainingEntityInfo(this, "MedicalVendorPayments");
				}
				return _medicalVendorTestPayments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestsEntity))]
		public virtual EntityCollection<CustomerEventTestsEntity> CustomerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments
		{
			get
			{
				if(_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments==null)
				{
					_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments = new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory)));
					_customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments.IsReadOnly=true;
				}
				return _customerEventTestsCollectionViaMedicalVendorMvuserCustomerPayments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorMvuserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorMvuserEntity))]
		public virtual EntityCollection<MedicalVendorMvuserEntity> MedicalVendorMvuserCollectionViaMedicalVendorTestPayments
		{
			get
			{
				if(_medicalVendorMvuserCollectionViaMedicalVendorTestPayments==null)
				{
					_medicalVendorMvuserCollectionViaMedicalVendorTestPayments = new EntityCollection<MedicalVendorMvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory)));
					_medicalVendorMvuserCollectionViaMedicalVendorTestPayments.IsReadOnly=true;
				}
				return _medicalVendorMvuserCollectionViaMedicalVendorTestPayments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorMvuserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorMvuserEntity))]
		public virtual EntityCollection<MedicalVendorMvuserEntity> MedicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments
		{
			get
			{
				if(_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments==null)
				{
					_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments = new EntityCollection<MedicalVendorMvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory)));
					_medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments.IsReadOnly=true;
				}
				return _medicalVendorMvuserCollectionViaMedicalVendorMvuserCustomerPayments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaMedicalVendorTestPayments
		{
			get
			{
				if(_testCollectionViaMedicalVendorTestPayments==null)
				{
					_testCollectionViaMedicalVendorTestPayments = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaMedicalVendorTestPayments.IsReadOnly=true;
				}
				return _testCollectionViaMedicalVendorTestPayments;
			}
		}

		/// <summary> Gets / sets related entity of type 'MedicalVendorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicalVendorEntity MedicalVendor
		{
			get
			{
				return _medicalVendor;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicalVendor(value);
				}
				else
				{
					if(value==null)
					{
						if(_medicalVendor != null)
						{
							_medicalVendor.UnsetRelatedEntity(this, "MedicalVendorPayments");
						}
					}
					else
					{
						if(_medicalVendor!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorPayments");
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
			get { return (int)HealthYes.Data.EntityType.MedicalVendorPaymentsEntity; }
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
