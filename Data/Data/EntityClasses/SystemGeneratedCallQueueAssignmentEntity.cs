﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:50
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
	/// Entity class which represents the entity 'SystemGeneratedCallQueueAssignment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class SystemGeneratedCallQueueAssignmentEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CallQueueEntity _callQueue;
		private CallQueueCustomerEntity _callQueueCustomer;
		private SystemGeneratedCallQueueCriteriaEntity _systemGeneratedCallQueueCriteria;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CallQueue</summary>
			public static readonly string CallQueue = "CallQueue";
			/// <summary>Member name CallQueueCustomer</summary>
			public static readonly string CallQueueCustomer = "CallQueueCustomer";
			/// <summary>Member name SystemGeneratedCallQueueCriteria</summary>
			public static readonly string SystemGeneratedCallQueueCriteria = "SystemGeneratedCallQueueCriteria";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SystemGeneratedCallQueueAssignmentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public SystemGeneratedCallQueueAssignmentEntity():base("SystemGeneratedCallQueueAssignmentEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SystemGeneratedCallQueueAssignmentEntity(IEntityFields2 fields):base("SystemGeneratedCallQueueAssignmentEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SystemGeneratedCallQueueAssignmentEntity</param>
		public SystemGeneratedCallQueueAssignmentEntity(IValidator validator):base("SystemGeneratedCallQueueAssignmentEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="callQueueCustomerId">PK value for SystemGeneratedCallQueueAssignment which data should be fetched into this SystemGeneratedCallQueueAssignment object</param>
		/// <param name="callQueueId">PK value for SystemGeneratedCallQueueAssignment which data should be fetched into this SystemGeneratedCallQueueAssignment object</param>
		/// <param name="criteriaId">PK value for SystemGeneratedCallQueueAssignment which data should be fetched into this SystemGeneratedCallQueueAssignment object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SystemGeneratedCallQueueAssignmentEntity(System.Int64 callQueueCustomerId, System.Int64 callQueueId, System.Int64 criteriaId):base("SystemGeneratedCallQueueAssignmentEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CallQueueCustomerId = callQueueCustomerId;
			this.CallQueueId = callQueueId;
			this.CriteriaId = criteriaId;
		}

		/// <summary> CTor</summary>
		/// <param name="callQueueCustomerId">PK value for SystemGeneratedCallQueueAssignment which data should be fetched into this SystemGeneratedCallQueueAssignment object</param>
		/// <param name="callQueueId">PK value for SystemGeneratedCallQueueAssignment which data should be fetched into this SystemGeneratedCallQueueAssignment object</param>
		/// <param name="criteriaId">PK value for SystemGeneratedCallQueueAssignment which data should be fetched into this SystemGeneratedCallQueueAssignment object</param>
		/// <param name="validator">The custom validator object for this SystemGeneratedCallQueueAssignmentEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SystemGeneratedCallQueueAssignmentEntity(System.Int64 callQueueCustomerId, System.Int64 callQueueId, System.Int64 criteriaId, IValidator validator):base("SystemGeneratedCallQueueAssignmentEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CallQueueCustomerId = callQueueCustomerId;
			this.CallQueueId = callQueueId;
			this.CriteriaId = criteriaId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected SystemGeneratedCallQueueAssignmentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_callQueue = (CallQueueEntity)info.GetValue("_callQueue", typeof(CallQueueEntity));
				if(_callQueue!=null)
				{
					_callQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_callQueueCustomer = (CallQueueCustomerEntity)info.GetValue("_callQueueCustomer", typeof(CallQueueCustomerEntity));
				if(_callQueueCustomer!=null)
				{
					_callQueueCustomer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_systemGeneratedCallQueueCriteria = (SystemGeneratedCallQueueCriteriaEntity)info.GetValue("_systemGeneratedCallQueueCriteria", typeof(SystemGeneratedCallQueueCriteriaEntity));
				if(_systemGeneratedCallQueueCriteria!=null)
				{
					_systemGeneratedCallQueueCriteria.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((SystemGeneratedCallQueueAssignmentFieldIndex)fieldIndex)
			{
				case SystemGeneratedCallQueueAssignmentFieldIndex.CallQueueCustomerId:
					DesetupSyncCallQueueCustomer(true, false);
					break;
				case SystemGeneratedCallQueueAssignmentFieldIndex.CallQueueId:
					DesetupSyncCallQueue(true, false);
					break;
				case SystemGeneratedCallQueueAssignmentFieldIndex.CriteriaId:
					DesetupSyncSystemGeneratedCallQueueCriteria(true, false);
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
				case "CallQueue":
					this.CallQueue = (CallQueueEntity)entity;
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer = (CallQueueCustomerEntity)entity;
					break;
				case "SystemGeneratedCallQueueCriteria":
					this.SystemGeneratedCallQueueCriteria = (SystemGeneratedCallQueueCriteriaEntity)entity;
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
			return SystemGeneratedCallQueueAssignmentEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CallQueue":
					toReturn.Add(SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueEntityUsingCallQueueId);
					break;
				case "CallQueueCustomer":
					toReturn.Add(SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId);
					break;
				case "SystemGeneratedCallQueueCriteria":
					toReturn.Add(SystemGeneratedCallQueueAssignmentEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCriteriaId);
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
				case "CallQueue":
					SetupSyncCallQueue(relatedEntity);
					break;
				case "CallQueueCustomer":
					SetupSyncCallQueueCustomer(relatedEntity);
					break;
				case "SystemGeneratedCallQueueCriteria":
					SetupSyncSystemGeneratedCallQueueCriteria(relatedEntity);
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
				case "CallQueue":
					DesetupSyncCallQueue(false, true);
					break;
				case "CallQueueCustomer":
					DesetupSyncCallQueueCustomer(false, true);
					break;
				case "SystemGeneratedCallQueueCriteria":
					DesetupSyncSystemGeneratedCallQueueCriteria(false, true);
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
			if(_callQueue!=null)
			{
				toReturn.Add(_callQueue);
			}
			if(_callQueueCustomer!=null)
			{
				toReturn.Add(_callQueueCustomer);
			}
			if(_systemGeneratedCallQueueCriteria!=null)
			{
				toReturn.Add(_systemGeneratedCallQueueCriteria);
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


				info.AddValue("_callQueue", (!this.MarkedForDeletion?_callQueue:null));
				info.AddValue("_callQueueCustomer", (!this.MarkedForDeletion?_callQueueCustomer:null));
				info.AddValue("_systemGeneratedCallQueueCriteria", (!this.MarkedForDeletion?_systemGeneratedCallQueueCriteria:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(SystemGeneratedCallQueueAssignmentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(SystemGeneratedCallQueueAssignmentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new SystemGeneratedCallQueueAssignmentRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'SystemGeneratedCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemGeneratedCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemGeneratedCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.CriteriaId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.SystemGeneratedCallQueueAssignmentEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueAssignmentEntityFactory));
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
			toReturn.Add("CallQueue", _callQueue);
			toReturn.Add("CallQueueCustomer", _callQueueCustomer);
			toReturn.Add("SystemGeneratedCallQueueCriteria", _systemGeneratedCallQueueCriteria);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_callQueue!=null)
			{
				_callQueue.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomer!=null)
			{
				_callQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_systemGeneratedCallQueueCriteria!=null)
			{
				_systemGeneratedCallQueueCriteria.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_callQueue = null;
			_callQueueCustomer = null;
			_systemGeneratedCallQueueCriteria = null;

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

			_fieldsCustomProperties.Add("CallQueueCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallQueueId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CriteriaId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _callQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueEntityUsingCallQueueId, true, signalRelatedEntity, "SystemGeneratedCallQueueAssignment", resetFKFields, new int[] { (int)SystemGeneratedCallQueueAssignmentFieldIndex.CallQueueId } );		
			_callQueue = null;
		}

		/// <summary> setups the sync logic for member _callQueue</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCallQueue(IEntity2 relatedEntity)
		{
			if(_callQueue!=relatedEntity)
			{
				DesetupSyncCallQueue(true, true);
				_callQueue = (CallQueueEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueEntityUsingCallQueueId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallQueuePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _callQueueCustomer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallQueueCustomer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callQueueCustomer, new PropertyChangedEventHandler( OnCallQueueCustomerPropertyChanged ), "CallQueueCustomer", SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId, true, signalRelatedEntity, "SystemGeneratedCallQueueAssignment", resetFKFields, new int[] { (int)SystemGeneratedCallQueueAssignmentFieldIndex.CallQueueCustomerId } );		
			_callQueueCustomer = null;
		}

		/// <summary> setups the sync logic for member _callQueueCustomer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCallQueueCustomer(IEntity2 relatedEntity)
		{
			if(_callQueueCustomer!=relatedEntity)
			{
				DesetupSyncCallQueueCustomer(true, true);
				_callQueueCustomer = (CallQueueCustomerEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _callQueueCustomer, new PropertyChangedEventHandler( OnCallQueueCustomerPropertyChanged ), "CallQueueCustomer", SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallQueueCustomerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _systemGeneratedCallQueueCriteria</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSystemGeneratedCallQueueCriteria(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _systemGeneratedCallQueueCriteria, new PropertyChangedEventHandler( OnSystemGeneratedCallQueueCriteriaPropertyChanged ), "SystemGeneratedCallQueueCriteria", SystemGeneratedCallQueueAssignmentEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCriteriaId, true, signalRelatedEntity, "SystemGeneratedCallQueueAssignment", resetFKFields, new int[] { (int)SystemGeneratedCallQueueAssignmentFieldIndex.CriteriaId } );		
			_systemGeneratedCallQueueCriteria = null;
		}

		/// <summary> setups the sync logic for member _systemGeneratedCallQueueCriteria</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSystemGeneratedCallQueueCriteria(IEntity2 relatedEntity)
		{
			if(_systemGeneratedCallQueueCriteria!=relatedEntity)
			{
				DesetupSyncSystemGeneratedCallQueueCriteria(true, true);
				_systemGeneratedCallQueueCriteria = (SystemGeneratedCallQueueCriteriaEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _systemGeneratedCallQueueCriteria, new PropertyChangedEventHandler( OnSystemGeneratedCallQueueCriteriaPropertyChanged ), "SystemGeneratedCallQueueCriteria", SystemGeneratedCallQueueAssignmentEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCriteriaId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSystemGeneratedCallQueueCriteriaPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this SystemGeneratedCallQueueAssignmentEntity</param>
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
		public  static SystemGeneratedCallQueueAssignmentRelations Relations
		{
			get	{ return new SystemGeneratedCallQueueAssignmentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueue
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueue")[0], (int)Falcon.Data.EntityType.SystemGeneratedCallQueueAssignmentEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, null, null, "CallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomer")[0], (int)Falcon.Data.EntityType.SystemGeneratedCallQueueAssignmentEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, null, null, "CallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SystemGeneratedCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemGeneratedCallQueueCriteria
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory))),
					(IEntityRelation)GetRelationsForField("SystemGeneratedCallQueueCriteria")[0], (int)Falcon.Data.EntityType.SystemGeneratedCallQueueAssignmentEntity, (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, 0, null, null, null, null, "SystemGeneratedCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return SystemGeneratedCallQueueAssignmentEntity.CustomProperties;}
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
			get { return SystemGeneratedCallQueueAssignmentEntity.FieldsCustomProperties;}
		}

		/// <summary> The CallQueueCustomerId property of the Entity SystemGeneratedCallQueueAssignment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueAssignment"."CallQueueCustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 CallQueueCustomerId
		{
			get { return (System.Int64)GetValue((int)SystemGeneratedCallQueueAssignmentFieldIndex.CallQueueCustomerId, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueAssignmentFieldIndex.CallQueueCustomerId, value); }
		}

		/// <summary> The CallQueueId property of the Entity SystemGeneratedCallQueueAssignment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueAssignment"."CallQueueId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 CallQueueId
		{
			get { return (System.Int64)GetValue((int)SystemGeneratedCallQueueAssignmentFieldIndex.CallQueueId, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueAssignmentFieldIndex.CallQueueId, value); }
		}

		/// <summary> The CriteriaId property of the Entity SystemGeneratedCallQueueAssignment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSystemGeneratedCallQueueAssignment"."CriteriaId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 CriteriaId
		{
			get { return (System.Int64)GetValue((int)SystemGeneratedCallQueueAssignmentFieldIndex.CriteriaId, true); }
			set	{ SetValue((int)SystemGeneratedCallQueueAssignmentFieldIndex.CriteriaId, value); }
		}



		/// <summary> Gets / sets related entity of type 'CallQueueEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallQueueEntity CallQueue
		{
			get
			{
				return _callQueue;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCallQueue(value);
				}
				else
				{
					if(value==null)
					{
						if(_callQueue != null)
						{
							_callQueue.UnsetRelatedEntity(this, "SystemGeneratedCallQueueAssignment");
						}
					}
					else
					{
						if(_callQueue!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SystemGeneratedCallQueueAssignment");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CallQueueCustomerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallQueueCustomerEntity CallQueueCustomer
		{
			get
			{
				return _callQueueCustomer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCallQueueCustomer(value);
				}
				else
				{
					if(value==null)
					{
						if(_callQueueCustomer != null)
						{
							_callQueueCustomer.UnsetRelatedEntity(this, "SystemGeneratedCallQueueAssignment");
						}
					}
					else
					{
						if(_callQueueCustomer!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SystemGeneratedCallQueueAssignment");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'SystemGeneratedCallQueueCriteriaEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual SystemGeneratedCallQueueCriteriaEntity SystemGeneratedCallQueueCriteria
		{
			get
			{
				return _systemGeneratedCallQueueCriteria;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncSystemGeneratedCallQueueCriteria(value);
				}
				else
				{
					if(value==null)
					{
						if(_systemGeneratedCallQueueCriteria != null)
						{
							_systemGeneratedCallQueueCriteria.UnsetRelatedEntity(this, "SystemGeneratedCallQueueAssignment");
						}
					}
					else
					{
						if(_systemGeneratedCallQueueCriteria!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SystemGeneratedCallQueueAssignment");
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
			get { return (int)Falcon.Data.EntityType.SystemGeneratedCallQueueAssignmentEntity; }
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