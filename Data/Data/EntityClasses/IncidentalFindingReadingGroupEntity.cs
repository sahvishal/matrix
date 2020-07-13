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
	/// Entity class which represents the entity 'IncidentalFindingReadingGroup'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class IncidentalFindingReadingGroupEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity> _incidentalFindingIncidentalFindingReadingGroup;
		private EntityCollection<IncidentalFindingReadingGroupItemEntity> _incidentalFindingReadingGroupItem;
		private EntityCollection<IncidentalFindingsEntity> _incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name IncidentalFindingIncidentalFindingReadingGroup</summary>
			public static readonly string IncidentalFindingIncidentalFindingReadingGroup = "IncidentalFindingIncidentalFindingReadingGroup";
			/// <summary>Member name IncidentalFindingReadingGroupItem</summary>
			public static readonly string IncidentalFindingReadingGroupItem = "IncidentalFindingReadingGroupItem";
			/// <summary>Member name IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup</summary>
			public static readonly string IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup = "IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static IncidentalFindingReadingGroupEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public IncidentalFindingReadingGroupEntity():base("IncidentalFindingReadingGroupEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public IncidentalFindingReadingGroupEntity(IEntityFields2 fields):base("IncidentalFindingReadingGroupEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this IncidentalFindingReadingGroupEntity</param>
		public IncidentalFindingReadingGroupEntity(IValidator validator):base("IncidentalFindingReadingGroupEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="groupId">PK value for IncidentalFindingReadingGroup which data should be fetched into this IncidentalFindingReadingGroup object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public IncidentalFindingReadingGroupEntity(System.Int64 groupId):base("IncidentalFindingReadingGroupEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.GroupId = groupId;
		}

		/// <summary> CTor</summary>
		/// <param name="groupId">PK value for IncidentalFindingReadingGroup which data should be fetched into this IncidentalFindingReadingGroup object</param>
		/// <param name="validator">The custom validator object for this IncidentalFindingReadingGroupEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public IncidentalFindingReadingGroupEntity(System.Int64 groupId, IValidator validator):base("IncidentalFindingReadingGroupEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.GroupId = groupId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected IncidentalFindingReadingGroupEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_incidentalFindingIncidentalFindingReadingGroup = (EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>)info.GetValue("_incidentalFindingIncidentalFindingReadingGroup", typeof(EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>));
				_incidentalFindingReadingGroupItem = (EntityCollection<IncidentalFindingReadingGroupItemEntity>)info.GetValue("_incidentalFindingReadingGroupItem", typeof(EntityCollection<IncidentalFindingReadingGroupItemEntity>));
				_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup = (EntityCollection<IncidentalFindingsEntity>)info.GetValue("_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup", typeof(EntityCollection<IncidentalFindingsEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((IncidentalFindingReadingGroupFieldIndex)fieldIndex)
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

				case "IncidentalFindingIncidentalFindingReadingGroup":
					this.IncidentalFindingIncidentalFindingReadingGroup.Add((IncidentalFindingIncidentalFindingReadingGroupEntity)entity);
					break;
				case "IncidentalFindingReadingGroupItem":
					this.IncidentalFindingReadingGroupItem.Add((IncidentalFindingReadingGroupItemEntity)entity);
					break;
				case "IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup":
					this.IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup.IsReadOnly = false;
					this.IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup.Add((IncidentalFindingsEntity)entity);
					this.IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup.IsReadOnly = true;
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
			return IncidentalFindingReadingGroupEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "IncidentalFindingIncidentalFindingReadingGroup":
					toReturn.Add(IncidentalFindingReadingGroupEntity.Relations.IncidentalFindingIncidentalFindingReadingGroupEntityUsingGroupId);
					break;
				case "IncidentalFindingReadingGroupItem":
					toReturn.Add(IncidentalFindingReadingGroupEntity.Relations.IncidentalFindingReadingGroupItemEntityUsingGroupId);
					break;
				case "IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup":
					toReturn.Add(IncidentalFindingReadingGroupEntity.Relations.IncidentalFindingIncidentalFindingReadingGroupEntityUsingGroupId, "IncidentalFindingReadingGroupEntity__", "IncidentalFindingIncidentalFindingReadingGroup_", JoinHint.None);
					toReturn.Add(IncidentalFindingIncidentalFindingReadingGroupEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingId, "IncidentalFindingIncidentalFindingReadingGroup_", string.Empty, JoinHint.None);
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

				case "IncidentalFindingIncidentalFindingReadingGroup":
					this.IncidentalFindingIncidentalFindingReadingGroup.Add((IncidentalFindingIncidentalFindingReadingGroupEntity)relatedEntity);
					break;
				case "IncidentalFindingReadingGroupItem":
					this.IncidentalFindingReadingGroupItem.Add((IncidentalFindingReadingGroupItemEntity)relatedEntity);
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

				case "IncidentalFindingIncidentalFindingReadingGroup":
					base.PerformRelatedEntityRemoval(this.IncidentalFindingIncidentalFindingReadingGroup, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "IncidentalFindingReadingGroupItem":
					base.PerformRelatedEntityRemoval(this.IncidentalFindingReadingGroupItem, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.IncidentalFindingIncidentalFindingReadingGroup);
			toReturn.Add(this.IncidentalFindingReadingGroupItem);

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
				info.AddValue("_incidentalFindingIncidentalFindingReadingGroup", ((_incidentalFindingIncidentalFindingReadingGroup!=null) && (_incidentalFindingIncidentalFindingReadingGroup.Count>0) && !this.MarkedForDeletion)?_incidentalFindingIncidentalFindingReadingGroup:null);
				info.AddValue("_incidentalFindingReadingGroupItem", ((_incidentalFindingReadingGroupItem!=null) && (_incidentalFindingReadingGroupItem.Count>0) && !this.MarkedForDeletion)?_incidentalFindingReadingGroupItem:null);
				info.AddValue("_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup", ((_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup!=null) && (_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup.Count>0) && !this.MarkedForDeletion)?_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(IncidentalFindingReadingGroupFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(IncidentalFindingReadingGroupFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new IncidentalFindingReadingGroupRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindingIncidentalFindingReadingGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingIncidentalFindingReadingGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingIncidentalFindingReadingGroupFields.GroupId, null, ComparisonOperator.Equal, this.GroupId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindingReadingGroupItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingReadingGroupItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingReadingGroupItemFields.GroupId, null, ComparisonOperator.Equal, this.GroupId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingReadingGroupFields.GroupId, null, ComparisonOperator.Equal, this.GroupId, "IncidentalFindingReadingGroupEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.IncidentalFindingReadingGroupEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._incidentalFindingIncidentalFindingReadingGroup);
			collectionsQueue.Enqueue(this._incidentalFindingReadingGroupItem);
			collectionsQueue.Enqueue(this._incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._incidentalFindingIncidentalFindingReadingGroup = (EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingReadingGroupItem = (EntityCollection<IncidentalFindingReadingGroupItemEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup = (EntityCollection<IncidentalFindingsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._incidentalFindingIncidentalFindingReadingGroup != null)
			{
				return true;
			}
			if (this._incidentalFindingReadingGroupItem != null)
			{
				return true;
			}
			if (this._incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingIncidentalFindingReadingGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingReadingGroupItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("IncidentalFindingIncidentalFindingReadingGroup", _incidentalFindingIncidentalFindingReadingGroup);
			toReturn.Add("IncidentalFindingReadingGroupItem", _incidentalFindingReadingGroupItem);
			toReturn.Add("IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup", _incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_incidentalFindingIncidentalFindingReadingGroup!=null)
			{
				_incidentalFindingIncidentalFindingReadingGroup.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingReadingGroupItem!=null)
			{
				_incidentalFindingReadingGroupItem.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup!=null)
			{
				_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_incidentalFindingIncidentalFindingReadingGroup = null;
			_incidentalFindingReadingGroupItem = null;
			_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup = null;


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

			_fieldsCustomProperties.Add("GroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DisplayControlType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this IncidentalFindingReadingGroupEntity</param>
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
		public  static IncidentalFindingReadingGroupRelations Relations
		{
			get	{ return new IncidentalFindingReadingGroupRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindingIncidentalFindingReadingGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingIncidentalFindingReadingGroup
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingIncidentalFindingReadingGroupEntityFactory))),
					(IEntityRelation)GetRelationsForField("IncidentalFindingIncidentalFindingReadingGroup")[0], (int)Falcon.Data.EntityType.IncidentalFindingReadingGroupEntity, (int)Falcon.Data.EntityType.IncidentalFindingIncidentalFindingReadingGroupEntity, 0, null, null, null, null, "IncidentalFindingIncidentalFindingReadingGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindingReadingGroupItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingReadingGroupItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<IncidentalFindingReadingGroupItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("IncidentalFindingReadingGroupItem")[0], (int)Falcon.Data.EntityType.IncidentalFindingReadingGroupEntity, (int)Falcon.Data.EntityType.IncidentalFindingReadingGroupItemEntity, 0, null, null, null, null, "IncidentalFindingReadingGroupItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup
		{
			get
			{
				IEntityRelation intermediateRelation = IncidentalFindingReadingGroupEntity.Relations.IncidentalFindingIncidentalFindingReadingGroupEntityUsingGroupId;
				intermediateRelation.SetAliases(string.Empty, "IncidentalFindingIncidentalFindingReadingGroup_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.IncidentalFindingReadingGroupEntity, (int)Falcon.Data.EntityType.IncidentalFindingsEntity, 0, null, null, GetRelationsForField("IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup"), null, "IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return IncidentalFindingReadingGroupEntity.CustomProperties;}
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
			get { return IncidentalFindingReadingGroupEntity.FieldsCustomProperties;}
		}

		/// <summary> The GroupId property of the Entity IncidentalFindingReadingGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindingReadingGroup"."GroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 GroupId
		{
			get { return (System.Int64)GetValue((int)IncidentalFindingReadingGroupFieldIndex.GroupId, true); }
			set	{ SetValue((int)IncidentalFindingReadingGroupFieldIndex.GroupId, value); }
		}

		/// <summary> The GroupName property of the Entity IncidentalFindingReadingGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindingReadingGroup"."GroupName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GroupName
		{
			get { return (System.String)GetValue((int)IncidentalFindingReadingGroupFieldIndex.GroupName, true); }
			set	{ SetValue((int)IncidentalFindingReadingGroupFieldIndex.GroupName, value); }
		}

		/// <summary> The DisplayControlType property of the Entity IncidentalFindingReadingGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindingReadingGroup"."DisplayControlType"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DisplayControlType
		{
			get { return (System.String)GetValue((int)IncidentalFindingReadingGroupFieldIndex.DisplayControlType, true); }
			set	{ SetValue((int)IncidentalFindingReadingGroupFieldIndex.DisplayControlType, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity IncidentalFindingReadingGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindingReadingGroup"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)IncidentalFindingReadingGroupFieldIndex.CreatedByOrgRoleUserId, false); }
			set	{ SetValue((int)IncidentalFindingReadingGroupFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The CreatedOn property of the Entity IncidentalFindingReadingGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIncidentalFindingReadingGroup"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)IncidentalFindingReadingGroupFieldIndex.CreatedOn, false); }
			set	{ SetValue((int)IncidentalFindingReadingGroupFieldIndex.CreatedOn, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingIncidentalFindingReadingGroupEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingIncidentalFindingReadingGroupEntity))]
		public virtual EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity> IncidentalFindingIncidentalFindingReadingGroup
		{
			get
			{
				if(_incidentalFindingIncidentalFindingReadingGroup==null)
				{
					_incidentalFindingIncidentalFindingReadingGroup = new EntityCollection<IncidentalFindingIncidentalFindingReadingGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingIncidentalFindingReadingGroupEntityFactory)));
					_incidentalFindingIncidentalFindingReadingGroup.SetContainingEntityInfo(this, "IncidentalFindingReadingGroup");
				}
				return _incidentalFindingIncidentalFindingReadingGroup;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingReadingGroupItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingReadingGroupItemEntity))]
		public virtual EntityCollection<IncidentalFindingReadingGroupItemEntity> IncidentalFindingReadingGroupItem
		{
			get
			{
				if(_incidentalFindingReadingGroupItem==null)
				{
					_incidentalFindingReadingGroupItem = new EntityCollection<IncidentalFindingReadingGroupItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupItemEntityFactory)));
					_incidentalFindingReadingGroupItem.SetContainingEntityInfo(this, "IncidentalFindingReadingGroup");
				}
				return _incidentalFindingReadingGroupItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingsEntity))]
		public virtual EntityCollection<IncidentalFindingsEntity> IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup
		{
			get
			{
				if(_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup==null)
				{
					_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup = new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory)));
					_incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup.IsReadOnly=true;
				}
				return _incidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup;
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
			get { return (int)Falcon.Data.EntityType.IncidentalFindingReadingGroupEntity; }
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
