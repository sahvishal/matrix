///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:46
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
	/// Entity class which represents the entity 'MedicalHistoryReadingAssosciation'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MedicalHistoryReadingAssosciationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CustomerHealthQuestionsEntity _customerHealthQuestions;
		private ReadingEntity _reading;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerHealthQuestions</summary>
			public static readonly string CustomerHealthQuestions = "CustomerHealthQuestions";
			/// <summary>Member name Reading</summary>
			public static readonly string Reading = "Reading";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MedicalHistoryReadingAssosciationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MedicalHistoryReadingAssosciationEntity():base("MedicalHistoryReadingAssosciationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MedicalHistoryReadingAssosciationEntity(IEntityFields2 fields):base("MedicalHistoryReadingAssosciationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MedicalHistoryReadingAssosciationEntity</param>
		public MedicalHistoryReadingAssosciationEntity(IValidator validator):base("MedicalHistoryReadingAssosciationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="readingId">PK value for MedicalHistoryReadingAssosciation which data should be fetched into this MedicalHistoryReadingAssosciation object</param>
		/// <param name="medicalHistoryQuestionId">PK value for MedicalHistoryReadingAssosciation which data should be fetched into this MedicalHistoryReadingAssosciation object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalHistoryReadingAssosciationEntity(System.Int32 readingId, System.Int64 medicalHistoryQuestionId):base("MedicalHistoryReadingAssosciationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ReadingId = readingId;
			this.MedicalHistoryQuestionId = medicalHistoryQuestionId;
		}

		/// <summary> CTor</summary>
		/// <param name="readingId">PK value for MedicalHistoryReadingAssosciation which data should be fetched into this MedicalHistoryReadingAssosciation object</param>
		/// <param name="medicalHistoryQuestionId">PK value for MedicalHistoryReadingAssosciation which data should be fetched into this MedicalHistoryReadingAssosciation object</param>
		/// <param name="validator">The custom validator object for this MedicalHistoryReadingAssosciationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalHistoryReadingAssosciationEntity(System.Int32 readingId, System.Int64 medicalHistoryQuestionId, IValidator validator):base("MedicalHistoryReadingAssosciationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ReadingId = readingId;
			this.MedicalHistoryQuestionId = medicalHistoryQuestionId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MedicalHistoryReadingAssosciationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_customerHealthQuestions = (CustomerHealthQuestionsEntity)info.GetValue("_customerHealthQuestions", typeof(CustomerHealthQuestionsEntity));
				if(_customerHealthQuestions!=null)
				{
					_customerHealthQuestions.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_reading = (ReadingEntity)info.GetValue("_reading", typeof(ReadingEntity));
				if(_reading!=null)
				{
					_reading.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MedicalHistoryReadingAssosciationFieldIndex)fieldIndex)
			{
				case MedicalHistoryReadingAssosciationFieldIndex.ReadingId:
					DesetupSyncReading(true, false);
					break;
				case MedicalHistoryReadingAssosciationFieldIndex.MedicalHistoryQuestionId:
					DesetupSyncCustomerHealthQuestions(true, false);
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
				case "CustomerHealthQuestions":
					this.CustomerHealthQuestions = (CustomerHealthQuestionsEntity)entity;
					break;
				case "Reading":
					this.Reading = (ReadingEntity)entity;
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
			return MedicalHistoryReadingAssosciationEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerHealthQuestions":
					toReturn.Add(MedicalHistoryReadingAssosciationEntity.Relations.CustomerHealthQuestionsEntityUsingMedicalHistoryQuestionId);
					break;
				case "Reading":
					toReturn.Add(MedicalHistoryReadingAssosciationEntity.Relations.ReadingEntityUsingReadingId);
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
				case "CustomerHealthQuestions":
					SetupSyncCustomerHealthQuestions(relatedEntity);
					break;
				case "Reading":
					SetupSyncReading(relatedEntity);
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
				case "CustomerHealthQuestions":
					DesetupSyncCustomerHealthQuestions(false, true);
					break;
				case "Reading":
					DesetupSyncReading(false, true);
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
			if(_customerHealthQuestions!=null)
			{
				toReturn.Add(_customerHealthQuestions);
			}
			if(_reading!=null)
			{
				toReturn.Add(_reading);
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


				info.AddValue("_customerHealthQuestions", (!this.MarkedForDeletion?_customerHealthQuestions:null));
				info.AddValue("_reading", (!this.MarkedForDeletion?_reading:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MedicalHistoryReadingAssosciationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MedicalHistoryReadingAssosciationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MedicalHistoryReadingAssosciationRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestions()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.MedicalHistoryQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Reading' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReadingFields.ReadingId, null, ComparisonOperator.Equal, this.ReadingId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MedicalHistoryReadingAssosciationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MedicalHistoryReadingAssosciationEntityFactory));
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
			toReturn.Add("CustomerHealthQuestions", _customerHealthQuestions);
			toReturn.Add("Reading", _reading);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_customerHealthQuestions!=null)
			{
				_customerHealthQuestions.ActiveContext = base.ActiveContext;
			}
			if(_reading!=null)
			{
				_reading.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_customerHealthQuestions = null;
			_reading = null;

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

			_fieldsCustomProperties.Add("ReadingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalHistoryQuestionId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerHealthQuestions</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerHealthQuestions(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerHealthQuestions, new PropertyChangedEventHandler( OnCustomerHealthQuestionsPropertyChanged ), "CustomerHealthQuestions", MedicalHistoryReadingAssosciationEntity.Relations.CustomerHealthQuestionsEntityUsingMedicalHistoryQuestionId, true, signalRelatedEntity, "MedicalHistoryReadingAssosciation", resetFKFields, new int[] { (int)MedicalHistoryReadingAssosciationFieldIndex.MedicalHistoryQuestionId } );		
			_customerHealthQuestions = null;
		}

		/// <summary> setups the sync logic for member _customerHealthQuestions</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerHealthQuestions(IEntity2 relatedEntity)
		{
			if(_customerHealthQuestions!=relatedEntity)
			{
				DesetupSyncCustomerHealthQuestions(true, true);
				_customerHealthQuestions = (CustomerHealthQuestionsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerHealthQuestions, new PropertyChangedEventHandler( OnCustomerHealthQuestionsPropertyChanged ), "CustomerHealthQuestions", MedicalHistoryReadingAssosciationEntity.Relations.CustomerHealthQuestionsEntityUsingMedicalHistoryQuestionId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerHealthQuestionsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _reading</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncReading(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _reading, new PropertyChangedEventHandler( OnReadingPropertyChanged ), "Reading", MedicalHistoryReadingAssosciationEntity.Relations.ReadingEntityUsingReadingId, true, signalRelatedEntity, "MedicalHistoryReadingAssosciation", resetFKFields, new int[] { (int)MedicalHistoryReadingAssosciationFieldIndex.ReadingId } );		
			_reading = null;
		}

		/// <summary> setups the sync logic for member _reading</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncReading(IEntity2 relatedEntity)
		{
			if(_reading!=relatedEntity)
			{
				DesetupSyncReading(true, true);
				_reading = (ReadingEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _reading, new PropertyChangedEventHandler( OnReadingPropertyChanged ), "Reading", MedicalHistoryReadingAssosciationEntity.Relations.ReadingEntityUsingReadingId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReadingPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MedicalHistoryReadingAssosciationEntity</param>
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
		public  static MedicalHistoryReadingAssosciationRelations Relations
		{
			get	{ return new MedicalHistoryReadingAssosciationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestions
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerHealthQuestions")[0], (int)Falcon.Data.EntityType.MedicalHistoryReadingAssosciationEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, null, null, "CustomerHealthQuestions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Reading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReading
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("Reading")[0], (int)Falcon.Data.EntityType.MedicalHistoryReadingAssosciationEntity, (int)Falcon.Data.EntityType.ReadingEntity, 0, null, null, null, null, "Reading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MedicalHistoryReadingAssosciationEntity.CustomProperties;}
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
			get { return MedicalHistoryReadingAssosciationEntity.FieldsCustomProperties;}
		}

		/// <summary> The ReadingId property of the Entity MedicalHistoryReadingAssosciation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalHistoryReadingAssosciation"."ReadingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ReadingId
		{
			get { return (System.Int32)GetValue((int)MedicalHistoryReadingAssosciationFieldIndex.ReadingId, true); }
			set	{ SetValue((int)MedicalHistoryReadingAssosciationFieldIndex.ReadingId, value); }
		}

		/// <summary> The MedicalHistoryQuestionId property of the Entity MedicalHistoryReadingAssosciation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalHistoryReadingAssosciation"."MedicalHistoryQuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 MedicalHistoryQuestionId
		{
			get { return (System.Int64)GetValue((int)MedicalHistoryReadingAssosciationFieldIndex.MedicalHistoryQuestionId, true); }
			set	{ SetValue((int)MedicalHistoryReadingAssosciationFieldIndex.MedicalHistoryQuestionId, value); }
		}



		/// <summary> Gets / sets related entity of type 'CustomerHealthQuestionsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerHealthQuestionsEntity CustomerHealthQuestions
		{
			get
			{
				return _customerHealthQuestions;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerHealthQuestions(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerHealthQuestions != null)
						{
							_customerHealthQuestions.UnsetRelatedEntity(this, "MedicalHistoryReadingAssosciation");
						}
					}
					else
					{
						if(_customerHealthQuestions!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalHistoryReadingAssosciation");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReadingEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ReadingEntity Reading
		{
			get
			{
				return _reading;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncReading(value);
				}
				else
				{
					if(value==null)
					{
						if(_reading != null)
						{
							_reading.UnsetRelatedEntity(this, "MedicalHistoryReadingAssosciation");
						}
					}
					else
					{
						if(_reading!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalHistoryReadingAssosciation");
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
			get { return (int)Falcon.Data.EntityType.MedicalHistoryReadingAssosciationEntity; }
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
