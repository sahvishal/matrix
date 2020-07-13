///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:25 AM
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
	/// Entity class which represents the entity 'AsitestIncidentalFindings'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AsitestIncidentalFindingsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private AsitestResultsEntity _asitestResults;
		private IncidentalFindingsEntity _incidentalFindings;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AsitestResults</summary>
			public static readonly string AsitestResults = "AsitestResults";
			/// <summary>Member name IncidentalFindings</summary>
			public static readonly string IncidentalFindings = "IncidentalFindings";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AsitestIncidentalFindingsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AsitestIncidentalFindingsEntity():base("AsitestIncidentalFindingsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AsitestIncidentalFindingsEntity(IEntityFields2 fields):base("AsitestIncidentalFindingsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AsitestIncidentalFindingsEntity</param>
		public AsitestIncidentalFindingsEntity(IValidator validator):base("AsitestIncidentalFindingsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="asitestIncidentalFindingsId">PK value for AsitestIncidentalFindings which data should be fetched into this AsitestIncidentalFindings object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AsitestIncidentalFindingsEntity(System.Int64 asitestIncidentalFindingsId):base("AsitestIncidentalFindingsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AsitestIncidentalFindingsId = asitestIncidentalFindingsId;
		}

		/// <summary> CTor</summary>
		/// <param name="asitestIncidentalFindingsId">PK value for AsitestIncidentalFindings which data should be fetched into this AsitestIncidentalFindings object</param>
		/// <param name="validator">The custom validator object for this AsitestIncidentalFindingsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AsitestIncidentalFindingsEntity(System.Int64 asitestIncidentalFindingsId, IValidator validator):base("AsitestIncidentalFindingsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AsitestIncidentalFindingsId = asitestIncidentalFindingsId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AsitestIncidentalFindingsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_asitestResults = (AsitestResultsEntity)info.GetValue("_asitestResults", typeof(AsitestResultsEntity));
				if(_asitestResults!=null)
				{
					_asitestResults.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_incidentalFindings = (IncidentalFindingsEntity)info.GetValue("_incidentalFindings", typeof(IncidentalFindingsEntity));
				if(_incidentalFindings!=null)
				{
					_incidentalFindings.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AsitestIncidentalFindingsFieldIndex)fieldIndex)
			{
				case AsitestIncidentalFindingsFieldIndex.AsitestId:
					DesetupSyncAsitestResults(true, false);
					break;
				case AsitestIncidentalFindingsFieldIndex.IncidentalFindingsId:
					DesetupSyncIncidentalFindings(true, false);
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
				case "AsitestResults":
					this.AsitestResults = (AsitestResultsEntity)entity;
					break;
				case "IncidentalFindings":
					this.IncidentalFindings = (IncidentalFindingsEntity)entity;
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
			return AsitestIncidentalFindingsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AsitestResults":
					toReturn.Add(AsitestIncidentalFindingsEntity.Relations.AsitestResultsEntityUsingAsitestId);
					break;
				case "IncidentalFindings":
					toReturn.Add(AsitestIncidentalFindingsEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingsId);
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
				case "AsitestResults":
					SetupSyncAsitestResults(relatedEntity);
					break;
				case "IncidentalFindings":
					SetupSyncIncidentalFindings(relatedEntity);
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
				case "AsitestResults":
					DesetupSyncAsitestResults(false, true);
					break;
				case "IncidentalFindings":
					DesetupSyncIncidentalFindings(false, true);
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
			if(_asitestResults!=null)
			{
				toReturn.Add(_asitestResults);
			}
			if(_incidentalFindings!=null)
			{
				toReturn.Add(_incidentalFindings);
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


				info.AddValue("_asitestResults", (!this.MarkedForDeletion?_asitestResults:null));
				info.AddValue("_incidentalFindings", (!this.MarkedForDeletion?_incidentalFindings:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AsitestIncidentalFindingsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AsitestIncidentalFindingsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AsitestIncidentalFindingsRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AsitestResults' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAsitestResults()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AsitestResultsFields.AsitestId, null, ComparisonOperator.Equal, this.AsitestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingsFields.IncidentalFindingsId, null, ComparisonOperator.Equal, this.IncidentalFindingsId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.AsitestIncidentalFindingsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AsitestIncidentalFindingsEntityFactory));
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
			toReturn.Add("AsitestResults", _asitestResults);
			toReturn.Add("IncidentalFindings", _incidentalFindings);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_asitestResults!=null)
			{
				_asitestResults.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindings!=null)
			{
				_incidentalFindings.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_asitestResults = null;
			_incidentalFindings = null;

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

			_fieldsCustomProperties.Add("AsitestIncidentalFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AsitestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IncidentalFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShellId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _asitestResults</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAsitestResults(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _asitestResults, new PropertyChangedEventHandler( OnAsitestResultsPropertyChanged ), "AsitestResults", AsitestIncidentalFindingsEntity.Relations.AsitestResultsEntityUsingAsitestId, true, signalRelatedEntity, "AsitestIncidentalFindings", resetFKFields, new int[] { (int)AsitestIncidentalFindingsFieldIndex.AsitestId } );		
			_asitestResults = null;
		}

		/// <summary> setups the sync logic for member _asitestResults</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAsitestResults(IEntity2 relatedEntity)
		{
			if(_asitestResults!=relatedEntity)
			{
				DesetupSyncAsitestResults(true, true);
				_asitestResults = (AsitestResultsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _asitestResults, new PropertyChangedEventHandler( OnAsitestResultsPropertyChanged ), "AsitestResults", AsitestIncidentalFindingsEntity.Relations.AsitestResultsEntityUsingAsitestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAsitestResultsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _incidentalFindings</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncIncidentalFindings(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _incidentalFindings, new PropertyChangedEventHandler( OnIncidentalFindingsPropertyChanged ), "IncidentalFindings", AsitestIncidentalFindingsEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingsId, true, signalRelatedEntity, "AsitestIncidentalFindings", resetFKFields, new int[] { (int)AsitestIncidentalFindingsFieldIndex.IncidentalFindingsId } );		
			_incidentalFindings = null;
		}

		/// <summary> setups the sync logic for member _incidentalFindings</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncIncidentalFindings(IEntity2 relatedEntity)
		{
			if(_incidentalFindings!=relatedEntity)
			{
				DesetupSyncIncidentalFindings(true, true);
				_incidentalFindings = (IncidentalFindingsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _incidentalFindings, new PropertyChangedEventHandler( OnIncidentalFindingsPropertyChanged ), "IncidentalFindings", AsitestIncidentalFindingsEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingsId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnIncidentalFindingsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AsitestIncidentalFindingsEntity</param>
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
		public  static AsitestIncidentalFindingsRelations Relations
		{
			get	{ return new AsitestIncidentalFindingsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AsitestResults' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAsitestResults
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AsitestResultsEntityFactory))),
					(IEntityRelation)GetRelationsForField("AsitestResults")[0], (int)HealthYes.Data.EntityType.AsitestIncidentalFindingsEntity, (int)HealthYes.Data.EntityType.AsitestResultsEntity, 0, null, null, null, null, "AsitestResults", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindings
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("IncidentalFindings")[0], (int)HealthYes.Data.EntityType.AsitestIncidentalFindingsEntity, (int)HealthYes.Data.EntityType.IncidentalFindingsEntity, 0, null, null, null, null, "IncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AsitestIncidentalFindingsEntity.CustomProperties;}
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
			get { return AsitestIncidentalFindingsEntity.FieldsCustomProperties;}
		}

		/// <summary> The AsitestIncidentalFindingsId property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."ASITestIncidentalFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 AsitestIncidentalFindingsId
		{
			get { return (System.Int64)GetValue((int)AsitestIncidentalFindingsFieldIndex.AsitestIncidentalFindingsId, true); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.AsitestIncidentalFindingsId, value); }
		}

		/// <summary> The AsitestId property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."ASITestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AsitestId
		{
			get { return (System.Int64)GetValue((int)AsitestIncidentalFindingsFieldIndex.AsitestId, true); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.AsitestId, value); }
		}

		/// <summary> The IncidentalFindingsId property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."IncidentalFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 IncidentalFindingsId
		{
			get { return (System.Int64)GetValue((int)AsitestIncidentalFindingsFieldIndex.IncidentalFindingsId, true); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.IncidentalFindingsId, value); }
		}

		/// <summary> The Notes property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)AsitestIncidentalFindingsFieldIndex.Notes, true); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.Notes, value); }
		}

		/// <summary> The UserId property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."UserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 UserId
		{
			get { return (System.Int64)GetValue((int)AsitestIncidentalFindingsFieldIndex.UserId, true); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.UserId, value); }
		}

		/// <summary> The ShellId property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."ShellID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ShellId
		{
			get { return (System.Int64)GetValue((int)AsitestIncidentalFindingsFieldIndex.ShellId, true); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.ShellId, value); }
		}

		/// <summary> The RoleId property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RoleId
		{
			get { return (System.Int32)GetValue((int)AsitestIncidentalFindingsFieldIndex.RoleId, true); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.RoleId, value); }
		}

		/// <summary> The DateCreated property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)AsitestIncidentalFindingsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AsitestIncidentalFindingsFieldIndex.DateModified, false); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity AsitestIncidentalFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblASITestIncidentalFindings_Legacy"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AsitestIncidentalFindingsFieldIndex.IsActive, true); }
			set	{ SetValue((int)AsitestIncidentalFindingsFieldIndex.IsActive, value); }
		}



		/// <summary> Gets / sets related entity of type 'AsitestResultsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AsitestResultsEntity AsitestResults
		{
			get
			{
				return _asitestResults;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAsitestResults(value);
				}
				else
				{
					if(value==null)
					{
						if(_asitestResults != null)
						{
							_asitestResults.UnsetRelatedEntity(this, "AsitestIncidentalFindings");
						}
					}
					else
					{
						if(_asitestResults!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AsitestIncidentalFindings");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'IncidentalFindingsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual IncidentalFindingsEntity IncidentalFindings
		{
			get
			{
				return _incidentalFindings;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncIncidentalFindings(value);
				}
				else
				{
					if(value==null)
					{
						if(_incidentalFindings != null)
						{
							_incidentalFindings.UnsetRelatedEntity(this, "AsitestIncidentalFindings");
						}
					}
					else
					{
						if(_incidentalFindings!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AsitestIncidentalFindings");
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
			get { return (int)HealthYes.Data.EntityType.AsitestIncidentalFindingsEntity; }
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
