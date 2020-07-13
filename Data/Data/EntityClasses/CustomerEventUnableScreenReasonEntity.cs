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
	/// Entity class which represents the entity 'CustomerEventUnableScreenReason'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerEventUnableScreenReasonEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CustomerEventScreeningTestsEntity _customerEventScreeningTests;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private TestUnableScreenReasonEntity _testUnableScreenReason;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerEventScreeningTests</summary>
			public static readonly string CustomerEventScreeningTests = "CustomerEventScreeningTests";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name TestUnableScreenReason</summary>
			public static readonly string TestUnableScreenReason = "TestUnableScreenReason";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerEventUnableScreenReasonEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerEventUnableScreenReasonEntity():base("CustomerEventUnableScreenReasonEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerEventUnableScreenReasonEntity(IEntityFields2 fields):base("CustomerEventUnableScreenReasonEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerEventUnableScreenReasonEntity</param>
		public CustomerEventUnableScreenReasonEntity(IValidator validator):base("CustomerEventUnableScreenReasonEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="customerEventUnableScreenReasonId">PK value for CustomerEventUnableScreenReason which data should be fetched into this CustomerEventUnableScreenReason object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerEventUnableScreenReasonEntity(System.Int64 customerEventUnableScreenReasonId):base("CustomerEventUnableScreenReasonEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CustomerEventUnableScreenReasonId = customerEventUnableScreenReasonId;
		}

		/// <summary> CTor</summary>
		/// <param name="customerEventUnableScreenReasonId">PK value for CustomerEventUnableScreenReason which data should be fetched into this CustomerEventUnableScreenReason object</param>
		/// <param name="validator">The custom validator object for this CustomerEventUnableScreenReasonEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerEventUnableScreenReasonEntity(System.Int64 customerEventUnableScreenReasonId, IValidator validator):base("CustomerEventUnableScreenReasonEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CustomerEventUnableScreenReasonId = customerEventUnableScreenReasonId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerEventUnableScreenReasonEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_customerEventScreeningTests = (CustomerEventScreeningTestsEntity)info.GetValue("_customerEventScreeningTests", typeof(CustomerEventScreeningTestsEntity));
				if(_customerEventScreeningTests!=null)
				{
					_customerEventScreeningTests.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_testUnableScreenReason = (TestUnableScreenReasonEntity)info.GetValue("_testUnableScreenReason", typeof(TestUnableScreenReasonEntity));
				if(_testUnableScreenReason!=null)
				{
					_testUnableScreenReason.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerEventUnableScreenReasonFieldIndex)fieldIndex)
			{
				case CustomerEventUnableScreenReasonFieldIndex.CustomerEventScreeningTestId:
					DesetupSyncCustomerEventScreeningTests(true, false);
					break;
				case CustomerEventUnableScreenReasonFieldIndex.TestUnableScreenReasonId:
					DesetupSyncTestUnableScreenReason(true, false);
					break;
				case CustomerEventUnableScreenReasonFieldIndex.UpdatedByOrgRoleUserId:
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
				case "CustomerEventScreeningTests":
					this.CustomerEventScreeningTests = (CustomerEventScreeningTestsEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "TestUnableScreenReason":
					this.TestUnableScreenReason = (TestUnableScreenReasonEntity)entity;
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
			return CustomerEventUnableScreenReasonEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerEventScreeningTests":
					toReturn.Add(CustomerEventUnableScreenReasonEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CustomerEventUnableScreenReasonEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId);
					break;
				case "TestUnableScreenReason":
					toReturn.Add(CustomerEventUnableScreenReasonEntity.Relations.TestUnableScreenReasonEntityUsingTestUnableScreenReasonId);
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
				case "CustomerEventScreeningTests":
					SetupSyncCustomerEventScreeningTests(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "TestUnableScreenReason":
					SetupSyncTestUnableScreenReason(relatedEntity);
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
				case "CustomerEventScreeningTests":
					DesetupSyncCustomerEventScreeningTests(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "TestUnableScreenReason":
					DesetupSyncTestUnableScreenReason(false, true);
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
			if(_customerEventScreeningTests!=null)
			{
				toReturn.Add(_customerEventScreeningTests);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_testUnableScreenReason!=null)
			{
				toReturn.Add(_testUnableScreenReason);
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


				info.AddValue("_customerEventScreeningTests", (!this.MarkedForDeletion?_customerEventScreeningTests:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_testUnableScreenReason", (!this.MarkedForDeletion?_testUnableScreenReason:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CustomerEventUnableScreenReasonFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerEventUnableScreenReasonFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerEventUnableScreenReasonRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerEventScreeningTests' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventScreeningTests()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.UpdatedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TestUnableScreenReason' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestUnableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestUnableScreenReasonFields.TestUnableScreenReasonId, null, ComparisonOperator.Equal, this.TestUnableScreenReasonId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerEventUnableScreenReasonEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventUnableScreenReasonEntityFactory));
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
			toReturn.Add("CustomerEventScreeningTests", _customerEventScreeningTests);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("TestUnableScreenReason", _testUnableScreenReason);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_customerEventScreeningTests!=null)
			{
				_customerEventScreeningTests.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_testUnableScreenReason!=null)
			{
				_testUnableScreenReason.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_customerEventScreeningTests = null;
			_organizationRoleUser = null;
			_testUnableScreenReason = null;

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

			_fieldsCustomProperties.Add("CustomerEventUnableScreenReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventScreeningTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestUnableScreenReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManual", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerEventScreeningTests</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventScreeningTests(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventScreeningTests, new PropertyChangedEventHandler( OnCustomerEventScreeningTestsPropertyChanged ), "CustomerEventScreeningTests", CustomerEventUnableScreenReasonEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId, true, signalRelatedEntity, "CustomerEventUnableScreenReason", resetFKFields, new int[] { (int)CustomerEventUnableScreenReasonFieldIndex.CustomerEventScreeningTestId } );		
			_customerEventScreeningTests = null;
		}

		/// <summary> setups the sync logic for member _customerEventScreeningTests</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerEventScreeningTests(IEntity2 relatedEntity)
		{
			if(_customerEventScreeningTests!=relatedEntity)
			{
				DesetupSyncCustomerEventScreeningTests(true, true);
				_customerEventScreeningTests = (CustomerEventScreeningTestsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerEventScreeningTests, new PropertyChangedEventHandler( OnCustomerEventScreeningTestsPropertyChanged ), "CustomerEventScreeningTests", CustomerEventUnableScreenReasonEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerEventScreeningTestsPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CustomerEventUnableScreenReasonEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId, true, signalRelatedEntity, "CustomerEventUnableScreenReason", resetFKFields, new int[] { (int)CustomerEventUnableScreenReasonFieldIndex.UpdatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CustomerEventUnableScreenReasonEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _testUnableScreenReason</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTestUnableScreenReason(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _testUnableScreenReason, new PropertyChangedEventHandler( OnTestUnableScreenReasonPropertyChanged ), "TestUnableScreenReason", CustomerEventUnableScreenReasonEntity.Relations.TestUnableScreenReasonEntityUsingTestUnableScreenReasonId, true, signalRelatedEntity, "CustomerEventUnableScreenReason", resetFKFields, new int[] { (int)CustomerEventUnableScreenReasonFieldIndex.TestUnableScreenReasonId } );		
			_testUnableScreenReason = null;
		}

		/// <summary> setups the sync logic for member _testUnableScreenReason</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTestUnableScreenReason(IEntity2 relatedEntity)
		{
			if(_testUnableScreenReason!=relatedEntity)
			{
				DesetupSyncTestUnableScreenReason(true, true);
				_testUnableScreenReason = (TestUnableScreenReasonEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _testUnableScreenReason, new PropertyChangedEventHandler( OnTestUnableScreenReasonPropertyChanged ), "TestUnableScreenReason", CustomerEventUnableScreenReasonEntity.Relations.TestUnableScreenReasonEntityUsingTestUnableScreenReasonId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTestUnableScreenReasonPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CustomerEventUnableScreenReasonEntity</param>
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
		public  static CustomerEventUnableScreenReasonRelations Relations
		{
			get	{ return new CustomerEventUnableScreenReasonRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventScreeningTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventScreeningTests
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventScreeningTests")[0], (int)Falcon.Data.EntityType.CustomerEventUnableScreenReasonEntity, (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, 0, null, null, null, null, "CustomerEventScreeningTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CustomerEventUnableScreenReasonEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestUnableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestUnableScreenReason
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TestUnableScreenReasonEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestUnableScreenReason")[0], (int)Falcon.Data.EntityType.CustomerEventUnableScreenReasonEntity, (int)Falcon.Data.EntityType.TestUnableScreenReasonEntity, 0, null, null, null, null, "TestUnableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerEventUnableScreenReasonEntity.CustomProperties;}
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
			get { return CustomerEventUnableScreenReasonEntity.FieldsCustomProperties;}
		}

		/// <summary> The CustomerEventUnableScreenReasonId property of the Entity CustomerEventUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventUnableScreenReason"."CustomerEventUnableScreenReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CustomerEventUnableScreenReasonId
		{
			get { return (System.Int64)GetValue((int)CustomerEventUnableScreenReasonFieldIndex.CustomerEventUnableScreenReasonId, true); }
			set	{ SetValue((int)CustomerEventUnableScreenReasonFieldIndex.CustomerEventUnableScreenReasonId, value); }
		}

		/// <summary> The CustomerEventScreeningTestId property of the Entity CustomerEventUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventUnableScreenReason"."CustomerEventScreeningTestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventScreeningTestId
		{
			get { return (System.Int64)GetValue((int)CustomerEventUnableScreenReasonFieldIndex.CustomerEventScreeningTestId, true); }
			set	{ SetValue((int)CustomerEventUnableScreenReasonFieldIndex.CustomerEventScreeningTestId, value); }
		}

		/// <summary> The TestUnableScreenReasonId property of the Entity CustomerEventUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventUnableScreenReason"."TestUnableScreenReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> TestUnableScreenReasonId
		{
			get { return (Nullable<System.Byte>)GetValue((int)CustomerEventUnableScreenReasonFieldIndex.TestUnableScreenReasonId, false); }
			set	{ SetValue((int)CustomerEventUnableScreenReasonFieldIndex.TestUnableScreenReasonId, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity CustomerEventUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventUnableScreenReason"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)CustomerEventUnableScreenReasonFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)CustomerEventUnableScreenReasonFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The CreatedOn property of the Entity CustomerEventUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventUnableScreenReason"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerEventUnableScreenReasonFieldIndex.CreatedOn, false); }
			set	{ SetValue((int)CustomerEventUnableScreenReasonFieldIndex.CreatedOn, value); }
		}

		/// <summary> The UpdatedByOrgRoleUserId property of the Entity CustomerEventUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventUnableScreenReason"."UpdatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UpdatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerEventUnableScreenReasonFieldIndex.UpdatedByOrgRoleUserId, false); }
			set	{ SetValue((int)CustomerEventUnableScreenReasonFieldIndex.UpdatedByOrgRoleUserId, value); }
		}

		/// <summary> The UpdatedOn property of the Entity CustomerEventUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventUnableScreenReason"."UpdatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> UpdatedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerEventUnableScreenReasonFieldIndex.UpdatedOn, false); }
			set	{ SetValue((int)CustomerEventUnableScreenReasonFieldIndex.UpdatedOn, value); }
		}

		/// <summary> The IsManual property of the Entity CustomerEventUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventUnableScreenReason"."IsManual"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManual
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CustomerEventUnableScreenReasonFieldIndex.IsManual, false); }
			set	{ SetValue((int)CustomerEventUnableScreenReasonFieldIndex.IsManual, value); }
		}



		/// <summary> Gets / sets related entity of type 'CustomerEventScreeningTestsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerEventScreeningTestsEntity CustomerEventScreeningTests
		{
			get
			{
				return _customerEventScreeningTests;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerEventScreeningTests(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerEventScreeningTests != null)
						{
							_customerEventScreeningTests.UnsetRelatedEntity(this, "CustomerEventUnableScreenReason");
						}
					}
					else
					{
						if(_customerEventScreeningTests!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerEventUnableScreenReason");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CustomerEventUnableScreenReason");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerEventUnableScreenReason");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TestUnableScreenReasonEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TestUnableScreenReasonEntity TestUnableScreenReason
		{
			get
			{
				return _testUnableScreenReason;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTestUnableScreenReason(value);
				}
				else
				{
					if(value==null)
					{
						if(_testUnableScreenReason != null)
						{
							_testUnableScreenReason.UnsetRelatedEntity(this, "CustomerEventUnableScreenReason");
						}
					}
					else
					{
						if(_testUnableScreenReason!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerEventUnableScreenReason");
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
			get { return (int)Falcon.Data.EntityType.CustomerEventUnableScreenReasonEntity; }
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
