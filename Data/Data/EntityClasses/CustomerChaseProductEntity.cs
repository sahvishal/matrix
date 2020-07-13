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
	/// Entity class which represents the entity 'CustomerChaseProduct'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerChaseProductEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private ChaseOutboundEntity _chaseOutbound;
		private ChaseProductEntity _chaseProduct;
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
			/// <summary>Member name ChaseOutbound</summary>
			public static readonly string ChaseOutbound = "ChaseOutbound";
			/// <summary>Member name ChaseProduct</summary>
			public static readonly string ChaseProduct = "ChaseProduct";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerChaseProductEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerChaseProductEntity():base("CustomerChaseProductEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerChaseProductEntity(IEntityFields2 fields):base("CustomerChaseProductEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerChaseProductEntity</param>
		public CustomerChaseProductEntity(IValidator validator):base("CustomerChaseProductEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="chaseOutboundId">PK value for CustomerChaseProduct which data should be fetched into this CustomerChaseProduct object</param>
		/// <param name="chaseProductId">PK value for CustomerChaseProduct which data should be fetched into this CustomerChaseProduct object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerChaseProductEntity(System.Int64 chaseOutboundId, System.Int64 chaseProductId):base("CustomerChaseProductEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ChaseOutboundId = chaseOutboundId;
			this.ChaseProductId = chaseProductId;
		}

		/// <summary> CTor</summary>
		/// <param name="chaseOutboundId">PK value for CustomerChaseProduct which data should be fetched into this CustomerChaseProduct object</param>
		/// <param name="chaseProductId">PK value for CustomerChaseProduct which data should be fetched into this CustomerChaseProduct object</param>
		/// <param name="validator">The custom validator object for this CustomerChaseProductEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerChaseProductEntity(System.Int64 chaseOutboundId, System.Int64 chaseProductId, IValidator validator):base("CustomerChaseProductEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ChaseOutboundId = chaseOutboundId;
			this.ChaseProductId = chaseProductId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerChaseProductEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_chaseOutbound = (ChaseOutboundEntity)info.GetValue("_chaseOutbound", typeof(ChaseOutboundEntity));
				if(_chaseOutbound!=null)
				{
					_chaseOutbound.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_chaseProduct = (ChaseProductEntity)info.GetValue("_chaseProduct", typeof(ChaseProductEntity));
				if(_chaseProduct!=null)
				{
					_chaseProduct.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerChaseProductFieldIndex)fieldIndex)
			{
				case CustomerChaseProductFieldIndex.ChaseOutboundId:
					DesetupSyncChaseOutbound(true, false);
					break;
				case CustomerChaseProductFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case CustomerChaseProductFieldIndex.ChaseProductId:
					DesetupSyncChaseProduct(true, false);
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
				case "ChaseOutbound":
					this.ChaseOutbound = (ChaseOutboundEntity)entity;
					break;
				case "ChaseProduct":
					this.ChaseProduct = (ChaseProductEntity)entity;
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
			return CustomerChaseProductEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ChaseOutbound":
					toReturn.Add(CustomerChaseProductEntity.Relations.ChaseOutboundEntityUsingChaseOutboundId);
					break;
				case "ChaseProduct":
					toReturn.Add(CustomerChaseProductEntity.Relations.ChaseProductEntityUsingChaseProductId);
					break;
				case "CustomerProfile":
					toReturn.Add(CustomerChaseProductEntity.Relations.CustomerProfileEntityUsingCustomerId);
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
				case "ChaseOutbound":
					SetupSyncChaseOutbound(relatedEntity);
					break;
				case "ChaseProduct":
					SetupSyncChaseProduct(relatedEntity);
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
				case "ChaseOutbound":
					DesetupSyncChaseOutbound(false, true);
					break;
				case "ChaseProduct":
					DesetupSyncChaseProduct(false, true);
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
			if(_chaseOutbound!=null)
			{
				toReturn.Add(_chaseOutbound);
			}
			if(_chaseProduct!=null)
			{
				toReturn.Add(_chaseProduct);
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


				info.AddValue("_chaseOutbound", (!this.MarkedForDeletion?_chaseOutbound:null));
				info.AddValue("_chaseProduct", (!this.MarkedForDeletion?_chaseProduct:null));
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
		public bool TestOriginalFieldValueForNull(CustomerChaseProductFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerChaseProductFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerChaseProductRelations().GetAllRelations();
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
		/// the related entity of type 'ChaseProduct' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseProduct()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseProductFields.ChaseProductId, null, ComparisonOperator.Equal, this.ChaseProductId));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerChaseProductEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseProductEntityFactory));
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
			toReturn.Add("ChaseOutbound", _chaseOutbound);
			toReturn.Add("ChaseProduct", _chaseProduct);
			toReturn.Add("CustomerProfile", _customerProfile);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_chaseOutbound!=null)
			{
				_chaseOutbound.ActiveContext = base.ActiveContext;
			}
			if(_chaseProduct!=null)
			{
				_chaseProduct.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_chaseOutbound = null;
			_chaseProduct = null;
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

			_fieldsCustomProperties.Add("ChaseProductId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _chaseOutbound</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncChaseOutbound(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _chaseOutbound, new PropertyChangedEventHandler( OnChaseOutboundPropertyChanged ), "ChaseOutbound", CustomerChaseProductEntity.Relations.ChaseOutboundEntityUsingChaseOutboundId, true, signalRelatedEntity, "CustomerChaseProduct", resetFKFields, new int[] { (int)CustomerChaseProductFieldIndex.ChaseOutboundId } );		
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
				base.PerformSetupSyncRelatedEntity( _chaseOutbound, new PropertyChangedEventHandler( OnChaseOutboundPropertyChanged ), "ChaseOutbound", CustomerChaseProductEntity.Relations.ChaseOutboundEntityUsingChaseOutboundId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _chaseProduct</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncChaseProduct(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _chaseProduct, new PropertyChangedEventHandler( OnChaseProductPropertyChanged ), "ChaseProduct", CustomerChaseProductEntity.Relations.ChaseProductEntityUsingChaseProductId, true, signalRelatedEntity, "CustomerChaseProduct", resetFKFields, new int[] { (int)CustomerChaseProductFieldIndex.ChaseProductId } );		
			_chaseProduct = null;
		}

		/// <summary> setups the sync logic for member _chaseProduct</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncChaseProduct(IEntity2 relatedEntity)
		{
			if(_chaseProduct!=relatedEntity)
			{
				DesetupSyncChaseProduct(true, true);
				_chaseProduct = (ChaseProductEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _chaseProduct, new PropertyChangedEventHandler( OnChaseProductPropertyChanged ), "ChaseProduct", CustomerChaseProductEntity.Relations.ChaseProductEntityUsingChaseProductId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnChaseProductPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CustomerChaseProductEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "CustomerChaseProduct", resetFKFields, new int[] { (int)CustomerChaseProductFieldIndex.CustomerId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CustomerChaseProductEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CustomerChaseProductEntity</param>
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
		public  static CustomerChaseProductRelations Relations
		{
			get	{ return new CustomerChaseProductRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseOutbound' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseOutbound
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaseOutbound")[0], (int)Falcon.Data.EntityType.CustomerChaseProductEntity, (int)Falcon.Data.EntityType.ChaseOutboundEntity, 0, null, null, null, null, "ChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseProduct' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseProduct
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ChaseProductEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaseProduct")[0], (int)Falcon.Data.EntityType.CustomerChaseProductEntity, (int)Falcon.Data.EntityType.ChaseProductEntity, 0, null, null, null, null, "ChaseProduct", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.CustomerChaseProductEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerChaseProductEntity.CustomProperties;}
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
			get { return CustomerChaseProductEntity.FieldsCustomProperties;}
		}

		/// <summary> The ChaseOutboundId property of the Entity CustomerChaseProduct<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerChaseProduct"."ChaseOutboundId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 ChaseOutboundId
		{
			get { return (System.Int64)GetValue((int)CustomerChaseProductFieldIndex.ChaseOutboundId, true); }
			set	{ SetValue((int)CustomerChaseProductFieldIndex.ChaseOutboundId, value); }
		}

		/// <summary> The CustomerId property of the Entity CustomerChaseProduct<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerChaseProduct"."CustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)CustomerChaseProductFieldIndex.CustomerId, true); }
			set	{ SetValue((int)CustomerChaseProductFieldIndex.CustomerId, value); }
		}

		/// <summary> The ChaseProductId property of the Entity CustomerChaseProduct<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerChaseProduct"."ChaseProductId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 ChaseProductId
		{
			get { return (System.Int64)GetValue((int)CustomerChaseProductFieldIndex.ChaseProductId, true); }
			set	{ SetValue((int)CustomerChaseProductFieldIndex.ChaseProductId, value); }
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
							_chaseOutbound.UnsetRelatedEntity(this, "CustomerChaseProduct");
						}
					}
					else
					{
						if(_chaseOutbound!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerChaseProduct");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ChaseProductEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ChaseProductEntity ChaseProduct
		{
			get
			{
				return _chaseProduct;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncChaseProduct(value);
				}
				else
				{
					if(value==null)
					{
						if(_chaseProduct != null)
						{
							_chaseProduct.UnsetRelatedEntity(this, "CustomerChaseProduct");
						}
					}
					else
					{
						if(_chaseProduct!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerChaseProduct");
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
							_customerProfile.UnsetRelatedEntity(this, "CustomerChaseProduct");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerChaseProduct");
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
			get { return (int)Falcon.Data.EntityType.CustomerChaseProductEntity; }
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
