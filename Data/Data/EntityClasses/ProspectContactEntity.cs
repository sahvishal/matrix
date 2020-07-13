///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:43
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
	/// Entity class which represents the entity 'ProspectContact'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ProspectContactEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ProspectContactRoleMappingEntity> _prospectContactRoleMapping;
		private EntityCollection<ProspectContactRoleEntity> _prospectContactRoleCollectionViaProspectContactRoleMapping;
		private ProspectsEntity _prospects;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Prospects</summary>
			public static readonly string Prospects = "Prospects";
			/// <summary>Member name ProspectContactRoleMapping</summary>
			public static readonly string ProspectContactRoleMapping = "ProspectContactRoleMapping";
			/// <summary>Member name ProspectContactRoleCollectionViaProspectContactRoleMapping</summary>
			public static readonly string ProspectContactRoleCollectionViaProspectContactRoleMapping = "ProspectContactRoleCollectionViaProspectContactRoleMapping";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ProspectContactEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ProspectContactEntity():base("ProspectContactEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ProspectContactEntity(IEntityFields2 fields):base("ProspectContactEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ProspectContactEntity</param>
		public ProspectContactEntity(IValidator validator):base("ProspectContactEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="prospectContactId">PK value for ProspectContact which data should be fetched into this ProspectContact object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectContactEntity(System.Int64 prospectContactId):base("ProspectContactEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ProspectContactId = prospectContactId;
		}

		/// <summary> CTor</summary>
		/// <param name="prospectContactId">PK value for ProspectContact which data should be fetched into this ProspectContact object</param>
		/// <param name="validator">The custom validator object for this ProspectContactEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectContactEntity(System.Int64 prospectContactId, IValidator validator):base("ProspectContactEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ProspectContactId = prospectContactId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ProspectContactEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_prospectContactRoleMapping = (EntityCollection<ProspectContactRoleMappingEntity>)info.GetValue("_prospectContactRoleMapping", typeof(EntityCollection<ProspectContactRoleMappingEntity>));
				_prospectContactRoleCollectionViaProspectContactRoleMapping = (EntityCollection<ProspectContactRoleEntity>)info.GetValue("_prospectContactRoleCollectionViaProspectContactRoleMapping", typeof(EntityCollection<ProspectContactRoleEntity>));
				_prospects = (ProspectsEntity)info.GetValue("_prospects", typeof(ProspectsEntity));
				if(_prospects!=null)
				{
					_prospects.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ProspectContactFieldIndex)fieldIndex)
			{
				case ProspectContactFieldIndex.ProspectId:
					DesetupSyncProspects(true, false);
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
				case "Prospects":
					this.Prospects = (ProspectsEntity)entity;
					break;
				case "ProspectContactRoleMapping":
					this.ProspectContactRoleMapping.Add((ProspectContactRoleMappingEntity)entity);
					break;
				case "ProspectContactRoleCollectionViaProspectContactRoleMapping":
					this.ProspectContactRoleCollectionViaProspectContactRoleMapping.IsReadOnly = false;
					this.ProspectContactRoleCollectionViaProspectContactRoleMapping.Add((ProspectContactRoleEntity)entity);
					this.ProspectContactRoleCollectionViaProspectContactRoleMapping.IsReadOnly = true;
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
			return ProspectContactEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Prospects":
					toReturn.Add(ProspectContactEntity.Relations.ProspectsEntityUsingProspectId);
					break;
				case "ProspectContactRoleMapping":
					toReturn.Add(ProspectContactEntity.Relations.ProspectContactRoleMappingEntityUsingProspectContactId);
					break;
				case "ProspectContactRoleCollectionViaProspectContactRoleMapping":
					toReturn.Add(ProspectContactEntity.Relations.ProspectContactRoleMappingEntityUsingProspectContactId, "ProspectContactEntity__", "ProspectContactRoleMapping_", JoinHint.None);
					toReturn.Add(ProspectContactRoleMappingEntity.Relations.ProspectContactRoleEntityUsingProspectContactRoleId, "ProspectContactRoleMapping_", string.Empty, JoinHint.None);
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
				case "Prospects":
					SetupSyncProspects(relatedEntity);
					break;
				case "ProspectContactRoleMapping":
					this.ProspectContactRoleMapping.Add((ProspectContactRoleMappingEntity)relatedEntity);
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
				case "Prospects":
					DesetupSyncProspects(false, true);
					break;
				case "ProspectContactRoleMapping":
					base.PerformRelatedEntityRemoval(this.ProspectContactRoleMapping, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_prospects!=null)
			{
				toReturn.Add(_prospects);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ProspectContactRoleMapping);

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
				info.AddValue("_prospectContactRoleMapping", ((_prospectContactRoleMapping!=null) && (_prospectContactRoleMapping.Count>0) && !this.MarkedForDeletion)?_prospectContactRoleMapping:null);
				info.AddValue("_prospectContactRoleCollectionViaProspectContactRoleMapping", ((_prospectContactRoleCollectionViaProspectContactRoleMapping!=null) && (_prospectContactRoleCollectionViaProspectContactRoleMapping.Count>0) && !this.MarkedForDeletion)?_prospectContactRoleCollectionViaProspectContactRoleMapping:null);
				info.AddValue("_prospects", (!this.MarkedForDeletion?_prospects:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ProspectContactFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ProspectContactFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ProspectContactRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectContactRoleMapping' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectContactRoleMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectContactRoleMappingFields.ProspectContactId, null, ComparisonOperator.Equal, this.ProspectContactId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectContactRole' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectContactRoleCollectionViaProspectContactRoleMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectContactRoleCollectionViaProspectContactRoleMapping"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectContactFields.ProspectContactId, null, ComparisonOperator.Equal, this.ProspectContactId, "ProspectContactEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Prospects' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ProspectContactEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._prospectContactRoleMapping);
			collectionsQueue.Enqueue(this._prospectContactRoleCollectionViaProspectContactRoleMapping);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._prospectContactRoleMapping = (EntityCollection<ProspectContactRoleMappingEntity>) collectionsQueue.Dequeue();
			this._prospectContactRoleCollectionViaProspectContactRoleMapping = (EntityCollection<ProspectContactRoleEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._prospectContactRoleMapping != null)
			{
				return true;
			}
			if (this._prospectContactRoleCollectionViaProspectContactRoleMapping != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectContactRoleMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactRoleMappingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectContactRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactRoleEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Prospects", _prospects);
			toReturn.Add("ProspectContactRoleMapping", _prospectContactRoleMapping);
			toReturn.Add("ProspectContactRoleCollectionViaProspectContactRoleMapping", _prospectContactRoleCollectionViaProspectContactRoleMapping);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_prospectContactRoleMapping!=null)
			{
				_prospectContactRoleMapping.ActiveContext = base.ActiveContext;
			}
			if(_prospectContactRoleCollectionViaProspectContactRoleMapping!=null)
			{
				_prospectContactRoleCollectionViaProspectContactRoleMapping.ActiveContext = base.ActiveContext;
			}
			if(_prospects!=null)
			{
				_prospects.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_prospectContactRoleMapping = null;
			_prospectContactRoleCollectionViaProspectContactRoleMapping = null;
			_prospects = null;

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

			_fieldsCustomProperties.Add("ProspectContactId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContactId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _prospects</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncProspects(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _prospects, new PropertyChangedEventHandler( OnProspectsPropertyChanged ), "Prospects", ProspectContactEntity.Relations.ProspectsEntityUsingProspectId, true, signalRelatedEntity, "ProspectContact", resetFKFields, new int[] { (int)ProspectContactFieldIndex.ProspectId } );		
			_prospects = null;
		}

		/// <summary> setups the sync logic for member _prospects</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncProspects(IEntity2 relatedEntity)
		{
			if(_prospects!=relatedEntity)
			{
				DesetupSyncProspects(true, true);
				_prospects = (ProspectsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _prospects, new PropertyChangedEventHandler( OnProspectsPropertyChanged ), "Prospects", ProspectContactEntity.Relations.ProspectsEntityUsingProspectId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProspectsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ProspectContactEntity</param>
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
		public  static ProspectContactRelations Relations
		{
			get	{ return new ProspectContactRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectContactRoleMapping' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectContactRoleMapping
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectContactRoleMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactRoleMappingEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectContactRoleMapping")[0], (int)Falcon.Data.EntityType.ProspectContactEntity, (int)Falcon.Data.EntityType.ProspectContactRoleMappingEntity, 0, null, null, null, null, "ProspectContactRoleMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectContactRole' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectContactRoleCollectionViaProspectContactRoleMapping
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectContactEntity.Relations.ProspectContactRoleMappingEntityUsingProspectContactId;
				intermediateRelation.SetAliases(string.Empty, "ProspectContactRoleMapping_");
				return new PrefetchPathElement2(new EntityCollection<ProspectContactRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactRoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectContactEntity, (int)Falcon.Data.EntityType.ProspectContactRoleEntity, 0, null, null, GetRelationsForField("ProspectContactRoleCollectionViaProspectContactRoleMapping"), null, "ProspectContactRoleCollectionViaProspectContactRoleMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspects
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Prospects")[0], (int)Falcon.Data.EntityType.ProspectContactEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, null, null, "Prospects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ProspectContactEntity.CustomProperties;}
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
			get { return ProspectContactEntity.FieldsCustomProperties;}
		}

		/// <summary> The ProspectContactId property of the Entity ProspectContact<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectContact"."ProspectContactID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ProspectContactId
		{
			get { return (System.Int64)GetValue((int)ProspectContactFieldIndex.ProspectContactId, true); }
			set	{ SetValue((int)ProspectContactFieldIndex.ProspectContactId, value); }
		}

		/// <summary> The ProspectId property of the Entity ProspectContact<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectContact"."ProspectID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ProspectId
		{
			get { return (System.Int64)GetValue((int)ProspectContactFieldIndex.ProspectId, true); }
			set	{ SetValue((int)ProspectContactFieldIndex.ProspectId, value); }
		}

		/// <summary> The ContactId property of the Entity ProspectContact<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectContact"."ContactID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ContactId
		{
			get { return (System.Int64)GetValue((int)ProspectContactFieldIndex.ContactId, true); }
			set	{ SetValue((int)ProspectContactFieldIndex.ContactId, value); }
		}

		/// <summary> The DateCreated property of the Entity ProspectContact<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectContact"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ProspectContactFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ProspectContactFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity ProspectContact<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectContact"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ProspectContactFieldIndex.DateModified, true); }
			set	{ SetValue((int)ProspectContactFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity ProspectContact<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectContact"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ProspectContactFieldIndex.IsActive, true); }
			set	{ SetValue((int)ProspectContactFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectContactRoleMappingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectContactRoleMappingEntity))]
		public virtual EntityCollection<ProspectContactRoleMappingEntity> ProspectContactRoleMapping
		{
			get
			{
				if(_prospectContactRoleMapping==null)
				{
					_prospectContactRoleMapping = new EntityCollection<ProspectContactRoleMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactRoleMappingEntityFactory)));
					_prospectContactRoleMapping.SetContainingEntityInfo(this, "ProspectContact");
				}
				return _prospectContactRoleMapping;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectContactRoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectContactRoleEntity))]
		public virtual EntityCollection<ProspectContactRoleEntity> ProspectContactRoleCollectionViaProspectContactRoleMapping
		{
			get
			{
				if(_prospectContactRoleCollectionViaProspectContactRoleMapping==null)
				{
					_prospectContactRoleCollectionViaProspectContactRoleMapping = new EntityCollection<ProspectContactRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactRoleEntityFactory)));
					_prospectContactRoleCollectionViaProspectContactRoleMapping.IsReadOnly=true;
				}
				return _prospectContactRoleCollectionViaProspectContactRoleMapping;
			}
		}

		/// <summary> Gets / sets related entity of type 'ProspectsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ProspectsEntity Prospects
		{
			get
			{
				return _prospects;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncProspects(value);
				}
				else
				{
					if(value==null)
					{
						if(_prospects != null)
						{
							_prospects.UnsetRelatedEntity(this, "ProspectContact");
						}
					}
					else
					{
						if(_prospects!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ProspectContact");
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
			get { return (int)Falcon.Data.EntityType.ProspectContactEntity; }
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
