///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:49
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
	/// Entity class which represents the entity 'Lab'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class LabEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerProfileEntity> _customerProfile;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCustomerProfile;
		private EntityCollection<AddressEntity> _addressCollectionViaCustomerProfile;
		private EntityCollection<LanguageEntity> _languageCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile______;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_______;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile________;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile___;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile__;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCustomerProfile;
		private EntityCollection<RoleEntity> _roleCollectionViaCustomerProfile;
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
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name ActivityTypeCollectionViaCustomerProfile</summary>
			public static readonly string ActivityTypeCollectionViaCustomerProfile = "ActivityTypeCollectionViaCustomerProfile";
			/// <summary>Member name AddressCollectionViaCustomerProfile</summary>
			public static readonly string AddressCollectionViaCustomerProfile = "AddressCollectionViaCustomerProfile";
			/// <summary>Member name LanguageCollectionViaCustomerProfile</summary>
			public static readonly string LanguageCollectionViaCustomerProfile = "LanguageCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaCustomerProfile______</summary>
			public static readonly string LookupCollectionViaCustomerProfile______ = "LookupCollectionViaCustomerProfile______";
			/// <summary>Member name LookupCollectionViaCustomerProfile_____</summary>
			public static readonly string LookupCollectionViaCustomerProfile_____ = "LookupCollectionViaCustomerProfile_____";
			/// <summary>Member name LookupCollectionViaCustomerProfile_______</summary>
			public static readonly string LookupCollectionViaCustomerProfile_______ = "LookupCollectionViaCustomerProfile_______";
			/// <summary>Member name LookupCollectionViaCustomerProfile________</summary>
			public static readonly string LookupCollectionViaCustomerProfile________ = "LookupCollectionViaCustomerProfile________";
			/// <summary>Member name LookupCollectionViaCustomerProfile____</summary>
			public static readonly string LookupCollectionViaCustomerProfile____ = "LookupCollectionViaCustomerProfile____";
			/// <summary>Member name LookupCollectionViaCustomerProfile_</summary>
			public static readonly string LookupCollectionViaCustomerProfile_ = "LookupCollectionViaCustomerProfile_";
			/// <summary>Member name LookupCollectionViaCustomerProfile</summary>
			public static readonly string LookupCollectionViaCustomerProfile = "LookupCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaCustomerProfile___</summary>
			public static readonly string LookupCollectionViaCustomerProfile___ = "LookupCollectionViaCustomerProfile___";
			/// <summary>Member name LookupCollectionViaCustomerProfile__</summary>
			public static readonly string LookupCollectionViaCustomerProfile__ = "LookupCollectionViaCustomerProfile__";
			/// <summary>Member name NotesDetailsCollectionViaCustomerProfile</summary>
			public static readonly string NotesDetailsCollectionViaCustomerProfile = "NotesDetailsCollectionViaCustomerProfile";
			/// <summary>Member name RoleCollectionViaCustomerProfile</summary>
			public static readonly string RoleCollectionViaCustomerProfile = "RoleCollectionViaCustomerProfile";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static LabEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public LabEntity():base("LabEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public LabEntity(IEntityFields2 fields):base("LabEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this LabEntity</param>
		public LabEntity(IValidator validator):base("LabEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Lab which data should be fetched into this Lab object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public LabEntity(System.Int64 id):base("LabEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Lab which data should be fetched into this Lab object</param>
		/// <param name="validator">The custom validator object for this LabEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public LabEntity(System.Int64 id, IValidator validator):base("LabEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected LabEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerProfile = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfile", typeof(EntityCollection<CustomerProfileEntity>));
				_activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCustomerProfile", typeof(EntityCollection<ActivityTypeEntity>));
				_addressCollectionViaCustomerProfile = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaCustomerProfile", typeof(EntityCollection<AddressEntity>));
				_languageCollectionViaCustomerProfile = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCustomerProfile", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile________", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile__", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaCustomerProfile = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCustomerProfile", typeof(EntityCollection<NotesDetailsEntity>));
				_roleCollectionViaCustomerProfile = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaCustomerProfile", typeof(EntityCollection<RoleEntity>));
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
			switch((LabFieldIndex)fieldIndex)
			{
				case LabFieldIndex.CreatedByOrgRoleUserId:
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
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)entity);
					break;
				case "ActivityTypeCollectionViaCustomerProfile":
					this.ActivityTypeCollectionViaCustomerProfile.IsReadOnly = false;
					this.ActivityTypeCollectionViaCustomerProfile.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "AddressCollectionViaCustomerProfile":
					this.AddressCollectionViaCustomerProfile.IsReadOnly = false;
					this.AddressCollectionViaCustomerProfile.Add((AddressEntity)entity);
					this.AddressCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LanguageCollectionViaCustomerProfile":
					this.LanguageCollectionViaCustomerProfile.IsReadOnly = false;
					this.LanguageCollectionViaCustomerProfile.Add((LanguageEntity)entity);
					this.LanguageCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile______":
					this.LookupCollectionViaCustomerProfile______.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile______.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile______.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_____":
					this.LookupCollectionViaCustomerProfile_____.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_____.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_____.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_______":
					this.LookupCollectionViaCustomerProfile_______.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_______.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_______.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile________":
					this.LookupCollectionViaCustomerProfile________.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile________.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile________.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile____":
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile____.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_":
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile":
					this.LookupCollectionViaCustomerProfile.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile___":
					this.LookupCollectionViaCustomerProfile___.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile___.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile___.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile__":
					this.LookupCollectionViaCustomerProfile__.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile__.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile__.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCustomerProfile":
					this.NotesDetailsCollectionViaCustomerProfile.IsReadOnly = false;
					this.NotesDetailsCollectionViaCustomerProfile.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "RoleCollectionViaCustomerProfile":
					this.RoleCollectionViaCustomerProfile.IsReadOnly = false;
					this.RoleCollectionViaCustomerProfile.Add((RoleEntity)entity);
					this.RoleCollectionViaCustomerProfile.IsReadOnly = true;
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
			return LabEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(LabEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "CustomerProfile":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId);
					break;
				case "ActivityTypeCollectionViaCustomerProfile":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.ActivityTypeEntityUsingActivityId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "AddressCollectionViaCustomerProfile":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.AddressEntityUsingBillingAddressId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCustomerProfile":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LanguageEntityUsingLanguageId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile______":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPreferredContactType, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_____":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneOfficeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_______":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactReasonId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile________":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingProductTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile____":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneHomeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile___":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneCellConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile__":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingMemberUploadSourceId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCustomerProfile":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.NotesDetailsEntityUsingDoNotContactReasonNotesId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaCustomerProfile":
					toReturn.Add(LabEntity.Relations.CustomerProfileEntityUsingLabId, "LabEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.RoleEntityUsingAddedByRoleId, "CustomerProfile_", string.Empty, JoinHint.None);
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
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)relatedEntity);
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
				case "CustomerProfile":
					base.PerformRelatedEntityRemoval(this.CustomerProfile, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CustomerProfile);

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
				info.AddValue("_customerProfile", ((_customerProfile!=null) && (_customerProfile.Count>0) && !this.MarkedForDeletion)?_customerProfile:null);
				info.AddValue("_activityTypeCollectionViaCustomerProfile", ((_activityTypeCollectionViaCustomerProfile!=null) && (_activityTypeCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCustomerProfile:null);
				info.AddValue("_addressCollectionViaCustomerProfile", ((_addressCollectionViaCustomerProfile!=null) && (_addressCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaCustomerProfile:null);
				info.AddValue("_languageCollectionViaCustomerProfile", ((_languageCollectionViaCustomerProfile!=null) && (_languageCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaCustomerProfile______", ((_lookupCollectionViaCustomerProfile______!=null) && (_lookupCollectionViaCustomerProfile______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile______:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_____", ((_lookupCollectionViaCustomerProfile_____!=null) && (_lookupCollectionViaCustomerProfile_____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_______", ((_lookupCollectionViaCustomerProfile_______!=null) && (_lookupCollectionViaCustomerProfile_______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_______:null);
				info.AddValue("_lookupCollectionViaCustomerProfile________", ((_lookupCollectionViaCustomerProfile________!=null) && (_lookupCollectionViaCustomerProfile________.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile________:null);
				info.AddValue("_lookupCollectionViaCustomerProfile____", ((_lookupCollectionViaCustomerProfile____!=null) && (_lookupCollectionViaCustomerProfile____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_", ((_lookupCollectionViaCustomerProfile_!=null) && (_lookupCollectionViaCustomerProfile_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_:null);
				info.AddValue("_lookupCollectionViaCustomerProfile", ((_lookupCollectionViaCustomerProfile!=null) && (_lookupCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaCustomerProfile___", ((_lookupCollectionViaCustomerProfile___!=null) && (_lookupCollectionViaCustomerProfile___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile___:null);
				info.AddValue("_lookupCollectionViaCustomerProfile__", ((_lookupCollectionViaCustomerProfile__!=null) && (_lookupCollectionViaCustomerProfile__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile__:null);
				info.AddValue("_notesDetailsCollectionViaCustomerProfile", ((_notesDetailsCollectionViaCustomerProfile!=null) && (_notesDetailsCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCustomerProfile:null);
				info.AddValue("_roleCollectionViaCustomerProfile", ((_roleCollectionViaCustomerProfile!=null) && (_roleCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaCustomerProfile:null);
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
		public bool TestOriginalFieldValueForNull(LabFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(LabFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new LabRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.LabId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LabFields.Id, null, ComparisonOperator.Equal, this.Id, "LabEntity__"));
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

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.LabEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(LabEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerProfile);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._addressCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._languageCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile______);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_______);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile________);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile___);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile__);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._roleCollectionViaCustomerProfile);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerProfile = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaCustomerProfile = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCustomerProfile = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCustomerProfile = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaCustomerProfile = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerProfile != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._addressCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._languageCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile________ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile__ != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._roleCollectionViaCustomerProfile != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
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
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("ActivityTypeCollectionViaCustomerProfile", _activityTypeCollectionViaCustomerProfile);
			toReturn.Add("AddressCollectionViaCustomerProfile", _addressCollectionViaCustomerProfile);
			toReturn.Add("LanguageCollectionViaCustomerProfile", _languageCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaCustomerProfile______", _lookupCollectionViaCustomerProfile______);
			toReturn.Add("LookupCollectionViaCustomerProfile_____", _lookupCollectionViaCustomerProfile_____);
			toReturn.Add("LookupCollectionViaCustomerProfile_______", _lookupCollectionViaCustomerProfile_______);
			toReturn.Add("LookupCollectionViaCustomerProfile________", _lookupCollectionViaCustomerProfile________);
			toReturn.Add("LookupCollectionViaCustomerProfile____", _lookupCollectionViaCustomerProfile____);
			toReturn.Add("LookupCollectionViaCustomerProfile_", _lookupCollectionViaCustomerProfile_);
			toReturn.Add("LookupCollectionViaCustomerProfile", _lookupCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaCustomerProfile___", _lookupCollectionViaCustomerProfile___);
			toReturn.Add("LookupCollectionViaCustomerProfile__", _lookupCollectionViaCustomerProfile__);
			toReturn.Add("NotesDetailsCollectionViaCustomerProfile", _notesDetailsCollectionViaCustomerProfile);
			toReturn.Add("RoleCollectionViaCustomerProfile", _roleCollectionViaCustomerProfile);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCustomerProfile!=null)
			{
				_activityTypeCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaCustomerProfile!=null)
			{
				_addressCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCustomerProfile!=null)
			{
				_languageCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile______!=null)
			{
				_lookupCollectionViaCustomerProfile______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_____!=null)
			{
				_lookupCollectionViaCustomerProfile_____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_______!=null)
			{
				_lookupCollectionViaCustomerProfile_______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile________!=null)
			{
				_lookupCollectionViaCustomerProfile________.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile____!=null)
			{
				_lookupCollectionViaCustomerProfile____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_!=null)
			{
				_lookupCollectionViaCustomerProfile_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile!=null)
			{
				_lookupCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile___!=null)
			{
				_lookupCollectionViaCustomerProfile___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile__!=null)
			{
				_lookupCollectionViaCustomerProfile__.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCustomerProfile!=null)
			{
				_notesDetailsCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaCustomerProfile!=null)
			{
				_roleCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerProfile = null;
			_activityTypeCollectionViaCustomerProfile = null;
			_addressCollectionViaCustomerProfile = null;
			_languageCollectionViaCustomerProfile = null;
			_lookupCollectionViaCustomerProfile______ = null;
			_lookupCollectionViaCustomerProfile_____ = null;
			_lookupCollectionViaCustomerProfile_______ = null;
			_lookupCollectionViaCustomerProfile________ = null;
			_lookupCollectionViaCustomerProfile____ = null;
			_lookupCollectionViaCustomerProfile_ = null;
			_lookupCollectionViaCustomerProfile = null;
			_lookupCollectionViaCustomerProfile___ = null;
			_lookupCollectionViaCustomerProfile__ = null;
			_notesDetailsCollectionViaCustomerProfile = null;
			_roleCollectionViaCustomerProfile = null;
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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", LabEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "Lab", resetFKFields, new int[] { (int)LabFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", LabEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this LabEntity</param>
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
		public  static LabRelations Relations
		{
			get	{ return new LabRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCustomerProfile"), null, "ActivityTypeCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaCustomerProfile"), null, "AddressCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCustomerProfile"), null, "LanguageCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile______
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile______"), null, "LookupCollectionViaCustomerProfile______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_____
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_____"), null, "LookupCollectionViaCustomerProfile_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_______
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_______"), null, "LookupCollectionViaCustomerProfile_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile________
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile________"), null, "LookupCollectionViaCustomerProfile________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile____
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile____"), null, "LookupCollectionViaCustomerProfile____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_"), null, "LookupCollectionViaCustomerProfile_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile"), null, "LookupCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile___
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile___"), null, "LookupCollectionViaCustomerProfile___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile__
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile__"), null, "LookupCollectionViaCustomerProfile__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCustomerProfile"), null, "NotesDetailsCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LabEntity.Relations.CustomerProfileEntityUsingLabId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaCustomerProfile"), null, "RoleCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.LabEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return LabEntity.CustomProperties;}
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
			get { return LabEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity Lab<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLab"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)LabFieldIndex.Id, true); }
			set	{ SetValue((int)LabFieldIndex.Id, value); }
		}

		/// <summary> The Name property of the Entity Lab<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLab"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)LabFieldIndex.Name, true); }
			set	{ SetValue((int)LabFieldIndex.Name, value); }
		}

		/// <summary> The Alias property of the Entity Lab<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLab"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)LabFieldIndex.Alias, true); }
			set	{ SetValue((int)LabFieldIndex.Alias, value); }
		}

		/// <summary> The DateCreated property of the Entity Lab<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLab"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)LabFieldIndex.DateCreated, true); }
			set	{ SetValue((int)LabFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity Lab<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLab"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)LabFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)LabFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The IsActive property of the Entity Lab<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLab"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)LabFieldIndex.IsActive, true); }
			set	{ SetValue((int)LabFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfile
		{
			get
			{
				if(_customerProfile==null)
				{
					_customerProfile = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfile.SetContainingEntityInfo(this, "Lab");
				}
				return _customerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActivityTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActivityTypeEntity))]
		public virtual EntityCollection<ActivityTypeEntity> ActivityTypeCollectionViaCustomerProfile
		{
			get
			{
				if(_activityTypeCollectionViaCustomerProfile==null)
				{
					_activityTypeCollectionViaCustomerProfile = new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory)));
					_activityTypeCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _activityTypeCollectionViaCustomerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaCustomerProfile
		{
			get
			{
				if(_addressCollectionViaCustomerProfile==null)
				{
					_addressCollectionViaCustomerProfile = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _addressCollectionViaCustomerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LanguageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LanguageEntity))]
		public virtual EntityCollection<LanguageEntity> LanguageCollectionViaCustomerProfile
		{
			get
			{
				if(_languageCollectionViaCustomerProfile==null)
				{
					_languageCollectionViaCustomerProfile = new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory)));
					_languageCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _languageCollectionViaCustomerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile______
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile______==null)
				{
					_lookupCollectionViaCustomerProfile______ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile______.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile_____
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile_____==null)
				{
					_lookupCollectionViaCustomerProfile_____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile_____.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile_______
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile_______==null)
				{
					_lookupCollectionViaCustomerProfile_______ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile_______.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile________
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile________==null)
				{
					_lookupCollectionViaCustomerProfile________ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile________.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile____
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile____==null)
				{
					_lookupCollectionViaCustomerProfile____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile____.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile_
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile_==null)
				{
					_lookupCollectionViaCustomerProfile_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile_.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile==null)
				{
					_lookupCollectionViaCustomerProfile = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile___
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile___==null)
				{
					_lookupCollectionViaCustomerProfile___ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile___.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile__
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile__==null)
				{
					_lookupCollectionViaCustomerProfile__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile__.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotesDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotesDetailsEntity))]
		public virtual EntityCollection<NotesDetailsEntity> NotesDetailsCollectionViaCustomerProfile
		{
			get
			{
				if(_notesDetailsCollectionViaCustomerProfile==null)
				{
					_notesDetailsCollectionViaCustomerProfile = new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory)));
					_notesDetailsCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _notesDetailsCollectionViaCustomerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaCustomerProfile
		{
			get
			{
				if(_roleCollectionViaCustomerProfile==null)
				{
					_roleCollectionViaCustomerProfile = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _roleCollectionViaCustomerProfile;
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Lab");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Lab");
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
			get { return (int)Falcon.Data.EntityType.LabEntity; }
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
