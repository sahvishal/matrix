///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:30 AM
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
	/// Entity class which represents the entity 'OsteoporosisTestRecommendation'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OsteoporosisTestRecommendationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private PadtestResultsEntity _padtestResults;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name PadtestResults</summary>
			public static readonly string PadtestResults = "PadtestResults";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OsteoporosisTestRecommendationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public OsteoporosisTestRecommendationEntity():base("OsteoporosisTestRecommendationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OsteoporosisTestRecommendationEntity(IEntityFields2 fields):base("OsteoporosisTestRecommendationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OsteoporosisTestRecommendationEntity</param>
		public OsteoporosisTestRecommendationEntity(IValidator validator):base("OsteoporosisTestRecommendationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="osteoporosisTestRecommendationId">PK value for OsteoporosisTestRecommendation which data should be fetched into this OsteoporosisTestRecommendation object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OsteoporosisTestRecommendationEntity(System.Int64 osteoporosisTestRecommendationId):base("OsteoporosisTestRecommendationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OsteoporosisTestRecommendationId = osteoporosisTestRecommendationId;
		}

		/// <summary> CTor</summary>
		/// <param name="osteoporosisTestRecommendationId">PK value for OsteoporosisTestRecommendation which data should be fetched into this OsteoporosisTestRecommendation object</param>
		/// <param name="validator">The custom validator object for this OsteoporosisTestRecommendationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OsteoporosisTestRecommendationEntity(System.Int64 osteoporosisTestRecommendationId, IValidator validator):base("OsteoporosisTestRecommendationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OsteoporosisTestRecommendationId = osteoporosisTestRecommendationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected OsteoporosisTestRecommendationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_padtestResults = (PadtestResultsEntity)info.GetValue("_padtestResults", typeof(PadtestResultsEntity));
				if(_padtestResults!=null)
				{
					_padtestResults.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((OsteoporosisTestRecommendationFieldIndex)fieldIndex)
			{
				case OsteoporosisTestRecommendationFieldIndex.OsteoporosisTestId:
					DesetupSyncPadtestResults(true, false);
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
				case "PadtestResults":
					this.PadtestResults = (PadtestResultsEntity)entity;
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
			return OsteoporosisTestRecommendationEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "PadtestResults":
					toReturn.Add(OsteoporosisTestRecommendationEntity.Relations.PadtestResultsEntityUsingOsteoporosisTestId);
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
				case "PadtestResults":
					SetupSyncPadtestResults(relatedEntity);
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
				case "PadtestResults":
					DesetupSyncPadtestResults(false, true);
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
			if(_padtestResults!=null)
			{
				toReturn.Add(_padtestResults);
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


				info.AddValue("_padtestResults", (!this.MarkedForDeletion?_padtestResults:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OsteoporosisTestRecommendationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OsteoporosisTestRecommendationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OsteoporosisTestRecommendationRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PadtestResults' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPadtestResults()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PadtestResultsFields.PadtestId, null, ComparisonOperator.Equal, this.OsteoporosisTestId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.OsteoporosisTestRecommendationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestRecommendationEntityFactory));
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
			toReturn.Add("PadtestResults", _padtestResults);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_padtestResults!=null)
			{
				_padtestResults.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_padtestResults = null;

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

			_fieldsCustomProperties.Add("OsteoporosisTestRecommendationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OsteoporosisTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsVisitPhysician", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhysicianRemarks", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TechnicianRemarks", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhysicianRiskEvaluation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsCriticalImmediately", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsCriticalSelf", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EvaluatingPhysicianId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _padtestResults</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPadtestResults(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _padtestResults, new PropertyChangedEventHandler( OnPadtestResultsPropertyChanged ), "PadtestResults", OsteoporosisTestRecommendationEntity.Relations.PadtestResultsEntityUsingOsteoporosisTestId, true, signalRelatedEntity, "OsteoporosisTestRecommendation", resetFKFields, new int[] { (int)OsteoporosisTestRecommendationFieldIndex.OsteoporosisTestId } );		
			_padtestResults = null;
		}

		/// <summary> setups the sync logic for member _padtestResults</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPadtestResults(IEntity2 relatedEntity)
		{
			if(_padtestResults!=relatedEntity)
			{
				DesetupSyncPadtestResults(true, true);
				_padtestResults = (PadtestResultsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _padtestResults, new PropertyChangedEventHandler( OnPadtestResultsPropertyChanged ), "PadtestResults", OsteoporosisTestRecommendationEntity.Relations.PadtestResultsEntityUsingOsteoporosisTestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPadtestResultsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OsteoporosisTestRecommendationEntity</param>
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
		public  static OsteoporosisTestRecommendationRelations Relations
		{
			get	{ return new OsteoporosisTestRecommendationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PadtestResults' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPadtestResults
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PadtestResultsEntityFactory))),
					(IEntityRelation)GetRelationsForField("PadtestResults")[0], (int)HealthYes.Data.EntityType.OsteoporosisTestRecommendationEntity, (int)HealthYes.Data.EntityType.PadtestResultsEntity, 0, null, null, null, null, "PadtestResults", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OsteoporosisTestRecommendationEntity.CustomProperties;}
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
			get { return OsteoporosisTestRecommendationEntity.FieldsCustomProperties;}
		}

		/// <summary> The OsteoporosisTestRecommendationId property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."PADTestRecommendationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 OsteoporosisTestRecommendationId
		{
			get { return (System.Int64)GetValue((int)OsteoporosisTestRecommendationFieldIndex.OsteoporosisTestRecommendationId, true); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.OsteoporosisTestRecommendationId, value); }
		}

		/// <summary> The OsteoporosisTestId property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."PADTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OsteoporosisTestId
		{
			get { return (System.Int64)GetValue((int)OsteoporosisTestRecommendationFieldIndex.OsteoporosisTestId, true); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.OsteoporosisTestId, value); }
		}

		/// <summary> The CustomerEventTestId property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."CustomerEventTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CustomerEventTestId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OsteoporosisTestRecommendationFieldIndex.CustomerEventTestId, false); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.CustomerEventTestId, value); }
		}

		/// <summary> The IsVisitPhysician property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."IsVisitPhysician"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsVisitPhysician
		{
			get { return (System.Boolean)GetValue((int)OsteoporosisTestRecommendationFieldIndex.IsVisitPhysician, true); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.IsVisitPhysician, value); }
		}

		/// <summary> The PhysicianRemarks property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."PhysicianRemarks"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhysicianRemarks
		{
			get { return (System.String)GetValue((int)OsteoporosisTestRecommendationFieldIndex.PhysicianRemarks, true); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.PhysicianRemarks, value); }
		}

		/// <summary> The TechnicianRemarks property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."TechnicianRemarks"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TechnicianRemarks
		{
			get { return (System.String)GetValue((int)OsteoporosisTestRecommendationFieldIndex.TechnicianRemarks, true); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.TechnicianRemarks, value); }
		}

		/// <summary> The PhysicianRiskEvaluation property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."PhysicianRiskEvaluation"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> PhysicianRiskEvaluation
		{
			get { return (Nullable<System.Int32>)GetValue((int)OsteoporosisTestRecommendationFieldIndex.PhysicianRiskEvaluation, false); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.PhysicianRiskEvaluation, value); }
		}

		/// <summary> The DateCreated property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)OsteoporosisTestRecommendationFieldIndex.DateCreated, false); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)OsteoporosisTestRecommendationFieldIndex.DateModified, false); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.DateModified, value); }
		}

		/// <summary> The IsCriticalImmediately property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."IsCriticalImmediately"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsCriticalImmediately
		{
			get { return (Nullable<System.Boolean>)GetValue((int)OsteoporosisTestRecommendationFieldIndex.IsCriticalImmediately, false); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.IsCriticalImmediately, value); }
		}

		/// <summary> The IsCriticalSelf property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."IsCriticalSelf"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsCriticalSelf
		{
			get { return (Nullable<System.Boolean>)GetValue((int)OsteoporosisTestRecommendationFieldIndex.IsCriticalSelf, false); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.IsCriticalSelf, value); }
		}

		/// <summary> The EvaluatingPhysicianId property of the Entity OsteoporosisTestRecommendation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPADTestRecommendation_Legacy"."EvaluatingPhysicianID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EvaluatingPhysicianId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OsteoporosisTestRecommendationFieldIndex.EvaluatingPhysicianId, false); }
			set	{ SetValue((int)OsteoporosisTestRecommendationFieldIndex.EvaluatingPhysicianId, value); }
		}



		/// <summary> Gets / sets related entity of type 'PadtestResultsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PadtestResultsEntity PadtestResults
		{
			get
			{
				return _padtestResults;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPadtestResults(value);
				}
				else
				{
					if(value==null)
					{
						if(_padtestResults != null)
						{
							_padtestResults.UnsetRelatedEntity(this, "OsteoporosisTestRecommendation");
						}
					}
					else
					{
						if(_padtestResults!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "OsteoporosisTestRecommendation");
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
			get { return (int)HealthYes.Data.EntityType.OsteoporosisTestRecommendationEntity; }
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
