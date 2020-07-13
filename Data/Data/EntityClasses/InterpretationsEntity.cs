﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:26 AM
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
using HealthYes.Data;
using HealthYes.Data.HelperClasses;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'Interpretations'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class InterpretationsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<InterpretationDetailsEntity> _interpretationDetails;
		private EntityCollection<InterpretationNotesEntity> _interpretationNotes;
		private EntityCollection<TestParametersEntity> _testParametersCollectionViaInterpretationDetails;
		private CustomerEventTestsEntity _customerEventTests;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerEventTests</summary>
			public static readonly string CustomerEventTests = "CustomerEventTests";
			/// <summary>Member name InterpretationDetails</summary>
			public static readonly string InterpretationDetails = "InterpretationDetails";
			/// <summary>Member name InterpretationNotes</summary>
			public static readonly string InterpretationNotes = "InterpretationNotes";
			/// <summary>Member name TestParametersCollectionViaInterpretationDetails</summary>
			public static readonly string TestParametersCollectionViaInterpretationDetails = "TestParametersCollectionViaInterpretationDetails";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static InterpretationsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public InterpretationsEntity():base("InterpretationsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public InterpretationsEntity(IEntityFields2 fields):base("InterpretationsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this InterpretationsEntity</param>
		public InterpretationsEntity(IValidator validator):base("InterpretationsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="interpretationId">PK value for Interpretations which data should be fetched into this Interpretations object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InterpretationsEntity(System.Int64 interpretationId):base("InterpretationsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.InterpretationId = interpretationId;
		}

		/// <summary> CTor</summary>
		/// <param name="interpretationId">PK value for Interpretations which data should be fetched into this Interpretations object</param>
		/// <param name="validator">The custom validator object for this InterpretationsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public InterpretationsEntity(System.Int64 interpretationId, IValidator validator):base("InterpretationsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.InterpretationId = interpretationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected InterpretationsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_interpretationDetails = (EntityCollection<InterpretationDetailsEntity>)info.GetValue("_interpretationDetails", typeof(EntityCollection<InterpretationDetailsEntity>));
				_interpretationNotes = (EntityCollection<InterpretationNotesEntity>)info.GetValue("_interpretationNotes", typeof(EntityCollection<InterpretationNotesEntity>));
				_testParametersCollectionViaInterpretationDetails = (EntityCollection<TestParametersEntity>)info.GetValue("_testParametersCollectionViaInterpretationDetails", typeof(EntityCollection<TestParametersEntity>));
				_customerEventTests = (CustomerEventTestsEntity)info.GetValue("_customerEventTests", typeof(CustomerEventTestsEntity));
				if(_customerEventTests!=null)
				{
					_customerEventTests.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((InterpretationsFieldIndex)fieldIndex)
			{
				case InterpretationsFieldIndex.CustomerEventTestId:
					DesetupSyncCustomerEventTests(true, false);
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
				case "CustomerEventTests":
					this.CustomerEventTests = (CustomerEventTestsEntity)entity;
					break;
				case "InterpretationDetails":
					this.InterpretationDetails.Add((InterpretationDetailsEntity)entity);
					break;
				case "InterpretationNotes":
					this.InterpretationNotes.Add((InterpretationNotesEntity)entity);
					break;
				case "TestParametersCollectionViaInterpretationDetails":
					this.TestParametersCollectionViaInterpretationDetails.IsReadOnly = false;
					this.TestParametersCollectionViaInterpretationDetails.Add((TestParametersEntity)entity);
					this.TestParametersCollectionViaInterpretationDetails.IsReadOnly = true;
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
			return InterpretationsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerEventTests":
					toReturn.Add(InterpretationsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId);
					break;
				case "InterpretationDetails":
					toReturn.Add(InterpretationsEntity.Relations.InterpretationDetailsEntityUsingInterpretationId);
					break;
				case "InterpretationNotes":
					toReturn.Add(InterpretationsEntity.Relations.InterpretationNotesEntityUsingInterpretationId);
					break;
				case "TestParametersCollectionViaInterpretationDetails":
					toReturn.Add(InterpretationsEntity.Relations.InterpretationDetailsEntityUsingInterpretationId, "InterpretationsEntity__", "InterpretationDetails_", JoinHint.None);
					toReturn.Add(InterpretationDetailsEntity.Relations.TestParametersEntityUsingTestParameterId, "InterpretationDetails_", string.Empty, JoinHint.None);
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
				case "CustomerEventTests":
					SetupSyncCustomerEventTests(relatedEntity);
					break;
				case "InterpretationDetails":
					this.InterpretationDetails.Add((InterpretationDetailsEntity)relatedEntity);
					break;
				case "InterpretationNotes":
					this.InterpretationNotes.Add((InterpretationNotesEntity)relatedEntity);
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
				case "CustomerEventTests":
					DesetupSyncCustomerEventTests(false, true);
					break;
				case "InterpretationDetails":
					base.PerformRelatedEntityRemoval(this.InterpretationDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "InterpretationNotes":
					base.PerformRelatedEntityRemoval(this.InterpretationNotes, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_customerEventTests!=null)
			{
				toReturn.Add(_customerEventTests);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.InterpretationDetails);
			toReturn.Add(this.InterpretationNotes);

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
				info.AddValue("_interpretationDetails", ((_interpretationDetails!=null) && (_interpretationDetails.Count>0) && !this.MarkedForDeletion)?_interpretationDetails:null);
				info.AddValue("_interpretationNotes", ((_interpretationNotes!=null) && (_interpretationNotes.Count>0) && !this.MarkedForDeletion)?_interpretationNotes:null);
				info.AddValue("_testParametersCollectionViaInterpretationDetails", ((_testParametersCollectionViaInterpretationDetails!=null) && (_testParametersCollectionViaInterpretationDetails.Count>0) && !this.MarkedForDeletion)?_testParametersCollectionViaInterpretationDetails:null);
				info.AddValue("_customerEventTests", (!this.MarkedForDeletion?_customerEventTests:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(InterpretationsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(InterpretationsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new InterpretationsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InterpretationDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInterpretationDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InterpretationDetailsFields.InterpretationId, null, ComparisonOperator.Equal, this.InterpretationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InterpretationNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInterpretationNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InterpretationNotesFields.InterpretationId, null, ComparisonOperator.Equal, this.InterpretationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestParameters' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestParametersCollectionViaInterpretationDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestParametersCollectionViaInterpretationDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InterpretationsFields.InterpretationId, null, ComparisonOperator.Equal, this.InterpretationId, "InterpretationsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerEventTests' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTests()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestsFields.CustomerEventTestId, null, ComparisonOperator.Equal, this.CustomerEventTestId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.InterpretationsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(InterpretationsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._interpretationDetails);
			collectionsQueue.Enqueue(this._interpretationNotes);
			collectionsQueue.Enqueue(this._testParametersCollectionViaInterpretationDetails);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._interpretationDetails = (EntityCollection<InterpretationDetailsEntity>) collectionsQueue.Dequeue();
			this._interpretationNotes = (EntityCollection<InterpretationNotesEntity>) collectionsQueue.Dequeue();
			this._testParametersCollectionViaInterpretationDetails = (EntityCollection<TestParametersEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._interpretationDetails != null)
			{
				return true;
			}
			if (this._interpretationNotes != null)
			{
				return true;
			}
			if (this._testParametersCollectionViaInterpretationDetails != null)
			{
				return true;
			}
			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InterpretationDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InterpretationDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InterpretationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InterpretationNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestParametersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestParametersEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CustomerEventTests", _customerEventTests);
			toReturn.Add("InterpretationDetails", _interpretationDetails);
			toReturn.Add("InterpretationNotes", _interpretationNotes);
			toReturn.Add("TestParametersCollectionViaInterpretationDetails", _testParametersCollectionViaInterpretationDetails);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_interpretationDetails!=null)
			{
				_interpretationDetails.ActiveContext = base.ActiveContext;
			}
			if(_interpretationNotes!=null)
			{
				_interpretationNotes.ActiveContext = base.ActiveContext;
			}
			if(_testParametersCollectionViaInterpretationDetails!=null)
			{
				_testParametersCollectionViaInterpretationDetails.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTests!=null)
			{
				_customerEventTests.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_interpretationDetails = null;
			_interpretationNotes = null;
			_testParametersCollectionViaInterpretationDetails = null;
			_customerEventTests = null;

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

			_fieldsCustomProperties.Add("InterpretationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InterpretedById", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerEventTests</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventTests(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", InterpretationsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, signalRelatedEntity, "Interpretations", resetFKFields, new int[] { (int)InterpretationsFieldIndex.CustomerEventTestId } );		
			_customerEventTests = null;
		}

		/// <summary> setups the sync logic for member _customerEventTests</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerEventTests(IEntity2 relatedEntity)
		{
			if(_customerEventTests!=relatedEntity)
			{
				DesetupSyncCustomerEventTests(true, true);
				_customerEventTests = (CustomerEventTestsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerEventTests, new PropertyChangedEventHandler( OnCustomerEventTestsPropertyChanged ), "CustomerEventTests", InterpretationsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerEventTestsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this InterpretationsEntity</param>
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
		public  static InterpretationsRelations Relations
		{
			get	{ return new InterpretationsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InterpretationDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInterpretationDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InterpretationDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InterpretationDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("InterpretationDetails")[0], (int)HealthYes.Data.EntityType.InterpretationsEntity, (int)HealthYes.Data.EntityType.InterpretationDetailsEntity, 0, null, null, null, null, "InterpretationDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InterpretationNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInterpretationNotes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InterpretationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InterpretationNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("InterpretationNotes")[0], (int)HealthYes.Data.EntityType.InterpretationsEntity, (int)HealthYes.Data.EntityType.InterpretationNotesEntity, 0, null, null, null, null, "InterpretationNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestParameters' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestParametersCollectionViaInterpretationDetails
		{
			get
			{
				IEntityRelation intermediateRelation = InterpretationsEntity.Relations.InterpretationDetailsEntityUsingInterpretationId;
				intermediateRelation.SetAliases(string.Empty, "InterpretationDetails_");
				return new PrefetchPathElement2(new EntityCollection<TestParametersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestParametersEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.InterpretationsEntity, (int)HealthYes.Data.EntityType.TestParametersEntity, 0, null, null, GetRelationsForField("TestParametersCollectionViaInterpretationDetails"), null, "TestParametersCollectionViaInterpretationDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTests
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTests")[0], (int)HealthYes.Data.EntityType.InterpretationsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, null, null, "CustomerEventTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return InterpretationsEntity.CustomProperties;}
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
			get { return InterpretationsEntity.FieldsCustomProperties;}
		}

		/// <summary> The InterpretationId property of the Entity Interpretations<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblInterpretations"."InterpretationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 InterpretationId
		{
			get { return (System.Int64)GetValue((int)InterpretationsFieldIndex.InterpretationId, true); }
			set	{ SetValue((int)InterpretationsFieldIndex.InterpretationId, value); }
		}

		/// <summary> The InterpretedById property of the Entity Interpretations<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblInterpretations"."InterpretedByID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 InterpretedById
		{
			get { return (System.Int64)GetValue((int)InterpretationsFieldIndex.InterpretedById, true); }
			set	{ SetValue((int)InterpretationsFieldIndex.InterpretedById, value); }
		}

		/// <summary> The DateCreated property of the Entity Interpretations<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblInterpretations"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)InterpretationsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)InterpretationsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Interpretations<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblInterpretations"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)InterpretationsFieldIndex.DateModified, true); }
			set	{ SetValue((int)InterpretationsFieldIndex.DateModified, value); }
		}

		/// <summary> The CustomerEventTestId property of the Entity Interpretations<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblInterpretations"."CustomerEventTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventTestId
		{
			get { return (System.Int64)GetValue((int)InterpretationsFieldIndex.CustomerEventTestId, true); }
			set	{ SetValue((int)InterpretationsFieldIndex.CustomerEventTestId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InterpretationDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InterpretationDetailsEntity))]
		public virtual EntityCollection<InterpretationDetailsEntity> InterpretationDetails
		{
			get
			{
				if(_interpretationDetails==null)
				{
					_interpretationDetails = new EntityCollection<InterpretationDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InterpretationDetailsEntityFactory)));
					_interpretationDetails.SetContainingEntityInfo(this, "Interpretations");
				}
				return _interpretationDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InterpretationNotesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InterpretationNotesEntity))]
		public virtual EntityCollection<InterpretationNotesEntity> InterpretationNotes
		{
			get
			{
				if(_interpretationNotes==null)
				{
					_interpretationNotes = new EntityCollection<InterpretationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InterpretationNotesEntityFactory)));
					_interpretationNotes.SetContainingEntityInfo(this, "Interpretations");
				}
				return _interpretationNotes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestParametersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestParametersEntity))]
		public virtual EntityCollection<TestParametersEntity> TestParametersCollectionViaInterpretationDetails
		{
			get
			{
				if(_testParametersCollectionViaInterpretationDetails==null)
				{
					_testParametersCollectionViaInterpretationDetails = new EntityCollection<TestParametersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestParametersEntityFactory)));
					_testParametersCollectionViaInterpretationDetails.IsReadOnly=true;
				}
				return _testParametersCollectionViaInterpretationDetails;
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerEventTestsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerEventTestsEntity CustomerEventTests
		{
			get
			{
				return _customerEventTests;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerEventTests(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerEventTests != null)
						{
							_customerEventTests.UnsetRelatedEntity(this, "Interpretations");
						}
					}
					else
					{
						if(_customerEventTests!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Interpretations");
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
		
		/// <summary>Returns the HealthYes.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)HealthYes.Data.EntityType.InterpretationsEntity; }
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
