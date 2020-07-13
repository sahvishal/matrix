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
	/// Entity class which represents the entity 'ChaperoneQuestion'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ChaperoneQuestionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ChaperoneAnswerEntity> _chaperoneAnswer;
		private EntityCollection<ChaperoneQuestionEntity> _chaperoneQuestion_;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaChaperoneAnswer;
		private EntityCollection<LookupEntity> _lookupCollectionViaChaperoneQuestion;
		private EntityCollection<LookupEntity> _lookupCollectionViaChaperoneQuestion_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaChaperoneAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaChaperoneAnswer;
		private ChaperoneQuestionEntity _chaperoneQuestion;
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
			/// <summary>Member name ChaperoneQuestion</summary>
			public static readonly string ChaperoneQuestion = "ChaperoneQuestion";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name ChaperoneAnswer</summary>
			public static readonly string ChaperoneAnswer = "ChaperoneAnswer";
			/// <summary>Member name ChaperoneQuestion_</summary>
			public static readonly string ChaperoneQuestion_ = "ChaperoneQuestion_";
			/// <summary>Member name EventCustomersCollectionViaChaperoneAnswer</summary>
			public static readonly string EventCustomersCollectionViaChaperoneAnswer = "EventCustomersCollectionViaChaperoneAnswer";
			/// <summary>Member name LookupCollectionViaChaperoneQuestion</summary>
			public static readonly string LookupCollectionViaChaperoneQuestion = "LookupCollectionViaChaperoneQuestion";
			/// <summary>Member name LookupCollectionViaChaperoneQuestion_</summary>
			public static readonly string LookupCollectionViaChaperoneQuestion_ = "LookupCollectionViaChaperoneQuestion_";
			/// <summary>Member name OrganizationRoleUserCollectionViaChaperoneAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaChaperoneAnswer_ = "OrganizationRoleUserCollectionViaChaperoneAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaChaperoneAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaChaperoneAnswer = "OrganizationRoleUserCollectionViaChaperoneAnswer";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ChaperoneQuestionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ChaperoneQuestionEntity():base("ChaperoneQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ChaperoneQuestionEntity(IEntityFields2 fields):base("ChaperoneQuestionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ChaperoneQuestionEntity</param>
		public ChaperoneQuestionEntity(IValidator validator):base("ChaperoneQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for ChaperoneQuestion which data should be fetched into this ChaperoneQuestion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaperoneQuestionEntity(System.Int64 id):base("ChaperoneQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for ChaperoneQuestion which data should be fetched into this ChaperoneQuestion object</param>
		/// <param name="validator">The custom validator object for this ChaperoneQuestionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaperoneQuestionEntity(System.Int64 id, IValidator validator):base("ChaperoneQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ChaperoneQuestionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_chaperoneAnswer = (EntityCollection<ChaperoneAnswerEntity>)info.GetValue("_chaperoneAnswer", typeof(EntityCollection<ChaperoneAnswerEntity>));
				_chaperoneQuestion_ = (EntityCollection<ChaperoneQuestionEntity>)info.GetValue("_chaperoneQuestion_", typeof(EntityCollection<ChaperoneQuestionEntity>));
				_eventCustomersCollectionViaChaperoneAnswer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaChaperoneAnswer", typeof(EntityCollection<EventCustomersEntity>));
				_lookupCollectionViaChaperoneQuestion = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaChaperoneQuestion", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaChaperoneQuestion_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaChaperoneQuestion_", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaChaperoneAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaChaperoneAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaChaperoneAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaChaperoneAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_chaperoneQuestion = (ChaperoneQuestionEntity)info.GetValue("_chaperoneQuestion", typeof(ChaperoneQuestionEntity));
				if(_chaperoneQuestion!=null)
				{
					_chaperoneQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ChaperoneQuestionFieldIndex)fieldIndex)
			{
				case ChaperoneQuestionFieldIndex.TypeId:
					DesetupSyncLookup_(true, false);
					break;
				case ChaperoneQuestionFieldIndex.Gender:
					DesetupSyncLookup(true, false);
					break;
				case ChaperoneQuestionFieldIndex.ParentId:
					DesetupSyncChaperoneQuestion(true, false);
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
				case "ChaperoneQuestion":
					this.ChaperoneQuestion = (ChaperoneQuestionEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "ChaperoneAnswer":
					this.ChaperoneAnswer.Add((ChaperoneAnswerEntity)entity);
					break;
				case "ChaperoneQuestion_":
					this.ChaperoneQuestion_.Add((ChaperoneQuestionEntity)entity);
					break;
				case "EventCustomersCollectionViaChaperoneAnswer":
					this.EventCustomersCollectionViaChaperoneAnswer.IsReadOnly = false;
					this.EventCustomersCollectionViaChaperoneAnswer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaChaperoneAnswer.IsReadOnly = true;
					break;
				case "LookupCollectionViaChaperoneQuestion":
					this.LookupCollectionViaChaperoneQuestion.IsReadOnly = false;
					this.LookupCollectionViaChaperoneQuestion.Add((LookupEntity)entity);
					this.LookupCollectionViaChaperoneQuestion.IsReadOnly = true;
					break;
				case "LookupCollectionViaChaperoneQuestion_":
					this.LookupCollectionViaChaperoneQuestion_.IsReadOnly = false;
					this.LookupCollectionViaChaperoneQuestion_.Add((LookupEntity)entity);
					this.LookupCollectionViaChaperoneQuestion_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaChaperoneAnswer_":
					this.OrganizationRoleUserCollectionViaChaperoneAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaChaperoneAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaChaperoneAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaChaperoneAnswer":
					this.OrganizationRoleUserCollectionViaChaperoneAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaChaperoneAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaChaperoneAnswer.IsReadOnly = true;
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
			return ChaperoneQuestionEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ChaperoneQuestion":
					toReturn.Add(ChaperoneQuestionEntity.Relations.ChaperoneQuestionEntityUsingIdParentId);
					break;
				case "Lookup_":
					toReturn.Add(ChaperoneQuestionEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "Lookup":
					toReturn.Add(ChaperoneQuestionEntity.Relations.LookupEntityUsingGender);
					break;
				case "ChaperoneAnswer":
					toReturn.Add(ChaperoneQuestionEntity.Relations.ChaperoneAnswerEntityUsingQuestionId);
					break;
				case "ChaperoneQuestion_":
					toReturn.Add(ChaperoneQuestionEntity.Relations.ChaperoneQuestionEntityUsingParentId);
					break;
				case "EventCustomersCollectionViaChaperoneAnswer":
					toReturn.Add(ChaperoneQuestionEntity.Relations.ChaperoneAnswerEntityUsingQuestionId, "ChaperoneQuestionEntity__", "ChaperoneAnswer_", JoinHint.None);
					toReturn.Add(ChaperoneAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "ChaperoneAnswer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaChaperoneQuestion":
					toReturn.Add(ChaperoneQuestionEntity.Relations.ChaperoneQuestionEntityUsingParentId, "ChaperoneQuestionEntity__", "ChaperoneQuestion_", JoinHint.None);
					toReturn.Add(ChaperoneQuestionEntity.Relations.LookupEntityUsingGender, "ChaperoneQuestion_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaChaperoneQuestion_":
					toReturn.Add(ChaperoneQuestionEntity.Relations.ChaperoneQuestionEntityUsingParentId, "ChaperoneQuestionEntity__", "ChaperoneQuestion_", JoinHint.None);
					toReturn.Add(ChaperoneQuestionEntity.Relations.LookupEntityUsingTypeId, "ChaperoneQuestion_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaChaperoneAnswer_":
					toReturn.Add(ChaperoneQuestionEntity.Relations.ChaperoneAnswerEntityUsingQuestionId, "ChaperoneQuestionEntity__", "ChaperoneAnswer_", JoinHint.None);
					toReturn.Add(ChaperoneAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ChaperoneAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaChaperoneAnswer":
					toReturn.Add(ChaperoneQuestionEntity.Relations.ChaperoneAnswerEntityUsingQuestionId, "ChaperoneQuestionEntity__", "ChaperoneAnswer_", JoinHint.None);
					toReturn.Add(ChaperoneAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ChaperoneAnswer_", string.Empty, JoinHint.None);
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
				case "ChaperoneQuestion":
					SetupSyncChaperoneQuestion(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "ChaperoneAnswer":
					this.ChaperoneAnswer.Add((ChaperoneAnswerEntity)relatedEntity);
					break;
				case "ChaperoneQuestion_":
					this.ChaperoneQuestion_.Add((ChaperoneQuestionEntity)relatedEntity);
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
				case "ChaperoneQuestion":
					DesetupSyncChaperoneQuestion(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "ChaperoneAnswer":
					base.PerformRelatedEntityRemoval(this.ChaperoneAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ChaperoneQuestion_":
					base.PerformRelatedEntityRemoval(this.ChaperoneQuestion_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_chaperoneQuestion!=null)
			{
				toReturn.Add(_chaperoneQuestion);
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
			toReturn.Add(this.ChaperoneAnswer);
			toReturn.Add(this.ChaperoneQuestion_);

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
				info.AddValue("_chaperoneAnswer", ((_chaperoneAnswer!=null) && (_chaperoneAnswer.Count>0) && !this.MarkedForDeletion)?_chaperoneAnswer:null);
				info.AddValue("_chaperoneQuestion_", ((_chaperoneQuestion_!=null) && (_chaperoneQuestion_.Count>0) && !this.MarkedForDeletion)?_chaperoneQuestion_:null);
				info.AddValue("_eventCustomersCollectionViaChaperoneAnswer", ((_eventCustomersCollectionViaChaperoneAnswer!=null) && (_eventCustomersCollectionViaChaperoneAnswer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaChaperoneAnswer:null);
				info.AddValue("_lookupCollectionViaChaperoneQuestion", ((_lookupCollectionViaChaperoneQuestion!=null) && (_lookupCollectionViaChaperoneQuestion.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaChaperoneQuestion:null);
				info.AddValue("_lookupCollectionViaChaperoneQuestion_", ((_lookupCollectionViaChaperoneQuestion_!=null) && (_lookupCollectionViaChaperoneQuestion_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaChaperoneQuestion_:null);
				info.AddValue("_organizationRoleUserCollectionViaChaperoneAnswer_", ((_organizationRoleUserCollectionViaChaperoneAnswer_!=null) && (_organizationRoleUserCollectionViaChaperoneAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaChaperoneAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaChaperoneAnswer", ((_organizationRoleUserCollectionViaChaperoneAnswer!=null) && (_organizationRoleUserCollectionViaChaperoneAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaChaperoneAnswer:null);
				info.AddValue("_chaperoneQuestion", (!this.MarkedForDeletion?_chaperoneQuestion:null));
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
		public bool TestOriginalFieldValueForNull(ChaperoneQuestionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ChaperoneQuestionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ChaperoneQuestionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaperoneAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaperoneAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneAnswerFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaperoneQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaperoneQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneQuestionFields.ParentId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaChaperoneAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaChaperoneAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaperoneQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaChaperoneQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaChaperoneQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaperoneQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaChaperoneQuestion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaChaperoneQuestion_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaperoneQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaChaperoneAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaChaperoneAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaperoneQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaChaperoneAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaChaperoneAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaperoneQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ChaperoneQuestion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaperoneQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneQuestionFields.Id, null, ComparisonOperator.Equal, this.ParentId));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ChaperoneQuestionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneQuestionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._chaperoneAnswer);
			collectionsQueue.Enqueue(this._chaperoneQuestion_);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaChaperoneAnswer);
			collectionsQueue.Enqueue(this._lookupCollectionViaChaperoneQuestion);
			collectionsQueue.Enqueue(this._lookupCollectionViaChaperoneQuestion_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaChaperoneAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaChaperoneAnswer);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._chaperoneAnswer = (EntityCollection<ChaperoneAnswerEntity>) collectionsQueue.Dequeue();
			this._chaperoneQuestion_ = (EntityCollection<ChaperoneQuestionEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaChaperoneAnswer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaChaperoneQuestion = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaChaperoneQuestion_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaChaperoneAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaChaperoneAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._chaperoneAnswer != null)
			{
				return true;
			}
			if (this._chaperoneQuestion_ != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaChaperoneAnswer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaChaperoneQuestion != null)
			{
				return true;
			}
			if (this._lookupCollectionViaChaperoneQuestion_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaChaperoneAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaChaperoneAnswer != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaperoneAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaperoneQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneQuestionEntityFactory))) : null);
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
			toReturn.Add("ChaperoneQuestion", _chaperoneQuestion);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("ChaperoneAnswer", _chaperoneAnswer);
			toReturn.Add("ChaperoneQuestion_", _chaperoneQuestion_);
			toReturn.Add("EventCustomersCollectionViaChaperoneAnswer", _eventCustomersCollectionViaChaperoneAnswer);
			toReturn.Add("LookupCollectionViaChaperoneQuestion", _lookupCollectionViaChaperoneQuestion);
			toReturn.Add("LookupCollectionViaChaperoneQuestion_", _lookupCollectionViaChaperoneQuestion_);
			toReturn.Add("OrganizationRoleUserCollectionViaChaperoneAnswer_", _organizationRoleUserCollectionViaChaperoneAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaChaperoneAnswer", _organizationRoleUserCollectionViaChaperoneAnswer);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_chaperoneAnswer!=null)
			{
				_chaperoneAnswer.ActiveContext = base.ActiveContext;
			}
			if(_chaperoneQuestion_!=null)
			{
				_chaperoneQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaChaperoneAnswer!=null)
			{
				_eventCustomersCollectionViaChaperoneAnswer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaChaperoneQuestion!=null)
			{
				_lookupCollectionViaChaperoneQuestion.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaChaperoneQuestion_!=null)
			{
				_lookupCollectionViaChaperoneQuestion_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaChaperoneAnswer_!=null)
			{
				_organizationRoleUserCollectionViaChaperoneAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaChaperoneAnswer!=null)
			{
				_organizationRoleUserCollectionViaChaperoneAnswer.ActiveContext = base.ActiveContext;
			}
			if(_chaperoneQuestion!=null)
			{
				_chaperoneQuestion.ActiveContext = base.ActiveContext;
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

			_chaperoneAnswer = null;
			_chaperoneQuestion_ = null;
			_eventCustomersCollectionViaChaperoneAnswer = null;
			_lookupCollectionViaChaperoneQuestion = null;
			_lookupCollectionViaChaperoneQuestion_ = null;
			_organizationRoleUserCollectionViaChaperoneAnswer_ = null;
			_organizationRoleUserCollectionViaChaperoneAnswer = null;
			_chaperoneQuestion = null;
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

		/// <summary> Removes the sync logic for member _chaperoneQuestion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncChaperoneQuestion(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _chaperoneQuestion, new PropertyChangedEventHandler( OnChaperoneQuestionPropertyChanged ), "ChaperoneQuestion", ChaperoneQuestionEntity.Relations.ChaperoneQuestionEntityUsingIdParentId, true, signalRelatedEntity, "ChaperoneQuestion_", resetFKFields, new int[] { (int)ChaperoneQuestionFieldIndex.ParentId } );		
			_chaperoneQuestion = null;
		}

		/// <summary> setups the sync logic for member _chaperoneQuestion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncChaperoneQuestion(IEntity2 relatedEntity)
		{
			if(_chaperoneQuestion!=relatedEntity)
			{
				DesetupSyncChaperoneQuestion(true, true);
				_chaperoneQuestion = (ChaperoneQuestionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _chaperoneQuestion, new PropertyChangedEventHandler( OnChaperoneQuestionPropertyChanged ), "ChaperoneQuestion", ChaperoneQuestionEntity.Relations.ChaperoneQuestionEntityUsingIdParentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnChaperoneQuestionPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", ChaperoneQuestionEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "ChaperoneQuestion_", resetFKFields, new int[] { (int)ChaperoneQuestionFieldIndex.TypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", ChaperoneQuestionEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", ChaperoneQuestionEntity.Relations.LookupEntityUsingGender, true, signalRelatedEntity, "ChaperoneQuestion", resetFKFields, new int[] { (int)ChaperoneQuestionFieldIndex.Gender } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", ChaperoneQuestionEntity.Relations.LookupEntityUsingGender, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this ChaperoneQuestionEntity</param>
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
		public  static ChaperoneQuestionRelations Relations
		{
			get	{ return new ChaperoneQuestionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaperoneAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaperoneAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChaperoneAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaperoneAnswer")[0], (int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.ChaperoneAnswerEntity, 0, null, null, null, null, "ChaperoneAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaperoneQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaperoneQuestion_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChaperoneQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaperoneQuestion_")[0], (int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.ChaperoneQuestionEntity, 0, null, null, null, null, "ChaperoneQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaChaperoneAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = ChaperoneQuestionEntity.Relations.ChaperoneAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaChaperoneAnswer"), null, "EventCustomersCollectionViaChaperoneAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaChaperoneQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = ChaperoneQuestionEntity.Relations.ChaperoneQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaChaperoneQuestion"), null, "LookupCollectionViaChaperoneQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaChaperoneQuestion_
		{
			get
			{
				IEntityRelation intermediateRelation = ChaperoneQuestionEntity.Relations.ChaperoneQuestionEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaChaperoneQuestion_"), null, "LookupCollectionViaChaperoneQuestion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaChaperoneAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = ChaperoneQuestionEntity.Relations.ChaperoneAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaChaperoneAnswer_"), null, "OrganizationRoleUserCollectionViaChaperoneAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaChaperoneAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = ChaperoneQuestionEntity.Relations.ChaperoneAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaChaperoneAnswer"), null, "OrganizationRoleUserCollectionViaChaperoneAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaperoneQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaperoneQuestion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaperoneQuestion")[0], (int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.ChaperoneQuestionEntity, 0, null, null, null, null, "ChaperoneQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.ChaperoneQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ChaperoneQuestionEntity.CustomProperties;}
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
			get { return ChaperoneQuestionEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity ChaperoneQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaperoneQuestion"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)ChaperoneQuestionFieldIndex.Id, true); }
			set	{ SetValue((int)ChaperoneQuestionFieldIndex.Id, value); }
		}

		/// <summary> The Question property of the Entity ChaperoneQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaperoneQuestion"."Question"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Question
		{
			get { return (System.String)GetValue((int)ChaperoneQuestionFieldIndex.Question, true); }
			set	{ SetValue((int)ChaperoneQuestionFieldIndex.Question, value); }
		}

		/// <summary> The TypeId property of the Entity ChaperoneQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaperoneQuestion"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)ChaperoneQuestionFieldIndex.TypeId, true); }
			set	{ SetValue((int)ChaperoneQuestionFieldIndex.TypeId, value); }
		}

		/// <summary> The Gender property of the Entity ChaperoneQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaperoneQuestion"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Gender
		{
			get { return (System.Int64)GetValue((int)ChaperoneQuestionFieldIndex.Gender, true); }
			set	{ SetValue((int)ChaperoneQuestionFieldIndex.Gender, value); }
		}

		/// <summary> The ParentId property of the Entity ChaperoneQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaperoneQuestion"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ChaperoneQuestionFieldIndex.ParentId, false); }
			set	{ SetValue((int)ChaperoneQuestionFieldIndex.ParentId, value); }
		}

		/// <summary> The ControlValues property of the Entity ChaperoneQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaperoneQuestion"."ControlValues"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValues
		{
			get { return (System.String)GetValue((int)ChaperoneQuestionFieldIndex.ControlValues, true); }
			set	{ SetValue((int)ChaperoneQuestionFieldIndex.ControlValues, value); }
		}

		/// <summary> The ControlValueDelimiter property of the Entity ChaperoneQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaperoneQuestion"."ControlValueDelimiter"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValueDelimiter
		{
			get { return (System.String)GetValue((int)ChaperoneQuestionFieldIndex.ControlValueDelimiter, true); }
			set	{ SetValue((int)ChaperoneQuestionFieldIndex.ControlValueDelimiter, value); }
		}

		/// <summary> The Index property of the Entity ChaperoneQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaperoneQuestion"."Index"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Index
		{
			get { return (System.Int64)GetValue((int)ChaperoneQuestionFieldIndex.Index, true); }
			set	{ SetValue((int)ChaperoneQuestionFieldIndex.Index, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaperoneAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaperoneAnswerEntity))]
		public virtual EntityCollection<ChaperoneAnswerEntity> ChaperoneAnswer
		{
			get
			{
				if(_chaperoneAnswer==null)
				{
					_chaperoneAnswer = new EntityCollection<ChaperoneAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneAnswerEntityFactory)));
					_chaperoneAnswer.SetContainingEntityInfo(this, "ChaperoneQuestion");
				}
				return _chaperoneAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaperoneQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaperoneQuestionEntity))]
		public virtual EntityCollection<ChaperoneQuestionEntity> ChaperoneQuestion_
		{
			get
			{
				if(_chaperoneQuestion_==null)
				{
					_chaperoneQuestion_ = new EntityCollection<ChaperoneQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneQuestionEntityFactory)));
					_chaperoneQuestion_.SetContainingEntityInfo(this, "ChaperoneQuestion");
				}
				return _chaperoneQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaChaperoneAnswer
		{
			get
			{
				if(_eventCustomersCollectionViaChaperoneAnswer==null)
				{
					_eventCustomersCollectionViaChaperoneAnswer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaChaperoneAnswer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaChaperoneAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaChaperoneQuestion
		{
			get
			{
				if(_lookupCollectionViaChaperoneQuestion==null)
				{
					_lookupCollectionViaChaperoneQuestion = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaChaperoneQuestion.IsReadOnly=true;
				}
				return _lookupCollectionViaChaperoneQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaChaperoneQuestion_
		{
			get
			{
				if(_lookupCollectionViaChaperoneQuestion_==null)
				{
					_lookupCollectionViaChaperoneQuestion_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaChaperoneQuestion_.IsReadOnly=true;
				}
				return _lookupCollectionViaChaperoneQuestion_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaChaperoneAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaChaperoneAnswer_==null)
				{
					_organizationRoleUserCollectionViaChaperoneAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaChaperoneAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaChaperoneAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaChaperoneAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaChaperoneAnswer==null)
				{
					_organizationRoleUserCollectionViaChaperoneAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaChaperoneAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaChaperoneAnswer;
			}
		}

		/// <summary> Gets / sets related entity of type 'ChaperoneQuestionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ChaperoneQuestionEntity ChaperoneQuestion
		{
			get
			{
				return _chaperoneQuestion;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncChaperoneQuestion(value);
				}
				else
				{
					if(value==null)
					{
						if(_chaperoneQuestion != null)
						{
							_chaperoneQuestion.UnsetRelatedEntity(this, "ChaperoneQuestion_");
						}
					}
					else
					{
						if(_chaperoneQuestion!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChaperoneQuestion_");
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
							_lookup_.UnsetRelatedEntity(this, "ChaperoneQuestion_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChaperoneQuestion_");
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
							_lookup.UnsetRelatedEntity(this, "ChaperoneQuestion");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChaperoneQuestion");
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
			get { return (int)Falcon.Data.EntityType.ChaperoneQuestionEntity; }
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
