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
	/// Entity class which represents the entity 'ChecklistGroupQuestion'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ChecklistGroupQuestionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CheckListTemplateQuestionEntity> _checkListTemplateQuestion;
		private EntityCollection<CheckListQuestionEntity> _checkListQuestionCollectionViaCheckListTemplateQuestion;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaCheckListTemplateQuestion;
		private CheckListGroupEntity _checkListGroup;
		private CheckListQuestionEntity _checkListQuestion_;
		private CheckListQuestionEntity _checkListQuestion;

		
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
			/// <summary>Member name CheckListQuestion_</summary>
			public static readonly string CheckListQuestion_ = "CheckListQuestion_";
			/// <summary>Member name CheckListQuestion</summary>
			public static readonly string CheckListQuestion = "CheckListQuestion";
			/// <summary>Member name CheckListTemplateQuestion</summary>
			public static readonly string CheckListTemplateQuestion = "CheckListTemplateQuestion";
			/// <summary>Member name CheckListQuestionCollectionViaCheckListTemplateQuestion</summary>
			public static readonly string CheckListQuestionCollectionViaCheckListTemplateQuestion = "CheckListQuestionCollectionViaCheckListTemplateQuestion";
			/// <summary>Member name CheckListTemplateCollectionViaCheckListTemplateQuestion</summary>
			public static readonly string CheckListTemplateCollectionViaCheckListTemplateQuestion = "CheckListTemplateCollectionViaCheckListTemplateQuestion";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ChecklistGroupQuestionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ChecklistGroupQuestionEntity():base("ChecklistGroupQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ChecklistGroupQuestionEntity(IEntityFields2 fields):base("ChecklistGroupQuestionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ChecklistGroupQuestionEntity</param>
		public ChecklistGroupQuestionEntity(IValidator validator):base("ChecklistGroupQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for ChecklistGroupQuestion which data should be fetched into this ChecklistGroupQuestion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChecklistGroupQuestionEntity(System.Int64 id):base("ChecklistGroupQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for ChecklistGroupQuestion which data should be fetched into this ChecklistGroupQuestion object</param>
		/// <param name="validator">The custom validator object for this ChecklistGroupQuestionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChecklistGroupQuestionEntity(System.Int64 id, IValidator validator):base("ChecklistGroupQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ChecklistGroupQuestionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_checkListTemplateQuestion = (EntityCollection<CheckListTemplateQuestionEntity>)info.GetValue("_checkListTemplateQuestion", typeof(EntityCollection<CheckListTemplateQuestionEntity>));
				_checkListQuestionCollectionViaCheckListTemplateQuestion = (EntityCollection<CheckListQuestionEntity>)info.GetValue("_checkListQuestionCollectionViaCheckListTemplateQuestion", typeof(EntityCollection<CheckListQuestionEntity>));
				_checkListTemplateCollectionViaCheckListTemplateQuestion = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaCheckListTemplateQuestion", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListGroup = (CheckListGroupEntity)info.GetValue("_checkListGroup", typeof(CheckListGroupEntity));
				if(_checkListGroup!=null)
				{
					_checkListGroup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_checkListQuestion_ = (CheckListQuestionEntity)info.GetValue("_checkListQuestion_", typeof(CheckListQuestionEntity));
				if(_checkListQuestion_!=null)
				{
					_checkListQuestion_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_checkListQuestion = (CheckListQuestionEntity)info.GetValue("_checkListQuestion", typeof(CheckListQuestionEntity));
				if(_checkListQuestion!=null)
				{
					_checkListQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ChecklistGroupQuestionFieldIndex)fieldIndex)
			{
				case ChecklistGroupQuestionFieldIndex.GroupId:
					DesetupSyncCheckListGroup(true, false);
					break;
				case ChecklistGroupQuestionFieldIndex.QuestionId:
					DesetupSyncCheckListQuestion_(true, false);
					break;
				case ChecklistGroupQuestionFieldIndex.ParentId:
					DesetupSyncCheckListQuestion(true, false);
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
				case "CheckListQuestion_":
					this.CheckListQuestion_ = (CheckListQuestionEntity)entity;
					break;
				case "CheckListQuestion":
					this.CheckListQuestion = (CheckListQuestionEntity)entity;
					break;
				case "CheckListTemplateQuestion":
					this.CheckListTemplateQuestion.Add((CheckListTemplateQuestionEntity)entity);
					break;
				case "CheckListQuestionCollectionViaCheckListTemplateQuestion":
					this.CheckListQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly = false;
					this.CheckListQuestionCollectionViaCheckListTemplateQuestion.Add((CheckListQuestionEntity)entity);
					this.CheckListQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly = true;
					break;
				case "CheckListTemplateCollectionViaCheckListTemplateQuestion":
					this.CheckListTemplateCollectionViaCheckListTemplateQuestion.IsReadOnly = false;
					this.CheckListTemplateCollectionViaCheckListTemplateQuestion.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaCheckListTemplateQuestion.IsReadOnly = true;
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
			return ChecklistGroupQuestionEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListGroupEntityUsingGroupId);
					break;
				case "CheckListQuestion_":
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListQuestionEntityUsingQuestionId);
					break;
				case "CheckListQuestion":
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListQuestionEntityUsingParentId);
					break;
				case "CheckListTemplateQuestion":
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingGroupQuestionId);
					break;
				case "CheckListQuestionCollectionViaCheckListTemplateQuestion":
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingGroupQuestionId, "ChecklistGroupQuestionEntity__", "CheckListTemplateQuestion_", JoinHint.None);
					toReturn.Add(CheckListTemplateQuestionEntity.Relations.CheckListQuestionEntityUsingQuestionId, "CheckListTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaCheckListTemplateQuestion":
					toReturn.Add(ChecklistGroupQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingGroupQuestionId, "ChecklistGroupQuestionEntity__", "CheckListTemplateQuestion_", JoinHint.None);
					toReturn.Add(CheckListTemplateQuestionEntity.Relations.CheckListTemplateEntityUsingTemplateId, "CheckListTemplateQuestion_", string.Empty, JoinHint.None);
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
				case "CheckListQuestion_":
					SetupSyncCheckListQuestion_(relatedEntity);
					break;
				case "CheckListQuestion":
					SetupSyncCheckListQuestion(relatedEntity);
					break;
				case "CheckListTemplateQuestion":
					this.CheckListTemplateQuestion.Add((CheckListTemplateQuestionEntity)relatedEntity);
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
				case "CheckListQuestion_":
					DesetupSyncCheckListQuestion_(false, true);
					break;
				case "CheckListQuestion":
					DesetupSyncCheckListQuestion(false, true);
					break;
				case "CheckListTemplateQuestion":
					base.PerformRelatedEntityRemoval(this.CheckListTemplateQuestion, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_checkListQuestion_!=null)
			{
				toReturn.Add(_checkListQuestion_);
			}
			if(_checkListQuestion!=null)
			{
				toReturn.Add(_checkListQuestion);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CheckListTemplateQuestion);

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
				info.AddValue("_checkListTemplateQuestion", ((_checkListTemplateQuestion!=null) && (_checkListTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_checkListTemplateQuestion:null);
				info.AddValue("_checkListQuestionCollectionViaCheckListTemplateQuestion", ((_checkListQuestionCollectionViaCheckListTemplateQuestion!=null) && (_checkListQuestionCollectionViaCheckListTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_checkListQuestionCollectionViaCheckListTemplateQuestion:null);
				info.AddValue("_checkListTemplateCollectionViaCheckListTemplateQuestion", ((_checkListTemplateCollectionViaCheckListTemplateQuestion!=null) && (_checkListTemplateCollectionViaCheckListTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaCheckListTemplateQuestion:null);
				info.AddValue("_checkListGroup", (!this.MarkedForDeletion?_checkListGroup:null));
				info.AddValue("_checkListQuestion_", (!this.MarkedForDeletion?_checkListQuestion_:null));
				info.AddValue("_checkListQuestion", (!this.MarkedForDeletion?_checkListQuestion:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ChecklistGroupQuestionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ChecklistGroupQuestionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ChecklistGroupQuestionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateQuestionFields.GroupQuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListQuestionCollectionViaCheckListTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListQuestionCollectionViaCheckListTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChecklistGroupQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ChecklistGroupQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaCheckListTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaCheckListTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChecklistGroupQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ChecklistGroupQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CheckListGroup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListGroupFields.Id, null, ComparisonOperator.Equal, this.GroupId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CheckListQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CheckListQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.ParentId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ChecklistGroupQuestionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._checkListTemplateQuestion);
			collectionsQueue.Enqueue(this._checkListQuestionCollectionViaCheckListTemplateQuestion);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaCheckListTemplateQuestion);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._checkListTemplateQuestion = (EntityCollection<CheckListTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._checkListQuestionCollectionViaCheckListTemplateQuestion = (EntityCollection<CheckListQuestionEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaCheckListTemplateQuestion = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._checkListTemplateQuestion != null)
			{
				return true;
			}
			if (this._checkListQuestionCollectionViaCheckListTemplateQuestion != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaCheckListTemplateQuestion != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
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
			toReturn.Add("CheckListQuestion_", _checkListQuestion_);
			toReturn.Add("CheckListQuestion", _checkListQuestion);
			toReturn.Add("CheckListTemplateQuestion", _checkListTemplateQuestion);
			toReturn.Add("CheckListQuestionCollectionViaCheckListTemplateQuestion", _checkListQuestionCollectionViaCheckListTemplateQuestion);
			toReturn.Add("CheckListTemplateCollectionViaCheckListTemplateQuestion", _checkListTemplateCollectionViaCheckListTemplateQuestion);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_checkListTemplateQuestion!=null)
			{
				_checkListTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListQuestionCollectionViaCheckListTemplateQuestion!=null)
			{
				_checkListQuestionCollectionViaCheckListTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaCheckListTemplateQuestion!=null)
			{
				_checkListTemplateCollectionViaCheckListTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListGroup!=null)
			{
				_checkListGroup.ActiveContext = base.ActiveContext;
			}
			if(_checkListQuestion_!=null)
			{
				_checkListQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_checkListQuestion!=null)
			{
				_checkListQuestion.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_checkListTemplateQuestion = null;
			_checkListQuestionCollectionViaCheckListTemplateQuestion = null;
			_checkListTemplateCollectionViaCheckListTemplateQuestion = null;
			_checkListGroup = null;
			_checkListQuestion_ = null;
			_checkListQuestion = null;

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

			_fieldsCustomProperties.Add("GroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("QuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _checkListGroup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCheckListGroup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _checkListGroup, new PropertyChangedEventHandler( OnCheckListGroupPropertyChanged ), "CheckListGroup", ChecklistGroupQuestionEntity.Relations.CheckListGroupEntityUsingGroupId, true, signalRelatedEntity, "ChecklistGroupQuestion", resetFKFields, new int[] { (int)ChecklistGroupQuestionFieldIndex.GroupId } );		
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
				base.PerformSetupSyncRelatedEntity( _checkListGroup, new PropertyChangedEventHandler( OnCheckListGroupPropertyChanged ), "CheckListGroup", ChecklistGroupQuestionEntity.Relations.CheckListGroupEntityUsingGroupId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _checkListQuestion_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCheckListQuestion_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _checkListQuestion_, new PropertyChangedEventHandler( OnCheckListQuestion_PropertyChanged ), "CheckListQuestion_", ChecklistGroupQuestionEntity.Relations.CheckListQuestionEntityUsingQuestionId, true, signalRelatedEntity, "ChecklistGroupQuestion_", resetFKFields, new int[] { (int)ChecklistGroupQuestionFieldIndex.QuestionId } );		
			_checkListQuestion_ = null;
		}

		/// <summary> setups the sync logic for member _checkListQuestion_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCheckListQuestion_(IEntity2 relatedEntity)
		{
			if(_checkListQuestion_!=relatedEntity)
			{
				DesetupSyncCheckListQuestion_(true, true);
				_checkListQuestion_ = (CheckListQuestionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _checkListQuestion_, new PropertyChangedEventHandler( OnCheckListQuestion_PropertyChanged ), "CheckListQuestion_", ChecklistGroupQuestionEntity.Relations.CheckListQuestionEntityUsingQuestionId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCheckListQuestion_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _checkListQuestion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCheckListQuestion(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _checkListQuestion, new PropertyChangedEventHandler( OnCheckListQuestionPropertyChanged ), "CheckListQuestion", ChecklistGroupQuestionEntity.Relations.CheckListQuestionEntityUsingParentId, true, signalRelatedEntity, "ChecklistGroupQuestion", resetFKFields, new int[] { (int)ChecklistGroupQuestionFieldIndex.ParentId } );		
			_checkListQuestion = null;
		}

		/// <summary> setups the sync logic for member _checkListQuestion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCheckListQuestion(IEntity2 relatedEntity)
		{
			if(_checkListQuestion!=relatedEntity)
			{
				DesetupSyncCheckListQuestion(true, true);
				_checkListQuestion = (CheckListQuestionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _checkListQuestion, new PropertyChangedEventHandler( OnCheckListQuestionPropertyChanged ), "CheckListQuestion", ChecklistGroupQuestionEntity.Relations.CheckListQuestionEntityUsingParentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCheckListQuestionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ChecklistGroupQuestionEntity</param>
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
		public  static ChecklistGroupQuestionRelations Relations
		{
			get	{ return new ChecklistGroupQuestionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplateQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CheckListTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListTemplateQuestion")[0], (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, (int)Falcon.Data.EntityType.CheckListTemplateQuestionEntity, 0, null, null, null, null, "CheckListTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListQuestionCollectionViaCheckListTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = ChecklistGroupQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingGroupQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CheckListTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, (int)Falcon.Data.EntityType.CheckListQuestionEntity, 0, null, null, GetRelationsForField("CheckListQuestionCollectionViaCheckListTemplateQuestion"), null, "CheckListQuestionCollectionViaCheckListTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaCheckListTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = ChecklistGroupQuestionEntity.Relations.CheckListTemplateQuestionEntityUsingGroupQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CheckListTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaCheckListTemplateQuestion"), null, "CheckListTemplateCollectionViaCheckListTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("CheckListGroup")[0], (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, (int)Falcon.Data.EntityType.CheckListGroupEntity, 0, null, null, null, null, "CheckListGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListQuestion_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListQuestion_")[0], (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, (int)Falcon.Data.EntityType.CheckListQuestionEntity, 0, null, null, null, null, "CheckListQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListQuestion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListQuestion")[0], (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, (int)Falcon.Data.EntityType.CheckListQuestionEntity, 0, null, null, null, null, "CheckListQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ChecklistGroupQuestionEntity.CustomProperties;}
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
			get { return ChecklistGroupQuestionEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity ChecklistGroupQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChecklistGroupQuestion"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)ChecklistGroupQuestionFieldIndex.Id, true); }
			set	{ SetValue((int)ChecklistGroupQuestionFieldIndex.Id, value); }
		}

		/// <summary> The GroupId property of the Entity ChecklistGroupQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChecklistGroupQuestion"."GroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GroupId
		{
			get { return (System.Int64)GetValue((int)ChecklistGroupQuestionFieldIndex.GroupId, true); }
			set	{ SetValue((int)ChecklistGroupQuestionFieldIndex.GroupId, value); }
		}

		/// <summary> The QuestionId property of the Entity ChecklistGroupQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChecklistGroupQuestion"."QuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 QuestionId
		{
			get { return (System.Int64)GetValue((int)ChecklistGroupQuestionFieldIndex.QuestionId, true); }
			set	{ SetValue((int)ChecklistGroupQuestionFieldIndex.QuestionId, value); }
		}

		/// <summary> The ParentId property of the Entity ChecklistGroupQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChecklistGroupQuestion"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ChecklistGroupQuestionFieldIndex.ParentId, false); }
			set	{ SetValue((int)ChecklistGroupQuestionFieldIndex.ParentId, value); }
		}

		/// <summary> The IsActive property of the Entity ChecklistGroupQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChecklistGroupQuestion"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ChecklistGroupQuestionFieldIndex.IsActive, true); }
			set	{ SetValue((int)ChecklistGroupQuestionFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateQuestionEntity))]
		public virtual EntityCollection<CheckListTemplateQuestionEntity> CheckListTemplateQuestion
		{
			get
			{
				if(_checkListTemplateQuestion==null)
				{
					_checkListTemplateQuestion = new EntityCollection<CheckListTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateQuestionEntityFactory)));
					_checkListTemplateQuestion.SetContainingEntityInfo(this, "ChecklistGroupQuestion");
				}
				return _checkListTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListQuestionEntity))]
		public virtual EntityCollection<CheckListQuestionEntity> CheckListQuestionCollectionViaCheckListTemplateQuestion
		{
			get
			{
				if(_checkListQuestionCollectionViaCheckListTemplateQuestion==null)
				{
					_checkListQuestionCollectionViaCheckListTemplateQuestion = new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory)));
					_checkListQuestionCollectionViaCheckListTemplateQuestion.IsReadOnly=true;
				}
				return _checkListQuestionCollectionViaCheckListTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaCheckListTemplateQuestion
		{
			get
			{
				if(_checkListTemplateCollectionViaCheckListTemplateQuestion==null)
				{
					_checkListTemplateCollectionViaCheckListTemplateQuestion = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaCheckListTemplateQuestion.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaCheckListTemplateQuestion;
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
							_checkListGroup.UnsetRelatedEntity(this, "ChecklistGroupQuestion");
						}
					}
					else
					{
						if(_checkListGroup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChecklistGroupQuestion");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CheckListQuestionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CheckListQuestionEntity CheckListQuestion_
		{
			get
			{
				return _checkListQuestion_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCheckListQuestion_(value);
				}
				else
				{
					if(value==null)
					{
						if(_checkListQuestion_ != null)
						{
							_checkListQuestion_.UnsetRelatedEntity(this, "ChecklistGroupQuestion_");
						}
					}
					else
					{
						if(_checkListQuestion_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChecklistGroupQuestion_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CheckListQuestionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CheckListQuestionEntity CheckListQuestion
		{
			get
			{
				return _checkListQuestion;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCheckListQuestion(value);
				}
				else
				{
					if(value==null)
					{
						if(_checkListQuestion != null)
						{
							_checkListQuestion.UnsetRelatedEntity(this, "ChecklistGroupQuestion");
						}
					}
					else
					{
						if(_checkListQuestion!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChecklistGroupQuestion");
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
			get { return (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity; }
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
