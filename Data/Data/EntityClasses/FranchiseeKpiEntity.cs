///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:29 AM
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
	/// Entity class which represents the entity 'FranchiseeKpi'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class FranchiseeKpiEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations



		private FranchiseeEntity _franchisee;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{



			/// <summary>Member name Franchisee</summary>
			public static readonly string Franchisee = "Franchisee";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static FranchiseeKpiEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public FranchiseeKpiEntity():base("FranchiseeKpiEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public FranchiseeKpiEntity(IEntityFields2 fields):base("FranchiseeKpiEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this FranchiseeKpiEntity</param>
		public FranchiseeKpiEntity(IValidator validator):base("FranchiseeKpiEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="franchiseeKpiid">PK value for FranchiseeKpi which data should be fetched into this FranchiseeKpi object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FranchiseeKpiEntity(System.Int64 franchiseeKpiid):base("FranchiseeKpiEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.FranchiseeKpiid = franchiseeKpiid;
		}

		/// <summary> CTor</summary>
		/// <param name="franchiseeKpiid">PK value for FranchiseeKpi which data should be fetched into this FranchiseeKpi object</param>
		/// <param name="validator">The custom validator object for this FranchiseeKpiEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FranchiseeKpiEntity(System.Int64 franchiseeKpiid, IValidator validator):base("FranchiseeKpiEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.FranchiseeKpiid = franchiseeKpiid;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected FranchiseeKpiEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{



				_franchisee = (FranchiseeEntity)info.GetValue("_franchisee", typeof(FranchiseeEntity));
				if(_franchisee!=null)
				{
					_franchisee.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((FranchiseeKpiFieldIndex)fieldIndex)
			{
				case FranchiseeKpiFieldIndex.FranchiseeKpiid:
					DesetupSyncFranchisee(true, false);
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



				case "Franchisee":
					this.Franchisee = (FranchiseeEntity)entity;
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
			return FranchiseeKpiEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{



				case "Franchisee":
					toReturn.Add(FranchiseeKpiEntity.Relations.FranchiseeEntityUsingFranchiseeKpiid);
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


				case "Franchisee":
					SetupSyncFranchisee(relatedEntity);
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


				case "Franchisee":
					DesetupSyncFranchisee(false, true);
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

			if(_franchisee!=null)
			{
				toReturn.Add(_franchisee);
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



				info.AddValue("_franchisee", (!this.MarkedForDeletion?_franchisee:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(FranchiseeKpiFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(FranchiseeKpiFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new FranchiseeKpiRelations().GetAllRelations();
		}
		




		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Franchisee' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFranchisee()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FranchiseeFields.FranchiseeId, null, ComparisonOperator.Equal, this.FranchiseeKpiid));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.FranchiseeKpiEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(FranchiseeKpiEntityFactory));
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



			toReturn.Add("Franchisee", _franchisee);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{



			if(_franchisee!=null)
			{
				_franchisee.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{




			_franchisee = null;
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

			_fieldsCustomProperties.Add("FranchiseeKpiid", fieldHashtable);
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


		/// <summary> Removes the sync logic for member _franchisee</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFranchisee(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _franchisee, new PropertyChangedEventHandler( OnFranchiseePropertyChanged ), "Franchisee", FranchiseeKpiEntity.Relations.FranchiseeEntityUsingFranchiseeKpiid, true, signalRelatedEntity, "FranchiseeKpi", false, new int[] { (int)FranchiseeKpiFieldIndex.FranchiseeKpiid } );
			_franchisee = null;
		}
		
		/// <summary> setups the sync logic for member _franchisee</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFranchisee(IEntity2 relatedEntity)
		{
			if(_franchisee!=relatedEntity)
			{
				DesetupSyncFranchisee(true, true);
				_franchisee = (FranchiseeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _franchisee, new PropertyChangedEventHandler( OnFranchiseePropertyChanged ), "Franchisee", FranchiseeKpiEntity.Relations.FranchiseeEntityUsingFranchiseeKpiid, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFranchiseePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this FranchiseeKpiEntity</param>
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
		public  static FranchiseeKpiRelations Relations
		{
			get	{ return new FranchiseeKpiRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}




		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Franchisee' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFranchisee
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FranchiseeEntityFactory))),
					(IEntityRelation)GetRelationsForField("Franchisee")[0], (int)HealthYes.Data.EntityType.FranchiseeKpiEntity, (int)HealthYes.Data.EntityType.FranchiseeEntity, 0, null, null, null, null, "Franchisee", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return FranchiseeKpiEntity.CustomProperties;}
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
			get { return FranchiseeKpiEntity.FieldsCustomProperties;}
		}

		/// <summary> The FranchiseeKpiid property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."FranchiseeKPIID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 FranchiseeKpiid
		{
			get { return (System.Int64)GetValue((int)FranchiseeKpiFieldIndex.FranchiseeKpiid, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.FranchiseeKpiid, value); }
		}

		/// <summary> The EventsThisWeek property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."EventsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EventsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.EventsThisWeek, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.EventsThisWeek, value); }
		}

		/// <summary> The ClientsThisWeek property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ClientsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ClientsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ClientsThisWeek, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ClientsThisWeek, value); }
		}

		/// <summary> The RevenueThisWeek property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."RevenueThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RevenueThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.RevenueThisWeek, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.RevenueThisWeek, value); }
		}

		/// <summary> The ColdCallsThisWeek property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ColdCallsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ColdCallsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ColdCallsThisWeek, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ColdCallsThisWeek, value); }
		}

		/// <summary> The ProspectsThisWeek property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ProspectsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ProspectsThisWeek, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ProspectsThisWeek, value); }
		}

		/// <summary> The ProspectVisitsThisWeek property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ProspectVisitsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectVisitsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ProspectVisitsThisWeek, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ProspectVisitsThisWeek, value); }
		}

		/// <summary> The HostAgreementsThisWeek property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."HostAgreementsThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HostAgreementsThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.HostAgreementsThisWeek, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.HostAgreementsThisWeek, value); }
		}

		/// <summary> The CustomersScreenedThisWeek property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."CustomersScreenedThisWeek"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CustomersScreenedThisWeek
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.CustomersScreenedThisWeek, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.CustomersScreenedThisWeek, value); }
		}

		/// <summary> The EventsThisMonth property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."EventsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EventsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.EventsThisMonth, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.EventsThisMonth, value); }
		}

		/// <summary> The ClientsThisMonth property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ClientsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ClientsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ClientsThisMonth, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ClientsThisMonth, value); }
		}

		/// <summary> The RevenueThisMonth property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."RevenueThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RevenueThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.RevenueThisMonth, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.RevenueThisMonth, value); }
		}

		/// <summary> The ColdCallsThisMonth property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ColdCallsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ColdCallsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ColdCallsThisMonth, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ColdCallsThisMonth, value); }
		}

		/// <summary> The ProspectsThisMonth property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ProspectsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ProspectsThisMonth, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ProspectsThisMonth, value); }
		}

		/// <summary> The ProspectVisitsThisMonth property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ProspectVisitsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectVisitsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ProspectVisitsThisMonth, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ProspectVisitsThisMonth, value); }
		}

		/// <summary> The HostAgreementsThisMonth property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."HostAgreementsThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HostAgreementsThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.HostAgreementsThisMonth, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.HostAgreementsThisMonth, value); }
		}

		/// <summary> The CustomersScreenedThisMonth property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."CustomersScreenedThisMonth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CustomersScreenedThisMonth
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.CustomersScreenedThisMonth, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.CustomersScreenedThisMonth, value); }
		}

		/// <summary> The EventsThisYear property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."EventsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EventsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.EventsThisYear, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.EventsThisYear, value); }
		}

		/// <summary> The ClientsThisYear property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ClientsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ClientsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ClientsThisYear, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ClientsThisYear, value); }
		}

		/// <summary> The RevenueThisYear property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."RevenueThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RevenueThisYear
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.RevenueThisYear, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.RevenueThisYear, value); }
		}

		/// <summary> The ColdCallsThisYear property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ColdCallsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ColdCallsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ColdCallsThisYear, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ColdCallsThisYear, value); }
		}

		/// <summary> The ProspectsThisYear property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ProspectsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ProspectsThisYear, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ProspectsThisYear, value); }
		}

		/// <summary> The ProspectVisitsThisYear property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ProspectVisitsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectVisitsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ProspectVisitsThisYear, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ProspectVisitsThisYear, value); }
		}

		/// <summary> The HostAgreementsThisYear property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."HostAgreementsThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HostAgreementsThisYear
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.HostAgreementsThisYear, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.HostAgreementsThisYear, value); }
		}

		/// <summary> The CustomersScreenedThisYear property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."CustomersScreenedThisYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CustomersScreenedThisYear
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.CustomersScreenedThisYear, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.CustomersScreenedThisYear, value); }
		}

		/// <summary> The EventsTillDate property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."EventsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EventsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.EventsTillDate, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.EventsTillDate, value); }
		}

		/// <summary> The ClientsTillDate property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ClientsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ClientsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ClientsTillDate, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ClientsTillDate, value); }
		}

		/// <summary> The RevenueTillDate property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."RevenueTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RevenueTillDate
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.RevenueTillDate, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.RevenueTillDate, value); }
		}

		/// <summary> The ColdCallsTillDate property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ColdCallsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ColdCallsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ColdCallsTillDate, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ColdCallsTillDate, value); }
		}

		/// <summary> The ProspectsTillDate property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ProspectsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ProspectsTillDate, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ProspectsTillDate, value); }
		}

		/// <summary> The ProspectVisitsTillDate property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."ProspectVisitsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ProspectVisitsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.ProspectVisitsTillDate, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.ProspectVisitsTillDate, value); }
		}

		/// <summary> The HostAgreementsTillDate property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."HostAgreementsTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HostAgreementsTillDate
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.HostAgreementsTillDate, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.HostAgreementsTillDate, value); }
		}

		/// <summary> The CustomersScreenedTillDate property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."CustomersScreenedTillDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CustomersScreenedTillDate
		{
			get { return (System.Int32)GetValue((int)FranchiseeKpiFieldIndex.CustomersScreenedTillDate, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.CustomersScreenedTillDate, value); }
		}

		/// <summary> The DateCreated property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)FranchiseeKpiFieldIndex.DateCreated, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity FranchiseeKpi<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblFranchiseeKPI"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)FranchiseeKpiFieldIndex.DateModified, true); }
			set	{ SetValue((int)FranchiseeKpiFieldIndex.DateModified, value); }
		}




		/// <summary> Gets / sets related entity of type 'FranchiseeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FranchiseeEntity Franchisee
		{
			get
			{
				return _franchisee;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFranchisee(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "FranchiseeKpi");
					}
				}
				else
				{
					if(value==null)
					{
						DesetupSyncFranchisee(true, true);
					}
					else
					{
						if(_franchisee!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "FranchiseeKpi");
							SetupSyncFranchisee(relatedEntity);
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
			get { return (int)HealthYes.Data.EntityType.FranchiseeKpiEntity; }
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
