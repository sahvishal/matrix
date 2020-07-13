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
	/// Entity class which represents the entity 'CheckListTemplateQuestion'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CheckListTemplateQuestionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private ChecklistGroupQuestionEntity _checklistGroupQuestion;
		private CheckListQuestionEntity _checkListQuestion;
		private CheckListTemplateEntity _checkListTemplate;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ChecklistGroupQuestion</summary>
			public static readonly string ChecklistGroupQuestion = "ChecklistGroupQuestion";
			/// <summary>Member name CheckListQuestion</summary>
			public static readonly string CheckListQuestion = "CheckListQuestion";
			/// <summary>Member name CheckListTemplate</summary>
			public static readonly string CheckListTemplate = "CheckListTemplate";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CheckListTemplateQuestionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CheckListTemplateQuestionEntity():base("CheckListTemplateQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CheckListTemplateQuestionEntity(IEntityFields2 fields):base("CheckListTemplateQuestionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CheckListTemplateQuestionEntity</param>
		public CheckListTemplateQuestionEntity(IValidator validator):base("CheckListTemplateQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="templateId">PK value for CheckListTemplateQuestion which data should be fetched into this CheckListTemplateQuestion object</param>
		/// <param name="groupQuestionId">PK value for CheckListTemplateQuestion which data should be fetched into this CheckListTemplateQuestion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckListTemplateQuestionEntity(System.Int64 templateId, System.Int64 groupQuestionId):base("CheckListTemplateQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TemplateId = templateId;
			this.GroupQuestionId = groupQuestionId;
		}

		/// <summary> CTor</summary>
		/// <param name="templateId">PK value for CheckListTemplateQuestion which data should be fetched into this CheckListTemplateQuestion object</param>
		/// <param name="groupQuestionId">PK value for CheckListTemplateQuestion which data should be fetched into this CheckListTemplateQuestion object</param>
		/// <param name="validator">The custom validator object for this CheckListTemplateQuestionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckListTemplateQuestionEntity(System.Int64 templateId, System.Int64 groupQuestionId, IValidator validator):base("CheckListTemplateQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TemplateId = templateId;
			this.GroupQuestionId = groupQuestionId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CheckListTemplateQuestionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_checklistGroupQuestion = (ChecklistGroupQuestionEntity)info.GetValue("_checklistGroupQuestion", typeof(ChecklistGroupQuestionEntity));
				if(_checklistGroupQuestion!=null)
				{
					_checklistGroupQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_checkListQuestion = (CheckListQuestionEntity)info.GetValue("_checkListQuestion", typeof(CheckListQuestionEntity));
				if(_checkListQuestion!=null)
				{
					_checkListQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_checkListTemplate = (CheckListTemplateEntity)info.GetValue("_checkListTemplate", typeof(CheckListTemplateEntity));
				if(_checkListTemplate!=null)
				{
					_checkListTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CheckListTemplateQuestionFieldIndex)fieldIndex)
			{
				case CheckListTemplateQuestionFieldIndex.TemplateId:
					DesetupSyncCheckListTemplate(true, false);
					break;
				case CheckListTemplateQuestionFieldIndex.QuestionId:
					DesetupSyncCheckListQuestion(true, false);
					break;
				case CheckListTemplateQuestionFieldIndex.GroupQuestionId:
					DesetupSyncChecklistGroupQuestion(true, false);
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
				case "ChecklistGroupQuestion":
					this.ChecklistGroupQuestion = (ChecklistGroupQuestionEntity)entity;
					break;
				case "CheckListQuestion":
					this.CheckListQuestion = (CheckListQuestionEntity)entity;
					break;
				case "CheckListTemplate":
					this.CheckListTemplate = (CheckListTemplateEntity)entity;
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
			return CheckListTemplateQuestionEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ChecklistGroupQuestion":
					toReturn.Add(CheckListTemplateQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingGroupQuestionId);
					break;
				case "CheckListQuestion":
					toReturn.Add(CheckListTemplateQuestionEntity.Relations.CheckListQuestionEntityUsingQuestionId);
					break;
				case "CheckListTemplate":
					toReturn.Add(CheckListTemplateQuestionEntity.Relations.CheckListTemplateEntityUsingTemplateId);
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
				case "ChecklistGroupQuestion":
					SetupSyncChecklistGroupQuestion(relatedEntity);
					break;
				case "CheckListQuestion":
					SetupSyncCheckListQuestion(relatedEntity);
					break;
				case "CheckListTemplate":
					SetupSyncCheckListTemplate(relatedEntity);
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
				case "ChecklistGroupQuestion":
					DesetupSyncChecklistGroupQuestion(false, true);
					break;
				case "CheckListQuestion":
					DesetupSyncCheckListQuestion(false, true);
					break;
				case "CheckListTemplate":
					DesetupSyncCheckListTemplate(false, true);
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
			if(_checklistGroupQuestion!=null)
			{
				toReturn.Add(_checklistGroupQuestion);
			}
			if(_checkListQuestion!=null)
			{
				toReturn.Add(_checkListQuestion);
			}
			if(_checkListTemplate!=null)
			{
				toReturn.Add(_checkListTemplate);
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


				info.AddValue("_checklistGroupQuestion", (!this.MarkedForDeletion?_checklistGroupQuestion:null));
				info.AddValue("_checkListQuestion", (!this.MarkedForDeletion?_checkListQuestion:null));
				info.AddValue("_checkListTemplate", (!this.MarkedForDeletion?_checkListTemplate:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CheckListTemplateQuestionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CheckListTemplateQuestionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CheckListTemplateQuestionRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ChecklistGroupQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChecklistGroupQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChecklistGroupQuestionFields.Id, null, ComparisonOperator.Equal, this.GroupQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CheckListQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListQuestionFields.Id, null, ComparisonOperator.Equal, this.QuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.TemplateId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CheckListTemplateQuestionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateQuestionEntityFactory));
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
			toReturn.Add("ChecklistGroupQuestion", _checklistGroupQuestion);
			toReturn.Add("CheckListQuestion", _checkListQuestion);
			toReturn.Add("CheckListTemplate", _checkListTemplate);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_checklistGroupQuestion!=null)
			{
				_checklistGroupQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListQuestion!=null)
			{
				_checkListQuestion.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplate!=null)
			{
				_checkListTemplate.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_checklistGroupQuestion = null;
			_checkListQuestion = null;
			_checkListTemplate = null;

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

			_fieldsCustomProperties.Add("TemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("QuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupQuestionId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _checklistGroupQuestion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncChecklistGroupQuestion(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _checklistGroupQuestion, new PropertyChangedEventHandler( OnChecklistGroupQuestionPropertyChanged ), "ChecklistGroupQuestion", CheckListTemplateQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingGroupQuestionId, true, signalRelatedEntity, "CheckListTemplateQuestion", resetFKFields, new int[] { (int)CheckListTemplateQuestionFieldIndex.GroupQuestionId } );		
			_checklistGroupQuestion = null;
		}

		/// <summary> setups the sync logic for member _checklistGroupQuestion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncChecklistGroupQuestion(IEntity2 relatedEntity)
		{
			if(_checklistGroupQuestion!=relatedEntity)
			{
				DesetupSyncChecklistGroupQuestion(true, true);
				_checklistGroupQuestion = (ChecklistGroupQuestionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _checklistGroupQuestion, new PropertyChangedEventHandler( OnChecklistGroupQuestionPropertyChanged ), "ChecklistGroupQuestion", CheckListTemplateQuestionEntity.Relations.ChecklistGroupQuestionEntityUsingGroupQuestionId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnChecklistGroupQuestionPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _checkListQuestion, new PropertyChangedEventHandler( OnCheckListQuestionPropertyChanged ), "CheckListQuestion", CheckListTemplateQuestionEntity.Relations.CheckListQuestionEntityUsingQuestionId, true, signalRelatedEntity, "CheckListTemplateQuestion", resetFKFields, new int[] { (int)CheckListTemplateQuestionFieldIndex.QuestionId } );		
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
				base.PerformSetupSyncRelatedEntity( _checkListQuestion, new PropertyChangedEventHandler( OnCheckListQuestionPropertyChanged ), "CheckListQuestion", CheckListTemplateQuestionEntity.Relations.CheckListQuestionEntityUsingQuestionId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _checkListTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCheckListTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _checkListTemplate, new PropertyChangedEventHandler( OnCheckListTemplatePropertyChanged ), "CheckListTemplate", CheckListTemplateQuestionEntity.Relations.CheckListTemplateEntityUsingTemplateId, true, signalRelatedEntity, "CheckListTemplateQuestion", resetFKFields, new int[] { (int)CheckListTemplateQuestionFieldIndex.TemplateId } );		
			_checkListTemplate = null;
		}

		/// <summary> setups the sync logic for member _checkListTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCheckListTemplate(IEntity2 relatedEntity)
		{
			if(_checkListTemplate!=relatedEntity)
			{
				DesetupSyncCheckListTemplate(true, true);
				_checkListTemplate = (CheckListTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _checkListTemplate, new PropertyChangedEventHandler( OnCheckListTemplatePropertyChanged ), "CheckListTemplate", CheckListTemplateQuestionEntity.Relations.CheckListTemplateEntityUsingTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCheckListTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CheckListTemplateQuestionEntity</param>
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
		public  static CheckListTemplateQuestionRelations Relations
		{
			get	{ return new CheckListTemplateQuestionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChecklistGroupQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChecklistGroupQuestion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ChecklistGroupQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChecklistGroupQuestion")[0], (int)Falcon.Data.EntityType.CheckListTemplateQuestionEntity, (int)Falcon.Data.EntityType.ChecklistGroupQuestionEntity, 0, null, null, null, null, "ChecklistGroupQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("CheckListQuestion")[0], (int)Falcon.Data.EntityType.CheckListTemplateQuestionEntity, (int)Falcon.Data.EntityType.CheckListQuestionEntity, 0, null, null, null, null, "CheckListQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListTemplate")[0], (int)Falcon.Data.EntityType.CheckListTemplateQuestionEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, null, null, "CheckListTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CheckListTemplateQuestionEntity.CustomProperties;}
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
			get { return CheckListTemplateQuestionEntity.FieldsCustomProperties;}
		}

		/// <summary> The TemplateId property of the Entity CheckListTemplateQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplateQuestion"."TemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 TemplateId
		{
			get { return (System.Int64)GetValue((int)CheckListTemplateQuestionFieldIndex.TemplateId, true); }
			set	{ SetValue((int)CheckListTemplateQuestionFieldIndex.TemplateId, value); }
		}

		/// <summary> The QuestionId property of the Entity CheckListTemplateQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplateQuestion"."QuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 QuestionId
		{
			get { return (System.Int64)GetValue((int)CheckListTemplateQuestionFieldIndex.QuestionId, true); }
			set	{ SetValue((int)CheckListTemplateQuestionFieldIndex.QuestionId, value); }
		}

		/// <summary> The GroupQuestionId property of the Entity CheckListTemplateQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheckListTemplateQuestion"."GroupQuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 GroupQuestionId
		{
			get { return (System.Int64)GetValue((int)CheckListTemplateQuestionFieldIndex.GroupQuestionId, true); }
			set	{ SetValue((int)CheckListTemplateQuestionFieldIndex.GroupQuestionId, value); }
		}



		/// <summary> Gets / sets related entity of type 'ChecklistGroupQuestionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ChecklistGroupQuestionEntity ChecklistGroupQuestion
		{
			get
			{
				return _checklistGroupQuestion;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncChecklistGroupQuestion(value);
				}
				else
				{
					if(value==null)
					{
						if(_checklistGroupQuestion != null)
						{
							_checklistGroupQuestion.UnsetRelatedEntity(this, "CheckListTemplateQuestion");
						}
					}
					else
					{
						if(_checklistGroupQuestion!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListTemplateQuestion");
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
							_checkListQuestion.UnsetRelatedEntity(this, "CheckListTemplateQuestion");
						}
					}
					else
					{
						if(_checkListQuestion!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListTemplateQuestion");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CheckListTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CheckListTemplateEntity CheckListTemplate
		{
			get
			{
				return _checkListTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCheckListTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_checkListTemplate != null)
						{
							_checkListTemplate.UnsetRelatedEntity(this, "CheckListTemplateQuestion");
						}
					}
					else
					{
						if(_checkListTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CheckListTemplateQuestion");
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
			get { return (int)Falcon.Data.EntityType.CheckListTemplateQuestionEntity; }
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
