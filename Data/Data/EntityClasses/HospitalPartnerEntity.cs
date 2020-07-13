///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:46
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
	/// Entity class which represents the entity 'HospitalPartner'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class HospitalPartnerEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventHospitalPartnerEntity> _eventHospitalPartner;
		private EntityCollection<HospitalPartnerHospitalFacilityEntity> _hospitalPartnerHospitalFacility;
		private EntityCollection<HospitalPartnerPackageEntity> _hospitalPartnerPackage;
		private EntityCollection<HospitalPartnerShippingOptionEntity> _hospitalPartnerShippingOption;
		private EntityCollection<HospitalPartnerTerritoryEntity> _hospitalPartnerTerritory;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventHospitalPartner;
		private EntityCollection<HospitalFacilityEntity> _hospitalFacilityCollectionViaHospitalPartnerHospitalFacility;
		private EntityCollection<PackageEntity> _packageCollectionViaHospitalPartnerPackage;
		private EntityCollection<ShippingOptionEntity> _shippingOptionCollectionViaHospitalPartnerShippingOption;
		private EntityCollection<TerritoryEntity> _territoryCollectionViaHospitalPartnerTerritory;
		private HafTemplateEntity _hafTemplate;
		private MedicalVendorProfileEntity _medicalVendorProfile;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name HafTemplate</summary>
			public static readonly string HafTemplate = "HafTemplate";
			/// <summary>Member name EventHospitalPartner</summary>
			public static readonly string EventHospitalPartner = "EventHospitalPartner";
			/// <summary>Member name HospitalPartnerHospitalFacility</summary>
			public static readonly string HospitalPartnerHospitalFacility = "HospitalPartnerHospitalFacility";
			/// <summary>Member name HospitalPartnerPackage</summary>
			public static readonly string HospitalPartnerPackage = "HospitalPartnerPackage";
			/// <summary>Member name HospitalPartnerShippingOption</summary>
			public static readonly string HospitalPartnerShippingOption = "HospitalPartnerShippingOption";
			/// <summary>Member name HospitalPartnerTerritory</summary>
			public static readonly string HospitalPartnerTerritory = "HospitalPartnerTerritory";
			/// <summary>Member name EventsCollectionViaEventHospitalPartner</summary>
			public static readonly string EventsCollectionViaEventHospitalPartner = "EventsCollectionViaEventHospitalPartner";
			/// <summary>Member name HospitalFacilityCollectionViaHospitalPartnerHospitalFacility</summary>
			public static readonly string HospitalFacilityCollectionViaHospitalPartnerHospitalFacility = "HospitalFacilityCollectionViaHospitalPartnerHospitalFacility";
			/// <summary>Member name PackageCollectionViaHospitalPartnerPackage</summary>
			public static readonly string PackageCollectionViaHospitalPartnerPackage = "PackageCollectionViaHospitalPartnerPackage";
			/// <summary>Member name ShippingOptionCollectionViaHospitalPartnerShippingOption</summary>
			public static readonly string ShippingOptionCollectionViaHospitalPartnerShippingOption = "ShippingOptionCollectionViaHospitalPartnerShippingOption";
			/// <summary>Member name TerritoryCollectionViaHospitalPartnerTerritory</summary>
			public static readonly string TerritoryCollectionViaHospitalPartnerTerritory = "TerritoryCollectionViaHospitalPartnerTerritory";
			/// <summary>Member name MedicalVendorProfile</summary>
			public static readonly string MedicalVendorProfile = "MedicalVendorProfile";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static HospitalPartnerEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public HospitalPartnerEntity():base("HospitalPartnerEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public HospitalPartnerEntity(IEntityFields2 fields):base("HospitalPartnerEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this HospitalPartnerEntity</param>
		public HospitalPartnerEntity(IValidator validator):base("HospitalPartnerEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="hospitalPartnerId">PK value for HospitalPartner which data should be fetched into this HospitalPartner object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HospitalPartnerEntity(System.Int64 hospitalPartnerId):base("HospitalPartnerEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.HospitalPartnerId = hospitalPartnerId;
		}

		/// <summary> CTor</summary>
		/// <param name="hospitalPartnerId">PK value for HospitalPartner which data should be fetched into this HospitalPartner object</param>
		/// <param name="validator">The custom validator object for this HospitalPartnerEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HospitalPartnerEntity(System.Int64 hospitalPartnerId, IValidator validator):base("HospitalPartnerEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.HospitalPartnerId = hospitalPartnerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected HospitalPartnerEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventHospitalPartner = (EntityCollection<EventHospitalPartnerEntity>)info.GetValue("_eventHospitalPartner", typeof(EntityCollection<EventHospitalPartnerEntity>));
				_hospitalPartnerHospitalFacility = (EntityCollection<HospitalPartnerHospitalFacilityEntity>)info.GetValue("_hospitalPartnerHospitalFacility", typeof(EntityCollection<HospitalPartnerHospitalFacilityEntity>));
				_hospitalPartnerPackage = (EntityCollection<HospitalPartnerPackageEntity>)info.GetValue("_hospitalPartnerPackage", typeof(EntityCollection<HospitalPartnerPackageEntity>));
				_hospitalPartnerShippingOption = (EntityCollection<HospitalPartnerShippingOptionEntity>)info.GetValue("_hospitalPartnerShippingOption", typeof(EntityCollection<HospitalPartnerShippingOptionEntity>));
				_hospitalPartnerTerritory = (EntityCollection<HospitalPartnerTerritoryEntity>)info.GetValue("_hospitalPartnerTerritory", typeof(EntityCollection<HospitalPartnerTerritoryEntity>));
				_eventsCollectionViaEventHospitalPartner = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventHospitalPartner", typeof(EntityCollection<EventsEntity>));
				_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility = (EntityCollection<HospitalFacilityEntity>)info.GetValue("_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility", typeof(EntityCollection<HospitalFacilityEntity>));
				_packageCollectionViaHospitalPartnerPackage = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaHospitalPartnerPackage", typeof(EntityCollection<PackageEntity>));
				_shippingOptionCollectionViaHospitalPartnerShippingOption = (EntityCollection<ShippingOptionEntity>)info.GetValue("_shippingOptionCollectionViaHospitalPartnerShippingOption", typeof(EntityCollection<ShippingOptionEntity>));
				_territoryCollectionViaHospitalPartnerTerritory = (EntityCollection<TerritoryEntity>)info.GetValue("_territoryCollectionViaHospitalPartnerTerritory", typeof(EntityCollection<TerritoryEntity>));
				_hafTemplate = (HafTemplateEntity)info.GetValue("_hafTemplate", typeof(HafTemplateEntity));
				if(_hafTemplate!=null)
				{
					_hafTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_medicalVendorProfile = (MedicalVendorProfileEntity)info.GetValue("_medicalVendorProfile", typeof(MedicalVendorProfileEntity));
				if(_medicalVendorProfile!=null)
				{
					_medicalVendorProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((HospitalPartnerFieldIndex)fieldIndex)
			{
				case HospitalPartnerFieldIndex.HospitalPartnerId:
					DesetupSyncMedicalVendorProfile(true, false);
					break;
				case HospitalPartnerFieldIndex.HafTemplateId:
					DesetupSyncHafTemplate(true, false);
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
				case "HafTemplate":
					this.HafTemplate = (HafTemplateEntity)entity;
					break;
				case "EventHospitalPartner":
					this.EventHospitalPartner.Add((EventHospitalPartnerEntity)entity);
					break;
				case "HospitalPartnerHospitalFacility":
					this.HospitalPartnerHospitalFacility.Add((HospitalPartnerHospitalFacilityEntity)entity);
					break;
				case "HospitalPartnerPackage":
					this.HospitalPartnerPackage.Add((HospitalPartnerPackageEntity)entity);
					break;
				case "HospitalPartnerShippingOption":
					this.HospitalPartnerShippingOption.Add((HospitalPartnerShippingOptionEntity)entity);
					break;
				case "HospitalPartnerTerritory":
					this.HospitalPartnerTerritory.Add((HospitalPartnerTerritoryEntity)entity);
					break;
				case "EventsCollectionViaEventHospitalPartner":
					this.EventsCollectionViaEventHospitalPartner.IsReadOnly = false;
					this.EventsCollectionViaEventHospitalPartner.Add((EventsEntity)entity);
					this.EventsCollectionViaEventHospitalPartner.IsReadOnly = true;
					break;
				case "HospitalFacilityCollectionViaHospitalPartnerHospitalFacility":
					this.HospitalFacilityCollectionViaHospitalPartnerHospitalFacility.IsReadOnly = false;
					this.HospitalFacilityCollectionViaHospitalPartnerHospitalFacility.Add((HospitalFacilityEntity)entity);
					this.HospitalFacilityCollectionViaHospitalPartnerHospitalFacility.IsReadOnly = true;
					break;
				case "PackageCollectionViaHospitalPartnerPackage":
					this.PackageCollectionViaHospitalPartnerPackage.IsReadOnly = false;
					this.PackageCollectionViaHospitalPartnerPackage.Add((PackageEntity)entity);
					this.PackageCollectionViaHospitalPartnerPackage.IsReadOnly = true;
					break;
				case "ShippingOptionCollectionViaHospitalPartnerShippingOption":
					this.ShippingOptionCollectionViaHospitalPartnerShippingOption.IsReadOnly = false;
					this.ShippingOptionCollectionViaHospitalPartnerShippingOption.Add((ShippingOptionEntity)entity);
					this.ShippingOptionCollectionViaHospitalPartnerShippingOption.IsReadOnly = true;
					break;
				case "TerritoryCollectionViaHospitalPartnerTerritory":
					this.TerritoryCollectionViaHospitalPartnerTerritory.IsReadOnly = false;
					this.TerritoryCollectionViaHospitalPartnerTerritory.Add((TerritoryEntity)entity);
					this.TerritoryCollectionViaHospitalPartnerTerritory.IsReadOnly = true;
					break;
				case "MedicalVendorProfile":
					this.MedicalVendorProfile = (MedicalVendorProfileEntity)entity;
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
			return HospitalPartnerEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "HafTemplate":
					toReturn.Add(HospitalPartnerEntity.Relations.HafTemplateEntityUsingHafTemplateId);
					break;
				case "EventHospitalPartner":
					toReturn.Add(HospitalPartnerEntity.Relations.EventHospitalPartnerEntityUsingHospitalPartnerId);
					break;
				case "HospitalPartnerHospitalFacility":
					toReturn.Add(HospitalPartnerEntity.Relations.HospitalPartnerHospitalFacilityEntityUsingHospitalPartnerId);
					break;
				case "HospitalPartnerPackage":
					toReturn.Add(HospitalPartnerEntity.Relations.HospitalPartnerPackageEntityUsingHospitalpartnerId);
					break;
				case "HospitalPartnerShippingOption":
					toReturn.Add(HospitalPartnerEntity.Relations.HospitalPartnerShippingOptionEntityUsingHospitalPartnerId);
					break;
				case "HospitalPartnerTerritory":
					toReturn.Add(HospitalPartnerEntity.Relations.HospitalPartnerTerritoryEntityUsingHospitalPartnerId);
					break;
				case "EventsCollectionViaEventHospitalPartner":
					toReturn.Add(HospitalPartnerEntity.Relations.EventHospitalPartnerEntityUsingHospitalPartnerId, "HospitalPartnerEntity__", "EventHospitalPartner_", JoinHint.None);
					toReturn.Add(EventHospitalPartnerEntity.Relations.EventsEntityUsingEventId, "EventHospitalPartner_", string.Empty, JoinHint.None);
					break;
				case "HospitalFacilityCollectionViaHospitalPartnerHospitalFacility":
					toReturn.Add(HospitalPartnerEntity.Relations.HospitalPartnerHospitalFacilityEntityUsingHospitalPartnerId, "HospitalPartnerEntity__", "HospitalPartnerHospitalFacility_", JoinHint.None);
					toReturn.Add(HospitalPartnerHospitalFacilityEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId, "HospitalPartnerHospitalFacility_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaHospitalPartnerPackage":
					toReturn.Add(HospitalPartnerEntity.Relations.HospitalPartnerPackageEntityUsingHospitalpartnerId, "HospitalPartnerEntity__", "HospitalPartnerPackage_", JoinHint.None);
					toReturn.Add(HospitalPartnerPackageEntity.Relations.PackageEntityUsingPackageId, "HospitalPartnerPackage_", string.Empty, JoinHint.None);
					break;
				case "ShippingOptionCollectionViaHospitalPartnerShippingOption":
					toReturn.Add(HospitalPartnerEntity.Relations.HospitalPartnerShippingOptionEntityUsingHospitalPartnerId, "HospitalPartnerEntity__", "HospitalPartnerShippingOption_", JoinHint.None);
					toReturn.Add(HospitalPartnerShippingOptionEntity.Relations.ShippingOptionEntityUsingShippingOptionId, "HospitalPartnerShippingOption_", string.Empty, JoinHint.None);
					break;
				case "TerritoryCollectionViaHospitalPartnerTerritory":
					toReturn.Add(HospitalPartnerEntity.Relations.HospitalPartnerTerritoryEntityUsingHospitalPartnerId, "HospitalPartnerEntity__", "HospitalPartnerTerritory_", JoinHint.None);
					toReturn.Add(HospitalPartnerTerritoryEntity.Relations.TerritoryEntityUsingTerritoryId, "HospitalPartnerTerritory_", string.Empty, JoinHint.None);
					break;
				case "MedicalVendorProfile":
					toReturn.Add(HospitalPartnerEntity.Relations.MedicalVendorProfileEntityUsingHospitalPartnerId);
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
				case "HafTemplate":
					SetupSyncHafTemplate(relatedEntity);
					break;
				case "EventHospitalPartner":
					this.EventHospitalPartner.Add((EventHospitalPartnerEntity)relatedEntity);
					break;
				case "HospitalPartnerHospitalFacility":
					this.HospitalPartnerHospitalFacility.Add((HospitalPartnerHospitalFacilityEntity)relatedEntity);
					break;
				case "HospitalPartnerPackage":
					this.HospitalPartnerPackage.Add((HospitalPartnerPackageEntity)relatedEntity);
					break;
				case "HospitalPartnerShippingOption":
					this.HospitalPartnerShippingOption.Add((HospitalPartnerShippingOptionEntity)relatedEntity);
					break;
				case "HospitalPartnerTerritory":
					this.HospitalPartnerTerritory.Add((HospitalPartnerTerritoryEntity)relatedEntity);
					break;
				case "MedicalVendorProfile":
					SetupSyncMedicalVendorProfile(relatedEntity);
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
				case "HafTemplate":
					DesetupSyncHafTemplate(false, true);
					break;
				case "EventHospitalPartner":
					base.PerformRelatedEntityRemoval(this.EventHospitalPartner, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HospitalPartnerHospitalFacility":
					base.PerformRelatedEntityRemoval(this.HospitalPartnerHospitalFacility, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HospitalPartnerPackage":
					base.PerformRelatedEntityRemoval(this.HospitalPartnerPackage, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HospitalPartnerShippingOption":
					base.PerformRelatedEntityRemoval(this.HospitalPartnerShippingOption, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HospitalPartnerTerritory":
					base.PerformRelatedEntityRemoval(this.HospitalPartnerTerritory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicalVendorProfile":
					DesetupSyncMedicalVendorProfile(false, true);
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
			if(_hafTemplate!=null)
			{
				toReturn.Add(_hafTemplate);
			}
			if(_medicalVendorProfile!=null)
			{
				toReturn.Add(_medicalVendorProfile);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventHospitalPartner);
			toReturn.Add(this.HospitalPartnerHospitalFacility);
			toReturn.Add(this.HospitalPartnerPackage);
			toReturn.Add(this.HospitalPartnerShippingOption);
			toReturn.Add(this.HospitalPartnerTerritory);

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
				info.AddValue("_eventHospitalPartner", ((_eventHospitalPartner!=null) && (_eventHospitalPartner.Count>0) && !this.MarkedForDeletion)?_eventHospitalPartner:null);
				info.AddValue("_hospitalPartnerHospitalFacility", ((_hospitalPartnerHospitalFacility!=null) && (_hospitalPartnerHospitalFacility.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerHospitalFacility:null);
				info.AddValue("_hospitalPartnerPackage", ((_hospitalPartnerPackage!=null) && (_hospitalPartnerPackage.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerPackage:null);
				info.AddValue("_hospitalPartnerShippingOption", ((_hospitalPartnerShippingOption!=null) && (_hospitalPartnerShippingOption.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerShippingOption:null);
				info.AddValue("_hospitalPartnerTerritory", ((_hospitalPartnerTerritory!=null) && (_hospitalPartnerTerritory.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerTerritory:null);
				info.AddValue("_eventsCollectionViaEventHospitalPartner", ((_eventsCollectionViaEventHospitalPartner!=null) && (_eventsCollectionViaEventHospitalPartner.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventHospitalPartner:null);
				info.AddValue("_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility", ((_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility!=null) && (_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility.Count>0) && !this.MarkedForDeletion)?_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility:null);
				info.AddValue("_packageCollectionViaHospitalPartnerPackage", ((_packageCollectionViaHospitalPartnerPackage!=null) && (_packageCollectionViaHospitalPartnerPackage.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaHospitalPartnerPackage:null);
				info.AddValue("_shippingOptionCollectionViaHospitalPartnerShippingOption", ((_shippingOptionCollectionViaHospitalPartnerShippingOption!=null) && (_shippingOptionCollectionViaHospitalPartnerShippingOption.Count>0) && !this.MarkedForDeletion)?_shippingOptionCollectionViaHospitalPartnerShippingOption:null);
				info.AddValue("_territoryCollectionViaHospitalPartnerTerritory", ((_territoryCollectionViaHospitalPartnerTerritory!=null) && (_territoryCollectionViaHospitalPartnerTerritory.Count>0) && !this.MarkedForDeletion)?_territoryCollectionViaHospitalPartnerTerritory:null);
				info.AddValue("_hafTemplate", (!this.MarkedForDeletion?_hafTemplate:null));
				info.AddValue("_medicalVendorProfile", (!this.MarkedForDeletion?_medicalVendorProfile:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(HospitalPartnerFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(HospitalPartnerFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new HospitalPartnerRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventHospitalPartner' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventHospitalPartner()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventHospitalPartnerFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartnerHospitalFacility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerHospitalFacility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerHospitalFacilityFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartnerPackage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerPackageFields.HospitalpartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartnerShippingOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerShippingOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerShippingOptionFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartnerTerritory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerTerritoryFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventHospitalPartner()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventHospitalPartner"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId, "HospitalPartnerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalFacility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalFacilityCollectionViaHospitalPartnerHospitalFacility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HospitalFacilityCollectionViaHospitalPartnerHospitalFacility"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId, "HospitalPartnerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaHospitalPartnerPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaHospitalPartnerPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId, "HospitalPartnerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingOptionCollectionViaHospitalPartnerShippingOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ShippingOptionCollectionViaHospitalPartnerShippingOption"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId, "HospitalPartnerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Territory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritoryCollectionViaHospitalPartnerTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TerritoryCollectionViaHospitalPartnerTerritory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerFields.HospitalPartnerId, null, ComparisonOperator.Equal, this.HospitalPartnerId, "HospitalPartnerEntity__"));
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
		/// the related entity of type 'MedicalVendorProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorProfileFields.OrganizationId, null, ComparisonOperator.Equal, this.HospitalPartnerId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.HospitalPartnerEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventHospitalPartner);
			collectionsQueue.Enqueue(this._hospitalPartnerHospitalFacility);
			collectionsQueue.Enqueue(this._hospitalPartnerPackage);
			collectionsQueue.Enqueue(this._hospitalPartnerShippingOption);
			collectionsQueue.Enqueue(this._hospitalPartnerTerritory);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventHospitalPartner);
			collectionsQueue.Enqueue(this._hospitalFacilityCollectionViaHospitalPartnerHospitalFacility);
			collectionsQueue.Enqueue(this._packageCollectionViaHospitalPartnerPackage);
			collectionsQueue.Enqueue(this._shippingOptionCollectionViaHospitalPartnerShippingOption);
			collectionsQueue.Enqueue(this._territoryCollectionViaHospitalPartnerTerritory);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventHospitalPartner = (EntityCollection<EventHospitalPartnerEntity>) collectionsQueue.Dequeue();
			this._hospitalPartnerHospitalFacility = (EntityCollection<HospitalPartnerHospitalFacilityEntity>) collectionsQueue.Dequeue();
			this._hospitalPartnerPackage = (EntityCollection<HospitalPartnerPackageEntity>) collectionsQueue.Dequeue();
			this._hospitalPartnerShippingOption = (EntityCollection<HospitalPartnerShippingOptionEntity>) collectionsQueue.Dequeue();
			this._hospitalPartnerTerritory = (EntityCollection<HospitalPartnerTerritoryEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventHospitalPartner = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._hospitalFacilityCollectionViaHospitalPartnerHospitalFacility = (EntityCollection<HospitalFacilityEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaHospitalPartnerPackage = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._shippingOptionCollectionViaHospitalPartnerShippingOption = (EntityCollection<ShippingOptionEntity>) collectionsQueue.Dequeue();
			this._territoryCollectionViaHospitalPartnerTerritory = (EntityCollection<TerritoryEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventHospitalPartner != null)
			{
				return true;
			}
			if (this._hospitalPartnerHospitalFacility != null)
			{
				return true;
			}
			if (this._hospitalPartnerPackage != null)
			{
				return true;
			}
			if (this._hospitalPartnerShippingOption != null)
			{
				return true;
			}
			if (this._hospitalPartnerTerritory != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventHospitalPartner != null)
			{
				return true;
			}
			if (this._hospitalFacilityCollectionViaHospitalPartnerHospitalFacility != null)
			{
				return true;
			}
			if (this._packageCollectionViaHospitalPartnerPackage != null)
			{
				return true;
			}
			if (this._shippingOptionCollectionViaHospitalPartnerShippingOption != null)
			{
				return true;
			}
			if (this._territoryCollectionViaHospitalPartnerTerritory != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventHospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventHospitalPartnerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerHospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerHospitalFacilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerPackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerShippingOptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerTerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("HafTemplate", _hafTemplate);
			toReturn.Add("EventHospitalPartner", _eventHospitalPartner);
			toReturn.Add("HospitalPartnerHospitalFacility", _hospitalPartnerHospitalFacility);
			toReturn.Add("HospitalPartnerPackage", _hospitalPartnerPackage);
			toReturn.Add("HospitalPartnerShippingOption", _hospitalPartnerShippingOption);
			toReturn.Add("HospitalPartnerTerritory", _hospitalPartnerTerritory);
			toReturn.Add("EventsCollectionViaEventHospitalPartner", _eventsCollectionViaEventHospitalPartner);
			toReturn.Add("HospitalFacilityCollectionViaHospitalPartnerHospitalFacility", _hospitalFacilityCollectionViaHospitalPartnerHospitalFacility);
			toReturn.Add("PackageCollectionViaHospitalPartnerPackage", _packageCollectionViaHospitalPartnerPackage);
			toReturn.Add("ShippingOptionCollectionViaHospitalPartnerShippingOption", _shippingOptionCollectionViaHospitalPartnerShippingOption);
			toReturn.Add("TerritoryCollectionViaHospitalPartnerTerritory", _territoryCollectionViaHospitalPartnerTerritory);
			toReturn.Add("MedicalVendorProfile", _medicalVendorProfile);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventHospitalPartner!=null)
			{
				_eventHospitalPartner.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerHospitalFacility!=null)
			{
				_hospitalPartnerHospitalFacility.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerPackage!=null)
			{
				_hospitalPartnerPackage.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerShippingOption!=null)
			{
				_hospitalPartnerShippingOption.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerTerritory!=null)
			{
				_hospitalPartnerTerritory.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventHospitalPartner!=null)
			{
				_eventsCollectionViaEventHospitalPartner.ActiveContext = base.ActiveContext;
			}
			if(_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility!=null)
			{
				_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaHospitalPartnerPackage!=null)
			{
				_packageCollectionViaHospitalPartnerPackage.ActiveContext = base.ActiveContext;
			}
			if(_shippingOptionCollectionViaHospitalPartnerShippingOption!=null)
			{
				_shippingOptionCollectionViaHospitalPartnerShippingOption.ActiveContext = base.ActiveContext;
			}
			if(_territoryCollectionViaHospitalPartnerTerritory!=null)
			{
				_territoryCollectionViaHospitalPartnerTerritory.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplate!=null)
			{
				_hafTemplate.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorProfile!=null)
			{
				_medicalVendorProfile.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventHospitalPartner = null;
			_hospitalPartnerHospitalFacility = null;
			_hospitalPartnerPackage = null;
			_hospitalPartnerShippingOption = null;
			_hospitalPartnerTerritory = null;
			_eventsCollectionViaEventHospitalPartner = null;
			_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility = null;
			_packageCollectionViaHospitalPartnerPackage = null;
			_shippingOptionCollectionViaHospitalPartnerShippingOption = null;
			_territoryCollectionViaHospitalPartnerTerritory = null;
			_hafTemplate = null;
			_medicalVendorProfile = null;
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

			_fieldsCustomProperties.Add("HospitalPartnerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AssociatedPhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdvocateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsGlobal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NormalResultValidityPeriod", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AbnormalResultValidityPeriod", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CriticalResultValidityPeriod", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailTransitDays", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HafTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CannedMessage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureSsn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecommendPackage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AskPreQualificationQuestion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachDoctorLetter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RestrictEvaluation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowOnlineShipping", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _hafTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHafTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", HospitalPartnerEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, signalRelatedEntity, "HospitalPartner", resetFKFields, new int[] { (int)HospitalPartnerFieldIndex.HafTemplateId } );		
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
				base.PerformSetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", HospitalPartnerEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _medicalVendorProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicalVendorProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicalVendorProfile, new PropertyChangedEventHandler( OnMedicalVendorProfilePropertyChanged ), "MedicalVendorProfile", HospitalPartnerEntity.Relations.MedicalVendorProfileEntityUsingHospitalPartnerId, true, signalRelatedEntity, "HospitalPartner", false, new int[] { (int)HospitalPartnerFieldIndex.HospitalPartnerId } );
			_medicalVendorProfile = null;
		}
		
		/// <summary> setups the sync logic for member _medicalVendorProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicalVendorProfile(IEntity2 relatedEntity)
		{
			if(_medicalVendorProfile!=relatedEntity)
			{
				DesetupSyncMedicalVendorProfile(true, true);
				_medicalVendorProfile = (MedicalVendorProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicalVendorProfile, new PropertyChangedEventHandler( OnMedicalVendorProfilePropertyChanged ), "MedicalVendorProfile", HospitalPartnerEntity.Relations.MedicalVendorProfileEntityUsingHospitalPartnerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicalVendorProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this HospitalPartnerEntity</param>
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
		public  static HospitalPartnerRelations Relations
		{
			get	{ return new HospitalPartnerRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventHospitalPartner' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventHospitalPartner
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventHospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventHospitalPartnerEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventHospitalPartner")[0], (int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.EventHospitalPartnerEntity, 0, null, null, null, null, "EventHospitalPartner", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartnerHospitalFacility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartnerHospitalFacility
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HospitalPartnerHospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerHospitalFacilityEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalPartnerHospitalFacility")[0], (int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.HospitalPartnerHospitalFacilityEntity, 0, null, null, null, null, "HospitalPartnerHospitalFacility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("HospitalPartnerPackage")[0], (int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.HospitalPartnerPackageEntity, 0, null, null, null, null, "HospitalPartnerPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartnerShippingOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartnerShippingOption
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HospitalPartnerShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerShippingOptionEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalPartnerShippingOption")[0], (int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.HospitalPartnerShippingOptionEntity, 0, null, null, null, null, "HospitalPartnerShippingOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("HospitalPartnerTerritory")[0], (int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.HospitalPartnerTerritoryEntity, 0, null, null, null, null, "HospitalPartnerTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventHospitalPartner
		{
			get
			{
				IEntityRelation intermediateRelation = HospitalPartnerEntity.Relations.EventHospitalPartnerEntityUsingHospitalPartnerId;
				intermediateRelation.SetAliases(string.Empty, "EventHospitalPartner_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventHospitalPartner"), null, "EventsCollectionViaEventHospitalPartner", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalFacility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalFacilityCollectionViaHospitalPartnerHospitalFacility
		{
			get
			{
				IEntityRelation intermediateRelation = HospitalPartnerEntity.Relations.HospitalPartnerHospitalFacilityEntityUsingHospitalPartnerId;
				intermediateRelation.SetAliases(string.Empty, "HospitalPartnerHospitalFacility_");
				return new PrefetchPathElement2(new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.HospitalFacilityEntity, 0, null, null, GetRelationsForField("HospitalFacilityCollectionViaHospitalPartnerHospitalFacility"), null, "HospitalFacilityCollectionViaHospitalPartnerHospitalFacility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaHospitalPartnerPackage
		{
			get
			{
				IEntityRelation intermediateRelation = HospitalPartnerEntity.Relations.HospitalPartnerPackageEntityUsingHospitalpartnerId;
				intermediateRelation.SetAliases(string.Empty, "HospitalPartnerPackage_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaHospitalPartnerPackage"), null, "PackageCollectionViaHospitalPartnerPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingOptionCollectionViaHospitalPartnerShippingOption
		{
			get
			{
				IEntityRelation intermediateRelation = HospitalPartnerEntity.Relations.HospitalPartnerShippingOptionEntityUsingHospitalPartnerId;
				intermediateRelation.SetAliases(string.Empty, "HospitalPartnerShippingOption_");
				return new PrefetchPathElement2(new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.ShippingOptionEntity, 0, null, null, GetRelationsForField("ShippingOptionCollectionViaHospitalPartnerShippingOption"), null, "ShippingOptionCollectionViaHospitalPartnerShippingOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Territory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTerritoryCollectionViaHospitalPartnerTerritory
		{
			get
			{
				IEntityRelation intermediateRelation = HospitalPartnerEntity.Relations.HospitalPartnerTerritoryEntityUsingHospitalPartnerId;
				intermediateRelation.SetAliases(string.Empty, "HospitalPartnerTerritory_");
				return new PrefetchPathElement2(new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.TerritoryEntity, 0, null, null, GetRelationsForField("TerritoryCollectionViaHospitalPartnerTerritory"), null, "TerritoryCollectionViaHospitalPartnerTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("HafTemplate")[0], (int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, null, null, "HafTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorProfile")[0], (int)Falcon.Data.EntityType.HospitalPartnerEntity, (int)Falcon.Data.EntityType.MedicalVendorProfileEntity, 0, null, null, null, null, "MedicalVendorProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return HospitalPartnerEntity.CustomProperties;}
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
			get { return HospitalPartnerEntity.FieldsCustomProperties;}
		}

		/// <summary> The HospitalPartnerId property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."HospitalPartnerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 HospitalPartnerId
		{
			get { return (System.Int64)GetValue((int)HospitalPartnerFieldIndex.HospitalPartnerId, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.HospitalPartnerId, value); }
		}

		/// <summary> The AssociatedPhoneNumber property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."AssociatedPhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AssociatedPhoneNumber
		{
			get { return (System.String)GetValue((int)HospitalPartnerFieldIndex.AssociatedPhoneNumber, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.AssociatedPhoneNumber, value); }
		}

		/// <summary> The AdvocateId property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."AdvocateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AdvocateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HospitalPartnerFieldIndex.AdvocateId, false); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.AdvocateId, value); }
		}

		/// <summary> The IsGlobal property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."IsGlobal"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsGlobal
		{
			get { return (System.Boolean)GetValue((int)HospitalPartnerFieldIndex.IsGlobal, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.IsGlobal, value); }
		}

		/// <summary> The NormalResultValidityPeriod property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."NormalResultValidityPeriod"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NormalResultValidityPeriod
		{
			get { return (System.Int32)GetValue((int)HospitalPartnerFieldIndex.NormalResultValidityPeriod, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.NormalResultValidityPeriod, value); }
		}

		/// <summary> The AbnormalResultValidityPeriod property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."AbnormalResultValidityPeriod"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AbnormalResultValidityPeriod
		{
			get { return (System.Int32)GetValue((int)HospitalPartnerFieldIndex.AbnormalResultValidityPeriod, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.AbnormalResultValidityPeriod, value); }
		}

		/// <summary> The CriticalResultValidityPeriod property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."CriticalResultValidityPeriod"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CriticalResultValidityPeriod
		{
			get { return (System.Int32)GetValue((int)HospitalPartnerFieldIndex.CriticalResultValidityPeriod, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.CriticalResultValidityPeriod, value); }
		}

		/// <summary> The MailTransitDays property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."MailTransitDays"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MailTransitDays
		{
			get { return (Nullable<System.Int32>)GetValue((int)HospitalPartnerFieldIndex.MailTransitDays, false); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.MailTransitDays, value); }
		}

		/// <summary> The HafTemplateId property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."HAFTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HafTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HospitalPartnerFieldIndex.HafTemplateId, false); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.HafTemplateId, value); }
		}

		/// <summary> The CannedMessage property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."CannedMessage"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CannedMessage
		{
			get { return (System.String)GetValue((int)HospitalPartnerFieldIndex.CannedMessage, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.CannedMessage, value); }
		}

		/// <summary> The CaptureSsn property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."CaptureSsn"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean CaptureSsn
		{
			get { return (System.Boolean)GetValue((int)HospitalPartnerFieldIndex.CaptureSsn, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.CaptureSsn, value); }
		}

		/// <summary> The RecommendPackage property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."RecommendPackage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean RecommendPackage
		{
			get { return (System.Boolean)GetValue((int)HospitalPartnerFieldIndex.RecommendPackage, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.RecommendPackage, value); }
		}

		/// <summary> The AskPreQualificationQuestion property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."AskPreQualificationQuestion"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AskPreQualificationQuestion
		{
			get { return (System.Boolean)GetValue((int)HospitalPartnerFieldIndex.AskPreQualificationQuestion, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.AskPreQualificationQuestion, value); }
		}

		/// <summary> The AttachDoctorLetter property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."AttachDoctorLetter"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachDoctorLetter
		{
			get { return (System.Boolean)GetValue((int)HospitalPartnerFieldIndex.AttachDoctorLetter, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.AttachDoctorLetter, value); }
		}

		/// <summary> The RestrictEvaluation property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."RestrictEvaluation"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean RestrictEvaluation
		{
			get { return (System.Boolean)GetValue((int)HospitalPartnerFieldIndex.RestrictEvaluation, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.RestrictEvaluation, value); }
		}

		/// <summary> The ShowOnlineShipping property of the Entity HospitalPartner<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHospitalPartner"."ShowOnlineShipping"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowOnlineShipping
		{
			get { return (System.Boolean)GetValue((int)HospitalPartnerFieldIndex.ShowOnlineShipping, true); }
			set	{ SetValue((int)HospitalPartnerFieldIndex.ShowOnlineShipping, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventHospitalPartnerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventHospitalPartnerEntity))]
		public virtual EntityCollection<EventHospitalPartnerEntity> EventHospitalPartner
		{
			get
			{
				if(_eventHospitalPartner==null)
				{
					_eventHospitalPartner = new EntityCollection<EventHospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventHospitalPartnerEntityFactory)));
					_eventHospitalPartner.SetContainingEntityInfo(this, "HospitalPartner");
				}
				return _eventHospitalPartner;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalPartnerHospitalFacilityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalPartnerHospitalFacilityEntity))]
		public virtual EntityCollection<HospitalPartnerHospitalFacilityEntity> HospitalPartnerHospitalFacility
		{
			get
			{
				if(_hospitalPartnerHospitalFacility==null)
				{
					_hospitalPartnerHospitalFacility = new EntityCollection<HospitalPartnerHospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerHospitalFacilityEntityFactory)));
					_hospitalPartnerHospitalFacility.SetContainingEntityInfo(this, "HospitalPartner");
				}
				return _hospitalPartnerHospitalFacility;
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
					_hospitalPartnerPackage.SetContainingEntityInfo(this, "HospitalPartner");
				}
				return _hospitalPartnerPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalPartnerShippingOptionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalPartnerShippingOptionEntity))]
		public virtual EntityCollection<HospitalPartnerShippingOptionEntity> HospitalPartnerShippingOption
		{
			get
			{
				if(_hospitalPartnerShippingOption==null)
				{
					_hospitalPartnerShippingOption = new EntityCollection<HospitalPartnerShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerShippingOptionEntityFactory)));
					_hospitalPartnerShippingOption.SetContainingEntityInfo(this, "HospitalPartner");
				}
				return _hospitalPartnerShippingOption;
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
					_hospitalPartnerTerritory.SetContainingEntityInfo(this, "HospitalPartner");
				}
				return _hospitalPartnerTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventHospitalPartner
		{
			get
			{
				if(_eventsCollectionViaEventHospitalPartner==null)
				{
					_eventsCollectionViaEventHospitalPartner = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventHospitalPartner.IsReadOnly=true;
				}
				return _eventsCollectionViaEventHospitalPartner;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalFacilityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalFacilityEntity))]
		public virtual EntityCollection<HospitalFacilityEntity> HospitalFacilityCollectionViaHospitalPartnerHospitalFacility
		{
			get
			{
				if(_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility==null)
				{
					_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility = new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory)));
					_hospitalFacilityCollectionViaHospitalPartnerHospitalFacility.IsReadOnly=true;
				}
				return _hospitalFacilityCollectionViaHospitalPartnerHospitalFacility;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaHospitalPartnerPackage
		{
			get
			{
				if(_packageCollectionViaHospitalPartnerPackage==null)
				{
					_packageCollectionViaHospitalPartnerPackage = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaHospitalPartnerPackage.IsReadOnly=true;
				}
				return _packageCollectionViaHospitalPartnerPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingOptionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingOptionEntity))]
		public virtual EntityCollection<ShippingOptionEntity> ShippingOptionCollectionViaHospitalPartnerShippingOption
		{
			get
			{
				if(_shippingOptionCollectionViaHospitalPartnerShippingOption==null)
				{
					_shippingOptionCollectionViaHospitalPartnerShippingOption = new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory)));
					_shippingOptionCollectionViaHospitalPartnerShippingOption.IsReadOnly=true;
				}
				return _shippingOptionCollectionViaHospitalPartnerShippingOption;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TerritoryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TerritoryEntity))]
		public virtual EntityCollection<TerritoryEntity> TerritoryCollectionViaHospitalPartnerTerritory
		{
			get
			{
				if(_territoryCollectionViaHospitalPartnerTerritory==null)
				{
					_territoryCollectionViaHospitalPartnerTerritory = new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory)));
					_territoryCollectionViaHospitalPartnerTerritory.IsReadOnly=true;
				}
				return _territoryCollectionViaHospitalPartnerTerritory;
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
							_hafTemplate.UnsetRelatedEntity(this, "HospitalPartner");
						}
					}
					else
					{
						if(_hafTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HospitalPartner");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MedicalVendorProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicalVendorProfileEntity MedicalVendorProfile
		{
			get
			{
				return _medicalVendorProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicalVendorProfile(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "HospitalPartner");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_medicalVendorProfile !=null);
						DesetupSyncMedicalVendorProfile(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("MedicalVendorProfile");
						}
					}
					else
					{
						if(_medicalVendorProfile!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "HospitalPartner");
							SetupSyncMedicalVendorProfile(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.HospitalPartnerEntity; }
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
