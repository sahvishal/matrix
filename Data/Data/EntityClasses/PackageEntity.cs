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
	/// Entity class which represents the entity 'Package'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PackageEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountPackageEntity> _accountPackage;
		private EntityCollection<EventCustomerPreApprovedPackageTestEntity> _eventCustomerPreApprovedPackageTest;
		private EntityCollection<EventPackageDetailsEntity> _eventPackageDetails;
		private EntityCollection<GiftCertificateEntity> _giftCertificate;
		private EntityCollection<HealthPlanRevenueItemEntity> _healthPlanRevenueItem;
		private EntityCollection<HospitalPartnerPackageEntity> _hospitalPartnerPackage;
		private EntityCollection<PackageSourceCodeDiscountEntity> _packageSourceCodeDiscount;
		private EntityCollection<PackageTestEntity> _packageTest;
		private EntityCollection<PodPackageEntity> _podPackage;
		private EntityCollection<PreApprovedPackageEntity> _preApprovedPackage;
		private EntityCollection<TerritoryPackageEntity> _territoryPackage;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountPackage;
		private EntityCollection<CouponsEntity> _couponsCollectionViaPackageSourceCodeDiscount;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerPreApprovedPackageTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventPackageDetails;
		private EntityCollection<GiftCertificateTypeEntity> _giftCertificateTypeCollectionViaGiftCertificate;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaEventPackageDetails;
		private EntityCollection<HealthPlanRevenueEntity> _healthPlanRevenueCollectionViaHealthPlanRevenueItem;
		private EntityCollection<HospitalPartnerEntity> _hospitalPartnerCollectionViaHospitalPartnerPackage;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventPackageDetails;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPreApprovedPackage;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaPodPackage;
		private EntityCollection<PodRoomEntity> _podRoomCollectionViaEventPackageDetails;
		private EntityCollection<TerritoryEntity> _territoryCollectionViaTerritoryPackage;
		private EntityCollection<TestEntity> _testCollectionViaHealthPlanRevenueItem;
		private EntityCollection<TestEntity> _testCollectionViaEventCustomerPreApprovedPackageTest;
		private EntityCollection<TestEntity> _testCollectionViaPackageTest;
		private FileEntity _file;
		private HafTemplateEntity _hafTemplate;
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
			/// <summary>Member name File</summary>
			public static readonly string File = "File";
			/// <summary>Member name HafTemplate</summary>
			public static readonly string HafTemplate = "HafTemplate";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name AccountPackage</summary>
			public static readonly string AccountPackage = "AccountPackage";
			/// <summary>Member name EventCustomerPreApprovedPackageTest</summary>
			public static readonly string EventCustomerPreApprovedPackageTest = "EventCustomerPreApprovedPackageTest";
			/// <summary>Member name EventPackageDetails</summary>
			public static readonly string EventPackageDetails = "EventPackageDetails";
			/// <summary>Member name GiftCertificate</summary>
			public static readonly string GiftCertificate = "GiftCertificate";
			/// <summary>Member name HealthPlanRevenueItem</summary>
			public static readonly string HealthPlanRevenueItem = "HealthPlanRevenueItem";
			/// <summary>Member name HospitalPartnerPackage</summary>
			public static readonly string HospitalPartnerPackage = "HospitalPartnerPackage";
			/// <summary>Member name PackageSourceCodeDiscount</summary>
			public static readonly string PackageSourceCodeDiscount = "PackageSourceCodeDiscount";
			/// <summary>Member name PackageTest</summary>
			public static readonly string PackageTest = "PackageTest";
			/// <summary>Member name PodPackage</summary>
			public static readonly string PodPackage = "PodPackage";
			/// <summary>Member name PreApprovedPackage</summary>
			public static readonly string PreApprovedPackage = "PreApprovedPackage";
			/// <summary>Member name TerritoryPackage</summary>
			public static readonly string TerritoryPackage = "TerritoryPackage";
			/// <summary>Member name AccountCollectionViaAccountPackage</summary>
			public static readonly string AccountCollectionViaAccountPackage = "AccountCollectionViaAccountPackage";
			/// <summary>Member name CouponsCollectionViaPackageSourceCodeDiscount</summary>
			public static readonly string CouponsCollectionViaPackageSourceCodeDiscount = "CouponsCollectionViaPackageSourceCodeDiscount";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerPreApprovedPackageTest</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerPreApprovedPackageTest = "EventCustomersCollectionViaEventCustomerPreApprovedPackageTest";
			/// <summary>Member name EventsCollectionViaEventPackageDetails</summary>
			public static readonly string EventsCollectionViaEventPackageDetails = "EventsCollectionViaEventPackageDetails";
			/// <summary>Member name GiftCertificateTypeCollectionViaGiftCertificate</summary>
			public static readonly string GiftCertificateTypeCollectionViaGiftCertificate = "GiftCertificateTypeCollectionViaGiftCertificate";
			/// <summary>Member name HafTemplateCollectionViaEventPackageDetails</summary>
			public static readonly string HafTemplateCollectionViaEventPackageDetails = "HafTemplateCollectionViaEventPackageDetails";
			/// <summary>Member name HealthPlanRevenueCollectionViaHealthPlanRevenueItem</summary>
			public static readonly string HealthPlanRevenueCollectionViaHealthPlanRevenueItem = "HealthPlanRevenueCollectionViaHealthPlanRevenueItem";
			/// <summary>Member name HospitalPartnerCollectionViaHospitalPartnerPackage</summary>
			public static readonly string HospitalPartnerCollectionViaHospitalPartnerPackage = "HospitalPartnerCollectionViaHospitalPartnerPackage";
			/// <summary>Member name LookupCollectionViaEventPackageDetails</summary>
			public static readonly string LookupCollectionViaEventPackageDetails = "LookupCollectionViaEventPackageDetails";
			/// <summary>Member name OrganizationRoleUserCollectionViaPreApprovedPackage</summary>
			public static readonly string OrganizationRoleUserCollectionViaPreApprovedPackage = "OrganizationRoleUserCollectionViaPreApprovedPackage";
			/// <summary>Member name PodDetailsCollectionViaPodPackage</summary>
			public static readonly string PodDetailsCollectionViaPodPackage = "PodDetailsCollectionViaPodPackage";
			/// <summary>Member name PodRoomCollectionViaEventPackageDetails</summary>
			public static readonly string PodRoomCollectionViaEventPackageDetails = "PodRoomCollectionViaEventPackageDetails";
			/// <summary>Member name TerritoryCollectionViaTerritoryPackage</summary>
			public static readonly string TerritoryCollectionViaTerritoryPackage = "TerritoryCollectionViaTerritoryPackage";
			/// <summary>Member name TestCollectionViaHealthPlanRevenueItem</summary>
			public static readonly string TestCollectionViaHealthPlanRevenueItem = "TestCollectionViaHealthPlanRevenueItem";
			/// <summary>Member name TestCollectionViaEventCustomerPreApprovedPackageTest</summary>
			public static readonly string TestCollectionViaEventCustomerPreApprovedPackageTest = "TestCollectionViaEventCustomerPreApprovedPackageTest";
			/// <summary>Member name TestCollectionViaPackageTest</summary>
			public static readonly string TestCollectionViaPackageTest = "TestCollectionViaPackageTest";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PackageEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PackageEntity():base("PackageEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PackageEntity(IEntityFields2 fields):base("PackageEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PackageEntity</param>
		public PackageEntity(IValidator validator):base("PackageEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="packageId">PK value for Package which data should be fetched into this Package object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PackageEntity(System.Int64 packageId):base("PackageEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PackageId = packageId;
		}

		/// <summary> CTor</summary>
		/// <param name="packageId">PK value for Package which data should be fetched into this Package object</param>
		/// <param name="validator">The custom validator object for this PackageEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PackageEntity(System.Int64 packageId, IValidator validator):base("PackageEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PackageId = packageId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PackageEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_accountPackage = (EntityCollection<AccountPackageEntity>)info.GetValue("_accountPackage", typeof(EntityCollection<AccountPackageEntity>));
				_eventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomerPreApprovedPackageTestEntity>)info.GetValue("_eventCustomerPreApprovedPackageTest", typeof(EntityCollection<EventCustomerPreApprovedPackageTestEntity>));
				_eventPackageDetails = (EntityCollection<EventPackageDetailsEntity>)info.GetValue("_eventPackageDetails", typeof(EntityCollection<EventPackageDetailsEntity>));
				_giftCertificate = (EntityCollection<GiftCertificateEntity>)info.GetValue("_giftCertificate", typeof(EntityCollection<GiftCertificateEntity>));
				_healthPlanRevenueItem = (EntityCollection<HealthPlanRevenueItemEntity>)info.GetValue("_healthPlanRevenueItem", typeof(EntityCollection<HealthPlanRevenueItemEntity>));
				_hospitalPartnerPackage = (EntityCollection<HospitalPartnerPackageEntity>)info.GetValue("_hospitalPartnerPackage", typeof(EntityCollection<HospitalPartnerPackageEntity>));
				_packageSourceCodeDiscount = (EntityCollection<PackageSourceCodeDiscountEntity>)info.GetValue("_packageSourceCodeDiscount", typeof(EntityCollection<PackageSourceCodeDiscountEntity>));
				_packageTest = (EntityCollection<PackageTestEntity>)info.GetValue("_packageTest", typeof(EntityCollection<PackageTestEntity>));
				_podPackage = (EntityCollection<PodPackageEntity>)info.GetValue("_podPackage", typeof(EntityCollection<PodPackageEntity>));
				_preApprovedPackage = (EntityCollection<PreApprovedPackageEntity>)info.GetValue("_preApprovedPackage", typeof(EntityCollection<PreApprovedPackageEntity>));
				_territoryPackage = (EntityCollection<TerritoryPackageEntity>)info.GetValue("_territoryPackage", typeof(EntityCollection<TerritoryPackageEntity>));
				_accountCollectionViaAccountPackage = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountPackage", typeof(EntityCollection<AccountEntity>));
				_couponsCollectionViaPackageSourceCodeDiscount = (EntityCollection<CouponsEntity>)info.GetValue("_couponsCollectionViaPackageSourceCodeDiscount", typeof(EntityCollection<CouponsEntity>));
				_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaEventPackageDetails = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventPackageDetails", typeof(EntityCollection<EventsEntity>));
				_giftCertificateTypeCollectionViaGiftCertificate = (EntityCollection<GiftCertificateTypeEntity>)info.GetValue("_giftCertificateTypeCollectionViaGiftCertificate", typeof(EntityCollection<GiftCertificateTypeEntity>));
				_hafTemplateCollectionViaEventPackageDetails = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaEventPackageDetails", typeof(EntityCollection<HafTemplateEntity>));
				_healthPlanRevenueCollectionViaHealthPlanRevenueItem = (EntityCollection<HealthPlanRevenueEntity>)info.GetValue("_healthPlanRevenueCollectionViaHealthPlanRevenueItem", typeof(EntityCollection<HealthPlanRevenueEntity>));
				_hospitalPartnerCollectionViaHospitalPartnerPackage = (EntityCollection<HospitalPartnerEntity>)info.GetValue("_hospitalPartnerCollectionViaHospitalPartnerPackage", typeof(EntityCollection<HospitalPartnerEntity>));
				_lookupCollectionViaEventPackageDetails = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventPackageDetails", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaPreApprovedPackage = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPreApprovedPackage", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_podDetailsCollectionViaPodPackage = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaPodPackage", typeof(EntityCollection<PodDetailsEntity>));
				_podRoomCollectionViaEventPackageDetails = (EntityCollection<PodRoomEntity>)info.GetValue("_podRoomCollectionViaEventPackageDetails", typeof(EntityCollection<PodRoomEntity>));
				_territoryCollectionViaTerritoryPackage = (EntityCollection<TerritoryEntity>)info.GetValue("_territoryCollectionViaTerritoryPackage", typeof(EntityCollection<TerritoryEntity>));
				_testCollectionViaHealthPlanRevenueItem = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaHealthPlanRevenueItem", typeof(EntityCollection<TestEntity>));
				_testCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventCustomerPreApprovedPackageTest", typeof(EntityCollection<TestEntity>));
				_testCollectionViaPackageTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaPackageTest", typeof(EntityCollection<TestEntity>));
				_file = (FileEntity)info.GetValue("_file", typeof(FileEntity));
				if(_file!=null)
				{
					_file.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hafTemplate = (HafTemplateEntity)info.GetValue("_hafTemplate", typeof(HafTemplateEntity));
				if(_hafTemplate!=null)
				{
					_hafTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PackageFieldIndex)fieldIndex)
			{
				case PackageFieldIndex.ForOrderDisplayFileId:
					DesetupSyncFile(true, false);
					break;
				case PackageFieldIndex.HafTemplateId:
					DesetupSyncHafTemplate(true, false);
					break;
				case PackageFieldIndex.Gender:
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
				case "File":
					this.File = (FileEntity)entity;
					break;
				case "HafTemplate":
					this.HafTemplate = (HafTemplateEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "AccountPackage":
					this.AccountPackage.Add((AccountPackageEntity)entity);
					break;
				case "EventCustomerPreApprovedPackageTest":
					this.EventCustomerPreApprovedPackageTest.Add((EventCustomerPreApprovedPackageTestEntity)entity);
					break;
				case "EventPackageDetails":
					this.EventPackageDetails.Add((EventPackageDetailsEntity)entity);
					break;
				case "GiftCertificate":
					this.GiftCertificate.Add((GiftCertificateEntity)entity);
					break;
				case "HealthPlanRevenueItem":
					this.HealthPlanRevenueItem.Add((HealthPlanRevenueItemEntity)entity);
					break;
				case "HospitalPartnerPackage":
					this.HospitalPartnerPackage.Add((HospitalPartnerPackageEntity)entity);
					break;
				case "PackageSourceCodeDiscount":
					this.PackageSourceCodeDiscount.Add((PackageSourceCodeDiscountEntity)entity);
					break;
				case "PackageTest":
					this.PackageTest.Add((PackageTestEntity)entity);
					break;
				case "PodPackage":
					this.PodPackage.Add((PodPackageEntity)entity);
					break;
				case "PreApprovedPackage":
					this.PreApprovedPackage.Add((PreApprovedPackageEntity)entity);
					break;
				case "TerritoryPackage":
					this.TerritoryPackage.Add((TerritoryPackageEntity)entity);
					break;
				case "AccountCollectionViaAccountPackage":
					this.AccountCollectionViaAccountPackage.IsReadOnly = false;
					this.AccountCollectionViaAccountPackage.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountPackage.IsReadOnly = true;
					break;
				case "CouponsCollectionViaPackageSourceCodeDiscount":
					this.CouponsCollectionViaPackageSourceCodeDiscount.IsReadOnly = false;
					this.CouponsCollectionViaPackageSourceCodeDiscount.Add((CouponsEntity)entity);
					this.CouponsCollectionViaPackageSourceCodeDiscount.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerPreApprovedPackageTest":
					this.EventCustomersCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerPreApprovedPackageTest.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventPackageDetails":
					this.EventsCollectionViaEventPackageDetails.IsReadOnly = false;
					this.EventsCollectionViaEventPackageDetails.Add((EventsEntity)entity);
					this.EventsCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "GiftCertificateTypeCollectionViaGiftCertificate":
					this.GiftCertificateTypeCollectionViaGiftCertificate.IsReadOnly = false;
					this.GiftCertificateTypeCollectionViaGiftCertificate.Add((GiftCertificateTypeEntity)entity);
					this.GiftCertificateTypeCollectionViaGiftCertificate.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaEventPackageDetails":
					this.HafTemplateCollectionViaEventPackageDetails.IsReadOnly = false;
					this.HafTemplateCollectionViaEventPackageDetails.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "HealthPlanRevenueCollectionViaHealthPlanRevenueItem":
					this.HealthPlanRevenueCollectionViaHealthPlanRevenueItem.IsReadOnly = false;
					this.HealthPlanRevenueCollectionViaHealthPlanRevenueItem.Add((HealthPlanRevenueEntity)entity);
					this.HealthPlanRevenueCollectionViaHealthPlanRevenueItem.IsReadOnly = true;
					break;
				case "HospitalPartnerCollectionViaHospitalPartnerPackage":
					this.HospitalPartnerCollectionViaHospitalPartnerPackage.IsReadOnly = false;
					this.HospitalPartnerCollectionViaHospitalPartnerPackage.Add((HospitalPartnerEntity)entity);
					this.HospitalPartnerCollectionViaHospitalPartnerPackage.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventPackageDetails":
					this.LookupCollectionViaEventPackageDetails.IsReadOnly = false;
					this.LookupCollectionViaEventPackageDetails.Add((LookupEntity)entity);
					this.LookupCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPreApprovedPackage":
					this.OrganizationRoleUserCollectionViaPreApprovedPackage.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPreApprovedPackage.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPreApprovedPackage.IsReadOnly = true;
					break;
				case "PodDetailsCollectionViaPodPackage":
					this.PodDetailsCollectionViaPodPackage.IsReadOnly = false;
					this.PodDetailsCollectionViaPodPackage.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaPodPackage.IsReadOnly = true;
					break;
				case "PodRoomCollectionViaEventPackageDetails":
					this.PodRoomCollectionViaEventPackageDetails.IsReadOnly = false;
					this.PodRoomCollectionViaEventPackageDetails.Add((PodRoomEntity)entity);
					this.PodRoomCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "TerritoryCollectionViaTerritoryPackage":
					this.TerritoryCollectionViaTerritoryPackage.IsReadOnly = false;
					this.TerritoryCollectionViaTerritoryPackage.Add((TerritoryEntity)entity);
					this.TerritoryCollectionViaTerritoryPackage.IsReadOnly = true;
					break;
				case "TestCollectionViaHealthPlanRevenueItem":
					this.TestCollectionViaHealthPlanRevenueItem.IsReadOnly = false;
					this.TestCollectionViaHealthPlanRevenueItem.Add((TestEntity)entity);
					this.TestCollectionViaHealthPlanRevenueItem.IsReadOnly = true;
					break;
				case "TestCollectionViaEventCustomerPreApprovedPackageTest":
					this.TestCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = false;
					this.TestCollectionViaEventCustomerPreApprovedPackageTest.Add((TestEntity)entity);
					this.TestCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = true;
					break;
				case "TestCollectionViaPackageTest":
					this.TestCollectionViaPackageTest.IsReadOnly = false;
					this.TestCollectionViaPackageTest.Add((TestEntity)entity);
					this.TestCollectionViaPackageTest.IsReadOnly = true;
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
			return PackageEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "File":
					toReturn.Add(PackageEntity.Relations.FileEntityUsingForOrderDisplayFileId);
					break;
				case "HafTemplate":
					toReturn.Add(PackageEntity.Relations.HafTemplateEntityUsingHafTemplateId);
					break;
				case "Lookup":
					toReturn.Add(PackageEntity.Relations.LookupEntityUsingGender);
					break;
				case "AccountPackage":
					toReturn.Add(PackageEntity.Relations.AccountPackageEntityUsingPackageId);
					break;
				case "EventCustomerPreApprovedPackageTest":
					toReturn.Add(PackageEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingPackageId);
					break;
				case "EventPackageDetails":
					toReturn.Add(PackageEntity.Relations.EventPackageDetailsEntityUsingPackageId);
					break;
				case "GiftCertificate":
					toReturn.Add(PackageEntity.Relations.GiftCertificateEntityUsingApplicablePackageId);
					break;
				case "HealthPlanRevenueItem":
					toReturn.Add(PackageEntity.Relations.HealthPlanRevenueItemEntityUsingPackageId);
					break;
				case "HospitalPartnerPackage":
					toReturn.Add(PackageEntity.Relations.HospitalPartnerPackageEntityUsingPackageId);
					break;
				case "PackageSourceCodeDiscount":
					toReturn.Add(PackageEntity.Relations.PackageSourceCodeDiscountEntityUsingPackageId);
					break;
				case "PackageTest":
					toReturn.Add(PackageEntity.Relations.PackageTestEntityUsingPackageId);
					break;
				case "PodPackage":
					toReturn.Add(PackageEntity.Relations.PodPackageEntityUsingPackageId);
					break;
				case "PreApprovedPackage":
					toReturn.Add(PackageEntity.Relations.PreApprovedPackageEntityUsingPackageId);
					break;
				case "TerritoryPackage":
					toReturn.Add(PackageEntity.Relations.TerritoryPackageEntityUsingPackageId);
					break;
				case "AccountCollectionViaAccountPackage":
					toReturn.Add(PackageEntity.Relations.AccountPackageEntityUsingPackageId, "PackageEntity__", "AccountPackage_", JoinHint.None);
					toReturn.Add(AccountPackageEntity.Relations.AccountEntityUsingAccountId, "AccountPackage_", string.Empty, JoinHint.None);
					break;
				case "CouponsCollectionViaPackageSourceCodeDiscount":
					toReturn.Add(PackageEntity.Relations.PackageSourceCodeDiscountEntityUsingPackageId, "PackageEntity__", "PackageSourceCodeDiscount_", JoinHint.None);
					toReturn.Add(PackageSourceCodeDiscountEntity.Relations.CouponsEntityUsingSourceCodeId, "PackageSourceCodeDiscount_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerPreApprovedPackageTest":
					toReturn.Add(PackageEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingPackageId, "PackageEntity__", "EventCustomerPreApprovedPackageTest_", JoinHint.None);
					toReturn.Add(EventCustomerPreApprovedPackageTestEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerPreApprovedPackageTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventPackageDetails":
					toReturn.Add(PackageEntity.Relations.EventPackageDetailsEntityUsingPackageId, "PackageEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.EventsEntityUsingEventId, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "GiftCertificateTypeCollectionViaGiftCertificate":
					toReturn.Add(PackageEntity.Relations.GiftCertificateEntityUsingApplicablePackageId, "PackageEntity__", "GiftCertificate_", JoinHint.None);
					toReturn.Add(GiftCertificateEntity.Relations.GiftCertificateTypeEntityUsingTypeId, "GiftCertificate_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaEventPackageDetails":
					toReturn.Add(PackageEntity.Relations.EventPackageDetailsEntityUsingPackageId, "PackageEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.HafTemplateEntityUsingHafTemplateId, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "HealthPlanRevenueCollectionViaHealthPlanRevenueItem":
					toReturn.Add(PackageEntity.Relations.HealthPlanRevenueItemEntityUsingPackageId, "PackageEntity__", "HealthPlanRevenueItem_", JoinHint.None);
					toReturn.Add(HealthPlanRevenueItemEntity.Relations.HealthPlanRevenueEntityUsingHealthPlanRevenueId, "HealthPlanRevenueItem_", string.Empty, JoinHint.None);
					break;
				case "HospitalPartnerCollectionViaHospitalPartnerPackage":
					toReturn.Add(PackageEntity.Relations.HospitalPartnerPackageEntityUsingPackageId, "PackageEntity__", "HospitalPartnerPackage_", JoinHint.None);
					toReturn.Add(HospitalPartnerPackageEntity.Relations.HospitalPartnerEntityUsingHospitalpartnerId, "HospitalPartnerPackage_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventPackageDetails":
					toReturn.Add(PackageEntity.Relations.EventPackageDetailsEntityUsingPackageId, "PackageEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.LookupEntityUsingGender, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPreApprovedPackage":
					toReturn.Add(PackageEntity.Relations.PreApprovedPackageEntityUsingPackageId, "PackageEntity__", "PreApprovedPackage_", JoinHint.None);
					toReturn.Add(PreApprovedPackageEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "PreApprovedPackage_", string.Empty, JoinHint.None);
					break;
				case "PodDetailsCollectionViaPodPackage":
					toReturn.Add(PackageEntity.Relations.PodPackageEntityUsingPackageId, "PackageEntity__", "PodPackage_", JoinHint.None);
					toReturn.Add(PodPackageEntity.Relations.PodDetailsEntityUsingPodId, "PodPackage_", string.Empty, JoinHint.None);
					break;
				case "PodRoomCollectionViaEventPackageDetails":
					toReturn.Add(PackageEntity.Relations.EventPackageDetailsEntityUsingPackageId, "PackageEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.PodRoomEntityUsingPodRoomId, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "TerritoryCollectionViaTerritoryPackage":
					toReturn.Add(PackageEntity.Relations.TerritoryPackageEntityUsingPackageId, "PackageEntity__", "TerritoryPackage_", JoinHint.None);
					toReturn.Add(TerritoryPackageEntity.Relations.TerritoryEntityUsingTerritoryId, "TerritoryPackage_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaHealthPlanRevenueItem":
					toReturn.Add(PackageEntity.Relations.HealthPlanRevenueItemEntityUsingPackageId, "PackageEntity__", "HealthPlanRevenueItem_", JoinHint.None);
					toReturn.Add(HealthPlanRevenueItemEntity.Relations.TestEntityUsingTestId, "HealthPlanRevenueItem_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventCustomerPreApprovedPackageTest":
					toReturn.Add(PackageEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingPackageId, "PackageEntity__", "EventCustomerPreApprovedPackageTest_", JoinHint.None);
					toReturn.Add(EventCustomerPreApprovedPackageTestEntity.Relations.TestEntityUsingTestId, "EventCustomerPreApprovedPackageTest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaPackageTest":
					toReturn.Add(PackageEntity.Relations.PackageTestEntityUsingPackageId, "PackageEntity__", "PackageTest_", JoinHint.None);
					toReturn.Add(PackageTestEntity.Relations.TestEntityUsingTestId, "PackageTest_", string.Empty, JoinHint.None);
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
				case "File":
					SetupSyncFile(relatedEntity);
					break;
				case "HafTemplate":
					SetupSyncHafTemplate(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "AccountPackage":
					this.AccountPackage.Add((AccountPackageEntity)relatedEntity);
					break;
				case "EventCustomerPreApprovedPackageTest":
					this.EventCustomerPreApprovedPackageTest.Add((EventCustomerPreApprovedPackageTestEntity)relatedEntity);
					break;
				case "EventPackageDetails":
					this.EventPackageDetails.Add((EventPackageDetailsEntity)relatedEntity);
					break;
				case "GiftCertificate":
					this.GiftCertificate.Add((GiftCertificateEntity)relatedEntity);
					break;
				case "HealthPlanRevenueItem":
					this.HealthPlanRevenueItem.Add((HealthPlanRevenueItemEntity)relatedEntity);
					break;
				case "HospitalPartnerPackage":
					this.HospitalPartnerPackage.Add((HospitalPartnerPackageEntity)relatedEntity);
					break;
				case "PackageSourceCodeDiscount":
					this.PackageSourceCodeDiscount.Add((PackageSourceCodeDiscountEntity)relatedEntity);
					break;
				case "PackageTest":
					this.PackageTest.Add((PackageTestEntity)relatedEntity);
					break;
				case "PodPackage":
					this.PodPackage.Add((PodPackageEntity)relatedEntity);
					break;
				case "PreApprovedPackage":
					this.PreApprovedPackage.Add((PreApprovedPackageEntity)relatedEntity);
					break;
				case "TerritoryPackage":
					this.TerritoryPackage.Add((TerritoryPackageEntity)relatedEntity);
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
				case "File":
					DesetupSyncFile(false, true);
					break;
				case "HafTemplate":
					DesetupSyncHafTemplate(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "AccountPackage":
					base.PerformRelatedEntityRemoval(this.AccountPackage, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerPreApprovedPackageTest":
					base.PerformRelatedEntityRemoval(this.EventCustomerPreApprovedPackageTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventPackageDetails":
					base.PerformRelatedEntityRemoval(this.EventPackageDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "GiftCertificate":
					base.PerformRelatedEntityRemoval(this.GiftCertificate, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanRevenueItem":
					base.PerformRelatedEntityRemoval(this.HealthPlanRevenueItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HospitalPartnerPackage":
					base.PerformRelatedEntityRemoval(this.HospitalPartnerPackage, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PackageSourceCodeDiscount":
					base.PerformRelatedEntityRemoval(this.PackageSourceCodeDiscount, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PackageTest":
					base.PerformRelatedEntityRemoval(this.PackageTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodPackage":
					base.PerformRelatedEntityRemoval(this.PodPackage, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreApprovedPackage":
					base.PerformRelatedEntityRemoval(this.PreApprovedPackage, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TerritoryPackage":
					base.PerformRelatedEntityRemoval(this.TerritoryPackage, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_file!=null)
			{
				toReturn.Add(_file);
			}
			if(_hafTemplate!=null)
			{
				toReturn.Add(_hafTemplate);
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
			toReturn.Add(this.AccountPackage);
			toReturn.Add(this.EventCustomerPreApprovedPackageTest);
			toReturn.Add(this.EventPackageDetails);
			toReturn.Add(this.GiftCertificate);
			toReturn.Add(this.HealthPlanRevenueItem);
			toReturn.Add(this.HospitalPartnerPackage);
			toReturn.Add(this.PackageSourceCodeDiscount);
			toReturn.Add(this.PackageTest);
			toReturn.Add(this.PodPackage);
			toReturn.Add(this.PreApprovedPackage);
			toReturn.Add(this.TerritoryPackage);

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
				info.AddValue("_accountPackage", ((_accountPackage!=null) && (_accountPackage.Count>0) && !this.MarkedForDeletion)?_accountPackage:null);
				info.AddValue("_eventCustomerPreApprovedPackageTest", ((_eventCustomerPreApprovedPackageTest!=null) && (_eventCustomerPreApprovedPackageTest.Count>0) && !this.MarkedForDeletion)?_eventCustomerPreApprovedPackageTest:null);
				info.AddValue("_eventPackageDetails", ((_eventPackageDetails!=null) && (_eventPackageDetails.Count>0) && !this.MarkedForDeletion)?_eventPackageDetails:null);
				info.AddValue("_giftCertificate", ((_giftCertificate!=null) && (_giftCertificate.Count>0) && !this.MarkedForDeletion)?_giftCertificate:null);
				info.AddValue("_healthPlanRevenueItem", ((_healthPlanRevenueItem!=null) && (_healthPlanRevenueItem.Count>0) && !this.MarkedForDeletion)?_healthPlanRevenueItem:null);
				info.AddValue("_hospitalPartnerPackage", ((_hospitalPartnerPackage!=null) && (_hospitalPartnerPackage.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerPackage:null);
				info.AddValue("_packageSourceCodeDiscount", ((_packageSourceCodeDiscount!=null) && (_packageSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_packageSourceCodeDiscount:null);
				info.AddValue("_packageTest", ((_packageTest!=null) && (_packageTest.Count>0) && !this.MarkedForDeletion)?_packageTest:null);
				info.AddValue("_podPackage", ((_podPackage!=null) && (_podPackage.Count>0) && !this.MarkedForDeletion)?_podPackage:null);
				info.AddValue("_preApprovedPackage", ((_preApprovedPackage!=null) && (_preApprovedPackage.Count>0) && !this.MarkedForDeletion)?_preApprovedPackage:null);
				info.AddValue("_territoryPackage", ((_territoryPackage!=null) && (_territoryPackage.Count>0) && !this.MarkedForDeletion)?_territoryPackage:null);
				info.AddValue("_accountCollectionViaAccountPackage", ((_accountCollectionViaAccountPackage!=null) && (_accountCollectionViaAccountPackage.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountPackage:null);
				info.AddValue("_couponsCollectionViaPackageSourceCodeDiscount", ((_couponsCollectionViaPackageSourceCodeDiscount!=null) && (_couponsCollectionViaPackageSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_couponsCollectionViaPackageSourceCodeDiscount:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest", ((_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest!=null) && (_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest:null);
				info.AddValue("_eventsCollectionViaEventPackageDetails", ((_eventsCollectionViaEventPackageDetails!=null) && (_eventsCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventPackageDetails:null);
				info.AddValue("_giftCertificateTypeCollectionViaGiftCertificate", ((_giftCertificateTypeCollectionViaGiftCertificate!=null) && (_giftCertificateTypeCollectionViaGiftCertificate.Count>0) && !this.MarkedForDeletion)?_giftCertificateTypeCollectionViaGiftCertificate:null);
				info.AddValue("_hafTemplateCollectionViaEventPackageDetails", ((_hafTemplateCollectionViaEventPackageDetails!=null) && (_hafTemplateCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaEventPackageDetails:null);
				info.AddValue("_healthPlanRevenueCollectionViaHealthPlanRevenueItem", ((_healthPlanRevenueCollectionViaHealthPlanRevenueItem!=null) && (_healthPlanRevenueCollectionViaHealthPlanRevenueItem.Count>0) && !this.MarkedForDeletion)?_healthPlanRevenueCollectionViaHealthPlanRevenueItem:null);
				info.AddValue("_hospitalPartnerCollectionViaHospitalPartnerPackage", ((_hospitalPartnerCollectionViaHospitalPartnerPackage!=null) && (_hospitalPartnerCollectionViaHospitalPartnerPackage.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerCollectionViaHospitalPartnerPackage:null);
				info.AddValue("_lookupCollectionViaEventPackageDetails", ((_lookupCollectionViaEventPackageDetails!=null) && (_lookupCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventPackageDetails:null);
				info.AddValue("_organizationRoleUserCollectionViaPreApprovedPackage", ((_organizationRoleUserCollectionViaPreApprovedPackage!=null) && (_organizationRoleUserCollectionViaPreApprovedPackage.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPreApprovedPackage:null);
				info.AddValue("_podDetailsCollectionViaPodPackage", ((_podDetailsCollectionViaPodPackage!=null) && (_podDetailsCollectionViaPodPackage.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaPodPackage:null);
				info.AddValue("_podRoomCollectionViaEventPackageDetails", ((_podRoomCollectionViaEventPackageDetails!=null) && (_podRoomCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_podRoomCollectionViaEventPackageDetails:null);
				info.AddValue("_territoryCollectionViaTerritoryPackage", ((_territoryCollectionViaTerritoryPackage!=null) && (_territoryCollectionViaTerritoryPackage.Count>0) && !this.MarkedForDeletion)?_territoryCollectionViaTerritoryPackage:null);
				info.AddValue("_testCollectionViaHealthPlanRevenueItem", ((_testCollectionViaHealthPlanRevenueItem!=null) && (_testCollectionViaHealthPlanRevenueItem.Count>0) && !this.MarkedForDeletion)?_testCollectionViaHealthPlanRevenueItem:null);
				info.AddValue("_testCollectionViaEventCustomerPreApprovedPackageTest", ((_testCollectionViaEventCustomerPreApprovedPackageTest!=null) && (_testCollectionViaEventCustomerPreApprovedPackageTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventCustomerPreApprovedPackageTest:null);
				info.AddValue("_testCollectionViaPackageTest", ((_testCollectionViaPackageTest!=null) && (_testCollectionViaPackageTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaPackageTest:null);
				info.AddValue("_file", (!this.MarkedForDeletion?_file:null));
				info.AddValue("_hafTemplate", (!this.MarkedForDeletion?_hafTemplate:null));
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
		public bool TestOriginalFieldValueForNull(PackageFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PackageFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PackageRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountPackage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountPackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerPreApprovedPackageTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerPreApprovedPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerPreApprovedPackageTestFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GiftCertificate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GiftCertificateFields.ApplicablePackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanRevenueItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanRevenueItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanRevenueItemFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartnerPackage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerPackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PackageSourceCodeDiscount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageSourceCodeDiscountFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PackageTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageTestFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodPackage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodPackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreApprovedPackage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreApprovedPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreApprovedPackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TerritoryPackage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritoryPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryPackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponsCollectionViaPackageSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CouponsCollectionViaPackageSourceCodeDiscount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerPreApprovedPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerPreApprovedPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GiftCertificateType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificateTypeCollectionViaGiftCertificate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("GiftCertificateTypeCollectionViaGiftCertificate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanRevenue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanRevenueCollectionViaHealthPlanRevenueItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HealthPlanRevenueCollectionViaHealthPlanRevenueItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartner' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerCollectionViaHospitalPartnerPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HospitalPartnerCollectionViaHospitalPartnerPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPreApprovedPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPreApprovedPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaPodPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaPodPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodRoom' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodRoomCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodRoomCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Territory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritoryCollectionViaTerritoryPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TerritoryCollectionViaTerritoryPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaHealthPlanRevenueItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaHealthPlanRevenueItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventCustomerPreApprovedPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventCustomerPreApprovedPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.PackageId, null, ComparisonOperator.Equal, this.PackageId, "PackageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.ForOrderDisplayFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HafTemplateId));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PackageEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._accountPackage);
			collectionsQueue.Enqueue(this._eventCustomerPreApprovedPackageTest);
			collectionsQueue.Enqueue(this._eventPackageDetails);
			collectionsQueue.Enqueue(this._giftCertificate);
			collectionsQueue.Enqueue(this._healthPlanRevenueItem);
			collectionsQueue.Enqueue(this._hospitalPartnerPackage);
			collectionsQueue.Enqueue(this._packageSourceCodeDiscount);
			collectionsQueue.Enqueue(this._packageTest);
			collectionsQueue.Enqueue(this._podPackage);
			collectionsQueue.Enqueue(this._preApprovedPackage);
			collectionsQueue.Enqueue(this._territoryPackage);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountPackage);
			collectionsQueue.Enqueue(this._couponsCollectionViaPackageSourceCodeDiscount);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerPreApprovedPackageTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._giftCertificateTypeCollectionViaGiftCertificate);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._healthPlanRevenueCollectionViaHealthPlanRevenueItem);
			collectionsQueue.Enqueue(this._hospitalPartnerCollectionViaHospitalPartnerPackage);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPreApprovedPackage);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaPodPackage);
			collectionsQueue.Enqueue(this._podRoomCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._territoryCollectionViaTerritoryPackage);
			collectionsQueue.Enqueue(this._testCollectionViaHealthPlanRevenueItem);
			collectionsQueue.Enqueue(this._testCollectionViaEventCustomerPreApprovedPackageTest);
			collectionsQueue.Enqueue(this._testCollectionViaPackageTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._accountPackage = (EntityCollection<AccountPackageEntity>) collectionsQueue.Dequeue();
			this._eventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomerPreApprovedPackageTestEntity>) collectionsQueue.Dequeue();
			this._eventPackageDetails = (EntityCollection<EventPackageDetailsEntity>) collectionsQueue.Dequeue();
			this._giftCertificate = (EntityCollection<GiftCertificateEntity>) collectionsQueue.Dequeue();
			this._healthPlanRevenueItem = (EntityCollection<HealthPlanRevenueItemEntity>) collectionsQueue.Dequeue();
			this._hospitalPartnerPackage = (EntityCollection<HospitalPartnerPackageEntity>) collectionsQueue.Dequeue();
			this._packageSourceCodeDiscount = (EntityCollection<PackageSourceCodeDiscountEntity>) collectionsQueue.Dequeue();
			this._packageTest = (EntityCollection<PackageTestEntity>) collectionsQueue.Dequeue();
			this._podPackage = (EntityCollection<PodPackageEntity>) collectionsQueue.Dequeue();
			this._preApprovedPackage = (EntityCollection<PreApprovedPackageEntity>) collectionsQueue.Dequeue();
			this._territoryPackage = (EntityCollection<TerritoryPackageEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountPackage = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._couponsCollectionViaPackageSourceCodeDiscount = (EntityCollection<CouponsEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventPackageDetails = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._giftCertificateTypeCollectionViaGiftCertificate = (EntityCollection<GiftCertificateTypeEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaEventPackageDetails = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._healthPlanRevenueCollectionViaHealthPlanRevenueItem = (EntityCollection<HealthPlanRevenueEntity>) collectionsQueue.Dequeue();
			this._hospitalPartnerCollectionViaHospitalPartnerPackage = (EntityCollection<HospitalPartnerEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventPackageDetails = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPreApprovedPackage = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaPodPackage = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
			this._podRoomCollectionViaEventPackageDetails = (EntityCollection<PodRoomEntity>) collectionsQueue.Dequeue();
			this._territoryCollectionViaTerritoryPackage = (EntityCollection<TerritoryEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaHealthPlanRevenueItem = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaPackageTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._accountPackage != null)
			{
				return true;
			}
			if (this._eventCustomerPreApprovedPackageTest != null)
			{
				return true;
			}
			if (this._eventPackageDetails != null)
			{
				return true;
			}
			if (this._giftCertificate != null)
			{
				return true;
			}
			if (this._healthPlanRevenueItem != null)
			{
				return true;
			}
			if (this._hospitalPartnerPackage != null)
			{
				return true;
			}
			if (this._packageSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._packageTest != null)
			{
				return true;
			}
			if (this._podPackage != null)
			{
				return true;
			}
			if (this._preApprovedPackage != null)
			{
				return true;
			}
			if (this._territoryPackage != null)
			{
				return true;
			}
			if (this._accountCollectionViaAccountPackage != null)
			{
				return true;
			}
			if (this._couponsCollectionViaPackageSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerPreApprovedPackageTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._giftCertificateTypeCollectionViaGiftCertificate != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._healthPlanRevenueCollectionViaHealthPlanRevenueItem != null)
			{
				return true;
			}
			if (this._hospitalPartnerCollectionViaHospitalPartnerPackage != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPreApprovedPackage != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaPodPackage != null)
			{
				return true;
			}
			if (this._podRoomCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._territoryCollectionViaTerritoryPackage != null)
			{
				return true;
			}
			if (this._testCollectionViaHealthPlanRevenueItem != null)
			{
				return true;
			}
			if (this._testCollectionViaEventCustomerPreApprovedPackageTest != null)
			{
				return true;
			}
			if (this._testCollectionViaPackageTest != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerPreApprovedPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedPackageTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanRevenueItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerPackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageSourceCodeDiscountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodPackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreApprovedPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreApprovedPackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TerritoryPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryPackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GiftCertificateTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanRevenueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
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
			toReturn.Add("File", _file);
			toReturn.Add("HafTemplate", _hafTemplate);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("AccountPackage", _accountPackage);
			toReturn.Add("EventCustomerPreApprovedPackageTest", _eventCustomerPreApprovedPackageTest);
			toReturn.Add("EventPackageDetails", _eventPackageDetails);
			toReturn.Add("GiftCertificate", _giftCertificate);
			toReturn.Add("HealthPlanRevenueItem", _healthPlanRevenueItem);
			toReturn.Add("HospitalPartnerPackage", _hospitalPartnerPackage);
			toReturn.Add("PackageSourceCodeDiscount", _packageSourceCodeDiscount);
			toReturn.Add("PackageTest", _packageTest);
			toReturn.Add("PodPackage", _podPackage);
			toReturn.Add("PreApprovedPackage", _preApprovedPackage);
			toReturn.Add("TerritoryPackage", _territoryPackage);
			toReturn.Add("AccountCollectionViaAccountPackage", _accountCollectionViaAccountPackage);
			toReturn.Add("CouponsCollectionViaPackageSourceCodeDiscount", _couponsCollectionViaPackageSourceCodeDiscount);
			toReturn.Add("EventCustomersCollectionViaEventCustomerPreApprovedPackageTest", _eventCustomersCollectionViaEventCustomerPreApprovedPackageTest);
			toReturn.Add("EventsCollectionViaEventPackageDetails", _eventsCollectionViaEventPackageDetails);
			toReturn.Add("GiftCertificateTypeCollectionViaGiftCertificate", _giftCertificateTypeCollectionViaGiftCertificate);
			toReturn.Add("HafTemplateCollectionViaEventPackageDetails", _hafTemplateCollectionViaEventPackageDetails);
			toReturn.Add("HealthPlanRevenueCollectionViaHealthPlanRevenueItem", _healthPlanRevenueCollectionViaHealthPlanRevenueItem);
			toReturn.Add("HospitalPartnerCollectionViaHospitalPartnerPackage", _hospitalPartnerCollectionViaHospitalPartnerPackage);
			toReturn.Add("LookupCollectionViaEventPackageDetails", _lookupCollectionViaEventPackageDetails);
			toReturn.Add("OrganizationRoleUserCollectionViaPreApprovedPackage", _organizationRoleUserCollectionViaPreApprovedPackage);
			toReturn.Add("PodDetailsCollectionViaPodPackage", _podDetailsCollectionViaPodPackage);
			toReturn.Add("PodRoomCollectionViaEventPackageDetails", _podRoomCollectionViaEventPackageDetails);
			toReturn.Add("TerritoryCollectionViaTerritoryPackage", _territoryCollectionViaTerritoryPackage);
			toReturn.Add("TestCollectionViaHealthPlanRevenueItem", _testCollectionViaHealthPlanRevenueItem);
			toReturn.Add("TestCollectionViaEventCustomerPreApprovedPackageTest", _testCollectionViaEventCustomerPreApprovedPackageTest);
			toReturn.Add("TestCollectionViaPackageTest", _testCollectionViaPackageTest);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_accountPackage!=null)
			{
				_accountPackage.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerPreApprovedPackageTest!=null)
			{
				_eventCustomerPreApprovedPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageDetails!=null)
			{
				_eventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_giftCertificate!=null)
			{
				_giftCertificate.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanRevenueItem!=null)
			{
				_healthPlanRevenueItem.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerPackage!=null)
			{
				_hospitalPartnerPackage.ActiveContext = base.ActiveContext;
			}
			if(_packageSourceCodeDiscount!=null)
			{
				_packageSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_packageTest!=null)
			{
				_packageTest.ActiveContext = base.ActiveContext;
			}
			if(_podPackage!=null)
			{
				_podPackage.ActiveContext = base.ActiveContext;
			}
			if(_preApprovedPackage!=null)
			{
				_preApprovedPackage.ActiveContext = base.ActiveContext;
			}
			if(_territoryPackage!=null)
			{
				_territoryPackage.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountPackage!=null)
			{
				_accountCollectionViaAccountPackage.ActiveContext = base.ActiveContext;
			}
			if(_couponsCollectionViaPackageSourceCodeDiscount!=null)
			{
				_couponsCollectionViaPackageSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest!=null)
			{
				_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventPackageDetails!=null)
			{
				_eventsCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_giftCertificateTypeCollectionViaGiftCertificate!=null)
			{
				_giftCertificateTypeCollectionViaGiftCertificate.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaEventPackageDetails!=null)
			{
				_hafTemplateCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanRevenueCollectionViaHealthPlanRevenueItem!=null)
			{
				_healthPlanRevenueCollectionViaHealthPlanRevenueItem.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerCollectionViaHospitalPartnerPackage!=null)
			{
				_hospitalPartnerCollectionViaHospitalPartnerPackage.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventPackageDetails!=null)
			{
				_lookupCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPreApprovedPackage!=null)
			{
				_organizationRoleUserCollectionViaPreApprovedPackage.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaPodPackage!=null)
			{
				_podDetailsCollectionViaPodPackage.ActiveContext = base.ActiveContext;
			}
			if(_podRoomCollectionViaEventPackageDetails!=null)
			{
				_podRoomCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_territoryCollectionViaTerritoryPackage!=null)
			{
				_territoryCollectionViaTerritoryPackage.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaHealthPlanRevenueItem!=null)
			{
				_testCollectionViaHealthPlanRevenueItem.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventCustomerPreApprovedPackageTest!=null)
			{
				_testCollectionViaEventCustomerPreApprovedPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaPackageTest!=null)
			{
				_testCollectionViaPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_file!=null)
			{
				_file.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplate!=null)
			{
				_hafTemplate.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_accountPackage = null;
			_eventCustomerPreApprovedPackageTest = null;
			_eventPackageDetails = null;
			_giftCertificate = null;
			_healthPlanRevenueItem = null;
			_hospitalPartnerPackage = null;
			_packageSourceCodeDiscount = null;
			_packageTest = null;
			_podPackage = null;
			_preApprovedPackage = null;
			_territoryPackage = null;
			_accountCollectionViaAccountPackage = null;
			_couponsCollectionViaPackageSourceCodeDiscount = null;
			_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest = null;
			_eventsCollectionViaEventPackageDetails = null;
			_giftCertificateTypeCollectionViaGiftCertificate = null;
			_hafTemplateCollectionViaEventPackageDetails = null;
			_healthPlanRevenueCollectionViaHealthPlanRevenueItem = null;
			_hospitalPartnerCollectionViaHospitalPartnerPackage = null;
			_lookupCollectionViaEventPackageDetails = null;
			_organizationRoleUserCollectionViaPreApprovedPackage = null;
			_podDetailsCollectionViaPodPackage = null;
			_podRoomCollectionViaEventPackageDetails = null;
			_territoryCollectionViaTerritoryPackage = null;
			_testCollectionViaHealthPlanRevenueItem = null;
			_testCollectionViaEventCustomerPreApprovedPackageTest = null;
			_testCollectionViaPackageTest = null;
			_file = null;
			_hafTemplate = null;
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

			_fieldsCustomProperties.Add("PackageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PackageName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Price", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PackageTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RelativeOrder", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DescriptiononPublicWebsite", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsSelectedByDefaultForEvent", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ForOrderDisplayFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PackageInfoUrl", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DescriptiononUpsellSection", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScreeningTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HafTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _file</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", PackageEntity.Relations.FileEntityUsingForOrderDisplayFileId, true, signalRelatedEntity, "Package", resetFKFields, new int[] { (int)PackageFieldIndex.ForOrderDisplayFileId } );		
			_file = null;
		}

		/// <summary> setups the sync logic for member _file</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile(IEntity2 relatedEntity)
		{
			if(_file!=relatedEntity)
			{
				DesetupSyncFile(true, true);
				_file = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", PackageEntity.Relations.FileEntityUsingForOrderDisplayFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _hafTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHafTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", PackageEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, signalRelatedEntity, "Package", resetFKFields, new int[] { (int)PackageFieldIndex.HafTemplateId } );		
			_hafTemplate = null;
		}

		/// <summary> setups the sync logic for member _hafTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHafTemplate(IEntity2 relatedEntity)
		{
			if(_hafTemplate!=relatedEntity)
			{
				DesetupSyncHafTemplate(true, true);
				_hafTemplate = (HafTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", PackageEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHafTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", PackageEntity.Relations.LookupEntityUsingGender, true, signalRelatedEntity, "Package", resetFKFields, new int[] { (int)PackageFieldIndex.Gender } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", PackageEntity.Relations.LookupEntityUsingGender, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this PackageEntity</param>
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
		public  static PackageRelations Relations
		{
			get	{ return new PackageRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountPackage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountPackage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountPackage")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.AccountPackageEntity, 0, null, null, null, null, "AccountPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerPreApprovedPackageTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerPreApprovedPackageTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerPreApprovedPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedPackageTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerPreApprovedPackageTest")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.EventCustomerPreApprovedPackageTestEntity, 0, null, null, null, null, "EventCustomerPreApprovedPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPackageDetails")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.EventPackageDetailsEntity, 0, null, null, null, null, "EventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory))),
					(IEntityRelation)GetRelationsForField("GiftCertificate")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.GiftCertificateEntity, 0, null, null, null, null, "GiftCertificate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanRevenueItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanRevenueItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanRevenueItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanRevenueItem")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.HealthPlanRevenueItemEntity, 0, null, null, null, null, "HealthPlanRevenueItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartnerPackage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartnerPackage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HospitalPartnerPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerPackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalPartnerPackage")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.HospitalPartnerPackageEntity, 0, null, null, null, null, "HospitalPartnerPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PackageSourceCodeDiscount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageSourceCodeDiscount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PackageSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageSourceCodeDiscountEntityFactory))),
					(IEntityRelation)GetRelationsForField("PackageSourceCodeDiscount")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.PackageSourceCodeDiscountEntity, 0, null, null, null, null, "PackageSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PackageTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PackageTest")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.PackageTestEntity, 0, null, null, null, null, "PackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodPackage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodPackage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodPackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodPackage")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.PodPackageEntity, 0, null, null, null, null, "PodPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreApprovedPackage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreApprovedPackage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreApprovedPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreApprovedPackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreApprovedPackage")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.PreApprovedPackageEntity, 0, null, null, null, null, "PreApprovedPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("TerritoryPackage")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.TerritoryPackageEntity, 0, null, null, null, null, "TerritoryPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountPackage
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.AccountPackageEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "AccountPackage_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountPackage"), null, "AccountCollectionViaAccountPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponsCollectionViaPackageSourceCodeDiscount
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.PackageSourceCodeDiscountEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "PackageSourceCodeDiscount_");
				return new PrefetchPathElement2(new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.CouponsEntity, 0, null, null, GetRelationsForField("CouponsCollectionViaPackageSourceCodeDiscount"), null, "CouponsCollectionViaPackageSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPreApprovedPackageTest_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerPreApprovedPackageTest"), null, "EventCustomersCollectionViaEventCustomerPreApprovedPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.EventPackageDetailsEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventPackageDetails"), null, "EventsCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificateType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificateTypeCollectionViaGiftCertificate
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.GiftCertificateEntityUsingApplicablePackageId;
				intermediateRelation.SetAliases(string.Empty, "GiftCertificate_");
				return new PrefetchPathElement2(new EntityCollection<GiftCertificateTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.GiftCertificateTypeEntity, 0, null, null, GetRelationsForField("GiftCertificateTypeCollectionViaGiftCertificate"), null, "GiftCertificateTypeCollectionViaGiftCertificate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.EventPackageDetailsEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaEventPackageDetails"), null, "HafTemplateCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanRevenue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanRevenueCollectionViaHealthPlanRevenueItem
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.HealthPlanRevenueItemEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanRevenueItem_");
				return new PrefetchPathElement2(new EntityCollection<HealthPlanRevenueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.HealthPlanRevenueEntity, 0, null, null, GetRelationsForField("HealthPlanRevenueCollectionViaHealthPlanRevenueItem"), null, "HealthPlanRevenueCollectionViaHealthPlanRevenueItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartner' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartnerCollectionViaHospitalPartnerPackage
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.HospitalPartnerPackageEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "HospitalPartnerPackage_");
				return new PrefetchPathElement2(new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.HospitalPartnerEntity, 0, null, null, GetRelationsForField("HospitalPartnerCollectionViaHospitalPartnerPackage"), null, "HospitalPartnerCollectionViaHospitalPartnerPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.EventPackageDetailsEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventPackageDetails"), null, "LookupCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPreApprovedPackage
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.PreApprovedPackageEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "PreApprovedPackage_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPreApprovedPackage"), null, "OrganizationRoleUserCollectionViaPreApprovedPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaPodPackage
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.PodPackageEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "PodPackage_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaPodPackage"), null, "PodDetailsCollectionViaPodPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodRoom' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodRoomCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.EventPackageDetailsEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.PodRoomEntity, 0, null, null, GetRelationsForField("PodRoomCollectionViaEventPackageDetails"), null, "PodRoomCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Territory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTerritoryCollectionViaTerritoryPackage
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.TerritoryPackageEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "TerritoryPackage_");
				return new PrefetchPathElement2(new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.TerritoryEntity, 0, null, null, GetRelationsForField("TerritoryCollectionViaTerritoryPackage"), null, "TerritoryCollectionViaTerritoryPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaHealthPlanRevenueItem
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.HealthPlanRevenueItemEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanRevenueItem_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaHealthPlanRevenueItem"), null, "TestCollectionViaHealthPlanRevenueItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPreApprovedPackageTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventCustomerPreApprovedPackageTest"), null, "TestCollectionViaEventCustomerPreApprovedPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = PackageEntity.Relations.PackageTestEntityUsingPackageId;
				intermediateRelation.SetAliases(string.Empty, "PackageTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaPackageTest"), null, "TestCollectionViaPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("HafTemplate")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, null, null, "HafTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.PackageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PackageEntity.CustomProperties;}
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
			get { return PackageEntity.FieldsCustomProperties;}
		}

		/// <summary> The PackageId property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."PackageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PackageId
		{
			get { return (System.Int64)GetValue((int)PackageFieldIndex.PackageId, true); }
			set	{ SetValue((int)PackageFieldIndex.PackageId, value); }
		}

		/// <summary> The PackageName property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."PackageName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PackageName
		{
			get { return (System.String)GetValue((int)PackageFieldIndex.PackageName, true); }
			set	{ SetValue((int)PackageFieldIndex.PackageName, value); }
		}

		/// <summary> The Description property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)PackageFieldIndex.Description, true); }
			set	{ SetValue((int)PackageFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PackageFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PackageFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PackageFieldIndex.DateModified, false); }
			set	{ SetValue((int)PackageFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)PackageFieldIndex.IsActive, true); }
			set	{ SetValue((int)PackageFieldIndex.IsActive, value); }
		}

		/// <summary> The Price property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."Price"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Price
		{
			get { return (System.Decimal)GetValue((int)PackageFieldIndex.Price, true); }
			set	{ SetValue((int)PackageFieldIndex.Price, value); }
		}

		/// <summary> The PackageTypeId property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."PackageTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PackageTypeId
		{
			get { return (System.Int64)GetValue((int)PackageFieldIndex.PackageTypeId, true); }
			set	{ SetValue((int)PackageFieldIndex.PackageTypeId, value); }
		}

		/// <summary> The RelativeOrder property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."RelativeOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 RelativeOrder
		{
			get { return (System.Int64)GetValue((int)PackageFieldIndex.RelativeOrder, true); }
			set	{ SetValue((int)PackageFieldIndex.RelativeOrder, value); }
		}

		/// <summary> The DescriptiononPublicWebsite property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."DescriptiononPublicWebsite"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean DescriptiononPublicWebsite
		{
			get { return (System.Boolean)GetValue((int)PackageFieldIndex.DescriptiononPublicWebsite, true); }
			set	{ SetValue((int)PackageFieldIndex.DescriptiononPublicWebsite, value); }
		}

		/// <summary> The IsSelectedByDefaultForEvent property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."IsSelectedByDefaultForEvent"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsSelectedByDefaultForEvent
		{
			get { return (System.Boolean)GetValue((int)PackageFieldIndex.IsSelectedByDefaultForEvent, true); }
			set	{ SetValue((int)PackageFieldIndex.IsSelectedByDefaultForEvent, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)PackageFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)PackageFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The UpdatedByOrgRoleUserId property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."UpdatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UpdatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PackageFieldIndex.UpdatedByOrgRoleUserId, false); }
			set	{ SetValue((int)PackageFieldIndex.UpdatedByOrgRoleUserId, value); }
		}

		/// <summary> The ForOrderDisplayFileId property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."ForOrderDisplayFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ForOrderDisplayFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PackageFieldIndex.ForOrderDisplayFileId, false); }
			set	{ SetValue((int)PackageFieldIndex.ForOrderDisplayFileId, value); }
		}

		/// <summary> The PackageInfoUrl property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."PackageInfoUrl"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PackageInfoUrl
		{
			get { return (System.String)GetValue((int)PackageFieldIndex.PackageInfoUrl, true); }
			set	{ SetValue((int)PackageFieldIndex.PackageInfoUrl, value); }
		}

		/// <summary> The DescriptiononUpsellSection property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."DescriptiononUpsellSection"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DescriptiononUpsellSection
		{
			get { return (System.String)GetValue((int)PackageFieldIndex.DescriptiononUpsellSection, true); }
			set	{ SetValue((int)PackageFieldIndex.DescriptiononUpsellSection, value); }
		}

		/// <summary> The ScreeningTime property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."ScreeningTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ScreeningTime
		{
			get { return (Nullable<System.Int32>)GetValue((int)PackageFieldIndex.ScreeningTime, false); }
			set	{ SetValue((int)PackageFieldIndex.ScreeningTime, value); }
		}

		/// <summary> The HafTemplateId property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."HAFTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HafTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PackageFieldIndex.HafTemplateId, false); }
			set	{ SetValue((int)PackageFieldIndex.HafTemplateId, value); }
		}

		/// <summary> The Gender property of the Entity Package<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPackage"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Gender
		{
			get { return (System.Int64)GetValue((int)PackageFieldIndex.Gender, true); }
			set	{ SetValue((int)PackageFieldIndex.Gender, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountPackageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountPackageEntity))]
		public virtual EntityCollection<AccountPackageEntity> AccountPackage
		{
			get
			{
				if(_accountPackage==null)
				{
					_accountPackage = new EntityCollection<AccountPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPackageEntityFactory)));
					_accountPackage.SetContainingEntityInfo(this, "Package");
				}
				return _accountPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerPreApprovedPackageTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerPreApprovedPackageTestEntity))]
		public virtual EntityCollection<EventCustomerPreApprovedPackageTestEntity> EventCustomerPreApprovedPackageTest
		{
			get
			{
				if(_eventCustomerPreApprovedPackageTest==null)
				{
					_eventCustomerPreApprovedPackageTest = new EntityCollection<EventCustomerPreApprovedPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedPackageTestEntityFactory)));
					_eventCustomerPreApprovedPackageTest.SetContainingEntityInfo(this, "Package");
				}
				return _eventCustomerPreApprovedPackageTest;
			}
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
					_eventPackageDetails.SetContainingEntityInfo(this, "Package");
				}
				return _eventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GiftCertificateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GiftCertificateEntity))]
		public virtual EntityCollection<GiftCertificateEntity> GiftCertificate
		{
			get
			{
				if(_giftCertificate==null)
				{
					_giftCertificate = new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory)));
					_giftCertificate.SetContainingEntityInfo(this, "Package");
				}
				return _giftCertificate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanRevenueItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanRevenueItemEntity))]
		public virtual EntityCollection<HealthPlanRevenueItemEntity> HealthPlanRevenueItem
		{
			get
			{
				if(_healthPlanRevenueItem==null)
				{
					_healthPlanRevenueItem = new EntityCollection<HealthPlanRevenueItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueItemEntityFactory)));
					_healthPlanRevenueItem.SetContainingEntityInfo(this, "Package");
				}
				return _healthPlanRevenueItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalPartnerPackageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalPartnerPackageEntity))]
		public virtual EntityCollection<HospitalPartnerPackageEntity> HospitalPartnerPackage
		{
			get
			{
				if(_hospitalPartnerPackage==null)
				{
					_hospitalPartnerPackage = new EntityCollection<HospitalPartnerPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerPackageEntityFactory)));
					_hospitalPartnerPackage.SetContainingEntityInfo(this, "Package");
				}
				return _hospitalPartnerPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageSourceCodeDiscountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageSourceCodeDiscountEntity))]
		public virtual EntityCollection<PackageSourceCodeDiscountEntity> PackageSourceCodeDiscount
		{
			get
			{
				if(_packageSourceCodeDiscount==null)
				{
					_packageSourceCodeDiscount = new EntityCollection<PackageSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageSourceCodeDiscountEntityFactory)));
					_packageSourceCodeDiscount.SetContainingEntityInfo(this, "Package");
				}
				return _packageSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageTestEntity))]
		public virtual EntityCollection<PackageTestEntity> PackageTest
		{
			get
			{
				if(_packageTest==null)
				{
					_packageTest = new EntityCollection<PackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageTestEntityFactory)));
					_packageTest.SetContainingEntityInfo(this, "Package");
				}
				return _packageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodPackageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodPackageEntity))]
		public virtual EntityCollection<PodPackageEntity> PodPackage
		{
			get
			{
				if(_podPackage==null)
				{
					_podPackage = new EntityCollection<PodPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodPackageEntityFactory)));
					_podPackage.SetContainingEntityInfo(this, "Package");
				}
				return _podPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreApprovedPackageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreApprovedPackageEntity))]
		public virtual EntityCollection<PreApprovedPackageEntity> PreApprovedPackage
		{
			get
			{
				if(_preApprovedPackage==null)
				{
					_preApprovedPackage = new EntityCollection<PreApprovedPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreApprovedPackageEntityFactory)));
					_preApprovedPackage.SetContainingEntityInfo(this, "Package");
				}
				return _preApprovedPackage;
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
					_territoryPackage.SetContainingEntityInfo(this, "Package");
				}
				return _territoryPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountPackage
		{
			get
			{
				if(_accountCollectionViaAccountPackage==null)
				{
					_accountCollectionViaAccountPackage = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountPackage.IsReadOnly=true;
				}
				return _accountCollectionViaAccountPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouponsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouponsEntity))]
		public virtual EntityCollection<CouponsEntity> CouponsCollectionViaPackageSourceCodeDiscount
		{
			get
			{
				if(_couponsCollectionViaPackageSourceCodeDiscount==null)
				{
					_couponsCollectionViaPackageSourceCodeDiscount = new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory)));
					_couponsCollectionViaPackageSourceCodeDiscount.IsReadOnly=true;
				}
				return _couponsCollectionViaPackageSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest==null)
				{
					_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerPreApprovedPackageTest;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'GiftCertificateTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GiftCertificateTypeEntity))]
		public virtual EntityCollection<GiftCertificateTypeEntity> GiftCertificateTypeCollectionViaGiftCertificate
		{
			get
			{
				if(_giftCertificateTypeCollectionViaGiftCertificate==null)
				{
					_giftCertificateTypeCollectionViaGiftCertificate = new EntityCollection<GiftCertificateTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateTypeEntityFactory)));
					_giftCertificateTypeCollectionViaGiftCertificate.IsReadOnly=true;
				}
				return _giftCertificateTypeCollectionViaGiftCertificate;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanRevenueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanRevenueEntity))]
		public virtual EntityCollection<HealthPlanRevenueEntity> HealthPlanRevenueCollectionViaHealthPlanRevenueItem
		{
			get
			{
				if(_healthPlanRevenueCollectionViaHealthPlanRevenueItem==null)
				{
					_healthPlanRevenueCollectionViaHealthPlanRevenueItem = new EntityCollection<HealthPlanRevenueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueEntityFactory)));
					_healthPlanRevenueCollectionViaHealthPlanRevenueItem.IsReadOnly=true;
				}
				return _healthPlanRevenueCollectionViaHealthPlanRevenueItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalPartnerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalPartnerEntity))]
		public virtual EntityCollection<HospitalPartnerEntity> HospitalPartnerCollectionViaHospitalPartnerPackage
		{
			get
			{
				if(_hospitalPartnerCollectionViaHospitalPartnerPackage==null)
				{
					_hospitalPartnerCollectionViaHospitalPartnerPackage = new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory)));
					_hospitalPartnerCollectionViaHospitalPartnerPackage.IsReadOnly=true;
				}
				return _hospitalPartnerCollectionViaHospitalPartnerPackage;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPreApprovedPackage
		{
			get
			{
				if(_organizationRoleUserCollectionViaPreApprovedPackage==null)
				{
					_organizationRoleUserCollectionViaPreApprovedPackage = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPreApprovedPackage.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPreApprovedPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaPodPackage
		{
			get
			{
				if(_podDetailsCollectionViaPodPackage==null)
				{
					_podDetailsCollectionViaPodPackage = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaPodPackage.IsReadOnly=true;
				}
				return _podDetailsCollectionViaPodPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodRoomEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodRoomEntity))]
		public virtual EntityCollection<PodRoomEntity> PodRoomCollectionViaEventPackageDetails
		{
			get
			{
				if(_podRoomCollectionViaEventPackageDetails==null)
				{
					_podRoomCollectionViaEventPackageDetails = new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory)));
					_podRoomCollectionViaEventPackageDetails.IsReadOnly=true;
				}
				return _podRoomCollectionViaEventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TerritoryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TerritoryEntity))]
		public virtual EntityCollection<TerritoryEntity> TerritoryCollectionViaTerritoryPackage
		{
			get
			{
				if(_territoryCollectionViaTerritoryPackage==null)
				{
					_territoryCollectionViaTerritoryPackage = new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory)));
					_territoryCollectionViaTerritoryPackage.IsReadOnly=true;
				}
				return _territoryCollectionViaTerritoryPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaHealthPlanRevenueItem
		{
			get
			{
				if(_testCollectionViaHealthPlanRevenueItem==null)
				{
					_testCollectionViaHealthPlanRevenueItem = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaHealthPlanRevenueItem.IsReadOnly=true;
				}
				return _testCollectionViaHealthPlanRevenueItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				if(_testCollectionViaEventCustomerPreApprovedPackageTest==null)
				{
					_testCollectionViaEventCustomerPreApprovedPackageTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly=true;
				}
				return _testCollectionViaEventCustomerPreApprovedPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaPackageTest
		{
			get
			{
				if(_testCollectionViaPackageTest==null)
				{
					_testCollectionViaPackageTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaPackageTest.IsReadOnly=true;
				}
				return _testCollectionViaPackageTest;
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File
		{
			get
			{
				return _file;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile(value);
				}
				else
				{
					if(value==null)
					{
						if(_file != null)
						{
							_file.UnsetRelatedEntity(this, "Package");
						}
					}
					else
					{
						if(_file!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Package");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HafTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HafTemplateEntity HafTemplate
		{
			get
			{
				return _hafTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHafTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_hafTemplate != null)
						{
							_hafTemplate.UnsetRelatedEntity(this, "Package");
						}
					}
					else
					{
						if(_hafTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Package");
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
							_lookup.UnsetRelatedEntity(this, "Package");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Package");
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
			get { return (int)Falcon.Data.EntityType.PackageEntity; }
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
