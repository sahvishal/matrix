///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:49
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
	/// Entity class which represents the entity 'SystemGeneratedCallQueueCriteria'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class SystemGeneratedCallQueueCriteriaEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<SystemGeneratedCallQueueAssignmentEntity> _systemGeneratedCallQueueAssignment;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaSystemGeneratedCallQueueAssignment;
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment;
		private CallQueueEntity _callQueue;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private OrganizationRoleUserEntity _organizationRoleUser__;
		private OrganizationRoleUserEntity _organizationRoleUser_;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CallQueue</summary>
			public static readonly string CallQueue = "CallQueue";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name OrganizationRoleUser__</summary>
			public static readonly string OrganizationRoleUser__ = "OrganizationRoleUser__";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name SystemGeneratedCallQueueAssignment</summary>
			public static readonly string SystemGeneratedCallQueueAssignment = "SystemGeneratedCallQueueAssignment";
			/// <summary>Member name CallQueueCollectionViaSystemGeneratedCallQueueAssignment</summary>
			public static readonly string CallQueueCollectionViaSystemGeneratedCallQueueAssignment = "CallQueueCollectionViaSystemGeneratedCallQueueAssignment";
			/// <summary>Member name CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment</summary>
			public static readonly string CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = "CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SystemGeneratedCallQueueCriteriaEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public SystemGeneratedCallQueueCriteriaEntity():base("SystemGeneratedCallQueueCriteriaEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SystemGeneratedCallQueueCriteriaEntity(IEntityFields2 fields):base("SystemGeneratedCallQueueCriteriaEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SystemGeneratedCallQueueCriteriaEntity</param>
		public SystemGeneratedCallQueueCriteriaEntity(IValidator validator):base("SystemGeneratedCallQueueCriteriaEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for SystemGeneratedCallQueueCriteria which data should be fetched into this SystemGeneratedCallQueueCriteria object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SystemGeneratedCallQueueCriteriaEntity(System.Int64 id):base("SystemGeneratedCallQueueCriteriaEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for SystemGeneratedCallQueueCriteria which data should be fetched into this SystemGeneratedCallQueueCriteria object</param>
		/// <param name="validator">The custom validator object for this SystemGeneratedCallQueueCriteriaEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SystemGeneratedCallQueueCriteriaEntity(System.Int64 id, IValidator validator):base("SystemGeneratedCallQueueCriteriaEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected SystemGeneratedCallQueueCriteriaEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_systemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueAssignmentEntity>)info.GetValue("_systemGeneratedCallQueueAssignment", typeof(EntityCollection<SystemGeneratedCallQueueAssignmentEntity>));
				_callQueueCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaSystemGeneratedCallQueueAssignment", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment", typeof(EntityCollection<CallQueueCustomerEntity>));
				_callQueue = (CallQueueEntity)info.GetValue("_callQueue", typeof(CallQueueEntity));
				if(_callQueue!=null)
				{
					_callQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser__ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser__", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser__!=null)
				{
					_organizationRoleUser__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((SystemGeneratedCallQueueCriteriaFieldIndex)fieldIndex)
			{
				case SystemGeneratedCallQueueCriteriaFieldIndex.CallQueueId:
					DesetupSyncCallQueue(true, false);
					break;
				case SystemGeneratedCallQueueCriteriaFieldIndex.AssignedToOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case SystemGeneratedCallQueueCriteriaFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case SystemGeneratedCallQueueCriteriaFieldIndex.ModifiedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser__(true, false);
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
				case "CallQueue":
					this.CallQueue = (CallQueueEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser__":
					this.OrganizationRoleUser__ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "SystemGeneratedCallQueueAssignment":
					this.SystemGeneratedCallQueueAssignment.Add((SystemGeneratedCallQueueAssignmentEntity)entity);
					break;
				case "CallQueueCollectionViaSystemGeneratedCallQueueAssignment":
					this.CallQueueCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = false;
					this.CallQueueCollectionViaSystemGeneratedCallQueueAssignment.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = true;
					break;
				case "CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment":
					this.CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = false;
					this.CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.Add((CallQueueCustomerEntity)entity);
					this.CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = true;
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
			return SystemGeneratedCallQueueCriteriaEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CallQueue":
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId);
					break;
				case "OrganizationRoleUser__":
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "SystemGeneratedCallQueueAssignment":
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCriteriaId);
					break;
				case "CallQueueCollectionViaSystemGeneratedCallQueueAssignment":
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCriteriaId, "SystemGeneratedCallQueueCriteriaEntity__", "SystemGeneratedCallQueueAssignment_", JoinHint.None);
					toReturn.Add(SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueEntityUsingCallQueueId, "SystemGeneratedCallQueueAssignment_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment":
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCriteriaId, "SystemGeneratedCallQueueCriteriaEntity__", "SystemGeneratedCallQueueAssignment_", JoinHint.None);
					toReturn.Add(SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId, "SystemGeneratedCallQueueAssignment_", string.Empty, JoinHint.None);
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
				case "CallQueue":
					SetupSyncCallQueue(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "OrganizationRoleUser__":
					SetupSyncOrganizationRoleUser__(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "SystemGeneratedCallQueueAssignment":
					this.SystemGeneratedCallQueueAssignment.Add((SystemGeneratedCallQueueAssignmentEntity)relatedEntity);
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
				case "CallQueue":
					DesetupSyncCallQueue(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "OrganizationRoleUser__":
					DesetupSyncOrganizationRoleUser__(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "SystemGeneratedCallQueueAssignment":
					base.PerformRelatedEntityRemoval(this.SystemGeneratedCallQueueAssignment, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_callQueue!=null)
			{
				toReturn.Add(_callQueue);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_organizationRoleUser__!=null)
			{
				toReturn.Add(_organizationRoleUser__);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.SystemGeneratedCallQueueAssignment);

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
				info.AddValue("_systemGeneratedCallQueueAssignment", ((_systemGeneratedCallQueueAssignment!=null) && (_systemGeneratedCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_systemGeneratedCallQueueAssignment:null);
				info.AddValue("_callQueueCollectionViaSystemGeneratedCallQueueAssignment", ((_callQueueCollectionViaSystemGeneratedCallQueueAssignment!=null) && (_callQueueCollectionViaSystemGeneratedCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaSystemGeneratedCallQueueAssignment:null);
				info.AddValue("_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment", ((_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment!=null) && (_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment:null);
				info.AddValue("_callQueue", (!this.MarkedForDeletion?_callQueue:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_organizationRoleUser__", (!this.MarkedForDeletion?_organizationRoleUser__:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(SystemGeneratedCallQueueCriteriaFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(SystemGeneratedCallQueueCriteriaFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new SystemGeneratedCallQueueCriteriaRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SystemGeneratedCallQueueAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemGeneratedCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemGeneratedCallQueueAssignmentFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaSystemGeneratedCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaSystemGeneratedCallQueueAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemGeneratedCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "SystemGeneratedCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemGeneratedCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "SystemGeneratedCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.AssignedToOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._systemGeneratedCallQueueAssignment);
			collectionsQueue.Enqueue(this._callQueueCollectionViaSystemGeneratedCallQueueAssignment);
			collectionsQueue.Enqueue(this._callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._systemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueAssignmentEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._systemGeneratedCallQueueAssignment != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaSystemGeneratedCallQueueAssignment != null)
			{
				return true;
			}
			if (this._callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SystemGeneratedCallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CallQueue", _callQueue);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("OrganizationRoleUser__", _organizationRoleUser__);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("SystemGeneratedCallQueueAssignment", _systemGeneratedCallQueueAssignment);
			toReturn.Add("CallQueueCollectionViaSystemGeneratedCallQueueAssignment", _callQueueCollectionViaSystemGeneratedCallQueueAssignment);
			toReturn.Add("CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment", _callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_systemGeneratedCallQueueAssignment!=null)
			{
				_systemGeneratedCallQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaSystemGeneratedCallQueueAssignment!=null)
			{
				_callQueueCollectionViaSystemGeneratedCallQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment!=null)
			{
				_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callQueue!=null)
			{
				_callQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser__!=null)
			{
				_organizationRoleUser__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_systemGeneratedCallQueueAssignment = null;
			_callQueueCollectionViaSystemGeneratedCallQueueAssignment = null;
			_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = null;
			_callQueue = null;
			_organizationRoleUser = null;
			_organizationRoleUser__ = null;
			_organizationRoleUser_ = null;

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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallQueueId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Amount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Percentage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoOfDays", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefault", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsQueueGenerated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastQueueGeneratedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AssignedToOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _callQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", SystemGeneratedCallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId, true, signalRelatedEntity, "SystemGenertedCallQueueCriteria", resetFKFields, new int[] { (int)SystemGeneratedCallQueueCriteriaFieldIndex.CallQueueId } );		
			_callQueue = null;
		}

		/// <summary> setups the sync logic for member _callQueue</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCallQueue(IEntity2 relatedEntity)
		{
			if(_callQueue!=relatedEntity)
			{
				DesetupSyncCallQueue(true, true);
				_callQueue = (CallQueueEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", SystemGeneratedCallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallQueuePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, true, signalRelatedEntity, "SystemGenertedCallQueueCriteria", resetFKFields, new int[] { (int)SystemGeneratedCallQueueCriteriaFieldIndex.AssignedToOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "SystemGenertedCallQueueCriteria__", resetFKFields, new int[] { (int)SystemGeneratedCallQueueCriteriaFieldIndex.ModifiedByOrgRoleUserId } );		
			_organizationRoleUser__ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser__(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser__!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser__(true, true);
				_organizationRoleUser__ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "SystemGenertedCallQueueCriteria_", resetFKFields, new int[] { (int)SystemGeneratedCallQueueCriteriaFieldIndex.CreatedByOrgRoleUserId } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this SystemGeneratedCallQueueCriteriaEntity</param>
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
		public  static SystemGeneratedCallQueueCriteriaRelations Relations
		{
			get	{ return new SystemGeneratedCallQueueCriteriaRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SystemGeneratedCallQueueAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemGeneratedCallQueueAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SystemGeneratedCallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("SystemGeneratedCallQueueAssignment")[0], (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.SystemGeneratedCallQueueAssignmentEntity, 0, null, null, null, null, "SystemGeneratedCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = SystemGeneratedCallQueueCriteriaEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "SystemGeneratedCallQueueAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaSystemGeneratedCallQueueAssignment"), null, "CallQueueCollectionViaSystemGeneratedCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = SystemGeneratedCallQueueCriteriaEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "SystemGeneratedCallQueueAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, GetRelationsForField("CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment"), null, "CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueue
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueue")[0], (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, null, null, "CallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser__")[0], (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return SystemGeneratedCallQueueCriteriaEntity.CustomProperties;}
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
			get { return SystemGeneratedCallQueueCriteriaEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.Id, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.Id, value); }
		}

		/// <summary> The CallQueueId property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."CallQueueId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CallQueueId
		{
			get { return (System.Int64)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.CallQueueId, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.CallQueueId, value); }
		}

		/// <summary> The Amount property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."Amount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Amount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.Amount, false); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.Amount, value); }
		}

		/// <summary> The Percentage property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."Percentage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Percentage
		{
			get { return (Nullable<System.Decimal>)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.Percentage, false); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.Percentage, value); }
		}

		/// <summary> The NoOfDays property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."NoOfDays"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NoOfDays
		{
			get { return (System.Int32)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.NoOfDays, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.NoOfDays, value); }
		}

		/// <summary> The IsDefault property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."IsDefault"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefault
		{
			get { return (System.Boolean)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.IsDefault, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.IsDefault, value); }
		}

		/// <summary> The IsQueueGenerated property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."IsQueueGenerated"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsQueueGenerated
		{
			get { return (System.Boolean)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.IsQueueGenerated, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.IsQueueGenerated, value); }
		}

		/// <summary> The LastQueueGeneratedDate property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."LastQueueGeneratedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastQueueGeneratedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.LastQueueGeneratedDate, false); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.LastQueueGeneratedDate, value); }
		}

		/// <summary> The AssignedToOrgRoleUserId property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."AssignedToOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AssignedToOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.AssignedToOrgRoleUserId, false); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.AssignedToOrgRoleUserId, value); }
		}

		/// <summary> The DateCreated property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.DateCreated, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.DateModified, false); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.DateModified, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity SystemGeneratedCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueCriteria"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)SystemGeneratedCallQueueCriteriaFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SystemGeneratedCallQueueAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SystemGeneratedCallQueueAssignmentEntity))]
		public virtual EntityCollection<SystemGeneratedCallQueueAssignmentEntity> SystemGeneratedCallQueueAssignment
		{
			get
			{
				if(_systemGeneratedCallQueueAssignment==null)
				{
					_systemGeneratedCallQueueAssignment = new EntityCollection<SystemGeneratedCallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueAssignmentEntityFactory)));
					_systemGeneratedCallQueueAssignment.SetContainingEntityInfo(this, "SystemGeneratedCallQueueCriteria");
				}
				return _systemGeneratedCallQueueAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				if(_callQueueCollectionViaSystemGeneratedCallQueueAssignment==null)
				{
					_callQueueCollectionViaSystemGeneratedCallQueueAssignment = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly=true;
				}
				return _callQueueCollectionViaSystemGeneratedCallQueueAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				if(_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment==null)
				{
					_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly=true;
				}
				return _callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment;
			}
		}

		/// <summary> Gets / sets related entity of type 'CallQueueEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallQueueEntity CallQueue
		{
			get
			{
				return _callQueue;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCallQueue(value);
				}
				else
				{
					if(value==null)
					{
						if(_callQueue != null)
						{
							_callQueue.UnsetRelatedEntity(this, "SystemGenertedCallQueueCriteria");
						}
					}
					else
					{
						if(_callQueue!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SystemGenertedCallQueueCriteria");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "SystemGenertedCallQueueCriteria");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SystemGenertedCallQueueCriteria");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser__
		{
			get
			{
				return _organizationRoleUser__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser__(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser__ != null)
						{
							_organizationRoleUser__.UnsetRelatedEntity(this, "SystemGenertedCallQueueCriteria__");
						}
					}
					else
					{
						if(_organizationRoleUser__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SystemGenertedCallQueueCriteria__");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "SystemGenertedCallQueueCriteria_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SystemGenertedCallQueueCriteria_");
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
			get { return (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity; }
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
