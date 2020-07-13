///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:44
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
	/// Entity class which represents the entity 'Territory'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TerritoryEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventPodEntity> _eventPod;
		private EntityCollection<HospitalPartnerTerritoryEntity> _hospitalPartnerTerritory;
		private EntityCollection<MarketingSourceTerritoryEntity> _marketingSourceTerritory;
		private EntityCollection<OrganizationRoleUserTerritoryEntity> _organizationRoleUserTerritory;
		private EntityCollection<PodTerritoryEntity> _podTerritory;
		private EntityCollection<TerritoryEntity> _territory_;
		private EntityCollection<TerritoryPackageEntity> _territoryPackage;
		private EntityCollection<TerritoryZipEntity> _territoryZip;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventPod;
		private EntityCollection<HospitalPartnerEntity> _hospitalPartnerCollectionViaHospitalPartnerTerritory;
		private EntityCollection<MarketingSourceEntity> _marketingSourceCollectionViaMarketingSourceTerritory;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTerritory;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaOrganizationRoleUserTerritory;
		private EntityCollection<PackageEntity> _packageCollectionViaTerritoryPackage;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaEventPod;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaPodTerritory;
		private EntityCollection<ZipEntity> _zipCollectionViaTerritoryZip;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private TerritoryEntity _territory;
		private FranchiseeTerritoryEntity _franchiseeTerritory;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Territory</summary>
			public static readonly string Territory = "Territory";
			/// <summary>Member name EventPod</summary>
			public static readonly string EventPod = "EventPod";
			/// <summary>Member name HospitalPartnerTerritory</summary>
			public static readonly string HospitalPartnerTerritory = "HospitalPartnerTerritory";
			/// <summary>Member name MarketingSourceTerritory</summary>
			public static readonly string MarketingSourceTerritory = "MarketingSourceTerritory";
			/// <summary>Member name OrganizationRoleUserTerritory</summary>
			public static readonly string OrganizationRoleUserTerritory = "OrganizationRoleUserTerritory";
			/// <summary>Member name PodTerritory</summary>
			public static readonly string PodTerritory = "PodTerritory";
			/// <summary>Member name Territory_</summary>
			public static readonly string Territory_ = "Territory_";
			/// <summary>Member name TerritoryPackage</summary>
			public static readonly string TerritoryPackage = "TerritoryPackage";
			/// <summary>Member name TerritoryZip</summary>
			public static readonly string TerritoryZip = "TerritoryZip";
			/// <summary>Member name EventsCollectionViaEventPod</summary>
			public static readonly string EventsCollectionViaEventPod = "EventsCollectionViaEventPod";
			/// <summary>Member name HospitalPartnerCollectionViaHospitalPartnerTerritory</summary>
			public static readonly string HospitalPartnerCollectionViaHospitalPartnerTerritory = "HospitalPartnerCollectionViaHospitalPartnerTerritory";
			/// <summary>Member name MarketingSourceCollectionViaMarketingSourceTerritory</summary>
			public static readonly string MarketingSourceCollectionViaMarketingSourceTerritory = "MarketingSourceCollectionViaMarketingSourceTerritory";
			/// <summary>Member name OrganizationRoleUserCollectionViaTerritory</summary>
			public static readonly string OrganizationRoleUserCollectionViaTerritory = "OrganizationRoleUserCollectionViaTerritory";
			/// <summary>Member name OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory</summary>
			public static readonly string OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory = "OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory";
			/// <summary>Member name PackageCollectionViaTerritoryPackage</summary>
			public static readonly string PackageCollectionViaTerritoryPackage = "PackageCollectionViaTerritoryPackage";
			/// <summary>Member name PodDetailsCollectionViaEventPod</summary>
			public static readonly string PodDetailsCollectionViaEventPod = "PodDetailsCollectionViaEventPod";
			/// <summary>Member name PodDetailsCollectionViaPodTerritory</summary>
			public static readonly string PodDetailsCollectionViaPodTerritory = "PodDetailsCollectionViaPodTerritory";
			/// <summary>Member name ZipCollectionViaTerritoryZip</summary>
			public static readonly string ZipCollectionViaTerritoryZip = "ZipCollectionViaTerritoryZip";
			/// <summary>Member name FranchiseeTerritory</summary>
			public static readonly string FranchiseeTerritory = "FranchiseeTerritory";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TerritoryEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TerritoryEntity():base("TerritoryEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TerritoryEntity(IEntityFields2 fields):base("TerritoryEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TerritoryEntity</param>
		public TerritoryEntity(IValidator validator):base("TerritoryEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="territoryId">PK value for Territory which data should be fetched into this Territory object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TerritoryEntity(System.Int64 territoryId):base("TerritoryEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TerritoryId = territoryId;
		}

		/// <summary> CTor</summary>
		/// <param name="territoryId">PK value for Territory which data should be fetched into this Territory object</param>
		/// <param name="validator">The custom validator object for this TerritoryEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TerritoryEntity(System.Int64 territoryId, IValidator validator):base("TerritoryEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TerritoryId = territoryId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TerritoryEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventPod = (EntityCollection<EventPodEntity>)info.GetValue("_eventPod", typeof(EntityCollection<EventPodEntity>));
				_hospitalPartnerTerritory = (EntityCollection<HospitalPartnerTerritoryEntity>)info.GetValue("_hospitalPartnerTerritory", typeof(EntityCollection<HospitalPartnerTerritoryEntity>));
				_marketingSourceTerritory = (EntityCollection<MarketingSourceTerritoryEntity>)info.GetValue("_marketingSourceTerritory", typeof(EntityCollection<MarketingSourceTerritoryEntity>));
				_organizationRoleUserTerritory = (EntityCollection<OrganizationRoleUserTerritoryEntity>)info.GetValue("_organizationRoleUserTerritory", typeof(EntityCollection<OrganizationRoleUserTerritoryEntity>));
				_podTerritory = (EntityCollection<PodTerritoryEntity>)info.GetValue("_podTerritory", typeof(EntityCollection<PodTerritoryEntity>));
				_territory_ = (EntityCollection<TerritoryEntity>)info.GetValue("_territory_", typeof(EntityCollection<TerritoryEntity>));
				_territoryPackage = (EntityCollection<TerritoryPackageEntity>)info.GetValue("_territoryPackage", typeof(EntityCollection<TerritoryPackageEntity>));
				_territoryZip = (EntityCollection<TerritoryZipEntity>)info.GetValue("_territoryZip", typeof(EntityCollection<TerritoryZipEntity>));
				_eventsCollectionViaEventPod = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventPod", typeof(EntityCollection<EventsEntity>));
				_hospitalPartnerCollectionViaHospitalPartnerTerritory = (EntityCollection<HospitalPartnerEntity>)info.GetValue("_hospitalPartnerCollectionViaHospitalPartnerTerritory", typeof(EntityCollection<HospitalPartnerEntity>));
				_marketingSourceCollectionViaMarketingSourceTerritory = (EntityCollection<MarketingSourceEntity>)info.GetValue("_marketingSourceCollectionViaMarketingSourceTerritory", typeof(EntityCollection<MarketingSourceEntity>));
				_organizationRoleUserCollectionViaTerritory = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTerritory", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaOrganizationRoleUserTerritory = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaOrganizationRoleUserTerritory", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_packageCollectionViaTerritoryPackage = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaTerritoryPackage", typeof(EntityCollection<PackageEntity>));
				_podDetailsCollectionViaEventPod = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaEventPod", typeof(EntityCollection<PodDetailsEntity>));
				_podDetailsCollectionViaPodTerritory = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaPodTerritory", typeof(EntityCollection<PodDetailsEntity>));
				_zipCollectionViaTerritoryZip = (EntityCollection<ZipEntity>)info.GetValue("_zipCollectionViaTerritoryZip", typeof(EntityCollection<ZipEntity>));
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_territory = (TerritoryEntity)info.GetValue("_territory", typeof(TerritoryEntity));
				if(_territory!=null)
				{
					_territory.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_franchiseeTerritory = (FranchiseeTerritoryEntity)info.GetValue("_franchiseeTerritory", typeof(FranchiseeTerritoryEntity));
				if(_franchiseeTerritory!=null)
				{
					_franchiseeTerritory.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TerritoryFieldIndex)fieldIndex)
			{
				case TerritoryFieldIndex.ParentTerritoryId:
					DesetupSyncTerritory(true, false);
					break;
				case TerritoryFieldIndex.CreatedBy:
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
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Territory":
					this.Territory = (TerritoryEntity)entity;
					break;
				case "EventPod":
					this.EventPod.Add((EventPodEntity)entity);
					break;
				case "HospitalPartnerTerritory":
					this.HospitalPartnerTerritory.Add((HospitalPartnerTerritoryEntity)entity);
					break;
				case "MarketingSourceTerritory":
					this.MarketingSourceTerritory.Add((MarketingSourceTerritoryEntity)entity);
					break;
				case "OrganizationRoleUserTerritory":
					this.OrganizationRoleUserTerritory.Add((OrganizationRoleUserTerritoryEntity)entity);
					break;
				case "PodTerritory":
					this.PodTerritory.Add((PodTerritoryEntity)entity);
					break;
				case "Territory_":
					this.Territory_.Add((TerritoryEntity)entity);
					break;
				case "TerritoryPackage":
					this.TerritoryPackage.Add((TerritoryPackageEntity)entity);
					break;
				case "TerritoryZip":
					this.TerritoryZip.Add((TerritoryZipEntity)entity);
					break;
				case "EventsCollectionViaEventPod":
					this.EventsCollectionViaEventPod.IsReadOnly = false;
					this.EventsCollectionViaEventPod.Add((EventsEntity)entity);
					this.EventsCollectionViaEventPod.IsReadOnly = true;
					break;
				case "HospitalPartnerCollectionViaHospitalPartnerTerritory":
					this.HospitalPartnerCollectionViaHospitalPartnerTerritory.IsReadOnly = false;
					this.HospitalPartnerCollectionViaHospitalPartnerTerritory.Add((HospitalPartnerEntity)entity);
					this.HospitalPartnerCollectionViaHospitalPartnerTerritory.IsReadOnly = true;
					break;
				case "MarketingSourceCollectionViaMarketingSourceTerritory":
					this.MarketingSourceCollectionViaMarketingSourceTerritory.IsReadOnly = false;
					this.MarketingSourceCollectionViaMarketingSourceTerritory.Add((MarketingSourceEntity)entity);
					this.MarketingSourceCollectionViaMarketingSourceTerritory.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTerritory":
					this.OrganizationRoleUserCollectionViaTerritory.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTerritory.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTerritory.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory":
					this.OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory.IsReadOnly = true;
					break;
				case "PackageCollectionViaTerritoryPackage":
					this.PackageCollectionViaTerritoryPackage.IsReadOnly = false;
					this.PackageCollectionViaTerritoryPackage.Add((PackageEntity)entity);
					this.PackageCollectionViaTerritoryPackage.IsReadOnly = true;
					break;
				case "PodDetailsCollectionViaEventPod":
					this.PodDetailsCollectionViaEventPod.IsReadOnly = false;
					this.PodDetailsCollectionViaEventPod.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaEventPod.IsReadOnly = true;
					break;
				case "PodDetailsCollectionViaPodTerritory":
					this.PodDetailsCollectionViaPodTerritory.IsReadOnly = false;
					this.PodDetailsCollectionViaPodTerritory.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaPodTerritory.IsReadOnly = true;
					break;
				case "ZipCollectionViaTerritoryZip":
					this.ZipCollectionViaTerritoryZip.IsReadOnly = false;
					this.ZipCollectionViaTerritoryZip.Add((ZipEntity)entity);
					this.ZipCollectionViaTerritoryZip.IsReadOnly = true;
					break;
				case "FranchiseeTerritory":
					this.FranchiseeTerritory = (FranchiseeTerritoryEntity)entity;
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
			return TerritoryEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser":
					toReturn.Add(TerritoryEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "Territory":
					toReturn.Add(TerritoryEntity.Relations.TerritoryEntityUsingTerritoryIdParentTerritoryId);
					break;
				case "EventPod":
					toReturn.Add(TerritoryEntity.Relations.EventPodEntityUsingTerritoryId);
					break;
				case "HospitalPartnerTerritory":
					toReturn.Add(TerritoryEntity.Relations.HospitalPartnerTerritoryEntityUsingTerritoryId);
					break;
				case "MarketingSourceTerritory":
					toReturn.Add(TerritoryEntity.Relations.MarketingSourceTerritoryEntityUsingTerritoryId);
					break;
				case "OrganizationRoleUserTerritory":
					toReturn.Add(TerritoryEntity.Relations.OrganizationRoleUserTerritoryEntityUsingTerritoryId);
					break;
				case "PodTerritory":
					toReturn.Add(TerritoryEntity.Relations.PodTerritoryEntityUsingTerritoryId);
					break;
				case "Territory_":
					toReturn.Add(TerritoryEntity.Relations.TerritoryEntityUsingParentTerritoryId);
					break;
				case "TerritoryPackage":
					toReturn.Add(TerritoryEntity.Relations.TerritoryPackageEntityUsingTerritoryId);
					break;
				case "TerritoryZip":
					toReturn.Add(TerritoryEntity.Relations.TerritoryZipEntityUsingTerritoryId);
					break;
				case "EventsCollectionViaEventPod":
					toReturn.Add(TerritoryEntity.Relations.EventPodEntityUsingTerritoryId, "TerritoryEntity__", "EventPod_", JoinHint.None);
					toReturn.Add(EventPodEntity.Relations.EventsEntityUsingEventId, "EventPod_", string.Empty, JoinHint.None);
					break;
				case "HospitalPartnerCollectionViaHospitalPartnerTerritory":
					toReturn.Add(TerritoryEntity.Relations.HospitalPartnerTerritoryEntityUsingTerritoryId, "TerritoryEntity__", "HospitalPartnerTerritory_", JoinHint.None);
					toReturn.Add(HospitalPartnerTerritoryEntity.Relations.HospitalPartnerEntityUsingHospitalPartnerId, "HospitalPartnerTerritory_", string.Empty, JoinHint.None);
					break;
				case "MarketingSourceCollectionViaMarketingSourceTerritory":
					toReturn.Add(TerritoryEntity.Relations.MarketingSourceTerritoryEntityUsingTerritoryId, "TerritoryEntity__", "MarketingSourceTerritory_", JoinHint.None);
					toReturn.Add(MarketingSourceTerritoryEntity.Relations.MarketingSourceEntityUsingMarketingSourceId, "MarketingSourceTerritory_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTerritory":
					toReturn.Add(TerritoryEntity.Relations.TerritoryEntityUsingParentTerritoryId, "TerritoryEntity__", "Territory_", JoinHint.None);
					toReturn.Add(TerritoryEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "Territory_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory":
					toReturn.Add(TerritoryEntity.Relations.OrganizationRoleUserTerritoryEntityUsingTerritoryId, "TerritoryEntity__", "OrganizationRoleUserTerritory_", JoinHint.None);
					toReturn.Add(OrganizationRoleUserTerritoryEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId, "OrganizationRoleUserTerritory_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaTerritoryPackage":
					toReturn.Add(TerritoryEntity.Relations.TerritoryPackageEntityUsingTerritoryId, "TerritoryEntity__", "TerritoryPackage_", JoinHint.None);
					toReturn.Add(TerritoryPackageEntity.Relations.PackageEntityUsingPackageId, "TerritoryPackage_", string.Empty, JoinHint.None);
					break;
				case "PodDetailsCollectionViaEventPod":
					toReturn.Add(TerritoryEntity.Relations.EventPodEntityUsingTerritoryId, "TerritoryEntity__", "EventPod_", JoinHint.None);
					toReturn.Add(EventPodEntity.Relations.PodDetailsEntityUsingPodId, "EventPod_", string.Empty, JoinHint.None);
					break;
				case "PodDetailsCollectionViaPodTerritory":
					toReturn.Add(TerritoryEntity.Relations.PodTerritoryEntityUsingTerritoryId, "TerritoryEntity__", "PodTerritory_", JoinHint.None);
					toReturn.Add(PodTerritoryEntity.Relations.PodDetailsEntityUsingPodId, "PodTerritory_", string.Empty, JoinHint.None);
					break;
				case "ZipCollectionViaTerritoryZip":
					toReturn.Add(TerritoryEntity.Relations.TerritoryZipEntityUsingTerritoryId, "TerritoryEntity__", "TerritoryZip_", JoinHint.None);
					toReturn.Add(TerritoryZipEntity.Relations.ZipEntityUsingZipId, "TerritoryZip_", string.Empty, JoinHint.None);
					break;
				case "FranchiseeTerritory":
					toReturn.Add(TerritoryEntity.Relations.FranchiseeTerritoryEntityUsingTerritoryId);
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
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Territory":
					SetupSyncTerritory(relatedEntity);
					break;
				case "EventPod":
					this.EventPod.Add((EventPodEntity)relatedEntity);
					break;
				case "HospitalPartnerTerritory":
					this.HospitalPartnerTerritory.Add((HospitalPartnerTerritoryEntity)relatedEntity);
					break;
				case "MarketingSourceTerritory":
					this.MarketingSourceTerritory.Add((MarketingSourceTerritoryEntity)relatedEntity);
					break;
				case "OrganizationRoleUserTerritory":
					this.OrganizationRoleUserTerritory.Add((OrganizationRoleUserTerritoryEntity)relatedEntity);
					break;
				case "PodTerritory":
					this.PodTerritory.Add((PodTerritoryEntity)relatedEntity);
					break;
				case "Territory_":
					this.Territory_.Add((TerritoryEntity)relatedEntity);
					break;
				case "TerritoryPackage":
					this.TerritoryPackage.Add((TerritoryPackageEntity)relatedEntity);
					break;
				case "TerritoryZip":
					this.TerritoryZip.Add((TerritoryZipEntity)relatedEntity);
					break;
				case "FranchiseeTerritory":
					SetupSyncFranchiseeTerritory(relatedEntity);
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
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Territory":
					DesetupSyncTerritory(false, true);
					break;
				case "EventPod":
					base.PerformRelatedEntityRemoval(this.EventPod, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HospitalPartnerTerritory":
					base.PerformRelatedEntityRemoval(this.HospitalPartnerTerritory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MarketingSourceTerritory":
					base.PerformRelatedEntityRemoval(this.MarketingSourceTerritory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "OrganizationRoleUserTerritory":
					base.PerformRelatedEntityRemoval(this.OrganizationRoleUserTerritory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodTerritory":
					base.PerformRelatedEntityRemoval(this.PodTerritory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Territory_":
					base.PerformRelatedEntityRemoval(this.Territory_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TerritoryPackage":
					base.PerformRelatedEntityRemoval(this.TerritoryPackage, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TerritoryZip":
					base.PerformRelatedEntityRemoval(this.TerritoryZip, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "FranchiseeTerritory":
					DesetupSyncFranchiseeTerritory(false, true);
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

			if(_franchiseeTerritory!=null)
			{
				toReturn.Add(_franchiseeTerritory);
			}
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_territory!=null)
			{
				toReturn.Add(_territory);
			}


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventPod);
			toReturn.Add(this.HospitalPartnerTerritory);
			toReturn.Add(this.MarketingSourceTerritory);
			toReturn.Add(this.OrganizationRoleUserTerritory);
			toReturn.Add(this.PodTerritory);
			toReturn.Add(this.Territory_);
			toReturn.Add(this.TerritoryPackage);
			toReturn.Add(this.TerritoryZip);

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
				info.AddValue("_eventPod", ((_eventPod!=null) && (_eventPod.Count>0) && !this.MarkedForDeletion)?_eventPod:null);
				info.AddValue("_hospitalPartnerTerritory", ((_hospitalPartnerTerritory!=null) && (_hospitalPartnerTerritory.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerTerritory:null);
				info.AddValue("_marketingSourceTerritory", ((_marketingSourceTerritory!=null) && (_marketingSourceTerritory.Count>0) && !this.MarkedForDeletion)?_marketingSourceTerritory:null);
				info.AddValue("_organizationRoleUserTerritory", ((_organizationRoleUserTerritory!=null) && (_organizationRoleUserTerritory.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserTerritory:null);
				info.AddValue("_podTerritory", ((_podTerritory!=null) && (_podTerritory.Count>0) && !this.MarkedForDeletion)?_podTerritory:null);
				info.AddValue("_territory_", ((_territory_!=null) && (_territory_.Count>0) && !this.MarkedForDeletion)?_territory_:null);
				info.AddValue("_territoryPackage", ((_territoryPackage!=null) && (_territoryPackage.Count>0) && !this.MarkedForDeletion)?_territoryPackage:null);
				info.AddValue("_territoryZip", ((_territoryZip!=null) && (_territoryZip.Count>0) && !this.MarkedForDeletion)?_territoryZip:null);
				info.AddValue("_eventsCollectionViaEventPod", ((_eventsCollectionViaEventPod!=null) && (_eventsCollectionViaEventPod.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventPod:null);
				info.AddValue("_hospitalPartnerCollectionViaHospitalPartnerTerritory", ((_hospitalPartnerCollectionViaHospitalPartnerTerritory!=null) && (_hospitalPartnerCollectionViaHospitalPartnerTerritory.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerCollectionViaHospitalPartnerTerritory:null);
				info.AddValue("_marketingSourceCollectionViaMarketingSourceTerritory", ((_marketingSourceCollectionViaMarketingSourceTerritory!=null) && (_marketingSourceCollectionViaMarketingSourceTerritory.Count>0) && !this.MarkedForDeletion)?_marketingSourceCollectionViaMarketingSourceTerritory:null);
				info.AddValue("_organizationRoleUserCollectionViaTerritory", ((_organizationRoleUserCollectionViaTerritory!=null) && (_organizationRoleUserCollectionViaTerritory.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTerritory:null);
				info.AddValue("_organizationRoleUserCollectionViaOrganizationRoleUserTerritory", ((_organizationRoleUserCollectionViaOrganizationRoleUserTerritory!=null) && (_organizationRoleUserCollectionViaOrganizationRoleUserTerritory.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaOrganizationRoleUserTerritory:null);
				info.AddValue("_packageCollectionViaTerritoryPackage", ((_packageCollectionViaTerritoryPackage!=null) && (_packageCollectionViaTerritoryPackage.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaTerritoryPackage:null);
				info.AddValue("_podDetailsCollectionViaEventPod", ((_podDetailsCollectionViaEventPod!=null) && (_podDetailsCollectionViaEventPod.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaEventPod:null);
				info.AddValue("_podDetailsCollectionViaPodTerritory", ((_podDetailsCollectionViaPodTerritory!=null) && (_podDetailsCollectionViaPodTerritory.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaPodTerritory:null);
				info.AddValue("_zipCollectionViaTerritoryZip", ((_zipCollectionViaTerritoryZip!=null) && (_zipCollectionViaTerritoryZip.Count>0) && !this.MarkedForDeletion)?_zipCollectionViaTerritoryZip:null);
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_territory", (!this.MarkedForDeletion?_territory:null));
				info.AddValue("_franchiseeTerritory", (!this.MarkedForDeletion?_franchiseeTerritory:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TerritoryFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TerritoryFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TerritoryRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPod' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPodFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartnerTerritory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerTerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingSourceTerritory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingSourceTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingSourceTerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUserTerritory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserTerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodTerritory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodTerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Territory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritory_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.ParentTerritoryId, null, ComparisonOperator.Equal, this.TerritoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TerritoryPackage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritoryPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryPackageFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TerritoryZip' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritoryZip()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryZipFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventPod"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId, "TerritoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartner' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerCollectionViaHospitalPartnerTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HospitalPartnerCollectionViaHospitalPartnerTerritory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId, "TerritoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingSource' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingSourceCollectionViaMarketingSourceTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MarketingSourceCollectionViaMarketingSourceTerritory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId, "TerritoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTerritory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId, "TerritoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaOrganizationRoleUserTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId, "TerritoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaTerritoryPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaTerritoryPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId, "TerritoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaEventPod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaEventPod"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId, "TerritoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaPodTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaPodTerritory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId, "TerritoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Zip' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoZipCollectionViaTerritoryZip()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ZipCollectionViaTerritoryZip"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId, "TerritoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Territory' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.ParentTerritoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'FranchiseeTerritory' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFranchiseeTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FranchiseeTerritoryFields.TerritoryId, null, ComparisonOperator.Equal, this.TerritoryId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.TerritoryEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventPod);
			collectionsQueue.Enqueue(this._hospitalPartnerTerritory);
			collectionsQueue.Enqueue(this._marketingSourceTerritory);
			collectionsQueue.Enqueue(this._organizationRoleUserTerritory);
			collectionsQueue.Enqueue(this._podTerritory);
			collectionsQueue.Enqueue(this._territory_);
			collectionsQueue.Enqueue(this._territoryPackage);
			collectionsQueue.Enqueue(this._territoryZip);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventPod);
			collectionsQueue.Enqueue(this._hospitalPartnerCollectionViaHospitalPartnerTerritory);
			collectionsQueue.Enqueue(this._marketingSourceCollectionViaMarketingSourceTerritory);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTerritory);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaOrganizationRoleUserTerritory);
			collectionsQueue.Enqueue(this._packageCollectionViaTerritoryPackage);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaEventPod);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaPodTerritory);
			collectionsQueue.Enqueue(this._zipCollectionViaTerritoryZip);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventPod = (EntityCollection<EventPodEntity>) collectionsQueue.Dequeue();
			this._hospitalPartnerTerritory = (EntityCollection<HospitalPartnerTerritoryEntity>) collectionsQueue.Dequeue();
			this._marketingSourceTerritory = (EntityCollection<MarketingSourceTerritoryEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserTerritory = (EntityCollection<OrganizationRoleUserTerritoryEntity>) collectionsQueue.Dequeue();
			this._podTerritory = (EntityCollection<PodTerritoryEntity>) collectionsQueue.Dequeue();
			this._territory_ = (EntityCollection<TerritoryEntity>) collectionsQueue.Dequeue();
			this._territoryPackage = (EntityCollection<TerritoryPackageEntity>) collectionsQueue.Dequeue();
			this._territoryZip = (EntityCollection<TerritoryZipEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventPod = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._hospitalPartnerCollectionViaHospitalPartnerTerritory = (EntityCollection<HospitalPartnerEntity>) collectionsQueue.Dequeue();
			this._marketingSourceCollectionViaMarketingSourceTerritory = (EntityCollection<MarketingSourceEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTerritory = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaOrganizationRoleUserTerritory = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaTerritoryPackage = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaEventPod = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaPodTerritory = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
			this._zipCollectionViaTerritoryZip = (EntityCollection<ZipEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventPod != null)
			{
				return true;
			}
			if (this._hospitalPartnerTerritory != null)
			{
				return true;
			}
			if (this._marketingSourceTerritory != null)
			{
				return true;
			}
			if (this._organizationRoleUserTerritory != null)
			{
				return true;
			}
			if (this._podTerritory != null)
			{
				return true;
			}
			if (this._territory_ != null)
			{
				return true;
			}
			if (this._territoryPackage != null)
			{
				return true;
			}
			if (this._territoryZip != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventPod != null)
			{
				return true;
			}
			if (this._hospitalPartnerCollectionViaHospitalPartnerTerritory != null)
			{
				return true;
			}
			if (this._marketingSourceCollectionViaMarketingSourceTerritory != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTerritory != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaOrganizationRoleUserTerritory != null)
			{
				return true;
			}
			if (this._packageCollectionViaTerritoryPackage != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaEventPod != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaPodTerritory != null)
			{
				return true;
			}
			if (this._zipCollectionViaTerritoryZip != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerTerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingSourceTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingSourceTerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserTerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TerritoryPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryPackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TerritoryZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryZipEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingSourceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Territory", _territory);
			toReturn.Add("EventPod", _eventPod);
			toReturn.Add("HospitalPartnerTerritory", _hospitalPartnerTerritory);
			toReturn.Add("MarketingSourceTerritory", _marketingSourceTerritory);
			toReturn.Add("OrganizationRoleUserTerritory", _organizationRoleUserTerritory);
			toReturn.Add("PodTerritory", _podTerritory);
			toReturn.Add("Territory_", _territory_);
			toReturn.Add("TerritoryPackage", _territoryPackage);
			toReturn.Add("TerritoryZip", _territoryZip);
			toReturn.Add("EventsCollectionViaEventPod", _eventsCollectionViaEventPod);
			toReturn.Add("HospitalPartnerCollectionViaHospitalPartnerTerritory", _hospitalPartnerCollectionViaHospitalPartnerTerritory);
			toReturn.Add("MarketingSourceCollectionViaMarketingSourceTerritory", _marketingSourceCollectionViaMarketingSourceTerritory);
			toReturn.Add("OrganizationRoleUserCollectionViaTerritory", _organizationRoleUserCollectionViaTerritory);
			toReturn.Add("OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory", _organizationRoleUserCollectionViaOrganizationRoleUserTerritory);
			toReturn.Add("PackageCollectionViaTerritoryPackage", _packageCollectionViaTerritoryPackage);
			toReturn.Add("PodDetailsCollectionViaEventPod", _podDetailsCollectionViaEventPod);
			toReturn.Add("PodDetailsCollectionViaPodTerritory", _podDetailsCollectionViaPodTerritory);
			toReturn.Add("ZipCollectionViaTerritoryZip", _zipCollectionViaTerritoryZip);
			toReturn.Add("FranchiseeTerritory", _franchiseeTerritory);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventPod!=null)
			{
				_eventPod.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerTerritory!=null)
			{
				_hospitalPartnerTerritory.ActiveContext = base.ActiveContext;
			}
			if(_marketingSourceTerritory!=null)
			{
				_marketingSourceTerritory.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserTerritory!=null)
			{
				_organizationRoleUserTerritory.ActiveContext = base.ActiveContext;
			}
			if(_podTerritory!=null)
			{
				_podTerritory.ActiveContext = base.ActiveContext;
			}
			if(_territory_!=null)
			{
				_territory_.ActiveContext = base.ActiveContext;
			}
			if(_territoryPackage!=null)
			{
				_territoryPackage.ActiveContext = base.ActiveContext;
			}
			if(_territoryZip!=null)
			{
				_territoryZip.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventPod!=null)
			{
				_eventsCollectionViaEventPod.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerCollectionViaHospitalPartnerTerritory!=null)
			{
				_hospitalPartnerCollectionViaHospitalPartnerTerritory.ActiveContext = base.ActiveContext;
			}
			if(_marketingSourceCollectionViaMarketingSourceTerritory!=null)
			{
				_marketingSourceCollectionViaMarketingSourceTerritory.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTerritory!=null)
			{
				_organizationRoleUserCollectionViaTerritory.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaOrganizationRoleUserTerritory!=null)
			{
				_organizationRoleUserCollectionViaOrganizationRoleUserTerritory.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaTerritoryPackage!=null)
			{
				_packageCollectionViaTerritoryPackage.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaEventPod!=null)
			{
				_podDetailsCollectionViaEventPod.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaPodTerritory!=null)
			{
				_podDetailsCollectionViaPodTerritory.ActiveContext = base.ActiveContext;
			}
			if(_zipCollectionViaTerritoryZip!=null)
			{
				_zipCollectionViaTerritoryZip.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_territory!=null)
			{
				_territory.ActiveContext = base.ActiveContext;
			}
			if(_franchiseeTerritory!=null)
			{
				_franchiseeTerritory.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventPod = null;
			_hospitalPartnerTerritory = null;
			_marketingSourceTerritory = null;
			_organizationRoleUserTerritory = null;
			_podTerritory = null;
			_territory_ = null;
			_territoryPackage = null;
			_territoryZip = null;
			_eventsCollectionViaEventPod = null;
			_hospitalPartnerCollectionViaHospitalPartnerTerritory = null;
			_marketingSourceCollectionViaMarketingSourceTerritory = null;
			_organizationRoleUserCollectionViaTerritory = null;
			_organizationRoleUserCollectionViaOrganizationRoleUserTerritory = null;
			_packageCollectionViaTerritoryPackage = null;
			_podDetailsCollectionViaEventPod = null;
			_podDetailsCollectionViaPodTerritory = null;
			_zipCollectionViaTerritoryZip = null;
			_organizationRoleUser = null;
			_territory = null;
			_franchiseeTerritory = null;
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

			_fieldsCustomProperties.Add("TerritoryId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Type", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentTerritoryId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", TerritoryEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "Territory", resetFKFields, new int[] { (int)TerritoryFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", TerritoryEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _territory</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTerritory(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _territory, new PropertyChangedEventHandler( OnTerritoryPropertyChanged ), "Territory", TerritoryEntity.Relations.TerritoryEntityUsingTerritoryIdParentTerritoryId, true, signalRelatedEntity, "Territory_", resetFKFields, new int[] { (int)TerritoryFieldIndex.ParentTerritoryId } );		
			_territory = null;
		}

		/// <summary> setups the sync logic for member _territory</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTerritory(IEntity2 relatedEntity)
		{
			if(_territory!=relatedEntity)
			{
				DesetupSyncTerritory(true, true);
				_territory = (TerritoryEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _territory, new PropertyChangedEventHandler( OnTerritoryPropertyChanged ), "Territory", TerritoryEntity.Relations.TerritoryEntityUsingTerritoryIdParentTerritoryId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTerritoryPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _franchiseeTerritory</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFranchiseeTerritory(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _franchiseeTerritory, new PropertyChangedEventHandler( OnFranchiseeTerritoryPropertyChanged ), "FranchiseeTerritory", TerritoryEntity.Relations.FranchiseeTerritoryEntityUsingTerritoryId, false, signalRelatedEntity, "Territory", false, new int[] { (int)TerritoryFieldIndex.TerritoryId } );
			_franchiseeTerritory = null;
		}
		
		/// <summary> setups the sync logic for member _franchiseeTerritory</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFranchiseeTerritory(IEntity2 relatedEntity)
		{
			if(_franchiseeTerritory!=relatedEntity)
			{
				DesetupSyncFranchiseeTerritory(true, true);
				_franchiseeTerritory = (FranchiseeTerritoryEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _franchiseeTerritory, new PropertyChangedEventHandler( OnFranchiseeTerritoryPropertyChanged ), "FranchiseeTerritory", TerritoryEntity.Relations.FranchiseeTerritoryEntityUsingTerritoryId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFranchiseeTerritoryPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TerritoryEntity</param>
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
		public  static TerritoryRelations Relations
		{
			get	{ return new TerritoryRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPod' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPod
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPod")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.EventPodEntity, 0, null, null, null, null, "EventPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartnerTerritory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartnerTerritory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HospitalPartnerTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerTerritoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalPartnerTerritory")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.HospitalPartnerTerritoryEntity, 0, null, null, null, null, "HospitalPartnerTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingSourceTerritory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingSourceTerritory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MarketingSourceTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingSourceTerritoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingSourceTerritory")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.MarketingSourceTerritoryEntity, 0, null, null, null, null, "MarketingSourceTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUserTerritory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserTerritory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrganizationRoleUserTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserTerritoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUserTerritory")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserTerritoryEntity, 0, null, null, null, null, "OrganizationRoleUserTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodTerritory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodTerritory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTerritoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodTerritory")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.PodTerritoryEntity, 0, null, null, null, null, "PodTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Territory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTerritory_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("Territory_")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.TerritoryEntity, 0, null, null, null, null, "Territory_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TerritoryPackage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTerritoryPackage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TerritoryPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryPackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("TerritoryPackage")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.TerritoryPackageEntity, 0, null, null, null, null, "TerritoryPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TerritoryZip' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTerritoryZip
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TerritoryZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryZipEntityFactory))),
					(IEntityRelation)GetRelationsForField("TerritoryZip")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.TerritoryZipEntity, 0, null, null, null, null, "TerritoryZip", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventPod
		{
			get
			{
				IEntityRelation intermediateRelation = TerritoryEntity.Relations.EventPodEntityUsingTerritoryId;
				intermediateRelation.SetAliases(string.Empty, "EventPod_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventPod"), null, "EventsCollectionViaEventPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartner' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartnerCollectionViaHospitalPartnerTerritory
		{
			get
			{
				IEntityRelation intermediateRelation = TerritoryEntity.Relations.HospitalPartnerTerritoryEntityUsingTerritoryId;
				intermediateRelation.SetAliases(string.Empty, "HospitalPartnerTerritory_");
				return new PrefetchPathElement2(new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.HospitalPartnerEntity, 0, null, null, GetRelationsForField("HospitalPartnerCollectionViaHospitalPartnerTerritory"), null, "HospitalPartnerCollectionViaHospitalPartnerTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingSource' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingSourceCollectionViaMarketingSourceTerritory
		{
			get
			{
				IEntityRelation intermediateRelation = TerritoryEntity.Relations.MarketingSourceTerritoryEntityUsingTerritoryId;
				intermediateRelation.SetAliases(string.Empty, "MarketingSourceTerritory_");
				return new PrefetchPathElement2(new EntityCollection<MarketingSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingSourceEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.MarketingSourceEntity, 0, null, null, GetRelationsForField("MarketingSourceCollectionViaMarketingSourceTerritory"), null, "MarketingSourceCollectionViaMarketingSourceTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTerritory
		{
			get
			{
				IEntityRelation intermediateRelation = TerritoryEntity.Relations.TerritoryEntityUsingParentTerritoryId;
				intermediateRelation.SetAliases(string.Empty, "Territory_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTerritory"), null, "OrganizationRoleUserCollectionViaTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaOrganizationRoleUserTerritory
		{
			get
			{
				IEntityRelation intermediateRelation = TerritoryEntity.Relations.OrganizationRoleUserTerritoryEntityUsingTerritoryId;
				intermediateRelation.SetAliases(string.Empty, "OrganizationRoleUserTerritory_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory"), null, "OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaTerritoryPackage
		{
			get
			{
				IEntityRelation intermediateRelation = TerritoryEntity.Relations.TerritoryPackageEntityUsingTerritoryId;
				intermediateRelation.SetAliases(string.Empty, "TerritoryPackage_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaTerritoryPackage"), null, "PackageCollectionViaTerritoryPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaEventPod
		{
			get
			{
				IEntityRelation intermediateRelation = TerritoryEntity.Relations.EventPodEntityUsingTerritoryId;
				intermediateRelation.SetAliases(string.Empty, "EventPod_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaEventPod"), null, "PodDetailsCollectionViaEventPod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaPodTerritory
		{
			get
			{
				IEntityRelation intermediateRelation = TerritoryEntity.Relations.PodTerritoryEntityUsingTerritoryId;
				intermediateRelation.SetAliases(string.Empty, "PodTerritory_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaPodTerritory"), null, "PodDetailsCollectionViaPodTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Zip' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathZipCollectionViaTerritoryZip
		{
			get
			{
				IEntityRelation intermediateRelation = TerritoryEntity.Relations.TerritoryZipEntityUsingTerritoryId;
				intermediateRelation.SetAliases(string.Empty, "TerritoryZip_");
				return new PrefetchPathElement2(new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.ZipEntity, 0, null, null, GetRelationsForField("ZipCollectionViaTerritoryZip"), null, "ZipCollectionViaTerritoryZip", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Territory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTerritory
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("Territory")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.TerritoryEntity, 0, null, null, null, null, "Territory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FranchiseeTerritory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFranchiseeTerritory
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FranchiseeTerritoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("FranchiseeTerritory")[0], (int)Falcon.Data.EntityType.TerritoryEntity, (int)Falcon.Data.EntityType.FranchiseeTerritoryEntity, 0, null, null, null, null, "FranchiseeTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TerritoryEntity.CustomProperties;}
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
			get { return TerritoryEntity.FieldsCustomProperties;}
		}

		/// <summary> The TerritoryId property of the Entity Territory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTerritory"."TerritoryID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TerritoryId
		{
			get { return (System.Int64)GetValue((int)TerritoryFieldIndex.TerritoryId, true); }
			set	{ SetValue((int)TerritoryFieldIndex.TerritoryId, value); }
		}

		/// <summary> The Name property of the Entity Territory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTerritory"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)TerritoryFieldIndex.Name, true); }
			set	{ SetValue((int)TerritoryFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity Territory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTerritory"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)TerritoryFieldIndex.Description, true); }
			set	{ SetValue((int)TerritoryFieldIndex.Description, value); }
		}

		/// <summary> The Type property of the Entity Territory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTerritory"."Type"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte Type
		{
			get { return (System.Byte)GetValue((int)TerritoryFieldIndex.Type, true); }
			set	{ SetValue((int)TerritoryFieldIndex.Type, value); }
		}

		/// <summary> The ParentTerritoryId property of the Entity Territory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTerritory"."ParentTerritoryID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentTerritoryId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TerritoryFieldIndex.ParentTerritoryId, false); }
			set	{ SetValue((int)TerritoryFieldIndex.ParentTerritoryId, value); }
		}

		/// <summary> The IsActive property of the Entity Territory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTerritory"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)TerritoryFieldIndex.IsActive, true); }
			set	{ SetValue((int)TerritoryFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity Territory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTerritory"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)TerritoryFieldIndex.DateCreated, true); }
			set	{ SetValue((int)TerritoryFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Territory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTerritory"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)TerritoryFieldIndex.DateModified, true); }
			set	{ SetValue((int)TerritoryFieldIndex.DateModified, value); }
		}

		/// <summary> The CreatedBy property of the Entity Territory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTerritory"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)TerritoryFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)TerritoryFieldIndex.CreatedBy, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPodEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPodEntity))]
		public virtual EntityCollection<EventPodEntity> EventPod
		{
			get
			{
				if(_eventPod==null)
				{
					_eventPod = new EntityCollection<EventPodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodEntityFactory)));
					_eventPod.SetContainingEntityInfo(this, "Territory");
				}
				return _eventPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalPartnerTerritoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalPartnerTerritoryEntity))]
		public virtual EntityCollection<HospitalPartnerTerritoryEntity> HospitalPartnerTerritory
		{
			get
			{
				if(_hospitalPartnerTerritory==null)
				{
					_hospitalPartnerTerritory = new EntityCollection<HospitalPartnerTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerTerritoryEntityFactory)));
					_hospitalPartnerTerritory.SetContainingEntityInfo(this, "Territory");
				}
				return _hospitalPartnerTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingSourceTerritoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingSourceTerritoryEntity))]
		public virtual EntityCollection<MarketingSourceTerritoryEntity> MarketingSourceTerritory
		{
			get
			{
				if(_marketingSourceTerritory==null)
				{
					_marketingSourceTerritory = new EntityCollection<MarketingSourceTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingSourceTerritoryEntityFactory)));
					_marketingSourceTerritory.SetContainingEntityInfo(this, "Territory");
				}
				return _marketingSourceTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserTerritoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserTerritoryEntity))]
		public virtual EntityCollection<OrganizationRoleUserTerritoryEntity> OrganizationRoleUserTerritory
		{
			get
			{
				if(_organizationRoleUserTerritory==null)
				{
					_organizationRoleUserTerritory = new EntityCollection<OrganizationRoleUserTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserTerritoryEntityFactory)));
					_organizationRoleUserTerritory.SetContainingEntityInfo(this, "Territory");
				}
				return _organizationRoleUserTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodTerritoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodTerritoryEntity))]
		public virtual EntityCollection<PodTerritoryEntity> PodTerritory
		{
			get
			{
				if(_podTerritory==null)
				{
					_podTerritory = new EntityCollection<PodTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTerritoryEntityFactory)));
					_podTerritory.SetContainingEntityInfo(this, "Territory");
				}
				return _podTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TerritoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TerritoryEntity))]
		public virtual EntityCollection<TerritoryEntity> Territory_
		{
			get
			{
				if(_territory_==null)
				{
					_territory_ = new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory)));
					_territory_.SetContainingEntityInfo(this, "Territory");
				}
				return _territory_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TerritoryPackageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TerritoryPackageEntity))]
		public virtual EntityCollection<TerritoryPackageEntity> TerritoryPackage
		{
			get
			{
				if(_territoryPackage==null)
				{
					_territoryPackage = new EntityCollection<TerritoryPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryPackageEntityFactory)));
					_territoryPackage.SetContainingEntityInfo(this, "Territory");
				}
				return _territoryPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TerritoryZipEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TerritoryZipEntity))]
		public virtual EntityCollection<TerritoryZipEntity> TerritoryZip
		{
			get
			{
				if(_territoryZip==null)
				{
					_territoryZip = new EntityCollection<TerritoryZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryZipEntityFactory)));
					_territoryZip.SetContainingEntityInfo(this, "Territory");
				}
				return _territoryZip;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventPod
		{
			get
			{
				if(_eventsCollectionViaEventPod==null)
				{
					_eventsCollectionViaEventPod = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventPod.IsReadOnly=true;
				}
				return _eventsCollectionViaEventPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalPartnerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalPartnerEntity))]
		public virtual EntityCollection<HospitalPartnerEntity> HospitalPartnerCollectionViaHospitalPartnerTerritory
		{
			get
			{
				if(_hospitalPartnerCollectionViaHospitalPartnerTerritory==null)
				{
					_hospitalPartnerCollectionViaHospitalPartnerTerritory = new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory)));
					_hospitalPartnerCollectionViaHospitalPartnerTerritory.IsReadOnly=true;
				}
				return _hospitalPartnerCollectionViaHospitalPartnerTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingSourceEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingSourceEntity))]
		public virtual EntityCollection<MarketingSourceEntity> MarketingSourceCollectionViaMarketingSourceTerritory
		{
			get
			{
				if(_marketingSourceCollectionViaMarketingSourceTerritory==null)
				{
					_marketingSourceCollectionViaMarketingSourceTerritory = new EntityCollection<MarketingSourceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingSourceEntityFactory)));
					_marketingSourceCollectionViaMarketingSourceTerritory.IsReadOnly=true;
				}
				return _marketingSourceCollectionViaMarketingSourceTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTerritory
		{
			get
			{
				if(_organizationRoleUserCollectionViaTerritory==null)
				{
					_organizationRoleUserCollectionViaTerritory = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTerritory.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaOrganizationRoleUserTerritory
		{
			get
			{
				if(_organizationRoleUserCollectionViaOrganizationRoleUserTerritory==null)
				{
					_organizationRoleUserCollectionViaOrganizationRoleUserTerritory = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaOrganizationRoleUserTerritory.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaOrganizationRoleUserTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaTerritoryPackage
		{
			get
			{
				if(_packageCollectionViaTerritoryPackage==null)
				{
					_packageCollectionViaTerritoryPackage = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaTerritoryPackage.IsReadOnly=true;
				}
				return _packageCollectionViaTerritoryPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaEventPod
		{
			get
			{
				if(_podDetailsCollectionViaEventPod==null)
				{
					_podDetailsCollectionViaEventPod = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaEventPod.IsReadOnly=true;
				}
				return _podDetailsCollectionViaEventPod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaPodTerritory
		{
			get
			{
				if(_podDetailsCollectionViaPodTerritory==null)
				{
					_podDetailsCollectionViaPodTerritory = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaPodTerritory.IsReadOnly=true;
				}
				return _podDetailsCollectionViaPodTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ZipEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ZipEntity))]
		public virtual EntityCollection<ZipEntity> ZipCollectionViaTerritoryZip
		{
			get
			{
				if(_zipCollectionViaTerritoryZip==null)
				{
					_zipCollectionViaTerritoryZip = new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory)));
					_zipCollectionViaTerritoryZip.IsReadOnly=true;
				}
				return _zipCollectionViaTerritoryZip;
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Territory");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Territory");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TerritoryEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TerritoryEntity Territory
		{
			get
			{
				return _territory;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTerritory(value);
				}
				else
				{
					if(value==null)
					{
						if(_territory != null)
						{
							_territory.UnsetRelatedEntity(this, "Territory_");
						}
					}
					else
					{
						if(_territory!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Territory_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FranchiseeTerritoryEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FranchiseeTerritoryEntity FranchiseeTerritory
		{
			get
			{
				return _franchiseeTerritory;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFranchiseeTerritory(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Territory");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_franchiseeTerritory !=null);
						DesetupSyncFranchiseeTerritory(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("FranchiseeTerritory");
						}
					}
					else
					{
						if(_franchiseeTerritory!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Territory");
							SetupSyncFranchiseeTerritory(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.TerritoryEntity; }
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
