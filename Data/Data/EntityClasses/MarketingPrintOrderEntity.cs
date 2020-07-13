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
	/// Entity class which represents the entity 'MarketingPrintOrder'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MarketingPrintOrderEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MarketingPrintOrderEventMappingEntity> _marketingPrintOrderEventMapping;
		private EntityCollection<MarketingPrintOrderItemEntity> _marketingPrintOrderItem;
		private EntityCollection<AfmarketingMaterialEntity> _afmarketingMaterialCollectionViaMarketingPrintOrderItem;
		private EntityCollection<CouponsEntity> _couponsCollectionViaMarketingPrintOrderItem;
		private EntityCollection<EventsEntity> _eventsCollectionViaMarketingPrintOrderEventMapping;
		private EntityCollection<LookupEntity> _lookupCollectionViaMarketingPrintOrderItem;
		private EntityCollection<MarketingOrderShippingInfoEntity> _marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem;
		private OrganizationEntity _organization_;
		private OrganizationEntity _organization;
		private OrganizationRoleUserEntity _organizationRoleUser;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Organization_</summary>
			public static readonly string Organization_ = "Organization_";
			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name MarketingPrintOrderEventMapping</summary>
			public static readonly string MarketingPrintOrderEventMapping = "MarketingPrintOrderEventMapping";
			/// <summary>Member name MarketingPrintOrderItem</summary>
			public static readonly string MarketingPrintOrderItem = "MarketingPrintOrderItem";
			/// <summary>Member name AfmarketingMaterialCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string AfmarketingMaterialCollectionViaMarketingPrintOrderItem = "AfmarketingMaterialCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name CouponsCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string CouponsCollectionViaMarketingPrintOrderItem = "CouponsCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name EventsCollectionViaMarketingPrintOrderEventMapping</summary>
			public static readonly string EventsCollectionViaMarketingPrintOrderEventMapping = "EventsCollectionViaMarketingPrintOrderEventMapping";
			/// <summary>Member name LookupCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string LookupCollectionViaMarketingPrintOrderItem = "LookupCollectionViaMarketingPrintOrderItem";
			/// <summary>Member name MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem</summary>
			public static readonly string MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MarketingPrintOrderEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MarketingPrintOrderEntity():base("MarketingPrintOrderEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MarketingPrintOrderEntity(IEntityFields2 fields):base("MarketingPrintOrderEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MarketingPrintOrderEntity</param>
		public MarketingPrintOrderEntity(IValidator validator):base("MarketingPrintOrderEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="marketingPrintOrderId">PK value for MarketingPrintOrder which data should be fetched into this MarketingPrintOrder object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MarketingPrintOrderEntity(System.Int64 marketingPrintOrderId):base("MarketingPrintOrderEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MarketingPrintOrderId = marketingPrintOrderId;
		}

		/// <summary> CTor</summary>
		/// <param name="marketingPrintOrderId">PK value for MarketingPrintOrder which data should be fetched into this MarketingPrintOrder object</param>
		/// <param name="validator">The custom validator object for this MarketingPrintOrderEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MarketingPrintOrderEntity(System.Int64 marketingPrintOrderId, IValidator validator):base("MarketingPrintOrderEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MarketingPrintOrderId = marketingPrintOrderId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MarketingPrintOrderEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_marketingPrintOrderEventMapping = (EntityCollection<MarketingPrintOrderEventMappingEntity>)info.GetValue("_marketingPrintOrderEventMapping", typeof(EntityCollection<MarketingPrintOrderEventMappingEntity>));
				_marketingPrintOrderItem = (EntityCollection<MarketingPrintOrderItemEntity>)info.GetValue("_marketingPrintOrderItem", typeof(EntityCollection<MarketingPrintOrderItemEntity>));
				_afmarketingMaterialCollectionViaMarketingPrintOrderItem = (EntityCollection<AfmarketingMaterialEntity>)info.GetValue("_afmarketingMaterialCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<AfmarketingMaterialEntity>));
				_couponsCollectionViaMarketingPrintOrderItem = (EntityCollection<CouponsEntity>)info.GetValue("_couponsCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<CouponsEntity>));
				_eventsCollectionViaMarketingPrintOrderEventMapping = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaMarketingPrintOrderEventMapping", typeof(EntityCollection<EventsEntity>));
				_lookupCollectionViaMarketingPrintOrderItem = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<LookupEntity>));
				_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingOrderShippingInfoEntity>)info.GetValue("_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", typeof(EntityCollection<MarketingOrderShippingInfoEntity>));
				_organization_ = (OrganizationEntity)info.GetValue("_organization_", typeof(OrganizationEntity));
				if(_organization_!=null)
				{
					_organization_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organization = (OrganizationEntity)info.GetValue("_organization", typeof(OrganizationEntity));
				if(_organization!=null)
				{
					_organization.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MarketingPrintOrderFieldIndex)fieldIndex)
			{
				case MarketingPrintOrderFieldIndex.FranchiseeOrganizationId:
					DesetupSyncOrganization(true, false);
					break;
				case MarketingPrintOrderFieldIndex.PrintVendorOrganizationId:
					DesetupSyncOrganization_(true, false);
					break;
				case MarketingPrintOrderFieldIndex.OrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
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
				case "Organization_":
					this.Organization_ = (OrganizationEntity)entity;
					break;
				case "Organization":
					this.Organization = (OrganizationEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "MarketingPrintOrderEventMapping":
					this.MarketingPrintOrderEventMapping.Add((MarketingPrintOrderEventMappingEntity)entity);
					break;
				case "MarketingPrintOrderItem":
					this.MarketingPrintOrderItem.Add((MarketingPrintOrderItemEntity)entity);
					break;
				case "AfmarketingMaterialCollectionViaMarketingPrintOrderItem":
					this.AfmarketingMaterialCollectionViaMarketingPrintOrderItem.IsReadOnly = false;
					this.AfmarketingMaterialCollectionViaMarketingPrintOrderItem.Add((AfmarketingMaterialEntity)entity);
					this.AfmarketingMaterialCollectionViaMarketingPrintOrderItem.IsReadOnly = true;
					break;
				case "CouponsCollectionViaMarketingPrintOrderItem":
					this.CouponsCollectionViaMarketingPrintOrderItem.IsReadOnly = false;
					this.CouponsCollectionViaMarketingPrintOrderItem.Add((CouponsEntity)entity);
					this.CouponsCollectionViaMarketingPrintOrderItem.IsReadOnly = true;
					break;
				case "EventsCollectionViaMarketingPrintOrderEventMapping":
					this.EventsCollectionViaMarketingPrintOrderEventMapping.IsReadOnly = false;
					this.EventsCollectionViaMarketingPrintOrderEventMapping.Add((EventsEntity)entity);
					this.EventsCollectionViaMarketingPrintOrderEventMapping.IsReadOnly = true;
					break;
				case "LookupCollectionViaMarketingPrintOrderItem":
					this.LookupCollectionViaMarketingPrintOrderItem.IsReadOnly = false;
					this.LookupCollectionViaMarketingPrintOrderItem.Add((LookupEntity)entity);
					this.LookupCollectionViaMarketingPrintOrderItem.IsReadOnly = true;
					break;
				case "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem":
					this.MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.IsReadOnly = false;
					this.MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.Add((MarketingOrderShippingInfoEntity)entity);
					this.MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.IsReadOnly = true;
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
			return MarketingPrintOrderEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Organization_":
					toReturn.Add(MarketingPrintOrderEntity.Relations.OrganizationEntityUsingPrintVendorOrganizationId);
					break;
				case "Organization":
					toReturn.Add(MarketingPrintOrderEntity.Relations.OrganizationEntityUsingFranchiseeOrganizationId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(MarketingPrintOrderEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId);
					break;
				case "MarketingPrintOrderEventMapping":
					toReturn.Add(MarketingPrintOrderEntity.Relations.MarketingPrintOrderEventMappingEntityUsingMarketingPrintOrderId);
					break;
				case "MarketingPrintOrderItem":
					toReturn.Add(MarketingPrintOrderEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId);
					break;
				case "AfmarketingMaterialCollectionViaMarketingPrintOrderItem":
					toReturn.Add(MarketingPrintOrderEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId, "MarketingPrintOrderEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "CouponsCollectionViaMarketingPrintOrderItem":
					toReturn.Add(MarketingPrintOrderEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId, "MarketingPrintOrderEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.CouponsEntityUsingSourceCodeId, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaMarketingPrintOrderEventMapping":
					toReturn.Add(MarketingPrintOrderEntity.Relations.MarketingPrintOrderEventMappingEntityUsingMarketingPrintOrderId, "MarketingPrintOrderEntity__", "MarketingPrintOrderEventMapping_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderEventMappingEntity.Relations.EventsEntityUsingEventId, "MarketingPrintOrderEventMapping_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaMarketingPrintOrderItem":
					toReturn.Add(MarketingPrintOrderEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId, "MarketingPrintOrderEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.LookupEntityUsingStatus, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
					break;
				case "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem":
					toReturn.Add(MarketingPrintOrderEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId, "MarketingPrintOrderEntity__", "MarketingPrintOrderItem_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.MarketingOrderShippingInfoEntityUsingMarketingOrderShippingInfoId, "MarketingPrintOrderItem_", string.Empty, JoinHint.None);
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
				case "Organization_":
					SetupSyncOrganization_(relatedEntity);
					break;
				case "Organization":
					SetupSyncOrganization(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "MarketingPrintOrderEventMapping":
					this.MarketingPrintOrderEventMapping.Add((MarketingPrintOrderEventMappingEntity)relatedEntity);
					break;
				case "MarketingPrintOrderItem":
					this.MarketingPrintOrderItem.Add((MarketingPrintOrderItemEntity)relatedEntity);
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
				case "Organization_":
					DesetupSyncOrganization_(false, true);
					break;
				case "Organization":
					DesetupSyncOrganization(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "MarketingPrintOrderEventMapping":
					base.PerformRelatedEntityRemoval(this.MarketingPrintOrderEventMapping, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MarketingPrintOrderItem":
					base.PerformRelatedEntityRemoval(this.MarketingPrintOrderItem, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organization_!=null)
			{
				toReturn.Add(_organization_);
			}
			if(_organization!=null)
			{
				toReturn.Add(_organization);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.MarketingPrintOrderEventMapping);
			toReturn.Add(this.MarketingPrintOrderItem);

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
				info.AddValue("_marketingPrintOrderEventMapping", ((_marketingPrintOrderEventMapping!=null) && (_marketingPrintOrderEventMapping.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrderEventMapping:null);
				info.AddValue("_marketingPrintOrderItem", ((_marketingPrintOrderItem!=null) && (_marketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrderItem:null);
				info.AddValue("_afmarketingMaterialCollectionViaMarketingPrintOrderItem", ((_afmarketingMaterialCollectionViaMarketingPrintOrderItem!=null) && (_afmarketingMaterialCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_afmarketingMaterialCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_couponsCollectionViaMarketingPrintOrderItem", ((_couponsCollectionViaMarketingPrintOrderItem!=null) && (_couponsCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_couponsCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_eventsCollectionViaMarketingPrintOrderEventMapping", ((_eventsCollectionViaMarketingPrintOrderEventMapping!=null) && (_eventsCollectionViaMarketingPrintOrderEventMapping.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaMarketingPrintOrderEventMapping:null);
				info.AddValue("_lookupCollectionViaMarketingPrintOrderItem", ((_lookupCollectionViaMarketingPrintOrderItem!=null) && (_lookupCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", ((_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem!=null) && (_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.Count>0) && !this.MarkedForDeletion)?_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem:null);
				info.AddValue("_organization_", (!this.MarkedForDeletion?_organization_:null));
				info.AddValue("_organization", (!this.MarkedForDeletion?_organization:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MarketingPrintOrderFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MarketingPrintOrderFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MarketingPrintOrderRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrderEventMapping' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrderEventMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderEventMappingFields.MarketingPrintOrderId, null, ComparisonOperator.Equal, this.MarketingPrintOrderId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderItemFields.MarketingPrintOrderId, null, ComparisonOperator.Equal, this.MarketingPrintOrderId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfmarketingMaterial' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfmarketingMaterialCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfmarketingMaterialCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderFields.MarketingPrintOrderId, null, ComparisonOperator.Equal, this.MarketingPrintOrderId, "MarketingPrintOrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponsCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CouponsCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderFields.MarketingPrintOrderId, null, ComparisonOperator.Equal, this.MarketingPrintOrderId, "MarketingPrintOrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaMarketingPrintOrderEventMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaMarketingPrintOrderEventMapping"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderFields.MarketingPrintOrderId, null, ComparisonOperator.Equal, this.MarketingPrintOrderId, "MarketingPrintOrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderFields.MarketingPrintOrderId, null, ComparisonOperator.Equal, this.MarketingPrintOrderId, "MarketingPrintOrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingOrderShippingInfo' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderFields.MarketingPrintOrderId, null, ComparisonOperator.Equal, this.MarketingPrintOrderId, "MarketingPrintOrderEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Organization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.PrintVendorOrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Organization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.FranchiseeOrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.OrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MarketingPrintOrderEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._marketingPrintOrderEventMapping);
			collectionsQueue.Enqueue(this._marketingPrintOrderItem);
			collectionsQueue.Enqueue(this._afmarketingMaterialCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._couponsCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._eventsCollectionViaMarketingPrintOrderEventMapping);
			collectionsQueue.Enqueue(this._lookupCollectionViaMarketingPrintOrderItem);
			collectionsQueue.Enqueue(this._marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._marketingPrintOrderEventMapping = (EntityCollection<MarketingPrintOrderEventMappingEntity>) collectionsQueue.Dequeue();
			this._marketingPrintOrderItem = (EntityCollection<MarketingPrintOrderItemEntity>) collectionsQueue.Dequeue();
			this._afmarketingMaterialCollectionViaMarketingPrintOrderItem = (EntityCollection<AfmarketingMaterialEntity>) collectionsQueue.Dequeue();
			this._couponsCollectionViaMarketingPrintOrderItem = (EntityCollection<CouponsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaMarketingPrintOrderEventMapping = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaMarketingPrintOrderItem = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = (EntityCollection<MarketingOrderShippingInfoEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._marketingPrintOrderEventMapping != null)
			{
				return true;
			}
			if (this._marketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._afmarketingMaterialCollectionViaMarketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._couponsCollectionViaMarketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._eventsCollectionViaMarketingPrintOrderEventMapping != null)
			{
				return true;
			}
			if (this._lookupCollectionViaMarketingPrintOrderItem != null)
			{
				return true;
			}
			if (this._marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderEventMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEventMappingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingOrderShippingInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingOrderShippingInfoEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Organization_", _organization_);
			toReturn.Add("Organization", _organization);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("MarketingPrintOrderEventMapping", _marketingPrintOrderEventMapping);
			toReturn.Add("MarketingPrintOrderItem", _marketingPrintOrderItem);
			toReturn.Add("AfmarketingMaterialCollectionViaMarketingPrintOrderItem", _afmarketingMaterialCollectionViaMarketingPrintOrderItem);
			toReturn.Add("CouponsCollectionViaMarketingPrintOrderItem", _couponsCollectionViaMarketingPrintOrderItem);
			toReturn.Add("EventsCollectionViaMarketingPrintOrderEventMapping", _eventsCollectionViaMarketingPrintOrderEventMapping);
			toReturn.Add("LookupCollectionViaMarketingPrintOrderItem", _lookupCollectionViaMarketingPrintOrderItem);
			toReturn.Add("MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", _marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_marketingPrintOrderEventMapping!=null)
			{
				_marketingPrintOrderEventMapping.ActiveContext = base.ActiveContext;
			}
			if(_marketingPrintOrderItem!=null)
			{
				_marketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterialCollectionViaMarketingPrintOrderItem!=null)
			{
				_afmarketingMaterialCollectionViaMarketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_couponsCollectionViaMarketingPrintOrderItem!=null)
			{
				_couponsCollectionViaMarketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaMarketingPrintOrderEventMapping!=null)
			{
				_eventsCollectionViaMarketingPrintOrderEventMapping.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaMarketingPrintOrderItem!=null)
			{
				_lookupCollectionViaMarketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem!=null)
			{
				_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_organization_!=null)
			{
				_organization_.ActiveContext = base.ActiveContext;
			}
			if(_organization!=null)
			{
				_organization.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_marketingPrintOrderEventMapping = null;
			_marketingPrintOrderItem = null;
			_afmarketingMaterialCollectionViaMarketingPrintOrderItem = null;
			_couponsCollectionViaMarketingPrintOrderItem = null;
			_eventsCollectionViaMarketingPrintOrderEventMapping = null;
			_lookupCollectionViaMarketingPrintOrderItem = null;
			_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = null;
			_organization_ = null;
			_organization = null;
			_organizationRoleUser = null;

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

			_fieldsCustomProperties.Add("MarketingPrintOrderId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrderDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DatePlaced", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateAssigned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FranchiseeOrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintVendorOrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organization_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganization_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organization_, new PropertyChangedEventHandler( OnOrganization_PropertyChanged ), "Organization_", MarketingPrintOrderEntity.Relations.OrganizationEntityUsingPrintVendorOrganizationId, true, signalRelatedEntity, "MarketingPrintOrder_", resetFKFields, new int[] { (int)MarketingPrintOrderFieldIndex.PrintVendorOrganizationId } );		
			_organization_ = null;
		}

		/// <summary> setups the sync logic for member _organization_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganization_(IEntity2 relatedEntity)
		{
			if(_organization_!=relatedEntity)
			{
				DesetupSyncOrganization_(true, true);
				_organization_ = (OrganizationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organization_, new PropertyChangedEventHandler( OnOrganization_PropertyChanged ), "Organization_", MarketingPrintOrderEntity.Relations.OrganizationEntityUsingPrintVendorOrganizationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganization_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", MarketingPrintOrderEntity.Relations.OrganizationEntityUsingFranchiseeOrganizationId, true, signalRelatedEntity, "MarketingPrintOrder", resetFKFields, new int[] { (int)MarketingPrintOrderFieldIndex.FranchiseeOrganizationId } );		
			_organization = null;
		}

		/// <summary> setups the sync logic for member _organization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganization(IEntity2 relatedEntity)
		{
			if(_organization!=relatedEntity)
			{
				DesetupSyncOrganization(true, true);
				_organization = (OrganizationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", MarketingPrintOrderEntity.Relations.OrganizationEntityUsingFranchiseeOrganizationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", MarketingPrintOrderEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, true, signalRelatedEntity, "MarketingPrintOrder", resetFKFields, new int[] { (int)MarketingPrintOrderFieldIndex.OrgRoleUserId } );		
			_organizationRoleUser = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser(true, true);
				_organizationRoleUser = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", MarketingPrintOrderEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MarketingPrintOrderEntity</param>
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
		public  static MarketingPrintOrderRelations Relations
		{
			get	{ return new MarketingPrintOrderRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrderEventMapping' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrderEventMapping
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MarketingPrintOrderEventMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEventMappingEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingPrintOrderEventMapping")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderEventMappingEntity, 0, null, null, null, null, "MarketingPrintOrderEventMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingPrintOrderItem")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, 0, null, null, null, null, "MarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfmarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfmarketingMaterialCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingPrintOrderEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, 0, null, null, GetRelationsForField("AfmarketingMaterialCollectionViaMarketingPrintOrderItem"), null, "AfmarketingMaterialCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponsCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingPrintOrderEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.CouponsEntity, 0, null, null, GetRelationsForField("CouponsCollectionViaMarketingPrintOrderItem"), null, "CouponsCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaMarketingPrintOrderEventMapping
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingPrintOrderEntity.Relations.MarketingPrintOrderEventMappingEntityUsingMarketingPrintOrderId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderEventMapping_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaMarketingPrintOrderEventMapping"), null, "EventsCollectionViaMarketingPrintOrderEventMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingPrintOrderEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaMarketingPrintOrderItem"), null, "LookupCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingOrderShippingInfo' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingPrintOrderEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<MarketingOrderShippingInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingOrderShippingInfoEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.MarketingOrderShippingInfoEntity, 0, null, null, GetRelationsForField("MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem"), null, "MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization_")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MarketingPrintOrderEntity.CustomProperties;}
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
			get { return MarketingPrintOrderEntity.FieldsCustomProperties;}
		}

		/// <summary> The MarketingPrintOrderId property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."MarketingPrintOrderID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MarketingPrintOrderId
		{
			get { return (System.Int64)GetValue((int)MarketingPrintOrderFieldIndex.MarketingPrintOrderId, true); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.MarketingPrintOrderId, value); }
		}

		/// <summary> The OrderDate property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."OrderDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> OrderDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MarketingPrintOrderFieldIndex.OrderDate, false); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.OrderDate, value); }
		}

		/// <summary> The Status property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Status
		{
			get { return (System.String)GetValue((int)MarketingPrintOrderFieldIndex.Status, true); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.Status, value); }
		}

		/// <summary> The IsActive property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)MarketingPrintOrderFieldIndex.IsActive, true); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MarketingPrintOrderFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MarketingPrintOrderFieldIndex.DateModified, true); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.DateModified, value); }
		}

		/// <summary> The DatePlaced property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."DatePlaced"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DatePlaced
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MarketingPrintOrderFieldIndex.DatePlaced, false); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.DatePlaced, value); }
		}

		/// <summary> The DateAssigned property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."DateAssigned"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateAssigned
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MarketingPrintOrderFieldIndex.DateAssigned, false); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.DateAssigned, value); }
		}

		/// <summary> The FranchiseeOrganizationId property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."FranchiseeOrganizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> FranchiseeOrganizationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MarketingPrintOrderFieldIndex.FranchiseeOrganizationId, false); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.FranchiseeOrganizationId, value); }
		}

		/// <summary> The PrintVendorOrganizationId property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."PrintVendorOrganizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PrintVendorOrganizationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MarketingPrintOrderFieldIndex.PrintVendorOrganizationId, false); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.PrintVendorOrganizationId, value); }
		}

		/// <summary> The OrgRoleUserId property of the Entity MarketingPrintOrder<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrder"."OrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)MarketingPrintOrderFieldIndex.OrgRoleUserId, true); }
			set	{ SetValue((int)MarketingPrintOrderFieldIndex.OrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingPrintOrderEventMappingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingPrintOrderEventMappingEntity))]
		public virtual EntityCollection<MarketingPrintOrderEventMappingEntity> MarketingPrintOrderEventMapping
		{
			get
			{
				if(_marketingPrintOrderEventMapping==null)
				{
					_marketingPrintOrderEventMapping = new EntityCollection<MarketingPrintOrderEventMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEventMappingEntityFactory)));
					_marketingPrintOrderEventMapping.SetContainingEntityInfo(this, "MarketingPrintOrder");
				}
				return _marketingPrintOrderEventMapping;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingPrintOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingPrintOrderItemEntity))]
		public virtual EntityCollection<MarketingPrintOrderItemEntity> MarketingPrintOrderItem
		{
			get
			{
				if(_marketingPrintOrderItem==null)
				{
					_marketingPrintOrderItem = new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory)));
					_marketingPrintOrderItem.SetContainingEntityInfo(this, "MarketingPrintOrder");
				}
				return _marketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfmarketingMaterialEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfmarketingMaterialEntity))]
		public virtual EntityCollection<AfmarketingMaterialEntity> AfmarketingMaterialCollectionViaMarketingPrintOrderItem
		{
			get
			{
				if(_afmarketingMaterialCollectionViaMarketingPrintOrderItem==null)
				{
					_afmarketingMaterialCollectionViaMarketingPrintOrderItem = new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory)));
					_afmarketingMaterialCollectionViaMarketingPrintOrderItem.IsReadOnly=true;
				}
				return _afmarketingMaterialCollectionViaMarketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouponsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouponsEntity))]
		public virtual EntityCollection<CouponsEntity> CouponsCollectionViaMarketingPrintOrderItem
		{
			get
			{
				if(_couponsCollectionViaMarketingPrintOrderItem==null)
				{
					_couponsCollectionViaMarketingPrintOrderItem = new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory)));
					_couponsCollectionViaMarketingPrintOrderItem.IsReadOnly=true;
				}
				return _couponsCollectionViaMarketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaMarketingPrintOrderEventMapping
		{
			get
			{
				if(_eventsCollectionViaMarketingPrintOrderEventMapping==null)
				{
					_eventsCollectionViaMarketingPrintOrderEventMapping = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaMarketingPrintOrderEventMapping.IsReadOnly=true;
				}
				return _eventsCollectionViaMarketingPrintOrderEventMapping;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaMarketingPrintOrderItem
		{
			get
			{
				if(_lookupCollectionViaMarketingPrintOrderItem==null)
				{
					_lookupCollectionViaMarketingPrintOrderItem = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaMarketingPrintOrderItem.IsReadOnly=true;
				}
				return _lookupCollectionViaMarketingPrintOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingOrderShippingInfoEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingOrderShippingInfoEntity))]
		public virtual EntityCollection<MarketingOrderShippingInfoEntity> MarketingOrderShippingInfoCollectionViaMarketingPrintOrderItem
		{
			get
			{
				if(_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem==null)
				{
					_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem = new EntityCollection<MarketingOrderShippingInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingOrderShippingInfoEntityFactory)));
					_marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem.IsReadOnly=true;
				}
				return _marketingOrderShippingInfoCollectionViaMarketingPrintOrderItem;
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationEntity Organization_
		{
			get
			{
				return _organization_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganization_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organization_ != null)
						{
							_organization_.UnsetRelatedEntity(this, "MarketingPrintOrder_");
						}
					}
					else
					{
						if(_organization_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MarketingPrintOrder_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationEntity Organization
		{
			get
			{
				return _organization;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganization(value);
				}
				else
				{
					if(value==null)
					{
						if(_organization != null)
						{
							_organization.UnsetRelatedEntity(this, "MarketingPrintOrder");
						}
					}
					else
					{
						if(_organization!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MarketingPrintOrder");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser
		{
			get
			{
				return _organizationRoleUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser != null)
						{
							_organizationRoleUser.UnsetRelatedEntity(this, "MarketingPrintOrder");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MarketingPrintOrder");
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
			get { return (int)Falcon.Data.EntityType.MarketingPrintOrderEntity; }
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
