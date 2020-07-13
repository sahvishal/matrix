///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:34 AM
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
	/// Entity class which represents the entity 'FranchisorKpi'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class FranchisorKpiEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations



		private FranchisorEntity _franchisor;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{



			/// <summary>Member name Franchisor</summary>
			public static readonly string Franchisor = "Franchisor";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static FranchisorKpiEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public FranchisorKpiEntity():base("FranchisorKpiEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public FranchisorKpiEntity(IEntityFields2 fields):base("FranchisorKpiEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this FranchisorKpiEntity</param>
		public FranchisorKpiEntity(IValidator validator):base("FranchisorKpiEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="franchisorKpiid">PK value for FranchisorKpi which data should be fetched into this FranchisorKpi object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FranchisorKpiEntity(System.Int64 franchisorKpiid):base("FranchisorKpiEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.FranchisorKpiid = franchisorKpiid;
		}

		/// <summary> CTor</summary>
		/// <param name="franchisorKpiid">PK value for FranchisorKpi which data should be fetched into this FranchisorKpi object</param>
		/// <param name="validator">The custom validator object for this FranchisorKpiEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FranchisorKpiEntity(System.Int64 franchisorKpiid, IValidator validator):base("FranchisorKpiEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.FranchisorKpiid = franchisorKpiid;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected FranchisorKpiEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{



				_franchisor = (FranchisorEntity)info.GetValue("_franchisor", typeof(FranchisorEntity));
				if(_franchisor!=null)
				{
					_franchisor.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((FranchisorKpiFieldIndex)fieldIndex)
			{
				case FranchisorKpiFieldIndex.FranchisorKpiid:
					DesetupSyncFranchisor(true, false);
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



				case "Franchisor":
					this.Franchisor = (FranchisorEntity)entity;
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
			return FranchisorKpiEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{



				case "Franchisor":
					toReturn.Add(FranchisorKpiEntity.Relations.FranchisorEntityUsingFranchisorKpiid);
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


				case "Franchisor":
					SetupSyncFranchisor(relatedEntity);
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


				case "Franchisor":
					DesetupSyncFranchisor(false, true);
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

			if(_franchisor!=null)
			{
				toReturn.Add(_franchisor);
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



				info.AddValue("_franchisor", (!this.MarkedForDeletion?_franchisor:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(FranchisorKpiFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(FranchisorKpiFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new FranchisorKpiRelations().GetAllRelations();
		}
		




		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Franchisor' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFranchisor()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FranchisorFields.FranchisorId, null, ComparisonOperator.Equal, this.FranchisorKpiid));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.FranchisorKpiEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(FranchisorKpiEntityFactory));
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



			toReturn.Add("Franchisor", _franchisor);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{



			if(_franchisor!=null)
			{
				_franchisor.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{




			_franchisor = null;
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

			_fieldsCustomProperties.Add("FranchisorKpiid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventsThisWeek", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClientsThisWeek", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RevenueThisWeek", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ColdCallsThisWeek", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectsThisWeek", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectVisitsThisWeek", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HostAgreementsThisWeek", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomersScreenedThisWeek", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventsThisMonth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClientsThisMonth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RevenueThisMonth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ColdCallsThisMonth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectsThisMonth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectVisitsThisMonth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HostAgreementsThisMonth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomersScreenedThisMonth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventsThisYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClientsThisYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RevenueThisYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ColdCallsThisYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectsThisYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectVisitsThisYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HostAgreementsThisYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomersScreenedThisYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventsTillDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClientsTillDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RevenueTillDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ColdCallsTillDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectsTillDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectVisitsTillDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HostAgreementsTillDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomersScreenedTillDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _franchisor</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFranchisor(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _franchisor, new PropertyChangedEventHandler( OnFranchisorPropertyChanged ), "Franchisor", FranchisorKpiEntity.Relations.FranchisorEntityUsingFranchisorKpiid, true, signalRelatedEntity, "FranchisorKpi", false, new int[] { (int)FranchisorKpiFieldIndex.FranchisorKpiid } );
			_franchisor = null;
		}
		
		/// <summary> setups the sync logic for member _franchisor</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFranchisor(IEntity2 relatedEntity)
		{
			if(_franchisor!=relatedEntity)
			{
				DesetupSyncFranchisor(true, true);
				_franchisor = (FranchisorEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _franchisor, new PropertyChangedEventHandler( OnFranchisorPropertyChanged ), "Franchisor", FranchisorKpiEntity.Relations.FranchisorEntityUsingFranchisorKpiid, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFranchisorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this FranchisorKpiEntity</param>
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
		public  static FranchisorKpiRelations Relations
		{
			get	{ return new FranchisorKpiRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}




		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Franchisor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFranchisor
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FranchisorEntityFactory))),
					(IEntityRelation)GetRelationsForField("Franchisor")[0], (int)HealthYes.Data.EntityType.FranchisorKpiEntity, (int)HealthYes.Data.EntityType.FranchisorEntity, 0, null, null, null, null, "Franchisor", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return FranchisorKpiEntity.CustomProperties;}
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
			get { return FranchisorKpiEntity.FieldsCustomProperties;}
		}

		/// <summary> The FranchisorKpiid property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."FranchisorKPIID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 FranchisorKpiid
		{
			get { return (System.Int64)GetValue((int)FranchisorKpiFieldIndex.FranchisorKpiid, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.FranchisorKpiid, value); }
		}

		/// <summary> The EventsThisWeek property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."EventsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EventsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.EventsThisWeek, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.EventsThisWeek, value); }
		}

		/// <summary> The ClientsThisWeek property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ClientsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ClientsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ClientsThisWeek, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ClientsThisWeek, value); }
		}

		/// <summary> The RevenueThisWeek property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."RevenueThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RevenueThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.RevenueThisWeek, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.RevenueThisWeek, value); }
		}

		/// <summary> The ColdCallsThisWeek property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ColdCallsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ColdCallsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ColdCallsThisWeek, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ColdCallsThisWeek, value); }
		}

		/// <summary> The ProspectsThisWeek property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ProspectsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ProspectsThisWeek, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ProspectsThisWeek, value); }
		}

		/// <summary> The ProspectVisitsThisWeek property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ProspectVisitsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectVisitsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ProspectVisitsThisWeek, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ProspectVisitsThisWeek, value); }
		}

		/// <summary> The HostAgreementsThisWeek property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."HostAgreementsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HostAgreementsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.HostAgreementsThisWeek, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.HostAgreementsThisWeek, value); }
		}

		/// <summary> The CustomersScreenedThisWeek property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."CustomersScreenedThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CustomersScreenedThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.CustomersScreenedThisWeek, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.CustomersScreenedThisWeek, value); }
		}

		/// <summary> The EventsThisMonth property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."EventsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EventsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.EventsThisMonth, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.EventsThisMonth, value); }
		}

		/// <summary> The ClientsThisMonth property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ClientsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ClientsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ClientsThisMonth, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ClientsThisMonth, value); }
		}

		/// <summary> The RevenueThisMonth property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."RevenueThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RevenueThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.RevenueThisMonth, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.RevenueThisMonth, value); }
		}

		/// <summary> The ColdCallsThisMonth property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ColdCallsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ColdCallsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ColdCallsThisMonth, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ColdCallsThisMonth, value); }
		}

		/// <summary> The ProspectsThisMonth property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ProspectsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ProspectsThisMonth, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ProspectsThisMonth, value); }
		}

		/// <summary> The ProspectVisitsThisMonth property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ProspectVisitsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectVisitsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ProspectVisitsThisMonth, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ProspectVisitsThisMonth, value); }
		}

		/// <summary> The HostAgreementsThisMonth property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."HostAgreementsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HostAgreementsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.HostAgreementsThisMonth, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.HostAgreementsThisMonth, value); }
		}

		/// <summary> The CustomersScreenedThisMonth property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."CustomersScreenedThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CustomersScreenedThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.CustomersScreenedThisMonth, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.CustomersScreenedThisMonth, value); }
		}

		/// <summary> The EventsThisYear property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."EventsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EventsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.EventsThisYear, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.EventsThisYear, value); }
		}

		/// <summary> The ClientsThisYear property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ClientsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ClientsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ClientsThisYear, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ClientsThisYear, value); }
		}

		/// <summary> The RevenueThisYear property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."RevenueThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RevenueThisYear
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.RevenueThisYear, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.RevenueThisYear, value); }
		}

		/// <summary> The ColdCallsThisYear property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ColdCallsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ColdCallsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ColdCallsThisYear, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ColdCallsThisYear, value); }
		}

		/// <summary> The ProspectsThisYear property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ProspectsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ProspectsThisYear, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ProspectsThisYear, value); }
		}

		/// <summary> The ProspectVisitsThisYear property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ProspectVisitsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectVisitsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ProspectVisitsThisYear, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ProspectVisitsThisYear, value); }
		}

		/// <summary> The HostAgreementsThisYear property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."HostAgreementsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HostAgreementsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.HostAgreementsThisYear, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.HostAgreementsThisYear, value); }
		}

		/// <summary> The CustomersScreenedThisYear property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."CustomersScreenedThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CustomersScreenedThisYear
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.CustomersScreenedThisYear, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.CustomersScreenedThisYear, value); }
		}

		/// <summary> The EventsTillDate property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."EventsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EventsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.EventsTillDate, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.EventsTillDate, value); }
		}

		/// <summary> The ClientsTillDate property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ClientsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ClientsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ClientsTillDate, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ClientsTillDate, value); }
		}

		/// <summary> The RevenueTillDate property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."RevenueTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RevenueTillDate
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.RevenueTillDate, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.RevenueTillDate, value); }
		}

		/// <summary> The ColdCallsTillDate property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ColdCallsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ColdCallsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ColdCallsTillDate, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ColdCallsTillDate, value); }
		}

		/// <summary> The ProspectsTillDate property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ProspectsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ProspectsTillDate, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ProspectsTillDate, value); }
		}

		/// <summary> The ProspectVisitsTillDate property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."ProspectVisitsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectVisitsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.ProspectVisitsTillDate, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.ProspectVisitsTillDate, value); }
		}

		/// <summary> The HostAgreementsTillDate property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."HostAgreementsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HostAgreementsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.HostAgreementsTillDate, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.HostAgreementsTillDate, value); }
		}

		/// <summary> The CustomersScreenedTillDate property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."CustomersScreenedTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CustomersScreenedTillDate
		{
			get { return (System.Int32)GetValue((int)FranchisorKpiFieldIndex.CustomersScreenedTillDate, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.CustomersScreenedTillDate, value); }
		}

		/// <summary> The DateCreated property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)FranchisorKpiFieldIndex.DateCreated, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity FranchisorKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchisorKPI"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)FranchisorKpiFieldIndex.DateModified, true); }
			set	{ SetValue((int)FranchisorKpiFieldIndex.DateModified, value); }
		}




		/// <summary> Gets / sets related entity of type 'FranchisorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FranchisorEntity Franchisor
		{
			get
			{
				return _franchisor;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFranchisor(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "FranchisorKpi");
					}
				}
				else
				{
					if(value==null)
					{
						DesetupSyncFranchisor(true, true);
					}
					else
					{
						if(_franchisor!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "FranchisorKpi");
							SetupSyncFranchisor(relatedEntity);
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
			get { return (int)HealthYes.Data.EntityType.FranchisorKpiEntity; }
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
