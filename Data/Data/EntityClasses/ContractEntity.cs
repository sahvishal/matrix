///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:44
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
	/// Entity class which represents the entity 'Contract'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ContractEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<HospitalFacilityEntity> _hospitalFacility;
		private EntityCollection<MedicalVendorProfileEntity> _medicalVendorProfile;
		private EntityCollection<FileEntity> _fileCollectionViaMedicalVendorProfile_;
		private EntityCollection<FileEntity> _fileCollectionViaMedicalVendorProfile;
		private EntityCollection<MedicalVendorTypeEntity> _medicalVendorTypeCollectionViaMedicalVendorProfile;
		private StateEntity _state;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name State</summary>
			public static readonly string State = "State";
			/// <summary>Member name HospitalFacility</summary>
			public static readonly string HospitalFacility = "HospitalFacility";
			/// <summary>Member name MedicalVendorProfile</summary>
			public static readonly string MedicalVendorProfile = "MedicalVendorProfile";
			/// <summary>Member name FileCollectionViaMedicalVendorProfile_</summary>
			public static readonly string FileCollectionViaMedicalVendorProfile_ = "FileCollectionViaMedicalVendorProfile_";
			/// <summary>Member name FileCollectionViaMedicalVendorProfile</summary>
			public static readonly string FileCollectionViaMedicalVendorProfile = "FileCollectionViaMedicalVendorProfile";
			/// <summary>Member name MedicalVendorTypeCollectionViaMedicalVendorProfile</summary>
			public static readonly string MedicalVendorTypeCollectionViaMedicalVendorProfile = "MedicalVendorTypeCollectionViaMedicalVendorProfile";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ContractEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ContractEntity():base("ContractEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ContractEntity(IEntityFields2 fields):base("ContractEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ContractEntity</param>
		public ContractEntity(IValidator validator):base("ContractEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="contractId">PK value for Contract which data should be fetched into this Contract object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ContractEntity(System.Int64 contractId):base("ContractEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ContractId = contractId;
		}

		/// <summary> CTor</summary>
		/// <param name="contractId">PK value for Contract which data should be fetched into this Contract object</param>
		/// <param name="validator">The custom validator object for this ContractEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ContractEntity(System.Int64 contractId, IValidator validator):base("ContractEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ContractId = contractId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ContractEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_hospitalFacility = (EntityCollection<HospitalFacilityEntity>)info.GetValue("_hospitalFacility", typeof(EntityCollection<HospitalFacilityEntity>));
				_medicalVendorProfile = (EntityCollection<MedicalVendorProfileEntity>)info.GetValue("_medicalVendorProfile", typeof(EntityCollection<MedicalVendorProfileEntity>));
				_fileCollectionViaMedicalVendorProfile_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaMedicalVendorProfile_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaMedicalVendorProfile = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaMedicalVendorProfile", typeof(EntityCollection<FileEntity>));
				_medicalVendorTypeCollectionViaMedicalVendorProfile = (EntityCollection<MedicalVendorTypeEntity>)info.GetValue("_medicalVendorTypeCollectionViaMedicalVendorProfile", typeof(EntityCollection<MedicalVendorTypeEntity>));
				_state = (StateEntity)info.GetValue("_state", typeof(StateEntity));
				if(_state!=null)
				{
					_state.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ContractFieldIndex)fieldIndex)
			{
				case ContractFieldIndex.StateId:
					DesetupSyncState(true, false);
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
				case "State":
					this.State = (StateEntity)entity;
					break;
				case "HospitalFacility":
					this.HospitalFacility.Add((HospitalFacilityEntity)entity);
					break;
				case "MedicalVendorProfile":
					this.MedicalVendorProfile.Add((MedicalVendorProfileEntity)entity);
					break;
				case "FileCollectionViaMedicalVendorProfile_":
					this.FileCollectionViaMedicalVendorProfile_.IsReadOnly = false;
					this.FileCollectionViaMedicalVendorProfile_.Add((FileEntity)entity);
					this.FileCollectionViaMedicalVendorProfile_.IsReadOnly = true;
					break;
				case "FileCollectionViaMedicalVendorProfile":
					this.FileCollectionViaMedicalVendorProfile.IsReadOnly = false;
					this.FileCollectionViaMedicalVendorProfile.Add((FileEntity)entity);
					this.FileCollectionViaMedicalVendorProfile.IsReadOnly = true;
					break;
				case "MedicalVendorTypeCollectionViaMedicalVendorProfile":
					this.MedicalVendorTypeCollectionViaMedicalVendorProfile.IsReadOnly = false;
					this.MedicalVendorTypeCollectionViaMedicalVendorProfile.Add((MedicalVendorTypeEntity)entity);
					this.MedicalVendorTypeCollectionViaMedicalVendorProfile.IsReadOnly = true;
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
			return ContractEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "State":
					toReturn.Add(ContractEntity.Relations.StateEntityUsingStateId);
					break;
				case "HospitalFacility":
					toReturn.Add(ContractEntity.Relations.HospitalFacilityEntityUsingContractId);
					break;
				case "MedicalVendorProfile":
					toReturn.Add(ContractEntity.Relations.MedicalVendorProfileEntityUsingContractId);
					break;
				case "FileCollectionViaMedicalVendorProfile_":
					toReturn.Add(ContractEntity.Relations.MedicalVendorProfileEntityUsingContractId, "ContractEntity__", "MedicalVendorProfile_", JoinHint.None);
					toReturn.Add(MedicalVendorProfileEntity.Relations.FileEntityUsingDoctorLetterFileId, "MedicalVendorProfile_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaMedicalVendorProfile":
					toReturn.Add(ContractEntity.Relations.MedicalVendorProfileEntityUsingContractId, "ContractEntity__", "MedicalVendorProfile_", JoinHint.None);
					toReturn.Add(MedicalVendorProfileEntity.Relations.FileEntityUsingResultLetterCoBrandingFileId, "MedicalVendorProfile_", string.Empty, JoinHint.None);
					break;
				case "MedicalVendorTypeCollectionViaMedicalVendorProfile":
					toReturn.Add(ContractEntity.Relations.MedicalVendorProfileEntityUsingContractId, "ContractEntity__", "MedicalVendorProfile_", JoinHint.None);
					toReturn.Add(MedicalVendorProfileEntity.Relations.MedicalVendorTypeEntityUsingTypeId, "MedicalVendorProfile_", string.Empty, JoinHint.None);
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
				case "State":
					SetupSyncState(relatedEntity);
					break;
				case "HospitalFacility":
					this.HospitalFacility.Add((HospitalFacilityEntity)relatedEntity);
					break;
				case "MedicalVendorProfile":
					this.MedicalVendorProfile.Add((MedicalVendorProfileEntity)relatedEntity);
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
				case "State":
					DesetupSyncState(false, true);
					break;
				case "HospitalFacility":
					base.PerformRelatedEntityRemoval(this.HospitalFacility, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicalVendorProfile":
					base.PerformRelatedEntityRemoval(this.MedicalVendorProfile, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_state!=null)
			{
				toReturn.Add(_state);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.HospitalFacility);
			toReturn.Add(this.MedicalVendorProfile);

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
				info.AddValue("_hospitalFacility", ((_hospitalFacility!=null) && (_hospitalFacility.Count>0) && !this.MarkedForDeletion)?_hospitalFacility:null);
				info.AddValue("_medicalVendorProfile", ((_medicalVendorProfile!=null) && (_medicalVendorProfile.Count>0) && !this.MarkedForDeletion)?_medicalVendorProfile:null);
				info.AddValue("_fileCollectionViaMedicalVendorProfile_", ((_fileCollectionViaMedicalVendorProfile_!=null) && (_fileCollectionViaMedicalVendorProfile_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaMedicalVendorProfile_:null);
				info.AddValue("_fileCollectionViaMedicalVendorProfile", ((_fileCollectionViaMedicalVendorProfile!=null) && (_fileCollectionViaMedicalVendorProfile.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaMedicalVendorProfile:null);
				info.AddValue("_medicalVendorTypeCollectionViaMedicalVendorProfile", ((_medicalVendorTypeCollectionViaMedicalVendorProfile!=null) && (_medicalVendorTypeCollectionViaMedicalVendorProfile.Count>0) && !this.MarkedForDeletion)?_medicalVendorTypeCollectionViaMedicalVendorProfile:null);
				info.AddValue("_state", (!this.MarkedForDeletion?_state:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ContractFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ContractFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ContractRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalFacility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalFacility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalFacilityFields.ContractId, null, ComparisonOperator.Equal, this.ContractId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendorProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorProfileFields.ContractId, null, ComparisonOperator.Equal, this.ContractId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaMedicalVendorProfile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaMedicalVendorProfile_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContractFields.ContractId, null, ComparisonOperator.Equal, this.ContractId, "ContractEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaMedicalVendorProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaMedicalVendorProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContractFields.ContractId, null, ComparisonOperator.Equal, this.ContractId, "ContractEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendorType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorTypeCollectionViaMedicalVendorProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MedicalVendorTypeCollectionViaMedicalVendorProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContractFields.ContractId, null, ComparisonOperator.Equal, this.ContractId, "ContractEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'State' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoState()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.StateId, null, ComparisonOperator.Equal, this.StateId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ContractEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ContractEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._hospitalFacility);
			collectionsQueue.Enqueue(this._medicalVendorProfile);
			collectionsQueue.Enqueue(this._fileCollectionViaMedicalVendorProfile_);
			collectionsQueue.Enqueue(this._fileCollectionViaMedicalVendorProfile);
			collectionsQueue.Enqueue(this._medicalVendorTypeCollectionViaMedicalVendorProfile);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._hospitalFacility = (EntityCollection<HospitalFacilityEntity>) collectionsQueue.Dequeue();
			this._medicalVendorProfile = (EntityCollection<MedicalVendorProfileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaMedicalVendorProfile_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaMedicalVendorProfile = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._medicalVendorTypeCollectionViaMedicalVendorProfile = (EntityCollection<MedicalVendorTypeEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._hospitalFacility != null)
			{
				return true;
			}
			if (this._medicalVendorProfile != null)
			{
				return true;
			}
			if (this._fileCollectionViaMedicalVendorProfile_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaMedicalVendorProfile != null)
			{
				return true;
			}
			if (this._medicalVendorTypeCollectionViaMedicalVendorProfile != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorTypeEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("State", _state);
			toReturn.Add("HospitalFacility", _hospitalFacility);
			toReturn.Add("MedicalVendorProfile", _medicalVendorProfile);
			toReturn.Add("FileCollectionViaMedicalVendorProfile_", _fileCollectionViaMedicalVendorProfile_);
			toReturn.Add("FileCollectionViaMedicalVendorProfile", _fileCollectionViaMedicalVendorProfile);
			toReturn.Add("MedicalVendorTypeCollectionViaMedicalVendorProfile", _medicalVendorTypeCollectionViaMedicalVendorProfile);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_hospitalFacility!=null)
			{
				_hospitalFacility.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorProfile!=null)
			{
				_medicalVendorProfile.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaMedicalVendorProfile_!=null)
			{
				_fileCollectionViaMedicalVendorProfile_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaMedicalVendorProfile!=null)
			{
				_fileCollectionViaMedicalVendorProfile.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorTypeCollectionViaMedicalVendorProfile!=null)
			{
				_medicalVendorTypeCollectionViaMedicalVendorProfile.ActiveContext = base.ActiveContext;
			}
			if(_state!=null)
			{
				_state.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_hospitalFacility = null;
			_medicalVendorProfile = null;
			_fileCollectionViaMedicalVendorProfile_ = null;
			_fileCollectionViaMedicalVendorProfile = null;
			_medicalVendorTypeCollectionViaMedicalVendorProfile = null;
			_state = null;

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

			_fieldsCustomProperties.Add("ContractId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContractName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Contract", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EndDate", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _state</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncState(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _state, new PropertyChangedEventHandler( OnStatePropertyChanged ), "State", ContractEntity.Relations.StateEntityUsingStateId, true, signalRelatedEntity, "Contract", resetFKFields, new int[] { (int)ContractFieldIndex.StateId } );		
			_state = null;
		}

		/// <summary> setups the sync logic for member _state</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncState(IEntity2 relatedEntity)
		{
			if(_state!=relatedEntity)
			{
				DesetupSyncState(true, true);
				_state = (StateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _state, new PropertyChangedEventHandler( OnStatePropertyChanged ), "State", ContractEntity.Relations.StateEntityUsingStateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnStatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ContractEntity</param>
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
		public  static ContractRelations Relations
		{
			get	{ return new ContractRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalFacility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalFacility
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalFacility")[0], (int)Falcon.Data.EntityType.ContractEntity, (int)Falcon.Data.EntityType.HospitalFacilityEntity, 0, null, null, null, null, "HospitalFacility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorProfile
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicalVendorProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorProfile")[0], (int)Falcon.Data.EntityType.ContractEntity, (int)Falcon.Data.EntityType.MedicalVendorProfileEntity, 0, null, null, null, null, "MedicalVendorProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaMedicalVendorProfile_
		{
			get
			{
				IEntityRelation intermediateRelation = ContractEntity.Relations.MedicalVendorProfileEntityUsingContractId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorProfile_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ContractEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaMedicalVendorProfile_"), null, "FileCollectionViaMedicalVendorProfile_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaMedicalVendorProfile
		{
			get
			{
				IEntityRelation intermediateRelation = ContractEntity.Relations.MedicalVendorProfileEntityUsingContractId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorProfile_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ContractEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaMedicalVendorProfile"), null, "FileCollectionViaMedicalVendorProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorTypeCollectionViaMedicalVendorProfile
		{
			get
			{
				IEntityRelation intermediateRelation = ContractEntity.Relations.MedicalVendorProfileEntityUsingContractId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorProfile_");
				return new PrefetchPathElement2(new EntityCollection<MedicalVendorTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ContractEntity, (int)Falcon.Data.EntityType.MedicalVendorTypeEntity, 0, null, null, GetRelationsForField("MedicalVendorTypeCollectionViaMedicalVendorProfile"), null, "MedicalVendorTypeCollectionViaMedicalVendorProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'State' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathState
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))),
					(IEntityRelation)GetRelationsForField("State")[0], (int)Falcon.Data.EntityType.ContractEntity, (int)Falcon.Data.EntityType.StateEntity, 0, null, null, null, null, "State", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ContractEntity.CustomProperties;}
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
			get { return ContractEntity.FieldsCustomProperties;}
		}

		/// <summary> The ContractId property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."ContractID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ContractId
		{
			get { return (System.Int64)GetValue((int)ContractFieldIndex.ContractId, true); }
			set	{ SetValue((int)ContractFieldIndex.ContractId, value); }
		}

		/// <summary> The ContractName property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."ContractName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ContractName
		{
			get { return (System.String)GetValue((int)ContractFieldIndex.ContractName, true); }
			set	{ SetValue((int)ContractFieldIndex.ContractName, value); }
		}

		/// <summary> The StateId property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."StateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 StateId
		{
			get { return (System.Int64)GetValue((int)ContractFieldIndex.StateId, true); }
			set	{ SetValue((int)ContractFieldIndex.StateId, value); }
		}

		/// <summary> The Description property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)ContractFieldIndex.Description, true); }
			set	{ SetValue((int)ContractFieldIndex.Description, value); }
		}

		/// <summary> The Contract property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."Contract"<br/>
		/// Table field type characteristics (type, precision, scale, length): Text, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Contract
		{
			get { return (System.String)GetValue((int)ContractFieldIndex.Contract, true); }
			set	{ SetValue((int)ContractFieldIndex.Contract, value); }
		}

		/// <summary> The IsActive property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ContractFieldIndex.IsActive, true); }
			set	{ SetValue((int)ContractFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ContractFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ContractFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ContractFieldIndex.DateModified, true); }
			set	{ SetValue((int)ContractFieldIndex.DateModified, value); }
		}

		/// <summary> The StartDate property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."StartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> StartDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ContractFieldIndex.StartDate, false); }
			set	{ SetValue((int)ContractFieldIndex.StartDate, value); }
		}

		/// <summary> The EndDate property of the Entity Contract<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblContract"."EndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> EndDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ContractFieldIndex.EndDate, false); }
			set	{ SetValue((int)ContractFieldIndex.EndDate, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalFacilityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalFacilityEntity))]
		public virtual EntityCollection<HospitalFacilityEntity> HospitalFacility
		{
			get
			{
				if(_hospitalFacility==null)
				{
					_hospitalFacility = new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory)));
					_hospitalFacility.SetContainingEntityInfo(this, "Contract");
				}
				return _hospitalFacility;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorProfileEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorProfileEntity))]
		public virtual EntityCollection<MedicalVendorProfileEntity> MedicalVendorProfile
		{
			get
			{
				if(_medicalVendorProfile==null)
				{
					_medicalVendorProfile = new EntityCollection<MedicalVendorProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorProfileEntityFactory)));
					_medicalVendorProfile.SetContainingEntityInfo(this, "Contract");
				}
				return _medicalVendorProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaMedicalVendorProfile_
		{
			get
			{
				if(_fileCollectionViaMedicalVendorProfile_==null)
				{
					_fileCollectionViaMedicalVendorProfile_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaMedicalVendorProfile_.IsReadOnly=true;
				}
				return _fileCollectionViaMedicalVendorProfile_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaMedicalVendorProfile
		{
			get
			{
				if(_fileCollectionViaMedicalVendorProfile==null)
				{
					_fileCollectionViaMedicalVendorProfile = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaMedicalVendorProfile.IsReadOnly=true;
				}
				return _fileCollectionViaMedicalVendorProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorTypeEntity))]
		public virtual EntityCollection<MedicalVendorTypeEntity> MedicalVendorTypeCollectionViaMedicalVendorProfile
		{
			get
			{
				if(_medicalVendorTypeCollectionViaMedicalVendorProfile==null)
				{
					_medicalVendorTypeCollectionViaMedicalVendorProfile = new EntityCollection<MedicalVendorTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorTypeEntityFactory)));
					_medicalVendorTypeCollectionViaMedicalVendorProfile.IsReadOnly=true;
				}
				return _medicalVendorTypeCollectionViaMedicalVendorProfile;
			}
		}

		/// <summary> Gets / sets related entity of type 'StateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual StateEntity State
		{
			get
			{
				return _state;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncState(value);
				}
				else
				{
					if(value==null)
					{
						if(_state != null)
						{
							_state.UnsetRelatedEntity(this, "Contract");
						}
					}
					else
					{
						if(_state!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Contract");
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
			get { return (int)Falcon.Data.EntityType.ContractEntity; }
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
