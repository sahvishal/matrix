﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'CustomerResultScreeningCommunication'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerResultScreeningCommunicationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private EventCustomerResultEntity _eventCustomerResult;
		private OrganizationRoleUserEntity _organizationRoleUser____;
		private OrganizationRoleUserEntity _organizationRoleUser_____;
		private OrganizationRoleUserEntity _organizationRoleUser___;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name EventCustomerResult</summary>
			public static readonly string EventCustomerResult = "EventCustomerResult";
			/// <summary>Member name OrganizationRoleUser____</summary>
			public static readonly string OrganizationRoleUser____ = "OrganizationRoleUser____";
			/// <summary>Member name OrganizationRoleUser_____</summary>
			public static readonly string OrganizationRoleUser_____ = "OrganizationRoleUser_____";
			/// <summary>Member name OrganizationRoleUser___</summary>
			public static readonly string OrganizationRoleUser___ = "OrganizationRoleUser___";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerResultScreeningCommunicationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerResultScreeningCommunicationEntity():base("CustomerResultScreeningCommunicationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerResultScreeningCommunicationEntity(IEntityFields2 fields):base("CustomerResultScreeningCommunicationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerResultScreeningCommunicationEntity</param>
		public CustomerResultScreeningCommunicationEntity(IValidator validator):base("CustomerResultScreeningCommunicationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="communicationId">PK value for CustomerResultScreeningCommunication which data should be fetched into this CustomerResultScreeningCommunication object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerResultScreeningCommunicationEntity(System.Int64 communicationId):base("CustomerResultScreeningCommunicationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CommunicationId = communicationId;
		}

		/// <summary> CTor</summary>
		/// <param name="communicationId">PK value for CustomerResultScreeningCommunication which data should be fetched into this CustomerResultScreeningCommunication object</param>
		/// <param name="validator">The custom validator object for this CustomerResultScreeningCommunicationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerResultScreeningCommunicationEntity(System.Int64 communicationId, IValidator validator):base("CustomerResultScreeningCommunicationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CommunicationId = communicationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerResultScreeningCommunicationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_eventCustomerResult = (EventCustomerResultEntity)info.GetValue("_eventCustomerResult", typeof(EventCustomerResultEntity));
				if(_eventCustomerResult!=null)
				{
					_eventCustomerResult.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser____ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser____", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser____!=null)
				{
					_organizationRoleUser____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_____ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_____", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_____!=null)
				{
					_organizationRoleUser_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser___ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser___", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser___!=null)
				{
					_organizationRoleUser___.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerResultScreeningCommunicationFieldIndex)fieldIndex)
			{
				case CustomerResultScreeningCommunicationFieldIndex.CommunicationInitiatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser___(true, false);
					break;
				case CustomerResultScreeningCommunicationFieldIndex.PhysicianOrgRoleUserId:
					DesetupSyncOrganizationRoleUser____(true, false);
					break;
				case CustomerResultScreeningCommunicationFieldIndex.FranchiseeAdminOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_____(true, false);
					break;
				case CustomerResultScreeningCommunicationFieldIndex.EventCustomerResultId:
					DesetupSyncEventCustomerResult(true, false);
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
				case "EventCustomerResult":
					this.EventCustomerResult = (EventCustomerResultEntity)entity;
					break;
				case "OrganizationRoleUser____":
					this.OrganizationRoleUser____ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser_____":
					this.OrganizationRoleUser_____ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser___":
					this.OrganizationRoleUser___ = (OrganizationRoleUserEntity)entity;
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
			return CustomerResultScreeningCommunicationEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "EventCustomerResult":
					toReturn.Add(CustomerResultScreeningCommunicationEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId);
					break;
				case "OrganizationRoleUser____":
					toReturn.Add(CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingPhysicianOrgRoleUserId);
					break;
				case "OrganizationRoleUser_____":
					toReturn.Add(CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingFranchiseeAdminOrgRoleUserId);
					break;
				case "OrganizationRoleUser___":
					toReturn.Add(CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingCommunicationInitiatedByOrgRoleUserId);
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
				case "EventCustomerResult":
					SetupSyncEventCustomerResult(relatedEntity);
					break;
				case "OrganizationRoleUser____":
					SetupSyncOrganizationRoleUser____(relatedEntity);
					break;
				case "OrganizationRoleUser_____":
					SetupSyncOrganizationRoleUser_____(relatedEntity);
					break;
				case "OrganizationRoleUser___":
					SetupSyncOrganizationRoleUser___(relatedEntity);
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
				case "EventCustomerResult":
					DesetupSyncEventCustomerResult(false, true);
					break;
				case "OrganizationRoleUser____":
					DesetupSyncOrganizationRoleUser____(false, true);
					break;
				case "OrganizationRoleUser_____":
					DesetupSyncOrganizationRoleUser_____(false, true);
					break;
				case "OrganizationRoleUser___":
					DesetupSyncOrganizationRoleUser___(false, true);
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
			if(_eventCustomerResult!=null)
			{
				toReturn.Add(_eventCustomerResult);
			}
			if(_organizationRoleUser____!=null)
			{
				toReturn.Add(_organizationRoleUser____);
			}
			if(_organizationRoleUser_____!=null)
			{
				toReturn.Add(_organizationRoleUser_____);
			}
			if(_organizationRoleUser___!=null)
			{
				toReturn.Add(_organizationRoleUser___);
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


				info.AddValue("_eventCustomerResult", (!this.MarkedForDeletion?_eventCustomerResult:null));
				info.AddValue("_organizationRoleUser____", (!this.MarkedForDeletion?_organizationRoleUser____:null));
				info.AddValue("_organizationRoleUser_____", (!this.MarkedForDeletion?_organizationRoleUser_____:null));
				info.AddValue("_organizationRoleUser___", (!this.MarkedForDeletion?_organizationRoleUser___:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CustomerResultScreeningCommunicationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerResultScreeningCommunicationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerResultScreeningCommunicationRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerResult' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.PhysicianOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.FranchiseeAdminOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CommunicationInitiatedByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerResultScreeningCommunicationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerResultScreeningCommunicationEntityFactory));
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
			toReturn.Add("EventCustomerResult", _eventCustomerResult);
			toReturn.Add("OrganizationRoleUser____", _organizationRoleUser____);
			toReturn.Add("OrganizationRoleUser_____", _organizationRoleUser_____);
			toReturn.Add("OrganizationRoleUser___", _organizationRoleUser___);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_eventCustomerResult!=null)
			{
				_eventCustomerResult.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser____!=null)
			{
				_organizationRoleUser____.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_____!=null)
			{
				_organizationRoleUser_____.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser___!=null)
			{
				_organizationRoleUser___.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_eventCustomerResult = null;
			_organizationRoleUser____ = null;
			_organizationRoleUser_____ = null;
			_organizationRoleUser___ = null;

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

			_fieldsCustomProperties.Add("CommunicationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhysicianComment", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FranchiseeComment", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateResponded", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CommunicationInitiatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhysicianOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FranchiseeAdminOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventCustomerResultId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _eventCustomerResult</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerResult(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerResult, new PropertyChangedEventHandler( OnEventCustomerResultPropertyChanged ), "EventCustomerResult", CustomerResultScreeningCommunicationEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, true, signalRelatedEntity, "CustomerResultScreeningCommunication", resetFKFields, new int[] { (int)CustomerResultScreeningCommunicationFieldIndex.EventCustomerResultId } );		
			_eventCustomerResult = null;
		}

		/// <summary> setups the sync logic for member _eventCustomerResult</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomerResult(IEntity2 relatedEntity)
		{
			if(_eventCustomerResult!=relatedEntity)
			{
				DesetupSyncEventCustomerResult(true, true);
				_eventCustomerResult = (EventCustomerResultEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomerResult, new PropertyChangedEventHandler( OnEventCustomerResultPropertyChanged ), "EventCustomerResult", CustomerResultScreeningCommunicationEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomerResultPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser____, new PropertyChangedEventHandler( OnOrganizationRoleUser____PropertyChanged ), "OrganizationRoleUser____", CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingPhysicianOrgRoleUserId, true, signalRelatedEntity, "CustomerResultScreeningCommunication__", resetFKFields, new int[] { (int)CustomerResultScreeningCommunicationFieldIndex.PhysicianOrgRoleUserId } );		
			_organizationRoleUser____ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser____(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser____!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser____(true, true);
				_organizationRoleUser____ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser____, new PropertyChangedEventHandler( OnOrganizationRoleUser____PropertyChanged ), "OrganizationRoleUser____", CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingPhysicianOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_____, new PropertyChangedEventHandler( OnOrganizationRoleUser_____PropertyChanged ), "OrganizationRoleUser_____", CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingFranchiseeAdminOrgRoleUserId, true, signalRelatedEntity, "CustomerResultScreeningCommunication_", resetFKFields, new int[] { (int)CustomerResultScreeningCommunicationFieldIndex.FranchiseeAdminOrgRoleUserId } );		
			_organizationRoleUser_____ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_____(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_____!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_____(true, true);
				_organizationRoleUser_____ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_____, new PropertyChangedEventHandler( OnOrganizationRoleUser_____PropertyChanged ), "OrganizationRoleUser_____", CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingFranchiseeAdminOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser___, new PropertyChangedEventHandler( OnOrganizationRoleUser___PropertyChanged ), "OrganizationRoleUser___", CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingCommunicationInitiatedByOrgRoleUserId, true, signalRelatedEntity, "CustomerResultScreeningCommunication", resetFKFields, new int[] { (int)CustomerResultScreeningCommunicationFieldIndex.CommunicationInitiatedByOrgRoleUserId } );		
			_organizationRoleUser___ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser___(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser___!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser___(true, true);
				_organizationRoleUser___ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser___, new PropertyChangedEventHandler( OnOrganizationRoleUser___PropertyChanged ), "OrganizationRoleUser___", CustomerResultScreeningCommunicationEntity.Relations.OrganizationRoleUserEntityUsingCommunicationInitiatedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CustomerResultScreeningCommunicationEntity</param>
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
		public  static CustomerResultScreeningCommunicationRelations Relations
		{
			get	{ return new CustomerResultScreeningCommunicationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerResult' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerResult
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerResult")[0], (int)Falcon.Data.EntityType.CustomerResultScreeningCommunicationEntity, (int)Falcon.Data.EntityType.EventCustomerResultEntity, 0, null, null, null, null, "EventCustomerResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser____")[0], (int)Falcon.Data.EntityType.CustomerResultScreeningCommunicationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_____")[0], (int)Falcon.Data.EntityType.CustomerResultScreeningCommunicationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser___")[0], (int)Falcon.Data.EntityType.CustomerResultScreeningCommunicationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerResultScreeningCommunicationEntity.CustomProperties;}
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
			get { return CustomerResultScreeningCommunicationEntity.FieldsCustomProperties;}
		}

		/// <summary> The CommunicationId property of the Entity CustomerResultScreeningCommunication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerResultScreeningCommunication"."CommunicationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CommunicationId
		{
			get { return (System.Int64)GetValue((int)CustomerResultScreeningCommunicationFieldIndex.CommunicationId, true); }
			set	{ SetValue((int)CustomerResultScreeningCommunicationFieldIndex.CommunicationId, value); }
		}

		/// <summary> The PhysicianComment property of the Entity CustomerResultScreeningCommunication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerResultScreeningCommunication"."PhysicianComment"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhysicianComment
		{
			get { return (System.String)GetValue((int)CustomerResultScreeningCommunicationFieldIndex.PhysicianComment, true); }
			set	{ SetValue((int)CustomerResultScreeningCommunicationFieldIndex.PhysicianComment, value); }
		}

		/// <summary> The FranchiseeComment property of the Entity CustomerResultScreeningCommunication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerResultScreeningCommunication"."FranchiseeComment"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FranchiseeComment
		{
			get { return (System.String)GetValue((int)CustomerResultScreeningCommunicationFieldIndex.FranchiseeComment, true); }
			set	{ SetValue((int)CustomerResultScreeningCommunicationFieldIndex.FranchiseeComment, value); }
		}

		/// <summary> The DateCreated property of the Entity CustomerResultScreeningCommunication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerResultScreeningCommunication"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CustomerResultScreeningCommunicationFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CustomerResultScreeningCommunicationFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateResponded property of the Entity CustomerResultScreeningCommunication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerResultScreeningCommunication"."DateResponded"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateResponded
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerResultScreeningCommunicationFieldIndex.DateResponded, false); }
			set	{ SetValue((int)CustomerResultScreeningCommunicationFieldIndex.DateResponded, value); }
		}

		/// <summary> The CommunicationInitiatedByOrgRoleUserId property of the Entity CustomerResultScreeningCommunication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerResultScreeningCommunication"."CommunicationInitiatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CommunicationInitiatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)CustomerResultScreeningCommunicationFieldIndex.CommunicationInitiatedByOrgRoleUserId, true); }
			set	{ SetValue((int)CustomerResultScreeningCommunicationFieldIndex.CommunicationInitiatedByOrgRoleUserId, value); }
		}

		/// <summary> The PhysicianOrgRoleUserId property of the Entity CustomerResultScreeningCommunication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerResultScreeningCommunication"."PhysicianOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PhysicianOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerResultScreeningCommunicationFieldIndex.PhysicianOrgRoleUserId, false); }
			set	{ SetValue((int)CustomerResultScreeningCommunicationFieldIndex.PhysicianOrgRoleUserId, value); }
		}

		/// <summary> The FranchiseeAdminOrgRoleUserId property of the Entity CustomerResultScreeningCommunication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerResultScreeningCommunication"."FranchiseeAdminOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> FranchiseeAdminOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerResultScreeningCommunicationFieldIndex.FranchiseeAdminOrgRoleUserId, false); }
			set	{ SetValue((int)CustomerResultScreeningCommunicationFieldIndex.FranchiseeAdminOrgRoleUserId, value); }
		}

		/// <summary> The EventCustomerResultId property of the Entity CustomerResultScreeningCommunication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerResultScreeningCommunication"."EventCustomerResultId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventCustomerResultId
		{
			get { return (System.Int64)GetValue((int)CustomerResultScreeningCommunicationFieldIndex.EventCustomerResultId, true); }
			set	{ SetValue((int)CustomerResultScreeningCommunicationFieldIndex.EventCustomerResultId, value); }
		}



		/// <summary> Gets / sets related entity of type 'EventCustomerResultEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomerResultEntity EventCustomerResult
		{
			get
			{
				return _eventCustomerResult;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomerResult(value);
				}
				else
				{
					if(value==null)
					{
						if(_eventCustomerResult != null)
						{
							_eventCustomerResult.UnsetRelatedEntity(this, "CustomerResultScreeningCommunication");
						}
					}
					else
					{
						if(_eventCustomerResult!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerResultScreeningCommunication");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser____
		{
			get
			{
				return _organizationRoleUser____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser____(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser____ != null)
						{
							_organizationRoleUser____.UnsetRelatedEntity(this, "CustomerResultScreeningCommunication__");
						}
					}
					else
					{
						if(_organizationRoleUser____!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerResultScreeningCommunication__");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_____
		{
			get
			{
				return _organizationRoleUser_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_____ != null)
						{
							_organizationRoleUser_____.UnsetRelatedEntity(this, "CustomerResultScreeningCommunication_");
						}
					}
					else
					{
						if(_organizationRoleUser_____!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerResultScreeningCommunication_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser___
		{
			get
			{
				return _organizationRoleUser___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser___(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser___ != null)
						{
							_organizationRoleUser___.UnsetRelatedEntity(this, "CustomerResultScreeningCommunication");
						}
					}
					else
					{
						if(_organizationRoleUser___!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerResultScreeningCommunication");
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
			get { return (int)Falcon.Data.EntityType.CustomerResultScreeningCommunicationEntity; }
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
