///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:45
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
	/// Entity class which represents the entity 'ClickLog'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ClickLogEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ClickConversionEntity> _clickConversion;
		private EntityCollection<ClickKeywordEntity> _clickKeyword;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaClickConversion;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaClickConversion;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaClickConversion;
		private AfcampaignEntity _afcampaign;
		private AfmarketingMaterialEntity _afmarketingMaterial;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Afcampaign</summary>
			public static readonly string Afcampaign = "Afcampaign";
			/// <summary>Member name AfmarketingMaterial</summary>
			public static readonly string AfmarketingMaterial = "AfmarketingMaterial";
			/// <summary>Member name ClickConversion</summary>
			public static readonly string ClickConversion = "ClickConversion";
			/// <summary>Member name ClickKeyword</summary>
			public static readonly string ClickKeyword = "ClickKeyword";
			/// <summary>Member name CustomerProfileCollectionViaClickConversion</summary>
			public static readonly string CustomerProfileCollectionViaClickConversion = "CustomerProfileCollectionViaClickConversion";
			/// <summary>Member name EventCustomersCollectionViaClickConversion</summary>
			public static readonly string EventCustomersCollectionViaClickConversion = "EventCustomersCollectionViaClickConversion";
			/// <summary>Member name ProspectCustomerCollectionViaClickConversion</summary>
			public static readonly string ProspectCustomerCollectionViaClickConversion = "ProspectCustomerCollectionViaClickConversion";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ClickLogEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ClickLogEntity():base("ClickLogEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ClickLogEntity(IEntityFields2 fields):base("ClickLogEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ClickLogEntity</param>
		public ClickLogEntity(IValidator validator):base("ClickLogEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="clickId">PK value for ClickLog which data should be fetched into this ClickLog object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ClickLogEntity(System.Int64 clickId):base("ClickLogEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ClickId = clickId;
		}

		/// <summary> CTor</summary>
		/// <param name="clickId">PK value for ClickLog which data should be fetched into this ClickLog object</param>
		/// <param name="validator">The custom validator object for this ClickLogEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ClickLogEntity(System.Int64 clickId, IValidator validator):base("ClickLogEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ClickId = clickId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ClickLogEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_clickConversion = (EntityCollection<ClickConversionEntity>)info.GetValue("_clickConversion", typeof(EntityCollection<ClickConversionEntity>));
				_clickKeyword = (EntityCollection<ClickKeywordEntity>)info.GetValue("_clickKeyword", typeof(EntityCollection<ClickKeywordEntity>));
				_customerProfileCollectionViaClickConversion = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaClickConversion", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaClickConversion = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaClickConversion", typeof(EntityCollection<EventCustomersEntity>));
				_prospectCustomerCollectionViaClickConversion = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaClickConversion", typeof(EntityCollection<ProspectCustomerEntity>));
				_afcampaign = (AfcampaignEntity)info.GetValue("_afcampaign", typeof(AfcampaignEntity));
				if(_afcampaign!=null)
				{
					_afcampaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_afmarketingMaterial = (AfmarketingMaterialEntity)info.GetValue("_afmarketingMaterial", typeof(AfmarketingMaterialEntity));
				if(_afmarketingMaterial!=null)
				{
					_afmarketingMaterial.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ClickLogFieldIndex)fieldIndex)
			{
				case ClickLogFieldIndex.CampaignId:
					DesetupSyncAfcampaign(true, false);
					break;
				case ClickLogFieldIndex.MarketingMaterialId:
					DesetupSyncAfmarketingMaterial(true, false);
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
				case "Afcampaign":
					this.Afcampaign = (AfcampaignEntity)entity;
					break;
				case "AfmarketingMaterial":
					this.AfmarketingMaterial = (AfmarketingMaterialEntity)entity;
					break;
				case "ClickConversion":
					this.ClickConversion.Add((ClickConversionEntity)entity);
					break;
				case "ClickKeyword":
					this.ClickKeyword.Add((ClickKeywordEntity)entity);
					break;
				case "CustomerProfileCollectionViaClickConversion":
					this.CustomerProfileCollectionViaClickConversion.IsReadOnly = false;
					this.CustomerProfileCollectionViaClickConversion.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaClickConversion.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaClickConversion":
					this.EventCustomersCollectionViaClickConversion.IsReadOnly = false;
					this.EventCustomersCollectionViaClickConversion.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaClickConversion.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaClickConversion":
					this.ProspectCustomerCollectionViaClickConversion.IsReadOnly = false;
					this.ProspectCustomerCollectionViaClickConversion.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaClickConversion.IsReadOnly = true;
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
			return ClickLogEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Afcampaign":
					toReturn.Add(ClickLogEntity.Relations.AfcampaignEntityUsingCampaignId);
					break;
				case "AfmarketingMaterial":
					toReturn.Add(ClickLogEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId);
					break;
				case "ClickConversion":
					toReturn.Add(ClickLogEntity.Relations.ClickConversionEntityUsingClickId);
					break;
				case "ClickKeyword":
					toReturn.Add(ClickLogEntity.Relations.ClickKeywordEntityUsingClickId);
					break;
				case "CustomerProfileCollectionViaClickConversion":
					toReturn.Add(ClickLogEntity.Relations.ClickConversionEntityUsingClickId, "ClickLogEntity__", "ClickConversion_", JoinHint.None);
					toReturn.Add(ClickConversionEntity.Relations.CustomerProfileEntityUsingCustomerId, "ClickConversion_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaClickConversion":
					toReturn.Add(ClickLogEntity.Relations.ClickConversionEntityUsingClickId, "ClickLogEntity__", "ClickConversion_", JoinHint.None);
					toReturn.Add(ClickConversionEntity.Relations.EventCustomersEntityUsingEventCustomerId, "ClickConversion_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaClickConversion":
					toReturn.Add(ClickLogEntity.Relations.ClickConversionEntityUsingClickId, "ClickLogEntity__", "ClickConversion_", JoinHint.None);
					toReturn.Add(ClickConversionEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "ClickConversion_", string.Empty, JoinHint.None);
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
				case "Afcampaign":
					SetupSyncAfcampaign(relatedEntity);
					break;
				case "AfmarketingMaterial":
					SetupSyncAfmarketingMaterial(relatedEntity);
					break;
				case "ClickConversion":
					this.ClickConversion.Add((ClickConversionEntity)relatedEntity);
					break;
				case "ClickKeyword":
					this.ClickKeyword.Add((ClickKeywordEntity)relatedEntity);
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
				case "Afcampaign":
					DesetupSyncAfcampaign(false, true);
					break;
				case "AfmarketingMaterial":
					DesetupSyncAfmarketingMaterial(false, true);
					break;
				case "ClickConversion":
					base.PerformRelatedEntityRemoval(this.ClickConversion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ClickKeyword":
					base.PerformRelatedEntityRemoval(this.ClickKeyword, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_afcampaign!=null)
			{
				toReturn.Add(_afcampaign);
			}
			if(_afmarketingMaterial!=null)
			{
				toReturn.Add(_afmarketingMaterial);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ClickConversion);
			toReturn.Add(this.ClickKeyword);

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
				info.AddValue("_clickConversion", ((_clickConversion!=null) && (_clickConversion.Count>0) && !this.MarkedForDeletion)?_clickConversion:null);
				info.AddValue("_clickKeyword", ((_clickKeyword!=null) && (_clickKeyword.Count>0) && !this.MarkedForDeletion)?_clickKeyword:null);
				info.AddValue("_customerProfileCollectionViaClickConversion", ((_customerProfileCollectionViaClickConversion!=null) && (_customerProfileCollectionViaClickConversion.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaClickConversion:null);
				info.AddValue("_eventCustomersCollectionViaClickConversion", ((_eventCustomersCollectionViaClickConversion!=null) && (_eventCustomersCollectionViaClickConversion.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaClickConversion:null);
				info.AddValue("_prospectCustomerCollectionViaClickConversion", ((_prospectCustomerCollectionViaClickConversion!=null) && (_prospectCustomerCollectionViaClickConversion.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaClickConversion:null);
				info.AddValue("_afcampaign", (!this.MarkedForDeletion?_afcampaign:null));
				info.AddValue("_afmarketingMaterial", (!this.MarkedForDeletion?_afmarketingMaterial:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ClickLogFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ClickLogFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ClickLogRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClickConversion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClickConversionFields.ClickId, null, ComparisonOperator.Equal, this.ClickId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClickKeyword' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClickKeyword()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClickKeywordFields.ClickId, null, ComparisonOperator.Equal, this.ClickId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaClickConversion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClickLogFields.ClickId, null, ComparisonOperator.Equal, this.ClickId, "ClickLogEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaClickConversion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClickLogFields.ClickId, null, ComparisonOperator.Equal, this.ClickId, "ClickLogEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaClickConversion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClickLogFields.ClickId, null, ComparisonOperator.Equal, this.ClickId, "ClickLogEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AfmarketingMaterial' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfmarketingMaterial()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ClickLogEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._clickConversion);
			collectionsQueue.Enqueue(this._clickKeyword);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaClickConversion);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaClickConversion);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaClickConversion);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._clickConversion = (EntityCollection<ClickConversionEntity>) collectionsQueue.Dequeue();
			this._clickKeyword = (EntityCollection<ClickKeywordEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaClickConversion = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaClickConversion = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaClickConversion = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._clickConversion != null)
			{
				return true;
			}
			if (this._clickKeyword != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaClickConversion != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaClickConversion != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaClickConversion != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClickConversionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickConversionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClickKeywordEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickKeywordEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Afcampaign", _afcampaign);
			toReturn.Add("AfmarketingMaterial", _afmarketingMaterial);
			toReturn.Add("ClickConversion", _clickConversion);
			toReturn.Add("ClickKeyword", _clickKeyword);
			toReturn.Add("CustomerProfileCollectionViaClickConversion", _customerProfileCollectionViaClickConversion);
			toReturn.Add("EventCustomersCollectionViaClickConversion", _eventCustomersCollectionViaClickConversion);
			toReturn.Add("ProspectCustomerCollectionViaClickConversion", _prospectCustomerCollectionViaClickConversion);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_clickConversion!=null)
			{
				_clickConversion.ActiveContext = base.ActiveContext;
			}
			if(_clickKeyword!=null)
			{
				_clickKeyword.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaClickConversion!=null)
			{
				_customerProfileCollectionViaClickConversion.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaClickConversion!=null)
			{
				_eventCustomersCollectionViaClickConversion.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaClickConversion!=null)
			{
				_prospectCustomerCollectionViaClickConversion.ActiveContext = base.ActiveContext;
			}
			if(_afcampaign!=null)
			{
				_afcampaign.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterial!=null)
			{
				_afmarketingMaterial.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_clickConversion = null;
			_clickKeyword = null;
			_customerProfileCollectionViaClickConversion = null;
			_eventCustomersCollectionViaClickConversion = null;
			_prospectCustomerCollectionViaClickConversion = null;
			_afcampaign = null;
			_afmarketingMaterial = null;

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

			_fieldsCustomProperties.Add("ClickId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingMaterialId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Timestamp", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IpAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PriorReferrer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Referrer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BrowserClient", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResolutionWidth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResolutionHeight", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Cookie", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afcampaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfcampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afcampaign, new PropertyChangedEventHandler( OnAfcampaignPropertyChanged ), "Afcampaign", ClickLogEntity.Relations.AfcampaignEntityUsingCampaignId, true, signalRelatedEntity, "ClickLog", resetFKFields, new int[] { (int)ClickLogFieldIndex.CampaignId } );		
			_afcampaign = null;
		}

		/// <summary> setups the sync logic for member _afcampaign</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfcampaign(IEntity2 relatedEntity)
		{
			if(_afcampaign!=relatedEntity)
			{
				DesetupSyncAfcampaign(true, true);
				_afcampaign = (AfcampaignEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afcampaign, new PropertyChangedEventHandler( OnAfcampaignPropertyChanged ), "Afcampaign", ClickLogEntity.Relations.AfcampaignEntityUsingCampaignId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfcampaignPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _afmarketingMaterial</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfmarketingMaterial(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afmarketingMaterial, new PropertyChangedEventHandler( OnAfmarketingMaterialPropertyChanged ), "AfmarketingMaterial", ClickLogEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, true, signalRelatedEntity, "ClickLog", resetFKFields, new int[] { (int)ClickLogFieldIndex.MarketingMaterialId } );		
			_afmarketingMaterial = null;
		}

		/// <summary> setups the sync logic for member _afmarketingMaterial</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfmarketingMaterial(IEntity2 relatedEntity)
		{
			if(_afmarketingMaterial!=relatedEntity)
			{
				DesetupSyncAfmarketingMaterial(true, true);
				_afmarketingMaterial = (AfmarketingMaterialEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afmarketingMaterial, new PropertyChangedEventHandler( OnAfmarketingMaterialPropertyChanged ), "AfmarketingMaterial", ClickLogEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfmarketingMaterialPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ClickLogEntity</param>
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
		public  static ClickLogRelations Relations
		{
			get	{ return new ClickLogRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClickConversion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClickConversion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClickConversionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickConversionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ClickConversion")[0], (int)Falcon.Data.EntityType.ClickLogEntity, (int)Falcon.Data.EntityType.ClickConversionEntity, 0, null, null, null, null, "ClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClickKeyword' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClickKeyword
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClickKeywordEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickKeywordEntityFactory))),
					(IEntityRelation)GetRelationsForField("ClickKeyword")[0], (int)Falcon.Data.EntityType.ClickLogEntity, (int)Falcon.Data.EntityType.ClickKeywordEntity, 0, null, null, null, null, "ClickKeyword", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaClickConversion
		{
			get
			{
				IEntityRelation intermediateRelation = ClickLogEntity.Relations.ClickConversionEntityUsingClickId;
				intermediateRelation.SetAliases(string.Empty, "ClickConversion_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ClickLogEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaClickConversion"), null, "CustomerProfileCollectionViaClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaClickConversion
		{
			get
			{
				IEntityRelation intermediateRelation = ClickLogEntity.Relations.ClickConversionEntityUsingClickId;
				intermediateRelation.SetAliases(string.Empty, "ClickConversion_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ClickLogEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaClickConversion"), null, "EventCustomersCollectionViaClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaClickConversion
		{
			get
			{
				IEntityRelation intermediateRelation = ClickLogEntity.Relations.ClickConversionEntityUsingClickId;
				intermediateRelation.SetAliases(string.Empty, "ClickConversion_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ClickLogEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaClickConversion"), null, "ProspectCustomerCollectionViaClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaign
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afcampaign")[0], (int)Falcon.Data.EntityType.ClickLogEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, null, null, "Afcampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfmarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfmarketingMaterial
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfmarketingMaterial")[0], (int)Falcon.Data.EntityType.ClickLogEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, 0, null, null, null, null, "AfmarketingMaterial", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ClickLogEntity.CustomProperties;}
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
			get { return ClickLogEntity.FieldsCustomProperties;}
		}

		/// <summary> The ClickId property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."ClickID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ClickId
		{
			get { return (System.Int64)GetValue((int)ClickLogFieldIndex.ClickId, true); }
			set	{ SetValue((int)ClickLogFieldIndex.ClickId, value); }
		}

		/// <summary> The CampaignId property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."CampaignID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CampaignId
		{
			get { return (System.Int64)GetValue((int)ClickLogFieldIndex.CampaignId, true); }
			set	{ SetValue((int)ClickLogFieldIndex.CampaignId, value); }
		}

		/// <summary> The MarketingMaterialId property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."MarketingMaterialID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MarketingMaterialId
		{
			get { return (System.Int64)GetValue((int)ClickLogFieldIndex.MarketingMaterialId, true); }
			set	{ SetValue((int)ClickLogFieldIndex.MarketingMaterialId, value); }
		}

		/// <summary> The Timestamp property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."Timestamp"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime Timestamp
		{
			get { return (System.DateTime)GetValue((int)ClickLogFieldIndex.Timestamp, true); }
			set	{ SetValue((int)ClickLogFieldIndex.Timestamp, value); }
		}

		/// <summary> The IpAddress property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."IpAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IpAddress
		{
			get { return (System.String)GetValue((int)ClickLogFieldIndex.IpAddress, true); }
			set	{ SetValue((int)ClickLogFieldIndex.IpAddress, value); }
		}

		/// <summary> The PriorReferrer property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."PriorReferrer"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PriorReferrer
		{
			get { return (System.String)GetValue((int)ClickLogFieldIndex.PriorReferrer, true); }
			set	{ SetValue((int)ClickLogFieldIndex.PriorReferrer, value); }
		}

		/// <summary> The Referrer property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."Referrer"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Referrer
		{
			get { return (System.String)GetValue((int)ClickLogFieldIndex.Referrer, true); }
			set	{ SetValue((int)ClickLogFieldIndex.Referrer, value); }
		}

		/// <summary> The BrowserClient property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."BrowserClient"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BrowserClient
		{
			get { return (System.String)GetValue((int)ClickLogFieldIndex.BrowserClient, true); }
			set	{ SetValue((int)ClickLogFieldIndex.BrowserClient, value); }
		}

		/// <summary> The ResolutionWidth property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."ResolutionWidth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ResolutionWidth
		{
			get { return (Nullable<System.Int32>)GetValue((int)ClickLogFieldIndex.ResolutionWidth, false); }
			set	{ SetValue((int)ClickLogFieldIndex.ResolutionWidth, value); }
		}

		/// <summary> The ResolutionHeight property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."ResolutionHeight"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ResolutionHeight
		{
			get { return (Nullable<System.Int32>)GetValue((int)ClickLogFieldIndex.ResolutionHeight, false); }
			set	{ SetValue((int)ClickLogFieldIndex.ResolutionHeight, value); }
		}

		/// <summary> The Cookie property of the Entity ClickLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblClickLog"."Cookie"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Cookie
		{
			get { return (System.String)GetValue((int)ClickLogFieldIndex.Cookie, true); }
			set	{ SetValue((int)ClickLogFieldIndex.Cookie, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClickConversionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClickConversionEntity))]
		public virtual EntityCollection<ClickConversionEntity> ClickConversion
		{
			get
			{
				if(_clickConversion==null)
				{
					_clickConversion = new EntityCollection<ClickConversionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickConversionEntityFactory)));
					_clickConversion.SetContainingEntityInfo(this, "ClickLog");
				}
				return _clickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClickKeywordEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClickKeywordEntity))]
		public virtual EntityCollection<ClickKeywordEntity> ClickKeyword
		{
			get
			{
				if(_clickKeyword==null)
				{
					_clickKeyword = new EntityCollection<ClickKeywordEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickKeywordEntityFactory)));
					_clickKeyword.SetContainingEntityInfo(this, "ClickLog");
				}
				return _clickKeyword;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaClickConversion
		{
			get
			{
				if(_customerProfileCollectionViaClickConversion==null)
				{
					_customerProfileCollectionViaClickConversion = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaClickConversion.IsReadOnly=true;
				}
				return _customerProfileCollectionViaClickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaClickConversion
		{
			get
			{
				if(_eventCustomersCollectionViaClickConversion==null)
				{
					_eventCustomersCollectionViaClickConversion = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaClickConversion.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaClickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerEntity))]
		public virtual EntityCollection<ProspectCustomerEntity> ProspectCustomerCollectionViaClickConversion
		{
			get
			{
				if(_prospectCustomerCollectionViaClickConversion==null)
				{
					_prospectCustomerCollectionViaClickConversion = new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory)));
					_prospectCustomerCollectionViaClickConversion.IsReadOnly=true;
				}
				return _prospectCustomerCollectionViaClickConversion;
			}
		}

		/// <summary> Gets / sets related entity of type 'AfcampaignEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfcampaignEntity Afcampaign
		{
			get
			{
				return _afcampaign;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfcampaign(value);
				}
				else
				{
					if(value==null)
					{
						if(_afcampaign != null)
						{
							_afcampaign.UnsetRelatedEntity(this, "ClickLog");
						}
					}
					else
					{
						if(_afcampaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ClickLog");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AfmarketingMaterialEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfmarketingMaterialEntity AfmarketingMaterial
		{
			get
			{
				return _afmarketingMaterial;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfmarketingMaterial(value);
				}
				else
				{
					if(value==null)
					{
						if(_afmarketingMaterial != null)
						{
							_afmarketingMaterial.UnsetRelatedEntity(this, "ClickLog");
						}
					}
					else
					{
						if(_afmarketingMaterial!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ClickLog");
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
			get { return (int)Falcon.Data.EntityType.ClickLogEntity; }
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
