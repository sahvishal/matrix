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
	/// Entity class which represents the entity 'Zip'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ZipEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountEventZipSubstituteEntity> _accountEventZipSubstitute;
		private EntityCollection<AddressEntity> _address;
		private EntityCollection<EventZipEntity> _eventZip;
		private EntityCollection<TerritoryZipEntity> _territoryZip;
		private EntityCollection<ZipRadiusDistanceEntity> _zipRadiusDistance_;
		private EntityCollection<ZipRadiusDistanceEntity> _zipRadiusDistance;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountEventZipSubstitute;
		private EntityCollection<CityEntity> _cityCollectionViaAddress;
		private EntityCollection<CountryEntity> _countryCollectionViaAddress;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventZip;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAddress;
		private EntityCollection<StateEntity> _stateCollectionViaAddress;
		private EntityCollection<TerritoryEntity> _territoryCollectionViaTerritoryZip;
		private CityEntity _city;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name City</summary>
			public static readonly string City = "City";
			/// <summary>Member name AccountEventZipSubstitute</summary>
			public static readonly string AccountEventZipSubstitute = "AccountEventZipSubstitute";
			/// <summary>Member name Address</summary>
			public static readonly string Address = "Address";
			/// <summary>Member name EventZip</summary>
			public static readonly string EventZip = "EventZip";
			/// <summary>Member name TerritoryZip</summary>
			public static readonly string TerritoryZip = "TerritoryZip";
			/// <summary>Member name ZipRadiusDistance_</summary>
			public static readonly string ZipRadiusDistance_ = "ZipRadiusDistance_";
			/// <summary>Member name ZipRadiusDistance</summary>
			public static readonly string ZipRadiusDistance = "ZipRadiusDistance";
			/// <summary>Member name AccountCollectionViaAccountEventZipSubstitute</summary>
			public static readonly string AccountCollectionViaAccountEventZipSubstitute = "AccountCollectionViaAccountEventZipSubstitute";
			/// <summary>Member name CityCollectionViaAddress</summary>
			public static readonly string CityCollectionViaAddress = "CityCollectionViaAddress";
			/// <summary>Member name CountryCollectionViaAddress</summary>
			public static readonly string CountryCollectionViaAddress = "CountryCollectionViaAddress";
			/// <summary>Member name EventsCollectionViaEventZip</summary>
			public static readonly string EventsCollectionViaEventZip = "EventsCollectionViaEventZip";
			/// <summary>Member name OrganizationRoleUserCollectionViaAddress</summary>
			public static readonly string OrganizationRoleUserCollectionViaAddress = "OrganizationRoleUserCollectionViaAddress";
			/// <summary>Member name StateCollectionViaAddress</summary>
			public static readonly string StateCollectionViaAddress = "StateCollectionViaAddress";
			/// <summary>Member name TerritoryCollectionViaTerritoryZip</summary>
			public static readonly string TerritoryCollectionViaTerritoryZip = "TerritoryCollectionViaTerritoryZip";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ZipEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ZipEntity():base("ZipEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ZipEntity(IEntityFields2 fields):base("ZipEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ZipEntity</param>
		public ZipEntity(IValidator validator):base("ZipEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="zipId">PK value for Zip which data should be fetched into this Zip object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ZipEntity(System.Int64 zipId):base("ZipEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ZipId = zipId;
		}

		/// <summary> CTor</summary>
		/// <param name="zipId">PK value for Zip which data should be fetched into this Zip object</param>
		/// <param name="validator">The custom validator object for this ZipEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ZipEntity(System.Int64 zipId, IValidator validator):base("ZipEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ZipId = zipId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ZipEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_accountEventZipSubstitute = (EntityCollection<AccountEventZipSubstituteEntity>)info.GetValue("_accountEventZipSubstitute", typeof(EntityCollection<AccountEventZipSubstituteEntity>));
				_address = (EntityCollection<AddressEntity>)info.GetValue("_address", typeof(EntityCollection<AddressEntity>));
				_eventZip = (EntityCollection<EventZipEntity>)info.GetValue("_eventZip", typeof(EntityCollection<EventZipEntity>));
				_territoryZip = (EntityCollection<TerritoryZipEntity>)info.GetValue("_territoryZip", typeof(EntityCollection<TerritoryZipEntity>));
				_zipRadiusDistance_ = (EntityCollection<ZipRadiusDistanceEntity>)info.GetValue("_zipRadiusDistance_", typeof(EntityCollection<ZipRadiusDistanceEntity>));
				_zipRadiusDistance = (EntityCollection<ZipRadiusDistanceEntity>)info.GetValue("_zipRadiusDistance", typeof(EntityCollection<ZipRadiusDistanceEntity>));
				_accountCollectionViaAccountEventZipSubstitute = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountEventZipSubstitute", typeof(EntityCollection<AccountEntity>));
				_cityCollectionViaAddress = (EntityCollection<CityEntity>)info.GetValue("_cityCollectionViaAddress", typeof(EntityCollection<CityEntity>));
				_countryCollectionViaAddress = (EntityCollection<CountryEntity>)info.GetValue("_countryCollectionViaAddress", typeof(EntityCollection<CountryEntity>));
				_eventsCollectionViaEventZip = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventZip", typeof(EntityCollection<EventsEntity>));
				_organizationRoleUserCollectionViaAddress = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAddress", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_stateCollectionViaAddress = (EntityCollection<StateEntity>)info.GetValue("_stateCollectionViaAddress", typeof(EntityCollection<StateEntity>));
				_territoryCollectionViaTerritoryZip = (EntityCollection<TerritoryEntity>)info.GetValue("_territoryCollectionViaTerritoryZip", typeof(EntityCollection<TerritoryEntity>));
				_city = (CityEntity)info.GetValue("_city", typeof(CityEntity));
				if(_city!=null)
				{
					_city.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ZipFieldIndex)fieldIndex)
			{
				case ZipFieldIndex.CityId:
					DesetupSyncCity(true, false);
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
				case "City":
					this.City = (CityEntity)entity;
					break;
				case "AccountEventZipSubstitute":
					this.AccountEventZipSubstitute.Add((AccountEventZipSubstituteEntity)entity);
					break;
				case "Address":
					this.Address.Add((AddressEntity)entity);
					break;
				case "EventZip":
					this.EventZip.Add((EventZipEntity)entity);
					break;
				case "TerritoryZip":
					this.TerritoryZip.Add((TerritoryZipEntity)entity);
					break;
				case "ZipRadiusDistance_":
					this.ZipRadiusDistance_.Add((ZipRadiusDistanceEntity)entity);
					break;
				case "ZipRadiusDistance":
					this.ZipRadiusDistance.Add((ZipRadiusDistanceEntity)entity);
					break;
				case "AccountCollectionViaAccountEventZipSubstitute":
					this.AccountCollectionViaAccountEventZipSubstitute.IsReadOnly = false;
					this.AccountCollectionViaAccountEventZipSubstitute.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountEventZipSubstitute.IsReadOnly = true;
					break;
				case "CityCollectionViaAddress":
					this.CityCollectionViaAddress.IsReadOnly = false;
					this.CityCollectionViaAddress.Add((CityEntity)entity);
					this.CityCollectionViaAddress.IsReadOnly = true;
					break;
				case "CountryCollectionViaAddress":
					this.CountryCollectionViaAddress.IsReadOnly = false;
					this.CountryCollectionViaAddress.Add((CountryEntity)entity);
					this.CountryCollectionViaAddress.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventZip":
					this.EventsCollectionViaEventZip.IsReadOnly = false;
					this.EventsCollectionViaEventZip.Add((EventsEntity)entity);
					this.EventsCollectionViaEventZip.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAddress":
					this.OrganizationRoleUserCollectionViaAddress.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAddress.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAddress.IsReadOnly = true;
					break;
				case "StateCollectionViaAddress":
					this.StateCollectionViaAddress.IsReadOnly = false;
					this.StateCollectionViaAddress.Add((StateEntity)entity);
					this.StateCollectionViaAddress.IsReadOnly = true;
					break;
				case "TerritoryCollectionViaTerritoryZip":
					this.TerritoryCollectionViaTerritoryZip.IsReadOnly = false;
					this.TerritoryCollectionViaTerritoryZip.Add((TerritoryEntity)entity);
					this.TerritoryCollectionViaTerritoryZip.IsReadOnly = true;
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
			return ZipEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "City":
					toReturn.Add(ZipEntity.Relations.CityEntityUsingCityId);
					break;
				case "AccountEventZipSubstitute":
					toReturn.Add(ZipEntity.Relations.AccountEventZipSubstituteEntityUsingZipId);
					break;
				case "Address":
					toReturn.Add(ZipEntity.Relations.AddressEntityUsingZipId);
					break;
				case "EventZip":
					toReturn.Add(ZipEntity.Relations.EventZipEntityUsingZipId);
					break;
				case "TerritoryZip":
					toReturn.Add(ZipEntity.Relations.TerritoryZipEntityUsingZipId);
					break;
				case "ZipRadiusDistance_":
					toReturn.Add(ZipEntity.Relations.ZipRadiusDistanceEntityUsingSourceZipId);
					break;
				case "ZipRadiusDistance":
					toReturn.Add(ZipEntity.Relations.ZipRadiusDistanceEntityUsingDestinationZipId);
					break;
				case "AccountCollectionViaAccountEventZipSubstitute":
					toReturn.Add(ZipEntity.Relations.AccountEventZipSubstituteEntityUsingZipId, "ZipEntity__", "AccountEventZipSubstitute_", JoinHint.None);
					toReturn.Add(AccountEventZipSubstituteEntity.Relations.AccountEntityUsingAccountId, "AccountEventZipSubstitute_", string.Empty, JoinHint.None);
					break;
				case "CityCollectionViaAddress":
					toReturn.Add(ZipEntity.Relations.AddressEntityUsingZipId, "ZipEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.CityEntityUsingCityId, "Address_", string.Empty, JoinHint.None);
					break;
				case "CountryCollectionViaAddress":
					toReturn.Add(ZipEntity.Relations.AddressEntityUsingZipId, "ZipEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.CountryEntityUsingCountryId, "Address_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventZip":
					toReturn.Add(ZipEntity.Relations.EventZipEntityUsingZipId, "ZipEntity__", "EventZip_", JoinHint.None);
					toReturn.Add(EventZipEntity.Relations.EventsEntityUsingEventId, "EventZip_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAddress":
					toReturn.Add(ZipEntity.Relations.AddressEntityUsingZipId, "ZipEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.OrganizationRoleUserEntityUsingVerificationOrgRoleUserId, "Address_", string.Empty, JoinHint.None);
					break;
				case "StateCollectionViaAddress":
					toReturn.Add(ZipEntity.Relations.AddressEntityUsingZipId, "ZipEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.StateEntityUsingStateId, "Address_", string.Empty, JoinHint.None);
					break;
				case "TerritoryCollectionViaTerritoryZip":
					toReturn.Add(ZipEntity.Relations.TerritoryZipEntityUsingZipId, "ZipEntity__", "TerritoryZip_", JoinHint.None);
					toReturn.Add(TerritoryZipEntity.Relations.TerritoryEntityUsingTerritoryId, "TerritoryZip_", string.Empty, JoinHint.None);
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
				case "City":
					SetupSyncCity(relatedEntity);
					break;
				case "AccountEventZipSubstitute":
					this.AccountEventZipSubstitute.Add((AccountEventZipSubstituteEntity)relatedEntity);
					break;
				case "Address":
					this.Address.Add((AddressEntity)relatedEntity);
					break;
				case "EventZip":
					this.EventZip.Add((EventZipEntity)relatedEntity);
					break;
				case "TerritoryZip":
					this.TerritoryZip.Add((TerritoryZipEntity)relatedEntity);
					break;
				case "ZipRadiusDistance_":
					this.ZipRadiusDistance_.Add((ZipRadiusDistanceEntity)relatedEntity);
					break;
				case "ZipRadiusDistance":
					this.ZipRadiusDistance.Add((ZipRadiusDistanceEntity)relatedEntity);
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
				case "City":
					DesetupSyncCity(false, true);
					break;
				case "AccountEventZipSubstitute":
					base.PerformRelatedEntityRemoval(this.AccountEventZipSubstitute, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Address":
					base.PerformRelatedEntityRemoval(this.Address, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventZip":
					base.PerformRelatedEntityRemoval(this.EventZip, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TerritoryZip":
					base.PerformRelatedEntityRemoval(this.TerritoryZip, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ZipRadiusDistance_":
					base.PerformRelatedEntityRemoval(this.ZipRadiusDistance_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ZipRadiusDistance":
					base.PerformRelatedEntityRemoval(this.ZipRadiusDistance, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_city!=null)
			{
				toReturn.Add(_city);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AccountEventZipSubstitute);
			toReturn.Add(this.Address);
			toReturn.Add(this.EventZip);
			toReturn.Add(this.TerritoryZip);
			toReturn.Add(this.ZipRadiusDistance_);
			toReturn.Add(this.ZipRadiusDistance);

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
				info.AddValue("_accountEventZipSubstitute", ((_accountEventZipSubstitute!=null) && (_accountEventZipSubstitute.Count>0) && !this.MarkedForDeletion)?_accountEventZipSubstitute:null);
				info.AddValue("_address", ((_address!=null) && (_address.Count>0) && !this.MarkedForDeletion)?_address:null);
				info.AddValue("_eventZip", ((_eventZip!=null) && (_eventZip.Count>0) && !this.MarkedForDeletion)?_eventZip:null);
				info.AddValue("_territoryZip", ((_territoryZip!=null) && (_territoryZip.Count>0) && !this.MarkedForDeletion)?_territoryZip:null);
				info.AddValue("_zipRadiusDistance_", ((_zipRadiusDistance_!=null) && (_zipRadiusDistance_.Count>0) && !this.MarkedForDeletion)?_zipRadiusDistance_:null);
				info.AddValue("_zipRadiusDistance", ((_zipRadiusDistance!=null) && (_zipRadiusDistance.Count>0) && !this.MarkedForDeletion)?_zipRadiusDistance:null);
				info.AddValue("_accountCollectionViaAccountEventZipSubstitute", ((_accountCollectionViaAccountEventZipSubstitute!=null) && (_accountCollectionViaAccountEventZipSubstitute.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountEventZipSubstitute:null);
				info.AddValue("_cityCollectionViaAddress", ((_cityCollectionViaAddress!=null) && (_cityCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_cityCollectionViaAddress:null);
				info.AddValue("_countryCollectionViaAddress", ((_countryCollectionViaAddress!=null) && (_countryCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_countryCollectionViaAddress:null);
				info.AddValue("_eventsCollectionViaEventZip", ((_eventsCollectionViaEventZip!=null) && (_eventsCollectionViaEventZip.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventZip:null);
				info.AddValue("_organizationRoleUserCollectionViaAddress", ((_organizationRoleUserCollectionViaAddress!=null) && (_organizationRoleUserCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAddress:null);
				info.AddValue("_stateCollectionViaAddress", ((_stateCollectionViaAddress!=null) && (_stateCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_stateCollectionViaAddress:null);
				info.AddValue("_territoryCollectionViaTerritoryZip", ((_territoryCollectionViaTerritoryZip!=null) && (_territoryCollectionViaTerritoryZip.Count>0) && !this.MarkedForDeletion)?_territoryCollectionViaTerritoryZip:null);
				info.AddValue("_city", (!this.MarkedForDeletion?_city:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ZipFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ZipFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ZipRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountEventZipSubstitute' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountEventZipSubstitute()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountEventZipSubstituteFields.ZipId, null, ComparisonOperator.Equal, this.ZipId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.ZipId, null, ComparisonOperator.Equal, this.ZipId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventZip' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventZip()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TerritoryZip' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritoryZip()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TerritoryZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ZipRadiusDistance' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoZipRadiusDistance_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipRadiusDistanceFields.SourceZipId, null, ComparisonOperator.Equal, this.ZipId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ZipRadiusDistance' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoZipRadiusDistance()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipRadiusDistanceFields.DestinationZipId, null, ComparisonOperator.Equal, this.ZipId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountEventZipSubstitute()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountEventZipSubstitute"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId, "ZipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'City' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCityCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CityCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId, "ZipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Country' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CountryCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId, "ZipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventZip()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventZip"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId, "ZipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId, "ZipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'State' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStateCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StateCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId, "ZipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Territory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTerritoryCollectionViaTerritoryZip()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TerritoryCollectionViaTerritoryZip"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId, "ZipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'City' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CityFields.CityId, null, ComparisonOperator.Equal, this.CityId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ZipEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._accountEventZipSubstitute);
			collectionsQueue.Enqueue(this._address);
			collectionsQueue.Enqueue(this._eventZip);
			collectionsQueue.Enqueue(this._territoryZip);
			collectionsQueue.Enqueue(this._zipRadiusDistance_);
			collectionsQueue.Enqueue(this._zipRadiusDistance);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountEventZipSubstitute);
			collectionsQueue.Enqueue(this._cityCollectionViaAddress);
			collectionsQueue.Enqueue(this._countryCollectionViaAddress);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventZip);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAddress);
			collectionsQueue.Enqueue(this._stateCollectionViaAddress);
			collectionsQueue.Enqueue(this._territoryCollectionViaTerritoryZip);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._accountEventZipSubstitute = (EntityCollection<AccountEventZipSubstituteEntity>) collectionsQueue.Dequeue();
			this._address = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._eventZip = (EntityCollection<EventZipEntity>) collectionsQueue.Dequeue();
			this._territoryZip = (EntityCollection<TerritoryZipEntity>) collectionsQueue.Dequeue();
			this._zipRadiusDistance_ = (EntityCollection<ZipRadiusDistanceEntity>) collectionsQueue.Dequeue();
			this._zipRadiusDistance = (EntityCollection<ZipRadiusDistanceEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountEventZipSubstitute = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._cityCollectionViaAddress = (EntityCollection<CityEntity>) collectionsQueue.Dequeue();
			this._countryCollectionViaAddress = (EntityCollection<CountryEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventZip = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAddress = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._stateCollectionViaAddress = (EntityCollection<StateEntity>) collectionsQueue.Dequeue();
			this._territoryCollectionViaTerritoryZip = (EntityCollection<TerritoryEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._accountEventZipSubstitute != null)
			{
				return true;
			}
			if (this._address != null)
			{
				return true;
			}
			if (this._eventZip != null)
			{
				return true;
			}
			if (this._territoryZip != null)
			{
				return true;
			}
			if (this._zipRadiusDistance_ != null)
			{
				return true;
			}
			if (this._zipRadiusDistance != null)
			{
				return true;
			}
			if (this._accountCollectionViaAccountEventZipSubstitute != null)
			{
				return true;
			}
			if (this._cityCollectionViaAddress != null)
			{
				return true;
			}
			if (this._countryCollectionViaAddress != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventZip != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAddress != null)
			{
				return true;
			}
			if (this._stateCollectionViaAddress != null)
			{
				return true;
			}
			if (this._territoryCollectionViaTerritoryZip != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEventZipSubstituteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEventZipSubstituteEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventZipEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TerritoryZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryZipEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ZipRadiusDistanceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipRadiusDistanceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ZipRadiusDistanceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipRadiusDistanceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))) : null);
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
			toReturn.Add("City", _city);
			toReturn.Add("AccountEventZipSubstitute", _accountEventZipSubstitute);
			toReturn.Add("Address", _address);
			toReturn.Add("EventZip", _eventZip);
			toReturn.Add("TerritoryZip", _territoryZip);
			toReturn.Add("ZipRadiusDistance_", _zipRadiusDistance_);
			toReturn.Add("ZipRadiusDistance", _zipRadiusDistance);
			toReturn.Add("AccountCollectionViaAccountEventZipSubstitute", _accountCollectionViaAccountEventZipSubstitute);
			toReturn.Add("CityCollectionViaAddress", _cityCollectionViaAddress);
			toReturn.Add("CountryCollectionViaAddress", _countryCollectionViaAddress);
			toReturn.Add("EventsCollectionViaEventZip", _eventsCollectionViaEventZip);
			toReturn.Add("OrganizationRoleUserCollectionViaAddress", _organizationRoleUserCollectionViaAddress);
			toReturn.Add("StateCollectionViaAddress", _stateCollectionViaAddress);
			toReturn.Add("TerritoryCollectionViaTerritoryZip", _territoryCollectionViaTerritoryZip);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_accountEventZipSubstitute!=null)
			{
				_accountEventZipSubstitute.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_eventZip!=null)
			{
				_eventZip.ActiveContext = base.ActiveContext;
			}
			if(_territoryZip!=null)
			{
				_territoryZip.ActiveContext = base.ActiveContext;
			}
			if(_zipRadiusDistance_!=null)
			{
				_zipRadiusDistance_.ActiveContext = base.ActiveContext;
			}
			if(_zipRadiusDistance!=null)
			{
				_zipRadiusDistance.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountEventZipSubstitute!=null)
			{
				_accountCollectionViaAccountEventZipSubstitute.ActiveContext = base.ActiveContext;
			}
			if(_cityCollectionViaAddress!=null)
			{
				_cityCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_countryCollectionViaAddress!=null)
			{
				_countryCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventZip!=null)
			{
				_eventsCollectionViaEventZip.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAddress!=null)
			{
				_organizationRoleUserCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_stateCollectionViaAddress!=null)
			{
				_stateCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_territoryCollectionViaTerritoryZip!=null)
			{
				_territoryCollectionViaTerritoryZip.ActiveContext = base.ActiveContext;
			}
			if(_city!=null)
			{
				_city.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_accountEventZipSubstitute = null;
			_address = null;
			_eventZip = null;
			_territoryZip = null;
			_zipRadiusDistance_ = null;
			_zipRadiusDistance = null;
			_accountCollectionViaAccountEventZipSubstitute = null;
			_cityCollectionViaAddress = null;
			_countryCollectionViaAddress = null;
			_eventsCollectionViaEventZip = null;
			_organizationRoleUserCollectionViaAddress = null;
			_stateCollectionViaAddress = null;
			_territoryCollectionViaTerritoryZip = null;
			_city = null;

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

			_fieldsCustomProperties.Add("ZipId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Latitude", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Longitude", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TimeZone", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DayLightSaving", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _city</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCity(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _city, new PropertyChangedEventHandler( OnCityPropertyChanged ), "City", ZipEntity.Relations.CityEntityUsingCityId, true, signalRelatedEntity, "Zip", resetFKFields, new int[] { (int)ZipFieldIndex.CityId } );		
			_city = null;
		}

		/// <summary> setups the sync logic for member _city</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCity(IEntity2 relatedEntity)
		{
			if(_city!=relatedEntity)
			{
				DesetupSyncCity(true, true);
				_city = (CityEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _city, new PropertyChangedEventHandler( OnCityPropertyChanged ), "City", ZipEntity.Relations.CityEntityUsingCityId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCityPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ZipEntity</param>
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
		public  static ZipRelations Relations
		{
			get	{ return new ZipRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountEventZipSubstitute' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountEventZipSubstitute
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountEventZipSubstituteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEventZipSubstituteEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountEventZipSubstitute")[0], (int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.AccountEventZipSubstituteEntity, 0, null, null, null, null, "AccountEventZipSubstitute", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddress
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),
					(IEntityRelation)GetRelationsForField("Address")[0], (int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventZip' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventZip
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventZipEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventZip")[0], (int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.EventZipEntity, 0, null, null, null, null, "EventZip", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("TerritoryZip")[0], (int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.TerritoryZipEntity, 0, null, null, null, null, "TerritoryZip", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ZipRadiusDistance' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathZipRadiusDistance_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ZipRadiusDistanceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipRadiusDistanceEntityFactory))),
					(IEntityRelation)GetRelationsForField("ZipRadiusDistance_")[0], (int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.ZipRadiusDistanceEntity, 0, null, null, null, null, "ZipRadiusDistance_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ZipRadiusDistance' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathZipRadiusDistance
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ZipRadiusDistanceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipRadiusDistanceEntityFactory))),
					(IEntityRelation)GetRelationsForField("ZipRadiusDistance")[0], (int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.ZipRadiusDistanceEntity, 0, null, null, null, null, "ZipRadiusDistance", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountEventZipSubstitute
		{
			get
			{
				IEntityRelation intermediateRelation = ZipEntity.Relations.AccountEventZipSubstituteEntityUsingZipId;
				intermediateRelation.SetAliases(string.Empty, "AccountEventZipSubstitute_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountEventZipSubstitute"), null, "AccountCollectionViaAccountEventZipSubstitute", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'City' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCityCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = ZipEntity.Relations.AddressEntityUsingZipId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.CityEntity, 0, null, null, GetRelationsForField("CityCollectionViaAddress"), null, "CityCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Country' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = ZipEntity.Relations.AddressEntityUsingZipId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.CountryEntity, 0, null, null, GetRelationsForField("CountryCollectionViaAddress"), null, "CountryCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventZip
		{
			get
			{
				IEntityRelation intermediateRelation = ZipEntity.Relations.EventZipEntityUsingZipId;
				intermediateRelation.SetAliases(string.Empty, "EventZip_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventZip"), null, "EventsCollectionViaEventZip", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = ZipEntity.Relations.AddressEntityUsingZipId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAddress"), null, "OrganizationRoleUserCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'State' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStateCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = ZipEntity.Relations.AddressEntityUsingZipId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.StateEntity, 0, null, null, GetRelationsForField("StateCollectionViaAddress"), null, "StateCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Territory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTerritoryCollectionViaTerritoryZip
		{
			get
			{
				IEntityRelation intermediateRelation = ZipEntity.Relations.TerritoryZipEntityUsingZipId;
				intermediateRelation.SetAliases(string.Empty, "TerritoryZip_");
				return new PrefetchPathElement2(new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.TerritoryEntity, 0, null, null, GetRelationsForField("TerritoryCollectionViaTerritoryZip"), null, "TerritoryCollectionViaTerritoryZip", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'City' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCity
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))),
					(IEntityRelation)GetRelationsForField("City")[0], (int)Falcon.Data.EntityType.ZipEntity, (int)Falcon.Data.EntityType.CityEntity, 0, null, null, null, null, "City", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ZipEntity.CustomProperties;}
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
			get { return ZipEntity.FieldsCustomProperties;}
		}

		/// <summary> The ZipId property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."ZipID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ZipId
		{
			get { return (System.Int64)GetValue((int)ZipFieldIndex.ZipId, true); }
			set	{ SetValue((int)ZipFieldIndex.ZipId, value); }
		}

		/// <summary> The ZipCode property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."ZipCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ZipCode
		{
			get { return (System.String)GetValue((int)ZipFieldIndex.ZipCode, true); }
			set	{ SetValue((int)ZipFieldIndex.ZipCode, value); }
		}

		/// <summary> The CityId property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."CityID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CityId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ZipFieldIndex.CityId, false); }
			set	{ SetValue((int)ZipFieldIndex.CityId, value); }
		}

		/// <summary> The Latitude property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."Latitude"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Latitude
		{
			get { return (System.String)GetValue((int)ZipFieldIndex.Latitude, true); }
			set	{ SetValue((int)ZipFieldIndex.Latitude, value); }
		}

		/// <summary> The Longitude property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."Longitude"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Longitude
		{
			get { return (System.String)GetValue((int)ZipFieldIndex.Longitude, true); }
			set	{ SetValue((int)ZipFieldIndex.Longitude, value); }
		}

		/// <summary> The TimeZone property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."TimeZone"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TimeZone
		{
			get { return (System.String)GetValue((int)ZipFieldIndex.TimeZone, true); }
			set	{ SetValue((int)ZipFieldIndex.TimeZone, value); }
		}

		/// <summary> The DayLightSaving property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."DayLightSaving"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DayLightSaving
		{
			get { return (System.String)GetValue((int)ZipFieldIndex.DayLightSaving, true); }
			set	{ SetValue((int)ZipFieldIndex.DayLightSaving, value); }
		}

		/// <summary> The Description property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)ZipFieldIndex.Description, true); }
			set	{ SetValue((int)ZipFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ZipFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ZipFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ZipFieldIndex.DateModified, true); }
			set	{ SetValue((int)ZipFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity Zip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblZip"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ZipFieldIndex.IsActive, true); }
			set	{ SetValue((int)ZipFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEventZipSubstituteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEventZipSubstituteEntity))]
		public virtual EntityCollection<AccountEventZipSubstituteEntity> AccountEventZipSubstitute
		{
			get
			{
				if(_accountEventZipSubstitute==null)
				{
					_accountEventZipSubstitute = new EntityCollection<AccountEventZipSubstituteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEventZipSubstituteEntityFactory)));
					_accountEventZipSubstitute.SetContainingEntityInfo(this, "Zip");
				}
				return _accountEventZipSubstitute;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> Address
		{
			get
			{
				if(_address==null)
				{
					_address = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_address.SetContainingEntityInfo(this, "Zip");
				}
				return _address;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventZipEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventZipEntity))]
		public virtual EntityCollection<EventZipEntity> EventZip
		{
			get
			{
				if(_eventZip==null)
				{
					_eventZip = new EntityCollection<EventZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventZipEntityFactory)));
					_eventZip.SetContainingEntityInfo(this, "Zip");
				}
				return _eventZip;
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
					_territoryZip.SetContainingEntityInfo(this, "Zip");
				}
				return _territoryZip;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ZipRadiusDistanceEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ZipRadiusDistanceEntity))]
		public virtual EntityCollection<ZipRadiusDistanceEntity> ZipRadiusDistance_
		{
			get
			{
				if(_zipRadiusDistance_==null)
				{
					_zipRadiusDistance_ = new EntityCollection<ZipRadiusDistanceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipRadiusDistanceEntityFactory)));
					_zipRadiusDistance_.SetContainingEntityInfo(this, "Zip_");
				}
				return _zipRadiusDistance_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ZipRadiusDistanceEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ZipRadiusDistanceEntity))]
		public virtual EntityCollection<ZipRadiusDistanceEntity> ZipRadiusDistance
		{
			get
			{
				if(_zipRadiusDistance==null)
				{
					_zipRadiusDistance = new EntityCollection<ZipRadiusDistanceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipRadiusDistanceEntityFactory)));
					_zipRadiusDistance.SetContainingEntityInfo(this, "Zip");
				}
				return _zipRadiusDistance;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountEventZipSubstitute
		{
			get
			{
				if(_accountCollectionViaAccountEventZipSubstitute==null)
				{
					_accountCollectionViaAccountEventZipSubstitute = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountEventZipSubstitute.IsReadOnly=true;
				}
				return _accountCollectionViaAccountEventZipSubstitute;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CityEntity))]
		public virtual EntityCollection<CityEntity> CityCollectionViaAddress
		{
			get
			{
				if(_cityCollectionViaAddress==null)
				{
					_cityCollectionViaAddress = new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory)));
					_cityCollectionViaAddress.IsReadOnly=true;
				}
				return _cityCollectionViaAddress;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CountryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CountryEntity))]
		public virtual EntityCollection<CountryEntity> CountryCollectionViaAddress
		{
			get
			{
				if(_countryCollectionViaAddress==null)
				{
					_countryCollectionViaAddress = new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory)));
					_countryCollectionViaAddress.IsReadOnly=true;
				}
				return _countryCollectionViaAddress;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventZip
		{
			get
			{
				if(_eventsCollectionViaEventZip==null)
				{
					_eventsCollectionViaEventZip = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventZip.IsReadOnly=true;
				}
				return _eventsCollectionViaEventZip;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAddress
		{
			get
			{
				if(_organizationRoleUserCollectionViaAddress==null)
				{
					_organizationRoleUserCollectionViaAddress = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAddress.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAddress;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StateEntity))]
		public virtual EntityCollection<StateEntity> StateCollectionViaAddress
		{
			get
			{
				if(_stateCollectionViaAddress==null)
				{
					_stateCollectionViaAddress = new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory)));
					_stateCollectionViaAddress.IsReadOnly=true;
				}
				return _stateCollectionViaAddress;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TerritoryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TerritoryEntity))]
		public virtual EntityCollection<TerritoryEntity> TerritoryCollectionViaTerritoryZip
		{
			get
			{
				if(_territoryCollectionViaTerritoryZip==null)
				{
					_territoryCollectionViaTerritoryZip = new EntityCollection<TerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TerritoryEntityFactory)));
					_territoryCollectionViaTerritoryZip.IsReadOnly=true;
				}
				return _territoryCollectionViaTerritoryZip;
			}
		}

		/// <summary> Gets / sets related entity of type 'CityEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CityEntity City
		{
			get
			{
				return _city;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCity(value);
				}
				else
				{
					if(value==null)
					{
						if(_city != null)
						{
							_city.UnsetRelatedEntity(this, "Zip");
						}
					}
					else
					{
						if(_city!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Zip");
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
			get { return (int)Falcon.Data.EntityType.ZipEntity; }
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
