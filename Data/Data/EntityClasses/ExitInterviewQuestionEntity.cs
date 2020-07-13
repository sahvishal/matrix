///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:52
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
	/// Entity class which represents the entity 'ExitInterviewQuestion'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ExitInterviewQuestionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ExitInterviewAnswerEntity> _exitInterviewAnswer;
		private EntityCollection<ExitInterviewQuestionEntity> _exitInterviewQuestion_;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaExitInterviewAnswer;
		private EntityCollection<LookupEntity> _lookupCollectionViaExitInterviewQuestion;
		private EntityCollection<LookupEntity> _lookupCollectionViaExitInterviewQuestion_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaExitInterviewAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaExitInterviewAnswer;
		private ExitInterviewQuestionEntity _exitInterviewQuestion;
		private LookupEntity _lookup_;
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
			/// <summary>Member name ExitInterviewQuestion</summary>
			public static readonly string ExitInterviewQuestion = "ExitInterviewQuestion";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name ExitInterviewAnswer</summary>
			public static readonly string ExitInterviewAnswer = "ExitInterviewAnswer";
			/// <summary>Member name ExitInterviewQuestion_</summary>
			public static readonly string ExitInterviewQuestion_ = "ExitInterviewQuestion_";
			/// <summary>Member name EventCustomersCollectionViaExitInterviewAnswer</summary>
			public static readonly string EventCustomersCollectionViaExitInterviewAnswer = "EventCustomersCollectionViaExitInterviewAnswer";
			/// <summary>Member name LookupCollectionViaExitInterviewQuestion</summary>
			public static readonly string LookupCollectionViaExitInterviewQuestion = "LookupCollectionViaExitInterviewQuestion";
			/// <summary>Member name LookupCollectionViaExitInterviewQuestion_</summary>
			public static readonly string LookupCollectionViaExitInterviewQuestion_ = "LookupCollectionViaExitInterviewQuestion_";
			/// <summary>Member name OrganizationRoleUserCollectionViaExitInterviewAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaExitInterviewAnswer_ = "OrganizationRoleUserCollectionViaExitInterviewAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaExitInterviewAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaExitInterviewAnswer = "OrganizationRoleUserCollectionViaExitInterviewAnswer";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ExitInterviewQuestionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ExitInterviewQuestionEntity():base("ExitInterviewQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ExitInterviewQuestionEntity(IEntityFields2 fields):base("ExitInterviewQuestionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ExitInterviewQuestionEntity</param>
		public ExitInterviewQuestionEntity(IValidator validator):base("ExitInterviewQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for ExitInterviewQuestion which data should be fetched into this ExitInterviewQuestion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ExitInterviewQuestionEntity(System.Int64 id):base("ExitInterviewQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for ExitInterviewQuestion which data should be fetched into this ExitInterviewQuestion object</param>
		/// <param name="validator">The custom validator object for this ExitInterviewQuestionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ExitInterviewQuestionEntity(System.Int64 id, IValidator validator):base("ExitInterviewQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ExitInterviewQuestionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_exitInterviewAnswer = (EntityCollection<ExitInterviewAnswerEntity>)info.GetValue("_exitInterviewAnswer", typeof(EntityCollection<ExitInterviewAnswerEntity>));
				_exitInterviewQuestion_ = (EntityCollection<ExitInterviewQuestionEntity>)info.GetValue("_exitInterviewQuestion_", typeof(EntityCollection<ExitInterviewQuestionEntity>));
				_eventCustomersCollectionViaExitInterviewAnswer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaExitInterviewAnswer", typeof(EntityCollection<EventCustomersEntity>));
				_lookupCollectionViaExitInterviewQuestion = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaExitInterviewQuestion", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaExitInterviewQuestion_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaExitInterviewQuestion_", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaExitInterviewAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaExitInterviewAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaExitInterviewAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaExitInterviewAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_exitInterviewQuestion = (ExitInterviewQuestionEntity)info.GetValue("_exitInterviewQuestion", typeof(ExitInterviewQuestionEntity));
				if(_exitInterviewQuestion!=null)
				{
					_exitInterviewQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup_ = (LookupEntity)info.GetValue("_lookup_", typeof(LookupEntity));
				if(_lookup_!=null)
				{
					_lookup_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ExitInterviewQuestionFieldIndex)fieldIndex)
			{
				case ExitInterviewQuestionFieldIndex.TypeId:
					DesetupSyncLookup_(true, false);
					break;
				case ExitInterviewQuestionFieldIndex.Gender:
					DesetupSyncLookup(true, false);
					break;
				case ExitInterviewQuestionFieldIndex.ParentId:
					DesetupSyncExitInterviewQuestion(true, false);
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
				case "ExitInterviewQuestion":
					this.ExitInterviewQuestion = (ExitInterviewQuestionEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "ExitInterviewAnswer":
					this.ExitInterviewAnswer.Add((ExitInterviewAnswerEntity)entity);
					break;
				case "ExitInterviewQuestion_":
					this.ExitInterviewQuestion_.Add((ExitInterviewQuestionEntity)entity);
					break;
				case "EventCustomersCollectionViaExitInterviewAnswer":
					this.EventCustomersCollectionViaExitInterviewAnswer.IsReadOnly = false;
					this.EventCustomersCollectionViaExitInterviewAnswer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaExitInterviewAnswer.IsReadOnly = true;
					break;
				case "LookupCollectionViaExitInterviewQuestion":
					this.LookupCollectionViaExitInterviewQuestion.IsReadOnly = false;
					this.LookupCollectionViaExitInterviewQuestion.Add((LookupEntity)entity);
					this.LookupCollectionViaExitInterviewQuestion.IsReadOnly = true;
					break;
				case "LookupCollectionViaExitInterviewQuestion_":
					this.LookupCollectionViaExitInterviewQuestion_.IsReadOnly = false;
					this.LookupCollectionViaExitInterviewQuestion_.Add((LookupEntity)entity);
					this.LookupCollectionViaExitInterviewQuestion_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewAnswer_":
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewAnswer":
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer.IsReadOnly = true;
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
			return ExitInterviewQuestionEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ExitInterviewQuestion":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.ExitInterviewQuestionEntityUsingIdParentId);
					break;
				case "Lookup_":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "Lookup":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.LookupEntityUsingGender);
					break;
				case "ExitInterviewAnswer":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.ExitInterviewAnswerEntityUsingQuestionId);
					break;
				case "ExitInterviewQuestion_":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.ExitInterviewQuestionEntityUsingParentId);
					break;
				case "EventCustomersCollectionViaExitInterviewAnswer":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.ExitInterviewAnswerEntityUsingQuestionId, "ExitInterviewQuestionEntity__", "ExitInterviewAnswer_", JoinHint.None);
					toReturn.Add(ExitInterviewAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "ExitInterviewAnswer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaExitInterviewQuestion":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.ExitInterviewQuestionEntityUsingParentId, "ExitInterviewQuestionEntity__", "ExitInterviewQuestion_", JoinHint.None);
					toReturn.Add(ExitInterviewQuestionEntity.Relations.LookupEntityUsingGender, "ExitInterviewQuestion_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaExitInterviewQuestion_":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.ExitInterviewQuestionEntityUsingParentId, "ExitInterviewQuestionEntity__", "ExitInterviewQuestion_", JoinHint.None);
					toReturn.Add(ExitInterviewQuestionEntity.Relations.LookupEntityUsingTypeId, "ExitInterviewQuestion_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewAnswer_":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.ExitInterviewAnswerEntityUsingQuestionId, "ExitInterviewQuestionEntity__", "ExitInterviewAnswer_", JoinHint.None);
					toReturn.Add(ExitInterviewAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ExitInterviewAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewAnswer":
					toReturn.Add(ExitInterviewQuestionEntity.Relations.ExitInterviewAnswerEntityUsingQuestionId, "ExitInterviewQuestionEntity__", "ExitInterviewAnswer_", JoinHint.None);
					toReturn.Add(ExitInterviewAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ExitInterviewAnswer_", string.Empty, JoinHint.None);
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
				case "ExitInterviewQuestion":
					SetupSyncExitInterviewQuestion(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "ExitInterviewAnswer":
					this.ExitInterviewAnswer.Add((ExitInterviewAnswerEntity)relatedEntity);
					break;
				case "ExitInterviewQuestion_":
					this.ExitInterviewQuestion_.Add((ExitInterviewQuestionEntity)relatedEntity);
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
				case "ExitInterviewQuestion":
					DesetupSyncExitInterviewQuestion(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "ExitInterviewAnswer":
					base.PerformRelatedEntityRemoval(this.ExitInterviewAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ExitInterviewQuestion_":
					base.PerformRelatedEntityRemoval(this.ExitInterviewQuestion_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_exitInterviewQuestion!=null)
			{
				toReturn.Add(_exitInterviewQuestion);
			}
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
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
			toReturn.Add(this.ExitInterviewAnswer);
			toReturn.Add(this.ExitInterviewQuestion_);

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
				info.AddValue("_exitInterviewAnswer", ((_exitInterviewAnswer!=null) && (_exitInterviewAnswer.Count>0) && !this.MarkedForDeletion)?_exitInterviewAnswer:null);
				info.AddValue("_exitInterviewQuestion_", ((_exitInterviewQuestion_!=null) && (_exitInterviewQuestion_.Count>0) && !this.MarkedForDeletion)?_exitInterviewQuestion_:null);
				info.AddValue("_eventCustomersCollectionViaExitInterviewAnswer", ((_eventCustomersCollectionViaExitInterviewAnswer!=null) && (_eventCustomersCollectionViaExitInterviewAnswer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaExitInterviewAnswer:null);
				info.AddValue("_lookupCollectionViaExitInterviewQuestion", ((_lookupCollectionViaExitInterviewQuestion!=null) && (_lookupCollectionViaExitInterviewQuestion.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaExitInterviewQuestion:null);
				info.AddValue("_lookupCollectionViaExitInterviewQuestion_", ((_lookupCollectionViaExitInterviewQuestion_!=null) && (_lookupCollectionViaExitInterviewQuestion_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaExitInterviewQuestion_:null);
				info.AddValue("_organizationRoleUserCollectionViaExitInterviewAnswer_", ((_organizationRoleUserCollectionViaExitInterviewAnswer_!=null) && (_organizationRoleUserCollectionViaExitInterviewAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaExitInterviewAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaExitInterviewAnswer", ((_organizationRoleUserCollectionViaExitInterviewAnswer!=null) && (_organizationRoleUserCollectionViaExitInterviewAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaExitInterviewAnswer:null);
				info.AddValue("_exitInterviewQuestion", (!this.MarkedForDeletion?_exitInterviewQuestion:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
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
		public bool TestOriginalFieldValueForNull(ExitInterviewQuestionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ExitInterviewQuestionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ExitInterviewQuestionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ExitInterviewAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoExitInterviewAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewAnswerFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ExitInterviewQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoExitInterviewQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewQuestionFields.ParentId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaExitInterviewAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaExitInterviewAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ExitInterviewQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaExitInterviewQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaExitInterviewQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ExitInterviewQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaExitInterviewQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaExitInterviewQuestion_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ExitInterviewQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaExitInterviewAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaExitInterviewAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ExitInterviewQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaExitInterviewAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaExitInterviewAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ExitInterviewQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ExitInterviewQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoExitInterviewQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewQuestionFields.Id, null, ComparisonOperator.Equal, this.ParentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Gender));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ExitInterviewQuestionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewQuestionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._exitInterviewAnswer);
			collectionsQueue.Enqueue(this._exitInterviewQuestion_);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaExitInterviewAnswer);
			collectionsQueue.Enqueue(this._lookupCollectionViaExitInterviewQuestion);
			collectionsQueue.Enqueue(this._lookupCollectionViaExitInterviewQuestion_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaExitInterviewAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaExitInterviewAnswer);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._exitInterviewAnswer = (EntityCollection<ExitInterviewAnswerEntity>) collectionsQueue.Dequeue();
			this._exitInterviewQuestion_ = (EntityCollection<ExitInterviewQuestionEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaExitInterviewAnswer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaExitInterviewQuestion = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaExitInterviewQuestion_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaExitInterviewAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaExitInterviewAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._exitInterviewAnswer != null)
			{
				return true;
			}
			if (this._exitInterviewQuestion_ != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaExitInterviewAnswer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaExitInterviewQuestion != null)
			{
				return true;
			}
			if (this._lookupCollectionViaExitInterviewQuestion_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaExitInterviewAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaExitInterviewAnswer != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ExitInterviewAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ExitInterviewQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ExitInterviewQuestion", _exitInterviewQuestion);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("ExitInterviewAnswer", _exitInterviewAnswer);
			toReturn.Add("ExitInterviewQuestion_", _exitInterviewQuestion_);
			toReturn.Add("EventCustomersCollectionViaExitInterviewAnswer", _eventCustomersCollectionViaExitInterviewAnswer);
			toReturn.Add("LookupCollectionViaExitInterviewQuestion", _lookupCollectionViaExitInterviewQuestion);
			toReturn.Add("LookupCollectionViaExitInterviewQuestion_", _lookupCollectionViaExitInterviewQuestion_);
			toReturn.Add("OrganizationRoleUserCollectionViaExitInterviewAnswer_", _organizationRoleUserCollectionViaExitInterviewAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaExitInterviewAnswer", _organizationRoleUserCollectionViaExitInterviewAnswer);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_exitInterviewAnswer!=null)
			{
				_exitInterviewAnswer.ActiveContext = base.ActiveContext;
			}
			if(_exitInterviewQuestion_!=null)
			{
				_exitInterviewQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaExitInterviewAnswer!=null)
			{
				_eventCustomersCollectionViaExitInterviewAnswer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaExitInterviewQuestion!=null)
			{
				_lookupCollectionViaExitInterviewQuestion.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaExitInterviewQuestion_!=null)
			{
				_lookupCollectionViaExitInterviewQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaExitInterviewAnswer_!=null)
			{
				_organizationRoleUserCollectionViaExitInterviewAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaExitInterviewAnswer!=null)
			{
				_organizationRoleUserCollectionViaExitInterviewAnswer.ActiveContext = base.ActiveContext;
			}
			if(_exitInterviewQuestion!=null)
			{
				_exitInterviewQuestion.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_exitInterviewAnswer = null;
			_exitInterviewQuestion_ = null;
			_eventCustomersCollectionViaExitInterviewAnswer = null;
			_lookupCollectionViaExitInterviewQuestion = null;
			_lookupCollectionViaExitInterviewQuestion_ = null;
			_organizationRoleUserCollectionViaExitInterviewAnswer_ = null;
			_organizationRoleUserCollectionViaExitInterviewAnswer = null;
			_exitInterviewQuestion = null;
			_lookup_ = null;
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

			_fieldsCustomProperties.Add("Question", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValues", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValueDelimiter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Index", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _exitInterviewQuestion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncExitInterviewQuestion(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _exitInterviewQuestion, new PropertyChangedEventHandler( OnExitInterviewQuestionPropertyChanged ), "ExitInterviewQuestion", ExitInterviewQuestionEntity.Relations.ExitInterviewQuestionEntityUsingIdParentId, true, signalRelatedEntity, "ExitInterviewQuestion_", resetFKFields, new int[] { (int)ExitInterviewQuestionFieldIndex.ParentId } );		
			_exitInterviewQuestion = null;
		}

		/// <summary> setups the sync logic for member _exitInterviewQuestion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncExitInterviewQuestion(IEntity2 relatedEntity)
		{
			if(_exitInterviewQuestion!=relatedEntity)
			{
				DesetupSyncExitInterviewQuestion(true, true);
				_exitInterviewQuestion = (ExitInterviewQuestionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _exitInterviewQuestion, new PropertyChangedEventHandler( OnExitInterviewQuestionPropertyChanged ), "ExitInterviewQuestion", ExitInterviewQuestionEntity.Relations.ExitInterviewQuestionEntityUsingIdParentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnExitInterviewQuestionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", ExitInterviewQuestionEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "ExitInterviewQuestion_", resetFKFields, new int[] { (int)ExitInterviewQuestionFieldIndex.TypeId } );		
			_lookup_ = null;
		}

		/// <summary> setups the sync logic for member _lookup_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup_(IEntity2 relatedEntity)
		{
			if(_lookup_!=relatedEntity)
			{
				DesetupSyncLookup_(true, true);
				_lookup_ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", ExitInterviewQuestionEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", ExitInterviewQuestionEntity.Relations.LookupEntityUsingGender, true, signalRelatedEntity, "ExitInterviewQuestion", resetFKFields, new int[] { (int)ExitInterviewQuestionFieldIndex.Gender } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", ExitInterviewQuestionEntity.Relations.LookupEntityUsingGender, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this ExitInterviewQuestionEntity</param>
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
		public  static ExitInterviewQuestionRelations Relations
		{
			get	{ return new ExitInterviewQuestionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ExitInterviewAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathExitInterviewAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ExitInterviewAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("ExitInterviewAnswer")[0], (int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.ExitInterviewAnswerEntity, 0, null, null, null, null, "ExitInterviewAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ExitInterviewQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathExitInterviewQuestion_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ExitInterviewQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ExitInterviewQuestion_")[0], (int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, 0, null, null, null, null, "ExitInterviewQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaExitInterviewAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = ExitInterviewQuestionEntity.Relations.ExitInterviewAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaExitInterviewAnswer"), null, "EventCustomersCollectionViaExitInterviewAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaExitInterviewQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = ExitInterviewQuestionEntity.Relations.ExitInterviewQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaExitInterviewQuestion"), null, "LookupCollectionViaExitInterviewQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaExitInterviewQuestion_
		{
			get
			{
				IEntityRelation intermediateRelation = ExitInterviewQuestionEntity.Relations.ExitInterviewQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaExitInterviewQuestion_"), null, "LookupCollectionViaExitInterviewQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaExitInterviewAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = ExitInterviewQuestionEntity.Relations.ExitInterviewAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaExitInterviewAnswer_"), null, "OrganizationRoleUserCollectionViaExitInterviewAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaExitInterviewAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = ExitInterviewQuestionEntity.Relations.ExitInterviewAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaExitInterviewAnswer"), null, "OrganizationRoleUserCollectionViaExitInterviewAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ExitInterviewQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathExitInterviewQuestion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ExitInterviewQuestion")[0], (int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, 0, null, null, null, null, "ExitInterviewQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ExitInterviewQuestionEntity.CustomProperties;}
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
			get { return ExitInterviewQuestionEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity ExitInterviewQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblExitInterviewQuestion"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)ExitInterviewQuestionFieldIndex.Id, true); }
			set	{ SetValue((int)ExitInterviewQuestionFieldIndex.Id, value); }
		}

		/// <summary> The Question property of the Entity ExitInterviewQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblExitInterviewQuestion"."Question"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2048<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Question
		{
			get { return (System.String)GetValue((int)ExitInterviewQuestionFieldIndex.Question, true); }
			set	{ SetValue((int)ExitInterviewQuestionFieldIndex.Question, value); }
		}

		/// <summary> The TypeId property of the Entity ExitInterviewQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblExitInterviewQuestion"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)ExitInterviewQuestionFieldIndex.TypeId, true); }
			set	{ SetValue((int)ExitInterviewQuestionFieldIndex.TypeId, value); }
		}

		/// <summary> The Gender property of the Entity ExitInterviewQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblExitInterviewQuestion"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Gender
		{
			get { return (System.Int64)GetValue((int)ExitInterviewQuestionFieldIndex.Gender, true); }
			set	{ SetValue((int)ExitInterviewQuestionFieldIndex.Gender, value); }
		}

		/// <summary> The ParentId property of the Entity ExitInterviewQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblExitInterviewQuestion"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ExitInterviewQuestionFieldIndex.ParentId, false); }
			set	{ SetValue((int)ExitInterviewQuestionFieldIndex.ParentId, value); }
		}

		/// <summary> The ControlValues property of the Entity ExitInterviewQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblExitInterviewQuestion"."ControlValues"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValues
		{
			get { return (System.String)GetValue((int)ExitInterviewQuestionFieldIndex.ControlValues, true); }
			set	{ SetValue((int)ExitInterviewQuestionFieldIndex.ControlValues, value); }
		}

		/// <summary> The ControlValueDelimiter property of the Entity ExitInterviewQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblExitInterviewQuestion"."ControlValueDelimiter"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValueDelimiter
		{
			get { return (System.String)GetValue((int)ExitInterviewQuestionFieldIndex.ControlValueDelimiter, true); }
			set	{ SetValue((int)ExitInterviewQuestionFieldIndex.ControlValueDelimiter, value); }
		}

		/// <summary> The Index property of the Entity ExitInterviewQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblExitInterviewQuestion"."Index"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Index
		{
			get { return (System.Int32)GetValue((int)ExitInterviewQuestionFieldIndex.Index, true); }
			set	{ SetValue((int)ExitInterviewQuestionFieldIndex.Index, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ExitInterviewAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ExitInterviewAnswerEntity))]
		public virtual EntityCollection<ExitInterviewAnswerEntity> ExitInterviewAnswer
		{
			get
			{
				if(_exitInterviewAnswer==null)
				{
					_exitInterviewAnswer = new EntityCollection<ExitInterviewAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewAnswerEntityFactory)));
					_exitInterviewAnswer.SetContainingEntityInfo(this, "ExitInterviewQuestion");
				}
				return _exitInterviewAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ExitInterviewQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ExitInterviewQuestionEntity))]
		public virtual EntityCollection<ExitInterviewQuestionEntity> ExitInterviewQuestion_
		{
			get
			{
				if(_exitInterviewQuestion_==null)
				{
					_exitInterviewQuestion_ = new EntityCollection<ExitInterviewQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewQuestionEntityFactory)));
					_exitInterviewQuestion_.SetContainingEntityInfo(this, "ExitInterviewQuestion");
				}
				return _exitInterviewQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaExitInterviewAnswer
		{
			get
			{
				if(_eventCustomersCollectionViaExitInterviewAnswer==null)
				{
					_eventCustomersCollectionViaExitInterviewAnswer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaExitInterviewAnswer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaExitInterviewAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaExitInterviewQuestion
		{
			get
			{
				if(_lookupCollectionViaExitInterviewQuestion==null)
				{
					_lookupCollectionViaExitInterviewQuestion = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaExitInterviewQuestion.IsReadOnly=true;
				}
				return _lookupCollectionViaExitInterviewQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaExitInterviewQuestion_
		{
			get
			{
				if(_lookupCollectionViaExitInterviewQuestion_==null)
				{
					_lookupCollectionViaExitInterviewQuestion_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaExitInterviewQuestion_.IsReadOnly=true;
				}
				return _lookupCollectionViaExitInterviewQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaExitInterviewAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaExitInterviewAnswer_==null)
				{
					_organizationRoleUserCollectionViaExitInterviewAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaExitInterviewAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaExitInterviewAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaExitInterviewAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaExitInterviewAnswer==null)
				{
					_organizationRoleUserCollectionViaExitInterviewAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaExitInterviewAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaExitInterviewAnswer;
			}
		}

		/// <summary> Gets / sets related entity of type 'ExitInterviewQuestionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ExitInterviewQuestionEntity ExitInterviewQuestion
		{
			get
			{
				return _exitInterviewQuestion;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncExitInterviewQuestion(value);
				}
				else
				{
					if(value==null)
					{
						if(_exitInterviewQuestion != null)
						{
							_exitInterviewQuestion.UnsetRelatedEntity(this, "ExitInterviewQuestion_");
						}
					}
					else
					{
						if(_exitInterviewQuestion!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ExitInterviewQuestion_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup_
		{
			get
			{
				return _lookup_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup_(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup_ != null)
						{
							_lookup_.UnsetRelatedEntity(this, "ExitInterviewQuestion_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ExitInterviewQuestion_");
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
							_lookup.UnsetRelatedEntity(this, "ExitInterviewQuestion");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ExitInterviewQuestion");
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
			get { return (int)Falcon.Data.EntityType.ExitInterviewQuestionEntity; }
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
