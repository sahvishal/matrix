///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:43
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
	/// Entity class which represents the entity 'IncidentalFindings'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class IncidentalFindingsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerEventTestIncidentalFindingEntity> _customerEventTestIncidentalFinding;
		private EntityCollection<IflocationMasterEntity> _iflocationMaster;
		private EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity> _incidentalFindingIncidentalFindingReadingGroup;
		private EntityCollection<TestIncidentalFindingEntity> _testIncidentalFinding;
		private EntityCollection<CustomerEventScreeningTestsEntity> _customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding;
		private EntityCollection<IncidentalFindingReadingGroupEntity> _incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup;
		private EntityCollection<TestEntity> _testCollectionViaTestIncidentalFinding;
		private OrganizationRoleUserEntity _organizationRoleUser;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CustomerEventTestIncidentalFinding</summary>
			public static readonly string CustomerEventTestIncidentalFinding = "CustomerEventTestIncidentalFinding";
			/// <summary>Member name IflocationMaster</summary>
			public static readonly string IflocationMaster = "IflocationMaster";
			/// <summary>Member name IncidentalFindingIncidentalFindingReadingGroup</summary>
			public static readonly string IncidentalFindingIncidentalFindingReadingGroup = "IncidentalFindingIncidentalFindingReadingGroup";
			/// <summary>Member name TestIncidentalFinding</summary>
			public static readonly string TestIncidentalFinding = "TestIncidentalFinding";
			/// <summary>Member name CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding</summary>
			public static readonly string CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding = "CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding";
			/// <summary>Member name IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup</summary>
			public static readonly string IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup = "IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup";
			/// <summary>Member name TestCollectionViaTestIncidentalFinding</summary>
			public static readonly string TestCollectionViaTestIncidentalFinding = "TestCollectionViaTestIncidentalFinding";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static IncidentalFindingsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public IncidentalFindingsEntity():base("IncidentalFindingsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public IncidentalFindingsEntity(IEntityFields2 fields):base("IncidentalFindingsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this IncidentalFindingsEntity</param>
		public IncidentalFindingsEntity(IValidator validator):base("IncidentalFindingsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="incidentalFindingsId">PK value for IncidentalFindings which data should be fetched into this IncidentalFindings object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public IncidentalFindingsEntity(System.Int64 incidentalFindingsId):base("IncidentalFindingsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.IncidentalFindingsId = incidentalFindingsId;
		}

		/// <summary> CTor</summary>
		/// <param name="incidentalFindingsId">PK value for IncidentalFindings which data should be fetched into this IncidentalFindings object</param>
		/// <param name="validator">The custom validator object for this IncidentalFindingsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public IncidentalFindingsEntity(System.Int64 incidentalFindingsId, IValidator validator):base("IncidentalFindingsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.IncidentalFindingsId = incidentalFindingsId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected IncidentalFindingsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerEventTestIncidentalFinding = (EntityCollection<CustomerEventTestIncidentalFindingEntity>)info.GetValue("_customerEventTestIncidentalFinding", typeof(EntityCollection<CustomerEventTestIncidentalFindingEntity>));
				_iflocationMaster = (EntityCollection<IflocationMasterEntity>)info.GetValue("_iflocationMaster", typeof(EntityCollection<IflocationMasterEntity>));
				_incidentalFindingIncidentalFindingReadingGroup = (EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>)info.GetValue("_incidentalFindingIncidentalFindingReadingGroup", typeof(EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>));
				_testIncidentalFinding = (EntityCollection<TestIncidentalFindingEntity>)info.GetValue("_testIncidentalFinding", typeof(EntityCollection<TestIncidentalFindingEntity>));
				_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding = (EntityCollection<CustomerEventScreeningTestsEntity>)info.GetValue("_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding", typeof(EntityCollection<CustomerEventScreeningTestsEntity>));
				_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup = (EntityCollection<IncidentalFindingReadingGroupEntity>)info.GetValue("_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup", typeof(EntityCollection<IncidentalFindingReadingGroupEntity>));
				_testCollectionViaTestIncidentalFinding = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaTestIncidentalFinding", typeof(EntityCollection<TestEntity>));
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((IncidentalFindingsFieldIndex)fieldIndex)
			{
				case IncidentalFindingsFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
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
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CustomerEventTestIncidentalFinding":
					this.CustomerEventTestIncidentalFinding.Add((CustomerEventTestIncidentalFindingEntity)entity);
					break;
				case "IflocationMaster":
					this.IflocationMaster.Add((IflocationMasterEntity)entity);
					break;
				case "IncidentalFindingIncidentalFindingReadingGroup":
					this.IncidentalFindingIncidentalFindingReadingGroup.Add((IncidentalFindingIncidentalFindingReadingGroupEntity)entity);
					break;
				case "TestIncidentalFinding":
					this.TestIncidentalFinding.Add((TestIncidentalFindingEntity)entity);
					break;
				case "CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding":
					this.CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding.IsReadOnly = false;
					this.CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding.Add((CustomerEventScreeningTestsEntity)entity);
					this.CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding.IsReadOnly = true;
					break;
				case "IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup":
					this.IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup.IsReadOnly = false;
					this.IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup.Add((IncidentalFindingReadingGroupEntity)entity);
					this.IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup.IsReadOnly = true;
					break;
				case "TestCollectionViaTestIncidentalFinding":
					this.TestCollectionViaTestIncidentalFinding.IsReadOnly = false;
					this.TestCollectionViaTestIncidentalFinding.Add((TestEntity)entity);
					this.TestCollectionViaTestIncidentalFinding.IsReadOnly = true;
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
			return IncidentalFindingsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser":
					toReturn.Add(IncidentalFindingsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "CustomerEventTestIncidentalFinding":
					toReturn.Add(IncidentalFindingsEntity.Relations.CustomerEventTestIncidentalFindingEntityUsingIncidentalFindingId);
					break;
				case "IflocationMaster":
					toReturn.Add(IncidentalFindingsEntity.Relations.IflocationMasterEntityUsingIncidentalFindingsId);
					break;
				case "IncidentalFindingIncidentalFindingReadingGroup":
					toReturn.Add(IncidentalFindingsEntity.Relations.IncidentalFindingIncidentalFindingReadingGroupEntityUsingIncidentalFindingId);
					break;
				case "TestIncidentalFinding":
					toReturn.Add(IncidentalFindingsEntity.Relations.TestIncidentalFindingEntityUsingIncidentalFindingId);
					break;
				case "CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding":
					toReturn.Add(IncidentalFindingsEntity.Relations.CustomerEventTestIncidentalFindingEntityUsingIncidentalFindingId, "IncidentalFindingsEntity__", "CustomerEventTestIncidentalFinding_", JoinHint.None);
					toReturn.Add(CustomerEventTestIncidentalFindingEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId, "CustomerEventTestIncidentalFinding_", string.Empty, JoinHint.None);
					break;
				case "IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup":
					toReturn.Add(IncidentalFindingsEntity.Relations.IncidentalFindingIncidentalFindingReadingGroupEntityUsingIncidentalFindingId, "IncidentalFindingsEntity__", "IncidentalFindingIncidentalFindingReadingGroup_", JoinHint.None);
					toReturn.Add(IncidentalFindingIncidentalFindingReadingGroupEntity.Relations.IncidentalFindingReadingGroupEntityUsingGroupId, "IncidentalFindingIncidentalFindingReadingGroup_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaTestIncidentalFinding":
					toReturn.Add(IncidentalFindingsEntity.Relations.TestIncidentalFindingEntityUsingIncidentalFindingId, "IncidentalFindingsEntity__", "TestIncidentalFinding_", JoinHint.None);
					toReturn.Add(TestIncidentalFindingEntity.Relations.TestEntityUsingTestId, "TestIncidentalFinding_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CustomerEventTestIncidentalFinding":
					this.CustomerEventTestIncidentalFinding.Add((CustomerEventTestIncidentalFindingEntity)relatedEntity);
					break;
				case "IflocationMaster":
					this.IflocationMaster.Add((IflocationMasterEntity)relatedEntity);
					break;
				case "IncidentalFindingIncidentalFindingReadingGroup":
					this.IncidentalFindingIncidentalFindingReadingGroup.Add((IncidentalFindingIncidentalFindingReadingGroupEntity)relatedEntity);
					break;
				case "TestIncidentalFinding":
					this.TestIncidentalFinding.Add((TestIncidentalFindingEntity)relatedEntity);
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
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CustomerEventTestIncidentalFinding":
					base.PerformRelatedEntityRemoval(this.CustomerEventTestIncidentalFinding, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "IflocationMaster":
					base.PerformRelatedEntityRemoval(this.IflocationMaster, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "IncidentalFindingIncidentalFindingReadingGroup":
					base.PerformRelatedEntityRemoval(this.IncidentalFindingIncidentalFindingReadingGroup, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestIncidentalFinding":
					base.PerformRelatedEntityRemoval(this.TestIncidentalFinding, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerEventTestIncidentalFinding);
			toReturn.Add(this.IflocationMaster);
			toReturn.Add(this.IncidentalFindingIncidentalFindingReadingGroup);
			toReturn.Add(this.TestIncidentalFinding);

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
				info.AddValue("_customerEventTestIncidentalFinding", ((_customerEventTestIncidentalFinding!=null) && (_customerEventTestIncidentalFinding.Count>0) && !this.MarkedForDeletion)?_customerEventTestIncidentalFinding:null);
				info.AddValue("_iflocationMaster", ((_iflocationMaster!=null) && (_iflocationMaster.Count>0) && !this.MarkedForDeletion)?_iflocationMaster:null);
				info.AddValue("_incidentalFindingIncidentalFindingReadingGroup", ((_incidentalFindingIncidentalFindingReadingGroup!=null) && (_incidentalFindingIncidentalFindingReadingGroup.Count>0) && !this.MarkedForDeletion)?_incidentalFindingIncidentalFindingReadingGroup:null);
				info.AddValue("_testIncidentalFinding", ((_testIncidentalFinding!=null) && (_testIncidentalFinding.Count>0) && !this.MarkedForDeletion)?_testIncidentalFinding:null);
				info.AddValue("_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding", ((_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding!=null) && (_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding.Count>0) && !this.MarkedForDeletion)?_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding:null);
				info.AddValue("_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup", ((_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup!=null) && (_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup.Count>0) && !this.MarkedForDeletion)?_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup:null);
				info.AddValue("_testCollectionViaTestIncidentalFinding", ((_testCollectionViaTestIncidentalFinding!=null) && (_testCollectionViaTestIncidentalFinding.Count>0) && !this.MarkedForDeletion)?_testCollectionViaTestIncidentalFinding:null);
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(IncidentalFindingsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(IncidentalFindingsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new IncidentalFindingsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTestIncidentalFinding' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestIncidentalFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestIncidentalFindingFields.IncidentalFindingId, null, ComparisonOperator.Equal, this.IncidentalFindingsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IflocationMaster' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIflocationMaster()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IflocationMasterFields.IncidentalFindingsId, null, ComparisonOperator.Equal, this.IncidentalFindingsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindingIncidentalFindingReadingGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingIncidentalFindingReadingGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingIncidentalFindingReadingGroupFields.IncidentalFindingId, null, ComparisonOperator.Equal, this.IncidentalFindingsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestIncidentalFinding' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestIncidentalFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestIncidentalFindingFields.IncidentalFindingId, null, ComparisonOperator.Equal, this.IncidentalFindingsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventScreeningTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingsFields.IncidentalFindingsId, null, ComparisonOperator.Equal, this.IncidentalFindingsId, "IncidentalFindingsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindingReadingGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingsFields.IncidentalFindingsId, null, ComparisonOperator.Equal, this.IncidentalFindingsId, "IncidentalFindingsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaTestIncidentalFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaTestIncidentalFinding"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingsFields.IncidentalFindingsId, null, ComparisonOperator.Equal, this.IncidentalFindingsId, "IncidentalFindingsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.IncidentalFindingsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerEventTestIncidentalFinding);
			collectionsQueue.Enqueue(this._iflocationMaster);
			collectionsQueue.Enqueue(this._incidentalFindingIncidentalFindingReadingGroup);
			collectionsQueue.Enqueue(this._testIncidentalFinding);
			collectionsQueue.Enqueue(this._customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding);
			collectionsQueue.Enqueue(this._incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup);
			collectionsQueue.Enqueue(this._testCollectionViaTestIncidentalFinding);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerEventTestIncidentalFinding = (EntityCollection<CustomerEventTestIncidentalFindingEntity>) collectionsQueue.Dequeue();
			this._iflocationMaster = (EntityCollection<IflocationMasterEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingIncidentalFindingReadingGroup = (EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>) collectionsQueue.Dequeue();
			this._testIncidentalFinding = (EntityCollection<TestIncidentalFindingEntity>) collectionsQueue.Dequeue();
			this._customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding = (EntityCollection<CustomerEventScreeningTestsEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup = (EntityCollection<IncidentalFindingReadingGroupEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaTestIncidentalFinding = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerEventTestIncidentalFinding != null)
			{
				return true;
			}
			if (this._iflocationMaster != null)
			{
				return true;
			}
			if (this._incidentalFindingIncidentalFindingReadingGroup != null)
			{
				return true;
			}
			if (this._testIncidentalFinding != null)
			{
				return true;
			}
			if (this._customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding != null)
			{
				return true;
			}
			if (this._incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup != null)
			{
				return true;
			}
			if (this._testCollectionViaTestIncidentalFinding != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IflocationMasterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IflocationMasterEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingIncidentalFindingReadingGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestIncidentalFindingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingReadingGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CustomerEventTestIncidentalFinding", _customerEventTestIncidentalFinding);
			toReturn.Add("IflocationMaster", _iflocationMaster);
			toReturn.Add("IncidentalFindingIncidentalFindingReadingGroup", _incidentalFindingIncidentalFindingReadingGroup);
			toReturn.Add("TestIncidentalFinding", _testIncidentalFinding);
			toReturn.Add("CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding", _customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding);
			toReturn.Add("IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup", _incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup);
			toReturn.Add("TestCollectionViaTestIncidentalFinding", _testCollectionViaTestIncidentalFinding);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerEventTestIncidentalFinding!=null)
			{
				_customerEventTestIncidentalFinding.ActiveContext = base.ActiveContext;
			}
			if(_iflocationMaster!=null)
			{
				_iflocationMaster.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingIncidentalFindingReadingGroup!=null)
			{
				_incidentalFindingIncidentalFindingReadingGroup.ActiveContext = base.ActiveContext;
			}
			if(_testIncidentalFinding!=null)
			{
				_testIncidentalFinding.ActiveContext = base.ActiveContext;
			}
			if(_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding!=null)
			{
				_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup!=null)
			{
				_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaTestIncidentalFinding!=null)
			{
				_testCollectionViaTestIncidentalFinding.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerEventTestIncidentalFinding = null;
			_iflocationMaster = null;
			_incidentalFindingIncidentalFindingReadingGroup = null;
			_testIncidentalFinding = null;
			_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding = null;
			_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup = null;
			_testCollectionViaTestIncidentalFinding = null;
			_organizationRoleUser = null;

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

			_fieldsCustomProperties.Add("IncidentalFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Label", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LocationCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", IncidentalFindingsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "IncidentalFindings", resetFKFields, new int[] { (int)IncidentalFindingsFieldIndex.CreatedByOrgRoleUserId } );		
			_organizationRoleUser = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser(true, true);
				_organizationRoleUser = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", IncidentalFindingsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this IncidentalFindingsEntity</param>
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
		public  static IncidentalFindingsRelations Relations
		{
			get	{ return new IncidentalFindingsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTestIncidentalFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestIncidentalFinding
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventTestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTestIncidentalFinding")[0], (int)Falcon.Data.EntityType.IncidentalFindingsEntity, (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity, 0, null, null, null, null, "CustomerEventTestIncidentalFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IflocationMaster' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIflocationMaster
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<IflocationMasterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IflocationMasterEntityFactory))),
					(IEntityRelation)GetRelationsForField("IflocationMaster")[0], (int)Falcon.Data.EntityType.IncidentalFindingsEntity, (int)Falcon.Data.EntityType.IflocationMasterEntity, 0, null, null, null, null, "IflocationMaster", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindingIncidentalFindingReadingGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingIncidentalFindingReadingGroup
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingIncidentalFindingReadingGroupEntityFactory))),
					(IEntityRelation)GetRelationsForField("IncidentalFindingIncidentalFindingReadingGroup")[0], (int)Falcon.Data.EntityType.IncidentalFindingsEntity, (int)Falcon.Data.EntityType.IncidentalFindingIncidentalFindingReadingGroupEntity, 0, null, null, null, null, "IncidentalFindingIncidentalFindingReadingGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestIncidentalFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestIncidentalFinding
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestIncidentalFindingEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestIncidentalFinding")[0], (int)Falcon.Data.EntityType.IncidentalFindingsEntity, (int)Falcon.Data.EntityType.TestIncidentalFindingEntity, 0, null, null, null, null, "TestIncidentalFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventScreeningTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding
		{
			get
			{
				IEntityRelation intermediateRelation = IncidentalFindingsEntity.Relations.CustomerEventTestIncidentalFindingEntityUsingIncidentalFindingId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestIncidentalFinding_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.IncidentalFindingsEntity, (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, 0, null, null, GetRelationsForField("CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding"), null, "CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindingReadingGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup
		{
			get
			{
				IEntityRelation intermediateRelation = IncidentalFindingsEntity.Relations.IncidentalFindingIncidentalFindingReadingGroupEntityUsingIncidentalFindingId;
				intermediateRelation.SetAliases(string.Empty, "IncidentalFindingIncidentalFindingReadingGroup_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingReadingGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.IncidentalFindingsEntity, (int)Falcon.Data.EntityType.IncidentalFindingReadingGroupEntity, 0, null, null, GetRelationsForField("IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup"), null, "IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaTestIncidentalFinding
		{
			get
			{
				IEntityRelation intermediateRelation = IncidentalFindingsEntity.Relations.TestIncidentalFindingEntityUsingIncidentalFindingId;
				intermediateRelation.SetAliases(string.Empty, "TestIncidentalFinding_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.IncidentalFindingsEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaTestIncidentalFinding"), null, "TestCollectionViaTestIncidentalFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.IncidentalFindingsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return IncidentalFindingsEntity.CustomProperties;}
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
			get { return IncidentalFindingsEntity.FieldsCustomProperties;}
		}

		/// <summary> The IncidentalFindingsId property of the Entity IncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindings"."IncidentalFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 IncidentalFindingsId
		{
			get { return (System.Int64)GetValue((int)IncidentalFindingsFieldIndex.IncidentalFindingsId, true); }
			set	{ SetValue((int)IncidentalFindingsFieldIndex.IncidentalFindingsId, value); }
		}

		/// <summary> The Label property of the Entity IncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindings"."Label"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Label
		{
			get { return (System.String)GetValue((int)IncidentalFindingsFieldIndex.Label, true); }
			set	{ SetValue((int)IncidentalFindingsFieldIndex.Label, value); }
		}

		/// <summary> The Description property of the Entity IncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindings"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)IncidentalFindingsFieldIndex.Description, true); }
			set	{ SetValue((int)IncidentalFindingsFieldIndex.Description, value); }
		}

		/// <summary> The LocationCount property of the Entity IncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindings"."LocationCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> LocationCount
		{
			get { return (Nullable<System.Byte>)GetValue((int)IncidentalFindingsFieldIndex.LocationCount, false); }
			set	{ SetValue((int)IncidentalFindingsFieldIndex.LocationCount, value); }
		}

		/// <summary> The IsActive property of the Entity IncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindings"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)IncidentalFindingsFieldIndex.IsActive, true); }
			set	{ SetValue((int)IncidentalFindingsFieldIndex.IsActive, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity IncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindings"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)IncidentalFindingsFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)IncidentalFindingsFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The DateCreated property of the Entity IncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindings"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)IncidentalFindingsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)IncidentalFindingsFieldIndex.DateCreated, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestIncidentalFindingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestIncidentalFindingEntity))]
		public virtual EntityCollection<CustomerEventTestIncidentalFindingEntity> CustomerEventTestIncidentalFinding
		{
			get
			{
				if(_customerEventTestIncidentalFinding==null)
				{
					_customerEventTestIncidentalFinding = new EntityCollection<CustomerEventTestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingEntityFactory)));
					_customerEventTestIncidentalFinding.SetContainingEntityInfo(this, "IncidentalFindings");
				}
				return _customerEventTestIncidentalFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IflocationMasterEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IflocationMasterEntity))]
		public virtual EntityCollection<IflocationMasterEntity> IflocationMaster
		{
			get
			{
				if(_iflocationMaster==null)
				{
					_iflocationMaster = new EntityCollection<IflocationMasterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IflocationMasterEntityFactory)));
					_iflocationMaster.SetContainingEntityInfo(this, "IncidentalFindings");
				}
				return _iflocationMaster;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingIncidentalFindingReadingGroupEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingIncidentalFindingReadingGroupEntity))]
		public virtual EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity> IncidentalFindingIncidentalFindingReadingGroup
		{
			get
			{
				if(_incidentalFindingIncidentalFindingReadingGroup==null)
				{
					_incidentalFindingIncidentalFindingReadingGroup = new EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingIncidentalFindingReadingGroupEntityFactory)));
					_incidentalFindingIncidentalFindingReadingGroup.SetContainingEntityInfo(this, "IncidentalFindings");
				}
				return _incidentalFindingIncidentalFindingReadingGroup;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestIncidentalFindingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestIncidentalFindingEntity))]
		public virtual EntityCollection<TestIncidentalFindingEntity> TestIncidentalFinding
		{
			get
			{
				if(_testIncidentalFinding==null)
				{
					_testIncidentalFinding = new EntityCollection<TestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestIncidentalFindingEntityFactory)));
					_testIncidentalFinding.SetContainingEntityInfo(this, "IncidentalFindings");
				}
				return _testIncidentalFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventScreeningTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventScreeningTestsEntity))]
		public virtual EntityCollection<CustomerEventScreeningTestsEntity> CustomerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding
		{
			get
			{
				if(_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding==null)
				{
					_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding = new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory)));
					_customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding.IsReadOnly=true;
				}
				return _customerEventScreeningTestsCollectionViaCustomerEventTestIncidentalFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingReadingGroupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingReadingGroupEntity))]
		public virtual EntityCollection<IncidentalFindingReadingGroupEntity> IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup
		{
			get
			{
				if(_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup==null)
				{
					_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup = new EntityCollection<IncidentalFindingReadingGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupEntityFactory)));
					_incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup.IsReadOnly=true;
				}
				return _incidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaTestIncidentalFinding
		{
			get
			{
				if(_testCollectionViaTestIncidentalFinding==null)
				{
					_testCollectionViaTestIncidentalFinding = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaTestIncidentalFinding.IsReadOnly=true;
				}
				return _testCollectionViaTestIncidentalFinding;
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser
		{
			get
			{
				return _organizationRoleUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser != null)
						{
							_organizationRoleUser.UnsetRelatedEntity(this, "IncidentalFindings");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "IncidentalFindings");
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
			get { return (int)Falcon.Data.EntityType.IncidentalFindingsEntity; }
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
