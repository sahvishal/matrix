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
	/// Entity class which represents the entity 'CustomerPrimaryCarePhysician'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerPrimaryCarePhysicianEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventCustomerPrimaryCarePhysicianEntity> _eventCustomerPrimaryCarePhysician;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerPrimaryCarePhysician;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician;
		private AddressEntity _address;
		private AddressEntity _address_;
		private CustomerProfileEntity _customerProfile;
		private LookupEntity _lookup;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private OrganizationRoleUserEntity _organizationRoleUser__;
		private PhysicianMasterEntity _physicianMaster;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Address</summary>
			public static readonly string Address = "Address";
			/// <summary>Member name Address_</summary>
			public static readonly string Address_ = "Address_";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name OrganizationRoleUser__</summary>
			public static readonly string OrganizationRoleUser__ = "OrganizationRoleUser__";
			/// <summary>Member name PhysicianMaster</summary>
			public static readonly string PhysicianMaster = "PhysicianMaster";
			/// <summary>Member name EventCustomerPrimaryCarePhysician</summary>
			public static readonly string EventCustomerPrimaryCarePhysician = "EventCustomerPrimaryCarePhysician";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerPrimaryCarePhysician</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerPrimaryCarePhysician = "EventCustomersCollectionViaEventCustomerPrimaryCarePhysician";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = "OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerPrimaryCarePhysicianEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerPrimaryCarePhysicianEntity():base("CustomerPrimaryCarePhysicianEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerPrimaryCarePhysicianEntity(IEntityFields2 fields):base("CustomerPrimaryCarePhysicianEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerPrimaryCarePhysicianEntity</param>
		public CustomerPrimaryCarePhysicianEntity(IValidator validator):base("CustomerPrimaryCarePhysicianEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="primaryCarePhysicianId">PK value for CustomerPrimaryCarePhysician which data should be fetched into this CustomerPrimaryCarePhysician object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerPrimaryCarePhysicianEntity(System.Int64 primaryCarePhysicianId):base("CustomerPrimaryCarePhysicianEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PrimaryCarePhysicianId = primaryCarePhysicianId;
		}

		/// <summary> CTor</summary>
		/// <param name="primaryCarePhysicianId">PK value for CustomerPrimaryCarePhysician which data should be fetched into this CustomerPrimaryCarePhysician object</param>
		/// <param name="validator">The custom validator object for this CustomerPrimaryCarePhysicianEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerPrimaryCarePhysicianEntity(System.Int64 primaryCarePhysicianId, IValidator validator):base("CustomerPrimaryCarePhysicianEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PrimaryCarePhysicianId = primaryCarePhysicianId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerPrimaryCarePhysicianEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventCustomerPrimaryCarePhysician = (EntityCollection<EventCustomerPrimaryCarePhysicianEntity>)info.GetValue("_eventCustomerPrimaryCarePhysician", typeof(EntityCollection<EventCustomerPrimaryCarePhysicianEntity>));
				_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician", typeof(EntityCollection<EventCustomersEntity>));
				_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_address_ = (AddressEntity)info.GetValue("_address_", typeof(AddressEntity));
				if(_address_!=null)
				{
					_address_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
				_organizationRoleUser__ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser__", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser__!=null)
				{
					_organizationRoleUser__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_physicianMaster = (PhysicianMasterEntity)info.GetValue("_physicianMaster", typeof(PhysicianMasterEntity));
				if(_physicianMaster!=null)
				{
					_physicianMaster.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerPrimaryCarePhysicianFieldIndex)fieldIndex)
			{
				case CustomerPrimaryCarePhysicianFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case CustomerPrimaryCarePhysicianFieldIndex.Pcpaddress:
					DesetupSyncAddress(true, false);
					break;
				case CustomerPrimaryCarePhysicianFieldIndex.UpdatedByOrganizationRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CustomerPrimaryCarePhysicianFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case CustomerPrimaryCarePhysicianFieldIndex.PhysicianMasterId:
					DesetupSyncPhysicianMaster(true, false);
					break;
				case CustomerPrimaryCarePhysicianFieldIndex.MailingAddressId:
					DesetupSyncAddress_(true, false);
					break;
				case CustomerPrimaryCarePhysicianFieldIndex.PcpAddressVerifiedBy:
					DesetupSyncOrganizationRoleUser__(true, false);
					break;
				case CustomerPrimaryCarePhysicianFieldIndex.Source:
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
				case "Address":
					this.Address = (AddressEntity)entity;
					break;
				case "Address_":
					this.Address_ = (AddressEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser__":
					this.OrganizationRoleUser__ = (OrganizationRoleUserEntity)entity;
					break;
				case "PhysicianMaster":
					this.PhysicianMaster = (PhysicianMasterEntity)entity;
					break;
				case "EventCustomerPrimaryCarePhysician":
					this.EventCustomerPrimaryCarePhysician.Add((EventCustomerPrimaryCarePhysicianEntity)entity);
					break;
				case "EventCustomersCollectionViaEventCustomerPrimaryCarePhysician":
					this.EventCustomersCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerPrimaryCarePhysician.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician":
					this.OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly = true;
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
			return CustomerPrimaryCarePhysicianEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Address":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.AddressEntityUsingPcpaddress);
					break;
				case "Address_":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.AddressEntityUsingMailingAddressId);
					break;
				case "CustomerProfile":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "Lookup":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.LookupEntityUsingSource);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrganizationRoleUserId);
					break;
				case "OrganizationRoleUser__":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingPcpAddressVerifiedBy);
					break;
				case "PhysicianMaster":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.PhysicianMasterEntityUsingPhysicianMasterId);
					break;
				case "EventCustomerPrimaryCarePhysician":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingPrimaryCarePhysicianId);
					break;
				case "EventCustomersCollectionViaEventCustomerPrimaryCarePhysician":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingPrimaryCarePhysicianId, "CustomerPrimaryCarePhysicianEntity__", "EventCustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(EventCustomerPrimaryCarePhysicianEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician":
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingPrimaryCarePhysicianId, "CustomerPrimaryCarePhysicianEntity__", "EventCustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(EventCustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingPcpAddressVerifiedBy, "EventCustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
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
				case "Address":
					SetupSyncAddress(relatedEntity);
					break;
				case "Address_":
					SetupSyncAddress_(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "OrganizationRoleUser__":
					SetupSyncOrganizationRoleUser__(relatedEntity);
					break;
				case "PhysicianMaster":
					SetupSyncPhysicianMaster(relatedEntity);
					break;
				case "EventCustomerPrimaryCarePhysician":
					this.EventCustomerPrimaryCarePhysician.Add((EventCustomerPrimaryCarePhysicianEntity)relatedEntity);
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
				case "Address":
					DesetupSyncAddress(false, true);
					break;
				case "Address_":
					DesetupSyncAddress_(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "OrganizationRoleUser__":
					DesetupSyncOrganizationRoleUser__(false, true);
					break;
				case "PhysicianMaster":
					DesetupSyncPhysicianMaster(false, true);
					break;
				case "EventCustomerPrimaryCarePhysician":
					base.PerformRelatedEntityRemoval(this.EventCustomerPrimaryCarePhysician, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_address!=null)
			{
				toReturn.Add(_address);
			}
			if(_address_!=null)
			{
				toReturn.Add(_address_);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_organizationRoleUser__!=null)
			{
				toReturn.Add(_organizationRoleUser__);
			}
			if(_physicianMaster!=null)
			{
				toReturn.Add(_physicianMaster);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventCustomerPrimaryCarePhysician);

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
				info.AddValue("_eventCustomerPrimaryCarePhysician", ((_eventCustomerPrimaryCarePhysician!=null) && (_eventCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_eventCustomerPrimaryCarePhysician:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician", ((_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician!=null) && (_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician", ((_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician!=null) && (_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician:null);
				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_address_", (!this.MarkedForDeletion?_address_:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_organizationRoleUser__", (!this.MarkedForDeletion?_organizationRoleUser__:null));
				info.AddValue("_physicianMaster", (!this.MarkedForDeletion?_physicianMaster:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CustomerPrimaryCarePhysicianFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerPrimaryCarePhysicianFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerPrimaryCarePhysicianRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerPrimaryCarePhysician' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerPrimaryCarePhysicianFields.PrimaryCarePhysicianId, null, ComparisonOperator.Equal, this.PrimaryCarePhysicianId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerPrimaryCarePhysicianFields.PrimaryCarePhysicianId, null, ComparisonOperator.Equal, this.PrimaryCarePhysicianId, "CustomerPrimaryCarePhysicianEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerPrimaryCarePhysicianFields.PrimaryCarePhysicianId, null, ComparisonOperator.Equal, this.PrimaryCarePhysicianId, "CustomerPrimaryCarePhysicianEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.Pcpaddress));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.MailingAddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Source));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.UpdatedByOrganizationRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.PcpAddressVerifiedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PhysicianMaster' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianMaster()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianMasterFields.PhysicianMasterId, null, ComparisonOperator.Equal, this.PhysicianMasterId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventCustomerPrimaryCarePhysician = (EntityCollection<EventCustomerPrimaryCarePhysicianEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerPrimaryCarePhysician = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPrimaryCarePhysicianEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Address", _address);
			toReturn.Add("Address_", _address_);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("OrganizationRoleUser__", _organizationRoleUser__);
			toReturn.Add("PhysicianMaster", _physicianMaster);
			toReturn.Add("EventCustomerPrimaryCarePhysician", _eventCustomerPrimaryCarePhysician);
			toReturn.Add("EventCustomersCollectionViaEventCustomerPrimaryCarePhysician", _eventCustomersCollectionViaEventCustomerPrimaryCarePhysician);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician", _organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventCustomerPrimaryCarePhysician!=null)
			{
				_eventCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician!=null)
			{
				_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_address_!=null)
			{
				_address_.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser__!=null)
			{
				_organizationRoleUser__.ActiveContext = base.ActiveContext;
			}
			if(_physicianMaster!=null)
			{
				_physicianMaster.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventCustomerPrimaryCarePhysician = null;
			_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician = null;
			_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = null;
			_address = null;
			_address_ = null;
			_customerProfile = null;
			_lookup = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser = null;
			_organizationRoleUser__ = null;
			_physicianMaster = null;

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

			_fieldsCustomProperties.Add("PrimaryCarePhysicianId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Pcpaddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendEmail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOther", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmailOther", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Website", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedByOrganizationRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Npi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Fax", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrefixText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SuffixText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CredentialText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhysicianMasterId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailingAddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPcpAddressVerified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpAddressVerifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpAddressVerifiedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Source", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", CustomerPrimaryCarePhysicianEntity.Relations.AddressEntityUsingPcpaddress, true, signalRelatedEntity, "CustomerPrimaryCarePhysician", resetFKFields, new int[] { (int)CustomerPrimaryCarePhysicianFieldIndex.Pcpaddress } );		
			_address = null;
		}

		/// <summary> setups the sync logic for member _address</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAddress(IEntity2 relatedEntity)
		{
			if(_address!=relatedEntity)
			{
				DesetupSyncAddress(true, true);
				_address = (AddressEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", CustomerPrimaryCarePhysicianEntity.Relations.AddressEntityUsingPcpaddress, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAddressPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _address_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address_, new PropertyChangedEventHandler( OnAddress_PropertyChanged ), "Address_", CustomerPrimaryCarePhysicianEntity.Relations.AddressEntityUsingMailingAddressId, true, signalRelatedEntity, "CustomerPrimaryCarePhysician_", resetFKFields, new int[] { (int)CustomerPrimaryCarePhysicianFieldIndex.MailingAddressId } );		
			_address_ = null;
		}

		/// <summary> setups the sync logic for member _address_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAddress_(IEntity2 relatedEntity)
		{
			if(_address_!=relatedEntity)
			{
				DesetupSyncAddress_(true, true);
				_address_ = (AddressEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _address_, new PropertyChangedEventHandler( OnAddress_PropertyChanged ), "Address_", CustomerPrimaryCarePhysicianEntity.Relations.AddressEntityUsingMailingAddressId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAddress_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CustomerPrimaryCarePhysicianEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "CustomerPrimaryCarePhysician", resetFKFields, new int[] { (int)CustomerPrimaryCarePhysicianFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CustomerPrimaryCarePhysicianEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CustomerPrimaryCarePhysicianEntity.Relations.LookupEntityUsingSource, true, signalRelatedEntity, "CustomerPrimaryCarePhysician", resetFKFields, new int[] { (int)CustomerPrimaryCarePhysicianFieldIndex.Source } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CustomerPrimaryCarePhysicianEntity.Relations.LookupEntityUsingSource, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "CustomerPrimaryCarePhysician_", resetFKFields, new int[] { (int)CustomerPrimaryCarePhysicianFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrganizationRoleUserId, true, signalRelatedEntity, "CustomerPrimaryCarePhysician", resetFKFields, new int[] { (int)CustomerPrimaryCarePhysicianFieldIndex.UpdatedByOrganizationRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrganizationRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingPcpAddressVerifiedBy, true, signalRelatedEntity, "CustomerPrimaryCarePhysician__", resetFKFields, new int[] { (int)CustomerPrimaryCarePhysicianFieldIndex.PcpAddressVerifiedBy } );		
			_organizationRoleUser__ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser__(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser__!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser__(true, true);
				_organizationRoleUser__ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingPcpAddressVerifiedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _physicianMaster</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPhysicianMaster(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _physicianMaster, new PropertyChangedEventHandler( OnPhysicianMasterPropertyChanged ), "PhysicianMaster", CustomerPrimaryCarePhysicianEntity.Relations.PhysicianMasterEntityUsingPhysicianMasterId, true, signalRelatedEntity, "CustomerPrimaryCarePhysician", resetFKFields, new int[] { (int)CustomerPrimaryCarePhysicianFieldIndex.PhysicianMasterId } );		
			_physicianMaster = null;
		}

		/// <summary> setups the sync logic for member _physicianMaster</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPhysicianMaster(IEntity2 relatedEntity)
		{
			if(_physicianMaster!=relatedEntity)
			{
				DesetupSyncPhysicianMaster(true, true);
				_physicianMaster = (PhysicianMasterEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _physicianMaster, new PropertyChangedEventHandler( OnPhysicianMasterPropertyChanged ), "PhysicianMaster", CustomerPrimaryCarePhysicianEntity.Relations.PhysicianMasterEntityUsingPhysicianMasterId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPhysicianMasterPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CustomerPrimaryCarePhysicianEntity</param>
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
		public  static CustomerPrimaryCarePhysicianRelations Relations
		{
			get	{ return new CustomerPrimaryCarePhysicianRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerPrimaryCarePhysician' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerPrimaryCarePhysician
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPrimaryCarePhysicianEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerPrimaryCarePhysician")[0], (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.EventCustomerPrimaryCarePhysicianEntity, 0, null, null, null, null, "EventCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerPrimaryCarePhysicianEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingPrimaryCarePhysicianId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerPrimaryCarePhysician"), null, "EventCustomersCollectionViaEventCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerPrimaryCarePhysicianEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingPrimaryCarePhysicianId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician"), null, "OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddress
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),
					(IEntityRelation)GetRelationsForField("Address")[0], (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddress_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),
					(IEntityRelation)GetRelationsForField("Address_")[0], (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser__")[0], (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianMaster' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianMaster
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianMasterEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianMaster")[0], (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, (int)Falcon.Data.EntityType.PhysicianMasterEntity, 0, null, null, null, null, "PhysicianMaster", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerPrimaryCarePhysicianEntity.CustomProperties;}
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
			get { return CustomerPrimaryCarePhysicianEntity.FieldsCustomProperties;}
		}

		/// <summary> The PrimaryCarePhysicianId property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."PrimaryCarePhysicianID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PrimaryCarePhysicianId
		{
			get { return (System.Int64)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PrimaryCarePhysicianId, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PrimaryCarePhysicianId, value); }
		}

		/// <summary> The CustomerId property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.CustomerId, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.CustomerId, value); }
		}

		/// <summary> The FirstName property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.FirstName, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."MiddleName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.MiddleName, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.MiddleName, value); }
		}

		/// <summary> The LastName property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.LastName, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.LastName, value); }
		}

		/// <summary> The Pcpaddress property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."Address"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Pcpaddress
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Pcpaddress, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Pcpaddress, value); }
		}

		/// <summary> The PhoneNumber property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."PhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneNumber
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PhoneNumber, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PhoneNumber, value); }
		}

		/// <summary> The Email property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."EMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Email, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Email, value); }
		}

		/// <summary> The SendEmail property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."SendEMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendEmail
		{
			get { return (System.Boolean)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.SendEmail, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.SendEmail, value); }
		}

		/// <summary> The DateCreated property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.DateModified, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.DateModified, value); }
		}

		/// <summary> The PhoneOther property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."PhoneOther"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOther
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PhoneOther, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PhoneOther, value); }
		}

		/// <summary> The EmailOther property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."EmailOther"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmailOther
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.EmailOther, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.EmailOther, value); }
		}

		/// <summary> The Website property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."Website"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Website
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Website, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Website, value); }
		}

		/// <summary> The UpdatedByOrganizationRoleUserId property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."UpdatedByOrganizationRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UpdatedByOrganizationRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.UpdatedByOrganizationRoleUserId, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.UpdatedByOrganizationRoleUserId, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.CreatedByOrgRoleUserId, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The Npi property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."NPI"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Npi
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Npi, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Npi, value); }
		}

		/// <summary> The Fax property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."Fax"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Fax
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Fax, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Fax, value); }
		}

		/// <summary> The PrefixText property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."PrefixText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PrefixText
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PrefixText, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PrefixText, value); }
		}

		/// <summary> The SuffixText property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."SuffixText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SuffixText
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.SuffixText, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.SuffixText, value); }
		}

		/// <summary> The CredentialText property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."CredentialText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CredentialText
		{
			get { return (System.String)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.CredentialText, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.CredentialText, value); }
		}

		/// <summary> The PhysicianMasterId property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."PhysicianMasterId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PhysicianMasterId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PhysicianMasterId, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PhysicianMasterId, value); }
		}

		/// <summary> The MailingAddressId property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."MailingAddressId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MailingAddressId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.MailingAddressId, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.MailingAddressId, value); }
		}

		/// <summary> The IsActive property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.IsActive, true); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.IsActive, value); }
		}

		/// <summary> The IsPcpAddressVerified property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."IsPcpAddressVerified"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsPcpAddressVerified
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.IsPcpAddressVerified, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.IsPcpAddressVerified, value); }
		}

		/// <summary> The PcpAddressVerifiedBy property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."PcpAddressVerifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PcpAddressVerifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PcpAddressVerifiedBy, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PcpAddressVerifiedBy, value); }
		}

		/// <summary> The PcpAddressVerifiedOn property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."PcpAddressVerifiedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> PcpAddressVerifiedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PcpAddressVerifiedOn, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.PcpAddressVerifiedOn, value); }
		}

		/// <summary> The Source property of the Entity CustomerPrimaryCarePhysician<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerPrimaryCarePhysician"."Source"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Source
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Source, false); }
			set	{ SetValue((int)CustomerPrimaryCarePhysicianFieldIndex.Source, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerPrimaryCarePhysicianEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerPrimaryCarePhysicianEntity))]
		public virtual EntityCollection<EventCustomerPrimaryCarePhysicianEntity> EventCustomerPrimaryCarePhysician
		{
			get
			{
				if(_eventCustomerPrimaryCarePhysician==null)
				{
					_eventCustomerPrimaryCarePhysician = new EntityCollection<EventCustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPrimaryCarePhysicianEntityFactory)));
					_eventCustomerPrimaryCarePhysician.SetContainingEntityInfo(this, "CustomerPrimaryCarePhysician");
				}
				return _eventCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerPrimaryCarePhysician
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician==null)
				{
					_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician==null)
				{
					_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets / sets related entity of type 'AddressEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AddressEntity Address
		{
			get
			{
				return _address;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAddress(value);
				}
				else
				{
					if(value==null)
					{
						if(_address != null)
						{
							_address.UnsetRelatedEntity(this, "CustomerPrimaryCarePhysician");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerPrimaryCarePhysician");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AddressEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AddressEntity Address_
		{
			get
			{
				return _address_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAddress_(value);
				}
				else
				{
					if(value==null)
					{
						if(_address_ != null)
						{
							_address_.UnsetRelatedEntity(this, "CustomerPrimaryCarePhysician_");
						}
					}
					else
					{
						if(_address_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerPrimaryCarePhysician_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "CustomerPrimaryCarePhysician");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerPrimaryCarePhysician");
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
							_lookup.UnsetRelatedEntity(this, "CustomerPrimaryCarePhysician");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerPrimaryCarePhysician");
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "CustomerPrimaryCarePhysician_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerPrimaryCarePhysician_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CustomerPrimaryCarePhysician");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerPrimaryCarePhysician");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser__
		{
			get
			{
				return _organizationRoleUser__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser__(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser__ != null)
						{
							_organizationRoleUser__.UnsetRelatedEntity(this, "CustomerPrimaryCarePhysician__");
						}
					}
					else
					{
						if(_organizationRoleUser__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerPrimaryCarePhysician__");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PhysicianMasterEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PhysicianMasterEntity PhysicianMaster
		{
			get
			{
				return _physicianMaster;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPhysicianMaster(value);
				}
				else
				{
					if(value==null)
					{
						if(_physicianMaster != null)
						{
							_physicianMaster.UnsetRelatedEntity(this, "CustomerPrimaryCarePhysician");
						}
					}
					else
					{
						if(_physicianMaster!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerPrimaryCarePhysician");
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
			get { return (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity; }
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
