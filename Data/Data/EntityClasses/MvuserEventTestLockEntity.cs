﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Thursday, July 21, 2011 6:44:34 PM
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
	/// Entity class which represents the entity 'MvuserEventTestLock'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MvuserEventTestLockEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MVEarningEntity> _mvearning;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaMvearning__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaMvearning_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaMvearning;
		private EventCustomerResultEntity _eventCustomerResult;
		private OrganizationRoleUserEntity _organizationRoleUser;
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
			/// <summary>Member name EventCustomerResult</summary>
			public static readonly string EventCustomerResult = "EventCustomerResult";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Test</summary>
			public static readonly string Test = "Test";
			/// <summary>Member name Mvearning</summary>
			public static readonly string Mvearning = "Mvearning";
			/// <summary>Member name OrganizationRoleUserCollectionViaMvearning__</summary>
			public static readonly string OrganizationRoleUserCollectionViaMvearning__ = "OrganizationRoleUserCollectionViaMvearning__";
			/// <summary>Member name OrganizationRoleUserCollectionViaMvearning_</summary>
			public static readonly string OrganizationRoleUserCollectionViaMvearning_ = "OrganizationRoleUserCollectionViaMvearning_";
			/// <summary>Member name OrganizationRoleUserCollectionViaMvearning</summary>
			public static readonly string OrganizationRoleUserCollectionViaMvearning = "OrganizationRoleUserCollectionViaMvearning";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MvuserEventTestLockEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MvuserEventTestLockEntity():base("MvuserEventTestLockEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MvuserEventTestLockEntity(IEntityFields2 fields):base("MvuserEventTestLockEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MvuserEventTestLockEntity</param>
		public MvuserEventTestLockEntity(IValidator validator):base("MvuserEventTestLockEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="mvuserEventTestLockId">PK value for MvuserEventTestLock which data should be fetched into this MvuserEventTestLock object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MvuserEventTestLockEntity(System.Int64 mvuserEventTestLockId):base("MvuserEventTestLockEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MvuserEventTestLockId = mvuserEventTestLockId;
		}

		/// <summary> CTor</summary>
		/// <param name="mvuserEventTestLockId">PK value for MvuserEventTestLock which data should be fetched into this MvuserEventTestLock object</param>
		/// <param name="validator">The custom validator object for this MvuserEventTestLockEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MvuserEventTestLockEntity(System.Int64 mvuserEventTestLockId, IValidator validator):base("MvuserEventTestLockEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MvuserEventTestLockId = mvuserEventTestLockId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MvuserEventTestLockEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_mvearning = (EntityCollection<MVEarningEntity>)info.GetValue("_mvearning", typeof(EntityCollection<MVEarningEntity>));
				_organizationRoleUserCollectionViaMvearning__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaMvearning__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaMvearning_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaMvearning_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaMvearning = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaMvearning", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_eventCustomerResult = (EventCustomerResultEntity)info.GetValue("_eventCustomerResult", typeof(EventCustomerResultEntity));
				if(_eventCustomerResult!=null)
				{
					_eventCustomerResult.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MvuserEventTestLockFieldIndex)fieldIndex)
			{
				case MvuserEventTestLockFieldIndex.TestId:
					DesetupSyncTest(true, false);
					break;
				case MvuserEventTestLockFieldIndex.OrganizationRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case MvuserEventTestLockFieldIndex.EventCustomerResultId:
					DesetupSyncEventCustomerResult(true, false);
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
				case "EventCustomerResult":
					this.EventCustomerResult = (EventCustomerResultEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Test":
					this.Test = (TestEntity)entity;
					break;
				case "Mvearning":
					this.Mvearning.Add((MVEarningEntity)entity);
					break;
				case "OrganizationRoleUserCollectionViaMvearning__":
					this.OrganizationRoleUserCollectionViaMvearning__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaMvearning__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaMvearning__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaMvearning_":
					this.OrganizationRoleUserCollectionViaMvearning_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaMvearning_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaMvearning_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaMvearning":
					this.OrganizationRoleUserCollectionViaMvearning.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaMvearning.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaMvearning.IsReadOnly = true;
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
			return MvuserEventTestLockEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "EventCustomerResult":
					toReturn.Add(MvuserEventTestLockEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(MvuserEventTestLockEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId);
					break;
				case "Test":
					toReturn.Add(MvuserEventTestLockEntity.Relations.TestEntityUsingTestId);
					break;
				case "Mvearning":
					toReturn.Add(MvuserEventTestLockEntity.Relations.MVEarningEntityUsingMvuserEventTestLockId);
					break;
				case "OrganizationRoleUserCollectionViaMvearning__":
					toReturn.Add(MvuserEventTestLockEntity.Relations.MVEarningEntityUsingMvuserEventTestLockId, "MvuserEventTestLockEntity__", "MVEarning_", JoinHint.None);
					toReturn.Add(MVEarningEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId, "MVEarning_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaMvearning_":
					toReturn.Add(MvuserEventTestLockEntity.Relations.MVEarningEntityUsingMvuserEventTestLockId, "MvuserEventTestLockEntity__", "MVEarning_", JoinHint.None);
					toReturn.Add(MVEarningEntity.Relations.OrganizationRoleUserEntityUsingDataRecoderModifierId, "MVEarning_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaMvearning":
					toReturn.Add(MvuserEventTestLockEntity.Relations.MVEarningEntityUsingMvuserEventTestLockId, "MvuserEventTestLockEntity__", "MVEarning_", JoinHint.None);
					toReturn.Add(MVEarningEntity.Relations.OrganizationRoleUserEntityUsingDataRecoderCreatorId, "MVEarning_", string.Empty, JoinHint.None);
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
				case "EventCustomerResult":
					SetupSyncEventCustomerResult(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Test":
					SetupSyncTest(relatedEntity);
					break;
				case "Mvearning":
					this.Mvearning.Add((MVEarningEntity)relatedEntity);
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
				case "EventCustomerResult":
					DesetupSyncEventCustomerResult(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Test":
					DesetupSyncTest(false, true);
					break;
				case "Mvearning":
					base.PerformRelatedEntityRemoval(this.Mvearning, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_eventCustomerResult!=null)
			{
				toReturn.Add(_eventCustomerResult);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
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
			toReturn.Add(this.Mvearning);

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
				info.AddValue("_mvearning", ((_mvearning!=null) && (_mvearning.Count>0) && !this.MarkedForDeletion)?_mvearning:null);
				info.AddValue("_organizationRoleUserCollectionViaMvearning__", ((_organizationRoleUserCollectionViaMvearning__!=null) && (_organizationRoleUserCollectionViaMvearning__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaMvearning__:null);
				info.AddValue("_organizationRoleUserCollectionViaMvearning_", ((_organizationRoleUserCollectionViaMvearning_!=null) && (_organizationRoleUserCollectionViaMvearning_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaMvearning_:null);
				info.AddValue("_organizationRoleUserCollectionViaMvearning", ((_organizationRoleUserCollectionViaMvearning!=null) && (_organizationRoleUserCollectionViaMvearning.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaMvearning:null);
				info.AddValue("_eventCustomerResult", (!this.MarkedForDeletion?_eventCustomerResult:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
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
		public bool TestOriginalFieldValueForNull(MvuserEventTestLockFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MvuserEventTestLockFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MvuserEventTestLockRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MVEarning' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvearning()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MVEarningFields.MvuserEventTestLockId, null, ComparisonOperator.Equal, this.MvuserEventTestLockId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaMvearning__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaMvearning__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvuserEventTestLockFields.MvuserEventTestLockId, null, ComparisonOperator.Equal, this.MvuserEventTestLockId, "MvuserEventTestLockEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaMvearning_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaMvearning_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvuserEventTestLockFields.MvuserEventTestLockId, null, ComparisonOperator.Equal, this.MvuserEventTestLockId, "MvuserEventTestLockEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaMvearning()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaMvearning"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvuserEventTestLockFields.MvuserEventTestLockId, null, ComparisonOperator.Equal, this.MvuserEventTestLockId, "MvuserEventTestLockEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerResult' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.OrganizationRoleUserId));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MvuserEventTestLockEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MvuserEventTestLockEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._mvearning);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaMvearning__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaMvearning_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaMvearning);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._mvearning = (EntityCollection<MVEarningEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaMvearning__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaMvearning_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaMvearning = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._mvearning != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaMvearning__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaMvearning_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaMvearning != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MVEarningEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVEarningEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("EventCustomerResult", _eventCustomerResult);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Test", _test);
			toReturn.Add("Mvearning", _mvearning);
			toReturn.Add("OrganizationRoleUserCollectionViaMvearning__", _organizationRoleUserCollectionViaMvearning__);
			toReturn.Add("OrganizationRoleUserCollectionViaMvearning_", _organizationRoleUserCollectionViaMvearning_);
			toReturn.Add("OrganizationRoleUserCollectionViaMvearning", _organizationRoleUserCollectionViaMvearning);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_mvearning!=null)
			{
				_mvearning.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaMvearning__!=null)
			{
				_organizationRoleUserCollectionViaMvearning__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaMvearning_!=null)
			{
				_organizationRoleUserCollectionViaMvearning_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaMvearning!=null)
			{
				_organizationRoleUserCollectionViaMvearning.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerResult!=null)
			{
				_eventCustomerResult.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_test!=null)
			{
				_test.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_mvearning = null;
			_organizationRoleUserCollectionViaMvearning__ = null;
			_organizationRoleUserCollectionViaMvearning_ = null;
			_organizationRoleUserCollectionViaMvearning = null;
			_eventCustomerResult = null;
			_organizationRoleUser = null;
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

			_fieldsCustomProperties.Add("MvuserEventTestLockId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alert1Sent", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alert2Sent", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventCustomerResultId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _eventCustomerResult</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerResult(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerResult, new PropertyChangedEventHandler( OnEventCustomerResultPropertyChanged ), "EventCustomerResult", MvuserEventTestLockEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, true, signalRelatedEntity, "MvuserEventTestLock", resetFKFields, new int[] { (int)MvuserEventTestLockFieldIndex.EventCustomerResultId } );		
			_eventCustomerResult = null;
		}

		/// <summary> setups the sync logic for member _eventCustomerResult</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomerResult(IEntity2 relatedEntity)
		{
			if(_eventCustomerResult!=relatedEntity)
			{
				DesetupSyncEventCustomerResult(true, true);
				_eventCustomerResult = (EventCustomerResultEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomerResult, new PropertyChangedEventHandler( OnEventCustomerResultPropertyChanged ), "EventCustomerResult", MvuserEventTestLockEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomerResultPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", MvuserEventTestLockEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId, true, signalRelatedEntity, "MvuserEventTestLock", resetFKFields, new int[] { (int)MvuserEventTestLockFieldIndex.OrganizationRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", MvuserEventTestLockEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _test</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTest(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", MvuserEventTestLockEntity.Relations.TestEntityUsingTestId, true, signalRelatedEntity, "MvuserEventTestLock", resetFKFields, new int[] { (int)MvuserEventTestLockFieldIndex.TestId } );		
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
				base.PerformSetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", MvuserEventTestLockEntity.Relations.TestEntityUsingTestId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this MvuserEventTestLockEntity</param>
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
		public  static MvuserEventTestLockRelations Relations
		{
			get	{ return new MvuserEventTestLockRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MVEarning' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvearning
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MVEarningEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVEarningEntityFactory))),
					(IEntityRelation)GetRelationsForField("Mvearning")[0], (int)Falcon.Data.EntityType.MvuserEventTestLockEntity, (int)Falcon.Data.EntityType.MVEarningEntity, 0, null, null, null, null, "Mvearning", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaMvearning__
		{
			get
			{
				IEntityRelation intermediateRelation = MvuserEventTestLockEntity.Relations.MVEarningEntityUsingMvuserEventTestLockId;
				intermediateRelation.SetAliases(string.Empty, "MVEarning_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MvuserEventTestLockEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaMvearning__"), null, "OrganizationRoleUserCollectionViaMvearning__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaMvearning_
		{
			get
			{
				IEntityRelation intermediateRelation = MvuserEventTestLockEntity.Relations.MVEarningEntityUsingMvuserEventTestLockId;
				intermediateRelation.SetAliases(string.Empty, "MVEarning_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MvuserEventTestLockEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaMvearning_"), null, "OrganizationRoleUserCollectionViaMvearning_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaMvearning
		{
			get
			{
				IEntityRelation intermediateRelation = MvuserEventTestLockEntity.Relations.MVEarningEntityUsingMvuserEventTestLockId;
				intermediateRelation.SetAliases(string.Empty, "MVEarning_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MvuserEventTestLockEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaMvearning"), null, "OrganizationRoleUserCollectionViaMvearning", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerResult' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerResult
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerResult")[0], (int)Falcon.Data.EntityType.MvuserEventTestLockEntity, (int)Falcon.Data.EntityType.EventCustomerResultEntity, 0, null, null, null, null, "EventCustomerResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.MvuserEventTestLockEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Test")[0], (int)Falcon.Data.EntityType.MvuserEventTestLockEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MvuserEventTestLockEntity.CustomProperties;}
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
			get { return MvuserEventTestLockEntity.FieldsCustomProperties;}
		}

		/// <summary> The MvuserEventTestLockId property of the Entity MvuserEventTestLock<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserEventTestLock"."MVUserEventTestLockID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MvuserEventTestLockId
		{
			get { return (System.Int64)GetValue((int)MvuserEventTestLockFieldIndex.MvuserEventTestLockId, true); }
			set	{ SetValue((int)MvuserEventTestLockFieldIndex.MvuserEventTestLockId, value); }
		}

		/// <summary> The TestId property of the Entity MvuserEventTestLock<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserEventTestLock"."TestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TestId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MvuserEventTestLockFieldIndex.TestId, false); }
			set	{ SetValue((int)MvuserEventTestLockFieldIndex.TestId, value); }
		}

		/// <summary> The Alert1Sent property of the Entity MvuserEventTestLock<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserEventTestLock"."Alert1Sent"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> Alert1Sent
		{
			get { return (Nullable<System.Boolean>)GetValue((int)MvuserEventTestLockFieldIndex.Alert1Sent, false); }
			set	{ SetValue((int)MvuserEventTestLockFieldIndex.Alert1Sent, value); }
		}

		/// <summary> The Alert2Sent property of the Entity MvuserEventTestLock<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserEventTestLock"."Alert2Sent"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> Alert2Sent
		{
			get { return (Nullable<System.Boolean>)GetValue((int)MvuserEventTestLockFieldIndex.Alert2Sent, false); }
			set	{ SetValue((int)MvuserEventTestLockFieldIndex.Alert2Sent, value); }
		}

		/// <summary> The DateCreated property of the Entity MvuserEventTestLock<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserEventTestLock"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MvuserEventTestLockFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MvuserEventTestLockFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MvuserEventTestLock<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserEventTestLock"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MvuserEventTestLockFieldIndex.DateModified, true); }
			set	{ SetValue((int)MvuserEventTestLockFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity MvuserEventTestLock<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserEventTestLock"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsActive
		{
			get { return (Nullable<System.Boolean>)GetValue((int)MvuserEventTestLockFieldIndex.IsActive, false); }
			set	{ SetValue((int)MvuserEventTestLockFieldIndex.IsActive, value); }
		}

		/// <summary> The OrganizationRoleUserId property of the Entity MvuserEventTestLock<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserEventTestLock"."OrganizationRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationRoleUserId
		{
			get { return (System.Int64)GetValue((int)MvuserEventTestLockFieldIndex.OrganizationRoleUserId, true); }
			set	{ SetValue((int)MvuserEventTestLockFieldIndex.OrganizationRoleUserId, value); }
		}

		/// <summary> The EventCustomerResultId property of the Entity MvuserEventTestLock<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserEventTestLock"."EventCustomerResultId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventCustomerResultId
		{
			get { return (System.Int64)GetValue((int)MvuserEventTestLockFieldIndex.EventCustomerResultId, true); }
			set	{ SetValue((int)MvuserEventTestLockFieldIndex.EventCustomerResultId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MVEarningEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MVEarningEntity))]
		public virtual EntityCollection<MVEarningEntity> Mvearning
		{
			get
			{
				if(_mvearning==null)
				{
					_mvearning = new EntityCollection<MVEarningEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVEarningEntityFactory)));
					_mvearning.SetContainingEntityInfo(this, "MvuserEventTestLock");
				}
				return _mvearning;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaMvearning__
		{
			get
			{
				if(_organizationRoleUserCollectionViaMvearning__==null)
				{
					_organizationRoleUserCollectionViaMvearning__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaMvearning__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaMvearning__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaMvearning_
		{
			get
			{
				if(_organizationRoleUserCollectionViaMvearning_==null)
				{
					_organizationRoleUserCollectionViaMvearning_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaMvearning_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaMvearning_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaMvearning
		{
			get
			{
				if(_organizationRoleUserCollectionViaMvearning==null)
				{
					_organizationRoleUserCollectionViaMvearning = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaMvearning.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaMvearning;
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomerResultEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomerResultEntity EventCustomerResult
		{
			get
			{
				return _eventCustomerResult;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomerResult(value);
				}
				else
				{
					if(value==null)
					{
						if(_eventCustomerResult != null)
						{
							_eventCustomerResult.UnsetRelatedEntity(this, "MvuserEventTestLock");
						}
					}
					else
					{
						if(_eventCustomerResult!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MvuserEventTestLock");
						}
					}
				}
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
							_organizationRoleUser.UnsetRelatedEntity(this, "MvuserEventTestLock");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MvuserEventTestLock");
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
							_test.UnsetRelatedEntity(this, "MvuserEventTestLock");
						}
					}
					else
					{
						if(_test!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MvuserEventTestLock");
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
			get { return (int)Falcon.Data.EntityType.MvuserEventTestLockEntity; }
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
