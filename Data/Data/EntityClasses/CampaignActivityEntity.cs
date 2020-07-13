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
	/// Entity class which represents the entity 'CampaignActivity'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CampaignActivityEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CampaignActivityAssignmentEntity> _campaignActivityAssignment;
		private EntityCollection<HealthPlanCriteriaDirectMailEntity> _healthPlanCriteriaDirectMail;
		private EntityCollection<HealthPlanCallQueueCriteriaEntity> _healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCampaignActivityAssignment;
		private CampaignEntity _campaign;
		private DirectMailTypeEntity _directMailType;
		private LookupEntity _lookup;
		private OrganizationRoleUserEntity _organizationRoleUser_;
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
			/// <summary>Member name Campaign</summary>
			public static readonly string Campaign = "Campaign";
			/// <summary>Member name DirectMailType</summary>
			public static readonly string DirectMailType = "DirectMailType";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CampaignActivityAssignment</summary>
			public static readonly string CampaignActivityAssignment = "CampaignActivityAssignment";
			/// <summary>Member name HealthPlanCriteriaDirectMail</summary>
			public static readonly string HealthPlanCriteriaDirectMail = "HealthPlanCriteriaDirectMail";
			/// <summary>Member name HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail</summary>
			public static readonly string HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail = "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail";
			/// <summary>Member name OrganizationRoleUserCollectionViaCampaignActivityAssignment</summary>
			public static readonly string OrganizationRoleUserCollectionViaCampaignActivityAssignment = "OrganizationRoleUserCollectionViaCampaignActivityAssignment";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CampaignActivityEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CampaignActivityEntity():base("CampaignActivityEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CampaignActivityEntity(IEntityFields2 fields):base("CampaignActivityEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CampaignActivityEntity</param>
		public CampaignActivityEntity(IValidator validator):base("CampaignActivityEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CampaignActivity which data should be fetched into this CampaignActivity object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CampaignActivityEntity(System.Int64 id):base("CampaignActivityEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CampaignActivity which data should be fetched into this CampaignActivity object</param>
		/// <param name="validator">The custom validator object for this CampaignActivityEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CampaignActivityEntity(System.Int64 id, IValidator validator):base("CampaignActivityEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CampaignActivityEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_campaignActivityAssignment = (EntityCollection<CampaignActivityAssignmentEntity>)info.GetValue("_campaignActivityAssignment", typeof(EntityCollection<CampaignActivityAssignmentEntity>));
				_healthPlanCriteriaDirectMail = (EntityCollection<HealthPlanCriteriaDirectMailEntity>)info.GetValue("_healthPlanCriteriaDirectMail", typeof(EntityCollection<HealthPlanCriteriaDirectMailEntity>));
				_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail = (EntityCollection<HealthPlanCallQueueCriteriaEntity>)info.GetValue("_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail", typeof(EntityCollection<HealthPlanCallQueueCriteriaEntity>));
				_organizationRoleUserCollectionViaCampaignActivityAssignment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCampaignActivityAssignment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_campaign = (CampaignEntity)info.GetValue("_campaign", typeof(CampaignEntity));
				if(_campaign!=null)
				{
					_campaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_directMailType = (DirectMailTypeEntity)info.GetValue("_directMailType", typeof(DirectMailTypeEntity));
				if(_directMailType!=null)
				{
					_directMailType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
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
			switch((CampaignActivityFieldIndex)fieldIndex)
			{
				case CampaignActivityFieldIndex.CampaignId:
					DesetupSyncCampaign(true, false);
					break;
				case CampaignActivityFieldIndex.TypeId:
					DesetupSyncLookup(true, false);
					break;
				case CampaignActivityFieldIndex.Createdby:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CampaignActivityFieldIndex.Modifiedby:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case CampaignActivityFieldIndex.DirectMailTypeId:
					DesetupSyncDirectMailType(true, false);
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
				case "Campaign":
					this.Campaign = (CampaignEntity)entity;
					break;
				case "DirectMailType":
					this.DirectMailType = (DirectMailTypeEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CampaignActivityAssignment":
					this.CampaignActivityAssignment.Add((CampaignActivityAssignmentEntity)entity);
					break;
				case "HealthPlanCriteriaDirectMail":
					this.HealthPlanCriteriaDirectMail.Add((HealthPlanCriteriaDirectMailEntity)entity);
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail":
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail.IsReadOnly = false;
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail.Add((HealthPlanCallQueueCriteriaEntity)entity);
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivityAssignment":
					this.OrganizationRoleUserCollectionViaCampaignActivityAssignment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCampaignActivityAssignment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCampaignActivityAssignment.IsReadOnly = true;
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
			return CampaignActivityEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Campaign":
					toReturn.Add(CampaignActivityEntity.Relations.CampaignEntityUsingCampaignId);
					break;
				case "DirectMailType":
					toReturn.Add(CampaignActivityEntity.Relations.DirectMailTypeEntityUsingDirectMailTypeId);
					break;
				case "Lookup":
					toReturn.Add(CampaignActivityEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingModifiedby);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingCreatedby);
					break;
				case "CampaignActivityAssignment":
					toReturn.Add(CampaignActivityEntity.Relations.CampaignActivityAssignmentEntityUsingCampaignActivityId);
					break;
				case "HealthPlanCriteriaDirectMail":
					toReturn.Add(CampaignActivityEntity.Relations.HealthPlanCriteriaDirectMailEntityUsingCampaignActivityId);
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail":
					toReturn.Add(CampaignActivityEntity.Relations.HealthPlanCriteriaDirectMailEntityUsingCampaignActivityId, "CampaignActivityEntity__", "HealthPlanCriteriaDirectMail_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaDirectMailEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCriteriaId, "HealthPlanCriteriaDirectMail_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivityAssignment":
					toReturn.Add(CampaignActivityEntity.Relations.CampaignActivityAssignmentEntityUsingCampaignActivityId, "CampaignActivityEntity__", "CampaignActivityAssignment_", JoinHint.None);
					toReturn.Add(CampaignActivityAssignmentEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CampaignActivityAssignment_", string.Empty, JoinHint.None);
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
				case "Campaign":
					SetupSyncCampaign(relatedEntity);
					break;
				case "DirectMailType":
					SetupSyncDirectMailType(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CampaignActivityAssignment":
					this.CampaignActivityAssignment.Add((CampaignActivityAssignmentEntity)relatedEntity);
					break;
				case "HealthPlanCriteriaDirectMail":
					this.HealthPlanCriteriaDirectMail.Add((HealthPlanCriteriaDirectMailEntity)relatedEntity);
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
				case "Campaign":
					DesetupSyncCampaign(false, true);
					break;
				case "DirectMailType":
					DesetupSyncDirectMailType(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CampaignActivityAssignment":
					base.PerformRelatedEntityRemoval(this.CampaignActivityAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCriteriaDirectMail":
					base.PerformRelatedEntityRemoval(this.HealthPlanCriteriaDirectMail, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_campaign!=null)
			{
				toReturn.Add(_campaign);
			}
			if(_directMailType!=null)
			{
				toReturn.Add(_directMailType);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
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
			toReturn.Add(this.CampaignActivityAssignment);
			toReturn.Add(this.HealthPlanCriteriaDirectMail);

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
				info.AddValue("_campaignActivityAssignment", ((_campaignActivityAssignment!=null) && (_campaignActivityAssignment.Count>0) && !this.MarkedForDeletion)?_campaignActivityAssignment:null);
				info.AddValue("_healthPlanCriteriaDirectMail", ((_healthPlanCriteriaDirectMail!=null) && (_healthPlanCriteriaDirectMail.Count>0) && !this.MarkedForDeletion)?_healthPlanCriteriaDirectMail:null);
				info.AddValue("_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail", ((_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail!=null) && (_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail:null);
				info.AddValue("_organizationRoleUserCollectionViaCampaignActivityAssignment", ((_organizationRoleUserCollectionViaCampaignActivityAssignment!=null) && (_organizationRoleUserCollectionViaCampaignActivityAssignment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCampaignActivityAssignment:null);
				info.AddValue("_campaign", (!this.MarkedForDeletion?_campaign:null));
				info.AddValue("_directMailType", (!this.MarkedForDeletion?_directMailType:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
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
		public bool TestOriginalFieldValueForNull(CampaignActivityFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CampaignActivityFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CampaignActivityRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CampaignActivityAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignActivityAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignActivityAssignmentFields.CampaignActivityId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCriteriaDirectMail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCriteriaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCriteriaDirectMailFields.CampaignActivityId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignActivityFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignActivityEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCampaignActivityAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCampaignActivityAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignActivityFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignActivityEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Campaign' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DirectMailType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDirectMailType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.DirectMailTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.Modifiedby));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.Createdby));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CampaignActivityEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._campaignActivityAssignment);
			collectionsQueue.Enqueue(this._healthPlanCriteriaDirectMail);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCampaignActivityAssignment);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._campaignActivityAssignment = (EntityCollection<CampaignActivityAssignmentEntity>) collectionsQueue.Dequeue();
			this._healthPlanCriteriaDirectMail = (EntityCollection<HealthPlanCriteriaDirectMailEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail = (EntityCollection<HealthPlanCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCampaignActivityAssignment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._campaignActivityAssignment != null)
			{
				return true;
			}
			if (this._healthPlanCriteriaDirectMail != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCampaignActivityAssignment != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignActivityAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCriteriaDirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaDirectMailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))) : null);
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
			toReturn.Add("Campaign", _campaign);
			toReturn.Add("DirectMailType", _directMailType);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CampaignActivityAssignment", _campaignActivityAssignment);
			toReturn.Add("HealthPlanCriteriaDirectMail", _healthPlanCriteriaDirectMail);
			toReturn.Add("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail", _healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail);
			toReturn.Add("OrganizationRoleUserCollectionViaCampaignActivityAssignment", _organizationRoleUserCollectionViaCampaignActivityAssignment);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_campaignActivityAssignment!=null)
			{
				_campaignActivityAssignment.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCriteriaDirectMail!=null)
			{
				_healthPlanCriteriaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail!=null)
			{
				_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCampaignActivityAssignment!=null)
			{
				_organizationRoleUserCollectionViaCampaignActivityAssignment.ActiveContext = base.ActiveContext;
			}
			if(_campaign!=null)
			{
				_campaign.ActiveContext = base.ActiveContext;
			}
			if(_directMailType!=null)
			{
				_directMailType.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_campaignActivityAssignment = null;
			_healthPlanCriteriaDirectMail = null;
			_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail = null;
			_organizationRoleUserCollectionViaCampaignActivityAssignment = null;
			_campaign = null;
			_directMailType = null;
			_lookup = null;
			_organizationRoleUser_ = null;
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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActivityDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sequence", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Createdby", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Modifiedby", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DirectMailTypeId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _campaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", CampaignActivityEntity.Relations.CampaignEntityUsingCampaignId, true, signalRelatedEntity, "CampaignActivity", resetFKFields, new int[] { (int)CampaignActivityFieldIndex.CampaignId } );		
			_campaign = null;
		}

		/// <summary> setups the sync logic for member _campaign</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCampaign(IEntity2 relatedEntity)
		{
			if(_campaign!=relatedEntity)
			{
				DesetupSyncCampaign(true, true);
				_campaign = (CampaignEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", CampaignActivityEntity.Relations.CampaignEntityUsingCampaignId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCampaignPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _directMailType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDirectMailType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _directMailType, new PropertyChangedEventHandler( OnDirectMailTypePropertyChanged ), "DirectMailType", CampaignActivityEntity.Relations.DirectMailTypeEntityUsingDirectMailTypeId, true, signalRelatedEntity, "CampaignActivity", resetFKFields, new int[] { (int)CampaignActivityFieldIndex.DirectMailTypeId } );		
			_directMailType = null;
		}

		/// <summary> setups the sync logic for member _directMailType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDirectMailType(IEntity2 relatedEntity)
		{
			if(_directMailType!=relatedEntity)
			{
				DesetupSyncDirectMailType(true, true);
				_directMailType = (DirectMailTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _directMailType, new PropertyChangedEventHandler( OnDirectMailTypePropertyChanged ), "DirectMailType", CampaignActivityEntity.Relations.DirectMailTypeEntityUsingDirectMailTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDirectMailTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CampaignActivityEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "CampaignActivity", resetFKFields, new int[] { (int)CampaignActivityFieldIndex.TypeId } );		
			_lookup = null;
		}

		/// <summary> setups the sync logic for member _lookup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup(IEntity2 relatedEntity)
		{
			if(_lookup!=relatedEntity)
			{
				DesetupSyncLookup(true, true);
				_lookup = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CampaignActivityEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookupPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingModifiedby, true, signalRelatedEntity, "CampaignActivity_", resetFKFields, new int[] { (int)CampaignActivityFieldIndex.Modifiedby } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingModifiedby, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingCreatedby, true, signalRelatedEntity, "CampaignActivity", resetFKFields, new int[] { (int)CampaignActivityFieldIndex.Createdby } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingCreatedby, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CampaignActivityEntity</param>
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
		public  static CampaignActivityRelations Relations
		{
			get	{ return new CampaignActivityRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CampaignActivityAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignActivityAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CampaignActivityAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CampaignActivityAssignment")[0], (int)Falcon.Data.EntityType.CampaignActivityEntity, (int)Falcon.Data.EntityType.CampaignActivityAssignmentEntity, 0, null, null, null, null, "CampaignActivityAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCriteriaDirectMail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCriteriaDirectMail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanCriteriaDirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaDirectMailEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanCriteriaDirectMail")[0], (int)Falcon.Data.EntityType.CampaignActivityEntity, (int)Falcon.Data.EntityType.HealthPlanCriteriaDirectMailEntity, 0, null, null, null, null, "HealthPlanCriteriaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignActivityEntity.Relations.HealthPlanCriteriaDirectMailEntityUsingCampaignActivityId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaDirectMail_");
				return new PrefetchPathElement2(new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignActivityEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, 0, null, null, GetRelationsForField("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail"), null, "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCampaignActivityAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignActivityEntity.Relations.CampaignActivityAssignmentEntityUsingCampaignActivityId;
				intermediateRelation.SetAliases(string.Empty, "CampaignActivityAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignActivityEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCampaignActivityAssignment"), null, "OrganizationRoleUserCollectionViaCampaignActivityAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaign
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("Campaign")[0], (int)Falcon.Data.EntityType.CampaignActivityEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, null, null, "Campaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DirectMailType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDirectMailType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("DirectMailType")[0], (int)Falcon.Data.EntityType.CampaignActivityEntity, (int)Falcon.Data.EntityType.DirectMailTypeEntity, 0, null, null, null, null, "DirectMailType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CampaignActivityEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.CampaignActivityEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CampaignActivityEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CampaignActivityEntity.CustomProperties;}
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
			get { return CampaignActivityEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CampaignActivityFieldIndex.Id, true); }
			set	{ SetValue((int)CampaignActivityFieldIndex.Id, value); }
		}

		/// <summary> The CampaignId property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."CampaignId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CampaignId
		{
			get { return (System.Int64)GetValue((int)CampaignActivityFieldIndex.CampaignId, true); }
			set	{ SetValue((int)CampaignActivityFieldIndex.CampaignId, value); }
		}

		/// <summary> The ActivityDate property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."ActivityDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ActivityDate
		{
			get { return (System.DateTime)GetValue((int)CampaignActivityFieldIndex.ActivityDate, true); }
			set	{ SetValue((int)CampaignActivityFieldIndex.ActivityDate, value); }
		}

		/// <summary> The TypeId property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)CampaignActivityFieldIndex.TypeId, true); }
			set	{ SetValue((int)CampaignActivityFieldIndex.TypeId, value); }
		}

		/// <summary> The Sequence property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."Sequence"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Sequence
		{
			get { return (System.Int32)GetValue((int)CampaignActivityFieldIndex.Sequence, true); }
			set	{ SetValue((int)CampaignActivityFieldIndex.Sequence, value); }
		}

		/// <summary> The CreatedOn property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedOn
		{
			get { return (System.DateTime)GetValue((int)CampaignActivityFieldIndex.CreatedOn, true); }
			set	{ SetValue((int)CampaignActivityFieldIndex.CreatedOn, value); }
		}

		/// <summary> The Createdby property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."Createdby"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Createdby
		{
			get { return (System.Int64)GetValue((int)CampaignActivityFieldIndex.Createdby, true); }
			set	{ SetValue((int)CampaignActivityFieldIndex.Createdby, value); }
		}

		/// <summary> The ModifiedOn property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."ModifiedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ModifiedOn
		{
			get { return (System.DateTime)GetValue((int)CampaignActivityFieldIndex.ModifiedOn, true); }
			set	{ SetValue((int)CampaignActivityFieldIndex.ModifiedOn, value); }
		}

		/// <summary> The Modifiedby property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."Modifiedby"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Modifiedby
		{
			get { return (System.Int64)GetValue((int)CampaignActivityFieldIndex.Modifiedby, true); }
			set	{ SetValue((int)CampaignActivityFieldIndex.Modifiedby, value); }
		}

		/// <summary> The DirectMailTypeId property of the Entity CampaignActivity<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaignActivity"."DirectMailTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DirectMailTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CampaignActivityFieldIndex.DirectMailTypeId, false); }
			set	{ SetValue((int)CampaignActivityFieldIndex.DirectMailTypeId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignActivityAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignActivityAssignmentEntity))]
		public virtual EntityCollection<CampaignActivityAssignmentEntity> CampaignActivityAssignment
		{
			get
			{
				if(_campaignActivityAssignment==null)
				{
					_campaignActivityAssignment = new EntityCollection<CampaignActivityAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityAssignmentEntityFactory)));
					_campaignActivityAssignment.SetContainingEntityInfo(this, "CampaignActivity");
				}
				return _campaignActivityAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCriteriaDirectMailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCriteriaDirectMailEntity))]
		public virtual EntityCollection<HealthPlanCriteriaDirectMailEntity> HealthPlanCriteriaDirectMail
		{
			get
			{
				if(_healthPlanCriteriaDirectMail==null)
				{
					_healthPlanCriteriaDirectMail = new EntityCollection<HealthPlanCriteriaDirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaDirectMailEntityFactory)));
					_healthPlanCriteriaDirectMail.SetContainingEntityInfo(this, "CampaignActivity");
				}
				return _healthPlanCriteriaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCallQueueCriteriaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCallQueueCriteriaEntity))]
		public virtual EntityCollection<HealthPlanCallQueueCriteriaEntity> HealthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail
		{
			get
			{
				if(_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail==null)
				{
					_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail = new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory)));
					_healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail.IsReadOnly=true;
				}
				return _healthPlanCallQueueCriteriaCollectionViaHealthPlanCriteriaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCampaignActivityAssignment
		{
			get
			{
				if(_organizationRoleUserCollectionViaCampaignActivityAssignment==null)
				{
					_organizationRoleUserCollectionViaCampaignActivityAssignment = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCampaignActivityAssignment.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCampaignActivityAssignment;
			}
		}

		/// <summary> Gets / sets related entity of type 'CampaignEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CampaignEntity Campaign
		{
			get
			{
				return _campaign;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCampaign(value);
				}
				else
				{
					if(value==null)
					{
						if(_campaign != null)
						{
							_campaign.UnsetRelatedEntity(this, "CampaignActivity");
						}
					}
					else
					{
						if(_campaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CampaignActivity");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DirectMailTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DirectMailTypeEntity DirectMailType
		{
			get
			{
				return _directMailType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDirectMailType(value);
				}
				else
				{
					if(value==null)
					{
						if(_directMailType != null)
						{
							_directMailType.UnsetRelatedEntity(this, "CampaignActivity");
						}
					}
					else
					{
						if(_directMailType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CampaignActivity");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup
		{
			get
			{
				return _lookup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup != null)
						{
							_lookup.UnsetRelatedEntity(this, "CampaignActivity");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CampaignActivity");
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "CampaignActivity_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CampaignActivity_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CampaignActivity");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CampaignActivity");
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
			get { return (int)Falcon.Data.EntityType.CampaignActivityEntity; }
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
