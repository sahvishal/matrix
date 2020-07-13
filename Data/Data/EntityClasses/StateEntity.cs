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
	/// Entity class which represents the entity 'State'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class StateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountCheckoutPhoneNumberEntity> _accountCheckoutPhoneNumber;
		private EntityCollection<AddressEntity> _address;
		private EntityCollection<ContractEntity> _contract;
		private EntityCollection<PhysicianLabTestEntity> _physicianLabTest;
		private EntityCollection<PhysicianLicenseEntity> _physicianLicense;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountCheckoutPhoneNumber;
		private EntityCollection<CityEntity> _cityCollectionViaAddress;
		private EntityCollection<CountryEntity> _countryCollectionViaAddress;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAddress;
		private EntityCollection<PhysicianProfileEntity> _physicianProfileCollectionViaPhysicianLicense;
		private EntityCollection<PhysicianProfileEntity> _physicianProfileCollectionViaPhysicianLabTest;
		private EntityCollection<ZipEntity> _zipCollectionViaAddress;
		private CountryEntity _country;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Country</summary>
			public static readonly string Country = "Country";
			/// <summary>Member name AccountCheckoutPhoneNumber</summary>
			public static readonly string AccountCheckoutPhoneNumber = "AccountCheckoutPhoneNumber";
			/// <summary>Member name Address</summary>
			public static readonly string Address = "Address";
			/// <summary>Member name Contract</summary>
			public static readonly string Contract = "Contract";
			/// <summary>Member name PhysicianLabTest</summary>
			public static readonly string PhysicianLabTest = "PhysicianLabTest";
			/// <summary>Member name PhysicianLicense</summary>
			public static readonly string PhysicianLicense = "PhysicianLicense";
			/// <summary>Member name AccountCollectionViaAccountCheckoutPhoneNumber</summary>
			public static readonly string AccountCollectionViaAccountCheckoutPhoneNumber = "AccountCollectionViaAccountCheckoutPhoneNumber";
			/// <summary>Member name CityCollectionViaAddress</summary>
			public static readonly string CityCollectionViaAddress = "CityCollectionViaAddress";
			/// <summary>Member name CountryCollectionViaAddress</summary>
			public static readonly string CountryCollectionViaAddress = "CountryCollectionViaAddress";
			/// <summary>Member name OrganizationRoleUserCollectionViaAddress</summary>
			public static readonly string OrganizationRoleUserCollectionViaAddress = "OrganizationRoleUserCollectionViaAddress";
			/// <summary>Member name PhysicianProfileCollectionViaPhysicianLicense</summary>
			public static readonly string PhysicianProfileCollectionViaPhysicianLicense = "PhysicianProfileCollectionViaPhysicianLicense";
			/// <summary>Member name PhysicianProfileCollectionViaPhysicianLabTest</summary>
			public static readonly string PhysicianProfileCollectionViaPhysicianLabTest = "PhysicianProfileCollectionViaPhysicianLabTest";
			/// <summary>Member name ZipCollectionViaAddress</summary>
			public static readonly string ZipCollectionViaAddress = "ZipCollectionViaAddress";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static StateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public StateEntity():base("StateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public StateEntity(IEntityFields2 fields):base("StateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this StateEntity</param>
		public StateEntity(IValidator validator):base("StateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="stateId">PK value for State which data should be fetched into this State object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public StateEntity(System.Int64 stateId):base("StateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.StateId = stateId;
		}

		/// <summary> CTor</summary>
		/// <param name="stateId">PK value for State which data should be fetched into this State object</param>
		/// <param name="validator">The custom validator object for this StateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public StateEntity(System.Int64 stateId, IValidator validator):base("StateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.StateId = stateId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected StateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_accountCheckoutPhoneNumber = (EntityCollection<AccountCheckoutPhoneNumberEntity>)info.GetValue("_accountCheckoutPhoneNumber", typeof(EntityCollection<AccountCheckoutPhoneNumberEntity>));
				_address = (EntityCollection<AddressEntity>)info.GetValue("_address", typeof(EntityCollection<AddressEntity>));
				_contract = (EntityCollection<ContractEntity>)info.GetValue("_contract", typeof(EntityCollection<ContractEntity>));
				_physicianLabTest = (EntityCollection<PhysicianLabTestEntity>)info.GetValue("_physicianLabTest", typeof(EntityCollection<PhysicianLabTestEntity>));
				_physicianLicense = (EntityCollection<PhysicianLicenseEntity>)info.GetValue("_physicianLicense", typeof(EntityCollection<PhysicianLicenseEntity>));
				_accountCollectionViaAccountCheckoutPhoneNumber = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountCheckoutPhoneNumber", typeof(EntityCollection<AccountEntity>));
				_cityCollectionViaAddress = (EntityCollection<CityEntity>)info.GetValue("_cityCollectionViaAddress", typeof(EntityCollection<CityEntity>));
				_countryCollectionViaAddress = (EntityCollection<CountryEntity>)info.GetValue("_countryCollectionViaAddress", typeof(EntityCollection<CountryEntity>));
				_organizationRoleUserCollectionViaAddress = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAddress", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_physicianProfileCollectionViaPhysicianLicense = (EntityCollection<PhysicianProfileEntity>)info.GetValue("_physicianProfileCollectionViaPhysicianLicense", typeof(EntityCollection<PhysicianProfileEntity>));
				_physicianProfileCollectionViaPhysicianLabTest = (EntityCollection<PhysicianProfileEntity>)info.GetValue("_physicianProfileCollectionViaPhysicianLabTest", typeof(EntityCollection<PhysicianProfileEntity>));
				_zipCollectionViaAddress = (EntityCollection<ZipEntity>)info.GetValue("_zipCollectionViaAddress", typeof(EntityCollection<ZipEntity>));
				_country = (CountryEntity)info.GetValue("_country", typeof(CountryEntity));
				if(_country!=null)
				{
					_country.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((StateFieldIndex)fieldIndex)
			{
				case StateFieldIndex.CountryId:
					DesetupSyncCountry(true, false);
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
				case "Country":
					this.Country = (CountryEntity)entity;
					break;
				case "AccountCheckoutPhoneNumber":
					this.AccountCheckoutPhoneNumber.Add((AccountCheckoutPhoneNumberEntity)entity);
					break;
				case "Address":
					this.Address.Add((AddressEntity)entity);
					break;
				case "Contract":
					this.Contract.Add((ContractEntity)entity);
					break;
				case "PhysicianLabTest":
					this.PhysicianLabTest.Add((PhysicianLabTestEntity)entity);
					break;
				case "PhysicianLicense":
					this.PhysicianLicense.Add((PhysicianLicenseEntity)entity);
					break;
				case "AccountCollectionViaAccountCheckoutPhoneNumber":
					this.AccountCollectionViaAccountCheckoutPhoneNumber.IsReadOnly = false;
					this.AccountCollectionViaAccountCheckoutPhoneNumber.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountCheckoutPhoneNumber.IsReadOnly = true;
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
				case "OrganizationRoleUserCollectionViaAddress":
					this.OrganizationRoleUserCollectionViaAddress.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAddress.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAddress.IsReadOnly = true;
					break;
				case "PhysicianProfileCollectionViaPhysicianLicense":
					this.PhysicianProfileCollectionViaPhysicianLicense.IsReadOnly = false;
					this.PhysicianProfileCollectionViaPhysicianLicense.Add((PhysicianProfileEntity)entity);
					this.PhysicianProfileCollectionViaPhysicianLicense.IsReadOnly = true;
					break;
				case "PhysicianProfileCollectionViaPhysicianLabTest":
					this.PhysicianProfileCollectionViaPhysicianLabTest.IsReadOnly = false;
					this.PhysicianProfileCollectionViaPhysicianLabTest.Add((PhysicianProfileEntity)entity);
					this.PhysicianProfileCollectionViaPhysicianLabTest.IsReadOnly = true;
					break;
				case "ZipCollectionViaAddress":
					this.ZipCollectionViaAddress.IsReadOnly = false;
					this.ZipCollectionViaAddress.Add((ZipEntity)entity);
					this.ZipCollectionViaAddress.IsReadOnly = true;
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
			return StateEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Country":
					toReturn.Add(StateEntity.Relations.CountryEntityUsingCountryId);
					break;
				case "AccountCheckoutPhoneNumber":
					toReturn.Add(StateEntity.Relations.AccountCheckoutPhoneNumberEntityUsingStateId);
					break;
				case "Address":
					toReturn.Add(StateEntity.Relations.AddressEntityUsingStateId);
					break;
				case "Contract":
					toReturn.Add(StateEntity.Relations.ContractEntityUsingStateId);
					break;
				case "PhysicianLabTest":
					toReturn.Add(StateEntity.Relations.PhysicianLabTestEntityUsingStateId);
					break;
				case "PhysicianLicense":
					toReturn.Add(StateEntity.Relations.PhysicianLicenseEntityUsingStateId);
					break;
				case "AccountCollectionViaAccountCheckoutPhoneNumber":
					toReturn.Add(StateEntity.Relations.AccountCheckoutPhoneNumberEntityUsingStateId, "StateEntity__", "AccountCheckoutPhoneNumber_", JoinHint.None);
					toReturn.Add(AccountCheckoutPhoneNumberEntity.Relations.AccountEntityUsingAccountId, "AccountCheckoutPhoneNumber_", string.Empty, JoinHint.None);
					break;
				case "CityCollectionViaAddress":
					toReturn.Add(StateEntity.Relations.AddressEntityUsingStateId, "StateEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.CityEntityUsingCityId, "Address_", string.Empty, JoinHint.None);
					break;
				case "CountryCollectionViaAddress":
					toReturn.Add(StateEntity.Relations.AddressEntityUsingStateId, "StateEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.CountryEntityUsingCountryId, "Address_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAddress":
					toReturn.Add(StateEntity.Relations.AddressEntityUsingStateId, "StateEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.OrganizationRoleUserEntityUsingVerificationOrgRoleUserId, "Address_", string.Empty, JoinHint.None);
					break;
				case "PhysicianProfileCollectionViaPhysicianLicense":
					toReturn.Add(StateEntity.Relations.PhysicianLicenseEntityUsingStateId, "StateEntity__", "PhysicianLicense_", JoinHint.None);
					toReturn.Add(PhysicianLicenseEntity.Relations.PhysicianProfileEntityUsingPhysicianId, "PhysicianLicense_", string.Empty, JoinHint.None);
					break;
				case "PhysicianProfileCollectionViaPhysicianLabTest":
					toReturn.Add(StateEntity.Relations.PhysicianLabTestEntityUsingStateId, "StateEntity__", "PhysicianLabTest_", JoinHint.None);
					toReturn.Add(PhysicianLabTestEntity.Relations.PhysicianProfileEntityUsingPhysicianId, "PhysicianLabTest_", string.Empty, JoinHint.None);
					break;
				case "ZipCollectionViaAddress":
					toReturn.Add(StateEntity.Relations.AddressEntityUsingStateId, "StateEntity__", "Address_", JoinHint.None);
					toReturn.Add(AddressEntity.Relations.ZipEntityUsingZipId, "Address_", string.Empty, JoinHint.None);
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
				case "Country":
					SetupSyncCountry(relatedEntity);
					break;
				case "AccountCheckoutPhoneNumber":
					this.AccountCheckoutPhoneNumber.Add((AccountCheckoutPhoneNumberEntity)relatedEntity);
					break;
				case "Address":
					this.Address.Add((AddressEntity)relatedEntity);
					break;
				case "Contract":
					this.Contract.Add((ContractEntity)relatedEntity);
					break;
				case "PhysicianLabTest":
					this.PhysicianLabTest.Add((PhysicianLabTestEntity)relatedEntity);
					break;
				case "PhysicianLicense":
					this.PhysicianLicense.Add((PhysicianLicenseEntity)relatedEntity);
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
				case "Country":
					DesetupSyncCountry(false, true);
					break;
				case "AccountCheckoutPhoneNumber":
					base.PerformRelatedEntityRemoval(this.AccountCheckoutPhoneNumber, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Address":
					base.PerformRelatedEntityRemoval(this.Address, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Contract":
					base.PerformRelatedEntityRemoval(this.Contract, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianLabTest":
					base.PerformRelatedEntityRemoval(this.PhysicianLabTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianLicense":
					base.PerformRelatedEntityRemoval(this.PhysicianLicense, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_country!=null)
			{
				toReturn.Add(_country);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AccountCheckoutPhoneNumber);
			toReturn.Add(this.Address);
			toReturn.Add(this.Contract);
			toReturn.Add(this.PhysicianLabTest);
			toReturn.Add(this.PhysicianLicense);

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
				info.AddValue("_accountCheckoutPhoneNumber", ((_accountCheckoutPhoneNumber!=null) && (_accountCheckoutPhoneNumber.Count>0) && !this.MarkedForDeletion)?_accountCheckoutPhoneNumber:null);
				info.AddValue("_address", ((_address!=null) && (_address.Count>0) && !this.MarkedForDeletion)?_address:null);
				info.AddValue("_contract", ((_contract!=null) && (_contract.Count>0) && !this.MarkedForDeletion)?_contract:null);
				info.AddValue("_physicianLabTest", ((_physicianLabTest!=null) && (_physicianLabTest.Count>0) && !this.MarkedForDeletion)?_physicianLabTest:null);
				info.AddValue("_physicianLicense", ((_physicianLicense!=null) && (_physicianLicense.Count>0) && !this.MarkedForDeletion)?_physicianLicense:null);
				info.AddValue("_accountCollectionViaAccountCheckoutPhoneNumber", ((_accountCollectionViaAccountCheckoutPhoneNumber!=null) && (_accountCollectionViaAccountCheckoutPhoneNumber.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountCheckoutPhoneNumber:null);
				info.AddValue("_cityCollectionViaAddress", ((_cityCollectionViaAddress!=null) && (_cityCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_cityCollectionViaAddress:null);
				info.AddValue("_countryCollectionViaAddress", ((_countryCollectionViaAddress!=null) && (_countryCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_countryCollectionViaAddress:null);
				info.AddValue("_organizationRoleUserCollectionViaAddress", ((_organizationRoleUserCollectionViaAddress!=null) && (_organizationRoleUserCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAddress:null);
				info.AddValue("_physicianProfileCollectionViaPhysicianLicense", ((_physicianProfileCollectionViaPhysicianLicense!=null) && (_physicianProfileCollectionViaPhysicianLicense.Count>0) && !this.MarkedForDeletion)?_physicianProfileCollectionViaPhysicianLicense:null);
				info.AddValue("_physicianProfileCollectionViaPhysicianLabTest", ((_physicianProfileCollectionViaPhysicianLabTest!=null) && (_physicianProfileCollectionViaPhysicianLabTest.Count>0) && !this.MarkedForDeletion)?_physicianProfileCollectionViaPhysicianLabTest:null);
				info.AddValue("_zipCollectionViaAddress", ((_zipCollectionViaAddress!=null) && (_zipCollectionViaAddress.Count>0) && !this.MarkedForDeletion)?_zipCollectionViaAddress:null);
				info.AddValue("_country", (!this.MarkedForDeletion?_country:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(StateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(StateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new StateRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountCheckoutPhoneNumber' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCheckoutPhoneNumber()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountCheckoutPhoneNumberFields.StateId, null, ComparisonOperator.Equal, this.StateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.StateId, null, ComparisonOperator.Equal, this.StateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Contract' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContract()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContractFields.StateId, null, ComparisonOperator.Equal, this.StateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianLabTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianLabTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianLabTestFields.StateId, null, ComparisonOperator.Equal, this.StateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianLicense' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianLicense()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianLicenseFields.StateId, null, ComparisonOperator.Equal, this.StateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountCheckoutPhoneNumber()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountCheckoutPhoneNumber"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.StateId, null, ComparisonOperator.Equal, this.StateId, "StateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'City' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCityCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CityCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.StateId, null, ComparisonOperator.Equal, this.StateId, "StateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Country' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CountryCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.StateId, null, ComparisonOperator.Equal, this.StateId, "StateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.StateId, null, ComparisonOperator.Equal, this.StateId, "StateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfileCollectionViaPhysicianLicense()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianProfileCollectionViaPhysicianLicense"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.StateId, null, ComparisonOperator.Equal, this.StateId, "StateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfileCollectionViaPhysicianLabTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianProfileCollectionViaPhysicianLabTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.StateId, null, ComparisonOperator.Equal, this.StateId, "StateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Zip' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoZipCollectionViaAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ZipCollectionViaAddress"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.StateId, null, ComparisonOperator.Equal, this.StateId, "StateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Country' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountry()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryFields.CountryId, null, ComparisonOperator.Equal, this.CountryId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.StateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._accountCheckoutPhoneNumber);
			collectionsQueue.Enqueue(this._address);
			collectionsQueue.Enqueue(this._contract);
			collectionsQueue.Enqueue(this._physicianLabTest);
			collectionsQueue.Enqueue(this._physicianLicense);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountCheckoutPhoneNumber);
			collectionsQueue.Enqueue(this._cityCollectionViaAddress);
			collectionsQueue.Enqueue(this._countryCollectionViaAddress);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAddress);
			collectionsQueue.Enqueue(this._physicianProfileCollectionViaPhysicianLicense);
			collectionsQueue.Enqueue(this._physicianProfileCollectionViaPhysicianLabTest);
			collectionsQueue.Enqueue(this._zipCollectionViaAddress);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._accountCheckoutPhoneNumber = (EntityCollection<AccountCheckoutPhoneNumberEntity>) collectionsQueue.Dequeue();
			this._address = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._contract = (EntityCollection<ContractEntity>) collectionsQueue.Dequeue();
			this._physicianLabTest = (EntityCollection<PhysicianLabTestEntity>) collectionsQueue.Dequeue();
			this._physicianLicense = (EntityCollection<PhysicianLicenseEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountCheckoutPhoneNumber = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._cityCollectionViaAddress = (EntityCollection<CityEntity>) collectionsQueue.Dequeue();
			this._countryCollectionViaAddress = (EntityCollection<CountryEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAddress = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._physicianProfileCollectionViaPhysicianLicense = (EntityCollection<PhysicianProfileEntity>) collectionsQueue.Dequeue();
			this._physicianProfileCollectionViaPhysicianLabTest = (EntityCollection<PhysicianProfileEntity>) collectionsQueue.Dequeue();
			this._zipCollectionViaAddress = (EntityCollection<ZipEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._accountCheckoutPhoneNumber != null)
			{
				return true;
			}
			if (this._address != null)
			{
				return true;
			}
			if (this._contract != null)
			{
				return true;
			}
			if (this._physicianLabTest != null)
			{
				return true;
			}
			if (this._physicianLicense != null)
			{
				return true;
			}
			if (this._accountCollectionViaAccountCheckoutPhoneNumber != null)
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
			if (this._organizationRoleUserCollectionViaAddress != null)
			{
				return true;
			}
			if (this._physicianProfileCollectionViaPhysicianLicense != null)
			{
				return true;
			}
			if (this._physicianProfileCollectionViaPhysicianLabTest != null)
			{
				return true;
			}
			if (this._zipCollectionViaAddress != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountCheckoutPhoneNumberEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCheckoutPhoneNumberEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContractEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContractEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianLabTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLabTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianLicenseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLicenseEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))) : null);
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
			toReturn.Add("Country", _country);
			toReturn.Add("AccountCheckoutPhoneNumber", _accountCheckoutPhoneNumber);
			toReturn.Add("Address", _address);
			toReturn.Add("Contract", _contract);
			toReturn.Add("PhysicianLabTest", _physicianLabTest);
			toReturn.Add("PhysicianLicense", _physicianLicense);
			toReturn.Add("AccountCollectionViaAccountCheckoutPhoneNumber", _accountCollectionViaAccountCheckoutPhoneNumber);
			toReturn.Add("CityCollectionViaAddress", _cityCollectionViaAddress);
			toReturn.Add("CountryCollectionViaAddress", _countryCollectionViaAddress);
			toReturn.Add("OrganizationRoleUserCollectionViaAddress", _organizationRoleUserCollectionViaAddress);
			toReturn.Add("PhysicianProfileCollectionViaPhysicianLicense", _physicianProfileCollectionViaPhysicianLicense);
			toReturn.Add("PhysicianProfileCollectionViaPhysicianLabTest", _physicianProfileCollectionViaPhysicianLabTest);
			toReturn.Add("ZipCollectionViaAddress", _zipCollectionViaAddress);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_accountCheckoutPhoneNumber!=null)
			{
				_accountCheckoutPhoneNumber.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_contract!=null)
			{
				_contract.ActiveContext = base.ActiveContext;
			}
			if(_physicianLabTest!=null)
			{
				_physicianLabTest.ActiveContext = base.ActiveContext;
			}
			if(_physicianLicense!=null)
			{
				_physicianLicense.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountCheckoutPhoneNumber!=null)
			{
				_accountCollectionViaAccountCheckoutPhoneNumber.ActiveContext = base.ActiveContext;
			}
			if(_cityCollectionViaAddress!=null)
			{
				_cityCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_countryCollectionViaAddress!=null)
			{
				_countryCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAddress!=null)
			{
				_organizationRoleUserCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_physicianProfileCollectionViaPhysicianLicense!=null)
			{
				_physicianProfileCollectionViaPhysicianLicense.ActiveContext = base.ActiveContext;
			}
			if(_physicianProfileCollectionViaPhysicianLabTest!=null)
			{
				_physicianProfileCollectionViaPhysicianLabTest.ActiveContext = base.ActiveContext;
			}
			if(_zipCollectionViaAddress!=null)
			{
				_zipCollectionViaAddress.ActiveContext = base.ActiveContext;
			}
			if(_country!=null)
			{
				_country.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_accountCheckoutPhoneNumber = null;
			_address = null;
			_contract = null;
			_physicianLabTest = null;
			_physicianLicense = null;
			_accountCollectionViaAccountCheckoutPhoneNumber = null;
			_cityCollectionViaAddress = null;
			_countryCollectionViaAddress = null;
			_organizationRoleUserCollectionViaAddress = null;
			_physicianProfileCollectionViaPhysicianLicense = null;
			_physicianProfileCollectionViaPhysicianLabTest = null;
			_zipCollectionViaAddress = null;
			_country = null;

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

			_fieldsCustomProperties.Add("StateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CountryId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StateCode", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _country</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCountry(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _country, new PropertyChangedEventHandler( OnCountryPropertyChanged ), "Country", StateEntity.Relations.CountryEntityUsingCountryId, true, signalRelatedEntity, "State", resetFKFields, new int[] { (int)StateFieldIndex.CountryId } );		
			_country = null;
		}

		/// <summary> setups the sync logic for member _country</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCountry(IEntity2 relatedEntity)
		{
			if(_country!=relatedEntity)
			{
				DesetupSyncCountry(true, true);
				_country = (CountryEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _country, new PropertyChangedEventHandler( OnCountryPropertyChanged ), "Country", StateEntity.Relations.CountryEntityUsingCountryId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCountryPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this StateEntity</param>
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
		public  static StateRelations Relations
		{
			get	{ return new StateRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountCheckoutPhoneNumber' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCheckoutPhoneNumber
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountCheckoutPhoneNumberEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCheckoutPhoneNumberEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountCheckoutPhoneNumber")[0], (int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.AccountCheckoutPhoneNumberEntity, 0, null, null, null, null, "AccountCheckoutPhoneNumber", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("Address")[0], (int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Contract' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContract
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ContractEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContractEntityFactory))),
					(IEntityRelation)GetRelationsForField("Contract")[0], (int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.ContractEntity, 0, null, null, null, null, "Contract", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianLabTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianLabTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianLabTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLabTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianLabTest")[0], (int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.PhysicianLabTestEntity, 0, null, null, null, null, "PhysicianLabTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianLicense' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianLicense
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianLicenseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLicenseEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianLicense")[0], (int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.PhysicianLicenseEntity, 0, null, null, null, null, "PhysicianLicense", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountCheckoutPhoneNumber
		{
			get
			{
				IEntityRelation intermediateRelation = StateEntity.Relations.AccountCheckoutPhoneNumberEntityUsingStateId;
				intermediateRelation.SetAliases(string.Empty, "AccountCheckoutPhoneNumber_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountCheckoutPhoneNumber"), null, "AccountCollectionViaAccountCheckoutPhoneNumber", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'City' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCityCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = StateEntity.Relations.AddressEntityUsingStateId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.CityEntity, 0, null, null, GetRelationsForField("CityCollectionViaAddress"), null, "CityCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Country' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = StateEntity.Relations.AddressEntityUsingStateId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.CountryEntity, 0, null, null, GetRelationsForField("CountryCollectionViaAddress"), null, "CountryCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = StateEntity.Relations.AddressEntityUsingStateId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAddress"), null, "OrganizationRoleUserCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfileCollectionViaPhysicianLicense
		{
			get
			{
				IEntityRelation intermediateRelation = StateEntity.Relations.PhysicianLicenseEntityUsingStateId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianLicense_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, GetRelationsForField("PhysicianProfileCollectionViaPhysicianLicense"), null, "PhysicianProfileCollectionViaPhysicianLicense", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfileCollectionViaPhysicianLabTest
		{
			get
			{
				IEntityRelation intermediateRelation = StateEntity.Relations.PhysicianLabTestEntityUsingStateId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianLabTest_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, GetRelationsForField("PhysicianProfileCollectionViaPhysicianLabTest"), null, "PhysicianProfileCollectionViaPhysicianLabTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Zip' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathZipCollectionViaAddress
		{
			get
			{
				IEntityRelation intermediateRelation = StateEntity.Relations.AddressEntityUsingStateId;
				intermediateRelation.SetAliases(string.Empty, "Address_");
				return new PrefetchPathElement2(new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.ZipEntity, 0, null, null, GetRelationsForField("ZipCollectionViaAddress"), null, "ZipCollectionViaAddress", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Country' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountry
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))),
					(IEntityRelation)GetRelationsForField("Country")[0], (int)Falcon.Data.EntityType.StateEntity, (int)Falcon.Data.EntityType.CountryEntity, 0, null, null, null, null, "Country", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return StateEntity.CustomProperties;}
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
			get { return StateEntity.FieldsCustomProperties;}
		}

		/// <summary> The StateId property of the Entity State<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblState"."StateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 StateId
		{
			get { return (System.Int64)GetValue((int)StateFieldIndex.StateId, true); }
			set	{ SetValue((int)StateFieldIndex.StateId, value); }
		}

		/// <summary> The Name property of the Entity State<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblState"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)StateFieldIndex.Name, true); }
			set	{ SetValue((int)StateFieldIndex.Name, value); }
		}

		/// <summary> The DateCreated property of the Entity State<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblState"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)StateFieldIndex.DateCreated, false); }
			set	{ SetValue((int)StateFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity State<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblState"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)StateFieldIndex.DateModified, false); }
			set	{ SetValue((int)StateFieldIndex.DateModified, value); }
		}

		/// <summary> The Description property of the Entity State<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblState"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)StateFieldIndex.Description, true); }
			set	{ SetValue((int)StateFieldIndex.Description, value); }
		}

		/// <summary> The IsActive property of the Entity State<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblState"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsActive
		{
			get { return (Nullable<System.Boolean>)GetValue((int)StateFieldIndex.IsActive, false); }
			set	{ SetValue((int)StateFieldIndex.IsActive, value); }
		}

		/// <summary> The CountryId property of the Entity State<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblState"."CountryID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CountryId
		{
			get { return (Nullable<System.Int64>)GetValue((int)StateFieldIndex.CountryId, false); }
			set	{ SetValue((int)StateFieldIndex.CountryId, value); }
		}

		/// <summary> The StateCode property of the Entity State<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblState"."StateCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String StateCode
		{
			get { return (System.String)GetValue((int)StateFieldIndex.StateCode, true); }
			set	{ SetValue((int)StateFieldIndex.StateCode, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountCheckoutPhoneNumberEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountCheckoutPhoneNumberEntity))]
		public virtual EntityCollection<AccountCheckoutPhoneNumberEntity> AccountCheckoutPhoneNumber
		{
			get
			{
				if(_accountCheckoutPhoneNumber==null)
				{
					_accountCheckoutPhoneNumber = new EntityCollection<AccountCheckoutPhoneNumberEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCheckoutPhoneNumberEntityFactory)));
					_accountCheckoutPhoneNumber.SetContainingEntityInfo(this, "State");
				}
				return _accountCheckoutPhoneNumber;
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
					_address.SetContainingEntityInfo(this, "State");
				}
				return _address;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContractEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContractEntity))]
		public virtual EntityCollection<ContractEntity> Contract
		{
			get
			{
				if(_contract==null)
				{
					_contract = new EntityCollection<ContractEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContractEntityFactory)));
					_contract.SetContainingEntityInfo(this, "State");
				}
				return _contract;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianLabTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianLabTestEntity))]
		public virtual EntityCollection<PhysicianLabTestEntity> PhysicianLabTest
		{
			get
			{
				if(_physicianLabTest==null)
				{
					_physicianLabTest = new EntityCollection<PhysicianLabTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLabTestEntityFactory)));
					_physicianLabTest.SetContainingEntityInfo(this, "State");
				}
				return _physicianLabTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianLicenseEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianLicenseEntity))]
		public virtual EntityCollection<PhysicianLicenseEntity> PhysicianLicense
		{
			get
			{
				if(_physicianLicense==null)
				{
					_physicianLicense = new EntityCollection<PhysicianLicenseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianLicenseEntityFactory)));
					_physicianLicense.SetContainingEntityInfo(this, "State");
				}
				return _physicianLicense;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountCheckoutPhoneNumber
		{
			get
			{
				if(_accountCollectionViaAccountCheckoutPhoneNumber==null)
				{
					_accountCollectionViaAccountCheckoutPhoneNumber = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountCheckoutPhoneNumber.IsReadOnly=true;
				}
				return _accountCollectionViaAccountCheckoutPhoneNumber;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianProfileEntity))]
		public virtual EntityCollection<PhysicianProfileEntity> PhysicianProfileCollectionViaPhysicianLicense
		{
			get
			{
				if(_physicianProfileCollectionViaPhysicianLicense==null)
				{
					_physicianProfileCollectionViaPhysicianLicense = new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory)));
					_physicianProfileCollectionViaPhysicianLicense.IsReadOnly=true;
				}
				return _physicianProfileCollectionViaPhysicianLicense;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianProfileEntity))]
		public virtual EntityCollection<PhysicianProfileEntity> PhysicianProfileCollectionViaPhysicianLabTest
		{
			get
			{
				if(_physicianProfileCollectionViaPhysicianLabTest==null)
				{
					_physicianProfileCollectionViaPhysicianLabTest = new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory)));
					_physicianProfileCollectionViaPhysicianLabTest.IsReadOnly=true;
				}
				return _physicianProfileCollectionViaPhysicianLabTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ZipEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ZipEntity))]
		public virtual EntityCollection<ZipEntity> ZipCollectionViaAddress
		{
			get
			{
				if(_zipCollectionViaAddress==null)
				{
					_zipCollectionViaAddress = new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory)));
					_zipCollectionViaAddress.IsReadOnly=true;
				}
				return _zipCollectionViaAddress;
			}
		}

		/// <summary> Gets / sets related entity of type 'CountryEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CountryEntity Country
		{
			get
			{
				return _country;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCountry(value);
				}
				else
				{
					if(value==null)
					{
						if(_country != null)
						{
							_country.UnsetRelatedEntity(this, "State");
						}
					}
					else
					{
						if(_country!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "State");
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
			get { return (int)Falcon.Data.EntityType.StateEntity; }
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
