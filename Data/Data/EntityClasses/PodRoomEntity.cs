///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:48
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
	/// Entity class which represents the entity 'PodRoom'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PodRoomEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventPackageDetailsEntity> _eventPackageDetails;
		private EntityCollection<PodRoomTestEntity> _podRoomTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventPackageDetails;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaEventPackageDetails;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventPackageDetails;
		private EntityCollection<PackageEntity> _packageCollectionViaEventPackageDetails;
		private EntityCollection<TestEntity> _testCollectionViaPodRoomTest;
		private PodDetailsEntity _podDetails;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name PodDetails</summary>
			public static readonly string PodDetails = "PodDetails";
			/// <summary>Member name EventPackageDetails</summary>
			public static readonly string EventPackageDetails = "EventPackageDetails";
			/// <summary>Member name PodRoomTest</summary>
			public static readonly string PodRoomTest = "PodRoomTest";
			/// <summary>Member name EventsCollectionViaEventPackageDetails</summary>
			public static readonly string EventsCollectionViaEventPackageDetails = "EventsCollectionViaEventPackageDetails";
			/// <summary>Member name HafTemplateCollectionViaEventPackageDetails</summary>
			public static readonly string HafTemplateCollectionViaEventPackageDetails = "HafTemplateCollectionViaEventPackageDetails";
			/// <summary>Member name LookupCollectionViaEventPackageDetails</summary>
			public static readonly string LookupCollectionViaEventPackageDetails = "LookupCollectionViaEventPackageDetails";
			/// <summary>Member name PackageCollectionViaEventPackageDetails</summary>
			public static readonly string PackageCollectionViaEventPackageDetails = "PackageCollectionViaEventPackageDetails";
			/// <summary>Member name TestCollectionViaPodRoomTest</summary>
			public static readonly string TestCollectionViaPodRoomTest = "TestCollectionViaPodRoomTest";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PodRoomEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PodRoomEntity():base("PodRoomEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PodRoomEntity(IEntityFields2 fields):base("PodRoomEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PodRoomEntity</param>
		public PodRoomEntity(IValidator validator):base("PodRoomEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="podRoomId">PK value for PodRoom which data should be fetched into this PodRoom object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PodRoomEntity(System.Int64 podRoomId):base("PodRoomEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PodRoomId = podRoomId;
		}

		/// <summary> CTor</summary>
		/// <param name="podRoomId">PK value for PodRoom which data should be fetched into this PodRoom object</param>
		/// <param name="validator">The custom validator object for this PodRoomEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PodRoomEntity(System.Int64 podRoomId, IValidator validator):base("PodRoomEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PodRoomId = podRoomId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PodRoomEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventPackageDetails = (EntityCollection<EventPackageDetailsEntity>)info.GetValue("_eventPackageDetails", typeof(EntityCollection<EventPackageDetailsEntity>));
				_podRoomTest = (EntityCollection<PodRoomTestEntity>)info.GetValue("_podRoomTest", typeof(EntityCollection<PodRoomTestEntity>));
				_eventsCollectionViaEventPackageDetails = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventPackageDetails", typeof(EntityCollection<EventsEntity>));
				_hafTemplateCollectionViaEventPackageDetails = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaEventPackageDetails", typeof(EntityCollection<HafTemplateEntity>));
				_lookupCollectionViaEventPackageDetails = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventPackageDetails", typeof(EntityCollection<LookupEntity>));
				_packageCollectionViaEventPackageDetails = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaEventPackageDetails", typeof(EntityCollection<PackageEntity>));
				_testCollectionViaPodRoomTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaPodRoomTest", typeof(EntityCollection<TestEntity>));
				_podDetails = (PodDetailsEntity)info.GetValue("_podDetails", typeof(PodDetailsEntity));
				if(_podDetails!=null)
				{
					_podDetails.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PodRoomFieldIndex)fieldIndex)
			{
				case PodRoomFieldIndex.PodId:
					DesetupSyncPodDetails(true, false);
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
				case "PodDetails":
					this.PodDetails = (PodDetailsEntity)entity;
					break;
				case "EventPackageDetails":
					this.EventPackageDetails.Add((EventPackageDetailsEntity)entity);
					break;
				case "PodRoomTest":
					this.PodRoomTest.Add((PodRoomTestEntity)entity);
					break;
				case "EventsCollectionViaEventPackageDetails":
					this.EventsCollectionViaEventPackageDetails.IsReadOnly = false;
					this.EventsCollectionViaEventPackageDetails.Add((EventsEntity)entity);
					this.EventsCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaEventPackageDetails":
					this.HafTemplateCollectionViaEventPackageDetails.IsReadOnly = false;
					this.HafTemplateCollectionViaEventPackageDetails.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventPackageDetails":
					this.LookupCollectionViaEventPackageDetails.IsReadOnly = false;
					this.LookupCollectionViaEventPackageDetails.Add((LookupEntity)entity);
					this.LookupCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "PackageCollectionViaEventPackageDetails":
					this.PackageCollectionViaEventPackageDetails.IsReadOnly = false;
					this.PackageCollectionViaEventPackageDetails.Add((PackageEntity)entity);
					this.PackageCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "TestCollectionViaPodRoomTest":
					this.TestCollectionViaPodRoomTest.IsReadOnly = false;
					this.TestCollectionViaPodRoomTest.Add((TestEntity)entity);
					this.TestCollectionViaPodRoomTest.IsReadOnly = true;
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
			return PodRoomEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "PodDetails":
					toReturn.Add(PodRoomEntity.Relations.PodDetailsEntityUsingPodId);
					break;
				case "EventPackageDetails":
					toReturn.Add(PodRoomEntity.Relations.EventPackageDetailsEntityUsingPodRoomId);
					break;
				case "PodRoomTest":
					toReturn.Add(PodRoomEntity.Relations.PodRoomTestEntityUsingPodRoomId);
					break;
				case "EventsCollectionViaEventPackageDetails":
					toReturn.Add(PodRoomEntity.Relations.EventPackageDetailsEntityUsingPodRoomId, "PodRoomEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.EventsEntityUsingEventId, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaEventPackageDetails":
					toReturn.Add(PodRoomEntity.Relations.EventPackageDetailsEntityUsingPodRoomId, "PodRoomEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.HafTemplateEntityUsingHafTemplateId, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventPackageDetails":
					toReturn.Add(PodRoomEntity.Relations.EventPackageDetailsEntityUsingPodRoomId, "PodRoomEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.LookupEntityUsingGender, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaEventPackageDetails":
					toReturn.Add(PodRoomEntity.Relations.EventPackageDetailsEntityUsingPodRoomId, "PodRoomEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.PackageEntityUsingPackageId, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaPodRoomTest":
					toReturn.Add(PodRoomEntity.Relations.PodRoomTestEntityUsingPodRoomId, "PodRoomEntity__", "PodRoomTest_", JoinHint.None);
					toReturn.Add(PodRoomTestEntity.Relations.TestEntityUsingTestId, "PodRoomTest_", string.Empty, JoinHint.None);
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
				case "PodDetails":
					SetupSyncPodDetails(relatedEntity);
					break;
				case "EventPackageDetails":
					this.EventPackageDetails.Add((EventPackageDetailsEntity)relatedEntity);
					break;
				case "PodRoomTest":
					this.PodRoomTest.Add((PodRoomTestEntity)relatedEntity);
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
				case "PodDetails":
					DesetupSyncPodDetails(false, true);
					break;
				case "EventPackageDetails":
					base.PerformRelatedEntityRemoval(this.EventPackageDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodRoomTest":
					base.PerformRelatedEntityRemoval(this.PodRoomTest, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_podDetails!=null)
			{
				toReturn.Add(_podDetails);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventPackageDetails);
			toReturn.Add(this.PodRoomTest);

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
				info.AddValue("_eventPackageDetails", ((_eventPackageDetails!=null) && (_eventPackageDetails.Count>0) && !this.MarkedForDeletion)?_eventPackageDetails:null);
				info.AddValue("_podRoomTest", ((_podRoomTest!=null) && (_podRoomTest.Count>0) && !this.MarkedForDeletion)?_podRoomTest:null);
				info.AddValue("_eventsCollectionViaEventPackageDetails", ((_eventsCollectionViaEventPackageDetails!=null) && (_eventsCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventPackageDetails:null);
				info.AddValue("_hafTemplateCollectionViaEventPackageDetails", ((_hafTemplateCollectionViaEventPackageDetails!=null) && (_hafTemplateCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaEventPackageDetails:null);
				info.AddValue("_lookupCollectionViaEventPackageDetails", ((_lookupCollectionViaEventPackageDetails!=null) && (_lookupCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventPackageDetails:null);
				info.AddValue("_packageCollectionViaEventPackageDetails", ((_packageCollectionViaEventPackageDetails!=null) && (_packageCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaEventPackageDetails:null);
				info.AddValue("_testCollectionViaPodRoomTest", ((_testCollectionViaPodRoomTest!=null) && (_testCollectionViaPodRoomTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaPodRoomTest:null);
				info.AddValue("_podDetails", (!this.MarkedForDeletion?_podDetails:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PodRoomFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PodRoomFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PodRoomRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.PodRoomId, null, ComparisonOperator.Equal, this.PodRoomId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodRoomTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodRoomTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodRoomTestFields.PodRoomId, null, ComparisonOperator.Equal, this.PodRoomId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodRoomFields.PodRoomId, null, ComparisonOperator.Equal, this.PodRoomId, "PodRoomEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodRoomFields.PodRoomId, null, ComparisonOperator.Equal, this.PodRoomId, "PodRoomEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodRoomFields.PodRoomId, null, ComparisonOperator.Equal, this.PodRoomId, "PodRoomEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodRoomFields.PodRoomId, null, ComparisonOperator.Equal, this.PodRoomId, "PodRoomEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaPodRoomTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaPodRoomTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodRoomFields.PodRoomId, null, ComparisonOperator.Equal, this.PodRoomId, "PodRoomEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.PodId, null, ComparisonOperator.Equal, this.PodId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PodRoomEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventPackageDetails);
			collectionsQueue.Enqueue(this._podRoomTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._packageCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._testCollectionViaPodRoomTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventPackageDetails = (EntityCollection<EventPackageDetailsEntity>) collectionsQueue.Dequeue();
			this._podRoomTest = (EntityCollection<PodRoomTestEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventPackageDetails = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaEventPackageDetails = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventPackageDetails = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaEventPackageDetails = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaPodRoomTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventPackageDetails != null)
			{
				return true;
			}
			if (this._podRoomTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._packageCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._testCollectionViaPodRoomTest != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("PodDetails", _podDetails);
			toReturn.Add("EventPackageDetails", _eventPackageDetails);
			toReturn.Add("PodRoomTest", _podRoomTest);
			toReturn.Add("EventsCollectionViaEventPackageDetails", _eventsCollectionViaEventPackageDetails);
			toReturn.Add("HafTemplateCollectionViaEventPackageDetails", _hafTemplateCollectionViaEventPackageDetails);
			toReturn.Add("LookupCollectionViaEventPackageDetails", _lookupCollectionViaEventPackageDetails);
			toReturn.Add("PackageCollectionViaEventPackageDetails", _packageCollectionViaEventPackageDetails);
			toReturn.Add("TestCollectionViaPodRoomTest", _testCollectionViaPodRoomTest);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventPackageDetails!=null)
			{
				_eventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_podRoomTest!=null)
			{
				_podRoomTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventPackageDetails!=null)
			{
				_eventsCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaEventPackageDetails!=null)
			{
				_hafTemplateCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventPackageDetails!=null)
			{
				_lookupCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaEventPackageDetails!=null)
			{
				_packageCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaPodRoomTest!=null)
			{
				_testCollectionViaPodRoomTest.ActiveContext = base.ActiveContext;
			}
			if(_podDetails!=null)
			{
				_podDetails.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventPackageDetails = null;
			_podRoomTest = null;
			_eventsCollectionViaEventPackageDetails = null;
			_hafTemplateCollectionViaEventPackageDetails = null;
			_lookupCollectionViaEventPackageDetails = null;
			_packageCollectionViaEventPackageDetails = null;
			_testCollectionViaPodRoomTest = null;
			_podDetails = null;

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

			_fieldsCustomProperties.Add("PodRoomId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PodId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoomNo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Duration", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _podDetails</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPodDetails(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _podDetails, new PropertyChangedEventHandler( OnPodDetailsPropertyChanged ), "PodDetails", PodRoomEntity.Relations.PodDetailsEntityUsingPodId, true, signalRelatedEntity, "PodRoom", resetFKFields, new int[] { (int)PodRoomFieldIndex.PodId } );		
			_podDetails = null;
		}

		/// <summary> setups the sync logic for member _podDetails</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPodDetails(IEntity2 relatedEntity)
		{
			if(_podDetails!=relatedEntity)
			{
				DesetupSyncPodDetails(true, true);
				_podDetails = (PodDetailsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _podDetails, new PropertyChangedEventHandler( OnPodDetailsPropertyChanged ), "PodDetails", PodRoomEntity.Relations.PodDetailsEntityUsingPodId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPodDetailsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PodRoomEntity</param>
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
		public  static PodRoomRelations Relations
		{
			get	{ return new PodRoomRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPackageDetails")[0], (int)Falcon.Data.EntityType.PodRoomEntity, (int)Falcon.Data.EntityType.EventPackageDetailsEntity, 0, null, null, null, null, "EventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodRoomTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodRoomTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodRoomTest")[0], (int)Falcon.Data.EntityType.PodRoomEntity, (int)Falcon.Data.EntityType.PodRoomTestEntity, 0, null, null, null, null, "PodRoomTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = PodRoomEntity.Relations.EventPackageDetailsEntityUsingPodRoomId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodRoomEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventPackageDetails"), null, "EventsCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = PodRoomEntity.Relations.EventPackageDetailsEntityUsingPodRoomId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodRoomEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaEventPackageDetails"), null, "HafTemplateCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = PodRoomEntity.Relations.EventPackageDetailsEntityUsingPodRoomId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodRoomEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventPackageDetails"), null, "LookupCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = PodRoomEntity.Relations.EventPackageDetailsEntityUsingPodRoomId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodRoomEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaEventPackageDetails"), null, "PackageCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaPodRoomTest
		{
			get
			{
				IEntityRelation intermediateRelation = PodRoomEntity.Relations.PodRoomTestEntityUsingPodRoomId;
				intermediateRelation.SetAliases(string.Empty, "PodRoomTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PodRoomEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaPodRoomTest"), null, "TestCollectionViaPodRoomTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetails
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodDetails")[0], (int)Falcon.Data.EntityType.PodRoomEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, null, null, "PodDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PodRoomEntity.CustomProperties;}
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
			get { return PodRoomEntity.FieldsCustomProperties;}
		}

		/// <summary> The PodRoomId property of the Entity PodRoom<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodRoom"."PodRoomId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PodRoomId
		{
			get { return (System.Int64)GetValue((int)PodRoomFieldIndex.PodRoomId, true); }
			set	{ SetValue((int)PodRoomFieldIndex.PodRoomId, value); }
		}

		/// <summary> The PodId property of the Entity PodRoom<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodRoom"."PodId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PodId
		{
			get { return (System.Int64)GetValue((int)PodRoomFieldIndex.PodId, true); }
			set	{ SetValue((int)PodRoomFieldIndex.PodId, value); }
		}

		/// <summary> The RoomNo property of the Entity PodRoom<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodRoom"."RoomNo"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RoomNo
		{
			get { return (System.Int32)GetValue((int)PodRoomFieldIndex.RoomNo, true); }
			set	{ SetValue((int)PodRoomFieldIndex.RoomNo, value); }
		}

		/// <summary> The Duration property of the Entity PodRoom<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPodRoom"."Duration"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Duration
		{
			get { return (System.Int32)GetValue((int)PodRoomFieldIndex.Duration, true); }
			set	{ SetValue((int)PodRoomFieldIndex.Duration, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageDetailsEntity))]
		public virtual EntityCollection<EventPackageDetailsEntity> EventPackageDetails
		{
			get
			{
				if(_eventPackageDetails==null)
				{
					_eventPackageDetails = new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory)));
					_eventPackageDetails.SetContainingEntityInfo(this, "PodRoom");
				}
				return _eventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodRoomTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodRoomTestEntity))]
		public virtual EntityCollection<PodRoomTestEntity> PodRoomTest
		{
			get
			{
				if(_podRoomTest==null)
				{
					_podRoomTest = new EntityCollection<PodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomTestEntityFactory)));
					_podRoomTest.SetContainingEntityInfo(this, "PodRoom");
				}
				return _podRoomTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventPackageDetails
		{
			get
			{
				if(_eventsCollectionViaEventPackageDetails==null)
				{
					_eventsCollectionViaEventPackageDetails = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventPackageDetails.IsReadOnly=true;
				}
				return _eventsCollectionViaEventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaEventPackageDetails
		{
			get
			{
				if(_hafTemplateCollectionViaEventPackageDetails==null)
				{
					_hafTemplateCollectionViaEventPackageDetails = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaEventPackageDetails.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaEventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventPackageDetails
		{
			get
			{
				if(_lookupCollectionViaEventPackageDetails==null)
				{
					_lookupCollectionViaEventPackageDetails = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventPackageDetails.IsReadOnly=true;
				}
				return _lookupCollectionViaEventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaEventPackageDetails
		{
			get
			{
				if(_packageCollectionViaEventPackageDetails==null)
				{
					_packageCollectionViaEventPackageDetails = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaEventPackageDetails.IsReadOnly=true;
				}
				return _packageCollectionViaEventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaPodRoomTest
		{
			get
			{
				if(_testCollectionViaPodRoomTest==null)
				{
					_testCollectionViaPodRoomTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaPodRoomTest.IsReadOnly=true;
				}
				return _testCollectionViaPodRoomTest;
			}
		}

		/// <summary> Gets / sets related entity of type 'PodDetailsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PodDetailsEntity PodDetails
		{
			get
			{
				return _podDetails;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPodDetails(value);
				}
				else
				{
					if(value==null)
					{
						if(_podDetails != null)
						{
							_podDetails.UnsetRelatedEntity(this, "PodRoom");
						}
					}
					else
					{
						if(_podDetails!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PodRoom");
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
			get { return (int)Falcon.Data.EntityType.PodRoomEntity; }
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
