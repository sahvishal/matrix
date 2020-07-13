///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:52
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
	/// Entity class which represents the entity 'FluConsentAnswer'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class FluConsentAnswerEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private EventCustomersEntity _eventCustomers;
		private FluConsentQuestionEntity _fluConsentQuestion;
		private OrganizationRoleUserEntity _organizationRoleUser_;
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
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
			/// <summary>Member name FluConsentQuestion</summary>
			public static readonly string FluConsentQuestion = "FluConsentQuestion";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static FluConsentAnswerEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public FluConsentAnswerEntity():base("FluConsentAnswerEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public FluConsentAnswerEntity(IEntityFields2 fields):base("FluConsentAnswerEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this FluConsentAnswerEntity</param>
		public FluConsentAnswerEntity(IValidator validator):base("FluConsentAnswerEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eventCustomerId">PK value for FluConsentAnswer which data should be fetched into this FluConsentAnswer object</param>
		/// <param name="questionId">PK value for FluConsentAnswer which data should be fetched into this FluConsentAnswer object</param>
		/// <param name="version">PK value for FluConsentAnswer which data should be fetched into this FluConsentAnswer object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FluConsentAnswerEntity(System.Int64 eventCustomerId, System.Int64 questionId, System.Int32 version):base("FluConsentAnswerEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EventCustomerId = eventCustomerId;
			this.QuestionId = questionId;
			this.Version = version;
		}

		/// <summary> CTor</summary>
		/// <param name="eventCustomerId">PK value for FluConsentAnswer which data should be fetched into this FluConsentAnswer object</param>
		/// <param name="questionId">PK value for FluConsentAnswer which data should be fetched into this FluConsentAnswer object</param>
		/// <param name="version">PK value for FluConsentAnswer which data should be fetched into this FluConsentAnswer object</param>
		/// <param name="validator">The custom validator object for this FluConsentAnswerEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FluConsentAnswerEntity(System.Int64 eventCustomerId, System.Int64 questionId, System.Int32 version, IValidator validator):base("FluConsentAnswerEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EventCustomerId = eventCustomerId;
			this.QuestionId = questionId;
			this.Version = version;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected FluConsentAnswerEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_eventCustomers = (EventCustomersEntity)info.GetValue("_eventCustomers", typeof(EventCustomersEntity));
				if(_eventCustomers!=null)
				{
					_eventCustomers.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_fluConsentQuestion = (FluConsentQuestionEntity)info.GetValue("_fluConsentQuestion", typeof(FluConsentQuestionEntity));
				if(_fluConsentQuestion!=null)
				{
					_fluConsentQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((FluConsentAnswerFieldIndex)fieldIndex)
			{
				case FluConsentAnswerFieldIndex.EventCustomerId:
					DesetupSyncEventCustomers(true, false);
					break;
				case FluConsentAnswerFieldIndex.QuestionId:
					DesetupSyncFluConsentQuestion(true, false);
					break;
				case FluConsentAnswerFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case FluConsentAnswerFieldIndex.ModifiedBy:
					DesetupSyncOrganizationRoleUser_(true, false);
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
				case "EventCustomers":
					this.EventCustomers = (EventCustomersEntity)entity;
					break;
				case "FluConsentQuestion":
					this.FluConsentQuestion = (FluConsentQuestionEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
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
			return FluConsentAnswerEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "EventCustomers":
					toReturn.Add(FluConsentAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId);
					break;
				case "FluConsentQuestion":
					toReturn.Add(FluConsentAnswerEntity.Relations.FluConsentQuestionEntityUsingQuestionId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
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
				case "EventCustomers":
					SetupSyncEventCustomers(relatedEntity);
					break;
				case "FluConsentQuestion":
					SetupSyncFluConsentQuestion(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
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
				case "EventCustomers":
					DesetupSyncEventCustomers(false, true);
					break;
				case "FluConsentQuestion":
					DesetupSyncFluConsentQuestion(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
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
			if(_eventCustomers!=null)
			{
				toReturn.Add(_eventCustomers);
			}
			if(_fluConsentQuestion!=null)
			{
				toReturn.Add(_fluConsentQuestion);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
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


				info.AddValue("_eventCustomers", (!this.MarkedForDeletion?_eventCustomers:null));
				info.AddValue("_fluConsentQuestion", (!this.MarkedForDeletion?_fluConsentQuestion:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
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
		public bool TestOriginalFieldValueForNull(FluConsentAnswerFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(FluConsentAnswerFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new FluConsentAnswerRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'FluConsentQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentQuestionFields.Id, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.FluConsentAnswerEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(FluConsentAnswerEntityFactory));
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
			toReturn.Add("EventCustomers", _eventCustomers);
			toReturn.Add("FluConsentQuestion", _fluConsentQuestion);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_eventCustomers!=null)
			{
				_eventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentQuestion!=null)
			{
				_fluConsentQuestion.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_eventCustomers = null;
			_fluConsentQuestion = null;
			_organizationRoleUser_ = null;
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

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("QuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Answer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Version", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _eventCustomers</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomers(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", FluConsentAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, signalRelatedEntity, "FluConsentAnswer", resetFKFields, new int[] { (int)FluConsentAnswerFieldIndex.EventCustomerId } );		
			_eventCustomers = null;
		}

		/// <summary> setups the sync logic for member _eventCustomers</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomers(IEntity2 relatedEntity)
		{
			if(_eventCustomers!=relatedEntity)
			{
				DesetupSyncEventCustomers(true, true);
				_eventCustomers = (EventCustomersEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", FluConsentAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomersPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _fluConsentQuestion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFluConsentQuestion(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _fluConsentQuestion, new PropertyChangedEventHandler( OnFluConsentQuestionPropertyChanged ), "FluConsentQuestion", FluConsentAnswerEntity.Relations.FluConsentQuestionEntityUsingQuestionId, true, signalRelatedEntity, "FluConsentAnswer", resetFKFields, new int[] { (int)FluConsentAnswerFieldIndex.QuestionId } );		
			_fluConsentQuestion = null;
		}

		/// <summary> setups the sync logic for member _fluConsentQuestion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFluConsentQuestion(IEntity2 relatedEntity)
		{
			if(_fluConsentQuestion!=relatedEntity)
			{
				DesetupSyncFluConsentQuestion(true, true);
				_fluConsentQuestion = (FluConsentQuestionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _fluConsentQuestion, new PropertyChangedEventHandler( OnFluConsentQuestionPropertyChanged ), "FluConsentQuestion", FluConsentAnswerEntity.Relations.FluConsentQuestionEntityUsingQuestionId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFluConsentQuestionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "FluConsentAnswer_", resetFKFields, new int[] { (int)FluConsentAnswerFieldIndex.ModifiedBy } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "FluConsentAnswer", resetFKFields, new int[] { (int)FluConsentAnswerFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this FluConsentAnswerEntity</param>
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
		public  static FluConsentAnswerRelations Relations
		{
			get	{ return new FluConsentAnswerRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomers
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)Falcon.Data.EntityType.FluConsentAnswerEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentQuestion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("FluConsentQuestion")[0], (int)Falcon.Data.EntityType.FluConsentAnswerEntity, (int)Falcon.Data.EntityType.FluConsentQuestionEntity, 0, null, null, null, null, "FluConsentQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.FluConsentAnswerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.FluConsentAnswerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return FluConsentAnswerEntity.CustomProperties;}
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
			get { return FluConsentAnswerEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventCustomerId property of the Entity FluConsentAnswer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentAnswer"."EventCustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 EventCustomerId
		{
			get { return (System.Int64)GetValue((int)FluConsentAnswerFieldIndex.EventCustomerId, true); }
			set	{ SetValue((int)FluConsentAnswerFieldIndex.EventCustomerId, value); }
		}

		/// <summary> The QuestionId property of the Entity FluConsentAnswer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentAnswer"."QuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 QuestionId
		{
			get { return (System.Int64)GetValue((int)FluConsentAnswerFieldIndex.QuestionId, true); }
			set	{ SetValue((int)FluConsentAnswerFieldIndex.QuestionId, value); }
		}

		/// <summary> The Answer property of the Entity FluConsentAnswer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentAnswer"."Answer"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Answer
		{
			get { return (System.String)GetValue((int)FluConsentAnswerFieldIndex.Answer, true); }
			set	{ SetValue((int)FluConsentAnswerFieldIndex.Answer, value); }
		}

		/// <summary> The Version property of the Entity FluConsentAnswer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentAnswer"."Version"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 Version
		{
			get { return (System.Int32)GetValue((int)FluConsentAnswerFieldIndex.Version, true); }
			set	{ SetValue((int)FluConsentAnswerFieldIndex.Version, value); }
		}

		/// <summary> The IsActive property of the Entity FluConsentAnswer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentAnswer"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)FluConsentAnswerFieldIndex.IsActive, true); }
			set	{ SetValue((int)FluConsentAnswerFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity FluConsentAnswer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentAnswer"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)FluConsentAnswerFieldIndex.DateCreated, true); }
			set	{ SetValue((int)FluConsentAnswerFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedBy property of the Entity FluConsentAnswer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentAnswer"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)FluConsentAnswerFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)FluConsentAnswerFieldIndex.CreatedBy, value); }
		}

		/// <summary> The DateModified property of the Entity FluConsentAnswer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentAnswer"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)FluConsentAnswerFieldIndex.DateModified, false); }
			set	{ SetValue((int)FluConsentAnswerFieldIndex.DateModified, value); }
		}

		/// <summary> The ModifiedBy property of the Entity FluConsentAnswer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFluConsentAnswer"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)FluConsentAnswerFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)FluConsentAnswerFieldIndex.ModifiedBy, value); }
		}



		/// <summary> Gets / sets related entity of type 'EventCustomersEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomersEntity EventCustomers
		{
			get
			{
				return _eventCustomers;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomers(value);
				}
				else
				{
					if(value==null)
					{
						if(_eventCustomers != null)
						{
							_eventCustomers.UnsetRelatedEntity(this, "FluConsentAnswer");
						}
					}
					else
					{
						if(_eventCustomers!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentAnswer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FluConsentQuestionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FluConsentQuestionEntity FluConsentQuestion
		{
			get
			{
				return _fluConsentQuestion;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFluConsentQuestion(value);
				}
				else
				{
					if(value==null)
					{
						if(_fluConsentQuestion != null)
						{
							_fluConsentQuestion.UnsetRelatedEntity(this, "FluConsentAnswer");
						}
					}
					else
					{
						if(_fluConsentQuestion!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentAnswer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "FluConsentAnswer_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentAnswer_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "FluConsentAnswer");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "FluConsentAnswer");
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
			get { return (int)Falcon.Data.EntityType.FluConsentAnswerEntity; }
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
