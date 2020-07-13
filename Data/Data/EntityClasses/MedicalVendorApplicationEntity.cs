///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:25 AM
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
using HealthYes.Data;
using HealthYes.Data.HelperClasses;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'MedicalVendorApplication'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MedicalVendorApplicationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MedicalVendorMvuserEntity> _medicalVendorMvuser;
		private EntityCollection<MedicalVendorNotesEntity> _medicalVendorNotes;
		private EntityCollection<MedicalVendorUserNotesEntity> _medicalVendorUserNotes;
		private EntityCollection<MedicalVendorEntity> _medicalVendorCollectionViaMedicalVendorNotes;
		private EntityCollection<MedicalVendorEntity> _medicalVendorCollectionViaMedicalVendorMvuser;
		private EntityCollection<MvuserEntity> _mvuserCollectionViaMedicalVendorMvuser;
		private EntityCollection<RoleEntity> _roleCollectionViaMedicalVendorMvuser;
		private AddressEntity _address_;
		private AddressEntity _address;
		private MedicalVendorTypeEntity _medicalVendorType;
		private MvuserSpecializationEntity _mvuserSpecialization;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Address_</summary>
			public static readonly string Address_ = "Address_";
			/// <summary>Member name Address</summary>
			public static readonly string Address = "Address";
			/// <summary>Member name MedicalVendorType</summary>
			public static readonly string MedicalVendorType = "MedicalVendorType";
			/// <summary>Member name MvuserSpecialization</summary>
			public static readonly string MvuserSpecialization = "MvuserSpecialization";
			/// <summary>Member name MedicalVendorMvuser</summary>
			public static readonly string MedicalVendorMvuser = "MedicalVendorMvuser";
			/// <summary>Member name MedicalVendorNotes</summary>
			public static readonly string MedicalVendorNotes = "MedicalVendorNotes";
			/// <summary>Member name MedicalVendorUserNotes</summary>
			public static readonly string MedicalVendorUserNotes = "MedicalVendorUserNotes";
			/// <summary>Member name MedicalVendorCollectionViaMedicalVendorNotes</summary>
			public static readonly string MedicalVendorCollectionViaMedicalVendorNotes = "MedicalVendorCollectionViaMedicalVendorNotes";
			/// <summary>Member name MedicalVendorCollectionViaMedicalVendorMvuser</summary>
			public static readonly string MedicalVendorCollectionViaMedicalVendorMvuser = "MedicalVendorCollectionViaMedicalVendorMvuser";
			/// <summary>Member name MvuserCollectionViaMedicalVendorMvuser</summary>
			public static readonly string MvuserCollectionViaMedicalVendorMvuser = "MvuserCollectionViaMedicalVendorMvuser";
			/// <summary>Member name RoleCollectionViaMedicalVendorMvuser</summary>
			public static readonly string RoleCollectionViaMedicalVendorMvuser = "RoleCollectionViaMedicalVendorMvuser";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MedicalVendorApplicationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MedicalVendorApplicationEntity():base("MedicalVendorApplicationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MedicalVendorApplicationEntity(IEntityFields2 fields):base("MedicalVendorApplicationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MedicalVendorApplicationEntity</param>
		public MedicalVendorApplicationEntity(IValidator validator):base("MedicalVendorApplicationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="medicalVendorApplicationId">PK value for MedicalVendorApplication which data should be fetched into this MedicalVendorApplication object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorApplicationEntity(System.Int64 medicalVendorApplicationId):base("MedicalVendorApplicationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MedicalVendorApplicationId = medicalVendorApplicationId;
		}

		/// <summary> CTor</summary>
		/// <param name="medicalVendorApplicationId">PK value for MedicalVendorApplication which data should be fetched into this MedicalVendorApplication object</param>
		/// <param name="validator">The custom validator object for this MedicalVendorApplicationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MedicalVendorApplicationEntity(System.Int64 medicalVendorApplicationId, IValidator validator):base("MedicalVendorApplicationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MedicalVendorApplicationId = medicalVendorApplicationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MedicalVendorApplicationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_medicalVendorMvuser = (EntityCollection<MedicalVendorMvuserEntity>)info.GetValue("_medicalVendorMvuser", typeof(EntityCollection<MedicalVendorMvuserEntity>));
				_medicalVendorNotes = (EntityCollection<MedicalVendorNotesEntity>)info.GetValue("_medicalVendorNotes", typeof(EntityCollection<MedicalVendorNotesEntity>));
				_medicalVendorUserNotes = (EntityCollection<MedicalVendorUserNotesEntity>)info.GetValue("_medicalVendorUserNotes", typeof(EntityCollection<MedicalVendorUserNotesEntity>));
				_medicalVendorCollectionViaMedicalVendorNotes = (EntityCollection<MedicalVendorEntity>)info.GetValue("_medicalVendorCollectionViaMedicalVendorNotes", typeof(EntityCollection<MedicalVendorEntity>));
				_medicalVendorCollectionViaMedicalVendorMvuser = (EntityCollection<MedicalVendorEntity>)info.GetValue("_medicalVendorCollectionViaMedicalVendorMvuser", typeof(EntityCollection<MedicalVendorEntity>));
				_mvuserCollectionViaMedicalVendorMvuser = (EntityCollection<MvuserEntity>)info.GetValue("_mvuserCollectionViaMedicalVendorMvuser", typeof(EntityCollection<MvuserEntity>));
				_roleCollectionViaMedicalVendorMvuser = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaMedicalVendorMvuser", typeof(EntityCollection<RoleEntity>));
				_address_ = (AddressEntity)info.GetValue("_address_", typeof(AddressEntity));
				if(_address_!=null)
				{
					_address_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_medicalVendorType = (MedicalVendorTypeEntity)info.GetValue("_medicalVendorType", typeof(MedicalVendorTypeEntity));
				if(_medicalVendorType!=null)
				{
					_medicalVendorType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_mvuserSpecialization = (MvuserSpecializationEntity)info.GetValue("_mvuserSpecialization", typeof(MvuserSpecializationEntity));
				if(_mvuserSpecialization!=null)
				{
					_mvuserSpecialization.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MedicalVendorApplicationFieldIndex)fieldIndex)
			{
				case MedicalVendorApplicationFieldIndex.BusinessAddressId:
					DesetupSyncAddress(true, false);
					break;
				case MedicalVendorApplicationFieldIndex.MedicalVendorTypeId:
					DesetupSyncMedicalVendorType(true, false);
					break;
				case MedicalVendorApplicationFieldIndex.SpecializationId:
					DesetupSyncMvuserSpecialization(true, false);
					break;
				case MedicalVendorApplicationFieldIndex.CorrespondenceAddressId:
					DesetupSyncAddress_(true, false);
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
				case "Address_":
					this.Address_ = (AddressEntity)entity;
					break;
				case "Address":
					this.Address = (AddressEntity)entity;
					break;
				case "MedicalVendorType":
					this.MedicalVendorType = (MedicalVendorTypeEntity)entity;
					break;
				case "MvuserSpecialization":
					this.MvuserSpecialization = (MvuserSpecializationEntity)entity;
					break;
				case "MedicalVendorMvuser":
					this.MedicalVendorMvuser.Add((MedicalVendorMvuserEntity)entity);
					break;
				case "MedicalVendorNotes":
					this.MedicalVendorNotes.Add((MedicalVendorNotesEntity)entity);
					break;
				case "MedicalVendorUserNotes":
					this.MedicalVendorUserNotes.Add((MedicalVendorUserNotesEntity)entity);
					break;
				case "MedicalVendorCollectionViaMedicalVendorNotes":
					this.MedicalVendorCollectionViaMedicalVendorNotes.IsReadOnly = false;
					this.MedicalVendorCollectionViaMedicalVendorNotes.Add((MedicalVendorEntity)entity);
					this.MedicalVendorCollectionViaMedicalVendorNotes.IsReadOnly = true;
					break;
				case "MedicalVendorCollectionViaMedicalVendorMvuser":
					this.MedicalVendorCollectionViaMedicalVendorMvuser.IsReadOnly = false;
					this.MedicalVendorCollectionViaMedicalVendorMvuser.Add((MedicalVendorEntity)entity);
					this.MedicalVendorCollectionViaMedicalVendorMvuser.IsReadOnly = true;
					break;
				case "MvuserCollectionViaMedicalVendorMvuser":
					this.MvuserCollectionViaMedicalVendorMvuser.IsReadOnly = false;
					this.MvuserCollectionViaMedicalVendorMvuser.Add((MvuserEntity)entity);
					this.MvuserCollectionViaMedicalVendorMvuser.IsReadOnly = true;
					break;
				case "RoleCollectionViaMedicalVendorMvuser":
					this.RoleCollectionViaMedicalVendorMvuser.IsReadOnly = false;
					this.RoleCollectionViaMedicalVendorMvuser.Add((RoleEntity)entity);
					this.RoleCollectionViaMedicalVendorMvuser.IsReadOnly = true;
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
			return MedicalVendorApplicationEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Address_":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.AddressEntityUsingCorrespondenceAddressId);
					break;
				case "Address":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.AddressEntityUsingBusinessAddressId);
					break;
				case "MedicalVendorType":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.MedicalVendorTypeEntityUsingMedicalVendorTypeId);
					break;
				case "MvuserSpecialization":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.MvuserSpecializationEntityUsingSpecializationId);
					break;
				case "MedicalVendorMvuser":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.MedicalVendorMvuserEntityUsingApplicationId);
					break;
				case "MedicalVendorNotes":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.MedicalVendorNotesEntityUsingMedicalVendorAppId);
					break;
				case "MedicalVendorUserNotes":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.MedicalVendorUserNotesEntityUsingAppId);
					break;
				case "MedicalVendorCollectionViaMedicalVendorNotes":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.MedicalVendorNotesEntityUsingMedicalVendorAppId, "MedicalVendorApplicationEntity__", "MedicalVendorNotes_", JoinHint.None);
					toReturn.Add(MedicalVendorNotesEntity.Relations.MedicalVendorEntityUsingMedicalVendorId, "MedicalVendorNotes_", string.Empty, JoinHint.None);
					break;
				case "MedicalVendorCollectionViaMedicalVendorMvuser":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.MedicalVendorMvuserEntityUsingApplicationId, "MedicalVendorApplicationEntity__", "MedicalVendorMvuser_", JoinHint.None);
					toReturn.Add(MedicalVendorMvuserEntity.Relations.MedicalVendorEntityUsingMedicalVendorId, "MedicalVendorMvuser_", string.Empty, JoinHint.None);
					break;
				case "MvuserCollectionViaMedicalVendorMvuser":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.MedicalVendorMvuserEntityUsingApplicationId, "MedicalVendorApplicationEntity__", "MedicalVendorMvuser_", JoinHint.None);
					toReturn.Add(MedicalVendorMvuserEntity.Relations.MvuserEntityUsingMvuserId, "MedicalVendorMvuser_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaMedicalVendorMvuser":
					toReturn.Add(MedicalVendorApplicationEntity.Relations.MedicalVendorMvuserEntityUsingApplicationId, "MedicalVendorApplicationEntity__", "MedicalVendorMvuser_", JoinHint.None);
					toReturn.Add(MedicalVendorMvuserEntity.Relations.RoleEntityUsingRoleId, "MedicalVendorMvuser_", string.Empty, JoinHint.None);
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
				case "Address_":
					SetupSyncAddress_(relatedEntity);
					break;
				case "Address":
					SetupSyncAddress(relatedEntity);
					break;
				case "MedicalVendorType":
					SetupSyncMedicalVendorType(relatedEntity);
					break;
				case "MvuserSpecialization":
					SetupSyncMvuserSpecialization(relatedEntity);
					break;
				case "MedicalVendorMvuser":
					this.MedicalVendorMvuser.Add((MedicalVendorMvuserEntity)relatedEntity);
					break;
				case "MedicalVendorNotes":
					this.MedicalVendorNotes.Add((MedicalVendorNotesEntity)relatedEntity);
					break;
				case "MedicalVendorUserNotes":
					this.MedicalVendorUserNotes.Add((MedicalVendorUserNotesEntity)relatedEntity);
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
				case "Address_":
					DesetupSyncAddress_(false, true);
					break;
				case "Address":
					DesetupSyncAddress(false, true);
					break;
				case "MedicalVendorType":
					DesetupSyncMedicalVendorType(false, true);
					break;
				case "MvuserSpecialization":
					DesetupSyncMvuserSpecialization(false, true);
					break;
				case "MedicalVendorMvuser":
					base.PerformRelatedEntityRemoval(this.MedicalVendorMvuser, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicalVendorNotes":
					base.PerformRelatedEntityRemoval(this.MedicalVendorNotes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicalVendorUserNotes":
					base.PerformRelatedEntityRemoval(this.MedicalVendorUserNotes, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_address_!=null)
			{
				toReturn.Add(_address_);
			}
			if(_address!=null)
			{
				toReturn.Add(_address);
			}
			if(_medicalVendorType!=null)
			{
				toReturn.Add(_medicalVendorType);
			}
			if(_mvuserSpecialization!=null)
			{
				toReturn.Add(_mvuserSpecialization);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.MedicalVendorMvuser);
			toReturn.Add(this.MedicalVendorNotes);
			toReturn.Add(this.MedicalVendorUserNotes);

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
				info.AddValue("_medicalVendorMvuser", ((_medicalVendorMvuser!=null) && (_medicalVendorMvuser.Count>0) && !this.MarkedForDeletion)?_medicalVendorMvuser:null);
				info.AddValue("_medicalVendorNotes", ((_medicalVendorNotes!=null) && (_medicalVendorNotes.Count>0) && !this.MarkedForDeletion)?_medicalVendorNotes:null);
				info.AddValue("_medicalVendorUserNotes", ((_medicalVendorUserNotes!=null) && (_medicalVendorUserNotes.Count>0) && !this.MarkedForDeletion)?_medicalVendorUserNotes:null);
				info.AddValue("_medicalVendorCollectionViaMedicalVendorNotes", ((_medicalVendorCollectionViaMedicalVendorNotes!=null) && (_medicalVendorCollectionViaMedicalVendorNotes.Count>0) && !this.MarkedForDeletion)?_medicalVendorCollectionViaMedicalVendorNotes:null);
				info.AddValue("_medicalVendorCollectionViaMedicalVendorMvuser", ((_medicalVendorCollectionViaMedicalVendorMvuser!=null) && (_medicalVendorCollectionViaMedicalVendorMvuser.Count>0) && !this.MarkedForDeletion)?_medicalVendorCollectionViaMedicalVendorMvuser:null);
				info.AddValue("_mvuserCollectionViaMedicalVendorMvuser", ((_mvuserCollectionViaMedicalVendorMvuser!=null) && (_mvuserCollectionViaMedicalVendorMvuser.Count>0) && !this.MarkedForDeletion)?_mvuserCollectionViaMedicalVendorMvuser:null);
				info.AddValue("_roleCollectionViaMedicalVendorMvuser", ((_roleCollectionViaMedicalVendorMvuser!=null) && (_roleCollectionViaMedicalVendorMvuser.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaMedicalVendorMvuser:null);
				info.AddValue("_address_", (!this.MarkedForDeletion?_address_:null));
				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_medicalVendorType", (!this.MarkedForDeletion?_medicalVendorType:null));
				info.AddValue("_mvuserSpecialization", (!this.MarkedForDeletion?_mvuserSpecialization:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MedicalVendorApplicationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MedicalVendorApplicationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MedicalVendorApplicationRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendorMvuser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorMvuser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorMvuserFields.ApplicationId, null, ComparisonOperator.Equal, this.MedicalVendorApplicationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendorNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorNotesFields.MedicalVendorAppId, null, ComparisonOperator.Equal, this.MedicalVendorApplicationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendorUserNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorUserNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorUserNotesFields.AppId, null, ComparisonOperator.Equal, this.MedicalVendorApplicationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorCollectionViaMedicalVendorNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MedicalVendorCollectionViaMedicalVendorNotes"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorApplicationFields.MedicalVendorApplicationId, null, ComparisonOperator.Equal, this.MedicalVendorApplicationId, "MedicalVendorApplicationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalVendor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorCollectionViaMedicalVendorMvuser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MedicalVendorCollectionViaMedicalVendorMvuser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorApplicationFields.MedicalVendorApplicationId, null, ComparisonOperator.Equal, this.MedicalVendorApplicationId, "MedicalVendorApplicationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Mvuser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvuserCollectionViaMedicalVendorMvuser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MvuserCollectionViaMedicalVendorMvuser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorApplicationFields.MedicalVendorApplicationId, null, ComparisonOperator.Equal, this.MedicalVendorApplicationId, "MedicalVendorApplicationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaMedicalVendorMvuser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaMedicalVendorMvuser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorApplicationFields.MedicalVendorApplicationId, null, ComparisonOperator.Equal, this.MedicalVendorApplicationId, "MedicalVendorApplicationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.CorrespondenceAddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.BusinessAddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MedicalVendorType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorTypeFields.MedicalVendorTypeId, null, ComparisonOperator.Equal, this.MedicalVendorTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MvuserSpecialization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvuserSpecialization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MvuserSpecializationFields.MvuserSpecializationId, null, ComparisonOperator.Equal, this.SpecializationId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.MedicalVendorApplicationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorApplicationEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._medicalVendorMvuser);
			collectionsQueue.Enqueue(this._medicalVendorNotes);
			collectionsQueue.Enqueue(this._medicalVendorUserNotes);
			collectionsQueue.Enqueue(this._medicalVendorCollectionViaMedicalVendorNotes);
			collectionsQueue.Enqueue(this._medicalVendorCollectionViaMedicalVendorMvuser);
			collectionsQueue.Enqueue(this._mvuserCollectionViaMedicalVendorMvuser);
			collectionsQueue.Enqueue(this._roleCollectionViaMedicalVendorMvuser);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._medicalVendorMvuser = (EntityCollection<MedicalVendorMvuserEntity>) collectionsQueue.Dequeue();
			this._medicalVendorNotes = (EntityCollection<MedicalVendorNotesEntity>) collectionsQueue.Dequeue();
			this._medicalVendorUserNotes = (EntityCollection<MedicalVendorUserNotesEntity>) collectionsQueue.Dequeue();
			this._medicalVendorCollectionViaMedicalVendorNotes = (EntityCollection<MedicalVendorEntity>) collectionsQueue.Dequeue();
			this._medicalVendorCollectionViaMedicalVendorMvuser = (EntityCollection<MedicalVendorEntity>) collectionsQueue.Dequeue();
			this._mvuserCollectionViaMedicalVendorMvuser = (EntityCollection<MvuserEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaMedicalVendorMvuser = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._medicalVendorMvuser != null)
			{
				return true;
			}
			if (this._medicalVendorNotes != null)
			{
				return true;
			}
			if (this._medicalVendorUserNotes != null)
			{
				return true;
			}
			if (this._medicalVendorCollectionViaMedicalVendorNotes != null)
			{
				return true;
			}
			if (this._medicalVendorCollectionViaMedicalVendorMvuser != null)
			{
				return true;
			}
			if (this._mvuserCollectionViaMedicalVendorMvuser != null)
			{
				return true;
			}
			if (this._roleCollectionViaMedicalVendorMvuser != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorMvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorUserNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorUserNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MvuserEntityFactory))) : null);
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
			toReturn.Add("Address_", _address_);
			toReturn.Add("Address", _address);
			toReturn.Add("MedicalVendorType", _medicalVendorType);
			toReturn.Add("MvuserSpecialization", _mvuserSpecialization);
			toReturn.Add("MedicalVendorMvuser", _medicalVendorMvuser);
			toReturn.Add("MedicalVendorNotes", _medicalVendorNotes);
			toReturn.Add("MedicalVendorUserNotes", _medicalVendorUserNotes);
			toReturn.Add("MedicalVendorCollectionViaMedicalVendorNotes", _medicalVendorCollectionViaMedicalVendorNotes);
			toReturn.Add("MedicalVendorCollectionViaMedicalVendorMvuser", _medicalVendorCollectionViaMedicalVendorMvuser);
			toReturn.Add("MvuserCollectionViaMedicalVendorMvuser", _mvuserCollectionViaMedicalVendorMvuser);
			toReturn.Add("RoleCollectionViaMedicalVendorMvuser", _roleCollectionViaMedicalVendorMvuser);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_medicalVendorMvuser!=null)
			{
				_medicalVendorMvuser.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorNotes!=null)
			{
				_medicalVendorNotes.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorUserNotes!=null)
			{
				_medicalVendorUserNotes.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorCollectionViaMedicalVendorNotes!=null)
			{
				_medicalVendorCollectionViaMedicalVendorNotes.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorCollectionViaMedicalVendorMvuser!=null)
			{
				_medicalVendorCollectionViaMedicalVendorMvuser.ActiveContext = base.ActiveContext;
			}
			if(_mvuserCollectionViaMedicalVendorMvuser!=null)
			{
				_mvuserCollectionViaMedicalVendorMvuser.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaMedicalVendorMvuser!=null)
			{
				_roleCollectionViaMedicalVendorMvuser.ActiveContext = base.ActiveContext;
			}
			if(_address_!=null)
			{
				_address_.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorType!=null)
			{
				_medicalVendorType.ActiveContext = base.ActiveContext;
			}
			if(_mvuserSpecialization!=null)
			{
				_mvuserSpecialization.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_medicalVendorMvuser = null;
			_medicalVendorNotes = null;
			_medicalVendorUserNotes = null;
			_medicalVendorCollectionViaMedicalVendorNotes = null;
			_medicalVendorCollectionViaMedicalVendorMvuser = null;
			_mvuserCollectionViaMedicalVendorMvuser = null;
			_roleCollectionViaMedicalVendorMvuser = null;
			_address_ = null;
			_address = null;
			_medicalVendorType = null;
			_mvuserSpecialization = null;

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

			_fieldsCustomProperties.Add("MedicalVendorApplicationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BusinessName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BusinessAddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingAddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SpecializationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CorrespondenceAddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHome", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOffice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Resume", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Reference1Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Reference1Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Reference2Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Reference2Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Reference3Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Reference3Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BusinessPhone", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BusinessFax", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WorkFlowStageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WorkFlowStageTriggerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WorkFlowStageActivityTriggerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ssn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dob", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _address_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address_, new PropertyChangedEventHandler( OnAddress_PropertyChanged ), "Address_", MedicalVendorApplicationEntity.Relations.AddressEntityUsingCorrespondenceAddressId, true, signalRelatedEntity, "MedicalVendorApplication_", resetFKFields, new int[] { (int)MedicalVendorApplicationFieldIndex.CorrespondenceAddressId } );		
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
				base.PerformSetupSyncRelatedEntity( _address_, new PropertyChangedEventHandler( OnAddress_PropertyChanged ), "Address_", MedicalVendorApplicationEntity.Relations.AddressEntityUsingCorrespondenceAddressId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", MedicalVendorApplicationEntity.Relations.AddressEntityUsingBusinessAddressId, true, signalRelatedEntity, "MedicalVendorApplication", resetFKFields, new int[] { (int)MedicalVendorApplicationFieldIndex.BusinessAddressId } );		
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
				base.PerformSetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", MedicalVendorApplicationEntity.Relations.AddressEntityUsingBusinessAddressId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _medicalVendorType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicalVendorType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicalVendorType, new PropertyChangedEventHandler( OnMedicalVendorTypePropertyChanged ), "MedicalVendorType", MedicalVendorApplicationEntity.Relations.MedicalVendorTypeEntityUsingMedicalVendorTypeId, true, signalRelatedEntity, "MedicalVendorApplication", resetFKFields, new int[] { (int)MedicalVendorApplicationFieldIndex.MedicalVendorTypeId } );		
			_medicalVendorType = null;
		}

		/// <summary> setups the sync logic for member _medicalVendorType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicalVendorType(IEntity2 relatedEntity)
		{
			if(_medicalVendorType!=relatedEntity)
			{
				DesetupSyncMedicalVendorType(true, true);
				_medicalVendorType = (MedicalVendorTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicalVendorType, new PropertyChangedEventHandler( OnMedicalVendorTypePropertyChanged ), "MedicalVendorType", MedicalVendorApplicationEntity.Relations.MedicalVendorTypeEntityUsingMedicalVendorTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicalVendorTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _mvuserSpecialization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMvuserSpecialization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _mvuserSpecialization, new PropertyChangedEventHandler( OnMvuserSpecializationPropertyChanged ), "MvuserSpecialization", MedicalVendorApplicationEntity.Relations.MvuserSpecializationEntityUsingSpecializationId, true, signalRelatedEntity, "MedicalVendorApplication", resetFKFields, new int[] { (int)MedicalVendorApplicationFieldIndex.SpecializationId } );		
			_mvuserSpecialization = null;
		}

		/// <summary> setups the sync logic for member _mvuserSpecialization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMvuserSpecialization(IEntity2 relatedEntity)
		{
			if(_mvuserSpecialization!=relatedEntity)
			{
				DesetupSyncMvuserSpecialization(true, true);
				_mvuserSpecialization = (MvuserSpecializationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _mvuserSpecialization, new PropertyChangedEventHandler( OnMvuserSpecializationPropertyChanged ), "MvuserSpecialization", MedicalVendorApplicationEntity.Relations.MvuserSpecializationEntityUsingSpecializationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMvuserSpecializationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MedicalVendorApplicationEntity</param>
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
		public  static MedicalVendorApplicationRelations Relations
		{
			get	{ return new MedicalVendorApplicationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorMvuser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorMvuser
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicalVendorMvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorMvuser")[0], (int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.MedicalVendorMvuserEntity, 0, null, null, null, null, "MedicalVendorMvuser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorNotes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicalVendorNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorNotes")[0], (int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.MedicalVendorNotesEntity, 0, null, null, null, null, "MedicalVendorNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorUserNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorUserNotes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicalVendorUserNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorUserNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorUserNotes")[0], (int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.MedicalVendorUserNotesEntity, 0, null, null, null, null, "MedicalVendorUserNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorCollectionViaMedicalVendorNotes
		{
			get
			{
				IEntityRelation intermediateRelation = MedicalVendorApplicationEntity.Relations.MedicalVendorNotesEntityUsingMedicalVendorAppId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorNotes_");
				return new PrefetchPathElement2(new EntityCollection<MedicalVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.MedicalVendorEntity, 0, null, null, GetRelationsForField("MedicalVendorCollectionViaMedicalVendorNotes"), null, "MedicalVendorCollectionViaMedicalVendorNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorCollectionViaMedicalVendorMvuser
		{
			get
			{
				IEntityRelation intermediateRelation = MedicalVendorApplicationEntity.Relations.MedicalVendorMvuserEntityUsingApplicationId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorMvuser_");
				return new PrefetchPathElement2(new EntityCollection<MedicalVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.MedicalVendorEntity, 0, null, null, GetRelationsForField("MedicalVendorCollectionViaMedicalVendorMvuser"), null, "MedicalVendorCollectionViaMedicalVendorMvuser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Mvuser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvuserCollectionViaMedicalVendorMvuser
		{
			get
			{
				IEntityRelation intermediateRelation = MedicalVendorApplicationEntity.Relations.MedicalVendorMvuserEntityUsingApplicationId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorMvuser_");
				return new PrefetchPathElement2(new EntityCollection<MvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MvuserEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.MvuserEntity, 0, null, null, GetRelationsForField("MvuserCollectionViaMedicalVendorMvuser"), null, "MvuserCollectionViaMedicalVendorMvuser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaMedicalVendorMvuser
		{
			get
			{
				IEntityRelation intermediateRelation = MedicalVendorApplicationEntity.Relations.MedicalVendorMvuserEntityUsingApplicationId;
				intermediateRelation.SetAliases(string.Empty, "MedicalVendorMvuser_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaMedicalVendorMvuser"), null, "RoleCollectionViaMedicalVendorMvuser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Address_")[0], (int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Address")[0], (int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorType")[0], (int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.MedicalVendorTypeEntity, 0, null, null, null, null, "MedicalVendorType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MvuserSpecialization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvuserSpecialization
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MvuserSpecializationEntityFactory))),
					(IEntityRelation)GetRelationsForField("MvuserSpecialization")[0], (int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity, (int)HealthYes.Data.EntityType.MvuserSpecializationEntity, 0, null, null, null, null, "MvuserSpecialization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MedicalVendorApplicationEntity.CustomProperties;}
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
			get { return MedicalVendorApplicationEntity.FieldsCustomProperties;}
		}

		/// <summary> The MedicalVendorApplicationId property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."MedicalVendorApplicationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MedicalVendorApplicationId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorApplicationFieldIndex.MedicalVendorApplicationId, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.MedicalVendorApplicationId, value); }
		}

		/// <summary> The BusinessName property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."BusinessName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BusinessName
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.BusinessName, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.BusinessName, value); }
		}

		/// <summary> The BusinessAddressId property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."BusinessAddressID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BusinessAddressId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MedicalVendorApplicationFieldIndex.BusinessAddressId, false); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.BusinessAddressId, value); }
		}

		/// <summary> The BillingAddressId property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."BillingAddressID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BillingAddressId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MedicalVendorApplicationFieldIndex.BillingAddressId, false); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.BillingAddressId, value); }
		}

		/// <summary> The MedicalVendorTypeId property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."MedicalVendorTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MedicalVendorTypeId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorApplicationFieldIndex.MedicalVendorTypeId, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.MedicalVendorTypeId, value); }
		}

		/// <summary> The FirstName property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.FirstName, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."MiddleName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.MiddleName, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.MiddleName, value); }
		}

		/// <summary> The LastName property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.LastName, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.LastName, value); }
		}

		/// <summary> The SpecializationId property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."SpecializationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SpecializationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MedicalVendorApplicationFieldIndex.SpecializationId, false); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.SpecializationId, value); }
		}

		/// <summary> The CorrespondenceAddressId property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."CorrespondenceAddressID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CorrespondenceAddressId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorApplicationFieldIndex.CorrespondenceAddressId, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.CorrespondenceAddressId, value); }
		}

		/// <summary> The PhoneCell property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."PhoneCell"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneHome property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."PhoneHome"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneHome
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.PhoneHome, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.PhoneHome, value); }
		}

		/// <summary> The PhoneOffice property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."PhoneOffice"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOffice
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.PhoneOffice, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.PhoneOffice, value); }
		}

		/// <summary> The Email1 property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."Email1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Email1
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Email1, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Email1, value); }
		}

		/// <summary> The Email2 property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."Email2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email2
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Email2, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Email2, value); }
		}

		/// <summary> The Resume property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."Resume"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Resume
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Resume, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Resume, value); }
		}

		/// <summary> The Reference1Name property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."Reference1Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Reference1Name
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Reference1Name, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Reference1Name, value); }
		}

		/// <summary> The Reference1Email property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."Reference1EMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Reference1Email
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Reference1Email, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Reference1Email, value); }
		}

		/// <summary> The Reference2Name property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."Reference2Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Reference2Name
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Reference2Name, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Reference2Name, value); }
		}

		/// <summary> The Reference2Email property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."Reference2EMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Reference2Email
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Reference2Email, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Reference2Email, value); }
		}

		/// <summary> The Reference3Name property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."Reference3Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Reference3Name
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Reference3Name, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Reference3Name, value); }
		}

		/// <summary> The Reference3Email property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."Reference3EMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Reference3Email
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Reference3Email, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Reference3Email, value); }
		}

		/// <summary> The BusinessPhone property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."BusinessPhone"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BusinessPhone
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.BusinessPhone, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.BusinessPhone, value); }
		}

		/// <summary> The BusinessFax property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."BusinessFax"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BusinessFax
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.BusinessFax, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.BusinessFax, value); }
		}

		/// <summary> The WorkFlowStageId property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."WorkFlowStageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 WorkFlowStageId
		{
			get { return (System.Int64)GetValue((int)MedicalVendorApplicationFieldIndex.WorkFlowStageId, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.WorkFlowStageId, value); }
		}

		/// <summary> The WorkFlowStageTriggerId property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."WorkFlowStageTriggerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> WorkFlowStageTriggerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MedicalVendorApplicationFieldIndex.WorkFlowStageTriggerId, false); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.WorkFlowStageTriggerId, value); }
		}

		/// <summary> The WorkFlowStageActivityTriggerId property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."WorkFlowStageActivityTriggerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> WorkFlowStageActivityTriggerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MedicalVendorApplicationFieldIndex.WorkFlowStageActivityTriggerId, false); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.WorkFlowStageActivityTriggerId, value); }
		}

		/// <summary> The DateCreated property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MedicalVendorApplicationFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MedicalVendorApplicationFieldIndex.DateModified, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.DateModified, value); }
		}

		/// <summary> The Ssn property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."SSN"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Ssn
		{
			get { return (System.String)GetValue((int)MedicalVendorApplicationFieldIndex.Ssn, true); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Ssn, value); }
		}

		/// <summary> The Dob property of the Entity MedicalVendorApplication<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMedicalVendorApplication"."DOB"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Dob
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MedicalVendorApplicationFieldIndex.Dob, false); }
			set	{ SetValue((int)MedicalVendorApplicationFieldIndex.Dob, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorMvuserEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorMvuserEntity))]
		public virtual EntityCollection<MedicalVendorMvuserEntity> MedicalVendorMvuser
		{
			get
			{
				if(_medicalVendorMvuser==null)
				{
					_medicalVendorMvuser = new EntityCollection<MedicalVendorMvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorMvuserEntityFactory)));
					_medicalVendorMvuser.SetContainingEntityInfo(this, "MedicalVendorApplication");
				}
				return _medicalVendorMvuser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorNotesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorNotesEntity))]
		public virtual EntityCollection<MedicalVendorNotesEntity> MedicalVendorNotes
		{
			get
			{
				if(_medicalVendorNotes==null)
				{
					_medicalVendorNotes = new EntityCollection<MedicalVendorNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorNotesEntityFactory)));
					_medicalVendorNotes.SetContainingEntityInfo(this, "MedicalVendorApplication");
				}
				return _medicalVendorNotes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorUserNotesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorUserNotesEntity))]
		public virtual EntityCollection<MedicalVendorUserNotesEntity> MedicalVendorUserNotes
		{
			get
			{
				if(_medicalVendorUserNotes==null)
				{
					_medicalVendorUserNotes = new EntityCollection<MedicalVendorUserNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorUserNotesEntityFactory)));
					_medicalVendorUserNotes.SetContainingEntityInfo(this, "MedicalVendorApplication");
				}
				return _medicalVendorUserNotes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorEntity))]
		public virtual EntityCollection<MedicalVendorEntity> MedicalVendorCollectionViaMedicalVendorNotes
		{
			get
			{
				if(_medicalVendorCollectionViaMedicalVendorNotes==null)
				{
					_medicalVendorCollectionViaMedicalVendorNotes = new EntityCollection<MedicalVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorEntityFactory)));
					_medicalVendorCollectionViaMedicalVendorNotes.IsReadOnly=true;
				}
				return _medicalVendorCollectionViaMedicalVendorNotes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalVendorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalVendorEntity))]
		public virtual EntityCollection<MedicalVendorEntity> MedicalVendorCollectionViaMedicalVendorMvuser
		{
			get
			{
				if(_medicalVendorCollectionViaMedicalVendorMvuser==null)
				{
					_medicalVendorCollectionViaMedicalVendorMvuser = new EntityCollection<MedicalVendorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorEntityFactory)));
					_medicalVendorCollectionViaMedicalVendorMvuser.IsReadOnly=true;
				}
				return _medicalVendorCollectionViaMedicalVendorMvuser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MvuserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MvuserEntity))]
		public virtual EntityCollection<MvuserEntity> MvuserCollectionViaMedicalVendorMvuser
		{
			get
			{
				if(_mvuserCollectionViaMedicalVendorMvuser==null)
				{
					_mvuserCollectionViaMedicalVendorMvuser = new EntityCollection<MvuserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MvuserEntityFactory)));
					_mvuserCollectionViaMedicalVendorMvuser.IsReadOnly=true;
				}
				return _mvuserCollectionViaMedicalVendorMvuser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaMedicalVendorMvuser
		{
			get
			{
				if(_roleCollectionViaMedicalVendorMvuser==null)
				{
					_roleCollectionViaMedicalVendorMvuser = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaMedicalVendorMvuser.IsReadOnly=true;
				}
				return _roleCollectionViaMedicalVendorMvuser;
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
							_address_.UnsetRelatedEntity(this, "MedicalVendorApplication_");
						}
					}
					else
					{
						if(_address_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorApplication_");
						}
					}
				}
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
							_address.UnsetRelatedEntity(this, "MedicalVendorApplication");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorApplication");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MedicalVendorTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicalVendorTypeEntity MedicalVendorType
		{
			get
			{
				return _medicalVendorType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicalVendorType(value);
				}
				else
				{
					if(value==null)
					{
						if(_medicalVendorType != null)
						{
							_medicalVendorType.UnsetRelatedEntity(this, "MedicalVendorApplication");
						}
					}
					else
					{
						if(_medicalVendorType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorApplication");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MvuserSpecializationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MvuserSpecializationEntity MvuserSpecialization
		{
			get
			{
				return _mvuserSpecialization;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMvuserSpecialization(value);
				}
				else
				{
					if(value==null)
					{
						if(_mvuserSpecialization != null)
						{
							_mvuserSpecialization.UnsetRelatedEntity(this, "MedicalVendorApplication");
						}
					}
					else
					{
						if(_mvuserSpecialization!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MedicalVendorApplication");
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
		
		/// <summary>Returns the HealthYes.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)HealthYes.Data.EntityType.MedicalVendorApplicationEntity; }
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
