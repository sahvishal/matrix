///////////////////////////////////////////////////////////////
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
	/// Entity class which represents the entity 'Afcreative'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AfcreativeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AfcampaignCreativeEntity> _afcampaignCreative;
		private EntityCollection<AfcampaignEntity> _afcampaignCollectionViaAfcampaignCreative;
		private AfcreativeFormatEntity _afcreativeFormat;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AfcreativeFormat</summary>
			public static readonly string AfcreativeFormat = "AfcreativeFormat";
			/// <summary>Member name AfcampaignCreative</summary>
			public static readonly string AfcampaignCreative = "AfcampaignCreative";
			/// <summary>Member name AfcampaignCollectionViaAfcampaignCreative</summary>
			public static readonly string AfcampaignCollectionViaAfcampaignCreative = "AfcampaignCollectionViaAfcampaignCreative";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AfcreativeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AfcreativeEntity():base("AfcreativeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AfcreativeEntity(IEntityFields2 fields):base("AfcreativeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AfcreativeEntity</param>
		public AfcreativeEntity(IValidator validator):base("AfcreativeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="creativeId">PK value for Afcreative which data should be fetched into this Afcreative object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfcreativeEntity(System.Int64 creativeId):base("AfcreativeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CreativeId = creativeId;
		}

		/// <summary> CTor</summary>
		/// <param name="creativeId">PK value for Afcreative which data should be fetched into this Afcreative object</param>
		/// <param name="validator">The custom validator object for this AfcreativeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfcreativeEntity(System.Int64 creativeId, IValidator validator):base("AfcreativeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CreativeId = creativeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AfcreativeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_afcampaignCreative = (EntityCollection<AfcampaignCreativeEntity>)info.GetValue("_afcampaignCreative", typeof(EntityCollection<AfcampaignCreativeEntity>));
				_afcampaignCollectionViaAfcampaignCreative = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaignCollectionViaAfcampaignCreative", typeof(EntityCollection<AfcampaignEntity>));
				_afcreativeFormat = (AfcreativeFormatEntity)info.GetValue("_afcreativeFormat", typeof(AfcreativeFormatEntity));
				if(_afcreativeFormat!=null)
				{
					_afcreativeFormat.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AfcreativeFieldIndex)fieldIndex)
			{
				case AfcreativeFieldIndex.CreativeFormatId:
					DesetupSyncAfcreativeFormat(true, false);
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
				case "AfcreativeFormat":
					this.AfcreativeFormat = (AfcreativeFormatEntity)entity;
					break;
				case "AfcampaignCreative":
					this.AfcampaignCreative.Add((AfcampaignCreativeEntity)entity);
					break;
				case "AfcampaignCollectionViaAfcampaignCreative":
					this.AfcampaignCollectionViaAfcampaignCreative.IsReadOnly = false;
					this.AfcampaignCollectionViaAfcampaignCreative.Add((AfcampaignEntity)entity);
					this.AfcampaignCollectionViaAfcampaignCreative.IsReadOnly = true;
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
			return AfcreativeEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AfcreativeFormat":
					toReturn.Add(AfcreativeEntity.Relations.AfcreativeFormatEntityUsingCreativeFormatId);
					break;
				case "AfcampaignCreative":
					toReturn.Add(AfcreativeEntity.Relations.AfcampaignCreativeEntityUsingCreativeId);
					break;
				case "AfcampaignCollectionViaAfcampaignCreative":
					toReturn.Add(AfcreativeEntity.Relations.AfcampaignCreativeEntityUsingCreativeId, "AfcreativeEntity__", "AfcampaignCreative_", JoinHint.None);
					toReturn.Add(AfcampaignCreativeEntity.Relations.AfcampaignEntityUsingCampaignId, "AfcampaignCreative_", string.Empty, JoinHint.None);
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
				case "AfcreativeFormat":
					SetupSyncAfcreativeFormat(relatedEntity);
					break;
				case "AfcampaignCreative":
					this.AfcampaignCreative.Add((AfcampaignCreativeEntity)relatedEntity);
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
				case "AfcreativeFormat":
					DesetupSyncAfcreativeFormat(false, true);
					break;
				case "AfcampaignCreative":
					base.PerformRelatedEntityRemoval(this.AfcampaignCreative, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_afcreativeFormat!=null)
			{
				toReturn.Add(_afcreativeFormat);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AfcampaignCreative);

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
				info.AddValue("_afcampaignCreative", ((_afcampaignCreative!=null) && (_afcampaignCreative.Count>0) && !this.MarkedForDeletion)?_afcampaignCreative:null);
				info.AddValue("_afcampaignCollectionViaAfcampaignCreative", ((_afcampaignCollectionViaAfcampaignCreative!=null) && (_afcampaignCollectionViaAfcampaignCreative.Count>0) && !this.MarkedForDeletion)?_afcampaignCollectionViaAfcampaignCreative:null);
				info.AddValue("_afcreativeFormat", (!this.MarkedForDeletion?_afcreativeFormat:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AfcreativeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AfcreativeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AfcreativeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfcampaignCreative' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCreative()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignCreativeFields.CreativeId, null, ComparisonOperator.Equal, this.CreativeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCollectionViaAfcampaignCreative()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfcampaignCollectionViaAfcampaignCreative"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcreativeFields.CreativeId, null, ComparisonOperator.Equal, this.CreativeId, "AfcreativeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AfcreativeFormat' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcreativeFormat()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcreativeFormatFields.CreativeFormatId, null, ComparisonOperator.Equal, this.CreativeFormatId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.AfcreativeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AfcreativeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._afcampaignCreative);
			collectionsQueue.Enqueue(this._afcampaignCollectionViaAfcampaignCreative);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._afcampaignCreative = (EntityCollection<AfcampaignCreativeEntity>) collectionsQueue.Dequeue();
			this._afcampaignCollectionViaAfcampaignCreative = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._afcampaignCreative != null)
			{
				return true;
			}
			if (this._afcampaignCollectionViaAfcampaignCreative != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignCreativeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignCreativeEntityFactory))) : null);
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
			toReturn.Add("AfcreativeFormat", _afcreativeFormat);
			toReturn.Add("AfcampaignCreative", _afcampaignCreative);
			toReturn.Add("AfcampaignCollectionViaAfcampaignCreative", _afcampaignCollectionViaAfcampaignCreative);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_afcampaignCreative!=null)
			{
				_afcampaignCreative.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignCollectionViaAfcampaignCreative!=null)
			{
				_afcampaignCollectionViaAfcampaignCreative.ActiveContext = base.ActiveContext;
			}
			if(_afcreativeFormat!=null)
			{
				_afcreativeFormat.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_afcampaignCreative = null;
			_afcampaignCollectionViaAfcampaignCreative = null;
			_afcreativeFormat = null;

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

			_fieldsCustomProperties.Add("CreativeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreativeCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreativeName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreativeContent", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreativeFormatId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afcreativeFormat</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfcreativeFormat(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afcreativeFormat, new PropertyChangedEventHandler( OnAfcreativeFormatPropertyChanged ), "AfcreativeFormat", AfcreativeEntity.Relations.AfcreativeFormatEntityUsingCreativeFormatId, true, signalRelatedEntity, "Afcreative", resetFKFields, new int[] { (int)AfcreativeFieldIndex.CreativeFormatId } );		
			_afcreativeFormat = null;
		}

		/// <summary> setups the sync logic for member _afcreativeFormat</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfcreativeFormat(IEntity2 relatedEntity)
		{
			if(_afcreativeFormat!=relatedEntity)
			{
				DesetupSyncAfcreativeFormat(true, true);
				_afcreativeFormat = (AfcreativeFormatEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afcreativeFormat, new PropertyChangedEventHandler( OnAfcreativeFormatPropertyChanged ), "AfcreativeFormat", AfcreativeEntity.Relations.AfcreativeFormatEntityUsingCreativeFormatId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfcreativeFormatPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AfcreativeEntity</param>
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
		public  static AfcreativeRelations Relations
		{
			get	{ return new AfcreativeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfcampaignCreative' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCreative
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfcampaignCreativeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignCreativeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfcampaignCreative")[0], (int)HealthYes.Data.EntityType.AfcreativeEntity, (int)HealthYes.Data.EntityType.AfcampaignCreativeEntity, 0, null, null, null, null, "AfcampaignCreative", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCollectionViaAfcampaignCreative
		{
			get
			{
				IEntityRelation intermediateRelation = AfcreativeEntity.Relations.AfcampaignCreativeEntityUsingCreativeId;
				intermediateRelation.SetAliases(string.Empty, "AfcampaignCreative_");
				return new PrefetchPathElement2(new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.AfcreativeEntity, (int)HealthYes.Data.EntityType.AfcampaignEntity, 0, null, null, GetRelationsForField("AfcampaignCollectionViaAfcampaignCreative"), null, "AfcampaignCollectionViaAfcampaignCreative", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfcreativeFormat' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcreativeFormat
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfcreativeFormatEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfcreativeFormat")[0], (int)HealthYes.Data.EntityType.AfcreativeEntity, (int)HealthYes.Data.EntityType.AfcreativeFormatEntity, 0, null, null, null, null, "AfcreativeFormat", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AfcreativeEntity.CustomProperties;}
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
			get { return AfcreativeEntity.FieldsCustomProperties;}
		}

		/// <summary> The CreativeId property of the Entity Afcreative<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCreative"."CreativeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CreativeId
		{
			get { return (System.Int64)GetValue((int)AfcreativeFieldIndex.CreativeId, true); }
			set	{ SetValue((int)AfcreativeFieldIndex.CreativeId, value); }
		}

		/// <summary> The CreativeCode property of the Entity Afcreative<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCreative"."CreativeCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CreativeCode
		{
			get { return (System.String)GetValue((int)AfcreativeFieldIndex.CreativeCode, true); }
			set	{ SetValue((int)AfcreativeFieldIndex.CreativeCode, value); }
		}

		/// <summary> The CreativeName property of the Entity Afcreative<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCreative"."CreativeName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CreativeName
		{
			get { return (System.String)GetValue((int)AfcreativeFieldIndex.CreativeName, true); }
			set	{ SetValue((int)AfcreativeFieldIndex.CreativeName, value); }
		}

		/// <summary> The CreativeContent property of the Entity Afcreative<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCreative"."CreativeContent"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CreativeContent
		{
			get { return (System.String)GetValue((int)AfcreativeFieldIndex.CreativeContent, true); }
			set	{ SetValue((int)AfcreativeFieldIndex.CreativeContent, value); }
		}

		/// <summary> The CreatedDate property of the Entity Afcreative<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCreative"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfcreativeFieldIndex.CreatedDate, false); }
			set	{ SetValue((int)AfcreativeFieldIndex.CreatedDate, value); }
		}

		/// <summary> The LastModifiedDate property of the Entity Afcreative<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCreative"."LastModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastModifiedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfcreativeFieldIndex.LastModifiedDate, false); }
			set	{ SetValue((int)AfcreativeFieldIndex.LastModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity Afcreative<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCreative"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AfcreativeFieldIndex.IsActive, true); }
			set	{ SetValue((int)AfcreativeFieldIndex.IsActive, value); }
		}

		/// <summary> The CreativeFormatId property of the Entity Afcreative<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCreative"."CreativeFormatID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreativeFormatId
		{
			get { return (System.Int64)GetValue((int)AfcreativeFieldIndex.CreativeFormatId, true); }
			set	{ SetValue((int)AfcreativeFieldIndex.CreativeFormatId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignCreativeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignCreativeEntity))]
		public virtual EntityCollection<AfcampaignCreativeEntity> AfcampaignCreative
		{
			get
			{
				if(_afcampaignCreative==null)
				{
					_afcampaignCreative = new EntityCollection<AfcampaignCreativeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignCreativeEntityFactory)));
					_afcampaignCreative.SetContainingEntityInfo(this, "Afcreative");
				}
				return _afcampaignCreative;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> AfcampaignCollectionViaAfcampaignCreative
		{
			get
			{
				if(_afcampaignCollectionViaAfcampaignCreative==null)
				{
					_afcampaignCollectionViaAfcampaignCreative = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaignCollectionViaAfcampaignCreative.IsReadOnly=true;
				}
				return _afcampaignCollectionViaAfcampaignCreative;
			}
		}

		/// <summary> Gets / sets related entity of type 'AfcreativeFormatEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfcreativeFormatEntity AfcreativeFormat
		{
			get
			{
				return _afcreativeFormat;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfcreativeFormat(value);
				}
				else
				{
					if(value==null)
					{
						if(_afcreativeFormat != null)
						{
							_afcreativeFormat.UnsetRelatedEntity(this, "Afcreative");
						}
					}
					else
					{
						if(_afcreativeFormat!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Afcreative");
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
			get { return (int)HealthYes.Data.EntityType.AfcreativeEntity; }
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
