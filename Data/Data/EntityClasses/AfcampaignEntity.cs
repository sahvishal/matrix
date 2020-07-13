///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:43
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
	/// Entity class which represents the entity 'Afcampaign'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AfcampaignEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AfAdvertisingCommissionEntity> _afAdvertisingCommission;
		private EntityCollection<AfaffiliateCampaignEntity> _afaffiliateCampaign;
		private EntityCollection<AfaffiliateCampaignMarketingMaterialEntity> _afaffiliateCampaignMarketingMaterial;
		private EntityCollection<AfcampaignSubAdvocateEntity> _afcampaignSubAdvocate;
		private EntityCollection<AfimpressionEntity> _afimpression;
		private EntityCollection<AfimpressionLogEntity> _afimpressionLog;
		private EntityCollection<CampaignTagMappingEntity> _campaignTagMapping;
		private EntityCollection<ClickLogEntity> _clickLog;
		private EntityCollection<CustomCampaignContentEntity> _customCampaignContent;
		private EntityCollection<EventCampaignDetailsEntity> _eventCampaignDetails;
		private EntityCollection<AfaffiliateCampaignMarketingMaterialEntity> _afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog;
		private EntityCollection<AffiliateProfileEntity> _affiliateProfileCollectionViaAfcampaignSubAdvocate;
		private EntityCollection<AffiliateProfileEntity> _affiliateProfileCollectionViaAfaffiliateCampaign;
		private EntityCollection<AfmarketingMaterialEntity> _afmarketingMaterialCollectionViaCustomCampaignContent;
		private EntityCollection<AfmarketingMaterialEntity> _afmarketingMaterialCollectionViaClickLog;
		private EntityCollection<AfmarketingMaterialEntity> _afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial;
		private EntityCollection<AfmarketingMaterialEntity> _afmarketingMaterialCollectionViaAfAdvertisingCommission;
		private EntityCollection<CampaignTagEntity> _campaignTagCollectionViaCampaignTagMapping;
		private AfadvertiserEntity _afadvertiser;
		private OrganizationRoleUserEntity _organizationRoleUser_;
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
			/// <summary>Member name Afadvertiser</summary>
			public static readonly string Afadvertiser = "Afadvertiser";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name AfAdvertisingCommission</summary>
			public static readonly string AfAdvertisingCommission = "AfAdvertisingCommission";
			/// <summary>Member name AfaffiliateCampaign</summary>
			public static readonly string AfaffiliateCampaign = "AfaffiliateCampaign";
			/// <summary>Member name AfaffiliateCampaignMarketingMaterial</summary>
			public static readonly string AfaffiliateCampaignMarketingMaterial = "AfaffiliateCampaignMarketingMaterial";
			/// <summary>Member name AfcampaignSubAdvocate</summary>
			public static readonly string AfcampaignSubAdvocate = "AfcampaignSubAdvocate";
			/// <summary>Member name Afimpression</summary>
			public static readonly string Afimpression = "Afimpression";
			/// <summary>Member name AfimpressionLog</summary>
			public static readonly string AfimpressionLog = "AfimpressionLog";
			/// <summary>Member name CampaignTagMapping</summary>
			public static readonly string CampaignTagMapping = "CampaignTagMapping";
			/// <summary>Member name ClickLog</summary>
			public static readonly string ClickLog = "ClickLog";
			/// <summary>Member name CustomCampaignContent</summary>
			public static readonly string CustomCampaignContent = "CustomCampaignContent";
			/// <summary>Member name EventCampaignDetails</summary>
			public static readonly string EventCampaignDetails = "EventCampaignDetails";
			/// <summary>Member name AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog</summary>
			public static readonly string AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog = "AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog";
			/// <summary>Member name AffiliateProfileCollectionViaAfcampaignSubAdvocate</summary>
			public static readonly string AffiliateProfileCollectionViaAfcampaignSubAdvocate = "AffiliateProfileCollectionViaAfcampaignSubAdvocate";
			/// <summary>Member name AffiliateProfileCollectionViaAfaffiliateCampaign</summary>
			public static readonly string AffiliateProfileCollectionViaAfaffiliateCampaign = "AffiliateProfileCollectionViaAfaffiliateCampaign";
			/// <summary>Member name AfmarketingMaterialCollectionViaCustomCampaignContent</summary>
			public static readonly string AfmarketingMaterialCollectionViaCustomCampaignContent = "AfmarketingMaterialCollectionViaCustomCampaignContent";
			/// <summary>Member name AfmarketingMaterialCollectionViaClickLog</summary>
			public static readonly string AfmarketingMaterialCollectionViaClickLog = "AfmarketingMaterialCollectionViaClickLog";
			/// <summary>Member name AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial</summary>
			public static readonly string AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial = "AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial";
			/// <summary>Member name AfmarketingMaterialCollectionViaAfAdvertisingCommission</summary>
			public static readonly string AfmarketingMaterialCollectionViaAfAdvertisingCommission = "AfmarketingMaterialCollectionViaAfAdvertisingCommission";
			/// <summary>Member name CampaignTagCollectionViaCampaignTagMapping</summary>
			public static readonly string CampaignTagCollectionViaCampaignTagMapping = "CampaignTagCollectionViaCampaignTagMapping";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AfcampaignEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AfcampaignEntity():base("AfcampaignEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AfcampaignEntity(IEntityFields2 fields):base("AfcampaignEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AfcampaignEntity</param>
		public AfcampaignEntity(IValidator validator):base("AfcampaignEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="campaignId">PK value for Afcampaign which data should be fetched into this Afcampaign object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfcampaignEntity(System.Int64 campaignId):base("AfcampaignEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CampaignId = campaignId;
		}

		/// <summary> CTor</summary>
		/// <param name="campaignId">PK value for Afcampaign which data should be fetched into this Afcampaign object</param>
		/// <param name="validator">The custom validator object for this AfcampaignEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfcampaignEntity(System.Int64 campaignId, IValidator validator):base("AfcampaignEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CampaignId = campaignId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AfcampaignEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_afAdvertisingCommission = (EntityCollection<AfAdvertisingCommissionEntity>)info.GetValue("_afAdvertisingCommission", typeof(EntityCollection<AfAdvertisingCommissionEntity>));
				_afaffiliateCampaign = (EntityCollection<AfaffiliateCampaignEntity>)info.GetValue("_afaffiliateCampaign", typeof(EntityCollection<AfaffiliateCampaignEntity>));
				_afaffiliateCampaignMarketingMaterial = (EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>)info.GetValue("_afaffiliateCampaignMarketingMaterial", typeof(EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>));
				_afcampaignSubAdvocate = (EntityCollection<AfcampaignSubAdvocateEntity>)info.GetValue("_afcampaignSubAdvocate", typeof(EntityCollection<AfcampaignSubAdvocateEntity>));
				_afimpression = (EntityCollection<AfimpressionEntity>)info.GetValue("_afimpression", typeof(EntityCollection<AfimpressionEntity>));
				_afimpressionLog = (EntityCollection<AfimpressionLogEntity>)info.GetValue("_afimpressionLog", typeof(EntityCollection<AfimpressionLogEntity>));
				_campaignTagMapping = (EntityCollection<CampaignTagMappingEntity>)info.GetValue("_campaignTagMapping", typeof(EntityCollection<CampaignTagMappingEntity>));
				_clickLog = (EntityCollection<ClickLogEntity>)info.GetValue("_clickLog", typeof(EntityCollection<ClickLogEntity>));
				_customCampaignContent = (EntityCollection<CustomCampaignContentEntity>)info.GetValue("_customCampaignContent", typeof(EntityCollection<CustomCampaignContentEntity>));
				_eventCampaignDetails = (EntityCollection<EventCampaignDetailsEntity>)info.GetValue("_eventCampaignDetails", typeof(EntityCollection<EventCampaignDetailsEntity>));
				_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog = (EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>)info.GetValue("_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog", typeof(EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>));
				_affiliateProfileCollectionViaAfcampaignSubAdvocate = (EntityCollection<AffiliateProfileEntity>)info.GetValue("_affiliateProfileCollectionViaAfcampaignSubAdvocate", typeof(EntityCollection<AffiliateProfileEntity>));
				_affiliateProfileCollectionViaAfaffiliateCampaign = (EntityCollection<AffiliateProfileEntity>)info.GetValue("_affiliateProfileCollectionViaAfaffiliateCampaign", typeof(EntityCollection<AffiliateProfileEntity>));
				_afmarketingMaterialCollectionViaCustomCampaignContent = (EntityCollection<AfmarketingMaterialEntity>)info.GetValue("_afmarketingMaterialCollectionViaCustomCampaignContent", typeof(EntityCollection<AfmarketingMaterialEntity>));
				_afmarketingMaterialCollectionViaClickLog = (EntityCollection<AfmarketingMaterialEntity>)info.GetValue("_afmarketingMaterialCollectionViaClickLog", typeof(EntityCollection<AfmarketingMaterialEntity>));
				_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial = (EntityCollection<AfmarketingMaterialEntity>)info.GetValue("_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial", typeof(EntityCollection<AfmarketingMaterialEntity>));
				_afmarketingMaterialCollectionViaAfAdvertisingCommission = (EntityCollection<AfmarketingMaterialEntity>)info.GetValue("_afmarketingMaterialCollectionViaAfAdvertisingCommission", typeof(EntityCollection<AfmarketingMaterialEntity>));
				_campaignTagCollectionViaCampaignTagMapping = (EntityCollection<CampaignTagEntity>)info.GetValue("_campaignTagCollectionViaCampaignTagMapping", typeof(EntityCollection<CampaignTagEntity>));
				_afadvertiser = (AfadvertiserEntity)info.GetValue("_afadvertiser", typeof(AfadvertiserEntity));
				if(_afadvertiser!=null)
				{
					_afadvertiser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AfcampaignFieldIndex)fieldIndex)
			{
				case AfcampaignFieldIndex.AdvertiserId:
					DesetupSyncAfadvertiser(true, false);
					break;
				case AfcampaignFieldIndex.RoleId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case AfcampaignFieldIndex.ShellId:
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
				case "Afadvertiser":
					this.Afadvertiser = (AfadvertiserEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "AfAdvertisingCommission":
					this.AfAdvertisingCommission.Add((AfAdvertisingCommissionEntity)entity);
					break;
				case "AfaffiliateCampaign":
					this.AfaffiliateCampaign.Add((AfaffiliateCampaignEntity)entity);
					break;
				case "AfaffiliateCampaignMarketingMaterial":
					this.AfaffiliateCampaignMarketingMaterial.Add((AfaffiliateCampaignMarketingMaterialEntity)entity);
					break;
				case "AfcampaignSubAdvocate":
					this.AfcampaignSubAdvocate.Add((AfcampaignSubAdvocateEntity)entity);
					break;
				case "Afimpression":
					this.Afimpression.Add((AfimpressionEntity)entity);
					break;
				case "AfimpressionLog":
					this.AfimpressionLog.Add((AfimpressionLogEntity)entity);
					break;
				case "CampaignTagMapping":
					this.CampaignTagMapping.Add((CampaignTagMappingEntity)entity);
					break;
				case "ClickLog":
					this.ClickLog.Add((ClickLogEntity)entity);
					break;
				case "CustomCampaignContent":
					this.CustomCampaignContent.Add((CustomCampaignContentEntity)entity);
					break;
				case "EventCampaignDetails":
					this.EventCampaignDetails.Add((EventCampaignDetailsEntity)entity);
					break;
				case "AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog":
					this.AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog.IsReadOnly = false;
					this.AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog.Add((AfaffiliateCampaignMarketingMaterialEntity)entity);
					this.AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog.IsReadOnly = true;
					break;
				case "AffiliateProfileCollectionViaAfcampaignSubAdvocate":
					this.AffiliateProfileCollectionViaAfcampaignSubAdvocate.IsReadOnly = false;
					this.AffiliateProfileCollectionViaAfcampaignSubAdvocate.Add((AffiliateProfileEntity)entity);
					this.AffiliateProfileCollectionViaAfcampaignSubAdvocate.IsReadOnly = true;
					break;
				case "AffiliateProfileCollectionViaAfaffiliateCampaign":
					this.AffiliateProfileCollectionViaAfaffiliateCampaign.IsReadOnly = false;
					this.AffiliateProfileCollectionViaAfaffiliateCampaign.Add((AffiliateProfileEntity)entity);
					this.AffiliateProfileCollectionViaAfaffiliateCampaign.IsReadOnly = true;
					break;
				case "AfmarketingMaterialCollectionViaCustomCampaignContent":
					this.AfmarketingMaterialCollectionViaCustomCampaignContent.IsReadOnly = false;
					this.AfmarketingMaterialCollectionViaCustomCampaignContent.Add((AfmarketingMaterialEntity)entity);
					this.AfmarketingMaterialCollectionViaCustomCampaignContent.IsReadOnly = true;
					break;
				case "AfmarketingMaterialCollectionViaClickLog":
					this.AfmarketingMaterialCollectionViaClickLog.IsReadOnly = false;
					this.AfmarketingMaterialCollectionViaClickLog.Add((AfmarketingMaterialEntity)entity);
					this.AfmarketingMaterialCollectionViaClickLog.IsReadOnly = true;
					break;
				case "AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial":
					this.AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial.IsReadOnly = false;
					this.AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial.Add((AfmarketingMaterialEntity)entity);
					this.AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial.IsReadOnly = true;
					break;
				case "AfmarketingMaterialCollectionViaAfAdvertisingCommission":
					this.AfmarketingMaterialCollectionViaAfAdvertisingCommission.IsReadOnly = false;
					this.AfmarketingMaterialCollectionViaAfAdvertisingCommission.Add((AfmarketingMaterialEntity)entity);
					this.AfmarketingMaterialCollectionViaAfAdvertisingCommission.IsReadOnly = true;
					break;
				case "CampaignTagCollectionViaCampaignTagMapping":
					this.CampaignTagCollectionViaCampaignTagMapping.IsReadOnly = false;
					this.CampaignTagCollectionViaCampaignTagMapping.Add((CampaignTagEntity)entity);
					this.CampaignTagCollectionViaCampaignTagMapping.IsReadOnly = true;
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
			return AfcampaignEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Afadvertiser":
					toReturn.Add(AfcampaignEntity.Relations.AfadvertiserEntityUsingAdvertiserId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(AfcampaignEntity.Relations.OrganizationRoleUserEntityUsingRoleId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(AfcampaignEntity.Relations.OrganizationRoleUserEntityUsingShellId);
					break;
				case "AfAdvertisingCommission":
					toReturn.Add(AfcampaignEntity.Relations.AfAdvertisingCommissionEntityUsingCampaignId);
					break;
				case "AfaffiliateCampaign":
					toReturn.Add(AfcampaignEntity.Relations.AfaffiliateCampaignEntityUsingCampaignId);
					break;
				case "AfaffiliateCampaignMarketingMaterial":
					toReturn.Add(AfcampaignEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingCampaignId);
					break;
				case "AfcampaignSubAdvocate":
					toReturn.Add(AfcampaignEntity.Relations.AfcampaignSubAdvocateEntityUsingCampaignId);
					break;
				case "Afimpression":
					toReturn.Add(AfcampaignEntity.Relations.AfimpressionEntityUsingCampaignId);
					break;
				case "AfimpressionLog":
					toReturn.Add(AfcampaignEntity.Relations.AfimpressionLogEntityUsingAffiliateCampaignMarketingMaterialId);
					break;
				case "CampaignTagMapping":
					toReturn.Add(AfcampaignEntity.Relations.CampaignTagMappingEntityUsingCampaignId);
					break;
				case "ClickLog":
					toReturn.Add(AfcampaignEntity.Relations.ClickLogEntityUsingCampaignId);
					break;
				case "CustomCampaignContent":
					toReturn.Add(AfcampaignEntity.Relations.CustomCampaignContentEntityUsingCampaignId);
					break;
				case "EventCampaignDetails":
					toReturn.Add(AfcampaignEntity.Relations.EventCampaignDetailsEntityUsingCampaignId);
					break;
				case "AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog":
					toReturn.Add(AfcampaignEntity.Relations.AfimpressionLogEntityUsingAffiliateCampaignMarketingMaterialId, "AfcampaignEntity__", "AfimpressionLog_", JoinHint.None);
					toReturn.Add(AfimpressionLogEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingAffiliateCampaignMarketingMaterialId, "AfimpressionLog_", string.Empty, JoinHint.None);
					break;
				case "AffiliateProfileCollectionViaAfcampaignSubAdvocate":
					toReturn.Add(AfcampaignEntity.Relations.AfcampaignSubAdvocateEntityUsingCampaignId, "AfcampaignEntity__", "AfcampaignSubAdvocate_", JoinHint.None);
					toReturn.Add(AfcampaignSubAdvocateEntity.Relations.AffiliateProfileEntityUsingAffiliateId, "AfcampaignSubAdvocate_", string.Empty, JoinHint.None);
					break;
				case "AffiliateProfileCollectionViaAfaffiliateCampaign":
					toReturn.Add(AfcampaignEntity.Relations.AfaffiliateCampaignEntityUsingCampaignId, "AfcampaignEntity__", "AfaffiliateCampaign_", JoinHint.None);
					toReturn.Add(AfaffiliateCampaignEntity.Relations.AffiliateProfileEntityUsingAffiliateId, "AfaffiliateCampaign_", string.Empty, JoinHint.None);
					break;
				case "AfmarketingMaterialCollectionViaCustomCampaignContent":
					toReturn.Add(AfcampaignEntity.Relations.CustomCampaignContentEntityUsingCampaignId, "AfcampaignEntity__", "CustomCampaignContent_", JoinHint.None);
					toReturn.Add(CustomCampaignContentEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, "CustomCampaignContent_", string.Empty, JoinHint.None);
					break;
				case "AfmarketingMaterialCollectionViaClickLog":
					toReturn.Add(AfcampaignEntity.Relations.ClickLogEntityUsingCampaignId, "AfcampaignEntity__", "ClickLog_", JoinHint.None);
					toReturn.Add(ClickLogEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, "ClickLog_", string.Empty, JoinHint.None);
					break;
				case "AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial":
					toReturn.Add(AfcampaignEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingCampaignId, "AfcampaignEntity__", "AfaffiliateCampaignMarketingMaterial_", JoinHint.None);
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, "AfaffiliateCampaignMarketingMaterial_", string.Empty, JoinHint.None);
					break;
				case "AfmarketingMaterialCollectionViaAfAdvertisingCommission":
					toReturn.Add(AfcampaignEntity.Relations.AfAdvertisingCommissionEntityUsingCampaignId, "AfcampaignEntity__", "AfAdvertisingCommission_", JoinHint.None);
					toReturn.Add(AfAdvertisingCommissionEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, "AfAdvertisingCommission_", string.Empty, JoinHint.None);
					break;
				case "CampaignTagCollectionViaCampaignTagMapping":
					toReturn.Add(AfcampaignEntity.Relations.CampaignTagMappingEntityUsingCampaignId, "AfcampaignEntity__", "CampaignTagMapping_", JoinHint.None);
					toReturn.Add(CampaignTagMappingEntity.Relations.CampaignTagEntityUsingCampaignTagId, "CampaignTagMapping_", string.Empty, JoinHint.None);
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
				case "Afadvertiser":
					SetupSyncAfadvertiser(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "AfAdvertisingCommission":
					this.AfAdvertisingCommission.Add((AfAdvertisingCommissionEntity)relatedEntity);
					break;
				case "AfaffiliateCampaign":
					this.AfaffiliateCampaign.Add((AfaffiliateCampaignEntity)relatedEntity);
					break;
				case "AfaffiliateCampaignMarketingMaterial":
					this.AfaffiliateCampaignMarketingMaterial.Add((AfaffiliateCampaignMarketingMaterialEntity)relatedEntity);
					break;
				case "AfcampaignSubAdvocate":
					this.AfcampaignSubAdvocate.Add((AfcampaignSubAdvocateEntity)relatedEntity);
					break;
				case "Afimpression":
					this.Afimpression.Add((AfimpressionEntity)relatedEntity);
					break;
				case "AfimpressionLog":
					this.AfimpressionLog.Add((AfimpressionLogEntity)relatedEntity);
					break;
				case "CampaignTagMapping":
					this.CampaignTagMapping.Add((CampaignTagMappingEntity)relatedEntity);
					break;
				case "ClickLog":
					this.ClickLog.Add((ClickLogEntity)relatedEntity);
					break;
				case "CustomCampaignContent":
					this.CustomCampaignContent.Add((CustomCampaignContentEntity)relatedEntity);
					break;
				case "EventCampaignDetails":
					this.EventCampaignDetails.Add((EventCampaignDetailsEntity)relatedEntity);
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
				case "Afadvertiser":
					DesetupSyncAfadvertiser(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "AfAdvertisingCommission":
					base.PerformRelatedEntityRemoval(this.AfAdvertisingCommission, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AfaffiliateCampaign":
					base.PerformRelatedEntityRemoval(this.AfaffiliateCampaign, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AfaffiliateCampaignMarketingMaterial":
					base.PerformRelatedEntityRemoval(this.AfaffiliateCampaignMarketingMaterial, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AfcampaignSubAdvocate":
					base.PerformRelatedEntityRemoval(this.AfcampaignSubAdvocate, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Afimpression":
					base.PerformRelatedEntityRemoval(this.Afimpression, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AfimpressionLog":
					base.PerformRelatedEntityRemoval(this.AfimpressionLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CampaignTagMapping":
					base.PerformRelatedEntityRemoval(this.CampaignTagMapping, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ClickLog":
					base.PerformRelatedEntityRemoval(this.ClickLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomCampaignContent":
					base.PerformRelatedEntityRemoval(this.CustomCampaignContent, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCampaignDetails":
					base.PerformRelatedEntityRemoval(this.EventCampaignDetails, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_afadvertiser!=null)
			{
				toReturn.Add(_afadvertiser);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
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
			toReturn.Add(this.AfAdvertisingCommission);
			toReturn.Add(this.AfaffiliateCampaign);
			toReturn.Add(this.AfaffiliateCampaignMarketingMaterial);
			toReturn.Add(this.AfcampaignSubAdvocate);
			toReturn.Add(this.Afimpression);
			toReturn.Add(this.AfimpressionLog);
			toReturn.Add(this.CampaignTagMapping);
			toReturn.Add(this.ClickLog);
			toReturn.Add(this.CustomCampaignContent);
			toReturn.Add(this.EventCampaignDetails);

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
				info.AddValue("_afAdvertisingCommission", ((_afAdvertisingCommission!=null) && (_afAdvertisingCommission.Count>0) && !this.MarkedForDeletion)?_afAdvertisingCommission:null);
				info.AddValue("_afaffiliateCampaign", ((_afaffiliateCampaign!=null) && (_afaffiliateCampaign.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaign:null);
				info.AddValue("_afaffiliateCampaignMarketingMaterial", ((_afaffiliateCampaignMarketingMaterial!=null) && (_afaffiliateCampaignMarketingMaterial.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaignMarketingMaterial:null);
				info.AddValue("_afcampaignSubAdvocate", ((_afcampaignSubAdvocate!=null) && (_afcampaignSubAdvocate.Count>0) && !this.MarkedForDeletion)?_afcampaignSubAdvocate:null);
				info.AddValue("_afimpression", ((_afimpression!=null) && (_afimpression.Count>0) && !this.MarkedForDeletion)?_afimpression:null);
				info.AddValue("_afimpressionLog", ((_afimpressionLog!=null) && (_afimpressionLog.Count>0) && !this.MarkedForDeletion)?_afimpressionLog:null);
				info.AddValue("_campaignTagMapping", ((_campaignTagMapping!=null) && (_campaignTagMapping.Count>0) && !this.MarkedForDeletion)?_campaignTagMapping:null);
				info.AddValue("_clickLog", ((_clickLog!=null) && (_clickLog.Count>0) && !this.MarkedForDeletion)?_clickLog:null);
				info.AddValue("_customCampaignContent", ((_customCampaignContent!=null) && (_customCampaignContent.Count>0) && !this.MarkedForDeletion)?_customCampaignContent:null);
				info.AddValue("_eventCampaignDetails", ((_eventCampaignDetails!=null) && (_eventCampaignDetails.Count>0) && !this.MarkedForDeletion)?_eventCampaignDetails:null);
				info.AddValue("_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog", ((_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog!=null) && (_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog:null);
				info.AddValue("_affiliateProfileCollectionViaAfcampaignSubAdvocate", ((_affiliateProfileCollectionViaAfcampaignSubAdvocate!=null) && (_affiliateProfileCollectionViaAfcampaignSubAdvocate.Count>0) && !this.MarkedForDeletion)?_affiliateProfileCollectionViaAfcampaignSubAdvocate:null);
				info.AddValue("_affiliateProfileCollectionViaAfaffiliateCampaign", ((_affiliateProfileCollectionViaAfaffiliateCampaign!=null) && (_affiliateProfileCollectionViaAfaffiliateCampaign.Count>0) && !this.MarkedForDeletion)?_affiliateProfileCollectionViaAfaffiliateCampaign:null);
				info.AddValue("_afmarketingMaterialCollectionViaCustomCampaignContent", ((_afmarketingMaterialCollectionViaCustomCampaignContent!=null) && (_afmarketingMaterialCollectionViaCustomCampaignContent.Count>0) && !this.MarkedForDeletion)?_afmarketingMaterialCollectionViaCustomCampaignContent:null);
				info.AddValue("_afmarketingMaterialCollectionViaClickLog", ((_afmarketingMaterialCollectionViaClickLog!=null) && (_afmarketingMaterialCollectionViaClickLog.Count>0) && !this.MarkedForDeletion)?_afmarketingMaterialCollectionViaClickLog:null);
				info.AddValue("_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial", ((_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial!=null) && (_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial.Count>0) && !this.MarkedForDeletion)?_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial:null);
				info.AddValue("_afmarketingMaterialCollectionViaAfAdvertisingCommission", ((_afmarketingMaterialCollectionViaAfAdvertisingCommission!=null) && (_afmarketingMaterialCollectionViaAfAdvertisingCommission.Count>0) && !this.MarkedForDeletion)?_afmarketingMaterialCollectionViaAfAdvertisingCommission:null);
				info.AddValue("_campaignTagCollectionViaCampaignTagMapping", ((_campaignTagCollectionViaCampaignTagMapping!=null) && (_campaignTagCollectionViaCampaignTagMapping.Count>0) && !this.MarkedForDeletion)?_campaignTagCollectionViaCampaignTagMapping:null);
				info.AddValue("_afadvertiser", (!this.MarkedForDeletion?_afadvertiser:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
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
		public bool TestOriginalFieldValueForNull(AfcampaignFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AfcampaignFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AfcampaignRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfAdvertisingCommission' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfAdvertisingCommission()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfAdvertisingCommissionFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaignMarketingMaterial' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignMarketingMaterial()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignMarketingMaterialFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfcampaignSubAdvocate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignSubAdvocate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignSubAdvocateFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afimpression' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfimpression()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfimpressionFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfimpressionLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfimpressionLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfimpressionLogFields.AffiliateCampaignMarketingMaterialId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CampaignTagMapping' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignTagMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignTagMappingFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClickLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClickLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClickLogFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomCampaignContent' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomCampaignContent()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomCampaignContentFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCampaignDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCampaignDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCampaignDetailsFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaignMarketingMaterial' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId, "AfcampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AffiliateProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAffiliateProfileCollectionViaAfcampaignSubAdvocate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AffiliateProfileCollectionViaAfcampaignSubAdvocate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId, "AfcampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AffiliateProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAffiliateProfileCollectionViaAfaffiliateCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AffiliateProfileCollectionViaAfaffiliateCampaign"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId, "AfcampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfmarketingMaterial' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfmarketingMaterialCollectionViaCustomCampaignContent()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfmarketingMaterialCollectionViaCustomCampaignContent"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId, "AfcampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfmarketingMaterial' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfmarketingMaterialCollectionViaClickLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfmarketingMaterialCollectionViaClickLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId, "AfcampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfmarketingMaterial' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId, "AfcampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfmarketingMaterial' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfmarketingMaterialCollectionViaAfAdvertisingCommission()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfmarketingMaterialCollectionViaAfAdvertisingCommission"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId, "AfcampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CampaignTag' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignTagCollectionViaCampaignTagMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignTagCollectionViaCampaignTagMapping"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId, "AfcampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Afadvertiser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfadvertiser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfadvertiserFields.AdvertiserId, null, ComparisonOperator.Equal, this.AdvertiserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ShellId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AfcampaignEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._afAdvertisingCommission);
			collectionsQueue.Enqueue(this._afaffiliateCampaign);
			collectionsQueue.Enqueue(this._afaffiliateCampaignMarketingMaterial);
			collectionsQueue.Enqueue(this._afcampaignSubAdvocate);
			collectionsQueue.Enqueue(this._afimpression);
			collectionsQueue.Enqueue(this._afimpressionLog);
			collectionsQueue.Enqueue(this._campaignTagMapping);
			collectionsQueue.Enqueue(this._clickLog);
			collectionsQueue.Enqueue(this._customCampaignContent);
			collectionsQueue.Enqueue(this._eventCampaignDetails);
			collectionsQueue.Enqueue(this._afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog);
			collectionsQueue.Enqueue(this._affiliateProfileCollectionViaAfcampaignSubAdvocate);
			collectionsQueue.Enqueue(this._affiliateProfileCollectionViaAfaffiliateCampaign);
			collectionsQueue.Enqueue(this._afmarketingMaterialCollectionViaCustomCampaignContent);
			collectionsQueue.Enqueue(this._afmarketingMaterialCollectionViaClickLog);
			collectionsQueue.Enqueue(this._afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial);
			collectionsQueue.Enqueue(this._afmarketingMaterialCollectionViaAfAdvertisingCommission);
			collectionsQueue.Enqueue(this._campaignTagCollectionViaCampaignTagMapping);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._afAdvertisingCommission = (EntityCollection<AfAdvertisingCommissionEntity>) collectionsQueue.Dequeue();
			this._afaffiliateCampaign = (EntityCollection<AfaffiliateCampaignEntity>) collectionsQueue.Dequeue();
			this._afaffiliateCampaignMarketingMaterial = (EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>) collectionsQueue.Dequeue();
			this._afcampaignSubAdvocate = (EntityCollection<AfcampaignSubAdvocateEntity>) collectionsQueue.Dequeue();
			this._afimpression = (EntityCollection<AfimpressionEntity>) collectionsQueue.Dequeue();
			this._afimpressionLog = (EntityCollection<AfimpressionLogEntity>) collectionsQueue.Dequeue();
			this._campaignTagMapping = (EntityCollection<CampaignTagMappingEntity>) collectionsQueue.Dequeue();
			this._clickLog = (EntityCollection<ClickLogEntity>) collectionsQueue.Dequeue();
			this._customCampaignContent = (EntityCollection<CustomCampaignContentEntity>) collectionsQueue.Dequeue();
			this._eventCampaignDetails = (EntityCollection<EventCampaignDetailsEntity>) collectionsQueue.Dequeue();
			this._afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog = (EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>) collectionsQueue.Dequeue();
			this._affiliateProfileCollectionViaAfcampaignSubAdvocate = (EntityCollection<AffiliateProfileEntity>) collectionsQueue.Dequeue();
			this._affiliateProfileCollectionViaAfaffiliateCampaign = (EntityCollection<AffiliateProfileEntity>) collectionsQueue.Dequeue();
			this._afmarketingMaterialCollectionViaCustomCampaignContent = (EntityCollection<AfmarketingMaterialEntity>) collectionsQueue.Dequeue();
			this._afmarketingMaterialCollectionViaClickLog = (EntityCollection<AfmarketingMaterialEntity>) collectionsQueue.Dequeue();
			this._afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial = (EntityCollection<AfmarketingMaterialEntity>) collectionsQueue.Dequeue();
			this._afmarketingMaterialCollectionViaAfAdvertisingCommission = (EntityCollection<AfmarketingMaterialEntity>) collectionsQueue.Dequeue();
			this._campaignTagCollectionViaCampaignTagMapping = (EntityCollection<CampaignTagEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._afAdvertisingCommission != null)
			{
				return true;
			}
			if (this._afaffiliateCampaign != null)
			{
				return true;
			}
			if (this._afaffiliateCampaignMarketingMaterial != null)
			{
				return true;
			}
			if (this._afcampaignSubAdvocate != null)
			{
				return true;
			}
			if (this._afimpression != null)
			{
				return true;
			}
			if (this._afimpressionLog != null)
			{
				return true;
			}
			if (this._campaignTagMapping != null)
			{
				return true;
			}
			if (this._clickLog != null)
			{
				return true;
			}
			if (this._customCampaignContent != null)
			{
				return true;
			}
			if (this._eventCampaignDetails != null)
			{
				return true;
			}
			if (this._afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog != null)
			{
				return true;
			}
			if (this._affiliateProfileCollectionViaAfcampaignSubAdvocate != null)
			{
				return true;
			}
			if (this._affiliateProfileCollectionViaAfaffiliateCampaign != null)
			{
				return true;
			}
			if (this._afmarketingMaterialCollectionViaCustomCampaignContent != null)
			{
				return true;
			}
			if (this._afmarketingMaterialCollectionViaClickLog != null)
			{
				return true;
			}
			if (this._afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial != null)
			{
				return true;
			}
			if (this._afmarketingMaterialCollectionViaAfAdvertisingCommission != null)
			{
				return true;
			}
			if (this._campaignTagCollectionViaCampaignTagMapping != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfAdvertisingCommissionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfAdvertisingCommissionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignSubAdvocateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignSubAdvocateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfimpressionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfimpressionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfimpressionLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfimpressionLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignTagMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagMappingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomCampaignContentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomCampaignContentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCampaignDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCampaignDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignTagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Afadvertiser", _afadvertiser);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("AfAdvertisingCommission", _afAdvertisingCommission);
			toReturn.Add("AfaffiliateCampaign", _afaffiliateCampaign);
			toReturn.Add("AfaffiliateCampaignMarketingMaterial", _afaffiliateCampaignMarketingMaterial);
			toReturn.Add("AfcampaignSubAdvocate", _afcampaignSubAdvocate);
			toReturn.Add("Afimpression", _afimpression);
			toReturn.Add("AfimpressionLog", _afimpressionLog);
			toReturn.Add("CampaignTagMapping", _campaignTagMapping);
			toReturn.Add("ClickLog", _clickLog);
			toReturn.Add("CustomCampaignContent", _customCampaignContent);
			toReturn.Add("EventCampaignDetails", _eventCampaignDetails);
			toReturn.Add("AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog", _afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog);
			toReturn.Add("AffiliateProfileCollectionViaAfcampaignSubAdvocate", _affiliateProfileCollectionViaAfcampaignSubAdvocate);
			toReturn.Add("AffiliateProfileCollectionViaAfaffiliateCampaign", _affiliateProfileCollectionViaAfaffiliateCampaign);
			toReturn.Add("AfmarketingMaterialCollectionViaCustomCampaignContent", _afmarketingMaterialCollectionViaCustomCampaignContent);
			toReturn.Add("AfmarketingMaterialCollectionViaClickLog", _afmarketingMaterialCollectionViaClickLog);
			toReturn.Add("AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial", _afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial);
			toReturn.Add("AfmarketingMaterialCollectionViaAfAdvertisingCommission", _afmarketingMaterialCollectionViaAfAdvertisingCommission);
			toReturn.Add("CampaignTagCollectionViaCampaignTagMapping", _campaignTagCollectionViaCampaignTagMapping);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_afAdvertisingCommission!=null)
			{
				_afAdvertisingCommission.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaign!=null)
			{
				_afaffiliateCampaign.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaignMarketingMaterial!=null)
			{
				_afaffiliateCampaignMarketingMaterial.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignSubAdvocate!=null)
			{
				_afcampaignSubAdvocate.ActiveContext = base.ActiveContext;
			}
			if(_afimpression!=null)
			{
				_afimpression.ActiveContext = base.ActiveContext;
			}
			if(_afimpressionLog!=null)
			{
				_afimpressionLog.ActiveContext = base.ActiveContext;
			}
			if(_campaignTagMapping!=null)
			{
				_campaignTagMapping.ActiveContext = base.ActiveContext;
			}
			if(_clickLog!=null)
			{
				_clickLog.ActiveContext = base.ActiveContext;
			}
			if(_customCampaignContent!=null)
			{
				_customCampaignContent.ActiveContext = base.ActiveContext;
			}
			if(_eventCampaignDetails!=null)
			{
				_eventCampaignDetails.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog!=null)
			{
				_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog.ActiveContext = base.ActiveContext;
			}
			if(_affiliateProfileCollectionViaAfcampaignSubAdvocate!=null)
			{
				_affiliateProfileCollectionViaAfcampaignSubAdvocate.ActiveContext = base.ActiveContext;
			}
			if(_affiliateProfileCollectionViaAfaffiliateCampaign!=null)
			{
				_affiliateProfileCollectionViaAfaffiliateCampaign.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterialCollectionViaCustomCampaignContent!=null)
			{
				_afmarketingMaterialCollectionViaCustomCampaignContent.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterialCollectionViaClickLog!=null)
			{
				_afmarketingMaterialCollectionViaClickLog.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial!=null)
			{
				_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterialCollectionViaAfAdvertisingCommission!=null)
			{
				_afmarketingMaterialCollectionViaAfAdvertisingCommission.ActiveContext = base.ActiveContext;
			}
			if(_campaignTagCollectionViaCampaignTagMapping!=null)
			{
				_campaignTagCollectionViaCampaignTagMapping.ActiveContext = base.ActiveContext;
			}
			if(_afadvertiser!=null)
			{
				_afadvertiser.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_afAdvertisingCommission = null;
			_afaffiliateCampaign = null;
			_afaffiliateCampaignMarketingMaterial = null;
			_afcampaignSubAdvocate = null;
			_afimpression = null;
			_afimpressionLog = null;
			_campaignTagMapping = null;
			_clickLog = null;
			_customCampaignContent = null;
			_eventCampaignDetails = null;
			_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog = null;
			_affiliateProfileCollectionViaAfcampaignSubAdvocate = null;
			_affiliateProfileCollectionViaAfaffiliateCampaign = null;
			_afmarketingMaterialCollectionViaCustomCampaignContent = null;
			_afmarketingMaterialCollectionViaClickLog = null;
			_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial = null;
			_afmarketingMaterialCollectionViaAfAdvertisingCommission = null;
			_campaignTagCollectionViaCampaignTagMapping = null;
			_afadvertiser = null;
			_organizationRoleUser_ = null;
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

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PromoCodeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdvertiserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IncomingPhone", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EndDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Cost", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Commision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentAffiliateCommision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsCommisionPercentage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsGlobal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CompensationType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OwnerAffiliate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsuniquePhonenumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsAutoGenerated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CategoryId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShellId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afadvertiser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfadvertiser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afadvertiser, new PropertyChangedEventHandler( OnAfadvertiserPropertyChanged ), "Afadvertiser", AfcampaignEntity.Relations.AfadvertiserEntityUsingAdvertiserId, true, signalRelatedEntity, "Afcampaign", resetFKFields, new int[] { (int)AfcampaignFieldIndex.AdvertiserId } );		
			_afadvertiser = null;
		}

		/// <summary> setups the sync logic for member _afadvertiser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfadvertiser(IEntity2 relatedEntity)
		{
			if(_afadvertiser!=relatedEntity)
			{
				DesetupSyncAfadvertiser(true, true);
				_afadvertiser = (AfadvertiserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afadvertiser, new PropertyChangedEventHandler( OnAfadvertiserPropertyChanged ), "Afadvertiser", AfcampaignEntity.Relations.AfadvertiserEntityUsingAdvertiserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfadvertiserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", AfcampaignEntity.Relations.OrganizationRoleUserEntityUsingRoleId, true, signalRelatedEntity, "Afcampaign_", resetFKFields, new int[] { (int)AfcampaignFieldIndex.RoleId } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", AfcampaignEntity.Relations.OrganizationRoleUserEntityUsingRoleId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", AfcampaignEntity.Relations.OrganizationRoleUserEntityUsingShellId, true, signalRelatedEntity, "Afcampaign", resetFKFields, new int[] { (int)AfcampaignFieldIndex.ShellId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", AfcampaignEntity.Relations.OrganizationRoleUserEntityUsingShellId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this AfcampaignEntity</param>
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
		public  static AfcampaignRelations Relations
		{
			get	{ return new AfcampaignRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfAdvertisingCommission' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfAdvertisingCommission
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfAdvertisingCommissionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfAdvertisingCommissionEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfAdvertisingCommission")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfAdvertisingCommissionEntity, 0, null, null, null, null, "AfAdvertisingCommission", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaign
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfaffiliateCampaign")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, null, null, "AfaffiliateCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaignMarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignMarketingMaterial
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfaffiliateCampaignMarketingMaterial")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, 0, null, null, null, null, "AfaffiliateCampaignMarketingMaterial", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfcampaignSubAdvocate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignSubAdvocate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfcampaignSubAdvocateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignSubAdvocateEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfcampaignSubAdvocate")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfcampaignSubAdvocateEntity, 0, null, null, null, null, "AfcampaignSubAdvocate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afimpression' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfimpression
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfimpressionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfimpressionEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afimpression")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfimpressionEntity, 0, null, null, null, null, "Afimpression", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfimpressionLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfimpressionLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfimpressionLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfimpressionLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfimpressionLog")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfimpressionLogEntity, 0, null, null, null, null, "AfimpressionLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CampaignTagMapping' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignTagMapping
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CampaignTagMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagMappingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CampaignTagMapping")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.CampaignTagMappingEntity, 0, null, null, null, null, "CampaignTagMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClickLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClickLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("ClickLog")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.ClickLogEntity, 0, null, null, null, null, "ClickLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomCampaignContent' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomCampaignContent
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomCampaignContentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomCampaignContentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomCampaignContent")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.CustomCampaignContentEntity, 0, null, null, null, null, "CustomCampaignContent", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCampaignDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCampaignDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCampaignDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCampaignDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCampaignDetails")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.EventCampaignDetailsEntity, 0, null, null, null, null, "EventCampaignDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaignMarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog
		{
			get
			{
				IEntityRelation intermediateRelation = AfcampaignEntity.Relations.AfimpressionLogEntityUsingAffiliateCampaignMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "AfimpressionLog_");
				return new PrefetchPathElement2(new EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, 0, null, null, GetRelationsForField("AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog"), null, "AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AffiliateProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAffiliateProfileCollectionViaAfcampaignSubAdvocate
		{
			get
			{
				IEntityRelation intermediateRelation = AfcampaignEntity.Relations.AfcampaignSubAdvocateEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "AfcampaignSubAdvocate_");
				return new PrefetchPathElement2(new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AffiliateProfileEntity, 0, null, null, GetRelationsForField("AffiliateProfileCollectionViaAfcampaignSubAdvocate"), null, "AffiliateProfileCollectionViaAfcampaignSubAdvocate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AffiliateProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAffiliateProfileCollectionViaAfaffiliateCampaign
		{
			get
			{
				IEntityRelation intermediateRelation = AfcampaignEntity.Relations.AfaffiliateCampaignEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "AfaffiliateCampaign_");
				return new PrefetchPathElement2(new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AffiliateProfileEntity, 0, null, null, GetRelationsForField("AffiliateProfileCollectionViaAfaffiliateCampaign"), null, "AffiliateProfileCollectionViaAfaffiliateCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfmarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfmarketingMaterialCollectionViaCustomCampaignContent
		{
			get
			{
				IEntityRelation intermediateRelation = AfcampaignEntity.Relations.CustomCampaignContentEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CustomCampaignContent_");
				return new PrefetchPathElement2(new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, 0, null, null, GetRelationsForField("AfmarketingMaterialCollectionViaCustomCampaignContent"), null, "AfmarketingMaterialCollectionViaCustomCampaignContent", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfmarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfmarketingMaterialCollectionViaClickLog
		{
			get
			{
				IEntityRelation intermediateRelation = AfcampaignEntity.Relations.ClickLogEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "ClickLog_");
				return new PrefetchPathElement2(new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, 0, null, null, GetRelationsForField("AfmarketingMaterialCollectionViaClickLog"), null, "AfmarketingMaterialCollectionViaClickLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfmarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial
		{
			get
			{
				IEntityRelation intermediateRelation = AfcampaignEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "AfaffiliateCampaignMarketingMaterial_");
				return new PrefetchPathElement2(new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, 0, null, null, GetRelationsForField("AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial"), null, "AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfmarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfmarketingMaterialCollectionViaAfAdvertisingCommission
		{
			get
			{
				IEntityRelation intermediateRelation = AfcampaignEntity.Relations.AfAdvertisingCommissionEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "AfAdvertisingCommission_");
				return new PrefetchPathElement2(new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, 0, null, null, GetRelationsForField("AfmarketingMaterialCollectionViaAfAdvertisingCommission"), null, "AfmarketingMaterialCollectionViaAfAdvertisingCommission", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CampaignTag' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignTagCollectionViaCampaignTagMapping
		{
			get
			{
				IEntityRelation intermediateRelation = AfcampaignEntity.Relations.CampaignTagMappingEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CampaignTagMapping_");
				return new PrefetchPathElement2(new EntityCollection<CampaignTagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.CampaignTagEntity, 0, null, null, GetRelationsForField("CampaignTagCollectionViaCampaignTagMapping"), null, "CampaignTagCollectionViaCampaignTagMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afadvertiser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfadvertiser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfadvertiserEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afadvertiser")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.AfadvertiserEntity, 0, null, null, null, null, "Afadvertiser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.AfcampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AfcampaignEntity.CustomProperties;}
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
			get { return AfcampaignEntity.FieldsCustomProperties;}
		}

		/// <summary> The CampaignId property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."CampaignID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CampaignId
		{
			get { return (System.Int64)GetValue((int)AfcampaignFieldIndex.CampaignId, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.CampaignId, value); }
		}

		/// <summary> The CampaignName property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."CampaignName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CampaignName
		{
			get { return (System.String)GetValue((int)AfcampaignFieldIndex.CampaignName, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.CampaignName, value); }
		}

		/// <summary> The PromoCodeId property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."PromoCodeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PromoCodeId
		{
			get { return (System.Int64)GetValue((int)AfcampaignFieldIndex.PromoCodeId, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.PromoCodeId, value); }
		}

		/// <summary> The AdvertiserId property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."AdvertiserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AdvertiserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AfcampaignFieldIndex.AdvertiserId, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.AdvertiserId, value); }
		}

		/// <summary> The IncomingPhone property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."IncomingPhone"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IncomingPhone
		{
			get { return (System.String)GetValue((int)AfcampaignFieldIndex.IncomingPhone, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.IncomingPhone, value); }
		}

		/// <summary> The StartDate property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."StartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime StartDate
		{
			get { return (System.DateTime)GetValue((int)AfcampaignFieldIndex.StartDate, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.StartDate, value); }
		}

		/// <summary> The EndDate property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."EndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> EndDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfcampaignFieldIndex.EndDate, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.EndDate, value); }
		}

		/// <summary> The Cost property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."Cost"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Cost
		{
			get { return (System.Decimal)GetValue((int)AfcampaignFieldIndex.Cost, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.Cost, value); }
		}

		/// <summary> The Commision property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."Commision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Commision
		{
			get { return (Nullable<System.Decimal>)GetValue((int)AfcampaignFieldIndex.Commision, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.Commision, value); }
		}

		/// <summary> The ParentAffiliateCommision property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."ParentAffiliateCommision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> ParentAffiliateCommision
		{
			get { return (Nullable<System.Decimal>)GetValue((int)AfcampaignFieldIndex.ParentAffiliateCommision, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.ParentAffiliateCommision, value); }
		}

		/// <summary> The IsCommisionPercentage property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."IsCommisionPercentage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsCommisionPercentage
		{
			get { return (System.Boolean)GetValue((int)AfcampaignFieldIndex.IsCommisionPercentage, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.IsCommisionPercentage, value); }
		}

		/// <summary> The CreatedDate property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfcampaignFieldIndex.CreatedDate, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.CreatedDate, value); }
		}

		/// <summary> The LastModifiedDate property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."LastModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastModifiedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfcampaignFieldIndex.LastModifiedDate, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.LastModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AfcampaignFieldIndex.IsActive, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.IsActive, value); }
		}

		/// <summary> The IsGlobal property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."IsGlobal"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsGlobal
		{
			get { return (System.Boolean)GetValue((int)AfcampaignFieldIndex.IsGlobal, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.IsGlobal, value); }
		}

		/// <summary> The CompensationType property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."CompensationType"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> CompensationType
		{
			get { return (Nullable<System.Int32>)GetValue((int)AfcampaignFieldIndex.CompensationType, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.CompensationType, value); }
		}

		/// <summary> The CampaignType property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."CampaignType"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 CampaignType
		{
			get { return (System.Int16)GetValue((int)AfcampaignFieldIndex.CampaignType, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.CampaignType, value); }
		}

		/// <summary> The OwnerAffiliate property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."OwnerAffiliate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> OwnerAffiliate
		{
			get { return (Nullable<System.Int32>)GetValue((int)AfcampaignFieldIndex.OwnerAffiliate, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.OwnerAffiliate, value); }
		}

		/// <summary> The IsuniquePhonenumber property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."IsuniquePhonenumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsuniquePhonenumber
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AfcampaignFieldIndex.IsuniquePhonenumber, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.IsuniquePhonenumber, value); }
		}

		/// <summary> The IsAutoGenerated property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."IsAutoGenerated"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsAutoGenerated
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AfcampaignFieldIndex.IsAutoGenerated, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.IsAutoGenerated, value); }
		}

		/// <summary> The Notes property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)AfcampaignFieldIndex.Notes, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.Notes, value); }
		}

		/// <summary> The CategoryId property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."CategoryId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> CategoryId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AfcampaignFieldIndex.CategoryId, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.CategoryId, value); }
		}

		/// <summary> The RoleId property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."OwnerOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RoleId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AfcampaignFieldIndex.RoleId, false); }
			set	{ SetValue((int)AfcampaignFieldIndex.RoleId, value); }
		}

		/// <summary> The ShellId property of the Entity Afcampaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCampaign"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ShellId
		{
			get { return (System.Int64)GetValue((int)AfcampaignFieldIndex.ShellId, true); }
			set	{ SetValue((int)AfcampaignFieldIndex.ShellId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfAdvertisingCommissionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfAdvertisingCommissionEntity))]
		public virtual EntityCollection<AfAdvertisingCommissionEntity> AfAdvertisingCommission
		{
			get
			{
				if(_afAdvertisingCommission==null)
				{
					_afAdvertisingCommission = new EntityCollection<AfAdvertisingCommissionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfAdvertisingCommissionEntityFactory)));
					_afAdvertisingCommission.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _afAdvertisingCommission;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfaffiliateCampaignEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfaffiliateCampaignEntity))]
		public virtual EntityCollection<AfaffiliateCampaignEntity> AfaffiliateCampaign
		{
			get
			{
				if(_afaffiliateCampaign==null)
				{
					_afaffiliateCampaign = new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory)));
					_afaffiliateCampaign.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _afaffiliateCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfaffiliateCampaignMarketingMaterialEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfaffiliateCampaignMarketingMaterialEntity))]
		public virtual EntityCollection<AfaffiliateCampaignMarketingMaterialEntity> AfaffiliateCampaignMarketingMaterial
		{
			get
			{
				if(_afaffiliateCampaignMarketingMaterial==null)
				{
					_afaffiliateCampaignMarketingMaterial = new EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory)));
					_afaffiliateCampaignMarketingMaterial.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _afaffiliateCampaignMarketingMaterial;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignSubAdvocateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignSubAdvocateEntity))]
		public virtual EntityCollection<AfcampaignSubAdvocateEntity> AfcampaignSubAdvocate
		{
			get
			{
				if(_afcampaignSubAdvocate==null)
				{
					_afcampaignSubAdvocate = new EntityCollection<AfcampaignSubAdvocateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignSubAdvocateEntityFactory)));
					_afcampaignSubAdvocate.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _afcampaignSubAdvocate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfimpressionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfimpressionEntity))]
		public virtual EntityCollection<AfimpressionEntity> Afimpression
		{
			get
			{
				if(_afimpression==null)
				{
					_afimpression = new EntityCollection<AfimpressionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfimpressionEntityFactory)));
					_afimpression.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _afimpression;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfimpressionLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfimpressionLogEntity))]
		public virtual EntityCollection<AfimpressionLogEntity> AfimpressionLog
		{
			get
			{
				if(_afimpressionLog==null)
				{
					_afimpressionLog = new EntityCollection<AfimpressionLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfimpressionLogEntityFactory)));
					_afimpressionLog.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _afimpressionLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignTagMappingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignTagMappingEntity))]
		public virtual EntityCollection<CampaignTagMappingEntity> CampaignTagMapping
		{
			get
			{
				if(_campaignTagMapping==null)
				{
					_campaignTagMapping = new EntityCollection<CampaignTagMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagMappingEntityFactory)));
					_campaignTagMapping.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _campaignTagMapping;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClickLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClickLogEntity))]
		public virtual EntityCollection<ClickLogEntity> ClickLog
		{
			get
			{
				if(_clickLog==null)
				{
					_clickLog = new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory)));
					_clickLog.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _clickLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomCampaignContentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomCampaignContentEntity))]
		public virtual EntityCollection<CustomCampaignContentEntity> CustomCampaignContent
		{
			get
			{
				if(_customCampaignContent==null)
				{
					_customCampaignContent = new EntityCollection<CustomCampaignContentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomCampaignContentEntityFactory)));
					_customCampaignContent.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _customCampaignContent;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCampaignDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCampaignDetailsEntity))]
		public virtual EntityCollection<EventCampaignDetailsEntity> EventCampaignDetails
		{
			get
			{
				if(_eventCampaignDetails==null)
				{
					_eventCampaignDetails = new EntityCollection<EventCampaignDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCampaignDetailsEntityFactory)));
					_eventCampaignDetails.SetContainingEntityInfo(this, "Afcampaign");
				}
				return _eventCampaignDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfaffiliateCampaignMarketingMaterialEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfaffiliateCampaignMarketingMaterialEntity))]
		public virtual EntityCollection<AfaffiliateCampaignMarketingMaterialEntity> AfaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog
		{
			get
			{
				if(_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog==null)
				{
					_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog = new EntityCollection<AfaffiliateCampaignMarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory)));
					_afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog.IsReadOnly=true;
				}
				return _afaffiliateCampaignMarketingMaterialCollectionViaAfimpressionLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AffiliateProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AffiliateProfileEntity))]
		public virtual EntityCollection<AffiliateProfileEntity> AffiliateProfileCollectionViaAfcampaignSubAdvocate
		{
			get
			{
				if(_affiliateProfileCollectionViaAfcampaignSubAdvocate==null)
				{
					_affiliateProfileCollectionViaAfcampaignSubAdvocate = new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory)));
					_affiliateProfileCollectionViaAfcampaignSubAdvocate.IsReadOnly=true;
				}
				return _affiliateProfileCollectionViaAfcampaignSubAdvocate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AffiliateProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AffiliateProfileEntity))]
		public virtual EntityCollection<AffiliateProfileEntity> AffiliateProfileCollectionViaAfaffiliateCampaign
		{
			get
			{
				if(_affiliateProfileCollectionViaAfaffiliateCampaign==null)
				{
					_affiliateProfileCollectionViaAfaffiliateCampaign = new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory)));
					_affiliateProfileCollectionViaAfaffiliateCampaign.IsReadOnly=true;
				}
				return _affiliateProfileCollectionViaAfaffiliateCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfmarketingMaterialEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfmarketingMaterialEntity))]
		public virtual EntityCollection<AfmarketingMaterialEntity> AfmarketingMaterialCollectionViaCustomCampaignContent
		{
			get
			{
				if(_afmarketingMaterialCollectionViaCustomCampaignContent==null)
				{
					_afmarketingMaterialCollectionViaCustomCampaignContent = new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory)));
					_afmarketingMaterialCollectionViaCustomCampaignContent.IsReadOnly=true;
				}
				return _afmarketingMaterialCollectionViaCustomCampaignContent;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfmarketingMaterialEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfmarketingMaterialEntity))]
		public virtual EntityCollection<AfmarketingMaterialEntity> AfmarketingMaterialCollectionViaClickLog
		{
			get
			{
				if(_afmarketingMaterialCollectionViaClickLog==null)
				{
					_afmarketingMaterialCollectionViaClickLog = new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory)));
					_afmarketingMaterialCollectionViaClickLog.IsReadOnly=true;
				}
				return _afmarketingMaterialCollectionViaClickLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfmarketingMaterialEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfmarketingMaterialEntity))]
		public virtual EntityCollection<AfmarketingMaterialEntity> AfmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial
		{
			get
			{
				if(_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial==null)
				{
					_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial = new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory)));
					_afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial.IsReadOnly=true;
				}
				return _afmarketingMaterialCollectionViaAfaffiliateCampaignMarketingMaterial;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfmarketingMaterialEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfmarketingMaterialEntity))]
		public virtual EntityCollection<AfmarketingMaterialEntity> AfmarketingMaterialCollectionViaAfAdvertisingCommission
		{
			get
			{
				if(_afmarketingMaterialCollectionViaAfAdvertisingCommission==null)
				{
					_afmarketingMaterialCollectionViaAfAdvertisingCommission = new EntityCollection<AfmarketingMaterialEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory)));
					_afmarketingMaterialCollectionViaAfAdvertisingCommission.IsReadOnly=true;
				}
				return _afmarketingMaterialCollectionViaAfAdvertisingCommission;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignTagEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignTagEntity))]
		public virtual EntityCollection<CampaignTagEntity> CampaignTagCollectionViaCampaignTagMapping
		{
			get
			{
				if(_campaignTagCollectionViaCampaignTagMapping==null)
				{
					_campaignTagCollectionViaCampaignTagMapping = new EntityCollection<CampaignTagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignTagEntityFactory)));
					_campaignTagCollectionViaCampaignTagMapping.IsReadOnly=true;
				}
				return _campaignTagCollectionViaCampaignTagMapping;
			}
		}

		/// <summary> Gets / sets related entity of type 'AfadvertiserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfadvertiserEntity Afadvertiser
		{
			get
			{
				return _afadvertiser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfadvertiser(value);
				}
				else
				{
					if(value==null)
					{
						if(_afadvertiser != null)
						{
							_afadvertiser.UnsetRelatedEntity(this, "Afcampaign");
						}
					}
					else
					{
						if(_afadvertiser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Afcampaign");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "Afcampaign_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Afcampaign_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Afcampaign");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Afcampaign");
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
			get { return (int)Falcon.Data.EntityType.AfcampaignEntity; }
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
