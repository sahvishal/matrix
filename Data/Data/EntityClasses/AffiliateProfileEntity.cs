///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'AffiliateProfile'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AffiliateProfileEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AfaffiliateCampaignEntity> _afaffiliateCampaign;
		private EntityCollection<AfcampaignSubAdvocateEntity> _afcampaignSubAdvocate;
		private EntityCollection<AfcommisionEntity> _afcommision;
		private EntityCollection<AflAffiliatePaymentMethodEntity> _aflAffiliatePaymentMethod;
		private EntityCollection<AfpaymentEntity> _afpayment;
		private EntityCollection<EventAffiliateDetailsEntity> _eventAffiliateDetails;
		private EntityCollection<AfaffiliateCampaignEntity> _afaffiliateCampaignCollectionViaAfcommision;
		private EntityCollection<AfcampaignEntity> _afcampaignCollectionViaAfaffiliateCampaign;
		private EntityCollection<AfcampaignEntity> _afcampaignCollectionViaAfcampaignSubAdvocate;
		private EntityCollection<AfpaymentEntity> _afpaymentCollectionViaAfcommision;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAffiliateDetails;
		private OrganizationEntity _organization;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private AfcampaignSubAdvocateEntity _afcampaignSubAdvocate_;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name AfaffiliateCampaign</summary>
			public static readonly string AfaffiliateCampaign = "AfaffiliateCampaign";
			/// <summary>Member name AfcampaignSubAdvocate</summary>
			public static readonly string AfcampaignSubAdvocate = "AfcampaignSubAdvocate";
			/// <summary>Member name Afcommision</summary>
			public static readonly string Afcommision = "Afcommision";
			/// <summary>Member name AflAffiliatePaymentMethod</summary>
			public static readonly string AflAffiliatePaymentMethod = "AflAffiliatePaymentMethod";
			/// <summary>Member name Afpayment</summary>
			public static readonly string Afpayment = "Afpayment";
			/// <summary>Member name EventAffiliateDetails</summary>
			public static readonly string EventAffiliateDetails = "EventAffiliateDetails";
			/// <summary>Member name AfaffiliateCampaignCollectionViaAfcommision</summary>
			public static readonly string AfaffiliateCampaignCollectionViaAfcommision = "AfaffiliateCampaignCollectionViaAfcommision";
			/// <summary>Member name AfcampaignCollectionViaAfaffiliateCampaign</summary>
			public static readonly string AfcampaignCollectionViaAfaffiliateCampaign = "AfcampaignCollectionViaAfaffiliateCampaign";
			/// <summary>Member name AfcampaignCollectionViaAfcampaignSubAdvocate</summary>
			public static readonly string AfcampaignCollectionViaAfcampaignSubAdvocate = "AfcampaignCollectionViaAfcampaignSubAdvocate";
			/// <summary>Member name AfpaymentCollectionViaAfcommision</summary>
			public static readonly string AfpaymentCollectionViaAfcommision = "AfpaymentCollectionViaAfcommision";
			/// <summary>Member name EventsCollectionViaEventAffiliateDetails</summary>
			public static readonly string EventsCollectionViaEventAffiliateDetails = "EventsCollectionViaEventAffiliateDetails";
			/// <summary>Member name AfcampaignSubAdvocate_</summary>
			public static readonly string AfcampaignSubAdvocate_ = "AfcampaignSubAdvocate_";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AffiliateProfileEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AffiliateProfileEntity():base("AffiliateProfileEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AffiliateProfileEntity(IEntityFields2 fields):base("AffiliateProfileEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AffiliateProfileEntity</param>
		public AffiliateProfileEntity(IValidator validator):base("AffiliateProfileEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="affiliateId">PK value for AffiliateProfile which data should be fetched into this AffiliateProfile object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AffiliateProfileEntity(System.Int64 affiliateId):base("AffiliateProfileEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AffiliateId = affiliateId;
		}

		/// <summary> CTor</summary>
		/// <param name="affiliateId">PK value for AffiliateProfile which data should be fetched into this AffiliateProfile object</param>
		/// <param name="validator">The custom validator object for this AffiliateProfileEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AffiliateProfileEntity(System.Int64 affiliateId, IValidator validator):base("AffiliateProfileEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AffiliateId = affiliateId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AffiliateProfileEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_afaffiliateCampaign = (EntityCollection<AfaffiliateCampaignEntity>)info.GetValue("_afaffiliateCampaign", typeof(EntityCollection<AfaffiliateCampaignEntity>));
				_afcampaignSubAdvocate = (EntityCollection<AfcampaignSubAdvocateEntity>)info.GetValue("_afcampaignSubAdvocate", typeof(EntityCollection<AfcampaignSubAdvocateEntity>));
				_afcommision = (EntityCollection<AfcommisionEntity>)info.GetValue("_afcommision", typeof(EntityCollection<AfcommisionEntity>));
				_aflAffiliatePaymentMethod = (EntityCollection<AflAffiliatePaymentMethodEntity>)info.GetValue("_aflAffiliatePaymentMethod", typeof(EntityCollection<AflAffiliatePaymentMethodEntity>));
				_afpayment = (EntityCollection<AfpaymentEntity>)info.GetValue("_afpayment", typeof(EntityCollection<AfpaymentEntity>));
				_eventAffiliateDetails = (EntityCollection<EventAffiliateDetailsEntity>)info.GetValue("_eventAffiliateDetails", typeof(EntityCollection<EventAffiliateDetailsEntity>));
				_afaffiliateCampaignCollectionViaAfcommision = (EntityCollection<AfaffiliateCampaignEntity>)info.GetValue("_afaffiliateCampaignCollectionViaAfcommision", typeof(EntityCollection<AfaffiliateCampaignEntity>));
				_afcampaignCollectionViaAfaffiliateCampaign = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaignCollectionViaAfaffiliateCampaign", typeof(EntityCollection<AfcampaignEntity>));
				_afcampaignCollectionViaAfcampaignSubAdvocate = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaignCollectionViaAfcampaignSubAdvocate", typeof(EntityCollection<AfcampaignEntity>));
				_afpaymentCollectionViaAfcommision = (EntityCollection<AfpaymentEntity>)info.GetValue("_afpaymentCollectionViaAfcommision", typeof(EntityCollection<AfpaymentEntity>));
				_eventsCollectionViaEventAffiliateDetails = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAffiliateDetails", typeof(EntityCollection<EventsEntity>));
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
				_afcampaignSubAdvocate_ = (AfcampaignSubAdvocateEntity)info.GetValue("_afcampaignSubAdvocate_", typeof(AfcampaignSubAdvocateEntity));
				if(_afcampaignSubAdvocate_!=null)
				{
					_afcampaignSubAdvocate_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AffiliateProfileFieldIndex)fieldIndex)
			{
				case AffiliateProfileFieldIndex.AffiliateId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case AffiliateProfileFieldIndex.OwnerOrganizationId:
					DesetupSyncOrganization(true, false);
					break;
				case AffiliateProfileFieldIndex.CreatedByOrgRoleUserId:
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
				case "Organization":
					this.Organization = (OrganizationEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "AfaffiliateCampaign":
					this.AfaffiliateCampaign.Add((AfaffiliateCampaignEntity)entity);
					break;
				case "AfcampaignSubAdvocate":
					this.AfcampaignSubAdvocate.Add((AfcampaignSubAdvocateEntity)entity);
					break;
				case "Afcommision":
					this.Afcommision.Add((AfcommisionEntity)entity);
					break;
				case "AflAffiliatePaymentMethod":
					this.AflAffiliatePaymentMethod.Add((AflAffiliatePaymentMethodEntity)entity);
					break;
				case "Afpayment":
					this.Afpayment.Add((AfpaymentEntity)entity);
					break;
				case "EventAffiliateDetails":
					this.EventAffiliateDetails.Add((EventAffiliateDetailsEntity)entity);
					break;
				case "AfaffiliateCampaignCollectionViaAfcommision":
					this.AfaffiliateCampaignCollectionViaAfcommision.IsReadOnly = false;
					this.AfaffiliateCampaignCollectionViaAfcommision.Add((AfaffiliateCampaignEntity)entity);
					this.AfaffiliateCampaignCollectionViaAfcommision.IsReadOnly = true;
					break;
				case "AfcampaignCollectionViaAfaffiliateCampaign":
					this.AfcampaignCollectionViaAfaffiliateCampaign.IsReadOnly = false;
					this.AfcampaignCollectionViaAfaffiliateCampaign.Add((AfcampaignEntity)entity);
					this.AfcampaignCollectionViaAfaffiliateCampaign.IsReadOnly = true;
					break;
				case "AfcampaignCollectionViaAfcampaignSubAdvocate":
					this.AfcampaignCollectionViaAfcampaignSubAdvocate.IsReadOnly = false;
					this.AfcampaignCollectionViaAfcampaignSubAdvocate.Add((AfcampaignEntity)entity);
					this.AfcampaignCollectionViaAfcampaignSubAdvocate.IsReadOnly = true;
					break;
				case "AfpaymentCollectionViaAfcommision":
					this.AfpaymentCollectionViaAfcommision.IsReadOnly = false;
					this.AfpaymentCollectionViaAfcommision.Add((AfpaymentEntity)entity);
					this.AfpaymentCollectionViaAfcommision.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventAffiliateDetails":
					this.EventsCollectionViaEventAffiliateDetails.IsReadOnly = false;
					this.EventsCollectionViaEventAffiliateDetails.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAffiliateDetails.IsReadOnly = true;
					break;
				case "AfcampaignSubAdvocate_":
					this.AfcampaignSubAdvocate_ = (AfcampaignSubAdvocateEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
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
			return AffiliateProfileEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Organization":
					toReturn.Add(AffiliateProfileEntity.Relations.OrganizationEntityUsingOwnerOrganizationId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(AffiliateProfileEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "AfaffiliateCampaign":
					toReturn.Add(AffiliateProfileEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateId);
					break;
				case "AfcampaignSubAdvocate":
					toReturn.Add(AffiliateProfileEntity.Relations.AfcampaignSubAdvocateEntityUsingAffiliateId);
					break;
				case "Afcommision":
					toReturn.Add(AffiliateProfileEntity.Relations.AfcommisionEntityUsingAffiliateId);
					break;
				case "AflAffiliatePaymentMethod":
					toReturn.Add(AffiliateProfileEntity.Relations.AflAffiliatePaymentMethodEntityUsingAffiliateId);
					break;
				case "Afpayment":
					toReturn.Add(AffiliateProfileEntity.Relations.AfpaymentEntityUsingAffiliateId);
					break;
				case "EventAffiliateDetails":
					toReturn.Add(AffiliateProfileEntity.Relations.EventAffiliateDetailsEntityUsingAffiliateId);
					break;
				case "AfaffiliateCampaignCollectionViaAfcommision":
					toReturn.Add(AffiliateProfileEntity.Relations.AfcommisionEntityUsingAffiliateId, "AffiliateProfileEntity__", "Afcommision_", JoinHint.None);
					toReturn.Add(AfcommisionEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, "Afcommision_", string.Empty, JoinHint.None);
					break;
				case "AfcampaignCollectionViaAfaffiliateCampaign":
					toReturn.Add(AffiliateProfileEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateId, "AffiliateProfileEntity__", "AfaffiliateCampaign_", JoinHint.None);
					toReturn.Add(AfaffiliateCampaignEntity.Relations.AfcampaignEntityUsingCampaignId, "AfaffiliateCampaign_", string.Empty, JoinHint.None);
					break;
				case "AfcampaignCollectionViaAfcampaignSubAdvocate":
					toReturn.Add(AffiliateProfileEntity.Relations.AfcampaignSubAdvocateEntityUsingAffiliateId, "AffiliateProfileEntity__", "AfcampaignSubAdvocate_", JoinHint.None);
					toReturn.Add(AfcampaignSubAdvocateEntity.Relations.AfcampaignEntityUsingCampaignId, "AfcampaignSubAdvocate_", string.Empty, JoinHint.None);
					break;
				case "AfpaymentCollectionViaAfcommision":
					toReturn.Add(AffiliateProfileEntity.Relations.AfcommisionEntityUsingAffiliateId, "AffiliateProfileEntity__", "Afcommision_", JoinHint.None);
					toReturn.Add(AfcommisionEntity.Relations.AfpaymentEntityUsingPaymentId, "Afcommision_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAffiliateDetails":
					toReturn.Add(AffiliateProfileEntity.Relations.EventAffiliateDetailsEntityUsingAffiliateId, "AffiliateProfileEntity__", "EventAffiliateDetails_", JoinHint.None);
					toReturn.Add(EventAffiliateDetailsEntity.Relations.EventsEntityUsingEventId, "EventAffiliateDetails_", string.Empty, JoinHint.None);
					break;
				case "AfcampaignSubAdvocate_":
					toReturn.Add(AffiliateProfileEntity.Relations.AfcampaignSubAdvocateEntityUsingCampaignSubAffiliateId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(AffiliateProfileEntity.Relations.OrganizationRoleUserEntityUsingAffiliateId);
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
				case "Organization":
					SetupSyncOrganization(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "AfaffiliateCampaign":
					this.AfaffiliateCampaign.Add((AfaffiliateCampaignEntity)relatedEntity);
					break;
				case "AfcampaignSubAdvocate":
					this.AfcampaignSubAdvocate.Add((AfcampaignSubAdvocateEntity)relatedEntity);
					break;
				case "Afcommision":
					this.Afcommision.Add((AfcommisionEntity)relatedEntity);
					break;
				case "AflAffiliatePaymentMethod":
					this.AflAffiliatePaymentMethod.Add((AflAffiliatePaymentMethodEntity)relatedEntity);
					break;
				case "Afpayment":
					this.Afpayment.Add((AfpaymentEntity)relatedEntity);
					break;
				case "EventAffiliateDetails":
					this.EventAffiliateDetails.Add((EventAffiliateDetailsEntity)relatedEntity);
					break;
				case "AfcampaignSubAdvocate_":
					SetupSyncAfcampaignSubAdvocate_(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
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
				case "Organization":
					DesetupSyncOrganization(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "AfaffiliateCampaign":
					base.PerformRelatedEntityRemoval(this.AfaffiliateCampaign, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AfcampaignSubAdvocate":
					base.PerformRelatedEntityRemoval(this.AfcampaignSubAdvocate, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Afcommision":
					base.PerformRelatedEntityRemoval(this.Afcommision, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AflAffiliatePaymentMethod":
					base.PerformRelatedEntityRemoval(this.AflAffiliatePaymentMethod, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Afpayment":
					base.PerformRelatedEntityRemoval(this.Afpayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventAffiliateDetails":
					base.PerformRelatedEntityRemoval(this.EventAffiliateDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AfcampaignSubAdvocate_":
					DesetupSyncAfcampaignSubAdvocate_(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
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
			if(_afcampaignSubAdvocate_!=null)
			{
				toReturn.Add(_afcampaignSubAdvocate_);
			}



			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_organization!=null)
			{
				toReturn.Add(_organization);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}


			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AfaffiliateCampaign);
			toReturn.Add(this.AfcampaignSubAdvocate);
			toReturn.Add(this.Afcommision);
			toReturn.Add(this.AflAffiliatePaymentMethod);
			toReturn.Add(this.Afpayment);
			toReturn.Add(this.EventAffiliateDetails);

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
				info.AddValue("_afaffiliateCampaign", ((_afaffiliateCampaign!=null) && (_afaffiliateCampaign.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaign:null);
				info.AddValue("_afcampaignSubAdvocate", ((_afcampaignSubAdvocate!=null) && (_afcampaignSubAdvocate.Count>0) && !this.MarkedForDeletion)?_afcampaignSubAdvocate:null);
				info.AddValue("_afcommision", ((_afcommision!=null) && (_afcommision.Count>0) && !this.MarkedForDeletion)?_afcommision:null);
				info.AddValue("_aflAffiliatePaymentMethod", ((_aflAffiliatePaymentMethod!=null) && (_aflAffiliatePaymentMethod.Count>0) && !this.MarkedForDeletion)?_aflAffiliatePaymentMethod:null);
				info.AddValue("_afpayment", ((_afpayment!=null) && (_afpayment.Count>0) && !this.MarkedForDeletion)?_afpayment:null);
				info.AddValue("_eventAffiliateDetails", ((_eventAffiliateDetails!=null) && (_eventAffiliateDetails.Count>0) && !this.MarkedForDeletion)?_eventAffiliateDetails:null);
				info.AddValue("_afaffiliateCampaignCollectionViaAfcommision", ((_afaffiliateCampaignCollectionViaAfcommision!=null) && (_afaffiliateCampaignCollectionViaAfcommision.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaignCollectionViaAfcommision:null);
				info.AddValue("_afcampaignCollectionViaAfaffiliateCampaign", ((_afcampaignCollectionViaAfaffiliateCampaign!=null) && (_afcampaignCollectionViaAfaffiliateCampaign.Count>0) && !this.MarkedForDeletion)?_afcampaignCollectionViaAfaffiliateCampaign:null);
				info.AddValue("_afcampaignCollectionViaAfcampaignSubAdvocate", ((_afcampaignCollectionViaAfcampaignSubAdvocate!=null) && (_afcampaignCollectionViaAfcampaignSubAdvocate.Count>0) && !this.MarkedForDeletion)?_afcampaignCollectionViaAfcampaignSubAdvocate:null);
				info.AddValue("_afpaymentCollectionViaAfcommision", ((_afpaymentCollectionViaAfcommision!=null) && (_afpaymentCollectionViaAfcommision.Count>0) && !this.MarkedForDeletion)?_afpaymentCollectionViaAfcommision:null);
				info.AddValue("_eventsCollectionViaEventAffiliateDetails", ((_eventsCollectionViaEventAffiliateDetails!=null) && (_eventsCollectionViaEventAffiliateDetails.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAffiliateDetails:null);
				info.AddValue("_organization", (!this.MarkedForDeletion?_organization:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_afcampaignSubAdvocate_", (!this.MarkedForDeletion?_afcampaignSubAdvocate_:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AffiliateProfileFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AffiliateProfileFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AffiliateProfileRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfcampaignSubAdvocate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignSubAdvocate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignSubAdvocateFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcommision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcommision()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcommisionFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AflAffiliatePaymentMethod' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAflAffiliatePaymentMethod()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AflAffiliatePaymentMethodFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afpayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfpayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfpaymentFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAffiliateDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAffiliateDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAffiliateDetailsFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignCollectionViaAfcommision()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfaffiliateCampaignCollectionViaAfcommision"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AffiliateProfileFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId, "AffiliateProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCollectionViaAfaffiliateCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfcampaignCollectionViaAfaffiliateCampaign"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AffiliateProfileFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId, "AffiliateProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCollectionViaAfcampaignSubAdvocate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfcampaignCollectionViaAfcampaignSubAdvocate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AffiliateProfileFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId, "AffiliateProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afpayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfpaymentCollectionViaAfcommision()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfpaymentCollectionViaAfcommision"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AffiliateProfileFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId, "AffiliateProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAffiliateDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAffiliateDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AffiliateProfileFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId, "AffiliateProfileEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Organization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OwnerOrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AfcampaignSubAdvocate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignSubAdvocate_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignSubAdvocateFields.CampaignSubAffiliateId, null, ComparisonOperator.Equal, this.AffiliateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.AffiliateId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AffiliateProfileEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._afaffiliateCampaign);
			collectionsQueue.Enqueue(this._afcampaignSubAdvocate);
			collectionsQueue.Enqueue(this._afcommision);
			collectionsQueue.Enqueue(this._aflAffiliatePaymentMethod);
			collectionsQueue.Enqueue(this._afpayment);
			collectionsQueue.Enqueue(this._eventAffiliateDetails);
			collectionsQueue.Enqueue(this._afaffiliateCampaignCollectionViaAfcommision);
			collectionsQueue.Enqueue(this._afcampaignCollectionViaAfaffiliateCampaign);
			collectionsQueue.Enqueue(this._afcampaignCollectionViaAfcampaignSubAdvocate);
			collectionsQueue.Enqueue(this._afpaymentCollectionViaAfcommision);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAffiliateDetails);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._afaffiliateCampaign = (EntityCollection<AfaffiliateCampaignEntity>) collectionsQueue.Dequeue();
			this._afcampaignSubAdvocate = (EntityCollection<AfcampaignSubAdvocateEntity>) collectionsQueue.Dequeue();
			this._afcommision = (EntityCollection<AfcommisionEntity>) collectionsQueue.Dequeue();
			this._aflAffiliatePaymentMethod = (EntityCollection<AflAffiliatePaymentMethodEntity>) collectionsQueue.Dequeue();
			this._afpayment = (EntityCollection<AfpaymentEntity>) collectionsQueue.Dequeue();
			this._eventAffiliateDetails = (EntityCollection<EventAffiliateDetailsEntity>) collectionsQueue.Dequeue();
			this._afaffiliateCampaignCollectionViaAfcommision = (EntityCollection<AfaffiliateCampaignEntity>) collectionsQueue.Dequeue();
			this._afcampaignCollectionViaAfaffiliateCampaign = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
			this._afcampaignCollectionViaAfcampaignSubAdvocate = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
			this._afpaymentCollectionViaAfcommision = (EntityCollection<AfpaymentEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAffiliateDetails = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._afaffiliateCampaign != null)
			{
				return true;
			}
			if (this._afcampaignSubAdvocate != null)
			{
				return true;
			}
			if (this._afcommision != null)
			{
				return true;
			}
			if (this._aflAffiliatePaymentMethod != null)
			{
				return true;
			}
			if (this._afpayment != null)
			{
				return true;
			}
			if (this._eventAffiliateDetails != null)
			{
				return true;
			}
			if (this._afaffiliateCampaignCollectionViaAfcommision != null)
			{
				return true;
			}
			if (this._afcampaignCollectionViaAfaffiliateCampaign != null)
			{
				return true;
			}
			if (this._afcampaignCollectionViaAfcampaignSubAdvocate != null)
			{
				return true;
			}
			if (this._afpaymentCollectionViaAfcommision != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAffiliateDetails != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignSubAdvocateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignSubAdvocateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcommisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcommisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AflAffiliatePaymentMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AflAffiliatePaymentMethodEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfpaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfpaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAffiliateDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAffiliateDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfpaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfpaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Organization", _organization);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("AfaffiliateCampaign", _afaffiliateCampaign);
			toReturn.Add("AfcampaignSubAdvocate", _afcampaignSubAdvocate);
			toReturn.Add("Afcommision", _afcommision);
			toReturn.Add("AflAffiliatePaymentMethod", _aflAffiliatePaymentMethod);
			toReturn.Add("Afpayment", _afpayment);
			toReturn.Add("EventAffiliateDetails", _eventAffiliateDetails);
			toReturn.Add("AfaffiliateCampaignCollectionViaAfcommision", _afaffiliateCampaignCollectionViaAfcommision);
			toReturn.Add("AfcampaignCollectionViaAfaffiliateCampaign", _afcampaignCollectionViaAfaffiliateCampaign);
			toReturn.Add("AfcampaignCollectionViaAfcampaignSubAdvocate", _afcampaignCollectionViaAfcampaignSubAdvocate);
			toReturn.Add("AfpaymentCollectionViaAfcommision", _afpaymentCollectionViaAfcommision);
			toReturn.Add("EventsCollectionViaEventAffiliateDetails", _eventsCollectionViaEventAffiliateDetails);
			toReturn.Add("AfcampaignSubAdvocate_", _afcampaignSubAdvocate_);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_afaffiliateCampaign!=null)
			{
				_afaffiliateCampaign.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignSubAdvocate!=null)
			{
				_afcampaignSubAdvocate.ActiveContext = base.ActiveContext;
			}
			if(_afcommision!=null)
			{
				_afcommision.ActiveContext = base.ActiveContext;
			}
			if(_aflAffiliatePaymentMethod!=null)
			{
				_aflAffiliatePaymentMethod.ActiveContext = base.ActiveContext;
			}
			if(_afpayment!=null)
			{
				_afpayment.ActiveContext = base.ActiveContext;
			}
			if(_eventAffiliateDetails!=null)
			{
				_eventAffiliateDetails.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaignCollectionViaAfcommision!=null)
			{
				_afaffiliateCampaignCollectionViaAfcommision.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignCollectionViaAfaffiliateCampaign!=null)
			{
				_afcampaignCollectionViaAfaffiliateCampaign.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignCollectionViaAfcampaignSubAdvocate!=null)
			{
				_afcampaignCollectionViaAfcampaignSubAdvocate.ActiveContext = base.ActiveContext;
			}
			if(_afpaymentCollectionViaAfcommision!=null)
			{
				_afpaymentCollectionViaAfcommision.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAffiliateDetails!=null)
			{
				_eventsCollectionViaEventAffiliateDetails.ActiveContext = base.ActiveContext;
			}
			if(_organization!=null)
			{
				_organization.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignSubAdvocate_!=null)
			{
				_afcampaignSubAdvocate_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_afaffiliateCampaign = null;
			_afcampaignSubAdvocate = null;
			_afcommision = null;
			_aflAffiliatePaymentMethod = null;
			_afpayment = null;
			_eventAffiliateDetails = null;
			_afaffiliateCampaignCollectionViaAfcommision = null;
			_afcampaignCollectionViaAfaffiliateCampaign = null;
			_afcampaignCollectionViaAfcampaignSubAdvocate = null;
			_afpaymentCollectionViaAfcommision = null;
			_eventsCollectionViaEventAffiliateDetails = null;
			_organization = null;
			_organizationRoleUser = null;
			_afcampaignSubAdvocate_ = null;
			_organizationRoleUser_ = null;
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

			_fieldsCustomProperties.Add("AffiliateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentAffilateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliateCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsGlobal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultIncomingPhoneLine", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaxCommisionDollar", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaxParentCommisionDollar", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PayCycle", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentThreshold", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentAddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPaymentByCheck", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDonation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CheckPaypalEmail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingInfo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaxCommisionPercentage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaxParentCommisionPercentage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsApproved", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastPaidOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NextDueOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsExpressAffiliate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsMonetize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CompanyName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignTypeAssignment", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CategoryId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WebAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OwnerOrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", AffiliateProfileEntity.Relations.OrganizationEntityUsingOwnerOrganizationId, true, signalRelatedEntity, "AffiliateProfile", resetFKFields, new int[] { (int)AffiliateProfileFieldIndex.OwnerOrganizationId } );		
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
				base.PerformSetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", AffiliateProfileEntity.Relations.OrganizationEntityUsingOwnerOrganizationId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", AffiliateProfileEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "AffiliateProfile", resetFKFields, new int[] { (int)AffiliateProfileFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", AffiliateProfileEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _afcampaignSubAdvocate_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfcampaignSubAdvocate_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afcampaignSubAdvocate_, new PropertyChangedEventHandler( OnAfcampaignSubAdvocate_PropertyChanged ), "AfcampaignSubAdvocate_", AffiliateProfileEntity.Relations.AfcampaignSubAdvocateEntityUsingCampaignSubAffiliateId, false, signalRelatedEntity, "AffiliateProfile_", false, new int[] { (int)AffiliateProfileFieldIndex.AffiliateId } );
			_afcampaignSubAdvocate_ = null;
		}
		
		/// <summary> setups the sync logic for member _afcampaignSubAdvocate_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfcampaignSubAdvocate_(IEntity2 relatedEntity)
		{
			if(_afcampaignSubAdvocate_!=relatedEntity)
			{
				DesetupSyncAfcampaignSubAdvocate_(true, true);
				_afcampaignSubAdvocate_ = (AfcampaignSubAdvocateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afcampaignSubAdvocate_, new PropertyChangedEventHandler( OnAfcampaignSubAdvocate_PropertyChanged ), "AfcampaignSubAdvocate_", AffiliateProfileEntity.Relations.AfcampaignSubAdvocateEntityUsingCampaignSubAffiliateId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfcampaignSubAdvocate_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", AffiliateProfileEntity.Relations.OrganizationRoleUserEntityUsingAffiliateId, true, signalRelatedEntity, "AffiliateProfile_", false, new int[] { (int)AffiliateProfileFieldIndex.AffiliateId } );
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", AffiliateProfileEntity.Relations.OrganizationRoleUserEntityUsingAffiliateId, true, new string[] {  } );
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

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AffiliateProfileEntity</param>
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
		public  static AffiliateProfileRelations Relations
		{
			get	{ return new AffiliateProfileRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaign
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfaffiliateCampaign")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, null, null, "AfaffiliateCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("AfcampaignSubAdvocate")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AfcampaignSubAdvocateEntity, 0, null, null, null, null, "AfcampaignSubAdvocate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcommision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcommision
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfcommisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcommisionEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afcommision")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AfcommisionEntity, 0, null, null, null, null, "Afcommision", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AflAffiliatePaymentMethod' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAflAffiliatePaymentMethod
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AflAffiliatePaymentMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AflAffiliatePaymentMethodEntityFactory))),
					(IEntityRelation)GetRelationsForField("AflAffiliatePaymentMethod")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AflAffiliatePaymentMethodEntity, 0, null, null, null, null, "AflAffiliatePaymentMethod", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afpayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfpayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfpaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfpaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afpayment")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AfpaymentEntity, 0, null, null, null, null, "Afpayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAffiliateDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAffiliateDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventAffiliateDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAffiliateDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAffiliateDetails")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.EventAffiliateDetailsEntity, 0, null, null, null, null, "EventAffiliateDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignCollectionViaAfcommision
		{
			get
			{
				IEntityRelation intermediateRelation = AffiliateProfileEntity.Relations.AfcommisionEntityUsingAffiliateId;
				intermediateRelation.SetAliases(string.Empty, "Afcommision_");
				return new PrefetchPathElement2(new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, GetRelationsForField("AfaffiliateCampaignCollectionViaAfcommision"), null, "AfaffiliateCampaignCollectionViaAfcommision", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCollectionViaAfaffiliateCampaign
		{
			get
			{
				IEntityRelation intermediateRelation = AffiliateProfileEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateId;
				intermediateRelation.SetAliases(string.Empty, "AfaffiliateCampaign_");
				return new PrefetchPathElement2(new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, GetRelationsForField("AfcampaignCollectionViaAfaffiliateCampaign"), null, "AfcampaignCollectionViaAfaffiliateCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCollectionViaAfcampaignSubAdvocate
		{
			get
			{
				IEntityRelation intermediateRelation = AffiliateProfileEntity.Relations.AfcampaignSubAdvocateEntityUsingAffiliateId;
				intermediateRelation.SetAliases(string.Empty, "AfcampaignSubAdvocate_");
				return new PrefetchPathElement2(new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, GetRelationsForField("AfcampaignCollectionViaAfcampaignSubAdvocate"), null, "AfcampaignCollectionViaAfcampaignSubAdvocate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afpayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfpaymentCollectionViaAfcommision
		{
			get
			{
				IEntityRelation intermediateRelation = AffiliateProfileEntity.Relations.AfcommisionEntityUsingAffiliateId;
				intermediateRelation.SetAliases(string.Empty, "Afcommision_");
				return new PrefetchPathElement2(new EntityCollection<AfpaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfpaymentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AfpaymentEntity, 0, null, null, GetRelationsForField("AfpaymentCollectionViaAfcommision"), null, "AfpaymentCollectionViaAfcommision", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAffiliateDetails
		{
			get
			{
				IEntityRelation intermediateRelation = AffiliateProfileEntity.Relations.EventAffiliateDetailsEntityUsingAffiliateId;
				intermediateRelation.SetAliases(string.Empty, "EventAffiliateDetails_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAffiliateDetails"), null, "EventsCollectionViaEventAffiliateDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Organization")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfcampaignSubAdvocate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignSubAdvocate_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignSubAdvocateEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfcampaignSubAdvocate_")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.AfcampaignSubAdvocateEntity, 0, null, null, null, null, "AfcampaignSubAdvocate_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.AffiliateProfileEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AffiliateProfileEntity.CustomProperties;}
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
			get { return AffiliateProfileEntity.FieldsCustomProperties;}
		}

		/// <summary> The AffiliateId property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."AffiliateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 AffiliateId
		{
			get { return (System.Int64)GetValue((int)AffiliateProfileFieldIndex.AffiliateId, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.AffiliateId, value); }
		}

		/// <summary> The ParentAffilateId property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."ParentAffilateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentAffilateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AffiliateProfileFieldIndex.ParentAffilateId, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.ParentAffilateId, value); }
		}

		/// <summary> The AffiliateCode property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."AffiliateCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String AffiliateCode
		{
			get { return (System.String)GetValue((int)AffiliateProfileFieldIndex.AffiliateCode, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.AffiliateCode, value); }
		}

		/// <summary> The CreatedDate property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedDate
		{
			get { return (System.DateTime)GetValue((int)AffiliateProfileFieldIndex.CreatedDate, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.CreatedDate, value); }
		}

		/// <summary> The LastModifiedDate property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."LastModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime LastModifiedDate
		{
			get { return (System.DateTime)GetValue((int)AffiliateProfileFieldIndex.LastModifiedDate, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.LastModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AffiliateProfileFieldIndex.IsActive, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.IsActive, value); }
		}

		/// <summary> The IsGlobal property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."IsGlobal"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsGlobal
		{
			get { return (System.Boolean)GetValue((int)AffiliateProfileFieldIndex.IsGlobal, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.IsGlobal, value); }
		}

		/// <summary> The DefaultIncomingPhoneLine property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."DefaultIncomingPhoneLine"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DefaultIncomingPhoneLine
		{
			get { return (System.String)GetValue((int)AffiliateProfileFieldIndex.DefaultIncomingPhoneLine, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.DefaultIncomingPhoneLine, value); }
		}

		/// <summary> The MaxCommisionDollar property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."MaxCommisionDollar"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MaxCommisionDollar
		{
			get { return (Nullable<System.Decimal>)GetValue((int)AffiliateProfileFieldIndex.MaxCommisionDollar, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.MaxCommisionDollar, value); }
		}

		/// <summary> The MaxParentCommisionDollar property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."MaxParentCommisionDollar"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MaxParentCommisionDollar
		{
			get { return (Nullable<System.Decimal>)GetValue((int)AffiliateProfileFieldIndex.MaxParentCommisionDollar, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.MaxParentCommisionDollar, value); }
		}

		/// <summary> The PayCycle property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."PayCycle"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PayCycle
		{
			get { return (System.Int32)GetValue((int)AffiliateProfileFieldIndex.PayCycle, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.PayCycle, value); }
		}

		/// <summary> The PaymentThreshold property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."PaymentThreshold"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal PaymentThreshold
		{
			get { return (System.Decimal)GetValue((int)AffiliateProfileFieldIndex.PaymentThreshold, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.PaymentThreshold, value); }
		}

		/// <summary> The PaymentAddressId property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."PaymentAddressId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PaymentAddressId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AffiliateProfileFieldIndex.PaymentAddressId, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.PaymentAddressId, value); }
		}

		/// <summary> The IsPaymentByCheck property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."IsPaymentByCheck"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsPaymentByCheck
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AffiliateProfileFieldIndex.IsPaymentByCheck, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.IsPaymentByCheck, value); }
		}

		/// <summary> The IsDonation property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."IsDonation"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDonation
		{
			get { return (System.Boolean)GetValue((int)AffiliateProfileFieldIndex.IsDonation, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.IsDonation, value); }
		}

		/// <summary> The CheckPaypalEmail property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."CheckPaypalEMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CheckPaypalEmail
		{
			get { return (System.String)GetValue((int)AffiliateProfileFieldIndex.CheckPaypalEmail, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.CheckPaypalEmail, value); }
		}

		/// <summary> The MarketingInfo property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."MarketingInfo"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MarketingInfo
		{
			get { return (System.String)GetValue((int)AffiliateProfileFieldIndex.MarketingInfo, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.MarketingInfo, value); }
		}

		/// <summary> The MaxCommisionPercentage property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."MaxCommisionPercentage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MaxCommisionPercentage
		{
			get { return (Nullable<System.Decimal>)GetValue((int)AffiliateProfileFieldIndex.MaxCommisionPercentage, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.MaxCommisionPercentage, value); }
		}

		/// <summary> The MaxParentCommisionPercentage property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."MaxParentCommisionPercentage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MaxParentCommisionPercentage
		{
			get { return (Nullable<System.Decimal>)GetValue((int)AffiliateProfileFieldIndex.MaxParentCommisionPercentage, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.MaxParentCommisionPercentage, value); }
		}

		/// <summary> The IsApproved property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."IsApproved"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsApproved
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AffiliateProfileFieldIndex.IsApproved, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.IsApproved, value); }
		}

		/// <summary> The LastPaidOn property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."LastPaidOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastPaidOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AffiliateProfileFieldIndex.LastPaidOn, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.LastPaidOn, value); }
		}

		/// <summary> The NextDueOn property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."NextDueOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> NextDueOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AffiliateProfileFieldIndex.NextDueOn, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.NextDueOn, value); }
		}

		/// <summary> The IsExpressAffiliate property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."isExpressAffiliate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsExpressAffiliate
		{
			get { return (System.Boolean)GetValue((int)AffiliateProfileFieldIndex.IsExpressAffiliate, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.IsExpressAffiliate, value); }
		}

		/// <summary> The IsMonetize property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."isMonetize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsMonetize
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AffiliateProfileFieldIndex.IsMonetize, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.IsMonetize, value); }
		}

		/// <summary> The CompanyName property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."CompanyName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CompanyName
		{
			get { return (System.String)GetValue((int)AffiliateProfileFieldIndex.CompanyName, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.CompanyName, value); }
		}

		/// <summary> The CampaignTypeAssignment property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."CampaignTypeAssignment"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 CampaignTypeAssignment
		{
			get { return (System.Int16)GetValue((int)AffiliateProfileFieldIndex.CampaignTypeAssignment, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.CampaignTypeAssignment, value); }
		}

		/// <summary> The CategoryId property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."CategoryId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> CategoryId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AffiliateProfileFieldIndex.CategoryId, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.CategoryId, value); }
		}

		/// <summary> The WebAddress property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."WebAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String WebAddress
		{
			get { return (System.String)GetValue((int)AffiliateProfileFieldIndex.WebAddress, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.WebAddress, value); }
		}

		/// <summary> The OwnerOrganizationId property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."OwnerOrganizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> OwnerOrganizationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AffiliateProfileFieldIndex.OwnerOrganizationId, false); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.OwnerOrganizationId, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity AffiliateProfile<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAffiliateProfile"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)AffiliateProfileFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)AffiliateProfileFieldIndex.CreatedByOrgRoleUserId, value); }
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
					_afaffiliateCampaign.SetContainingEntityInfo(this, "AffiliateProfile");
				}
				return _afaffiliateCampaign;
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
					_afcampaignSubAdvocate.SetContainingEntityInfo(this, "AffiliateProfile");
				}
				return _afcampaignSubAdvocate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcommisionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcommisionEntity))]
		public virtual EntityCollection<AfcommisionEntity> Afcommision
		{
			get
			{
				if(_afcommision==null)
				{
					_afcommision = new EntityCollection<AfcommisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcommisionEntityFactory)));
					_afcommision.SetContainingEntityInfo(this, "AffiliateProfile");
				}
				return _afcommision;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AflAffiliatePaymentMethodEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AflAffiliatePaymentMethodEntity))]
		public virtual EntityCollection<AflAffiliatePaymentMethodEntity> AflAffiliatePaymentMethod
		{
			get
			{
				if(_aflAffiliatePaymentMethod==null)
				{
					_aflAffiliatePaymentMethod = new EntityCollection<AflAffiliatePaymentMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AflAffiliatePaymentMethodEntityFactory)));
					_aflAffiliatePaymentMethod.SetContainingEntityInfo(this, "AffiliateProfile");
				}
				return _aflAffiliatePaymentMethod;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfpaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfpaymentEntity))]
		public virtual EntityCollection<AfpaymentEntity> Afpayment
		{
			get
			{
				if(_afpayment==null)
				{
					_afpayment = new EntityCollection<AfpaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfpaymentEntityFactory)));
					_afpayment.SetContainingEntityInfo(this, "AffiliateProfile");
				}
				return _afpayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAffiliateDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAffiliateDetailsEntity))]
		public virtual EntityCollection<EventAffiliateDetailsEntity> EventAffiliateDetails
		{
			get
			{
				if(_eventAffiliateDetails==null)
				{
					_eventAffiliateDetails = new EntityCollection<EventAffiliateDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAffiliateDetailsEntityFactory)));
					_eventAffiliateDetails.SetContainingEntityInfo(this, "AffiliateProfile");
				}
				return _eventAffiliateDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfaffiliateCampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfaffiliateCampaignEntity))]
		public virtual EntityCollection<AfaffiliateCampaignEntity> AfaffiliateCampaignCollectionViaAfcommision
		{
			get
			{
				if(_afaffiliateCampaignCollectionViaAfcommision==null)
				{
					_afaffiliateCampaignCollectionViaAfcommision = new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory)));
					_afaffiliateCampaignCollectionViaAfcommision.IsReadOnly=true;
				}
				return _afaffiliateCampaignCollectionViaAfcommision;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> AfcampaignCollectionViaAfaffiliateCampaign
		{
			get
			{
				if(_afcampaignCollectionViaAfaffiliateCampaign==null)
				{
					_afcampaignCollectionViaAfaffiliateCampaign = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaignCollectionViaAfaffiliateCampaign.IsReadOnly=true;
				}
				return _afcampaignCollectionViaAfaffiliateCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> AfcampaignCollectionViaAfcampaignSubAdvocate
		{
			get
			{
				if(_afcampaignCollectionViaAfcampaignSubAdvocate==null)
				{
					_afcampaignCollectionViaAfcampaignSubAdvocate = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaignCollectionViaAfcampaignSubAdvocate.IsReadOnly=true;
				}
				return _afcampaignCollectionViaAfcampaignSubAdvocate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfpaymentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfpaymentEntity))]
		public virtual EntityCollection<AfpaymentEntity> AfpaymentCollectionViaAfcommision
		{
			get
			{
				if(_afpaymentCollectionViaAfcommision==null)
				{
					_afpaymentCollectionViaAfcommision = new EntityCollection<AfpaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfpaymentEntityFactory)));
					_afpaymentCollectionViaAfcommision.IsReadOnly=true;
				}
				return _afpaymentCollectionViaAfcommision;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAffiliateDetails
		{
			get
			{
				if(_eventsCollectionViaEventAffiliateDetails==null)
				{
					_eventsCollectionViaEventAffiliateDetails = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAffiliateDetails.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAffiliateDetails;
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
							_organization.UnsetRelatedEntity(this, "AffiliateProfile");
						}
					}
					else
					{
						if(_organization!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AffiliateProfile");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "AffiliateProfile");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AffiliateProfile");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AfcampaignSubAdvocateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfcampaignSubAdvocateEntity AfcampaignSubAdvocate_
		{
			get
			{
				return _afcampaignSubAdvocate_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfcampaignSubAdvocate_(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "AffiliateProfile_");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_afcampaignSubAdvocate_ !=null);
						DesetupSyncAfcampaignSubAdvocate_(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("AfcampaignSubAdvocate_");
						}
					}
					else
					{
						if(_afcampaignSubAdvocate_!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "AffiliateProfile_");
							SetupSyncAfcampaignSubAdvocate_(relatedEntity);
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
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "AffiliateProfile_");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_organizationRoleUser_ !=null);
						DesetupSyncOrganizationRoleUser_(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("OrganizationRoleUser_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "AffiliateProfile_");
							SetupSyncOrganizationRoleUser_(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.AffiliateProfileEntity; }
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
