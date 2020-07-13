///////////////////////////////////////////////////////////////
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
	/// Entity class which represents the entity 'CustomerChaseChannel'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerChaseChannelEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private ChaseChannelLevelEntity _chaseChannelLevel;
		private ChaseOutboundEntity _chaseOutbound;
		private CustomerProfileEntity _customerProfile;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ChaseChannelLevel</summary>
			public static readonly string ChaseChannelLevel = "ChaseChannelLevel";
			/// <summary>Member name ChaseOutbound</summary>
			public static readonly string ChaseOutbound = "ChaseOutbound";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerChaseChannelEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerChaseChannelEntity():base("CustomerChaseChannelEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerChaseChannelEntity(IEntityFields2 fields):base("CustomerChaseChannelEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerChaseChannelEntity</param>
		public CustomerChaseChannelEntity(IValidator validator):base("CustomerChaseChannelEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="chaseOutboundId">PK value for CustomerChaseChannel which data should be fetched into this CustomerChaseChannel object</param>
		/// <param name="chaseChannelLevelId">PK value for CustomerChaseChannel which data should be fetched into this CustomerChaseChannel object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerChaseChannelEntity(System.Int64 chaseOutboundId, System.Int64 chaseChannelLevelId):base("CustomerChaseChannelEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ChaseOutboundId = chaseOutboundId;
			this.ChaseChannelLevelId = chaseChannelLevelId;
		}

		/// <summary> CTor</summary>
		/// <param name="chaseOutboundId">PK value for CustomerChaseChannel which data should be fetched into this CustomerChaseChannel object</param>
		/// <param name="chaseChannelLevelId">PK value for CustomerChaseChannel which data should be fetched into this CustomerChaseChannel object</param>
		/// <param name="validator">The custom validator object for this CustomerChaseChannelEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerChaseChannelEntity(System.Int64 chaseOutboundId, System.Int64 chaseChannelLevelId, IValidator validator):base("CustomerChaseChannelEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ChaseOutboundId = chaseOutboundId;
			this.ChaseChannelLevelId = chaseChannelLevelId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerChaseChannelEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_chaseChannelLevel = (ChaseChannelLevelEntity)info.GetValue("_chaseChannelLevel", typeof(ChaseChannelLevelEntity));
				if(_chaseChannelLevel!=null)
				{
					_chaseChannelLevel.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_chaseOutbound = (ChaseOutboundEntity)info.GetValue("_chaseOutbound", typeof(ChaseOutboundEntity));
				if(_chaseOutbound!=null)
				{
					_chaseOutbound.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerChaseChannelFieldIndex)fieldIndex)
			{
				case CustomerChaseChannelFieldIndex.ChaseOutboundId:
					DesetupSyncChaseOutbound(true, false);
					break;
				case CustomerChaseChannelFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case CustomerChaseChannelFieldIndex.ChaseChannelLevelId:
					DesetupSyncChaseChannelLevel(true, false);
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
				case "ChaseChannelLevel":
					this.ChaseChannelLevel = (ChaseChannelLevelEntity)entity;
					break;
				case "ChaseOutbound":
					this.ChaseOutbound = (ChaseOutboundEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
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
			return CustomerChaseChannelEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ChaseChannelLevel":
					toReturn.Add(CustomerChaseChannelEntity.Relations.ChaseChannelLevelEntityUsingChaseChannelLevelId);
					break;
				case "ChaseOutbound":
					toReturn.Add(CustomerChaseChannelEntity.Relations.ChaseOutboundEntityUsingChaseOutboundId);
					break;
				case "CustomerProfile":
					toReturn.Add(CustomerChaseChannelEntity.Relations.CustomerProfileEntityUsingCustomerId);
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
				case "ChaseChannelLevel":
					SetupSyncChaseChannelLevel(relatedEntity);
					break;
				case "ChaseOutbound":
					SetupSyncChaseOutbound(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
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
				case "ChaseChannelLevel":
					DesetupSyncChaseChannelLevel(false, true);
					break;
				case "ChaseOutbound":
					DesetupSyncChaseOutbound(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
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
			if(_chaseChannelLevel!=null)
			{
				toReturn.Add(_chaseChannelLevel);
			}
			if(_chaseOutbound!=null)
			{
				toReturn.Add(_chaseOutbound);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
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


				info.AddValue("_chaseChannelLevel", (!this.MarkedForDeletion?_chaseChannelLevel:null));
				info.AddValue("_chaseOutbound", (!this.MarkedForDeletion?_chaseOutbound:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CustomerChaseChannelFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerChaseChannelFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerChaseChannelRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ChaseChannelLevel' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseChannelLevel()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseChannelLevelFields.ChaseChannelLevelId, null, ComparisonOperator.Equal, this.ChaseChannelLevelId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ChaseOutbound' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseOutbound()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseOutboundFields.Id, null, ComparisonOperator.Equal, this.ChaseOutboundId));
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

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerChaseChannelEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseChannelEntityFactory));
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
			toReturn.Add("ChaseChannelLevel", _chaseChannelLevel);
			toReturn.Add("ChaseOutbound", _chaseOutbound);
			toReturn.Add("CustomerProfile", _customerProfile);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_chaseChannelLevel!=null)
			{
				_chaseChannelLevel.ActiveContext = base.ActiveContext;
			}
			if(_chaseOutbound!=null)
			{
				_chaseOutbound.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_chaseChannelLevel = null;
			_chaseOutbound = null;
			_customerProfile = null;

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

			_fieldsCustomProperties.Add("ChaseOutboundId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChaseChannelLevelId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _chaseChannelLevel</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncChaseChannelLevel(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _chaseChannelLevel, new PropertyChangedEventHandler( OnChaseChannelLevelPropertyChanged ), "ChaseChannelLevel", CustomerChaseChannelEntity.Relations.ChaseChannelLevelEntityUsingChaseChannelLevelId, true, signalRelatedEntity, "CustomerChaseChannel", resetFKFields, new int[] { (int)CustomerChaseChannelFieldIndex.ChaseChannelLevelId } );		
			_chaseChannelLevel = null;
		}

		/// <summary> setups the sync logic for member _chaseChannelLevel</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncChaseChannelLevel(IEntity2 relatedEntity)
		{
			if(_chaseChannelLevel!=relatedEntity)
			{
				DesetupSyncChaseChannelLevel(true, true);
				_chaseChannelLevel = (ChaseChannelLevelEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _chaseChannelLevel, new PropertyChangedEventHandler( OnChaseChannelLevelPropertyChanged ), "ChaseChannelLevel", CustomerChaseChannelEntity.Relations.ChaseChannelLevelEntityUsingChaseChannelLevelId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnChaseChannelLevelPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _chaseOutbound</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncChaseOutbound(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _chaseOutbound, new PropertyChangedEventHandler( OnChaseOutboundPropertyChanged ), "ChaseOutbound", CustomerChaseChannelEntity.Relations.ChaseOutboundEntityUsingChaseOutboundId, true, signalRelatedEntity, "CustomerChaseChannel", resetFKFields, new int[] { (int)CustomerChaseChannelFieldIndex.ChaseOutboundId } );		
			_chaseOutbound = null;
		}

		/// <summary> setups the sync logic for member _chaseOutbound</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncChaseOutbound(IEntity2 relatedEntity)
		{
			if(_chaseOutbound!=relatedEntity)
			{
				DesetupSyncChaseOutbound(true, true);
				_chaseOutbound = (ChaseOutboundEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _chaseOutbound, new PropertyChangedEventHandler( OnChaseOutboundPropertyChanged ), "ChaseOutbound", CustomerChaseChannelEntity.Relations.ChaseOutboundEntityUsingChaseOutboundId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnChaseOutboundPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CustomerChaseChannelEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "CustomerChaseChannel", resetFKFields, new int[] { (int)CustomerChaseChannelFieldIndex.CustomerId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CustomerChaseChannelEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CustomerChaseChannelEntity</param>
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
		public  static CustomerChaseChannelRelations Relations
		{
			get	{ return new CustomerChaseChannelRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseChannelLevel' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseChannelLevel
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ChaseChannelLevelEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaseChannelLevel")[0], (int)Falcon.Data.EntityType.CustomerChaseChannelEntity, (int)Falcon.Data.EntityType.ChaseChannelLevelEntity, 0, null, null, null, null, "ChaseChannelLevel", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseOutbound' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseOutbound
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaseOutbound")[0], (int)Falcon.Data.EntityType.CustomerChaseChannelEntity, (int)Falcon.Data.EntityType.ChaseOutboundEntity, 0, null, null, null, null, "ChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.CustomerChaseChannelEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerChaseChannelEntity.CustomProperties;}
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
			get { return CustomerChaseChannelEntity.FieldsCustomProperties;}
		}

		/// <summary> The ChaseOutboundId property of the Entity CustomerChaseChannel<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerChaseChannel"."ChaseOutboundId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 ChaseOutboundId
		{
			get { return (System.Int64)GetValue((int)CustomerChaseChannelFieldIndex.ChaseOutboundId, true); }
			set	{ SetValue((int)CustomerChaseChannelFieldIndex.ChaseOutboundId, value); }
		}

		/// <summary> The CustomerId property of the Entity CustomerChaseChannel<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerChaseChannel"."CustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)CustomerChaseChannelFieldIndex.CustomerId, true); }
			set	{ SetValue((int)CustomerChaseChannelFieldIndex.CustomerId, value); }
		}

		/// <summary> The ChaseChannelLevelId property of the Entity CustomerChaseChannel<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerChaseChannel"."ChaseChannelLevelId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 ChaseChannelLevelId
		{
			get { return (System.Int64)GetValue((int)CustomerChaseChannelFieldIndex.ChaseChannelLevelId, true); }
			set	{ SetValue((int)CustomerChaseChannelFieldIndex.ChaseChannelLevelId, value); }
		}



		/// <summary> Gets / sets related entity of type 'ChaseChannelLevelEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ChaseChannelLevelEntity ChaseChannelLevel
		{
			get
			{
				return _chaseChannelLevel;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncChaseChannelLevel(value);
				}
				else
				{
					if(value==null)
					{
						if(_chaseChannelLevel != null)
						{
							_chaseChannelLevel.UnsetRelatedEntity(this, "CustomerChaseChannel");
						}
					}
					else
					{
						if(_chaseChannelLevel!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerChaseChannel");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ChaseOutboundEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ChaseOutboundEntity ChaseOutbound
		{
			get
			{
				return _chaseOutbound;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncChaseOutbound(value);
				}
				else
				{
					if(value==null)
					{
						if(_chaseOutbound != null)
						{
							_chaseOutbound.UnsetRelatedEntity(this, "CustomerChaseChannel");
						}
					}
					else
					{
						if(_chaseOutbound!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerChaseChannel");
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
							_customerProfile.UnsetRelatedEntity(this, "CustomerChaseChannel");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerChaseChannel");
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
			get { return (int)Falcon.Data.EntityType.CustomerChaseChannelEntity; }
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
