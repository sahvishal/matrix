///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:45
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
	/// Entity class which represents the entity 'CampaignTag'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CampaignTagEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CampaignTagMappingEntity> _campaignTagMapping;
		private EntityCollection<AfcampaignEntity> _afcampaignCollectionViaCampaignTagMapping;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name CampaignTagMapping</summary>
			public static readonly string CampaignTagMapping = "CampaignTagMapping";
			/// <summary>Member name AfcampaignCollectionViaCampaignTagMapping</summary>
			public static readonly string AfcampaignCollectionViaCampaignTagMapping = "AfcampaignCollectionViaCampaignTagMapping";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CampaignTagEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CampaignTagEntity():base("CampaignTagEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CampaignTagEntity(IEntityFields2 fields):base("CampaignTagEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CampaignTagEntity</param>
		public CampaignTagEntity(IValidator validator):base("CampaignTagEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="campaignTagId">PK value for CampaignTag which data should be fetched into this CampaignTag object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CampaignTagEntity(System.Int64 campaignTagId):base("CampaignTagEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CampaignTagId = campaignTagId;
		}

		/// <summary> CTor</summary>
		/// <param name="campaignTagId">PK value for CampaignTag which data should be fetched into this CampaignTag object</param>
		/// <param name="validator">The custom validator object for this CampaignTagEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CampaignTagEntity(System.Int64 campaignTagId, IValidator validator):base("CampaignTagEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CampaignTagId = campaignTagId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CampaignTagEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_campaignTagMapping = (EntityCollection<CampaignTagMappingEntity>)info.GetValue("_campaignTagMapping", typeof(EntityCollection<CampaignTagMappingEntity>));
				_afcampaignCollectionViaCampaignTagMapping = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaignCollectionViaCampaignTagMapping", typeof(EntityCollection<AfcampaignEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CampaignTagFieldIndex)fieldIndex)
			{
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

				case "CampaignTagMapping":
					this.CampaignTagMapping.Add((CampaignTagMappingEntity)entity);
					break;
				case "AfcampaignCollectionViaCampaignTagMapping":
					this.AfcampaignCollectionViaCampaignTagMapping.IsReadOnly = false;
					this.AfcampaignCollectionViaCampaignTagMapping.Add((AfcampaignEntity)entity);
					this.AfcampaignCollectionViaCampaignTagMapping.IsReadOnly = true;
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
			return CampaignTagEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "CampaignTagMapping":
					toReturn.Add(CampaignTagEntity.Relations.CampaignTagMappingEntityUsingCampaignTagId);
					break;
				case "AfcampaignCollectionViaCampaignTagMapping":
					toReturn.Add(CampaignTagEntity.Relations.CampaignTagMappingEntityUsingCampaignTagId, "CampaignTagEntity__", "CampaignTagMapping_", JoinHint.None);
					toReturn.Add(CampaignTagMappingEntity.Relations.AfcampaignEntityUsingCampaignId, "CampaignTagMapping_", string.Empty, JoinHint.None);
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

				case "CampaignTagMapping":
					this.CampaignTagMapping.Add((CampaignTagMappingEntity)relatedEntity);
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

				case "CampaignTagMapping":
					base.PerformRelatedEntityRemoval(this.CampaignTagMapping, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CampaignTagMapping);

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
				info.AddValue("_campaignTagMapping", ((_campaignTagMapping!=null) && (_campaignTagMapping.Count>0) && !this.MarkedForDeletion)?_campaignTagMapping:null);
				info.AddValue("_afcampaignCollectionViaCampaignTagMapping", ((_afcampaignCollectionViaCampaignTagMapping!=null) && (_afcampaignCollectionViaCampaignTagMapping.Count>0) && !this.MarkedForDeletion)?_afcampaignCollectionViaCampaignTagMapping:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// Namespace , Tag .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCNamespaceTag()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)CampaignTagFieldIndex.Namespace], null, ComparisonOperator.Equal));
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)CampaignTagFieldIndex.Tag], null, ComparisonOperator.Equal)); 
			return filter;
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CampaignTagFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CampaignTagFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CampaignTagRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CampaignTagMapping' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignTagMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignTagMappingFields.CampaignTagId, null, ComparisonOperator.Equal, this.CampaignTagId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCollectionViaCampaignTagMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfcampaignCollectionViaCampaignTagMapping"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignTagFields.CampaignTagId, null, ComparisonOperator.Equal, this.CampaignTagId, "CampaignTagEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CampaignTagEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._campaignTagMapping);
			collectionsQueue.Enqueue(this._afcampaignCollectionViaCampaignTagMapping);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._campaignTagMapping = (EntityCollection<CampaignTagMappingEntity>) collectionsQueue.Dequeue();
			this._afcampaignCollectionViaCampaignTagMapping = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._campaignTagMapping != null)
			{
				return true;
			}
			if (this._afcampaignCollectionViaCampaignTagMapping != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignTagMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagMappingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("CampaignTagMapping", _campaignTagMapping);
			toReturn.Add("AfcampaignCollectionViaCampaignTagMapping", _afcampaignCollectionViaCampaignTagMapping);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_campaignTagMapping!=null)
			{
				_campaignTagMapping.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignCollectionViaCampaignTagMapping!=null)
			{
				_afcampaignCollectionViaCampaignTagMapping.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_campaignTagMapping = null;
			_afcampaignCollectionViaCampaignTagMapping = null;


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

			_fieldsCustomProperties.Add("CampaignTagId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Namespace", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Tag", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CampaignTagEntity</param>
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
		public  static CampaignTagRelations Relations
		{
			get	{ return new CampaignTagRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CampaignTagMapping' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignTagMapping
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CampaignTagMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagMappingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CampaignTagMapping")[0], (int)Falcon.Data.EntityType.CampaignTagEntity, (int)Falcon.Data.EntityType.CampaignTagMappingEntity, 0, null, null, null, null, "CampaignTagMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCollectionViaCampaignTagMapping
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignTagEntity.Relations.CampaignTagMappingEntityUsingCampaignTagId;
				intermediateRelation.SetAliases(string.Empty, "CampaignTagMapping_");
				return new PrefetchPathElement2(new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignTagEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, GetRelationsForField("AfcampaignCollectionViaCampaignTagMapping"), null, "AfcampaignCollectionViaCampaignTagMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CampaignTagEntity.CustomProperties;}
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
			get { return CampaignTagEntity.FieldsCustomProperties;}
		}

		/// <summary> The CampaignTagId property of the Entity CampaignTag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblCampaignTag"."CampaignTagID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CampaignTagId
		{
			get { return (System.Int64)GetValue((int)CampaignTagFieldIndex.CampaignTagId, true); }
			set	{ SetValue((int)CampaignTagFieldIndex.CampaignTagId, value); }
		}

		/// <summary> The Namespace property of the Entity CampaignTag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblCampaignTag"."Namespace"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Namespace
		{
			get { return (System.String)GetValue((int)CampaignTagFieldIndex.Namespace, true); }
			set	{ SetValue((int)CampaignTagFieldIndex.Namespace, value); }
		}

		/// <summary> The Tag property of the Entity CampaignTag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblCampaignTag"."Tag"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Tag
		{
			get { return (System.String)GetValue((int)CampaignTagFieldIndex.Tag, true); }
			set	{ SetValue((int)CampaignTagFieldIndex.Tag, value); }
		}

		/// <summary> The CreatedDate property of the Entity CampaignTag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblCampaignTag"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedDate
		{
			get { return (System.DateTime)GetValue((int)CampaignTagFieldIndex.CreatedDate, true); }
			set	{ SetValue((int)CampaignTagFieldIndex.CreatedDate, value); }
		}

		/// <summary> The ModifiedDate property of the Entity CampaignTag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblCampaignTag"."ModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ModifiedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CampaignTagFieldIndex.ModifiedDate, false); }
			set	{ SetValue((int)CampaignTagFieldIndex.ModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity CampaignTag<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblCampaignTag"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsActive
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CampaignTagFieldIndex.IsActive, false); }
			set	{ SetValue((int)CampaignTagFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignTagMappingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignTagMappingEntity))]
		public virtual EntityCollection<CampaignTagMappingEntity> CampaignTagMapping
		{
			get
			{
				if(_campaignTagMapping==null)
				{
					_campaignTagMapping = new EntityCollection<CampaignTagMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagMappingEntityFactory)));
					_campaignTagMapping.SetContainingEntityInfo(this, "CampaignTag");
				}
				return _campaignTagMapping;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> AfcampaignCollectionViaCampaignTagMapping
		{
			get
			{
				if(_afcampaignCollectionViaCampaignTagMapping==null)
				{
					_afcampaignCollectionViaCampaignTagMapping = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaignCollectionViaCampaignTagMapping.IsReadOnly=true;
				}
				return _afcampaignCollectionViaCampaignTagMapping;
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
			get { return (int)Falcon.Data.EntityType.CampaignTagEntity; }
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
