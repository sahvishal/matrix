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
	/// Entity class which represents the entity 'CustomerEventTestIncidentalFindingDetail'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerEventTestIncidentalFindingDetailEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CustomerEventTestIncidentalFindingEntity _customerEventTestIncidentalFinding;
		private IncidentalFindingReadingGroupItemEntity _incidentalFindingReadingGroupItem;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerEventTestIncidentalFinding</summary>
			public static readonly string CustomerEventTestIncidentalFinding = "CustomerEventTestIncidentalFinding";
			/// <summary>Member name IncidentalFindingReadingGroupItem</summary>
			public static readonly string IncidentalFindingReadingGroupItem = "IncidentalFindingReadingGroupItem";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerEventTestIncidentalFindingDetailEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerEventTestIncidentalFindingDetailEntity():base("CustomerEventTestIncidentalFindingDetailEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerEventTestIncidentalFindingDetailEntity(IEntityFields2 fields):base("CustomerEventTestIncidentalFindingDetailEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerEventTestIncidentalFindingDetailEntity</param>
		public CustomerEventTestIncidentalFindingDetailEntity(IValidator validator):base("CustomerEventTestIncidentalFindingDetailEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="customerEventTestIncidentalFindingDetailId">PK value for CustomerEventTestIncidentalFindingDetail which data should be fetched into this CustomerEventTestIncidentalFindingDetail object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerEventTestIncidentalFindingDetailEntity(System.Int64 customerEventTestIncidentalFindingDetailId):base("CustomerEventTestIncidentalFindingDetailEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CustomerEventTestIncidentalFindingDetailId = customerEventTestIncidentalFindingDetailId;
		}

		/// <summary> CTor</summary>
		/// <param name="customerEventTestIncidentalFindingDetailId">PK value for CustomerEventTestIncidentalFindingDetail which data should be fetched into this CustomerEventTestIncidentalFindingDetail object</param>
		/// <param name="validator">The custom validator object for this CustomerEventTestIncidentalFindingDetailEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerEventTestIncidentalFindingDetailEntity(System.Int64 customerEventTestIncidentalFindingDetailId, IValidator validator):base("CustomerEventTestIncidentalFindingDetailEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CustomerEventTestIncidentalFindingDetailId = customerEventTestIncidentalFindingDetailId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerEventTestIncidentalFindingDetailEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_customerEventTestIncidentalFinding = (CustomerEventTestIncidentalFindingEntity)info.GetValue("_customerEventTestIncidentalFinding", typeof(CustomerEventTestIncidentalFindingEntity));
				if(_customerEventTestIncidentalFinding!=null)
				{
					_customerEventTestIncidentalFinding.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_incidentalFindingReadingGroupItem = (IncidentalFindingReadingGroupItemEntity)info.GetValue("_incidentalFindingReadingGroupItem", typeof(IncidentalFindingReadingGroupItemEntity));
				if(_incidentalFindingReadingGroupItem!=null)
				{
					_incidentalFindingReadingGroupItem.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerEventTestIncidentalFindingDetailFieldIndex)fieldIndex)
			{
				case CustomerEventTestIncidentalFindingDetailFieldIndex.CustomerEventTestIncidentalFindingId:
					DesetupSyncCustomerEventTestIncidentalFinding(true, false);
					break;
				case CustomerEventTestIncidentalFindingDetailFieldIndex.GroupItemId:
					DesetupSyncIncidentalFindingReadingGroupItem(true, false);
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
				case "CustomerEventTestIncidentalFinding":
					this.CustomerEventTestIncidentalFinding = (CustomerEventTestIncidentalFindingEntity)entity;
					break;
				case "IncidentalFindingReadingGroupItem":
					this.IncidentalFindingReadingGroupItem = (IncidentalFindingReadingGroupItemEntity)entity;
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
			return CustomerEventTestIncidentalFindingDetailEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerEventTestIncidentalFinding":
					toReturn.Add(CustomerEventTestIncidentalFindingDetailEntity.Relations.CustomerEventTestIncidentalFindingEntityUsingCustomerEventTestIncidentalFindingId);
					break;
				case "IncidentalFindingReadingGroupItem":
					toReturn.Add(CustomerEventTestIncidentalFindingDetailEntity.Relations.IncidentalFindingReadingGroupItemEntityUsingGroupItemId);
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
				case "CustomerEventTestIncidentalFinding":
					SetupSyncCustomerEventTestIncidentalFinding(relatedEntity);
					break;
				case "IncidentalFindingReadingGroupItem":
					SetupSyncIncidentalFindingReadingGroupItem(relatedEntity);
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
				case "CustomerEventTestIncidentalFinding":
					DesetupSyncCustomerEventTestIncidentalFinding(false, true);
					break;
				case "IncidentalFindingReadingGroupItem":
					DesetupSyncIncidentalFindingReadingGroupItem(false, true);
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
			if(_customerEventTestIncidentalFinding!=null)
			{
				toReturn.Add(_customerEventTestIncidentalFinding);
			}
			if(_incidentalFindingReadingGroupItem!=null)
			{
				toReturn.Add(_incidentalFindingReadingGroupItem);
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


				info.AddValue("_customerEventTestIncidentalFinding", (!this.MarkedForDeletion?_customerEventTestIncidentalFinding:null));
				info.AddValue("_incidentalFindingReadingGroupItem", (!this.MarkedForDeletion?_incidentalFindingReadingGroupItem:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CustomerEventTestIncidentalFindingDetailFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerEventTestIncidentalFindingDetailFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerEventTestIncidentalFindingDetailRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerEventTestIncidentalFinding' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestIncidentalFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestIncidentalFindingFields.CustomerEventTestIncidentalFindingId, null, ComparisonOperator.Equal, this.CustomerEventTestIncidentalFindingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'IncidentalFindingReadingGroupItem' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingReadingGroupItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingReadingGroupItemFields.GroupItemId, null, ComparisonOperator.Equal, this.GroupItemId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerEventTestIncidentalFindingDetailEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingDetailEntityFactory));
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
			toReturn.Add("CustomerEventTestIncidentalFinding", _customerEventTestIncidentalFinding);
			toReturn.Add("IncidentalFindingReadingGroupItem", _incidentalFindingReadingGroupItem);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_customerEventTestIncidentalFinding!=null)
			{
				_customerEventTestIncidentalFinding.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingReadingGroupItem!=null)
			{
				_incidentalFindingReadingGroupItem.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_customerEventTestIncidentalFinding = null;
			_incidentalFindingReadingGroupItem = null;

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

			_fieldsCustomProperties.Add("CustomerEventTestIncidentalFindingDetailId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventTestIncidentalFindingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupItemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Value", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Location", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerEventTestIncidentalFinding</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventTestIncidentalFinding(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventTestIncidentalFinding, new PropertyChangedEventHandler( OnCustomerEventTestIncidentalFindingPropertyChanged ), "CustomerEventTestIncidentalFinding", CustomerEventTestIncidentalFindingDetailEntity.Relations.CustomerEventTestIncidentalFindingEntityUsingCustomerEventTestIncidentalFindingId, true, signalRelatedEntity, "CustomerEventTestIncidentalFindingDetail", resetFKFields, new int[] { (int)CustomerEventTestIncidentalFindingDetailFieldIndex.CustomerEventTestIncidentalFindingId } );		
			_customerEventTestIncidentalFinding = null;
		}

		/// <summary> setups the sync logic for member _customerEventTestIncidentalFinding</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerEventTestIncidentalFinding(IEntity2 relatedEntity)
		{
			if(_customerEventTestIncidentalFinding!=relatedEntity)
			{
				DesetupSyncCustomerEventTestIncidentalFinding(true, true);
				_customerEventTestIncidentalFinding = (CustomerEventTestIncidentalFindingEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerEventTestIncidentalFinding, new PropertyChangedEventHandler( OnCustomerEventTestIncidentalFindingPropertyChanged ), "CustomerEventTestIncidentalFinding", CustomerEventTestIncidentalFindingDetailEntity.Relations.CustomerEventTestIncidentalFindingEntityUsingCustomerEventTestIncidentalFindingId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerEventTestIncidentalFindingPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _incidentalFindingReadingGroupItem</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncIncidentalFindingReadingGroupItem(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _incidentalFindingReadingGroupItem, new PropertyChangedEventHandler( OnIncidentalFindingReadingGroupItemPropertyChanged ), "IncidentalFindingReadingGroupItem", CustomerEventTestIncidentalFindingDetailEntity.Relations.IncidentalFindingReadingGroupItemEntityUsingGroupItemId, true, signalRelatedEntity, "CustomerEventTestIncidentalFindingDetail", resetFKFields, new int[] { (int)CustomerEventTestIncidentalFindingDetailFieldIndex.GroupItemId } );		
			_incidentalFindingReadingGroupItem = null;
		}

		/// <summary> setups the sync logic for member _incidentalFindingReadingGroupItem</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncIncidentalFindingReadingGroupItem(IEntity2 relatedEntity)
		{
			if(_incidentalFindingReadingGroupItem!=relatedEntity)
			{
				DesetupSyncIncidentalFindingReadingGroupItem(true, true);
				_incidentalFindingReadingGroupItem = (IncidentalFindingReadingGroupItemEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _incidentalFindingReadingGroupItem, new PropertyChangedEventHandler( OnIncidentalFindingReadingGroupItemPropertyChanged ), "IncidentalFindingReadingGroupItem", CustomerEventTestIncidentalFindingDetailEntity.Relations.IncidentalFindingReadingGroupItemEntityUsingGroupItemId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnIncidentalFindingReadingGroupItemPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CustomerEventTestIncidentalFindingDetailEntity</param>
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
		public  static CustomerEventTestIncidentalFindingDetailRelations Relations
		{
			get	{ return new CustomerEventTestIncidentalFindingDetailRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTestIncidentalFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestIncidentalFinding
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTestIncidentalFinding")[0], (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingDetailEntity, (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity, 0, null, null, null, null, "CustomerEventTestIncidentalFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindingReadingGroupItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingReadingGroupItem
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("IncidentalFindingReadingGroupItem")[0], (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingDetailEntity, (int)Falcon.Data.EntityType.IncidentalFindingReadingGroupItemEntity, 0, null, null, null, null, "IncidentalFindingReadingGroupItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerEventTestIncidentalFindingDetailEntity.CustomProperties;}
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
			get { return CustomerEventTestIncidentalFindingDetailEntity.FieldsCustomProperties;}
		}

		/// <summary> The CustomerEventTestIncidentalFindingDetailId property of the Entity CustomerEventTestIncidentalFindingDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFindingDetail"."CustomerEventTestIncidentalFindingDetailId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CustomerEventTestIncidentalFindingDetailId
		{
			get { return (System.Int64)GetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.CustomerEventTestIncidentalFindingDetailId, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.CustomerEventTestIncidentalFindingDetailId, value); }
		}

		/// <summary> The CustomerEventTestIncidentalFindingId property of the Entity CustomerEventTestIncidentalFindingDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFindingDetail"."CustomerEventTestIncidentalFindingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventTestIncidentalFindingId
		{
			get { return (System.Int64)GetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.CustomerEventTestIncidentalFindingId, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.CustomerEventTestIncidentalFindingId, value); }
		}

		/// <summary> The GroupItemId property of the Entity CustomerEventTestIncidentalFindingDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFindingDetail"."GroupItemId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GroupItemId
		{
			get { return (System.Int64)GetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.GroupItemId, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.GroupItemId, value); }
		}

		/// <summary> The Value property of the Entity CustomerEventTestIncidentalFindingDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFindingDetail"."Value"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Value
		{
			get { return (System.String)GetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.Value, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.Value, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity CustomerEventTestIncidentalFindingDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFindingDetail"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.CreatedByOrgRoleUserId, false); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The CreatedOn property of the Entity CustomerEventTestIncidentalFindingDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFindingDetail"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.CreatedOn, false); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.CreatedOn, value); }
		}

		/// <summary> The UpdatedByOrgRoleUserId property of the Entity CustomerEventTestIncidentalFindingDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFindingDetail"."UpdatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UpdatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.UpdatedByOrgRoleUserId, false); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.UpdatedByOrgRoleUserId, value); }
		}

		/// <summary> The UpdatedOn property of the Entity CustomerEventTestIncidentalFindingDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFindingDetail"."UpdatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> UpdatedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.UpdatedOn, false); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.UpdatedOn, value); }
		}

		/// <summary> The Location property of the Entity CustomerEventTestIncidentalFindingDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFindingDetail"."Location"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Location
		{
			get { return (System.Int32)GetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.Location, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingDetailFieldIndex.Location, value); }
		}



		/// <summary> Gets / sets related entity of type 'CustomerEventTestIncidentalFindingEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerEventTestIncidentalFindingEntity CustomerEventTestIncidentalFinding
		{
			get
			{
				return _customerEventTestIncidentalFinding;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerEventTestIncidentalFinding(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerEventTestIncidentalFinding != null)
						{
							_customerEventTestIncidentalFinding.UnsetRelatedEntity(this, "CustomerEventTestIncidentalFindingDetail");
						}
					}
					else
					{
						if(_customerEventTestIncidentalFinding!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerEventTestIncidentalFindingDetail");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'IncidentalFindingReadingGroupItemEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual IncidentalFindingReadingGroupItemEntity IncidentalFindingReadingGroupItem
		{
			get
			{
				return _incidentalFindingReadingGroupItem;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncIncidentalFindingReadingGroupItem(value);
				}
				else
				{
					if(value==null)
					{
						if(_incidentalFindingReadingGroupItem != null)
						{
							_incidentalFindingReadingGroupItem.UnsetRelatedEntity(this, "CustomerEventTestIncidentalFindingDetail");
						}
					}
					else
					{
						if(_incidentalFindingReadingGroupItem!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerEventTestIncidentalFindingDetail");
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
			get { return (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingDetailEntity; }
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
