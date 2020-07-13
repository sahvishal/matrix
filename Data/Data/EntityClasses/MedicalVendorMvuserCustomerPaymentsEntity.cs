///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:31 AM
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
	/// Entity class which represents the entity 'MedicalVendorMvuserCustomerPayments'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MedicalVendorMvuserCustomerPaymentsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CustomerEventTestsEntity _customerEventTests;
		private MedicalVendorMvuserEntity _medicalVendorMvuser;
		private MedicalVendorPaymentsEntity _medicalVendorPayments;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerEventTests</summary>
			public static readonly string CustomerEventTests = "CustomerEventTests";
			/// <summary>Member name MedicalVendorMvuser</summary>
			public static readonly string MedicalVendorMvuser = "MedicalVendorMvuser";
			/// <summary>Member name MedicalVendorPayments</summary>
			public static readonly string MedicalVendorPayments = "MedicalVendorPayments";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MedicalVendorMvuserCustomerPaymentsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MedicalVendorMvuserCustomerPaymentsEntity():base("MedicalVendorMvuserCustomerPaymentsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MedicalVendorMvuserCustomerPaymentsEntity(IEntityFields2 fields):base("MedicalVendorMvuserCustomerPaymentsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MedicalVendorMvuserCustomerPaymentsEntity</param>
		public MedicalVendorMvuserCustomerPaymentsEntity(IValidator validator):base("MedicalVendorMvuserCustomerPaymentsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="medicalVendorMvuserPaymentCustomerId">PK value for MedicalVendorMvuserCustomerPayments which data should be fetched into this MedicalVendorMvuserCustomerPayments object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorMvuserCustomerPaymentsEntity(System.Int64 medicalVendorMvuserPaymentCustomerId):base("MedicalVendorMvuserCustomerPaymentsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MedicalVendorMvuserPaymentCustomerId = medicalVendorMvuserPaymentCustomerId;
		}

		/// <summary> CTor</summary>
		/// <param name="medicalVendorMvuserPaymentCustomerId">PK value for MedicalVendorMvuserCustomerPayments which data should be fetched into this MedicalVendorMvuserCustomerPayments object</param>
		/// <param name="validator">The custom validator object for this MedicalVendorMvuserCustomerPaymentsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorMvuserCustomerPaymentsEntity(System.Int64 medicalVendorMvuserPaymentCustomerId, IValidator validator):base("MedicalVendorMvuserCustomerPaymentsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MedicalVendorMvuserPaymentCustomerId = medicalVendorMvuserPaymentCustomerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MedicalVendorMvuserCustomerPaymentsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_customerEventTests = (CustomerEventTestsEntity)info.GetValue("_customerEventTests", typeof(CustomerEventTestsEntity));
				if(_customerEventTests!=null)
				{
					_customerEventTests.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_medicalVendorMvuser = (MedicalVendorMvuserEntity)info.GetValue("_medicalVendorMvuser", typeof(MedicalVendorMvuserEntity));
				if(_medicalVendorMvuser!=null)
				{
					_medicalVendorMvuser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_medicalVendorPayments = (MedicalVendorPaymentsEntity)info.GetValue("_medicalVendorPayments", typeof(MedicalVendorPaymentsEntity));
				if(_medicalVendorPayments!=null)
				{
					_medicalVendorPayments.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MedicalVendorMvuserCustomerPaymentsFieldIndex)fieldIndex)
			{
				case MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorMvuserId:
					DesetupSyncMedicalVendorMvuser(true, false);
					break;
				case MedicalVendorMvuserCustomerPaymentsFieldIndex.CustomerEventTestId:
					DesetupSyncCustomerEventTests(true, false);
					break;
				case MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorPaymentId:
					DesetupSyncMedicalVendorPayments(true, false);
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
				case "CustomerEventTests":
					this.CustomerEventTests = (CustomerEventTestsEntity)entity;
					break;
				case "MedicalVendorMvuser":
					this.MedicalVendorMvuser = (MedicalVendorMvuserEntity)entity;
					break;
				case "MedicalVendorPayments":
					this.MedicalVendorPayments = (MedicalVendorPaymentsEntity)entity;
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
			return MedicalVendorMvuserCustomerPaymentsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerEventTests":
					toReturn.Add(MedicalVendorMvuserCustomerPaymentsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId);
					break;
				case "MedicalVendorMvuser":
					toReturn.Add(MedicalVendorMvuserCustomerPaymentsEntity.Relations.MedicalVendorMvuserEntityUsingMedicalVendorMvuserId);
					break;
				case "MedicalVendorPayments":
					toReturn.Add(MedicalVendorMvuserCustomerPaymentsEntity.Relations.MedicalVendorPaymentsEntityUsingMedicalVendorPaymentId);
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
				case "CustomerEventTests":
					SetupSyncCustomerEventTests(relatedEntity);
					break;
				case "MedicalVendorMvuser":
					SetupSyncMedicalVendorMvuser(relatedEntity);
					break;
				case "MedicalVendorPayments":
					SetupSyncMedicalVendorPayments(relatedEntity);
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
				case "CustomerEventTests":
					DesetupSyncCustomerEventTests(false, true);
					break;
				case "MedicalVendorMvuser":
					DesetupSyncMedicalVendorMvuser(false, true);
					break;
				case "MedicalVendorPayments":
					DesetupSyncMedicalVendorPayments(false, true);
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
			if(_customerEventTests!=null)
			{
				toReturn.Add(_customerEventTests);
			}
			if(_medicalVendorMvuser!=null)
			{
				toReturn.Add(_medicalVendorMvuser);
			}
			if(_medicalVendorPayments!=null)
			{
				toReturn.Add(_medicalVendorPayments);
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


				info.AddValue("_customerEventTests", (!this.MarkedForDeletion?_customerEventTests:null));
				info.AddValue("_medicalVendorMvuser", (!this.MarkedForDeletion?_medicalVendorMvuser:null));
				info.AddValue("_medicalVendorPayments", (!this.MarkedForDeletion?_medicalVendorPayments:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MedicalVendorMvuserCustomerPaymentsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MedicalVendorMvuserCustomerPaymentsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MedicalVendorMvuserCustomerPaymentsRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerEventTests' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTests()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestsFields.CustomerEventTestId, null, ComparisonOperator.Equal, this.CustomerEventTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MedicalVendorMvuser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorMvuser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorMvuserFields.MedicalVendorMvuserId, null, ComparisonOperator.Equal, this.MedicalVendorMvuserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MedicalVendorPayments' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorPayments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorPaymentsFields.MedicalVendorPaymentId, null, ComparisonOperator.Equal, this.MedicalVendorPaymentId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.MedicalVendorMvuserCustomerPaymentsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserCustomerPaymentsEntityFactory));
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
			toReturn.Add("CustomerEventTests", _customerEventTests);
			toReturn.Add("MedicalVendorMvuser", _medicalVendorMvuser);
			toReturn.Add("MedicalVendorPayments", _medicalVendorPayments);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_customerEventTests!=null)
			{
				_customerEventTests.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorMvuser!=null)
			{
				_medicalVendorMvuser.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorPayments!=null)
			{
				_medicalVendorPayments.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_customerEventTests = null;
			_medicalVendorMvuser = null;
			_medicalVendorPayments = null;

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

			_fieldsCustomProperties.Add("MedicalVendorMvuserPaymentCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorMvuserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorPaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerEventTests</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventTests(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", MedicalVendorMvuserCustomerPaymentsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, signalRelatedEntity, "MedicalVendorMvuserCustomerPayments", resetFKFields, new int[] { (int)MedicalVendorMvuserCustomerPaymentsFieldIndex.CustomerEventTestId } );		
			_customerEventTests = null;
		}

		/// <summary> setups the sync logic for member _customerEventTests</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerEventTests(IEntity2 relatedEntity)
		{
			if(_customerEventTests!=relatedEntity)
			{
				DesetupSyncCustomerEventTests(true, true);
				_customerEventTests = (CustomerEventTestsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", MedicalVendorMvuserCustomerPaymentsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerEventTestsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _medicalVendorMvuser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicalVendorMvuser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicalVendorMvuser, new PropertyChangedEventHandler( OnMedicalVendorMvuserPropertyChanged ), "MedicalVendorMvuser", MedicalVendorMvuserCustomerPaymentsEntity.Relations.MedicalVendorMvuserEntityUsingMedicalVendorMvuserId, true, signalRelatedEntity, "MedicalVendorMvuserCustomerPayments", resetFKFields, new int[] { (int)MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorMvuserId } );		
			_medicalVendorMvuser = null;
		}

		/// <summary> setups the sync logic for member _medicalVendorMvuser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicalVendorMvuser(IEntity2 relatedEntity)
		{
			if(_medicalVendorMvuser!=relatedEntity)
			{
				DesetupSyncMedicalVendorMvuser(true, true);
				_medicalVendorMvuser = (MedicalVendorMvuserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicalVendorMvuser, new PropertyChangedEventHandler( OnMedicalVendorMvuserPropertyChanged ), "MedicalVendorMvuser", MedicalVendorMvuserCustomerPaymentsEntity.Relations.MedicalVendorMvuserEntityUsingMedicalVendorMvuserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicalVendorMvuserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _medicalVendorPayments</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicalVendorPayments(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicalVendorPayments, new PropertyChangedEventHandler( OnMedicalVendorPaymentsPropertyChanged ), "MedicalVendorPayments", MedicalVendorMvuserCustomerPaymentsEntity.Relations.MedicalVendorPaymentsEntityUsingMedicalVendorPaymentId, true, signalRelatedEntity, "MedicalVendorMvuserCustomerPayments", resetFKFields, new int[] { (int)MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorPaymentId } );		
			_medicalVendorPayments = null;
		}

		/// <summary> setups the sync logic for member _medicalVendorPayments</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicalVendorPayments(IEntity2 relatedEntity)
		{
			if(_medicalVendorPayments!=relatedEntity)
			{
				DesetupSyncMedicalVendorPayments(true, true);
				_medicalVendorPayments = (MedicalVendorPaymentsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicalVendorPayments, new PropertyChangedEventHandler( OnMedicalVendorPaymentsPropertyChanged ), "MedicalVendorPayments", MedicalVendorMvuserCustomerPaymentsEntity.Relations.MedicalVendorPaymentsEntityUsingMedicalVendorPaymentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicalVendorPaymentsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MedicalVendorMvuserCustomerPaymentsEntity</param>
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
		public  static MedicalVendorMvuserCustomerPaymentsRelations Relations
		{
			get	{ return new MedicalVendorMvuserCustomerPaymentsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTests
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTests")[0], (int)HealthYes.Data.EntityType.MedicalVendorMvuserCustomerPaymentsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, null, null, "CustomerEventTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorMvuser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorMvuser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorMvuser")[0], (int)HealthYes.Data.EntityType.MedicalVendorMvuserCustomerPaymentsEntity, (int)HealthYes.Data.EntityType.MedicalVendorMvuserEntity, 0, null, null, null, null, "MedicalVendorMvuser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorPayments' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorPayments
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorPaymentsEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorPayments")[0], (int)HealthYes.Data.EntityType.MedicalVendorMvuserCustomerPaymentsEntity, (int)HealthYes.Data.EntityType.MedicalVendorPaymentsEntity, 0, null, null, null, null, "MedicalVendorPayments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MedicalVendorMvuserCustomerPaymentsEntity.CustomProperties;}
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
			get { return MedicalVendorMvuserCustomerPaymentsEntity.FieldsCustomProperties;}
		}

		/// <summary> The MedicalVendorMvuserPaymentCustomerId property of the Entity MedicalVendorMvuserCustomerPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorMVUserCustomerPayments"."MedicalVendorMVUserPaymentCustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MedicalVendorMvuserPaymentCustomerId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorMvuserPaymentCustomerId, true); }
			set	{ SetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorMvuserPaymentCustomerId, value); }
		}

		/// <summary> The MedicalVendorMvuserId property of the Entity MedicalVendorMvuserCustomerPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorMVUserCustomerPayments"."MedicalVendorMVUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MedicalVendorMvuserId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorMvuserId, true); }
			set	{ SetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorMvuserId, value); }
		}

		/// <summary> The CustomerEventTestId property of the Entity MedicalVendorMvuserCustomerPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorMVUserCustomerPayments"."CustomerEventTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventTestId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.CustomerEventTestId, true); }
			set	{ SetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.CustomerEventTestId, value); }
		}

		/// <summary> The PaymentAmount property of the Entity MedicalVendorMvuserCustomerPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorMVUserCustomerPayments"."PaymentAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal PaymentAmount
		{
			get { return (System.Decimal)GetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.PaymentAmount, true); }
			set	{ SetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.PaymentAmount, value); }
		}

		/// <summary> The MedicalVendorPaymentId property of the Entity MedicalVendorMvuserCustomerPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorMVUserCustomerPayments"."MedicalVendorPaymentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MedicalVendorPaymentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorPaymentId, false); }
			set	{ SetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.MedicalVendorPaymentId, value); }
		}

		/// <summary> The DateCreated property of the Entity MedicalVendorMvuserCustomerPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorMVUserCustomerPayments"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MedicalVendorMvuserCustomerPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorMVUserCustomerPayments"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.DateModified, true); }
			set	{ SetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity MedicalVendorMvuserCustomerPayments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorMVUserCustomerPayments"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.IsActive, true); }
			set	{ SetValue((int)MedicalVendorMvuserCustomerPaymentsFieldIndex.IsActive, value); }
		}



		/// <summary> Gets / sets related entity of type 'CustomerEventTestsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerEventTestsEntity CustomerEventTests
		{
			get
			{
				return _customerEventTests;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerEventTests(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerEventTests != null)
						{
							_customerEventTests.UnsetRelatedEntity(this, "MedicalVendorMvuserCustomerPayments");
						}
					}
					else
					{
						if(_customerEventTests!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorMvuserCustomerPayments");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MedicalVendorMvuserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicalVendorMvuserEntity MedicalVendorMvuser
		{
			get
			{
				return _medicalVendorMvuser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicalVendorMvuser(value);
				}
				else
				{
					if(value==null)
					{
						if(_medicalVendorMvuser != null)
						{
							_medicalVendorMvuser.UnsetRelatedEntity(this, "MedicalVendorMvuserCustomerPayments");
						}
					}
					else
					{
						if(_medicalVendorMvuser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorMvuserCustomerPayments");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MedicalVendorPaymentsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicalVendorPaymentsEntity MedicalVendorPayments
		{
			get
			{
				return _medicalVendorPayments;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicalVendorPayments(value);
				}
				else
				{
					if(value==null)
					{
						if(_medicalVendorPayments != null)
						{
							_medicalVendorPayments.UnsetRelatedEntity(this, "MedicalVendorMvuserCustomerPayments");
						}
					}
					else
					{
						if(_medicalVendorPayments!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorMvuserCustomerPayments");
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
			get { return (int)HealthYes.Data.EntityType.MedicalVendorMvuserCustomerPaymentsEntity; }
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
