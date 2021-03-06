﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:25 AM
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
	/// Entity class which represents the entity 'OsteoporosisTestFindings'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OsteoporosisTestFindingsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AaatestResultsEntity> _aaatestResults;
		private EntityCollection<CustomerEventTestsEntity> _customerEventTestsCollectionViaAaatestResults;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name AaatestResults</summary>
			public static readonly string AaatestResults = "AaatestResults";
			/// <summary>Member name CustomerEventTestsCollectionViaAaatestResults</summary>
			public static readonly string CustomerEventTestsCollectionViaAaatestResults = "CustomerEventTestsCollectionViaAaatestResults";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OsteoporosisTestFindingsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public OsteoporosisTestFindingsEntity():base("OsteoporosisTestFindingsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OsteoporosisTestFindingsEntity(IEntityFields2 fields):base("OsteoporosisTestFindingsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OsteoporosisTestFindingsEntity</param>
		public OsteoporosisTestFindingsEntity(IValidator validator):base("OsteoporosisTestFindingsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="osteoporosisTestFindingsId">PK value for OsteoporosisTestFindings which data should be fetched into this OsteoporosisTestFindings object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OsteoporosisTestFindingsEntity(System.Int32 osteoporosisTestFindingsId):base("OsteoporosisTestFindingsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OsteoporosisTestFindingsId = osteoporosisTestFindingsId;
		}

		/// <summary> CTor</summary>
		/// <param name="osteoporosisTestFindingsId">PK value for OsteoporosisTestFindings which data should be fetched into this OsteoporosisTestFindings object</param>
		/// <param name="validator">The custom validator object for this OsteoporosisTestFindingsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OsteoporosisTestFindingsEntity(System.Int32 osteoporosisTestFindingsId, IValidator validator):base("OsteoporosisTestFindingsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OsteoporosisTestFindingsId = osteoporosisTestFindingsId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected OsteoporosisTestFindingsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_aaatestResults = (EntityCollection<AaatestResultsEntity>)info.GetValue("_aaatestResults", typeof(EntityCollection<AaatestResultsEntity>));
				_customerEventTestsCollectionViaAaatestResults = (EntityCollection<CustomerEventTestsEntity>)info.GetValue("_customerEventTestsCollectionViaAaatestResults", typeof(EntityCollection<CustomerEventTestsEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((OsteoporosisTestFindingsFieldIndex)fieldIndex)
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

				case "AaatestResults":
					this.AaatestResults.Add((AaatestResultsEntity)entity);
					break;
				case "CustomerEventTestsCollectionViaAaatestResults":
					this.CustomerEventTestsCollectionViaAaatestResults.IsReadOnly = false;
					this.CustomerEventTestsCollectionViaAaatestResults.Add((CustomerEventTestsEntity)entity);
					this.CustomerEventTestsCollectionViaAaatestResults.IsReadOnly = true;
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
			return OsteoporosisTestFindingsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "AaatestResults":
					toReturn.Add(OsteoporosisTestFindingsEntity.Relations.AaatestResultsEntityUsingAaatestFindingsId);
					break;
				case "CustomerEventTestsCollectionViaAaatestResults":
					toReturn.Add(OsteoporosisTestFindingsEntity.Relations.AaatestResultsEntityUsingAaatestFindingsId, "OsteoporosisTestFindingsEntity__", "AaatestResults_", JoinHint.None);
					toReturn.Add(AaatestResultsEntity.Relations.CustomerEventTestsEntityUsingCustomerEventTestId, "AaatestResults_", string.Empty, JoinHint.None);
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

				case "AaatestResults":
					this.AaatestResults.Add((AaatestResultsEntity)relatedEntity);
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

				case "AaatestResults":
					base.PerformRelatedEntityRemoval(this.AaatestResults, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.AaatestResults);

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
				info.AddValue("_aaatestResults", ((_aaatestResults!=null) && (_aaatestResults.Count>0) && !this.MarkedForDeletion)?_aaatestResults:null);
				info.AddValue("_customerEventTestsCollectionViaAaatestResults", ((_customerEventTestsCollectionViaAaatestResults!=null) && (_customerEventTestsCollectionViaAaatestResults.Count>0) && !this.MarkedForDeletion)?_customerEventTestsCollectionViaAaatestResults:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OsteoporosisTestFindingsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OsteoporosisTestFindingsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OsteoporosisTestFindingsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AaatestResults' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAaatestResults()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AaatestResultsFields.AaatestFindingsId, null, ComparisonOperator.Equal, this.OsteoporosisTestFindingsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestsCollectionViaAaatestResults()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventTestsCollectionViaAaatestResults"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OsteoporosisTestFindingsFields.OsteoporosisTestFindingsId, null, ComparisonOperator.Equal, this.OsteoporosisTestFindingsId, "OsteoporosisTestFindingsEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.OsteoporosisTestFindingsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(OsteoporosisTestFindingsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._aaatestResults);
			collectionsQueue.Enqueue(this._customerEventTestsCollectionViaAaatestResults);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._aaatestResults = (EntityCollection<AaatestResultsEntity>) collectionsQueue.Dequeue();
			this._customerEventTestsCollectionViaAaatestResults = (EntityCollection<CustomerEventTestsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._aaatestResults != null)
			{
				return true;
			}
			if (this._customerEventTestsCollectionViaAaatestResults != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AaatestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestResultsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("AaatestResults", _aaatestResults);
			toReturn.Add("CustomerEventTestsCollectionViaAaatestResults", _customerEventTestsCollectionViaAaatestResults);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_aaatestResults!=null)
			{
				_aaatestResults.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestsCollectionViaAaatestResults!=null)
			{
				_customerEventTestsCollectionViaAaatestResults.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_aaatestResults = null;
			_customerEventTestsCollectionViaAaatestResults = null;


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

			_fieldsCustomProperties.Add("OsteoporosisTestFindingsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Label", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComparisonLabel", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OsteoporosisTestFindingsEntity</param>
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
		public  static OsteoporosisTestFindingsRelations Relations
		{
			get	{ return new OsteoporosisTestFindingsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AaatestResults' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAaatestResults
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AaatestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestResultsEntityFactory))),
					(IEntityRelation)GetRelationsForField("AaatestResults")[0], (int)HealthYes.Data.EntityType.OsteoporosisTestFindingsEntity, (int)HealthYes.Data.EntityType.AaatestResultsEntity, 0, null, null, null, null, "AaatestResults", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestsCollectionViaAaatestResults
		{
			get
			{
				IEntityRelation intermediateRelation = OsteoporosisTestFindingsEntity.Relations.AaatestResultsEntityUsingAaatestFindingsId;
				intermediateRelation.SetAliases(string.Empty, "AaatestResults_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.OsteoporosisTestFindingsEntity, (int)HealthYes.Data.EntityType.CustomerEventTestsEntity, 0, null, null, GetRelationsForField("CustomerEventTestsCollectionViaAaatestResults"), null, "CustomerEventTestsCollectionViaAaatestResults", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OsteoporosisTestFindingsEntity.CustomProperties;}
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
			get { return OsteoporosisTestFindingsEntity.FieldsCustomProperties;}
		}

		/// <summary> The OsteoporosisTestFindingsId property of the Entity OsteoporosisTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestFindings_Legacy"."AAATestFindingsID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 OsteoporosisTestFindingsId
		{
			get { return (System.Int32)GetValue((int)OsteoporosisTestFindingsFieldIndex.OsteoporosisTestFindingsId, true); }
			set	{ SetValue((int)OsteoporosisTestFindingsFieldIndex.OsteoporosisTestFindingsId, value); }
		}

		/// <summary> The Label property of the Entity OsteoporosisTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestFindings_Legacy"."Label"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Label
		{
			get { return (System.String)GetValue((int)OsteoporosisTestFindingsFieldIndex.Label, true); }
			set	{ SetValue((int)OsteoporosisTestFindingsFieldIndex.Label, value); }
		}

		/// <summary> The Description property of the Entity OsteoporosisTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestFindings_Legacy"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)OsteoporosisTestFindingsFieldIndex.Description, true); }
			set	{ SetValue((int)OsteoporosisTestFindingsFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity OsteoporosisTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestFindings_Legacy"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)OsteoporosisTestFindingsFieldIndex.DateCreated, false); }
			set	{ SetValue((int)OsteoporosisTestFindingsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity OsteoporosisTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestFindings_Legacy"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)OsteoporosisTestFindingsFieldIndex.DateModified, false); }
			set	{ SetValue((int)OsteoporosisTestFindingsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity OsteoporosisTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestFindings_Legacy"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsActive
		{
			get { return (Nullable<System.Boolean>)GetValue((int)OsteoporosisTestFindingsFieldIndex.IsActive, false); }
			set	{ SetValue((int)OsteoporosisTestFindingsFieldIndex.IsActive, value); }
		}

		/// <summary> The ComparisonLabel property of the Entity OsteoporosisTestFindings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAAATestFindings_Legacy"."ComparisonLabel"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ComparisonLabel
		{
			get { return (System.String)GetValue((int)OsteoporosisTestFindingsFieldIndex.ComparisonLabel, true); }
			set	{ SetValue((int)OsteoporosisTestFindingsFieldIndex.ComparisonLabel, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AaatestResultsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AaatestResultsEntity))]
		public virtual EntityCollection<AaatestResultsEntity> AaatestResults
		{
			get
			{
				if(_aaatestResults==null)
				{
					_aaatestResults = new EntityCollection<AaatestResultsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AaatestResultsEntityFactory)));
					_aaatestResults.SetContainingEntityInfo(this, "OsteoporosisTestFindings");
				}
				return _aaatestResults;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestsEntity))]
		public virtual EntityCollection<CustomerEventTestsEntity> CustomerEventTestsCollectionViaAaatestResults
		{
			get
			{
				if(_customerEventTestsCollectionViaAaatestResults==null)
				{
					_customerEventTestsCollectionViaAaatestResults = new EntityCollection<CustomerEventTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestsEntityFactory)));
					_customerEventTestsCollectionViaAaatestResults.IsReadOnly=true;
				}
				return _customerEventTestsCollectionViaAaatestResults;
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
			get { return (int)HealthYes.Data.EntityType.OsteoporosisTestFindingsEntity; }
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
