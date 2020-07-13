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
	/// Entity class which represents the entity 'HealthQuestionDependencyRule'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class HealthQuestionDependencyRuleEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CustomerHealthQuestionsEntity _customerHealthQuestions_;
		private CustomerHealthQuestionsEntity _customerHealthQuestions;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerHealthQuestions_</summary>
			public static readonly string CustomerHealthQuestions_ = "CustomerHealthQuestions_";
			/// <summary>Member name CustomerHealthQuestions</summary>
			public static readonly string CustomerHealthQuestions = "CustomerHealthQuestions";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static HealthQuestionDependencyRuleEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public HealthQuestionDependencyRuleEntity():base("HealthQuestionDependencyRuleEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public HealthQuestionDependencyRuleEntity(IEntityFields2 fields):base("HealthQuestionDependencyRuleEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this HealthQuestionDependencyRuleEntity</param>
		public HealthQuestionDependencyRuleEntity(IValidator validator):base("HealthQuestionDependencyRuleEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="questionId">PK value for HealthQuestionDependencyRule which data should be fetched into this HealthQuestionDependencyRule object</param>
		/// <param name="dependantQuestionId">PK value for HealthQuestionDependencyRule which data should be fetched into this HealthQuestionDependencyRule object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HealthQuestionDependencyRuleEntity(System.Int64 questionId, System.Int64 dependantQuestionId):base("HealthQuestionDependencyRuleEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.QuestionId = questionId;
			this.DependantQuestionId = dependantQuestionId;
		}

		/// <summary> CTor</summary>
		/// <param name="questionId">PK value for HealthQuestionDependencyRule which data should be fetched into this HealthQuestionDependencyRule object</param>
		/// <param name="dependantQuestionId">PK value for HealthQuestionDependencyRule which data should be fetched into this HealthQuestionDependencyRule object</param>
		/// <param name="validator">The custom validator object for this HealthQuestionDependencyRuleEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HealthQuestionDependencyRuleEntity(System.Int64 questionId, System.Int64 dependantQuestionId, IValidator validator):base("HealthQuestionDependencyRuleEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.QuestionId = questionId;
			this.DependantQuestionId = dependantQuestionId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected HealthQuestionDependencyRuleEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_customerHealthQuestions_ = (CustomerHealthQuestionsEntity)info.GetValue("_customerHealthQuestions_", typeof(CustomerHealthQuestionsEntity));
				if(_customerHealthQuestions_!=null)
				{
					_customerHealthQuestions_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerHealthQuestions = (CustomerHealthQuestionsEntity)info.GetValue("_customerHealthQuestions", typeof(CustomerHealthQuestionsEntity));
				if(_customerHealthQuestions!=null)
				{
					_customerHealthQuestions.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((HealthQuestionDependencyRuleFieldIndex)fieldIndex)
			{
				case HealthQuestionDependencyRuleFieldIndex.QuestionId:
					DesetupSyncCustomerHealthQuestions_(true, false);
					break;
				case HealthQuestionDependencyRuleFieldIndex.DependantQuestionId:
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
				case "CustomerHealthQuestions_":
					this.CustomerHealthQuestions_ = (CustomerHealthQuestionsEntity)entity;
					break;
				case "CustomerHealthQuestions":
					this.CustomerHealthQuestions = (CustomerHealthQuestionsEntity)entity;
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
			return HealthQuestionDependencyRuleEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerHealthQuestions_":
					toReturn.Add(HealthQuestionDependencyRuleEntity.Relations.CustomerHealthQuestionsEntityUsingQuestionId);
					break;
				case "CustomerHealthQuestions":
					toReturn.Add(HealthQuestionDependencyRuleEntity.Relations.CustomerHealthQuestionsEntityUsingDependantQuestionId);
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
				case "CustomerHealthQuestions_":
					SetupSyncCustomerHealthQuestions_(relatedEntity);
					break;
				case "CustomerHealthQuestions":
					SetupSyncCustomerHealthQuestions(relatedEntity);
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
				case "CustomerHealthQuestions_":
					DesetupSyncCustomerHealthQuestions_(false, true);
					break;
				case "CustomerHealthQuestions":
					DesetupSyncCustomerHealthQuestions(false, true);
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
			if(_customerHealthQuestions_!=null)
			{
				toReturn.Add(_customerHealthQuestions_);
			}
			if(_customerHealthQuestions!=null)
			{
				toReturn.Add(_customerHealthQuestions);
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


				info.AddValue("_customerHealthQuestions_", (!this.MarkedForDeletion?_customerHealthQuestions_:null));
				info.AddValue("_customerHealthQuestions", (!this.MarkedForDeletion?_customerHealthQuestions:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(HealthQuestionDependencyRuleFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(HealthQuestionDependencyRuleFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new HealthQuestionDependencyRuleRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestions_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestions()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.DependantQuestionId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.HealthQuestionDependencyRuleEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(HealthQuestionDependencyRuleEntityFactory));
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
			toReturn.Add("CustomerHealthQuestions_", _customerHealthQuestions_);
			toReturn.Add("CustomerHealthQuestions", _customerHealthQuestions);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_customerHealthQuestions_!=null)
			{
				_customerHealthQuestions_.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestions!=null)
			{
				_customerHealthQuestions.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_customerHealthQuestions_ = null;
			_customerHealthQuestions = null;

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

			_fieldsCustomProperties.Add("QuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DependantQuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DependencyRule", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerHealthQuestions_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerHealthQuestions_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerHealthQuestions_, new PropertyChangedEventHandler( OnCustomerHealthQuestions_PropertyChanged ), "CustomerHealthQuestions_", HealthQuestionDependencyRuleEntity.Relations.CustomerHealthQuestionsEntityUsingQuestionId, true, signalRelatedEntity, "HealthQuestionDependencyRule_", resetFKFields, new int[] { (int)HealthQuestionDependencyRuleFieldIndex.QuestionId } );		
			_customerHealthQuestions_ = null;
		}

		/// <summary> setups the sync logic for member _customerHealthQuestions_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerHealthQuestions_(IEntity2 relatedEntity)
		{
			if(_customerHealthQuestions_!=relatedEntity)
			{
				DesetupSyncCustomerHealthQuestions_(true, true);
				_customerHealthQuestions_ = (CustomerHealthQuestionsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerHealthQuestions_, new PropertyChangedEventHandler( OnCustomerHealthQuestions_PropertyChanged ), "CustomerHealthQuestions_", HealthQuestionDependencyRuleEntity.Relations.CustomerHealthQuestionsEntityUsingQuestionId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerHealthQuestions_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerHealthQuestions</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerHealthQuestions(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerHealthQuestions, new PropertyChangedEventHandler( OnCustomerHealthQuestionsPropertyChanged ), "CustomerHealthQuestions", HealthQuestionDependencyRuleEntity.Relations.CustomerHealthQuestionsEntityUsingDependantQuestionId, true, signalRelatedEntity, "HealthQuestionDependencyRule", resetFKFields, new int[] { (int)HealthQuestionDependencyRuleFieldIndex.DependantQuestionId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerHealthQuestions, new PropertyChangedEventHandler( OnCustomerHealthQuestionsPropertyChanged ), "CustomerHealthQuestions", HealthQuestionDependencyRuleEntity.Relations.CustomerHealthQuestionsEntityUsingDependantQuestionId, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this HealthQuestionDependencyRuleEntity</param>
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
		public  static HealthQuestionDependencyRuleRelations Relations
		{
			get	{ return new HealthQuestionDependencyRuleRelations(); }
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
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestions_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerHealthQuestions_")[0], (int)Falcon.Data.EntityType.HealthQuestionDependencyRuleEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, null, null, "CustomerHealthQuestions_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestions
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerHealthQuestions")[0], (int)Falcon.Data.EntityType.HealthQuestionDependencyRuleEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, null, null, "CustomerHealthQuestions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return HealthQuestionDependencyRuleEntity.CustomProperties;}
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
			get { return HealthQuestionDependencyRuleEntity.FieldsCustomProperties;}
		}

		/// <summary> The QuestionId property of the Entity HealthQuestionDependencyRule<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthQuestionDependencyRule"."QuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 QuestionId
		{
			get { return (System.Int64)GetValue((int)HealthQuestionDependencyRuleFieldIndex.QuestionId, true); }
			set	{ SetValue((int)HealthQuestionDependencyRuleFieldIndex.QuestionId, value); }
		}

		/// <summary> The DependantQuestionId property of the Entity HealthQuestionDependencyRule<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthQuestionDependencyRule"."DependantQuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 DependantQuestionId
		{
			get { return (System.Int64)GetValue((int)HealthQuestionDependencyRuleFieldIndex.DependantQuestionId, true); }
			set	{ SetValue((int)HealthQuestionDependencyRuleFieldIndex.DependantQuestionId, value); }
		}

		/// <summary> The DependencyRule property of the Entity HealthQuestionDependencyRule<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthQuestionDependencyRule"."DependencyRule"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String DependencyRule
		{
			get { return (System.String)GetValue((int)HealthQuestionDependencyRuleFieldIndex.DependencyRule, true); }
			set	{ SetValue((int)HealthQuestionDependencyRuleFieldIndex.DependencyRule, value); }
		}



		/// <summary> Gets / sets related entity of type 'CustomerHealthQuestionsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerHealthQuestionsEntity CustomerHealthQuestions_
		{
			get
			{
				return _customerHealthQuestions_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerHealthQuestions_(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerHealthQuestions_ != null)
						{
							_customerHealthQuestions_.UnsetRelatedEntity(this, "HealthQuestionDependencyRule_");
						}
					}
					else
					{
						if(_customerHealthQuestions_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HealthQuestionDependencyRule_");
						}
					}
				}
			}
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
							_customerHealthQuestions.UnsetRelatedEntity(this, "HealthQuestionDependencyRule");
						}
					}
					else
					{
						if(_customerHealthQuestions!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HealthQuestionDependencyRule");
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
			get { return (int)Falcon.Data.EntityType.HealthQuestionDependencyRuleEntity; }
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
