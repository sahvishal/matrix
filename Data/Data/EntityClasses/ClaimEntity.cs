///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:48
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
	/// Entity class which represents the entity 'Claim'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ClaimEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private EncounterEntity _encounter;
		private InsurancePaymentEntity _insurancePayment;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Encounter</summary>
			public static readonly string Encounter = "Encounter";
			/// <summary>Member name InsurancePayment</summary>
			public static readonly string InsurancePayment = "InsurancePayment";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ClaimEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ClaimEntity():base("ClaimEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ClaimEntity(IEntityFields2 fields):base("ClaimEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ClaimEntity</param>
		public ClaimEntity(IValidator validator):base("ClaimEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="claimId">PK value for Claim which data should be fetched into this Claim object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ClaimEntity(System.Int64 claimId):base("ClaimEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ClaimId = claimId;
		}

		/// <summary> CTor</summary>
		/// <param name="claimId">PK value for Claim which data should be fetched into this Claim object</param>
		/// <param name="validator">The custom validator object for this ClaimEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ClaimEntity(System.Int64 claimId, IValidator validator):base("ClaimEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ClaimId = claimId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ClaimEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_encounter = (EncounterEntity)info.GetValue("_encounter", typeof(EncounterEntity));
				if(_encounter!=null)
				{
					_encounter.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_insurancePayment = (InsurancePaymentEntity)info.GetValue("_insurancePayment", typeof(InsurancePaymentEntity));
				if(_insurancePayment!=null)
				{
					_insurancePayment.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ClaimFieldIndex)fieldIndex)
			{
				case ClaimFieldIndex.EncounterId:
					DesetupSyncEncounter(true, false);
					break;
				case ClaimFieldIndex.InsurancePaymentId:
					DesetupSyncInsurancePayment(true, false);
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
				case "Encounter":
					this.Encounter = (EncounterEntity)entity;
					break;
				case "InsurancePayment":
					this.InsurancePayment = (InsurancePaymentEntity)entity;
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
			return ClaimEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Encounter":
					toReturn.Add(ClaimEntity.Relations.EncounterEntityUsingEncounterId);
					break;
				case "InsurancePayment":
					toReturn.Add(ClaimEntity.Relations.InsurancePaymentEntityUsingInsurancePaymentId);
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
				case "Encounter":
					SetupSyncEncounter(relatedEntity);
					break;
				case "InsurancePayment":
					SetupSyncInsurancePayment(relatedEntity);
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
				case "Encounter":
					DesetupSyncEncounter(false, true);
					break;
				case "InsurancePayment":
					DesetupSyncInsurancePayment(false, true);
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
			if(_encounter!=null)
			{
				toReturn.Add(_encounter);
			}
			if(_insurancePayment!=null)
			{
				toReturn.Add(_insurancePayment);
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


				info.AddValue("_encounter", (!this.MarkedForDeletion?_encounter:null));
				info.AddValue("_insurancePayment", (!this.MarkedForDeletion?_insurancePayment:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ClaimFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ClaimFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ClaimRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Encounter' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEncounter()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EncounterFields.EncounterId, null, ComparisonOperator.Equal, this.EncounterId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'InsurancePayment' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInsurancePayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InsurancePaymentFields.InsurancePaymentId, null, ComparisonOperator.Equal, this.InsurancePaymentId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ClaimEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ClaimEntityFactory));
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
			toReturn.Add("Encounter", _encounter);
			toReturn.Add("InsurancePayment", _insurancePayment);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_encounter!=null)
			{
				_encounter.ActiveContext = base.ActiveContext;
			}
			if(_insurancePayment!=null)
			{
				_insurancePayment.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_encounter = null;
			_insurancePayment = null;

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

			_fieldsCustomProperties.Add("ClaimId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EncounterId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InsurancePaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingPatientId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProcedureCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProcedureName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Units", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnitCharge", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TotalCharges", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdjustedCharges", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Receipts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PatientBalance", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InsuranceBalance", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TotalBalance", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstBillDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastBillDate", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _encounter</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEncounter(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _encounter, new PropertyChangedEventHandler( OnEncounterPropertyChanged ), "Encounter", ClaimEntity.Relations.EncounterEntityUsingEncounterId, true, signalRelatedEntity, "Claim", resetFKFields, new int[] { (int)ClaimFieldIndex.EncounterId } );		
			_encounter = null;
		}

		/// <summary> setups the sync logic for member _encounter</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEncounter(IEntity2 relatedEntity)
		{
			if(_encounter!=relatedEntity)
			{
				DesetupSyncEncounter(true, true);
				_encounter = (EncounterEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _encounter, new PropertyChangedEventHandler( OnEncounterPropertyChanged ), "Encounter", ClaimEntity.Relations.EncounterEntityUsingEncounterId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEncounterPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _insurancePayment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInsurancePayment(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _insurancePayment, new PropertyChangedEventHandler( OnInsurancePaymentPropertyChanged ), "InsurancePayment", ClaimEntity.Relations.InsurancePaymentEntityUsingInsurancePaymentId, true, signalRelatedEntity, "Claim", resetFKFields, new int[] { (int)ClaimFieldIndex.InsurancePaymentId } );		
			_insurancePayment = null;
		}

		/// <summary> setups the sync logic for member _insurancePayment</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInsurancePayment(IEntity2 relatedEntity)
		{
			if(_insurancePayment!=relatedEntity)
			{
				DesetupSyncInsurancePayment(true, true);
				_insurancePayment = (InsurancePaymentEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _insurancePayment, new PropertyChangedEventHandler( OnInsurancePaymentPropertyChanged ), "InsurancePayment", ClaimEntity.Relations.InsurancePaymentEntityUsingInsurancePaymentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInsurancePaymentPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ClaimEntity</param>
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
		public  static ClaimRelations Relations
		{
			get	{ return new ClaimRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Encounter' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEncounter
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory))),
					(IEntityRelation)GetRelationsForField("Encounter")[0], (int)Falcon.Data.EntityType.ClaimEntity, (int)Falcon.Data.EntityType.EncounterEntity, 0, null, null, null, null, "Encounter", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InsurancePayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInsurancePayment
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InsurancePaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("InsurancePayment")[0], (int)Falcon.Data.EntityType.ClaimEntity, (int)Falcon.Data.EntityType.InsurancePaymentEntity, 0, null, null, null, null, "InsurancePayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ClaimEntity.CustomProperties;}
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
			get { return ClaimEntity.FieldsCustomProperties;}
		}

		/// <summary> The ClaimId property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."ClaimId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 ClaimId
		{
			get { return (System.Int64)GetValue((int)ClaimFieldIndex.ClaimId, true); }
			set	{ SetValue((int)ClaimFieldIndex.ClaimId, value); }
		}

		/// <summary> The EncounterId property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."EncounterId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EncounterId
		{
			get { return (System.Int64)GetValue((int)ClaimFieldIndex.EncounterId, true); }
			set	{ SetValue((int)ClaimFieldIndex.EncounterId, value); }
		}

		/// <summary> The InsurancePaymentId property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."InsurancePaymentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 InsurancePaymentId
		{
			get { return (System.Int64)GetValue((int)ClaimFieldIndex.InsurancePaymentId, true); }
			set	{ SetValue((int)ClaimFieldIndex.InsurancePaymentId, value); }
		}

		/// <summary> The BillingPatientId property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."BillingPatientId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BillingPatientId
		{
			get { return (System.Int64)GetValue((int)ClaimFieldIndex.BillingPatientId, true); }
			set	{ SetValue((int)ClaimFieldIndex.BillingPatientId, value); }
		}

		/// <summary> The ProcedureCode property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."ProcedureCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ProcedureCode
		{
			get { return (System.String)GetValue((int)ClaimFieldIndex.ProcedureCode, true); }
			set	{ SetValue((int)ClaimFieldIndex.ProcedureCode, value); }
		}

		/// <summary> The ProcedureName property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."ProcedureName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ProcedureName
		{
			get { return (System.String)GetValue((int)ClaimFieldIndex.ProcedureName, true); }
			set	{ SetValue((int)ClaimFieldIndex.ProcedureName, value); }
		}

		/// <summary> The Units property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."Units"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Units
		{
			get { return (System.Int32)GetValue((int)ClaimFieldIndex.Units, true); }
			set	{ SetValue((int)ClaimFieldIndex.Units, value); }
		}

		/// <summary> The UnitCharge property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."UnitCharge"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal UnitCharge
		{
			get { return (System.Decimal)GetValue((int)ClaimFieldIndex.UnitCharge, true); }
			set	{ SetValue((int)ClaimFieldIndex.UnitCharge, value); }
		}

		/// <summary> The TotalCharges property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."TotalCharges"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal TotalCharges
		{
			get { return (System.Decimal)GetValue((int)ClaimFieldIndex.TotalCharges, true); }
			set	{ SetValue((int)ClaimFieldIndex.TotalCharges, value); }
		}

		/// <summary> The AdjustedCharges property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."AdjustedCharges"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal AdjustedCharges
		{
			get { return (System.Decimal)GetValue((int)ClaimFieldIndex.AdjustedCharges, true); }
			set	{ SetValue((int)ClaimFieldIndex.AdjustedCharges, value); }
		}

		/// <summary> The Receipts property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."Receipts"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Receipts
		{
			get { return (System.Decimal)GetValue((int)ClaimFieldIndex.Receipts, true); }
			set	{ SetValue((int)ClaimFieldIndex.Receipts, value); }
		}

		/// <summary> The PatientBalance property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."PatientBalance"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal PatientBalance
		{
			get { return (System.Decimal)GetValue((int)ClaimFieldIndex.PatientBalance, true); }
			set	{ SetValue((int)ClaimFieldIndex.PatientBalance, value); }
		}

		/// <summary> The InsuranceBalance property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."InsuranceBalance"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal InsuranceBalance
		{
			get { return (System.Decimal)GetValue((int)ClaimFieldIndex.InsuranceBalance, true); }
			set	{ SetValue((int)ClaimFieldIndex.InsuranceBalance, value); }
		}

		/// <summary> The TotalBalance property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."TotalBalance"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal TotalBalance
		{
			get { return (System.Decimal)GetValue((int)ClaimFieldIndex.TotalBalance, true); }
			set	{ SetValue((int)ClaimFieldIndex.TotalBalance, value); }
		}

		/// <summary> The Status property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Status
		{
			get { return (System.String)GetValue((int)ClaimFieldIndex.Status, true); }
			set	{ SetValue((int)ClaimFieldIndex.Status, value); }
		}

		/// <summary> The DateCreated property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ClaimFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ClaimFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ClaimFieldIndex.DateModified, false); }
			set	{ SetValue((int)ClaimFieldIndex.DateModified, value); }
		}

		/// <summary> The FirstBillDate property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."FirstBillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> FirstBillDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ClaimFieldIndex.FirstBillDate, false); }
			set	{ SetValue((int)ClaimFieldIndex.FirstBillDate, value); }
		}

		/// <summary> The LastBillDate property of the Entity Claim<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblClaim"."LastBillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastBillDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ClaimFieldIndex.LastBillDate, false); }
			set	{ SetValue((int)ClaimFieldIndex.LastBillDate, value); }
		}



		/// <summary> Gets / sets related entity of type 'EncounterEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EncounterEntity Encounter
		{
			get
			{
				return _encounter;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEncounter(value);
				}
				else
				{
					if(value==null)
					{
						if(_encounter != null)
						{
							_encounter.UnsetRelatedEntity(this, "Claim");
						}
					}
					else
					{
						if(_encounter!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Claim");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'InsurancePaymentEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual InsurancePaymentEntity InsurancePayment
		{
			get
			{
				return _insurancePayment;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncInsurancePayment(value);
				}
				else
				{
					if(value==null)
					{
						if(_insurancePayment != null)
						{
							_insurancePayment.UnsetRelatedEntity(this, "Claim");
						}
					}
					else
					{
						if(_insurancePayment!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Claim");
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
			get { return (int)Falcon.Data.EntityType.ClaimEntity; }
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
