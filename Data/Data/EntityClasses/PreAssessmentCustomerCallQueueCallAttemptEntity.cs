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
	/// Entity class which represents the entity 'PreAssessmentCustomerCallQueueCallAttempt'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PreAssessmentCustomerCallQueueCallAttemptEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CallsEntity _calls;
		private CustomerProfileEntity _customerProfile;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private TagEntity _tag;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Calls</summary>
			public static readonly string Calls = "Calls";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Tag</summary>
			public static readonly string Tag = "Tag";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PreAssessmentCustomerCallQueueCallAttemptEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PreAssessmentCustomerCallQueueCallAttemptEntity():base("PreAssessmentCustomerCallQueueCallAttemptEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PreAssessmentCustomerCallQueueCallAttemptEntity(IEntityFields2 fields):base("PreAssessmentCustomerCallQueueCallAttemptEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PreAssessmentCustomerCallQueueCallAttemptEntity</param>
		public PreAssessmentCustomerCallQueueCallAttemptEntity(IValidator validator):base("PreAssessmentCustomerCallQueueCallAttemptEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="preAssessmentCallAttemptId">PK value for PreAssessmentCustomerCallQueueCallAttempt which data should be fetched into this PreAssessmentCustomerCallQueueCallAttempt object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PreAssessmentCustomerCallQueueCallAttemptEntity(System.Int64 preAssessmentCallAttemptId):base("PreAssessmentCustomerCallQueueCallAttemptEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PreAssessmentCallAttemptId = preAssessmentCallAttemptId;
		}

		/// <summary> CTor</summary>
		/// <param name="preAssessmentCallAttemptId">PK value for PreAssessmentCustomerCallQueueCallAttempt which data should be fetched into this PreAssessmentCustomerCallQueueCallAttempt object</param>
		/// <param name="validator">The custom validator object for this PreAssessmentCustomerCallQueueCallAttemptEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PreAssessmentCustomerCallQueueCallAttemptEntity(System.Int64 preAssessmentCallAttemptId, IValidator validator):base("PreAssessmentCustomerCallQueueCallAttemptEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PreAssessmentCallAttemptId = preAssessmentCallAttemptId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PreAssessmentCustomerCallQueueCallAttemptEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_calls = (CallsEntity)info.GetValue("_calls", typeof(CallsEntity));
				if(_calls!=null)
				{
					_calls.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_tag = (TagEntity)info.GetValue("_tag", typeof(TagEntity));
				if(_tag!=null)
				{
					_tag.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PreAssessmentCustomerCallQueueCallAttemptFieldIndex)fieldIndex)
			{
				case PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CallId:
					DesetupSyncCalls(true, false);
					break;
				case PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case PreAssessmentCustomerCallQueueCallAttemptFieldIndex.NotInterestedReasonId:
					DesetupSyncTag(true, false);
					break;
				case PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
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
				case "Calls":
					this.Calls = (CallsEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Tag":
					this.Tag = (TagEntity)entity;
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
			return PreAssessmentCustomerCallQueueCallAttemptEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Calls":
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.CallsEntityUsingCallId);
					break;
				case "CustomerProfile":
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "Tag":
					toReturn.Add(PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.TagEntityUsingNotInterestedReasonId);
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
				case "Calls":
					SetupSyncCalls(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Tag":
					SetupSyncTag(relatedEntity);
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
				case "Calls":
					DesetupSyncCalls(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Tag":
					DesetupSyncTag(false, true);
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
			if(_calls!=null)
			{
				toReturn.Add(_calls);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_tag!=null)
			{
				toReturn.Add(_tag);
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


				info.AddValue("_calls", (!this.MarkedForDeletion?_calls:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_tag", (!this.MarkedForDeletion?_tag:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PreAssessmentCustomerCallQueueCallAttemptFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PreAssessmentCustomerCallQueueCallAttemptFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PreAssessmentCustomerCallQueueCallAttemptRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Calls' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
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

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Tag' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTag()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TagFields.TagId, null, ComparisonOperator.Equal, this.NotInterestedReasonId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PreAssessmentCustomerCallQueueCallAttemptEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PreAssessmentCustomerCallQueueCallAttemptEntityFactory));
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
			toReturn.Add("Calls", _calls);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Tag", _tag);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_calls!=null)
			{
				_calls.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_tag!=null)
			{
				_tag.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_calls = null;
			_customerProfile = null;
			_organizationRoleUser = null;
			_tag = null;

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

			_fieldsCustomProperties.Add("PreAssessmentCallAttemptId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsCallSkipped", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsNotesReadAndUnderstood", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotInterestedReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkipCallNote", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _calls</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCalls(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _calls, new PropertyChangedEventHandler( OnCallsPropertyChanged ), "Calls", PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.CallsEntityUsingCallId, true, signalRelatedEntity, "PreAssessmentCustomerCallQueueCallAttempt", resetFKFields, new int[] { (int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CallId } );		
			_calls = null;
		}

		/// <summary> setups the sync logic for member _calls</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCalls(IEntity2 relatedEntity)
		{
			if(_calls!=relatedEntity)
			{
				DesetupSyncCalls(true, true);
				_calls = (CallsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _calls, new PropertyChangedEventHandler( OnCallsPropertyChanged ), "Calls", PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.CallsEntityUsingCallId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "PreAssessmentCustomerCallQueueCallAttempt", resetFKFields, new int[] { (int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "PreAssessmentCustomerCallQueueCallAttempt", resetFKFields, new int[] { (int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _tag</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTag(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _tag, new PropertyChangedEventHandler( OnTagPropertyChanged ), "Tag", PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.TagEntityUsingNotInterestedReasonId, true, signalRelatedEntity, "PreAssessmentCustomerCallQueueCallAttempt", resetFKFields, new int[] { (int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.NotInterestedReasonId } );		
			_tag = null;
		}

		/// <summary> setups the sync logic for member _tag</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTag(IEntity2 relatedEntity)
		{
			if(_tag!=relatedEntity)
			{
				DesetupSyncTag(true, true);
				_tag = (TagEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _tag, new PropertyChangedEventHandler( OnTagPropertyChanged ), "Tag", PreAssessmentCustomerCallQueueCallAttemptEntity.Relations.TagEntityUsingNotInterestedReasonId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTagPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PreAssessmentCustomerCallQueueCallAttemptEntity</param>
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
		public  static PreAssessmentCustomerCallQueueCallAttemptRelations Relations
		{
			get	{ return new PreAssessmentCustomerCallQueueCallAttemptRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Calls' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCalls
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Calls")[0], (int)Falcon.Data.EntityType.PreAssessmentCustomerCallQueueCallAttemptEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, null, null, "Calls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.PreAssessmentCustomerCallQueueCallAttemptEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.PreAssessmentCustomerCallQueueCallAttemptEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Tag' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTag
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory))),
					(IEntityRelation)GetRelationsForField("Tag")[0], (int)Falcon.Data.EntityType.PreAssessmentCustomerCallQueueCallAttemptEntity, (int)Falcon.Data.EntityType.TagEntity, 0, null, null, null, null, "Tag", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PreAssessmentCustomerCallQueueCallAttemptEntity.CustomProperties;}
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
			get { return PreAssessmentCustomerCallQueueCallAttemptEntity.FieldsCustomProperties;}
		}

		/// <summary> The PreAssessmentCallAttemptId property of the Entity PreAssessmentCustomerCallQueueCallAttempt<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreAssessmentCustomerCallQueueCallAttempt"."PreAssessmentCallAttemptID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PreAssessmentCallAttemptId
		{
			get { return (System.Int64)GetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.PreAssessmentCallAttemptId, true); }
			set	{ SetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.PreAssessmentCallAttemptId, value); }
		}

		/// <summary> The CallId property of the Entity PreAssessmentCustomerCallQueueCallAttempt<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreAssessmentCustomerCallQueueCallAttempt"."CallID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CallId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CallId, false); }
			set	{ SetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CallId, value); }
		}

		/// <summary> The CustomerId property of the Entity PreAssessmentCustomerCallQueueCallAttempt<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreAssessmentCustomerCallQueueCallAttempt"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CustomerId, true); }
			set	{ SetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CustomerId, value); }
		}

		/// <summary> The IsCallSkipped property of the Entity PreAssessmentCustomerCallQueueCallAttempt<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreAssessmentCustomerCallQueueCallAttempt"."IsCallSkipped"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsCallSkipped
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.IsCallSkipped, false); }
			set	{ SetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.IsCallSkipped, value); }
		}

		/// <summary> The IsNotesReadAndUnderstood property of the Entity PreAssessmentCustomerCallQueueCallAttempt<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreAssessmentCustomerCallQueueCallAttempt"."IsNotesReadAndUnderstood"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsNotesReadAndUnderstood
		{
			get { return (Nullable<System.Boolean>)GetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.IsNotesReadAndUnderstood, false); }
			set	{ SetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.IsNotesReadAndUnderstood, value); }
		}

		/// <summary> The NotInterestedReasonId property of the Entity PreAssessmentCustomerCallQueueCallAttempt<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreAssessmentCustomerCallQueueCallAttempt"."NotInterestedReasonID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> NotInterestedReasonId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.NotInterestedReasonId, false); }
			set	{ SetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.NotInterestedReasonId, value); }
		}

		/// <summary> The DateCreated property of the Entity PreAssessmentCustomerCallQueueCallAttempt<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreAssessmentCustomerCallQueueCallAttempt"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedBy property of the Entity PreAssessmentCustomerCallQueueCallAttempt<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreAssessmentCustomerCallQueueCallAttempt"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.CreatedBy, value); }
		}

		/// <summary> The SkipCallNote property of the Entity PreAssessmentCustomerCallQueueCallAttempt<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreAssessmentCustomerCallQueueCallAttempt"."SkipCallNote"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SkipCallNote
		{
			get { return (System.String)GetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.SkipCallNote, true); }
			set	{ SetValue((int)PreAssessmentCustomerCallQueueCallAttemptFieldIndex.SkipCallNote, value); }
		}



		/// <summary> Gets / sets related entity of type 'CallsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallsEntity Calls
		{
			get
			{
				return _calls;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCalls(value);
				}
				else
				{
					if(value==null)
					{
						if(_calls != null)
						{
							_calls.UnsetRelatedEntity(this, "PreAssessmentCustomerCallQueueCallAttempt");
						}
					}
					else
					{
						if(_calls!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreAssessmentCustomerCallQueueCallAttempt");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "PreAssessmentCustomerCallQueueCallAttempt");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreAssessmentCustomerCallQueueCallAttempt");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "PreAssessmentCustomerCallQueueCallAttempt");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreAssessmentCustomerCallQueueCallAttempt");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TagEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TagEntity Tag
		{
			get
			{
				return _tag;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTag(value);
				}
				else
				{
					if(value==null)
					{
						if(_tag != null)
						{
							_tag.UnsetRelatedEntity(this, "PreAssessmentCustomerCallQueueCallAttempt");
						}
					}
					else
					{
						if(_tag!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreAssessmentCustomerCallQueueCallAttempt");
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
			get { return (int)Falcon.Data.EntityType.PreAssessmentCustomerCallQueueCallAttemptEntity; }
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
