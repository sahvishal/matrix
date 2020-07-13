﻿///////////////////////////////////////////////////////////////
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
	/// Entity class which represents the entity 'MvuserClassification'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MvuserClassificationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<PhysicianProfileEntity> _physicianProfile;
		private EntityCollection<FileEntity> _fileCollectionViaPhysicianProfile_;
		private EntityCollection<FileEntity> _fileCollectionViaPhysicianProfile;
		private EntityCollection<PhysicianSpecializationEntity> _physicianSpecializationCollectionViaPhysicianProfile;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name PhysicianProfile</summary>
			public static readonly string PhysicianProfile = "PhysicianProfile";
			/// <summary>Member name FileCollectionViaPhysicianProfile_</summary>
			public static readonly string FileCollectionViaPhysicianProfile_ = "FileCollectionViaPhysicianProfile_";
			/// <summary>Member name FileCollectionViaPhysicianProfile</summary>
			public static readonly string FileCollectionViaPhysicianProfile = "FileCollectionViaPhysicianProfile";
			/// <summary>Member name PhysicianSpecializationCollectionViaPhysicianProfile</summary>
			public static readonly string PhysicianSpecializationCollectionViaPhysicianProfile = "PhysicianSpecializationCollectionViaPhysicianProfile";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MvuserClassificationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MvuserClassificationEntity():base("MvuserClassificationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MvuserClassificationEntity(IEntityFields2 fields):base("MvuserClassificationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MvuserClassificationEntity</param>
		public MvuserClassificationEntity(IValidator validator):base("MvuserClassificationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="mvuserClassificationId">PK value for MvuserClassification which data should be fetched into this MvuserClassification object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MvuserClassificationEntity(System.Int64 mvuserClassificationId):base("MvuserClassificationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MvuserClassificationId = mvuserClassificationId;
		}

		/// <summary> CTor</summary>
		/// <param name="mvuserClassificationId">PK value for MvuserClassification which data should be fetched into this MvuserClassification object</param>
		/// <param name="validator">The custom validator object for this MvuserClassificationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MvuserClassificationEntity(System.Int64 mvuserClassificationId, IValidator validator):base("MvuserClassificationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MvuserClassificationId = mvuserClassificationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MvuserClassificationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_physicianProfile = (EntityCollection<PhysicianProfileEntity>)info.GetValue("_physicianProfile", typeof(EntityCollection<PhysicianProfileEntity>));
				_fileCollectionViaPhysicianProfile_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaPhysicianProfile_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaPhysicianProfile = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaPhysicianProfile", typeof(EntityCollection<FileEntity>));
				_physicianSpecializationCollectionViaPhysicianProfile = (EntityCollection<PhysicianSpecializationEntity>)info.GetValue("_physicianSpecializationCollectionViaPhysicianProfile", typeof(EntityCollection<PhysicianSpecializationEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((MvuserClassificationFieldIndex)fieldIndex)
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

				case "PhysicianProfile":
					this.PhysicianProfile.Add((PhysicianProfileEntity)entity);
					break;
				case "FileCollectionViaPhysicianProfile_":
					this.FileCollectionViaPhysicianProfile_.IsReadOnly = false;
					this.FileCollectionViaPhysicianProfile_.Add((FileEntity)entity);
					this.FileCollectionViaPhysicianProfile_.IsReadOnly = true;
					break;
				case "FileCollectionViaPhysicianProfile":
					this.FileCollectionViaPhysicianProfile.IsReadOnly = false;
					this.FileCollectionViaPhysicianProfile.Add((FileEntity)entity);
					this.FileCollectionViaPhysicianProfile.IsReadOnly = true;
					break;
				case "PhysicianSpecializationCollectionViaPhysicianProfile":
					this.PhysicianSpecializationCollectionViaPhysicianProfile.IsReadOnly = false;
					this.PhysicianSpecializationCollectionViaPhysicianProfile.Add((PhysicianSpecializationEntity)entity);
					this.PhysicianSpecializationCollectionViaPhysicianProfile.IsReadOnly = true;
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
			return MvuserClassificationEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "PhysicianProfile":
					toReturn.Add(MvuserClassificationEntity.Relations.PhysicianProfileEntityUsingClassificationId);
					break;
				case "FileCollectionViaPhysicianProfile_":
					toReturn.Add(MvuserClassificationEntity.Relations.PhysicianProfileEntityUsingClassificationId, "MvuserClassificationEntity__", "PhysicianProfile_", JoinHint.None);
					toReturn.Add(PhysicianProfileEntity.Relations.FileEntityUsingDigitalSignatureFileId, "PhysicianProfile_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaPhysicianProfile":
					toReturn.Add(MvuserClassificationEntity.Relations.PhysicianProfileEntityUsingClassificationId, "MvuserClassificationEntity__", "PhysicianProfile_", JoinHint.None);
					toReturn.Add(PhysicianProfileEntity.Relations.FileEntityUsingResumeFileId, "PhysicianProfile_", string.Empty, JoinHint.None);
					break;
				case "PhysicianSpecializationCollectionViaPhysicianProfile":
					toReturn.Add(MvuserClassificationEntity.Relations.PhysicianProfileEntityUsingClassificationId, "MvuserClassificationEntity__", "PhysicianProfile_", JoinHint.None);
					toReturn.Add(PhysicianProfileEntity.Relations.PhysicianSpecializationEntityUsingSpecializationId, "PhysicianProfile_", string.Empty, JoinHint.None);
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

				case "PhysicianProfile":
					this.PhysicianProfile.Add((PhysicianProfileEntity)relatedEntity);
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

				case "PhysicianProfile":
					base.PerformRelatedEntityRemoval(this.PhysicianProfile, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.PhysicianProfile);

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
				info.AddValue("_physicianProfile", ((_physicianProfile!=null) && (_physicianProfile.Count>0) && !this.MarkedForDeletion)?_physicianProfile:null);
				info.AddValue("_fileCollectionViaPhysicianProfile_", ((_fileCollectionViaPhysicianProfile_!=null) && (_fileCollectionViaPhysicianProfile_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaPhysicianProfile_:null);
				info.AddValue("_fileCollectionViaPhysicianProfile", ((_fileCollectionViaPhysicianProfile!=null) && (_fileCollectionViaPhysicianProfile.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaPhysicianProfile:null);
				info.AddValue("_physicianSpecializationCollectionViaPhysicianProfile", ((_physicianSpecializationCollectionViaPhysicianProfile!=null) && (_physicianSpecializationCollectionViaPhysicianProfile.Count>0) && !this.MarkedForDeletion)?_physicianSpecializationCollectionViaPhysicianProfile:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MvuserClassificationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MvuserClassificationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MvuserClassificationRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianProfileFields.ClassificationId, null, ComparisonOperator.Equal, this.MvuserClassificationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaPhysicianProfile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaPhysicianProfile_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvuserClassificationFields.MvuserClassificationId, null, ComparisonOperator.Equal, this.MvuserClassificationId, "MvuserClassificationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaPhysicianProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaPhysicianProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvuserClassificationFields.MvuserClassificationId, null, ComparisonOperator.Equal, this.MvuserClassificationId, "MvuserClassificationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianSpecialization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianSpecializationCollectionViaPhysicianProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianSpecializationCollectionViaPhysicianProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvuserClassificationFields.MvuserClassificationId, null, ComparisonOperator.Equal, this.MvuserClassificationId, "MvuserClassificationEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MvuserClassificationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MvuserClassificationEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._physicianProfile);
			collectionsQueue.Enqueue(this._fileCollectionViaPhysicianProfile_);
			collectionsQueue.Enqueue(this._fileCollectionViaPhysicianProfile);
			collectionsQueue.Enqueue(this._physicianSpecializationCollectionViaPhysicianProfile);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._physicianProfile = (EntityCollection<PhysicianProfileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaPhysicianProfile_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaPhysicianProfile = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._physicianSpecializationCollectionViaPhysicianProfile = (EntityCollection<PhysicianSpecializationEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._physicianProfile != null)
			{
				return true;
			}
			if (this._fileCollectionViaPhysicianProfile_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaPhysicianProfile != null)
			{
				return true;
			}
			if (this._physicianSpecializationCollectionViaPhysicianProfile != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianSpecializationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianSpecializationEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("PhysicianProfile", _physicianProfile);
			toReturn.Add("FileCollectionViaPhysicianProfile_", _fileCollectionViaPhysicianProfile_);
			toReturn.Add("FileCollectionViaPhysicianProfile", _fileCollectionViaPhysicianProfile);
			toReturn.Add("PhysicianSpecializationCollectionViaPhysicianProfile", _physicianSpecializationCollectionViaPhysicianProfile);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_physicianProfile!=null)
			{
				_physicianProfile.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaPhysicianProfile_!=null)
			{
				_fileCollectionViaPhysicianProfile_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaPhysicianProfile!=null)
			{
				_fileCollectionViaPhysicianProfile.ActiveContext = base.ActiveContext;
			}
			if(_physicianSpecializationCollectionViaPhysicianProfile!=null)
			{
				_physicianSpecializationCollectionViaPhysicianProfile.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_physicianProfile = null;
			_fileCollectionViaPhysicianProfile_ = null;
			_fileCollectionViaPhysicianProfile = null;
			_physicianSpecializationCollectionViaPhysicianProfile = null;


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

			_fieldsCustomProperties.Add("MvuserClassificationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MvuserClassificationEntity</param>
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
		public  static MvuserClassificationRelations Relations
		{
			get	{ return new MvuserClassificationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfile
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianProfile")[0], (int)Falcon.Data.EntityType.MvuserClassificationEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, null, null, "PhysicianProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaPhysicianProfile_
		{
			get
			{
				IEntityRelation intermediateRelation = MvuserClassificationEntity.Relations.PhysicianProfileEntityUsingClassificationId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianProfile_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MvuserClassificationEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaPhysicianProfile_"), null, "FileCollectionViaPhysicianProfile_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaPhysicianProfile
		{
			get
			{
				IEntityRelation intermediateRelation = MvuserClassificationEntity.Relations.PhysicianProfileEntityUsingClassificationId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianProfile_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MvuserClassificationEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaPhysicianProfile"), null, "FileCollectionViaPhysicianProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianSpecialization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianSpecializationCollectionViaPhysicianProfile
		{
			get
			{
				IEntityRelation intermediateRelation = MvuserClassificationEntity.Relations.PhysicianProfileEntityUsingClassificationId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianProfile_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianSpecializationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianSpecializationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MvuserClassificationEntity, (int)Falcon.Data.EntityType.PhysicianSpecializationEntity, 0, null, null, GetRelationsForField("PhysicianSpecializationCollectionViaPhysicianProfile"), null, "PhysicianSpecializationCollectionViaPhysicianProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MvuserClassificationEntity.CustomProperties;}
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
			get { return MvuserClassificationEntity.FieldsCustomProperties;}
		}

		/// <summary> The MvuserClassificationId property of the Entity MvuserClassification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserClassification"."MVUserClassificationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MvuserClassificationId
		{
			get { return (System.Int64)GetValue((int)MvuserClassificationFieldIndex.MvuserClassificationId, true); }
			set	{ SetValue((int)MvuserClassificationFieldIndex.MvuserClassificationId, value); }
		}

		/// <summary> The Name property of the Entity MvuserClassification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserClassification"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)MvuserClassificationFieldIndex.Name, true); }
			set	{ SetValue((int)MvuserClassificationFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity MvuserClassification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserClassification"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)MvuserClassificationFieldIndex.Description, true); }
			set	{ SetValue((int)MvuserClassificationFieldIndex.Description, value); }
		}

		/// <summary> The DateModified property of the Entity MvuserClassification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserClassification"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MvuserClassificationFieldIndex.DateModified, true); }
			set	{ SetValue((int)MvuserClassificationFieldIndex.DateModified, value); }
		}

		/// <summary> The DateCreated property of the Entity MvuserClassification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserClassification"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MvuserClassificationFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MvuserClassificationFieldIndex.DateCreated, value); }
		}

		/// <summary> The IsActive property of the Entity MvuserClassification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVUserClassification"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)MvuserClassificationFieldIndex.IsActive, true); }
			set	{ SetValue((int)MvuserClassificationFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianProfileEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianProfileEntity))]
		public virtual EntityCollection<PhysicianProfileEntity> PhysicianProfile
		{
			get
			{
				if(_physicianProfile==null)
				{
					_physicianProfile = new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory)));
					_physicianProfile.SetContainingEntityInfo(this, "MvuserClassification");
				}
				return _physicianProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaPhysicianProfile_
		{
			get
			{
				if(_fileCollectionViaPhysicianProfile_==null)
				{
					_fileCollectionViaPhysicianProfile_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaPhysicianProfile_.IsReadOnly=true;
				}
				return _fileCollectionViaPhysicianProfile_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaPhysicianProfile
		{
			get
			{
				if(_fileCollectionViaPhysicianProfile==null)
				{
					_fileCollectionViaPhysicianProfile = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaPhysicianProfile.IsReadOnly=true;
				}
				return _fileCollectionViaPhysicianProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianSpecializationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianSpecializationEntity))]
		public virtual EntityCollection<PhysicianSpecializationEntity> PhysicianSpecializationCollectionViaPhysicianProfile
		{
			get
			{
				if(_physicianSpecializationCollectionViaPhysicianProfile==null)
				{
					_physicianSpecializationCollectionViaPhysicianProfile = new EntityCollection<PhysicianSpecializationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianSpecializationEntityFactory)));
					_physicianSpecializationCollectionViaPhysicianProfile.IsReadOnly=true;
				}
				return _physicianSpecializationCollectionViaPhysicianProfile;
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
			get { return (int)Falcon.Data.EntityType.MvuserClassificationEntity; }
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
