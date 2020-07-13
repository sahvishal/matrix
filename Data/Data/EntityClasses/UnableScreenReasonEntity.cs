///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:24 AM
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
	/// Entity class which represents the entity 'UnableScreenReason'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class UnableScreenReasonEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AaaunableScreenReasonEntity> _aaaunableScreenReason;
		private EntityCollection<AsiunableScreenReasonEntity> _asiunableScreenReason;
		private EntityCollection<AaatestResultsEntity> _aaatestResultsCollectionViaAaaunableScreenReason;
		private EntityCollection<AsitestResultsEntity> _asitestResultsCollectionViaAsiunableScreenReason;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name AaaunableScreenReason</summary>
			public static readonly string AaaunableScreenReason = "AaaunableScreenReason";
			/// <summary>Member name AsiunableScreenReason</summary>
			public static readonly string AsiunableScreenReason = "AsiunableScreenReason";
			/// <summary>Member name AaatestResultsCollectionViaAaaunableScreenReason</summary>
			public static readonly string AaatestResultsCollectionViaAaaunableScreenReason = "AaatestResultsCollectionViaAaaunableScreenReason";
			/// <summary>Member name AsitestResultsCollectionViaAsiunableScreenReason</summary>
			public static readonly string AsitestResultsCollectionViaAsiunableScreenReason = "AsitestResultsCollectionViaAsiunableScreenReason";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static UnableScreenReasonEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public UnableScreenReasonEntity():base("UnableScreenReasonEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public UnableScreenReasonEntity(IEntityFields2 fields):base("UnableScreenReasonEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this UnableScreenReasonEntity</param>
		public UnableScreenReasonEntity(IValidator validator):base("UnableScreenReasonEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="unableScreenReasonId">PK value for UnableScreenReason which data should be fetched into this UnableScreenReason object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UnableScreenReasonEntity(System.Byte unableScreenReasonId):base("UnableScreenReasonEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.UnableScreenReasonId = unableScreenReasonId;
		}

		/// <summary> CTor</summary>
		/// <param name="unableScreenReasonId">PK value for UnableScreenReason which data should be fetched into this UnableScreenReason object</param>
		/// <param name="validator">The custom validator object for this UnableScreenReasonEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UnableScreenReasonEntity(System.Byte unableScreenReasonId, IValidator validator):base("UnableScreenReasonEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.UnableScreenReasonId = unableScreenReasonId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected UnableScreenReasonEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_aaaunableScreenReason = (EntityCollection<AaaunableScreenReasonEntity>)info.GetValue("_aaaunableScreenReason", typeof(EntityCollection<AaaunableScreenReasonEntity>));
				_asiunableScreenReason = (EntityCollection<AsiunableScreenReasonEntity>)info.GetValue("_asiunableScreenReason", typeof(EntityCollection<AsiunableScreenReasonEntity>));
				_aaatestResultsCollectionViaAaaunableScreenReason = (EntityCollection<AaatestResultsEntity>)info.GetValue("_aaatestResultsCollectionViaAaaunableScreenReason", typeof(EntityCollection<AaatestResultsEntity>));
				_asitestResultsCollectionViaAsiunableScreenReason = (EntityCollection<AsitestResultsEntity>)info.GetValue("_asitestResultsCollectionViaAsiunableScreenReason", typeof(EntityCollection<AsitestResultsEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((UnableScreenReasonFieldIndex)fieldIndex)
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

				case "AaaunableScreenReason":
					this.AaaunableScreenReason.Add((AaaunableScreenReasonEntity)entity);
					break;
				case "AsiunableScreenReason":
					this.AsiunableScreenReason.Add((AsiunableScreenReasonEntity)entity);
					break;
				case "AaatestResultsCollectionViaAaaunableScreenReason":
					this.AaatestResultsCollectionViaAaaunableScreenReason.IsReadOnly = false;
					this.AaatestResultsCollectionViaAaaunableScreenReason.Add((AaatestResultsEntity)entity);
					this.AaatestResultsCollectionViaAaaunableScreenReason.IsReadOnly = true;
					break;
				case "AsitestResultsCollectionViaAsiunableScreenReason":
					this.AsitestResultsCollectionViaAsiunableScreenReason.IsReadOnly = false;
					this.AsitestResultsCollectionViaAsiunableScreenReason.Add((AsitestResultsEntity)entity);
					this.AsitestResultsCollectionViaAsiunableScreenReason.IsReadOnly = true;
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
			return UnableScreenReasonEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "AaaunableScreenReason":
					toReturn.Add(UnableScreenReasonEntity.Relations.AaaunableScreenReasonEntityUsingUnableScreenReasonId);
					break;
				case "AsiunableScreenReason":
					toReturn.Add(UnableScreenReasonEntity.Relations.AsiunableScreenReasonEntityUsingUnableScreenReasonId);
					break;
				case "AaatestResultsCollectionViaAaaunableScreenReason":
					toReturn.Add(UnableScreenReasonEntity.Relations.AaaunableScreenReasonEntityUsingUnableScreenReasonId, "UnableScreenReasonEntity__", "AaaunableScreenReason_", JoinHint.None);
					toReturn.Add(AaaunableScreenReasonEntity.Relations.AaatestResultsEntityUsingAaatestId, "AaaunableScreenReason_", string.Empty, JoinHint.None);
					break;
				case "AsitestResultsCollectionViaAsiunableScreenReason":
					toReturn.Add(UnableScreenReasonEntity.Relations.AsiunableScreenReasonEntityUsingUnableScreenReasonId, "UnableScreenReasonEntity__", "AsiunableScreenReason_", JoinHint.None);
					toReturn.Add(AsiunableScreenReasonEntity.Relations.AsitestResultsEntityUsingAsitestId, "AsiunableScreenReason_", string.Empty, JoinHint.None);
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

				case "AaaunableScreenReason":
					this.AaaunableScreenReason.Add((AaaunableScreenReasonEntity)relatedEntity);
					break;
				case "AsiunableScreenReason":
					this.AsiunableScreenReason.Add((AsiunableScreenReasonEntity)relatedEntity);
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

				case "AaaunableScreenReason":
					base.PerformRelatedEntityRemoval(this.AaaunableScreenReason, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AsiunableScreenReason":
					base.PerformRelatedEntityRemoval(this.AsiunableScreenReason, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.AaaunableScreenReason);
			toReturn.Add(this.AsiunableScreenReason);

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
				info.AddValue("_aaaunableScreenReason", ((_aaaunableScreenReason!=null) && (_aaaunableScreenReason.Count>0) && !this.MarkedForDeletion)?_aaaunableScreenReason:null);
				info.AddValue("_asiunableScreenReason", ((_asiunableScreenReason!=null) && (_asiunableScreenReason.Count>0) && !this.MarkedForDeletion)?_asiunableScreenReason:null);
				info.AddValue("_aaatestResultsCollectionViaAaaunableScreenReason", ((_aaatestResultsCollectionViaAaaunableScreenReason!=null) && (_aaatestResultsCollectionViaAaaunableScreenReason.Count>0) && !this.MarkedForDeletion)?_aaatestResultsCollectionViaAaaunableScreenReason:null);
				info.AddValue("_asitestResultsCollectionViaAsiunableScreenReason", ((_asitestResultsCollectionViaAsiunableScreenReason!=null) && (_asitestResultsCollectionViaAsiunableScreenReason.Count>0) && !this.MarkedForDeletion)?_asitestResultsCollectionViaAsiunableScreenReason:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(UnableScreenReasonFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(UnableScreenReasonFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new UnableScreenReasonRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AaaunableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAaaunableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AaaunableScreenReasonFields.UnableScreenReasonId, null, ComparisonOperator.Equal, this.UnableScreenReasonId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AsiunableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAsiunableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AsiunableScreenReasonFields.UnableScreenReasonId, null, ComparisonOperator.Equal, this.UnableScreenReasonId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AaatestResults' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAaatestResultsCollectionViaAaaunableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AaatestResultsCollectionViaAaaunableScreenReason"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UnableScreenReasonFields.UnableScreenReasonId, null, ComparisonOperator.Equal, this.UnableScreenReasonId, "UnableScreenReasonEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AsitestResults' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAsitestResultsCollectionViaAsiunableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AsitestResultsCollectionViaAsiunableScreenReason"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UnableScreenReasonFields.UnableScreenReasonId, null, ComparisonOperator.Equal, this.UnableScreenReasonId, "UnableScreenReasonEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.UnableScreenReasonEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(UnableScreenReasonEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._aaaunableScreenReason);
			collectionsQueue.Enqueue(this._asiunableScreenReason);
			collectionsQueue.Enqueue(this._aaatestResultsCollectionViaAaaunableScreenReason);
			collectionsQueue.Enqueue(this._asitestResultsCollectionViaAsiunableScreenReason);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._aaaunableScreenReason = (EntityCollection<AaaunableScreenReasonEntity>) collectionsQueue.Dequeue();
			this._asiunableScreenReason = (EntityCollection<AsiunableScreenReasonEntity>) collectionsQueue.Dequeue();
			this._aaatestResultsCollectionViaAaaunableScreenReason = (EntityCollection<AaatestResultsEntity>) collectionsQueue.Dequeue();
			this._asitestResultsCollectionViaAsiunableScreenReason = (EntityCollection<AsitestResultsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._aaaunableScreenReason != null)
			{
				return true;
			}
			if (this._asiunableScreenReason != null)
			{
				return true;
			}
			if (this._aaatestResultsCollectionViaAaaunableScreenReason != null)
			{
				return true;
			}
			if (this._asitestResultsCollectionViaAsiunableScreenReason != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AaaunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaaunableScreenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AsiunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsiunableScreenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AaatestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestResultsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AsitestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsitestResultsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("AaaunableScreenReason", _aaaunableScreenReason);
			toReturn.Add("AsiunableScreenReason", _asiunableScreenReason);
			toReturn.Add("AaatestResultsCollectionViaAaaunableScreenReason", _aaatestResultsCollectionViaAaaunableScreenReason);
			toReturn.Add("AsitestResultsCollectionViaAsiunableScreenReason", _asitestResultsCollectionViaAsiunableScreenReason);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_aaaunableScreenReason!=null)
			{
				_aaaunableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_asiunableScreenReason!=null)
			{
				_asiunableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_aaatestResultsCollectionViaAaaunableScreenReason!=null)
			{
				_aaatestResultsCollectionViaAaaunableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_asitestResultsCollectionViaAsiunableScreenReason!=null)
			{
				_asitestResultsCollectionViaAsiunableScreenReason.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_aaaunableScreenReason = null;
			_asiunableScreenReason = null;
			_aaatestResultsCollectionViaAaaunableScreenReason = null;
			_asitestResultsCollectionViaAsiunableScreenReason = null;


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

			_fieldsCustomProperties.Add("UnableScreenReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Label", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsNotesEnabled", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this UnableScreenReasonEntity</param>
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
		public  static UnableScreenReasonRelations Relations
		{
			get	{ return new UnableScreenReasonRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AaaunableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAaaunableScreenReason
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AaaunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaaunableScreenReasonEntityFactory))),
					(IEntityRelation)GetRelationsForField("AaaunableScreenReason")[0], (int)HealthYes.Data.EntityType.UnableScreenReasonEntity, (int)HealthYes.Data.EntityType.AaaunableScreenReasonEntity, 0, null, null, null, null, "AaaunableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AsiunableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAsiunableScreenReason
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AsiunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsiunableScreenReasonEntityFactory))),
					(IEntityRelation)GetRelationsForField("AsiunableScreenReason")[0], (int)HealthYes.Data.EntityType.UnableScreenReasonEntity, (int)HealthYes.Data.EntityType.AsiunableScreenReasonEntity, 0, null, null, null, null, "AsiunableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AaatestResults' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAaatestResultsCollectionViaAaaunableScreenReason
		{
			get
			{
				IEntityRelation intermediateRelation = UnableScreenReasonEntity.Relations.AaaunableScreenReasonEntityUsingUnableScreenReasonId;
				intermediateRelation.SetAliases(string.Empty, "AaaunableScreenReason_");
				return new PrefetchPathElement2(new EntityCollection<AaatestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestResultsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.UnableScreenReasonEntity, (int)HealthYes.Data.EntityType.AaatestResultsEntity, 0, null, null, GetRelationsForField("AaatestResultsCollectionViaAaaunableScreenReason"), null, "AaatestResultsCollectionViaAaaunableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AsitestResults' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAsitestResultsCollectionViaAsiunableScreenReason
		{
			get
			{
				IEntityRelation intermediateRelation = UnableScreenReasonEntity.Relations.AsiunableScreenReasonEntityUsingUnableScreenReasonId;
				intermediateRelation.SetAliases(string.Empty, "AsiunableScreenReason_");
				return new PrefetchPathElement2(new EntityCollection<AsitestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsitestResultsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.UnableScreenReasonEntity, (int)HealthYes.Data.EntityType.AsitestResultsEntity, 0, null, null, GetRelationsForField("AsitestResultsCollectionViaAsiunableScreenReason"), null, "AsitestResultsCollectionViaAsiunableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return UnableScreenReasonEntity.CustomProperties;}
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
			get { return UnableScreenReasonEntity.FieldsCustomProperties;}
		}

		/// <summary> The UnableScreenReasonId property of the Entity UnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUnableScreenReason_Legacy"."UnableScreenReasonID"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Byte UnableScreenReasonId
		{
			get { return (System.Byte)GetValue((int)UnableScreenReasonFieldIndex.UnableScreenReasonId, true); }
			set	{ SetValue((int)UnableScreenReasonFieldIndex.UnableScreenReasonId, value); }
		}

		/// <summary> The Label property of the Entity UnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUnableScreenReason_Legacy"."Label"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Label
		{
			get { return (System.String)GetValue((int)UnableScreenReasonFieldIndex.Label, true); }
			set	{ SetValue((int)UnableScreenReasonFieldIndex.Label, value); }
		}

		/// <summary> The TestId property of the Entity UnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUnableScreenReason_Legacy"."TestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 TestId
		{
			get { return (System.Int32)GetValue((int)UnableScreenReasonFieldIndex.TestId, true); }
			set	{ SetValue((int)UnableScreenReasonFieldIndex.TestId, value); }
		}

		/// <summary> The IsNotesEnabled property of the Entity UnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblUnableScreenReason_Legacy"."IsNotesEnabled"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsNotesEnabled
		{
			get { return (System.Boolean)GetValue((int)UnableScreenReasonFieldIndex.IsNotesEnabled, true); }
			set	{ SetValue((int)UnableScreenReasonFieldIndex.IsNotesEnabled, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AaaunableScreenReasonEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AaaunableScreenReasonEntity))]
		public virtual EntityCollection<AaaunableScreenReasonEntity> AaaunableScreenReason
		{
			get
			{
				if(_aaaunableScreenReason==null)
				{
					_aaaunableScreenReason = new EntityCollection<AaaunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaaunableScreenReasonEntityFactory)));
					_aaaunableScreenReason.SetContainingEntityInfo(this, "UnableScreenReason");
				}
				return _aaaunableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AsiunableScreenReasonEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AsiunableScreenReasonEntity))]
		public virtual EntityCollection<AsiunableScreenReasonEntity> AsiunableScreenReason
		{
			get
			{
				if(_asiunableScreenReason==null)
				{
					_asiunableScreenReason = new EntityCollection<AsiunableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsiunableScreenReasonEntityFactory)));
					_asiunableScreenReason.SetContainingEntityInfo(this, "UnableScreenReason");
				}
				return _asiunableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AaatestResultsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AaatestResultsEntity))]
		public virtual EntityCollection<AaatestResultsEntity> AaatestResultsCollectionViaAaaunableScreenReason
		{
			get
			{
				if(_aaatestResultsCollectionViaAaaunableScreenReason==null)
				{
					_aaatestResultsCollectionViaAaaunableScreenReason = new EntityCollection<AaatestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestResultsEntityFactory)));
					_aaatestResultsCollectionViaAaaunableScreenReason.IsReadOnly=true;
				}
				return _aaatestResultsCollectionViaAaaunableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AsitestResultsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AsitestResultsEntity))]
		public virtual EntityCollection<AsitestResultsEntity> AsitestResultsCollectionViaAsiunableScreenReason
		{
			get
			{
				if(_asitestResultsCollectionViaAsiunableScreenReason==null)
				{
					_asitestResultsCollectionViaAsiunableScreenReason = new EntityCollection<AsitestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AsitestResultsEntityFactory)));
					_asitestResultsCollectionViaAsiunableScreenReason.IsReadOnly=true;
				}
				return _asitestResultsCollectionViaAsiunableScreenReason;
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
			get { return (int)HealthYes.Data.EntityType.UnableScreenReasonEntity; }
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
