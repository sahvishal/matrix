///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:33 AM
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
	/// Entity class which represents the entity 'MedicalVendorPaymentAccrued'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MedicalVendorPaymentAccruedEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MvpaymentInfoEntity> _mvpaymentInfo;
		private EntityCollection<MvuserEventTestLockEntity> _mvuserEventTestLockCollectionViaMvpaymentInfo;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name MvpaymentInfo</summary>
			public static readonly string MvpaymentInfo = "MvpaymentInfo";
			/// <summary>Member name MvuserEventTestLockCollectionViaMvpaymentInfo</summary>
			public static readonly string MvuserEventTestLockCollectionViaMvpaymentInfo = "MvuserEventTestLockCollectionViaMvpaymentInfo";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MedicalVendorPaymentAccruedEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MedicalVendorPaymentAccruedEntity():base("MedicalVendorPaymentAccruedEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MedicalVendorPaymentAccruedEntity(IEntityFields2 fields):base("MedicalVendorPaymentAccruedEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MedicalVendorPaymentAccruedEntity</param>
		public MedicalVendorPaymentAccruedEntity(IValidator validator):base("MedicalVendorPaymentAccruedEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="medicalVendorPayAccrId">PK value for MedicalVendorPaymentAccrued which data should be fetched into this MedicalVendorPaymentAccrued object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorPaymentAccruedEntity(System.Int64 medicalVendorPayAccrId):base("MedicalVendorPaymentAccruedEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MedicalVendorPayAccrId = medicalVendorPayAccrId;
		}

		/// <summary> CTor</summary>
		/// <param name="medicalVendorPayAccrId">PK value for MedicalVendorPaymentAccrued which data should be fetched into this MedicalVendorPaymentAccrued object</param>
		/// <param name="validator">The custom validator object for this MedicalVendorPaymentAccruedEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorPaymentAccruedEntity(System.Int64 medicalVendorPayAccrId, IValidator validator):base("MedicalVendorPaymentAccruedEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MedicalVendorPayAccrId = medicalVendorPayAccrId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MedicalVendorPaymentAccruedEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_mvpaymentInfo = (EntityCollection<MvpaymentInfoEntity>)info.GetValue("_mvpaymentInfo", typeof(EntityCollection<MvpaymentInfoEntity>));
				_mvuserEventTestLockCollectionViaMvpaymentInfo = (EntityCollection<MvuserEventTestLockEntity>)info.GetValue("_mvuserEventTestLockCollectionViaMvpaymentInfo", typeof(EntityCollection<MvuserEventTestLockEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((MedicalVendorPaymentAccruedFieldIndex)fieldIndex)
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

				case "MvpaymentInfo":
					this.MvpaymentInfo.Add((MvpaymentInfoEntity)entity);
					break;
				case "MvuserEventTestLockCollectionViaMvpaymentInfo":
					this.MvuserEventTestLockCollectionViaMvpaymentInfo.IsReadOnly = false;
					this.MvuserEventTestLockCollectionViaMvpaymentInfo.Add((MvuserEventTestLockEntity)entity);
					this.MvuserEventTestLockCollectionViaMvpaymentInfo.IsReadOnly = true;
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
			return MedicalVendorPaymentAccruedEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "MvpaymentInfo":
					toReturn.Add(MedicalVendorPaymentAccruedEntity.Relations.MvpaymentInfoEntityUsingMedicalVendorPayAccrId);
					break;
				case "MvuserEventTestLockCollectionViaMvpaymentInfo":
					toReturn.Add(MedicalVendorPaymentAccruedEntity.Relations.MvpaymentInfoEntityUsingMedicalVendorPayAccrId, "MedicalVendorPaymentAccruedEntity__", "MvpaymentInfo_", JoinHint.None);
					toReturn.Add(MvpaymentInfoEntity.Relations.MvuserEventTestLockEntityUsingMvuserEventTestLockId, "MvpaymentInfo_", string.Empty, JoinHint.None);
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

				case "MvpaymentInfo":
					this.MvpaymentInfo.Add((MvpaymentInfoEntity)relatedEntity);
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

				case "MvpaymentInfo":
					base.PerformRelatedEntityRemoval(this.MvpaymentInfo, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.MvpaymentInfo);

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
				info.AddValue("_mvpaymentInfo", ((_mvpaymentInfo!=null) && (_mvpaymentInfo.Count>0) && !this.MarkedForDeletion)?_mvpaymentInfo:null);
				info.AddValue("_mvuserEventTestLockCollectionViaMvpaymentInfo", ((_mvuserEventTestLockCollectionViaMvpaymentInfo!=null) && (_mvuserEventTestLockCollectionViaMvpaymentInfo.Count>0) && !this.MarkedForDeletion)?_mvuserEventTestLockCollectionViaMvpaymentInfo:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MedicalVendorPaymentAccruedFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MedicalVendorPaymentAccruedFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MedicalVendorPaymentAccruedRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MvpaymentInfo' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvpaymentInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvpaymentInfoFields.MedicalVendorPayAccrId, null, ComparisonOperator.Equal, this.MedicalVendorPayAccrId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MvuserEventTestLock' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvuserEventTestLockCollectionViaMvpaymentInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MvuserEventTestLockCollectionViaMvpaymentInfo"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorPaymentAccruedFields.MedicalVendorPayAccrId, null, ComparisonOperator.Equal, this.MedicalVendorPayAccrId, "MedicalVendorPaymentAccruedEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.MedicalVendorPaymentAccruedEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorPaymentAccruedEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._mvpaymentInfo);
			collectionsQueue.Enqueue(this._mvuserEventTestLockCollectionViaMvpaymentInfo);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._mvpaymentInfo = (EntityCollection<MvpaymentInfoEntity>) collectionsQueue.Dequeue();
			this._mvuserEventTestLockCollectionViaMvpaymentInfo = (EntityCollection<MvuserEventTestLockEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._mvpaymentInfo != null)
			{
				return true;
			}
			if (this._mvuserEventTestLockCollectionViaMvpaymentInfo != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MvpaymentInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MvpaymentInfoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MvuserEventTestLockEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MvuserEventTestLockEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("MvpaymentInfo", _mvpaymentInfo);
			toReturn.Add("MvuserEventTestLockCollectionViaMvpaymentInfo", _mvuserEventTestLockCollectionViaMvpaymentInfo);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_mvpaymentInfo!=null)
			{
				_mvpaymentInfo.ActiveContext = base.ActiveContext;
			}
			if(_mvuserEventTestLockCollectionViaMvpaymentInfo!=null)
			{
				_mvuserEventTestLockCollectionViaMvpaymentInfo.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_mvpaymentInfo = null;
			_mvuserEventTestLockCollectionViaMvpaymentInfo = null;


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

			_fieldsCustomProperties.Add("MedicalVendorPayAccrId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StartPaymentInfoId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EndPaymentInfoId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoiceReference", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorId", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MedicalVendorPaymentAccruedEntity</param>
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
		public  static MedicalVendorPaymentAccruedRelations Relations
		{
			get	{ return new MedicalVendorPaymentAccruedRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MvpaymentInfo' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvpaymentInfo
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MvpaymentInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MvpaymentInfoEntityFactory))),
					(IEntityRelation)GetRelationsForField("MvpaymentInfo")[0], (int)HealthYes.Data.EntityType.MedicalVendorPaymentAccruedEntity, (int)HealthYes.Data.EntityType.MvpaymentInfoEntity, 0, null, null, null, null, "MvpaymentInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MvuserEventTestLock' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvuserEventTestLockCollectionViaMvpaymentInfo
		{
			get
			{
				IEntityRelation intermediateRelation = MedicalVendorPaymentAccruedEntity.Relations.MvpaymentInfoEntityUsingMedicalVendorPayAccrId;
				intermediateRelation.SetAliases(string.Empty, "MvpaymentInfo_");
				return new PrefetchPathElement2(new EntityCollection<MvuserEventTestLockEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MvuserEventTestLockEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MedicalVendorPaymentAccruedEntity, (int)HealthYes.Data.EntityType.MvuserEventTestLockEntity, 0, null, null, GetRelationsForField("MvuserEventTestLockCollectionViaMvpaymentInfo"), null, "MvuserEventTestLockCollectionViaMvpaymentInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MedicalVendorPaymentAccruedEntity.CustomProperties;}
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
			get { return MedicalVendorPaymentAccruedEntity.FieldsCustomProperties;}
		}

		/// <summary> The MedicalVendorPayAccrId property of the Entity MedicalVendorPaymentAccrued<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPaymentAccrued"."MedicalVendorPayAccrID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MedicalVendorPayAccrId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorPaymentAccruedFieldIndex.MedicalVendorPayAccrId, true); }
			set	{ SetValue((int)MedicalVendorPaymentAccruedFieldIndex.MedicalVendorPayAccrId, value); }
		}

		/// <summary> The PaymentAmount property of the Entity MedicalVendorPaymentAccrued<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPaymentAccrued"."PaymentAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal PaymentAmount
		{
			get { return (System.Decimal)GetValue((int)MedicalVendorPaymentAccruedFieldIndex.PaymentAmount, true); }
			set	{ SetValue((int)MedicalVendorPaymentAccruedFieldIndex.PaymentAmount, value); }
		}

		/// <summary> The DateCreated property of the Entity MedicalVendorPaymentAccrued<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPaymentAccrued"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MedicalVendorPaymentAccruedFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MedicalVendorPaymentAccruedFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MedicalVendorPaymentAccrued<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPaymentAccrued"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MedicalVendorPaymentAccruedFieldIndex.DateModified, true); }
			set	{ SetValue((int)MedicalVendorPaymentAccruedFieldIndex.DateModified, value); }
		}

		/// <summary> The StartPaymentInfoId property of the Entity MedicalVendorPaymentAccrued<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPaymentAccrued"."StartPaymentInfoID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 StartPaymentInfoId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorPaymentAccruedFieldIndex.StartPaymentInfoId, true); }
			set	{ SetValue((int)MedicalVendorPaymentAccruedFieldIndex.StartPaymentInfoId, value); }
		}

		/// <summary> The EndPaymentInfoId property of the Entity MedicalVendorPaymentAccrued<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPaymentAccrued"."EndPaymentInfoID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EndPaymentInfoId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorPaymentAccruedFieldIndex.EndPaymentInfoId, true); }
			set	{ SetValue((int)MedicalVendorPaymentAccruedFieldIndex.EndPaymentInfoId, value); }
		}

		/// <summary> The InvoiceReference property of the Entity MedicalVendorPaymentAccrued<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPaymentAccrued"."InvoiceReference"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String InvoiceReference
		{
			get { return (System.String)GetValue((int)MedicalVendorPaymentAccruedFieldIndex.InvoiceReference, true); }
			set	{ SetValue((int)MedicalVendorPaymentAccruedFieldIndex.InvoiceReference, value); }
		}

		/// <summary> The Notes property of the Entity MedicalVendorPaymentAccrued<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPaymentAccrued"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)MedicalVendorPaymentAccruedFieldIndex.Notes, true); }
			set	{ SetValue((int)MedicalVendorPaymentAccruedFieldIndex.Notes, value); }
		}

		/// <summary> The MedicalVendorId property of the Entity MedicalVendorPaymentAccrued<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorPaymentAccrued"."MedicalVendorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MedicalVendorId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorPaymentAccruedFieldIndex.MedicalVendorId, true); }
			set	{ SetValue((int)MedicalVendorPaymentAccruedFieldIndex.MedicalVendorId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MvpaymentInfoEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MvpaymentInfoEntity))]
		public virtual EntityCollection<MvpaymentInfoEntity> MvpaymentInfo
		{
			get
			{
				if(_mvpaymentInfo==null)
				{
					_mvpaymentInfo = new EntityCollection<MvpaymentInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MvpaymentInfoEntityFactory)));
					_mvpaymentInfo.SetContainingEntityInfo(this, "MedicalVendorPaymentAccrued");
				}
				return _mvpaymentInfo;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MvuserEventTestLockEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MvuserEventTestLockEntity))]
		public virtual EntityCollection<MvuserEventTestLockEntity> MvuserEventTestLockCollectionViaMvpaymentInfo
		{
			get
			{
				if(_mvuserEventTestLockCollectionViaMvpaymentInfo==null)
				{
					_mvuserEventTestLockCollectionViaMvpaymentInfo = new EntityCollection<MvuserEventTestLockEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MvuserEventTestLockEntityFactory)));
					_mvuserEventTestLockCollectionViaMvpaymentInfo.IsReadOnly=true;
				}
				return _mvuserEventTestLockCollectionViaMvpaymentInfo;
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
			get { return (int)HealthYes.Data.EntityType.MedicalVendorPaymentAccruedEntity; }
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
