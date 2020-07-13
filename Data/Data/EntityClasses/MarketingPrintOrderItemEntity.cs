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
	/// Entity class which represents the entity 'MarketingPrintOrderItem'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MarketingPrintOrderItemEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MarketingPrintOrderProspectListMappingEntity> _marketingPrintOrderProspectListMapping;
		private EntityCollection<PrintOrderItemTrackingEntity> _printOrderItemTracking;
		private EntityCollection<LookupEntity> _lookupCollectionViaPrintOrderItemTracking_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPrintOrderItemTracking;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPrintOrderItemTracking_;
		private EntityCollection<ProspectListDetailsEntity> _prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping;
		private AfmarketingMaterialEntity _afmarketingMaterial;
		private CouponsEntity _coupons;
		private LookupEntity _lookup;
		private MarketingOrderShippingInfoEntity _marketingOrderShippingInfo;
		private MarketingPrintOrderEntity _marketingPrintOrder;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AfmarketingMaterial</summary>
			public static readonly string AfmarketingMaterial = "AfmarketingMaterial";
			/// <summary>Member name Coupons</summary>
			public static readonly string Coupons = "Coupons";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name MarketingOrderShippingInfo</summary>
			public static readonly string MarketingOrderShippingInfo = "MarketingOrderShippingInfo";
			/// <summary>Member name MarketingPrintOrder</summary>
			public static readonly string MarketingPrintOrder = "MarketingPrintOrder";
			/// <summary>Member name MarketingPrintOrderProspectListMapping</summary>
			public static readonly string MarketingPrintOrderProspectListMapping = "MarketingPrintOrderProspectListMapping";
			/// <summary>Member name PrintOrderItemTracking</summary>
			public static readonly string PrintOrderItemTracking = "PrintOrderItemTracking";
			/// <summary>Member name LookupCollectionViaPrintOrderItemTracking_</summary>
			public static readonly string LookupCollectionViaPrintOrderItemTracking_ = "LookupCollectionViaPrintOrderItemTracking_";
			/// <summary>Member name OrganizationRoleUserCollectionViaPrintOrderItemTracking</summary>
			public static readonly string OrganizationRoleUserCollectionViaPrintOrderItemTracking = "OrganizationRoleUserCollectionViaPrintOrderItemTracking";
			/// <summary>Member name OrganizationRoleUserCollectionViaPrintOrderItemTracking_</summary>
			public static readonly string OrganizationRoleUserCollectionViaPrintOrderItemTracking_ = "OrganizationRoleUserCollectionViaPrintOrderItemTracking_";
			/// <summary>Member name ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping</summary>
			public static readonly string ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping = "ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MarketingPrintOrderItemEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MarketingPrintOrderItemEntity():base("MarketingPrintOrderItemEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MarketingPrintOrderItemEntity(IEntityFields2 fields):base("MarketingPrintOrderItemEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MarketingPrintOrderItemEntity</param>
		public MarketingPrintOrderItemEntity(IValidator validator):base("MarketingPrintOrderItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="marketingPrintOrderItemId">PK value for MarketingPrintOrderItem which data should be fetched into this MarketingPrintOrderItem object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MarketingPrintOrderItemEntity(System.Int64 marketingPrintOrderItemId):base("MarketingPrintOrderItemEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MarketingPrintOrderItemId = marketingPrintOrderItemId;
		}

		/// <summary> CTor</summary>
		/// <param name="marketingPrintOrderItemId">PK value for MarketingPrintOrderItem which data should be fetched into this MarketingPrintOrderItem object</param>
		/// <param name="validator">The custom validator object for this MarketingPrintOrderItemEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MarketingPrintOrderItemEntity(System.Int64 marketingPrintOrderItemId, IValidator validator):base("MarketingPrintOrderItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MarketingPrintOrderItemId = marketingPrintOrderItemId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MarketingPrintOrderItemEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_marketingPrintOrderProspectListMapping = (EntityCollection<MarketingPrintOrderProspectListMappingEntity>)info.GetValue("_marketingPrintOrderProspectListMapping", typeof(EntityCollection<MarketingPrintOrderProspectListMappingEntity>));
				_printOrderItemTracking = (EntityCollection<PrintOrderItemTrackingEntity>)info.GetValue("_printOrderItemTracking", typeof(EntityCollection<PrintOrderItemTrackingEntity>));
				_lookupCollectionViaPrintOrderItemTracking_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPrintOrderItemTracking_", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaPrintOrderItemTracking = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPrintOrderItemTracking", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPrintOrderItemTracking_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPrintOrderItemTracking_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping = (EntityCollection<ProspectListDetailsEntity>)info.GetValue("_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping", typeof(EntityCollection<ProspectListDetailsEntity>));
				_afmarketingMaterial = (AfmarketingMaterialEntity)info.GetValue("_afmarketingMaterial", typeof(AfmarketingMaterialEntity));
				if(_afmarketingMaterial!=null)
				{
					_afmarketingMaterial.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_coupons = (CouponsEntity)info.GetValue("_coupons", typeof(CouponsEntity));
				if(_coupons!=null)
				{
					_coupons.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_marketingOrderShippingInfo = (MarketingOrderShippingInfoEntity)info.GetValue("_marketingOrderShippingInfo", typeof(MarketingOrderShippingInfoEntity));
				if(_marketingOrderShippingInfo!=null)
				{
					_marketingOrderShippingInfo.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_marketingPrintOrder = (MarketingPrintOrderEntity)info.GetValue("_marketingPrintOrder", typeof(MarketingPrintOrderEntity));
				if(_marketingPrintOrder!=null)
				{
					_marketingPrintOrder.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MarketingPrintOrderItemFieldIndex)fieldIndex)
			{
				case MarketingPrintOrderItemFieldIndex.MarketingPrintOrderId:
					DesetupSyncMarketingPrintOrder(true, false);
					break;
				case MarketingPrintOrderItemFieldIndex.MarketingMaterialId:
					DesetupSyncAfmarketingMaterial(true, false);
					break;
				case MarketingPrintOrderItemFieldIndex.MarketingOrderShippingInfoId:
					DesetupSyncMarketingOrderShippingInfo(true, false);
					break;
				case MarketingPrintOrderItemFieldIndex.SourceCodeId:
					DesetupSyncCoupons(true, false);
					break;
				case MarketingPrintOrderItemFieldIndex.Status:
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
				case "AfmarketingMaterial":
					this.AfmarketingMaterial = (AfmarketingMaterialEntity)entity;
					break;
				case "Coupons":
					this.Coupons = (CouponsEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "MarketingOrderShippingInfo":
					this.MarketingOrderShippingInfo = (MarketingOrderShippingInfoEntity)entity;
					break;
				case "MarketingPrintOrder":
					this.MarketingPrintOrder = (MarketingPrintOrderEntity)entity;
					break;
				case "MarketingPrintOrderProspectListMapping":
					this.MarketingPrintOrderProspectListMapping.Add((MarketingPrintOrderProspectListMappingEntity)entity);
					break;
				case "PrintOrderItemTracking":
					this.PrintOrderItemTracking.Add((PrintOrderItemTrackingEntity)entity);
					break;
				case "LookupCollectionViaPrintOrderItemTracking_":
					this.LookupCollectionViaPrintOrderItemTracking_.IsReadOnly = false;
					this.LookupCollectionViaPrintOrderItemTracking_.Add((LookupEntity)entity);
					this.LookupCollectionViaPrintOrderItemTracking_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPrintOrderItemTracking":
					this.OrganizationRoleUserCollectionViaPrintOrderItemTracking.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPrintOrderItemTracking.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPrintOrderItemTracking.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPrintOrderItemTracking_":
					this.OrganizationRoleUserCollectionViaPrintOrderItemTracking_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPrintOrderItemTracking_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPrintOrderItemTracking_.IsReadOnly = true;
					break;
				case "ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping":
					this.ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping.IsReadOnly = false;
					this.ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping.Add((ProspectListDetailsEntity)entity);
					this.ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping.IsReadOnly = true;
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
			return MarketingPrintOrderItemEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AfmarketingMaterial":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId);
					break;
				case "Coupons":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.CouponsEntityUsingSourceCodeId);
					break;
				case "Lookup":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.LookupEntityUsingStatus);
					break;
				case "MarketingOrderShippingInfo":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.MarketingOrderShippingInfoEntityUsingMarketingOrderShippingInfoId);
					break;
				case "MarketingPrintOrder":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.MarketingPrintOrderEntityUsingMarketingPrintOrderId);
					break;
				case "MarketingPrintOrderProspectListMapping":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.MarketingPrintOrderProspectListMappingEntityUsingMarketingPrintOrderItemId);
					break;
				case "PrintOrderItemTracking":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.PrintOrderItemTrackingEntityUsingPrintOrderItemId);
					break;
				case "LookupCollectionViaPrintOrderItemTracking_":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.PrintOrderItemTrackingEntityUsingPrintOrderItemId, "MarketingPrintOrderItemEntity__", "PrintOrderItemTracking_", JoinHint.None);
					toReturn.Add(PrintOrderItemTrackingEntity.Relations.LookupEntityUsingConfirmationMode, "PrintOrderItemTracking_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPrintOrderItemTracking":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.PrintOrderItemTrackingEntityUsingPrintOrderItemId, "MarketingPrintOrderItemEntity__", "PrintOrderItemTracking_", JoinHint.None);
					toReturn.Add(PrintOrderItemTrackingEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "PrintOrderItemTracking_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPrintOrderItemTracking_":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.PrintOrderItemTrackingEntityUsingPrintOrderItemId, "MarketingPrintOrderItemEntity__", "PrintOrderItemTracking_", JoinHint.None);
					toReturn.Add(PrintOrderItemTrackingEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId, "PrintOrderItemTracking_", string.Empty, JoinHint.None);
					break;
				case "ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping":
					toReturn.Add(MarketingPrintOrderItemEntity.Relations.MarketingPrintOrderProspectListMappingEntityUsingMarketingPrintOrderItemId, "MarketingPrintOrderItemEntity__", "MarketingPrintOrderProspectListMapping_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderProspectListMappingEntity.Relations.ProspectListDetailsEntityUsingProspectFileId, "MarketingPrintOrderProspectListMapping_", string.Empty, JoinHint.None);
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
				case "AfmarketingMaterial":
					SetupSyncAfmarketingMaterial(relatedEntity);
					break;
				case "Coupons":
					SetupSyncCoupons(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "MarketingOrderShippingInfo":
					SetupSyncMarketingOrderShippingInfo(relatedEntity);
					break;
				case "MarketingPrintOrder":
					SetupSyncMarketingPrintOrder(relatedEntity);
					break;
				case "MarketingPrintOrderProspectListMapping":
					this.MarketingPrintOrderProspectListMapping.Add((MarketingPrintOrderProspectListMappingEntity)relatedEntity);
					break;
				case "PrintOrderItemTracking":
					this.PrintOrderItemTracking.Add((PrintOrderItemTrackingEntity)relatedEntity);
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
				case "AfmarketingMaterial":
					DesetupSyncAfmarketingMaterial(false, true);
					break;
				case "Coupons":
					DesetupSyncCoupons(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "MarketingOrderShippingInfo":
					DesetupSyncMarketingOrderShippingInfo(false, true);
					break;
				case "MarketingPrintOrder":
					DesetupSyncMarketingPrintOrder(false, true);
					break;
				case "MarketingPrintOrderProspectListMapping":
					base.PerformRelatedEntityRemoval(this.MarketingPrintOrderProspectListMapping, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PrintOrderItemTracking":
					base.PerformRelatedEntityRemoval(this.PrintOrderItemTracking, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_afmarketingMaterial!=null)
			{
				toReturn.Add(_afmarketingMaterial);
			}
			if(_coupons!=null)
			{
				toReturn.Add(_coupons);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_marketingOrderShippingInfo!=null)
			{
				toReturn.Add(_marketingOrderShippingInfo);
			}
			if(_marketingPrintOrder!=null)
			{
				toReturn.Add(_marketingPrintOrder);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.MarketingPrintOrderProspectListMapping);
			toReturn.Add(this.PrintOrderItemTracking);

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
				info.AddValue("_marketingPrintOrderProspectListMapping", ((_marketingPrintOrderProspectListMapping!=null) && (_marketingPrintOrderProspectListMapping.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrderProspectListMapping:null);
				info.AddValue("_printOrderItemTracking", ((_printOrderItemTracking!=null) && (_printOrderItemTracking.Count>0) && !this.MarkedForDeletion)?_printOrderItemTracking:null);
				info.AddValue("_lookupCollectionViaPrintOrderItemTracking_", ((_lookupCollectionViaPrintOrderItemTracking_!=null) && (_lookupCollectionViaPrintOrderItemTracking_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPrintOrderItemTracking_:null);
				info.AddValue("_organizationRoleUserCollectionViaPrintOrderItemTracking", ((_organizationRoleUserCollectionViaPrintOrderItemTracking!=null) && (_organizationRoleUserCollectionViaPrintOrderItemTracking.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPrintOrderItemTracking:null);
				info.AddValue("_organizationRoleUserCollectionViaPrintOrderItemTracking_", ((_organizationRoleUserCollectionViaPrintOrderItemTracking_!=null) && (_organizationRoleUserCollectionViaPrintOrderItemTracking_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPrintOrderItemTracking_:null);
				info.AddValue("_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping", ((_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping!=null) && (_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping.Count>0) && !this.MarkedForDeletion)?_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping:null);
				info.AddValue("_afmarketingMaterial", (!this.MarkedForDeletion?_afmarketingMaterial:null));
				info.AddValue("_coupons", (!this.MarkedForDeletion?_coupons:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_marketingOrderShippingInfo", (!this.MarkedForDeletion?_marketingOrderShippingInfo:null));
				info.AddValue("_marketingPrintOrder", (!this.MarkedForDeletion?_marketingPrintOrder:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MarketingPrintOrderItemFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MarketingPrintOrderItemFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MarketingPrintOrderItemRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrderProspectListMapping' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrderProspectListMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderProspectListMappingFields.MarketingPrintOrderItemId, null, ComparisonOperator.Equal, this.MarketingPrintOrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PrintOrderItemTracking' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPrintOrderItemTracking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PrintOrderItemTrackingFields.PrintOrderItemId, null, ComparisonOperator.Equal, this.MarketingPrintOrderItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPrintOrderItemTracking_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPrintOrderItemTracking_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderItemFields.MarketingPrintOrderItemId, null, ComparisonOperator.Equal, this.MarketingPrintOrderItemId, "MarketingPrintOrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPrintOrderItemTracking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPrintOrderItemTracking"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderItemFields.MarketingPrintOrderItemId, null, ComparisonOperator.Equal, this.MarketingPrintOrderItemId, "MarketingPrintOrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPrintOrderItemTracking_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPrintOrderItemTracking_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderItemFields.MarketingPrintOrderItemId, null, ComparisonOperator.Equal, this.MarketingPrintOrderItemId, "MarketingPrintOrderItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectListDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderItemFields.MarketingPrintOrderItemId, null, ComparisonOperator.Equal, this.MarketingPrintOrderItemId, "MarketingPrintOrderItemEntity__"));
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

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Coupons' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCoupons()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponsFields.CouponId, null, ComparisonOperator.Equal, this.SourceCodeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Status));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MarketingOrderShippingInfo' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingOrderShippingInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingOrderShippingInfoFields.MarketingOrderShippingInfoId, null, ComparisonOperator.Equal, this.MarketingOrderShippingInfoId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MarketingPrintOrder' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderFields.MarketingPrintOrderId, null, ComparisonOperator.Equal, this.MarketingPrintOrderId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MarketingPrintOrderItemEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._marketingPrintOrderProspectListMapping);
			collectionsQueue.Enqueue(this._printOrderItemTracking);
			collectionsQueue.Enqueue(this._lookupCollectionViaPrintOrderItemTracking_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPrintOrderItemTracking);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPrintOrderItemTracking_);
			collectionsQueue.Enqueue(this._prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._marketingPrintOrderProspectListMapping = (EntityCollection<MarketingPrintOrderProspectListMappingEntity>) collectionsQueue.Dequeue();
			this._printOrderItemTracking = (EntityCollection<PrintOrderItemTrackingEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPrintOrderItemTracking_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPrintOrderItemTracking = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPrintOrderItemTracking_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping = (EntityCollection<ProspectListDetailsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._marketingPrintOrderProspectListMapping != null)
			{
				return true;
			}
			if (this._printOrderItemTracking != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPrintOrderItemTracking_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPrintOrderItemTracking != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPrintOrderItemTracking_ != null)
			{
				return true;
			}
			if (this._prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderProspectListMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderProspectListMappingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PrintOrderItemTrackingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PrintOrderItemTrackingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AfmarketingMaterial", _afmarketingMaterial);
			toReturn.Add("Coupons", _coupons);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("MarketingOrderShippingInfo", _marketingOrderShippingInfo);
			toReturn.Add("MarketingPrintOrder", _marketingPrintOrder);
			toReturn.Add("MarketingPrintOrderProspectListMapping", _marketingPrintOrderProspectListMapping);
			toReturn.Add("PrintOrderItemTracking", _printOrderItemTracking);
			toReturn.Add("LookupCollectionViaPrintOrderItemTracking_", _lookupCollectionViaPrintOrderItemTracking_);
			toReturn.Add("OrganizationRoleUserCollectionViaPrintOrderItemTracking", _organizationRoleUserCollectionViaPrintOrderItemTracking);
			toReturn.Add("OrganizationRoleUserCollectionViaPrintOrderItemTracking_", _organizationRoleUserCollectionViaPrintOrderItemTracking_);
			toReturn.Add("ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping", _prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_marketingPrintOrderProspectListMapping!=null)
			{
				_marketingPrintOrderProspectListMapping.ActiveContext = base.ActiveContext;
			}
			if(_printOrderItemTracking!=null)
			{
				_printOrderItemTracking.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPrintOrderItemTracking_!=null)
			{
				_lookupCollectionViaPrintOrderItemTracking_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPrintOrderItemTracking!=null)
			{
				_organizationRoleUserCollectionViaPrintOrderItemTracking.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPrintOrderItemTracking_!=null)
			{
				_organizationRoleUserCollectionViaPrintOrderItemTracking_.ActiveContext = base.ActiveContext;
			}
			if(_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping!=null)
			{
				_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterial!=null)
			{
				_afmarketingMaterial.ActiveContext = base.ActiveContext;
			}
			if(_coupons!=null)
			{
				_coupons.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_marketingOrderShippingInfo!=null)
			{
				_marketingOrderShippingInfo.ActiveContext = base.ActiveContext;
			}
			if(_marketingPrintOrder!=null)
			{
				_marketingPrintOrder.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_marketingPrintOrderProspectListMapping = null;
			_printOrderItemTracking = null;
			_lookupCollectionViaPrintOrderItemTracking_ = null;
			_organizationRoleUserCollectionViaPrintOrderItemTracking = null;
			_organizationRoleUserCollectionViaPrintOrderItemTracking_ = null;
			_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping = null;
			_afmarketingMaterial = null;
			_coupons = null;
			_lookup = null;
			_marketingOrderShippingInfo = null;
			_marketingPrintOrder = null;

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

			_fieldsCustomProperties.Add("MarketingPrintOrderItemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingPrintOrderId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingMaterialId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sourcecode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Quantity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShippingMethod", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Logo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingOrderShippingInfoId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SourceCodeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afmarketingMaterial</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfmarketingMaterial(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afmarketingMaterial, new PropertyChangedEventHandler( OnAfmarketingMaterialPropertyChanged ), "AfmarketingMaterial", MarketingPrintOrderItemEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, true, signalRelatedEntity, "MarketingPrintOrderItem", resetFKFields, new int[] { (int)MarketingPrintOrderItemFieldIndex.MarketingMaterialId } );		
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
				base.PerformSetupSyncRelatedEntity( _afmarketingMaterial, new PropertyChangedEventHandler( OnAfmarketingMaterialPropertyChanged ), "AfmarketingMaterial", MarketingPrintOrderItemEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _coupons</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCoupons(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _coupons, new PropertyChangedEventHandler( OnCouponsPropertyChanged ), "Coupons", MarketingPrintOrderItemEntity.Relations.CouponsEntityUsingSourceCodeId, true, signalRelatedEntity, "MarketingPrintOrderItem", resetFKFields, new int[] { (int)MarketingPrintOrderItemFieldIndex.SourceCodeId } );		
			_coupons = null;
		}

		/// <summary> setups the sync logic for member _coupons</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCoupons(IEntity2 relatedEntity)
		{
			if(_coupons!=relatedEntity)
			{
				DesetupSyncCoupons(true, true);
				_coupons = (CouponsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _coupons, new PropertyChangedEventHandler( OnCouponsPropertyChanged ), "Coupons", MarketingPrintOrderItemEntity.Relations.CouponsEntityUsingSourceCodeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCouponsPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", MarketingPrintOrderItemEntity.Relations.LookupEntityUsingStatus, true, signalRelatedEntity, "MarketingPrintOrderItem", resetFKFields, new int[] { (int)MarketingPrintOrderItemFieldIndex.Status } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", MarketingPrintOrderItemEntity.Relations.LookupEntityUsingStatus, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _marketingOrderShippingInfo</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMarketingOrderShippingInfo(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _marketingOrderShippingInfo, new PropertyChangedEventHandler( OnMarketingOrderShippingInfoPropertyChanged ), "MarketingOrderShippingInfo", MarketingPrintOrderItemEntity.Relations.MarketingOrderShippingInfoEntityUsingMarketingOrderShippingInfoId, true, signalRelatedEntity, "MarketingPrintOrderItem", resetFKFields, new int[] { (int)MarketingPrintOrderItemFieldIndex.MarketingOrderShippingInfoId } );		
			_marketingOrderShippingInfo = null;
		}

		/// <summary> setups the sync logic for member _marketingOrderShippingInfo</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMarketingOrderShippingInfo(IEntity2 relatedEntity)
		{
			if(_marketingOrderShippingInfo!=relatedEntity)
			{
				DesetupSyncMarketingOrderShippingInfo(true, true);
				_marketingOrderShippingInfo = (MarketingOrderShippingInfoEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _marketingOrderShippingInfo, new PropertyChangedEventHandler( OnMarketingOrderShippingInfoPropertyChanged ), "MarketingOrderShippingInfo", MarketingPrintOrderItemEntity.Relations.MarketingOrderShippingInfoEntityUsingMarketingOrderShippingInfoId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMarketingOrderShippingInfoPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _marketingPrintOrder</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMarketingPrintOrder(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _marketingPrintOrder, new PropertyChangedEventHandler( OnMarketingPrintOrderPropertyChanged ), "MarketingPrintOrder", MarketingPrintOrderItemEntity.Relations.MarketingPrintOrderEntityUsingMarketingPrintOrderId, true, signalRelatedEntity, "MarketingPrintOrderItem", resetFKFields, new int[] { (int)MarketingPrintOrderItemFieldIndex.MarketingPrintOrderId } );		
			_marketingPrintOrder = null;
		}

		/// <summary> setups the sync logic for member _marketingPrintOrder</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMarketingPrintOrder(IEntity2 relatedEntity)
		{
			if(_marketingPrintOrder!=relatedEntity)
			{
				DesetupSyncMarketingPrintOrder(true, true);
				_marketingPrintOrder = (MarketingPrintOrderEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _marketingPrintOrder, new PropertyChangedEventHandler( OnMarketingPrintOrderPropertyChanged ), "MarketingPrintOrder", MarketingPrintOrderItemEntity.Relations.MarketingPrintOrderEntityUsingMarketingPrintOrderId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMarketingPrintOrderPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MarketingPrintOrderItemEntity</param>
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
		public  static MarketingPrintOrderItemRelations Relations
		{
			get	{ return new MarketingPrintOrderItemRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrderProspectListMapping' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrderProspectListMapping
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MarketingPrintOrderProspectListMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderProspectListMappingEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingPrintOrderProspectListMapping")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderProspectListMappingEntity, 0, null, null, null, null, "MarketingPrintOrderProspectListMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PrintOrderItemTracking' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPrintOrderItemTracking
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PrintOrderItemTrackingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PrintOrderItemTrackingEntityFactory))),
					(IEntityRelation)GetRelationsForField("PrintOrderItemTracking")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.PrintOrderItemTrackingEntity, 0, null, null, null, null, "PrintOrderItemTracking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPrintOrderItemTracking_
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingPrintOrderItemEntity.Relations.PrintOrderItemTrackingEntityUsingPrintOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "PrintOrderItemTracking_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPrintOrderItemTracking_"), null, "LookupCollectionViaPrintOrderItemTracking_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPrintOrderItemTracking
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingPrintOrderItemEntity.Relations.PrintOrderItemTrackingEntityUsingPrintOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "PrintOrderItemTracking_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPrintOrderItemTracking"), null, "OrganizationRoleUserCollectionViaPrintOrderItemTracking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPrintOrderItemTracking_
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingPrintOrderItemEntity.Relations.PrintOrderItemTrackingEntityUsingPrintOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "PrintOrderItemTracking_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPrintOrderItemTracking_"), null, "OrganizationRoleUserCollectionViaPrintOrderItemTracking_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectListDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingPrintOrderItemEntity.Relations.MarketingPrintOrderProspectListMappingEntityUsingMarketingPrintOrderItemId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderProspectListMapping_");
				return new PrefetchPathElement2(new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.ProspectListDetailsEntity, 0, null, null, GetRelationsForField("ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping"), null, "ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("AfmarketingMaterial")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, 0, null, null, null, null, "AfmarketingMaterial", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCoupons
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Coupons")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.CouponsEntity, 0, null, null, null, null, "Coupons", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingOrderShippingInfo' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingOrderShippingInfo
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MarketingOrderShippingInfoEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingOrderShippingInfo")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.MarketingOrderShippingInfoEntity, 0, null, null, null, null, "MarketingOrderShippingInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrder' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrder
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingPrintOrder")[0], (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, 0, null, null, null, null, "MarketingPrintOrder", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MarketingPrintOrderItemEntity.CustomProperties;}
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
			get { return MarketingPrintOrderItemEntity.FieldsCustomProperties;}
		}

		/// <summary> The MarketingPrintOrderItemId property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."MarketingPrintOrderItemID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MarketingPrintOrderItemId
		{
			get { return (System.Int64)GetValue((int)MarketingPrintOrderItemFieldIndex.MarketingPrintOrderItemId, true); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.MarketingPrintOrderItemId, value); }
		}

		/// <summary> The MarketingPrintOrderId property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."MarketingPrintOrderID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MarketingPrintOrderId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MarketingPrintOrderItemFieldIndex.MarketingPrintOrderId, false); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.MarketingPrintOrderId, value); }
		}

		/// <summary> The MarketingMaterialId property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."MarketingMaterialId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MarketingMaterialId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MarketingPrintOrderItemFieldIndex.MarketingMaterialId, false); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.MarketingMaterialId, value); }
		}

		/// <summary> The PhoneNumber property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."PhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneNumber
		{
			get { return (System.String)GetValue((int)MarketingPrintOrderItemFieldIndex.PhoneNumber, true); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.PhoneNumber, value); }
		}

		/// <summary> The Sourcecode property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."Sourcecode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Sourcecode
		{
			get { return (System.String)GetValue((int)MarketingPrintOrderItemFieldIndex.Sourcecode, true); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.Sourcecode, value); }
		}

		/// <summary> The Quantity property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."Quantity"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Quantity
		{
			get { return (Nullable<System.Int32>)GetValue((int)MarketingPrintOrderItemFieldIndex.Quantity, false); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.Quantity, value); }
		}

		/// <summary> The ShippingMethod property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."ShippingMethod"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ShippingMethod
		{
			get { return (System.String)GetValue((int)MarketingPrintOrderItemFieldIndex.ShippingMethod, true); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.ShippingMethod, value); }
		}

		/// <summary> The Logo property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."Logo"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Logo
		{
			get { return (System.String)GetValue((int)MarketingPrintOrderItemFieldIndex.Logo, true); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.Logo, value); }
		}

		/// <summary> The MarketingOrderShippingInfoId property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."MarketingOrderShippingInfoID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MarketingOrderShippingInfoId
		{
			get { return (System.Int64)GetValue((int)MarketingPrintOrderItemFieldIndex.MarketingOrderShippingInfoId, true); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.MarketingOrderShippingInfoId, value); }
		}

		/// <summary> The IsActive property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)MarketingPrintOrderItemFieldIndex.IsActive, true); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MarketingPrintOrderItemFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MarketingPrintOrderItemFieldIndex.DateModified, false); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.DateModified, value); }
		}

		/// <summary> The AffiliateId property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."AffiliateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AffiliateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MarketingPrintOrderItemFieldIndex.AffiliateId, false); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.AffiliateId, value); }
		}

		/// <summary> The SourceCodeId property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."SourceCodeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SourceCodeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MarketingPrintOrderItemFieldIndex.SourceCodeId, false); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.SourceCodeId, value); }
		}

		/// <summary> The Status property of the Entity MarketingPrintOrderItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblMarketingPrintOrderItem"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Status
		{
			get { return (Nullable<System.Int64>)GetValue((int)MarketingPrintOrderItemFieldIndex.Status, false); }
			set	{ SetValue((int)MarketingPrintOrderItemFieldIndex.Status, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingPrintOrderProspectListMappingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingPrintOrderProspectListMappingEntity))]
		public virtual EntityCollection<MarketingPrintOrderProspectListMappingEntity> MarketingPrintOrderProspectListMapping
		{
			get
			{
				if(_marketingPrintOrderProspectListMapping==null)
				{
					_marketingPrintOrderProspectListMapping = new EntityCollection<MarketingPrintOrderProspectListMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderProspectListMappingEntityFactory)));
					_marketingPrintOrderProspectListMapping.SetContainingEntityInfo(this, "MarketingPrintOrderItem");
				}
				return _marketingPrintOrderProspectListMapping;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PrintOrderItemTrackingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PrintOrderItemTrackingEntity))]
		public virtual EntityCollection<PrintOrderItemTrackingEntity> PrintOrderItemTracking
		{
			get
			{
				if(_printOrderItemTracking==null)
				{
					_printOrderItemTracking = new EntityCollection<PrintOrderItemTrackingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PrintOrderItemTrackingEntityFactory)));
					_printOrderItemTracking.SetContainingEntityInfo(this, "MarketingPrintOrderItem");
				}
				return _printOrderItemTracking;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPrintOrderItemTracking_
		{
			get
			{
				if(_lookupCollectionViaPrintOrderItemTracking_==null)
				{
					_lookupCollectionViaPrintOrderItemTracking_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPrintOrderItemTracking_.IsReadOnly=true;
				}
				return _lookupCollectionViaPrintOrderItemTracking_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPrintOrderItemTracking
		{
			get
			{
				if(_organizationRoleUserCollectionViaPrintOrderItemTracking==null)
				{
					_organizationRoleUserCollectionViaPrintOrderItemTracking = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPrintOrderItemTracking.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPrintOrderItemTracking;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPrintOrderItemTracking_
		{
			get
			{
				if(_organizationRoleUserCollectionViaPrintOrderItemTracking_==null)
				{
					_organizationRoleUserCollectionViaPrintOrderItemTracking_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPrintOrderItemTracking_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPrintOrderItemTracking_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectListDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectListDetailsEntity))]
		public virtual EntityCollection<ProspectListDetailsEntity> ProspectListDetailsCollectionViaMarketingPrintOrderProspectListMapping
		{
			get
			{
				if(_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping==null)
				{
					_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping = new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory)));
					_prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping.IsReadOnly=true;
				}
				return _prospectListDetailsCollectionViaMarketingPrintOrderProspectListMapping;
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
							_afmarketingMaterial.UnsetRelatedEntity(this, "MarketingPrintOrderItem");
						}
					}
					else
					{
						if(_afmarketingMaterial!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MarketingPrintOrderItem");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CouponsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CouponsEntity Coupons
		{
			get
			{
				return _coupons;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCoupons(value);
				}
				else
				{
					if(value==null)
					{
						if(_coupons != null)
						{
							_coupons.UnsetRelatedEntity(this, "MarketingPrintOrderItem");
						}
					}
					else
					{
						if(_coupons!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MarketingPrintOrderItem");
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
							_lookup.UnsetRelatedEntity(this, "MarketingPrintOrderItem");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MarketingPrintOrderItem");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MarketingOrderShippingInfoEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MarketingOrderShippingInfoEntity MarketingOrderShippingInfo
		{
			get
			{
				return _marketingOrderShippingInfo;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMarketingOrderShippingInfo(value);
				}
				else
				{
					if(value==null)
					{
						if(_marketingOrderShippingInfo != null)
						{
							_marketingOrderShippingInfo.UnsetRelatedEntity(this, "MarketingPrintOrderItem");
						}
					}
					else
					{
						if(_marketingOrderShippingInfo!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MarketingPrintOrderItem");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MarketingPrintOrderEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MarketingPrintOrderEntity MarketingPrintOrder
		{
			get
			{
				return _marketingPrintOrder;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMarketingPrintOrder(value);
				}
				else
				{
					if(value==null)
					{
						if(_marketingPrintOrder != null)
						{
							_marketingPrintOrder.UnsetRelatedEntity(this, "MarketingPrintOrderItem");
						}
					}
					else
					{
						if(_marketingPrintOrder!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MarketingPrintOrderItem");
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
			get { return (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity; }
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
