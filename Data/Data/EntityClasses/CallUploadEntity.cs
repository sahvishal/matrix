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
	/// Entity class which represents the entity 'CallUpload'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CallUploadEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallUploadLogEntity> _callUploadLog;
		private EntityCollection<DirectMailEntity> _directMail;
		private EntityCollection<CampaignEntity> _campaignCollectionViaDirectMail;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaDirectMail;
		private EntityCollection<DirectMailTypeEntity> _directMailTypeCollectionViaDirectMail;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaDirectMail;
		private FileEntity _file_;
		private FileEntity _file;
		private LookupEntity _lookup;
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
			/// <summary>Member name File_</summary>
			public static readonly string File_ = "File_";
			/// <summary>Member name File</summary>
			public static readonly string File = "File";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CallUploadLog</summary>
			public static readonly string CallUploadLog = "CallUploadLog";
			/// <summary>Member name DirectMail</summary>
			public static readonly string DirectMail = "DirectMail";
			/// <summary>Member name CampaignCollectionViaDirectMail</summary>
			public static readonly string CampaignCollectionViaDirectMail = "CampaignCollectionViaDirectMail";
			/// <summary>Member name CustomerProfileCollectionViaDirectMail</summary>
			public static readonly string CustomerProfileCollectionViaDirectMail = "CustomerProfileCollectionViaDirectMail";
			/// <summary>Member name DirectMailTypeCollectionViaDirectMail</summary>
			public static readonly string DirectMailTypeCollectionViaDirectMail = "DirectMailTypeCollectionViaDirectMail";
			/// <summary>Member name OrganizationRoleUserCollectionViaDirectMail</summary>
			public static readonly string OrganizationRoleUserCollectionViaDirectMail = "OrganizationRoleUserCollectionViaDirectMail";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CallUploadEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CallUploadEntity():base("CallUploadEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CallUploadEntity(IEntityFields2 fields):base("CallUploadEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CallUploadEntity</param>
		public CallUploadEntity(IValidator validator):base("CallUploadEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CallUpload which data should be fetched into this CallUpload object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallUploadEntity(System.Int64 id):base("CallUploadEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CallUpload which data should be fetched into this CallUpload object</param>
		/// <param name="validator">The custom validator object for this CallUploadEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallUploadEntity(System.Int64 id, IValidator validator):base("CallUploadEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CallUploadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callUploadLog = (EntityCollection<CallUploadLogEntity>)info.GetValue("_callUploadLog", typeof(EntityCollection<CallUploadLogEntity>));
				_directMail = (EntityCollection<DirectMailEntity>)info.GetValue("_directMail", typeof(EntityCollection<DirectMailEntity>));
				_campaignCollectionViaDirectMail = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaDirectMail", typeof(EntityCollection<CampaignEntity>));
				_customerProfileCollectionViaDirectMail = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaDirectMail", typeof(EntityCollection<CustomerProfileEntity>));
				_directMailTypeCollectionViaDirectMail = (EntityCollection<DirectMailTypeEntity>)info.GetValue("_directMailTypeCollectionViaDirectMail", typeof(EntityCollection<DirectMailTypeEntity>));
				_organizationRoleUserCollectionViaDirectMail = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaDirectMail", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_file_ = (FileEntity)info.GetValue("_file_", typeof(FileEntity));
				if(_file_!=null)
				{
					_file_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file = (FileEntity)info.GetValue("_file", typeof(FileEntity));
				if(_file!=null)
				{
					_file.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CallUploadFieldIndex)fieldIndex)
			{
				case CallUploadFieldIndex.FileId:
					DesetupSyncFile(true, false);
					break;
				case CallUploadFieldIndex.StatusId:
					DesetupSyncLookup(true, false);
					break;
				case CallUploadFieldIndex.UploadedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CallUploadFieldIndex.LogFileId:
					DesetupSyncFile_(true, false);
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
				case "File_":
					this.File_ = (FileEntity)entity;
					break;
				case "File":
					this.File = (FileEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CallUploadLog":
					this.CallUploadLog.Add((CallUploadLogEntity)entity);
					break;
				case "DirectMail":
					this.DirectMail.Add((DirectMailEntity)entity);
					break;
				case "CampaignCollectionViaDirectMail":
					this.CampaignCollectionViaDirectMail.IsReadOnly = false;
					this.CampaignCollectionViaDirectMail.Add((CampaignEntity)entity);
					this.CampaignCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaDirectMail":
					this.CustomerProfileCollectionViaDirectMail.IsReadOnly = false;
					this.CustomerProfileCollectionViaDirectMail.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "DirectMailTypeCollectionViaDirectMail":
					this.DirectMailTypeCollectionViaDirectMail.IsReadOnly = false;
					this.DirectMailTypeCollectionViaDirectMail.Add((DirectMailTypeEntity)entity);
					this.DirectMailTypeCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaDirectMail":
					this.OrganizationRoleUserCollectionViaDirectMail.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaDirectMail.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaDirectMail.IsReadOnly = true;
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
			return CallUploadEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "File_":
					toReturn.Add(CallUploadEntity.Relations.FileEntityUsingLogFileId);
					break;
				case "File":
					toReturn.Add(CallUploadEntity.Relations.FileEntityUsingFileId);
					break;
				case "Lookup":
					toReturn.Add(CallUploadEntity.Relations.LookupEntityUsingStatusId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CallUploadEntity.Relations.OrganizationRoleUserEntityUsingUploadedBy);
					break;
				case "CallUploadLog":
					toReturn.Add(CallUploadEntity.Relations.CallUploadLogEntityUsingCallUploadId);
					break;
				case "DirectMail":
					toReturn.Add(CallUploadEntity.Relations.DirectMailEntityUsingCallUploadId);
					break;
				case "CampaignCollectionViaDirectMail":
					toReturn.Add(CallUploadEntity.Relations.DirectMailEntityUsingCallUploadId, "CallUploadEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.CampaignEntityUsingCampaignId, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaDirectMail":
					toReturn.Add(CallUploadEntity.Relations.DirectMailEntityUsingCallUploadId, "CallUploadEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.CustomerProfileEntityUsingCustomerId, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "DirectMailTypeCollectionViaDirectMail":
					toReturn.Add(CallUploadEntity.Relations.DirectMailEntityUsingCallUploadId, "CallUploadEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.DirectMailTypeEntityUsingDirectMailTypeId, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaDirectMail":
					toReturn.Add(CallUploadEntity.Relations.DirectMailEntityUsingCallUploadId, "CallUploadEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.OrganizationRoleUserEntityUsingMailedBy, "DirectMail_", string.Empty, JoinHint.None);
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
				case "File_":
					SetupSyncFile_(relatedEntity);
					break;
				case "File":
					SetupSyncFile(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CallUploadLog":
					this.CallUploadLog.Add((CallUploadLogEntity)relatedEntity);
					break;
				case "DirectMail":
					this.DirectMail.Add((DirectMailEntity)relatedEntity);
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
				case "File_":
					DesetupSyncFile_(false, true);
					break;
				case "File":
					DesetupSyncFile(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CallUploadLog":
					base.PerformRelatedEntityRemoval(this.CallUploadLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DirectMail":
					base.PerformRelatedEntityRemoval(this.DirectMail, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_file_!=null)
			{
				toReturn.Add(_file_);
			}
			if(_file!=null)
			{
				toReturn.Add(_file);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
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
			toReturn.Add(this.CallUploadLog);
			toReturn.Add(this.DirectMail);

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
				info.AddValue("_callUploadLog", ((_callUploadLog!=null) && (_callUploadLog.Count>0) && !this.MarkedForDeletion)?_callUploadLog:null);
				info.AddValue("_directMail", ((_directMail!=null) && (_directMail.Count>0) && !this.MarkedForDeletion)?_directMail:null);
				info.AddValue("_campaignCollectionViaDirectMail", ((_campaignCollectionViaDirectMail!=null) && (_campaignCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaDirectMail:null);
				info.AddValue("_customerProfileCollectionViaDirectMail", ((_customerProfileCollectionViaDirectMail!=null) && (_customerProfileCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaDirectMail:null);
				info.AddValue("_directMailTypeCollectionViaDirectMail", ((_directMailTypeCollectionViaDirectMail!=null) && (_directMailTypeCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_directMailTypeCollectionViaDirectMail:null);
				info.AddValue("_organizationRoleUserCollectionViaDirectMail", ((_organizationRoleUserCollectionViaDirectMail!=null) && (_organizationRoleUserCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaDirectMail:null);
				info.AddValue("_file_", (!this.MarkedForDeletion?_file_:null));
				info.AddValue("_file", (!this.MarkedForDeletion?_file:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
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
		public bool TestOriginalFieldValueForNull(CallUploadFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CallUploadFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CallUploadRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallUploadLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallUploadLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallUploadLogFields.CallUploadId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DirectMail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailFields.CallUploadId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CallUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CallUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DirectMailType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDirectMailTypeCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("DirectMailTypeCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CallUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallUploadFields.Id, null, ComparisonOperator.Equal, this.Id, "CallUploadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.LogFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.FileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.StatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.UploadedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CallUploadEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CallUploadEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callUploadLog);
			collectionsQueue.Enqueue(this._directMail);
			collectionsQueue.Enqueue(this._campaignCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._directMailTypeCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaDirectMail);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callUploadLog = (EntityCollection<CallUploadLogEntity>) collectionsQueue.Dequeue();
			this._directMail = (EntityCollection<DirectMailEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaDirectMail = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaDirectMail = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._directMailTypeCollectionViaDirectMail = (EntityCollection<DirectMailTypeEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaDirectMail = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callUploadLog != null)
			{
				return true;
			}
			if (this._directMail != null)
			{
				return true;
			}
			if (this._campaignCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._directMailTypeCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaDirectMail != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DirectMailTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory))) : null);
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
			toReturn.Add("File_", _file_);
			toReturn.Add("File", _file);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CallUploadLog", _callUploadLog);
			toReturn.Add("DirectMail", _directMail);
			toReturn.Add("CampaignCollectionViaDirectMail", _campaignCollectionViaDirectMail);
			toReturn.Add("CustomerProfileCollectionViaDirectMail", _customerProfileCollectionViaDirectMail);
			toReturn.Add("DirectMailTypeCollectionViaDirectMail", _directMailTypeCollectionViaDirectMail);
			toReturn.Add("OrganizationRoleUserCollectionViaDirectMail", _organizationRoleUserCollectionViaDirectMail);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callUploadLog!=null)
			{
				_callUploadLog.ActiveContext = base.ActiveContext;
			}
			if(_directMail!=null)
			{
				_directMail.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaDirectMail!=null)
			{
				_campaignCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaDirectMail!=null)
			{
				_customerProfileCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_directMailTypeCollectionViaDirectMail!=null)
			{
				_directMailTypeCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaDirectMail!=null)
			{
				_organizationRoleUserCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_file_!=null)
			{
				_file_.ActiveContext = base.ActiveContext;
			}
			if(_file!=null)
			{
				_file.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callUploadLog = null;
			_directMail = null;
			_campaignCollectionViaDirectMail = null;
			_customerProfileCollectionViaDirectMail = null;
			_directMailTypeCollectionViaDirectMail = null;
			_organizationRoleUserCollectionViaDirectMail = null;
			_file_ = null;
			_file = null;
			_lookup = null;
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

			_fieldsCustomProperties.Add("FileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SuccessfullUploadCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FailedUploadCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UploadTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UploadedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParseStartTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParseEndTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LogFileId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _file_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", CallUploadEntity.Relations.FileEntityUsingLogFileId, true, signalRelatedEntity, "CallUpload_", resetFKFields, new int[] { (int)CallUploadFieldIndex.LogFileId } );		
			_file_ = null;
		}

		/// <summary> setups the sync logic for member _file_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile_(IEntity2 relatedEntity)
		{
			if(_file_!=relatedEntity)
			{
				DesetupSyncFile_(true, true);
				_file_ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", CallUploadEntity.Relations.FileEntityUsingLogFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", CallUploadEntity.Relations.FileEntityUsingFileId, true, signalRelatedEntity, "CallUpload", resetFKFields, new int[] { (int)CallUploadFieldIndex.FileId } );		
			_file = null;
		}

		/// <summary> setups the sync logic for member _file</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile(IEntity2 relatedEntity)
		{
			if(_file!=relatedEntity)
			{
				DesetupSyncFile(true, true);
				_file = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", CallUploadEntity.Relations.FileEntityUsingFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFilePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallUploadEntity.Relations.LookupEntityUsingStatusId, true, signalRelatedEntity, "CallUpload", resetFKFields, new int[] { (int)CallUploadFieldIndex.StatusId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallUploadEntity.Relations.LookupEntityUsingStatusId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallUploadEntity.Relations.OrganizationRoleUserEntityUsingUploadedBy, true, signalRelatedEntity, "CallUpload", resetFKFields, new int[] { (int)CallUploadFieldIndex.UploadedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallUploadEntity.Relations.OrganizationRoleUserEntityUsingUploadedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CallUploadEntity</param>
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
		public  static CallUploadRelations Relations
		{
			get	{ return new CallUploadRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallUploadLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallUploadLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallUploadLog")[0], (int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.CallUploadLogEntity, 0, null, null, null, null, "CallUploadLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DirectMail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDirectMail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<DirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory))),
					(IEntityRelation)GetRelationsForField("DirectMail")[0], (int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.DirectMailEntity, 0, null, null, null, null, "DirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = CallUploadEntity.Relations.DirectMailEntityUsingCallUploadId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaDirectMail"), null, "CampaignCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = CallUploadEntity.Relations.DirectMailEntityUsingCallUploadId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaDirectMail"), null, "CustomerProfileCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DirectMailType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDirectMailTypeCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = CallUploadEntity.Relations.DirectMailEntityUsingCallUploadId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<DirectMailTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.DirectMailTypeEntity, 0, null, null, GetRelationsForField("DirectMailTypeCollectionViaDirectMail"), null, "DirectMailTypeCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = CallUploadEntity.Relations.DirectMailEntityUsingCallUploadId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaDirectMail"), null, "OrganizationRoleUserCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File_")[0], (int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File")[0], (int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CallUploadEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CallUploadEntity.CustomProperties;}
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
			get { return CallUploadEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CallUploadFieldIndex.Id, true); }
			set	{ SetValue((int)CallUploadFieldIndex.Id, value); }
		}

		/// <summary> The FileId property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."FileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 FileId
		{
			get { return (System.Int64)GetValue((int)CallUploadFieldIndex.FileId, true); }
			set	{ SetValue((int)CallUploadFieldIndex.FileId, value); }
		}

		/// <summary> The StatusId property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."StatusId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 StatusId
		{
			get { return (System.Int64)GetValue((int)CallUploadFieldIndex.StatusId, true); }
			set	{ SetValue((int)CallUploadFieldIndex.StatusId, value); }
		}

		/// <summary> The SuccessfullUploadCount property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."SuccessfullUploadCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 SuccessfullUploadCount
		{
			get { return (System.Int64)GetValue((int)CallUploadFieldIndex.SuccessfullUploadCount, true); }
			set	{ SetValue((int)CallUploadFieldIndex.SuccessfullUploadCount, value); }
		}

		/// <summary> The FailedUploadCount property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."FailedUploadCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 FailedUploadCount
		{
			get { return (System.Int64)GetValue((int)CallUploadFieldIndex.FailedUploadCount, true); }
			set	{ SetValue((int)CallUploadFieldIndex.FailedUploadCount, value); }
		}

		/// <summary> The UploadTime property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."UploadTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime UploadTime
		{
			get { return (System.DateTime)GetValue((int)CallUploadFieldIndex.UploadTime, true); }
			set	{ SetValue((int)CallUploadFieldIndex.UploadTime, value); }
		}

		/// <summary> The UploadedBy property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."UploadedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 UploadedBy
		{
			get { return (System.Int64)GetValue((int)CallUploadFieldIndex.UploadedBy, true); }
			set	{ SetValue((int)CallUploadFieldIndex.UploadedBy, value); }
		}

		/// <summary> The ParseStartTime property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."ParseStartTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ParseStartTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallUploadFieldIndex.ParseStartTime, false); }
			set	{ SetValue((int)CallUploadFieldIndex.ParseStartTime, value); }
		}

		/// <summary> The ParseEndTime property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."ParseEndTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ParseEndTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallUploadFieldIndex.ParseEndTime, false); }
			set	{ SetValue((int)CallUploadFieldIndex.ParseEndTime, value); }
		}

		/// <summary> The LogFileId property of the Entity CallUpload<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallUpload"."LogFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LogFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallUploadFieldIndex.LogFileId, false); }
			set	{ SetValue((int)CallUploadFieldIndex.LogFileId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallUploadLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallUploadLogEntity))]
		public virtual EntityCollection<CallUploadLogEntity> CallUploadLog
		{
			get
			{
				if(_callUploadLog==null)
				{
					_callUploadLog = new EntityCollection<CallUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadLogEntityFactory)));
					_callUploadLog.SetContainingEntityInfo(this, "CallUpload");
				}
				return _callUploadLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DirectMailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DirectMailEntity))]
		public virtual EntityCollection<DirectMailEntity> DirectMail
		{
			get
			{
				if(_directMail==null)
				{
					_directMail = new EntityCollection<DirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory)));
					_directMail.SetContainingEntityInfo(this, "CallUpload");
				}
				return _directMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaDirectMail
		{
			get
			{
				if(_campaignCollectionViaDirectMail==null)
				{
					_campaignCollectionViaDirectMail = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaDirectMail.IsReadOnly=true;
				}
				return _campaignCollectionViaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaDirectMail
		{
			get
			{
				if(_customerProfileCollectionViaDirectMail==null)
				{
					_customerProfileCollectionViaDirectMail = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaDirectMail.IsReadOnly=true;
				}
				return _customerProfileCollectionViaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DirectMailTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DirectMailTypeEntity))]
		public virtual EntityCollection<DirectMailTypeEntity> DirectMailTypeCollectionViaDirectMail
		{
			get
			{
				if(_directMailTypeCollectionViaDirectMail==null)
				{
					_directMailTypeCollectionViaDirectMail = new EntityCollection<DirectMailTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory)));
					_directMailTypeCollectionViaDirectMail.IsReadOnly=true;
				}
				return _directMailTypeCollectionViaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaDirectMail
		{
			get
			{
				if(_organizationRoleUserCollectionViaDirectMail==null)
				{
					_organizationRoleUserCollectionViaDirectMail = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaDirectMail.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaDirectMail;
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File_
		{
			get
			{
				return _file_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile_(value);
				}
				else
				{
					if(value==null)
					{
						if(_file_ != null)
						{
							_file_.UnsetRelatedEntity(this, "CallUpload_");
						}
					}
					else
					{
						if(_file_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallUpload_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File
		{
			get
			{
				return _file;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile(value);
				}
				else
				{
					if(value==null)
					{
						if(_file != null)
						{
							_file.UnsetRelatedEntity(this, "CallUpload");
						}
					}
					else
					{
						if(_file!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallUpload");
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
							_lookup.UnsetRelatedEntity(this, "CallUpload");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallUpload");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CallUpload");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallUpload");
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
			get { return (int)Falcon.Data.EntityType.CallUploadEntity; }
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
