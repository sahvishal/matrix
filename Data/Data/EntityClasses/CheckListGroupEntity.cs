///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:50
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
	/// Entity class which represents the entity 'CheckListGroup'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CheckListGroupEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CheckListGroupEntity> _checkListGroup_;
		private EntityCollection<ChecklistGroupQuestionEntity> _checklistGroupQuestion;
		private EntityCollection<CheckListQuestionEntity> _checkListQuestionCollectionViaChecklistGroupQuestion_;
		private EntityCollection<CheckListQuestionEntity> _checkListQuestionCollectionViaChecklistGroupQuestion;
		private EntityCollection<LookupEntity> _lookupCollectionViaCheckListGroup;
		private CheckListGroupEntity _checkListGroup;
		private LookupEntity _lookup;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CheckListGroup</summary>
			public static readonly string CheckListGroup = "CheckListGroup";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name CheckListGroup_</summary>
			public static readonly string CheckListGroup_ = "CheckListGroup_";
			/// <summary>Member name ChecklistGroupQuestion</summary>
			public static readonly string ChecklistGroupQuestion = "ChecklistGroupQuestion";
			/// <summary>Member name CheckListQuestionCollectionViaChecklistGroupQuestion_</summary>
			public static readonly string CheckListQuestionCollectionViaChecklistGroupQuestion_ = "CheckListQuestionCollectionViaChecklistGroupQuestion_";
			/// <summary>Member name CheckListQuestionCollectionViaChecklistGroupQuestion</summary>
			public static readonly string CheckListQuestionCollectionViaChecklistGroupQuestion = "CheckListQuestionCollectionViaChecklistGroupQuestion";
			/// <summary>Member name LookupCollectionViaCheckListGroup</summary>
			public static readonly string LookupCollectionViaCheckListGroup = "LookupCollectionViaCheckListGroup";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CheckListGroupEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CheckListGroupEntity():base("CheckListGroupEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CheckListGroupEntity(IEntityFields2 fields):base("CheckListGroupEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CheckListGroupEntity</param>
		public CheckListGroupEntity(IValidator validator):base("CheckListGroupEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CheckListGroup which data should be fetched into this CheckListGroup object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckListGroupEntity(System.Int64 id):base("CheckListGroupEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CheckListGroup which data should be fetched into this CheckListGroup object</param>
		/// <param name="validator">The custom validator object for this CheckListGroupEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckListGroupEntity(System.Int64 id, IValidator validator):base("CheckListGroupEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CheckListGroupEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_checkListGroup_ = (EntityCollection<CheckListGroupEntity>)info.GetValue("_checkListGroup_", typeof(EntityCollection<CheckListGroupEntity>));
				_checklistGroupQuestion = (EntityCollection<ChecklistGroupQuestionEntity>)info.GetValue("_checklistGroupQuestion", typeof(EntityCollection<ChecklistGroupQuestionEntity>));
				_checkListQuestionCollectionViaChecklistGroupQuestion_ = (EntityCollection<CheckListQuestionEntity>)info.GetValue("_checkListQuestionCollectionViaChecklistGroupQuestion_", typeof(EntityCollection<CheckListQuestionEntity>));
				_checkListQuestionCollectionViaChecklistGroupQuestion = (EntityCollection<CheckListQuestionEntity>)info.GetValue("_checkListQuestionCollectionViaChecklistGroupQuestion", typeof(EntityCollection<CheckListQuestionEntity>));
				_lookupCollectionViaCheckListGroup = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCheckListGroup", typeof(EntityCollection<LookupEntity>));
				_checkListGroup = (CheckListGroupEntity)info.GetValue("_checkListGroup", typeof(CheckListGroupEntity));
				if(_checkListGroup!=null)
				{
					_checkListGroup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CheckListGroupFieldIndex)fieldIndex)
			{
				case CheckListGroupFieldIndex.TypeId:
					DesetupSyncLookup(true, false);
					break;
				case CheckListGroupFieldIndex.ParentId:
					DesetupSyncCheckListGroup(true, false);
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
				case "CheckListGroup":
					this.CheckListGroup = (CheckListGroupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "CheckListGroup_":
					this.CheckListGroup_.Add((CheckListGroupEntity)entity);
					break;
				case "ChecklistGroupQuestion":
					this.ChecklistGroupQuestion.Add((ChecklistGroupQuestionEntity)entity);
					break;
				case "CheckListQuestionCollectionViaChecklistGroupQuestion_":
					this.CheckListQuestionCollectionViaChecklistGroupQuestion_.IsReadOnly = false;
					this.CheckListQuestionCollectionViaChecklistGroupQuestion_.Add((CheckListQuestionEntity)entity);
					this.CheckListQuestionCollectionViaChecklistGroupQuestion_.IsReadOnly = true;
					break;
				case "CheckListQuestionCollectionViaChecklistGroupQuestion":
					this.CheckListQuestionCollectionViaChecklistGroupQuestion.IsReadOnly = false;
					this.CheckListQuestionCollectionViaChecklistGroupQuestion.Add((CheckListQuestionEntity)entity);
					this.CheckListQuestionCollectionViaChecklistGroupQuestion.IsReadOnly = true;
					break;
				case "LookupCollectionViaCheckListGroup":
					this.LookupCollectionViaCheckListGroup.IsReadOnly = false;
					this.LookupCollectionViaCheckListGroup.Add((LookupEntity)entity);
					this.LookupCollectionViaCheckListGroup.IsReadOnly = true;
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
			return CheckListGroupEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CheckListGroup":
					toReturn.Add(CheckListGroupEntity.Relations.CheckListGroupEntityUsingIdParentId);
					break;
				case "Lookup":
					toReturn.Add(CheckListGroupEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "CheckListGroup_":
					toReturn.Add(CheckListGroupEntity.Relations.CheckListGroupEntityUsingParentId);
					break;
				case "ChecklistGroupQuestion":
					toReturn.Add(CheckListGroupEntity.Relations.ChecklistGroupQuestionEntityUsingGroupId);
					break;
				case "CheckListQuestionCollectionViaChecklistGroupQuestion_":
					toReturn.Add(CheckListGroupEntity.Relations.ChecklistGroupQuestionEntityUsingGroupId, "CheckListGroupEntity__", "ChecklistGroupQuestion_", JoinHint.None);
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListQuestionEntityUsingQuestionId, "ChecklistGroupQuestion_", string.Empty, JoinHint.None);
					break;
				case "CheckListQuestionCollectionViaChecklistGroupQuestion":
					toReturn.Add(CheckListGroupEntity.Relations.ChecklistGroupQuestionEntityUsingGroupId, "CheckListGroupEntity__", "ChecklistGroupQuestion_", JoinHint.None);
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListQuestionEntityUsingParentId, "ChecklistGroupQuestion_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCheckListGroup":
					toReturn.Add(CheckListGroupEntity.Relations.CheckListGroupEntityUsingParentId, "CheckListGroupEntity__", "CheckListGroup_", JoinHint.None);
					toReturn.Add(CheckListGroupEntity.Relations.LookupEntityUsingTypeId, "CheckListGroup_", string.Empty, JoinHint.None);
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
				case "CheckListGroup":
					SetupSyncCheckListGroup(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "CheckListGroup_":
					this.CheckListGroup_.Add((CheckListGroupEntity)relatedEntity);
					break;
				case "ChecklistGroupQuestion":
					this.ChecklistGroupQuestion.Add((ChecklistGroupQuestionEntity)relatedEntity);
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
				case "CheckListGroup":
					DesetupSyncCheckListGroup(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "CheckListGroup_":
					base.PerformRelatedEntityRemoval(this.CheckListGroup_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ChecklistGroupQuestion":
					base.PerformRelatedEntityRemoval(this.ChecklistGroupQuestion, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_checkListGroup!=null)
			{
				toReturn.Add(_checkListGroup);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CheckListGroup_);
			toReturn.Add(this.ChecklistGroupQuestion);

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
				info.AddValue("_checkListGroup_", ((_checkListGroup_!=null) && (_checkListGroup_.Count>0) && !this.MarkedForDeletion)?_checkListGroup_:null);
				info.AddValue("_checklistGroupQuestion", ((_checklistGroupQuestion!=null) && (_checklistGroupQuestion.Count>0) && !this.MarkedForDeletion)?_checklistGroupQuestion:null);
				info.AddValue("_checkListQuestionCollectionViaChecklistGroupQuestion_", ((_checkListQuestionCollectionViaChecklistGroupQuestion_!=null) && (_checkListQuestionCollectionViaChecklistGroupQuestion_.Count>0) && !this.MarkedForDeletion)?_checkListQuestionCollectionViaChecklistGroupQuestion_:null);
				info.AddValue("_checkListQuestionCollectionViaChecklistGroupQuestion", ((_checkListQuestionCollectionViaChecklistGroupQuestion!=null) && (_checkListQuestionCollectionViaChecklistGroupQuestion.Count>0) && !this.MarkedForDeletion)?_checkListQuestionCollectionViaChecklistGroupQuestion:null);
				info.AddValue("_lookupCollectionViaCheckListGroup", ((_lookupCollectionViaCheckListGroup!=null) && (_lookupCollectionViaCheckListGroup.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCheckListGroup:null);
				info.AddValue("_checkListGroup", (!this.MarkedForDeletion?_checkListGroup:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CheckListGroupFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CheckListGroupFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CheckListGroupRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListGroup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListGroupFields.ParentId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChecklistGroupQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChecklistGroupQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChecklistGroupQuestionFields.GroupId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListQuestionCollectionViaChecklistGroupQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListQuestionCollectionViaChecklistGroupQuestion_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListGroupFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListGroupEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListQuestionCollectionViaChecklistGroupQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListQuestionCollectionViaChecklistGroupQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListGroupFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListGroupEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCheckListGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCheckListGroup"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListGroupFields.Id, null, ComparisonOperator.Equal, this.Id, "CheckListGroupEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CheckListGroup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListGroupFields.Id, null, ComparisonOperator.Equal, this.ParentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CheckListGroupEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._checkListGroup_);
			collectionsQueue.Enqueue(this._checklistGroupQuestion);
			collectionsQueue.Enqueue(this._checkListQuestionCollectionViaChecklistGroupQuestion_);
			collectionsQueue.Enqueue(this._checkListQuestionCollectionViaChecklistGroupQuestion);
			collectionsQueue.Enqueue(this._lookupCollectionViaCheckListGroup);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._checkListGroup_ = (EntityCollection<CheckListGroupEntity>) collectionsQueue.Dequeue();
			this._checklistGroupQuestion = (EntityCollection<ChecklistGroupQuestionEntity>) collectionsQueue.Dequeue();
			this._checkListQuestionCollectionViaChecklistGroupQuestion_ = (EntityCollection<CheckListQuestionEntity>) collectionsQueue.Dequeue();
			this._checkListQuestionCollectionViaChecklistGroupQuestion = (EntityCollection<CheckListQuestionEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCheckListGroup = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._checkListGroup_ != null)
			{
				return true;
			}
			if (this._checklistGroupQuestion != null)
			{
				return true;
			}
			if (this._checkListQuestionCollectionViaChecklistGroupQuestion_ != null)
			{
				return true;
			}
			if (this._checkListQuestionCollectionViaChecklistGroupQuestion != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCheckListGroup != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CheckListGroup", _checkListGroup);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("CheckListGroup_", _checkListGroup_);
			toReturn.Add("ChecklistGroupQuestion", _checklistGroupQuestion);
			toReturn.Add("CheckListQuestionCollectionViaChecklistGroupQuestion_", _checkListQuestionCollectionViaChecklistGroupQuestion_);
			toReturn.Add("CheckListQuestionCollectionViaChecklistGroupQuestion", _checkListQuestionCollectionViaChecklistGroupQuestion);
			toReturn.Add("LookupCollectionViaCheckListGroup", _lookupCollectionViaCheckListGroup);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_checkListGroup_!=null)
			{
				_checkListGroup_.ActiveContext = base.ActiveContext;
			}
			if(_checklistGroupQuestion!=null)
			{
				_checklistGroupQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListQuestionCollectionViaChecklistGroupQuestion_!=null)
			{
				_checkListQuestionCollectionViaChecklistGroupQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_checkListQuestionCollectionViaChecklistGroupQuestion!=null)
			{
				_checkListQuestionCollectionViaChecklistGroupQuestion.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCheckListGroup!=null)
			{
				_lookupCollectionViaCheckListGroup.ActiveContext = base.ActiveContext;
			}
			if(_checkListGroup!=null)
			{
				_checkListGroup.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_checkListGroup_ = null;
			_checklistGroupQuestion = null;
			_checkListQuestionCollectionViaChecklistGroupQuestion_ = null;
			_checkListQuestionCollectionViaChecklistGroupQuestion = null;
			_lookupCollectionViaCheckListGroup = null;
			_checkListGroup = null;
			_lookup = null;

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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _checkListGroup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCheckListGroup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _checkListGroup, new PropertyChangedEventHandler( OnCheckListGroupPropertyChanged ), "CheckListGroup", CheckListGroupEntity.Relations.CheckListGroupEntityUsingIdParentId, true, signalRelatedEntity, "CheckListGroup_", resetFKFields, new int[] { (int)CheckListGroupFieldIndex.ParentId } );		
			_checkListGroup = null;
		}

		/// <summary> setups the sync logic for member _checkListGroup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCheckListGroup(IEntity2 relatedEntity)
		{
			if(_checkListGroup!=relatedEntity)
			{
				DesetupSyncCheckListGroup(true, true);
				_checkListGroup = (CheckListGroupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _checkListGroup, new PropertyChangedEventHandler( OnCheckListGroupPropertyChanged ), "CheckListGroup", CheckListGroupEntity.Relations.CheckListGroupEntityUsingIdParentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCheckListGroupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CheckListGroupEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "CheckListGroup", resetFKFields, new int[] { (int)CheckListGroupFieldIndex.TypeId } );		
			_lookup = null;
		}

		/// <summary> setups the sync logic for member _lookup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup(IEntity2 relatedEntity)
		{
			if(_lookup!=relatedEntity)
			{
				DesetupSyncLookup(true, true);
				_lookup = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CheckListGroupEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CheckListGroupEntity</param>
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
		public  static CheckListGroupRelations Relations
		{
			get	{ return new CheckListGroupRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListGroup_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CheckListGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListGroup_")[0], (int)Falcon.Data.EntityType.CheckListGroupEntity, (int)Falcon.Data.EntityType.CheckListGroupEntity, 0, null, null, null, null, "CheckListGroup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChecklistGroupQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChecklistGroupQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChecklistGroupQuestion")[0], (int)Falcon.Data.EntityType.CheckListGroupEntity, (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, 0, null, null, null, null, "ChecklistGroupQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListQuestionCollectionViaChecklistGroupQuestion_
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListGroupEntity.Relations.ChecklistGroupQuestionEntityUsingGroupId;
				intermediateRelation.SetAliases(string.Empty, "ChecklistGroupQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListGroupEntity, (int)Falcon.Data.EntityType.CheckListQuestionEntity, 0, null, null, GetRelationsForField("CheckListQuestionCollectionViaChecklistGroupQuestion_"), null, "CheckListQuestionCollectionViaChecklistGroupQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListQuestionCollectionViaChecklistGroupQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListGroupEntity.Relations.ChecklistGroupQuestionEntityUsingGroupId;
				intermediateRelation.SetAliases(string.Empty, "ChecklistGroupQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListGroupEntity, (int)Falcon.Data.EntityType.CheckListQuestionEntity, 0, null, null, GetRelationsForField("CheckListQuestionCollectionViaChecklistGroupQuestion"), null, "CheckListQuestionCollectionViaChecklistGroupQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCheckListGroup
		{
			get
			{
				IEntityRelation intermediateRelation = CheckListGroupEntity.Relations.CheckListGroupEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "CheckListGroup_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckListGroupEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCheckListGroup"), null, "LookupCollectionViaCheckListGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListGroup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListGroup")[0], (int)Falcon.Data.EntityType.CheckListGroupEntity, (int)Falcon.Data.EntityType.CheckListGroupEntity, 0, null, null, null, null, "CheckListGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CheckListGroupEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CheckListGroupEntity.CustomProperties;}
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
			get { return CheckListGroupEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity CheckListGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListGroup"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CheckListGroupFieldIndex.Id, true); }
			set	{ SetValue((int)CheckListGroupFieldIndex.Id, value); }
		}

		/// <summary> The Name property of the Entity CheckListGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListGroup"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CheckListGroupFieldIndex.Name, true); }
			set	{ SetValue((int)CheckListGroupFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity CheckListGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListGroup"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CheckListGroupFieldIndex.Description, true); }
			set	{ SetValue((int)CheckListGroupFieldIndex.Description, value); }
		}

		/// <summary> The TypeId property of the Entity CheckListGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListGroup"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)CheckListGroupFieldIndex.TypeId, true); }
			set	{ SetValue((int)CheckListGroupFieldIndex.TypeId, value); }
		}

		/// <summary> The ParentId property of the Entity CheckListGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListGroup"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CheckListGroupFieldIndex.ParentId, false); }
			set	{ SetValue((int)CheckListGroupFieldIndex.ParentId, value); }
		}

		/// <summary> The Alias property of the Entity CheckListGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListGroup"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)CheckListGroupFieldIndex.Alias, true); }
			set	{ SetValue((int)CheckListGroupFieldIndex.Alias, value); }
		}

		/// <summary> The IsActive property of the Entity CheckListGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListGroup"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CheckListGroupFieldIndex.IsActive, true); }
			set	{ SetValue((int)CheckListGroupFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListGroupEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListGroupEntity))]
		public virtual EntityCollection<CheckListGroupEntity> CheckListGroup_
		{
			get
			{
				if(_checkListGroup_==null)
				{
					_checkListGroup_ = new EntityCollection<CheckListGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListGroupEntityFactory)));
					_checkListGroup_.SetContainingEntityInfo(this, "CheckListGroup");
				}
				return _checkListGroup_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChecklistGroupQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChecklistGroupQuestionEntity))]
		public virtual EntityCollection<ChecklistGroupQuestionEntity> ChecklistGroupQuestion
		{
			get
			{
				if(_checklistGroupQuestion==null)
				{
					_checklistGroupQuestion = new EntityCollection<ChecklistGroupQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory)));
					_checklistGroupQuestion.SetContainingEntityInfo(this, "CheckListGroup");
				}
				return _checklistGroupQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListQuestionEntity))]
		public virtual EntityCollection<CheckListQuestionEntity> CheckListQuestionCollectionViaChecklistGroupQuestion_
		{
			get
			{
				if(_checkListQuestionCollectionViaChecklistGroupQuestion_==null)
				{
					_checkListQuestionCollectionViaChecklistGroupQuestion_ = new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory)));
					_checkListQuestionCollectionViaChecklistGroupQuestion_.IsReadOnly=true;
				}
				return _checkListQuestionCollectionViaChecklistGroupQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListQuestionEntity))]
		public virtual EntityCollection<CheckListQuestionEntity> CheckListQuestionCollectionViaChecklistGroupQuestion
		{
			get
			{
				if(_checkListQuestionCollectionViaChecklistGroupQuestion==null)
				{
					_checkListQuestionCollectionViaChecklistGroupQuestion = new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory)));
					_checkListQuestionCollectionViaChecklistGroupQuestion.IsReadOnly=true;
				}
				return _checkListQuestionCollectionViaChecklistGroupQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCheckListGroup
		{
			get
			{
				if(_lookupCollectionViaCheckListGroup==null)
				{
					_lookupCollectionViaCheckListGroup = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCheckListGroup.IsReadOnly=true;
				}
				return _lookupCollectionViaCheckListGroup;
			}
		}

		/// <summary> Gets / sets related entity of type 'CheckListGroupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CheckListGroupEntity CheckListGroup
		{
			get
			{
				return _checkListGroup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCheckListGroup(value);
				}
				else
				{
					if(value==null)
					{
						if(_checkListGroup != null)
						{
							_checkListGroup.UnsetRelatedEntity(this, "CheckListGroup_");
						}
					}
					else
					{
						if(_checkListGroup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListGroup_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup
		{
			get
			{
				return _lookup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup != null)
						{
							_lookup.UnsetRelatedEntity(this, "CheckListGroup");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListGroup");
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
			get { return (int)Falcon.Data.EntityType.CheckListGroupEntity; }
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
