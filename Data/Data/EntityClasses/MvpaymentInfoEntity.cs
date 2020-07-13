///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:30 AM
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
	/// Entity class which represents the entity 'MvpaymentInfo'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MvpaymentInfoEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private MedicalVendorPaymentAccruedEntity _medicalVendorPaymentAccrued;
		private MvuserEventTestLockEntity _mvuserEventTestLock;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name MedicalVendorPaymentAccrued</summary>
			public static readonly string MedicalVendorPaymentAccrued = "MedicalVendorPaymentAccrued";
			/// <summary>Member name MvuserEventTestLock</summary>
			public static readonly string MvuserEventTestLock = "MvuserEventTestLock";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MvpaymentInfoEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MvpaymentInfoEntity():base("MvpaymentInfoEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MvpaymentInfoEntity(IEntityFields2 fields):base("MvpaymentInfoEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MvpaymentInfoEntity</param>
		public MvpaymentInfoEntity(IValidator validator):base("MvpaymentInfoEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="mvpaymentInfoId">PK value for MvpaymentInfo which data should be fetched into this MvpaymentInfo object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MvpaymentInfoEntity(System.Int64 mvpaymentInfoId):base("MvpaymentInfoEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MvpaymentInfoId = mvpaymentInfoId;
		}

		/// <summary> CTor</summary>
		/// <param name="mvpaymentInfoId">PK value for MvpaymentInfo which data should be fetched into this MvpaymentInfo object</param>
		/// <param name="validator">The custom validator object for this MvpaymentInfoEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MvpaymentInfoEntity(System.Int64 mvpaymentInfoId, IValidator validator):base("MvpaymentInfoEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MvpaymentInfoId = mvpaymentInfoId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MvpaymentInfoEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_medicalVendorPaymentAccrued = (MedicalVendorPaymentAccruedEntity)info.GetValue("_medicalVendorPaymentAccrued", typeof(MedicalVendorPaymentAccruedEntity));
				if(_medicalVendorPaymentAccrued!=null)
				{
					_medicalVendorPaymentAccrued.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_mvuserEventTestLock = (MvuserEventTestLockEntity)info.GetValue("_mvuserEventTestLock", typeof(MvuserEventTestLockEntity));
				if(_mvuserEventTestLock!=null)
				{
					_mvuserEventTestLock.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MvpaymentInfoFieldIndex)fieldIndex)
			{
				case MvpaymentInfoFieldIndex.MvuserEventTestLockId:
					DesetupSyncMvuserEventTestLock(true, false);
					break;
				case MvpaymentInfoFieldIndex.MedicalVendorPayAccrId:
					DesetupSyncMedicalVendorPaymentAccrued(true, false);
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
				case "MedicalVendorPaymentAccrued":
					this.MedicalVendorPaymentAccrued = (MedicalVendorPaymentAccruedEntity)entity;
					break;
				case "MvuserEventTestLock":
					this.MvuserEventTestLock = (MvuserEventTestLockEntity)entity;
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
			return MvpaymentInfoEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "MedicalVendorPaymentAccrued":
					toReturn.Add(MvpaymentInfoEntity.Relations.MedicalVendorPaymentAccruedEntityUsingMedicalVendorPayAccrId);
					break;
				case "MvuserEventTestLock":
					toReturn.Add(MvpaymentInfoEntity.Relations.MvuserEventTestLockEntityUsingMvuserEventTestLockId);
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
				case "MedicalVendorPaymentAccrued":
					SetupSyncMedicalVendorPaymentAccrued(relatedEntity);
					break;
				case "MvuserEventTestLock":
					SetupSyncMvuserEventTestLock(relatedEntity);
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
				case "MedicalVendorPaymentAccrued":
					DesetupSyncMedicalVendorPaymentAccrued(false, true);
					break;
				case "MvuserEventTestLock":
					DesetupSyncMvuserEventTestLock(false, true);
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
			if(_medicalVendorPaymentAccrued!=null)
			{
				toReturn.Add(_medicalVendorPaymentAccrued);
			}
			if(_mvuserEventTestLock!=null)
			{
				toReturn.Add(_mvuserEventTestLock);
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


				info.AddValue("_medicalVendorPaymentAccrued", (!this.MarkedForDeletion?_medicalVendorPaymentAccrued:null));
				info.AddValue("_mvuserEventTestLock", (!this.MarkedForDeletion?_mvuserEventTestLock:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MvpaymentInfoFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MvpaymentInfoFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MvpaymentInfoRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MedicalVendorPaymentAccrued' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorPaymentAccrued()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorPaymentAccruedFields.MedicalVendorPayAccrId, null, ComparisonOperator.Equal, this.MedicalVendorPayAccrId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MvuserEventTestLock' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvuserEventTestLock()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvuserEventTestLockFields.MvuserEventTestLockId, null, ComparisonOperator.Equal, this.MvuserEventTestLockId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.MvpaymentInfoEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MvpaymentInfoEntityFactory));
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
			toReturn.Add("MedicalVendorPaymentAccrued", _medicalVendorPaymentAccrued);
			toReturn.Add("MvuserEventTestLock", _mvuserEventTestLock);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_medicalVendorPaymentAccrued!=null)
			{
				_medicalVendorPaymentAccrued.ActiveContext = base.ActiveContext;
			}
			if(_mvuserEventTestLock!=null)
			{
				_mvuserEventTestLock.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_medicalVendorPaymentAccrued = null;
			_mvuserEventTestLock = null;

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

			_fieldsCustomProperties.Add("MvpaymentInfoId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MvuserEventTestLockId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MvpaymentAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MvmvuserPaymentAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorPayAccrId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProgressStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StatusModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _medicalVendorPaymentAccrued</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicalVendorPaymentAccrued(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicalVendorPaymentAccrued, new PropertyChangedEventHandler( OnMedicalVendorPaymentAccruedPropertyChanged ), "MedicalVendorPaymentAccrued", MvpaymentInfoEntity.Relations.MedicalVendorPaymentAccruedEntityUsingMedicalVendorPayAccrId, true, signalRelatedEntity, "MvpaymentInfo", resetFKFields, new int[] { (int)MvpaymentInfoFieldIndex.MedicalVendorPayAccrId } );		
			_medicalVendorPaymentAccrued = null;
		}

		/// <summary> setups the sync logic for member _medicalVendorPaymentAccrued</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicalVendorPaymentAccrued(IEntity2 relatedEntity)
		{
			if(_medicalVendorPaymentAccrued!=relatedEntity)
			{
				DesetupSyncMedicalVendorPaymentAccrued(true, true);
				_medicalVendorPaymentAccrued = (MedicalVendorPaymentAccruedEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicalVendorPaymentAccrued, new PropertyChangedEventHandler( OnMedicalVendorPaymentAccruedPropertyChanged ), "MedicalVendorPaymentAccrued", MvpaymentInfoEntity.Relations.MedicalVendorPaymentAccruedEntityUsingMedicalVendorPayAccrId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicalVendorPaymentAccruedPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _mvuserEventTestLock</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMvuserEventTestLock(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _mvuserEventTestLock, new PropertyChangedEventHandler( OnMvuserEventTestLockPropertyChanged ), "MvuserEventTestLock", MvpaymentInfoEntity.Relations.MvuserEventTestLockEntityUsingMvuserEventTestLockId, true, signalRelatedEntity, "MvpaymentInfo", resetFKFields, new int[] { (int)MvpaymentInfoFieldIndex.MvuserEventTestLockId } );		
			_mvuserEventTestLock = null;
		}

		/// <summary> setups the sync logic for member _mvuserEventTestLock</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMvuserEventTestLock(IEntity2 relatedEntity)
		{
			if(_mvuserEventTestLock!=relatedEntity)
			{
				DesetupSyncMvuserEventTestLock(true, true);
				_mvuserEventTestLock = (MvuserEventTestLockEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _mvuserEventTestLock, new PropertyChangedEventHandler( OnMvuserEventTestLockPropertyChanged ), "MvuserEventTestLock", MvpaymentInfoEntity.Relations.MvuserEventTestLockEntityUsingMvuserEventTestLockId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMvuserEventTestLockPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MvpaymentInfoEntity</param>
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
		public  static MvpaymentInfoRelations Relations
		{
			get	{ return new MvpaymentInfoRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorPaymentAccrued' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorPaymentAccrued
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorPaymentAccruedEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorPaymentAccrued")[0], (int)HealthYes.Data.EntityType.MvpaymentInfoEntity, (int)HealthYes.Data.EntityType.MedicalVendorPaymentAccruedEntity, 0, null, null, null, null, "MedicalVendorPaymentAccrued", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MvuserEventTestLock' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvuserEventTestLock
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MvuserEventTestLockEntityFactory))),
					(IEntityRelation)GetRelationsForField("MvuserEventTestLock")[0], (int)HealthYes.Data.EntityType.MvpaymentInfoEntity, (int)HealthYes.Data.EntityType.MvuserEventTestLockEntity, 0, null, null, null, null, "MvuserEventTestLock", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MvpaymentInfoEntity.CustomProperties;}
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
			get { return MvpaymentInfoEntity.FieldsCustomProperties;}
		}

		/// <summary> The MvpaymentInfoId property of the Entity MvpaymentInfo<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVPaymentInfo"."MVPaymentInfoID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MvpaymentInfoId
		{
			get { return (System.Int64)GetValue((int)MvpaymentInfoFieldIndex.MvpaymentInfoId, true); }
			set	{ SetValue((int)MvpaymentInfoFieldIndex.MvpaymentInfoId, value); }
		}

		/// <summary> The MvuserEventTestLockId property of the Entity MvpaymentInfo<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVPaymentInfo"."MVUserEventTestLockID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MvuserEventTestLockId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MvpaymentInfoFieldIndex.MvuserEventTestLockId, false); }
			set	{ SetValue((int)MvpaymentInfoFieldIndex.MvuserEventTestLockId, value); }
		}

		/// <summary> The MvpaymentAmount property of the Entity MvpaymentInfo<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVPaymentInfo"."MVPaymentAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MvpaymentAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)MvpaymentInfoFieldIndex.MvpaymentAmount, false); }
			set	{ SetValue((int)MvpaymentInfoFieldIndex.MvpaymentAmount, value); }
		}

		/// <summary> The MvmvuserPaymentAmount property of the Entity MvpaymentInfo<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVPaymentInfo"."MVMVUserPaymentAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MvmvuserPaymentAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)MvpaymentInfoFieldIndex.MvmvuserPaymentAmount, false); }
			set	{ SetValue((int)MvpaymentInfoFieldIndex.MvmvuserPaymentAmount, value); }
		}

		/// <summary> The MedicalVendorPayAccrId property of the Entity MvpaymentInfo<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVPaymentInfo"."MedicalVendorPayAccrID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MedicalVendorPayAccrId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MvpaymentInfoFieldIndex.MedicalVendorPayAccrId, false); }
			set	{ SetValue((int)MvpaymentInfoFieldIndex.MedicalVendorPayAccrId, value); }
		}

		/// <summary> The ProgressStatus property of the Entity MvpaymentInfo<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVPaymentInfo"."ProgressStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte ProgressStatus
		{
			get { return (System.Byte)GetValue((int)MvpaymentInfoFieldIndex.ProgressStatus, true); }
			set	{ SetValue((int)MvpaymentInfoFieldIndex.ProgressStatus, value); }
		}

		/// <summary> The StatusModifiedDate property of the Entity MvpaymentInfo<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVPaymentInfo"."StatusModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime StatusModifiedDate
		{
			get { return (System.DateTime)GetValue((int)MvpaymentInfoFieldIndex.StatusModifiedDate, true); }
			set	{ SetValue((int)MvpaymentInfoFieldIndex.StatusModifiedDate, value); }
		}

		/// <summary> The DateCreated property of the Entity MvpaymentInfo<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVPaymentInfo"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MvpaymentInfoFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MvpaymentInfoFieldIndex.DateCreated, value); }
		}



		/// <summary> Gets / sets related entity of type 'MedicalVendorPaymentAccruedEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicalVendorPaymentAccruedEntity MedicalVendorPaymentAccrued
		{
			get
			{
				return _medicalVendorPaymentAccrued;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicalVendorPaymentAccrued(value);
				}
				else
				{
					if(value==null)
					{
						if(_medicalVendorPaymentAccrued != null)
						{
							_medicalVendorPaymentAccrued.UnsetRelatedEntity(this, "MvpaymentInfo");
						}
					}
					else
					{
						if(_medicalVendorPaymentAccrued!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MvpaymentInfo");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MvuserEventTestLockEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MvuserEventTestLockEntity MvuserEventTestLock
		{
			get
			{
				return _mvuserEventTestLock;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMvuserEventTestLock(value);
				}
				else
				{
					if(value==null)
					{
						if(_mvuserEventTestLock != null)
						{
							_mvuserEventTestLock.UnsetRelatedEntity(this, "MvpaymentInfo");
						}
					}
					else
					{
						if(_mvuserEventTestLock!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MvpaymentInfo");
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
			get { return (int)HealthYes.Data.EntityType.MvpaymentInfoEntity; }
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
