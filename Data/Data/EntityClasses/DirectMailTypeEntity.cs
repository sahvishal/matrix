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
	/// Entity class which represents the entity 'DirectMailType'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class DirectMailTypeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CampaignActivityEntity> _campaignActivity;
		private EntityCollection<DirectMailEntity> _directMail;
		private EntityCollection<CallUploadEntity> _callUploadCollectionViaDirectMail;
		private EntityCollection<CampaignEntity> _campaignCollectionViaDirectMail;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCampaignActivity;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaDirectMail;
		private EntityCollection<LookupEntity> _lookupCollectionViaCampaignActivity;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaDirectMail;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCampaignActivity;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCampaignActivity_;
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
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CampaignActivity</summary>
			public static readonly string CampaignActivity = "CampaignActivity";
			/// <summary>Member name DirectMail</summary>
			public static readonly string DirectMail = "DirectMail";
			/// <summary>Member name CallUploadCollectionViaDirectMail</summary>
			public static readonly string CallUploadCollectionViaDirectMail = "CallUploadCollectionViaDirectMail";
			/// <summary>Member name CampaignCollectionViaDirectMail</summary>
			public static readonly string CampaignCollectionViaDirectMail = "CampaignCollectionViaDirectMail";
			/// <summary>Member name CampaignCollectionViaCampaignActivity</summary>
			public static readonly string CampaignCollectionViaCampaignActivity = "CampaignCollectionViaCampaignActivity";
			/// <summary>Member name CustomerProfileCollectionViaDirectMail</summary>
			public static readonly string CustomerProfileCollectionViaDirectMail = "CustomerProfileCollectionViaDirectMail";
			/// <summary>Member name LookupCollectionViaCampaignActivity</summary>
			public static readonly string LookupCollectionViaCampaignActivity = "LookupCollectionViaCampaignActivity";
			/// <summary>Member name OrganizationRoleUserCollectionViaDirectMail</summary>
			public static readonly string OrganizationRoleUserCollectionViaDirectMail = "OrganizationRoleUserCollectionViaDirectMail";
			/// <summary>Member name OrganizationRoleUserCollectionViaCampaignActivity</summary>
			public static readonly string OrganizationRoleUserCollectionViaCampaignActivity = "OrganizationRoleUserCollectionViaCampaignActivity";
			/// <summary>Member name OrganizationRoleUserCollectionViaCampaignActivity_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCampaignActivity_ = "OrganizationRoleUserCollectionViaCampaignActivity_";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static DirectMailTypeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public DirectMailTypeEntity():base("DirectMailTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public DirectMailTypeEntity(IEntityFields2 fields):base("DirectMailTypeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this DirectMailTypeEntity</param>
		public DirectMailTypeEntity(IValidator validator):base("DirectMailTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for DirectMailType which data should be fetched into this DirectMailType object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public DirectMailTypeEntity(System.Int64 id):base("DirectMailTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for DirectMailType which data should be fetched into this DirectMailType object</param>
		/// <param name="validator">The custom validator object for this DirectMailTypeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public DirectMailTypeEntity(System.Int64 id, IValidator validator):base("DirectMailTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected DirectMailTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_campaignActivity = (EntityCollection<CampaignActivityEntity>)info.GetValue("_campaignActivity", typeof(EntityCollection<CampaignActivityEntity>));
				_directMail = (EntityCollection<DirectMailEntity>)info.GetValue("_directMail", typeof(EntityCollection<DirectMailEntity>));
				_callUploadCollectionViaDirectMail = (EntityCollection<CallUploadEntity>)info.GetValue("_callUploadCollectionViaDirectMail", typeof(EntityCollection<CallUploadEntity>));
				_campaignCollectionViaDirectMail = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaDirectMail", typeof(EntityCollection<CampaignEntity>));
				_campaignCollectionViaCampaignActivity = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCampaignActivity", typeof(EntityCollection<CampaignEntity>));
				_customerProfileCollectionViaDirectMail = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaDirectMail", typeof(EntityCollection<CustomerProfileEntity>));
				_lookupCollectionViaCampaignActivity = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCampaignActivity", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaDirectMail = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaDirectMail", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCampaignActivity = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCampaignActivity", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCampaignActivity_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCampaignActivity_", typeof(EntityCollection<OrganizationRoleUserEntity>));
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
			switch((DirectMailTypeFieldIndex)fieldIndex)
			{
				case DirectMailTypeFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case DirectMailTypeFieldIndex.ModifiedBy:
					DesetupSyncOrganizationRoleUser_(true, false);
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
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CampaignActivity":
					this.CampaignActivity.Add((CampaignActivityEntity)entity);
					break;
				case "DirectMail":
					this.DirectMail.Add((DirectMailEntity)entity);
					break;
				case "CallUploadCollectionViaDirectMail":
					this.CallUploadCollectionViaDirectMail.IsReadOnly = false;
					this.CallUploadCollectionViaDirectMail.Add((CallUploadEntity)entity);
					this.CallUploadCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "CampaignCollectionViaDirectMail":
					this.CampaignCollectionViaDirectMail.IsReadOnly = false;
					this.CampaignCollectionViaDirectMail.Add((CampaignEntity)entity);
					this.CampaignCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "CampaignCollectionViaCampaignActivity":
					this.CampaignCollectionViaCampaignActivity.IsReadOnly = false;
					this.CampaignCollectionViaCampaignActivity.Add((CampaignEntity)entity);
					this.CampaignCollectionViaCampaignActivity.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaDirectMail":
					this.CustomerProfileCollectionViaDirectMail.IsReadOnly = false;
					this.CustomerProfileCollectionViaDirectMail.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "LookupCollectionViaCampaignActivity":
					this.LookupCollectionViaCampaignActivity.IsReadOnly = false;
					this.LookupCollectionViaCampaignActivity.Add((LookupEntity)entity);
					this.LookupCollectionViaCampaignActivity.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaDirectMail":
					this.OrganizationRoleUserCollectionViaDirectMail.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaDirectMail.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivity":
					this.OrganizationRoleUserCollectionViaCampaignActivity.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCampaignActivity.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCampaignActivity.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivity_":
					this.OrganizationRoleUserCollectionViaCampaignActivity_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCampaignActivity_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCampaignActivity_.IsReadOnly = true;
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
			return DirectMailTypeEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser_":
					toReturn.Add(DirectMailTypeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(DirectMailTypeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "CampaignActivity":
					toReturn.Add(DirectMailTypeEntity.Relations.CampaignActivityEntityUsingDirectMailTypeId);
					break;
				case "DirectMail":
					toReturn.Add(DirectMailTypeEntity.Relations.DirectMailEntityUsingDirectMailTypeId);
					break;
				case "CallUploadCollectionViaDirectMail":
					toReturn.Add(DirectMailTypeEntity.Relations.DirectMailEntityUsingDirectMailTypeId, "DirectMailTypeEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.CallUploadEntityUsingCallUploadId, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaDirectMail":
					toReturn.Add(DirectMailTypeEntity.Relations.DirectMailEntityUsingDirectMailTypeId, "DirectMailTypeEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.CampaignEntityUsingCampaignId, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCampaignActivity":
					toReturn.Add(DirectMailTypeEntity.Relations.CampaignActivityEntityUsingDirectMailTypeId, "DirectMailTypeEntity__", "CampaignActivity_", JoinHint.None);
					toReturn.Add(CampaignActivityEntity.Relations.CampaignEntityUsingCampaignId, "CampaignActivity_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaDirectMail":
					toReturn.Add(DirectMailTypeEntity.Relations.DirectMailEntityUsingDirectMailTypeId, "DirectMailTypeEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.CustomerProfileEntityUsingCustomerId, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCampaignActivity":
					toReturn.Add(DirectMailTypeEntity.Relations.CampaignActivityEntityUsingDirectMailTypeId, "DirectMailTypeEntity__", "CampaignActivity_", JoinHint.None);
					toReturn.Add(CampaignActivityEntity.Relations.LookupEntityUsingTypeId, "CampaignActivity_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaDirectMail":
					toReturn.Add(DirectMailTypeEntity.Relations.DirectMailEntityUsingDirectMailTypeId, "DirectMailTypeEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.OrganizationRoleUserEntityUsingMailedBy, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivity":
					toReturn.Add(DirectMailTypeEntity.Relations.CampaignActivityEntityUsingDirectMailTypeId, "DirectMailTypeEntity__", "CampaignActivity_", JoinHint.None);
					toReturn.Add(CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingCreatedby, "CampaignActivity_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivity_":
					toReturn.Add(DirectMailTypeEntity.Relations.CampaignActivityEntityUsingDirectMailTypeId, "DirectMailTypeEntity__", "CampaignActivity_", JoinHint.None);
					toReturn.Add(CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingModifiedby, "CampaignActivity_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CampaignActivity":
					this.CampaignActivity.Add((CampaignActivityEntity)relatedEntity);
					break;
				case "DirectMail":
					this.DirectMail.Add((DirectMailEntity)relatedEntity);
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
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CampaignActivity":
					base.PerformRelatedEntityRemoval(this.CampaignActivity, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DirectMail":
					base.PerformRelatedEntityRemoval(this.DirectMail, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CampaignActivity);
			toReturn.Add(this.DirectMail);

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
				info.AddValue("_campaignActivity", ((_campaignActivity!=null) && (_campaignActivity.Count>0) && !this.MarkedForDeletion)?_campaignActivity:null);
				info.AddValue("_directMail", ((_directMail!=null) && (_directMail.Count>0) && !this.MarkedForDeletion)?_directMail:null);
				info.AddValue("_callUploadCollectionViaDirectMail", ((_callUploadCollectionViaDirectMail!=null) && (_callUploadCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_callUploadCollectionViaDirectMail:null);
				info.AddValue("_campaignCollectionViaDirectMail", ((_campaignCollectionViaDirectMail!=null) && (_campaignCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaDirectMail:null);
				info.AddValue("_campaignCollectionViaCampaignActivity", ((_campaignCollectionViaCampaignActivity!=null) && (_campaignCollectionViaCampaignActivity.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCampaignActivity:null);
				info.AddValue("_customerProfileCollectionViaDirectMail", ((_customerProfileCollectionViaDirectMail!=null) && (_customerProfileCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaDirectMail:null);
				info.AddValue("_lookupCollectionViaCampaignActivity", ((_lookupCollectionViaCampaignActivity!=null) && (_lookupCollectionViaCampaignActivity.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCampaignActivity:null);
				info.AddValue("_organizationRoleUserCollectionViaDirectMail", ((_organizationRoleUserCollectionViaDirectMail!=null) && (_organizationRoleUserCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaDirectMail:null);
				info.AddValue("_organizationRoleUserCollectionViaCampaignActivity", ((_organizationRoleUserCollectionViaCampaignActivity!=null) && (_organizationRoleUserCollectionViaCampaignActivity.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCampaignActivity:null);
				info.AddValue("_organizationRoleUserCollectionViaCampaignActivity_", ((_organizationRoleUserCollectionViaCampaignActivity_!=null) && (_organizationRoleUserCollectionViaCampaignActivity_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCampaignActivity_:null);
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
		public bool TestOriginalFieldValueForNull(DirectMailTypeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(DirectMailTypeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new DirectMailTypeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CampaignActivity' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignActivityFields.DirectMailTypeId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DirectMail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailFields.DirectMailTypeId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallUpload' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallUploadCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallUploadCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.Id, "DirectMailTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.Id, "DirectMailTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCampaignActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCampaignActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.Id, "DirectMailTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.Id, "DirectMailTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCampaignActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCampaignActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.Id, "DirectMailTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.Id, "DirectMailTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCampaignActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCampaignActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.Id, "DirectMailTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCampaignActivity_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCampaignActivity_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.Id, "DirectMailTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedBy));
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

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.DirectMailTypeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._campaignActivity);
			collectionsQueue.Enqueue(this._directMail);
			collectionsQueue.Enqueue(this._callUploadCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._campaignCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._campaignCollectionViaCampaignActivity);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._lookupCollectionViaCampaignActivity);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCampaignActivity);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCampaignActivity_);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._campaignActivity = (EntityCollection<CampaignActivityEntity>) collectionsQueue.Dequeue();
			this._directMail = (EntityCollection<DirectMailEntity>) collectionsQueue.Dequeue();
			this._callUploadCollectionViaDirectMail = (EntityCollection<CallUploadEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaDirectMail = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCampaignActivity = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaDirectMail = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCampaignActivity = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaDirectMail = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCampaignActivity = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCampaignActivity_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._campaignActivity != null)
			{
				return true;
			}
			if (this._directMail != null)
			{
				return true;
			}
			if (this._callUploadCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._campaignCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._campaignCollectionViaCampaignActivity != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCampaignActivity != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCampaignActivity != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCampaignActivity_ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CampaignActivity", _campaignActivity);
			toReturn.Add("DirectMail", _directMail);
			toReturn.Add("CallUploadCollectionViaDirectMail", _callUploadCollectionViaDirectMail);
			toReturn.Add("CampaignCollectionViaDirectMail", _campaignCollectionViaDirectMail);
			toReturn.Add("CampaignCollectionViaCampaignActivity", _campaignCollectionViaCampaignActivity);
			toReturn.Add("CustomerProfileCollectionViaDirectMail", _customerProfileCollectionViaDirectMail);
			toReturn.Add("LookupCollectionViaCampaignActivity", _lookupCollectionViaCampaignActivity);
			toReturn.Add("OrganizationRoleUserCollectionViaDirectMail", _organizationRoleUserCollectionViaDirectMail);
			toReturn.Add("OrganizationRoleUserCollectionViaCampaignActivity", _organizationRoleUserCollectionViaCampaignActivity);
			toReturn.Add("OrganizationRoleUserCollectionViaCampaignActivity_", _organizationRoleUserCollectionViaCampaignActivity_);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_campaignActivity!=null)
			{
				_campaignActivity.ActiveContext = base.ActiveContext;
			}
			if(_directMail!=null)
			{
				_directMail.ActiveContext = base.ActiveContext;
			}
			if(_callUploadCollectionViaDirectMail!=null)
			{
				_callUploadCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaDirectMail!=null)
			{
				_campaignCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaCampaignActivity!=null)
			{
				_campaignCollectionViaCampaignActivity.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaDirectMail!=null)
			{
				_customerProfileCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCampaignActivity!=null)
			{
				_lookupCollectionViaCampaignActivity.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaDirectMail!=null)
			{
				_organizationRoleUserCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCampaignActivity!=null)
			{
				_organizationRoleUserCollectionViaCampaignActivity.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCampaignActivity_!=null)
			{
				_organizationRoleUserCollectionViaCampaignActivity_.ActiveContext = base.ActiveContext;
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

			_campaignActivity = null;
			_directMail = null;
			_callUploadCollectionViaDirectMail = null;
			_campaignCollectionViaDirectMail = null;
			_campaignCollectionViaCampaignActivity = null;
			_customerProfileCollectionViaDirectMail = null;
			_lookupCollectionViaCampaignActivity = null;
			_organizationRoleUserCollectionViaDirectMail = null;
			_organizationRoleUserCollectionViaCampaignActivity = null;
			_organizationRoleUserCollectionViaCampaignActivity_ = null;
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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", DirectMailTypeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "DirectMailType_", resetFKFields, new int[] { (int)DirectMailTypeFieldIndex.ModifiedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", DirectMailTypeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", DirectMailTypeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "DirectMailType", resetFKFields, new int[] { (int)DirectMailTypeFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", DirectMailTypeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this DirectMailTypeEntity</param>
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
		public  static DirectMailTypeRelations Relations
		{
			get	{ return new DirectMailTypeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CampaignActivity' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignActivity
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CampaignActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory))),
					(IEntityRelation)GetRelationsForField("CampaignActivity")[0], (int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.CampaignActivityEntity, 0, null, null, null, null, "CampaignActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DirectMail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDirectMail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<DirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory))),
					(IEntityRelation)GetRelationsForField("DirectMail")[0], (int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.DirectMailEntity, 0, null, null, null, null, "DirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallUploadCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = DirectMailTypeEntity.Relations.DirectMailEntityUsingDirectMailTypeId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<CallUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.CallUploadEntity, 0, null, null, GetRelationsForField("CallUploadCollectionViaDirectMail"), null, "CallUploadCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = DirectMailTypeEntity.Relations.DirectMailEntityUsingDirectMailTypeId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaDirectMail"), null, "CampaignCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCampaignActivity
		{
			get
			{
				IEntityRelation intermediateRelation = DirectMailTypeEntity.Relations.CampaignActivityEntityUsingDirectMailTypeId;
				intermediateRelation.SetAliases(string.Empty, "CampaignActivity_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCampaignActivity"), null, "CampaignCollectionViaCampaignActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = DirectMailTypeEntity.Relations.DirectMailEntityUsingDirectMailTypeId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaDirectMail"), null, "CustomerProfileCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCampaignActivity
		{
			get
			{
				IEntityRelation intermediateRelation = DirectMailTypeEntity.Relations.CampaignActivityEntityUsingDirectMailTypeId;
				intermediateRelation.SetAliases(string.Empty, "CampaignActivity_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCampaignActivity"), null, "LookupCollectionViaCampaignActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = DirectMailTypeEntity.Relations.DirectMailEntityUsingDirectMailTypeId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaDirectMail"), null, "OrganizationRoleUserCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCampaignActivity
		{
			get
			{
				IEntityRelation intermediateRelation = DirectMailTypeEntity.Relations.CampaignActivityEntityUsingDirectMailTypeId;
				intermediateRelation.SetAliases(string.Empty, "CampaignActivity_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCampaignActivity"), null, "OrganizationRoleUserCollectionViaCampaignActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCampaignActivity_
		{
			get
			{
				IEntityRelation intermediateRelation = DirectMailTypeEntity.Relations.CampaignActivityEntityUsingDirectMailTypeId;
				intermediateRelation.SetAliases(string.Empty, "CampaignActivity_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCampaignActivity_"), null, "OrganizationRoleUserCollectionViaCampaignActivity_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.DirectMailTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return DirectMailTypeEntity.CustomProperties;}
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
			get { return DirectMailTypeEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity DirectMailType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMailType"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)DirectMailTypeFieldIndex.Id, true); }
			set	{ SetValue((int)DirectMailTypeFieldIndex.Id, value); }
		}

		/// <summary> The Name property of the Entity DirectMailType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMailType"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)DirectMailTypeFieldIndex.Name, true); }
			set	{ SetValue((int)DirectMailTypeFieldIndex.Name, value); }
		}

		/// <summary> The Alias property of the Entity DirectMailType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMailType"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)DirectMailTypeFieldIndex.Alias, true); }
			set	{ SetValue((int)DirectMailTypeFieldIndex.Alias, value); }
		}

		/// <summary> The DateCreated property of the Entity DirectMailType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMailType"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)DirectMailTypeFieldIndex.DateCreated, true); }
			set	{ SetValue((int)DirectMailTypeFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedBy property of the Entity DirectMailType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMailType"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)DirectMailTypeFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)DirectMailTypeFieldIndex.CreatedBy, value); }
		}

		/// <summary> The DateModified property of the Entity DirectMailType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMailType"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)DirectMailTypeFieldIndex.DateModified, false); }
			set	{ SetValue((int)DirectMailTypeFieldIndex.DateModified, value); }
		}

		/// <summary> The ModifiedBy property of the Entity DirectMailType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMailType"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)DirectMailTypeFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)DirectMailTypeFieldIndex.ModifiedBy, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignActivityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignActivityEntity))]
		public virtual EntityCollection<CampaignActivityEntity> CampaignActivity
		{
			get
			{
				if(_campaignActivity==null)
				{
					_campaignActivity = new EntityCollection<CampaignActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory)));
					_campaignActivity.SetContainingEntityInfo(this, "DirectMailType");
				}
				return _campaignActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DirectMailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DirectMailEntity))]
		public virtual EntityCollection<DirectMailEntity> DirectMail
		{
			get
			{
				if(_directMail==null)
				{
					_directMail = new EntityCollection<DirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory)));
					_directMail.SetContainingEntityInfo(this, "DirectMailType");
				}
				return _directMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallUploadEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallUploadEntity))]
		public virtual EntityCollection<CallUploadEntity> CallUploadCollectionViaDirectMail
		{
			get
			{
				if(_callUploadCollectionViaDirectMail==null)
				{
					_callUploadCollectionViaDirectMail = new EntityCollection<CallUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadEntityFactory)));
					_callUploadCollectionViaDirectMail.IsReadOnly=true;
				}
				return _callUploadCollectionViaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaDirectMail
		{
			get
			{
				if(_campaignCollectionViaDirectMail==null)
				{
					_campaignCollectionViaDirectMail = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaDirectMail.IsReadOnly=true;
				}
				return _campaignCollectionViaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaCampaignActivity
		{
			get
			{
				if(_campaignCollectionViaCampaignActivity==null)
				{
					_campaignCollectionViaCampaignActivity = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaCampaignActivity.IsReadOnly=true;
				}
				return _campaignCollectionViaCampaignActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaDirectMail
		{
			get
			{
				if(_customerProfileCollectionViaDirectMail==null)
				{
					_customerProfileCollectionViaDirectMail = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaDirectMail.IsReadOnly=true;
				}
				return _customerProfileCollectionViaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCampaignActivity
		{
			get
			{
				if(_lookupCollectionViaCampaignActivity==null)
				{
					_lookupCollectionViaCampaignActivity = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCampaignActivity.IsReadOnly=true;
				}
				return _lookupCollectionViaCampaignActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaDirectMail
		{
			get
			{
				if(_organizationRoleUserCollectionViaDirectMail==null)
				{
					_organizationRoleUserCollectionViaDirectMail = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaDirectMail.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCampaignActivity
		{
			get
			{
				if(_organizationRoleUserCollectionViaCampaignActivity==null)
				{
					_organizationRoleUserCollectionViaCampaignActivity = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCampaignActivity.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCampaignActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCampaignActivity_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCampaignActivity_==null)
				{
					_organizationRoleUserCollectionViaCampaignActivity_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCampaignActivity_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCampaignActivity_;
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "DirectMailType_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "DirectMailType_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "DirectMailType");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "DirectMailType");
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
			get { return (int)Falcon.Data.EntityType.DirectMailTypeEntity; }
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
