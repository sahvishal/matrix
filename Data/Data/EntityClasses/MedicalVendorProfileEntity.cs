///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'MedicalVendorProfile'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MedicalVendorProfileEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private ContractEntity _contract;
		private FileEntity _file_;
		private FileEntity _file;
		private MedicalVendorTypeEntity _medicalVendorType;
		private HospitalPartnerEntity _hospitalPartner;
		private OrganizationEntity _organization;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Contract</summary>
			public static readonly string Contract = "Contract";
			/// <summary>Member name File_</summary>
			public static readonly string File_ = "File_";
			/// <summary>Member name File</summary>
			public static readonly string File = "File";
			/// <summary>Member name MedicalVendorType</summary>
			public static readonly string MedicalVendorType = "MedicalVendorType";


			/// <summary>Member name HospitalPartner</summary>
			public static readonly string HospitalPartner = "HospitalPartner";
			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MedicalVendorProfileEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MedicalVendorProfileEntity():base("MedicalVendorProfileEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MedicalVendorProfileEntity(IEntityFields2 fields):base("MedicalVendorProfileEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MedicalVendorProfileEntity</param>
		public MedicalVendorProfileEntity(IValidator validator):base("MedicalVendorProfileEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="organizationId">PK value for MedicalVendorProfile which data should be fetched into this MedicalVendorProfile object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorProfileEntity(System.Int64 organizationId):base("MedicalVendorProfileEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OrganizationId = organizationId;
		}

		/// <summary> CTor</summary>
		/// <param name="organizationId">PK value for MedicalVendorProfile which data should be fetched into this MedicalVendorProfile object</param>
		/// <param name="validator">The custom validator object for this MedicalVendorProfileEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorProfileEntity(System.Int64 organizationId, IValidator validator):base("MedicalVendorProfileEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OrganizationId = organizationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MedicalVendorProfileEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_contract = (ContractEntity)info.GetValue("_contract", typeof(ContractEntity));
				if(_contract!=null)
				{
					_contract.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
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
				_medicalVendorType = (MedicalVendorTypeEntity)info.GetValue("_medicalVendorType", typeof(MedicalVendorTypeEntity));
				if(_medicalVendorType!=null)
				{
					_medicalVendorType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hospitalPartner = (HospitalPartnerEntity)info.GetValue("_hospitalPartner", typeof(HospitalPartnerEntity));
				if(_hospitalPartner!=null)
				{
					_hospitalPartner.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organization = (OrganizationEntity)info.GetValue("_organization", typeof(OrganizationEntity));
				if(_organization!=null)
				{
					_organization.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MedicalVendorProfileFieldIndex)fieldIndex)
			{
				case MedicalVendorProfileFieldIndex.OrganizationId:
					DesetupSyncOrganization(true, false);
					break;
				case MedicalVendorProfileFieldIndex.TypeId:
					DesetupSyncMedicalVendorType(true, false);
					break;
				case MedicalVendorProfileFieldIndex.ContractId:
					DesetupSyncContract(true, false);
					break;
				case MedicalVendorProfileFieldIndex.ResultLetterCoBrandingFileId:
					DesetupSyncFile(true, false);
					break;
				case MedicalVendorProfileFieldIndex.DoctorLetterFileId:
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
				case "Contract":
					this.Contract = (ContractEntity)entity;
					break;
				case "File_":
					this.File_ = (FileEntity)entity;
					break;
				case "File":
					this.File = (FileEntity)entity;
					break;
				case "MedicalVendorType":
					this.MedicalVendorType = (MedicalVendorTypeEntity)entity;
					break;


				case "HospitalPartner":
					this.HospitalPartner = (HospitalPartnerEntity)entity;
					break;
				case "Organization":
					this.Organization = (OrganizationEntity)entity;
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
			return MedicalVendorProfileEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Contract":
					toReturn.Add(MedicalVendorProfileEntity.Relations.ContractEntityUsingContractId);
					break;
				case "File_":
					toReturn.Add(MedicalVendorProfileEntity.Relations.FileEntityUsingDoctorLetterFileId);
					break;
				case "File":
					toReturn.Add(MedicalVendorProfileEntity.Relations.FileEntityUsingResultLetterCoBrandingFileId);
					break;
				case "MedicalVendorType":
					toReturn.Add(MedicalVendorProfileEntity.Relations.MedicalVendorTypeEntityUsingTypeId);
					break;


				case "HospitalPartner":
					toReturn.Add(MedicalVendorProfileEntity.Relations.HospitalPartnerEntityUsingHospitalPartnerId);
					break;
				case "Organization":
					toReturn.Add(MedicalVendorProfileEntity.Relations.OrganizationEntityUsingOrganizationId);
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
				case "Contract":
					SetupSyncContract(relatedEntity);
					break;
				case "File_":
					SetupSyncFile_(relatedEntity);
					break;
				case "File":
					SetupSyncFile(relatedEntity);
					break;
				case "MedicalVendorType":
					SetupSyncMedicalVendorType(relatedEntity);
					break;

				case "HospitalPartner":
					SetupSyncHospitalPartner(relatedEntity);
					break;
				case "Organization":
					SetupSyncOrganization(relatedEntity);
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
				case "Contract":
					DesetupSyncContract(false, true);
					break;
				case "File_":
					DesetupSyncFile_(false, true);
					break;
				case "File":
					DesetupSyncFile(false, true);
					break;
				case "MedicalVendorType":
					DesetupSyncMedicalVendorType(false, true);
					break;

				case "HospitalPartner":
					DesetupSyncHospitalPartner(false, true);
					break;
				case "Organization":
					DesetupSyncOrganization(false, true);
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
			if(_hospitalPartner!=null)
			{
				toReturn.Add(_hospitalPartner);
			}



			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_contract!=null)
			{
				toReturn.Add(_contract);
			}
			if(_file_!=null)
			{
				toReturn.Add(_file_);
			}
			if(_file!=null)
			{
				toReturn.Add(_file);
			}
			if(_medicalVendorType!=null)
			{
				toReturn.Add(_medicalVendorType);
			}


			if(_organization!=null)
			{
				toReturn.Add(_organization);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();


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


				info.AddValue("_contract", (!this.MarkedForDeletion?_contract:null));
				info.AddValue("_file_", (!this.MarkedForDeletion?_file_:null));
				info.AddValue("_file", (!this.MarkedForDeletion?_file:null));
				info.AddValue("_medicalVendorType", (!this.MarkedForDeletion?_medicalVendorType:null));
				info.AddValue("_hospitalPartner", (!this.MarkedForDeletion?_hospitalPartner:null));
				info.AddValue("_organization", (!this.MarkedForDeletion?_organization:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MedicalVendorProfileFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MedicalVendorProfileFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MedicalVendorProfileRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Contract' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContract()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContractFields.ContractId, null, ComparisonOperator.Equal, this.ContractId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.DoctorLetterFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.ResultLetterCoBrandingFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MedicalVendorType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorTypeFields.MedicalVendorTypeId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HospitalPartner' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartner()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Organization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MedicalVendorProfileEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorProfileEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{


			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Contract", _contract);
			toReturn.Add("File_", _file_);
			toReturn.Add("File", _file);
			toReturn.Add("MedicalVendorType", _medicalVendorType);


			toReturn.Add("HospitalPartner", _hospitalPartner);
			toReturn.Add("Organization", _organization);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_contract!=null)
			{
				_contract.ActiveContext = base.ActiveContext;
			}
			if(_file_!=null)
			{
				_file_.ActiveContext = base.ActiveContext;
			}
			if(_file!=null)
			{
				_file.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorType!=null)
			{
				_medicalVendorType.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartner!=null)
			{
				_hospitalPartner.ActiveContext = base.ActiveContext;
			}
			if(_organization!=null)
			{
				_organization.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_contract = null;
			_file_ = null;
			_file = null;
			_medicalVendorType = null;
			_hospitalPartner = null;
			_organization = null;
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

			_fieldsCustomProperties.Add("OrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContractId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsHospitalPartner", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultLetterCoBrandingFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoctorLetterFileId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _contract</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncContract(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _contract, new PropertyChangedEventHandler( OnContractPropertyChanged ), "Contract", MedicalVendorProfileEntity.Relations.ContractEntityUsingContractId, true, signalRelatedEntity, "MedicalVendorProfile", resetFKFields, new int[] { (int)MedicalVendorProfileFieldIndex.ContractId } );		
			_contract = null;
		}

		/// <summary> setups the sync logic for member _contract</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncContract(IEntity2 relatedEntity)
		{
			if(_contract!=relatedEntity)
			{
				DesetupSyncContract(true, true);
				_contract = (ContractEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _contract, new PropertyChangedEventHandler( OnContractPropertyChanged ), "Contract", MedicalVendorProfileEntity.Relations.ContractEntityUsingContractId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnContractPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", MedicalVendorProfileEntity.Relations.FileEntityUsingDoctorLetterFileId, true, signalRelatedEntity, "MedicalVendorProfile_", resetFKFields, new int[] { (int)MedicalVendorProfileFieldIndex.DoctorLetterFileId } );		
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
				base.PerformSetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", MedicalVendorProfileEntity.Relations.FileEntityUsingDoctorLetterFileId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", MedicalVendorProfileEntity.Relations.FileEntityUsingResultLetterCoBrandingFileId, true, signalRelatedEntity, "MedicalVendorProfile", resetFKFields, new int[] { (int)MedicalVendorProfileFieldIndex.ResultLetterCoBrandingFileId } );		
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
				base.PerformSetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", MedicalVendorProfileEntity.Relations.FileEntityUsingResultLetterCoBrandingFileId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _medicalVendorType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicalVendorType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicalVendorType, new PropertyChangedEventHandler( OnMedicalVendorTypePropertyChanged ), "MedicalVendorType", MedicalVendorProfileEntity.Relations.MedicalVendorTypeEntityUsingTypeId, true, signalRelatedEntity, "MedicalVendorProfile", resetFKFields, new int[] { (int)MedicalVendorProfileFieldIndex.TypeId } );		
			_medicalVendorType = null;
		}

		/// <summary> setups the sync logic for member _medicalVendorType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicalVendorType(IEntity2 relatedEntity)
		{
			if(_medicalVendorType!=relatedEntity)
			{
				DesetupSyncMedicalVendorType(true, true);
				_medicalVendorType = (MedicalVendorTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicalVendorType, new PropertyChangedEventHandler( OnMedicalVendorTypePropertyChanged ), "MedicalVendorType", MedicalVendorProfileEntity.Relations.MedicalVendorTypeEntityUsingTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicalVendorTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _hospitalPartner</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHospitalPartner(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hospitalPartner, new PropertyChangedEventHandler( OnHospitalPartnerPropertyChanged ), "HospitalPartner", MedicalVendorProfileEntity.Relations.HospitalPartnerEntityUsingHospitalPartnerId, false, signalRelatedEntity, "MedicalVendorProfile", false, new int[] { (int)MedicalVendorProfileFieldIndex.OrganizationId } );
			_hospitalPartner = null;
		}
		
		/// <summary> setups the sync logic for member _hospitalPartner</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHospitalPartner(IEntity2 relatedEntity)
		{
			if(_hospitalPartner!=relatedEntity)
			{
				DesetupSyncHospitalPartner(true, true);
				_hospitalPartner = (HospitalPartnerEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hospitalPartner, new PropertyChangedEventHandler( OnHospitalPartnerPropertyChanged ), "HospitalPartner", MedicalVendorProfileEntity.Relations.HospitalPartnerEntityUsingHospitalPartnerId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHospitalPartnerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", MedicalVendorProfileEntity.Relations.OrganizationEntityUsingOrganizationId, true, signalRelatedEntity, "MedicalVendorProfile", false, new int[] { (int)MedicalVendorProfileFieldIndex.OrganizationId } );
			_organization = null;
		}
		
		/// <summary> setups the sync logic for member _organization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganization(IEntity2 relatedEntity)
		{
			if(_organization!=relatedEntity)
			{
				DesetupSyncOrganization(true, true);
				_organization = (OrganizationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", MedicalVendorProfileEntity.Relations.OrganizationEntityUsingOrganizationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MedicalVendorProfileEntity</param>
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
		public  static MedicalVendorProfileRelations Relations
		{
			get	{ return new MedicalVendorProfileRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Contract' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContract
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ContractEntityFactory))),
					(IEntityRelation)GetRelationsForField("Contract")[0], (int)Falcon.Data.EntityType.MedicalVendorProfileEntity, (int)Falcon.Data.EntityType.ContractEntity, 0, null, null, null, null, "Contract", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("File_")[0], (int)Falcon.Data.EntityType.MedicalVendorProfileEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("File")[0], (int)Falcon.Data.EntityType.MedicalVendorProfileEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorType")[0], (int)Falcon.Data.EntityType.MedicalVendorProfileEntity, (int)Falcon.Data.EntityType.MedicalVendorTypeEntity, 0, null, null, null, null, "MedicalVendorType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartner' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartner
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalPartner")[0], (int)Falcon.Data.EntityType.MedicalVendorProfileEntity, (int)Falcon.Data.EntityType.HospitalPartnerEntity, 0, null, null, null, null, "HospitalPartner", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization")[0], (int)Falcon.Data.EntityType.MedicalVendorProfileEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MedicalVendorProfileEntity.CustomProperties;}
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
			get { return MedicalVendorProfileEntity.FieldsCustomProperties;}
		}

		/// <summary> The OrganizationId property of the Entity MedicalVendorProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorProfile"."OrganizationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 OrganizationId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorProfileFieldIndex.OrganizationId, true); }
			set	{ SetValue((int)MedicalVendorProfileFieldIndex.OrganizationId, value); }
		}

		/// <summary> The TypeId property of the Entity MedicalVendorProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorProfile"."TypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorProfileFieldIndex.TypeId, true); }
			set	{ SetValue((int)MedicalVendorProfileFieldIndex.TypeId, value); }
		}

		/// <summary> The ContractId property of the Entity MedicalVendorProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorProfile"."ContractID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ContractId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorProfileFieldIndex.ContractId, true); }
			set	{ SetValue((int)MedicalVendorProfileFieldIndex.ContractId, value); }
		}

		/// <summary> The IsHospitalPartner property of the Entity MedicalVendorProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorProfile"."IsHospitalPartner"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsHospitalPartner
		{
			get { return (System.Boolean)GetValue((int)MedicalVendorProfileFieldIndex.IsHospitalPartner, true); }
			set	{ SetValue((int)MedicalVendorProfileFieldIndex.IsHospitalPartner, value); }
		}

		/// <summary> The ResultLetterCoBrandingFileId property of the Entity MedicalVendorProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorProfile"."ResultLetterCoBrandingFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ResultLetterCoBrandingFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MedicalVendorProfileFieldIndex.ResultLetterCoBrandingFileId, false); }
			set	{ SetValue((int)MedicalVendorProfileFieldIndex.ResultLetterCoBrandingFileId, value); }
		}

		/// <summary> The DoctorLetterFileId property of the Entity MedicalVendorProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorProfile"."DoctorLetterFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DoctorLetterFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MedicalVendorProfileFieldIndex.DoctorLetterFileId, false); }
			set	{ SetValue((int)MedicalVendorProfileFieldIndex.DoctorLetterFileId, value); }
		}



		/// <summary> Gets / sets related entity of type 'ContractEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ContractEntity Contract
		{
			get
			{
				return _contract;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncContract(value);
				}
				else
				{
					if(value==null)
					{
						if(_contract != null)
						{
							_contract.UnsetRelatedEntity(this, "MedicalVendorProfile");
						}
					}
					else
					{
						if(_contract!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorProfile");
						}
					}
				}
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
							_file_.UnsetRelatedEntity(this, "MedicalVendorProfile_");
						}
					}
					else
					{
						if(_file_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorProfile_");
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
							_file.UnsetRelatedEntity(this, "MedicalVendorProfile");
						}
					}
					else
					{
						if(_file!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorProfile");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MedicalVendorTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicalVendorTypeEntity MedicalVendorType
		{
			get
			{
				return _medicalVendorType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicalVendorType(value);
				}
				else
				{
					if(value==null)
					{
						if(_medicalVendorType != null)
						{
							_medicalVendorType.UnsetRelatedEntity(this, "MedicalVendorProfile");
						}
					}
					else
					{
						if(_medicalVendorType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorProfile");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HospitalPartnerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HospitalPartnerEntity HospitalPartner
		{
			get
			{
				return _hospitalPartner;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHospitalPartner(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "MedicalVendorProfile");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_hospitalPartner !=null);
						DesetupSyncHospitalPartner(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("HospitalPartner");
						}
					}
					else
					{
						if(_hospitalPartner!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "MedicalVendorProfile");
							SetupSyncHospitalPartner(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationEntity Organization
		{
			get
			{
				return _organization;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganization(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "MedicalVendorProfile");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_organization !=null);
						DesetupSyncOrganization(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("Organization");
						}
					}
					else
					{
						if(_organization!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "MedicalVendorProfile");
							SetupSyncOrganization(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.MedicalVendorProfileEntity; }
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
