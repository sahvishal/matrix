///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:49
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
	/// Entity class which represents the entity 'PreQualificationResult'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PreQualificationResultEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CallsEntity _calls;
		private CustomerProfileEntity _customerProfile;
		private EventsEntity _events;
		private LookupEntity _lookup______;
		private LookupEntity _lookup_______;
		private LookupEntity _lookup________;
		private LookupEntity _lookup__;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;
		private LookupEntity _lookup_____;
		private LookupEntity _lookup____;
		private LookupEntity _lookup___;
		private TempCartEntity _tempCart;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Calls</summary>
			public static readonly string Calls = "Calls";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name Lookup______</summary>
			public static readonly string Lookup______ = "Lookup______";
			/// <summary>Member name Lookup_______</summary>
			public static readonly string Lookup_______ = "Lookup_______";
			/// <summary>Member name Lookup________</summary>
			public static readonly string Lookup________ = "Lookup________";
			/// <summary>Member name Lookup__</summary>
			public static readonly string Lookup__ = "Lookup__";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Lookup_____</summary>
			public static readonly string Lookup_____ = "Lookup_____";
			/// <summary>Member name Lookup____</summary>
			public static readonly string Lookup____ = "Lookup____";
			/// <summary>Member name Lookup___</summary>
			public static readonly string Lookup___ = "Lookup___";
			/// <summary>Member name TempCart</summary>
			public static readonly string TempCart = "TempCart";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PreQualificationResultEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PreQualificationResultEntity():base("PreQualificationResultEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PreQualificationResultEntity(IEntityFields2 fields):base("PreQualificationResultEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PreQualificationResultEntity</param>
		public PreQualificationResultEntity(IValidator validator):base("PreQualificationResultEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="preQualificationResultId">PK value for PreQualificationResult which data should be fetched into this PreQualificationResult object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PreQualificationResultEntity(System.Int64 preQualificationResultId):base("PreQualificationResultEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PreQualificationResultId = preQualificationResultId;
		}

		/// <summary> CTor</summary>
		/// <param name="preQualificationResultId">PK value for PreQualificationResult which data should be fetched into this PreQualificationResult object</param>
		/// <param name="validator">The custom validator object for this PreQualificationResultEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PreQualificationResultEntity(System.Int64 preQualificationResultId, IValidator validator):base("PreQualificationResultEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PreQualificationResultId = preQualificationResultId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PreQualificationResultEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_calls = (CallsEntity)info.GetValue("_calls", typeof(CallsEntity));
				if(_calls!=null)
				{
					_calls.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup______ = (LookupEntity)info.GetValue("_lookup______", typeof(LookupEntity));
				if(_lookup______!=null)
				{
					_lookup______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup_______ = (LookupEntity)info.GetValue("_lookup_______", typeof(LookupEntity));
				if(_lookup_______!=null)
				{
					_lookup_______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup________ = (LookupEntity)info.GetValue("_lookup________", typeof(LookupEntity));
				if(_lookup________!=null)
				{
					_lookup________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup__ = (LookupEntity)info.GetValue("_lookup__", typeof(LookupEntity));
				if(_lookup__!=null)
				{
					_lookup__.AfterSave+=new EventHandler(OnEntityAfterSave);
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
				_lookup_____ = (LookupEntity)info.GetValue("_lookup_____", typeof(LookupEntity));
				if(_lookup_____!=null)
				{
					_lookup_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup____ = (LookupEntity)info.GetValue("_lookup____", typeof(LookupEntity));
				if(_lookup____!=null)
				{
					_lookup____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup___ = (LookupEntity)info.GetValue("_lookup___", typeof(LookupEntity));
				if(_lookup___!=null)
				{
					_lookup___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_tempCart = (TempCartEntity)info.GetValue("_tempCart", typeof(TempCartEntity));
				if(_tempCart!=null)
				{
					_tempCart.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PreQualificationResultFieldIndex)fieldIndex)
			{
				case PreQualificationResultFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case PreQualificationResultFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case PreQualificationResultFieldIndex.TempCartId:
					DesetupSyncTempCart(true, false);
					break;
				case PreQualificationResultFieldIndex.CallId:
					DesetupSyncCalls(true, false);
					break;
				case PreQualificationResultFieldIndex.HighBloodPressure:
					DesetupSyncLookup_____(true, false);
					break;
				case PreQualificationResultFieldIndex.Smoker:
					DesetupSyncLookup________(true, false);
					break;
				case PreQualificationResultFieldIndex.HeartDisease:
					DesetupSyncLookup____(true, false);
					break;
				case PreQualificationResultFieldIndex.Diabetic:
					DesetupSyncLookup__(true, false);
					break;
				case PreQualificationResultFieldIndex.ChestPain:
					DesetupSyncLookup_(true, false);
					break;
				case PreQualificationResultFieldIndex.DiagnosedHeartProblem:
					DesetupSyncLookup___(true, false);
					break;
				case PreQualificationResultFieldIndex.HighCholestrol:
					DesetupSyncLookup______(true, false);
					break;
				case PreQualificationResultFieldIndex.OverWeight:
					DesetupSyncLookup_______(true, false);
					break;
				case PreQualificationResultFieldIndex.AgeOverPreQualificationQuestion:
					DesetupSyncLookup(true, false);
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
				case "Calls":
					this.Calls = (CallsEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "Lookup______":
					this.Lookup______ = (LookupEntity)entity;
					break;
				case "Lookup_______":
					this.Lookup_______ = (LookupEntity)entity;
					break;
				case "Lookup________":
					this.Lookup________ = (LookupEntity)entity;
					break;
				case "Lookup__":
					this.Lookup__ = (LookupEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Lookup_____":
					this.Lookup_____ = (LookupEntity)entity;
					break;
				case "Lookup____":
					this.Lookup____ = (LookupEntity)entity;
					break;
				case "Lookup___":
					this.Lookup___ = (LookupEntity)entity;
					break;
				case "TempCart":
					this.TempCart = (TempCartEntity)entity;
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
			return PreQualificationResultEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Calls":
					toReturn.Add(PreQualificationResultEntity.Relations.CallsEntityUsingCallId);
					break;
				case "CustomerProfile":
					toReturn.Add(PreQualificationResultEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "Events":
					toReturn.Add(PreQualificationResultEntity.Relations.EventsEntityUsingEventId);
					break;
				case "Lookup______":
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingHighCholestrol);
					break;
				case "Lookup_______":
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingOverWeight);
					break;
				case "Lookup________":
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingSmoker);
					break;
				case "Lookup__":
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingDiabetic);
					break;
				case "Lookup_":
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingChestPain);
					break;
				case "Lookup":
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingAgeOverPreQualificationQuestion);
					break;
				case "Lookup_____":
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingHighBloodPressure);
					break;
				case "Lookup____":
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingHeartDisease);
					break;
				case "Lookup___":
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingDiagnosedHeartProblem);
					break;
				case "TempCart":
					toReturn.Add(PreQualificationResultEntity.Relations.TempCartEntityUsingTempCartId);
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
				case "Calls":
					SetupSyncCalls(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "Lookup______":
					SetupSyncLookup______(relatedEntity);
					break;
				case "Lookup_______":
					SetupSyncLookup_______(relatedEntity);
					break;
				case "Lookup________":
					SetupSyncLookup________(relatedEntity);
					break;
				case "Lookup__":
					SetupSyncLookup__(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "Lookup_____":
					SetupSyncLookup_____(relatedEntity);
					break;
				case "Lookup____":
					SetupSyncLookup____(relatedEntity);
					break;
				case "Lookup___":
					SetupSyncLookup___(relatedEntity);
					break;
				case "TempCart":
					SetupSyncTempCart(relatedEntity);
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
				case "Calls":
					DesetupSyncCalls(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "Lookup______":
					DesetupSyncLookup______(false, true);
					break;
				case "Lookup_______":
					DesetupSyncLookup_______(false, true);
					break;
				case "Lookup________":
					DesetupSyncLookup________(false, true);
					break;
				case "Lookup__":
					DesetupSyncLookup__(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "Lookup_____":
					DesetupSyncLookup_____(false, true);
					break;
				case "Lookup____":
					DesetupSyncLookup____(false, true);
					break;
				case "Lookup___":
					DesetupSyncLookup___(false, true);
					break;
				case "TempCart":
					DesetupSyncTempCart(false, true);
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
			if(_calls!=null)
			{
				toReturn.Add(_calls);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_lookup______!=null)
			{
				toReturn.Add(_lookup______);
			}
			if(_lookup_______!=null)
			{
				toReturn.Add(_lookup_______);
			}
			if(_lookup________!=null)
			{
				toReturn.Add(_lookup________);
			}
			if(_lookup__!=null)
			{
				toReturn.Add(_lookup__);
			}
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_lookup_____!=null)
			{
				toReturn.Add(_lookup_____);
			}
			if(_lookup____!=null)
			{
				toReturn.Add(_lookup____);
			}
			if(_lookup___!=null)
			{
				toReturn.Add(_lookup___);
			}
			if(_tempCart!=null)
			{
				toReturn.Add(_tempCart);
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


				info.AddValue("_calls", (!this.MarkedForDeletion?_calls:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_lookup______", (!this.MarkedForDeletion?_lookup______:null));
				info.AddValue("_lookup_______", (!this.MarkedForDeletion?_lookup_______:null));
				info.AddValue("_lookup________", (!this.MarkedForDeletion?_lookup________:null));
				info.AddValue("_lookup__", (!this.MarkedForDeletion?_lookup__:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_lookup_____", (!this.MarkedForDeletion?_lookup_____:null));
				info.AddValue("_lookup____", (!this.MarkedForDeletion?_lookup____:null));
				info.AddValue("_lookup___", (!this.MarkedForDeletion?_lookup___:null));
				info.AddValue("_tempCart", (!this.MarkedForDeletion?_tempCart:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PreQualificationResultFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PreQualificationResultFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PreQualificationResultRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Calls' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallId, null, ComparisonOperator.Equal, this.CallId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Events' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.EventId, null, ComparisonOperator.Equal, this.EventId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.HighCholestrol));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.OverWeight));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Smoker));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Diabetic));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ChestPain));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.AgeOverPreQualificationQuestion));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.HighBloodPressure));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.HeartDisease));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.DiagnosedHeartProblem));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TempCart' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.TempCartId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PreQualificationResultEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationResultEntityFactory));
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
			toReturn.Add("Calls", _calls);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Events", _events);
			toReturn.Add("Lookup______", _lookup______);
			toReturn.Add("Lookup_______", _lookup_______);
			toReturn.Add("Lookup________", _lookup________);
			toReturn.Add("Lookup__", _lookup__);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Lookup_____", _lookup_____);
			toReturn.Add("Lookup____", _lookup____);
			toReturn.Add("Lookup___", _lookup___);
			toReturn.Add("TempCart", _tempCart);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_calls!=null)
			{
				_calls.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_lookup______!=null)
			{
				_lookup______.ActiveContext = base.ActiveContext;
			}
			if(_lookup_______!=null)
			{
				_lookup_______.ActiveContext = base.ActiveContext;
			}
			if(_lookup________!=null)
			{
				_lookup________.ActiveContext = base.ActiveContext;
			}
			if(_lookup__!=null)
			{
				_lookup__.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_lookup_____!=null)
			{
				_lookup_____.ActiveContext = base.ActiveContext;
			}
			if(_lookup____!=null)
			{
				_lookup____.ActiveContext = base.ActiveContext;
			}
			if(_lookup___!=null)
			{
				_lookup___.ActiveContext = base.ActiveContext;
			}
			if(_tempCart!=null)
			{
				_tempCart.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_calls = null;
			_customerProfile = null;
			_events = null;
			_lookup______ = null;
			_lookup_______ = null;
			_lookup________ = null;
			_lookup__ = null;
			_lookup_ = null;
			_lookup = null;
			_lookup_____ = null;
			_lookup____ = null;
			_lookup___ = null;
			_tempCart = null;

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

			_fieldsCustomProperties.Add("PreQualificationResultId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TempCartId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SignUpModeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HighBloodPressure", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Smoker", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HeartDisease", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Diabetic", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChestPain", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DiagnosedHeartProblem", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HighCholestrol", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OverWeight", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AgreedWithPrequalificationQuestion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkipPreQualificationQuestion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AgeOverPreQualificationQuestion", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _calls</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCalls(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _calls, new PropertyChangedEventHandler( OnCallsPropertyChanged ), "Calls", PreQualificationResultEntity.Relations.CallsEntityUsingCallId, true, signalRelatedEntity, "PreQualificationResult", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.CallId } );		
			_calls = null;
		}

		/// <summary> setups the sync logic for member _calls</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCalls(IEntity2 relatedEntity)
		{
			if(_calls!=relatedEntity)
			{
				DesetupSyncCalls(true, true);
				_calls = (CallsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _calls, new PropertyChangedEventHandler( OnCallsPropertyChanged ), "Calls", PreQualificationResultEntity.Relations.CallsEntityUsingCallId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", PreQualificationResultEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "PreQualificationResult", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", PreQualificationResultEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", PreQualificationResultEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "PreQualificationResult", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.EventId } );		
			_events = null;
		}

		/// <summary> setups the sync logic for member _events</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEvents(IEntity2 relatedEntity)
		{
			if(_events!=relatedEntity)
			{
				DesetupSyncEvents(true, true);
				_events = (EventsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", PreQualificationResultEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup______, new PropertyChangedEventHandler( OnLookup______PropertyChanged ), "Lookup______", PreQualificationResultEntity.Relations.LookupEntityUsingHighCholestrol, true, signalRelatedEntity, "PreQualificationResult______", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.HighCholestrol } );		
			_lookup______ = null;
		}

		/// <summary> setups the sync logic for member _lookup______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup______(IEntity2 relatedEntity)
		{
			if(_lookup______!=relatedEntity)
			{
				DesetupSyncLookup______(true, true);
				_lookup______ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup______, new PropertyChangedEventHandler( OnLookup______PropertyChanged ), "Lookup______", PreQualificationResultEntity.Relations.LookupEntityUsingHighCholestrol, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup_______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_______, new PropertyChangedEventHandler( OnLookup_______PropertyChanged ), "Lookup_______", PreQualificationResultEntity.Relations.LookupEntityUsingOverWeight, true, signalRelatedEntity, "PreQualificationResult_______", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.OverWeight } );		
			_lookup_______ = null;
		}

		/// <summary> setups the sync logic for member _lookup_______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup_______(IEntity2 relatedEntity)
		{
			if(_lookup_______!=relatedEntity)
			{
				DesetupSyncLookup_______(true, true);
				_lookup_______ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup_______, new PropertyChangedEventHandler( OnLookup_______PropertyChanged ), "Lookup_______", PreQualificationResultEntity.Relations.LookupEntityUsingOverWeight, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup_______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup________, new PropertyChangedEventHandler( OnLookup________PropertyChanged ), "Lookup________", PreQualificationResultEntity.Relations.LookupEntityUsingSmoker, true, signalRelatedEntity, "PreQualificationResult________", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.Smoker } );		
			_lookup________ = null;
		}

		/// <summary> setups the sync logic for member _lookup________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup________(IEntity2 relatedEntity)
		{
			if(_lookup________!=relatedEntity)
			{
				DesetupSyncLookup________(true, true);
				_lookup________ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup________, new PropertyChangedEventHandler( OnLookup________PropertyChanged ), "Lookup________", PreQualificationResultEntity.Relations.LookupEntityUsingSmoker, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", PreQualificationResultEntity.Relations.LookupEntityUsingDiabetic, true, signalRelatedEntity, "PreQualificationResult__", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.Diabetic } );		
			_lookup__ = null;
		}

		/// <summary> setups the sync logic for member _lookup__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup__(IEntity2 relatedEntity)
		{
			if(_lookup__!=relatedEntity)
			{
				DesetupSyncLookup__(true, true);
				_lookup__ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", PreQualificationResultEntity.Relations.LookupEntityUsingDiabetic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup__PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", PreQualificationResultEntity.Relations.LookupEntityUsingChestPain, true, signalRelatedEntity, "PreQualificationResult_", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.ChestPain } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", PreQualificationResultEntity.Relations.LookupEntityUsingChestPain, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", PreQualificationResultEntity.Relations.LookupEntityUsingAgeOverPreQualificationQuestion, true, signalRelatedEntity, "PreQualificationResult", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.AgeOverPreQualificationQuestion } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", PreQualificationResultEntity.Relations.LookupEntityUsingAgeOverPreQualificationQuestion, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_____, new PropertyChangedEventHandler( OnLookup_____PropertyChanged ), "Lookup_____", PreQualificationResultEntity.Relations.LookupEntityUsingHighBloodPressure, true, signalRelatedEntity, "PreQualificationResult_____", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.HighBloodPressure } );		
			_lookup_____ = null;
		}

		/// <summary> setups the sync logic for member _lookup_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup_____(IEntity2 relatedEntity)
		{
			if(_lookup_____!=relatedEntity)
			{
				DesetupSyncLookup_____(true, true);
				_lookup_____ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup_____, new PropertyChangedEventHandler( OnLookup_____PropertyChanged ), "Lookup_____", PreQualificationResultEntity.Relations.LookupEntityUsingHighBloodPressure, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup____, new PropertyChangedEventHandler( OnLookup____PropertyChanged ), "Lookup____", PreQualificationResultEntity.Relations.LookupEntityUsingHeartDisease, true, signalRelatedEntity, "PreQualificationResult____", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.HeartDisease } );		
			_lookup____ = null;
		}

		/// <summary> setups the sync logic for member _lookup____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup____(IEntity2 relatedEntity)
		{
			if(_lookup____!=relatedEntity)
			{
				DesetupSyncLookup____(true, true);
				_lookup____ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup____, new PropertyChangedEventHandler( OnLookup____PropertyChanged ), "Lookup____", PreQualificationResultEntity.Relations.LookupEntityUsingHeartDisease, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup___, new PropertyChangedEventHandler( OnLookup___PropertyChanged ), "Lookup___", PreQualificationResultEntity.Relations.LookupEntityUsingDiagnosedHeartProblem, true, signalRelatedEntity, "PreQualificationResult___", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.DiagnosedHeartProblem } );		
			_lookup___ = null;
		}

		/// <summary> setups the sync logic for member _lookup___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup___(IEntity2 relatedEntity)
		{
			if(_lookup___!=relatedEntity)
			{
				DesetupSyncLookup___(true, true);
				_lookup___ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup___, new PropertyChangedEventHandler( OnLookup___PropertyChanged ), "Lookup___", PreQualificationResultEntity.Relations.LookupEntityUsingDiagnosedHeartProblem, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _tempCart</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTempCart(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _tempCart, new PropertyChangedEventHandler( OnTempCartPropertyChanged ), "TempCart", PreQualificationResultEntity.Relations.TempCartEntityUsingTempCartId, true, signalRelatedEntity, "PreQualificationResult", resetFKFields, new int[] { (int)PreQualificationResultFieldIndex.TempCartId } );		
			_tempCart = null;
		}

		/// <summary> setups the sync logic for member _tempCart</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTempCart(IEntity2 relatedEntity)
		{
			if(_tempCart!=relatedEntity)
			{
				DesetupSyncTempCart(true, true);
				_tempCart = (TempCartEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _tempCart, new PropertyChangedEventHandler( OnTempCartPropertyChanged ), "TempCart", PreQualificationResultEntity.Relations.TempCartEntityUsingTempCartId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTempCartPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PreQualificationResultEntity</param>
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
		public  static PreQualificationResultRelations Relations
		{
			get	{ return new PreQualificationResultRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Calls' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCalls
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Calls")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, null, null, "Calls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup______")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup_______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup_______")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup________")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup__")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup_____")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup____")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup___")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TempCart' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTempCart
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory))),
					(IEntityRelation)GetRelationsForField("TempCart")[0], (int)Falcon.Data.EntityType.PreQualificationResultEntity, (int)Falcon.Data.EntityType.TempCartEntity, 0, null, null, null, null, "TempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PreQualificationResultEntity.CustomProperties;}
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
			get { return PreQualificationResultEntity.FieldsCustomProperties;}
		}

		/// <summary> The PreQualificationResultId property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."PreQualificationResultId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PreQualificationResultId
		{
			get { return (System.Int64)GetValue((int)PreQualificationResultFieldIndex.PreQualificationResultId, true); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.PreQualificationResultId, value); }
		}

		/// <summary> The EventId property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."EventId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)PreQualificationResultFieldIndex.EventId, true); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.EventId, value); }
		}

		/// <summary> The CustomerId property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."CustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.CustomerId, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.CustomerId, value); }
		}

		/// <summary> The TempCartId property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."TempCartId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TempCartId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.TempCartId, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.TempCartId, value); }
		}

		/// <summary> The SignUpModeId property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."SignUpModeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 SignUpModeId
		{
			get { return (System.Int64)GetValue((int)PreQualificationResultFieldIndex.SignUpModeId, true); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.SignUpModeId, value); }
		}

		/// <summary> The CallId property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."CallId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CallId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.CallId, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.CallId, value); }
		}

		/// <summary> The HighBloodPressure property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."HighBloodPressure"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HighBloodPressure
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.HighBloodPressure, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.HighBloodPressure, value); }
		}

		/// <summary> The Smoker property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."Smoker"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Smoker
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.Smoker, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.Smoker, value); }
		}

		/// <summary> The HeartDisease property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."HeartDisease"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HeartDisease
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.HeartDisease, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.HeartDisease, value); }
		}

		/// <summary> The Diabetic property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."Diabetic"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Diabetic
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.Diabetic, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.Diabetic, value); }
		}

		/// <summary> The ChestPain property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."ChestPain"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ChestPain
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.ChestPain, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.ChestPain, value); }
		}

		/// <summary> The DiagnosedHeartProblem property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."DiagnosedHeartProblem"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DiagnosedHeartProblem
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.DiagnosedHeartProblem, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.DiagnosedHeartProblem, value); }
		}

		/// <summary> The HighCholestrol property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."HighCholestrol"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HighCholestrol
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.HighCholestrol, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.HighCholestrol, value); }
		}

		/// <summary> The OverWeight property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."OverWeight"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> OverWeight
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.OverWeight, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.OverWeight, value); }
		}

		/// <summary> The DateCreated property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PreQualificationResultFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.DateCreated, value); }
		}

		/// <summary> The IsActive property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)PreQualificationResultFieldIndex.IsActive, true); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.IsActive, value); }
		}

		/// <summary> The AgreedWithPrequalificationQuestion property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."AgreedWithPrequalificationQuestion"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AgreedWithPrequalificationQuestion
		{
			get { return (System.Boolean)GetValue((int)PreQualificationResultFieldIndex.AgreedWithPrequalificationQuestion, true); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.AgreedWithPrequalificationQuestion, value); }
		}

		/// <summary> The SkipPreQualificationQuestion property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."SkipPreQualificationQuestion"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SkipPreQualificationQuestion
		{
			get { return (System.Boolean)GetValue((int)PreQualificationResultFieldIndex.SkipPreQualificationQuestion, true); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.SkipPreQualificationQuestion, value); }
		}

		/// <summary> The AgeOverPreQualificationQuestion property of the Entity PreQualificationResult<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationResult"."AgeOverPreQualificationQuestion"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AgeOverPreQualificationQuestion
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationResultFieldIndex.AgeOverPreQualificationQuestion, false); }
			set	{ SetValue((int)PreQualificationResultFieldIndex.AgeOverPreQualificationQuestion, value); }
		}



		/// <summary> Gets / sets related entity of type 'CallsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallsEntity Calls
		{
			get
			{
				return _calls;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCalls(value);
				}
				else
				{
					if(value==null)
					{
						if(_calls != null)
						{
							_calls.UnsetRelatedEntity(this, "PreQualificationResult");
						}
					}
					else
					{
						if(_calls!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "PreQualificationResult");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventsEntity Events
		{
			get
			{
				return _events;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEvents(value);
				}
				else
				{
					if(value==null)
					{
						if(_events != null)
						{
							_events.UnsetRelatedEntity(this, "PreQualificationResult");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup______
		{
			get
			{
				return _lookup______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup______(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup______ != null)
						{
							_lookup______.UnsetRelatedEntity(this, "PreQualificationResult______");
						}
					}
					else
					{
						if(_lookup______!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult______");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup_______
		{
			get
			{
				return _lookup_______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup_______(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup_______ != null)
						{
							_lookup_______.UnsetRelatedEntity(this, "PreQualificationResult_______");
						}
					}
					else
					{
						if(_lookup_______!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult_______");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup________
		{
			get
			{
				return _lookup________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup________(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup________ != null)
						{
							_lookup________.UnsetRelatedEntity(this, "PreQualificationResult________");
						}
					}
					else
					{
						if(_lookup________!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult________");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup__
		{
			get
			{
				return _lookup__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup__(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup__ != null)
						{
							_lookup__.UnsetRelatedEntity(this, "PreQualificationResult__");
						}
					}
					else
					{
						if(_lookup__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult__");
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
							_lookup_.UnsetRelatedEntity(this, "PreQualificationResult_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult_");
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
							_lookup.UnsetRelatedEntity(this, "PreQualificationResult");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup_____
		{
			get
			{
				return _lookup_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup_____ != null)
						{
							_lookup_____.UnsetRelatedEntity(this, "PreQualificationResult_____");
						}
					}
					else
					{
						if(_lookup_____!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult_____");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup____
		{
			get
			{
				return _lookup____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup____(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup____ != null)
						{
							_lookup____.UnsetRelatedEntity(this, "PreQualificationResult____");
						}
					}
					else
					{
						if(_lookup____!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult____");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup___
		{
			get
			{
				return _lookup___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup___(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup___ != null)
						{
							_lookup___.UnsetRelatedEntity(this, "PreQualificationResult___");
						}
					}
					else
					{
						if(_lookup___!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult___");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TempCartEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TempCartEntity TempCart
		{
			get
			{
				return _tempCart;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTempCart(value);
				}
				else
				{
					if(value==null)
					{
						if(_tempCart != null)
						{
							_tempCart.UnsetRelatedEntity(this, "PreQualificationResult");
						}
					}
					else
					{
						if(_tempCart!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationResult");
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
			get { return (int)Falcon.Data.EntityType.PreQualificationResultEntity; }
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
